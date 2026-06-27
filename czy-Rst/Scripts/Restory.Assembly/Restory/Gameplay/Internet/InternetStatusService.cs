using System;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.Common;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.Equipment.PersonalComputers;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Internet
{
	public class InternetStatusService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent, IActiveStateSwitchRequester
	{
		private PcInteractiveWorkplaceItem pcInteractiveWorkplaceItem;

		private PcKeyboardInteractiveWorkplaceItem pcKeyboardInteractiveWorkplaceItem;

		private bool isInternetOn;

		public bool IsInternetOn
		{
			get
			{
				return isInternetOn;
			}
			set
			{
				if (value != isInternetOn)
				{
					isInternetOn = value;
					SwitchPcInteractivity();
				}
			}
		}

		[Inject]
		private void Construct(PcInteractiveWorkplaceItem pcInteractiveWorkplaceItem, PcKeyboardInteractiveWorkplaceItem pcKeyboardInteractiveWorkplaceItem)
		{
			this.pcInteractiveWorkplaceItem = pcInteractiveWorkplaceItem;
			this.pcKeyboardInteractiveWorkplaceItem = pcKeyboardInteractiveWorkplaceItem;
		}

		private void SwitchPcInteractivity()
		{
			pcInteractiveWorkplaceItem.IsInternetOn = IsInternetOn;
			pcInteractiveWorkplaceItem.IsOn |= IsInternetOn;
			pcInteractiveWorkplaceItem.IsPowerOffLocked = IsInternetOn;
		}

		public object CaptureState()
		{
			try
			{
				return new InternetStatusServiceSaveData
				{
					IsInternetOn = IsInternetOn
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				InternetStatusServiceSaveData internetStatusServiceSaveData = DataMigrationWizard.Migrate<InternetStatusServiceSaveData>(state, base.gameObject);
				isInternetOn = internetStatusServiceSaveData.IsInternetOn;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void PostRestore()
		{
			SwitchPcInteractivity();
		}
	}
}
