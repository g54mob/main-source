using System.Reflection;

namespace NodeCanvas.Framework.Internal
{
	public abstract class ReflectedActionWrapper : ReflectedWrapper
	{
		public new static ReflectedActionWrapper Create(MethodInfo method, IBlackboard bb)
		{
			return null;
		}

		public abstract void Call();
	}
}
