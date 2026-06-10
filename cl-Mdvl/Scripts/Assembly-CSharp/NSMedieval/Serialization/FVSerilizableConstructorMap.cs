using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;

namespace NSMedieval.Serialization
{
	public class FVSerilizableConstructorMap : MonoSingleton<FVSerilizableConstructorMap>
	{
		[NonSerialized]
		private Dictionary<int, int> formerlySerialized;

		private bool initialized;

		[field: NonSerialized]
		public Dictionary<int, ConstructorInfo> Constructors { get; private set; }

		public new static FVSerilizableConstructorMap Instance
		{
			get
			{
				FVSerilizableConstructorMap fVSerilizableConstructorMap = MonoSingleton<FVSerilizableConstructorMap>.Instance;
				if (!fVSerilizableConstructorMap.initialized)
				{
					fVSerilizableConstructorMap.initialized = true;
					fVSerilizableConstructorMap.PopulateMap();
				}
				return fVSerilizableConstructorMap;
			}
		}

		public ConstructorInfo GetByID(int hash)
		{
			if (Constructors.ContainsKey(hash))
			{
				return Constructors[hash];
			}
			if (formerlySerialized.ContainsKey(hash))
			{
				return Constructors[formerlySerialized[hash]];
			}
			return null;
		}

		private void PopulateMap()
		{
			Constructors = new Dictionary<int, ConstructorInfo>();
			formerlySerialized = new Dictionary<int, int>();
			foreach (Type item in FindAllClassesImplementingInterface<IFVSerializable>())
			{
				ConstructorInfo[] constructors = item.GetConstructors();
				foreach (ConstructorInfo constructorInfo in constructors)
				{
					ParameterInfo[] parameters = constructorInfo.GetParameters();
					for (int j = 0; j < parameters.Length; j++)
					{
						if (parameters[j].ParameterType != typeof(FVDeserializer))
						{
							continue;
						}
						FVSerializableKey customAttribute = item.GetCustomAttribute<FVSerializableKey>();
						if (customAttribute == null)
						{
							bool isEnabled;
							FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\FVSerilizableConstructorMap.cs");
							if (isEnabled)
							{
								messageBuilder.AppendLiteral("Missing FVSerializableKey for class ");
								messageBuilder.AppendFormatted(item.FullName);
							}
							Log.Error(messageBuilder);
							continue;
						}
						Constructors.Add(customAttribute.Key.GetHashCode(), constructorInfo);
						if (!string.IsNullOrEmpty(customAttribute.FormerKey))
						{
							string[] array = customAttribute.FormerKey.Split(new char[2] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
							foreach (string text in array)
							{
								formerlySerialized.Add(text.GetHashCode(), customAttribute.Key.GetHashCode());
							}
						}
					}
				}
			}
		}

		private static IEnumerable<Type> FindAllClassesImplementingInterface<T>()
		{
			List<Type> list = new List<Type>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				list.AddRange(from t in assembly.GetTypes()
					where (t.IsClass || t.IsValueType) && typeof(T).IsAssignableFrom(t)
					select t);
			}
			return list;
		}
	}
}
