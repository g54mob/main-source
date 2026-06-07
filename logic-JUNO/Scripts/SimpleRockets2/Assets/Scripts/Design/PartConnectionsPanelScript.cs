using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Craft.Parts;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design
{
	public class PartConnectionsPanelScript : DesignerSubPanelScript
	{
		private List<XmlElement> _attachPointElements = new List<XmlElement>();

		private XmlElement _attachPointParent;

		private XmlElement _connectButton;

		private TextMeshProUGUI _connectingText;

		private AttachPoint _highlightedAttachPoint;

		private IPartScript _highlightedPart;

		private XmlElement _panelAttachPoints;

		private XmlElement _panelButtons;

		private XmlElement _panelConnecting;

		private AttachPoint _sourceAttachPoint;

		private (AttachPoint AttachPoint, XmlElement Element)? _targetAttachPoint;

		private XmlElement _targetAttachPointParent;

		private List<XmlElement> _targetAttachPoints = new List<XmlElement>();

		private XmlElement _templateAttachPoint;

		private XmlElement _templatePartConnection;

		private XmlElement _templateTargetAttachPoint;

		private PartConnectionsTool _tool;

		public AttachPoint HighlightedAttachPoint
		{
			get
			{
				return _highlightedAttachPoint;
			}
			private set
			{
				if (_highlightedAttachPoint != value)
				{
					if (_highlightedAttachPoint != null)
					{
						_highlightedAttachPoint.AttachPointScript.Visible = false;
					}
					_highlightedAttachPoint = value;
					if (_highlightedAttachPoint != null)
					{
						_highlightedAttachPoint.AttachPointScript.Visible = true;
					}
				}
			}
		}

		public IPartScript HighlightedPart
		{
			get
			{
				return _highlightedPart;
			}
			set
			{
				if (_highlightedPart != null)
				{
					_highlightedPart.PartMaterialScript.IsHighlighted = false;
				}
				_highlightedPart = value;
				if (_highlightedPart != null)
				{
					_highlightedPart.PartMaterialScript.IsHighlighted = true;
				}
			}
		}

		public AttachPoint SourceAttachPoint
		{
			get
			{
				return _sourceAttachPoint;
			}
			private set
			{
				if (_sourceAttachPoint != value)
				{
					if (_sourceAttachPoint != null)
					{
						_sourceAttachPoint.AttachPointScript.Visible = false;
					}
					_sourceAttachPoint = value;
					if (_sourceAttachPoint != null)
					{
						_sourceAttachPoint.AttachPointScript.Visible = true;
					}
				}
			}
		}

		public (AttachPoint AttachPoint, XmlElement Element)? TargetAttachPoint
		{
			get
			{
				return _targetAttachPoint;
			}
			private set
			{
				(AttachPoint, XmlElement)? targetAttachPoint = _targetAttachPoint;
				(AttachPoint, XmlElement)? tuple = value;
				bool hasValue = targetAttachPoint.HasValue;
				if (hasValue == tuple.HasValue)
				{
					if (!hasValue)
					{
						return;
					}
					(AttachPoint, XmlElement) valueOrDefault = targetAttachPoint.GetValueOrDefault();
					(AttachPoint, XmlElement) valueOrDefault2 = tuple.GetValueOrDefault();
					if (valueOrDefault.Item1 == valueOrDefault2.Item1 && !(valueOrDefault.Item2 != valueOrDefault2.Item2))
					{
						return;
					}
				}
				if (_targetAttachPoint.HasValue)
				{
					_targetAttachPoint.Value.Element.RemoveClass("btn-primary");
				}
				_targetAttachPoint = value;
				HighlightedAttachPoint = _targetAttachPoint?.AttachPoint;
				if (_targetAttachPoint.HasValue)
				{
					_targetAttachPoint.Value.Element.AddClass("btn-primary");
				}
			}
		}

		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			base.DesignerUi.Designer.CraftStructureChanged += OnCraftStructureChanged;
			base.DesignerUi.Designer.SelectedPartChanged += OnSelectedPartChanged;
			_tool = base.DesignerUi.Designer.PartConnectionsTool;
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			_attachPointParent = base.xmlLayout.GetElementById("attach-points");
			_targetAttachPointParent = base.xmlLayout.GetElementById("target-attach-points");
			_templateAttachPoint = base.xmlLayout.GetElementById("template-attach-point");
			_templatePartConnection = base.xmlLayout.GetElementById("template-connection");
			_templateTargetAttachPoint = base.xmlLayout.GetElementById("template-target-attach-point");
			_panelConnecting = base.xmlLayout.GetElementById("connecting-panel");
			_panelAttachPoints = base.xmlLayout.GetElementById("attach-points");
			_panelButtons = base.xmlLayout.GetElementById("button-panel");
			_connectingText = base.xmlLayout.GetElementById<TextMeshProUGUI>("connecting-text");
			_connectButton = base.xmlLayout.GetElementById("connect-button");
			_panelButtons.SetActive(active: false);
		}

		public override void OnOpened()
		{
			base.OnOpened();
			RefreshPanel();
		}

		public override void OnClosed()
		{
			base.OnClosed();
			HighlightedPart = null;
			HighlightedAttachPoint = null;
			EndManualPartConnection(refreshPanel: false);
		}

		private static string GetDisplayName(AttachPoint attachPoint)
		{
			if (attachPoint.ConnectionType == AttachPointConnectionType.Shell)
			{
				return attachPoint.DisplayName + "(Shell)";
			}
			return attachPoint.DisplayName;
		}

		private void ConnectParts(AttachPointScript attachPointA, AttachPointScript attachPointB)
		{
			IPartScript partScript = attachPointA.PartScript;
			IPartScript partScript2 = attachPointB.PartScript;
			if (partScript.Disconnected != partScript2.Disconnected)
			{
				IPartScript partScript3 = null;
				AttachPoint attachPoint = null;
				if (partScript.Disconnected)
				{
					partScript3 = partScript;
					attachPoint = attachPointB.AttachPoint;
				}
				else
				{
					partScript3 = partScript2;
					attachPoint = attachPointA.AttachPoint;
				}
				Symmetry.UpdateSymmetry(new PartGraph(partScript3.Data, breakOnRigidBodyBoundary: false).Parts.Select((PartData x) => x.PartScript).ToList(), partScript3, attachPoint);
			}
			PartScript.ConnectPartsAndUpdateSymmetry(attachPointA, attachPointB);
		}

		private void CreateAttachPointUI(AttachPoint attachPoint, PartData part)
		{
			XmlElement attachPointParent = _attachPointParent;
			XmlElement xmlElement = UiUtilities.CloneTemplate(_templateAttachPoint, attachPointParent);
			xmlElement.GetElementByInternalId<TextMeshProUGUI>("ap-name").text = GetDisplayName(attachPoint);
			XmlElement elementByInternalId = xmlElement.GetElementByInternalId("ap-icon");
			if (attachPoint.FuelLine)
			{
				elementByInternalId.AddClass("ap-fuel-line");
			}
			else if (attachPoint.AllowRotation && !attachPoint.IgnoreSurfaces)
			{
				elementByInternalId.AddClass("ap-rotating");
			}
			else if (attachPoint.IsSurfaceAttachPoint)
			{
				elementByInternalId.AddClass("ap-surface");
			}
			if (attachPoint.ConnectionType == AttachPointConnectionType.Fairing)
			{
				elementByInternalId.AddClass("ap-fairing");
			}
			Toggle elementByInternalId2 = xmlElement.GetElementByInternalId<Toggle>("ap-toggle");
			elementByInternalId2.onValueChanged.AddListener(delegate(bool x)
			{
				OnAttachPointToggled(attachPoint, x);
			});
			elementByInternalId2.isOn = attachPoint.Enabled;
			xmlElement.GetElementByInternalId("add-connection-button").AddOnClickEvent(delegate
			{
				OnAddConnectionButtonClicked(part, attachPoint);
			});
			XmlElement elementByInternalId3 = xmlElement.GetElementByInternalId("attachpoint-header");
			elementByInternalId3.AddOnMouseEnterEvent(delegate
			{
				HighlightedAttachPoint = attachPoint;
			});
			elementByInternalId3.AddOnMouseExitEvent(delegate
			{
				HighlightedAttachPoint = null;
			});
			foreach (PartConnection partConnection in attachPoint.PartConnections)
			{
				PartData otherPart = partConnection.GetOtherPart(part);
				XmlElement xmlElement2 = UiUtilities.CloneTemplate(_templatePartConnection, xmlElement);
				TextMeshProUGUI elementByInternalId4 = xmlElement2.GetElementByInternalId<TextMeshProUGUI>("connection-name");
				string text = $"{otherPart.Name} #{otherPart.Id}";
				PartConnection.Attachment attachment = partConnection.Attachments.Where((PartConnection.Attachment x) => x.AttachPointA == attachPoint || x.AttachPointB == attachPoint).FirstOrDefault();
				if (attachment != null)
				{
					AttachPoint otherAttachPoint = attachment.GetOtherAttachPoint(attachPoint);
					text = text + " - " + GetDisplayName(otherAttachPoint);
				}
				elementByInternalId4.text = text;
				PartConnectionElementScript partConnectionElementScript = xmlElement2.gameObject.AddComponent<PartConnectionElementScript>();
				partConnectionElementScript.Part = part;
				partConnectionElementScript.OtherPart = otherPart;
				partConnectionElementScript.PartConnection = partConnection;
				partConnectionElementScript.AttachPoint = attachPoint;
				if (!partConnection.AllowManualDelete)
				{
					xmlElement2.GetElementByInternalId("delete-part-connection").SetActive(active: false);
				}
				if (!Device.IsMobileBuild)
				{
					xmlElement2.AddOnMouseEnterEvent(delegate
					{
						OnCursorEnterPartConnection(partConnectionElementScript);
					});
					xmlElement2.AddOnMouseExitEvent(delegate
					{
						OnCursorExitPartConnection(partConnectionElementScript);
					});
				}
				xmlElement2.AddOnClickEvent(delegate
				{
					OnClickPartConnection(partConnectionElementScript);
				});
			}
			xmlElement.GetElementByInternalId("add-connection").gameObject.SetActive(attachPoint.IsAvailableForManualConnection && attachPoint.CanSeek);
			_attachPointElements.Add(xmlElement);
		}

		private void CreateTargetAttachPointUI(AttachPoint targetAttachPoint)
		{
			XmlElement targetAttachPointParent = _targetAttachPointParent;
			XmlElement attachPointElement = UiUtilities.CloneTemplate(_templateTargetAttachPoint, targetAttachPointParent);
			TextMeshProUGUI elementByInternalId = attachPointElement.GetElementByInternalId<TextMeshProUGUI>("ap-name");
			elementByInternalId.text = GetDisplayName(targetAttachPoint);
			attachPointElement.AddOnClickEvent(delegate
			{
				OnTargetAttachPointClicked(targetAttachPoint, attachPointElement);
			});
			bool flag = false;
			if (targetAttachPoint.ConnectionType != SourceAttachPoint.ConnectionType)
			{
				flag = true;
				elementByInternalId.text += " (Incompatible)";
			}
			else if (!targetAttachPoint.IsAvailableForManualConnection)
			{
				flag = true;
				elementByInternalId.text += " (Unavailable)";
			}
			if (flag)
			{
				attachPointElement.AddClass("disabled");
			}
			_targetAttachPoints.Add(attachPointElement);
		}

		private void EndManualPartConnection(bool refreshPanel)
		{
			if (_tool.Active && refreshPanel)
			{
				base.DesignerUi.Designer.SelectTool(base.DesignerUi.Designer.MovePartTool);
			}
			IPartScript partScript = SourceAttachPoint?.AttachPointScript?.PartScript;
			SourceAttachPoint = null;
			_panelConnecting.SetActive(active: false);
			_panelAttachPoints.SetActive(active: true);
			_panelButtons.SetActive(active: true);
			if (refreshPanel && partScript != null)
			{
				base.DesignerUi.Designer.SelectPart(partScript, null, justAdded: false);
			}
		}

		private void OnAddConnectionButtonClicked(PartData part, AttachPoint attachPoint)
		{
			base.DesignerUi.Designer.SelectTool(_tool);
			_panelConnecting.SetActive(active: true);
			_panelButtons.SetActive(active: false);
			_panelAttachPoints.SetActive(active: false);
			_connectButton.SetActive(active: false);
			SourceAttachPoint = attachPoint;
			RefreshPanel();
		}

		private void OnAttachPointToggled(AttachPoint attachPoint, bool enabled)
		{
			attachPoint.Enabled = enabled;
			if (!enabled)
			{
				attachPoint.IsCustomized = true;
			}
		}

		private void OnCancelConnectButtonClicked()
		{
			EndManualPartConnection(refreshPanel: true);
		}

		private void OnClickPartConnection(PartConnectionElementScript partConnectionElementScript)
		{
			base.DesignerUi.Designer.SelectPart(partConnectionElementScript.OtherPart.PartScript, null, justAdded: false);
		}

		private void OnConnectButtonClicked()
		{
			if (TargetAttachPoint.HasValue && SourceAttachPoint != null)
			{
				AttachPointScript attachPointScript = SourceAttachPoint.AttachPointScript;
				AttachPointScript attachPointScript2 = TargetAttachPoint.Value.AttachPoint.AttachPointScript;
				ConnectParts(attachPointScript, attachPointScript2);
				EndManualPartConnection(refreshPanel: false);
				base.DesignerUi.Designer.CraftScript.SetStructureChanged();
				base.DesignerUi.ShowMessage($"Connected {attachPointScript.PartScript.Data.Name} #{attachPointScript.PartScript.Data.Id} - {GetDisplayName(attachPointScript.AttachPoint)} to {attachPointScript2.PartScript.Data.Name} #{attachPointScript2.PartScript.Data.Id} - {GetDisplayName(attachPointScript2.AttachPoint)}");
			}
		}

		private void OnCraftStructureChanged()
		{
			if (base.IsOpen)
			{
				EndManualPartConnection(refreshPanel: false);
				RefreshPanel();
			}
		}

		private void OnCursorEnterPartConnection(PartConnectionElementScript partConnectionElementScript)
		{
			HighlightedPart = partConnectionElementScript.OtherPart.PartScript;
		}

		private void OnCursorExitPartConnection(PartConnectionElementScript partConnectionElementScript)
		{
			if (HighlightedPart == partConnectionElementScript.OtherPart.PartScript)
			{
				HighlightedPart = null;
			}
		}

		private void OnDeletePartConnectionClicked(XmlElement element)
		{
			HighlightedPart = null;
			HighlightedAttachPoint = null;
			PartConnectionElementScript componentInParent = element.GetComponentInParent<PartConnectionElementScript>();
			bool flag = false;
			PartConnection.Attachment[] array = componentInParent.PartConnection.Attachments.ToArray();
			PartConnection.Attachment[] array2 = array;
			foreach (PartConnection.Attachment attachment in array2)
			{
				if (attachment.AttachPointA != componentInParent.AttachPoint && attachment.AttachPointB != componentInParent.AttachPoint)
				{
					continue;
				}
				PartData partData = attachment.GetOtherAttachPoint(componentInParent.AttachPoint)?.AttachPointScript?.PartScript?.Data;
				if (attachment.AttachPointA.AttachPointScript.PartScript.SymmetrySlice != null || attachment.AttachPointB.AttachPointScript.PartScript.SymmetrySlice != null)
				{
					if (array.Length > 1)
					{
						base.DesignerUi.Designer.ShowMessage("This connection cannot be deleted because of part symmetry.");
						return;
					}
					flag = true;
				}
				componentInParent.PartConnection.DestroyAttachment(attachment);
				if (partData != null)
				{
					base.DesignerUi.ShowMessage($"Removed connection to {partData.Name} #{partData.Id}");
				}
			}
			if (componentInParent.PartConnection.Attachments.Count == 0)
			{
				PartData otherPart = componentInParent.PartConnection.GetOtherPart(componentInParent.Part);
				componentInParent.PartConnection.DestroyConnection();
				if (flag)
				{
					Symmetry.RemovePartConnection(componentInParent.Part.PartScript, componentInParent.PartConnection);
					PartGraph partGraph = new PartGraph(componentInParent.Part, breakOnRigidBodyBoundary: false);
					if (partGraph.HasRoot)
					{
						partGraph = new PartGraph(otherPart, breakOnRigidBodyBoundary: false);
					}
					if (!partGraph.HasRoot)
					{
						Symmetry.DeleteSymmetricParts(partGraph.Parts.Select((PartData x) => x.PartScript).ToList());
					}
				}
			}
			base.DesignerUi.Designer.CraftScript.SetStructureChanged();
			base.DesignerUi.Designer.CreateUndoStep();
		}

		private void OnDisconnectButtonClicked()
		{
			PartData partData = base.DesignerUi.Designer.SelectedPart?.Data;
			if (partData != null && partData.PartConnectionsEnabled)
			{
				PartSelection.PartLimb partLimb = null;
				if (partData.PartScript.SymmetrySlice != null)
				{
					partLimb = PartSelection.FindPartLimb(partData.PartScript);
				}
				PartConnection[] array = partData.PartConnections.ToArray();
				foreach (PartConnection partConnection in array)
				{
					partConnection.DestroyConnection();
					Symmetry.RemovePartConnection(partData.PartScript, partConnection);
				}
				if (partLimb != null)
				{
					Symmetry.DeleteSymmetricParts(partLimb.Parts);
				}
				partData.PartScript.CraftScript.SetStructureChanged();
				base.DesignerUi.Designer.CreateUndoStep();
				base.DesignerUi.ShowMessage("Removed all of this part's connections.");
			}
		}

		private void OnReconnectButtonClicked()
		{
			base.DesignerUi.Designer.ReconnectSelectedPart();
		}

		private void OnSelectedPartChanged(IPartScript oldPart, IPartScript newPart)
		{
			if (base.IsOpen)
			{
				RefreshPanel();
			}
		}

		private void OnTargetAttachPointClicked(AttachPoint targetAttachPoint, XmlElement attachPointElement)
		{
			if (!attachPointElement.HasClass("disabled"))
			{
				TargetAttachPoint = (targetAttachPoint, attachPointElement);
				_connectButton.SetActive(active: true);
			}
		}

		private void OnToggleAllAttachPoints()
		{
			PartData partData = base.DesignerUi.Designer.SelectedPart?.Data;
			if (!(partData != null) || partData.AttachPoints.Count <= 0 || !partData.PartConnectionsEnabled)
			{
				return;
			}
			bool flag = !partData.AttachPoints[0].Enabled;
			foreach (AttachPoint attachPoint in partData.AttachPoints)
			{
				attachPoint.Enabled = flag;
			}
			base.DesignerUi.ShowMessage(string.Format("{0} all of this part's attach points.", flag ? "Enabled" : "Disabled"));
			RefreshPanel();
		}

		private void OnToggleAllConnectedAttachPoints()
		{
			PartData partData = base.DesignerUi.Designer.SelectedPart?.Data;
			if (!(partData != null) || partData.AttachPoints.Count <= 0 || !partData.PartConnectionsEnabled)
			{
				return;
			}
			bool flag = !partData.AttachPoints[0].Enabled;
			foreach (PartData part in new PartGraph(partData, breakOnRigidBodyBoundary: false).Parts)
			{
				if (!part.PartConnectionsEnabled)
				{
					continue;
				}
				foreach (AttachPoint attachPoint in part.AttachPoints)
				{
					attachPoint.Enabled = flag;
				}
			}
			base.DesignerUi.ShowMessage(string.Format("{0} all connected parts' attach points.", flag ? "Enabled" : "Disabled"));
			RefreshPanel();
		}

		private void RefreshPanel()
		{
			foreach (XmlElement attachPointElement in _attachPointElements)
			{
				Object.Destroy(attachPointElement.gameObject);
			}
			_attachPointElements.Clear();
			TargetAttachPoint = null;
			foreach (XmlElement targetAttachPoint in _targetAttachPoints)
			{
				Object.Destroy(targetAttachPoint.gameObject);
			}
			_targetAttachPoints.Clear();
			TextMeshProUGUI elementById = base.xmlLayout.GetElementById<TextMeshProUGUI>("part-name");
			IPartScript selectedPart = base.DesignerUi.Designer.SelectedPart;
			if (selectedPart != null && !selectedPart.Data.PartConnectionsEnabled)
			{
				return;
			}
			if (_panelConnecting.Visible)
			{
				elementById.text = "ADD NEW CONNECTION";
				TextMeshProUGUI elementById2 = base.xmlLayout.GetElementById<TextMeshProUGUI>("add-new-connection-header");
				_connectButton.SetActive(active: false);
				if (selectedPart != null)
				{
					elementById2.text = $"{selectedPart.Data.Name} #{selectedPart.Data.Id}";
					IPartScript partScript = SourceAttachPoint.AttachPointScript.PartScript;
					string text = null;
					if (selectedPart == partScript)
					{
						text = "Select a different part. You cannot connect a part to itself.";
					}
					else if (!selectedPart.Data.PartConnectionsEnabled)
					{
						text = "Select a different part. This part doesn't support changes to its connections.";
					}
					else if ((selectedPart.SymmetrySlice != null || partScript.SymmetrySlice != null) && selectedPart.SymmetrySlice != partScript.SymmetrySlice)
					{
						if (selectedPart.SymmetrySlice != null && partScript.SymmetrySlice != null && selectedPart.SymmetrySlice != partScript.SymmetrySlice)
						{
							text = "Select a different part. You cannot connect a part to a symmetric part.";
						}
						else
						{
							PartGraph partGraph = null;
							PartData item = null;
							if (selectedPart.SymmetrySlice == null)
							{
								partGraph = new PartGraph(selectedPart.Data, breakOnRigidBodyBoundary: false);
								item = partScript.SymmetrySlice.SliceRootPart;
							}
							else if (partScript.SymmetrySlice == null)
							{
								partGraph = new PartGraph(partScript.Data, breakOnRigidBodyBoundary: false);
								item = selectedPart.SymmetrySlice.SliceRootPart;
							}
							if (partGraph != null && partGraph.Parts.Contains(item))
							{
								text = "Select a different part. You cannot connect a symmetric part to this part.";
							}
						}
					}
					if (text == null)
					{
						_connectingText.text = "Now select the attach point to connect to.";
						{
							foreach (AttachPoint attachPoint in selectedPart.Data.AttachPoints)
							{
								if (attachPoint.CanReceive)
								{
									CreateTargetAttachPointUI(attachPoint);
								}
							}
							return;
						}
					}
					_connectingText.text = text;
				}
				else
				{
					TextMeshProUGUI connectingText = _connectingText;
					string text2 = (_connectingText.text = "Select the other part you want to connect to.");
					connectingText.text = text2;
					elementById2.text = "No Part Selected";
				}
				return;
			}
			TextMeshProUGUI elementById3 = base.xmlLayout.GetElementById<TextMeshProUGUI>("attachpoint-group-header");
			if (selectedPart != null)
			{
				_panelButtons.SetActive(active: true);
				elementById.text = $"{selectedPart.Data.Name} #{selectedPart.Data.Id}";
				elementById3.text = string.Format("{0} x ATTACH POINT{1}", selectedPart.Data.AttachPoints.Count, (selectedPart.Data.AttachPoints.Count == 1) ? string.Empty : "S");
				{
					foreach (AttachPoint attachPoint2 in selectedPart.Data.AttachPoints)
					{
						CreateAttachPointUI(attachPoint2, selectedPart.Data);
					}
					return;
				}
			}
			elementById.text = "No Part Selected";
			elementById3.text = "Select a part to view its part connections";
			_panelButtons.SetActive(active: false);
		}
	}
}
