using Assets.Behaviour.UI;
using Assets.Source.Player;
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
			_countText.TL("@T12RocketPartsCommitted", GamePlayer.Current.RocketParts, T12LaunchFacility.PartsPerRocket);
			_rocketSprite.size = new Vector2(_rocketSprite.size.x, _rocketHeight * GameMath.Clamp01(GamePlayer.Current.RocketParts, T12LaunchFacility.PartsPerRocket));
			_launchButton.gameObject.SetActive(GamePlayer.Current.RocketParts >= T12LaunchFacility.PartsPerRocket);
		}

		public void LaunchButton()
		{
			GameUI.Instance.ShowFullScreenUI(RocketLaunchUI.Instance);
		}
	}
}
