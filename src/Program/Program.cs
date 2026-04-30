using System;
using Ucu.Poo.Dbc;

namespace Ucu.Poo.Dbc.Demo
{
    /// <summary>
    /// Ejecuta el programa de demostración de Diseño por Contrato.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Punto de entrada de la aplicación de demostración.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("=== Demo de Diseño por Contrato ===");
            Console.WriteLine();

            // Camino normal
            BankAccount account = new BankAccount(100.0);
            Console.WriteLine("Cuenta creada con saldo: " + account.Balance);

            account.Deposit(50.0);
            Console.WriteLine("Luego de depositar 50: " + account.Balance);

            account.Withdraw(30.0);
            Console.WriteLine("Luego de retirar 30: " + account.Balance);

            double resultingBalance = account.WithdrawAndReturnBalance(10.0);
            Console.WriteLine("Luego de WithdrawAndReturnBalance(10): " + account.Balance);
            Console.WriteLine("Valor retornado (result()): " + resultingBalance);

            Console.WriteLine();
            Console.WriteLine("--- Provocando una violación de precondición ---");

            try
            {
                // Viola: amount > 0.
                account.Deposit(-10.0);
            }
            catch (PreconditionViolationException ex)
            {
                Console.WriteLine("Se capturó PreconditionViolationException:");
                Console.WriteLine("  Método : " + ex.MemberName);
                Console.WriteLine("  Predicado : " + ex.Predicate);
                Console.WriteLine("  Mensaje   : " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("--- Provocando una violación por fondos insuficientes ---");

            try
            {
                // Viola: amount <= Balance.
                account.Withdraw(99999.0);
            }
            catch (PreconditionViolationException ex)
            {
                Console.WriteLine("Se capturó PreconditionViolationException:");
                Console.WriteLine("  Método : " + ex.MemberName);
                Console.WriteLine("  Predicado : " + ex.Predicate);
                Console.WriteLine("  Mensaje   : " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("--- Provocando una violación de poscondición (old() + result()) ---");

            try
            {
                account.WithdrawAndReturnWrongResult(5.0);
            }
            catch (PostconditionViolationException ex)
            {
                Console.WriteLine("Se capturó PostconditionViolationException:");
                Console.WriteLine("  Método : " + ex.MemberName);
                Console.WriteLine("  Predicado : " + ex.Predicate);
                Console.WriteLine("  Mensaje   : " + ex.Message);
            }
        }
    }
}
