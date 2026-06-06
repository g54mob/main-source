using Febucci.TextAnimatorCore.BuiltIn;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Effects/Direct/Rainbow", fileName = "Rainbow Effect")]
	internal sealed class RainbowEffectScriptable : ManagedEffectScriptable<RainbowColorEffectState, RainbowData>
	{
		protected override RainbowColorEffectState CreateState(RainbowData parameters)
		{
			return new RainbowColorEffectState(temp: true);
		}
	}
}
