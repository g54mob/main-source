using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.UI;
using Jundroo.Common.Coroutines;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using Shapes;
using UnityEngine;

namespace Assets.Scripts.Design.UI
{
	public class PartConnectionsPanelScript : DesignerPanelScript
	{
		private class AttachmentLine
		{
			public Line Line { get; set; }

			public PartConnection PartConnection { get; internal set; }

			public AttachPointScript SourceAttachPoint { get; set; }

			public AttachPointScript TargetAttachPoint { get; set; }

			public void Update()
			{
				Line.Start = SourceAttachPoint.transform.position;
				Line.End = TargetAttachPoint.transform.position;
			}
		}

		private List<PartConnectionItemScript> _connectionScripts = new List<PartConnectionItemScript>();

		private Widget _connectionsParent;

		private PartData _currentPart;

		private AttachPointData _firstAttachPoint;

		private Material _hiddenSelectedMaterial;

		private Color _lineColor;

		private Color _lineColorHovered;

		private GameObject _lineParent;

		private List<AttachmentLine> _lines = new List<AttachmentLine>();

		private RunOnceOnNextUpdate _onFirstAPSelected;

		private RunOnceOnNextUpdate _onSecondPartSelected;

		private PartData _secondPart;

		private TextWidget _selectedPartLabel;

		private string _selectedPartLabelFormat;

		private bool _updateQueued;

		public void GhostAllPartsExcept(PartData partToHighlight)
		{
			PartData part = base.Designer.SelectedPart.Part;
			foreach (PartData part2 in base.Designer.Aircraft.Aircraft.Assembly.Parts)
			{
				PartMaterialScript partMaterialScript = part2.PartScript.PartMaterialScript;
				if (part2 == part)
				{
					partMaterialScript.IsHidden = true;
					partMaterialScript.SetSelected(selected: true, updateSymmetricParts: false);
					partMaterialScript.IsHighlighted = true;
					partMaterialScript.OverrideMaterial = _hiddenSelectedMaterial;
				}
				else if (part2 == partToHighlight)
				{
					partMaterialScript.IsHidden = false;
					partMaterialScript.SetSelected(selected: false, updateSymmetricParts: false);
					partMaterialScript.IsHighlighted = true;
					partMaterialScript.OverrideMaterial = null;
				}
				else
				{
					partMaterialScript.IsHidden = true;
					partMaterialScript.SetSelected(selected: false, updateSymmetricParts: false);
					partMaterialScript.IsHighlighted = false;
					partMaterialScript.OverrideMaterial = null;
				}
			}
		}

		public override void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			base.InitializeDesignerPanel(designerUI);
			_hiddenSelectedMaterial = Game.Instance.ResourceLoader.LoadSharedMaterial("Designer/Materials/DesignerPartHiddenSelected");
			base.Designer.AircraftStructureChangedEvent += Designer_AircraftStructureChanged;
			_connectionsParent = base.Widget.FindWidget("connections-parent");
			_selectedPartLabel = base.Widget.FindWidget<TextWidget>("selected-part-label");
			_selectedPartLabelFormat = base.Widget.Stylesheet.GetConstant("PartNameFormat") ?? "{PartName}";
			base.Flyout.Opened += OnFlyoutOpened;
			base.Flyout.Closed += OnFlyoutClosed;
			_lineColorHovered = Constants.Colors.HighlightColor;
			_lineColor = _lineColorHovered;
			_lineColor.a = 0.1f;
		}

		public void OnConnectionRemoved(PartConnectionItemScript connection)
		{
			_connectionScripts.Remove(connection);
			base.Designer.OnAircraftStructureChanged();
			Designer.Instance.CreateUndoStepForSelectedPart("Connection Removed");
		}

		public void OnItemHoveredStateChanged(PartConnectionItemScript item, bool hover)
		{
			if (hover)
			{
				GhostAllPartsExcept(item.OtherPart);
			}
			else
			{
				ResetGhosting();
			}
			foreach (AttachmentLine line in _lines)
			{
				if (line.PartConnection == item.PartConnection && hover)
				{
					line.Line.Color = _lineColorHovered;
				}
				else
				{
					line.Line.Color = _lineColor;
				}
			}
		}

