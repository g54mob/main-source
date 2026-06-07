using Assets.Nimbatus.GUI.MissionControl.Scripts.Main.MissionRewards;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.Main
{
	public class LocationDetailDisplay : MonoBehaviour
	{
		public UILabel NameLabel;

		public UILabel GalaxyNumberLabel;

		public UITexture LocationImage;

		public TravelButton TravelButton;

		public VisitLocationButton VisitButton;

		public MissionRewardDisplay MissionDisplay;

		public void Init(MissionControlUiManager manager, LocationData location)
		{
			if (location == null)
			{
				base.gameObject.SetActive(false);
				return;
			}
			base.gameObject.SetActive(true);
			NameLabel.text = location.Name;
			LocationImage.mainTexture = location.GetPreviewImage();
			Material material = new Material(LocationImage.material);
			material.SetFloat("_Grayscale", (!location.Sector.Explored || !location.Visitable) ? 1 : 0);
			LocationImage.material = material;
			if ((bool)LocationImage.GetComponent<TweenRotation>())
			{
				TweenRotation component = LocationImage.GetComponent<TweenRotation>();
				int num = Random.Range(0, 360);
				int num2 = num + ((Random.Range(0, 2) == 0) ? 360 : (-360));
				if (location.IsShopLocation || location is BossfightLocationData)
				{
					num = Random.Range(-20, 0);
					num2 = Random.Range(0, 20);
				}
				LocationImage.transform.eulerAngles.Set(0f, 0f, num);
				component.from.z = num;
				component.to.z = num2;
				component.value = Quaternion.Euler(new Vector3(0f, 0f, num));
				component.ResetToBeginning();
			}
			TravelButton.gameObject.SetActive(manager.SelectedLocation != manager.CurrentLocation);
			VisitButton.gameObject.SetActive(manager.SelectedLocation == manager.CurrentLocation);
			MissionDisplay.Init(location);
			TravelButton.Init(manager);
			VisitButton.Init(manager);
			GalaxyNumberLabel.text = LocalizationManager.GetTermTranslation("GalaxyMap/Galaxy") + " #" + SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.Level;
		}
	}
}
