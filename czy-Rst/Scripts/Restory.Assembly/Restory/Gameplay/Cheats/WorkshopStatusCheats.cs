using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Restory.AssetManagement;
using Restory.Data.Base;
using Restory.Data.WorkshopStatus;
using Restory.Gameplay.WorkshopStatus;
using UnityEngine.Scripting;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	[Preserve]
	public class WorkshopStatusCheats : SRDebugCheatBase, INotifyPropertyChanged
	{
		private readonly WorkshopStatusService workshopStatusService;

		private readonly List<StatusInfo> statuses = new List<StatusInfo>();

		private const string COMMON_CATEGORY = "Status Cheats";

		private StatusInfo selectedStatus;

		[Category("Status Cheats")]
		[DisplayName("Selected Status")]
		[SROptions.Sort(1)]
		public string SelectedStatus
		{
			get
			{
				if (!(selectedStatus == null))
				{
					return selectedStatus.ID;
				}
				return "None";
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[Category("Status Cheats")]
		[DisplayName("<")]
		[SROptions.Sort(0)]
		public void CycleSelectedStatusLeft()
		{
			SwitchSelectedStatus(-1);
		}

		[Category("Status Cheats")]
		[DisplayName(">")]
		[SROptions.Sort(2)]
		public void CycleSelectedStatusRight()
		{
			SwitchSelectedStatus(1);
		}

		[Category("Status Cheats")]
		[DisplayName("Add Status")]
		[SROptions.Sort(4)]
		public void AddStatus()
		{
			if (selectedStatus != null)
			{
				workshopStatusService.AddStatus(selectedStatus);
			}
		}

		[Category("Status Cheats")]
		[DisplayName("Remove Status")]
		[SROptions.Sort(5)]
		public void RemoveStatus()
		{
			if (selectedStatus != null)
			{
				workshopStatusService.RemoveStatus(selectedStatus);
			}
		}

		private void SwitchSelectedStatus(int increment)
		{
			if (statuses != null && statuses.Count != 0)
			{
				int num = statuses.IndexOf(selectedStatus);
				if (num < 0 || num >= statuses.Count)
				{
					num = 0;
				}
				num = (num + increment + statuses.Count) % statuses.Count;
				selectedStatus = statuses[num];
				OnPropertyChanged("SelectedStatus");
			}
		}

		[Inject]
		public WorkshopStatusCheats(WorkshopStatusService workshopStatusService, GameEntityDataBaseProvider gameEntityDataBaseProvider)
		{
			this.workshopStatusService = workshopStatusService;
			statuses = gameEntityDataBaseProvider.Asset.All.Where((RestoryEntityInfoBase entity) => entity is StatusInfo).Cast<StatusInfo>().ToList();
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
