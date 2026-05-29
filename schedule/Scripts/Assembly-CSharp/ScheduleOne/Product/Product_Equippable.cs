using ScheduleOne.Equipping;
using ScheduleOne.ItemFramework;
using UnityEngine;

namespace ScheduleOne.Product
{
	public class Product_Equippable : Equippable_Viewmodel
	{
		[Header("References")]
		public ProductVisualsSetter Visuals;

		public Transform ModelContainer;

		private ProductConsumeAnimation consumeAnimation;

		private bool isConsumable;

		private float consumeTime;

		private bool consumingInProgress;

		private Vector3 defaultModelPosition;

		private Coroutine consumeRoutine;

		private bool mouseUp;

		public string ConsumeDescription => null;

		public float PrepareDuration => 0f;

		public float EffectsApplyDelay => 0f;

		public override void Equip(ItemInstance item)
		{
		}

		protected virtual void ApplyProductVisuals(ProductItemInstance product)
		{
		}

		public override void Unequip()
		{
		}

		protected override void Update()
		{
		}

		protected virtual void StartPrepare()
		{
		}

		protected virtual void CancelPrepare()
		{
		}

		protected virtual void Consume()
		{
		}

		protected virtual void ApplyEffects()
		{
		}
	}
}
