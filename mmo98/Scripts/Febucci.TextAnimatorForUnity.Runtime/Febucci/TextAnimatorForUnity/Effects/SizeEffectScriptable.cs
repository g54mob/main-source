using Febucci.TextAnimatorCore.BuiltIn;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Effects/Direct/Scale", fileName = "Scale Effect")]
	internal sealed class SizeEffectScriptable : ManagedEffectScriptable<SizeEffectState, SizeData>
	{
		protected override SizeEffectState CreateState(SizeData parameters)
		{
			return new SizeEffectState(parameters.scale);
		}
	}
}
