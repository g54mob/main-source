using UnityEngine;

namespace TerrainComposer2
{
	[ExecuteInEditMode]
	public class TC_SpawnTerrainHeight : MonoBehaviour
	{
		public float heightOffset;

		private Transform t;

		private void Start()
		{
			t = base.transform;
			SetSpawnHeight();
		}

		private void SetSpawnHeight()
		{
			if (Physics.Raycast(new Ray(t.position + new Vector3(0f, 10000f, 0f), Vector3.down), out var hitInfo))
			{
				t.position = new Vector3(t.position.x, hitInfo.point.y + heightOffset, t.position.z);
			}
		}
	}
}
