using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class GameoverinoPage : BaseUIPage
	{
		[FormerlySerializedAs("Pixeler")]
		[SerializeField]
		private PixelationTool _Pixeler;

		[SerializeField]
		private Button _ReviveButton;

		[SerializeField]
		private UISpriteAnimation _ReviveAnimation;

		[SerializeField]
		private Material _GameOverPixelise;

		[SerializeField]
		private Image _WhiteFlash;

		[SerializeField]
		private Image _Background;

		[SerializeField]
		private Image _Title;

		[SerializeField]
		private Image _LeftHand;

		[SerializeField]
		private Image _RightHand;

		[SerializeField]
		private Material _BackgroundPixelMat;

		[SerializeField]
		private Material _TitlePixelMat;

		private PlayerOptions _playerOptions;

		private static readonly int CellSizeX;

		private static readonly int CellSizeY;

		[Inject]
		private void Construct(PlayerOptions player)
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		private void OnIntroEnded()
		{
		}

		private void PlayAutoRevive()
		{
		}
	}
}
