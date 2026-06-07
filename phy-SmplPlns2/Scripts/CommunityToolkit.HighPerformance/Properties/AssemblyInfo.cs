using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;

[assembly: AssemblyFileVersion("8.2.2.1")]
[assembly: AssemblyInformationalVersion("8.2.2.1+4c21e0294b")]
[assembly: AssemblyMetadata("CommitHash", "4c21e0294bd39f307219259b830485f14f5086ce")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("(c) .NET Foundation and Contributors. All rights reserved.")]
[assembly: AssemblyDescription("\r\n      This package includes high performance .NET helpers such as:\r\n      - Memory2D<T> and Span2D<T>: two types providing fast and allocation-free abstraction over 2D memory areas.\r\n      - ArrayPoolBufferWriter<T>: an IBufferWriter<T> implementation using pooled arrays, which also supports IMemoryOwner<T>.\r\n      - MemoryBufferWriter<T>: an IBufferWriter<T>: implementation that can wrap external Memory<T>: instances.\r\n      - MemoryOwner<T>: an IMemoryOwner<T> implementation with an embedded length and a fast Span<T> accessor.\r\n      - SpanOwner<T>: a stack-only type with the ability to rent a buffer of a specified length and getting a Span<T> from it.\r\n      - StringPool: a configurable pool for string instances that be used to minimize allocations when creating multiple strings from char buffers.\r\n      - String, array, Memory<T>, Span<T> extensions and more, all focused on high performance.\r\n      - HashCode<T>: a SIMD-enabled extension of HashCode to quickly process sequences of values.\r\n      - BitHelper: a class with helper methods to perform bit operations on numeric types.\r\n      - ParallelHelper: helpers to work with parallel code in a highly optimized manner.\r\n      - Box<T>: a type mapping boxed value types and exposing some utility and high performance methods.\r\n      - Ref<T>: a stack-only struct that can store a reference to a value of a specified type.\r\n      - NullableRef<T>: a stack-only struct similar to Ref<T>, which also supports nullable references.\r\n    ")]
[assembly: AssemblyProduct(".NET Community Toolkit")]
[assembly: AssemblyTitle("CommunityToolkit.HighPerformance")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/CommunityToolkit/dotnet")]
[assembly: AssemblyVersion("8.2.0.0")]
[module: SkipLocalsInit]
