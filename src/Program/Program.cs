//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

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

            Console.WriteLine();
            Console.WriteLine("=== Cuenta a plazo fijo ===");
            Console.WriteLine();

            // Camino normal: plazo de 30 días que comenzó hace 40 días.
            FixedTermDepositAccount maturedAccount = new FixedTermDepositAccount(100.0, 30, DateTime.Today.AddDays(-40));
            Console.WriteLine("Cuenta vencida creada con saldo: " + maturedAccount.Balance);

            maturedAccount.Withdraw(10.0);
            Console.WriteLine("Luego de retirar 10: " + maturedAccount.Balance);

            Console.WriteLine();
            Console.WriteLine("--- Provocando una violación de una precondición heredada de BankAccount ---");

            try
            {
                // Viola: amount <= Balance, definida en BankAccount.Withdraw.
                maturedAccount.Withdraw(99999.0);
            }
            catch (PreconditionViolationException ex)
            {
                Console.WriteLine("Se capturó PreconditionViolationException:");
                Console.WriteLine("  Método : " + ex.MemberName);
                Console.WriteLine("  Predicado : " + ex.Predicate);
                Console.WriteLine("  Mensaje   : " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("--- Provocando una violación por retiro antes del vencimiento ---");

            // Plazo de 30 días que comenzó hace 5 días.
            FixedTermDepositAccount notMaturedAccount = new FixedTermDepositAccount(100.0, 30, DateTime.Today.AddDays(-5));

            try
            {
                // Viola: IsMature.
                notMaturedAccount.Withdraw(10.0);
            }
            catch (PreconditionViolationException ex)
            {
                Console.WriteLine("Se capturó PreconditionViolationException:");
                Console.WriteLine("  Método : " + ex.MemberName);
                Console.WriteLine("  Predicado : " + ex.Predicate);
                Console.WriteLine("  Mensaje   : " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("--- Violando el principio de sustitución de Liskov ---");

            // El cliente solo conoce el contrato de BankAccount: amount > 0 y amount <= Balance.
            BankAccount substitutedAccount = notMaturedAccount;

            try
            {
                // Cumple el contrato de BankAccount.Withdraw, pero la subclase fortaleció la precondición.
                substitutedAccount.Withdraw(10.0);
            }
            catch (PreconditionViolationException ex)
            {
                Console.WriteLine("Se capturó PreconditionViolationException:");
                Console.WriteLine("  Método : " + ex.MemberName);
                Console.WriteLine("  Predicado : " + ex.Predicate);
                Console.WriteLine("  Mensaje   : " + ex.Message);
            }
        }
    }
}
