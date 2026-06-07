using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.App.Scripts.Objects
{
	public class NewsFeed : MonoBehaviour
	{
		private const string BannerSpriteName = "NewsfeedWarning";

		private const string BannerTextureName = "UI";

		private const float ScreenPercentY = 0.9f;

		private const float ScrollDurationMS = 10000f;

		private const float BannerAlphaDefault = 0.25f;

		private const float BannerAlphaPulse = 0.35f;

		private const float BannerAlphaPulseDurationMS = 1000f;

		private const float BannerFadeInDurationMS = 150f;

		private const float BannerFadeOutDurationMS = 150f;

		private const float TextFadeInDurationMS = 150f;

		private const float TextFadeOutDurationMS = 150f;

		private MultiTargetTween _bannerShowTween;

		private MultiTargetTween _bannerScrollTween;

		private MultiTargetTween _bannerAlphaTween;

		private MultiTargetTween _bannerHideTween;

		private MultiTargetTween _textShowTween;

		private MultiTargetTween _textScrollTween;

		private MultiTargetTween _textHideTween;

		private GameObject _banner;

		private TileSpriteBuilder _bannerTileSpriteBuilder;

		private TileSprite _bannerTileSprite;

		private PhaserText _text;

		private float _textStartPosX;

		private float _bannerScrollStartOffsetX;

		public float _BannerScrollOffsetX;

		public PhaserText TextObject => null;

		private void Awake()
		{
		}

		private void MakeBanner()
		{
		}

		private void MakeText()
		{
		}

		public void SetText(string text)
		{
		}

		public void SetSprite(string _BannerSpriteName, string _BannerTextureName)
		{
		}

		public void SetVisible(bool visible)
		{
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}
	}
}
