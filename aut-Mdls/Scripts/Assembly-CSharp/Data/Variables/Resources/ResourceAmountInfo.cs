using System;
using UnityEngine;

namespace Data.Variables.Resources
{
	[CreateAssetMenu(menuName = "Variables/Resources/ResourceAmountInfo", fileName = "ResourceAmountInfo", order = 0)]
	public class ResourceAmountInfo : ScriptableObject
	{
		[SerializeField]
		private int _amount;

		[SerializeField]
		private int _totalAmount;

		public int Amount => _amount;

		public int TotalAmount => _totalAmount;

		public event Action<int, int> ValueChanged = delegate
		{
		};

		public void SetValue(int amount, int totalAmount)
		{
			_amount = amount;
			_totalAmount = totalAmount;
			this.ValueChanged(amount, totalAmount);
		}
	}
}
