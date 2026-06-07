using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.World;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings;
using I2.Loc;
using NGenerics.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ToggleAirResistance : SerializedMonoBehaviour
	{
		public UITexture Image;

		public UILabel Label;

		public Color NormalColor;

		public Color HoverColor;

		public Texture2D[] Textures;

		private bool _hover;

		private EAirResistance[] _modes = new EAirResistance[4]
		{
			EAirResistance.None,
			EAirResistance.Low,
			EAirResistance.Normal,
			EAirResistance.High
		};

		private int _selectedIndex;

		public void Start()
		{
			_selectedIndex = _modes.FindIndex((EAirResistance i) => i == WorldController.TerrainSettings.TestSimulationAirResistance);
			ShowActive();
		}

		public void OnClick()
		{
			_selectedIndex++;
			if (_selectedIndex >= _modes.Length)
			{
				_selectedIndex = 0;
			}
			WorldController.TerrainSettings.TestSimulationAirResistance = _modes[_selectedIndex];
			ShowActive();
		}

		private void ShowActive()
		{
			Image.mainTexture = Textures[_selectedIndex];
			Label.text = LabelHelper.White + LocalizationManager.GetTermTranslation("GalaxyMap/AirResistance") + ": " + LabelHelper.Orange + WorldController.TerrainSettings.TestSimulationAirResistance.ToLocalizationString();
		}

		public void Update()
		{
			Image.color = (_hover ? HoverColor : NormalColor);
		}

		protected virtual void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
