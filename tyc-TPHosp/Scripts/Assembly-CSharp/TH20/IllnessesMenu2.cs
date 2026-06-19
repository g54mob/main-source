using System;
using System.Collections.Generic;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[Serializable]
	[DontSave]
	public class IllnessesMenu2 : AnimatedMenuBase
	{
		[Serializable]
		public class IllnessesMenu2Settings
		{
			[Header("General")]
			[SerializeField]
			public GameObject RowPrefab;

			[SerializeField]
			public RectTransform ColumnHeadersParent;

			[SerializeField]
			public Table DataTable;

			[SerializeField]
			public Vector2 PanelSizeDelta;

			[NonSerialized]
			[HideInInspector]
			public int AnimHash;

			[NonSerialized]
			[HideInInspector]
			public int TriggerHash;

			[SerializeField]
			public DynamicButton CloseButton;

			[SerializeField]
			public RectTransform BarRectTransform;

			[SerializeField]
			public RectTransform PanelRectTransform;

			[SerializeField]
			public RectTransform TabSelectionRectTransform;

			[SerializeField]
			public RectTransform TitleRectTransform;
		}

		[SerializeField]
		private IllnessesMenu2Data _data;

		[SerializeField]
		private GraphicRaycaster _graphicRaycaster;

		private IllnessesMenu2Settings _illnessesMenu2Settings;

		private GameObject _illnessesMenu2RowPrefab;

		private GameplayStatsTracker _gameplayStatsTracker;

		private ResearchManager _researchManager;

		private ReputationTracker _reputationTracker;

		private Level _level;

		private Table _table;

		private Dictionary<IllnessDefinition, IllnessesMenu2Row> _rows = new Dictionary<IllnessDefinition, IllnessesMenu2Row>();

		public void Initialise(Level level)
		{
			_level = level;
			_gameplayStatsTracker = _level.GameplayStatsTracker;
			_researchManager = _level.ResearchManager;
			_reputationTracker = _level.ReputationTracker;
			_illnessesMenu2Settings = _data.IllnessesMenu2Settings;
			_level.InputManager.AddGraphicRayCaster(_graphicRaycaster);
			_illnessesMenu2RowPrefab = _illnessesMenu2Settings.RowPrefab;
			if ((bool)_illnessesMenu2Settings.ColumnHeadersParent)
			{
				_illnessesMenu2Settings.ColumnHeadersParent.gameObject.SetActive(value: false);
			}
			_table = _illnessesMenu2Settings.DataTable;
			if ((bool)_table)
			{
				_table.gameObject.SetActive(value: true);
				_table.ColumnHeaders = _illnessesMenu2Settings.ColumnHeadersParent;
				if ((bool)_table.ColumnHeaders)
				{
					_table.ColumnHeaders.gameObject.SetActive(value: true);
				}
			}
			if (_gameplayStatsTracker != null)
			{
				GameplayStatsTracker gameplayStatsTracker = _gameplayStatsTracker;
				gameplayStatsTracker.OnNewDiscoveredIllnessesStat = (Action<IllnessDefinition>)Delegate.Combine(gameplayStatsTracker.OnNewDiscoveredIllnessesStat, new Action<IllnessDefinition>(OnNewDiscoveredIllnessesStat));
			}
			PanelItem[] componentsInChildren = GetComponentsInChildren<PanelItem>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].Setup();
			}
			if ((bool)_illnessesMenu2Settings.CloseButton)
			{
				_illnessesMenu2Settings.CloseButton.onPrimaryDown.AddListener(OnCloseButton);
			}
		}

		public void Setup()
		{
			UpdateIllnessesList(force: true);
			_table.Refresh();
		}

		protected void ClearTable()
		{
			if ((bool)_table)
			{
				for (int i = 0; i < _rows.Count; i++)
				{
					_table.DestroyRow(i);
				}
				_rows.Clear();
			}
		}

		protected void UpdateIllnessesList(bool force)
		{
			ClearTable();
			if ((bool)_illnessesMenu2RowPrefab)
			{
				foreach (IllnessDefinition discoveredIllness in _gameplayStatsTracker.DiscoveredIllnesses)
				{
					_rows[discoveredIllness] = CreateIllnessRow(discoveredIllness);
				}
				_table.Resort();
			}
			UpdateRowBackgrounds();
		}

		protected IllnessesMenu2Row CreateIllnessRow(IllnessDefinition illness)
		{
			IllnessesMenu2Row component = _table.InstantiateAsRow(_illnessesMenu2RowPrefab).GetComponent<IllnessesMenu2Row>();
			component.Setup(illness, _researchManager, _gameplayStatsTracker, _reputationTracker, _level.FinanceManager);
			return component;
		}

		protected void UpdateRowBackgrounds()
		{
			int num = 0;
			foreach (KeyValuePair<IllnessDefinition, IllnessesMenu2Row> row in _rows)
			{
				row.Value.SetRowBackground(num++);
			}
		}

		private void OnNewDiscoveredIllnessesStat(IllnessDefinition illness)
		{
			_rows[illness] = CreateIllnessRow(illness);
			_table.Resort();
			UpdateRowBackgrounds();
		}

		public override void Destroy()
		{
			_level.InputManager.RemoveGraphicRayCaster(_graphicRaycaster);
			if (_gameplayStatsTracker != null)
			{
				GameplayStatsTracker gameplayStatsTracker = _gameplayStatsTracker;
				gameplayStatsTracker.OnNewDiscoveredIllnessesStat = (Action<IllnessDefinition>)Delegate.Remove(gameplayStatsTracker.OnNewDiscoveredIllnessesStat, new Action<IllnessDefinition>(OnNewDiscoveredIllnessesStat));
			}
			if (_illnessesMenu2Settings != null && _illnessesMenu2Settings.CloseButton != null)
			{
				_illnessesMenu2Settings.CloseButton.onPrimaryDown.RemoveListener(OnCloseButton);
			}
		}

		private void OnCloseButton()
		{
			CloseMenu();
		}

		protected override void Update()
		{
			base.Update();
			Refresh();
		}

		private void Refresh()
		{
		}
	}
}
