namespace DomainDrivenDesign.SDK;

/// <summary>
/// Represents the interface implementation of the domain error reasons.
/// </summary>
public interface IReason {
    /// <summary>
    /// Gets the domain error message.
    /// </summary>
    string Message { get; }

    /// <summary>
    /// Gets or sets the <see cref="IDictionary{TKey, TValue}"/> containing the 
    /// metadata information about the error details.
    /// </summary>
    IDictionary<string, object> Metadata { get; }
}
