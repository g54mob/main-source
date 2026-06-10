using NSMedieval.Views.Resources;
using UnityEngine;
using UnityEngine.Serialization;

namespace NSMedieval.BuildingComponents
{
	public class FuelConsumerFireComponent : MonoBehaviour, IPoolableMonoBehaviour
	{
		[SerializeField]
		private GameObject pointLight;

		[FormerlySerializedAs("flameMeshRenderer")]
		[SerializeField]
		private MeshRenderer[] flameMeshRenderers;

		[SerializeField]
		private MeshVariationHandler meshVariationHandler;

		[SerializeField]
		private string audioEventId;

		public GameObject PointLight => pointLight;

		public MeshRenderer[] FlameMeshRenderers => flameMeshRenderers;

		public MeshVariationHandler MeshVariationHandler => meshVariationHandler;

		public string AudioEventId => audioEventId;
	}
}
