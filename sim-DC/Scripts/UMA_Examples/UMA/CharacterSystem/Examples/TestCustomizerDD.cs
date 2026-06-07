using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UMA.Examples;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UMA.CharacterSystem.Examples
{
	public class TestCustomizerDD : MonoBehaviour
	{
		[Serializable]
		public class SharedColorTableItem
		{
			public string name;

			public SharedColorTable sharedColorTable;

			public Sprite swatch;

			public Sprite swatchMetallic;
		}

		[CompilerGenerated]
		private sealed class _003CFinishSaveFile_003Ed__98 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TestCustomizerDD _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CFinishSaveFile_003Ed__98(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public DynamicCharacterAvatar Avatar;

		public SharedColorTable GenericColorList;

		public Sprite genericColorSwatch;

		public Sprite genericColorSwatchMetallic;

		[SerializeField]
		public List<SharedColorTableItem> sharedColorTables;

		public Dropdown changeRaceDropdown;

		private List<string> raceDropdownOptions;

		public GameObject colorDropdownPrefab;

		public GameObject wardrobeDrodownPrefab;

		public GameObject raceDropdownPrefab;

		public GameObject loadableItemPrefab;

		public Button cancelLoadItem;

		public Button saveCompleteBut;

		public GameObject colorDropdownPanel;

		public GameObject wardrobeDropdownPanel;

		public DNAPanel faceEditor;

		public DNAPanel bodyEditor;

		[Tooltip("If set, ONLY the wardrobe slots specified have controls generated. TIP: you can limit this restriction to a race by prefixing the racename to the wardrobe slot name eg ToonFemale:Face")]
		public List<string> limitWardrobeOptions;

		[Tooltip("If set, this prevents the SPECIFIED controls from being generated. TIP: you can limit this restriction to a race by prefixing the racename to the wardrobe slot name eg ToonFemale:Face")]
		public List<string> hideWardrobeOptions;

		public UMAMouseOrbitImproved Orbitor;

		public bool _loadRace;

		public bool _loadDNA;

		public bool _loadWardrobe;

		public bool _loadBodyColors;

		public bool _loadWardrobeColors;

		public UMAContextBase Context;

		private bool _keepDNA;

		private bool _keepWardrobe;

		private bool _keepBodyColors;

		private bool _saveDNA;

		private bool _saveWardrobe;

		private bool _saveColors;

		private string thisRace;

		public bool LoadRace
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool LoadDNA
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool LoadWardrobe
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool LoadBodyColors
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool LoadWardrobeColors
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool KeepDNA
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool KeepWardrobe
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool KeepBodyColors
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SaveDNA
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SaveWardrobe
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SaveColors
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void Start()
		{
		}

		private void BonesCreated()
		{
		}

		public void Init(UMAData umaData)
		{
		}

		public void SetAvatar(GameObject newAvatarObject)
		{
		}

		public void SetUpRacesDropdown(string selected = "")
		{
		}

		public void ChangeRace(string racename)
		{
		}

		public void ChangeRace(int raceId)
		{
		}

		public void InitializeWardrobeDropDowns()
		{
		}

		public void SetUpWardrobeDropdowns()
		{
		}

		private void SetUpWardrobeCollectionDropdown(Transform childGO, Dropdown thisDD)
		{
		}

		public void UpdateWardrobeCollectionDropdownOpts(BaseEventData eventData)
		{
		}

		public void UpdateSuppressedWardrobeDropdowns()
		{
		}

		public void SetUpColorDropdowns()
		{
		}

		public void SetUpColorDropdownValue(CSColorChangerDD colorDropdown, OverlayColorData colorType)
		{
		}

		public void SetUpColorDropdownOptions(CSColorChangerDD colorDropdown, SharedColorTable colorTable, int colorTableSelected, OverlayColorData activeColor)
		{
		}

		public string ColorToHex(Color32 color)
		{
			return null;
		}

		public void SetColor(string colorName, float fColor)
		{
		}

		public void SetSlot(string slotToChange, float fSlotNumber)
		{
		}

		public void SetWardrobeCollectionSlot(string slotToChange, float fSlotNumber)
		{
		}

		public void CloseAllPanels()
		{
		}

		public void ShowHideWardrobeDropdowns()
		{
		}

		public void ShowHideColorDropdowns()
		{
		}

		public void ShowHideFaceDNA()
		{
		}

		public void ShowHideBodyDNA()
		{
		}

		public void TargetBody()
		{
		}

		public void TargetFace()
		{
		}

		public void LoadRecipe()
		{
		}

		public void SaveRecipe()
		{
		}

		public void ListLoadableFiles(ScrollRect ItemList)
		{
		}

		public void LoadListedFile(string filename, string filepath = "")
		{
		}

		public void SaveFile(InputField inputField)
		{
		}

		[IteratorStateMachine(typeof(_003CFinishSaveFile_003Ed__98))]
		private IEnumerator FinishSaveFile()
		{
			return null;
		}
	}
}
