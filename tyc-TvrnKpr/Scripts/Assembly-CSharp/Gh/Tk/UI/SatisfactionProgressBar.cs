using UnityEngine;

namespace Gh.Tk.UI
{
	public class SatisfactionProgressBar : BaseInteractable3DUIView
	{
		[SerializeField]
		private Transform _indicator;

		[SerializeField]
		private Vector3 _indicatorStartPosition;

		[SerializeField]
		private Vector3 _indicatorEndPosition;

		[SerializeField]
		private Transform _thumbBacker;

		[SerializeField]
		private Transform _thumbUp;

		[SerializeField]
		private Transform _thumbDown;

		private PatronSatisfactionCompoundStat _stat;

		public PatronSatisfactionCompoundStat Stat
		{
			private get
			{
				return null;
			}
			set
			{
			}
		}

		private void OnValueChanged(object sender, ValueChangedEventArgs<float> e)
		{
		}

		private void UpdateValues()
		{
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}
	}
}
