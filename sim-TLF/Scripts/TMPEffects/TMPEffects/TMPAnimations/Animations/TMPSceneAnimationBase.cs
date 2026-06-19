using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.ObjectChanged;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	public abstract class TMPSceneAnimationBase : MonoBehaviour, ITMPAnimation, ITMPParameterValidator, INotifyObjectChanged
	{
		public event ObjectChangedEventHandler ObjectChanged;

		public abstract void Animate(CharData cData, IAnimationContext context);

		public abstract object GetNewCustomData();

		public abstract void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase);

		public abstract bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase);

		protected virtual void OnValidate()
		{
			RaiseObjectChanged();
		}

		protected virtual void OnDestroy()
		{
			RaiseObjectChanged();
		}

		protected void RaiseObjectChanged()
		{
			this.ObjectChanged?.Invoke(this);
		}
	}
}
