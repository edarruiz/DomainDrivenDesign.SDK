- [A C# and dotnet Software Development Kit for the Domain-Driven Design concepts](#a-c-and-dotnet-software-development-kit-for-the-domain-driven-design-concepts)
- [Background](#background)
  - [The Core DDD concepts](#the-core-ddd-concepts)
    - [Ubiquitous Language](#ubiquitous-language)
    - [Entities](#entities)
    - [Value Objects](#value-objects)
    - [Domain Services](#domain-services)
    - [Domain Events](#domain-events)
    - [Bounded Contexts](#bounded-contexts)
    - [Aggregates and Aggregate Roots](#aggregates-and-aggregate-roots)
  - [The essential Toolbox - Useful Design and Architecture Patterns](#the-essential-toolbox---useful-design-and-architecture-patterns)
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

I've been using and improving my understanding, knowledge and usage of the DDD concepts over the years using C# and dotnet. As a developer, I'm far from having a perfect implementation model of the very complex vision the book proposes in each and every corner of its theories. Anyway, this SDK is a very realistic effort to achieve a solid and stable code, enriched with the experience I had in various projects using DDD, C# and dotnet in the past.

One of my biggest frustrations when using Domain-Driven Design was, everytime I started working in a new project, new company or new team, I always endup with the requirement of creating all this basic framework of DDD over and over again, from time to time, from solution to solution. Sometimes, we can't just reuse code between projects, teams or companies, for any reason that happens to occurs.

Besides DDD being well known over the past 20 years, until today, I found a good number of developers and teams that had some critical gaps of the fundamentals and some big misunderstanding of the application for some concepts Eric Evans proposes in his book.

And this brought consequences, for every project I went on. From what I could experienced over time over this gaps and misunderstandings, at minimum, was unsuccessful implementations, defected features, mislead results, right implementations in the wrong places, high coupling, high dependency, business model blurring and lots, lots of bugs and refactorings until the "final decent result".

For these and another minor various reasons, this SDK project intend to give you a full range of abstractions and concrete implementations of the concepts existing on the Domain-Driven Design as a standalone Nuget package, built with C# and with the dotnet framework. 

With this SDK, you (and me) can reuse the same implementations without the need of recreating and testing everything we need everytime, over and over again.

Also, this SDK will provide some extended implementations using design patterns that might help you to deal with specific scenarios and business problems inside your application, when you choose to follow the path of using the domain model design to develop your solutions.

## The Core DDD concepts

The Domain-Driven Design strategy is composed by a series of concepts, patterns and good pratices. 

The main goal of Domain-Driven Design is to create a model (representation) that accurately reflects the domain and its associated business rules, which can then be used to drive the design and implementation of the software.

To achieve this, the book provides us a huge number of constraints and careful definitions that should be followed to create a successful domain model design solution.

In the book, the author uses Java to create some examples of the implementations as real and fictitious scenarios to demonstrate the usage of the concepts explained along the chapters. When using C# to create this implementations, we have a lot of tools and powerful ways of how to implement all the DDD concepts within the dotnet framework.

But before that, is very important you notice you should know and master **all the basic concepts** of the domain-driven design before jumping into the code. 

The next sections will give you an overview of the basic concepts without getting too much into the details.

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
- They are UNIQUE
- They have a UNIQUE identity
- They are MUTABLE
- They have a lifecycle and a history
- They have attributes
- They have behaviors
- They have relations
- They have validation constraints
- They reinforce usage of constraints and validations by creational and structural patterns
- They have diferent representations of the same identity
- They can transform through its lifecycle, but holds the same identity
- They cannot be replaced by equivalent instances

### Value Objects

For very system we have values, their meaning and their definitions. For this reason, I like to think the value objects as *a way of describing things*.

Value objects are introduced in the book on chapter 5, when Eric Evans says:

> *"Many objects have no conceptual identity. These objects describe some characteristic of a  hing."*
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

So, these are the key characteristics of a Value  Object:
- They are NOT UNIQUE
- They are IMMUTABLE
- They represent VALUES by its structure
- They have attributes
- They have behaviors
- They can have relations
- They have validation constraints
- They reinforce usage of constraints and validations by creational and structural patterns
- They do not have a lifecycle
- They can be replaced by equivalent instances
- They can reduce complex operations or tasks to represent, simplify and isolate business rules or any domain logic

### Domain Services

TODO - In progress of documentation

### Domain Events

TODO - In progress of documentation

### Bounded Contexts

TODO - In progress of documentation

### Aggregates and Aggregate Roots

Setting the boundaries that tells a story
TODO - In progress of documentation

## The essential Toolbox - Useful Design and Architecture Patterns

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