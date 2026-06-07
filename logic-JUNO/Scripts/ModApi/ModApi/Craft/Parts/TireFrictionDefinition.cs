using UnityEngine;

namespace ModApi.Craft.Parts
{
	public class TireFrictionDefinition : MonoBehaviour
	{
		[Range(0f, 1f)]
		[SerializeField]
		private float _offroadPercentage = 0.1f;

		public float OffroadPercentage => _offroadPercentage;
	}
}
