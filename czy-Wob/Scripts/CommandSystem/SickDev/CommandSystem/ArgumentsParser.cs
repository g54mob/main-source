using System;
using System.Collections.Generic;
using System.Reflection;

namespace SickDev.CommandSystem
{
	internal class ArgumentsParser
	{
		private Dictionary<Type, MethodInfo> parsers;

		public ArgumentsParser()
		{
			Load();
		}

		private void Load()
		{
			parsers = new Dictionary<Type, MethodInfo>();
			Type[] array = ReflectionFinder.LoadUserClassesAndStructs();
			for (int i = 0; i < array.Length; i++)
			{
				MethodInfo[] methods = array[i].GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				for (int j = 0; j < methods.Length; j++)
				{
					object[] customAttributes = methods[j].GetCustomAttributes(typeof(ParserAttribute), inherit: false);
					if (customAttributes.Length != 0)
					{
						ParserAttribute parserAttribute = (ParserAttribute)customAttributes[0];
						if (!parsers.ContainsKey(parserAttribute.type))
						{
							parsers.Add(parserAttribute.type, methods[j]);
						}
						else
						{
							CommandsManager.SendException(new DuplicatedParserException(parserAttribute));
						}
					}
				}
			}
		}

		private bool HasParserForType(Type type)
		{
			return parsers.ContainsKey(type);
		}

		public object Parse(string value, Type type)
		{
			if (HasParserForType(type))
			{
				return parsers[type].Invoke(null, new object[1] { value });
			}
			throw new NoValidParserFoundException(type);
		}
	}
}