		public void ResetGhosting()
		{
			PartData partData = base.Designer.SelectedPart?.Part;
			foreach (PartData part in base.Designer.Aircraft.Aircraft.Assembly.Parts)
			{
				PartMaterialScript partMaterialScript = part.PartScript.PartMaterialScript;
				partMaterialScript.IsHidden = base.Designer.GhostViewEnabled && part != partData;
				partMaterialScript.IsHighlighted = false;
				partMaterialScript.OverrideMaterial = null;
			}
		}

		protected virtual void Update()
		{
			PartData partData = base.Designer.SelectedPart?.Part;
			if (partData != _currentPart || _updateQueued)
			{
				_currentPart = partData;
				_updateQueued = false;
				_selectedPartLabel.RichText = ((_currentPart == null) ? "No Part Selected" : _selectedPartLabelFormat.Replace("{PartName}", StringUtility.ClampString(_currentPart.Name, 25)).Replace("{PartNumber}", _currentPart.Id.ToString()));
				UpdateConnectionEntries(partData);
			}
			foreach (AttachmentLine line in _lines)
			{
				line.Update();
			}
		}

		private void CreateConnectionEntry(PartConnection connection, PartData part)
		{
			PartData otherPart = connection.GetOtherPart(part);
			Widget widget = base.Widget.Context.CreateWidgetFromTemplate("list-item", _connectionsParent);
			PartConnectionItemScript partConnectionItemScript = widget.gameObject.AddComponent<PartConnectionItemScript>();
			partConnectionItemScript.Initialize(widget, this, connection, otherPart);
			_connectionScripts.Add(partConnectionItemScript);
		}

		private void CreateLine(AttachPointScript source, AttachPointScript target, PartConnection partConnection)
		{
			if (_lineParent == null)
			{
				_lineParent = new GameObject("Connections Line Parent");
				_lineParent.transform.SetParent(base.Designer.DesignerScript.transform);
			}
			GameObject obj = new GameObject("ShapesLine");
			obj.transform.SetParent(_lineParent.transform);
			Line line = obj.AddComponent<Line>();
			line.Thickness = 0.025f;
			line.Color = _lineColor;
			line.EndCaps = LineEndCap.Round;
			AttachmentLine attachmentLine = new AttachmentLine
			{
				Line = line,
				SourceAttachPoint = source,
				TargetAttachPoint = target,
				PartConnection = partConnection
			};
			attachmentLine.Update();
			_lines.Add(attachmentLine);
		}

		private void Designer_AircraftStructureChanged()
		{
			_updateQueued = true;
		}

		private void DestroyLines()
		{
			_lines.Clear();
			if (_lineParent != null)
			{
				Object.Destroy(_lineParent);
				_lineParent = null;
			}
		}

		private void DisconnectPart()
		{
			int num = base.Designer.DisconnectPart(base.Designer.SelectedPart.Part, disconnectSymmetricParts: true);
			base.Designer.OnAircraftStructureChanged();
			base.DesignerUI.ShowMessage($"{num} connection(s) removed");
			base.Designer.CreateUndoStepForSelectedPart("Disconnected");
		}

		private void OnAddConnectionButtonClicked(Widget wiget)
		{
			if (!(base.Designer.SelectedPart == null))
			{
				base.DesignerUI.ShowMessage("Select the attach point to connect from.");
				base.Designer.Tools.SelectChooseAttachPointTool(base.Designer.SelectedPart.Part, delegate(AttachPointData firstAttach)
				{
					_firstAttachPoint = firstAttach;
					_onFirstAPSelected.Queue();
				}, (AttachPointData attachPoint) => (attachPoint.IsAvailable || attachPoint.AllowMultipleManualConnections) && attachPoint.SeekType != AttachPointConnectionType.None && attachPoint.AllowManualConnection);
			}
		}

		private void OnDisconnectButtonClicked(Widget widget)
		{
			if (!(base.Designer.SelectedPart == null))
			{
				DisconnectPart();
				UpdateConnectionEntries(base.Designer.DesignerScript.SelectedPart.Part);
			}
		}

		private void OnFirstAPSelected()
		{
			if (_firstAttachPoint == null)
			{
				base.DesignerUI.ShowMessage("No attach point selected.");
				ResetGhosting();
				return;
			}
			base.DesignerUI.ShowMessage("Select the part to connect to.");
			base.Designer.Tools.SelectChoosePartTool((PartData x) => true, connectedToSelectedPart: false, -1, "No parts to connect to.", delegate(PartData secondPart)
			{
				_secondPart = secondPart;
				_onSecondPartSelected.Queue();
			}, Game.Instance.Device.IsTouchEnabled);
			base.Designer.SelectedPart.PartMaterialScript.IsHidden = true;
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
			DestroyLines();
		}

