using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters
{
	public sealed class LdindOpCodesDictionary : Dictionary<Type, OpCode>
	{
		private static readonly LdindOpCodesDictionary dict = new LdindOpCodesDictionary();

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

		public static LdindOpCodesDictionary Instance => dict;

		private LdindOpCodesDictionary()
		{
			Add(typeof(bool), OpCodes.Ldind_I1);
			Add(typeof(char), OpCodes.Ldind_I2);
			Add(typeof(sbyte), OpCodes.Ldind_I1);
			Add(typeof(short), OpCodes.Ldind_I2);
			Add(typeof(int), OpCodes.Ldind_I4);
			Add(typeof(long), OpCodes.Ldind_I8);
			Add(typeof(float), OpCodes.Ldind_R4);
			Add(typeof(double), OpCodes.Ldind_R8);
			Add(typeof(byte), OpCodes.Ldind_U1);
			Add(typeof(ushort), OpCodes.Ldind_U2);
			Add(typeof(uint), OpCodes.Ldind_U4);
			Add(typeof(ulong), OpCodes.Ldind_I8);
		}
	}
}
