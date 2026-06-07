using System;
using Simulator;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public abstract class UI_BasePaintMiniGame : MonoBehaviour, IActivable
	{
		public static Action<bool, int> OnTry;

		public static Action<int> Completed;

		protected abstract int ComputeScore();

		protected void Complete()
		{
			OnComplete();
			SetActive(active: false);
			Completed?.Invoke(ComputeScore());
		}

		protected virtual void OnComplete()
		{
		}

		public void SetActive(bool active)
		{
			base.gameObject.SetActive(active);
			if (active)
			{
				OnSetActive();
			}
			else
			{
				OnSetInactive();
			}
		}

		protected virtual void OnSetActive()
		{
		}

		protected virtual void OnSetInactive()
		{
		}
	}
}
