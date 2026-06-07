using UnityEngine;
using UnityEngine.Serialization;

namespace Motorways.Views.MeshGeneration
{
	public class CarparkMeshCombineInfo : MonoBehaviour
	{
		[SerializeField]
		public CarparkMesh[] singleCarparkMeshes;

		[SerializeField]
		public CarparkMesh singleCarparkTopLeftOpen;

		[SerializeField]
		public CarparkMesh singleCarparkTopLeftClosed;

		[SerializeField]
		public CarparkMesh singleCarparkBottomRightOpen;

		[SerializeField]
		public CarparkMesh singleCarparkBottomRightClosed;

		[SerializeField]
		public CarparkMesh[] doubleCarparkTiles;

		[SerializeField]
		public CarparkMesh doubleCarparkTopLeftOpen;

		[SerializeField]
		public CarparkMesh doubleCarparkTopLeftClosed;

		[SerializeField]
		public CarparkMesh doubleCarparkBottomRightOpen;

		[SerializeField]
		public CarparkMesh doubleCarparkBottomRightClosed;

		[SerializeField]
		public CarparkMesh doubleCarparkTopLeftCorner;

		[SerializeField]
		public CarparkMesh doubleCarparkTopRightCorner;

		[FormerlySerializedAs("ferryTopLeftCorner")]
		[SerializeField]
		public CarparkMesh boatTopLeftCorner;

		[SerializeField]
		[FormerlySerializedAs("ferryTopRightCorner")]
		public CarparkMesh boatTopRightCorner;

		[SerializeField]
		[FormerlySerializedAs("ferryTopLeftEntrance")]
		public CarparkMesh boatTopLeftEntrance;

		[SerializeField]
		[FormerlySerializedAs("ferryTopRightEntrance")]
		public CarparkMesh boatTopRightEntrance;

		[SerializeField]
		public CarparkMesh[] reversedDoubleCarparkTiles;

		[SerializeField]
		public CarparkMesh reversedDoubleCarparkTopLeftOpen;

		[SerializeField]
		public CarparkMesh reversedDoubleCarparkTopLeftClosed;

		[SerializeField]
		public CarparkMesh reversedDoubleCarparkBottomRightOpen;

		[SerializeField]
		public CarparkMesh reversedDoubleCarparkBottomRightClosed;

		public void Remove()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			foreach (Transform item in base.transform)
			{
				Object.Destroy(item.gameObject);
			}
			Object.Destroy(base.gameObject);
		}
	}
}
