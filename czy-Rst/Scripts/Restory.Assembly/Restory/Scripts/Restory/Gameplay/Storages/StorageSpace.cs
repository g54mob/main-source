using UnityEngine;

namespace Restory.Scripts.Restory.Gameplay.Storages
{
	public class StorageSpace : StorageBase
	{
		[SerializeField]
		private LineRenderer storageLine;

		protected override void InitStorageGridPositions()
		{
			if (storageLine.positionCount < 2)
			{
				Debug.LogError("StorageSpace line renderer position count must be at least 2");
				return;
			}
			Vector3[] array = new Vector3[storageLine.positionCount];
			for (int i = 0; i < array.Length; i++)
			{
				Vector3 position = storageLine.GetPosition(i);
				Vector3 position2 = new Vector3(position.x, 0f, position.z);
				array[i] = base.transform.TransformPoint(position2);
			}
			storageGridPositions.Clear();
			if (storageGridResolution <= 0)
			{
				storageGridPositions.AddRange(array);
				return;
			}
			for (int j = 0; j < array.Length - 1; j++)
			{
				Vector3 vector = array[j];
				Vector3 vector2 = array[j + 1];
				storageGridPositions.Add(vector);
				if (!((vector2 - vector).sqrMagnitude <= Mathf.Epsilon))
				{
					for (int k = 1; k <= storageGridResolution; k++)
					{
						float t = (float)k / (float)(storageGridResolution + 1);
						storageGridPositions.Add(Vector3.Lerp(vector, vector2, t));
					}
				}
			}
			storageGridPositions.Add(array[^1]);
		}
	}
}
