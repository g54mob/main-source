using Restory.Utils.Observers;
using Zenject;

namespace Restory.ObjectPools
{
	public class UIGameObjectPool : GameObjectPool
	{
		public UIGameObjectPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, string nameContainer = "UIGameObjectPoolContainer")
			: base(diContainer, applicationQuitStartObserver, nameContainer)
		{
		}
	}
}
