using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class LocalDroneItem : MonoBehaviour
	{
		public UILabel NameLabel;

		public UITexture DroneImage;

		public UITexture Background;

		public Color NormalColor;

		public Color HoverColor;

		[HideInInspector]
		public DroneData Drone;

		private LocalDroneList _list;

		private bool _hover;

		public void Init(LocalDroneList list, DroneData drone)
		{
			_list = list;
			Drone = drone;
			DroneImage.mainTexture = drone.Image;
			if (DroneImage.mainTexture != null)
			{
				DroneImage.mainTexture.wrapMode = TextureWrapMode.Clamp;
			}
			NameLabel.text = Drone.DroneName;
			_hover = false;
			Background.color = NormalColor;
		}

		public void OnClick()
		{
			_list.SelectItem(Drone);
		}

		public void Update()
		{
			NameLabel.text = Drone.DroneName;
			Background.color = (_hover ? HoverColor : NormalColor);
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
