using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class ShowTournamentPanelButton : MonoBehaviour
	{
		public Color NormalBackgroundColor;

		public Color HoverBackgroundColor;

		public Color DisabledBackgroundColor;

		public Color NormalForegroundColor;

		public Color HoverForegroundColor;

		public Color DisabledForegroundColor;

		public UITexture Background;

		public UILabel Label;

		private bool _enabled;

		private bool _hover;

		private TournamentStartScreen _startScreen;

		public void Init(TournamentStartScreen startScreen)
		{
			_startScreen = startScreen;
		}

		public void OnClick()
		{
			_startScreen.ShowTournamentPanel();
		}

		public void Enable(bool enable)
		{
			_enabled = enable;
		}

		public void Update()
		{
			if (!_enabled)
			{
				Label.color = (_hover ? HoverForegroundColor : DisabledForegroundColor);
			}
			else
			{
				Label.color = (_hover ? HoverForegroundColor : NormalForegroundColor);
			}
			if (!_enabled)
			{
				Background.color = (_hover ? HoverBackgroundColor : DisabledBackgroundColor);
			}
			else
			{
				Background.color = (_hover ? HoverBackgroundColor : NormalBackgroundColor);
			}
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
