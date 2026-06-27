using System.Collections.Generic;
using UnityEngine;

namespace Restory.Scripts.Restory.Gameplay.Storages
{
	public abstract class StorageBase : MonoBehaviour
	{
		[SerializeField]
		[Range(0f, 4f)]
		protected int storageGridResolution = 1;

		[SerializeField]
		[Range(0f, 360f)]
		private float rotationOffsetY;

		protected readonly List<Vector3> storageGridPositions = new List<Vector3>();

		public IReadOnlyList<Vector3> StorageGridPositions => storageGridPositions;

		public Quaternion RefinedRotation { get; private set; }

		public void Init()
		{
			RefinedRotation = Quaternion.Euler(0f, rotationOffsetY, 0f);
			InitStorageGridPositions();
		}

		protected abstract void InitStorageGridPositions();
	}
}
