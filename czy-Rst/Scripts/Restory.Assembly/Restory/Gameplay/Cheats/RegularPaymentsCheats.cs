using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.RegularPayments;
using Restory.Gameplay.TimeSystems;
using UnityEngine.Scripting;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	[Preserve]
	public class RegularPaymentsCheats : SRDebugCheatBase, INotifyPropertyChanged
	{
		private readonly GameCalendar gameCalendar;

		private readonly RegularPaymentObjectRegistry regularPaymentObjectRegistry;

		private const string COMMON_CATEGORY = "Regular Payments Cheats";

		private RegularPaymentObject selectedRegularPaymentObject;

		[Category("Regular Payments Cheats")]
		[DisplayName("Selected Regular Payment")]
		[SROptions.Sort(1)]
		public string SelectedRegularPayment
		{
			get
			{
				if (!(selectedRegularPaymentObject == null))
				{
					return selectedRegularPaymentObject.gameObject.name;
				}
				return "None";
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[Category("Regular Payments Cheats")]
		[DisplayName("<")]
		[SROptions.Sort(0)]
		public void CycleSelectedRegularPaymentObjectLeft()
		{
			SwitchSelectedRegularPaymentObject(-1);
		}

		[Category("Regular Payments Cheats")]
		[DisplayName(">")]
		[SROptions.Sort(2)]
		public void CycleSelectedRegularPaymentObjectRight()
		{
			SwitchSelectedRegularPaymentObject(1);
		}

		[Category("Regular Payments Cheats")]
		[DisplayName("Set Overdue Regular Payment")]
		[SROptions.Sort(3)]
		public void SetOverdueRegularPaymentObject()
		{
			if (selectedRegularPaymentObject != null)
			{
				InteractiveObjectAdditionalProperties additionalProperties = selectedRegularPaymentObject.InteractiveObject.AdditionalProperties;
				if (additionalProperties.TryToGetProperty<RegularPaymentDeliveryDateInteractiveObjectProperty>(out var foundProperty))
				{
					DateTime deliveryTime = gameCalendar.CurrentDateTime.AddDays(-selectedRegularPaymentObject.RegularPaymentInfo.DaysForPayment);
					additionalProperties.RemoveProperty(foundProperty);
					additionalProperties.TryToAddProperty(new RegularPaymentDeliveryDateInteractiveObjectProperty(deliveryTime));
				}
			}
		}

		[Category("Regular Payments Cheats")]
		[DisplayName("Set Not Overdue Regular Payment")]
		[SROptions.Sort(4)]
		public void SetNotOverdueRegularPaymentObject()
		{
			if (selectedRegularPaymentObject != null)
			{
				InteractiveObjectAdditionalProperties additionalProperties = selectedRegularPaymentObject.InteractiveObject.AdditionalProperties;
				if (additionalProperties.TryToGetProperty<RegularPaymentDeliveryDateInteractiveObjectProperty>(out var foundProperty))
				{
					additionalProperties.RemoveProperty(foundProperty);
					additionalProperties.TryToAddProperty(new RegularPaymentDeliveryDateInteractiveObjectProperty(gameCalendar.CurrentDateTime));
				}
			}
		}

		private void SwitchSelectedRegularPaymentObject(int increment)
		{
			IReadOnlyCollection<RegularPaymentObject> all = regularPaymentObjectRegistry.All;
			if (all != null && all.Count != 0)
			{
				RegularPaymentObject[] array = all.ToArray();
				int num = Array.IndexOf(array, selectedRegularPaymentObject);
				if (num < 0 || num >= array.Length)
				{
					num = 0;
				}
				num = (num + increment + array.Length) % array.Length;
				selectedRegularPaymentObject = array[num];
				OnPropertyChanged("SelectedRegularPayment");
			}
		}

		[Inject]
		public RegularPaymentsCheats(RegularPaymentObjectRegistry regularPaymentObjectRegistry, GameCalendar gameCalendar)
		{
			this.regularPaymentObjectRegistry = regularPaymentObjectRegistry;
			this.gameCalendar = gameCalendar;
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
