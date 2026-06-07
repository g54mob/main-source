using Brewery.CombatSystem;
using UnityEngine;

namespace Brewery.Face
{
	public class StaminaFaceProbe : FaceStateProbe
	{
		[Tooltip("Stamina ratio (0..1) at or below which the exhausted face is full.")]
		[SerializeField]
		private float fullIntensityAt;

		[Tooltip("Stamina ratio above which the exhausted face is off.")]
		[SerializeField]
		private float zeroIntensityAt;

		private SimpleCombatController _combat;

		public override string ProbeId => null;

		private void Awake()
		{
		}

		public override float Evaluate01()
		{
			return 0f;
		}
	}
}
