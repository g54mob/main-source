using Febucci.UI.Core;
using UnityEngine;

namespace Febucci.UI.Effects
{
	public abstract class AnimationScriptableBase : ScriptableObject, ITagProvider
	{
		[SerializeField]
		private string tagID;

		private bool initialized;

		public string TagID
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void InitializeOnce()
		{
		}

		protected virtual void OnInitialize()
		{
		}

		private void OnEnable()
		{
		}

		public abstract void ResetContext(TAnimCore animator);

		public virtual void SetModifier(ModifierInfo modifier)
		{
		}

		public abstract float GetMaxDuration();

		public abstract bool CanApplyEffectTo(CharacterData character, TAnimCore animator);

		public abstract void ApplyEffectTo(ref CharacterData character, TAnimCore animator);
	}
}
