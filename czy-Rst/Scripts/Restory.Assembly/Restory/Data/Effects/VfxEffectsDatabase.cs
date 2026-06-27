using UnityEngine;

namespace Restory.Data.Effects
{
	[CreateAssetMenu(menuName = "Restory/Effects/VfxEffectsDatabase", fileName = "VfxEffectsDatabase")]
	public class VfxEffectsDatabase : ScriptableObject
	{
		[SerializeField]
		private ParticleSystem placementVfxPrefab;

		[SerializeField]
		private ParticleSystem sootCleaningVfxPrefab;

		[SerializeField]
		private ParticleSystem solderingVfxPrefab;

		[SerializeField]
		private ParticleSystem moneyVfxPrefab;

		[SerializeField]
		private GameObject checkDeviceVfxPrefab;

		public ParticleSystem PlacementVfxPrefab => placementVfxPrefab;

		public ParticleSystem SootCleaningVfxPrefab => sootCleaningVfxPrefab;

		public ParticleSystem SolderingVfxPrefab => solderingVfxPrefab;

		public ParticleSystem MoneyVfxPrefab => moneyVfxPrefab;

		public GameObject CheckDeviceVfxPrefab => checkDeviceVfxPrefab;
	}
}
