using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SDFEditor : MaskableGraphic, ILayoutElement, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, ICursorOverride, IScrollHandler
{
	public const int SDFLimit = 25;

	public SDFNode NodePrefab;

	public RawImage Preview;

	public GameObject NoPreview;

	public GameObject CopyPastePanel;

	public InputField PasteInput;

	public RectTransform NodePanel;

	public RectTransform NodeRect;

	public RectTransform CreationPanel;

	public RectTransform FinalConnector;

	public RectTransform NodeLine;

	public Color SDFColor;

	public Color RGBColor;

	public Color AllColor;

	[Header("Inspector")]
	public GUICombobox ShapeCombo;

	[Header("Inspector")]
	public GUICombobox CombinationCombo;

	[Header("Inspector")]
	public GUICombobox ResourceCombo;

	public PositioningTool PosTool;

	public GUIWindow ParentWindow;

	public Slider Scale;

	public Slider Scale2;

	public Slider Rotation;

	public Slider CombinationSmoothness;

	public Slider Rounding;

	public Slider Subtraction;

	public Slider ColorThreshold;

	public Slider ColorOutline;

	public Slider GradientRotation;

	public Slider Distortion;

	public Slider MirrorTimes;

	public Slider MirrorAngle;

	public Slider MirrorOffset;

	public Slider WaveXAmount;

	public Slider WaveYAmount;

	public Slider WaveXFreq;

	public Slider WaveYFreq;

	public Slider SkewX;

	public Slider SkewY;

	public Toggle GradientLinear;

	public Toggle FlipX;

	public Toggle FlipY;

	public Slider[] Parameters;

	public Button[] CreateButtons;

	public Text LimitLabel;

	public Image MainColor;

	public Image OutlineColor;

	public Image GradientColor;

	public int? DirtyRend;

	public int DirtyAmount;

	public bool DirtyMain;

	public Vector2? _lastMax;

	public string ForceGen;

	[NonSerialized]
	public List<SDFNode> Nodes = new List<SDFNode>();

	[NonSerialized]
	private float _prefWidth;

	[NonSerialized]
	private float _prefHeight;

	public float ConnectionLineWidth = 4f;

	[NonSerialized]
	private int _lastRender;

	[NonSerialized]
	public SDFNode ActiveNode;

	[NonSerialized]
	public SDFNode FinalNode;

	[NonSerialized]
	private RenderTexture _preview;

	private static bool _isUploadingLogo = false;

	private static List<float> _uploadedLogos = new List<float>();

	[NonSerialized]
	private bool _disableInspector;

	[CompilerGenerated]
	private readonly float _003CminWidth_003Ek__BackingField;

	[CompilerGenerated]
	private readonly float _003CflexibleWidth_003Ek__BackingField;

	[CompilerGenerated]
	private readonly float _003CminHeight_003Ek__BackingField;

	[CompilerGenerated]
	private readonly float _003CflexibleHeight_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003ClayoutPriority_003Ek__BackingField;

	public float minWidth
	{
		[CompilerGenerated]
		get
		{
			return _003CminWidth_003Ek__BackingField;
		}
	}

	public float preferredWidth
	{
		get
		{
			return _prefWidth;
		}
	}

	public float flexibleWidth
	{
		[CompilerGenerated]
		get
		{
			return _003CflexibleWidth_003Ek__BackingField;
		}
	}

	public float minHeight
	{
		[CompilerGenerated]
		get
		{
			return _003CminHeight_003Ek__BackingField;
		}
	}

	public float preferredHeight
	{
		get
		{
			return _prefHeight;
		}
	}

	public float flexibleHeight
	{
		[CompilerGenerated]
		get
		{
			return _003CflexibleHeight_003Ek__BackingField;
		}
	}

	public int layoutPriority
	{
		[CompilerGenerated]
		get
		{
			return _003ClayoutPriority_003Ek__BackingField;
		}
	}

	public string CursorOverrideName
	{
		get
		{
			return null;
		}
	}

	protected override void OnDestroy()
	{
		if (_preview != null)
		{
			Preview.texture = null;
			UnityEngine.Object.Destroy(_preview);
		}
	}

	public SDFNode CreateNode(SDFCreator.ISDFNode node)
	{
		SDFNode sDFNode = UnityEngine.Object.Instantiate(NodePrefab);
		sDFNode.Init(node, this);
		sDFNode.Self.SetParent(NodePanel, false);
		Nodes.Add(sDFNode);
		MakeDirty(sDFNode);
		UpdateLimit();
		return sDFNode;
	}

	public void MakeDirty(SDFNode node)
	{
		if (node != null)
		{
			int num = Nodes.IndexOf(node);
			if (num == -1)
			{
				num = 0;
			}
			DirtyRend = num;
			DirtyAmount = Nodes.Count;
			DirtyMain = true;
		}
	}

	public SDFNode CreateTree(SDFCreator.ISDFNode current, bool start, Dictionary<SDFCreator.ISDFNode, SDFNode> existing)
	{
		SDFNode sDFNode = (existing[current] = CreateNode(current));
		int num = 0;
		foreach (SDFCreator.ISDFNode child in current.GetChildren())
		{
			if (child != null)
			{
				SDFNode value;
				if (!existing.TryGetValue(child, out value))
				{
					value = CreateTree(child, start, existing);
				}
				value.ConnectTo(sDFNode, num);
			}
			num++;
		}
		if (start)
		{
			if (current is SDFCreator.ISDFOutput)
			{
				FinalNode = sDFNode;
			}
			Dictionary<SDFNode, int> layers = new Dictionary<SDFNode, int> { { sDFNode, 0 } };
			Dictionary<int, List<SDFNode>> dictionary = new Dictionary<int, List<SDFNode>>();
			foreach (SDFNode value2 in existing.Values)
			{
				dictionary.Append(GetLayer(value2, layers), value2);
			}
			int num2 = dictionary.MaxSafeInt((KeyValuePair<int, List<SDFNode>> x) => x.Value.Count);
			int num3 = dictionary.Keys.Max();
			foreach (KeyValuePair<int, List<SDFNode>> item in dictionary)
			{
				int num4 = (num2 - item.Value.Count) * 148 / 2;
				int num5 = (num3 - item.Key) * 256 + 74;
				for (int num6 = 0; num6 < item.Value.Count; num6++)
				{
					SDFNode sDFNode3 = item.Value[num6];
					sDFNode3.Self.anchoredPosition = new Vector2(num5, -num6 * 148 - 74 - num4);
					sDFNode3.ImprintPos();
				}
			}
			SetAllDirty();
		}
		UpdatePreview();
		return sDFNode;
	}

	private int GetLayer(SDFNode n, Dictionary<SDFNode, int> layers)
	{
		int value;
		if (!layers.TryGetValue(n, out value))
		{
			return layers[n] = n.Outputs.MaxSafeInt((SDFNode x) => GetLayer(x, layers), 0) + 1;
		}
		return value;
	}

	public void Clear(bool user = false)
	{
		if (user)
		{
			DialogWindow dialogWindow = WindowManager.Instance.ShowMessageBox("LogoDeletePrompt".Loc(), true, DialogWindow.DialogType.Question, ActualClear);
			if (ParentWindow != null)
			{
				dialogWindow.Window.SetParentWindow(ParentWindow);
			}
		}
		else
		{
			ActualClear();
		}
	}

	private void ActualClear()
	{
		Nodes.ForEach(delegate(SDFNode x)
		{
			UnityEngine.Object.Destroy(x.gameObject);
		});
		Nodes.Clear();
		UpdateLimit();
	}

	public void Generate()
	{
		DialogWindow dialogWindow = WindowManager.Instance.ShowMessageBox("LogoDeletePrompt".Loc(), true, DialogWindow.DialogType.Question, delegate
		{
			Clear();
			SDFCreator.SDFRandomNode randomTree = SDFCreator.Instance.GetRandomTree("Final");
			CreateTree(randomTree.Generate(), true, new Dictionary<SDFCreator.ISDFNode, SDFNode>());
		});
		if (ParentWindow != null)
		{
			dialogWindow.Window.SetParentWindow(ParentWindow);
		}
	}

	public void Load()
	{
	}

	public void LoadLogo(SDFCreator.ISDFNode root)
	{
		Clear();
		if (root != null)
		{
			CreateTree(root, true, new Dictionary<SDFCreator.ISDFNode, SDFNode>());
		}
	}

	public void OpenCopyPastePanel()
	{
		if (FinalNode != null && FinalNode.Node.IsValid())
		{
			PasteInput.text = SDFCreator.GetTreeString(SDFCreator.SerializeTree(FinalNode.Node));
		}
		else
		{
			PasteInput.text = "";
		}
		CopyPastePanel.SetActive(true);
	}

	public void PasteToPanel()
	{
		PasteInput.text = GUIUtility.systemCopyBuffer;
		LoadCode();
	}

	public void CopyCode()
	{
		GUIUtility.systemCopyBuffer = PasteInput.text;
		CopyPastePanel.SetActive(false);
	}

	public void LoadCode()
	{
		SDFCreator.ISDFNode current;
		try
		{
			current = SDFCreator.LoadSDFTree(SDFCreator.GetTreeFromString(PasteInput.text));
		}
		catch (Exception)
		{
			WindowManager.Instance.ShowMessageBox("LogoCodeError".Loc(), true, DialogWindow.DialogType.Error);
			return;
		}
		CopyPastePanel.SetActive(false);
		Clear();
		CreateTree(current, true, new Dictionary<SDFCreator.ISDFNode, SDFNode>());
	}

	public void SaveToImage()
	{
		if (!(FinalNode != null) || !FinalNode.Node.IsValid())
		{
			return;
		}
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Software Inc Logo");
		string uniqueImageName = GetUniqueImageName(text, "Logo");
		try
		{
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			Texture2D texture2D = SDFCreator.EncodeInTexture(FinalNode.Node);
			File.WriteAllBytes(uniqueImageName, texture2D.EncodeToPNG());
			UnityEngine.Object.Destroy(texture2D);
			WindowManager.Instance.ShowMessageBox("Saved to: " + uniqueImageName, true, DialogWindow.DialogType.Information);
		}
		catch (Exception)
		{
			try
			{
				text = Path.GetFullPath("");
				uniqueImageName = GetUniqueImageName(text, "Logo");
				Texture2D texture2D2 = SDFCreator.EncodeInTexture(FinalNode.Node);
				File.WriteAllBytes(uniqueImageName, texture2D2.EncodeToPNG());
				UnityEngine.Object.Destroy(texture2D2);
				WindowManager.Instance.ShowMessageBox("Saved to: " + uniqueImageName, true, DialogWindow.DialogType.Information);
			}
			catch (Exception ex2)
			{
				WindowManager.Instance.ShowMessageBox("Failed saving file: " + ex2.Message, true, DialogWindow.DialogType.Information);
			}
		}
	}

	public void UploadLogo()
	{
		if (!(FinalNode != null) || !FinalNode.Node.IsValid())
		{
			return;
		}
		string logo = SDFCreator.GetTreeString(SDFCreator.SerializeTree(FinalNode.Node));
		WindowManager.SpawnInputDialog("EnterName".Loc(), "Logo".Loc(), "", delegate(string name)
		{
			if (!string.IsNullOrWhiteSpace(name.Replace("|", "")))
			{
				StartCoroutine(UploadLogo(logo, name, delegate(string x)
				{
					if (x == null)
					{
						WindowManager.Instance.ShowMessageBox("Uploaded".Loc(), true, DialogWindow.DialogType.Information, ParentWindow);
					}
					else
					{
						WindowManager.Instance.ShowMessageBox("Error".Loc(), true, DialogWindow.DialogType.Error, ParentWindow);
						Debug.Log("Failed uploading logo:\n" + x);
					}
				}));
			}
		}, null, 64);
	}

	private static bool CheckCanUploadLogo()
	{
		for (int i = 0; i < _uploadedLogos.Count; i++)
		{
			if (Time.realtimeSinceStartup - _uploadedLogos[i] > 60f)
			{
				_uploadedLogos.RemoveAt(i);
				i--;
			}
		}
		return _uploadedLogos.Count < 10;
	}

	public static IEnumerator UploadLogo(string logo, string name, Action<string> callback)
	{
		if (_isUploadingLogo)
		{
			callback("Already uploading a logo");
			yield break;
		}
		if (!CheckCanUploadLogo())
		{
			callback("Can only upload 10 logos per minute");
			yield break;
		}
		logo = SDFDownloader.ReloadTree(SDFDownloader.ReloadTree(SDFDownloader.ReloadTree(logo)));
		if (logo.Length > 1023)
		{
			callback("Logo data is too long");
			yield break;
		}
		_isUploadingLogo = true;
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("logo", logo);
		wWWForm.AddField("name", name.Trim().Replace("\r", "").Replace("\n", "")
			.Replace("|", ""));
		Texture2D texture2D = null;
		RenderTexture renderTexture = null;
		RenderTexture active = RenderTexture.active;
		try
		{
			SDFCreator.ISDFNode iSDFNode = SDFCreator.LoadSDFTree(SDFCreator.GetTreeFromString(logo));
			renderTexture = RenderTexture.GetTemporary(64, 64);
			iSDFNode.Execute(64, renderTexture, Matrix4x4.identity);
			RenderTexture.active = renderTexture;
			texture2D = new Texture2D(64, 64, TextureFormat.ARGB32, false);
			texture2D.ReadPixels(new Rect(0f, 0f, 64f, 64f), 0, 0, false);
			texture2D.Apply(false);
			wWWForm.AddBinaryData("image_file", texture2D.EncodeToPNG());
		}
		catch (Exception ex)
		{
			Debug.Log(ex.ToString());
		}
		finally
		{
			if (texture2D != null)
			{
				UnityEngine.Object.Destroy(texture2D);
			}
			if (renderTexture != null)
			{
				RenderTexture.ReleaseTemporary(renderTexture);
			}
			RenderTexture.active = active;
		}
		UnityWebRequest www = UnityWebRequest.Post("https://SoftwareInc.Coredumping.com/logo/save.php", wWWForm);
		www.SetRequestHeader("User-Agent", "Swinc User Agent");
		yield return www.SendWebRequest();
		if (string.IsNullOrEmpty(www.error))
		{
			string text = www.downloadHandler.text;
			bool flag = !text.StartsWith("SUCCESS");
			if (!flag)
			{
				_uploadedLogos.Add(Time.realtimeSinceStartup);
			}
			callback(flag ? text : null);
		}
		else
		{
			callback(www.error);
		}
		_isUploadingLogo = false;
	}

	public void LoadFromImage()
	{
		string systemCopyBuffer = GUIUtility.systemCopyBuffer;
		if (File.Exists(systemCopyBuffer))
		{
			Texture2D texture2D = new Texture2D(256, 256, TextureFormat.ARGB32, false);
			texture2D.LoadImage(File.ReadAllBytes(systemCopyBuffer));
			SDFCreator.ISDFNode current = SDFCreator.DecodeFromTexture(texture2D);
			UnityEngine.Object.Destroy(texture2D);
			Clear();
			CreateTree(current, true, new Dictionary<SDFCreator.ISDFNode, SDFNode>());
		}
	}

	private string GetUniqueImageName(string folder, string name)
	{
		if (!Directory.Exists(folder))
		{
			return Path.Combine(folder, name + ".png");
		}
		string text = Path.Combine(folder, name + ".png");
		int num = 2;
		while (File.Exists(text))
		{
			text = Path.Combine(folder, name + num + ".png");
			num++;
		}
		return text;
	}

	public void Save()
	{
	}

	public void SetActive(SDFNode node)
	{
		if (node != ActiveNode && node != null)
		{
			UISoundFX.PlaySFX("Tick2");
		}
		if (ActiveNode != null)
		{
			ActiveNode.HeaderPanel.color = ActiveNode.Inactive;
		}
		ActiveNode = node;
		if (ActiveNode != null)
		{
			ActiveNode.HeaderPanel.color = ActiveNode.Active;
		}
		InitInspector();
	}

	private void InitInspector()
	{
		_disableInspector = true;
		ToggleTool(ShapeCombo.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Shape);
		ToggleTool(PosTool.transform, ActiveNode != null && (ActiveNode.Type == SDFCreator.NodeType.Shape || ActiveNode.Type == SDFCreator.NodeType.Transform || ActiveNode.Type == SDFCreator.NodeType.Mix || ActiveNode.Type == SDFCreator.NodeType.Color || ActiveNode.Type == SDFCreator.NodeType.Mirror || ActiveNode.Type == SDFCreator.NodeType.Reflect || ActiveNode.Type == SDFCreator.NodeType.Texture || ActiveNode.Type == SDFCreator.NodeType.Array));
		ToggleTool(Scale.transform, ActiveNode != null && (ActiveNode.Type == SDFCreator.NodeType.Shape || ActiveNode.Type == SDFCreator.NodeType.Transform || ActiveNode.Type == SDFCreator.NodeType.Mix || ActiveNode.Type == SDFCreator.NodeType.Color || ActiveNode.Type == SDFCreator.NodeType.Texture));
		ToggleTool(Rotation.transform, ActiveNode != null && (ActiveNode.Type == SDFCreator.NodeType.Shape || ActiveNode.Type == SDFCreator.NodeType.Transform || ActiveNode.Type == SDFCreator.NodeType.Mix || ActiveNode.Type == SDFCreator.NodeType.Reflect || ActiveNode.Type == SDFCreator.NodeType.Color || ActiveNode.Type == SDFCreator.NodeType.Texture || ActiveNode.Type == SDFCreator.NodeType.Array));
		ToggleTool(Rounding.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Shape);
		ToggleTool(Parameters[0].transform, false);
		ToggleTool(Parameters[1].transform, false);
		ToggleTool(Parameters[2].transform, false);
		ToggleTool(Parameters[3].transform, false);
		ToggleTool(CombinationCombo.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Combine);
		ToggleTool(CombinationSmoothness.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Combine);
		ToggleTool(Subtraction.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Effect);
		ToggleTool(Distortion.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Effect);
		ToggleTool(MainColor.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Color);
		ToggleTool(GradientColor.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Color);
		ToggleTool(OutlineColor.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Color);
		ToggleTool(ColorOutline.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Color);
		ToggleTool(ColorThreshold.transform, ActiveNode != null && (ActiveNode.Type == SDFCreator.NodeType.Color || ActiveNode.Type == SDFCreator.NodeType.Effect));
		ToggleTool(GradientRotation.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Color);
		ToggleTool(GradientLinear.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Color);
		ToggleTool(MirrorTimes.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Mirror);
		ToggleTool(MirrorAngle.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Mirror);
		ToggleTool(MirrorOffset.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Mirror);
		ToggleTool(FlipX.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Mirror);
		ToggleTool(FlipY.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Mirror);
		ToggleTool(ResourceCombo.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Texture);
		ToggleTool(WaveXAmount.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Effect);
		ToggleTool(WaveYAmount.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Effect);
		ToggleTool(WaveXFreq.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Effect);
		ToggleTool(WaveYFreq.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Effect);
		ToggleTool(SkewX.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Effect);
		ToggleTool(SkewY.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Effect);
		ToggleTool(Scale2.transform, ActiveNode != null && ActiveNode.Type == SDFCreator.NodeType.Array);
		if (ActiveNode != null)
		{
			switch (ActiveNode.Type)
			{
			case SDFCreator.NodeType.Shape:
			{
				SDFCreator.SDFShape sDFShape = (SDFCreator.SDFShape)ActiveNode.Node;
				ShapeCombo.SelectedItem = sDFShape.Function;
				PosTool.Position = sDFShape.Pos + Vector2.one * 0.5f;
				Scale.value = sDFShape.Scale.x;
				Rotation.value = sDFShape.Rotation;
				Rounding.value = sDFShape.Rounding;
				SDFCreator.ParameterInfo[] parameters = SDFCreator.GetParameters(sDFShape.Function);
				for (int i = 0; i < Parameters.Length; i++)
				{
					if (i < parameters.Length)
					{
						SDFCreator.ParameterInfo parameterInfo = parameters[i];
						Parameters[i].transform.parent.GetChild(Parameters[i].transform.GetSiblingIndex() - 1).GetComponent<Text>().text = parameterInfo.Name.Loc();
						ToggleTool(Parameters[i].transform, true);
						Parameters[i].minValue = parameterInfo.Min;
						Parameters[i].maxValue = parameterInfo.Max;
						Parameters[i].value = sDFShape.SDFParams[i];
					}
					else
					{
						ToggleTool(Parameters[i].transform, false);
					}
				}
				break;
			}
			case SDFCreator.NodeType.Effect:
			{
				SDFCreator.SDFEffect sDFEffect = (SDFCreator.SDFEffect)ActiveNode.Node;
				Subtraction.value = sDFEffect.Subtraction;
				Distortion.value = sDFEffect.Distortion;
				ColorThreshold.value = sDFEffect.Threshold;
				WaveXAmount.value = sDFEffect.WaveAmount.x;
				WaveYAmount.value = sDFEffect.WaveAmount.y;
				WaveXFreq.value = sDFEffect.WaveFrequency.x;
				WaveYFreq.value = sDFEffect.WaveFrequency.y;
				SkewX.value = sDFEffect.Skew.x;
				SkewY.value = sDFEffect.Skew.y;
				break;
			}
			case SDFCreator.NodeType.Combine:
			{
				SDFCreator.SDFCombine sDFCombine = (SDFCreator.SDFCombine)ActiveNode.Node;
				CombinationCombo.Selected = (int)sDFCombine.Function % 4;
				CombinationSmoothness.value = sDFCombine.Param;
				break;
			}
			case SDFCreator.NodeType.Color:
			{
				SDFCreator.SDFExport sDFExport = (SDFCreator.SDFExport)ActiveNode.Node;
				MainColor.color = sDFExport.MainColor;
				GradientColor.color = sDFExport.GradientColor;
				OutlineColor.color = sDFExport.OutlineColor;
				ColorOutline.value = sDFExport.Outline;
				ColorThreshold.value = sDFExport.Threshold;
				PosTool.Position = sDFExport.Pos + Vector2.one * 0.5f;
				Scale.value = sDFExport.Scale.x;
				Rotation.value = sDFExport.Rotation;
				GradientRotation.value = sDFExport.GradientRotation;
				GradientLinear.isOn = sDFExport.GradientLinear;
				break;
			}
			case SDFCreator.NodeType.Transform:
			{
				SDFCreator.SDFTransform sDFTransform = (SDFCreator.SDFTransform)ActiveNode.Node;
				PosTool.Position = sDFTransform.Pos + Vector2.one * 0.5f;
				Scale.value = sDFTransform.Scale.x;
				Rotation.value = sDFTransform.Rotation;
				break;
			}
			case SDFCreator.NodeType.Mix:
			{
				SDFCreator.SDFMix sDFMix = (SDFCreator.SDFMix)ActiveNode.Node;
				PosTool.Position = sDFMix.Pos + Vector2.one * 0.5f;
				Scale.value = sDFMix.Scale.x;
				Rotation.value = sDFMix.Rotation;
				break;
			}
			case SDFCreator.NodeType.Mirror:
			{
				SDFCreator.SDFMirror sDFMirror = (SDFCreator.SDFMirror)ActiveNode.Node;
				PosTool.Position = sDFMirror.Pos;
				MirrorTimes.value = sDFMirror.Times;
				MirrorAngle.value = sDFMirror.Angle;
				MirrorOffset.value = sDFMirror.Offset;
				FlipX.isOn = sDFMirror.FlipX;
				FlipY.isOn = sDFMirror.FlipY;
				break;
			}
			case SDFCreator.NodeType.Reflect:
			{
				SDFCreator.SDFReflect sDFReflect = (SDFCreator.SDFReflect)ActiveNode.Node;
				PosTool.Position = sDFReflect.Pos;
				Rotation.value = sDFReflect.Angle;
				break;
			}
			case SDFCreator.NodeType.Texture:
			{
				SDFCreator.SDFTexture sDFTexture = (SDFCreator.SDFTexture)ActiveNode.Node;
				ResourceCombo.SelectedItem = sDFTexture.SDFResource;
				PosTool.Position = sDFTexture.Pos + Vector2.one * 0.5f;
				Scale.value = sDFTexture.Scale.x;
				Rotation.value = sDFTexture.Rotation;
				break;
			}
			case SDFCreator.NodeType.Array:
			{
				SDFCreator.SDFArray sDFArray = (SDFCreator.SDFArray)ActiveNode.Node;
				PosTool.Position = sDFArray.Pos + Vector2.one * 0.5f;
				Scale2.value = 1f / sDFArray.Scale.x;
				Rotation.value = sDFArray.Rotation;
				break;
			}
			}
		}
		_disableInspector = false;
	}

	public void ChangeMainColor()
	{
		if (_disableInspector)
		{
			return;
		}
		SDFNode activeNode = ActiveNode;
		SDFCreator.SDFExport n;
		if ((n = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFExport) != null)
		{
			ColorWindow colorWindow = WindowManager.SpawnColorDialog(delegate(Color x)
			{
				MainColor.color = x;
				n.MainColor = x;
				MakeDirty(ActiveNode);
			}, n.MainColor);
			if (ParentWindow != null)
			{
				colorWindow.Window.SetParentWindow(ParentWindow, true);
				colorWindow.Window.HideBlockPanel = false;
			}
		}
	}

	public void ReverseColor()
	{
		if (!_disableInspector)
		{
			SDFNode activeNode = ActiveNode;
			SDFCreator.SDFExport sDFExport;
			if ((sDFExport = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFExport) != null)
			{
				Image mainColor = MainColor;
				Image gradientColor = GradientColor;
				Color color = GradientColor.color;
				Color color2 = MainColor.color;
				Color color3 = (mainColor.color = color);
				color3 = (gradientColor.color = color2);
				SDFCreator.SDFExport sDFExport2 = sDFExport;
				SDFCreator.SDFExport sDFExport3 = sDFExport;
				color2 = sDFExport.GradientColor;
				color = sDFExport.MainColor;
				sDFExport2.MainColor = color2;
				sDFExport3.GradientColor = color;
				MakeDirty(ActiveNode);
			}
		}
	}

	public void ChangeGradientColor()
	{
		if (_disableInspector)
		{
			return;
		}
		SDFNode activeNode = ActiveNode;
		SDFCreator.SDFExport n;
		if ((n = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFExport) != null)
		{
			ColorWindow colorWindow = WindowManager.SpawnColorDialog(delegate(Color x)
			{
				GradientColor.color = x;
				n.GradientColor = x;
				MakeDirty(ActiveNode);
			}, n.GradientColor);
			if (ParentWindow != null)
			{
				colorWindow.Window.SetParentWindow(ParentWindow, true);
				colorWindow.Window.HideBlockPanel = false;
			}
		}
	}

	public void ChangeOutlineColor()
	{
		if (_disableInspector)
		{
			return;
		}
		SDFNode activeNode = ActiveNode;
		SDFCreator.SDFExport n;
		if ((n = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFExport) != null)
		{
			ColorWindow colorWindow = WindowManager.SpawnColorDialog(delegate(Color x)
			{
				OutlineColor.color = x;
				n.OutlineColor = x;
				MakeDirty(ActiveNode);
			}, n.OutlineColor);
			if (ParentWindow != null)
			{
				colorWindow.Window.SetParentWindow(ParentWindow, true);
				colorWindow.Window.HideBlockPanel = false;
			}
		}
	}

	public void ColorThresholdChanged()
	{
		if (!_disableInspector)
		{
			SDFNode activeNode = ActiveNode;
			SDFCreator.SDFExport sDFExport;
			if ((sDFExport = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFExport) != null)
			{
				sDFExport.Threshold = ColorThreshold.value;
			}
			SDFNode activeNode2 = ActiveNode;
			SDFCreator.SDFEffect sDFEffect;
			if ((sDFEffect = (((object)activeNode2 != null) ? activeNode2.Node : null) as SDFCreator.SDFEffect) != null)
			{
				sDFEffect.Threshold = ColorThreshold.value;
			}
			MakeDirty(ActiveNode);
		}
	}

	public void GradientLinearChanged()
	{
		if (!_disableInspector)
		{
			SDFNode activeNode = ActiveNode;
			SDFCreator.SDFExport sDFExport;
			if ((sDFExport = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFExport) != null)
			{
				sDFExport.GradientLinear = GradientLinear.isOn;
			}
			MakeDirty(ActiveNode);
		}
	}

	public void ResourceChanged()
	{
		if (!_disableInspector)
		{
			SDFNode activeNode = ActiveNode;
			SDFCreator.SDFTexture sDFTexture;
			if ((sDFTexture = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFTexture) != null)
			{
				sDFTexture.SDFResource = ResourceCombo.SelectedItemString;
				sDFTexture.Reset();
			}
			MakeDirty(ActiveNode);
		}
	}

	public void ColorOutlineChanged()
	{
		if (!_disableInspector)
		{
			SDFNode activeNode = ActiveNode;
			SDFCreator.SDFExport sDFExport;
			if ((sDFExport = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFExport) != null)
			{
				sDFExport.Outline = ColorOutline.value;
			}
			MakeDirty(ActiveNode);
		}
	}

	public void MirrorTimesChanged()
	{
		if (!_disableInspector)
		{
			SDFNode activeNode = ActiveNode;
			SDFCreator.SDFMirror sDFMirror;
			if ((sDFMirror = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFMirror) != null)
			{
				sDFMirror.Times = (int)MirrorTimes.value;
			}
			MakeDirty(ActiveNode);
		}
	}

	public void FlipChanged()
	{
		if (!_disableInspector)
		{
			SDFNode activeNode = ActiveNode;
			SDFCreator.SDFMirror sDFMirror;
			if ((sDFMirror = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFMirror) != null)
			{
				sDFMirror.FlipX = FlipX.isOn;
				sDFMirror.FlipY = FlipY.isOn;
			}
			MakeDirty(ActiveNode);
		}
	}

	public void WaveChanged()
	{
		if (!_disableInspector)
		{
			SDFNode activeNode = ActiveNode;
			SDFCreator.SDFEffect sDFEffect;
			if ((sDFEffect = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFEffect) != null)
			{
				sDFEffect.WaveAmount = new Vector2(WaveXAmount.value, WaveYAmount.value);
				sDFEffect.WaveFrequency = new Vector2(WaveXFreq.value, WaveYFreq.value);
				sDFEffect.Skew = new Vector2(SkewX.value, SkewY.value);
			}
			MakeDirty(ActiveNode);
		}
	}

	public void MirrorAngleChanged()
	{
		if (!_disableInspector)
		{
			SDFNode activeNode = ActiveNode;
			SDFCreator.SDFMirror sDFMirror;
			if ((sDFMirror = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFMirror) != null)
			{
				sDFMirror.Angle = MirrorAngle.value;
			}
			MakeDirty(ActiveNode);
		}
	}

	public void MirrorOffsetChanged()
	{
		if (!_disableInspector)
		{
			SDFNode activeNode = ActiveNode;
			SDFCreator.SDFMirror sDFMirror;
			if ((sDFMirror = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFMirror) != null)
			{
				sDFMirror.Offset = MirrorOffset.value;
			}
			MakeDirty(ActiveNode);
		}
	}

	public void RoundingChanged()
	{
		if (!_disableInspector)
		{
			SDFNode activeNode = ActiveNode;
			SDFCreator.SDFShape sDFShape;
			if ((sDFShape = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFShape) != null)
			{
				sDFShape.Rounding = Rounding.value;
			}
			MakeDirty(ActiveNode);
		}
	}

	public void SubtractionChanged()
	{
		if (!_disableInspector)
		{
			SDFNode activeNode = ActiveNode;
			SDFCreator.SDFEffect sDFEffect;
			if ((sDFEffect = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFEffect) != null)
			{
				sDFEffect.Subtraction = Subtraction.value;
			}
			MakeDirty(ActiveNode);
		}
	}

	public void DistortionChanged()
	{
		if (!_disableInspector)
		{
			SDFNode activeNode = ActiveNode;
			SDFCreator.SDFEffect sDFEffect;
			if ((sDFEffect = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFEffect) != null)
			{
				sDFEffect.Distortion = Distortion.value;
			}
			MakeDirty(ActiveNode);
		}
	}

	public void GradientRotationChanged()
	{
		if (!_disableInspector)
		{
			SDFNode activeNode = ActiveNode;
			SDFCreator.SDFExport sDFExport;
			if ((sDFExport = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFExport) != null)
			{
				sDFExport.GradientRotation = GradientRotation.value;
			}
			MakeDirty(ActiveNode);
		}
	}

	public void ParamaterChanged()
	{
		if (!_disableInspector)
		{
			SDFNode activeNode = ActiveNode;
			SDFCreator.SDFShape sDFShape;
			if ((sDFShape = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFShape) != null)
			{
				sDFShape.SDFParams = new Vector4(Parameters[0].value, Parameters[1].value, Parameters[2].value, Parameters[3].value);
			}
			MakeDirty(ActiveNode);
		}
	}

	public void CombinationChanged()
	{
		if (_disableInspector)
		{
			return;
		}
		SDFNode activeNode = ActiveNode;
		SDFCreator.SDFCombine sDFCombine;
		if ((sDFCombine = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFCombine) != null)
		{
			sDFCombine.Param = CombinationSmoothness.value;
			sDFCombine.Function = (SDFCreator.CombineFunction)CombinationCombo.Selected;
			if (sDFCombine.Function != SDFCreator.CombineFunction.Lerp && sDFCombine.Param > 0f)
			{
				sDFCombine.Function += 4;
			}
		}
		MakeDirty(ActiveNode);
	}

	public void ShapeChanged()
	{
		if (!_disableInspector)
		{
			SDFNode activeNode = ActiveNode;
			SDFCreator.SDFShape sDFShape;
			if ((sDFShape = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFShape) != null)
			{
				sDFShape.Function = (SDFCreator.SDFFunction)ShapeCombo.SelectedItem;
				InitInspector();
			}
			MakeDirty(ActiveNode);
		}
	}

	public void PosChanged()
	{
		if (_disableInspector)
		{
			return;
		}
		SDFNode activeNode = ActiveNode;
		SDFCreator.SDFShape sDFShape;
		if ((sDFShape = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFShape) != null)
		{
			sDFShape.Pos = PosTool.Position - Vector2.one * 0.5f;
		}
		else
		{
			SDFNode activeNode2 = ActiveNode;
			SDFCreator.SDFTransform sDFTransform;
			if ((sDFTransform = (((object)activeNode2 != null) ? activeNode2.Node : null) as SDFCreator.SDFTransform) != null)
			{
				sDFTransform.Pos = PosTool.Position - Vector2.one * 0.5f;
			}
			else
			{
				SDFNode activeNode3 = ActiveNode;
				SDFCreator.SDFMix sDFMix;
				if ((sDFMix = (((object)activeNode3 != null) ? activeNode3.Node : null) as SDFCreator.SDFMix) != null)
				{
					sDFMix.Pos = PosTool.Position - Vector2.one * 0.5f;
				}
				else
				{
					SDFNode activeNode4 = ActiveNode;
					SDFCreator.SDFExport sDFExport;
					if ((sDFExport = (((object)activeNode4 != null) ? activeNode4.Node : null) as SDFCreator.SDFExport) != null)
					{
						sDFExport.Pos = PosTool.Position - Vector2.one * 0.5f;
					}
					else
					{
						SDFNode activeNode5 = ActiveNode;
						SDFCreator.SDFMirror sDFMirror;
						if ((sDFMirror = (((object)activeNode5 != null) ? activeNode5.Node : null) as SDFCreator.SDFMirror) != null)
						{
							sDFMirror.Pos = PosTool.Position;
						}
						else
						{
							SDFNode activeNode6 = ActiveNode;
							SDFCreator.SDFTexture sDFTexture;
							if ((sDFTexture = (((object)activeNode6 != null) ? activeNode6.Node : null) as SDFCreator.SDFTexture) != null)
							{
								sDFTexture.Pos = PosTool.Position - Vector2.one * 0.5f;
							}
							else
							{
								SDFNode activeNode7 = ActiveNode;
								SDFCreator.SDFArray sDFArray;
								if ((sDFArray = (((object)activeNode7 != null) ? activeNode7.Node : null) as SDFCreator.SDFArray) != null)
								{
									sDFArray.Pos = PosTool.Position - Vector2.one * 0.5f;
								}
								else
								{
									SDFNode activeNode8 = ActiveNode;
									SDFCreator.SDFReflect sDFReflect;
									if ((sDFReflect = (((object)activeNode8 != null) ? activeNode8.Node : null) as SDFCreator.SDFReflect) != null)
									{
										sDFReflect.Pos = PosTool.Position;
									}
								}
							}
						}
					}
				}
			}
		}
		MakeDirty(ActiveNode);
	}

	public void ScaleChanged()
	{
		if (_disableInspector)
		{
			return;
		}
		SDFNode activeNode = ActiveNode;
		SDFCreator.SDFShape sDFShape;
		if ((sDFShape = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFShape) != null)
		{
			sDFShape.Scale = Vector2.one * Scale.value;
		}
		else
		{
			SDFNode activeNode2 = ActiveNode;
			SDFCreator.SDFTransform sDFTransform;
			if ((sDFTransform = (((object)activeNode2 != null) ? activeNode2.Node : null) as SDFCreator.SDFTransform) != null)
			{
				sDFTransform.Scale = Vector2.one * Scale.value;
			}
			else
			{
				SDFNode activeNode3 = ActiveNode;
				SDFCreator.SDFMix sDFMix;
				if ((sDFMix = (((object)activeNode3 != null) ? activeNode3.Node : null) as SDFCreator.SDFMix) != null)
				{
					sDFMix.Scale = Vector2.one * Scale.value;
				}
				else
				{
					SDFNode activeNode4 = ActiveNode;
					SDFCreator.SDFExport sDFExport;
					if ((sDFExport = (((object)activeNode4 != null) ? activeNode4.Node : null) as SDFCreator.SDFExport) != null)
					{
						sDFExport.Scale = Vector2.one * Scale.value;
					}
					else
					{
						SDFNode activeNode5 = ActiveNode;
						SDFCreator.SDFTexture sDFTexture;
						if ((sDFTexture = (((object)activeNode5 != null) ? activeNode5.Node : null) as SDFCreator.SDFTexture) != null)
						{
							sDFTexture.Scale = Vector2.one * Scale.value;
						}
					}
				}
			}
		}
		MakeDirty(ActiveNode);
	}

	public void Scale2Changed()
	{
		if (!_disableInspector)
		{
			SDFNode activeNode = ActiveNode;
			SDFCreator.SDFArray sDFArray;
			if ((sDFArray = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFArray) != null)
			{
				sDFArray.Scale = Vector2.one * 1f / Scale2.value;
			}
			MakeDirty(ActiveNode);
		}
	}

	public void RotationChanged()
	{
		if (_disableInspector)
		{
			return;
		}
		SDFNode activeNode = ActiveNode;
		SDFCreator.SDFShape sDFShape;
		if ((sDFShape = (((object)activeNode != null) ? activeNode.Node : null) as SDFCreator.SDFShape) != null)
		{
			sDFShape.Rotation = Rotation.value;
		}
		else
		{
			SDFNode activeNode2 = ActiveNode;
			SDFCreator.SDFTransform sDFTransform;
			if ((sDFTransform = (((object)activeNode2 != null) ? activeNode2.Node : null) as SDFCreator.SDFTransform) != null)
			{
				sDFTransform.Rotation = Rotation.value;
			}
			else
			{
				SDFNode activeNode3 = ActiveNode;
				SDFCreator.SDFMix sDFMix;
				if ((sDFMix = (((object)activeNode3 != null) ? activeNode3.Node : null) as SDFCreator.SDFMix) != null)
				{
					sDFMix.Rotation = Rotation.value;
				}
				else
				{
					SDFNode activeNode4 = ActiveNode;
					SDFCreator.SDFExport sDFExport;
					if ((sDFExport = (((object)activeNode4 != null) ? activeNode4.Node : null) as SDFCreator.SDFExport) != null)
					{
						sDFExport.Rotation = Rotation.value;
					}
					else
					{
						SDFNode activeNode5 = ActiveNode;
						SDFCreator.SDFTexture sDFTexture;
						if ((sDFTexture = (((object)activeNode5 != null) ? activeNode5.Node : null) as SDFCreator.SDFTexture) != null)
						{
							sDFTexture.Rotation = Rotation.value;
						}
						else
						{
							SDFNode activeNode6 = ActiveNode;
							SDFCreator.SDFArray sDFArray;
							if ((sDFArray = (((object)activeNode6 != null) ? activeNode6.Node : null) as SDFCreator.SDFArray) != null)
							{
								sDFArray.Rotation = Rotation.value;
							}
							else
							{
								SDFNode activeNode7 = ActiveNode;
								SDFCreator.SDFReflect sDFReflect;
								if ((sDFReflect = (((object)activeNode7 != null) ? activeNode7.Node : null) as SDFCreator.SDFReflect) != null)
								{
									sDFReflect.Angle = Rotation.value;
								}
							}
						}
					}
				}
			}
		}
		MakeDirty(ActiveNode);
	}

	private void ToggleTool(Transform t, bool enable)
	{
		t.gameObject.SetActive(enable);
		t.parent.GetChild(t.GetSiblingIndex() - 1).gameObject.SetActive(enable);
	}

	private void FixedUpdate()
	{
		if (!DirtyRend.HasValue)
		{
			return;
		}
		bool flag = false;
		if (DirtyMain)
		{
			DirtyMain = false;
			if (FinalNode != null)
			{
				FinalNode.Render(_preview);
				flag = true;
			}
		}
		if (!flag && Nodes.Count > 0)
		{
			int num = DirtyRend.Value % Nodes.Count;
			Nodes[num].Render();
			DirtyAmount--;
			if (DirtyAmount == 0)
			{
				DirtyRend = null;
			}
			else
			{
				DirtyRend = (num + 1) % Nodes.Count;
			}
		}
	}

	public IEnumerable<ValueTuple<SDFNode, SDFNode>> GetConnections(Vector2 p, float maxDist)
	{
		Vector2 off = UICamSize.GetUICamOffset() / base.rectTransform.localScale.x;
		for (int i = 0; i < Nodes.Count; i++)
		{
			SDFNode n = Nodes[i];
			for (int j = 0; j < n.Inputs.Length; j++)
			{
				SDFNode sDFNode = n.Inputs[j];
				Vector2 localPoint;
				Vector2 localPoint2;
				Vector2 res;
				if (sDFNode != null && RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, n.InputPos[j].position, UICamSize.GetUICam(), out localPoint) && RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, sDFNode.OutputPos.position, UICamSize.GetUICam(), out localPoint2) && Utilities.ProjectToLine(p, localPoint + off, localPoint2 + off, out res) && (p - res).magnitude < maxDist)
				{
					yield return new ValueTuple<SDFNode, SDFNode>(sDFNode, n);
				}
			}
		}
	}

	public void UpdatePreview()
	{
		if (Application.isPlaying)
		{
			if (FinalNode != null)
			{
				Preview.gameObject.SetActive(true);
				NoPreview.SetActive(false);
			}
			else
			{
				Preview.gameObject.SetActive(false);
				NoPreview.SetActive(true);
			}
		}
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		if (!Application.isPlaying)
		{
			return;
		}
		Vector2 vector = UICamSize.GetUICamOffset() / base.rectTransform.localScale.x;
		for (int i = 0; i < Nodes.Count; i++)
		{
			SDFNode sDFNode = Nodes[i];
			for (int j = 0; j < sDFNode.Inputs.Length; j++)
			{
				SDFNode sDFNode2 = sDFNode.Inputs[j];
				Vector2 localPoint;
				Vector2 localPoint2;
				if (sDFNode2 != null && RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, sDFNode.InputPos[j].position, UICamSize.GetUICam(), out localPoint) && RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, sDFNode2.OutputPos.position, UICamSize.GetUICam(), out localPoint2))
				{
					vh.DrawLine(localPoint - new Vector2(6f, 0f) + vector, localPoint2 + new Vector2(6f, 0f) + vector, ConnectionLineWidth, sDFNode.GetColor(true));
				}
			}
		}
		Vector2 localPoint3;
		Vector2 localPoint4;
		if (FinalNode != null && RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, FinalConnector.position, UICamSize.GetUICam(), out localPoint3) && RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, FinalNode.OutputPos.position, UICamSize.GetUICam(), out localPoint4))
		{
			vh.DrawLine(localPoint3 + vector, localPoint4 + new Vector2(6f, 0f) + vector, ConnectionLineWidth, RGBColor);
		}
	}

	protected override void Start()
	{
		base.Start();
		if (Application.isPlaying)
		{
			UpdateLimit();
			ShapeCombo.UpdateContent(Enum.GetValues(typeof(SDFCreator.SDFFunction)).OfType<SDFCreator.SDFFunction>());
			CombinationCombo.UpdateContent(new string[4] { "SDFUnion", "SDFIntersection", "SDFSubtract", "SDFInterpolate" });
			ResourceCombo.UpdateContent(Resources.Load<TextAsset>("SDF/SDFManifest").text.SplitByNewLines());
			_preview = new RenderTexture(256, 256, 0);
			Preview.texture = _preview;
			InitInspector();
			UpdatePreview();
		}
	}

	public void UpdateLimit()
	{
		bool canCreate = CanCreateNode();
		CreateButtons.ForEachEnum(delegate(Button x)
		{
			x.interactable = canCreate;
		});
		LimitLabel.text = Nodes.Count + "/" + 25;
	}

	public bool CanCreateNode()
	{
		return Nodes.Count < 25;
	}

	public void CreateNode(int type)
	{
		CreateNode((SDFCreator.NodeType)type);
	}

	public void CreateNode(SDFCreator.NodeType type)
	{
		if (CanCreateNode())
		{
			SDFNode sDFNode = UnityEngine.Object.Instantiate(NodePrefab);
			sDFNode.Init(type, this);
			sDFNode.FirstDrag = true;
			sDFNode.StartDrag();
			Nodes.Add(sDFNode);
			MakeDirty(sDFNode);
			UpdateLimit();
		}
	}

	public void SetLine(Vector2 v1, Vector2 v2, Color c)
	{
		NodeLine.gameObject.SetActive(true);
		NodeLine.anchoredPosition = (v1 + v2) * 0.5f;
		NodeLine.sizeDelta = new Vector2((v1 - v2).magnitude, ConnectionLineWidth);
		NodeLine.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(v1.y - v2.y, v1.x - v2.x) * 57.29578f);
		NodeLine.GetComponent<Image>().color = c;
	}

	public void UnsetLine()
	{
		NodeLine.gameObject.SetActive(false);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Vector2 localPoint;
		if (eventData.button != PointerEventData.InputButton.Right || !RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
		{
			return;
		}
		Vector2 vector = UICamSize.GetUICamOffset() / base.rectTransform.localScale.x;
		SDFNode sDFNode = null;
		for (int i = 0; i < Nodes.Count; i++)
		{
			SDFNode sDFNode2 = Nodes[i];
			for (int j = 0; j < sDFNode2.Inputs.Length; j++)
			{
				SDFNode sDFNode3 = sDFNode2.Inputs[j];
				Vector2 localPoint2;
				Vector2 localPoint3;
				Vector2 res;
				if (sDFNode3 != null && RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, sDFNode2.InputPos[j].position, UICamSize.GetUICam(), out localPoint2) && RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, sDFNode3.OutputPos.position, UICamSize.GetUICam(), out localPoint3) && Utilities.ProjectToLine(localPoint, localPoint2 + vector, localPoint3 + vector, out res) && (res - localPoint).magnitude < 8f)
				{
					sDFNode = sDFNode3;
					break;
				}
			}
			if (sDFNode != null)
			{
				sDFNode.Disconnect(sDFNode2);
				UISoundFX.PlaySFX("ButtonSwoop");
				SetAllDirty();
				UpdatePreview();
				break;
			}
		}
		Vector2 localPoint4;
		Vector2 localPoint5;
		Vector2 res2;
		if (sDFNode == null && FinalNode != null && RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, FinalConnector.position, UICamSize.GetUICam(), out localPoint4) && RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, FinalNode.OutputPos.position, UICamSize.GetUICam(), out localPoint5) && Utilities.ProjectToLine(localPoint, localPoint4 + vector, localPoint5 + vector, out res2) && (res2 - localPoint).magnitude < 8f)
		{
			FinalNode = null;
			UISoundFX.PlaySFX("ButtonSwoop");
			SetAllDirty();
			UpdatePreview();
		}
	}

	public void CalculateLayoutInputHorizontal()
	{
		_prefWidth = ((Nodes.Count > 0) ? (Nodes.Max((SDFNode x) => (!(x.Self.parent == NodePanel)) ? 10f : (x.Self.anchoredPosition.x + x.Self.rect.width / 2f)) + 64f) : 10f);
		_prefHeight = ((Nodes.Count > 0) ? (Nodes.Max((SDFNode x) => (!(x.Self.parent == NodePanel)) ? 10f : (0f - x.Self.anchoredPosition.y + x.Self.rect.height / 2f)) + 64f) : 10f);
		if (_lastMax.HasValue)
		{
			_prefWidth = Mathf.Max(_prefWidth, _lastMax.Value.x + 64f, base.rectTransform.parent.GetComponent<RectTransform>().rect.width);
			_prefHeight = Mathf.Max(_prefHeight, 0f - _lastMax.Value.y + 64f);
		}
		_prefWidth = Mathf.Max(_prefWidth, base.rectTransform.parent.GetComponent<RectTransform>().rect.width);
		_prefHeight = Mathf.Max(_prefHeight, base.rectTransform.parent.GetComponent<RectTransform>().rect.height);
	}

	public void CalculateLayoutInputVertical()
	{
		CalculateLayoutInputHorizontal();
	}

	public void OnScroll(PointerEventData eventData)
	{
		float num = Mathf.Clamp(base.rectTransform.localScale.x + eventData.scrollDelta.y * 0.1f, 0.5f, 1f);
		base.rectTransform.localScale = new Vector3(num, num, 1f);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}
}
