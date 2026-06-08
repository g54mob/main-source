using System;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Generators.Emitters
{
	public abstract class ArgumentsUtil
	{
		public static Expression[] ConvertArgumentReferenceToExpression(ArgumentReference[] args)
		{
			Expression[] array = new Expression[args.Length];
			for (int i = 0; i < args.Length; i++)
			{
				array[i] = args[i].ToExpression();
			}
			return array;
		}

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

		public static ReferenceExpression[] ConvertToArgumentReferenceExpression(ParameterInfo[] args)
		{
			ReferenceExpression[] array = new ReferenceExpression[args.Length];
			for (int i = 0; i < args.Length; i++)
			{
				array[i] = new ReferenceExpression(new ArgumentReference(args[i].ParameterType, i + 1));
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

		[Obsolete]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool IsAnyByRef(ParameterInfo[] parameters)
		{
			for (int i = 0; i < parameters.Length; i++)
			{
				if (parameters[i].ParameterType.GetTypeInfo().IsByRef)
				{
					return true;
				}
			}
			return false;
		}
	}
}
