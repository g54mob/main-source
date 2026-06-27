using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class ElementFactory
	{
		private readonly DiContainer diContainer;

		[Inject]
		private ElementFactory(DiContainer diContainer)
		{
			this.diContainer = diContainer;
		}

		public ElementBase CreateElement(ElementBase elementPrefab, Vector3 spawnPosition)
		{
			ElementBase elementBase = diContainer.InstantiatePrefabForComponent<ElementBase>(elementPrefab.gameObject);
			elementBase.transform.position = spawnPosition;
			elementBase.Init();
			elementBase.InSocket = false;
			return elementBase;
		}

		public void DestroyElement(ElementBase element)
		{
			Object.Destroy(element.gameObject);
		}
	}
}
