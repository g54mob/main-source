using System.Collections.Generic;
using System.Linq;
using Data.FactoryFloor.Islands;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.LevelEditor.IslandEditor
{
	public class IslandEditorToolbarManager : MonoBehaviour
	{
		[SerializeField]
		private IslandEditorToolbarView[] _defaultToolbars;

		[SerializeField]
		private FactoryObjectEditorToolbarView _factoryEditorToolbarViewPrefab;

		[SerializeField]
		private IslandEditorToolBarButton _islandEditorToolBarButtonPrefab;

		[SerializeField]
		private RectTransform _buttonParent;

		[SerializeField]
		private EnvironmentObjectsDatabase _environmentObjectsDatabase;

		private readonly Dictionary<IslandEditorToolBarButton, IslandEditorToolbarView> _islandEditorToolbarViews = new Dictionary<IslandEditorToolBarButton, IslandEditorToolbarView>();

		private IslandEditorToolbarView _selectedToolbar;

		private IslandEditorToolBarButton _selectedToolbarButton;

		private void Awake()
		{
			IslandEditorToolbarView[] defaultToolbars = _defaultToolbars;
			foreach (IslandEditorToolbarView defaultToolBar in defaultToolbars)
			{
				SetupToolbar(defaultToolBar, null);
			}
			foreach (EnvironmentObjectsDatabase.ItemCollection allCollection in _environmentObjectsDatabase.AllCollections)
			{
				FactoryObjectEditorToolbarView factoryObjectEditorToolbarView = Object.Instantiate(_factoryEditorToolbarViewPrefab, base.transform);
				SetupToolbar(factoryObjectEditorToolbarView, allCollection);
				factoryObjectEditorToolbarView.SetItems(allCollection);
			}
			_selectedToolbar = _defaultToolbars[0];
			_selectedToolbar.Select();
			_selectedToolbarButton = _islandEditorToolbarViews.First().Key;
			_selectedToolbarButton.SetSelected(isSelected: true);
		}

		private void Start()
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(_buttonParent);
			LayoutRebuilder.ForceRebuildLayoutImmediate(_buttonParent);
		}

		private void SetupToolbar(IslandEditorToolbarView defaultToolBar, EnvironmentObjectsDatabase.ItemCollection itemCollection)
		{
			IslandEditorToolBarButton islandEditorToolBarButton = Object.Instantiate(_islandEditorToolBarButtonPrefab, _buttonParent);
			islandEditorToolBarButton.Selected += ButtonSelected;
			if (itemCollection == null)
			{
				islandEditorToolBarButton.SetSprite(defaultToolBar.Sprite, Color.white, defaultToolBar.DisplayName);
			}
			else
			{
				islandEditorToolBarButton.SetSprite(itemCollection.Sprite, itemCollection.SpriteColour, itemCollection.Name);
			}
			defaultToolBar.DeSelect();
			_islandEditorToolbarViews.Add(islandEditorToolBarButton, defaultToolBar);
		}

		private void OnDestroy()
		{
			foreach (KeyValuePair<IslandEditorToolBarButton, IslandEditorToolbarView> islandEditorToolbarView in _islandEditorToolbarViews)
			{
				islandEditorToolbarView.Key.Selected -= ButtonSelected;
			}
		}

		private void ButtonSelected(IslandEditorToolBarButton button)
		{
			if (_islandEditorToolbarViews.TryGetValue(button, out var value))
			{
				SelectToolbar(button, value);
			}
		}

		private void SelectToolbar(IslandEditorToolBarButton button, IslandEditorToolbarView value)
		{
			_selectedToolbarButton.SetSelected(isSelected: false);
			_selectedToolbarButton = button;
			_selectedToolbarButton.SetSelected(isSelected: true);
			if (_selectedToolbar != null)
			{
				_selectedToolbar.DeSelect();
			}
			_selectedToolbar = value;
			_selectedToolbar.Select();
		}
	}
}
