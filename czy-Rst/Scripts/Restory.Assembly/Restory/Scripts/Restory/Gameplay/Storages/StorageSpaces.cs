using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Restory.Scripts.Restory.Gameplay.Storages
{
	public class StorageSpaces : MonoBehaviour, IInitializable
	{
		[SerializeField]
		private List<StorageBase> freeStorageSpaceSearchOrder;

		public IReadOnlyCollection<StorageBase> FreeStorageSpaceSearchOrder => freeStorageSpaceSearchOrder;

		public void Initialize()
		{
			foreach (StorageBase item in freeStorageSpaceSearchOrder)
			{
				item.Init();
			}
		}
	}
}
