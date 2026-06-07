using Febucci.TextAnimatorCore.BuiltIn;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Effects/Direct/Random Position", fileName = "Random Position Effect")]
	internal sealed class RandomPositionEffect : ManagedEffectScriptable<RandomPositionEffectState, RandomPositionData>
	{
		protected override RandomPositionEffectState CreateState(RandomPositionData parameters)
		{
			return new RandomPositionEffectState(parameters.amplitude, parameters.progressIndexWithTime);
		}
	}
}
