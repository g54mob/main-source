using UnityEngine;

namespace ModApi.Data
{
	[CreateAssetMenu(fileName = "Curve", menuName = "SimpleRockets 2/CurveObject")]
	public class CurveObject : ScriptableObject
	{
		[SerializeField]
		private AnimationCurve _curve = AnimationCurve.Linear(0f, 1f, 1f, 0f);

		public AnimationCurve Curve => _curve;
	}
}
