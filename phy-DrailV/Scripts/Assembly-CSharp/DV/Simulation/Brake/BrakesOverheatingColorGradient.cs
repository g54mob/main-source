using UnityEngine;

namespace DV.Simulation.Brake
{
	[CreateAssetMenu(menuName = "DV/Brakes overheat color gradient")]
	public class BrakesOverheatingColorGradient : ScriptableObject
	{
		[GradientUsage(true)]
		public Gradient colorGradient;
	}
}
