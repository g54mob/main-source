using UnityEngine;

namespace Assets.Nimbatus.Scripts.Receivables
{
	public class NoReceivable : BaseReceivable
	{
		public override EReceivableType Type()
		{
			return EReceivableType.None;
		}

		public override T GetReward<T>()
		{
			return (T)(object)null;
		}

		public override Texture2D GetIcon()
		{
			return null;
		}

		public override string GetTitle()
		{
			return "";
		}

		public override string GetAmount()
		{
			return "";
		}

		public override void HandleReward()
		{
		}

		public override bool IsPositive()
		{
			return false;
		}
	}
}
