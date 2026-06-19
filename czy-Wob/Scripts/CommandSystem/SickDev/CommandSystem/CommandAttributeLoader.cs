using System;
using System.Collections.Generic;
using System.Reflection;

namespace SickDev.CommandSystem
{
	internal class CommandAttributeLoader
	{
		private List<CommandBase> commands = new List<CommandBase>();

		private Type[] types;

		private CommandTypeInfo[] commandTypes;

		public CommandAttributeLoader(Config config)
		{
			types = ReflectionFinder.LoadUserClassesAndStructs(config.assembliesWithCommands);
			commandTypes = FilterCommandTypes(types);
		}

		private static CommandTypeInfo[] FilterCommandTypes(Type[] types)
		{
			List<CommandTypeInfo> list = new List<CommandTypeInfo>();
			for (int i = 0; i < types.Length; i++)
			{
				if (types[i].IsSubclassOf(typeof(CommandBase)))
				{
					list.Add(new CommandTypeInfo(types[i]));
				}
			}
			return list.ToArray();
		}

		public CommandBase[] LoadCommands()
		{
			for (int i = 0; i < types.Length; i++)
			{
				commands.AddRange(LoadCommandsInType(types[i]));
			}
			return commands.ToArray();
		}

		private CommandBase[] LoadCommandsInType(Type type)
		{
			List<CommandBase> list = new List<CommandBase>();
			MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			for (int i = 0; i < methods.Length; i++)
			{
				try
				{
					CommandAttributeVerifier commandAttributeVerifier = new CommandAttributeVerifier(methods[i]);
					if (commandAttributeVerifier.hasCommandAttribute)
					{
						CommandBase commandBase = commandAttributeVerifier.ExtractCommand(commandTypes);
						if (commandBase != null)
						{
							list.Add(commandBase);
						}
					}
				}
				catch (CommandSystemException exception)
				{
					CommandsManager.SendException(exception);
				}
			}
			return list.ToArray();
		}
	}
}
