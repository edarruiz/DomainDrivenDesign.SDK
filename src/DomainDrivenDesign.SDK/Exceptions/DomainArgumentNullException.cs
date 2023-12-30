namespace DomainDrivenDesign.SDK;

/// <summary>
/// Represents a domain exception that is thrown when a <see langword="null"/> reference 
/// is passed to a method that does not accept it as a valid argument.
/// </summary>
public class DomainArgumentNullException : ArgumentNullException {

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainArgumentNullException"/> class.
    /// </summary>
    public DomainArgumentNullException() : base() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainArgumentNullException"/> class 
    /// with the name of the parameter that causes this exception.
    /// </summary>
    /// <param name="paramName">The name of the parameter that caused the exception.</param>
    public DomainArgumentNullException(string? paramName) : base(paramName) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainArgumentNullException"/> class 
    /// with a specified error message and the exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for this exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a 
    /// <see langword="null"/> reference if no inner exception is specified.</param>
    public DomainArgumentNullException(string? message, Exception? innerException) : base(message, innerException) { }

    /// <summary>
    /// Initializes an instance of the <see cref="DomainArgumentNullException"/> class 
    /// with a specified error message and the name of the parameter that causes this exception.
    /// </summary>
    /// <param name="paramName">The name of the parameter that caused the exception.</param>
    /// <param name="message">A message that describes the error.</param>
    public DomainArgumentNullException(string? paramName, string? message) : base(paramName, message) { }


}
