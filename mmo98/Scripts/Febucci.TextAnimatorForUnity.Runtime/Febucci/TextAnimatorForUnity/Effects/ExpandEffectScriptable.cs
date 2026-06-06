using Febucci.TextAnimatorCore.BuiltIn;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Effects/Direct/Expand", fileName = "Expand Effect")]
	internal sealed class ExpandEffectScriptable : ManagedEffectScriptable<ExpandEffectState, ExpandData>
	{
		protected override ExpandEffectState CreateState(ExpandData parameters)
		{
			return new ExpandEffectState(parameters.amplitude, parameters.mode);
		}
	}
}
