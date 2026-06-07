using Data.LevelData;
using Data.ResourceTypes;
using Events.WorldMap;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace Presentation.UI.WorldMap
{
	[RequireComponent(typeof(ScreenInteractableWorldArea))]
	public class CityWorldMapUI : MonoBehaviour
	{
		[SerializeField]
		private ScreenInteractableWorldArea _interactableWorldArea;

		[SerializeField]
		private CityData _cityData;

		[SerializeField]
		private TextMeshProUGUI _cityNameText;

		[SerializeField]
		private TextMeshProUGUI _requiredToUnlockText;

		[SerializeField]
		private GameObject _cityUI;

		[SerializeField]
		private GameObject _lockUI;

		[SerializeField]
		private CityUnlockedEvent _cityUnlockedEvent;

		[SerializeField]
		private HoverInfoUI _hoveredInfoUI;

		[SerializeField]
		private Transform _cityTransform;

		[SerializeField]
		[Required(null)]
		private WorldUI _worldMapUI;

		[SerializeField]
		[Required(null)]
		private ExportLineVisuals _exportLineVisuals;

		[SerializeField]
		private ExportButtons _exportButton;

		public CityData CityData => _cityData;

		public Transform CityTransform => _cityTransform;

		private void Awake()
		{
			_cityUnlockedEvent.Register(OnCityUnlocked);
			_interactableWorldArea.OnAreaIsClickedAction += OnAreaIsClicked;
			_cityNameText.SetText(_cityData.Name);
			_requiredToUnlockText.SetText("Required Fame: " + _cityData.RequiredRankForUnlock);
		}

		private void OnCityUnlocked(string levelGuid)
		{
			if (levelGuid == _cityData.GuidStr)
			{
				_cityUI.SetActive(value: true);
				_lockUI.SetActive(value: false);
				_hoveredInfoUI.OnCityUnlocked();
			}
		}

		public void Initialize()
		{
		}

		private void OnValidate()
		{
			if (_interactableWorldArea == null)
			{
				_interactableWorldArea = GetComponent<ScreenInteractableWorldArea>();
			}
		}

		public void OnDestroy()
		{
			_interactableWorldArea.OnAreaIsClickedAction -= OnAreaIsClicked;
			_cityUnlockedEvent.UnRegister(OnCityUnlocked);
		}

		public void OnAreaIsClicked()
		{
		}

		public void CreateExportLine(ResourceExportButton exportButton)
		{
			_exportLineVisuals.CreateLine(_cityTransform, exportButton, CityData.GuidStr);
		}

		public void RemoveExportLine(ResourceExportButton button)
		{
			_exportLineVisuals.GetLine(button);
			_exportLineVisuals.RemoveLine(button);
			button.IsExporting = false;
		}

		public ResourceExportButton GetButton(ResourceType type)
		{
			return _exportButton.GetUnusedButton(type);
		}

		public void LoadExistingLines()
		{
		}

		public void AnimateLine(ResourceExportButton button)
		{
			_exportLineVisuals.AnimateLine(button);
		}

		public void StopAnimationLine(ResourceExportButton button)
		{
			_exportLineVisuals.StopAnimationLine(button);
		}
	}
}
