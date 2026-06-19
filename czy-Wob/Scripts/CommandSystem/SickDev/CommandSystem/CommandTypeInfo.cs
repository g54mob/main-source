using System;
using System.Reflection;

namespace SickDev.CommandSystem
{
	internal class CommandTypeInfo
	{
		public Type type { get; private set; }

		public bool isGeneric { get; private set; }

		public ConstructorInfo constructor { get; private set; }

		public ParameterInfo firstParameter { get; private set; }

		public bool isFunc { get; private set; }

		public int parametersLength { get; private set; }

		public CommandTypeInfo(Type type)
		{
			try
			{
				this.type = type;
				isGeneric = type.IsGenericType && type.IsGenericTypeDefinition;
				SetConstructor();
				SetExtraInfo();
			}
			catch (CommandSystemException exception)
			{
				CommandsManager.SendException(exception);
			}
		}

		private void SetConstructor()
		{
			bool flag = false;
			ConstructorInfo[] constructors = type.GetConstructors();
			for (int i = 0; i < constructors.Length; i++)
			{
				if (constructors[i].IsPublic)
				{
					ParameterInfo[] parameters = constructors[i].GetParameters();
					if (parameters.Length >= 3 && parameters[0].ParameterType.IsSubclassOf(typeof(Delegate)) && (object)parameters[1].ParameterType == typeof(string) && (object)parameters[2].ParameterType == typeof(string))
					{
						constructor = constructors[i];
						firstParameter = parameters[0];
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				throw new InvalidCommandTypeConstructorException(type);
			}
		}

		private void SetExtraInfo()
		{
			MethodInfo method = firstParameter.ParameterType.GetMethod("Invoke");
			isFunc = (object)method.ReturnType != typeof(void);
			parametersLength = method.GetParameters().Length;
		}

		public CommandTypeInfo MakeGeneric(Type[] paramTypes)
		{
			Type type = this.type.MakeGenericType(paramTypes);
			return new CommandTypeInfo(type);
		}
	}
}
