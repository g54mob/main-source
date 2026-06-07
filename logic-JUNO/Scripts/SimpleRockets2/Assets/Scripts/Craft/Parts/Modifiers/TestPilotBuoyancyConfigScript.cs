using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class TestPilotBuoyancyConfigScript : MonoBehaviour
	{
		[Range(-1f, 10f)]
		[SerializeField]
		private float _buoyancyScale = 1f;

		[SerializeField]
		private Vector3 _centerOfBuoyancy = Vector3.zero;

		public float BuoyancyScale => _buoyancyScale;

		public Vector3 CenterOfBuoyancy => _centerOfBuoyancy;
	}
}
