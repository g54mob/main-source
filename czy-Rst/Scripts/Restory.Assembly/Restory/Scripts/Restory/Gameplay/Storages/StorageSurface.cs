using UnityEngine;

namespace Restory.Scripts.Restory.Gameplay.Storages
{
	public class StorageSurface : StorageBase
	{
		[SerializeField]
		private BoxCollider surfaceCollider;

		private readonly float initialGridResolutions = 0.2f;

		private readonly int minGridSize = 2;

		protected override void InitStorageGridPositions()
		{
			storageGridPositions.Clear();
			Vector3 center = surfaceCollider.center;
			Vector3 size = surfaceCollider.size;
			Transform transform = surfaceCollider.transform;
			float y = center.y - size.y * 0.5f;
			int num = Mathf.Max((int)(size.x / initialGridResolutions), minGridSize);
			int num2 = Mathf.Max((int)(size.z / initialGridResolutions), minGridSize);
			int num3 = num + (num - 1) * storageGridResolution;
			int num4 = num2 + (num2 - 1) * storageGridResolution;
			for (int num5 = num4 - 1; num5 > 0; num5--)
			{
				float num6 = ((num4 == 1) ? 0.5f : ((float)num5 / (float)(num4 - 1)));
				float z = center.z + (num6 - 0.5f) * size.z;
				for (int i = 0; i < num3; i++)
				{
					float num7 = ((num3 == 1) ? 0.5f : ((float)i / (float)(num3 - 1)));
					float x = center.x + (num7 - 0.5f) * size.x;
					Vector3 position = new Vector3(x, y, z);
					Vector3 item = transform.TransformPoint(position);
					storageGridPositions.Add(item);
				}
			}
		}
	}
}
