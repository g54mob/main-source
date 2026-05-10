using UnityEngine;

namespace CTS
{
	public interface IDependencyResolver
	{
		void ResolveDependencies(GameObject obj);
	}
	public interface IDependencyResolver<in T>
	{
		void ResolveDependencies(GameObject obj, T data);
	}
}
