using System;
using I18n;
using UnityEngine;

namespace Gh.Tk
{
	public class Clock3DUIView : BaseInteractable3DUIView
	{
		public Transform hourHand;

		public Transform minuteHand;

		public TextMeshProI18n digital;

		private GlobalTimeController _timeController;

		private bool isShowingDigitalClock;

		protected const float _hourHandTotalDegrees = 720f;

		protected const float _minuteHandTotalDegrees = 8640f;

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void MinuteChanged(object sender, EventArgs e)
		{
		}

		public override void OnClicked()
		{
		}

		protected virtual void Update()
		{
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}
	}
}
