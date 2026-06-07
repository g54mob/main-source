using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Fade Behavior", menuName = "Text Animator/Animations/Behaviors/Fade")]
	[EffectInfo("fade", EffectCategory.Behaviors)]
	public sealed class FadeBehavior : BehaviorScriptableBase
	{
		private Color32 temp;

		public float baseSpeed = 0.5f;

		public float baseDelay = 1f;

		private float delay;

		private float timeToShow;

		public override void ResetContext(TAnimCore animator)
		{
			delay = baseDelay;
			SetTimeToShow(baseSpeed);
		}

		private void SetTimeToShow(float speed)
		{
			timeToShow = 1f / speed;
		}

		public override void SetModifier(ModifierInfo modifier)
		{
			string text = modifier.name;
			if (!(text == "f"))
			{
				if (text == "d")
				{
					delay = baseDelay * modifier.value;
				}
			}
			else
			{
				SetTimeToShow(baseSpeed * modifier.value);
			}
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			if (character.passedTime <= delay)
			{
				return;
			}
			float num = (character.passedTime - delay) / timeToShow;
			if (num > 1f)
			{
				num = 1f;
			}
			if (num < 1f && num >= 0f)
			{
				for (int i = 0; i < 4; i++)
				{
					temp = character.current.colors[i];
					temp.a = 0;
					character.current.colors[i] = Color32.LerpUnclamped(character.current.colors[i], temp, Tween.EaseInOut(num));
				}
			}
			else
			{
				for (int j = 0; j < 4; j++)
				{
					temp = character.current.colors[j];
					temp.a = 0;
					character.current.colors[j] = temp;
				}
			}
		}
	}
}
