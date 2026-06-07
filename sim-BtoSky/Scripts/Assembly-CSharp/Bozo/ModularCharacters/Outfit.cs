using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;

namespace Bozo.ModularCharacters
{
	public class Outfit : OutfitBase
	{
		[SerializeField]
		private bool AttachInEditMode;

		private OutfitSystem system;

		public string OutfitName;

		public Sprite OutfitIcon;

		public string[] ColorChannels = new string[1] { "Base" };

		public string TextureCatagory;

		public bool supportDecals;

		public bool supportPatterns;

		public bool showCharacterCreator = true;

		[SerializeField]
		public OutfitType Type;

		public string AttachPoint;

		public Color[] defaultColors;

		public string[] tags;

		public GameObject[] optionalPieces;

		public Transform[] additionalBones;

		private Dictionary<string, int> tagShapes = new Dictionary<string, int>();

		private Dictionary<string, int> shapes = new Dictionary<string, int>();

		public LinkedColorSets[] LinkedColorSets;

		public OutfitType[] IncompatibleSets;

		public OutfitType[] HideTypes;

		public int currentSwatch;

		public List<OutfitSwatch> outfitSwatches = new List<OutfitSwatch>();

		public Transform[] originalBones;

		public Transform originalRootBone;

		public Transform editorAttachPoint;

		public bool Initalized { get; set; }

		public SkinnedMeshRenderer skinnedRenderer { get; private set; }

		public SkinnedMeshRenderer[] skinnedRenderers { get; private set; }

		public Renderer outfitRenderer { get; private set; }

		private void OnValidate()
		{
			if (Application.isPlaying && base.gameObject.scene.isLoaded)
			{
				if (system == null)
				{
					system = GetComponentInParent<OutfitSystem>();
				}
				SetColorInital();
			}
		}

