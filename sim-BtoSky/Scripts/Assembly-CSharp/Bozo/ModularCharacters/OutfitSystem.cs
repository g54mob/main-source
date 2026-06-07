using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Bozo.ModularCharacters
{
	public class OutfitSystem : MonoBehaviour
	{
		public enum LoadMode
		{
			OnStartAndOnValidate = 0,
			OnStart = 1,
			Manual = 2
		}

		public DataObject characterData;

		private DataObject _characterData;

		public string SaveID;

		[SerializeField]
		private SkinnedMeshRenderer CharacterBody;

		private Animator _animator;

		private Bounds CharacterRenderBounds;

		public Dictionary<string, Transform> boneMap = new Dictionary<string, Transform>();

		public Dictionary<OutfitType, Outfit> Outfits = new Dictionary<OutfitType, Outfit>();

		public Dictionary<string, OutfitType> KnownOutfitTypes = new Dictionary<string, OutfitType>();

		public Dictionary<OutfitType, List<Outfit>> hiddenTypes = new Dictionary<OutfitType, List<Outfit>>();

		private Dictionary<string, int> bodyShapes = new Dictionary<string, int>();

		private Dictionary<string, int> faceShapes = new Dictionary<string, int>();

		private Dictionary<string, int> tagShapes = new Dictionary<string, int>();

		public Dictionary<string, BodyShapeModifier> bodyModifiers = new Dictionary<string, BodyShapeModifier>();

		private List<string> tags = new List<string>();

		public UnityAction<Outfit> OnOutfitChanged;

		public UnityAction<SkinnedMeshRenderer> OnRigChanged;

		public UnityAction<string, float> OnShapeChanged;

		public UnityAction<List<string>> OnTagsChanged;

		public string prefabName;

		public Material mergeMaterial;

		public bool mergedMode;

		public bool mergeOnAwake;

		public bool autoUpdate;

		public bool mergeBase;

		public CharacterData data;

		private Dictionary<string, OutfitData> outfitData = new Dictionary<string, OutfitData>();

		public Dictionary<string, Texture2D> customMaps = new Dictionary<string, Texture2D>();

		public MergedMaterialData[] materialData;

		public LoadMode loadMode;

		public bool async;

		public bool muteHeightChange { get; private set; }

		public float height { get; private set; }

		public float heeledHeight { get; private set; }

		public Animator animator
		{
			get
			{
				if (_animator == null)
				{
					_animator = GetComponentInParent<Animator>();
					if (_animator == null)
					{
						_animator = GetComponentInChildren<Animator>();
					}
				}
				return _animator;
			}
			private set
			{
				_animator = value;
			}
		}

		public float stance { get; private set; }

		public bool initalized { get; private set; }

		public bool isDirty { get; private set; }

		private void OnValidate()
		{
			if (Application.isPlaying && base.gameObject.scene.isLoaded && loadMode == LoadMode.OnStartAndOnValidate)
			{
				Invoke("LoadFromObject", 0f);
			}
		}

		private void Awake()
		{
			Init();
			if (mergeOnAwake)
			{
				mergedMode = true;
			}
		}

		private void Start()
		{
			InitClothColliders();
			if (loadMode == LoadMode.OnStart || loadMode == LoadMode.OnStartAndOnValidate)
			{
				LoadFromObject();
			}
		}

		public void Init()
		{
			if (initalized)
			{
				return;
			}
			if (CharacterBody == null)
			{
				Debug.LogWarning("Outfit System does not have a Rig assigned please assign one to prevent this warning", base.gameObject);
				Debug.LogWarning("Attempting auto rig assignment...");
				SkinnedMeshRenderer[] componentsInChildren = GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
				{
					if (skinnedMeshRenderer.name == "BMAC_Body")
					{
						CharacterBody = skinnedMeshRenderer;
						Debug.Log("Rig Found Successfully!");
						break;
					}
				}
				Debug.LogError("Search Failed. Please Assign Mannually", base.gameObject);
			}
			else
			{
				CharacterRenderBounds = CharacterBody.localBounds;
				InitBoneMap();
				InitBodyShapes();
				InitBodyMods();
				initalized = true;
			}
		}

		private void InitBoneMap()
		{
			boneMap.Clear();
			Transform[] bones = CharacterBody.bones;
			foreach (Transform transform in bones)
			{
				if (!boneMap.ContainsKey(transform.name))
				{
					boneMap.Add(transform.name, transform);
				}
			}
		}

		private void InitBodyShapes()
		{
			Outfit outfit = GetOutfit("Body");
			bodyShapes.Clear();
			tagShapes.Clear();
			int num = 0;
			Mesh sharedMesh;
			if (outfit != null)
			{
				sharedMesh = outfit.skinnedRenderer.sharedMesh;
				num = outfit.skinnedRenderer.sharedMesh.blendShapeCount;
			}
			else
			{
				sharedMesh = CharacterBody.sharedMesh;
				num = CharacterBody.sharedMesh.blendShapeCount;
			}
			for (int i = 0; i < num; i++)
			{
				sharedMesh.GetBlendShapeName(i);
				string text = sharedMesh.GetBlendShapeName(i);
				string[] array = text.Split(".");
				if (array.Length > 1)
				{
					text = array[1];
				}
				array = text.Split("_");
				if (array.Length > 1)
				{
					if (array[0] == "Shape")
					{
						bodyShapes.Add(array[1], i);
					}
					if (array[0] == "Tag")
					{
						tagShapes.Add(array[1], i);
					}
				}
			}
		}

		private void InitBodyMods()
		{
			List<BodyShapeModifier> list = new List<BodyShapeModifier>(GetComponentsInChildren<BodyShapeModifier>());
			bodyModifiers.Clear();
			for (int i = 0; i < list.Count; i++)
			{
				bodyModifiers.Add(list[i].name, list[i]);
			}
		}

		private void InitFaceShapes()
		{
			Outfit outfit = GetOutfit("Head");
			faceShapes.Clear();
			Mesh mesh = ((!(outfit != null)) ? CharacterBody.sharedMesh : outfit.skinnedRenderer.sharedMesh);
			int blendShapeCount = mesh.blendShapeCount;
			for (int i = 0; i < blendShapeCount; i++)
			{
				mesh.GetBlendShapeName(i);
				string text = mesh.GetBlendShapeName(i);
				string[] array = text.Split(".");
				if (array.Length > 1)
				{
					text = array[1];
				}
				array = text.Split("_");
				if (array.Length > 1 && array[0] == "Shape")
				{
					faceShapes.Add(array[1], i);
				}
			}
		}

		private void InitClothColliders()
		{
		}

		public void LoadFromObject(DataObject saveData)
		{
			characterData = saveData;
			LoadFromObject();
		}

		[ContextMenu("Load")]
		public void LoadFromObject()
		{
			if ((bool)characterData && _characterData != characterData)
			{
				SaveID = characterData.name;
				if (mergedMode)
				{
					data = characterData.GetCharacterData();
					isDirty = true;
					MergeCharacter();
				}
				else
				{
					_characterData = characterData;
					LoadCharacter(characterData.GetCharacterData());
				}
			}
		}

		[ContextMenu("LoadByID")]
		public void LoadFromID()
		{
			LoadFromID(SaveID);
		}

		public void LoadFromID(string saveName)
		{
			if (!string.IsNullOrEmpty(saveName))
			{
				SaveID = saveName;
				CharacterData dataFromID = BMAC_SaveSystem.GetDataFromID(SaveID);
				if (dataFromID != null)
				{
					LoadCharacter(dataFromID);
				}
			}
		}

		private async void LoadCharacter(CharacterData data)
		{
			if (mergedMode)
			{
				this.data = data;
				isDirty = true;
				MergeCharacter();
			}
			else
			{
				await BMAC_SaveSystem.LoadCharacter(this, data, manualShapeApply: false, async);
			}
		}

		[ContextMenu("SaveToObject")]
		public void SaveToObject()
		{
			if (!characterData)
			{
				Debug.LogWarning("Character Data Field is empty. Please provide a BSMC_CharacterObject to " + base.transform.name);
			}
			else
			{
				BMAC_SaveSystem.SaveCharacter(this, characterData.GetCharacterData().characterName, characterData.GetCharacterIcon());
			}
		}

		[ContextMenu("SaveByID")]
		public void SaveByID()
		{
			SaveByID(SaveID);
		}

		public void SaveByID(string characterName)
		{
			if (string.IsNullOrEmpty(characterName))
			{
				Debug.LogWarning("No ID provided saving aborted");
				return;
			}
			if (!File.Exists(BMAC_SaveSystem.iconFilePath + "/" + characterName + ".png"))
			{
				byte[] bytes = new Texture2D(2, 2, TextureFormat.RGBA32, mipChain: false).EncodeToPNG();
				File.WriteAllBytes(BMAC_SaveSystem.iconFilePath + "/" + characterName + ".png", bytes);
			}
			BMAC_SaveSystem.SaveCharacter(this, characterName);
		}

		public void RemoveOutfit(Outfit outfit, bool destory)
		{
			if (Outfits.TryGetValue(outfit.Type, out var value) && destory && value != null)
			{
				value.ReturnBones();
				Object.Destroy(value.gameObject);
				Outfits[outfit.Type] = null;
			}
			RemoveHide(outfit);
			RemoveTags(outfit.tags);
			OnOutfitChanged?.Invoke(null);
		}

		public void RemoveOutfit(OutfitType type, bool destory)
		{
			if (Outfits.TryGetValue(type, out var value) && destory && value != null)
			{
				value.ReturnBones();
				Object.Destroy(value.gameObject);
				Outfits[type] = null;
			}
			if ((bool)value)
			{
				RemoveHide(value);
				RemoveTags(value.tags);
			}
			OnOutfitChanged?.Invoke(null);
		}

		public void RemoveTags(string[] outfitTags)
		{
			foreach (string item in outfitTags)
			{
				tags.Remove(item);
			}
			OnTagsChanged?.Invoke(tags);
		}

		public void RemoveAllOutfits()
		{
			foreach (Outfit item in new List<Outfit>(Outfits.Values))
			{
				if (!(item == null))
				{
					Object.Destroy(item.gameObject);
				}
			}
			Outfits.Clear();
			tags.Clear();
			hiddenTypes.Clear();
			OnOutfitChanged?.Invoke(null);
		}

		public Outfit InstantiateOutfit(Outfit outfit)
		{
			Outfit outfit2 = Object.Instantiate(outfit, base.transform);
			outfit2.name = outfit2.name.Replace("(Clone)", "");
			return outfit2;
		}

		public void AttachSkinnedOutfit(Outfit outfit)
		{
			AttachOutfit(outfit);
		}

		public void ReattachOutfit(Outfit outfit)
		{
			OnOutfitChanged?.Invoke(outfit);
			AddTags(outfit.tags);
			SetHide(outfit);
			ApplyTags();
			OnOutfitChanged?.Invoke(outfit);
		}

		public void AttachOutfit(Outfit outfit)
		{
			if (!initalized)
			{
				return;
			}
			if (mergedMode)
			{
				outfitData[outfit.Type.name] = outfit.GetOutfitData();
				data.outfitDatas = outfitData.Values.ToList();
				isDirty = true;
				Object.Destroy(outfit.gameObject);
				if (autoUpdate)
				{
					MergeCharacter();
				}
				return;
			}
			if (!KnownOutfitTypes.ContainsKey(outfit.Type.name))
			{
				KnownOutfitTypes.Add(outfit.Type.name, outfit.Type);
			}
			ReplaceOutfit(outfit);
			MergeBones(outfit);
			if ((bool)outfit.skinnedRenderer)
			{
				UpdateCharacterBounds(outfit);
			}
			ApplyShapesToOufit(outfit);
			if (outfit.Type.name == "Head")
			{
				InitFaceShapes();
			}
			if (outfit.Type.name == "Body")
			{
				InitBodyShapes();
			}
			SetHide(outfit);
			AddTags(outfit.tags);
			ApplyTags();
			if (hiddenTypes.ContainsKey(outfit.Type))
			{
				outfit.gameObject.SetActive(value: false);
			}
			OnOutfitChanged?.Invoke(outfit);
		}

		private void ApplyShapesToOufit(Outfit outfit)
		{
			List<string> list = new List<string>(bodyShapes.Keys);
			for (int i = 0; i < list.Count; i++)
			{
				GetBodyShapeValues();
				outfit.SetShape(list[i], GetShape(list[i]));
			}
		}

		public void SetShape(string key, float value)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = null;
			int index = -1;
			Outfit outfit = GetOutfit("Body");
			Outfit outfit2 = GetOutfit("Head");
			int value3;
			int value4;
			if (bodyShapes.TryGetValue(key, out var value2) && (bool)outfit)
			{
				index = value2;
				if (outfit != null)
				{
					skinnedMeshRenderer = outfit.skinnedRenderer;
				}
			}
			else if (faceShapes.TryGetValue(key, out value3) && (bool)outfit2)
			{
				index = value3;
				if (outfit2 != null)
				{
					skinnedMeshRenderer = outfit2.skinnedRenderer;
				}
			}
			else if (bodyShapes.TryGetValue(key, out value4))
			{
				index = value4;
				skinnedMeshRenderer = CharacterBody;
			}
			if (skinnedMeshRenderer != null)
			{
				skinnedMeshRenderer.SetBlendShapeWeight(index, value);
			}
			OnShapeChanged?.Invoke(key, value);
		}

		public void AddTags(string[] tags)
		{
			this.tags.AddRange(tags);
			OnTagsChanged?.Invoke(this.tags);
		}

		public void SetHide(Outfit outfit)
		{
			if (outfit == null)
			{
				return;
			}
			OutfitType[] hideTypes = outfit.HideTypes;
			foreach (OutfitType outfitType in hideTypes)
			{
				if (hiddenTypes.ContainsKey(outfitType))
				{
					hiddenTypes[outfitType].Add(outfit);
				}
				else
				{
					hiddenTypes.Add(outfitType, new List<Outfit>());
					hiddenTypes[outfitType].Add(outfit);
				}
				Outfit outfit2 = GetOutfit(outfitType);
				if ((bool)outfit2)
				{
					outfit2.gameObject.SetActive(value: false);
				}
			}
		}

		public void RemoveHide(Outfit outfit)
		{
			if (outfit == null)
			{
				return;
			}
			OutfitType[] hideTypes = outfit.HideTypes;
			foreach (OutfitType outfitType in hideTypes)
			{
				if (!hiddenTypes.ContainsKey(outfitType))
				{
					continue;
				}
				hiddenTypes[outfitType].Remove(outfit);
				if (hiddenTypes[outfitType].Count == 0)
				{
					hiddenTypes.Remove(outfitType);
					Outfit outfit2 = GetOutfit(outfitType);
					if ((bool)outfit2)
					{
						outfit2.gameObject.SetActive(value: true);
					}
				}
			}
		}

		private void ApplyTags()
		{
			if (GetOutfit("Body") != null)
			{
				return;
			}
			List<string> list = new List<string>(tagShapes.Keys);
			if (!CharacterBody || CharacterBody.sharedMesh.blendShapeCount == 0)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (ContainsTag(list[i]))
				{
					CharacterBody.SetBlendShapeWeight(tagShapes[list[i]], 100f);
				}
				else
				{
					CharacterBody.SetBlendShapeWeight(tagShapes[list[i]], 0f);
				}
			}
		}

		public void SetStance(float value)
		{
			AnimatorControllerParameter[] parameters = animator.parameters;
			for (int i = 0; i < parameters.Length; i++)
			{
				if (parameters[i].name == "Stance")
				{
					animator.SetFloat("Stance", value);
				}
			}
			stance = value;
		}

		public void SetHeight(float value)
		{
			bool flag = false;
			AnimatorControllerParameter[] parameters = animator.parameters;
			for (int i = 0; i < parameters.Length; i++)
			{
				if (parameters[i].name == "HeelHeight")
				{
					flag = true;
				}
			}
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y - height, base.transform.localPosition.z);
			height = value;
			if (flag)
			{
				heeledHeight = animator.GetFloat("HeelHeight");
			}
			if (!muteHeightChange)
			{
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y + value, base.transform.localPosition.z);
				if (flag)
				{
					animator.SetFloat("HeelHeight", 0f);
				}
			}
		}

		public void MuteHeightChange(bool value)
		{
			if (value != muteHeightChange)
			{
				AnimatorControllerParameter[] parameters = animator.parameters;
				for (int i = 0; i < parameters.Length; i++)
				{
					_ = parameters[i];
					animator.SetFloat("HeelHeight", heeledHeight);
				}
				muteHeightChange = value;
				float num = height;
				if (muteHeightChange)
				{
					num = 0f - num;
				}
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y + num, base.transform.localPosition.z);
			}
		}

		private void ReplaceOutfit(Outfit outfit)
		{
			if (Outfits.TryGetValue(outfit.Type, out var value))
			{
				if ((bool)Outfits[outfit.Type])
				{
					if (outfit.transform != Outfits[outfit.Type].transform)
					{
						value.ReturnBones();
						Object.Destroy(value.gameObject);
					}
					else
					{
						OnOutfitChanged?.Invoke(outfit);
					}
				}
				Outfits[outfit.Type] = outfit;
			}
			else
			{
				Outfits.Add(outfit.Type, outfit);
			}
		}

		private void MergeBones(Outfit outfit)
		{
			if (outfit.additionalBones.Length != 0)
			{
				for (int i = 0; i < outfit.additionalBones.Length; i++)
				{
					Transform transform = outfit.additionalBones[i];
					Transform transform2 = GetBones()[transform.parent.name];
					transform.parent.SetPositionAndRotation(transform2.position, transform2.rotation);
					transform.parent = transform2;
					Transform[] componentsInChildren = transform.GetComponentsInChildren<Transform>(includeInactive: true);
					foreach (Transform transform3 in componentsInChildren)
					{
						if (boneMap.ContainsKey(transform.name))
						{
							boneMap[transform3.name] = transform3;
						}
						else
						{
							boneMap.Add(transform3.name, transform3);
						}
					}
				}
			}
			SkinnedMeshRenderer[] skinnedRenderers = outfit.skinnedRenderers;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinnedRenderers)
			{
				if (outfit.AttachPoint == "" && (bool)skinnedMeshRenderer)
				{
					if (outfit.Initalized)
					{
						continue;
					}
					Transform[] array = skinnedMeshRenderer.bones.ToArray();
					Transform[] array2 = new Transform[skinnedMeshRenderer.bones.Length];
					for (int k = 0; k < array.Length; k++)
					{
						Transform transform4 = array[k];
						boneMap.TryGetValue(transform4.name, out var value);
						if (transform4 == value)
						{
							array2[k] = value;
						}
						else
						{
							array2[k] = value;
						}
					}
					skinnedMeshRenderer.bones = array2;
					skinnedMeshRenderer.rootBone = CharacterBody.rootBone;
					continue;
				}
				Transform transform5 = null;
				try
				{
					transform5 = boneMap[outfit.AttachPoint];
				}
				catch
				{
					Debug.LogError(base.name + " is missing " + outfit.AttachPoint + " that " + outfit.name + " requires");
					return;
				}
				outfit.transform.parent = transform5.transform;
				outfit.transform.position = transform5.position;
				outfit.transform.rotation = transform5.rotation;
				outfit.transform.localScale = Vector3.one;
			}
			outfit.ActivateCloth(boneMap);
			outfit.Initalized = true;
			if ((bool)outfit.outfitRenderer && outfit.AttachPoint != "")
			{
				Transform transform6 = null;
				try
				{
					transform6 = boneMap[outfit.AttachPoint];
				}
				catch
				{
					Debug.LogError(base.name + " is missing " + outfit.AttachPoint + " that " + outfit.name + " requires");
					return;
				}
				outfit.transform.parent = transform6.transform;
				outfit.transform.position = transform6.position;
				outfit.transform.rotation = transform6.rotation;
				outfit.transform.localScale = Vector3.one;
			}
		}

		public void UpdateCharacterBounds(Outfit outfit)
		{
			foreach (Outfit value in Outfits.Values)
			{
				if (value == null)
				{
					continue;
				}
				SkinnedMeshRenderer[] skinnedRenderers = value.skinnedRenderers;
				foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinnedRenderers)
				{
					if (skinnedMeshRenderer != null)
					{
						skinnedMeshRenderer.localBounds = CharacterRenderBounds;
					}
				}
			}
		}

		public bool ContainsTag(string tag)
		{
			return tags.Contains(tag);
		}

		public Outfit GetOutfit(OutfitType outfitType)
		{
			if (Outfits.TryGetValue(outfitType, out var value))
			{
				return value;
			}
			return null;
		}

		public Outfit GetOutfit(string outfitType)
		{
			if (KnownOutfitTypes.TryGetValue(outfitType, out var value) && Outfits.TryGetValue(value, out var value2))
			{
				return value2;
			}
			return null;
		}

		public List<Outfit> GetOutfits()
		{
			return new List<Outfit>(Outfits.Values);
		}

		public List<string> GetShapes()
		{
			return bodyShapes.Keys.ToList();
		}

		public List<string> GetFaceShapes()
		{
			return faceShapes.Keys.ToList();
		}

		public float GetShape(string key)
		{
			if (bodyShapes.TryGetValue(key, out var value))
			{
				Outfit outfit = GetOutfit("Body");
				if (outfit != null)
				{
					return outfit.skinnedRenderer.GetBlendShapeWeight(value);
				}
				return -10000f;
			}
			return -10000f;
		}

		public Dictionary<string, BodyShapeModifier> GetMods()
		{
			return bodyModifiers;
		}

		public Dictionary<string, Transform> GetBones()
		{
			return boneMap;
		}

		public float GetShapeValue(string key)
		{
			float result = -1f;
			Outfit outfit = GetOutfit("Body");
			if (outfit == null)
			{
				return -1f;
			}
			int value2;
			if (bodyShapes.TryGetValue(key, out var value))
			{
				result = outfit.skinnedRenderer.GetBlendShapeWeight(value);
			}
			else if (faceShapes.TryGetValue(key, out value2))
			{
				Outfit outfit2 = GetOutfit("Head");
				if (outfit2 == null)
				{
					return -1f;
				}
				result = outfit2.skinnedRenderer.GetBlendShapeWeight(value2);
			}
			return result;
		}

		public float GetShapeValue(int key)
		{
			Outfit outfit = GetOutfit("Body");
			SkinnedMeshRenderer skinnedMeshRenderer = ((!(outfit == null)) ? outfit.skinnedRenderer : CharacterBody);
			return skinnedMeshRenderer.GetBlendShapeWeight(key);
		}

		public Dictionary<string, float> GetBodyShapeValues()
		{
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			int[] array = bodyShapes.Values.ToArray();
			string[] array2 = bodyShapes.Keys.ToArray();
			Outfit outfit = GetOutfit("Body");
			SkinnedMeshRenderer skinnedMeshRenderer = ((!(outfit == null)) ? outfit.skinnedRenderer : CharacterBody);
			for (int i = 0; i < array.Length; i++)
			{
				float blendShapeWeight = skinnedMeshRenderer.GetBlendShapeWeight(array[i]);
				dictionary.Add(array2[i], blendShapeWeight);
			}
			return dictionary;
		}

		public Dictionary<string, float> GetFaceShapeValues()
		{
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			int[] array = faceShapes.Values.ToArray();
			string[] array2 = faceShapes.Keys.ToArray();
			Outfit outfit = GetOutfit("Head");
			SkinnedMeshRenderer skinnedMeshRenderer = ((!(outfit == null)) ? outfit.skinnedRenderer : CharacterBody);
			for (int i = 0; i < array.Length; i++)
			{
				float blendShapeWeight = skinnedMeshRenderer.GetBlendShapeWeight(array[i]);
				dictionary.Add(array2[i], blendShapeWeight);
			}
			return dictionary;
		}

		public SkinnedMeshRenderer GetCharacterBody()
		{
			return CharacterBody;
		}

		public void SetCharacterBody(GameObject newBody)
		{
			SkinnedMeshRenderer componentInChildren = newBody.GetComponentInChildren<SkinnedMeshRenderer>();
			if (!(componentInChildren == null))
			{
				RemoveAllOutfits();
				Object.DestroyImmediate(CharacterBody.transform.parent.gameObject);
				newBody.transform.parent = base.transform;
				newBody.transform.localPosition = Vector3.zero;
				newBody.transform.localRotation = Quaternion.identity;
				newBody.transform.localScale = Vector3.one;
				CharacterBody = componentInChildren;
				InitBoneMap();
				InitBodyShapes();
				InitBodyMods();
				InitClothColliders();
				OnRigChanged?.Invoke(CharacterBody);
				Invoke("RebindBody", 0f);
			}
		}

		public void RebindBody()
		{
			animator.Rebind();
			AnimatorControllerParameter[] parameters = animator.parameters;
			foreach (AnimatorControllerParameter obj in parameters)
			{
				if (obj.name == "HeelHeight")
				{
					animator.SetFloat("HeelHeight", heeledHeight);
				}
				if (obj.name == "Stance")
				{
					animator.SetFloat("Stance", stance);
				}
			}
		}

		[ContextMenu("Merge")]
		public void MergeCharacter()
		{
			if (Application.isPlaying && base.gameObject.scene.isLoaded)
			{
				BoZo_CharacterOptimizer boZo_CharacterOptimizer = new BoZo_CharacterOptimizer();
				if (mergedMode && isDirty)
				{
					boZo_CharacterOptimizer.OptimizeCharacter(this, data);
					return;
				}
				CharacterData characterData = (data = BMAC_SaveSystem.GetCharacterData(this));
				foreach (Outfit outfit in GetOutfits())
				{
					if ((bool)outfit)
					{
						OutfitData outfitData = (this.outfitData[outfit.Type.name] = outfit.GetOutfitData());
					}
				}
				boZo_CharacterOptimizer.OptimizeCharacter(this, characterData);
				mergedMode = true;
			}
			else
			{
				Debug.LogWarning("For stability reason Character Merging is only available in Play Mode");
			}
		}

		[ContextMenu("SaveToPrefab")]
		public void SaveCharacterToPrefab()
		{
		}
	}
}
