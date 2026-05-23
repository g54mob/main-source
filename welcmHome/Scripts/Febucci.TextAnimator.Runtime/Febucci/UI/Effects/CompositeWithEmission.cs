using System.Collections.Generic;
using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Composite With Emission", menuName = "Text Animator/Animations/Special/Composite With Emission")]
	[EffectInfo("", EffectCategory.All)]
	public sealed class CompositeWithEmission : AnimationScriptableBase
	{
		public TimeMode timeMode = new TimeMode(useUniformTime: true);

		[EmissionCurveProperty]
		public EmissionCurve emissionCurve = new EmissionCurve();

		public AnimationScriptableBase[] animations = new AnimationScriptableBase[0];

		private MeshData prev;

		protected override void OnInitialize()
		{
			base.OnInitialize();
			ValidateArray();
			AnimationScriptableBase[] array = animations;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].InitializeOnce();
			}
			prev = default(MeshData);
			prev.colors = new Color32[4];
			prev.positions = new Vector3[4];
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
			float time = timeMode.GetTime(animator.time.timeSinceStart, character.passedTime, character.index);
			if (time < 0f)
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				prev.positions[i] = character.current.positions[i];
				prev.colors[i] = character.current.colors[i];
			}
			float t = emissionCurve.Evaluate(time);
			AnimationScriptableBase[] array = animations;
			foreach (AnimationScriptableBase animationScriptableBase in array)
			{
				if (animationScriptableBase.CanApplyEffectTo(character, animator))
				{
					animationScriptableBase.ApplyEffectTo(ref character, animator);
				}
			}
			for (int k = 0; k < 4; k++)
			{
				character.current.positions[k] = Vector3.LerpUnclamped(prev.positions[k], character.current.positions[k], t);
				character.current.colors[k] = Color32.LerpUnclamped(prev.colors[k], character.current.colors[k], t);
			}
		}

		public override bool CanApplyEffectTo(CharacterData character, TAnimCore animator)
		{
			return true;
		}

		public override float GetMaxDuration()
		{
			return emissionCurve.GetMaxDuration();
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
