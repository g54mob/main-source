using System;
using MessagePack;
using UnityEngine;

namespace KitchenData
{
	[Serializable]
	[MessagePackObject(false)]
	public struct DecorationValues
	{
		[IgnoreMember]
		public const int PointsPerLevel = 3;

		[IgnoreMember]
		public const int MaxLevel = 3;

		[IgnoreMember]
		private static DecorationType[] _Types;

		[Key(0)]
		public int Exclusive;

		[Key(1)]
		public int Affordable;

		[Key(2)]
		public int Charming;

		[Key(3)]
		public int Formal;

		[HideInInspector]
		[Key(4)]
		public int Kitchen;

		[IgnoreMember]
		public static DecorationType[] Types
		{
			get
			{
				if (_Types == null)
				{
					Array values = Enum.GetValues(typeof(DecorationType));
					_Types = new DecorationType[values.Length];
					values.CopyTo(_Types, 0);
				}
				return _Types;
			}
		}

		public int this[DecorationType t]
		{
			get
			{
				return t switch
				{
					DecorationType.Exclusive => Exclusive, 
					DecorationType.Affordable => Affordable, 
					DecorationType.Charming => Charming, 
					DecorationType.Formal => Formal, 
					DecorationType.Kitchen => Kitchen, 
					_ => 0, 
				};
			}
			set
			{
				switch (t)
				{
				case DecorationType.Exclusive:
					Exclusive = value;
					break;
				case DecorationType.Affordable:
					Affordable = value;
					break;
				case DecorationType.Charming:
					Charming = value;
					break;
				case DecorationType.Formal:
					Formal = value;
					break;
				case DecorationType.Kitchen:
					Kitchen = value;
					break;
				}
			}
		}

		[IgnoreMember]
		public static DecorationValues Neutral => default(DecorationValues);

		[IgnoreMember]
		public bool IsNeutral => !IsChangedFrom(default(DecorationValues));

		public DecorationValues ApplyModifiers(DecorationValues d)
		{
			return new DecorationValues
			{
				Exclusive = Exclusive + d.Exclusive,
				Affordable = Affordable + d.Affordable,
				Charming = Charming + d.Charming,
				Formal = Formal + d.Formal,
				Kitchen = Kitchen + d.Kitchen
			};
		}

		public static DecorationBonus Bonus(DecorationType t, int level)
		{
			switch (t)
			{
			case DecorationType.Exclusive:
				switch (level)
				{
				case 1:
					return DecorationBonus.QueuePatienceIncrease;
				case 2:
					return DecorationBonus.MoneyPerDelivery;
				case 3:
					return DecorationBonus.InfinitePatienceIfQueue;
				}
				break;
			case DecorationType.Affordable:
				switch (level)
				{
				case 1:
					return DecorationBonus.WaitTimeDecrease;
				case 2:
					return DecorationBonus.ConsumableReuseChance;
				case 3:
					return DecorationBonus.InformalService;
				}
				break;
			case DecorationType.Charming:
				switch (level)
				{
				case 1:
					return DecorationBonus.IncreasedServicePatience;
				case 2:
					return DecorationBonus.BonusPatienceNearby;
				case 3:
					return DecorationBonus.SeatWithoutClear;
				}
				break;
			case DecorationType.Formal:
				switch (level)
				{
				case 1:
					return DecorationBonus.DecreasedMess;
				case 2:
					return DecorationBonus.IncreasedDeliveryPatience;
				case 3:
					return DecorationBonus.PreventMess;
				}
				break;
			case DecorationType.Kitchen:
				switch (level)
				{
				case 1:
					return DecorationBonus.DecreasedOrderPatience;
				case 2:
					return DecorationBonus.IncreasedOrderChangeChance;
				case 3:
					return DecorationBonus.IncreasedMess;
				}
				break;
			}
			return DecorationBonus.None;
		}

		public int GetBonusLevel(DecorationType t)
		{
			return Mathf.Clamp(this[t] / 3, 0, 3);
		}

		public static int GetBonusLevel(int value)
		{
			return Mathf.Clamp(value / 3, 0, 3);
		}

		public int GetPartialLevel(DecorationType t)
		{
			return this[t] % 3;
		}

		public static int GetPartialLevel(int value)
		{
			return value % 3;
		}

		public bool IsChangedFrom(DecorationValues o)
		{
			if (Exclusive == o.Exclusive && Affordable == o.Affordable && Charming == o.Charming && Formal == o.Formal)
			{
				return Kitchen != o.Kitchen;
			}
			return true;
		}
	}
}
