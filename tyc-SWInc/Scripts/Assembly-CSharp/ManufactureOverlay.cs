using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManufactureOverlay : MonoBehaviour
{
	private class OutputNode
	{
		public ProductPrinter Printer;

		public Image Arrow;

		public OutputNode(ProductPrinter printer)
		{
			Printer = printer;
			Arrow = null;
		}
	}

	private class Node
	{
		public ProductPrinter Printer;

		public RectTransform Icon;

		public Image Outline;

		public Image Backing;

		public List<OutputNode> Outputs = new List<OutputNode>();

		private int _lastAtlas = -5;

		public Node(ProductPrinter printer, RectTransform icon)
		{
			Printer = printer;
			Icon = icon;
			Image[] componentsInChildren = icon.GetComponentsInChildren<Image>();
			Outline = componentsInChildren[0];
			Backing = componentsInChildren[1];
			UpdateAtlas();
		}

		public void UpdateAtlas()
		{
			int stickerIndex = Printer.GetStickerIndex();
			if (stickerIndex != _lastAtlas)
			{
				_lastAtlas = stickerIndex;
				RawImage componentInChildren = Icon.GetComponentInChildren<RawImage>();
				if (stickerIndex == -1)
				{
					componentInChildren.enabled = false;
					return;
				}
				componentInChildren.enabled = true;
				int manAtlasWidth = MarketSimulation.Active.ManAtlasWidth;
				float num = 1f / (float)manAtlasWidth;
				float num2 = 1f / (float)MarketSimulation.Active.ManAtlasHeight;
				int num3 = stickerIndex;
				componentInChildren.uvRect = new Rect((float)(num3 % manAtlasWidth) * num, (float)(num3 / manAtlasWidth) * num2, num, num2);
			}
		}

		public void UpdateEff()
		{
			float effectiveness = Printer.GetEffectiveness();
			Outline.fillAmount = effectiveness;
			Outline.color = Color.Lerp(HUD.GetPosNeg(false), HUD.GetPosNeg(true), effectiveness);
			Backing.color = ((Printer.Group == null) ? Color.white : Printer.Group.AColor);
		}
	}

	public static ManufactureOverlay Instance;

	public Image ArrowPrefab;

	public RectTransform IconPrefab;

	[NonSerialized]
	private ObjectPool<Image> _arrowPool;

	[NonSerialized]
	private ObjectPool<RectTransform> _iconPool;

	[NonSerialized]
	private List<Node> _active = new List<Node>();

	public AnimationCurve IconSize;

	private int _nextRefresh;

	private int _lastCount;

	private int _lastFloor;

	private HashSet<Conveyor> _visited = new HashSet<Conveyor>();

	private HashSet<ProductPrinter> _result = new HashSet<ProductPrinter>();

	public static bool IsActive
	{
		get
		{
			if (Instance != null)
			{
				return Instance.gameObject.activeSelf;
			}
			return false;
		}
	}

	private void Awake()
	{
		_arrowPool = new ObjectPool<Image>(delegate
		{
			Image image = UnityEngine.Object.Instantiate(ArrowPrefab);
			image.transform.SetParent(base.transform, false);
			image.transform.SetAsFirstSibling();
			return image;
		}, delegate(Image x)
		{
			x.gameObject.SetActive(true);
		}, delegate(Image x)
		{
			x.gameObject.SetActive(false);
		});
		_iconPool = new ObjectPool<RectTransform>(delegate
		{
			RectTransform rectTransform = UnityEngine.Object.Instantiate(IconPrefab);
			rectTransform.SetParent(base.transform, false);
			rectTransform.SetAsLastSibling();
			rectTransform.GetComponentInChildren<RawImage>().texture = MarketSimulation.Active.ManufacturingIcons;
			rectTransform.GetComponent<Image>().color = HUD.GetAccentColor();
			return rectTransform;
		}, delegate(RectTransform x)
		{
			x.gameObject.SetActive(true);
		}, delegate(RectTransform x)
		{
			x.gameObject.SetActive(false);
		});
		Instance = this;
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void OnEnable()
	{
		Initialize();
	}

	private void Initialize()
	{
		_lastCount = GameSettings.Instance.ProductPrinters.Count;
		_lastFloor = GameSettings.Instance.ActiveFloor;
		foreach (ProductPrinter item in GameSettings.Instance.ProductPrinters.Where((ProductPrinter x) => x.Furn.GetFloor() == GameSettings.Instance.ActiveFloor && x.IsManufacturing()))
		{
			Node node = new Node(item, _iconPool.Get());
			_active.Add(node);
			RefreshOutputs(node);
		}
	}

	private void OnDisable()
	{
		Clear();
	}

	private void Clear()
	{
		for (int i = 0; i < _active.Count; i++)
		{
			Release(_active[i]);
		}
		_active.Clear();
	}

	private void Release(Node n)
	{
		_iconPool.Release(n.Icon);
		for (int i = 0; i < n.Outputs.Count; i++)
		{
			if (n.Outputs[i].Arrow != null)
			{
				_arrowPool.Release(n.Outputs[i].Arrow);
			}
		}
	}

	private void RefreshOutputs(Node n)
	{
		if (n.Printer == null)
		{
			return;
		}
		_visited.Clear();
		_result.Clear();
		GetOutputs(n.Printer.Furn.Conveyor, _visited, _result, n.Printer.GetMask(), true);
		for (int i = 0; i < n.Outputs.Count; i++)
		{
			OutputNode outputNode = n.Outputs[i];
			if (!_result.Contains(outputNode.Printer))
			{
				if (outputNode.Arrow != null)
				{
					_arrowPool.Release(outputNode.Arrow);
					outputNode.Arrow = null;
				}
				n.Outputs.RemoveAt(i);
				i--;
			}
			else
			{
				_result.Remove(outputNode.Printer);
			}
		}
		foreach (ProductPrinter item in _result)
		{
			n.Outputs.Add(new OutputNode(item));
		}
	}

	public static bool CheckValid(HardwareComponent output, ComponentProcess input)
	{
		if (input == null || output == null)
		{
			return false;
		}
		if (output.Parent != input.Parent)
		{
			return false;
		}
		if (output.InputProcess == input)
		{
			return true;
		}
		if (!output.InputProcess.Final && string.IsNullOrEmpty(output.InputProcess.Output.DependsOn))
		{
			return false;
		}
		return CheckValid(output.InputProcess.Output, input);
	}

	private void GetOutputs(Conveyor from, HashSet<Conveyor> visited, HashSet<ProductPrinter> result, int mask, bool first = false)
	{
		if (from == null || !visited.Add(from) || from.Recycler)
		{
			return;
		}
		if (!first && from.Parent.Printer != null && from.Parent.Printer.IsManufacturing())
		{
			result.Add(from.Parent.Printer);
			return;
		}
		bool flag = false;
		if (from.AutoRoute)
		{
			for (int i = 0; i < from.OutputLength; i++)
			{
				if ((from.OutputMasks[i] & mask) != 0)
				{
					GetOutputs(from.GetOutput(i), visited, result, mask);
					flag = true;
				}
			}
		}
		if (flag)
		{
			return;
		}
		for (int j = 0; j < from.OutputLength; j++)
		{
			Conveyor output = from.GetOutput(j);
			if (output != null)
			{
				GetOutputs(output, visited, result, mask);
			}
		}
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (_lastFloor != GameSettings.Instance.ActiveFloor)
		{
			Clear();
			Initialize();
		}
		else if (_lastCount != GameSettings.Instance.ProductPrinters.Count)
		{
			HashSet<ProductPrinter> hashSet = GameSettings.Instance.ProductPrinters.Where((ProductPrinter x) => x != null && x.Furn.GetFloor() == GameSettings.Instance.ActiveFloor && x.IsManufacturing()).ToHashSet();
			_lastCount = GameSettings.Instance.ProductPrinters.Count;
			for (int num = 0; num < _active.Count; num++)
			{
				Node node = _active[num];
				if (hashSet.Contains(node.Printer))
				{
					hashSet.Remove(node.Printer);
					continue;
				}
				Release(node);
				_active.RemoveAt(num);
				num--;
			}
			foreach (ProductPrinter item in hashSet)
			{
				Node node2 = new Node(item, _iconPool.Get());
				_active.Add(node2);
				RefreshOutputs(node2);
			}
		}
		if (_active.Count == 0)
		{
			return;
		}
		Node n = _active[_nextRefresh % _active.Count];
		RefreshOutputs(n);
		_nextRefresh = (_nextRefresh + 1) % _active.Count;
		int num2 = Mathf.RoundToInt(IconSize.Evaluate((CameraScript.Instance.transform.position - CameraScript.Instance.mainCam.transform.position).magnitude));
		Rect rect = new Rect(0f, 0f, Screen.width, Screen.height).Expand(32f, 32f);
		for (int num3 = 0; num3 < _active.Count; num3++)
		{
			Node node3 = _active[num3];
			if (node3.Printer == null)
			{
				GameObject gameObject = node3.Icon.gameObject;
				if (!gameObject.activeSelf)
				{
					continue;
				}
				gameObject.SetActive(false);
				if (node3.Outputs.Count <= 0)
				{
					continue;
				}
				for (int num4 = 0; num4 < node3.Outputs.Count; num4++)
				{
					if (node3.Outputs[num4].Arrow != null)
					{
						node3.Outputs[num4].Arrow.gameObject.SetActive(false);
					}
				}
				continue;
			}
			node3.UpdateEff();
			Vector3 vector = CameraScript.Instance.SSAScript.WorldToScreenPoint(node3.Printer.transform.position + Vector3.up);
			if (!rect.Contains(vector) || vector.z < 0f)
			{
				GameObject gameObject2 = node3.Icon.gameObject;
				if (!gameObject2.activeSelf)
				{
					continue;
				}
				gameObject2.SetActive(false);
				if (node3.Outputs.Count <= 0)
				{
					continue;
				}
				for (int num5 = 0; num5 < node3.Outputs.Count; num5++)
				{
					if (node3.Outputs[num5].Arrow != null)
					{
						node3.Outputs[num5].Arrow.gameObject.SetActive(false);
					}
				}
				continue;
			}
			node3.Icon.gameObject.SetActive(true);
			node3.Icon.anchoredPosition = new Vector2(vector.x, 0f - ((float)Screen.height - vector.y));
			node3.Icon.sizeDelta = new Vector2(num2, num2);
			node3.UpdateAtlas();
			if (node3.Outputs.Count <= 0)
			{
				continue;
			}
			bool isSelected = node3.Printer.Furn.IsSelected;
			if (isSelected != (node3.Outputs[0].Arrow != null))
			{
				for (int num6 = 0; num6 < node3.Outputs.Count; num6++)
				{
					if (isSelected)
					{
						node3.Outputs[num6].Arrow = _arrowPool.Get();
					}
					else if (node3.Outputs[num6].Arrow != null)
					{
						_arrowPool.Release(node3.Outputs[num6].Arrow);
						node3.Outputs[num6].Arrow = null;
					}
				}
			}
			if (!isSelected)
			{
				continue;
			}
			for (int num7 = 0; num7 < node3.Outputs.Count; num7++)
			{
				OutputNode outputNode = node3.Outputs[num7];
				if (outputNode.Arrow == null)
				{
					outputNode.Arrow = _arrowPool.Get();
				}
				if (outputNode.Printer == null)
				{
					outputNode.Arrow.gameObject.SetActive(false);
					continue;
				}
				Vector3 vector2 = CameraScript.Instance.SSAScript.WorldToScreenPoint(outputNode.Printer.transform.position + Vector3.up);
				if (!rect.Contains(vector2) || vector2.z < 0f)
				{
					outputNode.Arrow.gameObject.SetActive(false);
					continue;
				}
				outputNode.Arrow.gameObject.SetActive(true);
				Vector3 vector3 = (vector + vector2) * 0.5f;
				outputNode.Arrow.color = ((node3.Printer.CheckSame(outputNode.Printer) || CheckValid(node3.Printer.GetHardwareComponent(), outputNode.Printer.GetHardwareProcess())) ? HUD.GetAccentColor() : HUD.GetWarningColor());
				outputNode.Arrow.rectTransform.anchoredPosition = new Vector2(vector3.x, 0f - ((float)Screen.height - vector3.y));
				outputNode.Arrow.rectTransform.sizeDelta = new Vector2((vector - vector2).magnitude - (float)num2, 32f);
				outputNode.Arrow.rectTransform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(vector2.y - vector.y, vector2.x - vector.x) * 57.29578f);
			}
		}
	}

	public void Toggle()
	{
		base.gameObject.SetActive(!base.gameObject.activeSelf);
	}
}
