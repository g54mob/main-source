using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tyd;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureMaterialEditor : MonoBehaviour
{
	public class MaterialVariable
	{
		public enum Type
		{
			Texture = 0,
			Float = 1,
			Color = 2,
			Range = 3,
			Toggle = 4,
			Flag = 5,
			Vector = 6
		}

		public string Name;

		public string Target;

		public string Desc;

		public string ForceFlag;

		public int VectorIndex = -1;

		public Type VarType;

		public MaterialVariable(string name, string target, Type varType)
		{
			Name = name;
			Target = target;
			VarType = varType;
		}

		public MaterialVariable(string name, string target, int index)
		{
			Name = name;
			Target = target;
			VarType = Type.Vector;
			VectorIndex = index;
		}
	}

	public GUIWindow Window;

	public GameObject ThumbCam;

	public MeshRenderer PreviewBall;

	public MeshFilter BallMesh;

	public Mesh[] PreviewMeshes;

	public float[] PreviewScales;

	private int _currentMesh;

	public RectTransform MaterialPanel;

	public RectTransform PropertyPanel;

	public Text LabelPrefab;

	public Text ShaderLabel;

	public Button ButtonPrefab;

	public Toggle TogglePrefab;

	public InputField InputPrefab;

	public Slider SliderPrefab;

	public GameObject Vector3Prefab;

	public GameObject TwoButtonPrefab;

	public InputField NameField;

	private bool _init;

	private Dictionary<Material, Button> _buttons = new Dictionary<Material, Button>();

	private Material _activeMat;

	private static Dictionary<string, List<MaterialVariable>> _Variables = new Dictionary<string, List<MaterialVariable>>
	{
		{
			"Standard",
			new List<MaterialVariable>
			{
				new MaterialVariable("Texture", "_MainTex", MaterialVariable.Type.Texture),
				new MaterialVariable("Extra", "_ExtraTex", MaterialVariable.Type.Texture)
				{
					ForceFlag = "_EXTRAMAP",
					Desc = "Red channel = Smoothness\nGreen channel = Emission\nBlue channel = Mask"
				},
				new MaterialVariable("Normal", "_LumpMap", MaterialVariable.Type.Texture)
				{
					ForceFlag = "_BUMPMAP",
					Desc = "Alpha channel controls metal reflection map factor"
				},
				new MaterialVariable("Emission factor", "_EmissionFact", MaterialVariable.Type.Range),
				new MaterialVariable("Reverse metallic", "_REVERSEMETAL", MaterialVariable.Type.Flag)
				{
					Desc = "Reverse alpha channel of normal map"
				},
				new MaterialVariable("Use snow", "_SNOW", MaterialVariable.Type.Flag)
				{
					Desc = "If the object will is going to sit outdoors, it should accumulate snow"
				},
				new MaterialVariable("World UV Y", "_MAPYWORLD", MaterialVariable.Type.Flag)
				{
					Desc = "Maps the y-coordinate to world coordinates so textures don't stretch when the object is scaled"
				},
				new MaterialVariable("Blink speed", "_Blink", 0)
				{
					Desc = "Masks any emission with noise to make it appear as if lights are blinking"
				},
				new MaterialVariable("Blink width", "_Blink", 1),
				new MaterialVariable("Blink height", "_Blink", 2)
			}
		},
		{
			"Atlas",
			new List<MaterialVariable>
			{
				new MaterialVariable("Texture", "_MainTex", MaterialVariable.Type.Texture),
				new MaterialVariable("Normal", "_BumpMap", MaterialVariable.Type.Texture)
				{
					ForceFlag = "_BUMPMAP"
				},
				new MaterialVariable("Normal factor", "_BumpScale", MaterialVariable.Type.Range),
				new MaterialVariable("Normal atlas x", "_BumpOffset", 0)
				{
					Desc = "You can change the scale of the normal map if you don't want it atlassed with the main texture"
				},
				new MaterialVariable("Normal atlas y", "_BumpOffset", 1)
				{
					Desc = "You can change the scale of the normal map if you don't want it atlassed with the main texture"
				},
				new MaterialVariable("Smoothness", "_Glossiness", MaterialVariable.Type.Range),
				new MaterialVariable("Metallic", "_Metallic", MaterialVariable.Type.Range),
				new MaterialVariable("Emission factor", "_EmissionFactor", MaterialVariable.Type.Range),
				new MaterialVariable("Map RGB", "_RGBMAP", MaterialVariable.Type.Flag)
				{
					Desc = "RGB colors are mapped to the player's choices like the standard shader"
				}
			}
		},
		{
			"Masked",
			new List<MaterialVariable>
			{
				new MaterialVariable("Texture", "_MainTex", MaterialVariable.Type.Texture),
				new MaterialVariable("Holographic", "_HOLO", MaterialVariable.Type.Flag)
				{
					Desc = "Changes the color of the material based on viewing angle"
				}
			}
		},
		{
			"Unity",
			new List<MaterialVariable>
			{
				new MaterialVariable("Color", "_Color", MaterialVariable.Type.Color),
				new MaterialVariable("Texture", "_MainTex", MaterialVariable.Type.Texture),
				new MaterialVariable("Smoothness", "_Glossiness", MaterialVariable.Type.Range),
				new MaterialVariable("Metallic", "_Metallic", MaterialVariable.Type.Range),
				new MaterialVariable("Metal gloss map", "_MetallicGlossMap", MaterialVariable.Type.Texture),
				new MaterialVariable("Metal gloss channel", "_SmoothnessTextureChannel", MaterialVariable.Type.Toggle),
				new MaterialVariable("Normal", "_BumpMap", MaterialVariable.Type.Texture)
				{
					ForceFlag = "_NORMALMAP"
				},
				new MaterialVariable("Normal factor", "_BumpScale", MaterialVariable.Type.Range),
				new MaterialVariable("Emission", "_EMISSION", MaterialVariable.Type.Flag),
				new MaterialVariable("Emission color", "_EmissionColor", MaterialVariable.Type.Color),
				new MaterialVariable("Emission map", "_EmissionMap", MaterialVariable.Type.Texture),
				new MaterialVariable("Occlusion", "_OcclusionMap", MaterialVariable.Type.Texture),
				new MaterialVariable("Occlusion strength", "_OcclusionStrength", MaterialVariable.Type.Range)
			}
		}
	};

	private bool _isDragging;

	private Vector3 _lastMPos;

	public static void SaveMaterials(List<Material> mats, FurnitureMod mod)
	{
		TydTable tydTable = new TydTable("Materials");
		foreach (Material mat in mats)
		{
			if (mat != ObjectDatabase.Instance.CombineFurnitureMaterial && !ObjectDatabase.Instance.ModMats.Contains(mat))
			{
				KeyValuePair<string, Material> keyValuePair = ObjectDatabase.Instance.FurnitureMaterialTypes.First((KeyValuePair<string, Material> x) => x.Value.shader == mat.shader);
				SaveMat(mat, keyValuePair.Key, tydTable, keyValuePair.Value, mod.Root);
			}
		}
		File.WriteAllText(Path.Combine(mod.Root, "materials.tyd"), TydToText.Write(tydTable, true));
	}

	private static void SaveMat(Material mat, string shader, TydTable root, Material originalMat, string path)
	{
		TydTable root2 = root.AddChild(new TydTable(mat.name, new TydString("Type", shader)));
		foreach (MaterialVariable item in _Variables[shader])
		{
			switch (item.VarType)
			{
			case MaterialVariable.Type.Texture:
			{
				Texture texture = mat.GetTexture(item.Target);
				if (texture != null && File.Exists(Path.Combine(path, texture.name)))
				{
					(root2.FindNode("Textures", true) as TydTable).AddChild(new TydString(item.Target, texture.name));
					if (item.ForceFlag == null)
					{
						break;
					}
					if (!originalMat.IsKeywordEnabled(item.Target))
					{
						(root2.FindNode("Keywords", true) as TydTable).SetNode(item.ForceFlag, "True", true);
						break;
					}
					TydTable obj2 = root2.FindNode("Keywords") as TydTable;
					if (obj2 != null)
					{
						obj2.RemoveNode(item.ForceFlag);
					}
				}
				else
				{
					if (item.ForceFlag == null)
					{
						break;
					}
					if (originalMat.IsKeywordEnabled(item.Target))
					{
						(root2.FindNode("Keywords", true) as TydTable).SetNode(item.ForceFlag, "False", true);
						break;
					}
					TydTable obj3 = root2.FindNode("Keywords") as TydTable;
					if (obj3 != null)
					{
						obj3.RemoveNode(item.ForceFlag);
					}
				}
				break;
			}
			case MaterialVariable.Type.Float:
			case MaterialVariable.Type.Range:
			case MaterialVariable.Type.Toggle:
			{
				float num = mat.GetFloat(item.Target);
				if (num != originalMat.GetFloat(item.Target))
				{
					(root2.FindNode("Floats", true) as TydTable).AddChild(new TydString(item.Target, num.ToString()));
				}
				break;
			}
			case MaterialVariable.Type.Color:
			{
				Color color = mat.GetColor(item.Target);
				if (color != originalMat.GetColor(item.Target))
				{
					(root2.FindNode("Colors", true) as TydTable).AddChild(new TydString(item.Target, ColorUtility.ToHtmlStringRGB(color)));
				}
				break;
			}
			case MaterialVariable.Type.Flag:
			{
				bool flag = mat.IsKeywordEnabled(item.Target);
				if (flag != originalMat.IsKeywordEnabled(item.Target))
				{
					(root2.FindNode("Keywords", true) as TydTable).SetNode(item.Target, flag.ToString(), true);
					break;
				}
				TydTable obj = root2.FindNode("Keywords") as TydTable;
				if (obj != null)
				{
					obj.RemoveNode(item.Target);
				}
				break;
			}
			case MaterialVariable.Type.Vector:
			{
				Vector4 vector = mat.GetVector(item.Target);
				if (vector != originalMat.GetVector(item.Target))
				{
					(root2.FindNode("Vectors", true) as TydTable).SetNode(item.Target, vector.ToTyd(item.Target));
				}
				break;
			}
			}
		}
	}

	public void Init()
	{
		if (_init)
		{
			return;
		}
		_init = true;
		foreach (Material material in FurnitureModdingTool.Instance.Materials)
		{
			if (material != ObjectDatabase.Instance.CombineFurnitureMaterial && !ObjectDatabase.Instance.ModMats.Contains(material))
			{
				AddButton(material);
			}
		}
	}

	private void AddButton(Material mat)
	{
		Button button = Object.Instantiate(ButtonPrefab);
		button.GetComponentInChildren<Text>().text = mat.name;
		button.onClick.AddListener(delegate
		{
			SelectMaterial(mat);
		});
		button.transform.SetParent(MaterialPanel, false);
		_buttons[mat] = button;
	}

	public void ChangeShader()
	{
		if (!(_activeMat != null))
		{
			return;
		}
		List<KeyValuePair<string, Material>> shaders = ObjectDatabase.Instance.FurnitureMaterialTypes.ToList();
		WindowManager.Instance.MultiWindow.Show("Shader", shaders.Select((KeyValuePair<string, Material> x) => x.Key), delegate(int x)
		{
			string key = shaders.First((KeyValuePair<string, Material> z) => z.Value.shader == _activeMat.shader).Key;
			_activeMat.shader = shaders[x].Value.shader;
			FixFlags(_activeMat, key, shaders[x].Key);
			ShaderLabel.text = shaders[x].Key;
			SelectMaterial(_activeMat);
		}, false);
	}

	private void FixFlags(Material mat, string oldShader, string newShader)
	{
		foreach (MaterialVariable item in _Variables[oldShader])
		{
			if (item.ForceFlag != null)
			{
				mat.DisableKeyword(item.ForceFlag);
			}
			else if (item.VarType == MaterialVariable.Type.Flag)
			{
				mat.DisableKeyword(item.Target);
			}
		}
		foreach (MaterialVariable item2 in _Variables[newShader])
		{
			if (item2.ForceFlag != null && mat.GetTexture(item2.Target) != null)
			{
				mat.EnableKeyword(item2.ForceFlag);
			}
		}
	}

	public static void ConvertUnityNormal(string file)
	{
		Texture2D texture2D = new Texture2D(1, 1, TextureFormat.ARGB32, false, true);
		texture2D.LoadImage(File.ReadAllBytes(file));
		Color32[] pixels = texture2D.GetPixels32();
		for (int i = 0; i < pixels.Length; i++)
		{
			pixels[i] = new Color32(byte.MaxValue, pixels[i].g, byte.MaxValue, pixels[i].r);
		}
		texture2D.SetPixels32(pixels);
		texture2D.Apply(false);
		File.WriteAllBytes(file, texture2D.EncodeToPNG());
		Object.Destroy(texture2D);
	}

	public void SelectMaterial(Material mat)
	{
		_activeMat = mat;
		int childCount = PropertyPanel.childCount;
		for (int i = 5; i < childCount; i++)
		{
			Object.Destroy(PropertyPanel.GetChild(i).gameObject);
		}
		if (!(mat != null))
		{
			return;
		}
		NameField.text = mat.name;
		string key = ObjectDatabase.Instance.FurnitureMaterialTypes.First((KeyValuePair<string, Material> x) => x.Value.shader == mat.shader).Key;
		ShaderLabel.text = key;
		PreviewBall.sharedMaterial = mat;
		List<MaterialVariable> value;
		if (!_Variables.TryGetValue(key, out value))
		{
			return;
		}
		foreach (MaterialVariable prop in value)
		{
			switch (prop.VarType)
			{
			case MaterialVariable.Type.Texture:
			{
				MakeLabel(prop);
				GameObject obj = Object.Instantiate(TwoButtonPrefab);
				Button[] componentsInChildren = obj.GetComponentsInChildren<Button>();
				Text t = componentsInChildren[0].GetComponentInChildren<Text>();
				Texture texture = _activeMat.GetTexture(prop.Target);
				t.text = ((texture != null) ? texture.name : "[NULL]");
				componentsInChildren[1].onClick.AddListener(delegate
				{
					Texture texture2 = _activeMat.GetTexture(prop.Target);
					FurnitureMod activeMod = FurnitureModdingTool.Instance.ActiveMod;
					string path = Path.Combine(activeMod.Root, texture2.name);
					if (texture2 != null && File.Exists(path))
					{
						Texture2D texture2D = new Texture2D(1, 1);
						texture2D.LoadImage(File.ReadAllBytes(path));
						texture2D.name = texture2.name;
						FurnitureModdingTool.Instance.Textures.Remove(texture2);
						activeMod.Textures.Remove(texture2);
						FurnitureModdingTool.Instance.Textures.Add(texture2D);
						activeMod.Textures.Add(texture2D);
						Object.Destroy(texture2);
						_activeMat.SetTexture(prop.Target, texture2D);
					}
				});
				componentsInChildren[0].onClick.AddListener(delegate
				{
					WindowManager.Instance.MultiWindow.Show("Texture", FurnitureModdingTool.Instance.Textures.Select((Texture2D x) => x.name), delegate(int num)
					{
						Texture2D texture2D = ((num >= 0) ? FurnitureModdingTool.Instance.Textures[num] : null);
						_activeMat.SetTexture(prop.Target, texture2D);
						t.text = ((texture2D != null) ? texture2D.name : "[NULL]");
						if (prop.ForceFlag != null)
						{
							if (texture2D != null)
							{
								_activeMat.EnableKeyword(prop.ForceFlag);
							}
							else
							{
								_activeMat.DisableKeyword(prop.ForceFlag);
							}
						}
					}, true);
				});
				obj.transform.SetParent(PropertyPanel, false);
				break;
			}
			case MaterialVariable.Type.Float:
			{
				MakeLabel(prop);
				InputField i3 = Object.Instantiate(InputPrefab);
				i3.contentType = InputField.ContentType.DecimalNumber;
				i3.text = _activeMat.GetFloat(prop.Target).ToString();
				i3.onEndEdit.AddListener(delegate
				{
					float value2 = i3.text.ConvertToFloatDef(_activeMat.GetFloat(prop.Target));
					_activeMat.SetFloat(prop.Target, value2);
					i3.text = value2.ToString();
				});
				i3.transform.SetParent(PropertyPanel, false);
				break;
			}
			case MaterialVariable.Type.Range:
			{
				MakeLabel(prop);
				Slider slider = Object.Instantiate(SliderPrefab);
				slider.value = _activeMat.GetFloat(prop.Target);
				slider.onValueChanged.AddListener(delegate(float x)
				{
					_activeMat.SetFloat(prop.Target, x);
				});
				slider.transform.SetParent(PropertyPanel, false);
				break;
			}
			case MaterialVariable.Type.Toggle:
			{
				MakeLabel(prop);
				Toggle toggle2 = Object.Instantiate(TogglePrefab);
				toggle2.isOn = _activeMat.GetFloat(prop.Target) > 0.5f;
				toggle2.onValueChanged.AddListener(delegate(bool x)
				{
					_activeMat.SetFloat(prop.Target, x ? 1 : 0);
				});
				toggle2.transform.SetParent(PropertyPanel, false);
				break;
			}
			case MaterialVariable.Type.Flag:
			{
				MakeLabel(prop);
				Toggle toggle = Object.Instantiate(TogglePrefab);
				toggle.isOn = _activeMat.IsKeywordEnabled(prop.Target);
				toggle.onValueChanged.AddListener(delegate(bool x)
				{
					if (x)
					{
						_activeMat.EnableKeyword(prop.Target);
					}
					else
					{
						_activeMat.DisableKeyword(prop.Target);
					}
				});
				toggle.transform.SetParent(PropertyPanel, false);
				break;
			}
			case MaterialVariable.Type.Vector:
				if (prop.VectorIndex > -1)
				{
					MakeLabel(prop);
					InputField i2 = Object.Instantiate(InputPrefab);
					i2.contentType = InputField.ContentType.DecimalNumber;
					i2.text = GetComp(_activeMat.GetVector(prop.Target), prop.VectorIndex).ToString();
					i2.onEndEdit.AddListener(delegate
					{
						Vector4 vector = _activeMat.GetVector(prop.Target);
						float val = i2.text.ConvertToFloatDef(GetComp(vector, prop.VectorIndex));
						_activeMat.SetVector(prop.Target, SetComp(vector, prop.VectorIndex, val));
						i2.text = val.ToString();
					});
					i2.transform.SetParent(PropertyPanel, false);
				}
				break;
			case MaterialVariable.Type.Color:
			{
				MakeLabel(prop);
				Button button = Object.Instantiate(ButtonPrefab);
				Object.Destroy(button.GetComponentInChildren<Text>().gameObject);
				Image img = button.GetComponent<Image>();
				img.color = _activeMat.GetColor(prop.Target);
				button.onClick.AddListener(delegate
				{
					WindowManager.SpawnColorDialog(delegate(Color col)
					{
						_activeMat.SetColor(prop.Target, col);
						img.color = col;
					}, _activeMat.GetColor(prop.Target));
				});
				button.transform.SetParent(PropertyPanel, false);
				break;
			}
			}
		}
	}

	private float GetComp(Vector4 v, int i)
	{
		switch (i)
		{
		case 0:
			return v.x;
		case 1:
			return v.y;
		case 2:
			return v.z;
		case 3:
			return v.w;
		default:
			return 0f;
		}
	}

	private Vector4 SetComp(Vector4 v, int i, float val)
	{
		switch (i)
		{
		case 0:
			return new Vector4(val, v.y, v.z, v.w);
		case 1:
			return new Vector4(v.x, val, v.z, v.w);
		case 2:
			return new Vector4(v.x, v.y, val, v.w);
		case 3:
			return new Vector4(v.x, v.y, v.z, val);
		default:
			return v;
		}
	}

	private void MakeLabel(MaterialVariable var)
	{
		Text text = Object.Instantiate(LabelPrefab);
		text.text = var.Name;
		if (var.Desc != null)
		{
			GUIToolTipper gUIToolTipper = text.gameObject.AddComponent<GUIToolTipper>();
			gUIToolTipper.Localize = false;
			gUIToolTipper.TooltipDescription = var.Desc;
		}
		text.transform.SetParent(PropertyPanel, false);
	}

	public void StartDragPrev()
	{
		_isDragging = true;
		_lastMPos = Input.mousePosition;
	}

	private void Update()
	{
		if (_isDragging)
		{
			Vector3 vector = _lastMPos - Input.mousePosition;
			PreviewBall.transform.rotation = Quaternion.Euler(0f - vector.y, vector.x, 0f) * PreviewBall.transform.rotation;
			_lastMPos = Input.mousePosition;
			if (Input.GetMouseButtonUp(0))
			{
				_isDragging = false;
			}
		}
	}

	public void AddMaterial()
	{
		Material material = new Material(ObjectDatabase.Instance.CombineFurnitureMaterial);
		material.name = "NewMaterial";
		FurnitureModdingTool.Instance.Materials.Add(material);
		AddButton(material);
		SelectMaterial(material);
	}

	public void DeleteMaterial()
	{
		if (!(_activeMat != null))
		{
			return;
		}
		Material m = _activeMat;
		SelectMaterial(null);
		if (FurnitureModdingTool.Instance.ActiveObject != null)
		{
			Material st = ObjectDatabase.Instance.CombineFurnitureMaterial;
			FurnitureModdingTool.Instance.ActiveObject.GetComponentsInChildren<MeshRenderer>().ForEachEnum(delegate(MeshRenderer x)
			{
				FixMat(x, m, st);
			});
			FurnitureModdingTool.Instance.CurrentMeta.OfType<FurnMeshMeta>().ForEachEnum(delegate(FurnMeshMeta x)
			{
				FixMat(ref x.Material, m, st);
			});
		}
		FurnitureModdingTool.Instance.Materials.Remove(m);
		Object.Destroy(_buttons[m].gameObject);
		Object.Destroy(m);
	}

	private void FixMat(ref Material mat, Material prev, Material next)
	{
		if (mat == prev)
		{
			mat = next;
		}
	}

	private void FixMat(Renderer rend, Material prev, Material next)
	{
		if (rend.sharedMaterial == prev)
		{
			rend.sharedMaterial = next;
		}
	}

	public void OnNameChange()
	{
		if (_activeMat != null)
		{
			_activeMat.name = NameField.text;
			_buttons[_activeMat].GetComponentInChildren<Text>().text = NameField.text;
		}
	}

	private void Start()
	{
		Window.OnClose = delegate
		{
			Shader.SetGlobalFloat("_Snow", 0f);
			ThumbCam.SetActive(false);
		};
	}

	public void Show()
	{
		Shader.SetGlobalFloat("_Snow", 1f);
		Init();
		ThumbCam.SetActive(true);
		Window.Show();
	}

	public void ChangePreview()
	{
		_currentMesh = (_currentMesh + 1) % PreviewMeshes.Length;
		BallMesh.sharedMesh = PreviewMeshes[_currentMesh];
		BallMesh.transform.localScale = Vector3.one * PreviewScales[_currentMesh];
	}
}
