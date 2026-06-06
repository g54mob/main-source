using Febucci.TextAnimatorCore.BuiltIn;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Effects/Direct/Shear", fileName = "Shear Effect")]
	internal sealed class ShearEffectScriptable : ManagedEffectScriptable<ShearEffectState, ShearData>
	{
		protected override ShearEffectState CreateState(ShearData parameters)
		{
			return new ShearEffectState(parameters.amplitude, parameters.vertical, parameters.horizontal);
		}
	}
}
