using System;
using Calculadora_SOAP.WebServiceSOAP;

namespace Calculadora_SOAP.Scripts
{
    public class Calculadora
    {
        public Calculadora()
        {
        }

        public static float soma(float x, float y){
            return new Implements_SOAPService().Somar(x, y);
        }

        public static float subtracao(float x, float y){
            return new Implements_SOAPService().Subtrair_A_menos_B(x, y);
        }

        public static float multiplicacao(float x, float y){
            return new Implements_SOAPService().Multiplicar(x, y);
        }

        public static float divisao(float x, float y){
            return new Implements_SOAPService().Dividir_A_por_B(x, y);
        }

        public static float quadrado(float x){
            return new Implements_SOAPService().Quadrado(x);
        }

        public static float cubo(float x){
            return new Implements_SOAPService().Cubo(x);
        }
    }
}
