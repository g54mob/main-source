using Febucci.Numbers;
using Febucci.TextAnimatorCore.BuiltIn;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Effects/Direct/Continuous Rotation", fileName = "Continuous Rotation Effect")]
	[EffectInfo("rot", EffectCategory.Behaviors)]
	internal sealed class RotationEffectScriptable : ManagedEffectScriptable<RotationEffectState, RotationData>
	{
		protected override RotationEffectState CreateState(RotationData parameters)
		{
			return new RotationEffectState(parameters.loopDegrees, parameters.oscillationDegrees, new Febucci.Numbers.Vector3(parameters.customPivot.x, parameters.customPivot.y, 0f));
		}
	}
}
