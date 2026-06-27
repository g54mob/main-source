using Restory.Utils.Observers;
using Zenject;

namespace Restory.ObjectPools
{
	public sealed class GameObjectPoolFactory : IFactory<string, GameObjectPool>, IFactory
	{
		private readonly DiContainer diContainer;

		private readonly ApplicationQuitStartObserver applicationQuitStartObserver;

		public GameObjectPoolFactory(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver)
		{
			this.diContainer = diContainer;
			this.applicationQuitStartObserver = applicationQuitStartObserver;
		}

		public GameObjectPool Create(string name = "GameObjectPoolContainer")
		{
			return new GameObjectPool(diContainer, applicationQuitStartObserver, name);
		}
	}
}
