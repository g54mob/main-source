using UnityEngine;

namespace Jundroo.Common.DataTypes.ScriptableObjects
{
	[CreateAssetMenu(fileName = "Curve", menuName = "SimplePlanes 2/CurveObject")]
	public class AnimationCurveScriptableObject : ScriptableObject
	{
		[SerializeField]
		private AnimationCurve _curve = AnimationCurve.Linear(0f, 1f, 1f, 0f);

		public AnimationCurve Curve => _curve;
	}
}
