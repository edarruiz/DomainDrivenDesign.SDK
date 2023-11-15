- [A C# and dotnet Software Development Kit for the Domain-Driven Design concepts](#a-c-and-dotnet-software-development-kit-for-the-domain-driven-design-concepts)
- [Background](#background)
  - [The Domain-Driven Design Core Concepts](#the-domain-driven-design-core-concepts)
    - [Ubiquitous Language](#ubiquitous-language)
    - [Entities](#entities)
    - [Value Objects](#value-objects)
    - [Domain Services](#domain-services)
    - [Domain Object Life Cycle - The problems that justify the Design Patterns](#domain-object-life-cycle---the-problems-that-justify-the-design-patterns)
    - [Aggregates and Aggregate Roots](#aggregates-and-aggregate-roots)
    - [Factories](#factories)
    - [Repositories](#repositories)
  - [The Domain-Driven Design Model Integrity Concepts](#the-domain-driven-design-model-integrity-concepts)
    - [Bounded Contexts](#bounded-contexts)
    - [Continuous Integration (Not CI/CD framework)](#continuous-integration-not-cicd-framework)
    - [Context Mapping (The infamous mappers)](#context-mapping-the-infamous-mappers)
    - [Shared Kernel](#shared-kernel)
    - [Anticorruption Layer](#anticorruption-layer)
    - [Transformations](#transformations)
  - [Extending the toolbox - More Patterns](#extending-the-toolbox---more-patterns)
    - [Strategy (Policy)](#strategy-policy)
    - [Composite](#composite)
    - [CQRS (Command and Query Responsibility Segregation)](#cqrs-command-and-query-responsibility-segregation)
    - [Mediator Design Pattern](#mediator-design-pattern)
    - [Notification Pattern](#notification-pattern)
- [Acknowledgement](#acknowledgement)
- [How to use this SDK](#how-to-use-this-sdk)
  - [Installation](#installation)
  - [Dependency Injection](#dependency-injection)
- [Documentation](#documentation)
- [Examples](#examples)


# A C# and dotnet Software Development Kit for the Domain-Driven Design concepts

> *"Domain-Driven Design is an approach to software development that centers the development on programming a domain model that has a rich understanding of the processes and rules of a domain. The name comes from a 2003 book by Eric Evans that describes the approach through a catalog of patterns. Since then a community of practitioners have further developed the ideas, spawning various other books and training courses. The approach is particularly suited to complex domains, where a lot of often-messy logic needs to be organized. (...)"*
>
> [Domain Driven Design](https://martinfowler.com/bliki/DomainDrivenDesign.html), Martin Fowler, April 2020

The Domain-Driven Design, also known as *DDD*, is well known in the developer's community because its a good strategy to solve complex business problems in a very particular and structured way.

Its concepts and strategy proposals are present since 2003, when Eric Evans published the book *[Domain-Driven Design: Tackling Complexity in the Heart of Software](https://www.amazon.com.br/Domain-Driven-Design-Tackling-Complexity-Software/dp/0321125215)*.

If you haven't read the book yet, I strongly recommend you to do so. It not only will give you precious information, but also will open your eyes to a new world of possibilities you are probably missing inside your current implementation details while creating software solutions.

**All the concepts implemented in this SDK was inspired by this book**. This project goal is to provide a standard and practical way of reusing this concepts as implementation building blocks for any application made with dotnet and C#, no matter the type they could be or the purpose they should reach.

# Background

I've been using and improving my understanding, knowledge and usage of the DDD concepts over the years using C# and dotnet. 

As a developer, I'm far from having a perfect implementation model of the very complex vision the book proposes in each and every corner of its theories. Anyway, this SDK is a very realistic effort to achieve a solid and stable code, enriched with the experience I had in various projects using DDD, C# and dotnet in the past.

One of my biggest frustrations when using Domain-Driven Design was, everytime I started working in a new project, new company or new team, I always endup with the requirement of creating all this basic framework of DDD over and over again, from time to time, from solution to solution. Sometimes, we can't just reuse code between projects, teams or companies, for any reason that happens to occurs.

Besides DDD being well known over the past 20 years, until today, I found a good number of developers and teams that had some critical gaps of the fundamentals and some big misunderstanding of the application for some concepts Eric Evans proposes in his book.

And this brought consequences, for every project I went on. From what I could experienced over time, over this gaps and misunderstandings, at minimum, was unsuccessful implementations, defected features, mislead results, right implementations in the wrong places, high coupling, high dependency, business model blurring, and lots, lots of bugs and refactorings until the "final decent result".

For these and another minor various reasons, this SDK project intend to give you a full range of abstractions and concrete implementations of the concepts existing on the Domain-Driven Design as a standalone Nuget package, built with C# and with the dotnet framework. 

With this SDK, you (and me) can reuse the same implementations without the need of recreating and testing everything we need everytime, over and over again.

Also, this SDK will provide some extended implementations using design patterns that might help you to deal with specific scenarios and business problems inside your application, when you choose to follow the path of using the domain model design to develop your solutions.

Finally, as a final goal to this SDK, I decided to choose quality and completeness over simplicity and practicallity. This because we always have deadlines and excessive pressure when we are inside companies, doing our project, doing our job.

This SDK is a honest and humble effort, to give the concepts contained inside the book the attention and time they need, to give the developers the most complete abstractions they should receive to create any implementation, based on these very Domain-Driven Design concepts.

## The Domain-Driven Design Core Concepts

The Domain-Driven Design strategy is composed by a series of concepts, patterns and good pratices. 

The main goal of Domain-Driven Design is to create a model (representation) that accurately reflects the domain and its associated business rules, which can then be used to drive the design and implementation of the software.

To achieve this, the book provides us a huge number of constraints and careful definitions that should be followed to create a successful domain model design solution.

In the book, the author uses Java to create some examples of the implementations as real and fictitious scenarios to demonstrate the usage of the concepts explained along the chapters. When using C# to create this implementations, we have a lot of tools and powerful ways of how to implement all the DDD concepts within the dotnet framework.

But before that, is very important you notice you should know and master **all the basic concepts** of the domain-driven design before jumping into the code. 

The next sections, I will give you an overview of the basic concepts without getting too much into the details. This content should be enough for you to get the things right, and have a good grasp of what the concepts of Domain-Driven Design is about.

Enough introductions, let's dive into it!

### Ubiquitous Language

I like to call this concept as the *final desired common language everyone in the project should know and must use*.

We use language and words to create and maintain a communication between developers and business experts, so we can have a good understanting of the subjects and topics being discussed in a conversation. And for this to happen with some degree of success, we need a common way of talking, something that looks like an verbal (literally) agreement of understanding and meaning of the words, and terms we are going to use throught the whole project.

The **ubiquitous language** is introduced in the book on chapter 2, with a simple glimpse:

> *"To create a supple, knowledge-rich design calls for a versatile, shared team language, and a lively experimentation with language that seldom happens on software projects. (...)"*

In a simple way, we must understand the ubiquitous language as a common language shared by both domain experts and developers, which is used to define the model and communicate about the domain. 

This language should be based on the terms and concepts of the domain and should be used consistently throughout the project.

For the SDK, the ubiquitous language is always present when we choose to use some common verbs, nouns, noun phrases for classes, methods, interfaces, services and other general components of the code structure, bringing meaning to this structures and pieces of code.

### Entities

When we think about an entity model, we must think them as *the core and the heart of the domain model design*.

The entities (a.k.a Reference Objects) are presented in the book on chapter 5, with a very clear concept about *Entities* as *reference objects*:

> *"Many objects are not fundamentally defined by their attributes, but rather by a thread of continuity and identity. (...)"*

> ***"Some objects are not defined primarily by their attributes. They represent a thread of identity that runs through time and often across distinct representations. Sometimes such an object must be matched with another object even though attributes differ. An object must be distinguished from other objects even though they might have the same attributes. Mistaken identity can lead to data corruption. (...)"***

And finally, Eric Evans describes the exact definition of what an **Entity** is:

> *"An object defined primarily by its identity is called an ENTITY. ENTITIES have special modeling and design considerations. They have life cycles that can radically change their form  and content, but a thread of continuity must be maintained. Their identities must be defined so  hat they can be effectively tracked. Their class definitions, responsibilities, attributes, and associations should revolve around who they are, rather than the particular attributes they carry. Even for ENTITIES that don't transform so radically or have such complicated life cycles, placing them in the semantic category leads to more lucid models and more robust implementations. "*
> 
> *(...)*
>
> *"When an object is distinguished by its identity, rather than its attributes, make this primary to its definition in the model. Keep the class definition simple and focused on life cycle continuity and identity. Define a means of distinguishing each object regardless of its form or history. Be alert to requirements that call for matching objects by attributes. Define an operation that is guaranteed to produce a unique result for each object, possibly by attaching a symbol that is guaranteed unique. This means of identification may come from the outside, or it may be an arbitrary identifier created by and for the system, but it must correspond to the identity distinctions in the model. The model must define what it means to be the same thing."*

So, these are the key characteristics of an Entity:
- They are UNIQUE ***(required)***
- They have a UNIQUE identity ***(required)***
- They are MUTABLE ***(required)***
- They have a life cycle and a history ***(required)***
- They have attributes ***(required)***
- They have behaviors ***(required)***
- They have validation constraints ***(required)***
- They can have relations ***(optional)***
- They reinforce usage of constraints and validations by creational and structural patterns ***(required)***
- They can have diferent representations of the same identity ***(optional)***
- They can transform through its life cycle , but holds the same identity ***(optional)***
- They cannot be replaced by equivalent instances because they are unique ***(required)***

### Value Objects

For very system we have values, their meaning and their definitions. For this reason, I like to think the value objects as *a way of describing things*.

Value objects are introduced in the book on chapter 5, when Eric Evans says:

> *"Many objects have no conceptual identity. These objects describe some characteristic of a  thing."*
>
> *(...)*
>
> *"However, if we think of this category of object as just the absence of identity, we haven't added much to our toolbox or vocabulary. In fact, these objects have characteristics of their own and their own significance to the model. These are the objects that describe things."*
>
> *(...)*
>
> *"An object that represents a descriptive aspect of the domain with no conceptual identity is called a VALUE OBJECT. VALUE OBJECTS are instantiated to represent elements of the design that we care about only for what they are, not who or which they are."*
>
> *(...)*
>
> *"When you care only about the attributes of an element of the model, classify it as a VALUE OBJECT. Make it express the meaning of the attributes it conveys and give it related functionality. Treat the VALUE OBJECT as immutable. Don't give it any identity and avoid the design complexities necessary to maintain ENTITIES."*

So, these are the key characteristics of a Value Object:
- They are NOT UNIQUE ***(required)***
- They are IMMUTABLE ***(required)***
- They represent JUST VALUES by its internal structure ***(required)***
- They have attributes ***(required)***
- They can have behaviors ***(optional)***
- They can have relations ***(optional)***
- They can have validation constraints ***(optional)***
- They can reinforce usage of constraints and validations by creational and structural patterns ***(optional)***
- They do not have a lifecycle ***(required)***
- They can be replaced by equivalent instances ***(required)***
- They can reduce complex operations or tasks to represent, simplify and isolate business rules or any domain logic ***(optional, situational)***

### Domain Services

Domain models objects have responsibilities, behaviors, relationships, limits and limitations, being them an Entity or a Value Object.

Inside the domain, when discovering, defining and using Entities and Value Objects, sometimes we need to do some stuff with them, to or for them. This *stuff we need to do* could be actions, activities based on their relationships, behaviors triggered from some place else, it could be some changes in the state of the domain, well, it could be a lot of things.

When is hard to define WHO (entity or value object) should be responsible for doing the action, when apparently no object is directly responsible for doing it, or when the responsibility could be shared between objects we use a new key concept: *Services.*

Inside the domain model, a service describes and emphasizes relationship between objects, and tends to be named based on its activity, rather than the object sources, being these entities or value objects.

The Services are introduced in the book on chapter 5, when Eric Evans says:

> *"In some cases, the clearest and most pragmatic design includes operations that do not conceptually belong to any object. Rather than force the issue, we can follow the natural  contours of the problem space and include SERVICES explicitly in the model."*
>
> *(...)*
>
> *"There are important domain operations that can't find a natural home in an ENTITY or VALUE OBJECT. Some of these are intrinsically activities or actions, not things, but since our modeling paradigm is objects, we try to fit them into objects anyway."*
> 
> *(...)*
>
> *"Some concepts from the domain aren't natural to model as objects. Forcing the required domain functionality to be the responsibility of an ENTITY or VALUE either distorts the definition of a model-based object or adds meaningless artificial objects."*
> 
> *"A SERVICE is an operation offered as an interface that stands alone in the model, without encapsulating state, as ENTITIES and VALUE OBJECTS do. SERVICES are a common pattern in technical frameworks, but they can also apply in the domain layer."*
>
> *(...)*
>
> *"When a significant process or transformation in the domain is not a natural responsibility of an ENTITY or VALUE OBJECT, add an operation to the model as a standalone interface declared as a SERVICE. Define the interface in terms of the language of the model and make sure the operation name is part of the UBIQUITOUS LANGUAGE. Make the SERVICE stateless."*

*Services* are a common name and a very common concept in web applications. For this reason, when using Domain-Driven Design, we prefix the names of this kind of domain related services, especifically calling them *Domain Services*.

So, these are the key characteristics of a Domain Service:
- They SHOULD HAVE a defined and definite responsibility ***(required)***
- Their responsibility SHOULD BE defided as part of the domain model ***(required)***
- Their names SHOULD COME from the Ubiquitous Language ***(required)***
- Their parameters and results SHOULD BE domain objects ***(required)***
- They SHOULD NOT strip or steal behavior from Entities and Value Objects ***(required)***
- They MUST represent an operation related to the domain concept that is not a natural part of an Entity or Value Object ***(required)***
- Their interface MUST be defined in terms of other elements of the domain model ***(required)***
- Their operation SHOULD BE stateless ***(required)***

### Domain Object Life Cycle - The problems that justify the Design Patterns

We are used to the concept of any object life cycle inside the application, and it's always related to the object life cycle in system's memory.

When we talk about an object life cycle in Domain-Driven Design, we are not just talking about its lifetime inside the system memory. We are talking about their life inside and ouside the boudaries of our application: it's all about its creating, continuity, persistency and archiving (death).

It is very, very important you learn to understand and identify this distinction. 

As developers we tend to understand *things* inside our application boudaries, and as expected from us, we tend to do not care what happen about things when our application scope ends, otherwise, it will be impossible to keep track of everything that happens outside our application boundaries scope.

In chapter 6, Eric Evans talk about the life cycle of a domain object, and this will give us grounds to understand the next concepts:

> *"Every object has a life cycle. An object is born, it likely goes through various states, and it eventually dies—being either archived or deleted. Of course, many of these are simple, transient objects, created with an easy call to their constructor, used in some computation, and then abandoned to the garbage collector. There is no need to complicate such objects. But other objects have longer lives, not all of which are spent in active memory. They have complex interdependencies with other objects. They go through changes of state to which invariants apply. Managing these objects presents challenges that can easily derail an attempt at MODEL-DRIVEN DESIGN."*
>
> *(...)*
> 

Also, Eric Evans give us the diagram representing the life cycle of a domain object:

![domain_object_lifecycle](doc/domain_object_lifecycle.png)

The domain object life cycle challenges mentioned in the book, fall in 2 categories:

1. Maintain the object integrity throughout its whole life cycle
2. Prevent the model from getting swarmed by the life cycle management complexity (even technical)

To solve this problems, we should use (and implement) the next three concepts presented in the book:

- **Aggregates** - the grouping, association and relationship between model objects;
- **Factories** - the creational pattern responsible for create and reconstitute complex objects and tree of objects (Aggregates);
- **Repositories** - the pattern that *glues* the aggregates and the factories together, being responsible for persist, find and retrieve objects while encapsulating the infrastructure complexity and their needed implementation details.

### Aggregates and Aggregate Roots

When we think about the domain model objects, we quickly identify and see the relations between objects. Sometimes, this relations are so deeply interconnected that is hard to use them as a tool to maintain the domain model integrity itself.

For these reasons, we should try to see the directions of these relationships between the domain model objects, and also, try to isolate and restrict them as much as possible, so we can refrain the models to explode into too many object references inside the domain model.

In the chapter 6, Eric Evans says:

> *"It is difficult to guarantee the consistency of changes to objects in a model with complex associations. Invariants need to be maintained that apply to closely related groups of objects, not just discrete objects. Yet cautious locking schemes cause multiple users to interfere pointlessly with each other and make a system unusable."* 
> 
> *(...)*
> 

In another words, we need to discover the exact boundaries the domain model objects have. We need to consider the persistence of this objects, their scope of transactions, and finally, how we are going to create and maintain its invariants, so we can have the consistency of the data needed to reflect the domain models as a "single block of information".

For this reasons, in the same chapter, we have the actual definition of *Aggregates* and *Aggregate Roots*, that help us to identify these grouping of objects, their main entities and the limits of their relations between other objects:

> *"First we need an abstraction for encapsulating references within the model. An AGGREGATE is a cluster of associated objects that we treat as a unit for the purpose of data changes. Each AGGREGATE has a root and a boundary. The boundary defines what is inside the AGGREGATE. The root is a single, specific ENTITY contained in the AGGREGATE. The root is the only member of the AGGREGATE that outside objects are allowed to hold references to, although objects within the boundary may hold references to each other. ENTITIES other than the root have local identity, but that identity needs to be distinguishable only within the AGGREGATE, because no outside  bject can ever see it out of the context of the root ENTITY."*
> 
> *(...)*
> 
> *"Cluster the ENTITIES and VALUE OBJECTS into AGGREGATES and define boundaries around each. Choose one ENTITY to be the root of each AGGREGATE, and control all access to the objects inside the boundary through the root. Allow external objects to hold references to the root only. Transient references to internal members can be passed out for use within a single operation only. Because the root controls access, it cannot be blindsided by changes to the internals. This arrangement makes it practical to enforce all invariants for objects in the AGGREGATE and for the AGGREGATE as a whole in any state change."*
> 
> *(...)*
> 

Once defined these groupings, boundaries and the main elements of the groups, we can deal with all necessary logic to enforce data validation and constraints to achieve the data integrity of the domain model.

Finally, the book define a set of rules that must apply to all object transactions, that helps to translate the conceptual Aggregate into the concrete implementation details:

- The Aggregate Root (root entity) must have a global identity in the whole domain model
- The Aggregate Root shoud be responsible for checking the invariants inside the Aggregate boundaries
- The Entities inside the boundary have local identity and unique identity inside the Aggregate
- No object outside the Aggregate can hold or have a reference to anything that is inside the Aggregate, except to the Aggregate Root Entity
- The Aggregate Root can provide transient references to the internal Entities, but cannot hold internal references to be exposed outside the boundaries of the Aggregate
- The Aggregate Root can provide copies of the Value Objects to another objects, and this copies should not contain any associations with the Aggregate
- Only Aggregate Roots can be obtained directly from the persistence layer (database queries or any equivalent data source read operation). The related objects can only be obtained by transversal of associations.
- Objects inside the Aggregate can hold references to other Aggregate Root objects existing outside the Aggregate boundaries
- A removal operation (DELETE) must remove everything within the Aggregate boundaries at once
- When persisting a change to any object inside the Aggregate boundaries (UPDATE), all invariants of the whole Aggregate must be satisfied.

The next two sections explore the patterns of [Factories](#factories) and [Repositories](#repositories), that operates on Aggregates, encapsulating the complexity of the objects life cycles and their transitions.

### Factories

TODO - In progress of documentation

### Repositories

TODO - In progress of documentation

## The Domain-Driven Design Model Integrity Concepts

TODO - In progress of documentation

### Bounded Contexts

TODO - In progress of documentation

### Continuous Integration (Not CI/CD framework)

TODO - In progress of documentation

### Context Mapping (The infamous mappers)

TODO - In progress of documentation

### Shared Kernel

TODO - In progress of documentation

### Anticorruption Layer

TODO - In progress of documentation

### Transformations

TODO - In progress of documentation

## Extending the toolbox - More Patterns

TODO - In progress of documentation

### Strategy (Policy)

TODO - In progress of documentation

### Composite

TODO - In progress of documentation

### CQRS (Command and Query Responsibility Segregation)

TODO - In progress of documentation

### Mediator Design Pattern

TODO - In progress of documentation

### Notification Pattern

> *"An object that collects together information about errors and other information in the domain layer and communicates it to the presentation."*
> 
> [Notification](https://martinfowler.com/eaaDev/Notification.html), Martin Fowler, August 2004

# Acknowledgement

This work I present here would not be possible without the brilliant and resourceful minds of great mens, that dedicated their lifes to software development, to the business and software communities, when they brought new ideas to the world, that gave success opportunities to inumerous business and techonology people all around the world over the past two decades.

So I personally thank you:

- **[Eric Evans](https://www.domainlanguage.com/)** - for his book [Domain-Driven Design: Tackling Complexity in the Heart of Software](https://www.amazon.com.br/Domain-Driven-Design-Tackling-Complexity-Software/dp/0321125215), that motivated me to open my mind to new ideas and concepts that could be applied in the most complex business enterprises and gave me the reasons to pursue my Software Architecture career.

- **[Martin Fowler](https://martinfowler.com/aboutMe.html)** - for his articles and his relentless work on concepts and patterns of software developement, which resulted in inumerous articles and books.
- **[Steven Smith (a.k.a Ardalis)](https://ardalis.com/)** - for his contributions to the software development community, through its trainings, videos, articles and more content than we can process in one lifetime career.
- **[Michael Altmann](https://twitter.com/michael_altmann)** - for his work on the package [FluentResults](https://github.com/altmann/FluentResults).
- **[Jeremy Skinner](https://twitter.com/JeremySkinner)** - for his work on the package [FluentValidation](https://github.com/FluentValidation/FluentValidation).
- **[Vladimir Khorikov](https://enterprisecraftsmanship.com/)** - for his work on the package [CSharpFunctionalExtensions](https://github.com/vkhorikov/CSharpFunctionalExtensions), and his dedication to software development community, with articles, courses, training and great contents about TDD and DDD.


# How to use this SDK

TODO - In progress of documentation

## Installation

TODO - In progress of documentation

## Dependency Injection

TODO - In progress of documentation

# Documentation

TODO - In progress of documentation

# Examples

TODO - In progress of documentation