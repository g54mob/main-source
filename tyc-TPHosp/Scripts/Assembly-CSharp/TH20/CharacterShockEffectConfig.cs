using FullInspector.Generated.SharedInstance;
using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Character Shock Effect Config", order = 1113)]
	public class CharacterShockEffectConfig : ScriptableObjectWithID
	{
		public float FlickerDurationMin;

		public float FlickerDurationMax;

		public float EmissiveAmount = 1.6f;

		public Material BlackMaterial;

		public Color ShockColor = Color.white;

		public SharedInstance_TH20TH20_CharModule_Mask CharacterElectricShockSkeletonMask;
	}
}
