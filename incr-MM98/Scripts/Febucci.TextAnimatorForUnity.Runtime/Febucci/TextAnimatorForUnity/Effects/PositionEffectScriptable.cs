using Febucci.TextAnimatorCore.BuiltIn;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Effects/Direct/Position", fileName = "Position Effect")]
	internal sealed class PositionEffectScriptable : ManagedEffectScriptable<PositionEffectState, PositionData>
	{
		protected override PositionEffectState CreateState(PositionData parameters)
		{
			return new PositionEffectState(parameters.direction * parameters.amplitude);
		}
	}
}
