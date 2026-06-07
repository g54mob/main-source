using UnityEngine;

namespace Gh.Tk.UI
{
	public class GameObjectXStat3DUIView : AiComponent3DUIView
	{
		private GameObject[] _negativeChevrons;

		private GameObject[] _positiveChevrons;

		public Transform hideHelper;

		private int _chevrons;

		public new virtual GameObjectXStat SourceValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Chevrons
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}

		protected override void Awake()
		{
		}

		protected void OnValueChanged(object sender, ValueChangedEventArgs<float> e)
		{
		}

		protected override void RefreshValues()
		{
		}

		protected virtual void InvalidateVerticalIndicators()
		{
		}

		private void InvalidateChevronsObjects()
		{
		}
	}
}
