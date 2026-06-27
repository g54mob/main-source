using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Restory.AssetManagement;
using Restory.Data.Base;
using Restory.Data.PC;
using Restory.Gameplay.PC;
using UnityEngine.Scripting;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	[Preserve]
	public class PcAppsCheats : SRDebugCheatBase, INotifyPropertyChanged
	{
		private readonly PcAppManager pcAppManager;

		private readonly List<PcAppInfo> pcAppInfos = new List<PcAppInfo>();

		private const string COMMON_CATEGORY = "Pc Apps Cheats";

		private PcAppInfo selectedPcAppInfo;

		[Category("Pc Apps Cheats")]
		[DisplayName("Selected PC App")]
		[SROptions.Sort(1)]
		public string SelectedPcApp
		{
			get
			{
				if (!(selectedPcAppInfo == null))
				{
					return selectedPcAppInfo.ID;
				}
				return "None";
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[Category("Pc Apps Cheats")]
		[DisplayName("<")]
		[SROptions.Sort(0)]
		public void CycleSelectedPcAppLeft()
		{
			SwitchSelectedPcApp(-1);
		}

		[Category("Pc Apps Cheats")]
		[DisplayName(">")]
		[SROptions.Sort(2)]
		public void CycleSelectedPcAppRight()
		{
			SwitchSelectedPcApp(1);
		}

		[Category("Pc Apps Cheats")]
		[DisplayName("Install PC App")]
		[SROptions.Sort(3)]
		public void InstallPcApp()
		{
			if (selectedPcAppInfo != null)
			{
				pcAppManager.InstallPcApp(selectedPcAppInfo);
			}
		}

		[Category("Pc Apps Cheats")]
		[DisplayName("Activate PC App")]
		[SROptions.Sort(4)]
		public void ActivatePcApp()
		{
			if (selectedPcAppInfo != null)
			{
				pcAppManager.ActivatePcApp(selectedPcAppInfo);
			}
		}

		private void SwitchSelectedPcApp(int increment)
		{
			List<PcAppInfo> list = pcAppInfos;
			if (list != null && list.Count != 0)
			{
				int num = list.IndexOf(selectedPcAppInfo);
				if (num < 0 || num >= list.Count)
				{
					num = 0;
				}
				num = (num + increment + list.Count) % list.Count;
				selectedPcAppInfo = list[num];
				OnPropertyChanged("SelectedPcApp");
			}
		}

		[Inject]
		public PcAppsCheats(PcAppManager pcAppManager, GameEntityDataBaseProvider gameEntityDataBaseProvider)
		{
			this.pcAppManager = pcAppManager;
			pcAppInfos = gameEntityDataBaseProvider.Asset.All.Where((RestoryEntityInfoBase entity) => entity is PcAppInfo).Cast<PcAppInfo>().ToList();
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
