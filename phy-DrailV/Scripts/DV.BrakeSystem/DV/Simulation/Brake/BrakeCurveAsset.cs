using UnityEngine;

namespace DV.Simulation.Brake
{
	[CreateAssetMenu(menuName = "DV/Brakes curve")]
	public class BrakeCurveAsset : ScriptableObject
	{
		public AnimationCurve brakeCurve;
	}
}
