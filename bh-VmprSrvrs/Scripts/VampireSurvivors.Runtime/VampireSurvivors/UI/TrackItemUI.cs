using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.Data;

namespace VampireSurvivors.UI
{
	public class TrackItemUI : SelectableUI
	{
		[SerializeField]
		private Image _Icon;

		[SerializeField]
		private TextMeshProUGUI _Title;

		[SerializeField]
		private Image _Frame;

		[SerializeField]
		private Button _Button;

		[FormerlySerializedAs("_cg")]
		[SerializeField]
		private CanvasGroup _CanvasGroup;

		private Canvas _canvas;

		private BgmType _bgmType;

		private MusicData _data;

		private AdvancedMusicSelection _page;

		private Color _deselectColor;

		private float _deselectAlpha;

		private bool _holdSelection;

		private Tween _colorTween;

		private Tween _fadeTween;

		protected override void Awake()
		{
		}

		public void SetData(string name, Sprite icon, BgmType bgmType, MusicData data, AdvancedMusicSelection page)
		{
		}

		protected override void OnDisable()
		{
		}

		public void KillTweens()
		{
		}

		public void OnMouseClick()
		{
		}

		public BgmType GetBgmType()
		{
			return default(BgmType);
		}

		public MusicData GetMusicData()
		{
			return null;
		}

		public void SetLoading(bool v)
		{
		}

		public void HoldSelection()
		{
		}

		public void ReleaseSelection()
		{
		}

		public void ForceDeselect()
		{
		}

		protected override void OnSelected()
		{
		}
	}
}
