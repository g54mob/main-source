using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class ExhaustInfoScript : MonoBehaviour
	{
		[SerializeField]
		private float _throatRadius = 0.5f;

		public float ThroatRadius => _throatRadius;
	}
}
