namespace DomainDrivenDesign.SDK;

/// <summary>
/// Represents a domain exception that occur during application execution.
/// </summary>
[Serializable]
public class DomainException : Exception {

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class.
    /// </summary>
    public DomainException() : base() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class with a
    /// specified error message.
    /// </summary>
    /// <param name="message">The message that describe the error.</param>
    public DomainException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class with a 
    /// specified error message and a reference to the inner exception that is the
    /// cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="inner">The exception that is the cause of the current exception, or a 
    /// <see langword="null"/> if no inner exception is specified.</param>
    public DomainException(string message, Exception inner) : base(message, inner) { }
}