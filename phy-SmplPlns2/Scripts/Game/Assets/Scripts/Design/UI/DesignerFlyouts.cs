using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Design.Demo;
using Assets.Scripts.UI;
using Jundroo.Common.Platform;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI
{
	public class DesignerFlyouts : IDesignerFlyouts
	{
		public delegate void FlyoutNotificationDelegate(IFlyout flyout);

		private List<DesignerPanelScript> _panels = new List<DesignerPanelScript>();

		private Action<IFlyout> _pendingFlyoutOpenedAction;

		private IFlyout _selected;

		public IFlyout Blueprints { get; private set; }

		public IFlyout CraftProperties { get; }

		public DesignerUIScript DesignerUI { get; }

		public IFlyout DragVisualizer { get; }

		public IFlyout Environment { get; }

		public IFlyout FuselageShape { get; }

		public IFlyout JFuselageShape { get; }

		public IFlyout LoadCraft { get; private set; }

		public IFlyout Menu { get; private set; }

		public IFlyout Paint { get; }

		public IFlyout PartConnections { get; }

		public IFlyout PartList { get; }

		public IFlyout PartProperties { get; }

		public IFlyout SearchParts { get; }

		public IFlyout Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				if (_selected == value)
				{
					return;
				}
				if (Device.IsDemoBuild && (value == Blueprints || value == PartConnections || value == TransformPart))
				{
					Game.Instance.UserInterface.CreateMessageDialog(DemoMessages.FlyoutNotAvailable(value), "Not Available In Demo");
					return;
				}
				if (_selected != null)
				{
					_selected.Opened -= OnFlyoutOpened;
					_selected.Closed -= OnFlyoutClosed;
					_selected.Show(show: false);
					_selected = null;
				}
				_selected = value;
				if (_selected != null)
				{
					_selected.Opened += OnFlyoutOpened;
					_selected.Closed += OnFlyoutClosed;
					_selected.Show(show: true);
				}
				this.SelectedFlyoutChanged?.Invoke(_selected);
			}
		}

		public IFlyout Symmetry { get; }

		public IFlyout TransformPart { get; }

		public IFlyout Tutorials { get; }

		public IFlyout UndoHistory { get; }

		public IFlyout WingEditor { get; }

		public event FlyoutNotificationDelegate SelectedFlyoutChanged;

		public DesignerFlyouts(DesignerUIScript designerUI, Widget root)
		{
			DesignerUI = designerUI;
			Menu = RegisterFlyout(root, "flyout-menu");
			LoadCraft = RegisterFlyout(root, "flyout-load-craft");
			CraftProperties = RegisterFlyout(root, "flyout-craft-properties");
			PartList = RegisterFlyout(root, "flyout-part-list");
			Symmetry = RegisterFlyout(root, "flyout-symmetry");
			Environment = RegisterFlyout(root, "flyout-environment");
			PartConnections = RegisterFlyout(root, "flyout-part-connections");
			Blueprints = RegisterFlyout(root, "flyout-blueprints");
			TransformPart = RegisterFlyout(root, "flyout-transform-part");
			FuselageShape = RegisterFlyout(root, "flyout-fuselage-shape");
			JFuselageShape = RegisterFlyout(root, "flyout-new-fuselage-shape");
			PartProperties = RegisterFlyout(root, "flyout-part-properties");
			Paint = RegisterFlyout(root, "flyout-paint");
			WingEditor = RegisterFlyout(root, "flyout-wing-editor");
			SearchParts = RegisterFlyout(root, "flyout-search-parts");
			UndoHistory = RegisterFlyout(root, "flyout-undo-history");
			DragVisualizer = RegisterFlyout(root, "flyout-drag-visualizer");
			Tutorials = RegisterFlyout(root, "flyout-tutorials");
		}

		public IFlyout FindById(string id)
		{
			return _panels.Where((DesignerPanelScript x) => x.Flyout.Id == id).FirstOrDefault()?.Flyout;
		}

		public void SelectFlyoutAndQueueAction(IFlyout flyout, Action<IFlyout> flyoutOpenedAction)
		{
			if (Selected == flyout && flyout.IsOpen)
			{
				flyoutOpenedAction(flyout);
				return;
			}
			_pendingFlyoutOpenedAction = flyoutOpenedAction;
			Selected = flyout;
		}

		public void ToggleFlyout(IFlyout flyout)
		{
			if (Selected == flyout)
			{
				Selected = null;
			}
			else
			{
				Selected = flyout;
			}
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
			if (_selected == flyout)
			{
				_selected.Opened -= OnFlyoutOpened;
				_selected.Closed -= OnFlyoutClosed;
				_selected = null;
				this.SelectedFlyoutChanged?.Invoke(_selected);
			}
		}

		private void OnFlyoutOpened(IFlyout flyout)
		{
			if (_pendingFlyoutOpenedAction != null)
			{
				_pendingFlyoutOpenedAction(flyout);
				_pendingFlyoutOpenedAction = null;
			}
		}

		private IFlyout RegisterFlyout(Widget root, string id)
		{
			DesignerPanelScript designerPanelScript = root.FindWidget(id)?.gameObject.GetComponentInChildren<DesignerPanelScript>(includeInactive: true);
			if (designerPanelScript != null)
			{
				designerPanelScript.InitializeDesignerPanel(DesignerUI);
			}
			else
			{
				Debug.LogError("Could not find designer panel " + id);
			}
			_panels.Add(designerPanelScript);
			return designerPanelScript.Flyout;
		}
	}
}
