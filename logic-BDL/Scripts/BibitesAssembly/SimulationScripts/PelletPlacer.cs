using System;
using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using SettingScripts;
using TMPro;
using UIScripts;
using UIScripts.SettingHandles;
using UIScripts.SettingHandles.References;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SimulationScripts
{
	public class PelletPlacer : UIPanel
	{
		private static FloatSetting pelletSize = new FloatSetting
		{
			Name = "Pellet Size Factor",
			minValue = 0.1f,
			maxValue = 1000f,
			DefaultValue = 1f,
			val = 1f,
			precision = 1
		};

		private static IntSetting pelletCount = new IntSetting
		{
			Name = "Pellet Number",
			minValue = 1,
			maxValue = 10,
			DefaultValue = 1,
			val = 1
		};

		private static LogFloatSettingSlider pelletSizeSlider = new LogFloatSettingSlider(pelletSize, 10f);

		private static IntSettingSlider pelletCountSlider = new IntSettingSlider(pelletCount);

		[SerializeField]
		private TMP_Dropdown materialDropdown;

		public SettingSliderReference sizeRef;

		public SettingSliderReference countRef;

		private List<ISettingHandle> settings = new List<ISettingHandle> { pelletSizeSlider, pelletCountSlider };

		private GraphicRaycaster rayCaster;

		private EventSystem eventSystem;

		private float pileRadius;

		private Vector2 lastPlacement;

		private bool isDragging;

		private Camera cam;

		private MatterMaterial material;

		public override void InitPanel()
		{
			cam = Camera.main;
			rayCaster = GameObject.Find("UICanvas").GetComponent<GraphicRaycaster>();
			eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
			pelletSizeSlider.InitUIElement(sizeRef);
			pelletCountSlider.InitUIElement(countRef);
			materialDropdown.options.Clear();
			MatterMaterialManager.PhysicalMaterials.ForEach(delegate(MatterMaterial mat)
			{
				materialDropdown.options.Add(new TMP_Dropdown.OptionData(mat.Name, mat.defaultSprite, new Color(0f, 0f, 0f, 0f)));
			});
			materialDropdown.onValueChanged.AddListener(ChangeMaterial);
			materialDropdown.value = 0;
			ChangeMaterial(0);
			materialDropdown.RefreshShownValue();
			int val = pelletCount.val;
			float energy = ScenarioSettings.Instance.pelletEnergy.val * pelletSize.val;
			float num = material.AmountOfEnergy(energy);
			pileRadius = Mathf.Sqrt((float)(2 * val) * num / MathF.PI);
		}

		protected override void UpdatePanel()
		{
			if (!base.isActiveAndEnabled || EventSystem.current.IsPointerOverGameObject())
			{
				return;
			}
			bool mouseButton = Input.GetMouseButton(0);
			Vector3 vector = cam.ScreenToWorldPoint(Input.mousePosition);
			vector.z = 0f;
			if (!isDragging && mouseButton)
			{
				PointerEventData pointerEventData = new PointerEventData(eventSystem);
				pointerEventData.position = Input.mousePosition;
				List<RaycastResult> list = new List<RaycastResult>();
				rayCaster.Raycast(pointerEventData, list);
				if (!list.Any())
				{
					isDragging = true;
					PlacementEvent(vector);
				}
			}
			else if (!mouseButton)
			{
				isDragging = false;
			}
			else if ((lastPlacement - (Vector2)vector).magnitude > 1.5f * pileRadius)
			{
				PlacementEvent(vector);
			}
		}

		private void PlacementEvent(Vector3 clickPos)
		{
			int val = pelletCount.val;
			float num = ScenarioSettings.Instance.pelletEnergy.val * pelletSize.val;
			float num2 = material.AmountOfEnergy(num);
			if (val <= 1)
			{
				WorldObjectsSpawner.Instance.SpawnPelletOfMatter(material, clickPos, num);
			}
			else
			{
				pileRadius = Mathf.Sqrt((float)(2 * val) * num2 / MathF.PI);
				for (int i = 0; i < val; i++)
				{
					Vector3 value = clickPos + (Vector3)UnityEngine.Random.insideUnitCircle * pileRadius;
					WorldObjectsSpawner.Instance.SpawnPelletOfMatter(material, value, num * UnityEngine.Random.Range(0.75f, 1.25f));
				}
			}
			lastPlacement = clickPos;
		}

		public void ChangeMaterial(int value)
		{
			material = MatterMaterialManager.PhysicalMaterials.FirstOrDefault((MatterMaterial mat) => mat.Name == materialDropdown.options[value].text);
		}
	}
}
