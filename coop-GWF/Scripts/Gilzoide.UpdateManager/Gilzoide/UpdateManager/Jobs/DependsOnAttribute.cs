using System;
using Gilzoide.UpdateManager.Extensions;

namespace Gilzoide.UpdateManager.Jobs
{
	[AttributeUsage(AttributeTargets.Struct)]
	public class DependsOnAttribute : Attribute
	{
		public Type[] DependencyTypes { get; private set; }

		public DependsOnAttribute(params Type[] dependencyTypes)
		{
			AssertUpdateJobTypes(dependencyTypes);
			DependencyTypes = dependencyTypes;
		}

		public static void AssertUpdateJobTypes(params Type[] dependencyTypes)
		{
			foreach (Type type in dependencyTypes)
			{
				if (!type.IsValueType)
				{
					throw new ArgumentException($"Dependency type must be a struct type: '{type}'", "dependencyTypes");
				}
				if (!type.IsIUpdateJob() && !type.IsIUpdateTransformJob())
				{
					throw new ArgumentException($"Dependency type must implement IUpdateJob or IUpdateTransformJob: '{type}'", "dependencyTypes");
				}
			}
		}
	}
}
