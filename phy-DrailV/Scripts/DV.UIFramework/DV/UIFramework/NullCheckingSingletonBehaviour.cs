using DV.Utils;

namespace DV.UIFramework
{
	public abstract class NullCheckingSingletonBehaviour<T> : SingletonBehaviour<T> where T : __SingletonBehaviourBase
	{
		protected override void Awake()
		{
			base.Awake();
		}
	}
}
