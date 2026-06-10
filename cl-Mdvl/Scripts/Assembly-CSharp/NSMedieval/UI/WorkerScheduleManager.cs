using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Goap;
using NSMedieval.Repository;
using NSMedieval.State;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class WorkerScheduleManager : WorkerPanelGroup
	{
		[SerializeField]
		private ScheduleHourLayoutItemView hourButton;

		[SerializeField]
		private Transform hourButtonParent;

		private List<SoundButton> hourButtons;

		private SchedulePanelManager schedulePanelManager;

		public override void SetWorker(HumanoidInstance humanoid, WorkerPanelManager panelManager)
		{
			schedulePanelManager = (SchedulePanelManager)panelManager;
			base.SetWorker(humanoid, panelManager);
			SetupButtons();
			OnCopyChange();
			LoadHourColours();
		}

		protected override void CopySettings()
		{
			Dictionary<SoundButton, HourType> dictionary = new Dictionary<SoundButton, HourType>();
			HourType[] scheduleHours = base.Humanoid.ScheduleHours;
			for (int i = 0; i < scheduleHours.Length; i++)
			{
				dictionary.Add(hourButtons[i], scheduleHours[i]);
			}
			schedulePanelManager.CopiedSchedule = dictionary;
		}

		protected override void PasteSettings()
		{
			schedulePanelManager.PasteToWorker(base.Humanoid);
			foreach (var (soundButton2, hourType2) in schedulePanelManager.CopiedSchedule)
			{
				int.TryParse(soundButton2.name, out var result);
				ScheduleData scheduleData = Repository<ScheduleModelRepository, ScheduleModel>.Instance.GetByID("worker").GetScheduleData(hourType2);
				hourButtons[result].GetComponent<Image>().color = scheduleData.Color;
			}
		}

		private void SetupButtons()
		{
			if (hourButtons != null && hourButtons.Count > 0)
			{
				return;
			}
			int hoursInDay = GlobalSaveController.CurrentVillageData.DateAndTime.HoursInDay;
			hourButtons = new List<SoundButton>();
			for (int i = 0; i < hoursInDay; i++)
			{
				SoundButton button = Object.Instantiate(hourButton, hourButtonParent).GetComponent<SoundButton>();
				button.onPointerDown.AddListener(delegate
				{
					OnHourButtonClick(button);
				});
				button.onPointerDrag.AddListener(delegate
				{
					OnHourButtonClick(button);
				});
				button.gameObject.SetActive(value: true);
				button.gameObject.name = i.ToString();
				hourButtons.Add(button);
			}
			LoadHourColours();
		}

		private void DestroyButtons()
		{
			foreach (SoundButton hourButton in hourButtons)
			{
				Object.Destroy(hourButton);
			}
			hourButtons.Clear();
		}

		private void LoadHourColours()
		{
			HourType[] scheduleHours = base.Humanoid.ScheduleHours;
			for (int i = 0; i < scheduleHours.Length; i++)
			{
				if (i < hourButtons.Count)
				{
					SoundButton button = hourButtons[i];
					ChangeHourType(button, scheduleHours[i]);
				}
			}
		}

		private void OnHourButtonClick(SoundButton button)
		{
			ChangeHourType(button, schedulePanelManager.SelectedHourType);
		}

		private void ChangeHourType(SoundButton button, HourType hourType)
		{
			int.TryParse(button.name, out var result);
			ChangeHourType(result, hourType);
		}

		private void ChangeHourType(int index, HourType hourType)
		{
			ScheduleData scheduleData = Repository<ScheduleModelRepository, ScheduleModel>.Instance.GetByID("worker").GetScheduleData(hourType);
			hourButtons[index].GetComponent<Image>().color = scheduleData.Color;
			if (base.Humanoid != null && !base.Humanoid.HasDisposed)
			{
				base.Humanoid.ChangeSchedule(index, hourType);
			}
		}

		private void OnEnable()
		{
			MonoSingleton<UIController>.Instance.OnCopyScheduleSettingsEvent += OnCopyChange;
		}

		private void OnDisable()
		{
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.OnCopyScheduleSettingsEvent -= OnCopyChange;
			}
		}

		private void OnCopyChange()
		{
			base.PasteButton.interactable = schedulePanelManager.CopiedSchedule.Count > 0 && !base.Humanoid.IsInIncognitoMode();
		}
	}
}
