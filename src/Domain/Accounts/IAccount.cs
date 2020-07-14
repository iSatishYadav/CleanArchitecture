// <copyright file="IAccount.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts
{
    using Credits;
    using Debits;
    using ValueObjects;

    /// <summary>
    ///     Account
    ///     <see
    ///         href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#aggregate-root">
    ///         Aggregate
    ///         Root Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        ///     Gets Id.
        /// </summary>
        AccountId Id { get; }

        /// <summary>
        ///     Deposits into account.
        /// </summary>
        /// <param name="entityFactory">Factory to create new credits.</param>
        /// <param name="amountToDeposit">Amount.</param>
        /// <returns>Credit created.</returns>
        ICredit Deposit(IAccountFactory entityFactory, PositiveMoney amountToDeposit);

        /// <summary>
        ///     Withdrawls from account.
        /// </summary>
        /// <param name="entityFactory">Factory to create new debits.</param>
        /// <param name="amountToWithdraw">Amount.</param>
        /// <returns>Debit created.</returns>
        IDebit Withdraw(IAccountFactory entityFactory, PositiveMoney amountToWithdraw);

        /// <summary>
        ///     Check if closing account is allowed.
        /// </summary>
        /// <returns>True if is allowed.</returns>
        bool IsClosingAllowed();

        /// <summary>
        ///     Gets the current balance considering credits and debits totals.
        /// </summary>
        /// <returns>The current balance.</returns>
        Money GetCurrentBalance();
    }
}
