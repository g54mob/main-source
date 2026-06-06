using Febucci.TextAnimatorCore.BuiltIn;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Curves/Linear", fileName = "Linear Curve")]
	public sealed class LinearCurve : CoreLibraryCurveScriptableBase<Febucci.TextAnimatorCore.BuiltIn.LinearCurve>
	{
	}
}
