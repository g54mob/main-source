using Assets.Source.Player;
using Assets.Source.Util;
using Assets.Source.World.Frames;
using TMPro;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class DemoTurtleScreen : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _countText;

		[SerializeField]
		private SpriteRenderer _turtleSprite;

		[SerializeField]
		private Transform _launchButton;

		private ActiveWorldFrame _parent;

		private float _rocketHeight;

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
			_rocketHeight = _turtleSprite.size.y;
		}

		private void Update()
		{
			_countText.TL("@T12RocketPartsCommitted", GamePlayer.Current.DemoTurtleParts, DemoTurtle.PartsPerTurtle);
			_turtleSprite.size = new Vector2(_turtleSprite.size.x, _rocketHeight * GameMath.Clamp01(GamePlayer.Current.DemoTurtleParts, DemoTurtle.PartsPerTurtle));
		}

		public void LaunchButton()
		{
		}
	}
}
