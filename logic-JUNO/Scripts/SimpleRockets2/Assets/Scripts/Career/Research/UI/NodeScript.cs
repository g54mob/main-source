using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Career.Contracts;
using DG.Tweening;
using ModApi.Audio;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Career.Research.UI
{
	public class NodeScript : BlockScript
	{
		public const float HalfLineThickness = 0.05f;

		public const float PaddingHeight = 1.25f;

		public const float PaddingWidth = 6f;

		[SerializeField]
		private GameObject _checkmark;

		private List<NodeScript> _children = new List<NodeScript>();

		[SerializeField]
		private Color _colorResearched;

		[SerializeField]
		private Color _colorResearchedLine;

		[SerializeField]
		private Color _colorSelected;

		[SerializeField]
		private Color _colorUnavailable;

		[SerializeField]
		private Color _colorUnavailableLine;

		[SerializeField]
		private TextMeshPro _cost;

		[SerializeField]
		private GameObject _featured;

		private Color _initialColor;

		private Color _initialColorOutline;

		private List<Transform> _lines = new List<Transform>();

		[SerializeField]
		private TextMeshPro _name;

		[SerializeField]
		private MeshRenderer _outlineRenderer;

		[SerializeField]
		private MeshRenderer _renderer;

		[SerializeField]
		private GameObject _researchParticles;

		private bool _selected;

		private float _startY;

		public IReadOnlyList<NodeScript> Children => _children;

		public float Height { get; set; }

		public NodeScript Parent { get; private set; }

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				if (_selected != value)
				{
					_selected = value;
					UpdateColor();
				}
			}
		}

		public TechNode TechNode { get; set; }

		public float TotalHeight
		{
			get
			{
				if (Children.Count == 0)
				{
					return Height;
				}
				float num = 0f;
				for (int i = 0; i < Children.Count; i++)
				{
					num += Children[i].TotalHeight;
					if (i < Children.Count - 1)
					{
						num += 1.25f;
					}
				}
				return num;
			}
		}

		public float TotalWidth
		{
			get
			{
				if (Children.Count == 0)
				{
					return Width;
				}
				return Width + 6f + Children.Max((NodeScript x) => x.TotalWidth);
			}
		}

		public float Width { get; } = 4f;

		public string CheckIfAvailable()
		{
			string result = null;
			if (Parent != null && !Parent.TechNode.Researched)
			{
				result = "Requires " + Parent.TechNode.Name;
			}
			else if (TechNode.Cost <= base.TechTreeUI.TechTree.ResearchPoints)
			{
				if (TechNode.RequiredContractID != null && !Game.Instance.GameState.Career.Contracts.Completed.Any((Contract x) => x.Id == TechNode.RequiredContractID))
				{
					string contractName = Game.Instance.GameState.Career.Contracts.GetContractName(TechNode.RequiredContractID);
					if (contractName != null)
					{
						result = "Must complete '" + contractName + "' contract";
					}
					else
					{
						Debug.LogError("Could not find contract with ID '" + TechNode.RequiredContractID + "' that is a requirement for tech node '" + TechNode.Id + "'");
					}
				}
			}
			else
			{
				result = "Insufficient Tech Points";
			}
			return result;
		}

		public void Initialize(TechNode node)
		{
			TechNode = node;
			Height = 1f;
			_name.text = node.Name;
			_featured.SetActive(node.IsFeatured);
			_cost.text = $"{node.Cost}";
			_initialColor = _renderer.material.color;
			_initialColorOutline = _outlineRenderer.material.color;
			UpdateColor();
			base.ClickSound = AudioLibrary.Design.SelectPart;
			base.BeginHover += delegate
			{
				base.transform.DOMoveY(_startY + 0.25f, 0.25f);
			};
			base.EndHover += delegate
			{
				base.transform.DOMoveY(_startY, 0.25f);
			};
		}

		public void MarkAsResearched(float duration = 0f)
		{
			_checkmark.SetActive(value: true);
			_cost.gameObject.SetActive(value: false);
			UpdateColor(duration);
			if (duration > 0f)
			{
				_researchParticles.SetActive(value: true);
			}
		}

		public override void OnClicked()
		{
			base.OnClicked();
			base.TechTreeUI.SetSelectedNode(this);
		}

		public void RefreshLayout(Vector3 position, bool createLines = true)
		{
			_startY = position.y;
			base.transform.position = position;
			float totalHeight = TotalHeight;
			float num = position.z - totalHeight / 2f;
			float num2 = position.x + Width + 6f;
			if (Children.Count > 0)
			{
				float z = position.z;
				float num3 = position.x + Width;
				float num4 = num3 + 3f;
				if (createLines)
				{
					CreateLine(new Vector2(num3, z), new Vector2(num4 - 0.05f, z));
				}
				float num5 = float.MaxValue;
				float num6 = float.MinValue;
				foreach (NodeScript child in Children)
				{
					num += child.TotalHeight / 2f;
					child.RefreshLayout(new Vector3(num2 + (float)child.TechNode.TierOffset * (Width + 6f), position.y, num));
					if (createLines)
					{
						CreateLine(new Vector2(num4 + 0.05f, num), new Vector2(child.transform.position.x, num));
					}
					num5 = Mathf.Min(num5, num);
					num6 = Mathf.Max(num6, num);
					num += child.TotalHeight / 2f;
					num += 1.25f;
				}
				if (createLines)
				{
					CreateLine(new Vector2(num4, num6 + 0.05f), new Vector2(num4, num5 - 0.05f));
				}
			}
			if (TechNode.Researched)
			{
				MarkAsResearched();
			}
		}

		public void SetParent(NodeScript parent)
		{
			if (Parent != null)
			{
				throw new NotSupportedException("Node cannot switch to a different parent.");
			}
			Parent = parent;
			parent._children.Add(this);
		}

		public void UpdateColor(float duration = 0f)
		{
			Color color = _initialColor;
			Color color2 = _initialColorOutline;
			bool flag = CheckIfAvailable() != null;
			if (_selected)
			{
				color = _colorSelected;
			}
			else if (TechNode.Researched)
			{
				color = _colorResearched;
			}
			else if (flag)
			{
				color2 = _colorUnavailableLine;
				color = _colorUnavailable;
			}
			SetColor(_renderer, color);
			SetColor(_outlineRenderer, color2);
			Color color3 = (TechNode.Researched ? _colorResearchedLine : _colorUnavailableLine);
			foreach (Transform line in _lines)
			{
				MeshRenderer component = line.GetComponent<MeshRenderer>();
				SetColor(component, color3, 0f);
			}
		}

		private void CreateLine(Vector2 startPosition, Vector2 endPosition)
		{
			Transform transform = base.TechTreeUI.CreateLine();
			Vector2 vector = endPosition - startPosition;
			transform.localRotation = Quaternion.Euler(0f, Mathf.Atan2(vector.y, vector.x) * 57.29578f, 0f);
			transform.localScale = new Vector3(vector.magnitude, 0.1f, 0.1f);
			Vector2 vector2 = (startPosition + endPosition) / 2f;
			transform.position = new Vector3(vector2.x, 0.52f, vector2.y);
			_lines.Add(transform);
		}

		private void SetColor(MeshRenderer renderer, Color color, float duration = 0.1f)
		{
			if (duration > 0f)
			{
				DOTween.To(() => renderer.material.color, delegate(Color x)
				{
					renderer.material.color = x;
				}, color, duration);
			}
			else
			{
				renderer.material.color = color;
			}
		}
	}
}
