using Restory.Utils.Observers;
using Zenject;

namespace Restory.ObjectPools
{
	public sealed class UIGameObjectPoolFactory : IFactory<string, UIGameObjectPool>, IFactory
	{
		private readonly DiContainer diContainer;

		private readonly ApplicationQuitStartObserver applicationQuitStartObserver;

		public UIGameObjectPoolFactory(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver)
		{
			this.diContainer = diContainer;
			this.applicationQuitStartObserver = applicationQuitStartObserver;
		}

		public UIGameObjectPool Create(string name = "UIGameObjectPoolContainer")
		{
			return new UIGameObjectPool(diContainer, applicationQuitStartObserver, name);
		}
	}
}
