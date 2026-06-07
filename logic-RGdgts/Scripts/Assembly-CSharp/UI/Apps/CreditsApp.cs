using DG.Tweening;
using UI.Credits;
using UI.Elements;
using UnityEngine;

namespace UI.Apps
{
	public class CreditsApp : MultiToolApp
	{
		[SerializeField]
		private CreditsScroll credits;

		private Transform creditsT;

		private Sequence scrollCredits;

		[SerializeField]
		private Ease customEase;

		[SerializeField]
		private int deltaEnd;

		[SerializeField]
		private int duration;

		[SerializeField]
		private UIText idea;

		[SerializeField]
		private UIText design;

		[SerializeField]
		private UIText producer;

		[SerializeField]
		private UIText programmer;

		[SerializeField]
		private UIText ui;

		[SerializeField]
		private UIText additionalprogrammer;

		[SerializeField]
		private UIText art;

		[SerializeField]
		private UIText logo;

		[SerializeField]
		private UIText music;

		[SerializeField]
		private UIText thanks;

		[SerializeField]
		private UIText external;

		[SerializeField]
		private UIText stickers;

		[SerializeField]
		private UIText earlyAcces;

		[SerializeField]
		private UIText doc;

		[SerializeField]
		private UIText icoCompani;

		[SerializeField]
		private UIText icoPeople;

		[SerializeField]
		private UIText nps;

		[SerializeField]
		private UIText locPM;

		[SerializeField]
		private UIText french;

		[SerializeField]
		private UIText german;

		[SerializeField]
		private UIText spanish;

		[SerializeField]
		private UIText portuguese;

		[SerializeField]
		private UIText japanese;

		[SerializeField]
		private UIText chinese;

		[SerializeField]
		private UIText paletteUI;

		public override void Init()
		{
		}

		public override void AppStart()
		{
		}

		public override void AppStop()
		{
		}

		private void InitNames()
		{
		}
	}
}
