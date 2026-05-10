using UnityEngine;

namespace Gadd420
{
	[RequireComponent(typeof(RB_Controller))]
	public class PedalManager : MonoBehaviour
	{
		public WheelRotationAxis pedalRotationAxis;

		private RB_Controller rbScript;

		public GameObject pedalRotationOBJ;

		public float gearRatioInFirstGear;

		public float gearRatioInLastGear;

		public GameObject[] pedals;

		private float ogRatioInFirst;

		private Vector3 rotationSpeed;

		private float gearRatioDifference;

		private Input_Manager inputs;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
