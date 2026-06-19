using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.ObjectChanged;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations
{
	public abstract class TMPHideAnimation : ScriptableObject, ITMPAnimation, ITMPParameterValidator, INotifyObjectChanged
	{
		public event ObjectChangedEventHandler ObjectChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public abstract void Animate(CharData charData, IAnimationContext context);

		public abstract void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase);

		public abstract bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase);

		public abstract object GetNewCustomData();

		protected virtual void OnValidate()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected void RaiseObjectChanged()
		{
		}
	}
}
