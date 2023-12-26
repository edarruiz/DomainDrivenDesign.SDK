namespace DomainDrivenDesign.SDK;

/// <summary>
/// Represents the life cycle stages of a domain entity existing inside the domain model.
/// </summary>
/// <remarks>The life cycle of a domain entity is not limited to the application's memory, but is directly related 
/// to lifetime of the domain entity's information, where its states can change outside the application scope.</remarks>
public enum EntityLifecycleStage {
    /// <summary>
    /// At this stage, the domain entity is being created, where a new identity of the entity is being defined.
    /// </summary>
    /// <remarks>Before creation, the domain entity does not exist, and after the creation, the domain entity will
    /// exist until <see cref="Deleted"/> or <see cref="Archived"/>.</remarks>
    Created,

    /// <summary>
    /// In this stage, the domain entity is being activated, making it ready for use within the domain model.
    /// </summary>
    /// <remarks>Before activation, the domain entity cannot be used inside the domain model. Activation happens
    /// after the <see cref="Created"/> stage, being the domain entity a new one or when the domain entity is 
    /// <see cref="Reconstituted"/> from a data source. After activation, the domain entity is ready 
    /// to be <see cref="Modified"/>, <see cref="Stored"/>, <see cref="Archived"/> or <see cref="Deleted"/> to
    /// a data source.</remarks>
    Activated,

    /// <summary>
    /// At this stage, the domain entity is being modified, where its data has changed.
    /// </summary>
    /// <remarks>After being modified, the domain entity is ready to be <see cref="Stored"/>, <see cref="Archived"/> 
    /// or <see cref="Deleted"/> to any data source.</remarks>
    Modified,

    /// <summary>
    /// At this stage, the domain entity has been successfully persisted (stored) to the database or equivalent data source.
    /// </summary>
    /// <remarks>After being stored, the domain entity is ready to be <see cref="Reconstituted"/> from a data source.</remarks>
    Stored,

    /// <summary>
    /// At this stage, the domain entity has been reconstituted successfully from the database or equivalent data source
    /// </summary>
    /// <remarks>After being reconstituted from a data source, the domain entity is ready to be <see cref="Activated"/>.</remarks>
    Reconstituted,

    /// <summary>
    /// At this stage, the domain entity was archived and persisted successfully to the database, file or equivalent data source.
    /// </summary>
    /// <remarks>Once archived to a data source, the domain entity's lifetime ends, and will no longer be available 
    /// in the domain model.</remarks>
    Archived,

    /// <summary>
    /// At this stage, the domain entity was successfully removed from the database or equivalent data source. 
    /// </summary>
    /// <remarks>Once deleted form a data source, the domain entity's lifetime ends, and will no longer be available 
    /// in the domain model.</remarks>
    Deleted
}
