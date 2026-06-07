using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ActorBodyItem : MonoBehaviour
{
	[Serializable]
	public class ColorMapping
	{
		public string ColorName;

		public string MaterialSlot;

		public string LogicalCategory;

		[ActorGradient]
		public string Mapping;

		public ColorMapping(string colorName, string materialSlot, string mapping)
		{
			ColorName = colorName;
			MaterialSlot = materialSlot;
			Mapping = mapping;
		}

		public ColorMapping(string colorName, string materialSlot, string mapping, string logicalCategory)
			: this(colorName, materialSlot, mapping)
		{
			LogicalCategory = logicalCategory;
		}

		public override string ToString()
		{
			return ColorName + ": " + Mapping + " -> " + MaterialSlot;
		}
	}

	[Serializable]
	public class BlendTransform
	{
		public string BlendKey;

		public Vector3 TranslateFrom = Vector3.zero;

		public float ScaleFrom = 1f;

		public Vector3 TranslateTo = Vector3.zero;

		public float ScaleTo = 1f;

		public bool Double;

		public bool Reversed;

		public BlendTransform(string blendKey, Vector3 translateFrom, float scaleFrom, Vector3 translateTo, float scaleTo, bool reversed)
		{
			BlendKey = blendKey;
			TranslateFrom = translateFrom;
			ScaleFrom = scaleFrom;
			TranslateTo = translateTo;
			ScaleTo = scaleTo;
			Double = true;
			Reversed = reversed;
		}

		public BlendTransform(string blendKey, Vector3 translateTo, float scaleTo, bool reversed)
		{
			BlendKey = blendKey;
			TranslateTo = translateTo;
			ScaleTo = scaleTo;
			Double = false;
			Reversed = reversed;
		}

		public BlendTransform(BlendTransform input, Matrix4x4 transform)
		{
			BlendKey = input.BlendKey;
			TranslateTo = transform.MultiplyPoint(input.TranslateTo);
			ScaleTo = input.ScaleTo;
			Double = input.Double;
			Reversed = input.Reversed;
			if (Double)
			{
				TranslateFrom = transform.MultiplyPoint(input.TranslateFrom);
				ScaleFrom = input.ScaleFrom;
			}
		}
	}

	[Serializable]
	public class BlendKeys
	{
		public enum MorphType
		{
			Linear = 0,
			Gauss = 1,
			InverseGauss = 2
		}

		public string BlendName;

		public string GroupName;

		public int Index;

		public int Index2;

		public int LODIndex1 = -1;

		public int LODIndex2 = -1;

		public MorphType RandomType;

		public float GaussMean = 0.5f;

		public float GaussSpread = 0.2f;

		public float Extreme = 2f;

		public bool doubleKey;

		public bool hide;

		public bool Reverse;

		public bool AutoSpread = true;

		public Sprite Thumbnail;

		public float GetRandomValue(System.Random rng = null)
		{
			rng = rng ?? Utilities.RNG;
			switch (RandomType)
			{
			case MorphType.Linear:
				return rng.NextFloat();
			case MorphType.Gauss:
				return Utilities.RandomGaussClamped(GaussMean, AutoSpread ? Mathf.Abs(GaussMean - 0.5f).MapRange(0f, 0.5f, 0.1f, 0.3f) : GaussSpread, rng);
			case MorphType.InverseGauss:
			{
				float num = Utilities.RandomGaussClamped(0.5f, 0.2f, rng) + 0.5f;
				if (num > 1f)
				{
					num -= 1f;
				}
				return num;
			}
			default:
				return 0f;
			}
		}

		public float GetBlendValue(SkinnedMeshRenderer ms)
		{
			if (doubleKey)
			{
				if (Reverse)
				{
					return ms.GetBlendShapeWeight(Index) - ms.GetBlendShapeWeight(Index2);
				}
				return ms.GetBlendShapeWeight(Index2) - ms.GetBlendShapeWeight(Index);
			}
			if (!Reverse)
			{
				return ms.GetBlendShapeWeight(Index);
			}
			return 100f - ms.GetBlendShapeWeight(Index);
		}

		public float GetBlendValueNormalized(SkinnedMeshRenderer ms)
		{
			float num = ((!doubleKey) ? (ms.GetBlendShapeWeight(Index) / 100f) : ((ms.GetBlendShapeWeight(Index2) - ms.GetBlendShapeWeight(Index) + 100f) / 200f));
			if (!Reverse)
			{
				return num;
			}
			return 1f - num;
		}

		public void SetBlendValue(float val, SkinnedMeshRenderer skin, Renderer lod)
		{
			SetActualBlendValue(val, skin, Index, Index2, Reverse, doubleKey);
			SkinnedMeshRenderer skin2;
			if (lod != null && (object)(skin2 = lod as SkinnedMeshRenderer) != null && LODIndex1 > -1)
			{
				SetActualBlendValue(val, skin2, LODIndex1, LODIndex2, Reverse, LODIndex2 > -1);
			}
		}

		private static void SetActualBlendValue(float val, SkinnedMeshRenderer skin, int index1, int index2, bool reverse, bool doubleKey)
		{
			if (doubleKey)
			{
				int num = index1;
				int num2 = index2;
				if (reverse)
				{
					int num3 = num;
					num = num2;
					num2 = num3;
				}
				if (val < 0f)
				{
					skin.SetBlendShapeWeight(num, 0f - val);
					skin.SetBlendShapeWeight(num2, 0f);
				}
				else
				{
					skin.SetBlendShapeWeight(num, 0f);
					skin.SetBlendShapeWeight(num2, val);
				}
			}
			else
			{
				skin.SetBlendShapeWeight(index1, reverse ? (100f - val) : val);
			}
		}

		public override string ToString()
		{
			return GroupName + ": " + BlendName;
		}
	}

	[Serializable]
	public class TriangleBlendHolder
	{
		public List<TriangleBlend> Blends = new List<TriangleBlend>();
	}

	[Serializable]
	public class TriangleBlend
	{
		public string BlendName;

		public Vector3 Direction;

		public TriangleBlend(string blendName, Vector3 direction)
		{
			BlendName = blendName;
			Direction = direction;
		}
	}

	[Serializable]
	public class BodyItemObject
	{
		public string Key;

		public int SkinToneIndex;

		public int PatternIndex;

		public bool Mirrored;

		public Dictionary<string, SVector3> Colors;

		public Dictionary<string, float> Blends;

		public XMLParser.XMLNode Serialize()
		{
			XMLParser.XMLNode xMLNode = new XMLParser.XMLNode("Colors");
			XMLParser.XMLNode xMLNode2 = new XMLParser.XMLNode("Blends");
			XMLParser.XMLNode xMLNode3 = new XMLParser.XMLNode(Key.Replace(" ", "_"), xMLNode, xMLNode2);
			if (SkinToneIndex > 0)
			{
				xMLNode3.Children.Add(new XMLParser.XMLNode("SkinToneIndex", SkinToneIndex.ToString()));
			}
			if (PatternIndex > 0)
			{
				xMLNode3.Children.Add(new XMLParser.XMLNode("PatternIndex", PatternIndex.ToString()));
			}
			foreach (KeyValuePair<string, SVector3> color in Colors)
			{
				xMLNode.Children.Add(new XMLParser.XMLNode(color.Key.Replace(" ", "_"), ColorUtility.ToHtmlStringRGB(color.Value)));
			}
			foreach (KeyValuePair<string, float> blend in Blends)
			{
				xMLNode2.Children.Add(new XMLParser.XMLNode(blend.Key.Replace(" ", "_"), blend.Value.ToString("N")));
			}
			if (Mirrored)
			{
				xMLNode3.Attributes["Mirrored"] = "true";
			}
			return xMLNode3;
		}

		public BodyItemObject(XMLParser.XMLNode node)
		{
			Key = node.Name.Replace("_", " ");
			Colors = new Dictionary<string, SVector3>();
			SkinToneIndex = node.GetNodeValue("SkinToneIndex", 0);
			PatternIndex = node.GetNodeValue("PatternIndex", 0);
			List<XMLParser.XMLNode> children = node.GetNode("Colors").Children;
			for (int i = 0; i < children.Count; i++)
			{
				XMLParser.XMLNode xMLNode = children[i];
				Color color2;
				Color color = (ColorUtility.TryParseHtmlString("#" + xMLNode.Value, out color2) ? color2 : Color.white);
				Colors[xMLNode.Name.Replace("_", " ")] = color;
			}
			Blends = new Dictionary<string, float>();
			XMLParser.XMLNode node2 = node.GetNode("Blends");
			for (int j = 0; j < node2.Children.Count; j++)
			{
				XMLParser.XMLNode xMLNode2 = node2.Children[j];
				Blends[xMLNode2.Name.Replace("_", " ")] = xMLNode2.Value.ConvertToFloatDef(0f);
			}
			Mirrored = node.Attributes.ContainsKey("Mirrored");
		}

		public BodyItemObject(BodyItemObject item)
		{
			Key = item.Key;
			Colors = new Dictionary<string, SVector3>(item.Colors);
			SkinToneIndex = item.SkinToneIndex;
			Blends = new Dictionary<string, float>(item.Blends);
			PatternIndex = item.PatternIndex;
			Mirrored = item.Mirrored;
		}

		public BodyItemObject(ActorBodyItem item)
		{
			Key = item.Key;
			Colors = new Dictionary<string, SVector3>();
			SkinToneIndex = item.SkinToneIndex;
			PatternIndex = item.PatternIndex;
			for (int i = 0; i < item.Colormap.Length; i++)
			{
				ColorMapping colorMapping = item.Colormap[i];
				Color colorFromSlot = item.GetColorFromSlot(colorMapping.MaterialSlot);
				Colors[colorMapping.ColorName] = colorFromSlot;
			}
			Blends = new Dictionary<string, float>();
			if (item.Blends != null && item.Blends.Length != 0)
			{
				SkinnedMeshRenderer component = item.rend.GetComponent<SkinnedMeshRenderer>();
				for (int j = 0; j < item.Blends.Length; j++)
				{
					BlendKeys blendKeys = item.Blends[j];
					if (!blendKeys.hide)
					{
						Blends[blendKeys.BlendName] = blendKeys.GetBlendValue(component);
					}
				}
			}
			Mirrored = item.Mirror;
		}

		public BodyItemObject(ActorBodyItem item, Dictionary<string, Color> colors, Dictionary<string, float> blends, int skinToneIndex, int patternIndex, bool mirrored)
		{
			Key = item.Key;
			Colors = new Dictionary<string, SVector3>();
			SkinToneIndex = skinToneIndex;
			PatternIndex = patternIndex;
			Mirrored = mirrored;
			foreach (KeyValuePair<string, Color> color in colors)
			{
				Colors[color.Key] = color.Value;
			}
			Blends = new Dictionary<string, float>();
			if (item.Blends == null)
			{
				return;
			}
			for (int i = 0; i < item.Blends.Length; i++)
			{
				BlendKeys blendKeys = item.Blends[i];
				if (!blendKeys.hide)
				{
					float value;
					if (blends != null && blends.TryGetValue(blendKeys.BlendName, out value))
					{
						Blends[blendKeys.BlendName] = value;
						continue;
					}
					float randomValue = blendKeys.GetRandomValue();
					Blends[blendKeys.BlendName] = (blendKeys.doubleKey ? (randomValue * 2f - 1f) : randomValue) * 100f;
				}
			}
		}

		public BodyItemObject()
		{
		}

		public override string ToString()
		{
			return Key;
		}
	}

	public enum BodyType
	{
		Legs = 0,
		Torso = 1,
		Accessory = 2,
		Head = 3,
		Eyebrows = 4,
		Hair = 5
	}

	public enum GenderType
	{
		Male = 0,
		Female = 1,
		Both = 2
	}

	public enum GUICategory
	{
		NA = 0,
		Hair = 1,
		Face = 2,
		Torso = 3,
		Legs = 4,
		Accessory = 5
	}

	public bool Hidden;

	public bool KeepLocalPosition;

	public bool RotationFix = true;

	public bool DontOverride;

	public bool GPUInstanced;

	public string Name;

	public string LocName;

	public string Category;

	public string PrettyColorName;

	public string[] LOD2Part;

	public string[] LOD2ColorKey;

	public bool SelfLOD1;

	public GameObject LOD1;

	[NonSerialized]
	public GameObject LOD1Instance;

	[NonSerialized]
	public Renderer LOD1Renderer;

	public bool UsesSkinColor;

	public bool CanDeselect;

	public BodyType Type;

	public GenderType Gender;

	public GUICategory guiCategory;

	public Sprite Thumbnail;

	public Texture2D FaceTexture;

	public Texture2D BeardMakeupTexture;

	public Texture2D WeightMapTexture;

	public bool IsFaceTexture;

	public bool IsFaceMap;

	public bool IsFaceUV;

	public float UVOffset;

	public ColorMapping[] Colormap;

	public BlendKeys[] Blends;

	public BlendTransform[] BlendsTransforms = new BlendTransform[0];

	public bool IsRigged;

	[NonSerialized]
	public bool Mirror;

	public string RootBone;

	public Renderer rend;

	public Renderer[] ExtraRends = new Renderer[0];

	private GameObject[] Children;

	public bool AllowHoliday = true;

	public bool AllowBed = true;

	public bool CanUsePattern;

	public bool ColorExtraRends;

	public bool CreateMirrorVersion;

	[ActorPattern]
	public string[] PatternGroups;

	public int PatternIndex;

	[NonSerialized]
	private bool _hasBeenDestroyed;

	[NonSerialized]
	public bool RunDestruction = true;

	[NonSerialized]
	private Vector3 _imprintPos;

	[NonSerialized]
	private Vector3 _imprintScale;

	[NonSerialized]
	private Vector3 _imprintRotation;

	private static List<Vector3> _transformCache = new List<Vector3>();

	public int SkinToneIndex { get; private set; }

	public string Key
	{
		get
		{
			return string.Concat(Type, Name);
		}
	}

	public void SetPattern(int pattern)
	{
		PatternIndex = pattern;
		Renderer renderer = GetRend();
		Renderer lODRend = GetLODRend();
		Vector4 value = ActorGenerator.Instance.PatternToUV(PatternIndex);
		if (GPUInstanced)
		{
			if (renderer != null)
			{
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				renderer.GetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.SetVector("_Pattern", value);
				renderer.SetPropertyBlock(materialPropertyBlock);
				if (lODRend != null)
				{
					lODRend.SetPropertyBlock(materialPropertyBlock);
				}
			}
		}
		else
		{
			if ((object)renderer != null)
			{
				renderer.material.SetVector("_Pattern", value);
			}
			if (lODRend != null)
			{
				lODRend.material.SetVector("_Pattern", value);
			}
		}
	}

	public void SetSkinTone(int tone)
	{
		SkinToneIndex = tone;
		Renderer renderer = GetRend();
		Renderer lODRend = GetLODRend();
		if (GPUInstanced)
		{
			if (!(renderer != null))
			{
				return;
			}
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			renderer.GetPropertyBlock(materialPropertyBlock);
			materialPropertyBlock.SetInt("_SkinTone", tone);
			renderer.SetPropertyBlock(materialPropertyBlock);
			if (ColorExtraRends)
			{
				for (int i = 0; i < ExtraRends.Length; i++)
				{
					ExtraRends[i].SetPropertyBlock(materialPropertyBlock);
				}
			}
			if (lODRend != null)
			{
				lODRend.SetPropertyBlock(materialPropertyBlock);
			}
			return;
		}
		if ((object)renderer != null)
		{
			renderer.material.SetInt("_SkinTone", tone);
		}
		if (ColorExtraRends)
		{
			for (int j = 0; j < ExtraRends.Length; j++)
			{
				ExtraRends[j].material.SetInt("_SkinTone", tone);
			}
		}
		if (lODRend != null)
		{
			lODRend.material.SetInt("_SkinTone", tone);
		}
	}

	public string GetColorName()
	{
		switch (Type)
		{
		case BodyType.Legs:
			return "Legs";
		case BodyType.Torso:
			return "Torso";
		case BodyType.Accessory:
			return PrettyColorName;
		case BodyType.Head:
			if (Gender != GenderType.Female)
			{
				return "Facial hair";
			}
			return "Makeup";
		case BodyType.Eyebrows:
			return "Eyebrows";
		case BodyType.Hair:
			return "Hair";
		default:
			return "N/A";
		}
	}

	private void Awake()
	{
		Transform[] componentsInChildren = GetComponentsInChildren<Transform>(true);
		Children = new GameObject[componentsInChildren.Length];
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Children[i] = componentsInChildren[i].gameObject;
		}
		if (BeardMakeupTexture != null)
		{
			rend.material.SetTexture("_OverlayTex2", BeardMakeupTexture);
		}
	}

	public Color GetColor(string cName)
	{
		return GetColorFromSlot(Colormap.First((ColorMapping x) => x.ColorName.Equals(cName)).MaterialSlot);
	}

	public Color GetColorFromSlot(string slotName)
	{
		Renderer renderer = GetRend();
		if (GPUInstanced)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			renderer.GetPropertyBlock(materialPropertyBlock);
			return materialPropertyBlock.GetColor(slotName);
		}
		return renderer.material.GetColor(slotName);
	}

	public ColorMapping GetMapFromColor(string cName)
	{
		return Colormap.FirstOrDefault((ColorMapping x) => x.ColorName.Equals(cName));
	}

	public BlendKeys GetBlendKey(string name)
	{
		return Blends.FirstOrDefault((BlendKeys x) => x.BlendName.Equals(name));
	}

	public float GetBlendValue(string name)
	{
		SkinnedMeshRenderer ms;
		if ((object)(ms = rend as SkinnedMeshRenderer) != null)
		{
			BlendKeys blendKey = GetBlendKey(name);
			if (blendKey != null)
			{
				return blendKey.GetBlendValue(ms);
			}
		}
		return 0f;
	}

	public float GetBlendValueNormalized(string name)
	{
		SkinnedMeshRenderer ms;
		if ((object)(ms = rend as SkinnedMeshRenderer) != null)
		{
			BlendKeys blendKey = GetBlendKey(name);
			if (blendKey != null)
			{
				return blendKey.GetBlendValueNormalized(ms);
			}
		}
		return 0f;
	}

	public void SetColor(string cName, Color color)
	{
		ColorMapping mapFromColor = GetMapFromColor(cName);
		if (mapFromColor != null)
		{
			SetMaterialColor(mapFromColor.MaterialSlot, color);
		}
	}

	public bool InitLOD2(out GameObject l)
	{
		l = null;
		if (LOD1 != null)
		{
			l = UnityEngine.Object.Instantiate(LOD1);
			Transform[] componentsInChildren = l.GetComponentsInChildren<Transform>(true);
			GameObject[] children = Children;
			Children = new GameObject[children.Length + componentsInChildren.Length];
			for (int i = 0; i < children.Length; i++)
			{
				Children[i] = children[i];
			}
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				Children[children.Length + j] = componentsInChildren[j].gameObject;
			}
			LOD1Instance = l;
			LOD1Renderer = l.GetComponentInChildren<Renderer>();
			LOD1Renderer.sharedMaterial = rend.sharedMaterial;
			if (BeardMakeupTexture != null)
			{
				LOD1Renderer.material.SetTexture("_OverlayTex2", BeardMakeupTexture);
			}
			return true;
		}
		return false;
	}

	public void SetColorDirect(string matChannelName, Color color)
	{
		SetMaterialColor(matChannelName, color);
	}

	public void OnDestroy()
	{
		if (!RunDestruction)
		{
			return;
		}
		if (!_hasBeenDestroyed)
		{
			_hasBeenDestroyed = true;
			for (int i = 0; i < Children.Length; i++)
			{
				GameObject gameObject = Children[i];
				if (gameObject != null)
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
			RemoveEffects();
		}
		if (LOD1Instance != null)
		{
			UnityEngine.Object.Destroy(LOD1Instance);
			LOD1Instance = null;
		}
	}

	public void RemoveEffects()
	{
		if (IsFaceTexture)
		{
			ActorBodyItem head = GetHead();
			if (head != null && head.rend != null && head.rend.material.GetTexture("_OverlayTex2") == FaceTexture)
			{
				head.rend.material.SetTexture("_OverlayTex2", null);
				head.LOD1Renderer.material.SetTexture("_OverlayTex2", null);
			}
		}
		if (!IsFaceMap)
		{
			return;
		}
		if (IsFaceUV)
		{
			ActorBodyItem head2 = GetHead();
			if (head2 != null && head2.rend != null && head2.rend.sharedMaterial.GetFloat("_EOffset") == UVOffset)
			{
				head2.rend.material.SetFloat("_EOffset", 0f);
				if (head2.LOD1Renderer != null)
				{
					head2.LOD1Renderer.material.SetFloat("_EOffset", 0f);
				}
			}
		}
		else
		{
			SetColor(Colormap[0].ColorName, Color.clear);
		}
	}

	private ActorBodyItem GetHead()
	{
		Transform parent = base.transform.parent;
		if (parent != null)
		{
			IStylable component = parent.GetComponent<IStylable>();
			if (component != null)
			{
				return component.BodyItems.FirstOrDefault((ActorBodyItem x) => x.gameObject.activeSelf && x.Type == BodyType.Head);
			}
		}
		return null;
	}

	public BodyItemObject Save()
	{
		return new BodyItemObject(this);
	}

	public BodyItemObject Save(Dictionary<string, Color> colors, Dictionary<string, float> blends, int skinToneIndex, int patternIndex, bool mirrored)
	{
		return new BodyItemObject(this, colors, blends, skinToneIndex, patternIndex, mirrored);
	}

	public void InitRandomColors(string style, Dictionary<string, Color> prev, Color skinColor)
	{
		for (int i = 0; i < Colormap.Length; i++)
		{
			ColorMapping map = Colormap[i];
			Color value;
			if (prev != null && prev.TryGetValue(map.Mapping, out value))
			{
				SetMaterialColor(map.MaterialSlot, value);
				continue;
			}
			ActorGenerator.RandomGradient randomGradient = ActorGenerator.Instance.Gradients.FirstOrDefault((ActorGenerator.RandomGradient x) => map.Mapping.Equals(x.Key));
			if (randomGradient != null)
			{
				SetMaterialColor(map.MaterialSlot, randomGradient.Evaluate(Utilities.RandomValue, style, skinColor));
			}
		}
	}

	private Renderer GetRend()
	{
		if (IsFaceMap)
		{
			ActorBodyItem head = GetHead();
			if ((object)head == null)
			{
				return null;
			}
			return head.rend;
		}
		return rend;
	}

	private Renderer GetLODRend()
	{
		if (IsFaceMap)
		{
			ActorBodyItem head = GetHead();
			if ((object)head == null)
			{
				return null;
			}
			return head.LOD1Renderer;
		}
		return LOD1Renderer;
	}

	private void SetMaterialColor(string property, Color c)
	{
		Renderer renderer = GetRend();
		Renderer lODRend = GetLODRend();
		if (GPUInstanced)
		{
			if (!(renderer != null))
			{
				return;
			}
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			renderer.GetPropertyBlock(materialPropertyBlock);
			materialPropertyBlock.SetColor(property, c);
			renderer.SetPropertyBlock(materialPropertyBlock);
			if (ColorExtraRends)
			{
				for (int i = 0; i < ExtraRends.Length; i++)
				{
					ExtraRends[i].SetPropertyBlock(materialPropertyBlock);
				}
			}
			if (lODRend != null)
			{
				lODRend.SetPropertyBlock(materialPropertyBlock);
			}
			return;
		}
		if ((object)renderer != null)
		{
			renderer.material.SetColor(property, c);
		}
		if (ColorExtraRends)
		{
			for (int j = 0; j < ExtraRends.Length; j++)
			{
				ExtraRends[j].material.SetColor(property, c);
			}
		}
		if (lODRend != null)
		{
			lODRend.material.SetColor(property, c);
		}
	}

	public void Load(BodyItemObject item, string style, Dictionary<string, Color> prev)
	{
		for (int i = 0; i < Colormap.Length; i++)
		{
			ColorMapping map = Colormap[i];
			SVector3 value;
			Color value2;
			if (item.Colors.TryGetValue(map.ColorName, out value))
			{
				SetMaterialColor(map.MaterialSlot, value);
			}
			else if (prev != null && prev.TryGetValue(map.Mapping, out value2))
			{
				SetMaterialColor(map.MaterialSlot, value2);
			}
			else if (style != null)
			{
				ActorGenerator.RandomGradient randomGradient = ActorGenerator.Instance.Gradients.FirstOrDefault((ActorGenerator.RandomGradient x) => map.Mapping.Equals(x.Key));
				if (randomGradient != null)
				{
					SetMaterialColor(map.MaterialSlot, randomGradient.Evaluate(Utilities.RandomValue, style, Color.white));
				}
			}
		}
		if (Blends != null && Blends.Length != 0)
		{
			SkinnedMeshRenderer component = rend.GetComponent<SkinnedMeshRenderer>();
			foreach (KeyValuePair<string, float> blend in item.Blends)
			{
				BlendKeys blendKeys = Blends.FirstOrDefault((BlendKeys x) => x.BlendName.Equals(blend.Key));
				if (blendKeys != null)
				{
					blendKeys.SetBlendValue(blend.Value, component, LOD1Renderer);
				}
				else
				{
					Debug.Log("Missing blend: " + blend.Key + " for " + base.name);
				}
			}
		}
		if (CanUsePattern)
		{
			SetPattern(item.PatternIndex);
		}
		if (!IsFaceMap)
		{
			SetSkinTone(item.SkinToneIndex);
		}
	}

	public void LoadBlendTransforms(Dictionary<string, float> blends)
	{
		if (blends == null)
		{
			return;
		}
		ResetPos();
		if (BlendsTransforms.Length == 0)
		{
			return;
		}
		BlendTransform[] blendsTransforms = BlendsTransforms;
		foreach (BlendTransform blendTransform in blendsTransforms)
		{
			float value;
			if (!blends.TryGetValue(blendTransform.BlendKey, out value))
			{
				continue;
			}
			float num = value / 100f;
			Vector3 vector;
			float b;
			if (blendTransform.Double && value < 0f)
			{
				num = 0f - num;
				vector = blendTransform.TranslateFrom;
				b = blendTransform.ScaleFrom;
				if (blendTransform.Reversed)
				{
					num = 0f - num;
				}
			}
			else
			{
				vector = blendTransform.TranslateTo;
				b = blendTransform.ScaleTo;
				if (blendTransform.Reversed)
				{
					num = 1f - num;
				}
			}
			Vector3 vector2 = vector * num;
			if (Mirror)
			{
				vector2 = new Vector3(vector2.x, vector2.y, 0f - vector2.z);
			}
			base.transform.localPosition = base.transform.localPosition + vector2;
			base.transform.localScale = base.transform.localScale * Mathf.Lerp(1f, b, num);
		}
	}

	public void ImprintPosition()
	{
		_imprintPos = base.transform.localPosition;
		_imprintScale = base.transform.localScale;
		_imprintRotation = base.transform.localRotation.eulerAngles;
	}

	public void ResetPos()
	{
		base.transform.localPosition = _imprintPos;
		base.transform.localScale = _imprintScale;
		base.transform.localRotation = Quaternion.Euler(_imprintRotation);
	}

	public void ApplyMirror()
	{
		base.transform.localScale = new Vector3(0f - base.transform.localScale.x, base.transform.localScale.y, base.transform.localScale.z);
		_transformCache.Clear();
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Transform child = base.transform.GetChild(i);
			_transformCache.Add(child.position);
			_transformCache.Add(child.rotation.eulerAngles);
		}
		base.transform.localScale = new Vector3(0f - base.transform.localScale.x, base.transform.localScale.y, base.transform.localScale.z);
		for (int j = 0; j < base.transform.childCount; j++)
		{
			Transform child2 = base.transform.GetChild(j);
			child2.position = _transformCache[j * 2];
			child2.rotation = Quaternion.Euler(_transformCache[j * 2 + 1]);
		}
	}

	public void SetBlendValue(string key, float value)
	{
		BlendKeys blendKeys = Blends.FirstOrDefault((BlendKeys x) => x.BlendName.Equals(key));
		if (blendKeys != null)
		{
			SkinnedMeshRenderer component = rend.GetComponent<SkinnedMeshRenderer>();
			blendKeys.SetBlendValue(value, component, LOD1Renderer);
		}
	}

	public bool Match(ActorBodyItem other)
	{
		if (!DontOverride && !other.DontOverride && other.Gender == Gender)
		{
			if (Type == BodyType.Accessory || Type != other.Type)
			{
				if (Type == BodyType.Accessory)
				{
					return Category.Equals(other.Category);
				}
				return false;
			}
			return true;
		}
		return false;
	}

	private string FixName(string name)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < name.Length; i++)
		{
			if (i > 0 && char.IsUpper(name[i]))
			{
				stringBuilder.Append(' ');
				stringBuilder.Append(char.ToLower(name[i]));
			}
			else
			{
				stringBuilder.Append(name[i]);
			}
		}
		return stringBuilder.ToString();
	}

	private string UnFixName(string name)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		for (int i = 0; i < name.Length; i++)
		{
			if (name[i] == ' ')
			{
				flag = true;
				continue;
			}
			stringBuilder.Append(flag ? char.ToUpper(name[i]) : name[i]);
			flag = false;
		}
		return stringBuilder.ToString();
	}

	[ContextMenu("Update BlendShapes")]
	public void InitBlendShapes()
	{
		SkinnedMeshRenderer skinnedMeshRenderer = rend as SkinnedMeshRenderer;
		if (!(skinnedMeshRenderer != null))
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		Mesh sharedMesh = skinnedMeshRenderer.sharedMesh;
		Dictionary<string, BlendKeys> dictionary = new Dictionary<string, BlendKeys>();
		List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
		for (int i = 0; i < sharedMesh.blendShapeCount; i++)
		{
			string[] array = sharedMesh.GetBlendShapeName(i).Split('|');
			if (array[0].Last() == '2')
			{
				string key = FixName(array[0].Substring(0, array[0].Length - 1));
				BlendKeys value;
				if (dictionary.TryGetValue(key, out value))
				{
					value.doubleKey = true;
					value.Index2 = i;
				}
				else
				{
					list.Add(new KeyValuePair<string, int>(key, i));
				}
			}
			else
			{
				string text = FixName(array[0]);
				dictionary[text] = new BlendKeys
				{
					BlendName = text,
					doubleKey = false,
					GroupName = ((array.Length > 1) ? array[1] : ""),
					hide = (array.Length > 1 && array[1].Equals("Expressions")),
					Index = i
				};
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			KeyValuePair<string, int> keyValuePair = list[j];
			BlendKeys value2;
			if (dictionary.TryGetValue(keyValuePair.Key, out value2))
			{
				value2.doubleKey = true;
				value2.Index2 = keyValuePair.Value;
			}
			else
			{
				stringBuilder.AppendLine(("Could not find double key: " + keyValuePair.Key).FontColor(Color.red));
			}
		}
		Dictionary<string, BlendKeys> dictionary2 = Blends.ToDictionary((BlendKeys x) => x.BlendName, (BlendKeys x) => x);
		for (int num = 0; num < Blends.Length; num++)
		{
			string blendName = Blends[num].BlendName;
			if (!dictionary.ContainsKey(blendName))
			{
				dictionary2.Remove(blendName);
				stringBuilder.AppendLine("Removed: " + blendName);
			}
		}
		foreach (KeyValuePair<string, BlendKeys> item in dictionary)
		{
			BlendKeys value3;
			if (dictionary2.TryGetValue(item.Key, out value3))
			{
				bool flag = value3.GroupName.Equals(item.Value.GroupName);
				if (!flag)
				{
					value3.GroupName = item.Value.GroupName;
				}
				if (value3.doubleKey != item.Value.doubleKey)
				{
					value3.doubleKey = item.Value.doubleKey;
					value3.Index = item.Value.Index;
					value3.Index2 = item.Value.Index2;
					stringBuilder.AppendLine(("Double key changed for: " + item.Key).FontColor(Color.cyan));
				}
				else if (!flag)
				{
					stringBuilder.AppendLine(("Group name changed for: " + item.Key).FontColor(Color.cyan));
				}
				else
				{
					stringBuilder.AppendLine("Nothing has changed for: " + item.Key);
				}
			}
			else
			{
				dictionary2[item.Key] = item.Value;
				stringBuilder.AppendLine(("Added: " + item.Key).FontColor(Color.green));
			}
		}
		Blends = dictionary2.Values.ToArray();
		Debug.Log(stringBuilder.ToString());
	}

	[ContextMenu("Reimport BlendShape order")]
	public void ReimportBlendOrder()
	{
		SkinnedMeshRenderer skinnedMeshRenderer = rend as SkinnedMeshRenderer;
		if (!(skinnedMeshRenderer != null))
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		Dictionary<string, BlendKeys> dictionary = Blends.ToDictionary((BlendKeys x) => x.BlendName, (BlendKeys x) => x);
		Mesh sharedMesh = skinnedMeshRenderer.sharedMesh;
		for (int num = 0; num < sharedMesh.blendShapeCount; num++)
		{
			string text = sharedMesh.GetBlendShapeName(num).Split('|')[0];
			bool flag = false;
			if (text.Last() == '2')
			{
				text = text.Substring(0, text.Length - 1);
				flag = true;
			}
			text = FixName(text);
			BlendKeys value;
			if (dictionary.TryGetValue(text, out value))
			{
				if (flag)
				{
					if (!value.doubleKey)
					{
						stringBuilder.AppendLine("Tried setting second index of non double key " + text);
						continue;
					}
					if (value.Index2 == num)
					{
						stringBuilder.AppendLine("Key " + text + " already had same second index");
						continue;
					}
					stringBuilder.AppendLine("Changed second index of " + text + " from " + value.Index2 + " to " + num);
					value.Index2 = num;
				}
				else if (value.Index == num)
				{
					stringBuilder.AppendLine("Key " + text + " already had same index");
				}
				else
				{
					stringBuilder.AppendLine("Changed index of " + text + " from " + value.Index + " to " + num);
					value.Index = num;
				}
			}
			else
			{
				stringBuilder.AppendLine("Did not find " + text + " in current blends");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	[ContextMenu("Check blend shapes")]
	public void CheckBlends()
	{
		Mesh sharedMesh = (rend as SkinnedMeshRenderer).sharedMesh;
		StringBuilder stringBuilder = new StringBuilder();
		BlendKeys[] blends = Blends;
		foreach (BlendKeys blendKeys in blends)
		{
			if (blendKeys.doubleKey)
			{
				if (CheckBlendIndex(sharedMesh, blendKeys.BlendName, blendKeys.Index, stringBuilder) && CheckBlendIndex(sharedMesh, blendKeys.BlendName, blendKeys.Index2, stringBuilder))
				{
					stringBuilder.AppendLine(blendKeys.BlendName + ": " + sharedMesh.GetBlendShapeName(blendKeys.Index) + " -> " + sharedMesh.GetBlendShapeName(blendKeys.Index2));
				}
			}
			else if (CheckBlendIndex(sharedMesh, blendKeys.BlendName, blendKeys.Index, stringBuilder))
			{
				stringBuilder.AppendLine(blendKeys.BlendName + ": " + sharedMesh.GetBlendShapeName(blendKeys.Index));
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	private bool CheckBlendIndex(Mesh mesh, string name, int index, StringBuilder sb)
	{
		if (index >= mesh.blendShapeCount)
		{
			sb.AppendLine((name + ": Index out of bounds - " + index).FontColor(Color.red));
			return false;
		}
		return true;
	}

	[ContextMenu("Check blend groups")]
	public void BlendGroups()
	{
		Debug.Log(string.Join("\n", Blends.Select((BlendKeys x) => x.GroupName).Distinct()));
	}

	private void PopulateBlendMap(BlendKeys bl, int[] bTri, Vector3[] v2, Vector3[] v3, Mesh m, List<TriangleBlendHolder> blendMap)
	{
		Vector3[] array;
		Vector3[] array2;
		if (bl.doubleKey)
		{
			m.GetBlendVertices(bl.Index, v2);
			m.GetBlendVertices(bl.Index2, v3);
			array = v2;
			array2 = v3;
		}
		else
		{
			m.GetBlendVertices(bl.Index, v2);
			array = null;
			array2 = v2;
		}
		if (bl.Reverse)
		{
			Vector3[] array3 = array;
			array = array2;
			array2 = array3;
		}
		for (int i = 0; i < bTri.Length; i += 3)
		{
			Vector3 vector = (GetDiff(array, array2, bTri[i]) + GetDiff(array, array2, bTri[i + 1]) + GetDiff(array, array2, bTri[i + 2])) / 3f;
			if (vector.magnitude > 1E-05f)
			{
				blendMap[i / 3].Blends.Add(new TriangleBlend(bl.BlendName, (Gender == GenderType.Female) ? vector : Vector3.Scale(Quaternion.Euler(90f, 0f, 0f) * vector, new Vector3(1f, -1f, -1f))));
			}
		}
	}

	private float[] GetWeightMap(BlendKeys bl, Vector3[] v2, Vector3[] v3, Mesh m)
	{
		Vector3[] v4;
		Vector3[] v5;
		if (bl.doubleKey)
		{
			m.GetBlendVertices(bl.Index, v2);
			m.GetBlendVertices(bl.Index2, v3);
			v4 = v2;
			v5 = v3;
		}
		else
		{
			m.GetBlendVertices(bl.Index, v2);
			v4 = null;
			v5 = v2;
		}
		float[] array = new float[v2.Length];
		float num = 0f;
		for (int i = 0; i < v2.Length; i++)
		{
			float magnitude = GetDiff(v4, v5, i).magnitude;
			num = Mathf.Max(magnitude, num);
			array[i] = magnitude;
		}
		for (int j = 0; j < array.Length; j++)
		{
			array[j] /= num;
		}
		return array;
	}

	private Vector3 GetDiff(Vector3[] v1, Vector3[] v2, int index)
	{
		return ((v2 != null) ? v2[index] : Vector3.zero) - ((v1 != null) ? v1[index] : Vector3.zero);
	}
}
