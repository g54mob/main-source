using JUTPS.JUInputSystem;
using UnityEngine;

namespace JUTPS.VehicleSystem
{
	public class VehicleNitroBoost : MonoBehaviour
	{
		public bool UseDefaultInput = true;

		public Vehicle.VehicleNitroBoost Nitro;

		[HideInInspector]
		public bool UseNitro;

		private void Update()
		{
			Nitro.SimulateNitro(UseNitro);
			if (UseDefaultInput)
			{
				if (JUInput.GetButtonDown(JUInput.Buttons.RunButton))
				{
					UseNitro = true;
				}
				else
				{
					UseNitro = false;
				}
			}
		}

		public void DoNitro()
		{
			UseNitro = true;
		}
	}
}
