using UnityEngine;

namespace Gh.Tk.UI
{
	public abstract class BaseProgressBar3DUIView : MonoBehaviour
	{
		private float _totalValue;

		private float _bonusMalus;

		public float MinValue { get; set; }

		public float MaxValue { get; set; }

		public float TotalValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float BonusMalus
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TotalValuePercentage => 0f;

		protected float BonusPercentage => 0f;

		protected float MalusPercentage => 0f;

		protected abstract void Refresh();
	}
}
