using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.ObjectChanged;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations
{
	public abstract class TMPAnimation : ScriptableObject, ITMPAnimation, ITMPParameterValidator, INotifyObjectChanged
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

		public abstract void Animate(CharData cData, IAnimationContext context);

		public abstract bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase);

		public abstract object GetNewCustomData();

		public abstract void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase);

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
