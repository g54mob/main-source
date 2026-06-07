using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI
{
	public class SealPanel : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _Title;

		[SerializeField]
		private TextMeshProUGUI _Amount;

		[SerializeField]
		private CanvasGroup _Warning;

		[SerializeField]
		private Button _PortraitMegaSealButton;

		private PlayerOptions _playerOptions;

		private Tween _warningTween;

		public void Initialize(PlayerOptions player)
		{
		}

		public void ShowWarning()
		{
		}

		public void UpdateValues()
		{
		}

		private void SetNormalLayout()
		{
		}

		private void SetPortraitMegaSealLayout()
		{
		}

		private bool ShowPortraitMegaFormat()
		{
			return false;
		}
	}
}
