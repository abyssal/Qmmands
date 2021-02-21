﻿using System;
using System.Threading.Tasks;

namespace Qmmands
{
    /// <summary>
    ///     Represents a <see cref="Qmmands.Parameter"/> check that has to succeed before the <see cref="Command"/> can be executed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
    public abstract class ParameterCheckAttribute : Attribute
    {
        /// <summary>
        ///     Gets the <see cref="Predicate{T}"/> that determines which types are supported by this <see cref="ParameterCheckAttribute"/>.
        ///     If <see langword="null"/>, any <see cref="Type"/> of parameters are accepted. 
        /// </summary>
        public Predicate<Type> Predicate { get; }

        /// <summary>
        ///     Gets the <see cref="Qmmands.Parameter"/> this <see cref="ParameterCheckAttribute"/> is for.
        /// </summary>
        public Parameter Parameter { get; internal set; }


        /// <inheritdoc cref="CheckAttribute.Group"/>
        public object Group { get; set; }

        /// <summary>
        ///     Initialises a new <see cref="ParameterCheckAttribute"/> with the predicate that determines what <see cref="Type"/>s are supported.
        /// </summary>
        /// <param name="predicate"> The optional <see cref="Predicate{T}"/> that determines what types are supported. </param>
        protected ParameterCheckAttribute(Predicate<Type> predicate = null)
        {
            Predicate = predicate;
        }

        /// <summary>
        ///     Determines whether the <paramref name="argument"/> is valid for the <see cref="Qmmands.Parameter"/> in given circumstances.
        /// </summary>
        /// <param name="argument"> The value given to this <see cref="Qmmands.Parameter"/>. </param>
        /// <param name="context"> The <see cref="CommandContext"/> used during execution. </param>
        /// <returns>
        ///     A <see cref="CheckResult"/> which determines whether this <see cref="ParameterCheckAttribute"/> succeeded or not.
        /// </returns>
        public abstract ValueTask<CheckResult> CheckAsync(object argument, CommandContext context);

        /// <summary>
        ///     Returns a successful <see cref="CheckResult"/>.
        /// </summary>
        /// <returns> A successful <see cref="CheckResult"/>. </returns>
        protected static CheckResult Success()
            => CheckResult.Successful;

        /// <summary>
        ///     Returns a failed <see cref="CheckResult"/> with the specified reason.
        /// </summary>
        /// <returns> A failed <see cref="CheckResult"/>. </returns>
        protected static CheckResult Failure(string reason)
            => CheckResult.Failed(reason);
    }
}
