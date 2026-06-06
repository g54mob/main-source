using Febucci.TextAnimatorCore.BuiltIn;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator for Unity/Effects/Direct/Color", fileName = "Color Effect")]
	internal sealed class ColorEffectScriptable : ManagedEffectScriptable<ColorEffectState, ColorData>
	{
		protected override ColorEffectState CreateState(ColorData parameters)
		{
			return new ColorEffectState(parameters.color, parameters.mode);
		}
	}
}
