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
				return tagID;
			}
			set
			{
				tagID = value;
			}
		}

		public void InitializeOnce()
		{
			if (!initialized)
			{
				initialized = true;
				OnInitialize();
			}
		}

		protected virtual void OnInitialize()
		{
		}

		private void OnEnable()
		{
			initialized = false;
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
