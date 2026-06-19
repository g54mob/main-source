using System;
using I2.Loc;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class PricesMenu2 : MenuBase
	{
		private enum SortOrder
		{
			Diagnosis = 1,
			Treatment = 2,
			Other = 3
		}

		[SerializeField]
		private Table _table;

		[SerializeField]
		private GameObject _rowPrefab;

		[SerializeField]
		private ScrollRect _scrollRect;

		[SerializeField]
		private ProgressBarMaskable _priceReputationProgressBar;

		[SerializeField]
		private TooltipSpawner _priceReputationTooltip;

		[SerializeField]
		private TooltipSpawner _modifyAllPlusTooltip;

		[SerializeField]
		private TooltipSpawner _modifyAllMinusTooltip;

		[SerializeField]
		private TooltipSpawner _modifyAllResetTooltip;

		[SerializeField]
		private DynamicButton _modifyAllPlusButton;

		[SerializeField]
		private DynamicButton _modifyAllMinusButton;

		[SerializeField]
		private DynamicButton _modifyAllResetButton;

		[SerializeField]
		private ColumnSortButton _columnSortButtonItemName;

		[SerializeField]
		private ColumnSortButton _columnSortButtonPrice;

		[SerializeField]
		private ColumnSortButton _columnSortButtonModifier;

		[SerializeField]
		private int _allPricesPlusDelta = 5;

		[SerializeField]
		private float _PriceReputationOverride;

		private PriceModifiablesConfig _config;

		private Level _level;

		public Level Level => _level;

		public void Initialise(Level level, PriceModifiablesConfig priceModifiablesConfig)
		{
			_config = priceModifiablesConfig;
			_level = level;
			if (_priceReputationTooltip != null)
			{
				_priceReputationTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_PriceReputation_CS, StringUtils.FormatPercentageValue(GetPriceReputationValue()));
				});
			}
			if (_modifyAllPlusTooltip != null)
			{
				_modifyAllPlusTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = ScriptLocalization.Menu_Prices.TooltipModifyPlus_CS.Replace("{[PERCENT]}", StringUtils.FormatPercentageValue((float)_allPricesPlusDelta / 100f));
				});
			}
			if (_modifyAllMinusTooltip != null)
			{
				_modifyAllMinusTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = ScriptLocalization.Menu_Prices.TooltipModifyMinus_CS.Replace("{[PERCENT]}", StringUtils.FormatPercentageValue((float)_allPricesPlusDelta / 100f));
				});
			}
			GameplayStatsTracker gameplayStatsTracker = _level.GameplayStatsTracker;
			gameplayStatsTracker.OnNewDiscoveredIllnessesStat = (Action<IllnessDefinition>)Delegate.Combine(gameplayStatsTracker.OnNewDiscoveredIllnessesStat, new Action<IllnessDefinition>(OnNewDiscoveredIllnessesStat));
			if (_modifyAllPlusButton != null)
			{
				_modifyAllPlusButton.onPrimaryDown.AddListener(OnModifyAllPlusButtonClicked);
			}
			if (_modifyAllMinusButton != null)
			{
				_modifyAllMinusButton.onPrimaryDown.AddListener(OnModifyAllMinusButtonClicked);
			}
			if (_modifyAllResetButton != null)
			{
				_modifyAllResetButton.onPrimaryDown.AddListener(OnModifyAllResetButtonClicked);
			}
		}

		protected void OnDestroy()
		{
			if (_table != null)
			{
				Table table = _table;
				table.onSortOrderChanged = (Action)Delegate.Remove(table.onSortOrderChanged, new Action(OnSortOrderChanged));
			}
		}

		public void Setup()
		{
			if (!(_table != null))
			{
				return;
			}
			foreach (Transform row in _table.Rows)
			{
				UnityEngine.Object.Destroy(row.gameObject);
			}
			_table.Rows.DetachChildren();
			Table table = _table;
			table.onSortOrderChanged = (Action)Delegate.Combine(table.onSortOrderChanged, new Action(OnSortOrderChanged));
			foreach (RoomDefinition availableRoom in _level.WorldState.AvailableRooms)
			{
				if (availableRoom._diagnosisCost > 0)
				{
					string localisedName = availableRoom.GetLocalisedName();
					_table.InstantiateAsRow(_rowPrefab).GetComponent<PricesMenu2Row>().Setup(this, string.Format("{0}{2}{1}", ScriptLocalization.Menu_Prices.PrefixDiagnosis_CS, localisedName, ScriptLocalization.Misc.ColonSeparator_CS), availableRoom._icon, Mathf.CeilToInt(Level.FinanceManager.GetDiagnosisBaseCharge(availableRoom)), _level.FinanceManager.PriceModifiers, availableRoom, _config.DiagnosisPercentageDelta, _config.DiagnosisPercentageMin, _config.DiagnosisPercentageMax, _table.Rows.childCount, 1, localisedName);
				}
			}
			foreach (PriceModifiablesConfig.Modifiable modifiable in _config.Modifiables)
			{
				if (modifiable.FinanceModifier != null && modifiable.FinanceModifier.Instance != null)
				{
					_table.InstantiateAsRow(_rowPrefab).GetComponent<PricesMenu2Row>().Setup(this, modifiable.NameLocalised.Translation, (modifiable.IconSprite != null) ? modifiable.IconSprite : null, Mathf.CeilToInt(modifiable.FinanceModifier.Instance.GetBaseCost()), _level.FinanceManager.PriceModifiers, modifiable.FinanceModifier.Instance, modifiable.PercentageDelta, modifiable.PercentageMin, modifiable.PercentageMax, _table.Rows.childCount, 3, modifiable.NameLocalised.Translation);
				}
			}
			foreach (IllnessDefinition discoveredIllness in _level.GameplayStatsTracker.DiscoveredIllnesses)
			{
				AddIllnessRow(discoveredIllness);
			}
			if (_columnSortButtonItemName != null)
			{
				_columnSortButtonItemName.CurrentSortMode = ColumnSortButton.SortMode.Ascending;
			}
			if (_scrollRect != null)
			{
				_scrollRect.verticalNormalizedPosition = 1f;
			}
		}

		private void AddIllnessRow(IllnessDefinition illnessDefinition)
		{
			if (_table != null)
			{
				GameObject obj = _table.InstantiateAsRow(_rowPrefab);
				RoomDefinition treatmentRoom = illnessDefinition.GetTreatmentRoom(null, _level.ResearchManager);
				string localisedName = treatmentRoom.GetLocalisedName();
				obj.GetComponent<PricesMenu2Row>().Setup(this, string.Format("{0}{3}{1}{3}{2}", ScriptLocalization.Menu_Prices.PrefixTreatment_CS, localisedName, illnessDefinition.Name.Translation, ScriptLocalization.Misc.ColonSeparator_CS), treatmentRoom._icon, illnessDefinition.GetTreatmentCostForRoom(treatmentRoom, _level.ResearchManager, _level.FinanceManager), _level.FinanceManager.PriceModifiers, illnessDefinition, _config.TreatmentPercentageDelta, _config.TreatmentPercentageMin, _config.TreatmentPercentageMax, _table.Rows.childCount, 2, localisedName);
			}
		}

		private void OnSortOrderChanged()
		{
			UpdateRowItemRowIndexes();
		}

		private void UpdateRowItemRowIndexes()
		{
			int childCount = _table.Rows.childCount;
			for (int i = 0; i < childCount; i++)
			{
				_table.Rows.GetChild(i).GetComponent<PricesMenu2Row>().SetRowIndex(i);
			}
			_table.Refresh();
		}

		private void OnNewDiscoveredIllnessesStat(IllnessDefinition illnessDefinition)
		{
			AddIllnessRow(illnessDefinition);
		}

		private void OnModifyAllResetButtonClicked()
		{
			ResetAllPricesModifiers();
		}

		private void OnModifyAllPlusButtonClicked()
		{
			IncrementAllPricesModifiers(_allPricesPlusDelta);
		}

		private void OnModifyAllMinusButtonClicked()
		{
			IncrementAllPricesModifiers(-_allPricesPlusDelta);
		}

		private void IncrementAllPricesModifiers(int incrAmount)
		{
			bool flag = false;
			foreach (Transform row in _table.Rows)
			{
				GameObject gameObject = row.gameObject;
				if (!(gameObject != null))
				{
					continue;
				}
				PricesMenu2Row component = gameObject.GetComponent<PricesMenu2Row>();
				if (component != null)
				{
					int modifier = component.GetModifier();
					modifier += incrAmount;
					if (component.SetModifier(modifier, bInformParent: false))
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				OnAnyRowItemChanges();
			}
		}

		private void ResetAllPricesModifiers()
		{
			bool flag = false;
			foreach (Transform row in _table.Rows)
			{
				GameObject gameObject = row.gameObject;
				if (gameObject != null)
				{
					PricesMenu2Row component = gameObject.GetComponent<PricesMenu2Row>();
					if (component != null && component.SetModifier(0, bInformParent: false))
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				OnAnyRowItemChanges();
			}
		}

		public void OnAnyRowItemChanges()
		{
			DisableAllSorting();
		}

		private void DisableAllSorting()
		{
			if (_columnSortButtonItemName != null)
			{
				_columnSortButtonItemName.SetSortModeWithoutNotifyingTable(ColumnSortButton.SortMode.None);
			}
			if (_columnSortButtonPrice != null)
			{
				_columnSortButtonPrice.SetSortModeWithoutNotifyingTable(ColumnSortButton.SortMode.None);
			}
			if (_columnSortButtonModifier != null)
			{
				_columnSortButtonModifier.SetSortModeWithoutNotifyingTable(ColumnSortButton.SortMode.None);
			}
		}

		protected override void Update()
		{
			base.Update();
			if (_priceReputationProgressBar != null)
			{
				_priceReputationProgressBar.SetProgressSmooth(GetPriceReputationValue());
				_priceReputationProgressBar.SetDirty();
			}
		}

		public override void Destroy()
		{
			GameplayStatsTracker gameplayStatsTracker = _level.GameplayStatsTracker;
			gameplayStatsTracker.OnNewDiscoveredIllnessesStat = (Action<IllnessDefinition>)Delegate.Remove(gameplayStatsTracker.OnNewDiscoveredIllnessesStat, new Action<IllnessDefinition>(OnNewDiscoveredIllnessesStat));
		}

		private float GetPriceReputationValue()
		{
			float result = _level.ReputationTracker.PriceReputation;
			if (_PriceReputationOverride != 0f)
			{
				result = _PriceReputationOverride;
			}
			return result;
		}
	}
}
