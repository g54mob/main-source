using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "RandomDir Appearance", menuName = "Text Animator/Animations/Appearances/Random Direction")]
	[EffectInfo("rdir", EffectCategory.Appearances)]
	public sealed class RandomDirectionAppearance : AppearanceScriptableBase
	{
		public float baseAmount = 10f;

		private float amount;

		private Vector3[] directions;

		public override void ResetContext(TAnimCore animator)
		{
			base.ResetContext(animator);
			amount = baseAmount;
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			directions = new Vector3[20];
			for (int i = 0; i < directions.Length; i++)
			{
				directions[i] = TextUtilities.fakeRandoms[Random.Range(0, 24)] * Mathf.Sign(Mathf.Sin(i));
			}
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			int num = character.index % directions.Length;
			character.current.positions.MoveChar(directions[num] * amount * character.uniformIntensity * Tween.EaseIn(1f - character.passedTime / duration));
		}

		public override void SetModifier(ModifierInfo modifier)
		{
			if (modifier.name == "a")
			{
				amount = baseAmount * modifier.value;
			}
			else
			{
				base.SetModifier(modifier);
			}
		}
	}
}
