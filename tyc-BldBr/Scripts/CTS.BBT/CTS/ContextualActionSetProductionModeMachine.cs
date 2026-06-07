using System;
using CTS.BBT;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[Serializable]
	[Obsolete("This functionality was discontinued after the integration of the new machine management interface - Dorian 13/08/24")]
	internal sealed class ContextualActionSetProductionModeMachine : MenuContextualAction<MachineBase>
	{
		[SerializeField]
		private LocalizedString _productionModeSafeKey;

		[SerializeField]
		private LocalizedString _productionModeNormalKey;

		[SerializeField]
		private LocalizedString _productionModeOverclockKey;

		private string _productionText;

		public override void Setup()
		{
		}

		public override string GetDisplayName()
		{
			switch (contextActor.MachineProductionMode)
			{
			case EMachineProductionMode.Safe:
				_productionText = base.CurrentDisplayText.GetLocalizedString() + " " + _productionModeNormalKey.GetLocalizedString();
				break;
			case EMachineProductionMode.Normal:
				_productionText = base.CurrentDisplayText.GetLocalizedString() + " " + _productionModeOverclockKey.GetLocalizedString();
				break;
			case EMachineProductionMode.Overclocked:
				_productionText = base.CurrentDisplayText.GetLocalizedString() + " " + _productionModeSafeKey.GetLocalizedString();
				break;
			}
			return _productionText;
		}

		protected override bool CanBePerformed()
		{
			return contextActor.MachineProductionMode != EMachineProductionMode.None;
		}

		protected override void Execution()
		{
			switch (contextActor.MachineProductionMode)
			{
			case EMachineProductionMode.Safe:
				contextActor.SetProductionMode(EMachineProductionMode.Normal);
				break;
			case EMachineProductionMode.Normal:
				contextActor.SetProductionMode(EMachineProductionMode.Overclocked);
				break;
			case EMachineProductionMode.Overclocked:
				contextActor.SetProductionMode(EMachineProductionMode.Safe);
				break;
			}
		}
	}
}
