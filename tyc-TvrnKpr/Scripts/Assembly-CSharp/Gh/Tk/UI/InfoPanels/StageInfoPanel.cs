using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class StageInfoPanel : PropInfoPanel
	{
		[Header("Stage & Entertainment")]
		[SerializeField]
		private List<Button3DUIView> _openScheduleButtons;

		[SerializeField]
		private List<EntertainerBillingCard3DUIView> _billingCards;

		[SerializeField]
		private EntertainerComingSoon3DUIView _comingSoonCard;

		public override void Start()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		private void OnListingsChanged(object sender, EventArgs e)
		{
		}

		public void RefreshListings()
		{
		}
	}
}
