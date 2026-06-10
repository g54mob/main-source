using System;
using NSEipix.Base;
using NSMedieval.Enums;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class TradingPostComponentBlueprint : NSEipix.Base.Model
	{
		private readonly BuildingType componentType = BuildingType.Decoration;

		[SerializeField]
		private string id;

		[SerializeField]
		private TraderSlot[] slots;

		[SerializeField]
		private bool turnTowardsCenter;

		[SerializeField]
		private bool turnAwayFromCenter;

		public BuildingType ComponentType => componentType;

		public int MaxTraders
		{
			get
			{
				TraderSlot[] array = slots;
				if (array == null)
				{
					return 0;
				}
				return array.Length;
			}
		}

		public TraderSlot[] Slots => slots;

		public bool TurnTowardsCenter => turnTowardsCenter;

		public bool TurnAwayFromCenter => turnAwayFromCenter;

		public override string GetID()
		{
			return id;
		}
	}
}
