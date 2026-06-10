using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class SchedulePanelManager : WorkerPanelManager
	{
		[SerializeField]
		private ButtonLayoutItemView categoryButton;

		[SerializeField]
		private Transform categoryButtonsParent;

		[SerializeField]
		private TMP_Text hourLabel;

		[SerializeField]
		private Transform hourLabelsParent;

		[SerializeField]
		private float elementBaseWidth;

		[SerializeField]
		private float variableElementWidth;

		private HourType selectedHourType;

		private Color selectedColor;

		private float selectionAlpha = 0.1f;

		private List<ButtonLayoutItemView> categoryButtons = new List<ButtonLayoutItemView>();

		private Dictionary<SoundButton, HourType> copiedSchedule = new Dictionary<SoundButton, HourType>();

		private int hoursPerDay;

		public Dictionary<SoundButton, HourType> CopiedSchedule
		{
			get
			{
				if (copiedSchedule == null)
				{
					copiedSchedule = new Dictionary<SoundButton, HourType>();
				}
				return copiedSchedule;
			}
			set
			{
				copiedSchedule = value;
				MonoSingleton<UIController>.Instance.OnCopyScheduleSettings();
			}
		}

		public HourType SelectedHourType => selectedHourType;

		public Color SelectedColor
		{
			get
			{
				_ = selectedColor;
				return selectedColor;
			}
		}

		public void ClearCopiedSettings()
		{
			copiedSchedule.Clear();
			MonoSingleton<UIController>.Instance.OnCopyScheduleSettings();
		}

		public override void PasteToWorker(HumanoidInstance worker)
		{
			if (CopiedSchedule.Count == 0 || worker == null || worker.HasDisposed)
			{
				return;
			}
			foreach (var (soundButton2, newHourType) in CopiedSchedule)
			{
				int.TryParse(soundButton2.name, out var result);
				worker.ChangeSchedule(result, newHourType);
			}
		}

		protected override void OnHelpClick()
		{
			MonoSingleton<UIController>.Instance.ShowAlmanacEntry("Gameplaytipsschedule");
		}

		protected override void Awake()
		{
			base.Awake();
			GenerateCategoryButtons();
			GenerateHoursLabels();
		}

		protected override void Start()
		{
			base.Start();
			SetPreferredWidth(elementBaseWidth + variableElementWidth * (float)hoursPerDay);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			MonoSingleton<UIController>.Instance.OnScheduleHourButtonHoverEvent += base.OnHoverToggle;
			ClearCopiedSettings();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.OnScheduleHourButtonHoverEvent -= base.OnHoverToggle;
			}
		}

		private void OnCategoryButtonClick(ScheduleData data)
		{
			selectedHourType = data.HourType;
			selectedColor = data.Color;
			foreach (ButtonLayoutItemView categoryButton in categoryButtons)
			{
				categoryButton.Select(categoryButton.GetId == data.ID);
			}
		}

		private void GenerateCategoryButtons()
		{
			foreach (ScheduleData data in Repository<ScheduleModelRepository, ScheduleModel>.Instance.GetByID("worker").Schedule)
			{
				if (data.IsHidden)
				{
					continue;
				}
				ButtonLayoutItemView buttonLayoutItemView = Object.Instantiate(categoryButton, categoryButtonsParent);
				buttonLayoutItemView.Select(select: false);
				buttonLayoutItemView.ImageObject.color = data.Color;
				buttonLayoutItemView.SetButtonData(MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(data.LocKeys)));
				buttonLayoutItemView.Button.onClick.AddListener(delegate
				{
					OnCategoryButtonClick(data);
				});
				buttonLayoutItemView.TooltipNew.AppendLine(LocKeyUtils.GetName(data.LocKeys).ToLocalized(BodyType.None), TooltipStyles.TooltipTitle);
				if (LocKeyUtils.GetTooltipLines(data.LocKeys, out var lines))
				{
					string[] array = lines;
					foreach (string locKey in array)
					{
						buttonLayoutItemView.TooltipNew.AppendLine(locKey.ToLocalized(BodyType.None));
					}
				}
				categoryButtons.Add(buttonLayoutItemView);
			}
		}

		private void GenerateHoursLabels()
		{
			hoursPerDay = GlobalSaveController.CurrentVillageData.DateAndTime.HoursInDay;
			for (int i = 0; i < hoursPerDay; i++)
			{
				TMP_Text component = Object.Instantiate(hourLabel, hourLabelsParent).GetComponent<TMP_Text>();
				component.text = i.ToString();
				component.gameObject.SetActive(value: true);
			}
		}
	}
}
