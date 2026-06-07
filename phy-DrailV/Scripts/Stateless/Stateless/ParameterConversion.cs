using System;

namespace Stateless
{
	internal static class ParameterConversion
	{
		public static object Unpack(object[] args, Type argType, int index)
		{
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			if (args.Length == 0)
			{
				return null;
			}
			if (args.Length <= index)
			{
				throw new ArgumentException(string.Format(ParameterConversionResources.ArgOfTypeRequiredInPosition, argType, index));
			}
			object obj = args[index];
			if (obj != null && !argType.IsInstanceOfType(obj))
			{
				throw new ArgumentException(string.Format(ParameterConversionResources.WrongArgType, index, obj.GetType(), argType));
			}
			return obj;
		}

		public static TArg Unpack<TArg>(object[] args, int index)
		{
			if (args.Length == 0)
			{
				return default(TArg);
			}
			return (TArg)Unpack(args, typeof(TArg), index);
		}

		public static void Validate(object[] args, Type[] expected)
		{
			if (args.Length > expected.Length)
			{
				throw new ArgumentException(string.Format(ParameterConversionResources.TooManyParameters, expected.Length, args.Length));
			}
			for (int i = 0; i < expected.Length; i++)
			{
				Unpack(args, expected[i], i);
			}
		}
	}
}
