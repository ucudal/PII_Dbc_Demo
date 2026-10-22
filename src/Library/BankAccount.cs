using Ucu.Poo.Dbc;

namespace Ucu.Poo.Dbc.Demo
{
    /// <summary>
    /// Cuenta bancaria simple que demuestra Diseño por Contrato.
    ///
    /// Invariante : Balance >= 0
    /// Depósito   : amount > 0  =>  Balance == old(Balance) + amount
    /// Retiro     : amount > 0 y amount &lt;= Balance
    ///              =>  Balance == old(Balance) - amount
    /// </summary>
    [Invariant("Balance >= 0")]
    public class BankAccount
    {
        /// <summary>
        /// Obtiene el saldo actual de la cuenta.
        /// </summary>
        /// <value>
        /// Saldo actual de la cuenta bancaria.
        /// </value>
        public double Balance { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BankAccount"/>.
        /// </summary>
        /// <param name="initialBalance">Saldo inicial de la cuenta.</param>
        [Requires("initialBalance >= 0", "El saldo inicial no puede ser negativo.")]
        public BankAccount(double initialBalance)
        {
            Balance = initialBalance;
        }

        /// <summary>
        /// Deposita un monto en la cuenta.
        /// </summary>
        /// <param name="amount">Monto a depositar.</param>
        [Requires("amount > 0", "El monto del depósito debe ser positivo.")]
        [Ensures("Balance == old(Balance) + amount")]
        public void Deposit(double amount)
        {
            Balance += amount;
        }

        /// <summary>
        /// Retira un monto de la cuenta.
        /// </summary>
        /// <param name="amount">Monto a retirar.</param>
        [Requires("amount > 0", "El monto del retiro debe ser positivo.")]
        [Requires("amount <= Balance", "No se puede retirar más que el saldo actual.")]
        [Ensures("Balance == old(Balance) - amount")]
        public virtual void Withdraw(double amount)
        {
            Balance -= amount;
        }

        /// <summary>
        /// Retira un monto y retorna el saldo resultante.
        /// </summary>
        /// <param name="amount">Monto a retirar.</param>
        /// <returns>Saldo luego del retiro.</returns>
        [Requires("amount > 0", "El monto del retiro debe ser positivo.")]
        [Requires("amount <= Balance", "No se puede retirar más que el saldo actual.")]
        [Ensures("Balance == old(Balance) - amount")]
        [Ensures("result() == Balance")]
        public double WithdrawAndReturnBalance(double amount)
        {
            Balance -= amount;

            return Balance;
        }

        /// <summary>
        /// Retira un monto y retorna el saldo, forzando una violación de poscondición para fines de demostración.
        /// </summary>
        /// <param name="amount">Monto a retirar.</param>
        /// <returns>Saldo luego del retiro.</returns>
        [Requires("amount > 0", "El monto del retiro debe ser positivo.")]
        [Requires("amount <= Balance", "No se puede retirar más que el saldo actual.")]
        [Ensures("Balance == old(Balance) - amount")]
        public double WithdrawAndReturnWrongResult(double amount)
        {
            Balance += amount; // Error intencional

            return Balance;
        }
    }
}
