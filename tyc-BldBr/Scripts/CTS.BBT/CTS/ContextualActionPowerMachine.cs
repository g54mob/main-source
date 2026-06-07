using System;
using CTS.BBT;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[Serializable]
	internal sealed class ContextualActionPowerMachine : MenuContextualAction<MachineBase>
	{
		[SerializeField]
		private LocalizedString _displayNameIfOnKey;

		public override void Setup()
		{
		}

		public override string GetDisplayName()
		{
			if (contextActor.MachinePowerState != EMachinePowerState.Off)
			{
				return _displayNameIfOnKey.GetLocalizedString();
			}
			return base.CurrentDisplayText.GetLocalizedString();
		}

		protected override bool CanBePerformed()
		{
			if (contextActor.MachinePowerState == EMachinePowerState.None)
			{
				return false;
			}
			return true;
		}

		protected override void Execution()
		{
			contextActor.SetMachinePowerState((contextActor.MachinePowerState == EMachinePowerState.On) ? EMachinePowerState.Off : EMachinePowerState.On);
		}
	}
}
