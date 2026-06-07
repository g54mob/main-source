using DG.Tweening;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI
{
	public class StageItemUI : SelectableUI
	{
		[SerializeField]
		private Image _Background;

		[SerializeField]
		private Image _Icon;

		[SerializeField]
		private Localize _NameText;

		[SerializeField]
		private Localize _DescriptionText;

		[SerializeField]
		private Text _StageNumber;

		[SerializeField]
		private Image _Overlay;

		[SerializeField]
		private Image _FrameCorners;

		[SerializeField]
		private GameObject _Exclamation;

		private bool _unlocked;

		private Sequence _specialTween;

		private StageSelectPage _page;

		private StageData _stage;

		private PlayerOptions _playerOptions;

		private readonly string[] _frameNames;

		public StageType Type { get; set; }

		public TextMeshProUGUI DescriptionText => null;

		protected override void OnDestroy()
		{
		}

		public void DoHighlight()
		{
		}

		public void DoUnhighlight()
		{
		}

		public void SetData(PlayerOptions player, StageSelectPage page, StageData stage, Sprite mapSprite, StageType stageType, int index, bool hideDescriptionText)
		{
		}

		public void SetInfoPanel()
		{
		}

		public StageData GetData()
		{
			return null;
		}

		public StageType GetStageType()
		{
			return default(StageType);
		}

		public bool HasHyperUnlocked()
		{
			return false;
		}

		public void MakeDisabled()
		{
		}

		public void MakeEnabled()
		{
		}

		protected override void OnSelected()
		{
		}
	}
}
