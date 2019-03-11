/*
 * Elaborado por
 * Adrián Rangel Suárez, 2859552
 * Jan Mungarro, mat.
 */

using System;

namespace Tema7_Tarea6_2859552
{
    class MainClass
    {
        public static bool NewtonRhapson(double x, double standard, int counter = 0)
        {
            //Realizar la ecuación:
            double y = - Math.Pow(x, 3) - Math.Pow(x, 2) + 13 * x + 30;
            //Si el contador es 100 va a cancelar el proceso
            if(counter == 100)
                return false;
            //Si el absoluto de y es mayor al número límite.
            if (Math.Abs(y) > standard)
            {
                //Obtener la derivada y recalcular x para volver a realizar el ciclo.
                double dy = -3 * Math.Pow(x, 2) - 2 * x + 13;
                x = x - (y / dy);
                return NewtonRhapson(x, standard, counter + 1);
            }
            //Se imprimen los resultados y se manda que se pudo cumplir el proceso.
            Console.WriteLine("Contador: " + counter);
            Console.WriteLine("x = " + Math.Round(x, 4));
            Console.WriteLine("y = " + Math.Round(y, 4));
            return true;
        }

        //Función Recursiva Secante 2
        //En esta función se realiza el proceso con la ecuación de la secante.
        private static bool Secante(double xOld, double xNew, double yOld, double yNew, double minLim, double maxLim, int counter)
        {
            //Se iguala x Media a x Vieja solo en caso de que el if no se cumpla
            double xMed = xOld;
            if (counter == 100)
                return false;
            //Mientras la nueva y esté fuera del rango:
            if (yNew > maxLim || yNew < minLim)
            {
                //Se realiza la ecuación de la secante.
                xMed = xNew - ((xOld - xNew) * yNew / (yOld - yNew));
                //Se pasa la y que antes era nueva a la vieja.
                yOld = yNew;
                //La nueva Y se calcula.
                yNew = -Math.Pow(xMed, 3) - Math.Pow(xMed, 2) + 13 * xMed + 30;
                //Se realiza la función de nuevo con los nuevos valores obtenidos.
                return Secante(xNew, xMed, yOld, yNew, minLim, maxLim, counter + 1);
            }
            //Se imprimen los resultados.
            Console.WriteLine("Contador: " + counter);
            Console.WriteLine("x = " + Math.Round(xMed, 4));
            Console.WriteLine("y = " + Math.Round(yNew, 4));
            return true;
        }

        //Función Recursiva Secante 1
        //En esta función se realiza el proceso que es parte de la bisección hasta que llega a la parte de la secante.
        public static bool Secante(double x, double minLim, double maxLim, double step = 1, bool toTheRight = true, int counter = 0)
        {
            //Calcula y.
            double y = -Math.Pow(x, 3) - Math.Pow(x, 2) + 13 * x + 30;
            //
            if (counter == 100)
                return false;
            //Si está fuera del rango.
            if (y > maxLim || y < minLim)
            {
                //Se le suma o resta dependiendo de la dirección que tome x.
                double xNew = x;
                if (toTheRight)
                    xNew += step;
                else
                    xNew -= step;
                //Se vuelve a calcular el nuevo valor de y.
                double yNew = -Math.Pow(xNew, 3) - Math.Pow(xNew, 2) + 13 * xNew + 30;
                //Si hay cambio de signos entonces va a entrar la función 2, de lo contrario sigue con la misma.
                if ((y < 0 && yNew > 0) || (y > 0 && yNew < 0))
                {
                    return Secante(x, xNew, y, yNew, minLim, maxLim, counter + 1);
                }
                return Secante(xNew, minLim, maxLim, step, toTheRight, counter + 1);
            }
            //En caso de no entrar la función 2, imprime los resultados.
            Console.WriteLine("Contador: " + counter);
            Console.WriteLine("x = " + Math.Round(x, 4));
            Console.WriteLine("y = " + Math.Round(y, 4));
            return true;
        }

        public static bool Biseccion(double x, double minLim, double maxLim, double step = 1, bool toTheRight = true, int counter = 0)
        {
            //Se realiza la ecuación.
            double y = -Math.Pow(x, 3) - Math.Pow(x, 2) + 13 * x + 30;
            if (counter == 100)
                return false;
            //Si aún no se encuentra dentro del rango entonces realiza el ciclo.
            if (y > maxLim || y < minLim)
            {
                //Para guardar la nueva X se declara primero al tamaño de la X original para luego sumar o restar según la dirección.
                double xNew = x;
                if (toTheRight)
                    xNew += step;
                else
                    xNew -= step;
                //Se vuelve a comprar la operación con la nueva X
                double yNew = -Math.Pow(xNew, 3) - Math.Pow(xNew, 2) + 13 * xNew + 30;
                //Si se cruzó de 0 según las dos y entonces va a dividir en dos el paso y volteará de dirección.
                if ((y < 0 && yNew > 0) || (y > 0 && yNew < 0))
                {
                    step /= 2;
                    toTheRight = !toTheRight;
                }
                //Se realiza de nuevo la operación
                return Biseccion(xNew, minLim, maxLim, step, toTheRight, counter + 1);
            }
            //Si ya terminó el ciclo solo imprime finalmente toda la información.
            Console.WriteLine("Contador: " + counter);
            Console.WriteLine("x = " + Math.Round(x, 4));
            Console.WriteLine("y = " + Math.Round(y, 4));
            return true;
        }

        public static void Main(string[] args)
        {
            /*
             *Los métodos retornan un valor booleano (true o false) con un contador
             *si el contador llega a 100 entonces manda falso, de lo contrario mandar verdad,
             *lo que se debe de hacer es poner un if que mande que si uno de los métodos manda falso
             *que se pase al siguiente método, en el orden de NewtonRhapson, Secante y como última opción mandar
             *bisección.
             *Para rellenar las funciones es:
             *NewtonRhapson(-4, puntoCriterio)
             *Secante(-4, .000001, .000009, .1)
             *Biseccion(-4, .000001, .000009, .1)
             */
        }
    }
}
