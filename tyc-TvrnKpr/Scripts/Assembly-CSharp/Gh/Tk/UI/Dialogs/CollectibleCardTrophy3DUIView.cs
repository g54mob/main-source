using System;
using System.Collections.Generic;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class CollectibleCardTrophy3DUIView : TrophyDisplay3DUIView
	{
		private List<GameObject> _cardInstances;

		[SerializeField]
		private TextMeshProI18n _stackAmountText;

		public CollectibleCardData CardData { get; private set; }

		public override bool IsBlocked => false;

		protected override void OnEnable()
		{
		}

		private void OnRewardsChanged(object sender, EventArgs e)
		{
		}

		private void OnCardChanged()
		{
		}

		protected override void OnDisable()
		{
		}

		public void SetData(CollectibleCardData card, DissolveArea3DUIView dissolveMats)
		{
		}

		protected override void UpdateVisuals()
		{
		}

		protected override TooltipData CreateTooltip()
		{
			return null;
		}

		protected CollectibleCard3DUIView CreateCardTrophy(Transform socket)
		{
			return null;
		}
	}
}
