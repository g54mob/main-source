using System;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Generators.Emitters
{
	internal abstract class ArgumentsUtil
	{
		public static ArgumentReference[] ConvertToArgumentReference(Type[] args)
		{
			ArgumentReference[] array = new ArgumentReference[args.Length];
			for (int i = 0; i < args.Length; i++)
			{
				array[i] = new ArgumentReference(args[i]);
			}
			return array;
		}

		public static ArgumentReference[] ConvertToArgumentReference(ParameterInfo[] args)
		{
			ArgumentReference[] array = new ArgumentReference[args.Length];
			for (int i = 0; i < args.Length; i++)
			{
				array[i] = new ArgumentReference(args[i].ParameterType);
			}
			return array;
		}

		public static IExpression[] ConvertToArgumentReferenceExpression(ParameterInfo[] args)
		{
			IExpression[] array = new IExpression[args.Length];
			for (int i = 0; i < args.Length; i++)
			{
				array[i] = new ArgumentReference(args[i].ParameterType, i + 1);
			}
			return array;
		}

		public static void EmitLoadOwnerAndReference(Reference reference, ILGenerator il)
		{
			if (reference != null)
			{
				EmitLoadOwnerAndReference(reference.OwnerReference, il);
				reference.LoadReference(il);
			}
		}

		public static Type[] GetTypes(ParameterInfo[] parameters)
		{
			Type[] array = new Type[parameters.Length];
			for (int i = 0; i < parameters.Length; i++)
			{
				array[i] = parameters[i].ParameterType;
			}
			return array;
		}

		public static Type[] InitializeAndConvert(ArgumentReference[] args)
		{
			Type[] array = new Type[args.Length];
			for (int i = 0; i < args.Length; i++)
			{
				args[i].Position = i + 1;
				array[i] = args[i].Type;
			}
			return array;
		}

		public static void InitializeArgumentsByPosition(ArgumentReference[] args, bool isStatic)
		{
			int num = ((!isStatic) ? 1 : 0);
			for (int i = 0; i < args.Length; i++)
			{
				args[i].Position = i + num;
			}
		}
	}
}
