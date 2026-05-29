using Assets.Behaviour.UI;
using Assets.Source.Player;
using Assets.Source.UI;
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
			_countText.text = UIHelper.HighlightText(GameMath.FormatNumber(GamePlayer.Current.DemoTurtleParts) + " / " + GameMath.FormatNumber(DemoTurtle.PartsPerTurtle)) + " parts committed.";
			_turtleSprite.size = new Vector2(_turtleSprite.size.x, _rocketHeight * Mathf.Clamp01((float)GamePlayer.Current.DemoTurtleParts / (float)DemoTurtle.PartsPerTurtle));
			if ((bool)_launchButton)
			{
				_launchButton.gameObject.SetActive(GamePlayer.Current.DemoTurtleParts >= DemoTurtle.PartsPerTurtle);
			}
		}

		public void LaunchButton()
		{
			UIStatusMessage.Show("Demo finished in " + GameMath.FormatTime(GamePlayer.Current.SessionStats.PlayTime), "Items_7", persistent: true);
			GameUI.Instance.ShowDemoThanksMessage();
			Object.Destroy(_launchButton.gameObject);
		}
	}
}
