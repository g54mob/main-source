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
	public class ToggleGravity : SerializedMonoBehaviour
	{
		public UITexture Image;

		public UILabel Label;

		public Color NormalColor;

		public Color HoverColor;

		public Texture2D[] GravityTextures;

		private bool _hover;

		private EGravity[] _gravityModes = new EGravity[4]
		{
			EGravity.None,
			EGravity.Low,
			EGravity.Normal,
			EGravity.High
		};

		private int _selectedGravityIndex;

		public void Start()
		{
			_selectedGravityIndex = _gravityModes.FindIndex((EGravity i) => i == WorldController.TerrainSettings.TestSimulationGravity);
			ShowActive();
		}

		public void OnClick()
		{
			_selectedGravityIndex++;
			if (_selectedGravityIndex >= _gravityModes.Length)
			{
				_selectedGravityIndex = 0;
			}
			WorldController.TerrainSettings.TestSimulationGravity = _gravityModes[_selectedGravityIndex];
			ShowActive();
		}

		private void ShowActive()
		{
			Image.mainTexture = GravityTextures[_selectedGravityIndex];
			Label.text = LabelHelper.White + LocalizationManager.GetTermTranslation("GalaxyMap/Gravity") + ": " + LabelHelper.Orange + WorldController.TerrainSettings.TestSimulationGravity.ToLocalizationString();
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
