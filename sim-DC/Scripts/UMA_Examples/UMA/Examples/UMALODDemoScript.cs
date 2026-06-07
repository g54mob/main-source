using UnityEngine;

namespace UMA.Examples
{
	public class UMALODDemoScript : MonoBehaviour
	{
		public int characterCount;

		public float range;

		public float lodDistance;

		public GameObject LODDisplayPrefab;

		[Tooltip("Look for LOD slots in the library.")]
		public bool swapSlots;

		[Tooltip("This value is subtracted from the slot LOD counter.")]
		public int lodOffset;

		private bool isBuilding;

		private UMACrowd crowd;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void CharacterCreated(UMAData umaData)
		{
		}
	}
}
