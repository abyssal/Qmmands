namespace Qmmands
{
    /// <summary>
    ///     Represents a command result where the command has been successfully dispatched.
    /// </summary>
    public sealed class ParallelExecutionResult : IResult
    {
        /// <summary>
        ///     Gets <see langword="true"/>.
        /// </summary>
        public bool IsSuccessful => true;

        /// <summary>
        ///     Initialises a new <see cref="ParallelExecutionResult"/>.
        /// </summary>
        public ParallelExecutionResult()
        { }
    }
}
