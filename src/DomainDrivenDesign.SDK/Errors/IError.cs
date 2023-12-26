namespace DomainDrivenDesign.SDK;

/// <summary>
/// Represents the interface implementation of domain errors.
/// </summary>
public interface IError : IReason {
    /// <summary>
    /// Gets the list of reasons for the error.
    /// </summary>
    IList<IError> Reasons { get; }
}
