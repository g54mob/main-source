using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class ShowDrones : MonoBehaviour
	{
		public bool Steam;

		public UILabel Label;

		public UITexture Background;

		public Color NormalColor;

		public Color HoverColor;

		public Color SelectedColor;

		public Color NormalTextColor;

		public Color HoverTextColor;

		public Color SelectedTextColor;

		private DroneSelectionManager _manager;

		private bool _hover;

		public void Init(DroneSelectionManager droneSelectionManager)
		{
			_manager = droneSelectionManager;
		}

		public void OnClick()
		{
			_manager.ShowSteamDrones(Steam);
		}

		public void Update()
		{
			if (_manager.AreSteamDronesShown() == Steam)
			{
				Background.color = (_hover ? HoverColor : SelectedColor);
				Label.color = (_hover ? HoverTextColor : SelectedTextColor);
			}
			else
			{
				Background.color = (_hover ? HoverColor : NormalColor);
				Label.color = (_hover ? HoverTextColor : NormalTextColor);
			}
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
