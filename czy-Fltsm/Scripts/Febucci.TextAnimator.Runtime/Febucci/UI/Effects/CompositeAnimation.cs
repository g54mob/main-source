using System.Collections.Generic;
using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Composite Animation", menuName = "Text Animator/Animations/Special/Composite")]
	[EffectInfo("", EffectCategory.All)]
	public sealed class CompositeAnimation : AnimationScriptableBase
	{
		public AnimationScriptableBase[] animations = new AnimationScriptableBase[0];

		protected override void OnInitialize()
		{
			base.OnInitialize();
			ValidateArray();
			AnimationScriptableBase[] array = animations;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].InitializeOnce();
			}
		}

		public override void ResetContext(TAnimCore animator)
		{
			AnimationScriptableBase[] array = animations;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].ResetContext(animator);
			}
		}

		public override void SetModifier(ModifierInfo modifier)
		{
			base.SetModifier(modifier);
			AnimationScriptableBase[] array = animations;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetModifier(modifier);
			}
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			AnimationScriptableBase[] array = animations;
			foreach (AnimationScriptableBase animationScriptableBase in array)
			{
				if (animationScriptableBase.CanApplyEffectTo(character, animator))
				{
					animationScriptableBase.ApplyEffectTo(ref character, animator);
				}
			}
		}

		public override bool CanApplyEffectTo(CharacterData character, TAnimCore animator)
		{
			return true;
		}

		public override float GetMaxDuration()
		{
			float num = -1f;
			AnimationScriptableBase[] array = animations;
			foreach (AnimationScriptableBase animationScriptableBase in array)
			{
				num = Mathf.Max(num, animationScriptableBase.GetMaxDuration());
			}
			return num;
		}

		private void ValidateArray()
		{
			List<AnimationScriptableBase> list = new List<AnimationScriptableBase>();
			for (int i = 0; i < animations.Length; i++)
			{
				if (animations[i] != this)
				{
					list.Add(animations[i]);
				}
			}
			animations = list.ToArray();
		}

		private void OnValidate()
		{
			ValidateArray();
		}
	}
}