		private void OnFlyoutOpened(IFlyout flyout)
		{
			UpdateConnectionEntries(base.Designer.SelectedPart?.Part);
			_onFirstAPSelected = new RunOnceOnNextUpdate(this, OnFirstAPSelected);
			_onSecondPartSelected = new RunOnceOnNextUpdate(this, OnSecondPartSelected);
		}

		private void OnReconnectButtonClicked(Widget widget)
		{
			if (!(base.Designer.SelectedPart == null))
			{
				base.Designer.ReconnectSelectedPart();
				base.Designer.OnAircraftStructureChanged();
				base.Designer.CreateUndoStepForSelectedPart("Reconnected");
				UpdateConnectionEntries(base.Designer.SelectedPart.Part);
			}
		}

		private void OnSecondPartSelected()
		{
			if (_secondPart == base.Designer.SelectedPart.Part)
			{
				base.DesignerUI.ShowMessage("Cannot connect a part to itself");
				return;
			}
			if (_secondPart == null)
			{
				base.DesignerUI.ShowMessage("No part selected.");
				return;
			}
			base.DesignerUI.ShowMessage("Select the attach point to connect to.");
			base.Designer.Tools.SelectChooseAttachPointTool(_secondPart, delegate(AttachPointData secondAttach)
			{
				if (secondAttach == null)
				{
					base.DesignerUI.ShowMessage("No attach point selected.");
					ResetGhosting();
				}
				else
				{
					if (secondAttach.AttachPointScript.PartScript != _firstAttachPoint.AttachPointScript.PartScript)
					{
						base.DesignerUI.ShowMessage(null);
						List<(PartData, PartData)> value;
						using (CollectionPool<List<(PartData, PartData)>, (PartData, PartData)>.Get(out value))
						{
							MovePartTool.ConnectPartToAttachPoint(secondAttach.AttachPointScript, _firstAttachPoint.AttachPointScript, connectSymmetricParts: true, autoConcealSymmetricParts: false, value);
							base.Designer.OnAircraftStructureChanged();
							PartData part = _firstAttachPoint.AttachPointScript.PartScript.Part;
							PartData part2 = secondAttach.AttachPointScript.PartScript.Part;
							base.DesignerUI.AppendMessage($"Connected part '{part.Name} (ID: {part.Id})' to part '{part2.Name} (ID: {part2.Id})'.");
							foreach (var item in value)
							{
								base.DesignerUI.AppendMessage(string.Format("Connected {0}part '{1} (ID: {2})' to {3}part '{4} (ID: {5})'.", (part.SymmetryId == 0) ? string.Empty : "symmetric ", item.Item1.Name, item.Item1.Id, (part2.SymmetryId == 0) ? string.Empty : "symmetric ", item.Item2.Name, item.Item2.Id));
							}
							base.Designer.CreateUndoStepForSelectedPart("Connection Added");
							_updateQueued = true;
							return;
						}
					}
					base.DesignerUI.ShowMessage("Cannot select the same part.");
					ResetGhosting();
				}
			}, (AttachPointData targetAttachPoint) => (targetAttachPoint.IsAvailable || targetAttachPoint.AllowMultipleManualConnections) && targetAttachPoint.CanReceive(_firstAttachPoint));
		}

		private void UpdateConnectionEntries(PartData part)
		{
			if (!base.gameObject.activeInHierarchy)
			{
				return;
			}
			ResetGhosting();
			foreach (PartConnectionItemScript connectionScript in _connectionScripts)
			{
				connectionScript.Widget.Destroy();
			}
			_connectionScripts.Clear();
			DestroyLines();
			if (part == null)
			{
				return;
			}
			foreach (PartConnection partConnection in part.PartConnections)
			{
				CreateConnectionEntry(partConnection, part);
				foreach (AttachPointData item in partConnection.AttachPointsA)
				{
					foreach (AttachPointData item2 in partConnection.AttachPointsB)
					{
						_ = item.AttachPointScript.transform.position;
						_ = item2.AttachPointScript.transform.position;
						CreateLine(item.AttachPointScript, item2.AttachPointScript, partConnection);
					}
				}
			}
		}
	}
}
