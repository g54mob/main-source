using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SDFNode : MonoBehaviour
{
	public RectTransform Self;

	public RectTransform OutputPos;

	public RawImage Preview;

	public List<RectTransform> InputPos = new List<RectTransform>();

	public Image HeaderPanel;

	public Image PreviewBack;

	public Color Active;

	public Color Inactive;

	public Text Header;

	[NonSerialized]
	public SDFEditor Parent;

	public GameObject ErrorMsg;

	public HashSet<SDFNode> Outputs = new HashSet<SDFNode>();

	public SDFNode[] Inputs;

	public bool FirstDrag;

	[NonSerialized]
	private bool _isDragging;

	[NonSerialized]
	private int _isConnecting;

	[NonSerialized]
	public SDFCreator.NodeType Type;

	[NonSerialized]
	public SDFCreator.ISDFNode Node;

	[NonSerialized]
	private RenderTexture _preview;

	[NonSerialized]
	private Vector2? _lastPos;

	public void ConnectSDF()
	{
		for (int i = 0; i < Inputs.Length; i++)
		{
			SDFNode sDFNode = Inputs[i];
			if (sDFNode != null)
			{
				sDFNode.ConnectSDF();
			}
			Node.SetInput(((object)sDFNode != null) ? sDFNode.Node : null, i);
		}
	}

	public Color GetColor(bool input)
	{
		switch (Type)
		{
		case SDFCreator.NodeType.Shape:
		case SDFCreator.NodeType.Effect:
		case SDFCreator.NodeType.Combine:
		case SDFCreator.NodeType.Transform:
		case SDFCreator.NodeType.Mirror:
		case SDFCreator.NodeType.Texture:
		case SDFCreator.NodeType.Array:
		case SDFCreator.NodeType.Reflect:
			return Parent.SDFColor;
		case SDFCreator.NodeType.Color:
			if (!input)
			{
				return Parent.RGBColor;
			}
			return Parent.SDFColor;
		case SDFCreator.NodeType.Mix:
			return Parent.RGBColor;
		default:
			return Color.white;
		}
	}

	public void Render()
	{
		Render(_preview);
	}

	public void Render(RenderTexture tex)
	{
		ConnectSDF();
		if (Node.IsValid())
		{
			Preview.gameObject.SetActive(true);
			ErrorMsg.SetActive(false);
			SDFCreator.ISDFOutput sdf = ((!(Node is SDFCreator.ISDFOutput)) ? new SDFCreator.SDFExport(Node as SDFCreator.ISDFInput, Color.white) : ((SDFCreator.ISDFOutput)Node));
			SDFCreator.Instance.Render(sdf, tex);
		}
		else
		{
			Preview.gameObject.SetActive(false);
			ErrorMsg.SetActive(true);
		}
	}

	public bool ValidConnection(SDFNode node)
	{
		if (!CheckLoop(node, this))
		{
			return false;
		}
		switch (Type)
		{
		case SDFCreator.NodeType.Shape:
		case SDFCreator.NodeType.Effect:
		case SDFCreator.NodeType.Combine:
		case SDFCreator.NodeType.Transform:
		case SDFCreator.NodeType.Mirror:
		case SDFCreator.NodeType.Texture:
		case SDFCreator.NodeType.Array:
		case SDFCreator.NodeType.Reflect:
			if (node.Type != SDFCreator.NodeType.Effect && node.Type != SDFCreator.NodeType.Combine && node.Type != SDFCreator.NodeType.Color && node.Type != SDFCreator.NodeType.Transform && node.Type != SDFCreator.NodeType.Mirror && node.Type != SDFCreator.NodeType.Reflect && node.Type != SDFCreator.NodeType.Texture)
			{
				return node.Type == SDFCreator.NodeType.Array;
			}
			return true;
		case SDFCreator.NodeType.Color:
			return node.Type == SDFCreator.NodeType.Mix;
		case SDFCreator.NodeType.Mix:
			return node.Type == SDFCreator.NodeType.Mix;
		default:
			return false;
		}
	}

	public bool CheckLoop(SDFNode start, SDFNode current)
	{
		if (current == null)
		{
			return true;
		}
		if (current == start)
		{
			return false;
		}
		for (int i = 0; i < current.Inputs.Length; i++)
		{
			SDFNode sDFNode = current.Inputs[i];
			if (sDFNode != null && !CheckLoop(start, sDFNode))
			{
				return false;
			}
		}
		return true;
	}

	public bool ConnectTo(SDFNode node, int input)
	{
		if (ValidConnection(node))
		{
			if (node.Inputs[input] != null)
			{
				node.Inputs[input].Disconnect(node);
			}
			Outputs.Add(node);
			node.Inputs[input] = this;
			Parent.MakeDirty(node);
			return true;
		}
		return false;
	}

	public void Disconnect(SDFNode node)
	{
		int num = Array.IndexOf(node.Inputs, this);
		if (num >= 0)
		{
			node.Inputs[num] = null;
		}
		Outputs.Remove(node);
		Parent.MakeDirty(node);
	}

	public void ImprintPos()
	{
		_lastPos = Self.anchoredPosition;
	}

	public void Init(SDFCreator.ISDFNode node, SDFEditor parent)
	{
		if (node == null)
		{
			return;
		}
		if (!(node is SDFCreator.SDFShape))
		{
			if (!(node is SDFCreator.SDFEffect))
			{
				if (!(node is SDFCreator.SDFTransform))
				{
					if (!(node is SDFCreator.SDFCombine))
					{
						if (!(node is SDFCreator.SDFExport))
						{
							if (!(node is SDFCreator.SDFMix))
							{
								if (!(node is SDFCreator.SDFMirror))
								{
									if (!(node is SDFCreator.SDFReflect))
									{
										if (!(node is SDFCreator.SDFTexture))
										{
											if (node is SDFCreator.SDFArray)
											{
												Init(SDFCreator.NodeType.Array, parent, node);
											}
										}
										else
										{
											Init(SDFCreator.NodeType.Texture, parent, node);
										}
									}
									else
									{
										Init(SDFCreator.NodeType.Reflect, parent, node);
									}
								}
								else
								{
									Init(SDFCreator.NodeType.Mirror, parent, node);
								}
							}
							else
							{
								Init(SDFCreator.NodeType.Mix, parent, node);
							}
						}
						else
						{
							Init(SDFCreator.NodeType.Color, parent, node);
						}
					}
					else
					{
						Init(SDFCreator.NodeType.Combine, parent, node);
					}
				}
				else
				{
					Init(SDFCreator.NodeType.Transform, parent, node);
				}
			}
			else
			{
				Init(SDFCreator.NodeType.Effect, parent, node);
			}
		}
		else
		{
			Init(SDFCreator.NodeType.Shape, parent, node);
		}
	}

	public void Duplicate()
	{
		if (Parent.CanCreateNode())
		{
			SDFCreator.ISDFNode node = Node.Duplicate();
			SDFNode sDFNode = Parent.CreateNode(node);
			sDFNode.FirstDrag = true;
			sDFNode.StartDrag();
		}
	}

	public void Init(SDFCreator.NodeType type, SDFEditor parent, SDFCreator.ISDFNode node = null)
	{
		HeaderPanel.color = Inactive;
		Parent = parent;
		Type = type;
		Header.text = ("SDF" + Type).Loc();
		bool flag = false;
		float x = Utilities.RGBToHSV(GetColor(true)).x;
		switch (type)
		{
		case SDFCreator.NodeType.Shape:
			Node = node ?? new SDFCreator.SDFShape(SDFCreator.SDFFunction.Circle, Vector4.one);
			flag = true;
			break;
		case SDFCreator.NodeType.Effect:
			Node = node ?? new SDFCreator.SDFEffect(null, 0f, 0f);
			flag = true;
			break;
		case SDFCreator.NodeType.Combine:
			Node = node ?? new SDFCreator.SDFCombine(null, null, SDFCreator.CombineFunction.Intersection);
			flag = true;
			break;
		case SDFCreator.NodeType.Color:
			Node = node ?? new SDFCreator.SDFExport(null, Color.red);
			x = Utilities.RGBToHSV(GetColor(false)).x;
			break;
		case SDFCreator.NodeType.Transform:
			Node = node ?? new SDFCreator.SDFTransform(null, Vector2.zero, Vector2.one, 0f);
			flag = true;
			break;
		case SDFCreator.NodeType.Mix:
			Node = node ?? new SDFCreator.SDFMix(null, null, Vector2.zero);
			x = Utilities.RGBToHSV(GetColor(false)).x;
			break;
		case SDFCreator.NodeType.Mirror:
			Node = node ?? new SDFCreator.SDFMirror(null, 2);
			flag = true;
			break;
		case SDFCreator.NodeType.Reflect:
			Node = node ?? new SDFCreator.SDFReflect((SDFCreator.ISDFInput)null);
			flag = true;
			break;
		case SDFCreator.NodeType.Texture:
			Node = node ?? new SDFCreator.SDFTexture("OKSign");
			flag = true;
			break;
		case SDFCreator.NodeType.Array:
			Node = node ?? new SDFCreator.SDFArray(null, true, true);
			flag = true;
			break;
		default:
			throw new ArgumentOutOfRangeException("type", type, null);
		}
		GetComponent<Image>().color = Utilities.HSVToRGBA(x, 0.2f, 1f);
		if (flag)
		{
			PreviewBack.sprite = null;
			PreviewBack.color = Color.black;
		}
		OutputPos.GetComponent<Image>().color = GetColor(false);
		Inputs = new SDFNode[ValidInputs()];
		int num = InputPos.Count - Inputs.Length;
		for (int i = 0; i < num; i++)
		{
			UnityEngine.Object.Destroy(InputPos.Last().gameObject);
			InputPos.RemoveAt(InputPos.Count - 1);
		}
		foreach (RectTransform inputPo in InputPos)
		{
			inputPo.GetComponent<Image>().color = GetColor(true);
		}
		_preview = new RenderTexture(128, 128, 0);
		Preview.texture = _preview;
	}

	public int ValidInputs()
	{
		switch (Type)
		{
		case SDFCreator.NodeType.Effect:
		case SDFCreator.NodeType.Transform:
		case SDFCreator.NodeType.Mirror:
		case SDFCreator.NodeType.Array:
		case SDFCreator.NodeType.Reflect:
			return 1;
		case SDFCreator.NodeType.Combine:
		case SDFCreator.NodeType.Color:
		case SDFCreator.NodeType.Mix:
			return 2;
		default:
			return 0;
		}
	}

	private void OnDestroy()
	{
		if (_preview != null)
		{
			Preview.texture = null;
			if (_preview != null)
			{
				if (_preview == RenderTexture.active)
				{
					RenderTexture.active = null;
				}
				UnityEngine.Object.Destroy(_preview);
			}
		}
		if (!(Parent != null))
		{
			return;
		}
		if (Parent.ActiveNode == this)
		{
			Parent.SetActive(null);
		}
		if (Parent.FinalNode == this)
		{
			Parent.FinalNode = null;
		}
		List<SDFNode> list = Outputs.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			Disconnect(list[i]);
		}
		for (int j = 0; j < Inputs.Length; j++)
		{
			if (Inputs[j] != null)
			{
				Inputs[j].Disconnect(this);
			}
		}
		Parent.Nodes.Remove(this);
		Parent.UpdateLimit();
		Parent.SetAllDirty();
		Parent.UpdatePreview();
	}

	public void Activate()
	{
		Parent.SetActive(this);
	}

	public void StartDrag()
	{
		if (Input.GetMouseButton(1))
		{
			if (Inputs.Length == 1 && Inputs[0] != null && Outputs.Count > 0 && Outputs.All((SDFNode x) => Inputs[0].ValidConnection(x)))
			{
				List<SDFNode> list = Outputs.ToList();
				for (int num = 0; num < list.Count; num++)
				{
					SDFNode sDFNode = list[num];
					Inputs[0].ConnectTo(sDFNode, Array.IndexOf(sDFNode.Inputs, this));
				}
			}
			UnityEngine.Object.Destroy(base.gameObject);
			UISoundFX.PlaySFX("ButtonSwoop");
		}
		else if (!_isDragging)
		{
			if (!FirstDrag)
			{
				UISoundFX.PlaySFX("Tick2");
			}
			Parent.SetActive(this);
			Parent._lastMax = Self.anchoredPosition + new Vector2(Self.rect.width / 2f, (0f - Self.rect.height) / 2f);
			Self.SetParent(WindowManager.Instance.Canvas.transform, false);
			Self.localScale = Parent.NodePanel.localScale * 1.1f;
			_isDragging = true;
		}
	}

	public void StartConnection(int side)
	{
		if (Input.GetMouseButton(1))
		{
			if (side > 0)
			{
				SDFNode sDFNode = Inputs[side - 1];
				if (sDFNode != null)
				{
					sDFNode.Disconnect(this);
					UISoundFX.PlaySFX("ButtonSwoop");
				}
			}
			else if (Outputs.Count > 0)
			{
				List<SDFNode> list = Outputs.ToList();
				for (int i = 0; i < list.Count; i++)
				{
					Disconnect(list[i]);
				}
				UISoundFX.PlaySFX("ButtonSwoop");
			}
			if (Parent.FinalNode == this)
			{
				Parent.FinalNode = null;
			}
			Parent.SetAllDirty();
			Parent.UpdatePreview();
		}
		else
		{
			UISoundFX.PlaySFX("Tick2");
			_isConnecting = side;
		}
	}

	private void Update()
	{
		if (_isConnecting != 0)
		{
			Vector2 localPoint;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Parent.NodePanel, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
			{
				Vector3 vector = ((_isConnecting > 0) ? InputPos[_isConnecting - 1].position : OutputPos.position);
				Vector2 localPoint2;
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Parent.NodePanel, vector, UICamSize.GetUICam(), out localPoint2))
				{
					Parent.SetLine(localPoint2 + UICamSize.GetUICamOffset() / Parent.rectTransform.localScale.x, localPoint, GetColor(_isConnecting > 0));
				}
			}
			if (Input.GetMouseButtonUp(0))
			{
				bool flag = false;
				if (_isConnecting < 0 && (Type == SDFCreator.NodeType.Color || Type == SDFCreator.NodeType.Mix) && CheckConnection(Parent.FinalConnector))
				{
					Parent.FinalNode = this;
					flag = true;
					Parent.MakeDirty(this);
					Parent.SetAllDirty();
					Parent.UpdatePreview();
					UISoundFX.PlaySFX("ServerConnect");
				}
				if (!flag)
				{
					foreach (SDFNode node in Parent.Nodes)
					{
						if (!(node != this))
						{
							continue;
						}
						if (_isConnecting > 0)
						{
							if (CheckConnection(node.OutputPos))
							{
								UISoundFX.PlaySFX(node.ConnectTo(this, _isConnecting - 1) ? "ServerConnect" : "BuildError");
								Parent.SetAllDirty();
								break;
							}
							continue;
						}
						for (int i = 0; i < node.InputPos.Count; i++)
						{
							if (CheckConnection(node.InputPos[i]))
							{
								UISoundFX.PlaySFX(ConnectTo(node, i) ? "ServerConnect" : "BuildError");
								Parent.SetAllDirty();
								break;
							}
						}
					}
				}
				Parent.UnsetLine();
				_isConnecting = 0;
			}
		}
		if (!_isDragging)
		{
			return;
		}
		Vector3 vector2 = Input.mousePosition / Options.UISize - new Vector3(0f, Self.rect.height * Self.localScale.x / 2f - 12f, 0f);
		Vector3 vector3 = Input.mousePosition - new Vector3(0f, Self.rect.height * Self.localScale.x / 2f - 12f, 0f);
		Self.anchoredPosition = vector2 - new Vector3(0f, (float)Screen.height / Options.UISize, 0f);
		if (Input.GetMouseButtonUp(0))
		{
			Vector2 localPoint3;
			Vector2 localPoint4;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Parent.NodeRect, vector3, UICamSize.GetUICam(), out localPoint3) && localPoint3.x > 0f && localPoint3.y > 0f && localPoint3.x < Parent.NodeRect.rect.width && localPoint3.y < Parent.NodeRect.rect.height && RectTransformUtility.ScreenPointToLocalPointInRectangle(Parent.NodePanel, vector3, UICamSize.GetUICam(), out localPoint4))
			{
				Self.SetParent(Parent.NodePanel, false);
				localPoint4 = new Vector2(Mathf.Max(Self.rect.width / 2f, localPoint4.x), Mathf.Min((0f - Self.rect.height) / 2f, localPoint4.y));
				Self.anchoredPosition = localPoint4;
				_lastPos = Self.anchoredPosition;
				if (FirstDrag && Inputs.Length != 0)
				{
					foreach (var connection in Parent.GetConnections(localPoint4, 32f))
					{
						if (connection.Item1.ValidConnection(this) && ValidConnection(connection.Item2))
						{
							ConnectTo(connection.Item2, Array.IndexOf(connection.Item2.Inputs, connection.Item1));
							connection.Item1.ConnectTo(this, 0);
						}
					}
				}
				UISoundFX.PlaySFX("Tick2");
			}
			else if (_lastPos.HasValue)
			{
				Self.SetParent(Parent.NodePanel, false);
				Self.anchoredPosition = _lastPos.Value;
			}
			else
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			Self.localScale = Vector3.one;
			FirstDrag = false;
			_isDragging = false;
			Parent._lastMax = null;
		}
		Parent.SetAllDirty();
	}

	private bool CheckConnection(RectTransform r)
	{
		Vector2 localPoint;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(r, Input.mousePosition, UICamSize.GetUICam(), out localPoint) && localPoint.x > (0f - r.rect.width) / 2f && localPoint.y > (0f - r.rect.height) / 2f && localPoint.x < r.rect.width / 2f)
		{
			return localPoint.y < r.rect.height / 2f;
		}
		return false;
	}
}
