using System;
using CTS.BBT;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[Serializable]
	internal sealed class ContextualActionTVFunStation : MenuContextualAction<Television>
	{
		[SerializeField]
		private LocalizedString _displayNameIfOnKey;

		public override void Setup()
		{
		}

		public override string GetDisplayName()
		{
			if (contextActor.IsActive)
			{
				return _displayNameIfOnKey.GetLocalizedString();
			}
			return base.CurrentDisplayText.GetLocalizedString();
		}

		protected override void Execution()
		{
			contextActor.SetActive(!contextActor.IsActive);
		}

		protected override bool CanBePerformed()
		{
			return true;
		}
	}
}
