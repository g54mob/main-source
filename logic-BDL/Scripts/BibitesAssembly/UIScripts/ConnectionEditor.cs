using System;
using SimulationScripts.BibiteScripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using Utility;

namespace UIScripts
{
	public class ConnectionEditor : PoolableItem<ConnectionEditor>, IPointerClickHandler, IEventSystemHandler
	{
		[NonSerialized]
		public NodeEditor nodeIn;

		[NonSerialized]
		public NodeEditor nodeOut;

		[NonSerialized]
		public UnityEvent<ConnectionEditor, PointerEventData> itemClicked = new UnityEvent<ConnectionEditor, PointerEventData>();

		[SerializeField]
		private Image img;

		[NonSerialized]
		public RectTransform rt;

		[NonSerialized]
		public NEATBrain.Synaps connection;

		private float alpha = 1f;

		private Material mat;

		private static readonly int Color1 = Shader.PropertyToID("_Color");

		private static readonly int Selected = Shader.PropertyToID("_Selected");

		public NEATBrain.NodeArchetype missingArchetype;

		public bool updatePlacement = true;

		public NodeEditor anchoredNode
		{
			get
			{
				if (!(nodeIn != null))
				{
					return nodeOut;
				}
				return nodeIn;
			}
		}

		public float weight => connection.Weight;

		public bool isEnabled => connection.En;

		public Vector2 middlePoint => (nodeIn.rt.anchoredPosition + nodeOut.rt.anchoredPosition) / 2f;

		public override void Initialize()
		{
			base.Initialize();
			img.material = UnityEngine.Object.Instantiate(img.material);
			mat = img.material;
			rt = GetComponent<RectTransform>();
		}

		public override void Retire()
		{
			base.Retire();
			if (nodeIn != null)
			{
				nodeIn.RemoveConnection(this, ingoing: false);
			}
			if (nodeOut != null)
			{
				nodeOut.RemoveConnection(this, ingoing: true);
			}
			nodeIn = null;
			nodeOut = null;
		}

		public override void Destroy()
		{
			base.Destroy();
			UnityEngine.Object.Destroy(mat);
		}

		public void AssignNodes(NodeEditor inNode, NodeEditor outNode, NEATBrain.Synaps synaps)
		{
			if (inNode != null)
			{
				nodeIn = inNode;
				nodeIn.AddConnection(this, ingoing: false);
			}
			else
			{
				missingArchetype = NEATBrain.NodeArchetype.Input;
			}
			if (outNode != null)
			{
				nodeOut = outNode;
				nodeOut.AddConnection(this, ingoing: true);
			}
			else
			{
				missingArchetype = NEATBrain.NodeArchetype.Output;
			}
			connection = synaps;
			connection.NodeIn = nodeIn?.node.Index ?? (-1);
			connection.NodeOut = nodeOut?.node.Index ?? (-1);
			updatePlacement = true;
			UpdateColor();
			UpdateThickness();
		}

		public void AssignMissingNode(NodeEditor node)
		{
			if (nodeIn == null)
			{
				nodeIn = node;
				connection.NodeIn = node.node.Index;
				nodeIn.AddConnection(this, ingoing: false);
			}
			else
			{
				nodeOut = node;
				connection.NodeOut = node.node.Index;
				nodeOut.AddConnection(this, ingoing: true);
			}
			updatePlacement = true;
		}

		public void ReassignNode(NodeEditor node, bool input)
		{
			if (input)
			{
				if (nodeIn != null)
				{
					nodeIn.RemoveConnection(this, ingoing: false);
				}
				nodeIn = node;
				nodeIn.AddConnection(this, ingoing: false);
			}
			else
			{
				if (nodeOut != null)
				{
					nodeOut.RemoveConnection(this, ingoing: true);
				}
				nodeOut = node;
				nodeOut.AddConnection(this, ingoing: true);
			}
		}

		private void Update()
		{
			if (updatePlacement)
			{
				UpdatePosition();
			}
		}

		public void Propagate()
		{
			if (!(nodeIn == null) && !(nodeOut == null) && connection.En)
			{
				float num = nodeIn.node.LastOutput * connection.Weight;
				if (nodeOut.node.Type == NEATBrain.NodeType.Mult)
				{
					nodeOut.activation *= num;
				}
				else
				{
					nodeOut.activation += num;
				}
			}
		}

		public void UpdatePosition()
		{
			rt.anchoredPosition = nodeIn?.rt.anchoredPosition ?? BibiteBrainEditor.instance.MouseToNodePos();
			Vector2 vector = (nodeOut?.rt.anchoredPosition ?? BibiteBrainEditor.instance.MouseToNodePos()) - rt.anchoredPosition;
			rt.sizeDelta = new Vector2(vector.magnitude, rt.sizeDelta.y);
			rt.eulerAngles = new Vector3(0f, 0f, Mathf.Atan2(vector.y, vector.x) * 57.29578f);
		}

		public void EditWeight(float val)
		{
			connection.Weight = val;
			UpdateColor();
			UpdateThickness();
		}

		public void EditEnabled(bool val)
		{
			connection.En = val;
			UpdateColor();
		}

		public void SetAlphaLow(bool val)
		{
			alpha = (val ? 0.02f : 1f);
			UpdateColor();
		}

		public void UpdateColor()
		{
			float num = connection.Weight;
			float num2 = (Mathf.Exp(num) - 1f) / (1f + Mathf.Exp(num));
			float a = (connection.En ? alpha : 0.25f);
			Color value = ((num >= 0f) ? new Color(1f - num2, 1f, 1f - num2, a) : new Color(1f, num2 + 1f, num2 + 1f, a));
			img.material.SetColor(Color1, value);
			img.materialForRendering.SetColor(Color1, value);
		}

		private void UpdateThickness()
		{
			float num = Mathf.Clamp(Mathf.Abs(connection.Weight), 0f, 25f);
			float num2 = (Mathf.Exp(num / 2f) - 1f) / (1f + Mathf.Exp(num / 2f)) * 6f + 10f;
			img.pixelsPerUnitMultiplier = 7f / num2;
			rt.sizeDelta = new Vector2(rt.sizeDelta.x, num2);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			itemClicked.Invoke(this, eventData);
		}

		public void SetHighlight(bool val)
		{
			img.material.SetInt(Selected, val ? 1 : 0);
			img.materialForRendering.SetInt(Selected, val ? 1 : 0);
		}
	}
}
