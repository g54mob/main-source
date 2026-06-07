using Assets.Scripts.UI;
using Jundroo.Common.Platform;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Design.UI
{
	public class PartButtonScript : WidgetScript, IDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler
	{
		private const float MinimumDragDelta = 100f;

		private bool _beginDrag;

		private ButtonWidget _deleteButton;

		private Vector2 _delta;

		private bool _draggingPart;

		private float _requiredDragDelta;

		private bool _selected;

		public string Category { get; private set; }

		public TextWidget NameText { get; private set; }

		public DesignerPart Part { get; private set; }

		public RawImageWidget PartIcon { get; private set; }

		public PartListPanelScript PartListPanel { get; private set; }

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
					if (Part.IsSubassembly)
					{
						_deleteButton.Visible = _selected;
					}
				}
			}
		}

		public void Initialize(PartListPanelScript partListPanel, string name, DesignerPart part, string category, Texture2D texture)
		{
			base.gameObject.name = "PartButton-" + name;
			PartListPanel = partListPanel;
			Part = part;
			Category = category;
			NameText.Text = name;
			PartIcon.Image.texture = texture;
			Widget widget = base.Widget.FindWidget("container");
			widget.AddClass((part != null) ? "show-part-animation" : "show-category-animation");
			widget.UpdateWidget(null);
			widget.Show();
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				_delta = Vector2.zero;
				_draggingPart = false;
				_beginDrag = true;
				ExecuteEvents.ExecuteHierarchy(base.transform.parent.gameObject, eventData, ExecuteEvents.beginDragHandler);
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (eventData.button != PointerEventData.InputButton.Left)
			{
				return;
			}
			if (_beginDrag && !_draggingPart && Part != null)
			{
				_delta += eventData.delta;
				if (_delta.x - Mathf.Abs(_delta.y * 0.75f) > 50f)
				{
					if (Device.IsDemoBuild)
					{
						Game.Instance.UserInterface.CreateMessageDialog("Adding parts is not available in the demo version of the game.", "Not Available In Demo");
						_beginDrag = false;
					}
					else
					{
						_draggingPart = true;
						PartListPanel.AddPart(this, eventData);
						ExecuteEvents.ExecuteHierarchy(base.transform.parent.gameObject, eventData, ExecuteEvents.endDragHandler);
					}
				}
			}
			else
			{
				PartListPanel.MovePart(eventData);
			}
			if (!_draggingPart)
			{
				ExecuteEvents.ExecuteHierarchy(base.transform.parent.gameObject, eventData, ExecuteEvents.dragHandler);
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				_delta = Vector2.zero;
				_beginDrag = false;
				if (_draggingPart)
				{
					PartListPanel.FinishedAddingPart(eventData);
				}
				else
				{
					ExecuteEvents.ExecuteHierarchy(base.transform.parent.gameObject, eventData, ExecuteEvents.endDragHandler);
				}
			}
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_draggingPart = false;
			NameText = widget.FindWidget<TextWidget>("part-name-text");
			PartIcon = widget.FindWidget<RawImageWidget>("part-icon");
			_deleteButton = widget.FindWidget<ButtonWidget>("delete-button");
		}

		private void OnClicked(Widget widget)
		{
			if (!_beginDrag)
			{
				if (!string.IsNullOrEmpty(Category))
				{
					PartListPanel.CategorySelected(Category);
				}
				else
				{
					PartListPanel.SelectPartButton(this);
				}
			}
		}

		private void OnDeleteButtonClicked(Widget widget)
		{
			MessageDialogScript dialog = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			dialog.MessageText = "Confirm that you wish to delete the subassembly '" + Part.Name + "'.";
			dialog.UseDangerButtonStyle = true;
			dialog.OkayClicked += delegate
			{
				dialog.Close();
				PartListPanel.DeleteSubassembly(Part);
			};
		}
	}
}
