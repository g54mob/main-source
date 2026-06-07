using System;
using CTS.BBT;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class BBTStockAmountQualityGoal : BBTGoal<StockAmountQualityGoal>
	{
		[SerializeField]
		[VariablePopup(false)]
		private string _targetQuality;

		[field: SerializeField]
		public StockItemSO StockItem { get; private set; }

		[field: SerializeField]
		[field: Range(1f, 10f)]
		public int TargetQualityValue { get; private set; } = 1;

		protected override void InstantiateGoal()
		{
			DialogueLua.SetVariable(_targetQuality, TargetQualityValue);
			Goal = new StockAmountQualityGoal(Quest, Entry, Variable, Target, _targetQuality, StockItem);
		}
	}
}
