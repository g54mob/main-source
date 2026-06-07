using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class VoteButton : MonoBehaviour
	{
		public bool Upvote;

		public UITexture Background;

		public Color NormalColor;

		public Color HoverColor;

		public Color SelectedColor;

		private ChangeVoteControl _control;

		private bool _hover;

		public void Init(ChangeVoteControl control)
		{
			_control = control;
		}

		public void OnClick()
		{
			if (!(_control == null))
			{
				_control.Vote(Upvote);
			}
		}

		public void Update()
		{
			if (!(_control == null))
			{
				if (_control.HasVoted(Upvote))
				{
					Background.color = (_hover ? HoverColor : SelectedColor);
				}
				else
				{
					Background.color = (_hover ? HoverColor : NormalColor);
				}
			}
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
