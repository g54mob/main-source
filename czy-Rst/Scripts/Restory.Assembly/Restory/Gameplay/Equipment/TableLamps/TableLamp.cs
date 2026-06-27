using System;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.DetectableObjects;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;

namespace Restory.Gameplay.Equipment.TableLamps
{
	public class TableLamp : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IDetectableObject
	{
		[SerializeField]
		private ClickableTrigger[] onOffTriggers = Array.Empty<ClickableTrigger>();

		[SerializeField]
		private TableLampVisualizer visualizer;

		private bool isOn;

		public bool CanBeDetected
		{
			set
			{
				ClickableTrigger[] array = onOffTriggers;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].enabled = value;
				}
			}
		}

		public bool IsOn
		{
			get
			{
				return isOn;
			}
			set
			{
				if (isOn != value)
				{
					isOn = value;
					visualizer.SetIsOn(isOn);
					this.OnIsOnChanged?.Invoke();
				}
			}
		}

		public event Action OnIsOnChanged;

		private void OnEnable()
		{
			visualizer.SetIsOn(isOn);
			ClickableTrigger[] array = onOffTriggers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnClick += ResolveOnOffClick;
			}
		}

		private void OnDisable()
		{
			ClickableTrigger[] array = onOffTriggers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnClick -= ResolveOnOffClick;
			}
		}

		private void ResolveOnOffClick()
		{
			IsOn = !IsOn;
		}

		public object CaptureState()
		{
			try
			{
				return new TableLampSaveData
				{
					IsOn = isOn
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
				TableLampSaveData tableLampSaveData = DataMigrationWizard.Migrate<TableLampSaveData>(state, base.gameObject);
				IsOn = tableLampSaveData.IsOn;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
