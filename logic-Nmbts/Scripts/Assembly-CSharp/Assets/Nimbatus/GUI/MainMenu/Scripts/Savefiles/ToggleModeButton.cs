using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts.Savefiles
{
	public class ToggleModeButton : MonoBehaviour
	{
		public EGameMode Mode;

		public UITexture Background;

		public UILabel Label;

		public Color SelectedColor;

		public Color NormalColor;

		private StartGameUI _parent;

		public void Init(StartGameUI parent)
		{
			_parent = parent;
		}

		public void Update()
		{
			if (_parent != null)
			{
				if (_parent.SelectedGameMode == Mode)
				{
					Background.color = SelectedColor;
					Label.color = SelectedColor;
				}
				else
				{
					Background.color = NormalColor;
					Label.color = NormalColor;
				}
			}
		}

		public void OnClick()
		{
			_parent.SetGameMode(Mode);
		}
	}
}
