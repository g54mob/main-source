using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Restory.Gameplay.TimeSystems;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine.Scripting;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	[Preserve]
	public class OrdersCheats : SRDebugCheatBase, INotifyPropertyChanged
	{
		private readonly GameCalendar gameCalendar;

		private readonly EmailOrdersService emailOrdersService;

		private const string EMAIL_ORDERS_CATEGORY = "Email Orders Cheats";

		private int selectedEmailOrderIndex;

		[Category("Email Orders Cheats")]
		[DisplayName("Selected Email Order")]
		[SROptions.Sort(1)]
		public string SelectedEmailOrder
		{
			get
			{
				if (selectedEmailOrderIndex >= 0 && selectedEmailOrderIndex < emailOrdersService.TrackedOrders.Count)
				{
					return emailOrdersService.TrackedOrders[selectedEmailOrderIndex].Order.SenderContactInfo.EmailAddress;
				}
				return "None";
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[Category("Email Orders Cheats")]
		[DisplayName("<")]
		[SROptions.Sort(0)]
		public void CycleSelectedEmailOrderLeft()
		{
			SwitchSelectedEmailOrder(-1);
		}

		[Category("Email Orders Cheats")]
		[DisplayName(">")]
		[SROptions.Sort(2)]
		public void CycleSelectedEmailOrderRight()
		{
			SwitchSelectedEmailOrder(1);
		}

		[Category("Email Orders Cheats")]
		[DisplayName("Set Last Day Email Order")]
		[SROptions.Sort(3)]
		public void SetLastDayEmailOrder()
		{
			if (selectedEmailOrderIndex >= 0 && selectedEmailOrderIndex < emailOrdersService.TrackedOrders.Count)
			{
				TrackedEmailOrder trackedEmailOrder = emailOrdersService.TrackedOrders[selectedEmailOrderIndex];
				trackedEmailOrder.Order.NumberDaysToComplete = (gameCalendar.CurrentDateTime - trackedEmailOrder.Order.ReceivedDateTime).Days + 1;
			}
		}

		[Category("Email Orders Cheats")]
		[DisplayName("Set Overdue Email Order")]
		[SROptions.Sort(4)]
		public void SetOverdueEmailOrder()
		{
			if (selectedEmailOrderIndex >= 0 && selectedEmailOrderIndex < emailOrdersService.TrackedOrders.Count)
			{
				TrackedEmailOrder trackedEmailOrder = emailOrdersService.TrackedOrders[selectedEmailOrderIndex];
				trackedEmailOrder.Order.NumberDaysToComplete = (gameCalendar.CurrentDateTime - trackedEmailOrder.Order.ReceivedDateTime).Days;
			}
		}

		private void SwitchSelectedEmailOrder(int increment)
		{
			List<TrackedEmailOrder> trackedOrders = emailOrdersService.TrackedOrders;
			if (trackedOrders != null && trackedOrders.Count != 0)
			{
				if (selectedEmailOrderIndex < 0 || selectedEmailOrderIndex >= trackedOrders.Count)
				{
					selectedEmailOrderIndex = 0;
				}
				int num = (selectedEmailOrderIndex + increment + trackedOrders.Count) % trackedOrders.Count;
				selectedEmailOrderIndex = num;
				OnPropertyChanged("SelectedEmailOrder");
			}
		}

		[Inject]
		public OrdersCheats(EmailOrdersService emailOrdersService, GameCalendar gameCalendar)
		{
			this.emailOrdersService = emailOrdersService;
			this.gameCalendar = gameCalendar;
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
