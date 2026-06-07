using System.Collections.Generic;
using ModApi.Craft.Program;
using ModApi.Craft.Program.Instructions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Vizzy.UI.Elements
{
	public class InstructionElementScript : BlockElementScript
	{
		private const float InstructionOverlap = 6f;

		[SerializeField]
		private RectTransform _blockEnd;

		[SerializeField]
		private InstructionElementScript _childInstruction;

		private Vector2 _instructionSize;

		private float _nextConnectionOffset;

		[SerializeField]
		private InstructionElementScript _nextInstruction;

		private ConnectionPointType? _previewInstruction;

		[SerializeField]
		private InstructionElementScript _prevInstruction;

		private bool _supportsPreviousConnections = true;

		public InstructionElementScript ChildInstruction
		{
			get
			{
				return _childInstruction;
			}
			set
			{
				_childInstruction = value;
				Instruction.FirstChild = value?.Instruction;
			}
		}

		public override Color Color
		{
			get
			{
				return base.Color;
			}
			set
			{
				base.Color = value;
				if (_blockEnd != null)
				{
					Image component = _blockEnd.GetComponent<Image>();
					if (component != null)
					{
						component.color = value;
					}
				}
			}
		}

		public InstructionElementScript FirstInstruction
		{
			get
			{
				if (PrevInstruction == null)
				{
					return this;
				}
				return PrevInstruction.FirstInstruction;
			}
		}

		public ProgramInstruction Instruction { get; private set; }

		public InstructionElementScript LastInstruction
		{
			get
			{
				if (NextInstruction == null)
				{
					return this;
				}
				return NextInstruction.LastInstruction;
			}
		}

		public InstructionElementScript NextInstruction
		{
			get
			{
				return _nextInstruction;
			}
			set
			{
				_nextInstruction = value;
				Instruction.Next = value?.Instruction;
			}
		}

		public InstructionElementScript ParentInstruction { get; set; }

		public InstructionElementScript PrevInstruction
		{
			get
			{
				return _prevInstruction;
			}
			set
			{
				_prevInstruction = value;
			}
		}

		public override void Initialize(IVizzyUI vizzyUI, ProgramNode node, string style)
		{
			base.Initialize(vizzyUI, node, style);
			base.DragBehavior = DragBehaviorType.Move;
			Instruction = node as ProgramInstruction;
			base.ConnectionPoints.Add(new ConnectionPoint(this, ConnectionPointType.InstructionPrevious, Vector2.zero));
			base.ConnectionPoints.Add(new ConnectionPoint(this, ConnectionPointType.InstructionNext, Vector2.zero));
			if (Instruction.SupportsChildren)
			{
				base.ConnectionPoints.Add(new ConnectionPoint(this, ConnectionPointType.InstructionChild, Vector2.zero));
			}
			if (node is IfInstruction)
			{
				base.ConnectionPoints[1].SpecialConnection = SpecialConnectionType.If;
				if (node is ElseIfInstruction)
				{
					base.ConnectionPoints[0].SpecialConnection = SpecialConnectionType.Else;
					if (string.CompareOrdinal(base.Format, "else") == 0)
					{
						base.ConnectionPoints[1].SpecialConnection = SpecialConnectionType.None;
					}
				}
			}
			_supportsPreviousConnections = !(node is EventInstruction) && !(node is CustomInstruction);
		}

		public override Vector2 LayoutElement()
		{
			base.LayoutElement();
			_instructionSize = base.Size;
			Vector2 size = base.Size;
			if (_previewInstruction == ConnectionPointType.InstructionChild)
			{
				size.y += 50f;
			}
			if (ChildInstruction != null)
			{
				Vector2 anchoredPosition = new Vector2(12f, 0f - (size.y - 6f));
				ChildInstruction.RectTransform.anchoredPosition = anchoredPosition;
				InstructionElementScript instructionElementScript = ChildInstruction;
				while (instructionElementScript != null)
				{
					instructionElementScript.LayoutElement();
					size += new Vector2(0f, instructionElementScript.Size.y - 6f);
					instructionElementScript = instructionElementScript.NextInstruction;
				}
			}
			if (_blockEnd != null)
			{
				_blockEnd.SetAsLastSibling();
				if (size.y < _instructionSize.y + 30f)
				{
					size.y = _instructionSize.y + 30f;
				}
				_blockEnd.anchoredPosition = new Vector2(0f, 0f - (_instructionSize.y - 6f));
				_blockEnd.sizeDelta = new Vector2(size.x, size.y + 17f - _instructionSize.y);
				size.y += 11f;
			}
			if (_previewInstruction == ConnectionPointType.InstructionNext)
			{
				_nextConnectionOffset = 50f;
				size.y += 50f;
			}
			else
			{
				_nextConnectionOffset = 0f;
			}
			base.Size = size;
			RepsitionNextInstruction();
			return base.Size;
		}

		public override void OnUserConnected(ConnectionPoint thisConnection, ConnectionPoint targetConnection)
		{
			InstructionElementScript instructionElementScript = targetConnection.Block as InstructionElementScript;
			if (!(instructionElementScript != null))
			{
				return;
			}
			if (thisConnection.ConnectionPointType == ConnectionPointType.InstructionChild)
			{
				ConnectChildInstruction(this, instructionElementScript);
			}
			else if (targetConnection.ConnectionPointType == ConnectionPointType.InstructionChild)
			{
				ConnectChildInstruction(instructionElementScript, this);
			}
			else if (targetConnection.ConnectionPointType == ConnectionPointType.InstructionPrevious)
			{
				NextInstruction = instructionElementScript;
				if (instructionElementScript.PrevInstruction != null)
				{
					InstructionElementScript firstInstruction = FirstInstruction;
					firstInstruction.PrevInstruction = instructionElementScript.PrevInstruction;
					instructionElementScript.PrevInstruction.NextInstruction = firstInstruction;
				}
				instructionElementScript.PrevInstruction = this;
				RepsitionNextInstruction();
			}
			else if (targetConnection.ConnectionPointType == ConnectionPointType.InstructionNext)
			{
				PrevInstruction = instructionElementScript;
				if (instructionElementScript.NextInstruction != null)
				{
					InstructionElementScript lastInstruction = LastInstruction;
					lastInstruction.NextInstruction = instructionElementScript.NextInstruction;
					instructionElementScript.NextInstruction.PrevInstruction = lastInstruction;
				}
				instructionElementScript.NextInstruction = this;
				instructionElementScript.RepsitionNextInstruction();
			}
			OnChildSizeChanged();
		}

		public override void PreviewConnection(ConnectionPoint connectionPoint)
		{
			if ((connectionPoint != null && connectionPoint.ConnectionPointType == ConnectionPointType.InstructionNext) || (connectionPoint != null && connectionPoint.ConnectionPointType == ConnectionPointType.InstructionChild))
			{
				_previewInstruction = connectionPoint?.ConnectionPointType;
			}
			else
			{
				_previewInstruction = null;
			}
			OnChildSizeChanged();
		}

		protected override List<BlockElementScript> DragBegin()
		{
			OnChildSizeChanged();
			List<BlockElementScript> list = new List<BlockElementScript>();
			if (PrevInstruction != null)
			{
				PrevInstruction.NextInstruction = null;
				PrevInstruction = null;
			}
			if (ParentInstruction != null)
			{
				ParentInstruction.ChildInstruction = null;
				ParentInstruction = null;
			}
			UpdateConnectionPoints();
			list.Add(this);
			InstructionElementScript nextInstruction = NextInstruction;
			while (nextInstruction != null)
			{
				list.Add(nextInstruction);
				nextInstruction = nextInstruction.NextInstruction;
			}
			return list;
		}

		protected override void OnPointerClick(PointerEventData eventData)
		{
			base.OnPointerClick(eventData);
			if ((eventData.position - eventData.pressPosition).magnitude < 25f)
			{
				base.VizzyUI.SelectedElement = this;
			}
		}

		private static void ConnectChildInstruction(InstructionElementScript parent, InstructionElementScript child)
		{
			if (parent.ChildInstruction != null)
			{
				InstructionElementScript childInstruction = parent.ChildInstruction;
				childInstruction.ParentInstruction = null;
				InstructionElementScript lastInstruction = child.LastInstruction;
				lastInstruction.NextInstruction = childInstruction;
				childInstruction.PrevInstruction = lastInstruction;
			}
			parent.ChildInstruction = child;
			child.ParentInstruction = parent;
			InstructionElementScript instructionElementScript = child;
			while (instructionElementScript != null)
			{
				instructionElementScript.RectTransform.SetParent(parent.RectTransform, worldPositionStays: true);
				instructionElementScript = instructionElementScript.NextInstruction;
			}
		}

		private void RepsitionNextInstruction()
		{
			if (NextInstruction != null)
			{
				Vector2 anchoredPosition = base.RectTransform.anchoredPosition - new Vector2(0f, base.Size.y - 6f);
				if (NextInstruction.RectTransform.parent != base.RectTransform.parent)
				{
					NextInstruction.RectTransform.SetParent(base.RectTransform.parent, worldPositionStays: false);
				}
				NextInstruction.RectTransform.anchoredPosition = anchoredPosition;
				NextInstruction.RepsitionNextInstruction();
			}
			UpdateConnectionPoints();
		}

		private void UpdateConnectionPoints()
		{
			if (_supportsPreviousConnections)
			{
				base.ConnectionPoints[0].CanSeek = PrevInstruction == null && ParentInstruction == null;
				base.ConnectionPoints[0].CanReceive = base.ConnectionPoints[0].CanSeek;
			}
			else
			{
				base.ConnectionPoints[0].CanSeek = false;
				base.ConnectionPoints[0].CanReceive = false;
			}
			base.ConnectionPoints[1].CanSeek = NextInstruction == null;
			base.ConnectionPoints[1].CanReceive = true;
			base.ConnectionPoints[0].LocalPosition = new Vector2(16f, 0f);
			base.ConnectionPoints[1].LocalPosition = new Vector2(16f, 0f - base.Size.y + _nextConnectionOffset);
			if (Instruction.SupportsChildren)
			{
				base.ConnectionPoints[2].LocalPosition = new Vector2(30f, 0f - _instructionSize.y);
				base.ConnectionPoints[2].CanSeek = ChildInstruction == null;
				base.ConnectionPoints[2].CanReceive = true;
			}
		}
	}
}
