using System;
using CTS.BBT.Handlers.Transactions;
using CTS.BBT.TechTree;
using CTS.Core;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.TechTree
{
	public class TechTreePointsConverter : MonoBehaviour
	{
		[SerializeField]
		[Space(10f)]
		[BoxGroup("Base Settings")]
		private TechTreePointsConverterSO _techTreePointsConverterSO;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Component Links")]
		private TMP_Text _researchPointsText;

		[SerializeField]
		[BoxGroup("Component Links")]
		private TMP_Text _monneyAmountText;

		[SerializeField]
		[BoxGroup("Component Links")]
		private Button _buttonComponent;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("GameObject Links")]
		private GameObject _padlockVisualGameObject;

		private int _currentResearchPointsAmount;

		private int _researchPointsRequired;

		private int _moneyAmountToReceive;

		public static event Action<int> ResearchPointSold;

		public static event Action<int> ResearchPointSellMoneyGenerated;

		private void OnEnable()
		{
			_buttonComponent.onClick.AddListener(TryToConvert);
			TechTreePoints.OnGainResearchPoints += UpdateVisual;
			TechTreePoints.OnLooseResearchPoints += UpdateVisual;
		}

		private void Start()
		{
			_researchPointsRequired = _techTreePointsConverterSO.PointsAmountToExchange;
			_moneyAmountToReceive = _techTreePointsConverterSO.MoneyAmountToReceive;
			_researchPointsText.text = $"{_researchPointsRequired}";
			_monneyAmountText.text = $"${_moneyAmountToReceive}";
			UpdateVisual();
		}

		private void OnDisable()
		{
			_buttonComponent.onClick.RemoveListener(TryToConvert);
			TechTreePoints.OnGainResearchPoints -= UpdateVisual;
			TechTreePoints.OnLooseResearchPoints -= UpdateVisual;
		}

		private void UpdateVisual()
		{
			_currentResearchPointsAmount = TechTreeManager.GetCurrentPoints;
			_padlockVisualGameObject.SetActive(_currentResearchPointsAmount < _researchPointsRequired);
		}

		private void TryToConvert()
		{
			if (_currentResearchPointsAmount >= _researchPointsRequired)
			{
				MonoSingleton<TransactionsHandlers>.Instance.AddNewData(TransactionType.Income, _moneyAmountToReceive, TransactionTag.Exceptional);
				EventsManager.ChangeMoney?.Invoke(Currencies.Dollars, _moneyAmountToReceive);
				if (CTSSingleton<TechTreePoints>.InstanceExists())
				{
					CTSSingleton<TechTreePoints>.Instance.SpendPoints(_researchPointsRequired);
				}
				TechTreePointsConverter.ResearchPointSold?.Invoke(_researchPointsRequired);
				TechTreePointsConverter.ResearchPointSellMoneyGenerated?.Invoke(_moneyAmountToReceive);
			}
		}
	}
}
