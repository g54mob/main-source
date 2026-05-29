using Assets.Behaviour.UI;
using Assets.Source.Player;
using Assets.Source.UI;
using Assets.Source.Util;
using Assets.Source.World.Frames;
using TMPro;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T12LaunchPadLauncher : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _countText;

		[SerializeField]
		private SpriteRenderer _rocketSprite;

		[SerializeField]
		private Transform _launchButton;

		private ActiveWorldFrame _parent;

		private float _rocketHeight;

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
			_rocketHeight = _rocketSprite.size.y;
		}

		private void Update()
		{
			_ = _parent.ActiveFrame;
			_countText.text = UIHelper.HighlightText(GameMath.FormatNumber(GamePlayer.Current.RocketParts) + " / " + GameMath.FormatNumber(T12LaunchFacility.PartsPerRocket)) + " parts committed.";
			_rocketSprite.size = new Vector2(_rocketSprite.size.x, _rocketHeight * Mathf.Clamp01((float)GamePlayer.Current.RocketParts / (float)T12LaunchFacility.PartsPerRocket));
			_launchButton.gameObject.SetActive(GamePlayer.Current.RocketParts >= T12LaunchFacility.PartsPerRocket);
		}

		public void LaunchButton()
		{
			GameUI.Instance.ShowFullScreenUI(RocketLaunchUI.Instance);
		}
	}
}
