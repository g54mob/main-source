using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SDFSimpleEditor : MonoBehaviour
{
	public class SDFSuperNode
	{
		public enum Type
		{
			Shape = 0,
			Texture = 1,
			Mirror = 2,
			Array = 3,
			Reflect = 4
		}

		public SDFSuperNode Parent;

		public List<SDFSuperNode> Children = new List<SDFSuperNode>();

		public SDFLayer UILayer;

		public Type SDFType;

		public SDFCreator.CombineFunction CombineType;

		public string SDFResource;

		public Color MainColor = Color.red;

		public Color GradientColor = Color.red;

		public Color OutlineColor = Color.black;

		public Vector2 Pos = Vector2.zero;

		public Vector2 WaveAmount = Vector2.zero;

		public Vector2 WaveFrequency = Vector2.one;

		public Vector2 Skew = Vector2.zero;

		public float Rotation;

		public float Scale = 0.5f;

		public float Rounding;

		public float CombineParam;

		public float Subtraction;

		public float Distortion;

		public float Threshold;

		public float EffectThreshold;

		public float Offset;

		public float Outline;

		public float GradientRotation;

		public bool FlipX;

		public bool FlipY;

		public bool GradientLinear = true;

		public bool TransformColor;

		public int Times = 2;

		public SDFCreator.SDFFunction Function;

		public Vector4 SDFParams = Vector4.one;

		public Vector2 LastPos;

		public float LastRot;

		public float LastScale;

		public bool CanBeParentOf(SDFSuperNode node)
		{
			SDFSuperNode sDFSuperNode = this;
			if (!IsGraphic())
			{
				return false;
			}
			while (sDFSuperNode != null)
			{
				if (sDFSuperNode == node)
				{
					return false;
				}
				sDFSuperNode = sDFSuperNode.Parent;
			}
			return true;
		}

		public SDFSuperNode GetTransformParent()
		{
			return null;
		}

		public Matrix4x4 GetParentTRS()
		{
			return Matrix4x4.identity;
		}

		public Matrix4x4 GetTRS(bool pp = false)
		{
			Vector2 boxCenter = GetBoxCenter();
			SDFSuperNode transformParent = GetTransformParent();
			Matrix4x4 matrix4x = Matrix4x4.TRS(new Vector3(boxCenter.x, boxCenter.y, 0f), Quaternion.Euler(0f, 0f, pp ? (360f - Rotation) : Rotation), Vector3.one * GetBoxScale());
			if (transformParent != null)
			{
				matrix4x = transformParent.GetTRS(true) * matrix4x;
				Vector3 position;
				Quaternion rotation;
				Vector3 scale;
				matrix4x.ExtractTRS(out position, out rotation, out scale);
				matrix4x = Matrix4x4.TRS(position, Quaternion.Euler(0f, 0f, transformParent.Rotation + Rotation), scale);
			}
			return matrix4x;
		}

		public void SetParent(SDFSuperNode node, int index = -1)
		{
			if (Parent != null)
			{
				if (node == Parent && Parent.Children.IndexOf(this) < index)
				{
					index--;
				}
				Parent.Children.Remove(this);
				SDFLayer uILayer = Parent.UILayer;
				if ((object)uILayer != null)
				{
					uILayer.UpdateCollapse();
				}
			}
			Parent = node;
			if (Parent != null)
			{
				SDFLayer uILayer2 = Parent.UILayer;
				if ((object)uILayer2 != null)
				{
					uILayer2.UpdateCollapse();
				}
				if (Parent.Parent == this)
				{
					Parent.Parent = null;
					Children.Remove(Parent);
				}
				Parent.Children.Insert((index >= 0) ? Mathf.Clamp(index, 0, Parent.Children.Count) : Parent.Children.Count, this);
			}
		}

		public bool IsGraphic()
		{
			if (SDFType != Type.Shape)
			{
				return SDFType == Type.Texture;
			}
			return true;
		}

		public void SetLastTransform()
		{
			LastPos = Pos;
			LastRot = Rotation;
			LastScale = Scale;
			for (int i = 0; i < Children.Count; i++)
			{
				Children[i].SetLastTransform();
			}
		}

		public SDFSuperNode()
		{
		}

		public SDFSuperNode(Type sdfType, SDFCreator.CombineFunction combineType, string sdfResource, float rotation, float scale, float rounding, float combineParam, float subtraction, float distortion, float threshold, float effectThreshold, float offset, float outline, float gradientRotation, bool flipX, bool flipY, bool gradientLinear, int times, SDFCreator.SDFFunction function, Vector2 pos, Vector2 waveAmount, Vector2 waveFrequency, Vector2 skew, Vector4 sdfParams, Color mainColor, Color gradientColor, Color outlineColor)
		{
			SDFType = sdfType;
			CombineType = combineType;
			SDFResource = sdfResource;
			Rotation = rotation;
			Scale = scale;
			Rounding = rounding;
			Subtraction = subtraction;
			CombineParam = combineParam;
			Distortion = distortion;
			Threshold = threshold;
			EffectThreshold = effectThreshold;
			Offset = offset;
			Outline = outline;
			GradientRotation = gradientRotation;
			FlipX = flipX;
			FlipY = flipY;
			GradientLinear = gradientLinear;
			Times = times;
			Function = function;
			Pos = pos;
			WaveAmount = waveAmount;
			WaveFrequency = waveFrequency;
			Skew = skew;
			SDFParams = sdfParams;
			MainColor = mainColor;
			GradientColor = gradientColor;
			OutlineColor = outlineColor;
		}

		public SDFSuperNode Clone()
		{
			return new SDFSuperNode(SDFType, CombineType, SDFResource, Rotation, Scale, Rounding, CombineParam, Subtraction, Distortion, Threshold, EffectThreshold, Offset, Outline, GradientRotation, FlipX, FlipY, GradientLinear, Times, Function, Pos, WaveAmount, WaveFrequency, Skew, SDFParams, MainColor, GradientColor, OutlineColor);
		}

		public float GetPosScaleOffset()
		{
			Type sDFType = SDFType;
			if (sDFType == Type.Mirror || sDFType == Type.Reflect)
			{
				return 0.25f;
			}
			return 0.5f;
		}

		public Vector2 GetBoxCenter()
		{
			Type sDFType = SDFType;
			if (sDFType == Type.Mirror || sDFType == Type.Reflect)
			{
				return Pos - Vector2.one * 0.5f;
			}
			return Pos;
		}

		public void SetBoxCenter(Vector2 pos)
		{
			Type sDFType = SDFType;
			if (sDFType == Type.Mirror || sDFType == Type.Reflect)
			{
				Pos = pos + Vector2.one * 0.5f;
			}
			else
			{
				Pos = pos;
			}
		}

		public Vector2 GetLastBoxCenter()
		{
			Type sDFType = SDFType;
			if (sDFType == Type.Mirror || sDFType == Type.Reflect)
			{
				return LastPos - Vector2.one * 0.5f;
			}
			return LastPos;
		}

		public void SetLastBoxCenter(Vector2 pos)
		{
			Pos = LastPos + pos;
		}

		public float GetBoxScale()
		{
			return Scale * GetScaleFactor();
		}

		public float GetScaleFactor()
		{
			Type sDFType = SDFType;
			if (sDFType == Type.Texture)
			{
				return 1f;
			}
			return 2f;
		}

		public void SetBoxScale(float scale)
		{
			Scale = scale / GetScaleFactor();
		}

		public SDFCreator.CombineFunction GetCombineFunction()
		{
			switch (CombineType)
			{
			case SDFCreator.CombineFunction.Union:
				if (!(CombineParam > 0f))
				{
					return SDFCreator.CombineFunction.Union;
				}
				return SDFCreator.CombineFunction.RoundUnion;
			case SDFCreator.CombineFunction.Intersection:
				if (!(CombineParam > 0f))
				{
					return SDFCreator.CombineFunction.Intersection;
				}
				return SDFCreator.CombineFunction.RoundIntersection;
			case SDFCreator.CombineFunction.Subtraction:
				if (!(CombineParam > 0f))
				{
					return SDFCreator.CombineFunction.Subtraction;
				}
				return SDFCreator.CombineFunction.RoundSubtraction;
			case SDFCreator.CombineFunction.Lerp:
				return SDFCreator.CombineFunction.Lerp;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public static void SwitchInput(SDFCreator.ISDFNode node, SDFCreator.ISDFNode before, SDFCreator.ISDFNode after, Dictionary<SDFCreator.ISDFNode, SDFCreator.ISDFNode> connections)
		{
			int num = 0;
			foreach (SDFCreator.ISDFNode child in node.GetChildren())
			{
				if (child == before)
				{
					node.SetInput(after, num);
					connections[after] = node;
					break;
				}
				num++;
			}
		}

		public SDFCreator.ISDFInput GetShape(bool combine)
		{
			SDFCreator.ISDFInput iSDFInput = null;
			switch (SDFType)
			{
			case Type.Shape:
				iSDFInput = new SDFCreator.SDFShape(Function, (combine || !TransformColor) ? Pos : Vector2.zero, ((combine || !TransformColor) ? Scale : (1f / GetScaleFactor())) * Vector2.one, (combine || !TransformColor) ? Rotation : 0f, Rounding, SDFParams);
				break;
			case Type.Texture:
				iSDFInput = new SDFCreator.SDFTexture(SDFResource, (combine || !TransformColor) ? Pos : Vector2.zero, ((combine || !TransformColor) ? Scale : (1f / GetScaleFactor())) * Vector2.one, (combine || !TransformColor) ? Rotation : 0f);
				break;
			}
			if (iSDFInput != null)
			{
				return iSDFInput;
			}
			throw new Exception("Cannot convert shape to anything");
		}

		public SDFCreator.ISDFNode ToSDFNode(bool temp)
		{
			if (temp && !UILayer.Show.isOn)
			{
				return null;
			}
			SDFCreator.ISDFNode iSDFNode;
			switch (SDFType)
			{
			case Type.Shape:
			case Type.Texture:
				iSDFNode = GetShape(Parent != null);
				break;
			case Type.Mirror:
				iSDFNode = new SDFCreator.SDFMirror(null, Pos, Times, 360f - Offset, 360f - Rotation)
				{
					FlipX = FlipX,
					FlipY = FlipY
				};
				break;
			case Type.Reflect:
				iSDFNode = new SDFCreator.SDFReflect(null, Pos, 360f - Rotation);
				break;
			case Type.Array:
				iSDFNode = new SDFCreator.SDFArray(Pos, Scale * Vector2.one, Rotation, false, false);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			foreach (SDFSuperNode child in Children)
			{
				SDFCreator.ISDFNode iSDFNode2 = child.ToSDFNode(temp);
				if (iSDFNode2 != null)
				{
					switch (child.SDFType)
					{
					case Type.Shape:
					case Type.Texture:
						iSDFNode = new SDFCreator.SDFCombine(child.GetCombineFunction(), child.CombineParam)
						{
							Input1 = (SDFCreator.ISDFInput)iSDFNode,
							Input2 = (SDFCreator.ISDFInput)iSDFNode2
						};
						break;
					case Type.Mirror:
						((SDFCreator.SDFMirror)iSDFNode2).Input = (SDFCreator.ISDFInput)iSDFNode;
						iSDFNode = iSDFNode2;
						break;
					case Type.Reflect:
						((SDFCreator.SDFReflect)iSDFNode2).Input = (SDFCreator.ISDFInput)iSDFNode;
						iSDFNode = iSDFNode2;
						break;
					case Type.Array:
						((SDFCreator.SDFArray)iSDFNode2).Input = (SDFCreator.ISDFInput)iSDFNode;
						iSDFNode = iSDFNode2;
						break;
					default:
						throw new ArgumentOutOfRangeException();
					}
				}
			}
			if (Subtraction > 0f || WaveAmount != Vector2.zero || Skew != Vector2.zero || Distortion != 0f || EffectThreshold != 0f)
			{
				iSDFNode = new SDFCreator.SDFEffect(0f, Subtraction, Distortion, EffectThreshold, 0f, WaveAmount, WaveFrequency, Skew)
				{
					Input = (SDFCreator.ISDFInput)iSDFNode
				};
			}
			if (Parent == null)
			{
				if (SDFType == Type.Mirror || SDFType == Type.Reflect || SDFType == Type.Array)
				{
					throw new Exception("Only shapes in root layers");
				}
				return new SDFCreator.SDFExport(MainColor, GradientColor, OutlineColor, Threshold, Outline, (Parent == null && TransformColor) ? Pos : Vector2.zero, ((Parent == null && TransformColor) ? (Scale * GetScaleFactor()) : 1f) * Vector2.one, (Parent == null && TransformColor) ? (360f - Rotation) : 0f, GradientRotation, GradientLinear)
				{
					Input = (SDFCreator.ISDFInput)iSDFNode
				};
			}
			return iSDFNode;
		}
	}

	public RawImage MainImage;

	public RawImage SelectionImage;

	[NonSerialized]
	private RenderTexture _targetTex;

	[NonSerialized]
	private RenderTexture _selectionTex;

	public RectTransform CreationPanel;

	public GameObject CopyPastePanel;

	public InputField PasteInput;

	public SimpleLogoEditorWindow ParentWindow;

	public AdvancedLogoEditorWindow AdvancedEditor;

	public ScrollRect LayerView;

	public ScrollRectDragDisabler DragDisabler;

	public GUICombobox ShapeCombo;

	public GUICombobox TypeCombo;

	public Slider Smoothing;

	public Slider CombineParam;

	public Slider Distortion;

	public Slider Rotation;

	public Slider Outline;

	public Slider Subtraction;

	public Slider Threshold;

	public Slider Times;

	public Slider WaveAmountX;

	public Slider WaveAmountY;

	public Slider WaveFrequencyX;

	public Slider WaveFrequencyY;

	public Slider SkewX;

	public Slider SkewY;

	public Slider GradientRotation;

	public Slider EffectThreshold;

	public Slider[] SDFParameters;

	public Slider ParamSliderPrefab;

	public Toggle FlipX;

	public Toggle FlipY;

	public Toggle GradientLinear;

	public Toggle TransformColor;

	public Image MainColor;

	public Image OutlineColor;

	public Image GradientColor;

	public int StepSize = 1;

	[NonSerialized]
	public int Dirty;

	public Texture2D ArrayIcon;

	public Texture2D MirrorIcon;

	public Texture2D ReflectIcon;

	public Text ComplexityLabel;

	[NonSerialized]
	private HashSet<SDFLayer> _activeLayers = new HashSet<SDFLayer>();

	[NonSerialized]
	private HashSet<SDFLayer> _topLevelActiveLayers = new HashSet<SDFLayer>();

	[NonSerialized]
	private float _lastComplexity;

	[NonSerialized]
	private float _lastRot;

	[NonSerialized]
	private float _boxRot;

	[NonSerialized]
	private float _boxScale;

	[NonSerialized]
	private float _lastScale;

	[NonSerialized]
	private float _lastScaling = 1f;

	[NonSerialized]
	private SDFLayer _isDragging;

	[NonSerialized]
	private bool _movingBox;

	[NonSerialized]
	private bool _rotatingBox;

	[NonSerialized]
	private Vector2? _scalingBox;

	[NonSerialized]
	private Vector2 _scalingDir;

	[NonSerialized]
	private Vector2 _moveLast;

	[NonSerialized]
	private Vector2 _posLast;

	[NonSerialized]
	private Vector2 _scaleStart;

	[NonSerialized]
	private Vector3? _lastHitMP;

	[NonSerialized]
	public bool _pressedCanvas;

	[NonSerialized]
	private Vector2 _transformCenter;

	private ObjectPool<Slider> _sliderParamPool;

	private static Dictionary<string, RenderTexture> _sdfIcons = new Dictionary<string, RenderTexture>();

	public SDFLayer LayerPrefab;

	public Button SDFButtonPrefab;

	public Text HintLabel;

	public GameObject ReflectLine;

	public RectTransform LayerPanel;

	public RectTransform LayerBox;

	public RectTransform MainPanel;

	public RectTransform Dragger;

	public RectTransform FullMainPanel;

	public CursorOverride[] DragCorners;

	public float[] Offsets = new float[4] { 0f, 90f, 180f, 270f };

	public List<SDFSuperNode> Layers = new List<SDFSuperNode>();

	[NonSerialized]
	public int Size;

	[NonSerialized]
	private bool _disableInspector;

	public SDFLayer FirstActiveLayer
	{
		get
		{
			if (_activeLayers.Count != 1)
			{
				return null;
			}
			return _activeLayers.First();
		}
	}

	public void AddActiveLayer(SDFLayer layer)
	{
		if (_activeLayers.Add(layer))
		{
			layer.SetActive(true);
			UpdateTopLevelLayers();
			UpdateSelectionTex();
			UpdateEverything();
		}
	}

	public void RemoveActiveLayer(SDFLayer layer)
	{
		if (_activeLayers.Remove(layer))
		{
			layer.SetActive(false);
			UpdateTopLevelLayers();
			UpdateSelectionTex();
			UpdateEverything();
		}
	}

	public void SetActiveLayer(SDFLayer layer)
	{
		_activeLayers.ForEachEnum(delegate(SDFLayer x)
		{
			x.SetActive(false);
		});
		_activeLayers.Clear();
		_activeLayers.Add(layer);
		layer.SetActive(true);
		UpdateTopLevelLayers();
		UpdateSelectionTex();
		UpdateEverything();
	}

	public void ClearActiveLayers()
	{
		if (_activeLayers.Count > 0)
		{
			_activeLayers.ForEachEnum(delegate(SDFLayer x)
			{
				x.SetActive(false);
			});
			_activeLayers.Clear();
			_topLevelActiveLayers.Clear();
			UpdateSelectionTex();
		}
		UpdateEverything();
	}

	private void UpdateTopLevelLayers()
	{
		_topLevelActiveLayers.Clear();
		_topLevelActiveLayers.AddRange(_activeLayers);
		foreach (SDFLayer activeLayer in _activeLayers)
		{
			RemoveChildrenFromTop(activeLayer);
		}
	}

	private void RemoveChildrenFromTop(SDFLayer layer)
	{
		foreach (SDFSuperNode child in layer.Node.Children)
		{
			_topLevelActiveLayers.Remove(child.UILayer);
			RemoveChildrenFromTop(child.UILayer);
		}
	}

	public bool IsActiveLayer(SDFLayer layer)
	{
		return _activeLayers.Contains(layer);
	}

	public void Zoom(BaseEventData d)
	{
		PointerEventData pointerEventData;
		if ((pointerEventData = d as PointerEventData) != null)
		{
			float num = Mathf.Clamp(MainPanel.localScale.x + pointerEventData.scrollDelta.y * 0.25f, 1f, 4f);
			MainPanel.localScale = new Vector3(num, num, 1f);
			UpdateSelectionTex();
		}
	}

	private void SetLastTransforms()
	{
		for (int i = 0; i < Layers.Count; i++)
		{
			Layers[i].SetLastTransform();
		}
	}

	public void StartMovingBox()
	{
		SetLastTransforms();
		_movingBox = true;
		HintLabel.text = "SimpleLogoMoveHint".Loc();
		HintLabel.gameObject.SetActive(true);
	}

	public void StartRotatingBox()
	{
		Vector2 localPoint;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(MainPanel, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
		{
			SetLastTransforms();
			Vector2 anchoredPosition = LayerBox.anchoredPosition;
			_lastRot = Mathf.Atan2(anchoredPosition.y - localPoint.y, anchoredPosition.x - localPoint.x) * 57.29578f;
			_boxRot = LayerBox.rotation.eulerAngles.z;
			_rotatingBox = true;
			HintLabel.text = "SimpleLogoRotationHint".Loc();
			HintLabel.gameObject.SetActive(true);
		}
	}

	public void StartScaling(int from)
	{
		Vector2 localPoint;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(MainPanel, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
		{
			SetLastTransforms();
			Vector3[] array = new Vector3[4];
			LayerBox.GetLocalCorners(array);
			Vector3 vector = LayerBox.rotation * array[from];
			_scalingBox = new Vector2(vector.x, vector.y) + LayerBox.anchoredPosition;
			_scalingDir = (LayerBox.anchoredPosition - _scalingBox.Value).normalized;
			_lastScale = (_scalingBox.Value - localPoint).magnitude;
			_boxScale = LayerBox.sizeDelta.x;
			_lastScaling = (LayerBox.sizeDelta.x + LayerBox.sizeDelta.y) * 0.5f / (float)Size;
			_scaleStart = GetLayerBoxLocalPosition();
			HintLabel.text = "SimpleLogoScaleHint".Loc();
			HintLabel.gameObject.SetActive(true);
		}
	}

	public RenderTexture GetSDFIcon(object key)
	{
		if (key == null)
		{
			return null;
		}
		string text = key.ToString().Trim();
		RenderTexture value;
		if (!_sdfIcons.TryGetValue(text, out value))
		{
			value = new RenderTexture(32, 32, 0);
			object obj;
			SDFCreator.ISDFInput input;
			if ((obj = key) is SDFCreator.SDFFunction)
			{
				SDFCreator.SDFFunction sDFFunction = (SDFCreator.SDFFunction)obj;
				input = new SDFCreator.SDFShape(sDFFunction, SDFCreator.GetDefaultParameters(sDFFunction));
			}
			else
			{
				input = new SDFCreator.SDFTexture(text);
			}
			SDFCreator.SDFExport sdf = new SDFCreator.SDFExport(input, Color.white);
			SDFCreator.Instance.Render(sdf, value);
			_sdfIcons[text] = value;
		}
		return value;
	}

	private void Start()
	{
		_sliderParamPool = new ObjectPool<Slider>(delegate
		{
			Slider slider = UnityEngine.Object.Instantiate(ParamSliderPrefab);
			slider.transform.SetParent(LayerBox, false);
			return slider;
		}, delegate(Slider x)
		{
			x.gameObject.SetActive(true);
		}, delegate(Slider x)
		{
			x.onValueChanged.RemoveAllListeners();
			x.gameObject.SetActive(false);
		});
		TypeCombo.UpdateContent(new string[4] { "SDFUnion", "SDFIntersection", "SDFSubtract", "SDFInterpolate" });
		string[] array = Resources.Load<TextAsset>("SDF/SDFManifest").text.SplitByNewLines();
		ShapeCombo.UpdateContent(Enum.GetValues(typeof(SDFCreator.SDFFunction)).OfType<SDFCreator.SDFFunction>().Cast<object>()
			.Concat(array));
		Size = Mathf.FloorToInt(MainPanel.sizeDelta.x);
		_targetTex = new RenderTexture(Size * 2, Size * 2, 0);
		_selectionTex = new RenderTexture(Size * 2, Size * 2, 0);
		MainImage.texture = _targetTex;
		SelectionImage.texture = _selectionTex;
		foreach (object value in Enum.GetValues(typeof(SDFCreator.SDFFunction)))
		{
			Button button = UnityEngine.Object.Instantiate(SDFButtonPrefab);
			button.GetComponentInChildren<RawImage>().texture = GetSDFIcon(value);
			SDFCreator.SDFFunction sdfFunction = (SDFCreator.SDFFunction)value;
			button.onClick.AddListener(delegate
			{
				SDFLayer sDFLayer = CreateSDFLayer(SDFSuperNode.Type.Shape);
				if (sDFLayer != null)
				{
					sDFLayer.Node.Function = sdfFunction;
					sDFLayer.Node.SDFParams = SDFCreator.GetDefaultParameters(sdfFunction);
					sDFLayer.Refresh();
					UpdateEverything();
				}
			});
			button.GetComponent<GUIToolTipper>().ToolTipValue = sdfFunction.ToString();
			button.transform.SetParent(CreationPanel, false);
			button.gameObject.SetActive(true);
		}
		string[] array2 = array;
		foreach (string tex in array2)
		{
			Button button2 = UnityEngine.Object.Instantiate(SDFButtonPrefab);
			button2.GetComponentInChildren<RawImage>().texture = GetSDFIcon(tex);
			button2.onClick.AddListener(delegate
			{
				SDFLayer sDFLayer = CreateSDFLayer(new SDFSuperNode
				{
					SDFType = SDFSuperNode.Type.Texture,
					SDFResource = tex,
					Scale = 1f
				});
				if (sDFLayer != null)
				{
					sDFLayer.Refresh();
					UpdateEverything();
				}
			});
			button2.GetComponent<GUIToolTipper>().ToolTipValue = tex;
			button2.transform.SetParent(CreationPanel, false);
			button2.gameObject.SetActive(true);
		}
		UpdateParameters(null);
		ComplexityLabel.text = "Complexity".Loc() + ": 0%";
	}

	public void UpdateSelectionTex()
	{
		SDFCreator.ISDFOutput iSDFOutput = null;
		if (_topLevelActiveLayers.Count != 0)
		{
			if (_topLevelActiveLayers.Count == 1)
			{
				iSDFOutput = GetSelectionTree(_topLevelActiveLayers.First());
			}
			else
			{
				SDFCreator.SDFMix sDFMix = new SDFCreator.SDFMix(null, null, Vector2.zero);
				iSDFOutput = sDFMix;
				bool flag = true;
				foreach (SDFLayer topLevelActiveLayer in _topLevelActiveLayers)
				{
					SDFCreator.SDFExport selectionTree = GetSelectionTree(topLevelActiveLayer);
					if (selectionTree != null)
					{
						if (flag)
						{
							sDFMix.Input1 = selectionTree;
							flag = false;
						}
						else
						{
							sDFMix.Input2 = selectionTree;
							sDFMix = new SDFCreator.SDFMix(sDFMix, null, Vector2.zero);
							iSDFOutput = sDFMix;
						}
					}
				}
				if (flag)
				{
					iSDFOutput = null;
				}
				else if (sDFMix.Input2 == null)
				{
					iSDFOutput = sDFMix.Input1;
				}
			}
		}
		if (iSDFOutput != null)
		{
			SDFCreator.Instance.Render(iSDFOutput, _selectionTex);
			return;
		}
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = _selectionTex;
		GL.Clear(false, true, Color.clear);
		RenderTexture.active = active;
	}

	public SDFCreator.SDFExport GetSelectionTree(SDFLayer layer)
	{
		SDFSuperNode parent = layer.Node.Parent;
		try
		{
			layer.Node.Parent = null;
			SDFCreator.SDFExport sDFExport = (SDFCreator.SDFExport)CreateTree(new List<SDFSuperNode> { layer.Node }, false);
			sDFExport.MainColor = Color.clear;
			sDFExport.GradientColor = Color.clear;
			sDFExport.OutlineColor = Color.cyan;
			sDFExport.Outline = 0.02f / MainPanel.localScale.x;
			sDFExport.Threshold = -0.01f / MainPanel.localScale.x;
			layer.Node.Parent = parent;
			SDFSuperNode transformParent = layer.Node.GetTransformParent();
			if (transformParent != null)
			{
				sDFExport.Pos = transformParent.Pos;
				sDFExport.Rotation = 360f - transformParent.Rotation;
				sDFExport.Scale = transformParent.Scale * transformParent.GetScaleFactor() * Vector2.one;
			}
			return sDFExport;
		}
		catch (Exception)
		{
		}
		layer.Node.Parent = parent;
		return null;
	}

	private void OnDestroy()
	{
		if (_targetTex != null)
		{
			UnityEngine.Object.Destroy(_targetTex);
			UnityEngine.Object.Destroy(_selectionTex);
		}
	}

	public void UpdateEverything()
	{
		UpdateLayerBox(_topLevelActiveLayers, true);
		UpdateParameters((_activeLayers.Count == 1) ? _activeLayers.First() : null);
	}

	public void UpdateLayerBox(HashSet<SDFLayer> layers, bool initParams)
	{
		LayerBox.gameObject.SetActive(layers.Count > 0);
		SelectionImage.gameObject.SetActive(LayerBox.gameObject.activeSelf);
		if (initParams)
		{
			_sliderParamPool.ReleaseAll();
		}
		ReflectLine.SetActive(false);
		if (layers.Count == 1)
		{
			SDFLayer layer = layers.First();
			ReflectLine.SetActive(layer.Node.SDFType == SDFSuperNode.Type.Reflect);
			Vector3 position;
			Quaternion rotation;
			Vector3 scale;
			layer.Node.GetTRS().ExtractTRS(out position, out rotation, out scale);
			LayerBox.rotation = rotation;
			LayerBox.anchoredPosition = new Vector2(position.x, 0f - position.y) * Size;
			LayerBox.sizeDelta = scale * Size;
			float num = LayerBox.rotation.eulerAngles.z + 45f;
			for (int i = 0; i < DragCorners.Length; i++)
			{
				if (layer.Node.SDFType == SDFSuperNode.Type.Mirror || layer.Node.SDFType == SDFSuperNode.Type.Reflect)
				{
					DragCorners[i].gameObject.SetActive(false);
					continue;
				}
				DragCorners[i].gameObject.SetActive(true);
				DragCorners[i].Cursor = Utilities.UIDirectionToIcon(num + Offsets[i]);
			}
			if (!initParams || layer.Node.SDFType != SDFSuperNode.Type.Shape)
			{
				return;
			}
			SDFCreator.ParameterInfo[] parameters = SDFCreator.GetParameters(layer.Node.Function);
			for (int j = 0; j < parameters.Length; j++)
			{
				SDFCreator.ParameterInfo pp = parameters[j];
				if (pp.UseSlider)
				{
					int i2 = j;
					AddSlider(pp.Start, pp.End, layer.Node.SDFParams[j].MapRange(pp.Min, pp.Max, 0f, 1f), delegate(float x)
					{
						Vector4 sDFParams = ((SVector3)layer.Node.SDFParams).Swizzle(x.MapRange(0f, 1f, pp.Min, pp.Max), i2).ToVector4();
						layer.Node.SDFParams = sDFParams;
						Dirty = 1;
						UpdateParameters(layer);
					});
				}
			}
		}
		else
		{
			if (layers.Count <= 1)
			{
				return;
			}
			Vector2 vector = new Vector2(float.MaxValue, float.MaxValue);
			Vector2 vector2 = new Vector2(float.MinValue, float.MinValue);
			foreach (SDFLayer layer2 in layers)
			{
				Vector3 position2;
				Quaternion rotation2;
				Vector3 scale2;
				layer2.Node.GetTRS().ExtractTRS(out position2, out rotation2, out scale2);
				Vector2 vector3 = new Vector2(position2.x, position2.y);
				vector = Vector2.Min(vector3 - Vector2.one * scale2.x * 0.5f, vector);
				vector2 = Vector2.Max(vector3 + Vector2.one * scale2.x * 0.5f, vector2);
			}
			LayerBox.rotation = Quaternion.identity;
			Vector2 vector4 = (vector + vector2) * 0.5f;
			LayerBox.anchoredPosition = new Vector2(vector4.x, 0f - vector4.y) * Size;
			LayerBox.sizeDelta = new Vector2(vector2.x - vector.x, vector2.y - vector.y) * Size;
			float num2 = LayerBox.rotation.eulerAngles.z + 45f;
			for (int num3 = 0; num3 < DragCorners.Length; num3++)
			{
				DragCorners[num3].gameObject.SetActive(true);
				DragCorners[num3].Cursor = Utilities.UIDirectionToIcon(num2 + Offsets[num3]);
			}
		}
	}

	public void AddSlider(Vector2 a, Vector2 b, float defValue, Action<float> onChange)
	{
		a = a * LayerBox.sizeDelta * 0.5f;
		b = b * LayerBox.sizeDelta * 0.5f;
		Slider slider = _sliderParamPool.Get();
		slider.value = defValue;
		RectTransform component = slider.GetComponent<RectTransform>();
		component.anchoredPosition = (a + b) * 0.5f;
		component.sizeDelta = new Vector2((a - b).magnitude, 4f);
		component.localRotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(b.y - a.y, b.x - a.x) * 57.29578f);
		slider.onValueChanged.AddListener(delegate(float x)
		{
			onChange(x);
		});
	}

	private void ToggleTool(Transform t, bool enable)
	{
		t.gameObject.SetActive(enable);
		t.parent.GetChild(t.GetSiblingIndex() - 1).gameObject.SetActive(enable);
	}

	public void UpdateParameters(SDFLayer layer)
	{
		_disableInspector = true;
		SDFSuperNode sDFSuperNode = (((object)layer != null) ? layer.Node : null);
		ToggleTool(TypeCombo.transform, layer != null && sDFSuperNode.Parent != null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(ShapeCombo.transform, layer != null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(CombineParam.transform, layer != null && sDFSuperNode.Parent != null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(TransformColor.transform, layer != null && sDFSuperNode.Parent == null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(Subtraction.transform, layer != null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(GradientRotation.transform, layer != null && sDFSuperNode.Parent == null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(GradientLinear.transform, layer != null && sDFSuperNode.Parent == null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(WaveAmountX.transform, layer != null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(WaveAmountY.transform, layer != null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(WaveFrequencyX.transform, layer != null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(WaveFrequencyY.transform, layer != null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(SkewX.transform, layer != null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(SkewY.transform, layer != null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(Distortion.transform, layer != null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(EffectThreshold.transform, layer != null && sDFSuperNode.Parent != null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(Smoothing.transform, layer != null && sDFSuperNode.SDFType == SDFSuperNode.Type.Shape);
		ToggleTool(Rotation.transform, layer != null && sDFSuperNode.SDFType == SDFSuperNode.Type.Mirror);
		ToggleTool(FlipX.transform, layer != null && sDFSuperNode.SDFType == SDFSuperNode.Type.Mirror);
		ToggleTool(FlipY.transform, layer != null && sDFSuperNode.SDFType == SDFSuperNode.Type.Mirror);
		ToggleTool(Times.transform, layer != null && sDFSuperNode.SDFType == SDFSuperNode.Type.Mirror);
		ToggleTool(Outline.transform, layer != null && sDFSuperNode.Parent == null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(MainColor.transform, layer != null && sDFSuperNode.Parent == null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(OutlineColor.transform, layer != null && sDFSuperNode.Parent == null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(GradientColor.transform, layer != null && sDFSuperNode.Parent == null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(Threshold.transform, layer != null && sDFSuperNode.Parent == null && (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture));
		ToggleTool(SDFParameters[0].transform, false);
		ToggleTool(SDFParameters[1].transform, false);
		ToggleTool(SDFParameters[2].transform, false);
		ToggleTool(SDFParameters[3].transform, false);
		if (layer != null)
		{
			if (sDFSuperNode.SDFType == SDFSuperNode.Type.Shape || sDFSuperNode.SDFType == SDFSuperNode.Type.Texture)
			{
				TypeCombo.Selected = (int)sDFSuperNode.CombineType;
				TransformColor.isOn = sDFSuperNode.TransformColor;
				MainColor.color = sDFSuperNode.MainColor;
				GradientColor.color = sDFSuperNode.GradientColor;
				OutlineColor.color = sDFSuperNode.OutlineColor;
				Outline.value = sDFSuperNode.Outline;
				Smoothing.value = sDFSuperNode.Rounding;
				CombineParam.value = sDFSuperNode.CombineParam;
				Distortion.value = sDFSuperNode.Distortion;
				Subtraction.value = sDFSuperNode.Subtraction;
				Threshold.value = sDFSuperNode.Threshold;
				EffectThreshold.value = sDFSuperNode.EffectThreshold;
				GradientLinear.isOn = sDFSuperNode.GradientLinear;
				GradientRotation.value = sDFSuperNode.GradientRotation;
				WaveAmountX.value = sDFSuperNode.WaveAmount.x;
				WaveAmountY.value = sDFSuperNode.WaveAmount.y;
				WaveFrequencyX.value = sDFSuperNode.WaveFrequency.x;
				WaveFrequencyY.value = sDFSuperNode.WaveFrequency.y;
				SkewX.value = sDFSuperNode.Skew.x;
				SkewY.value = sDFSuperNode.Skew.y;
			}
			switch (sDFSuperNode.SDFType)
			{
			case SDFSuperNode.Type.Shape:
			{
				ShapeCombo.SelectedItem = sDFSuperNode.Function;
				SDFCreator.ParameterInfo[] parameters = SDFCreator.GetParameters(sDFSuperNode.Function);
				for (int i = 0; i < SDFParameters.Length; i++)
				{
					if (i < parameters.Length)
					{
						SDFCreator.ParameterInfo parameterInfo = parameters[i];
						SDFParameters[i].transform.parent.GetChild(SDFParameters[i].transform.GetSiblingIndex() - 1).GetComponent<Text>().text = parameterInfo.Name.Loc();
						ToggleTool(SDFParameters[i].transform, true);
						SDFParameters[i].value = sDFSuperNode.SDFParams[i];
						SDFParameters[i].minValue = parameterInfo.Min;
						SDFParameters[i].maxValue = parameterInfo.Max;
					}
					else
					{
						ToggleTool(SDFParameters[i].transform, false);
					}
				}
				break;
			}
			case SDFSuperNode.Type.Texture:
				ShapeCombo.SelectedItem = sDFSuperNode.SDFResource;
				break;
			case SDFSuperNode.Type.Mirror:
				Rotation.value = sDFSuperNode.Offset;
				FlipX.isOn = sDFSuperNode.FlipX;
				FlipY.isOn = sDFSuperNode.FlipY;
				Times.value = sDFSuperNode.Times;
				break;
			}
		}
		_disableInspector = false;
	}

	public void ShapeChanged()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (_disableInspector || firstActiveLayer == null)
		{
			return;
		}
		object selectedItem;
		if ((selectedItem = ShapeCombo.SelectedItem) is SDFCreator.SDFFunction)
		{
			SDFCreator.SDFFunction function = (SDFCreator.SDFFunction)selectedItem;
			firstActiveLayer.Node.Function = function;
			if (firstActiveLayer.Node.SDFType == SDFSuperNode.Type.Texture)
			{
				firstActiveLayer.Node.Scale *= 0.5f;
				firstActiveLayer.Node.SDFType = SDFSuperNode.Type.Shape;
			}
		}
		else
		{
			firstActiveLayer.Node.SDFResource = ShapeCombo.SelectedItem.ToString();
			if (firstActiveLayer.Node.SDFType == SDFSuperNode.Type.Shape)
			{
				firstActiveLayer.Node.Scale *= 2f;
				firstActiveLayer.Node.SDFType = SDFSuperNode.Type.Texture;
			}
		}
		firstActiveLayer.Refresh();
		Dirty = 1;
		UpdateEverything();
	}

	public void ValueChangeEffectThreshold()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			firstActiveLayer.Node.EffectThreshold = EffectThreshold.value;
			Dirty = 1;
		}
	}

	public void ValueChangeDistortion()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			firstActiveLayer.Node.Distortion = Distortion.value;
			Dirty = 1;
		}
	}

	public void ValueChangeCombineParam()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			firstActiveLayer.Node.CombineParam = CombineParam.value;
			Dirty = 1;
		}
	}

	public void ValueChangeTransformColor()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			firstActiveLayer.Node.TransformColor = TransformColor.isOn;
			Dirty = 1;
		}
	}

	public void ValueChangeParameter()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			firstActiveLayer.Node.SDFParams = new Vector4(SDFParameters[0].value, SDFParameters[1].value, SDFParameters[2].value, SDFParameters[3].value);
			Dirty = 1;
		}
	}

	public void ValueChangeGradientRot()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			firstActiveLayer.Node.GradientRotation = GradientRotation.value;
			Dirty = 1;
		}
	}

	public void ValueChangeSkew()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			firstActiveLayer.Node.Skew = new Vector2(SkewX.value, SkewY.value);
			Dirty = 1;
		}
	}

	public void ValueChangeWave()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			firstActiveLayer.Node.WaveAmount = new Vector2(WaveAmountX.value, WaveAmountY.value);
			firstActiveLayer.Node.WaveFrequency = new Vector2(WaveFrequencyX.value, WaveFrequencyY.value);
			Dirty = 1;
		}
	}

	public void ValueChangeTimes()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			firstActiveLayer.Node.Times = Mathf.RoundToInt(Times.value);
			Dirty = 1;
		}
	}

	public void ValueChangeGradientLinear()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			firstActiveLayer.Node.GradientLinear = GradientLinear.isOn;
			Dirty = 1;
		}
	}

	public void ValueChangeFlip()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			firstActiveLayer.Node.FlipX = FlipX.isOn;
			firstActiveLayer.Node.FlipY = FlipY.isOn;
			Dirty = 1;
		}
	}

	public void ValueChangeThreshold()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			firstActiveLayer.Node.Threshold = Threshold.value;
			Dirty = 1;
		}
	}

	public void ValueChangeSubtraction()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			firstActiveLayer.Node.Subtraction = Subtraction.value;
			Dirty = 1;
		}
	}

	public void ValueChangeRotation()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			firstActiveLayer.Node.Offset = Rotation.value;
			Dirty = 1;
		}
	}

	public void ValueChangeSmoothing()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			firstActiveLayer.Node.Rounding = Smoothing.value;
			Dirty = 1;
		}
	}

	public void ValueChangeOutline()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			firstActiveLayer.Node.Outline = Outline.value;
			firstActiveLayer.Refresh();
			Dirty = 1;
		}
	}

	public void ValueChangeMainColor()
	{
		SDFLayer ActiveLayer = FirstActiveLayer;
		if (_disableInspector || ActiveLayer == null)
		{
			return;
		}
		bool wasEqual = ActiveLayer.Node.MainColor == ActiveLayer.Node.GradientColor;
		SDFSuperNode active = ActiveLayer.Node;
		ColorWindow colorWindow = WindowManager.SpawnColorDialog(delegate(Color x)
		{
			MainColor.color = x;
			active.MainColor = x;
			if (wasEqual)
			{
				GradientColor.color = x;
				active.GradientColor = x;
			}
			ActiveLayer.Refresh();
			Dirty = 1;
		}, active.MainColor);
		if (ParentWindow != null)
		{
			colorWindow.Window.SetParentWindow(ParentWindow.Window, true);
			colorWindow.Window.HideBlockPanel = false;
		}
	}

	public void ReverseColors()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			SDFSuperNode node = firstActiveLayer.Node;
			SDFSuperNode node2 = firstActiveLayer.Node;
			Color gradientColor = firstActiveLayer.Node.GradientColor;
			Color mainColor = firstActiveLayer.Node.MainColor;
			node.MainColor = gradientColor;
			node2.GradientColor = mainColor;
			Image mainColor2 = MainColor;
			Image gradientColor2 = GradientColor;
			mainColor = GradientColor.color;
			gradientColor = MainColor.color;
			Color color = (mainColor2.color = mainColor);
			color = (gradientColor2.color = gradientColor);
			firstActiveLayer.Refresh();
			Dirty = 1;
		}
	}

	public void ValueChangeGradientColor()
	{
		SDFLayer ActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(ActiveLayer == null))
		{
			SDFSuperNode active = ActiveLayer.Node;
			ColorWindow colorWindow = WindowManager.SpawnColorDialog(delegate(Color x)
			{
				GradientColor.color = x;
				active.GradientColor = x;
				ActiveLayer.Refresh();
				Dirty = 1;
			}, active.GradientColor);
			if (ParentWindow != null)
			{
				colorWindow.Window.SetParentWindow(ParentWindow.Window, true);
				colorWindow.Window.HideBlockPanel = false;
			}
		}
	}

	public void ValueChangeOutlineColor()
	{
		SDFLayer ActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(ActiveLayer == null))
		{
			SDFSuperNode active = ActiveLayer.Node;
			ColorWindow colorWindow = WindowManager.SpawnColorDialog(delegate(Color x)
			{
				OutlineColor.color = x;
				active.OutlineColor = x;
				ActiveLayer.Refresh();
				Dirty = 1;
			}, active.OutlineColor);
			if (ParentWindow != null)
			{
				colorWindow.Window.SetParentWindow(ParentWindow.Window, true);
				colorWindow.Window.HideBlockPanel = false;
			}
		}
	}

	public void ValueChangeType()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (!_disableInspector && !(firstActiveLayer == null))
		{
			firstActiveLayer.Node.CombineType = (SDFCreator.CombineFunction)TypeCombo.Selected;
			firstActiveLayer.Refresh();
			Dirty = 1;
			UpdateParameters(firstActiveLayer);
		}
	}

	public void StartDragging(SDFLayer layer)
	{
		_isDragging = layer;
		layer.gameObject.SetActive(false);
		Dragger.gameObject.SetActive(true);
		DragDisabler.enabled = true;
		Layers.Remove(layer.Node);
	}

	public int LayerCount()
	{
		int num = 0;
		for (int i = 0; i < LayerPanel.childCount; i++)
		{
			Transform child = LayerPanel.GetChild(i);
			if (child != Dragger.transform && child.gameObject.activeSelf)
			{
				num++;
			}
		}
		return num;
	}

	public SDFLayer GetLayer(int index)
	{
		int num = 0;
		for (int i = 0; i < LayerPanel.childCount; i++)
		{
			Transform child = LayerPanel.GetChild(i);
			if (child != Dragger.transform && child.gameObject.activeSelf)
			{
				if (num == index)
				{
					return child.GetComponent<SDFLayer>();
				}
				num++;
			}
		}
		return null;
	}

	private Vector2 GetLayerBoxLocalPosition()
	{
		return new Vector2(LayerBox.anchoredPosition.x, 0f - LayerBox.anchoredPosition.y) / Size;
	}

	private Vector2 ConvertToLocal(Vector2 input)
	{
		return new Vector2(input.x, 0f - input.y) / Size;
	}

	private void ChangeRotation(SDFLayer layer, float deg)
	{
		Vector2 vector = layer.Node.GetLastBoxCenter() - GetLayerBoxLocalPosition();
		Vector3 vector2 = Quaternion.Euler(0f, 0f, 0f - deg) * vector;
		layer.Node.Rotation = layer.Node.LastRot + deg;
		layer.Node.Pos = layer.Node.LastPos + new Vector2(vector2.x, vector2.y) - vector;
		if (layer.Node.TransformColor)
		{
			return;
		}
		layer.Node.Children.ForEach(delegate(SDFSuperNode x)
		{
			if (x.IsGraphic())
			{
				ChangeRotation(x.UILayer, deg);
			}
		});
	}

	private void ChangePosition(SDFLayer layer, Vector2 change)
	{
		layer.Node.SetLastBoxCenter(change / Size);
		if (layer.Node.TransformColor)
		{
			return;
		}
		layer.Node.Children.ForEach(delegate(SDFSuperNode x)
		{
			if (x.IsGraphic())
			{
				ChangePosition(x.UILayer, change);
			}
		});
	}

	private void ChangeScale(SDFLayer layer, float newScale)
	{
		if (Input.GetKey(KeyCode.LeftControl))
		{
			int num = StepSize * 4;
			int num2 = Mathf.CeilToInt(Mathf.Sign(newScale) * Mathf.Sqrt(newScale * newScale * 2f) / (float)num) * num;
			newScale = Mathf.Sign(newScale) * Mathf.Sqrt((float)(num2 * num2) / 2f);
		}
		newScale *= layer.Node.LastScale;
		float num3 = Mathf.Sign(newScale) * Mathf.Sqrt(newScale * newScale * 2f);
		Vector2 vector = layer.Node.GetLastBoxCenter() - (Input.GetKey(KeyCode.LeftShift) ? _scaleStart : ConvertToLocal(_scalingBox.Value));
		if (Input.GetKey(KeyCode.LeftShift))
		{
			layer.Node.Scale = layer.Node.LastScale + num3 / (float)Size / layer.Node.GetScaleFactor();
			layer.Node.SetBoxCenter(_scaleStart + vector * (1f + num3 * 0.5f / layer.Node.LastScale / (float)Size));
		}
		else
		{
			layer.Node.Scale = layer.Node.LastScale + num3 / (float)Size / layer.Node.GetScaleFactor() * 0.5f;
			layer.Node.SetBoxCenter(ConvertToLocal(_scalingBox.Value) + vector * (1f + num3 * 0.5f / (layer.Node.LastScale / 0.5f) / (float)Size));
		}
		if (layer.Node.TransformColor)
		{
			return;
		}
		layer.Node.Children.ForEach(delegate(SDFSuperNode x)
		{
			if (x.IsGraphic())
			{
				ChangeScale(x.UILayer, newScale / layer.Node.LastScale);
			}
		});
	}

	public void Align(bool hor)
	{
		if (_activeLayers.Count <= 1)
		{
			return;
		}
		if (hor)
		{
			float y = _activeLayers.Average((SDFLayer sDFLayer) => sDFLayer.Node.Pos.y);
			_activeLayers.ForEachEnum(delegate(SDFLayer z)
			{
				z.Node.Pos = new Vector2(z.Node.Pos.x, y);
			});
		}
		else
		{
			float x = _activeLayers.Average((SDFLayer z) => z.Node.Pos.x);
			_activeLayers.ForEachEnum(delegate(SDFLayer z)
			{
				z.Node.Pos = new Vector2(x, z.Node.Pos.y);
			});
		}
		Dirty = 1;
		UpdateLayerBox(_topLevelActiveLayers, true);
	}

	public void Spread(bool spreadOut)
	{
		if (_activeLayers.Count <= 1)
		{
			return;
		}
		float x = (_activeLayers.Min((SDFLayer sDFLayer) => sDFLayer.Node.Pos.x) + _activeLayers.Max((SDFLayer sDFLayer) => sDFLayer.Node.Pos.x)) * 0.5f;
		float y = (_activeLayers.Min((SDFLayer sDFLayer) => sDFLayer.Node.Pos.y) + _activeLayers.Max((SDFLayer sDFLayer) => sDFLayer.Node.Pos.y)) * 0.5f;
		Vector2 c = new Vector2(x, y);
		if (spreadOut)
		{
			_activeLayers.ForEachEnum(delegate(SDFLayer z)
			{
				z.Node.Pos += (z.Node.Pos - c).normalized * (1f / (float)Size);
			});
		}
		else
		{
			_activeLayers.ForEachEnum(delegate(SDFLayer z)
			{
				z.Node.Pos += (c - z.Node.Pos).normalized * (1f / (float)Size);
			});
		}
		Dirty = 1;
		UpdateLayerBox(_topLevelActiveLayers, true);
	}

	public void Distribute(bool hor)
	{
		if (_activeLayers.Count <= 2)
		{
			return;
		}
		if (hor)
		{
			float num = _activeLayers.Min((SDFLayer x) => x.Node.Pos.x);
			float num2 = _activeLayers.Max((SDFLayer x) => x.Node.Pos.x);
			int num3 = 0;
			foreach (SDFLayer item in _activeLayers.OrderBy((SDFLayer x) => x.Node.Pos.x))
			{
				item.Node.Pos = new Vector2(num + (num2 - num) / (float)(_activeLayers.Count - 1) * (float)num3, item.Node.Pos.y);
				num3++;
			}
		}
		else
		{
			float num4 = _activeLayers.Min((SDFLayer x) => x.Node.Pos.y);
			float num5 = _activeLayers.Max((SDFLayer x) => x.Node.Pos.y);
			int num6 = 0;
			foreach (SDFLayer item2 in _activeLayers.OrderBy((SDFLayer x) => x.Node.Pos.y))
			{
				item2.Node.Pos = new Vector2(item2.Node.Pos.x, num4 + (num5 - num4) / (float)(_activeLayers.Count - 1) * (float)num6);
				num6++;
			}
		}
		Dirty = 1;
		UpdateLayerBox(_topLevelActiveLayers, true);
	}

	public void UpdateActivation()
	{
		foreach (SDFSuperNode layer in Layers)
		{
			layer.UILayer.UpdateActivation(true);
		}
	}

	private void Update()
	{
		if (_isDragging != null)
		{
			Vector2 localPoint;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(LayerPanel, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
			{
				int num = Mathf.FloorToInt((0f - localPoint.y) / 17f);
				Dragger.anchoredPosition = new Vector2(0f, -Mathf.Clamp(num, 0, LayerCount() * 2) * 17);
				bool flag = num % 2 == 0;
				Dragger.offsetMin = new Vector2((!flag) ? 32 : 0, Dragger.offsetMin.y);
				Dragger.sizeDelta = new Vector2(Dragger.sizeDelta.x, flag ? 4 : 8);
			}
			if (Input.GetMouseButtonUp(0))
			{
				int num2 = Mathf.FloorToInt((0f - Dragger.anchoredPosition.y) / 17f);
				Dragger.anchoredPosition = new Vector2(0f, 0f - localPoint.y);
				bool flag2 = true;
				if (num2 % 2 == 0)
				{
					SDFLayer layer = GetLayer(num2 / 2);
					if (layer == null)
					{
						if (_isDragging.Node.IsGraphic())
						{
							_isDragging.Node.SetParent(null);
							Layers.Insert(0, _isDragging.Node);
						}
					}
					else if (layer.Node.Parent != null)
					{
						if (layer.Node.Parent.CanBeParentOf(_isDragging.Node))
						{
							_isDragging.Node.SetParent(layer.Node.Parent, layer.Node.Parent.Children.IndexOf(layer.Node) + 1);
						}
						else
						{
							flag2 = false;
						}
					}
					else if (_isDragging.Node.IsGraphic())
					{
						_isDragging.Node.SetParent(null);
						Layers.Insert(Layers.IndexOf(layer.Node) + 1, _isDragging.Node);
					}
				}
				else
				{
					SDFSuperNode node = GetLayer(num2 / 2).Node;
					if (node.CanBeParentOf(_isDragging.Node))
					{
						_isDragging.Node.SetParent(node);
					}
					else
					{
						flag2 = false;
					}
				}
				if (!flag2 && _isDragging.Node.Parent == null)
				{
					Layers.Insert(0, _isDragging.Node);
				}
				ArrangeLayers();
				_isDragging.gameObject.SetActive(true);
				UpdateParameters(_isDragging);
				_isDragging = null;
				DragDisabler.enabled = false;
				Dragger.gameObject.SetActive(false);
				Dirty = 1;
				UpdateActivation();
			}
		}
		else if (Dirty > 0)
		{
			Dirty--;
			if (Dirty == 0)
			{
				if (_topLevelActiveLayers.Count > 0)
				{
					UpdateSelectionTex();
				}
				SDFCreator.ISDFOutput iSDFOutput;
				try
				{
					iSDFOutput = CreateTree(Layers, true);
					_lastComplexity = ((iSDFOutput == null) ? 0f : ((float)iSDFOutput.CountNodes() / 25f));
					ComplexityLabel.text = "Complexity".Loc() + ": " + _lastComplexity.ToPercent();
					if (_lastComplexity > 1f)
					{
						ComplexityLabel.text = ComplexityLabel.text.FontColor(Color.red);
					}
				}
				catch (Exception exception)
				{
					iSDFOutput = null;
					Debug.LogException(exception);
				}
				if (iSDFOutput == null)
				{
					RenderTexture active = RenderTexture.active;
					RenderTexture.active = _targetTex;
					GL.Clear(false, true, Color.clear);
					RenderTexture.active = active;
				}
				else
				{
					SDFCreator.Instance.Render(iSDFOutput, _targetTex);
				}
			}
		}
		if (_movingBox)
		{
			Vector2 localPoint2;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(MainPanel, Input.mousePosition, UICamSize.GetUICam(), out localPoint2))
			{
				Dirty = 1;
				Vector2 change = new Vector2(localPoint2.x, 0f - localPoint2.y) - _moveLast;
				if (Input.GetKey(KeyCode.LeftControl))
				{
					change = new Vector2(Mathf.FloorToInt(change.x / (float)StepSize) * StepSize, Mathf.FloorToInt(change.y / (float)StepSize) * StepSize) + new Vector2((0f - _posLast.x) % (float)StepSize, _posLast.y % (float)StepSize);
				}
				foreach (SDFLayer topLevelActiveLayer in _topLevelActiveLayers)
				{
					ChangePosition(topLevelActiveLayer, change);
				}
				UpdateLayerBox(_topLevelActiveLayers, true);
			}
			if (Input.GetMouseButtonUp(0))
			{
				_movingBox = false;
				_lastHitMP = null;
				HintLabel.gameObject.SetActive(false);
			}
		}
		else if (_rotatingBox)
		{
			Vector2 localPoint3;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(MainPanel, Input.mousePosition, UICamSize.GetUICam(), out localPoint3))
			{
				Vector2 anchoredPosition = LayerBox.anchoredPosition;
				float num3 = Mathf.Atan2(anchoredPosition.y - localPoint3.y, anchoredPosition.x - localPoint3.x) * 57.29578f;
				float num4 = num3;
				if (Input.GetKey(KeyCode.LeftShift))
				{
					num3 = Mathf.Round(num3 / 22.5f) * 22.5f + _lastRot % 22.5f - _boxRot % 22.5f;
					num4 = Mathf.Round(num3 / 22.5f) * 22.5f;
				}
				foreach (SDFLayer topLevelActiveLayer2 in _topLevelActiveLayers)
				{
					ChangeRotation(topLevelActiveLayer2, num3 - _lastRot);
				}
				LayerBox.rotation = Quaternion.Euler(0f, 0f, num4 + 90f);
				Dirty = 1;
			}
			if (Input.GetMouseButtonUp(0))
			{
				_rotatingBox = false;
				_lastHitMP = null;
				HintLabel.gameObject.SetActive(false);
				UpdateLayerBox(_topLevelActiveLayers, true);
			}
		}
		else if (_scalingBox.HasValue)
		{
			Vector2 localPoint4;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(MainPanel, Input.mousePosition, UICamSize.GetUICam(), out localPoint4))
			{
				Dirty = 1;
				float magnitude = (_scalingBox.Value - localPoint4).magnitude;
				foreach (SDFLayer topLevelActiveLayer3 in _topLevelActiveLayers)
				{
					ChangeScale(topLevelActiveLayer3, (magnitude - _lastScale) / (_lastScaling * 0.5f));
				}
				UpdateLayerBox(_topLevelActiveLayers, true);
			}
			if (Input.GetMouseButtonUp(0))
			{
				_scalingBox = null;
				_lastHitMP = null;
				HintLabel.gameObject.SetActive(false);
			}
		}
		else if (Input.GetMouseButtonDown(0) && ActuallyHitCanvas())
		{
			_pressedCanvas = true;
			_lastHitMP = null;
			Vector2 localPoint5;
			if (_activeLayers.Count == 0)
			{
				HandleSelection();
			}
			else if (_activeLayers.Count > 0 && RectTransformUtility.ScreenPointToLocalPointInRectangle(MainPanel, Input.mousePosition, UICamSize.GetUICam(), out localPoint5))
			{
				bool flag3 = false;
				foreach (SDFLayer activeLayer in _activeLayers)
				{
					if (CheckHit(activeLayer, false) != null)
					{
						_moveLast = new Vector2(localPoint5.x, 0f - localPoint5.y);
						_posLast = LayerBox.anchoredPosition;
						_lastHitMP = Input.mousePosition;
						UpdateLayerBox(_topLevelActiveLayers, true);
						flag3 = true;
						break;
					}
				}
				if (!flag3)
				{
					HandleSelection();
				}
			}
		}
		else if (Input.GetMouseButton(0) && _topLevelActiveLayers.Count > 0 && _lastHitMP.HasValue && (Input.mousePosition - _lastHitMP.Value).magnitude > 4f)
		{
			StartMovingBox();
		}
		else if (Input.GetMouseButtonUp(0) && _pressedCanvas && ActuallyHitCanvas())
		{
			_lastHitMP = null;
		}
		else if (_topLevelActiveLayers.Count > 0)
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				foreach (SDFLayer topLevelActiveLayer4 in _topLevelActiveLayers)
				{
					MoveLayer(topLevelActiveLayer4, Vector2.left / Size);
				}
				Dirty = 1;
				UpdateLayerBox(_topLevelActiveLayers, true);
				InputController.LockKey(KeyCode.LeftArrow);
			}
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				foreach (SDFLayer topLevelActiveLayer5 in _topLevelActiveLayers)
				{
					MoveLayer(topLevelActiveLayer5, Vector2.down / Size);
				}
				Dirty = 1;
				UpdateLayerBox(_topLevelActiveLayers, true);
				InputController.LockKey(KeyCode.UpArrow);
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				foreach (SDFLayer topLevelActiveLayer6 in _topLevelActiveLayers)
				{
					MoveLayer(topLevelActiveLayer6, Vector2.up / Size);
				}
				Dirty = 1;
				UpdateLayerBox(_topLevelActiveLayers, true);
				InputController.LockKey(KeyCode.DownArrow);
			}
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				foreach (SDFLayer topLevelActiveLayer7 in _topLevelActiveLayers)
				{
					MoveLayer(topLevelActiveLayer7, Vector2.right / Size);
				}
				Dirty = 1;
				UpdateLayerBox(_topLevelActiveLayers, true);
				InputController.LockKey(KeyCode.RightArrow);
			}
			if (Input.GetKeyDown(KeyCode.Delete) && ParentWindow.Window.IsActiveWindow && !_isDragging)
			{
				foreach (SDFLayer item in _topLevelActiveLayers.ToList())
				{
					item.DestroyMe();
					MoveLayer(item, Vector2.right / Size);
				}
				InputController.LockKey(KeyCode.Delete);
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			_pressedCanvas = false;
		}
	}

	private void MoveLayer(SDFLayer layer, Vector2 off)
	{
		layer.Node.Pos += off;
		if (layer.Node.TransformColor)
		{
			return;
		}
		foreach (SDFSuperNode child in layer.Node.Children)
		{
			if (child.IsGraphic())
			{
				MoveLayer(child.UILayer, off);
			}
		}
	}

	private bool ActuallyHitCanvas()
	{
		if (RectTransformUtility.RectangleContainsScreenPoint(FullMainPanel, Input.mousePosition, UICamSize.GetUICam()))
		{
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			pointerEventData.pointerId = -1;
			pointerEventData.position = Input.mousePosition;
			List<RaycastResult> list = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerEventData, list);
			if (HasTransformParent(list[0].gameObject.transform, FullMainPanel.transform))
			{
				return true;
			}
		}
		return false;
	}

	private bool HasTransformParent(Transform t, Transform parent)
	{
		if (t.GetComponent<Slider>() != null)
		{
			return false;
		}
		if (t == parent)
		{
			return true;
		}
		if (t.parent != null)
		{
			return HasTransformParent(t.parent, parent);
		}
		return false;
	}

	public bool HandleSelection()
	{
		bool flag = false;
		for (int i = 0; i < LayerPanel.childCount; i++)
		{
			Transform child = LayerPanel.GetChild(i);
			if (!(child != Dragger.transform))
			{
				continue;
			}
			SDFLayer sDFLayer = CheckHit(child.GetComponent<SDFLayer>(), true);
			if (!(sDFLayer != null))
			{
				continue;
			}
			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (IsActiveLayer(sDFLayer))
				{
					RemoveActiveLayer(sDFLayer);
				}
				else
				{
					AddActiveLayer(sDFLayer);
				}
			}
			else
			{
				SetActiveLayer(sDFLayer);
			}
			_lastHitMP = Input.mousePosition;
			Vector2 localPoint;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(MainPanel, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
			{
				_moveLast = new Vector2(localPoint.x, 0f - localPoint.y);
				_posLast = LayerBox.anchoredPosition;
			}
			flag = true;
			break;
		}
		if (!flag && !Input.GetKey(KeyCode.LeftShift))
		{
			ClearActiveLayers();
		}
		return flag;
	}

	public SDFLayer CheckHit(SDFLayer l, bool children)
	{
		if (children)
		{
			foreach (SDFSuperNode child in l.Node.Children)
			{
				if (IsActiveLayer(child.UILayer) || child.UILayer.Show.isOn)
				{
					SDFLayer sDFLayer = CheckHit(child.UILayer, true);
					if (sDFLayer != null)
					{
						return sDFLayer;
					}
				}
			}
		}
		UpdateLayerBox(new HashSet<SDFLayer> { l }, false);
		if ((l.Show.isOn || IsActiveLayer(l)) && RectTransformUtility.RectangleContainsScreenPoint(LayerBox, Input.mousePosition, UICamSize.GetUICam()))
		{
			return l;
		}
		return null;
	}

	public void Clear(bool user = false)
	{
		if (user)
		{
			DialogWindow dialogWindow = WindowManager.Instance.ShowMessageBox("LogoDeletePrompt".Loc(), true, DialogWindow.DialogType.Question, ActualClear);
			if (ParentWindow != null)
			{
				dialogWindow.Window.SetParentWindow(ParentWindow.Window);
			}
		}
		else
		{
			ActualClear();
		}
	}

	private void ActualClear()
	{
		int childCount = LayerPanel.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Transform child = LayerPanel.GetChild(i);
			if (child != Dragger.transform)
			{
				UnityEngine.Object.Destroy(child.gameObject);
			}
		}
		Layers.Clear();
		Dirty = 1;
		_isDragging = null;
		_scalingBox = null;
		_rotatingBox = false;
		_movingBox = false;
		ClearActiveLayers();
	}

	public void ArrangeLayers()
	{
		int idx = 0;
		for (int num = Layers.Count - 1; num >= 0; num--)
		{
			SDFSuperNode sDFSuperNode = Layers[num];
			ArrangeLayer(sDFSuperNode, ref idx);
		}
	}

	private void ArrangeLayer(SDFSuperNode from, ref int idx)
	{
		from.UILayer.transform.SetSiblingIndex(idx);
		from.UILayer.Refresh();
		idx++;
		for (int num = from.Children.Count - 1; num >= 0; num--)
		{
			SDFSuperNode sDFSuperNode = from.Children[num];
			ArrangeLayer(sDFSuperNode, ref idx);
		}
	}

	public void CreateMirrorLayer()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (firstActiveLayer != null && firstActiveLayer.Node.IsGraphic())
		{
			if (CanCreate())
			{
				SDFLayer sDFLayer = CreateSDFLayerDirect(new SDFSuperNode
				{
					SDFType = SDFSuperNode.Type.Mirror,
					Pos = Vector2.one * 0.5f
				});
				sDFLayer.Node.SetParent(firstActiveLayer.Node);
				ArrangeLayers();
				SetActiveLayer(sDFLayer);
				Dirty = 1;
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("LogoComplexityLimit".Loc(), true, DialogWindow.DialogType.Error, ParentWindow.Window);
			}
		}
	}

	public void CreateReflectLayer()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (firstActiveLayer != null && firstActiveLayer.Node.IsGraphic())
		{
			if (CanCreate())
			{
				SDFLayer sDFLayer = CreateSDFLayerDirect(new SDFSuperNode
				{
					SDFType = SDFSuperNode.Type.Reflect,
					Pos = Vector2.one * 0.5f
				});
				sDFLayer.Node.SetParent(firstActiveLayer.Node);
				ArrangeLayers();
				SetActiveLayer(sDFLayer);
				Dirty = 1;
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("LogoComplexityLimit".Loc(), true, DialogWindow.DialogType.Error, ParentWindow.Window);
			}
		}
	}

	public void CreateArrayLayer()
	{
		SDFLayer firstActiveLayer = FirstActiveLayer;
		if (firstActiveLayer != null && firstActiveLayer.Node.IsGraphic())
		{
			if (CanCreate())
			{
				SDFLayer sDFLayer = CreateSDFLayerDirect(new SDFSuperNode
				{
					SDFType = SDFSuperNode.Type.Array
				});
				sDFLayer.Node.SetParent(firstActiveLayer.Node);
				ArrangeLayers();
				SetActiveLayer(sDFLayer);
				Dirty = 1;
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("LogoComplexityLimit".Loc(), true, DialogWindow.DialogType.Error, ParentWindow.Window);
			}
		}
	}

	public SDFLayer CreateSDFLayer(SDFSuperNode.Type type)
	{
		return CreateSDFLayer(new SDFSuperNode
		{
			SDFType = type
		});
	}

	public SDFLayer CreateSDFLayer(SDFSuperNode n)
	{
		if (CanCreate())
		{
			SDFLayer sDFLayer = CreateSDFLayerDirect(n);
			Layers.Add(n);
			sDFLayer.Activate();
			ArrangeLayers();
			Dirty = 1;
			return sDFLayer;
		}
		WindowManager.Instance.ShowMessageBox("LogoComplexityLimit".Loc(), true, DialogWindow.DialogType.Error, ParentWindow.Window);
		return null;
	}

	public SDFLayer CreateSDFLayerDirect(SDFSuperNode n)
	{
		SDFLayer sDFLayer = (n.UILayer = UnityEngine.Object.Instantiate(LayerPrefab));
		sDFLayer.Init(this, n);
		sDFLayer.transform.SetParent(LayerPanel, false);
		return sDFLayer;
	}

	public bool CanCreate()
	{
		return _lastComplexity < 1f;
	}

	public static SDFCreator.ISDFOutput CreateTree(List<SDFSuperNode> layers, bool temp)
	{
		SDFCreator.ISDFOutput iSDFOutput = null;
		for (int i = 0; i < layers.Count; i++)
		{
			SDFCreator.ISDFNode iSDFNode = layers[i].ToSDFNode(temp);
			if (iSDFNode != null)
			{
				SDFCreator.SDFExport sDFExport;
				if ((sDFExport = iSDFNode as SDFCreator.SDFExport) == null)
				{
					throw new Exception("Node did not convert to color export");
				}
				iSDFOutput = ((iSDFOutput == null) ? ((SDFCreator.ISDFOutput)sDFExport) : ((SDFCreator.ISDFOutput)new SDFCreator.SDFMix(iSDFOutput, sDFExport, Vector2.zero)));
			}
		}
		return iSDFOutput;
	}

	public static List<SDFSuperNode> ConvertToLayers(SDFCreator.ISDFNode node, out bool perfect)
	{
		List<SDFSuperNode> result = new List<SDFSuperNode>();
		perfect = true;
		SubConvertToLayer(node, result, Matrix4x4.identity, true, ref perfect);
		return result;
	}

	private static void AddExport(SDFSuperNode current, SDFCreator.SDFExport sdfExport, bool colorTrans, float gradRot)
	{
		current.MainColor = sdfExport.MainColor;
		current.GradientColor = sdfExport.GradientColor;
		current.OutlineColor = sdfExport.OutlineColor;
		current.GradientLinear = sdfExport.GradientLinear;
		current.GradientRotation = gradRot;
		current.Outline = sdfExport.Outline;
		current.Threshold = sdfExport.Threshold;
		if (colorTrans)
		{
			current.TransformColor = true;
			Matrix4x4 matrix4x = Matrix4x4.TRS(sdfExport.Pos.ToVector3(0f), Quaternion.Euler(0f, 360f - sdfExport.Rotation, 0f), sdfExport.Scale.ToVector3(1f));
			Vector3 v = matrix4x.MultiplyPoint(current.Pos.ToVector3(0f));
			Vector3 vector = Vector3.Scale(matrix4x.lossyScale, current.Scale * Vector3.one);
			float y = Quaternion.LookRotation(matrix4x.MultiplyVector(Quaternion.Euler(0f, current.Rotation, 0f) * Vector3.forward)).eulerAngles.y;
			current.Pos = v.FlattenVector3();
			current.Rotation = y;
			current.Scale = vector.x;
		}
	}

	private static bool ShouldApplyExportTransform(SDFCreator.SDFExport sdfExport, out float newRotation)
	{
		newRotation = sdfExport.GradientRotation;
		if (!sdfExport.Pos.Approximate(Vector2.zero, 0.01f) || !sdfExport.Scale.Approximate(Vector2.one, 0.01f))
		{
			if (!sdfExport.MainColor.Approximate(sdfExport.GradientColor))
			{
				return !AnyMoves(sdfExport.Input);
			}
		}
		else if (!Mathf.Approximately(sdfExport.Rotation, 0f) && !sdfExport.MainColor.Approximate(sdfExport.GradientColor))
		{
			newRotation += sdfExport.Rotation;
			return false;
		}
		return false;
	}

	private static bool AnyMoves(SDFCreator.ISDFNode node)
	{
		return false;
	}

	private static SDFSuperNode SubConvertToLayer(SDFCreator.ISDFNode node, List<SDFSuperNode> result, Matrix4x4 m, bool topTrack, ref bool perfect)
	{
		if (node != null)
		{
			SDFCreator.SDFArray sDFArray;
			if ((sDFArray = node as SDFCreator.SDFArray) != null)
			{
				SDFCreator.SDFArray sDFArray2 = sDFArray;
				Vector3 v = m.MultiplyPoint(sDFArray2.Pos.ToVector3(0f));
				Vector3 vector = Vector3.Scale(m.lossyScale, sDFArray2.Scale.ToVector3(1f));
				float rotation = 0f - Quaternion.LookRotation(m.MultiplyVector(Quaternion.Euler(0f, 360f - sDFArray2.Rotation, 0f) * Vector3.forward)).eulerAngles.y;
				SDFSuperNode sDFSuperNode = SubConvertToLayer(sDFArray2.Input, result, Matrix4x4.identity, topTrack, ref perfect);
				SDFSuperNode sDFSuperNode2 = new SDFSuperNode();
				sDFSuperNode2.SDFType = SDFSuperNode.Type.Array;
				sDFSuperNode2.Pos = v.FlattenVector3();
				sDFSuperNode2.Rotation = rotation;
				sDFSuperNode2.Scale = vector.x;
				sDFSuperNode2.SetParent(sDFSuperNode);
				return sDFSuperNode;
			}
			SDFCreator.SDFCombine sDFCombine;
			if ((sDFCombine = node as SDFCreator.SDFCombine) != null)
			{
				SDFCreator.SDFCombine sDFCombine2 = sDFCombine;
				SDFSuperNode sDFSuperNode3 = SubConvertToLayer(sDFCombine2.Input2, result, m, false, ref perfect);
				SDFSuperNode sDFSuperNode4 = SubConvertToLayer(sDFCombine2.Input1, result, m, topTrack, ref perfect);
				sDFSuperNode3.CombineType = sDFCombine2.SimpleFunction();
				sDFSuperNode3.CombineParam = sDFCombine2.Param;
				if (!sDFSuperNode4.Skew.Approximate(Vector2.zero, 0.01f) || !sDFSuperNode4.WaveAmount.Approximate(Vector2.zero, 0.01f) || !sDFSuperNode4.Distortion.Appx(0f) || !sDFSuperNode4.Subtraction.Appx(0f) || !sDFSuperNode4.EffectThreshold.Appx(0f))
				{
					perfect = false;
				}
				sDFSuperNode3.SetParent(sDFSuperNode4);
				return sDFSuperNode4;
			}
			SDFCreator.SDFEffect sDFEffect;
			if ((sDFEffect = node as SDFCreator.SDFEffect) != null)
			{
				SDFCreator.SDFEffect sDFEffect2 = sDFEffect;
				SDFSuperNode sDFSuperNode5 = SubConvertToLayer(sDFEffect2.Input, result, m, topTrack, ref perfect);
				if (sDFEffect2.Skew != Vector2.zero)
				{
					if (sDFSuperNode5.Skew != Vector2.zero && sDFSuperNode5.Skew != sDFEffect2.Skew)
					{
						perfect = false;
					}
					sDFSuperNode5.Skew = sDFEffect2.Skew;
				}
				if (sDFEffect2.Subtraction != 0f)
				{
					if (sDFSuperNode5.Subtraction != 0f && !sDFSuperNode5.Subtraction.Appx(sDFEffect2.Subtraction))
					{
						perfect = false;
					}
					sDFSuperNode5.Subtraction = sDFEffect2.Subtraction;
				}
				if (sDFEffect2.WaveAmount != Vector2.zero)
				{
					bool flag = sDFSuperNode5.WaveAmount != Vector2.zero;
					if (sDFSuperNode5.WaveAmount != Vector2.zero && sDFSuperNode5.WaveAmount != sDFEffect2.WaveAmount)
					{
						perfect = false;
					}
					sDFSuperNode5.WaveAmount = sDFEffect2.WaveAmount;
					if (sDFEffect2.WaveFrequency != Vector2.one)
					{
						if (sDFSuperNode5.Skew != Vector2.one && sDFSuperNode5.WaveFrequency != sDFEffect2.WaveFrequency && flag)
						{
							perfect = false;
						}
						sDFSuperNode5.WaveFrequency = sDFEffect2.WaveFrequency;
					}
				}
				if (sDFEffect2.Distortion != 0f)
				{
					if (sDFSuperNode5.Distortion != 0f && !sDFSuperNode5.Distortion.Appx(sDFEffect2.Distortion))
					{
						perfect = false;
					}
					sDFSuperNode5.Distortion = sDFEffect2.Distortion;
				}
				if (sDFEffect2.Threshold != 0f)
				{
					if (sDFSuperNode5.EffectThreshold != 0f && !sDFSuperNode5.EffectThreshold.Appx(sDFEffect2.Threshold))
					{
						perfect = false;
					}
					sDFSuperNode5.EffectThreshold = sDFEffect2.Threshold;
				}
				if (!sDFEffect2.Rounding.Appx(0f))
				{
					perfect = false;
				}
				return sDFSuperNode5;
			}
			SDFCreator.SDFExport sDFExport;
			if ((sDFExport = node as SDFCreator.SDFExport) != null)
			{
				SDFCreator.SDFExport sDFExport2 = sDFExport;
				float newRotation;
				bool flag2 = ShouldApplyExportTransform(sDFExport2, out newRotation);
				if (sDFExport2.ColorSDF != null || (!flag2 && (!sDFExport2.Pos.Approximate(Vector2.zero, 0.01f) || !sDFExport2.Scale.Approximate(Vector2.one, 0.01f)) && !sDFExport2.MainColor.Approximate(sDFExport2.GradientColor)))
				{
					perfect = false;
				}
				Matrix4x4 matrix4x = (flag2 ? Matrix4x4.identity : Matrix4x4.TRS(sDFExport2.Pos.ToVector3(0f), Quaternion.Euler(0f, 360f - sDFExport2.Rotation, 0f), sDFExport2.Scale.ToVector3(1f)));
				SDFSuperNode sDFSuperNode6 = SubConvertToLayer(sDFExport2.Input, result, matrix4x * m, true, ref perfect);
				AddExport(sDFSuperNode6, sDFExport2, flag2, newRotation);
				result.Add(sDFSuperNode6);
				return null;
			}
			SDFCreator.SDFMirror sDFMirror;
			if ((sDFMirror = node as SDFCreator.SDFMirror) != null)
			{
				SDFCreator.SDFMirror sDFMirror2 = sDFMirror;
				Vector3 position;
				Quaternion rotation2;
				Vector3 scale;
				m.ExtractTRS(out position, out rotation2, out scale);
				float y = rotation2.eulerAngles.y;
				Vector2 vector2 = new Vector2(position.x, position.z);
				if (!y.Appx(0f))
				{
					perfect = false;
				}
				m = Matrix4x4.TRS(position, Quaternion.identity, scale);
				SDFSuperNode sDFSuperNode7 = SubConvertToLayer(sDFMirror2.Input, result, m, topTrack, ref perfect);
				SDFSuperNode sDFSuperNode8 = new SDFSuperNode();
				sDFSuperNode8.SDFType = SDFSuperNode.Type.Mirror;
				sDFSuperNode8.Pos = sDFMirror2.Pos + vector2 * scale.x;
				sDFSuperNode8.Rotation = 360f - sDFMirror2.Offset + y;
				sDFSuperNode8.Offset = 360f - sDFMirror2.Angle;
				sDFSuperNode8.Times = sDFMirror2.Times;
				sDFSuperNode8.FlipX = sDFMirror2.FlipX;
				sDFSuperNode8.FlipY = sDFMirror2.FlipY;
				sDFSuperNode8.SetParent(sDFSuperNode7);
				return sDFSuperNode7;
			}
			SDFCreator.SDFReflect sDFReflect;
			if ((sDFReflect = node as SDFCreator.SDFReflect) != null)
			{
				SDFCreator.SDFReflect sDFReflect2 = sDFReflect;
				Vector3 position2;
				Quaternion rotation3;
				Vector3 scale2;
				m.ExtractTRS(out position2, out rotation3, out scale2);
				if (!rotation3.eulerAngles.y.Appx(0f))
				{
					perfect = false;
				}
				SDFSuperNode sDFSuperNode9 = SubConvertToLayer(sDFReflect2.Input, result, m, topTrack, ref perfect);
				SDFSuperNode sDFSuperNode10 = new SDFSuperNode();
				sDFSuperNode10.SDFType = SDFSuperNode.Type.Reflect;
				sDFSuperNode10.Pos = sDFReflect2.Pos + (rotation3 * position2 * scale2.x).FlattenVector3();
				sDFSuperNode10.Rotation = 360f - sDFReflect2.Angle + rotation3.eulerAngles.y;
				sDFSuperNode10.SetParent(sDFSuperNode9);
				return sDFSuperNode9;
			}
			SDFCreator.SDFMix sDFMix;
			if ((sDFMix = node as SDFCreator.SDFMix) != null)
			{
				SDFCreator.SDFMix sDFMix2 = sDFMix;
				if (!sDFMix2.Pos.Approximate(Vector2.zero, 0.01f) || !sDFMix2.Scale.Approximate(Vector2.one, 0.01f) || !sDFMix2.Rotation.Appx(0f))
				{
					perfect = false;
				}
				SubConvertToLayer(sDFMix2.Input1, result, m, true, ref perfect);
				Matrix4x4 matrix4x2 = Matrix4x4.TRS(sDFMix2.Pos.ToVector3(0f), Quaternion.Euler(0f, 360f - sDFMix2.Rotation, 0f), sDFMix2.Scale.ToVector3(1f));
				SubConvertToLayer(sDFMix2.Input2, result, matrix4x2 * m, true, ref perfect);
				return null;
			}
			SDFCreator.SDFShape sDFShape;
			if ((sDFShape = node as SDFCreator.SDFShape) != null)
			{
				SDFCreator.SDFShape sDFShape2 = sDFShape;
				Vector3 v2 = m.MultiplyPoint(sDFShape2.Pos.ToVector3(0f));
				Vector3 vector3 = Vector3.Scale(m.lossyScale, sDFShape2.Scale.ToVector3(1f));
				Vector3 vector4 = m.MultiplyVector(Quaternion.Euler(0f, sDFShape2.Rotation, 0f) * Vector3.forward);
				float rotation4 = ((vector4 == Vector3.zero) ? 0f : Quaternion.LookRotation(vector4).eulerAngles.y);
				return new SDFSuperNode
				{
					SDFType = SDFSuperNode.Type.Shape,
					Function = sDFShape2.Function,
					Rounding = sDFShape2.Rounding,
					Pos = v2.FlattenVector3(),
					Rotation = rotation4,
					Scale = vector3.x,
					SDFParams = sDFShape2.SDFParams
				};
			}
			SDFCreator.SDFTexture sDFTexture;
			if ((sDFTexture = node as SDFCreator.SDFTexture) != null)
			{
				SDFCreator.SDFTexture sDFTexture2 = sDFTexture;
				Vector3 v3 = m.MultiplyPoint(sDFTexture2.Pos.ToVector3(0f));
				Vector3 vector5 = Vector3.Scale(m.lossyScale, sDFTexture2.Scale.ToVector3(1f));
				float y2 = Quaternion.LookRotation(m.MultiplyVector(Quaternion.Euler(0f, sDFTexture2.Rotation, 0f) * Vector3.forward)).eulerAngles.y;
				return new SDFSuperNode
				{
					SDFType = SDFSuperNode.Type.Texture,
					SDFResource = sDFTexture2.SDFResource,
					Pos = v3.FlattenVector3(),
					Rotation = y2,
					Scale = vector5.x
				};
			}
			SDFCreator.SDFTransform sDFTransform;
			if ((sDFTransform = node as SDFCreator.SDFTransform) != null)
			{
				SDFCreator.SDFTransform sDFTransform2 = sDFTransform;
				Matrix4x4 matrix4x3 = Matrix4x4.TRS(sDFTransform2.Pos.ToVector3(0f), Quaternion.Euler(0f, sDFTransform2.Rotation, 0f), sDFTransform2.Scale.ToVector3(1f));
				return SubConvertToLayer(sDFTransform2.Input, result, m * matrix4x3, topTrack, ref perfect);
			}
		}
		throw new ArgumentOutOfRangeException("node", node, null);
	}

	public void OpenCopyPastePanel()
	{
		SDFCreator.ISDFNode iSDFNode = null;
		try
		{
			iSDFNode = CreateTree(Layers, false);
		}
		catch (Exception)
		{
		}
		if (iSDFNode != null && iSDFNode.IsValid())
		{
			if (iSDFNode.CountNodes() > 25)
			{
				WindowManager.Instance.ShowMessageBox("LogoComplexityLimit".Loc(), true, DialogWindow.DialogType.Error, ParentWindow.Window);
				return;
			}
			PasteInput.text = SDFCreator.GetTreeString(SDFCreator.SerializeTree(iSDFNode));
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

	public void CreateAllLayers(SDFSuperNode node)
	{
		CreateSDFLayerDirect(node);
		foreach (SDFSuperNode child in node.Children)
		{
			CreateAllLayers(child);
		}
	}

	public void LoadTreeData(byte[] data)
	{
		LoadTree((data == null) ? null : SDFCreator.LoadSDFTree(data));
	}

	public void LoadTree(SDFCreator.ISDFNode node)
	{
		if (node == null)
		{
			Clear();
			return;
		}
		try
		{
			Dirty = 1;
			bool perfect;
			List<SDFSuperNode> list = ConvertToLayers(node, out perfect);
			Clear();
			for (int i = 0; i < list.Count; i++)
			{
				Layers.Add(list[i]);
				CreateAllLayers(list[i]);
			}
			ArrangeLayers();
			if (!perfect)
			{
				WindowManager.Instance.ShowMessageBox("ImperfectLogoConversion".Loc(), true, DialogWindow.DialogType.Question, delegate
				{
					ParentWindow.Window.Close();
					AdvancedEditor.Show(SDFCreator.SerializeTree(node), ParentWindow.OnSave);
				}).Window.SetParentWindow(ParentWindow.Window);
			}
		}
		catch (Exception)
		{
			WindowManager.Instance.ShowMessageBox("LogoCodeError".Loc(), true, DialogWindow.DialogType.Error, ParentWindow.Window);
		}
	}

	public void LoadCode()
	{
		CopyPastePanel.SetActive(false);
		Dirty = 1;
		try
		{
			LoadTree(SDFCreator.LoadSDFTree(SDFCreator.GetTreeFromString(PasteInput.text)));
		}
		catch (Exception)
		{
			WindowManager.Instance.ShowMessageBox("LogoCodeError".Loc(), true, DialogWindow.DialogType.Error, ParentWindow.Window);
		}
	}

	public void UploadLogo()
	{
		SDFCreator.ISDFOutput iSDFOutput = null;
		try
		{
			iSDFOutput = CreateTree(Layers, false);
		}
		catch (Exception)
		{
		}
		if (iSDFOutput == null || !iSDFOutput.IsValid())
		{
			return;
		}
		if (iSDFOutput.CountNodes() > 25)
		{
			WindowManager.Instance.ShowMessageBox("LogoComplexityLimit".Loc(), true, DialogWindow.DialogType.Error, ParentWindow.Window);
			return;
		}
		string logo = SDFCreator.GetTreeString(SDFCreator.SerializeTree(iSDFOutput));
		WindowManager.SpawnInputDialog("EnterName".Loc(), "Logo".Loc(), "", delegate(string name)
		{
			if (!string.IsNullOrWhiteSpace(name.Replace("|", "")))
			{
				StartCoroutine(SDFEditor.UploadLogo(logo, name, delegate(string x)
				{
					if (x == null)
					{
						WindowManager.Instance.ShowMessageBox("Uploaded".Loc(), true, DialogWindow.DialogType.Information, ParentWindow.Window);
					}
					else
					{
						WindowManager.Instance.ShowMessageBox("Error".Loc(), true, DialogWindow.DialogType.Error, ParentWindow.Window);
						Debug.Log("Failed uploading logo:\n" + x);
					}
				}));
			}
		}, null, 64);
	}
}
