using System.Collections.Generic;
using UMA.CharacterSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UMA
{
	public class NewUMAGUI : MonoBehaviour, IDNASelector, IColorSelector, IItemSelector
	{
		private bool lerping;

		private Vector3 lerpTo;

		private float lerpPos;

		private Vector3 LerpStart;

		private Transform mainCameraTransform;

		private bool constructing;

		[Header("UMA")]
		public DynamicCharacterAvatar avatar;

		public bool showConsole;

		[Header("GUI Prefabs")]
		public GameObject ColorSelector;

		public GameObject DNAAdjuster;

		public GameObject ColorLabel;

		public GameObject GridContainer;

		public GameObject Item;

		public GameObject ItemContainer;

		public GameObject InfoText;

		public GameObject LogLabel;

		[Header("Camera Animation")]
		public Transform FacePos;

		public Transform LegsPos;

		public Transform BodyPos;

		public string FaceBoneName;

		public string LegsBoneName;

		public float FaceBoneOffset;

		public float LegsBoneOffset;

		public float lerpSpeed;

		public AnimationCurve lerpCurve;

		[Header("Test")]
		public List<string> Labels;

		[Header("Color Tables")]
		public List<SharedColorTable> FaceColors;

		public List<SharedColorTable> HairColors;

		public List<SharedColorTable> LegsColors;

		public List<SharedColorTable> BodyColors;

		[Header("DNA")]
		public List<string> FaceDNA;

		public List<string> HairDNA;

		public List<string> LegsDNA;

		public List<string> BodyDNA;

		[Header("Items")]
		public List<UMAWardrobeRecipe> FaceItems;

		public List<UMAWardrobeRecipe> HairItems;

		public List<UMAWardrobeRecipe> LegsItems;

		public List<UMAWardrobeRecipe> BodyItems;

		[Header("Containers")]
		public GameObject DNAContainer;

		public GameObject ItemsContainer;

		public GameObject LogDetailContainer;

		[Header("Buttons")]
		public GameObject FaceButton;

		public GameObject LegsButton;

		public GameObject BodyButton;

		public GameObject HairButton;

		public GameObject BackButton;

		private List<string> ConsoleLog;

		private List<string> PendingLog;

		private GameObject currentButton;

		private string currentInfoText;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void HandleLog(string logString, string stackTrace, LogType type)
		{
		}

		public void SetColor(string ColorName, OverlayColorData color)
		{
		}

		public void SetDNA(string DNAName, float value)
		{
		}

		public void SetItem(UMAWardrobeRecipe item)
		{
		}

		private Vector3 GetLerpPosition(Transform pos, string bone, float offset)
		{
			return default(Vector3);
		}

		private void StartLerp(Transform pos, string bone, float offset)
		{
		}

		private void AddColors(GameObject layoutParent, SharedColorTable colorTable)
		{
		}

		public string[] BreakCamelCase(string str)
		{
			return null;
		}

		private void CleanContainer(GameObject container)
		{
		}

		private void SetupCategory(GameObject container, List<SharedColorTable> colorTables, List<string> DNA, List<UMAWardrobeRecipe> items)
		{
		}

		private void AddWardrobeItems(GameObject container, List<UMAWardrobeRecipe> items)
		{
		}

		private void AddWardrobeItemsForCategory(GameObject container, List<UMAWardrobeRecipe> items, string category)
		{
		}

		private void AddDNA(GameObject container, List<string> DNA)
		{
		}

		private void AddEffector(GameObject parent, string dna, string label)
		{
		}

		private void AddHeader(GameObject container, string currentHeader)
		{
		}

		private void DeactivateButtons()
		{
		}

		private void ActivateButton(GameObject button)
		{
		}

		private void DeactivateButton(GameObject button)
		{
		}

		public void ShowInfo()
		{
		}

		private string TranslateMacros(string text)
		{
			return null;
		}

		private void ShowLogItem(string logtext)
		{
		}

		private void ShowLogDetail(string log)
		{
		}

		private void ShowLog()
		{
		}

		public void OnLogitemClick()
		{
		}

		public void OnFaceClick()
		{
		}

		public void OnLegsClick()
		{
		}

		public void OnBodyClick()
		{
		}

		public void OnHairClick()
		{
		}

		public void OnRaceClick(string raceName)
		{
		}

		public void OnBackClick()
		{
		}

		public void DoDrag(BaseEventData eventData)
		{
		}
	}
}
