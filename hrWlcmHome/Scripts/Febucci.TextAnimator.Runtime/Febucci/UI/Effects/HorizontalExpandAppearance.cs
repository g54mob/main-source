using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Horizontal Expand Appearance", menuName = "Text Animator/Animations/Appearances/Horizontal Expand")]
	[EffectInfo("horiexp", EffectCategory.Appearances)]
	public sealed class HorizontalExpandAppearance : AppearanceScriptableBase
	{
		public enum ExpType
		{
			Left = 0,
			Middle = 1,
			Right = 2
		}

		public ExpType type;

		private Vector2 startTop;

		private Vector2 startBot;

		private float pct;

		public override void ResetContext(TAnimCore animator)
		{
			base.ResetContext(animator);
			type = ExpType.Left;
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			pct = Tween.EaseInOut(character.passedTime / duration);
			switch (type)
			{
			default:
				startTop = character.current.positions[1];
				startBot = character.current.positions[0];
				character.current.positions[2] = Vector3.LerpUnclamped(startTop, character.current.positions[2], pct);
				character.current.positions[3] = Vector3.LerpUnclamped(startBot, character.current.positions[3], pct);
				break;
			case ExpType.Right:
				startTop = character.current.positions[2];
				startBot = character.current.positions[3];
				character.current.positions[1] = Vector3.LerpUnclamped(startTop, character.current.positions[1], pct);
				character.current.positions[0] = Vector3.LerpUnclamped(startBot, character.current.positions[0], pct);
				break;
			case ExpType.Middle:
				startTop = (character.current.positions[1] + character.current.positions[2]) / 2f;
				startBot = (character.current.positions[0] + character.current.positions[3]) / 2f;
				character.current.positions[1] = Vector3.LerpUnclamped(startTop, character.current.positions[1], pct);
				character.current.positions[2] = Vector3.LerpUnclamped(startTop, character.current.positions[2], pct);
				character.current.positions[0] = Vector3.LerpUnclamped(startBot, character.current.positions[0], pct);
				character.current.positions[3] = Vector3.LerpUnclamped(startBot, character.current.positions[3], pct);
				break;
			}
		}

		public override void SetModifier(ModifierInfo modifier)
		{
			if (modifier.name == "x")
			{
				float value = modifier.value;
				if (value != -1f)
				{
					if (value != 0f)
					{
						if (value == 1f)
						{
							type = ExpType.Right;
						}
						else
						{
							Debug.LogError($"Text Animator: you set an '{modifier.name}' modifier with value '{modifier.value}' for the HorizontalExpandAppearance effect, but it can only be '-1', '0', or '1'");
						}
					}
					else
					{
						type = ExpType.Middle;
					}
				}
				else
				{
					type = ExpType.Left;
				}
			}
			else
			{
				base.SetModifier(modifier);
			}
		}
	}
}
