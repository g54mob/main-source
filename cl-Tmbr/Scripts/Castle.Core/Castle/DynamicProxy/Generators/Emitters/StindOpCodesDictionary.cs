using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters
{
	internal sealed class StindOpCodesDictionary : Dictionary<Type, OpCode>
	{
		private static readonly StindOpCodesDictionary dict = new StindOpCodesDictionary();

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

		public static StindOpCodesDictionary Instance => dict;

		private StindOpCodesDictionary()
		{
			Add(typeof(bool), OpCodes.Stind_I1);
			Add(typeof(char), OpCodes.Stind_I2);
			Add(typeof(sbyte), OpCodes.Stind_I1);
			Add(typeof(short), OpCodes.Stind_I2);
			Add(typeof(int), OpCodes.Stind_I4);
			Add(typeof(long), OpCodes.Stind_I8);
			Add(typeof(float), OpCodes.Stind_R4);
			Add(typeof(double), OpCodes.Stind_R8);
			Add(typeof(byte), OpCodes.Stind_I1);
			Add(typeof(ushort), OpCodes.Stind_I2);
			Add(typeof(uint), OpCodes.Stind_I4);
			Add(typeof(ulong), OpCodes.Stind_I8);
		}
	}
}
