using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using Data.Buildings;
using Data.Notifications;
using Data.Operator;
using Data.Progression;
using Data.Shapes;
using Events.UI.Notifications;
using Presentation.UI.Menus.FullscreenPage;
using TMPro;
using UnityEngine;

namespace Presentation.UI.Menus.ProgressionStats
{
	public class GeneralProgressionUI : SimplePage
	{
		[SerializeField]
		private ProgressionManagerLocator _progressionManagerLocator;

		[Header("Monuments")]
		[SerializeField]
		private TextMeshProUGUI _monumentsTitleText;

		[SerializeField]
		private SerializedDictionary<BuildingObjectData, ProgressionMonumentState> _monuments;

		[SerializeField]
		[LocaKey]
		private string _monumentsTitleLocakey;

		[SerializeField]
		private ProgressionMonumentEvent _monumentStateChangedEvent;

		[Header("Modules")]
		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private TextMeshProUGUI _modulesTitleText;

		[SerializeField]
		private ProgressionModuleState _progressionModulePrefab;

		[SerializeField]
		private Transform _moduleParent;

		[SerializeField]
		[LocaKey]
		private string _modulesTitleLocakey;

		[SerializeField]
		private NotificationEvent _moduleFirstCreatedEvent;

		private readonly Dictionary<ShapeData, ProgressionModuleState> _moduleLibrary = new Dictionary<ShapeData, ProgressionModuleState>();

		private string _monumentsTitle;

		private string _modulesTitle;

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= UpdateTexts;
		}

		private void UpdateTexts()
		{
			_monumentsTitle = LocalizationUtility.GetLocalizedText(_monumentsTitleLocakey);
			_modulesTitle = LocalizationUtility.GetLocalizedText(_modulesTitleLocakey);
		}

		public override void Initialize()
		{
			LocalizationUtility.OnLanguageUpdate += UpdateTexts;
			UpdateTexts();
			BuildModules();
		}

		public override void ShowPage()
		{
			_moduleFirstCreatedEvent.Register(OnModuleFirstCreated);
			_monumentStateChangedEvent.Register(OnMonumentStateChanged);
			UpdateMonuments();
			UpdateModules();
			base.gameObject.SetActive(value: true);
		}

		public override void HidePage()
		{
			_moduleFirstCreatedEvent.UnRegister(OnModuleFirstCreated);
			_monumentStateChangedEvent.UnRegister(OnMonumentStateChanged);
			base.gameObject.SetActive(value: false);
		}

		private void UpdateMonuments()
		{
			foreach (KeyValuePair<BuildingObjectData, ProgressionMonumentState> monument in _monuments)
			{
				monument.Value.SetStateDefault();
			}
			for (int i = 0; i < _progressionManagerLocator.ProgressionMonuments.MonumentInfos.Count; i++)
			{
				SetMonumentState(_progressionManagerLocator.ProgressionMonuments.MonumentInfos[i]);
			}
			_monumentsTitleText.SetText($"{_monumentsTitle}  <size=80%>({_progressionManagerLocator.ProgressionMonuments.BuiltMonumentCount}/{_monuments.Count})</size>");
		}

		private void BuildModules()
		{
			_moduleLibrary.Clear();
			for (int i = 0; i < _factoryObjectDatabase.BuildingsObjectData.BuildingDatas.Count; i++)
			{
				BuildingObjectData buildingObjectData = _factoryObjectDatabase.BuildingsObjectData.BuildingDatas[i];
				if (buildingObjectData == null)
				{
					continue;
				}
				int num = 0;
				foreach (DioramaEditorSave.DioramaShapeCollection value in buildingObjectData.DioramaSave.DioramaShapesDictionary.Values)
				{
					if (!_moduleLibrary.ContainsKey(value.ShapeData.Data))
					{
						ProgressionModuleState progressionModuleState = Object.Instantiate(_progressionModulePrefab, _moduleParent);
						progressionModuleState.Build(buildingObjectData, num, value.ShapeData.Data.GridIcon);
						progressionModuleState.SetStateDefault();
						num++;
						_moduleLibrary.Add(value.ShapeData.Data, progressionModuleState);
					}
				}
			}
		}

		private void UpdateModules()
		{
			int num = 0;
			foreach (KeyValuePair<ShapeData, ProgressionModuleState> item in _moduleLibrary)
			{
				if (_progressionManagerLocator.ProgressionModules.DiscoveredShapes.Contains(item.Key))
				{
					item.Value.SetStateCompleted();
					num++;
				}
				else
				{
					item.Value.SetStateDefault();
				}
			}
			_modulesTitleText.SetText($"{_modulesTitle}  <size=80%>({num}/{_moduleLibrary.Count})</size>");
		}

		private void OnModuleFirstCreated(AbstractNotificationData notificationData)
		{
			if (notificationData is ModuleNotificationData moduleNotificationData)
			{
				_moduleLibrary[moduleNotificationData.ShapeData].SetStateCompleted();
			}
		}

		private void OnMonumentStateChanged(ProgressionMonumentsManager.Monument monument)
		{
			SetMonumentState(monument);
		}

		private void SetMonumentState(ProgressionMonumentsManager.Monument monument)
		{
			switch (monument.State)
			{
			case ProgressionMonumentsManager.MonumentState.None:
				_monuments[monument.BuildingObjectData].SetStateDefault();
				break;
			case ProgressionMonumentsManager.MonumentState.Placed:
				_monuments[monument.BuildingObjectData].SetStateUnderConstruction();
				break;
			case ProgressionMonumentsManager.MonumentState.Built:
				_monuments[monument.BuildingObjectData].SetStateCompleted();
				break;
			}
		}
	}
}
