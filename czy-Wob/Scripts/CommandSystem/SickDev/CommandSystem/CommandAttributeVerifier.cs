using System;
using System.Linq;
using System.Reflection;

namespace SickDev.CommandSystem
{
	internal class CommandAttributeVerifier
	{
		private MethodInfo method;

		private CommandAttribute attribute;

		private CommandTypeInfo commandType;

		public bool hasCommandAttribute => attribute != null;

		public CommandAttributeVerifier(MethodInfo method)
		{
			this.method = method;
			attribute = Attribute.GetCustomAttribute(method, typeof(CommandAttribute)) as CommandAttribute;
		}

		public CommandBase ExtractCommand(CommandTypeInfo[] commandTypes)
		{
			CommandBase commandBase = null;
			if (IsDeclarationSupported())
			{
				CheckCommandTypeMatch(commandTypes);
				if (commandType == null)
				{
					throw new NoSuitableCommandFoundException(method);
				}
				return (CommandBase)Activator.CreateInstance(commandType.type, Delegate.CreateDelegate(commandType.firstParameter.ParameterType, method), attribute.description, attribute.alias);
			}
			throw new UnsupportedCommandDeclarationException(method);
		}

		private bool IsDeclarationSupported()
		{
			return method.IsStatic && !method.IsGenericMethod && !method.IsGenericMethodDefinition;
		}

		private void CheckCommandTypeMatch(CommandTypeInfo[] commandTypes)
		{
			ParameterInfo[] parameters = method.GetParameters();
			Type[] array = new Type[parameters.Length];
			for (int i = 0; i < parameters.Length; i++)
			{
				array[i] = parameters[i].ParameterType;
			}
			for (int j = 0; j < commandTypes.Length; j++)
			{
				if (parameters.Length != commandTypes[j].parametersLength)
				{
					continue;
				}
				if (BothAreAction(method, commandTypes[j]))
				{
					if (commandTypes[j].isGeneric)
					{
						commandType = commandTypes[j].MakeGeneric(array);
					}
					else
					{
						commandType = commandTypes[j];
					}
					break;
				}
				if (BothAreFunc(method, commandTypes[j]))
				{
					if (commandTypes[j].isGeneric)
					{
						commandType = commandTypes[j].MakeGeneric(array.Concat(new Type[1] { method.ReturnType }).ToArray());
					}
					else
					{
						commandType = commandTypes[j];
					}
					break;
				}
			}
		}

		private static bool BothAreAction(MethodInfo method, CommandTypeInfo commandType)
		{
			return (object)method.ReturnType == typeof(void) && !commandType.isFunc;
		}

		private static bool BothAreFunc(MethodInfo method, CommandTypeInfo commandType)
		{
			return (object)method.ReturnType != typeof(void) && commandType.isFunc;
		}
	}
}
