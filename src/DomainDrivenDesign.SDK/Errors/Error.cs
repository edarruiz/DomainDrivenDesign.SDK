namespace DomainDrivenDesign.SDK;

/// <summary>
/// Represents a domain error.
/// </summary>
public class Error : IError {
    #region Ctor
    /// <summary>
    /// Initializes a new instance of the class <see cref="Error"/>.
    /// </summary>
    protected Error() { }

    /// <summary>
    /// Initializes a new instance of the class <see cref="Message"/> defining the domain error message.
    /// </summary>
    /// <param name="message"><see cref="string"/> representing the domain error message.</param>
    public Error(string message) : this() {
        Message = message;
    }
    #endregion

    #region IError
    /// <inheritdoc/>
    public string Message { get; protected set; } = string.Empty;

    /// <inheritdoc/>
    public IList<IError> Reasons { get; protected set; } = new List<IError>();

    /// <inheritdoc/>
    public IDictionary<string, object> Metadata { get; protected set; } = new Dictionary<string, object>();
    #endregion
}
