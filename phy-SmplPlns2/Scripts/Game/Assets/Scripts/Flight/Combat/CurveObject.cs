using UnityEngine;

namespace Assets.Scripts.Flight.Combat
{
	[CreateAssetMenu(fileName = "Curve", menuName = "SimplePlanes/CurveObject", order = 3)]
	public class CurveObject : ScriptableObject
	{
		public AnimationCurve Curve = AnimationCurve.Linear(0f, 1f, 1f, 0f);
	}
}
