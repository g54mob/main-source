using System;
using System.Reflection;
using Gilzoide.UpdateManager.Extensions;

namespace Gilzoide.UpdateManager.Jobs.Internal
{
	public static class UpdateJobOptions
	{
		public const int DefaultBatchSize = 64;

		public static int GetBatchSize<TData>()
		{
			JobBatchSizeAttribute customAttribute = typeof(TData).GetCustomAttribute<JobBatchSizeAttribute>();
			if (customAttribute != null)
			{
				return customAttribute.BatchSize;
			}
			UpdateJobOptionsAttribute customAttribute2 = typeof(TData).GetCustomAttribute<UpdateJobOptionsAttribute>();
			if (customAttribute2 != null && customAttribute2.BatchSize > 0)
			{
				return customAttribute2.BatchSize;
			}
			return 64;
		}

		public static bool GetReadOnlyTransformAccess<TData>()
		{
			if (typeof(TData).GetCustomAttribute<ReadOnlyTransformAccessAttribute>() == null)
			{
				return typeof(TData).GetCustomAttribute<UpdateJobOptionsAttribute>()?.ReadOnlyTransforms ?? false;
			}
			return true;
		}

		public static Type[] GetDependsOn<TData>()
		{
			DependsOnAttribute customAttribute = typeof(TData).GetCustomAttribute<DependsOnAttribute>();
			if (customAttribute != null)
			{
				Type[] dependencyTypes = customAttribute.DependencyTypes;
				if (dependencyTypes != null && dependencyTypes.Length != 0)
				{
					return customAttribute.DependencyTypes;
				}
			}
			return Array.Empty<Type>();
		}

		public static IJobManager[] GetDependsOnManagers<TData>()
		{
			Type[] dependsOn = GetDependsOn<TData>();
			if (dependsOn.Length == 0)
			{
				return Array.Empty<IJobManager>();
			}
			IJobManager[] array = new IJobManager[dependsOn.Length];
			for (int i = 0; i < dependsOn.Length; i++)
			{
				Type type = dependsOn[i];
				if (type.IsIUpdateJob())
				{
					array[i] = (IJobManager)typeof(UpdateJobManager<>).MakeGenericType(type).GetProperty("Instance").GetValue(null);
					continue;
				}
				if (type.IsIUpdateTransformJob())
				{
					array[i] = (IJobManager)typeof(UpdateTransformJobManager<>).MakeGenericType(type).GetProperty("Instance").GetValue(null);
					continue;
				}
				throw new ArgumentException($"Dependency type '{type}' must implement IUpdateJob or IUpdateTransformJob", "DependencyTypes");
			}
			return array;
		}

		public static bool GetIsBurstCompiled<TData>()
		{
			if (!typeof(TData).ImplementsGenericInterface(typeof(IBurstUpdateJob<>)))
			{
				return typeof(TData).ImplementsGenericInterface(typeof(IBurstUpdateTransformJob<>));
			}
			return true;
		}
	}
}
