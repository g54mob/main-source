using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActorGenerator : ScriptableObject
{
	[Serializable]
	public struct OldColorMapping
	{
		public string From;

		public string To;
	}

	[Serializable]
	public struct OldBlendConversion
	{
		public string OldName;

		public string NewName;

		public bool WasDouble;

		public bool Invert;
	}

	[Serializable]
	public struct OldConversion
	{
		public string OldName;

		public string NewName;

		public OldColorMapping[] Colors;
	}

	[Serializable]
	public struct PatternGroup
	{
		public string Name;

		public int[] Patterns;
	}

	public interface IRandomGradient
	{
		Gradient GetGradient();

		Color[] GetColors();

		ValueTuple<string, bool, float> GetDepends();
	}

	[Serializable]
	public class RandomGradient : IRandomGradient
	{
		[Serializable]
		public struct GradientOverride : IRandomGradient
		{
			public string Tag;

			public Gradient Gradient;

			public Color[] Colors;

			public GradientOverride(string tag, Gradient gradient, params Color[] c)
			{
				Tag = tag;
				Gradient = gradient;
				Colors = c;
			}

			public Gradient GetGradient()
			{
				return Gradient;
			}

			public Color[] GetColors()
			{
				return Colors;
			}

			public ValueTuple<string, bool, float> GetDepends()
			{
				return new ValueTuple<string, bool, float>(null, false, 0f);
			}
		}

		[Serializable]
		public struct GradientVariant : IRandomGradient
		{
			public float Chance;

			[ActorGradient]
			public string DependOn;

			public bool DependClamp;

			[Range(0f, 1f)]
			public float DependScale;

			public Gradient Gradient;

			public Color[] Colors;

			public string[] ExcludeTags;

			public Gradient GetGradient()
			{
				return Gradient;
			}

			public Color[] GetColors()
			{
				return Colors;
			}

			public ValueTuple<string, bool, float> GetDepends()
			{
				return new ValueTuple<string, bool, float>(DependOn, DependClamp, DependScale);
			}
		}

		public string Key;

		[ActorGradient]
		public string DependOn;

		[Range(0f, 1f)]
		public float DependScale = 0.1f;

		public bool DependClamp = true;

		public bool DependVariant;

		public Gradient Gradient;

		public Color[] Colors;

		public List<GradientOverride> Overrides = new List<GradientOverride>();

		public List<GradientVariant> Variants = new List<GradientVariant>();

		[Range(0f, 1f)]
		public float SkinBlend;

		public override string ToString()
		{
			return Key;
		}

		public Color Evaluate(Dictionary<string, float> cols, Dictionary<string, int> variants, HashSet<string> tags, Color skinColor)
		{
			int value = -1;
			IRandomGradient randomGradient = this;
			ValueTuple<string, bool, float> depends = GetDepends();
			bool flag = false;
			for (int i = 0; i < Overrides.Count; i++)
			{
				GradientOverride gradientOverride = Overrides[i];
				if (tags.Contains(gradientOverride.Tag))
				{
					randomGradient = gradientOverride;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				int value2 = -1;
				if (!string.IsNullOrEmpty(depends.Item1) && DependVariant)
				{
					if (variants.TryGetValue(depends.Item1, out value2))
					{
						if (value2 < 0)
						{
							value2 = -2;
						}
					}
					else
					{
						value2 = -1;
					}
				}
				if (value2 == -1)
				{
					for (int j = 0; j < Variants.Count; j++)
					{
						GradientVariant gradientVariant = Variants[j];
						if ((gradientVariant.ExcludeTags == null || !gradientVariant.ExcludeTags.Any(tags.Contains)) && Utilities.RandomValue < gradientVariant.Chance)
						{
							value2 = j;
							break;
						}
					}
				}
				value = value2;
				if (value2 >= 0)
				{
					randomGradient = Variants[value2];
					depends = randomGradient.GetDepends();
				}
			}
			variants[Key] = value;
			float num;
			if (!string.IsNullOrEmpty(depends.Item1))
			{
				num = cols[depends.Item1] + (Utilities.RandomValue - 0.5f) * depends.Item3;
				num = ((!depends.Item2) ? ((num < 0f) ? (1f + num) : (num % 1f)) : Mathf.Clamp01(num));
			}
			else
			{
				num = Utilities.RandomValue;
			}
			cols[Key] = num;
			return Evaluate(num, randomGradient, skinColor, SkinBlend);
		}

		public Color Evaluate(float rnd, string tag, Color skinColor)
		{
			IRandomGradient grad = this;
			bool flag = false;
			for (int i = 0; i < Overrides.Count; i++)
			{
				GradientOverride gradientOverride = Overrides[i];
				if (gradientOverride.Tag.Equals(tag))
				{
					grad = gradientOverride;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				for (int j = 0; j < Variants.Count; j++)
				{
					GradientVariant gradientVariant = Variants[j];
					if (Utilities.RandomValue < gradientVariant.Chance)
					{
						grad = gradientVariant;
						break;
					}
				}
			}
			return Evaluate(rnd, grad, skinColor, SkinBlend);
		}

		public static Color Evaluate(float rnd, IRandomGradient grad, Color skinColor, float skinBlend)
		{
			Color[] colors = grad.GetColors();
			Color color = ((colors == null || colors.Length == 0) ? grad.GetGradient().Evaluate(rnd) : colors[Mathf.Min(colors.Length - 1, Mathf.FloorToInt(rnd * (float)colors.Length))]);
			if (skinBlend > 0f)
			{
				color = Color.Lerp(color, skinColor, skinBlend);
			}
			return color;
		}

		public Gradient GetGradient()
		{
			return Gradient;
		}

		public Color[] GetColors()
		{
			return Colors;
		}

		public ValueTuple<string, bool, float> GetDepends()
		{
			return new ValueTuple<string, bool, float>(DependOn, DependClamp, DependScale);
		}
	}

	[Serializable]
	public class Node
	{
		public enum NodeType
		{
			Node = 0,
			Leaf = 1
		}

		public enum SelectionType
		{
			Single = 0,
			All = 1,
			Individual = 2
		}

		public string Name = "Node";

		public uint ID;

		public bool ExcludeTags;

		public NodeType Type;

		public SelectionType SelType;

		public string[] Filter;

		[Range(0f, 1f)]
		public float Probability = 1f;

		public ActorBodyItem Prefab;

		public List<uint> _outputsIDs = new List<uint>();

		[NonSerialized]
		private List<Node> _outputs;

		public Vector2 Position;

		public Node()
		{
		}

		public Node(ActorBodyItem prefab, Vector2 position)
		{
			Name = prefab.Name;
			Prefab = prefab;
			Position = position;
			Type = NodeType.Leaf;
		}

		public Node(bool selectOne, Vector2 position)
		{
			SelType = ((!selectOne) ? SelectionType.All : SelectionType.Single);
			Position = position;
			Type = NodeType.Node;
		}

		public Node(bool selectOne, Vector2 position, params string[] tags)
		{
			SelType = ((!selectOne) ? SelectionType.All : SelectionType.Single);
			Position = position;
			Type = NodeType.Node;
			Filter = tags;
		}

		public void SetID(ActorGenerator gen)
		{
			ID = gen.Nodes.MaxSafeUInt((Node x) => x.ID) + 1;
		}

		public List<Node> GetOutputs(ActorGenerator gen)
		{
			if (_outputs == null)
			{
				_outputs = (from x in _outputsIDs
					select gen.Nodes.FirstOrDefault((Node z) => z.ID == x) into x
					orderby x.Position.x
					select x).ToList();
			}
			return _outputs;
		}

		public void AddNode(Node n)
		{
			if (n != this && !_outputsIDs.Contains(n.ID))
			{
				_outputsIDs.Add(n.ID);
				_outputs = null;
			}
		}

		public void RemoveNode(Node n)
		{
			if (_outputsIDs.RemoveAll((uint x) => x == n.ID) > 0)
			{
				_outputs = null;
			}
		}

		public bool Valid(HashSet<string> tags)
		{
			if (Filter == null || Filter.Length == 0)
			{
				return true;
			}
			for (int i = 0; i < Filter.Length; i++)
			{
				if (tags.Contains(Filter[i]))
				{
					return !ExcludeTags;
				}
			}
			return ExcludeTags;
		}
	}

	private static bool _bound;

	private static ActorGenerator _instance;

	public List<string> Tags = new List<string>();

	public List<GameObject> BodyItemPrefabs = new List<GameObject>();

	public List<Node> Nodes = new List<Node>();

	public GameObject BodyShadow;

	public List<RandomGradient> Gradients = new List<RandomGradient>();

	public int SkinColors;

	public int SkinColorRow;

	public Texture2D SkinToneTexture;

	public Sprite DefaultBlendSprite;

	[NonSerialized]
	public Color[] AllSkinColors;

	public OldConversion[] Compatibility;

	public OldBlendConversion[] BlendCompatibility;

	public int PatternSizeX = 2;

	public int PatternSizeY = 2;

	public PatternGroup[] PatternGroups;

	public Texture PatternTexture;

	public Material ClothesMat;

	public Material ClothesSkinMat;

	public Material ClothesPatternMat;

	public Material ClothesSkinPatternMat;

	public Material ClothesInstancedMat;

	public Material ClothesSkinInstancedMat;

	public Material ClothesPatternInstancedMat;

	public Material ClothesSkinPatternInstancedMat;

	public List<ActorBodyItem.TriangleBlendHolder> MaleHeadBlendMap = new List<ActorBodyItem.TriangleBlendHolder>();

	public List<ActorBodyItem.TriangleBlendHolder> FemaleHeadBlendMap = new List<ActorBodyItem.TriangleBlendHolder>();

	public int ElderlyAgeLimit = 45;

	[NonSerialized]
	public Dictionary<string, GameObject> BodyItems = new Dictionary<string, GameObject>();

	[NonSerialized]
	private bool _initialized;

	public static ActorGenerator Instance
	{
		get
		{
			if (!_bound)
			{
				_instance = UnityEngine.Object.Instantiate(Resources.Load<ActorGenerator>("ActorGenerator"));
				_bound = true;
			}
			return _instance;
		}
	}

	public static float AgeWeightStart
	{
		get
		{
			return Employee.RetirementAge - 20;
		}
	}

	public static float AgeWeightEnd
	{
		get
		{
			return Employee.RetirementAge - 5;
		}
	}

	public Vector4 PatternToUV(int pattern)
	{
		int num = pattern % PatternSizeX;
		int num2 = pattern / PatternSizeX;
		num2 = PatternSizeY - 1 - num2;
		return new Vector4(num, num2, 0f, 0f);
	}

	private void OnEnable()
	{
		if (!_initialized)
		{
			_initialized = true;
			for (int i = 0; i < BodyItemPrefabs.Count; i++)
			{
				GameObject gameObject = BodyItemPrefabs[i];
				ActorBodyItem component = gameObject.GetComponent<ActorBodyItem>();
				BodyItems.Add(component.Key, gameObject);
			}
			BodyItems["Shadow"] = BodyShadow;
			AllSkinColors = new Color[SkinColors];
			for (int j = 0; j < SkinColors; j++)
			{
				AllSkinColors[j] = SkinToneTexture.GetPixel(j, SkinColorRow);
			}
			Shader.SetGlobalTexture("_SkinToneTexture", SkinToneTexture);
		}
	}

	public Node AddNode(string name, Node n)
	{
		n.Name = name;
		n.SetID(this);
		Nodes.Add(n);
		return n;
	}

	public ActorBodyItem InitShadow(IStylable act)
	{
		ActorBodyItem actorBodyItem = SetItem(act, false, "Shadow");
		act.BodyItems.Remove(actorBodyItem);
		return actorBodyItem;
	}

	public ActorBodyItem SetItem(IStylable act, bool mirrored, string item, bool destroy = true, string style = null, Dictionary<string, Color> prev = null)
	{
		GameObject gameObject = BodyItems[item];
		ActorBodyItem component = gameObject.GetComponent<ActorBodyItem>();
		ActorBodyItem actorBodyItem = null;
		if (!destroy)
		{
			bool flag = false;
			for (int i = 0; i < act.BodyItems.Count; i++)
			{
				ActorBodyItem actorBodyItem2 = act.BodyItems[i];
				if (actorBodyItem2.Key.Equals(item) && actorBodyItem2.Mirror == mirrored)
				{
					actorBodyItem = actorBodyItem2;
					actorBodyItem.gameObject.SetActive(true);
					flag = true;
				}
				else
				{
					if (actorBodyItem2.DontOverride)
					{
						continue;
					}
					if (component.Type == ActorBodyItem.BodyType.Accessory)
					{
						if (actorBodyItem2.Type == ActorBodyItem.BodyType.Accessory && component.Category.Equals(actorBodyItem2.Category))
						{
							actorBodyItem2.gameObject.SetActive(false);
						}
					}
					else if (actorBodyItem2.Type == component.Type)
					{
						actorBodyItem2.gameObject.SetActive(false);
					}
				}
			}
			if (!flag)
			{
				actorBodyItem = UnityEngine.Object.Instantiate(gameObject).GetComponent<ActorBodyItem>();
				actorBodyItem.RunDestruction = act.NeedsDestruction;
				actorBodyItem.Mirror = mirrored;
				RigItem(component, actorBodyItem, act);
				act.BodyItems.Add(actorBodyItem);
			}
			else if (actorBodyItem.IsFaceTexture)
			{
				SetFace(act, component.FaceTexture);
			}
			else if (actorBodyItem.IsFaceMap && actorBodyItem.IsFaceUV)
			{
				ActorBodyItem actorBodyItem3 = act.BodyItems.First((ActorBodyItem x) => x.gameObject.activeSelf && x.Type == ActorBodyItem.BodyType.Head);
				actorBodyItem3.rend.material.SetFloat("_EOffset", component.UVOffset);
				if (act.UsesLOD1)
				{
					actorBodyItem3.LOD1Renderer.material.SetFloat("_EOffset", component.UVOffset);
				}
			}
		}
		else
		{
			actorBodyItem = UnityEngine.Object.Instantiate(gameObject).GetComponent<ActorBodyItem>();
			actorBodyItem.RunDestruction = act.NeedsDestruction;
			bool flag2 = false;
			actorBodyItem.Mirror = mirrored;
			RigItem(component, actorBodyItem, act);
			Color skinColor = Color.white;
			if (!actorBodyItem.DontOverride)
			{
				for (int num = 0; num < act.BodyItems.Count; num++)
				{
					ActorBodyItem actorBodyItem4 = act.BodyItems[num];
					if (actorBodyItem4.Type == ActorBodyItem.BodyType.Head)
					{
						skinColor = actorBodyItem4.GetColor("Skin") * AllSkinColors[actorBodyItem4.SkinToneIndex];
					}
					if (component.Type == ActorBodyItem.BodyType.Accessory)
					{
						if (actorBodyItem4.Type == ActorBodyItem.BodyType.Accessory && component.Category.Equals(actorBodyItem4.Category))
						{
							actorBodyItem.Load(actorBodyItem4.Save(), style, prev);
							act.BodyItems.RemoveAt(num);
							num--;
							if (actorBodyItem4.LOD1Instance != null)
							{
								UnityEngine.Object.Destroy(actorBodyItem4.LOD1Instance);
								actorBodyItem4.LOD1Instance = null;
							}
							actorBodyItem4.OnDestroy();
							UnityEngine.Object.Destroy(actorBodyItem4.gameObject);
							flag2 = true;
						}
					}
					else if (actorBodyItem4.Type == component.Type)
					{
						actorBodyItem.Load(actorBodyItem4.Save(), style, prev);
						act.BodyItems.RemoveAt(num);
						num--;
						if (actorBodyItem4.LOD1Instance != null)
						{
							UnityEngine.Object.Destroy(actorBodyItem4.LOD1Instance);
							actorBodyItem4.LOD1Instance = null;
						}
						UnityEngine.Object.Destroy(actorBodyItem4.gameObject);
						flag2 = true;
					}
				}
			}
			else
			{
				ActorBodyItem actorBodyItem5 = act.BodyItems.First((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
				if (actorBodyItem5 != null)
				{
					skinColor = actorBodyItem5.GetColor("Skin") * AllSkinColors[actorBodyItem5.SkinToneIndex];
				}
			}
			act.BodyItems.Add(actorBodyItem);
			if (!flag2 && style != null)
			{
				actorBodyItem.InitRandomColors(style, prev, skinColor);
			}
			if (!component.DontOverride && component.Type == ActorBodyItem.BodyType.Head)
			{
				act.UpdateEyes();
			}
		}
		actorBodyItem.LoadBlendTransforms(GetHeadBlends(act));
		return actorBodyItem;
	}

	public void RigItem(ActorBodyItem itb, ActorBodyItem bodyItem, IStylable actor)
	{
		Transform transform = actor.GetTransform();
		if (itb.IsFaceTexture)
		{
			SetFace(actor, itb.FaceTexture);
			bodyItem.transform.SetParent(transform);
			return;
		}
		if (itb.IsFaceMap)
		{
			if (itb.IsFaceUV)
			{
				ActorBodyItem actorBodyItem = actor.BodyItems.First((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
				actorBodyItem.rend.material.SetFloat("_EOffset", itb.UVOffset);
				if (actor.UsesLOD1)
				{
					actorBodyItem.LOD1Renderer.material.SetFloat("_EOffset", itb.UVOffset);
				}
			}
			bodyItem.transform.SetParent(transform);
			return;
		}
		if (itb.IsRigged)
		{
			Transform transform2 = actor.GetTransform();
			AttachToBones(transform2, actor, bodyItem.transform);
			GameObject l;
			if (actor.UsesLOD1 && bodyItem.InitLOD2(out l))
			{
				AttachToBones(transform2, actor, l.transform);
			}
			return;
		}
		Transform parent = transform.GetComponentsInChildren<Transform>(true).FirstOrDefault((Transform x) => x.name.Equals(itb.RootBone));
		SetPosition(transform, parent, bodyItem.transform, itb);
		GameObject l2;
		if (actor.UsesLOD1 && bodyItem.InitLOD2(out l2))
		{
			SetPosition(transform, parent, l2.transform, itb);
		}
		if (bodyItem.Mirror)
		{
			bodyItem.ApplyMirror();
		}
		bodyItem.ImprintPosition();
	}

	private void SetPosition(Transform root, Transform parent, Transform item, ActorBodyItem itb)
	{
		item.localScale *= root.localScale.x;
		Vector3 position = item.position;
		item.SetParent(parent, true);
		item.localPosition = (itb.KeepLocalPosition ? position : Vector3.zero);
		item.localRotation = (itb.RotationFix ? Quaternion.Euler(0f, 270f, 180f) : Quaternion.identity);
	}

	public ActorBodyItem.BodyItemObject[] FixOldStyle(ActorBodyItem.BodyItemObject[] input)
	{
		if (input.Any((ActorBodyItem.BodyItemObject x) => x.Key.Contains("Eyebrows")) || input.Any((ActorBodyItem.BodyItemObject x) => x.Key.Equals("AccessoryHood")))
		{
			List<ActorBodyItem.BodyItemObject> list = new List<ActorBodyItem.BodyItemObject>();
			Dictionary<string, SVector3> dictionary = new Dictionary<string, SVector3>();
			Dictionary<string, float> dictionary2 = new Dictionary<string, float>();
			foreach (ActorBodyItem.BodyItemObject bodyItemObject in input)
			{
				foreach (KeyValuePair<string, SVector3> color in bodyItemObject.Colors)
				{
					dictionary[bodyItemObject.Key + "." + color.Key] = color.Value;
				}
				foreach (KeyValuePair<string, float> blend in bodyItemObject.Blends)
				{
					dictionary2[blend.Key] = blend.Value;
				}
			}
			SVector3 value;
			if (!dictionary.TryGetValue("EyebrowsMale.Color", out value))
			{
				value = dictionary.GetOrDefault("EyebrowsFemale.Color", new SVector3(0f, 0f, 0f, 1f));
			}
			dictionary["!Hair"] = value;
			System.Random rng = new System.Random(string.Join(",", dictionary.Select((KeyValuePair<string, SVector3> x) => x.Value.ToString())).GetHashCode());
			for (int num2 = 0; num2 < input.Length; num2++)
			{
				ActorBodyItem.BodyItemObject o = input[num2];
				OldConversion r;
				if (!Compatibility.TryGetFirst((OldConversion x) => x.OldName.Equals(o.Key), out r) || string.IsNullOrEmpty(r.NewName))
				{
					continue;
				}
				o = new ActorBodyItem.BodyItemObject(o);
				o.Key = r.NewName;
				Dictionary<string, SVector3> dictionary3 = new Dictionary<string, SVector3>();
				OldColorMapping[] colors = r.Colors;
				for (int num3 = 0; num3 < colors.Length; num3++)
				{
					OldColorMapping oldColorMapping = colors[num3];
					if (oldColorMapping.To.Contains('.') || oldColorMapping.To.Contains('!'))
					{
						dictionary3[oldColorMapping.From] = dictionary.GetOrDefault(oldColorMapping.To, SVector3.One);
					}
					else
					{
						dictionary3[oldColorMapping.From] = o.Colors.GetOrDefault(oldColorMapping.To, SVector3.One);
					}
				}
				o.Colors = dictionary3;
				list.Add(o);
			}
			ActorBodyItem.BodyItemObject bodyItemObject2 = list.FirstOrDefault((ActorBodyItem.BodyItemObject x) => x.Key.StartsWith("Head"));
			if (bodyItemObject2 != null)
			{
				Dictionary<string, OldBlendConversion> dictionary4 = BlendCompatibility.ToDictionary((OldBlendConversion x) => x.NewName, (OldBlendConversion x) => x);
				bodyItemObject2.Blends = new Dictionary<string, float>();
				GameObject value2;
				if (BodyItems.TryGetValue(bodyItemObject2.Key, out value2))
				{
					ActorBodyItem.BlendKeys[] blends = value2.GetComponent<ActorBodyItem>().Blends;
					foreach (ActorBodyItem.BlendKeys blendKeys in blends)
					{
						OldBlendConversion value3;
						float value4;
						if (dictionary4.TryGetValue(blendKeys.BlendName, out value3) && dictionary2.TryGetValue(value3.OldName, out value4))
						{
							if (value3.WasDouble && !blendKeys.doubleKey)
							{
								value4 = value4.MapRange(-100f, 100f, 0f, 100f);
							}
							else if (!value3.WasDouble && blendKeys.doubleKey)
							{
								value4 = value4.MapRange(0f, 100f, -100f, 100f);
							}
							if (value3.Invert)
							{
								value4 = ((!blendKeys.doubleKey) ? (100f - value4) : (0f - value4));
							}
							bodyItemObject2.Blends[blendKeys.BlendName] = value4;
						}
						else if (blendKeys.hide)
						{
							bodyItemObject2.Blends[blendKeys.BlendName] = 0f;
						}
						else
						{
							float randomValue = blendKeys.GetRandomValue(rng);
							bodyItemObject2.Blends[blendKeys.BlendName] = (blendKeys.doubleKey ? (randomValue * 2f - 1f) : randomValue) * 100f;
						}
					}
				}
				else
				{
					Debug.LogError("Could not find body item: " + bodyItemObject2.Key + " when converting old actor style");
				}
				foreach (ActorBodyItem.BodyItemObject item in list)
				{
					if (item == bodyItemObject2)
					{
						continue;
					}
					GameObject value5;
					if (BodyItems.TryGetValue(item.Key, out value5))
					{
						ActorBodyItem.BlendKeys[] blends = value5.GetComponent<ActorBodyItem>().Blends;
						foreach (ActorBodyItem.BlendKeys blendKeys2 in blends)
						{
							item.Blends[blendKeys2.BlendName] = bodyItemObject2.Blends.GetOrDefault(blendKeys2.BlendName, 0f);
						}
					}
					else
					{
						Debug.LogError("Could not find body item: " + item.Key + " when converting old actor style");
					}
				}
			}
			return list.ToArray();
		}
		return input;
	}

	public ActorBodyItem.BodyItemObject[] GenerateStyle(bool female, string style, float age)
	{
		bool num = age >= (float)ElderlyAgeLimit;
		int num2 = Utilities.RandomRange(1, SkinColors);
		float value = ((float)num2 - 1f) / ((float)SkinColors - 1f);
		List<ActorBodyItem.BodyItemObject> list = new List<ActorBodyItem.BodyItemObject>();
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		Dictionary<string, int> variants = new Dictionary<string, int>();
		HashSet<string> hashSet = new HashSet<string>
		{
			style,
			female ? "Female" : "Male"
		};
		if (num)
		{
			hashSet.Add("Elderly");
		}
		dictionary["Skin"] = value;
		Dictionary<string, Color> dictionary2 = new Dictionary<string, Color>();
		for (int i = 0; i < Gradients.Count; i++)
		{
			RandomGradient randomGradient = Gradients[i];
			if (!randomGradient.Key.Equals("Skin"))
			{
				dictionary2[randomGradient.Key] = randomGradient.Evaluate(dictionary, variants, hashSet, AllSkinColors[num2]);
			}
		}
		dictionary2["Skin"] = Color.white;
		Node node = Nodes[0];
		GoDownTree(node, hashSet, dictionary2, new Dictionary<string, float>(), num2, list);
		SetStyleAge(list, age);
		return list.ToArray();
	}

	public static void SetStyleAge(IList<ActorBodyItem.BodyItemObject> style, float age)
	{
		ActorBodyItem.BodyItemObject bodyItemObject = ((style != null) ? style.FirstOrDefault((ActorBodyItem.BodyItemObject x) => x.Key.Equals("HeadFemale") || x.Key.Equals("HeadMale")) : null);
		if (bodyItemObject != null)
		{
			bodyItemObject.Blends["Age"] = GetAgeWeight(age) * 100f;
		}
	}

	private void GoDownTree(Node node, HashSet<string> tags, Dictionary<string, Color> colors, Dictionary<string, float> blends, int skinIndex, List<ActorBodyItem.BodyItemObject> result)
	{
		if (!node.Valid(tags))
		{
			return;
		}
		if (node.Type == Node.NodeType.Node)
		{
			if (!(node.Probability >= 1f) && !(Utilities.RandomValue < node.Probability))
			{
				return;
			}
			Node[] array = (from x in node.GetOutputs(this)
				where x.Valid(tags)
				select x).ToArray();
			if (array.Length == 0)
			{
				return;
			}
			switch (node.SelType)
			{
			case Node.SelectionType.Single:
			{
				float num2 = array.SumSafe((Node x) => (!x.Valid(tags)) ? 0f : x.Probability);
				float num3 = Utilities.RandomValue * num2;
				float num4 = 0f;
				Node node3 = null;
				for (int num5 = 0; num5 < array.Length; num5++)
				{
					if (array[num5].Valid(tags))
					{
						num4 += array[num5].Probability;
						if (num3 < num4)
						{
							node3 = array[num5];
							break;
						}
					}
				}
				if (node3 != null)
				{
					GoDownTree(node3, tags, colors, blends, skinIndex, result);
				}
				break;
			}
			case Node.SelectionType.All:
			{
				Node[] array2 = array;
				foreach (Node node4 in array2)
				{
					GoDownTree(node4, tags, colors, blends, skinIndex, result);
				}
				break;
			}
			case Node.SelectionType.Individual:
			{
				Node[] array2 = array;
				foreach (Node node2 in array2)
				{
					if (node2.Type != Node.NodeType.Leaf || Utilities.RandomValue < node2.Probability)
					{
						GoDownTree(node2, tags, colors, blends, skinIndex, result);
					}
				}
				break;
			}
			}
		}
		else
		{
			if (node.Type != Node.NodeType.Leaf)
			{
				return;
			}
			int patternIndex = 0;
			if (!tags.Contains("Burglar") && node.Prefab.CanUsePattern && node.Prefab.PatternGroups != null && node.Prefab.PatternGroups.Length != 0)
			{
				string group = ((node.Prefab.PatternGroups.Length == 1) ? node.Prefab.PatternGroups[0] : node.Prefab.PatternGroups.GetRandom(Utilities.RNG));
				patternIndex = PatternGroups.First((PatternGroup x) => x.Name.Equals(group)).Patterns.GetRandom(Utilities.RNG);
			}
			if (node.Prefab.CreateMirrorVersion)
			{
				int num6 = Utilities.RandomRange(1, 4);
				if ((num6 & 1) > 0)
				{
					result.Add(node.Prefab.Save(node.Prefab.Colormap.ToDictionary((ActorBodyItem.ColorMapping x) => x.ColorName, (ActorBodyItem.ColorMapping x) => colors[x.Mapping]), blends, skinIndex, patternIndex, false));
				}
				if ((num6 & 2) > 0)
				{
					result.Add(node.Prefab.Save(node.Prefab.Colormap.ToDictionary((ActorBodyItem.ColorMapping x) => x.ColorName, (ActorBodyItem.ColorMapping x) => colors[x.Mapping]), blends, skinIndex, patternIndex, true));
				}
				return;
			}
			ActorBodyItem.BodyItemObject bodyItemObject = node.Prefab.Save(node.Prefab.Colormap.ToDictionary((ActorBodyItem.ColorMapping x) => x.ColorName, (ActorBodyItem.ColorMapping x) => colors[x.Mapping]), blends, skinIndex, patternIndex, false);
			if (node.Prefab.Type == ActorBodyItem.BodyType.Head)
			{
				foreach (KeyValuePair<string, float> blend in bodyItemObject.Blends)
				{
					blends[blend.Key] = blend.Value;
				}
			}
			result.Add(bodyItemObject);
		}
	}

	private void ResetFace(IStylable actor)
	{
		for (int i = 0; i < actor.BodyItems.Count; i++)
		{
			ActorBodyItem actorBodyItem = actor.BodyItems[i];
			if (actorBodyItem.Type == ActorBodyItem.BodyType.Head)
			{
				actorBodyItem.rend.material.SetFloat("_EOffset", 0f);
				if (actor.UsesLOD1)
				{
					actorBodyItem.LOD1Renderer.material.SetFloat("_EOffset", 0f);
				}
				actorBodyItem.SetColorDirect("_EColor1", Color.clear);
				actorBodyItem.SetColorDirect("_EColor2", Color.clear);
				actorBodyItem.SetColorDirect("_EColor3", Color.clear);
			}
		}
	}

	[Obsolete]
	private void SetFace(IStylable actor, Texture2D tex)
	{
		for (int i = 0; i < actor.BodyItems.Count; i++)
		{
			ActorBodyItem actorBodyItem = actor.BodyItems[i];
			if (actorBodyItem.Type == ActorBodyItem.BodyType.Head)
			{
				actorBodyItem.rend.material.SetTexture("_OverlayTex2", tex);
				if (actor.UsesLOD1)
				{
					actorBodyItem.LOD1Renderer.material.SetTexture("_OverlayTex2", tex);
				}
			}
		}
	}

	public void SetTorsoPantsColor(IStylable actor, Color c)
	{
		for (int i = 0; i < actor.BodyItems.Count; i++)
		{
			ActorBodyItem actorBodyItem = actor.BodyItems[i];
			if (actorBodyItem.Type != ActorBodyItem.BodyType.Torso && actorBodyItem.Type != ActorBodyItem.BodyType.Legs)
			{
				continue;
			}
			for (int j = 0; j < actorBodyItem.Colormap.Length; j++)
			{
				ActorBodyItem.ColorMapping colorMapping = actorBodyItem.Colormap[j];
				if (!colorMapping.ColorName.Equals("Skin"))
				{
					actorBodyItem.SetColorDirect(colorMapping.MaterialSlot, c);
				}
			}
		}
	}

	public void SetTorsoPantsColor(IStylable actor, ActorBodyItem.BodyItemObject[] items)
	{
		for (int i = 0; i < actor.BodyItems.Count; i++)
		{
			ActorBodyItem actorBodyItem = actor.BodyItems[i];
			if (actorBodyItem.Type != ActorBodyItem.BodyType.Torso && actorBodyItem.Type != ActorBodyItem.BodyType.Legs)
			{
				continue;
			}
			string key = actorBodyItem.Key;
			ActorBodyItem.BodyItemObject bodyItemObject = items.FirstOrDefault((ActorBodyItem.BodyItemObject x) => x.Key.Equals(key));
			if (bodyItemObject == null)
			{
				continue;
			}
			for (int num = 0; num < actorBodyItem.Colormap.Length; num++)
			{
				ActorBodyItem.ColorMapping colorMapping = actorBodyItem.Colormap[num];
				SVector3 value;
				if (!colorMapping.ColorName.Equals("Skin") && bodyItemObject.Colors.TryGetValue(colorMapping.ColorName, out value))
				{
					actorBodyItem.SetColorDirect(colorMapping.MaterialSlot, value);
				}
			}
		}
	}

	public ActorBodyItem.BodyItemObject[] ApplySavedStyle(ActorBodyItem.BodyItemObject[] items, IStylable actor, bool destroy = true)
	{
		items = FixOldStyle(items);
		InitParentBones(actor.RootBone, actor);
		foreach (ActorBodyItem bodyItem in actor.BodyItems)
		{
			if (destroy)
			{
				UnityEngine.Object.Destroy(bodyItem.gameObject);
				bodyItem.OnDestroy();
			}
			else
			{
				bodyItem.RemoveEffects();
				bodyItem.gameObject.SetActive(false);
			}
		}
		if (destroy)
		{
			actor.BodyItems.Clear();
		}
		else
		{
			ResetFace(actor);
		}
		bool flag = true;
		ActorBodyItem.BodyItemObject[] array = items;
		foreach (ActorBodyItem.BodyItemObject bodyItemObject in array)
		{
			ActorBodyItem actorBodyItem = SetItem(actor, bodyItemObject.Mirrored, bodyItemObject.Key, destroy);
			if (actorBodyItem.LOD2Part != null && actorBodyItem.LOD2Part.Length != 0)
			{
				for (int j = 0; j < actorBodyItem.LOD2Part.Length; j++)
				{
					SVector3 sVector = bodyItemObject.Colors.GetOrDefault(actorBodyItem.LOD2ColorKey[j], Color.gray);
					if (actorBodyItem.LOD2ColorKey[j].Equals("Skin"))
					{
						sVector *= AllSkinColors[bodyItemObject.SkinToneIndex];
					}
					actor.SetLOD2Color(actorBodyItem.LOD2Part[j], sVector);
				}
			}
			SVector3 value;
			if (actorBodyItem.Type == ActorBodyItem.BodyType.Hair && bodyItemObject.Colors.TryGetValue("Hair", out value))
			{
				actor.UpdateHairColor(value);
			}
			SVector3 value2;
			if (actorBodyItem.Type == ActorBodyItem.BodyType.Head && bodyItemObject.Colors.TryGetValue("Skin", out value2))
			{
				actor.UpdateSkinColor(value2 * AllSkinColors[bodyItemObject.SkinToneIndex]);
			}
			actorBodyItem.Load(bodyItemObject, null, null);
			flag &= actorBodyItem.AllowHoliday;
		}
		actor.PostUpdate(flag);
		return items;
	}

	public static Dictionary<string, float> GetHeadBlends(IStylable actor)
	{
		ActorBodyItem actorBodyItem = actor.BodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
		if (actorBodyItem != null)
		{
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			SkinnedMeshRenderer component = actorBodyItem.rend.GetComponent<SkinnedMeshRenderer>();
			for (int num = 0; num < actorBodyItem.Blends.Length; num++)
			{
				ActorBodyItem.BlendKeys blendKeys = actorBodyItem.Blends[num];
				dictionary[blendKeys.BlendName] = blendKeys.GetBlendValue(component);
			}
			return dictionary;
		}
		return null;
	}

	public static Dictionary<string, float> GetHeadBlends(ActorBodyItem.BodyItemObject[] items)
	{
		ActorBodyItem.BodyItemObject bodyItemObject = items.FirstOrDefault((ActorBodyItem.BodyItemObject x) => x.Key.Equals("HeadMale") || x.Key.Equals("HeadFemale"));
		if (bodyItemObject == null)
		{
			return null;
		}
		return bodyItemObject.Blends;
	}

	public static void ApplyBlendTransforms(IStylable actor, Dictionary<string, float> blends)
	{
		if (blends != null)
		{
			for (int i = 0; i < actor.BodyItems.Count; i++)
			{
				actor.BodyItems[i].LoadBlendTransforms(blends);
			}
		}
	}

	public static void ApplyBlendTransforms(IStylable actor)
	{
		ApplyBlendTransforms(actor, GetHeadBlends(actor));
	}

	public void CopyStyle(IStylable src, IStylable actor, bool destroy = true)
	{
		InitParentBones(actor.RootBone, actor);
		foreach (ActorBodyItem bodyItem in actor.BodyItems)
		{
			if (destroy)
			{
				UnityEngine.Object.DestroyImmediate(bodyItem.gameObject);
			}
			else
			{
				bodyItem.gameObject.SetActive(false);
			}
		}
		if (destroy)
		{
			actor.BodyItems.Clear();
		}
		else
		{
			ResetFace(actor);
		}
		bool flag = true;
		foreach (ActorBodyItem bodyItem2 in src.BodyItems)
		{
			ActorBodyItem.BodyItemObject bodyItemObject = bodyItem2.Save();
			ActorBodyItem actorBodyItem = SetItem(actor, bodyItemObject.Mirrored, bodyItemObject.Key, destroy);
			if (actorBodyItem.LOD2Part != null && actorBodyItem.LOD2Part.Length != 0)
			{
				for (int i = 0; i < actorBodyItem.LOD2Part.Length; i++)
				{
					actor.SetLOD2Color(actorBodyItem.LOD2Part[i], bodyItemObject.Colors.GetOrDefault(actorBodyItem.LOD2ColorKey[i], Color.gray));
				}
			}
			SVector3 value;
			if (actorBodyItem.Type == ActorBodyItem.BodyType.Hair && bodyItemObject.Colors.TryGetValue("Hair", out value))
			{
				actor.UpdateHairColor(value);
			}
			SVector3 value2;
			if (actorBodyItem.Type == ActorBodyItem.BodyType.Head && bodyItemObject.Colors.TryGetValue("Skin", out value2))
			{
				actor.UpdateSkinColor(value2 * AllSkinColors[bodyItemObject.SkinToneIndex]);
			}
			actorBodyItem.Load(bodyItemObject, null, null);
			flag &= actorBodyItem.AllowHoliday;
		}
		actor.PostUpdate(flag);
	}

	private void AttachToBones(Transform parent, IStylable act, Transform child)
	{
		Vector3 localScale = child.localScale;
		child.localScale *= parent.localScale.x;
		Transform[] array = (from x in child.GetComponentsInChildren<Transform>()
			where x != child && x.GetComponent<SkinnedMeshRenderer>() == null
			select x).ToArray();
		Dictionary<string, Transform> parentBones = GetParentBones(act);
		child.parent = parent;
		child.localPosition = Vector3.zero;
		child.localRotation = Quaternion.identity;
		child.localScale = localScale;
		Transform[] array2 = array;
		foreach (Transform transform in array2)
		{
			Transform orDefault = parentBones.GetOrDefault(transform.name);
			if (orDefault != null)
			{
				transform.parent = orDefault;
			}
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.name = "Rigged" + transform.name;
		}
	}

	private Dictionary<string, Transform> GetParentBones(IStylable act)
	{
		if (act.Rig == null)
		{
			InitParentBones(act.RootBone, act);
		}
		return act.Rig;
	}

	private void InitParentBones(Transform root, IStylable act)
	{
		if (act.Rig == null)
		{
			act.Rig = new Dictionary<string, Transform>();
		}
		if (!act.Rig.ContainsKey(root.name))
		{
			act.Rig[root.name] = root.transform;
			for (int i = 0; i < root.childCount; i++)
			{
				InitParentBones(root.GetChild(i), act);
			}
		}
	}

	public static float GetAgeWeight(float age)
	{
		return age.MapRange(AgeWeightStart, AgeWeightEnd, 0f, 1f, true);
	}
}
