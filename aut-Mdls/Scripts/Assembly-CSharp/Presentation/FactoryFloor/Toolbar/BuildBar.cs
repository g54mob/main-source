using System;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using Events;
using Events.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Utils;

namespace Presentation.FactoryFloor.Toolbar
{
	public class BuildBar : MonoBehaviour, IPointerExitHandler, IEventSystemHandler
	{
		[Serializable]
		private struct BuildBarElements
		{
			public BuildBarButton BuildBarButton;

			public AbstractOperatorBar OperatorBar;

			public int BuildingFamily;
		}

		[SerializeField]
		private InputActionReference _tabInputAction;

		[SerializeField]
		private InputActionReference _shiftInputAction;

		[SerializeField]
		private ShowBuildBarEvent _showBuildBarEvent;

		[SerializeField]
		private SerializedDictionary<BuildMode, BuildBarElements> _buildBarDictionary;

		[SerializeField]
		private BuildingsBar _buildingsBar;

		[SerializeField]
		private BlueprintsBar _blueprintsBar;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		private BuildMode _currentBuildMode;

		private void Start()
		{
			_finishedLoadingSaveEvent.Register(OnFinishedLoadingSave);
		}

		private void OnFinishedLoadingSave()
		{
			_finishedLoadingSaveEvent.UnRegister(OnFinishedLoadingSave);
			foreach (KeyValuePair<BuildMode, BuildBarElements> bar in _buildBarDictionary)
			{
				bar.Value.BuildBarButton.Button.onClick.AddListener(delegate
				{
					SwapBuildMode((newBuildMode: bar.Key, buildingFamily: bar.Value.BuildingFamily));
				});
				bar.Value.OperatorBar.BuildMode = bar.Key;
				bar.Value.OperatorBar.gameObject.SetActive(value: false);
				bar.Value.OperatorBar.Initalize();
				bar.Value.BuildBarButton.Init(bar.Key, bar.Value.BuildingFamily);
			}
			_showBuildBarEvent.Register(SwapBuildMode);
			_tabInputAction.action.performed += TabPressed;
			_currentBuildMode = BuildMode.Operators;
			ShowBuildMode(_currentBuildMode);
		}

		private void OnDestroy()
		{
			foreach (KeyValuePair<BuildMode, BuildBarElements> item in _buildBarDictionary)
			{
				item.Value.BuildBarButton.Button.onClick.RemoveAllListeners();
			}
			_finishedLoadingSaveEvent.UnRegister(OnFinishedLoadingSave);
			_showBuildBarEvent.UnRegister(SwapBuildMode);
			_tabInputAction.action.performed -= TabPressed;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (_buildingsBar.gameObject.activeSelf)
			{
				_buildingsBar.HideDetails();
			}
			else if (_blueprintsBar.gameObject.activeSelf)
			{
				_blueprintsBar.HideInfoBar();
			}
		}

		private int GetIndexOfBuildMode(BuildMode buildMode)
		{
			int num = 0;
			foreach (KeyValuePair<BuildMode, BuildBarElements> item in _buildBarDictionary)
			{
				if (item.Key == buildMode)
				{
					return num;
				}
				num++;
			}
			return num;
		}

		private void TabPressed(InputAction.CallbackContext _)
		{
			int num = ((!_shiftInputAction.action.IsPressed()) ? 1 : (-1));
			int newIndex = GetIndexOfBuildMode(_currentBuildMode) + num;
			WrapIndex();
			while (!_buildBarDictionary.ElementAt(newIndex).Value.BuildBarButton.gameObject.activeSelf)
			{
				newIndex += num;
				WrapIndex();
			}
			_buildBarDictionary.ElementAt(newIndex).Value.BuildBarButton.Button.PressButton();
			void WrapIndex()
			{
				if (newIndex >= _buildBarDictionary.Count)
				{
					newIndex = 0;
				}
				if (newIndex < 0)
				{
					newIndex = _buildBarDictionary.Count - 1;
				}
			}
		}

		private void SwapBuildMode((BuildMode newBuildMode, int buildingFamily) args)
		{
			if (_currentBuildMode != args.newBuildMode)
			{
				HideBuildMode(_currentBuildMode);
				(_currentBuildMode, _) = args;
				if (args.newBuildMode == BuildMode.Buildings_Grey || args.newBuildMode == BuildMode.Buildings_Blue || args.newBuildMode == BuildMode.Buildings_Yellow || args.newBuildMode == BuildMode.Buildings_Red)
				{
					_buildBarDictionary[args.newBuildMode].OperatorBar.BuildingFamily = args.buildingFamily;
				}
				ShowBuildMode(args.newBuildMode);
			}
		}

		private void HideBuildMode(BuildMode buildMode)
		{
			_buildBarDictionary[buildMode].BuildBarButton.Deselect();
			_buildBarDictionary[buildMode].OperatorBar.Hide();
		}

		private void ShowBuildMode(BuildMode buildMode)
		{
			_buildBarDictionary[buildMode].BuildBarButton.Select();
			_buildBarDictionary[buildMode].OperatorBar.Show();
		}
	}
}
