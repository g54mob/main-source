using UnityEngine;
using Zenject;

namespace UI.Craft
{
	public class CraftItemFactory : ICraftItemFactory, IFactory<CraftItemView>, IFactory
	{
		private DiContainer _container;

		public CraftItemFactory(DiContainer container)
		{
			_container = container;
		}

		public CraftItemView Create()
		{
			Debug.Log("Creating Item FROM CUSTOM FACTORY");
			return _container.InstantiatePrefabResourceForComponent<CraftItemView>("UI/Craft/CraftIndicator");
		}
	}
}
