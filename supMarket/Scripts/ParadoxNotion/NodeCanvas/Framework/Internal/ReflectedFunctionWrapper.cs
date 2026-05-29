using System.Reflection;

namespace NodeCanvas.Framework.Internal
{
	public abstract class ReflectedFunctionWrapper : ReflectedWrapper
	{
		public new static ReflectedFunctionWrapper Create(MethodInfo method, IBlackboard bb)
		{
			return null;
		}

		public abstract object Call();
	}
}
