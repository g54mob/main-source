using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SelectedSandboxMenu : AnimatedMenuBase
	{
		[SerializeField]
		private SandboxInfoPanel _sandboxInfoPanel;

		public void Setup(SandboxSettings settings, MetagameMap metagameMap, SandboxSaveManager saveManager, DLCManager dlcManager)
		{
			_sandboxInfoPanel.Setup(settings, metagameMap.SaveSystem.GetSaveForSandbox(settings), metagameMap, saveManager, dlcManager, default(SandboxMenu.DLCAndUGCPresence));
		}
	}
}