		private void Awake()
		{
			skinnedRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
			if ((bool)skinnedRenderer)
			{
				material = skinnedRenderer.material;
			}
			skinnedRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
			outfitRenderer = GetComponentInChildren<Renderer>();
			SkinnedMeshRenderer[] array = skinnedRenderers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].sharedMaterial = material;
			}
			InitSetUpShapes();
		}

		private void OnEnable()
		{
			Attach();
		}

		private void OnDisable()
		{
			if ((bool)system)
			{
				OutfitSystem outfitSystem = system;
				outfitSystem.OnOutfitChanged = (UnityAction<Outfit>)Delegate.Remove(outfitSystem.OnOutfitChanged, new UnityAction<Outfit>(OnOutfitUpdate));
				OutfitSystem outfitSystem2 = system;
				outfitSystem2.OnShapeChanged = (UnityAction<string, float>)Delegate.Remove(outfitSystem2.OnShapeChanged, new UnityAction<string, float>(SetShape));
				system.RemoveOutfit(this, destory: false);
			}
		}

		private void OnDestroy()
		{
			if ((bool)system)
			{
				OutfitSystem outfitSystem = system;
				outfitSystem.OnOutfitChanged = (UnityAction<Outfit>)Delegate.Remove(outfitSystem.OnOutfitChanged, new UnityAction<Outfit>(OnOutfitUpdate));
			}
		}

		private void Start()
		{
			if (Application.isPlaying && base.gameObject.scene.isLoaded && !Initalized)
			{
				Attach();
			}
			SetColorInital();
		}

		public void Attach(Transform parent)
		{
			base.transform.parent = parent;
			Attach();
		}

		public void Attach(OutfitSystem system)
		{
			base.transform.parent = system.transform;
			Attach();
		}

		public void Attach()
		{
			system = GetComponentInParent<OutfitSystem>();
			skinnedRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
			outfitRenderer = GetComponentInChildren<Renderer>();
			if (system == null || !system.initalized)
			{
				return;
			}
			RemoveIncompatible();
			CheckTags();
			CopySystemShapes();
			OutfitSystem outfitSystem = system;
			outfitSystem.OnOutfitChanged = (UnityAction<Outfit>)Delegate.Combine(outfitSystem.OnOutfitChanged, new UnityAction<Outfit>(OnOutfitUpdate));
			OutfitSystem outfitSystem2 = system;
			outfitSystem2.OnShapeChanged = (UnityAction<string, float>)Delegate.Combine(outfitSystem2.OnShapeChanged, new UnityAction<string, float>(SetShape));
			if (Initalized)
			{
				system.ReattachOutfit(this);
				return;
			}
			IOutfitExtension[] componentsInChildren = GetComponentsInChildren<IOutfitExtension>();
			IOutfitExtension[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Initalize(system, this);
			}
			if (originalBones.Length != 0 && (bool)skinnedRenderer)
			{
				skinnedRenderer.bones = originalBones;
				skinnedRenderer.rootBone = originalRootBone;
			}
			system.AttachOutfit(this);
			array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Execute(system, this);
			}
		}

		public void ReturnBones()
		{
			Transform[] array = additionalBones;
			foreach (Transform transform in array)
			{
				if (!(transform == null))
				{
					transform.parent = base.transform;
				}
			}
		}

		private void OnOutfitUpdate(Outfit newOutfit)
		{
			if (!RemoveIfIncompatible(newOutfit))
			{
				CheckTags();
			}
		}

		private void CheckTags()
		{
			List<string> list = new List<string>(tagShapes.Keys);
			SkinnedMeshRenderer[] array = skinnedRenderers;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
			{
				for (int j = 0; j < list.Count; j++)
				{
					if (system.ContainsTag(list[j]))
					{
						skinnedMeshRenderer.SetBlendShapeWeight(tagShapes[list[j]], 100f);
					}
					else
					{
						skinnedMeshRenderer.SetBlendShapeWeight(tagShapes[list[j]], 0f);
					}
				}
			}
		}

		private void CopySystemShapes()
		{
			if (!system)
			{
				return;
			}
			string[] array = shapes.Keys.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				float shape = system.GetShape(array[i]);
				if (shape != -10000f)
				{
					SetShape(array[i], shape);
				}
			}
		}

		private void InitSetUpShapes()
		{
			if (!skinnedRenderer)
			{
				return;
			}
			Mesh sharedMesh = skinnedRenderer.sharedMesh;
			int blendShapeCount = skinnedRenderer.sharedMesh.blendShapeCount;
			for (int i = 0; i < blendShapeCount; i++)
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
					if (array[0] == "Tag")
					{
						tagShapes.Add(array[1], i);
					}
					if (array[0] == "Shape")
					{
						shapes.Add(array[1], i);
					}
				}
			}
		}

		public void SetShape(string key, float value)
		{
			if (value <= -10000f || !skinnedRenderer)
			{
				return;
			}
			string[] array = key.Split(".");
			if (array.Length > 1)
			{
				key = array[1];
			}
			if (!shapes.TryGetValue(key, out var value2))
			{
				return;
			}
			SkinnedMeshRenderer[] array2 = skinnedRenderers;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array2)
			{
				if (skinnedMeshRenderer.sharedMesh.blendShapeCount > value2)
				{
					skinnedMeshRenderer.SetBlendShapeWeight(value2, value);
				}
			}
		}

		private void RemoveIncompatible()
		{
			OutfitType[] incompatibleSets = IncompatibleSets;
			foreach (OutfitType type in incompatibleSets)
			{
				system.RemoveOutfit(type, destory: true);
			}
		}

		private bool RemoveIfIncompatible(Outfit outfit)
		{
			if (outfit == null)
			{
				return false;
			}
			OutfitType[] incompatibleSets = IncompatibleSets;
			foreach (OutfitType outfitType in incompatibleSets)
			{
				if (outfit.Type == outfitType)
				{
					system.RemoveOutfit(this, destory: true);
					return true;
				}
			}
			return false;
		}

		private void SetColorInital()
		{
			if ((bool)outfitRenderer)
			{
				Material material = outfitRenderer.material;
				for (int i = 0; i < defaultColors.Length; i++)
				{
					material.SetColor("_Color_" + (1 + i), defaultColors[i]);
				}
			}
		}

		public override void SetColor(Color color, int index, bool linkedChanged = false)
		{
			if (system == null)
			{
				system = GetComponentInParent<OutfitSystem>();
			}
			if (outfitRenderer == null)
			{
				outfitRenderer = GetComponentInChildren<Renderer>();
			}
			if (customShader)
			{
				SetColor(color);
			}
			else
			{
				outfitRenderer.material.SetColor("_Color_" + index, color);
			}
			LinkedColorSets[] linkedColorSets = LinkedColorSets;
			foreach (LinkedColorSets linkedColorSets2 in linkedColorSets)
			{
				if (!linkedChanged)
				{
					Outfit outfit = system.GetOutfit(linkedColorSets2.linkedType);
					if (!(outfit == null) && index <= linkedColorSets2.linkedChannelRange)
					{
						outfit.SetColor(color, index, linkedChanged: true);
					}
				}
			}
		}

		public override void SetSwatch(int swatchIndex, bool linkedChanged = false)
		{
			if (!customShader)
			{
				return;
			}
			if (!material)
			{
				material = GetComponentInChildren<Renderer>().material;
			}
			if (swatchIndex + 1 > outfitSwatches.Count)
			{
				return;
			}
			Texture mainTexture = Resources.Load<Texture>(outfitSwatches[swatchIndex].swatchID);
			material.mainTexture = mainTexture;
			currentSwatch = swatchIndex;
			LinkedColorSets[] linkedColorSets = LinkedColorSets;
			foreach (LinkedColorSets linkedColorSets2 in linkedColorSets)
			{
				if (!linkedChanged)
				{
					Outfit outfit = system.GetOutfit(linkedColorSets2.linkedType);
					if (!(outfit == null))
					{
						outfit.SetSwatch(swatchIndex, true);
					}
				}
			}
		}

		public OutfitData GetOutfitData()
		{
			OutfitData outfitData = new OutfitData();
			string text = Type.name + "/" + base.name;
			text = text.Replace("(Clone)", "");
			outfitData.outfit = text;
			if (customShader)
			{
				outfitData.color = GetColor(1);
				outfitData.swatch = currentSwatch;
			}
			else
			{
				outfitData.colors = GetColors();
				Texture decal = GetDecal();
				if (decal != null)
				{
					outfitData.decal = "Decal/" + decal.name;
					outfitData.decalColors = GetDecalColors();
					outfitData.decalScale = GetDecalSize();
				}
				else
				{
					outfitData.decal = "";
				}
				Texture pattern = GetPattern();
				if (pattern != null)
				{
					outfitData.pattern = "Pattern/" + pattern.name;
					outfitData.patternColors = GetPatternColors();
					outfitData.patternScale = GetPatternSize();
				}
				else
				{
					outfitData.pattern = "";
				}
			}
			bool[] array = new bool[optionalPieces.Length];
			for (int i = 0; i < optionalPieces.Length; i++)
			{
				if (!(optionalPieces[i] == null))
				{
					array[i] = optionalPieces[i].activeSelf;
				}
			}
			outfitData.partVisibility = array;
			return outfitData;
		}

		private void InitCloth()
		{
		}

		public void ActivateCloth(Dictionary<string, Transform> boneMap)
		{
		}

		[ContextMenu("QuickName")]
		private void QuickName()
		{
			int num = base.name.IndexOf('_');
			string outfitName = Regex.Replace((num >= 0) ? base.name.Substring(num + 1) : base.name, "(?<!^)([A-Z])", " $1");
			OutfitName = outfitName;
		}
	}
}
