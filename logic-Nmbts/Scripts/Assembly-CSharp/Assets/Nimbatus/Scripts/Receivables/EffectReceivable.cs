using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Receivables
{
	public class EffectReceivable : BaseReceivable
	{
		public DroneEffect Effect;

		public override EReceivableType Type()
		{
			return EReceivableType.Effect;
		}

		public override T GetReward<T>()
		{
			return (T)(object)Effect;
		}

		public override Texture2D GetIcon()
		{
			return Effect.GetIcon();
		}

		public override string GetTitle()
		{
			return Effect.GetDescription();
		}

		public override string GetAmount()
		{
			return "";
		}

		public override void HandleReward()
		{
			SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.AddEffect(Effect);
		}

		public override bool IsPositive()
		{
			return true;
		}

		public override bool IsDuplicate(BaseReceivable receivable)
		{
			EffectReceivable effectReceivable;
			if ((effectReceivable = receivable as EffectReceivable) != null && Type() == effectReceivable.Type())
			{
				return Effect.EffectType == effectReceivable.Effect.EffectType;
			}
			return false;
		}
	}
}
