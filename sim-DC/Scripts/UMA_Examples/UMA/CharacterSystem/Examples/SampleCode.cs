using System.Collections.Generic;
using UMA.Examples;
using UnityEngine;
using UnityEngine.UI;

namespace UMA.CharacterSystem.Examples
{
	public class SampleCode : MonoBehaviour
	{
		public DynamicCharacterAvatar Avatar;

		public GameObject SlotPrefab;

		public GameObject WardrobePrefab;

		public GameObject SlotPanel;

		public GameObject WardrobePanel;

		public GameObject ColorPrefab;

		public GameObject DnaPrefab;

		public GameObject LabelPrefab;

		public GameObject GeneralHelpText;

		public GameObject WardrobeHelpText;

		public GameObject ColorsHelpText;

		public GameObject DnaHelpText;

		public GameObject AvatarPrefab;

		public GameObject NoBuildPrefab;

		public UMAMouseOrbitImproved Orbiter;

		public SharedColorTable HairColor;

		public SharedColorTable SkinColor;

		public SharedColorTable EyesColor;

		public SharedColorTable ClothingColor;

		public Dropdown RaceDropdown;

		public GameObject CharacterUI;

		public bool PreloadAndUnload;

		public Slider TestSlider;

		public UMAWardrobeCollection CollectionToAdd;

		public bool UseHighresModels;

		private List<RaceData> races;

		public SharedColorTable SkinColors;

		public SharedColorTable HairColors;

		public void Start()
		{
		}

		public void SliderChange(float value)
		{
		}

		public void UnloadAllItems(bool force)
		{
		}

		private void Cleanup()
		{
		}

		public void HelpClick()
		{
		}

		public void WardrobeHelpClick()
		{
		}

		public void ColorsHelpClick()
		{
		}

		public void DNAHelpClick()
		{
		}

		public void DnaClick()
		{
		}

		public void ColorsClick()
		{
		}

		public void WardrobeClick()
		{
		}

		public void DumpData()
		{
		}

		public void CreateFromPrefab()
		{
		}

		public void DynamicCreateClick()
		{
		}

		public void SetRawColorTest()
		{
		}

		public void ChangeRace(int index)
		{
		}

		public void ChangeSex()
		{
		}

		public void CenterCam()
		{
		}

		public void ToggleUpdateBounds()
		{
		}

		public void RandomClick()
		{
		}

		private void RandomizeAvatar(DynamicCharacterAvatar Avatar)
		{
		}

		public void LinkToAssets()
		{
		}

		public void ToggleAnimation()
		{
		}
	}
}
