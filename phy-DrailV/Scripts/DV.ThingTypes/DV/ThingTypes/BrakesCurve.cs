using UnityEngine;

namespace DV.ThingTypes
{
	[CreateAssetMenu(menuName = "DV/Object Model/Brakes curve", fileName = "BrakesCurve_")]
	public class BrakesCurve : ScriptableObject
	{
		public AnimationCurve brakesCurve;
	}
}
