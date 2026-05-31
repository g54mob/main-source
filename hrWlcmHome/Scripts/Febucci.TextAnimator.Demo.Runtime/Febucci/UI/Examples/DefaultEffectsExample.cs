using Febucci.UI.Core;
using Febucci.UI.Effects;
using UnityEngine;

namespace Febucci.UI.Examples
{
	[AddComponentMenu("")]
	public class DefaultEffectsExample : MonoBehaviour
	{
		public TypewriterCore typewriter;

		private TextAnimatorSettings settings;

		private void Awake()
		{
			settings = TextAnimatorSettings.Instance;
		}

		private string AddEffect<T>(TextAnimatorSettings.Category<T> category, string tag) where T : ScriptableObject
		{
			return $"{category.openingSymbol}{tag}{category.closingSymbol}{tag}{category.openingSymbol}/{category.closingSymbol}, ";
		}

		private void Start()
		{
			string text = "<b>You can add effects by using <color=red>rich text tags</color>.</b>" + $"\nExample: writing {'"'}<noparse><shake>I'm cold</shake></noparse>{'"'} will result in {'"'}<shake>I'm cold</shake>{'"'}." + $"\n\n Effects that animate through time are called {'"'}<color=red>Behaviors</color>{'"'}, and the default tags are: ";
			foreach (AnimationScriptableBase datum in typewriter.TextAnimator.DatabaseBehaviors.Data)
			{
				if ((bool)datum)
				{
					text += AddEffect(settings.behaviors, datum.TagID);
				}
			}
			text += $"\n\n<b>Effects that animate letters while they appear on screen are called {'"'}<color=red>Appearances</color>{'"'} and the default tags are</b>: ";
			foreach (AnimationScriptableBase datum2 in typewriter.TextAnimator.DatabaseAppearances.Data)
			{
				if ((bool)datum2)
				{
					text += AddEffect(settings.appearances, datum2.TagID);
				}
			}
			typewriter.ShowText(text);
		}
	}
}
