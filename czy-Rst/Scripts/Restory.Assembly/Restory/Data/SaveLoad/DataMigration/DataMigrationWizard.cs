using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Restory.Data.SaveLoad.DataMigration
{
	public static class DataMigrationWizard
	{
		private record MigrationScheme
		{
			public Type Type;

			public Type FinalType;

			public MethodInfo MigrationMethod;
		}

		private static readonly Dictionary<Type, MigrationScheme> Schemes = new Dictionary<Type, MigrationScheme>();

		private static readonly HashSet<Type> IgnoredTypes = new HashSet<Type>();

		public static TFinalType Migrate<TFinalType>(object instance, GameObject associatedGameObject)
		{
			if (instance == null)
			{
				return default(TFinalType);
			}
			object obj = instance;
			Type type = obj.GetType();
			try
			{
				MigrationScheme scheme;
				while (!(obj is TFinalType) && !IsIgnored(type) && TryGetMigrationRecord(type, out scheme))
				{
					obj = MigrationWithScheme(obj, scheme, associatedGameObject);
					type = obj.GetType();
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			if (!(obj is TFinalType))
			{
				Debug.LogError($"Failed to migrate {type} to {typeof(TFinalType)}");
			}
			if (obj is IPostMigratable postMigratable)
			{
				postMigratable.PostMigration();
			}
			return (TFinalType)obj;
		}

		private static bool IsIgnored(Type resultType)
		{
			return IgnoredTypes.Contains(resultType);
		}

		private static bool TryGetMigrationRecord(Type forType, out MigrationScheme scheme)
		{
			scheme = null;
			if (Schemes.TryGetValue(forType, out scheme))
			{
				return true;
			}
			MigrateToAttribute migrateToAttribute = (MigrateToAttribute)Attribute.GetCustomAttribute(forType, typeof(MigrateToAttribute));
			if (migrateToAttribute == null)
			{
				IgnoredTypes.Add(forType);
				return false;
			}
			InterfaceMapping interfaceMap;
			try
			{
				interfaceMap = migrateToAttribute.NextType.GetInterfaceMap(typeof(IMigratable<>).MakeGenericType(forType));
			}
			catch (Exception ex)
			{
				Debug.LogException(new Exception("Type must implement IMigratable<T> for each one of the types\n" + ex.Message));
				return false;
			}
			MethodInfo migrationMethod = interfaceMap.InterfaceMethods.First((MethodInfo m) => m.Name == "Migrate");
			scheme = new MigrationScheme
			{
				Type = forType,
				FinalType = migrateToAttribute.NextType,
				MigrationMethod = migrationMethod
			};
			Schemes[forType] = scheme;
			return true;
		}

		private static object MigrationWithScheme(object previousInstance, MigrationScheme migrationScheme, GameObject associatedGameObject)
		{
			object obj = Activator.CreateInstance(migrationScheme.FinalType);
			migrationScheme.MigrationMethod.Invoke(obj, new object[2] { previousInstance, associatedGameObject });
			return obj;
		}
	}
}
