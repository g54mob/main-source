using System.Collections;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Workshop;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ShowCenterOfMass : MonoBehaviour
	{
		public GameObject CenterOfMass;

		public UITexture Icon;

		public Color SelectedColor;

		public Color NormalColor;

		public Color HoverColor;

		private Vector3 _centerOfMass;

		private bool _hover;

		public void Start()
		{
			StartCoroutine(DisplayCenterOfMass());
		}

		public void OnClick()
		{
			SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.ShowCenterOfMass = !SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.ShowCenterOfMass;
		}

		public IEnumerator DisplayCenterOfMass()
		{
			while (true)
			{
				if (SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.ShowCenterOfMass)
				{
					CenterOfMass.SetActive(true);
					_centerOfMass = DronePartManager.Instance.CalculateCenterOfMass();
					_centerOfMass.z = CenterOfMass.transform.position.z;
					CenterOfMass.transform.position = _centerOfMass;
				}
				yield return new WaitForSeconds(0.05f);
			}
		}

		public void Update()
		{
			if (SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.ShowCenterOfMass)
			{
				CenterOfMass.SetActive(true);
				Icon.color = SelectedColor;
			}
			else
			{
				CenterOfMass.SetActive(false);
				Icon.color = (_hover ? HoverColor : NormalColor);
			}
		}

		public void OnTooltip(bool show)
		{
			NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("DroneWorkshop/ToggleCenterOfMass"));
			if (!show)
			{
				NimbatusToolTip.Show(null);
			}
		}

		protected virtual void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
