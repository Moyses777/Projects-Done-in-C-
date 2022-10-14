using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDAppDependencyInversionPrinciple
{
    public enum Relationship
    {
        Parent, Child, Sibling
    }

    public class person
    {
        public string Name;
        
    }

    // Low level

    public interface IRelationshipBrowser
    {
        IEnumerable<person> findAllChildrenOf(string name);
    }

    public class Relationships : IRelationshipBrowser
    {
        private List<(person, Relationship, person)> relations = new List<(person, Relationship, person)>();

        public void addParentRelation(person parent, person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public IEnumerable<person> findAllChildrenOf(string name) => relations.Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent).Select(x => x.Item3);

    }

    class Research
    {

        public Research(IRelationshipBrowser browser)
        {
            foreach(var brow in browser.findAllChildrenOf("David"))
            {
                Console.WriteLine($"David has a child called { brow.Name }");
            }
        }

        static void Main(string[] args)
        {
            person child = new person() { Name = "Goerge" };
            person child2 = new person() { Name = "Mary" };
            person parent = new person() { Name = "David" };

            var relationships = new Relationships();
            relationships.addParentRelation(parent, child);
            relationships.addParentRelation(parent, child2);

            new Research(relationships);
            Console.ReadKey();

        }
    }
}
