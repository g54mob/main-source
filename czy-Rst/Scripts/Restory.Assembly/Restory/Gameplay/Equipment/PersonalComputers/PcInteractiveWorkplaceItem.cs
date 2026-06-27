using System;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.DetectableObjects;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Restory.Gameplay.Equipment.PersonalComputers
{
	public class PcInteractiveWorkplaceItem : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IDetectableObject
	{
		[FormerlySerializedAs("webBrowserTrigger")]
		[SerializeField]
		private ClickableTrigger pcTrigger;

		[FormerlySerializedAs("webBrowserTriggerCollider")]
		[SerializeField]
		private Collider pcTriggerCollider;

		[SerializeField]
		private ClickableTrigger onOffTrigger;

		[SerializeField]
		private Collider onOffTriggerCollider;

		[SerializeField]
		private PcInteractiveWorkplaceItemVisualizer visualizer;

		private bool isOn;

		private bool isInternetOn;

		private bool isPowerOffLocked;

		public bool CanBeDetected
		{
			set
			{
				pcTrigger.enabled = value;
				onOffTrigger.enabled = value;
			}
		}

		public ClickableTrigger Trigger => pcTrigger;

		public bool IsOn
		{
			get
			{
				return isOn;
			}
			set
			{
				if (value != isOn && (value || !isPowerOffLocked))
				{
					isOn = value;
					UpdateDisplay();
					UpdateTriggers();
				}
			}
		}

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
					UpdateDisplay();
					UpdateTriggers();
				}
			}
		}

		public bool IsPowerOffLocked
		{
			get
			{
				return isPowerOffLocked;
			}
			set
			{
				isPowerOffLocked = value;
			}
		}

		public event Action OnPcOpened;

		private void OnEnable()
		{
			UpdateDisplay();
			UpdateTriggers();
			onOffTrigger.OnClick += ResolveOnOffClick;
			pcTrigger.OnClick += ResolvePcClick;
		}

		private void OnDisable()
		{
			onOffTrigger.OnClick -= ResolveOnOffClick;
			pcTrigger.OnClick -= ResolvePcClick;
		}

		public bool TryOpenWindowsXP()
		{
			if (IsOn && IsInternetOn)
			{
				this.OnPcOpened?.Invoke();
				return true;
			}
			return false;
		}

		private void UpdateDisplay()
		{
			if (!IsOn)
			{
				visualizer.ShowBlackScreen();
			}
			else if (IsInternetOn)
			{
				visualizer.ShowDesktop();
			}
			else
			{
				visualizer.ShowNoInternet();
			}
		}

		private void UpdateTriggers()
		{
			pcTriggerCollider.enabled = IsOn && IsInternetOn;
			onOffTriggerCollider.enabled = !IsOn || !IsInternetOn;
		}

		private void ResolveOnOffClick()
		{
			IsOn = !IsOn;
		}

		private void ResolvePcClick()
		{
			if (IsInternetOn)
			{
				if (!IsOn)
				{
					IsOn = true;
				}
				TryOpenWindowsXP();
			}
			else
			{
				IsOn = !IsOn;
			}
		}

		public object CaptureState()
		{
			try
			{
				return new PcInteractiveWorkplaceItemSaveData
				{
					IsOn = isOn,
					IsInternetOn = isInternetOn,
					IsPowerOffLocked = isPowerOffLocked
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
				PcInteractiveWorkplaceItemSaveData pcInteractiveWorkplaceItemSaveData = DataMigrationWizard.Migrate<PcInteractiveWorkplaceItemSaveData>(state, base.gameObject);
				isOn = pcInteractiveWorkplaceItemSaveData.IsOn;
				isInternetOn = pcInteractiveWorkplaceItemSaveData.IsInternetOn;
				isPowerOffLocked = pcInteractiveWorkplaceItemSaveData.IsPowerOffLocked;
				UpdateDisplay();
				UpdateTriggers();
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
