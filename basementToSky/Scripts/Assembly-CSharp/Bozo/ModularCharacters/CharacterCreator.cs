using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Bozo.ModularCharacters
{
	public class CharacterCreator : MonoBehaviour
	{
		[Header("Creator Dependencies")]
		public OutfitSystem character;

		public ColorPickerControl colorPickerControl;

		[SerializeField]
		private CharacterSpinner Spinner;

		[SerializeField]
		private Camera iconCamera;

		[SerializeField]
		private RenderTexture iconTexture;

		public OutfitType[] outfitTypes;

		[Header("Outfit Dependencies")]
		private Dictionary<string, Outfit> OutfitDataBase = new Dictionary<string, Outfit>();

		[SerializeField]
		private OutfitSelector outfitSelectorObject;

		private List<OutfitSelector> outfitSelectors = new List<OutfitSelector>();

		[SerializeField]
		private Transform outfitContainer;

		[Header("Texture Dependencies")]
		[SerializeField]
		private TextureSelector textureSelectorObject;

		private List<TextureSelector> textureSelectors = new List<TextureSelector>();

		[SerializeField]
		private Transform decalContainer;

		[SerializeField]
		private Transform patternContainer;

		[Header("BodyShape Dependencies")]
		[SerializeField]
		private BlendSlider blendSliderObject;

		private List<BlendSlider> blendSliders = new List<BlendSlider>();

		private List<BlendSlider> faceBlendSliders = new List<BlendSlider>();

		[SerializeField]
		private BodyShapeSliders modSliderObject;

		private List<BodyShapeSliders> ModSliders = new List<BodyShapeSliders>();

		[SerializeField]
		private Transform bodyShapeContainer;

		[SerializeField]
		private Transform bodyModContainer;

		[SerializeField]
		private Transform faceShapeContainer;

		[SerializeField]
		private Transform faceModContainer;

		[SerializeField]
		private GameObject currentPage;

		private GameObject previousPage;

		private Dictionary<string, List<GameObject>> outfits = new Dictionary<string, List<GameObject>>();

		private List<TexturePackage> textures = new List<TexturePackage>();

		[Header("Save Dependencies")]
		[SerializeField]
		private SaveSelector saveSelector;

		[SerializeField]
		private Dictionary<string, SaveSelector> saveSlots = new Dictionary<string, SaveSelector>();

		[SerializeField]
		private Transform saveContainer;

		[SerializeField]
		private GameObject DeleteConfirmWindow;

		[SerializeField]
		private TMP_Text loadedCharacterNameText;

		[SerializeField]
		private TMP_Text DeleteCharacterNameText;

		[SerializeField]
		private OutfitVisibilityToggler visibilityToggler;

		private OutfitType type;

		[Header("Save Options")]
		public TMP_InputField CharacterName;

		private void Awake()
		{
			outfits.Clear();
			OutfitDataBase.Clear();
			Outfit[] array = Resources.LoadAll<Outfit>("");
			TexturePackage[] array2 = Resources.LoadAll<TexturePackage>("");
			Outfit[] array3 = array;
			foreach (Outfit outfit in array3)
			{
				if (outfit.showCharacterCreator)
				{
					if (OutfitDataBase.ContainsKey(outfit.name))
					{
						Debug.LogWarning("Outfit: " + outfit.name + " has already been added, you may have a duplicate outfit in your project");
					}
					else
					{
						OutfitDataBase.Add(outfit.name, outfit.GetComponent<Outfit>());
					}
				}
			}
			TexturePackage[] array4 = array2;
			foreach (TexturePackage texturePackage in array4)
			{
				textures.Add(texturePackage.GetComponent<TexturePackage>());
			}
			GenerateOutfitSelection();
			GenerateTextureSelection();
		}

		private void OnEnable()
		{
			OutfitSystem outfitSystem = character;
			outfitSystem.OnOutfitChanged = (UnityAction<Outfit>)Delegate.Combine(outfitSystem.OnOutfitChanged, new UnityAction<Outfit>(OnOutfitUpdate));
			OutfitSystem outfitSystem2 = character;
			outfitSystem2.OnRigChanged = (UnityAction<SkinnedMeshRenderer>)Delegate.Combine(outfitSystem2.OnRigChanged, new UnityAction<SkinnedMeshRenderer>(OnRigUpdate));
		}

		private void OnDisable()
		{
			OutfitSystem outfitSystem = character;
			outfitSystem.OnOutfitChanged = (UnityAction<Outfit>)Delegate.Remove(outfitSystem.OnOutfitChanged, new UnityAction<Outfit>(OnOutfitUpdate));
			OutfitSystem outfitSystem2 = character;
			outfitSystem2.OnRigChanged = (UnityAction<SkinnedMeshRenderer>)Delegate.Remove(outfitSystem2.OnRigChanged, new UnityAction<SkinnedMeshRenderer>(OnRigUpdate));
		}

		public void Start()
		{
			GetBodyBlends();
			GetFaceBlends();
			GetBodyMods();
			SwitchCatagory("Top");
			UpdateCharacterSaves();
		}

		public void GenerateOutfitSelection()
		{
			Outfit[] array = OutfitDataBase.Values.ToArray();
			foreach (Outfit outfit in array)
			{
				OutfitSelector outfitSelector = UnityEngine.Object.Instantiate(outfitSelectorObject, outfitContainer);
				outfitSelector.Init(outfit, this);
				outfitSelectors.Add(outfitSelector);
			}
		}

		public void GenerateTextureSelection()
		{
			foreach (TexturePackage texture in textures)
			{
				Transform parent = null;
				if (texture.type == TextureType.Decal)
				{
					parent = decalContainer;
				}
				if (texture.type == TextureType.Pattern)
				{
					parent = patternContainer;
				}
				TextureSelector textureSelector = UnityEngine.Object.Instantiate(textureSelectorObject, parent);
				textureSelector.Init(texture, this);
				textureSelectors.Add(textureSelector);
			}
		}

		public void GetBodyBlends()
		{
			for (int i = 0; i < blendSliders.Count; i++)
			{
				UnityEngine.Object.Destroy(blendSliders[i].gameObject);
			}
			blendSliders.Clear();
			foreach (string shape in character.GetShapes())
			{
				BlendSlider blendSlider = UnityEngine.Object.Instantiate(blendSliderObject, bodyShapeContainer);
				blendSlider.Init(character, shape);
				blendSliders.Add(blendSlider);
			}
		}

		public void GetFaceBlends()
		{
			for (int i = 0; i < faceBlendSliders.Count; i++)
			{
				UnityEngine.Object.Destroy(faceBlendSliders[i].gameObject);
			}
			faceBlendSliders.Clear();
			foreach (string faceShape in character.GetFaceShapes())
			{
				BlendSlider blendSlider = UnityEngine.Object.Instantiate(blendSliderObject, faceShapeContainer);
				blendSlider.Init(character, faceShape);
				faceBlendSliders.Add(blendSlider);
			}
		}

		public void GetBodyMods()
		{
			List<BodyShapeModifier> list = character.GetMods().Values.ToList();
			for (int i = 0; i < ModSliders.Count; i++)
			{
				UnityEngine.Object.Destroy(ModSliders[i].gameObject);
			}
			ModSliders.Clear();
			Transform transform = bodyShapeContainer;
			foreach (BodyShapeModifier item in list)
			{
				BodyShapeSliders bodyShapeSliders = UnityEngine.Object.Instantiate(parent: (!(item.sorting == "Head")) ? bodyModContainer : faceModContainer, original: modSliderObject);
				bodyShapeSliders.Init(character, item);
				ModSliders.Add(bodyShapeSliders);
			}
		}

		public void UpdateCharacterSaves()
		{
			SaveSelector[] array = saveSlots.Values.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				UnityEngine.Object.Destroy(array[i].gameObject);
			}
			saveSlots.Clear();
			if (!Directory.Exists(BMAC_SaveSystem.filePath))
			{
				Directory.CreateDirectory(BMAC_SaveSystem.filePath);
				Directory.CreateDirectory(BMAC_SaveSystem.iconFilePath);
				MonoBehaviour.print("Created Save JSON save Location At: " + BMAC_SaveSystem.filePath);
			}
			string[] files = Directory.GetFiles(BMAC_SaveSystem.filePath, "*.json");
			string[] files2 = Directory.GetFiles(BMAC_SaveSystem.iconFilePath, "*.png");
			for (int j = 0; j < files.Length; j++)
			{
				CharacterData characterData = JsonUtility.FromJson<CharacterData>(File.ReadAllText(files[j]));
				byte[] data = File.ReadAllBytes(files2[j]);
				Texture2D texture2D = new Texture2D(2, 2);
				Sprite icon = null;
				if (texture2D.LoadImage(data))
				{
					icon = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
				}
				SaveSelector saveSelector = UnityEngine.Object.Instantiate(this.saveSelector, saveContainer);
				saveSelector.Init(characterData, icon, this);
				saveSlots.Add(characterData.characterName, saveSelector);
			}
			CharacterObject[] array2 = Resources.LoadAll<CharacterObject>("");
			foreach (CharacterObject characterObject in array2)
			{
				if (!saveSlots.ContainsKey(characterObject.data.characterName))
				{
					SaveSelector saveSelector2 = UnityEngine.Object.Instantiate(this.saveSelector, saveContainer);
					Sprite icon2 = null;
					if (characterObject.icon != null)
					{
						icon2 = Sprite.Create(characterObject.icon, new Rect(0f, 0f, characterObject.icon.width, characterObject.icon.height), new Vector2(0.5f, 0.5f));
					}
					saveSelector2.Init(characterObject.data, icon2, this);
					saveSlots.Add(characterObject.data.characterName, saveSelector2);
				}
			}
		}

		public void OpenPage(GameObject page)
		{
			currentPage.SetActive(value: false);
			previousPage = currentPage;
			currentPage = page;
			currentPage.SetActive(value: true);
		}

		public void BackPage()
		{
			currentPage.SetActive(value: false);
			currentPage = previousPage;
			currentPage.SetActive(value: true);
			colorPickerControl.RemoveObject();
		}

		public void SetOutfit(Outfit outfit)
		{
			Outfit colorPickerObject = UnityEngine.Object.Instantiate(outfit, character.transform);
			SetColorPickerObject(colorPickerObject);
			SwitchTextureCatagory(outfit.TextureCatagory);
			type = outfit.Type;
		}

		public void OnOutfitUpdate(Outfit outfit)
		{
			visibilityToggler.Set(outfit);
			if (!(outfit == null))
			{
				if (outfit.Type.name == "Head")
				{
					GetFaceBlends();
				}
				if (outfit.Type.name == "Body")
				{
					GetBodyBlends();
				}
			}
		}

		public void OnRigUpdate(SkinnedMeshRenderer rig)
		{
			GetBodyMods();
		}

		public void SetOutfitDecal(Texture texture, Color[] colors = null)
		{
			if ((bool)colorPickerControl.colorObject)
			{
				colorPickerControl.colorObject.SetDecal(texture);
			}
		}

		public void SetOutfitPattern(Texture texture, Color[] colors = null)
		{
			if ((bool)colorPickerControl.colorObject)
			{
				colorPickerControl.colorObject.SetPattern(texture);
			}
		}

		public void RemoveOutfit()
		{
			if (!(type == null))
			{
				character.RemoveOutfit(type, destory: true);
				colorPickerControl.RemoveObject();
			}
		}

		public void RemoveOutfitDecal()
		{
			if ((bool)colorPickerControl.colorObject)
			{
				colorPickerControl.colorObject.SetDecal(null);
			}
		}

		public void RemoveOutfitPattern()
		{
			if ((bool)colorPickerControl.colorObject)
			{
				colorPickerControl.colorObject.SetPattern(null);
			}
		}

		public void SwitchCatagory(string catagory)
		{
			foreach (OutfitSelector outfitSelector in outfitSelectors)
			{
				outfitSelector.SetVisable(catagory);
			}
			Outfit outfit = character.GetOutfit(catagory);
			SetColorPickerObject(outfit);
			visibilityToggler.Set(outfit);
			if (!(outfit == null))
			{
				SwitchTextureCatagory(outfit.TextureCatagory);
				type = outfit.Type;
			}
		}

		public void SwitchTextureCatagory(string catagory)
		{
			if (catagory == "")
			{
				catagory = "Outfit";
			}
			foreach (TextureSelector textureSelector in textureSelectors)
			{
				textureSelector.SetVisable(catagory);
			}
		}

		public void SetColorPickerObject(string type)
		{
			Outfit outfit = character.GetOutfit(type);
			colorPickerControl.ChangeObject(outfit);
		}

		public void SetColorPickerObject(Outfit outfit)
		{
			colorPickerControl.ChangeObject(outfit);
		}

		public void ReplaceCharacter(OutfitSystem character)
		{
			UnityEngine.Object.Destroy(this.character.gameObject);
			this.character = character;
			Spinner.SetCharacter(character.transform);
		}

		public void GetCurrentCatagory()
		{
			if (!(type == null))
			{
				SwitchCatagory(type.name);
			}
		}

		public void CopyColor(string copyTo)
		{
			Outfit outfit = character.GetOutfit((OutfitType)Enum.Parse(typeof(OutfitType), copyTo));
			colorPickerControl.CopyColor(outfit);
		}

		public void ToggleWalk(bool value)
		{
			character.animator.SetBool("isWalk", value);
		}

		public void SaveCharacter()
		{
			StartCoroutine(Save());
		}

		public Outfit GetOutfit(string outfitName)
		{
			return OutfitDataBase[outfitName];
		}

		[ContextMenu("Save")]
		private IEnumerator Save()
		{
			yield return new WaitForEndOfFrame();
			if (CharacterName.text.Length == 0)
			{
				Debug.LogWarning("Please enter in a name with at least one letter");
				yield break;
			}
			RenderTexture.active = iconTexture;
			Texture2D texture2D = new Texture2D(iconTexture.width, iconTexture.height, TextureFormat.RGBA32, mipChain: false);
			Rect source = new Rect(new Rect(0f, 0f, iconTexture.width, iconTexture.height));
			texture2D.ReadPixels(source, 0, 0);
			texture2D.Apply();
			byte[] bytes = texture2D.EncodeToPNG();
			Texture2D icon = null;
			if (!Directory.Exists(BMAC_SaveSystem.iconFilePath))
			{
				Directory.CreateDirectory(BMAC_SaveSystem.iconFilePath);
			}
			File.WriteAllBytes(BMAC_SaveSystem.iconFilePath + "/" + CharacterName.text + ".png", bytes);
			BMAC_SaveSystem.SaveCharacter(character, CharacterName.text, icon);
			UpdateCharacterSaves();
		}

		public void LoadCharacter(CharacterData data)
		{
			loadedCharacterNameText.text = data.characterName;
			BMAC_SaveSystem.LoadCharacter(character, data);
		}

		public void DeleteCharacter()
		{
			if (!(loadedCharacterNameText.text == ""))
			{
				DeleteCharacterNameText.text = "Delete: " + loadedCharacterNameText.text;
				DeleteConfirmWindow.SetActive(value: true);
			}
		}

		public void ConfirmDelete()
		{
			BMAC_SaveSystem.DeleteCharacter(loadedCharacterNameText.text);
			loadedCharacterNameText.text = "";
			UpdateCharacterSaves();
		}
	}
}
