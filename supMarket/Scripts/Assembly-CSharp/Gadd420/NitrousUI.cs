using UnityEngine;
using UnityEngine.UI;

namespace Gadd420
{
	public class NitrousUI : MonoBehaviour
	{
		public NitrousManager nitrousScript;

		private VehicleSelect vehicleSelect;

		public Text tankNo;

		public Slider slider;

		[Header("False If you arent using my vehicle Selection script")]
		public bool inTestScene;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
