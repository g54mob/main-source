using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("Count = {DebugCount}")]
	[DebuggerTypeProxy(typeof(CustomOptionsDebugView))]
	public sealed class CustomOptions
	{
		private sealed class CustomOptionsDebugView
		{
			private readonly CustomOptions customOptions;

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public KeyValuePair<int, IExtensionValue>[] Items => null;

			public CustomOptionsDebugView(CustomOptions customOptions)
			{
			}
		}

		private const string UnreferencedCodeMessage = "CustomOptions is incompatible with trimming.";

		private static readonly object[] EmptyParameters;

		private readonly IDictionary<int, IExtensionValue> values;

		private int DebugCount => 0;

		internal CustomOptions(IDictionary<int, IExtensionValue> values)
		{
		}

		[RequiresUnreferencedCode("CustomOptions is incompatible with trimming.")]
		public bool TryGetBool(int field, out bool value)
		{
			value = default(bool);
			return false;
		}

		[RequiresUnreferencedCode("CustomOptions is incompatible with trimming.")]
		public bool TryGetInt32(int field, out int value)
		{
			value = default(int);
			return false;
		}

		[RequiresUnreferencedCode("CustomOptions is incompatible with trimming.")]
		public bool TryGetInt64(int field, out long value)
		{
			value = default(long);
			return false;
		}

		[RequiresUnreferencedCode("CustomOptions is incompatible with trimming.")]
		public bool TryGetFixed32(int field, out uint value)
		{
			value = default(uint);
			return false;
		}

		[RequiresUnreferencedCode("CustomOptions is incompatible with trimming.")]
		public bool TryGetFixed64(int field, out ulong value)
		{
			value = default(ulong);
			return false;
		}

		[RequiresUnreferencedCode("CustomOptions is incompatible with trimming.")]
		public bool TryGetSFixed32(int field, out int value)
		{
			value = default(int);
			return false;
		}

		[RequiresUnreferencedCode("CustomOptions is incompatible with trimming.")]
		public bool TryGetSFixed64(int field, out long value)
		{
			value = default(long);
			return false;
		}

		[RequiresUnreferencedCode("CustomOptions is incompatible with trimming.")]
		public bool TryGetSInt32(int field, out int value)
		{
			value = default(int);
			return false;
		}

		[RequiresUnreferencedCode("CustomOptions is incompatible with trimming.")]
		public bool TryGetSInt64(int field, out long value)
		{
			value = default(long);
			return false;
		}

		[RequiresUnreferencedCode("CustomOptions is incompatible with trimming.")]
		public bool TryGetUInt32(int field, out uint value)
		{
			value = default(uint);
			return false;
		}

		[RequiresUnreferencedCode("CustomOptions is incompatible with trimming.")]
		public bool TryGetUInt64(int field, out ulong value)
		{
			value = default(ulong);
			return false;
		}

		[RequiresUnreferencedCode("CustomOptions is incompatible with trimming.")]
		public bool TryGetFloat(int field, out float value)
		{
			value = default(float);
			return false;
		}

		[RequiresUnreferencedCode("CustomOptions is incompatible with trimming.")]
		public bool TryGetDouble(int field, out double value)
		{
			value = default(double);
			return false;
		}

		[RequiresUnreferencedCode("CustomOptions is incompatible with trimming.")]
		public bool TryGetString(int field, out string value)
		{
			value = null;
			return false;
		}

		[RequiresUnreferencedCode("CustomOptions is incompatible with trimming.")]
		public bool TryGetBytes(int field, out ByteString value)
		{
			value = null;
			return false;
		}

		[RequiresUnreferencedCode("CustomOptions is incompatible with trimming.")]
		public bool TryGetMessage<T>(int field, out T value) where T : class, IMessage, new()
		{
			value = null;
			return false;
		}

		[RequiresUnreferencedCode("CustomOptions is incompatible with trimming.")]
		private bool TryGetPrimitiveValue<T>(int field, out T value)
		{
			value = default(T);
			return false;
		}
	}
}
