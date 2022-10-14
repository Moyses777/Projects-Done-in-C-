using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaAppBuilderPattern.Interfaces
{
    public interface IArea
    {
        void CalcularArea();

    }

    public class Cuadrado : IArea
    {
        private int _lado;

        public Cuadrado(int lado)
        {
            this._lado = lado;
        }

        public void CalcularArea()
        {
            MessageBox.Show($"Area { _lado * _lado }");
        }
    }

    public class Triangulo : IArea
    {
        private int bases;
        private int altura;
        public Triangulo(int bases, int altura)
        {
            this.bases = bases;
            this.altura = altura;
        }

        public void CalcularArea()
        {
            MessageBox.Show($"Area { bases * altura / 2 }");
        }
    }

    public class DirectoryBuilder
    {
        private IArea area;
        public DirectoryBuilder(IArea area)
        {
            this.area = area;
        }

        public void Ejecutar() => area.CalcularArea();
    }

}
