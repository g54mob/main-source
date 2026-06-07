using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.DronePartTemplates;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class CreateDronePartTemplateWindow : MonoBehaviour
	{
		public Camera DroneCam;

		public RenderTexture DroneTexture;

		public UITexture Image;

		public LoadAllDroneParts List;

		public UIInput NameInput;

		public UIInput DescInput;

		private Texture2D _image;

		private DronePart _dronePart;

		private List<WeaponPresetData> _weapons;

		public void Awake()
		{
			base.gameObject.SetActive(false);
		}

		public void Init()
		{
			RuntimeGlobals.StopInteraction = true;
			base.gameObject.SetActive(true);
			_dronePart = ItemSelector.SelectedItems.First();
			if (_dronePart == null)
			{
				return;
			}
			NameInput.value = LocalizationManager.GetTermTranslation("DroneWorkshop/NewTemplate");
			DescInput.value = "";
			_weapons = new List<WeaponPresetData>();
			foreach (Weapon weapon in _dronePart.GetAllChildParts<Weapon>())
			{
				if (_weapons.All((WeaponPresetData w) => w.UniqueId != weapon.Preset.UniqueID))
				{
					_weapons.Add(weapon.Preset.Save());
				}
			}
			ItemSelector.Deselect(_dronePart);
			_dronePart.PrepareForImageRecursive();
			DronePartManager.Instance.ActiveDrone.RootDronePart.EnableRenderers(false);
			_dronePart.EnableRenderers(true);
			_dronePart.EnableLineRenderer(false);
			Bounds bounds = _dronePart.CalculateDroneBounds();
			DroneCam.targetTexture = DroneTexture;
			Vector3 position = DroneCam.transform.position;
			DroneCam.transform.position = new Vector3(bounds.center.x, bounds.center.y, position.z);
			DroneCam.orthographicSize = Math.Max(bounds.size.x / 2f, bounds.size.y / 2f);
			DroneCam.Render();
			Texture2D texture2D = new Texture2D(DroneTexture.width, DroneTexture.height, TextureFormat.ARGB32, false, true);
			RenderTexture.active = DroneTexture;
			texture2D.ReadPixels(new Rect(0f, 0f, DroneTexture.width, DroneTexture.height), 0, 0);
			texture2D.Apply(false);
			Image.mainTexture = texture2D;
			_image = texture2D;
			_dronePart.EnableLineRenderer(true);
			DronePartManager.Instance.ActiveDrone.RootDronePart.EnableRenderers(true);
			ItemSelector.Select(_dronePart);
		}

		public void Close()
		{
			base.gameObject.SetActive(false);
			RuntimeGlobals.StopInteraction = false;
		}

		public void CreateTemplate()
		{
			BaseSingleton<DronePartTemplateManager>.Instance.CreateTemplate(_dronePart.GenerateData(), _weapons, NameInput.value, DescInput.value, _image);
			List.SelectedDronePartType = EDronePartType.None;
			List.ShowTemplates = true;
			List.FillUp();
			Close();
		}
	}
}
