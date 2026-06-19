using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomItemShrinkComponent : EntityTickComponent
	{
		private float _duration;

		private float _startTime;

		private RoomItem _item;

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_item = GetOwner<RoomItem>();
			_startTime = GameTime.time;
		}

		public void SetDuration(float duration)
		{
			_duration = duration;
		}

		public override void LateTick()
		{
			base.LateTick();
			if (_item.Visual != null)
			{
				float num = GameTime.time - _startTime;
				if (num > _duration)
				{
					Destroy();
					return;
				}
				num = 1f - num / _duration;
				_item.Visual.GameObject.transform.localScale = new Vector3(num, num, num);
			}
		}
	}
}
