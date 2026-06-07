using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class DroneInformationItem : MonoBehaviour
	{
		public UILabel NameLabel;

		public GameObject WasShared;

		public UITexture DroneImage;

		public UITexture Background;

		public Color NormalColor;

		public Color HoverColor;

		public Color SelectedColor;

		public Color NormalTextColor;

		public Color HoverTextColor;

		public Color SelectedTextColor;

		[HideInInspector]
		public DroneData Drone;

		private IDroneInformationList _manager;

		private bool _hover;

		private bool _wasInitialized;

		public void Init(IDroneInformationList manager, DroneData drone)
		{
			_manager = manager;
			Drone = drone;
			DroneImage.mainTexture = drone.Image;
			if (DroneImage.mainTexture != null)
			{
				DroneImage.mainTexture.wrapMode = TextureWrapMode.Clamp;
			}
			NameLabel.text = Drone.DroneName;
			WasShared.SetActive(drone.WasShared);
			_wasInitialized = true;
		}

		public void OnClick()
		{
			if (_wasInitialized)
			{
				_manager.SelectDrone(Drone);
			}
		}

		public void Update()
		{
			if (_wasInitialized)
			{
				NameLabel.text = Drone.DroneName;
				if (_manager.GetSelectedDrone() == Drone)
				{
					Background.color = SelectedColor;
					NameLabel.color = SelectedTextColor;
				}
				else
				{
					Background.color = (_hover ? HoverColor : NormalColor);
					NameLabel.color = (_hover ? HoverTextColor : NormalTextColor);
				}
			}
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
