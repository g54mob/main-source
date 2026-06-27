using UnityEngine;

namespace Restory.Data.Effects
{
	[CreateAssetMenu(menuName = "Restory/Effects/CleaningVfxEffect", fileName = "CleaningVfxEffect")]
	public class CleaningVfxSettings : ScriptableObject
	{
		private static class Style
		{
			public const string ResidueParticleColors = "Residue Particles Colors";
		}

		[SerializeField]
		private ParticleSystem cleanedResidueVfxPrefab;

		[SerializeField]
		[Range(0.1f, 3f)]
		private float residueEmissionMinTime = 0.2f;

		[SerializeField]
		[Range(0f, 0.1f)]
		private float delayBeforeResidueEmissionStarts = 0.02f;

		[SerializeField]
		private Color dustResidueFirstColor = Color.white;

		[SerializeField]
		private Color dustResidueSecondColor = Color.grey;

		[SerializeField]
		private Color dirtResidueFirstColor = Color.black;

		[SerializeField]
		private Color dirtResidueSecondColor = Color.black;

		[SerializeField]
		private Color rustResidueFirstColor = Color.red;

		[SerializeField]
		private Color rustResidueSecondColor = Color.red;

		[SerializeField]
		[Range(0f, 5f)]
		private float minCleanedColorAmountToTriggerResidueVfx = 0.001f;

		public ParticleSystem CleanedResidueVfxPrefab => cleanedResidueVfxPrefab;

		public float ResidueEmissionMinTime => residueEmissionMinTime;

		public float DelayBeforeResidueEmissionStarts => delayBeforeResidueEmissionStarts;

		public Color DustResidueFirstColor => dustResidueFirstColor;

		public Color DustResidueSecondColor => dustResidueSecondColor;

		public Color DirtResidueFirstColor => dirtResidueFirstColor;

		public Color DirtResidueSecondColor => dirtResidueSecondColor;

		public Color RustResidueFirstColor => rustResidueFirstColor;

		public Color RustResidueSecondColor => rustResidueSecondColor;

		public float MinCleanedColorAmountToTriggerResidueVfx => minCleanedColorAmountToTriggerResidueVfx;
	}
}
