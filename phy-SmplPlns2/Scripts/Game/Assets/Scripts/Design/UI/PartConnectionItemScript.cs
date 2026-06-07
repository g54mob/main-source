using System;
using Assets.Scripts.Craft.Parts;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI
{
	public class PartConnectionItemScript : MonoBehaviour
	{
		private PartConnectionsPanelScript _parent;

		private DateTime _pressTime;

		public PartData OtherPart { get; private set; }

		public PartConnection PartConnection { get; private set; }

		public Widget Widget { get; private set; }

		public void Initialize(Widget widget, PartConnectionsPanelScript partConnectionsPanel, PartConnection connection, PartData otherPart)
		{
			string text = widget.Stylesheet.GetConstant("PartNameFormat") ?? "{PartName}";
			Widget = widget;
			Widget.EventHandler = this;
			Widget.FindWidget<TextWidget>("item-name").RichText = text.Replace("{PartName}", StringUtility.ClampString(otherPart.Name, 25)).Replace("{PartNumber}", otherPart.Id.ToString());
			Widget.Clicked += OnItemClicked;
			Widget.PointerEnter += delegate
			{
				OnHover(value: true);
			};
			Widget.PointerExit += delegate
			{
				OnHover(value: false);
			};
			Widget.PointerDown += delegate
			{
				OnPress(pressed: true);
			};
			Widget.PointerUp += delegate
			{
				OnPress(pressed: false);
			};
			_parent = partConnectionsPanel;
			PartConnection = connection;
			OtherPart = otherPart;
		}

		private void OnDeleteButtonClicked(Widget widget)
		{
			Remove();
			_parent.OnConnectionRemoved(this);
		}

		private void OnHover(bool value)
		{
			if (!Game.Instance.Device.IsTouchEnabled)
			{
				if (value)
				{
					_parent.OnItemHoveredStateChanged(this, hover: true);
				}
				else
				{
					_parent.OnItemHoveredStateChanged(this, hover: false);
				}
			}
		}

		private void OnItemClicked(Widget widget)
		{
			TimeSpan timeSpan = DateTime.UtcNow - _pressTime;
			if (!Game.Instance.Device.IsTouchEnabled || timeSpan.TotalMilliseconds < 250.0)
			{
				_parent.Designer.SelectedPart = OtherPart.PartScript;
			}
		}

		private void OnPress(bool pressed)
		{
			if (pressed)
			{
				_pressTime = DateTime.UtcNow;
			}
			if (Game.Instance.Device.IsTouchEnabled)
			{
				if (pressed)
				{
					_parent.OnItemHoveredStateChanged(this, hover: true);
				}
				else
				{
					_parent.OnItemHoveredStateChanged(this, hover: false);
				}
			}
		}

		private void Remove()
		{
			PartData otherPart = OtherPart;
			Widget.Destroy();
			int num = PartConnection.DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: true, raiseConnectionChangedEvents: true);
			_parent.DesignerUI.ShowMessage($"Removed connection to '{OtherPart.Name} (ID: {otherPart.Id})'" + ((num <= 1) ? string.Empty : string.Format(" and {0} other symmetric connection{1}", num - 1, (num == 2) ? string.Empty : "s")));
		}
	}
}
