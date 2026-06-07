using System;
using I18n;
using TMPro;
using UnityEngine;

namespace Gh.Tk
{
	public class Date3DUIView : BaseInteractable3DUIView
	{
		[SerializeField]
		private TextMeshProI18n _dayValueText;

		[SerializeField]
		private TextMeshPro _dateValueText;

		[SerializeField]
		private Animator _dateAnimator;

		protected override void Start()
		{
		}

		private TooltipData GetDayTooltip()
		{
			return null;
		}

		private void ResetUI(object sender, EventArgs e)
		{
		}

		protected override void OnClickedInternal()
		{
		}

		private void OnDayOfWeekChanged(object sender, EventArgs e)
		{
		}

		private void OnDayChanged(object sender, EventArgs e)
		{
		}

		public void Jiggle()
		{
		}
	}
}
