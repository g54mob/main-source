using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player.GameplayInput.ButtonsActions.Handler
{
	public abstract class ButtonsActionsHandler<TAction, TButtonEnum, TActionEnum, TActionData> : MonoBehaviour, mr<TButtonEnum, TActionEnum, TActionData>, mq<TActionEnum, TActionData> where TAction : class, lo where TButtonEnum : Enum where TActionEnum : Enum where TActionData : ButtonActionData
	{
		private sealed class mp
		{
			public lo qpl;

			internal bool fmo(KeyValuePair<TActionEnum, Type> a)
			{
				return false;
			}
		}

		[SerializeField]
		private TActionData[] m_data;

		private Dictionary<TActionEnum, TActionData> qpm;

		private Dictionary<TActionEnum, Type> qpn;

		private bool qpo;

		private hu qpp;

		public void fmp(cka a)
		{
		}

		public void fmq()
		{
		}

		public TActionData fmr(lo a)
		{
			return null;
		}

		public TActionData fmr(TActionEnum a)
		{
			return null;
		}

		public TButtonEnum fms(TActionEnum a)
		{
			return default(TButtonEnum);
		}

		public TButtonEnum fms(lo a)
		{
			return default(TButtonEnum);
		}

		public lo fmt(TActionEnum a)
		{
			return null;
		}

		protected void fmu<a>(TActionEnum a) where a : TAction
		{
		}

		private void fmv()
		{
		}

		private TActionEnum fmw(lo a)
		{
			return default(TActionEnum);
		}

		private TAction fmx(TActionEnum a)
		{
			return null;
		}

		protected abstract void flo();

		private void fmy()
		{
		}

		private Dictionary<TActionEnum, TActionData> fmz()
		{
			return null;
		}

		public void fna()
		{
		}

		private void fnb()
		{
		}
	}
}
