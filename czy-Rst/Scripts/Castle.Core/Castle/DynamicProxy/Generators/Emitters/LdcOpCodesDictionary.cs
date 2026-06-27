using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters
{
	internal sealed class LdcOpCodesDictionary : Dictionary<Type, OpCode>
	{
		private static readonly LdcOpCodesDictionary dict = new LdcOpCodesDictionary();

		private static readonly OpCode emptyOpCode = default(OpCode);

		public new OpCode this[Type type]
		{
			get
			{
				if (TryGetValue(type, out var value))
				{
					return value;
				}
				return EmptyOpCode;
			}
		}

		public static OpCode EmptyOpCode => emptyOpCode;

		public static LdcOpCodesDictionary Instance => dict;

		private LdcOpCodesDictionary()
		{
			Add(typeof(bool), OpCodes.Ldc_I4);
			Add(typeof(char), OpCodes.Ldc_I4);
			Add(typeof(sbyte), OpCodes.Ldc_I4);
			Add(typeof(short), OpCodes.Ldc_I4);
			Add(typeof(int), OpCodes.Ldc_I4);
			Add(typeof(long), OpCodes.Ldc_I8);
			Add(typeof(float), OpCodes.Ldc_R4);
			Add(typeof(double), OpCodes.Ldc_R8);
			Add(typeof(byte), OpCodes.Ldc_I4_0);
			Add(typeof(ushort), OpCodes.Ldc_I4_0);
			Add(typeof(uint), OpCodes.Ldc_I4_0);
			Add(typeof(ulong), OpCodes.Ldc_I4_0);
		}
	}
}
