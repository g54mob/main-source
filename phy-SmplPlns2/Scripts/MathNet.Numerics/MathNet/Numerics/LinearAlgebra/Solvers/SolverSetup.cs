using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MathNet.Numerics.LinearAlgebra.Solvers
{
	public static class SolverSetup<T> where T : struct, IEquatable<T>, IFormattable
	{
		public static IEnumerable<IIterativeSolverSetup<T>> LoadFromAssembly(Assembly assembly, bool ignoreFailed = true, params Type[] typesToExclude)
		{
			Type setupInterfaceType = typeof(IIterativeSolverSetup<T>);
			IEnumerable<Type> enumerable = from type in assembly.GetTypes()
				where !type.IsAbstract && !type.IsEnum && !type.IsInterface && type.IsVisible
				where type.GetInterfaces().Any(setupInterfaceType.IsAssignableFrom)
				select type;
			List<IIterativeSolverSetup<T>> list = new List<IIterativeSolverSetup<T>>();
			foreach (Type item in enumerable)
			{
				try
				{
					list.Add((IIterativeSolverSetup<T>)Activator.CreateInstance(item));
				}
				catch
				{
					if (!ignoreFailed)
					{
						throw;
					}
				}
			}
			List<Type> excludedTypes = new List<Type>(typesToExclude);
			return from s in list
				where !excludedTypes.Any((Type t) => t.IsAssignableFrom(s.SolverType) || t.IsAssignableFrom(s.PreconditionerType))
				orderby s.SolutionSpeed / s.Reliability
				select s;
		}

		public static IEnumerable<IIterativeSolverSetup<T>> LoadFromAssembly(Type typeInAssembly, bool ignoreFailed = true, params Type[] typesToExclude)
		{
			return LoadFromAssembly(typeInAssembly.Assembly, ignoreFailed, typesToExclude);
		}

		public static IEnumerable<IIterativeSolverSetup<T>> LoadFromAssembly(AssemblyName assemblyName, bool ignoreFailed = true, params Type[] typesToExclude)
		{
			return LoadFromAssembly(Assembly.Load(assemblyName.FullName), ignoreFailed, typesToExclude);
		}

		public static IEnumerable<IIterativeSolverSetup<T>> Load(Type[] typesToExclude)
		{
			return LoadFromAssembly(typeof(SolverSetup<T>), ignoreFailed: false, typesToExclude);
		}

		public static IEnumerable<IIterativeSolverSetup<T>> Load()
		{
			return LoadFromAssembly(typeof(SolverSetup<T>), false);
		}
	}
}
