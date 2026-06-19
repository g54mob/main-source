using MyBox;
using UnityEngine;

namespace Items
{
	public class LiquidCan : EquipableToolItem
	{
		[SerializeField]
		private float _liquidMaxAmount;

		[ReadOnly(new string[] { })]
		[SerializeField]
		private float _liquidAmount;

		public float LiquidAmount => _liquidAmount;

		private void Awake()
		{
			_liquidAmount = _liquidMaxAmount;
		}

		public void ChangeLiquidAmount(float amount)
		{
			_liquidAmount = Mathf.Clamp(_liquidAmount + amount, 0f, _liquidMaxAmount);
		}
	}
}
