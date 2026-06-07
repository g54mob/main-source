using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Menu.ListView;
using Assets.Scripts.PlanetStudio.PlanetObjects;
using Assets.Scripts.PlanetStudio.Tools;
using Assets.Scripts.Ui;
using ModApi.Audio;
using ModApi.Common.Events;
using ModApi.Flight.Sim;
using ModApi.Planet;
using ModApi.State;
using ModApi.Ui;
using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public class PlanetObjectsFlyoutScript : PlanetStudioFlyoutScript, IDragDropContainer
	{
		public class PlanetObjectElement : TreeNode<PlanetObjectElement>
		{
			private PlanetObjectsFlyoutScript _flyout;

			public override bool Collapsed
			{
				get
				{
					return PlanetObject?.Collapsed ?? base.Collapsed;
				}
				set
				{
					base.Collapsed = value;
					if (PlanetObject != null)
					{
						PlanetObject.Collapsed = value;
					}
				}
			}

			public TextMeshProUGUI NameText { get; set; }

			public IPlanetObject PlanetObject { get; }

			public bool RefreshUIWhenExpanded { get; set; }

			public override bool ShowCollapseArrow
			{
				get
				{
					if (base.Children.Count <= 0)
					{
						return RefreshUIWhenExpanded;
					}
					return true;
				}
			}

			public PlanetObjectElement(IPlanetObject planetObject, PlanetObjectsFlyoutScript flyout)
			{
				base.Item = this;
				PlanetObject = planetObject;
				_flyout = flyout;
				if (planetObject != null)
				{
					base.Collapsed = planetObject.Collapsed;
				}
			}

			public override bool MoveToContainer(TreeNode<PlanetObjectElement> container, TreeNode<PlanetObjectElement> insertBefore)
			{
				if (container != null && container.Item?.PlanetObject?.OnReceiveDropInTreeView(PlanetObject, insertBefore?.Item?.PlanetObject) == true)
				{
					base.MoveToContainer(container, insertBefore);
					return true;
				}
				return false;
			}

			protected override void OnArrowClicked(TreeNode<PlanetObjectElement> node)
			{
				if (RefreshUIWhenExpanded && node.Collapsed)
				{
					node.Collapsed = false;
					_flyout.RefreshUI();
				}
				else
				{
					base.OnArrowClicked(node);
				}
			}
		}

		private float _autoScrollAmount;

		private XmlElement _cloneButton;

		private Vector2? _currentOffset;

		private CelestialBodyDesignerScript _designer;

		private PlanetObjectElement _dragSource;

		private TreeNode<PlanetObjectElement>.DropTarget _dropTarget;

		private XmlElement _insertIndicator;

		private MoveObjectTool _moveTool;

		private bool _planetRotated;

		private ScrollRect _scrollRect;

		private PlanetObjectElement _selectedObject;

		private GameObject _target;

		public CelestialBodyViewerScript CelestialBodyViewer => _designer.CelestialBodyViewer;

		public CelestialBodyDesignerScript Designer => _designer;

		public Transform DragParent { get; private set; }

		public IInspectorPanel InspectorPanel { get; private set; }

		public PlanetObjectElement Root { get; set; }

		public PlanetObjectElement SelectedObject
		{
			get
			{
				return _selectedObject;
			}
			private set
			{
				if (_selectedObject != value)
				{
					if (_selectedObject?.RowElement != null)
					{
						_selectedObject.RowElement.RemoveClass("selected");
					}
					_selectedObject = value;
					_moveTool.Stop();
					if (_selectedObject != null)
					{
						_selectedObject.RowElement.AddClass("selected");
						_moveTool.Start(_target.transform, _selectedObject.PlanetObject);
					}
					UpdateDetails(_selectedObject);
				}
			}
		}

		public PlanetDataScript ViewerPlanetData => base.PlanetStudioUI.PlanetStudioScript?.CelestialBodyDesignerScript.CelestialBodyViewer.CelestialBodyData;

		public void AddWindow(RaycastHit? raycasthit, int windowType)
		{
			StructureObject structureObject = (SelectedObject?.PlanetObject as StructureObject) ?? (SelectedObject?.PlanetObject as SubStructureObject)?.RootStructureObject;
			SubStructure subStructure = (SelectedObject?.PlanetObject as SubStructureObject)?.SubStructure;
			if (subStructure == null && structureObject == null)
			{
				return;
			}
			SubStructure subStructure2 = windowType switch
			{
				4 => new SubStructure("Door", "Flight/GameView/Structures/Door2", structureObject.Data), 
				3 => new SubStructure("Door", "Flight/GameView/Structures/Door1", structureObject.Data), 
				2 => new SubStructure("Window", "Flight/GameView/Structures/WindowLarge", structureObject.Data), 
				1 => new SubStructure("Window", "Flight/GameView/Structures/WindowSmall", structureObject.Data), 
				_ => new SubStructure("Window", "Flight/GameView/Structures/WindowMedium", structureObject.Data), 
			};
			if (subStructure != null)
			{
				subStructure2.SetParent(subStructure, null);
				Transform transform = raycasthit.Value.collider.transform;
				subStructure2.LocalRotation = new Vector3(0f, 90f * Mathf.Round(Quaternion.LookRotation(transform.InverseTransformDirection(raycasthit.Value.normal), transform.up).eulerAngles.y / 90f), 0f);
				Vector3 vector = transform.InverseTransformPoint(raycasthit.Value.point);
				subStructure2.LocalPosition = new Vector3((float)Math.Round(vector.x, 2), (float)Math.Round(vector.y, 2), (float)Math.Round(vector.z, 2));
				if (Mathf.Abs(subStructure2.LocalPosition.x) > Mathf.Abs(subStructure2.LocalPosition.z))
				{
					subStructure2.LocalScale = new Vector3(1f / subStructure.LocalScale.z, 1f / subStructure.LocalScale.y, 1f / subStructure.LocalScale.x);
				}
				else
				{
					subStructure2.LocalScale = new Vector3(1f / subStructure.LocalScale.x, 1f / subStructure.LocalScale.y, 1f / subStructure.LocalScale.z);
				}
			}
			else
			{
				subStructure2.SetParent(structureObject.Data, null);
			}
			structureObject.RecreateGameObjects();
			CreateUndoStep(null, "Added a window");
			RefreshUI();
			SelectSubStructureDelayed(subStructure2);
		}

		public void Dragging(PointerEventData eventData)
		{
			_autoScrollAmount = 0f;
			XmlElement xmlElement = eventData.pointerCurrentRaycast.gameObject?.GetComponentInParent<XmlElement>();
			TreeNode<PlanetObjectElement>.DropTarget dropTarget = new TreeNode<PlanetObjectElement>.DropTarget();
			if (xmlElement != null)
			{
				XmlElement rowElement = xmlElement.GetParentElementWithClass("list-item");
				if (rowElement != null)
				{
					PlanetObjectElement planetObjectElement = Root.FindNode((TreeNode<PlanetObjectElement> n) => n.Item.RowElement == rowElement)?.Item;
					if (planetObjectElement != null && planetObjectElement.AllowDrop && !_dragSource.IsAncestor(planetObjectElement))
					{
						RectTransformUtility.ScreenPointToLocalPointInRectangle(rowElement.rectTransform, eventData.position, null, out var localPoint);
						if (localPoint.y >= 0f)
						{
							dropTarget.Container = planetObjectElement.Parent;
							dropTarget.InsertBefore = planetObjectElement;
						}
						else if (localPoint.y < 0f)
						{
							if (!planetObjectElement.Collapsed && planetObjectElement.Children.Count > 0)
							{
								dropTarget.Container = planetObjectElement;
								dropTarget.InsertBefore = planetObjectElement.Children.First();
							}
							else
							{
								dropTarget.Container = planetObjectElement.Parent;
								dropTarget.InsertBefore = planetObjectElement.GetNextOrNull();
							}
						}
						float num = rowElement.rectTransform.rect.height * 0.25f;
						if (Mathf.Abs(localPoint.y) < num)
						{
							dropTarget.Container = planetObjectElement;
							dropTarget.InsertBefore = null;
						}
					}
				}
			}
			if (_dropTarget?.InsertBefore != dropTarget.InsertBefore)
			{
				int num2 = -1;
				if (dropTarget.InsertBefore != null)
				{
					num2 = dropTarget.InsertBefore.RowElement.transform.GetSiblingIndex();
				}
				if (num2 >= 0)
				{
					_insertIndicator.SetActive(active: true);
					if (_insertIndicator.transform.GetSiblingIndex() < num2)
					{
						num2--;
					}
					_insertIndicator.transform.SetSiblingIndex(num2);
				}
				else
				{
					_insertIndicator.SetActive(active: false);
				}
			}
			_dropTarget = dropTarget;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_scrollRect.viewport, eventData.position, null, out var localPoint2))
			{
				float num3 = Mathf.Clamp(0f - localPoint2.y, 0f, _scrollRect.viewport.rect.height);
				if (num3 < 50f)
				{
					_autoScrollAmount = Mathf.Clamp01((50f - num3) / 50f * 2f);
				}
				else if (num3 > _scrollRect.viewport.rect.height - 50f)
				{
					float num4 = _scrollRect.viewport.rect.height - num3;
					_autoScrollAmount = 0f - Mathf.Clamp01((50f - num4) / 50f * 2f);
				}
			}
		}

		public void EndDrag(IDragDropElement e)
		{
			PlanetObjectElement planetObjectElement = e as PlanetObjectElement;
			if (_dropTarget?.Container != null)
			{
				if (_dragSource.MoveToContainer(_dropTarget.Container, _dropTarget.InsertBefore))
				{
					CreateUndoStep(null, "Moved " + planetObjectElement.PlanetObject?.Name);
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Design.StagingDropPart);
				}
				else
				{
					Game.Instance.UserInterface.CreateMessageDialog("Cannot move the object there.");
				}
				Root.UpdateRowElements();
			}
			_dropTarget = null;
			_insertIndicator.SetActive(active: false);
			_dragSource = null;
			_autoScrollAmount = 0f;
		}

		public bool OnColliderSelected(Collider collider)
		{
			if (base.Flyout.IsOpen && collider != null)
			{
				StructureGameObjectScript script = collider.GetComponentInParent<StructureGameObjectScript>();
				if (script != null)
				{
					SubStructure subStructure = script.SubStructure;
					if (subStructure != null && subStructure.StructureNodeData?.Collapsed == true)
					{
						script.SubStructure.StructureNodeData.Collapsed = false;
						RefreshUI();
					}
					Func<TreeNode<PlanetObjectElement>> func = () => Root.FindNode(delegate(TreeNode<PlanetObjectElement> x)
					{
						if ((x.Item.PlanetObject as StructureObject)?.Data == script.StructureNode?.Data && script.StructureNode != null)
						{
							return true;
						}
						return ((x.Item.PlanetObject as SubStructureObject)?.SubStructure == script.SubStructure && script.SubStructure != null) ? true : false;
					});
					TreeNode<PlanetObjectElement> treeNode = func();
					if (treeNode != null)
					{
						if (treeNode.IsAnyParentCollapsed || treeNode.RowElement == null)
						{
							treeNode.ExecuteParentTree(delegate(PlanetObjectElement x)
							{
								x.Collapsed = false;
							});
							RefreshUI();
							treeNode = func();
						}
						SelectObject(treeNode?.Item);
					}
					return treeNode != null;
				}
			}
			return false;
		}

		public void OnObjectMovedExternally(IPlanetObject planetObject)
		{
			planetObject.UpdateGameViewObject(_designer.CelestialBodyViewer);
			_moveTool.ResetGizmoPosition();
			UpdateCelestialBodyData();
		}

		public void RefreshStructureGameObjects(StructureNodeData structureNodeData)
		{
			TreeNode<PlanetObjectElement> treeNode = Root.FindNode((TreeNode<PlanetObjectElement> x) => (x.Item.PlanetObject as StructureObject)?.Data == structureNodeData);
			if (treeNode != null)
			{
				(treeNode.Item.PlanetObject as StructureObject)?.RecreateGameObjects();
			}
		}

		public void SelectObject(PlanetObjectElement planetObject, bool delayed = false)
		{
			Action action = delegate
			{
				SelectedObject = planetObject;
				if (planetObject != null)
				{
					if (!planetObject.IsVisible)
					{
						for (TreeNode<PlanetObjectElement> parent = planetObject.Parent; parent != null; parent = parent.Parent)
						{
							parent.Collapsed = false;
						}
						Root.UpdateRowElements();
					}
					UiUtilities.ScrollToTarget(planetObject.RowElement.rectTransform, _scrollRect, -20f);
				}
			};
			if (delayed)
			{
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(action);
			}
			else
			{
				action();
			}
		}

		public void StartDrag(IDragDropElement element)
		{
			_dragSource = element as PlanetObjectElement;
			Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Design.StagingDragStage);
		}

		protected override void OnCelestialBodyLoaded()
		{
			if (base.Flyout.IsOpen)
			{
				base.Flyout.Close();
			}
		}

		protected override void OnCelestialBodyViewRefreshed()
		{
			base.OnCelestialBodyViewRefreshed();
			UpdateCelestialBodyData();
			if (base.Flyout.IsOpen)
			{
				RefreshUI();
			}
		}

		protected override void OnFlyoutClosed()
		{
			base.OnFlyoutClosed();
			InspectorPanel?.Close();
			_moveTool.Stop();
			UpdateCelestialBodyData();
		}

		protected override void OnInitialized(PlanetStudioUIScript planetStudioUI)
		{
			base.OnInitialized(planetStudioUI);
			_designer = base.PlanetStudioUI.PlanetStudioScript.CelestialBodyDesignerScript;
			_designer.CelestialBodyViewer.ReferenceFrameRecentered += ReferenceFrameRecentered;
			_target = new GameObject("Target");
			_moveTool = new MoveObjectTool(_target, _designer.CelestialBodyViewer);
			_moveTool.OnEndDrag += OnMoveToolEndDrag;
			_scrollRect = base.xmlLayout.GetElementById<ScrollRect>("scroll-view");
			DragParent = base.xmlLayout.GetElementById("drag-parent").transform;
			_insertIndicator = base.xmlLayout.GetElementById("insert-indicator");
			_cloneButton = base.xmlLayout.GetElementById("clone-button");
			UpdateDetails(null);
			CelestialBodyViewer.MovementScript.PlanetRotated += OnPlanetRotated;
		}

		protected override void RefreshUI()
		{
			base.RefreshUI();
			SelectObject(null);
			if (Root != null)
			{
				Root.ExecuteTree(delegate(PlanetObjectElement n)
				{
					UnityEngine.Object.Destroy(n.RowElement?.gameObject);
				});
			}
			Root = new PlanetObjectElement(null, this);
			foreach (StructureNodeData structureNode in ViewerPlanetData.StructureNodes)
			{
				StructureObject structureObject = new StructureObject(structureNode, this);
				PlanetObjectElement planetObjectElement = new PlanetObjectElement(structureObject, this);
				planetObjectElement.SetParent(Root);
				if (!structureNode.Collapsed)
				{
					CreateSubStructureRows(planetObjectElement, structureNode.SubStructures, structureObject);
				}
				else
				{
					planetObjectElement.RefreshUIWhenExpanded = true;
				}
			}
			foreach (LaunchLocation defaultLaunchLocation in ViewerPlanetData.DefaultLaunchLocations)
			{
				new PlanetObjectElement(new LaunchLocationObject(defaultLaunchLocation, this), this).SetParent(Root);
			}
			foreach (TreeNode<PlanetObjectElement> child in Root.Children)
			{
				CreateRowElementHierarchy(child);
			}
			Root.UpdateRowElements();
		}

		protected override void Update()
		{
			base.Update();
			if (_planetRotated)
			{
				_planetRotated = false;
				if (base.Flyout.IsOpen && SelectedObject != null)
				{
					_moveTool.ResetGizmoPosition();
				}
			}
		}

		private void CreateRowElement(PlanetObjectElement planetObject)
		{
			XmlElement elementById = base.xmlLayout.GetElementById("row-template");
			XmlElement xmlElement = UiUtilities.CloneTemplate(elementById, elementById.parentElement, applyAttributes: false);
			XmlElement elementByInternalId = xmlElement.GetElementByInternalId("name");
			planetObject.NameText = elementByInternalId.GetComponent<TextMeshProUGUI>();
			planetObject.NameText.text = planetObject.PlanetObject.Name;
			if (planetObject.PlanetObject.Icon != null)
			{
				xmlElement.GetElementByInternalId("icon").AddClass(planetObject.PlanetObject.Icon);
			}
			planetObject.UpdateIndent();
			if (planetObject.PlanetObject.CanDragInTreeView)
			{
				xmlElement.gameObject.AddComponent<ElementDragHandlerScript>().Initialize(planetObject, this);
			}
			planetObject.RowElement = xmlElement;
			planetObject.Collapsed = planetObject.PlanetObject.Collapsed;
		}

		private void CreateRowElementHierarchy(TreeNode<PlanetObjectElement> node)
		{
			CreateRowElement(node.Item);
			if (node.Children.Count <= 0)
			{
				return;
			}
			if (!node.Item.Collapsed)
			{
				foreach (TreeNode<PlanetObjectElement> child in node.Children)
				{
					CreateRowElementHierarchy(child);
				}
				return;
			}
			node.Item.RefreshUIWhenExpanded = true;
		}

		private void CreateSubStructureRows(PlanetObjectElement parent, IEnumerable<SubStructure> subStructures, StructureObject rootStructureObject)
		{
			foreach (SubStructure subStructure in subStructures)
			{
				PlanetObjectElement planetObjectElement = new PlanetObjectElement(new SubStructureObject(subStructure, this, rootStructureObject), this);
				planetObjectElement.SetParent(parent);
				CreateSubStructureRows(planetObjectElement, subStructure.SubStructures, rootStructureObject);
			}
		}

		private void CreateUndoStep(string ignoreKey, string description)
		{
			UpdateCelestialBodyData();
			base.PlanetStudioUI.CreateUndoStep(ignoreKey, description);
		}

		private void OnAddLaunchLocationClicked()
		{
			Vector3d surfacePosition = _designer.CelestialBodyViewer.CameraSurfacePosition;
			if (_designer.CelestialBodyViewer.MovementScript.HasFocusTarget)
			{
				surfacePosition = _designer.CelestialBodyViewer.PlanetScript.PlanetNode.PlanetVectorToSurfaceVector(_designer.CelestialBodyViewer.MovementScript.FocusTargetPci);
			}
			_designer.CelestialBodyViewer.PlanetScript.PlanetNode.GetSurfaceCoordinates(surfacePosition, out var latitude, out var longitude);
			ModApi.Ui.InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
			inputDialogScript.MessageText = "Enter a name for the launch location.\n\nNote that launch locations added to a planet might not automatically added to its planetary system.";
			inputDialogScript.OkayClicked += delegate(ModApi.Ui.InputDialogScript d)
			{
				d.Close();
				LaunchLocation launchLocation = new LaunchLocation(d.InputText, LaunchLocationType.SurfaceLockedGround, ViewerPlanetData.Name, latitude * 57.29578, longitude * 57.29578, Vector3.zero, 0.0, 0.0);
				ViewerPlanetData.DefaultLaunchLocations.Add(launchLocation);
				PlanetObjectElement planetObjectElement = new PlanetObjectElement(new LaunchLocationObject(launchLocation, this), this);
				CreateRowElement(planetObjectElement);
				planetObjectElement.SetParent(Root);
				SelectObject(planetObjectElement, delayed: true);
				CreateUndoStep(null, "Add Launch Location '" + d.InputText + "'");
			};
		}

		private void OnAddStructureClicked()
		{
			Vector3d surfacePosition = _designer.CelestialBodyViewer.CameraSurfacePosition;
			if (_designer.CelestialBodyViewer.MovementScript.HasFocusTarget)
			{
				surfacePosition = _designer.CelestialBodyViewer.PlanetScript.PlanetNode.PlanetVectorToSurfaceVector(_designer.CelestialBodyViewer.MovementScript.FocusTargetPci);
			}
			_designer.CelestialBodyViewer.PlanetScript.PlanetNode.GetSurfaceCoordinates(surfacePosition, out var latitude, out var longitude);
			ModApi.Ui.InputDialogScript inputDialog = Game.Instance.UserInterface.CreateInputDialog();
			inputDialog.MessageText = "After creating a structure, you can then add sub-structures under it to provide runways, hangars, launch pads, etc.";
			inputDialog.InputPlaceholderText = "Structure Name";
			inputDialog.OkayClicked += delegate(ModApi.Ui.InputDialogScript d)
			{
				if (!string.IsNullOrWhiteSpace(d.InputText))
				{
					d.Close();
					string inputText = inputDialog.InputText;
					StructureNodeData structureNodeData = new StructureNodeData(inputDialog.InputText, "Flight/GameView/Structures/Empty")
					{
						Latitude = latitude * 57.29578,
						Longitude = longitude * 57.29578
					};
					ViewerPlanetData.StructureNodes.Add(structureNodeData);
					IPlanetNode planetNode = CelestialBodyViewer.PlanetScript.PlanetNode;
					StructureNode node = new StructureNode(structureNodeData, planetNode);
					planetNode.AddChildNode(node);
					PlanetObjectElement planetObjectElement = new PlanetObjectElement(new StructureObject(structureNodeData, this), this);
					CreateRowElement(planetObjectElement);
					planetObjectElement.SetParent(Root);
					SelectObject(planetObjectElement, delayed: true);
					planetObjectElement.PlanetObject.UpdateGameViewObject(_designer.CelestialBodyViewer);
					CreateUndoStep(null, "Add Structure '" + inputText + "'");
				}
			};
		}

		private void OnAddSubStructureClicked()
		{
			StructureObject rootStructureObject = (SelectedObject?.PlanetObject as StructureObject) ?? (SelectedObject?.PlanetObject as SubStructureObject)?.RootStructureObject;
			if (rootStructureObject == null)
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "You must select a structure or a sub-structure first.";
			}
			SubStructure parentSubstructure = (SelectedObject?.PlanetObject as SubStructureObject)?.SubStructure;
			if (parentSubstructure == null && rootStructureObject == null)
			{
				return;
			}
			AddStructureViewModel addStructureViewModel = new AddStructureViewModel();
			addStructureViewModel.StructureSelected = delegate(AddStructureViewModel.StructureItem x)
			{
				SubStructure subStructure = new SubStructure(x.Name, x.PrefabPath, rootStructureObject.Data)
				{
					Tiling = x.Tiling,
					Color = x.Color
				};
				if (parentSubstructure != null)
				{
					subStructure.SetParent(parentSubstructure, null);
				}
				else
				{
					subStructure.SetParent(rootStructureObject.Data, null);
				}
				rootStructureObject.RecreateGameObjects();
				CreateUndoStep(null, "Add Sub Structure '" + x.Name + "'");
				RefreshUI();
				SelectSubStructureDelayed(subStructure);
			};
			base.PlanetStudioUI.CreateListView(addStructureViewModel);
		}

		private void OnCloneClicked()
		{
			if (SelectedObject?.PlanetObject is SubStructureObject subStructureObject)
			{
				XElement xElement = new XElement("Clone");
				XElement content = subStructureObject.SubStructure.GenerateXml("SubStructure");
				xElement.Add(content);
				List<SubStructure> list = new List<SubStructure>();
				SubStructure.DeserializeSubStructures(xElement, subStructureObject.SubStructure.Parent, list);
				RefreshStructureGameObjects(subStructureObject.SubStructure.StructureNodeData);
				CreateUndoStep(null, "Cloned Sub Structure '" + subStructureObject.Name + "'");
				RefreshUI();
				base.PlanetStudioUI.ShowMessage("Cloned " + subStructureObject.Name);
				SelectSubStructureDelayed(list.First());
			}
			else
			{
				Game.Instance.UserInterface.CreateMessageDialog("The selected object cannot be cloned");
			}
		}

		private void OnDeleteObject()
		{
			PlanetObjectElement planetObject = SelectedObject;
			ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = "Please confirm that you want to delete the " + planetObject.PlanetObject.Icon + ": '" + planetObject.PlanetObject.Name + "'.";
			messageDialogScript.UseDangerButtonStyle = true;
			messageDialogScript.OkayButtonText = "DELETE";
			messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
			{
				d.Close();
				planetObject.PlanetObject.Delete(ViewerPlanetData, CelestialBodyViewer);
				CreateUndoStep(null, "Deleted " + planetObject?.PlanetObject?.TypeName + " '" + planetObject?.PlanetObject?.Name + "'");
				RefreshUI();
				base.PlanetStudioUI.ShowMessage("Deleted " + planetObject?.PlanetObject?.Name);
				SelectObject(null);
			};
		}

		private void OnListItemClicked(XmlElement rowElement)
		{
			PlanetObjectElement planetObjectElement = Root.FindNode((TreeNode<PlanetObjectElement> x) => x.RowElement == rowElement)?.Item;
			if (SelectedObject == planetObjectElement)
			{
				SelectedObject = null;
			}
			else
			{
				SelectedObject = planetObjectElement;
			}
		}

		private void OnMoveToolEndDrag(object sender, EventArgs e)
		{
			CreateUndoStep($"Moved {SelectedObject?.GetHashCode()}", "Moved " + SelectedObject?.PlanetObject?.Name);
		}

		private void OnPlanetRotated(object sender, EventArgs e)
		{
			_planetRotated = true;
		}

		private void OnViewTargetClicked()
		{
			IPlanetNode planetNode = CelestialBodyViewer.PlanetScript.PlanetNode;
			if ((CelestialBodyViewer.CameraPlanetPosition - _selectedObject.PlanetObject.PlanetPosition).magnitude < 50000.0)
			{
				_designer.CelestialBodyViewer.MovementScript.Focus(_selectedObject.PlanetObject.PlanetPosition);
				return;
			}
			Vector3d surfacePosition = planetNode.PlanetVectorToSurfaceVector(_selectedObject.PlanetObject.PlanetPosition);
			CelestialBodyViewer.PlanetScript.PlanetNode.GetSurfaceCoordinates(surfacePosition, out var latitude, out var longitude);
			double altitude = surfacePosition.magnitude - (planetNode.PlanetData.Radius + (double)planetNode.PlanetData.SeaLevel);
			_designer.CelestialBodyViewer.MovementScript.AnimateToSurfacePosition(latitude, longitude, AltitudeType.AboveSeaLevel, altitude, 2500.0, delegate
			{
				_moveTool?.ResetGizmoPosition();
			});
		}

		private void ReferenceFrameRecentered(object sender, EventArgs e)
		{
			if (_moveTool.IsActive)
			{
				_moveTool.Recenter();
			}
		}

		private void SelectSubStructureDelayed(SubStructure subStructure)
		{
			TreeNode<PlanetObjectElement> subStructureElement = Root.FindNode((TreeNode<PlanetObjectElement> x) => (x.Item?.PlanetObject is SubStructureObject subStructureObject && subStructureObject.SubStructure == subStructure) ? true : false);
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				SelectObject(subStructureElement?.Item);
			});
		}

		private void UpdateCelestialBodyData()
		{
			if (ViewerPlanetData != null)
			{
				PlanetDataScript currentCelestialBody = _designer.CurrentCelestialBody;
				currentCelestialBody.DefaultLaunchLocations.Clear();
				currentCelestialBody.DefaultLaunchLocations.AddRange(ViewerPlanetData.DefaultLaunchLocations);
				currentCelestialBody.StructureNodes.Clear();
				currentCelestialBody.StructureNodes.AddRange(ViewerPlanetData.StructureNodes);
			}
		}

		private void UpdateDetails(PlanetObjectElement planetObject)
		{
			if (InspectorPanel != null)
			{
				InspectorPanel.Close();
				InspectorPanel = null;
			}
			if (planetObject != null)
			{
				InspectorModel inspectorModel = new InspectorModel("Planet Object Details", planetObject.PlanetObject.TypeName ?? "");
				inspectorModel.Add(new TextInputModel("Name", () => planetObject.PlanetObject.Name, null, ElementAlignment.Right)).ValueSetter = delegate(string x)
				{
					planetObject.PlanetObject.Name = x;
					planetObject.NameText.text = x;
				};
				planetObject.PlanetObject.GenerateModel(inspectorModel, delegate
				{
					UpdateCelestialBodyData();
					RefreshUI();
				});
				base.PlanetStudioUI.PrepareInspectorModel(inspectorModel, delegate(string key, string description)
				{
					CreateUndoStep(key, description);
				});
				InspectorPanelCreationInfo inspectorPanelCreationInfo = new InspectorPanelCreationInfo();
				inspectorPanelCreationInfo.PanelWidth = 300;
				inspectorPanelCreationInfo.StartOffset = _currentOffset ?? new Vector2(400f, 0f);
				inspectorPanelCreationInfo.PanelMaxHeight = 0.8f;
				inspectorPanelCreationInfo.CanPin = false;
				InspectorPanel = Game.Instance.UserInterface.CreateInspectorPanel(inspectorModel, inspectorPanelCreationInfo);
				InspectorPanel.Closed += delegate(IInspectorPanel p)
				{
					_currentOffset = p.Position;
					InspectorPanel = null;
				};
				base.xmlLayout.GetElementsByClass("visible-selected").ForEach(delegate(XmlElement e)
				{
					e.SetActive(active: true);
				});
			}
			else
			{
				base.xmlLayout.GetElementsByClass("visible-selected").ForEach(delegate(XmlElement e)
				{
					e.SetActive(active: false);
				});
			}
			_cloneButton.SetActive(planetObject?.PlanetObject is SubStructureObject);
		}
	}
}
