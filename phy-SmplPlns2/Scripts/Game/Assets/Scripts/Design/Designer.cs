using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.CraftFiles;
using Assets.Scripts.Craft.CraftFiles.Exceptions;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Craft.Events;
using Assets.Scripts.Craft.Exceptions;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.CarverParts;
using Assets.Scripts.Design.Events;
using Assets.Scripts.Design.Symmetry;
using Assets.Scripts.Design.Symmetry.Events;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.AI;
using Assets.Scripts.Input.Events;
using Assets.Scripts.Menu;
using Assets.Scripts.UI;
using Jundroo.Common.Platform;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using UnityEngine;
using Vectrosity;

namespace Assets.Scripts.Design
{
	public class Designer : IInputHandler
	{
		public delegate void DesignerDelegate();

		public delegate void SelectedPartChangedDelegate(PartScript newPart);

		private static Vector3? _cameraPosition;

		private static Quaternion? _cameraRotation;

		private static Vector3? _cameraTarget;

		private static UndoHistory<UndoStep> _undoHistory = new UndoHistory<UndoStep>(250);

		private AircraftScript _aircraft;

		private GameObject _centerOfLiftGameObject;

		private GameObject _centerOfMassGameObject;

		private GameObject _centerOfPartGameObject;

		private GameObject _centerOfThrustGameObject;

		private bool _cotWarningMixingPropellersAndJets;

		private bool _cotWarningMultiplePropsShown;

		private PartScript _highlightedPart;

		private float _lastClickTime;

		private bool _linesCreated;

		private Transform _paintOrigin;

		private List<PartScript> _powertrainViewHiddenParts = new List<PartScript>();

		private PartScript _selectedPart;

		private bool _structureChanged;

		private DesignerViewMode _viewMode;

		public static bool IncludeHiddenPartsInRaycast { get; set; } = true;

		public static Designer Instance { get; private set; }

		public static Vector3 Position => Instance?.DesignerScript.transform.position ?? Vector3.zero;

		public AircraftScript Aircraft
		{
			get
			{
				return _aircraft;
			}
			private set
			{
				if ((object)_aircraft != null)
				{
					_aircraft.MainCockpitChanged -= OnMainCockpitChanged;
				}
				_aircraft = value;
				if ((object)_aircraft != null)
				{
					_aircraft.MainCockpitChanged += OnMainCockpitChanged;
				}
			}
		}

		public CameraController CameraController { get; set; }

		public DesignerPartIntersectionManager DesignerPartIntersectionManager { get; private set; }

		public DesignerScript DesignerScript { get; private set; }

		public bool DisableMovePart { get; set; }

		public bool EnableViewportPanningAndRotation { get; set; }

		public DesignerEnvironmentScript Environment => DesignerScript.Environment;

		public bool FingerAidAvailable { get; set; }

		public bool FingerAidEnabled { get; set; }

		public bool FingerAidSelected { get; set; }

		public bool GhostViewEnabled
		{
			get
			{
				return _viewMode == DesignerViewMode.Ghost;
			}
			set
			{
				if (value)
				{
					ViewMode = DesignerViewMode.Ghost;
				}
				else if (_viewMode == DesignerViewMode.Ghost)
				{
					ViewMode = DesignerViewMode.Normal;
				}
			}
		}

		public PartScript HighlightedPart
		{
			get
			{
				return _highlightedPart;
			}
			set
			{
				if (value != _highlightedPart)
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
		}

		public bool LockMovePart { get; set; }

		public bool MakeConnectionsToInvisibleParts => false;

		public DesignerPartList PartList { get; private set; }

		public PartScript SelectedPart
		{
			get
			{
				return _selectedPart;
			}
			set
			{
				SelectPart(value);
			}
		}

		public bool ShowCenterOfLiftGizmo { get; set; }

		public bool ShowCenterOfMassGizmo { get; set; }

		public bool ShowCenterOfThrustGizmo { get; set; }

		public bool ShowDrag
		{
			get
			{
				return Tools.MovePartTool.ShowDrag;
			}
			set
			{
				Tools.SelectMovePartTool();
				Tools.MovePartTool.ShowDrag = value;
			}
		}

		public SymmetryConfig Symmetry { get; }

		public DesignerTools Tools { get; private set; }

		public UndoHistory<UndoStep> UndoHistory => _undoHistory;

		public bool UserPreventPartGrab
		{
			get
			{
				if (!UnityEngine.Input.GetKey(KeyCode.LeftControl))
				{
					return UnityEngine.Input.GetKey(KeyCode.RightControl);
				}
				return true;
			}
		}

		public DesignerViewMode ViewMode
		{
			get
			{
				return _viewMode;
			}
			set
			{
				if (_viewMode == value)
				{
					return;
				}
				switch (_viewMode)
				{
				case DesignerViewMode.Ghost:
					foreach (PartData part in Aircraft.Aircraft.Assembly.Parts)
					{
						part.PartScript.PartMaterialScript.IsHidden = false;
					}
					break;
				case DesignerViewMode.Powertrain:
					foreach (PartScript powertrainViewHiddenPart in _powertrainViewHiddenParts)
					{
						powertrainViewHiddenPart.PartMaterialScript.IsHidden = false;
					}
					_powertrainViewHiddenParts.Clear();
					IncludeHiddenPartsInRaycast = true;
					break;
				}
				_viewMode = value;
				switch (value)
				{
				case DesignerViewMode.Ghost:
				{
					foreach (PartData part2 in Aircraft.Aircraft.Assembly.Parts)
					{
						if (SelectedPart != part2.PartScript)
						{
							part2.PartScript.PartMaterialScript.IsHidden = true;
						}
						else
						{
							part2.PartScript.PartMaterialScript.IsHidden = false;
						}
					}
					break;
				}
				case DesignerViewMode.Powertrain:
					foreach (PartData part3 in Aircraft.Aircraft.Assembly.Parts)
					{
						PartScript partScript = part3.PartScript;
						if (!part3.IsPowertrainPart && !partScript.PartMaterialScript.IsHidden)
						{
							partScript.PartMaterialScript.IsHidden = true;
							_powertrainViewHiddenParts.Add(partScript);
						}
					}
					IncludeHiddenPartsInRaycast = false;
					break;
				}
			}
		}

		public event DesignerDelegate AircraftStructureChangedEvent;

		public event DesignerDelegate CraftLoaded;

		public event DesignerDelegate CraftSaved;

		public event EventHandler<PartDeletedEventArgs> PartDeleted;

		public event SelectedPartChangedDelegate SelectedPartChangedEvent;

		public Designer(DesignerScript designerScript)
		{
			Instance = this;
			DesignerScript = designerScript;
			GameObject cameraTarget = Utilities.FindFirstGameObjectMyselfOrChildren("CameraTarget", DesignerScript.gameObject);
			Camera component = Utilities.FindFirstGameObjectMyselfOrChildren("Camera", DesignerScript.gameObject).GetComponent<Camera>();
			Camera component2 = Utilities.FindFirstGameObjectMyselfOrChildren("GizmoCamera", DesignerScript.gameObject).GetComponent<Camera>();
			_centerOfMassGameObject = Utilities.FindFirstGameObjectMyselfOrChildren("CenterOfMass", DesignerScript.gameObject);
			_centerOfLiftGameObject = Utilities.FindFirstGameObjectMyselfOrChildren("CenterOfLift", DesignerScript.gameObject);
			_centerOfThrustGameObject = Utilities.FindFirstGameObjectMyselfOrChildren("CenterOfThrust", DesignerScript.gameObject);
			_centerOfPartGameObject = Utilities.FindFirstGameObjectMyselfOrChildren("CenterOfPart", DesignerScript.gameObject);
			Symmetry = new SymmetryConfig();
			Symmetry.SymmetryModeChanged += OnSymmetryModeChanged;
			CameraController = new CameraController(component, cameraTarget, new Camera[1] { component2 });
			Tools = new DesignerTools(this);
			CraftLoaded += OnCraftLoaded;
			XElement xElement = Game.Instance.CraftDatabase.LoadBuiltinCraftXml("__editor__.xml", showErrorDialogs: true);
			if (xElement == null)
			{
				xElement = Game.Instance.CraftDatabase.LoadBuiltinCraftXml("__new__", showErrorDialogs: true);
			}
			LoadXml(xElement);
			Aircraft.DrawAerodynamicCenter = false;
			FingerAidAvailable = Game.Instance.Device.IsTouchEnabled;
			FingerAidSelected = FingerAidAvailable;
			DisableMovePart = Game.Instance.Device.IsTouchEnabled;
			PartList = new DesignerPartList();
			PartList.Load();
			if (_cameraTarget.HasValue)
			{
				CameraController.TargetPosition = _cameraTarget.Value;
				CameraController.Camera.transform.SetPositionAndRotation(_cameraPosition.Value, _cameraRotation.Value);
				_cameraTarget = null;
				_cameraPosition = null;
				_cameraRotation = null;
			}
		}

		public static void CenterViewOnPart(PartScript part)
		{
			Camera main = Camera.main;
			MoveObjectScript component = main.GetComponent<MoveObjectScript>();
			if (!component.ObjectIsPanning)
			{
				component.ResetPanning();
				WingScript wingScriptFromPart = WingScript.GetWingScriptFromPart(part);
				if (wingScriptFromPart != null)
				{
					float f = main.fieldOfView * (MathF.PI / 180f) / 2f;
					float f2 = Mathf.Atan(Mathf.Tan(f) * main.aspect);
					float a = 0.5f * wingScriptFromPart.Wing.WingSpan / Mathf.Tan(f2);
					float num = Mathf.Min(wingScriptFromPart.RootTrailingEdge.z, wingScriptFromPart.TipTrailingEdge.z);
					float num2 = Mathf.Max(wingScriptFromPart.RootLeadingEdge.z, wingScriptFromPart.TipLeadingEdge.z) - num;
					float b = 0.5f * num2 / Mathf.Tan(f);
					float num3 = Mathf.Max(a, b);
					float num4 = 4f;
					float num5 = 1.5f;
					float num6 = 2f;
					float num7 = 6f;
					float value = (num3 - num6) / (num7 - num6);
					value = Mathf.Clamp(value, 0f, 1f);
					value = 1f - value;
					float num8 = num5 + value * (num4 - num5);
					num3 *= num8;
					Vector3 vector = (part.transform.TransformPoint(wingScriptFromPart.RootLeadingEdge) + part.transform.TransformPoint(wingScriptFromPart.RootTrailingEdge) + part.transform.TransformPoint(wingScriptFromPart.TipLeadingEdge) + part.transform.TransformPoint(wingScriptFromPart.TipTrailingEdge)) / 4f;
					num3 = Mathf.Max(num3, 5f);
					component.DestinationPanPosition = vector + Utilities.Abs(part.transform.right) * num3;
					component.PanningFocus = vector;
					component.DestinationPanUp = Vector3.forward;
					component.IsInterruptable = false;
				}
				else
				{
					Vector3 vector2 = part.transform.position - main.transform.position;
					component.DestinationPanPosition = part.transform.position + main.transform.forward * (0f - vector2.magnitude);
					component.PanningFocus = part.transform.position;
				}
				component.IsPanningFocusACameraTarget = true;
				component.CameraTarget = main.transform.parent;
				component.TimeToFinishPanning = 0.65f;
			}
		}

		public static (PartScript Part, RaycastHit Hit, Ray Ray)? GetPartFromRayCast(Ray ray, int layerMask = 2129921, float radius = 0f)
		{
			RaycastHit[] array = (from x in ((radius == 0f) ? Physics.RaycastAll(ray, 10000f, layerMask) : Physics.SphereCastAll(ray, 10000f, layerMask)).Where((RaycastHit x) => x.collider.gameObject.GetComponentInParent<PartScript>()?.IsInteractable ?? false).ToArray()
				orderby x.distance
				select x).ToArray();
			RaycastHit? raycastHit = null;
			PartScript partScript = null;
			RaycastHit[] array2 = array;
			for (int num = 0; num < array2.Length; num++)
			{
				RaycastHit value = array2[num];
				PartScript componentInParent = value.collider.transform.GetComponentInParent<PartScript>();
				if (componentInParent != null && (IncludeHiddenPartsInRaycast || !componentInParent.PartMaterialScript.IsHidden))
				{
					partScript = componentInParent;
					raycastHit = value;
					break;
				}
			}
			if (partScript != null)
			{
				return (partScript, raycastHit.Value, ray);
			}
			return null;
		}

		public void AssignAircraft(GameObject aircraftGameObject)
		{
			SelectedPart = null;
			DesignerScript.ClearPartConcealment();
			Transform transform = DesignerScript.transform.Find("AircraftContainer");
			string text = "Aircraft";
			Transform transform2 = transform.Find(text);
			if (transform2 != null)
			{
				UnityEngine.Object.Destroy(transform2.gameObject);
				FlightSceneScript instance = FlightSceneScript.Instance;
				if (instance != null)
				{
					instance.UnloadUnusedAssets(force: false);
				}
				else
				{
					DesignerScript.UnloadUnusedAssets(force: false);
				}
			}
			aircraftGameObject.name = text;
			aircraftGameObject.transform.SetParent(transform, worldPositionStays: true);
			Aircraft = aircraftGameObject.GetComponent<AircraftScript>();
			if (!Physics.autoSyncTransforms)
			{
				Physics.SyncTransforms();
			}
			_paintOrigin = new GameObject("PaintOrigin").transform;
			_paintOrigin.SetParent(aircraftGameObject.transform, worldPositionStays: false);
			_paintOrigin.localPosition = Aircraft.Aircraft.PaintOrigin;
			OnAircraftStructureChanged();
			this.CraftLoaded?.Invoke();
			foreach (PartData part in Aircraft.Aircraft.Assembly.Parts)
			{
				if (!part.VisibleInDesigner)
				{
					DesignerScript.AddPartToConcealedCollection(part.PartScript);
				}
			}
			if (ViewMode != DesignerViewMode.Normal)
			{
				DesignerViewMode viewMode = ViewMode;
				_viewMode = DesignerViewMode.Normal;
				ViewMode = viewMode;
			}
		}

		public void ControlSurfaceDeleted(ControlSurfaceScript controlSurfaceScript)
		{
			if (Tools.SelectedTool == Tools.ControlSurfaceTool)
			{
				Tools.SelectMovePartTool();
			}
		}

		public void CreateNewAircraft()
		{
			XElement aircraftElement = Game.Instance.CraftDatabase.LoadBuiltinCraftXml("__new__", showErrorDialogs: true);
			LoadXml(aircraftElement, isNewAircraft: true);
		}

		public Assembly CreateSubassemblyFromSelectedParts(string filename)
		{
			List<PartData> partsConnectedToPartButNotConnectedToCockpit = PartGraph.GetPartsConnectedToPartButNotConnectedToCockpit(SelectedPart);
			Assembly assembly = SelectedPart.Aircraft.Aircraft.Assembly;
			foreach (PartData item in partsConnectedToPartButNotConnectedToCockpit)
			{
				if (item.SymmetryId != 0)
				{
					assembly.UnlinkSymmetricParts(item.SymmetryId, disableSymmetry: false);
				}
			}
			Assembly assembly2 = Assembly.CreateAssemblyFromParts(partsConnectedToPartButNotConnectedToCockpit, CraftLoadContext.Designer);
			PartList.CreateSubassembly(filename, assembly2);
			return assembly2;
		}

		public UndoStep CreateUndoStep(string description, string replaceKey = null)
		{
			XElement craftXml = Aircraft.Aircraft.GenerateXml(createRigidBodyGroups: false);
			return CreateUndoStep(description, replaceKey, craftXml);
		}

		public UndoStep CreateUndoStep(string description, string replaceKey, XElement craftXml)
		{
			UndoStep undoStep = new UndoStep(craftXml, description, DateTime.UtcNow);
			UndoHistory.PushUndo(undoStep, replaceKey);
			return undoStep;
		}

		public UndoStep CreateUndoStepForSelectedPart(string propertyName, string replaceKey = null)
		{
			string text = propertyName;
			if (SelectedPart != null)
			{
				text = $"{SelectedPart.Part.Name} #{SelectedPart.Part.Id} {propertyName}";
			}
			if (string.IsNullOrEmpty(replaceKey))
			{
				replaceKey = text;
			}
			return CreateUndoStep(text, replaceKey);
		}

		public void DeletePart(PartScript partScript, bool deleteSymmetricParts = false)
		{
			if (deleteSymmetricParts)
			{
				List<PartData> symmetricParts;
				using (partScript.Aircraft.Aircraft.Assembly.GetOtherSymmetricParts(partScript.Part, out symmetricParts))
				{
					foreach (PartData item in symmetricParts)
					{
						DeletePart(item.PartScript);
					}
				}
			}
			Aircraft.DeletePart(partScript);
			this.PartDeleted?.Invoke(this, new PartDeletedEventArgs(partScript));
			if (SelectedPart == partScript)
			{
				SelectPart(null);
			}
		}

		public void DeleteSelectedParts(bool singlePart = false)
		{
			if (Tools.SelectedTool == Tools.MovePartTool)
			{
				Tools.MovePartTool.DeleteSelectedParts(singlePart);
			}
		}

		public void DeselectPart()
		{
			SelectPart(null);
		}

		public int DisconnectPart(PartData part, bool disconnectSymmetricParts)
		{
			int num = 0;
			PartConnection[] array = part.PartConnections.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: false, raiseConnectionChangedEvents: true);
				num++;
			}
			if (disconnectSymmetricParts && part.SymmetryId != 0)
			{
				Assembly assembly = part.PartScript.Aircraft.Aircraft.Assembly;
				List<PartData> value;
				using (CollectionPool<List<PartData>, PartData>.Get(out value))
				{
					assembly.GetOtherSymmetricParts(part, value);
					foreach (PartData item in value)
					{
						num += DisconnectPart(item, disconnectSymmetricParts: false);
					}
				}
			}
			return num;
		}

		public bool DraggingPartsOverCreateSubassembly()
		{
			return DesignerScript.DesignerUI.DropZones.IsOverCreateSubassembly();
		}

		public bool DraggingPartsOverTrashcan()
		{
			return DesignerScript.DesignerUI.DropZones.IsOverTrashCan();
		}

		public void FixedUpdate()
		{
		}

		public (PartScript Part, RaycastHit Hit, Ray Ray)? GetPartAtScreenPosition(Vector2 screenPosition, float radius = 0f)
		{
			return GetPartFromRayCast(ScreenPointToRay(screenPosition));
		}

		public void HandleInput(InputEvent e)
		{
			if ((Tools.SelectedTool == null || Tools.SelectedTool.AllowPartSelection) && !FingerAidEnabled)
			{
				(PartScript, RaycastHit, Ray)? partAtScreenPosition = GetPartAtScreenPosition(e.Position);
				if (partAtScreenPosition.HasValue)
				{
					PartScript item = partAtScreenPosition.Value.Item1;
					if (e.InputState == InputState.Updated && e.InputButton == InputButton.Primary)
					{
						DesignerScript.DesignerUI.HideMainUI(hide: true);
					}
					else if (e.InputState == InputState.End && e.InputButton == InputButton.Primary && e.DeltaPositionSinceBegin == Vector2.zero && item != null && !UserPreventPartGrab)
					{
						bool focus = SelectedPart == item && Time.time - _lastClickTime < 0.5f;
						_lastClickTime = Time.time;
						SelectPart(item, focus, partAtScreenPosition.Value.Item2);
					}
				}
				else if (e.InputState == InputState.End && e.InputButton == InputButton.Primary && e.DeltaPositionSinceBegin == Vector2.zero)
				{
					SelectPart(null);
				}
			}
			if (Tools.SelectedTool != null)
			{
				Tools.SelectedTool.HandleInput(e);
			}
		}

		public void HandlePinch(PinchEvent e)
		{
			Tools.SelectedTool.HandlePinch(e);
		}

		public void HandleScroll(MouseScrollEvent e)
		{
			Tools.SelectedTool.HandleScroll(e);
		}

		public void HideDraggingPartButtons()
		{
			DesignerScript.DesignerUI.DropZones.Hide();
		}

		public void LateUpdate()
		{
			if (_structureChanged)
			{
				_structureChanged = false;
				OnAircraftStructureChanged();
			}
		}

		public void LoadXml(XElement aircraftElement, bool isNewAircraft = false)
		{
			bool flag = false;
			try
			{
				SelectPart(null);
				CrashDetection.SetFlag();
				if (Aircraft != null)
				{
					UnityEngine.Object.Destroy(Aircraft.gameObject);
				}
				Tools.SelectMovePartTool();
				AircraftData aircraftData = new AircraftData(aircraftElement, CraftLoadContext.Designer);
				List<string> missingParts = aircraftData.Assembly.MissingParts;
				if (missingParts.Count > 0)
				{
					bool flag2 = false;
					bool flag3 = true;
					foreach (string item in missingParts)
					{
						bool flag4 = item?.ToLower().StartsWith("mod_") ?? false;
						flag2 = flag2 || flag4;
						flag3 = flag3 && flag4;
					}
					MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog();
					string text = "This airplane requires missing part(s):\n";
					if (flag2 && !flag3)
					{
						IEnumerable<string> enumerable2;
						if (missingParts.Count <= 2)
						{
							IEnumerable<string> enumerable = missingParts;
							enumerable2 = enumerable;
						}
						else
						{
							enumerable2 = missingParts.Take(1);
						}
						foreach (string item2 in enumerable2)
						{
							text = text + " " + item2 + ",";
						}
						if (missingParts.Count > 2)
						{
							text += $"\n +{missingParts.Count - 1} other part(s) ";
						}
						text = text.TrimEnd(',') + "\n";
						if (missingParts.Count <= 1)
						{
							text += "\n";
						}
						text += "There are two possible reasons for this:\n1) You need to update to the newest version of SimplePlanes (check your app store)\n2) The airplane uses a 'mod' and you'll need to contact the airplane designer to find out more.";
					}
					else
					{
						IEnumerable<string> enumerable3;
						if (missingParts.Count <= 4)
						{
							IEnumerable<string> enumerable = missingParts;
							enumerable3 = enumerable;
						}
						else
						{
							enumerable3 = missingParts.Take(3);
						}
						foreach (string item3 in enumerable3)
						{
							text = text + " " + item3 + ",";
						}
						if (missingParts.Count > 4)
						{
							text += $"\n +{missingParts.Count - 3} other part(s) ";
						}
						text = text.TrimEnd(',') + "\n";
						if (missingParts.Count <= 3)
						{
							text += "\n";
						}
						text = ((!flag3) ? (text + "You may be running an older version of the game. Verify that your game is up to date and try again.") : (text + "The airplane uses one or more 'mods'.\nContact the airplane designer to find out more."));
					}
					messageDialogScript.MessageText = text;
					flag = true;
				}
				PartData.PartCreationInfo partCreationInfo = new PartData.PartCreationInfo();
				partCreationInfo.CreateHingeJoints = false;
				partCreationInfo.IsRigidBodyKinematic = true;
				partCreationInfo.CreateRigidBody = false;
				partCreationInfo.EnableWingScript = false;
				AssignAircraft(AircraftData.GenerateGameObject(aircraftData, partCreationInfo, 0));
				if (isNewAircraft || UndoHistory.NumUndoSteps == 0)
				{
					CreateUndoStep("Loaded '" + StringUtility.ClampString(aircraftData?.Name, 15) + "'");
				}
			}
			catch (XmlVersionException)
			{
				flag = true;
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "This airplane requires a newer version of SimplePlanes. Check your app store and download the newest version of SimplePlanes.";
			}
			catch (Exception ex2)
			{
				flag = true;
				Debug.LogException(ex2);
				Debug.LogError("Failed to load aircraft: " + ex2.ToString());
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "There was an error loading the aircraft design.";
			}
			if (flag)
			{
				try
				{
					if (!isNewAircraft)
					{
						CreateNewAircraft();
					}
				}
				catch (Exception ex3)
				{
					Debug.LogError("Failed to load new aircraft: " + ex3.Message);
					ShowMessage(string.Empty);
					Game.Instance.UserInterface.CreateMessageDialog().MessageText = "Failed to load the aircraft, and a new aircraft cannot be created. You may need to clear SimplePlanes data cache (aircraft will be lost, manually back up of possible).";
				}
			}
			CrashDetection.ClearFlag();
		}

		public void MouseHover(Vector3? screenPosition)
		{
			Tools.SelectedTool?.MouseHover(screenPosition);
		}

		public void OnAircraftStructureChanged()
		{
			foreach (PartData part in Aircraft.Aircraft.Assembly.Parts)
			{
				part.PartScript.PartMaterialScript.IsDisconnected = true;
			}
			Aircraft.AircraftStructureChanged();
			_centerOfMassGameObject.transform.position = Aircraft.CenterOfMass.CenterOfMass;
			Tools.OnAircraftStructureChanged();
			if (ShowCenterOfMassGizmo)
			{
				DesignerScript.StartCoroutine(RecalculateGizmos());
			}
			UpdateSymmetryConfig();
			DesignerScript.StartCoroutine(UpdateAdaptiveBlockStates());
			this.AircraftStructureChangedEvent?.Invoke();
		}

		public void OnDestroy()
		{
			Instance = null;
			Symmetry.SymmetryModeChanged -= OnSymmetryModeChanged;
		}

		public void ReconnectSelectedPart()
		{
			if (Device.IsDemoBuild)
			{
				Game.Instance.UserInterface.CreateMessageDialog("This functionality is not available in the demo version of the game.", "Not Available In Demo");
			}
			else
			{
				if (!(SelectedPart != null))
				{
					return;
				}
				DesignerScript.EndPartMovement();
				DisconnectPart(SelectedPart.Part, disconnectSymmetricParts: true);
				int num = MovePartTool.DetectAttachPointConnectionsAndConnect(SelectedPart.AttachPointScripts, SelectedPart.gameObject, connectSymmetricParts: true, autoConcealSymmetricParts: true);
				if (SelectedPart.Part.SymmetryId != 0)
				{
					List<PartData> value;
					using (CollectionPool<List<PartData>, PartData>.Get(out value))
					{
						SelectedPart.Aircraft.Aircraft.Assembly.GetOtherSymmetricParts(SelectedPart.Part, value);
						foreach (PartData item in value)
						{
							num += MovePartTool.DetectAttachPointConnectionsAndConnect(item.PartScript.AttachPointScripts, item.PartScript.gameObject, connectSymmetricParts: false, autoConcealSymmetricParts: false);
						}
					}
				}
				ShowMessage($"Part reconnected. Found {num} connection(s)");
			}
		}

		public void Redo()
		{
			UndoStep nextRedoStep = UndoHistory.GetNextRedoStep();
			if (nextRedoStep != null)
			{
				RestoreFromUndoStep(nextRedoStep);
			}
		}

		public void RestoreFromUndoStep(UndoStep step)
		{
			Tools.SelectMovePartTool();
			PartData.PartCreationInfo partCreationInfo = new PartData.PartCreationInfo();
			partCreationInfo.CreateHingeJoints = false;
			partCreationInfo.IsRigidBodyKinematic = true;
			partCreationInfo.CreateRigidBody = false;
			partCreationInfo.EnableWingScript = false;
			GameObject aircraftGameObject = AircraftData.GenerateGameObject(new AircraftData(step.Xml, CraftLoadContext.Designer), partCreationInfo, 0);
			AssignAircraft(aircraftGameObject);
		}

		public void RotatePartOnAxis(Vector3 axis, int angle)
		{
			if (SelectedPart != null)
			{
				Quaternion rotation = Quaternion.AngleAxis(angle, axis);
				Tools.MovePartTool.RotatePart(SelectedPart, rotation, singlePart: false, rotationIsTarget: false, disconnectParts: true);
			}
		}

		public void Save(string aircraftId, string name)
		{
			if (DesignerScript.Tutorial.CurrentTutorial != null && aircraftId == "__editor__.xml")
			{
				return;
			}
			Bounds bounds = Aircraft.CalculateBounds(includeDisconnectedParts: false);
			bool flag = false;
			if (Game.Instance.Settings.Gameplay.Designer.AutoRecenter.Value)
			{
				flag = RepositionAircraftOnGround(Aircraft, ref bounds, 0.5f);
			}
			if (flag)
			{
				DesignerPartIntersectionManager.OnCraftReposition();
			}
			if (Aircraft.Aircraft.AerodynamicsModelType == CraftAerodynamicsModelType.Legacy)
			{
				new DragCalculator(Aircraft.Parts).CalculateDrag();
				if (!Aircraft.Aircraft.UseOldDragCalculation)
				{
					new DragCalculator(Aircraft.InitiallyDisconnectedParts).CalculateDrag();
				}
			}
			else
			{
				DesignerScript.DragCalculator.CalculateDragInDesigner(Aircraft);
			}
			Aircraft.Aircraft.Size = bounds.size;
			Aircraft.Aircraft.BoundsMinimum = bounds.min;
			Aircraft.Aircraft.BoundsOffset = Aircraft.MainCockpit.transform.position - bounds.center;
			Aircraft.Aircraft.Name = name;
			XElement craftXml = Aircraft.Aircraft.GenerateXml(createRigidBodyGroups: true, serializeStats: true);
			if (flag)
			{
				CreateUndoStep("Craft Repositioned", "Craft Repositioned", craftXml);
			}
			if (aircraftId != "__editor__.xml")
			{
				Game.Instance.CraftDatabase.SaveCraft("__editor__.xml", craftXml, backupPreviousFile: true, updateXmlVersion: true);
			}
			try
			{
				CraftFileInfo craftFileInfo = Game.Instance.CraftDatabase.SaveCraft(aircraftId, craftXml, backupPreviousFile: true, updateXmlVersion: true);
				if (aircraftId != "__editor__.xml")
				{
					Game.Instance.CraftDatabase.CurrentSubdirectoryPath = craftFileInfo.SubdirectoryPath;
				}
			}
			catch (CraftDatabaseException ex)
			{
				Game.Instance.UserInterface.CreateMessageDialog(ex.Message, "Craft Save Failed");
			}
			if (aircraftId != "__editor__.xml")
			{
				AiAircraftInfo aiAircraftInfo = new AiAircraftInfo(aircraftId);
				aiAircraftInfo.PartCount = Aircraft.Parts.Count;
				aiAircraftInfo.WingCount = Aircraft.Wings.Count;
				aiAircraftInfo.ForceFlyabilityRetests();
				aiAircraftInfo.Save();
			}
			this.CraftSaved?.Invoke();
		}

		public Ray ScreenPointToRay(Vector2 screenCoordinates)
		{
			return Tools.SelectedTool.CameraController.Camera.ScreenPointToRay(screenCoordinates);
		}

		public void SelectPart(Vector2 screenPosition, bool focus)
		{
			(PartScript, RaycastHit, Ray)? partAtScreenPosition = GetPartAtScreenPosition(screenPosition);
			PartScript partScript = partAtScreenPosition?.Item1;
			if (partScript != null)
			{
				SelectPart(partScript, focus, partAtScreenPosition.Value.Item2);
			}
		}

		public void SetAircraftStructureChanged()
		{
			_structureChanged = true;
		}

		public void ShowDraggingPartButtons(bool isNewOrClonedPart)
		{
			DesignerScript.DesignerUI.DropZones.Show(isNewOrClonedPart);
		}

		public void ShowMessage(string message, float time = 7f)
		{
			if (DesignerScript.DesignerUI != null)
			{
				DesignerScript.DesignerUI.ShowMessage(message, time);
			}
		}

		public void StartFlight()
		{
			DesignerScript.StartCoroutine(StartFlightCoroutine());
		}

		public void Undo()
		{
			UndoStep nextUndoStep = UndoHistory.GetNextUndoStep();
			if (nextUndoStep != null)
			{
				RestoreFromUndoStep(nextUndoStep);
			}
		}

		public void Update()
		{
			Tools.Update();
			bool flag = false;
			if (ShowCenterOfMassGizmo != _centerOfMassGameObject.activeInHierarchy)
			{
				_centerOfMassGameObject.SetActive(ShowCenterOfMassGizmo);
				flag = ShowCenterOfMassGizmo || flag;
			}
			if (ShowCenterOfLiftGizmo != _centerOfLiftGameObject.activeInHierarchy)
			{
				_centerOfLiftGameObject.SetActive(ShowCenterOfLiftGizmo);
				flag = ShowCenterOfLiftGizmo || flag;
			}
			if (ShowCenterOfThrustGizmo != _centerOfThrustGameObject.activeInHierarchy)
			{
				_centerOfThrustGameObject.SetActive(ShowCenterOfThrustGizmo);
				flag = ShowCenterOfThrustGizmo || flag;
			}
			if (flag)
			{
				DesignerScript.StartCoroutine(RecalculateGizmos());
			}
			bool flag2 = FingerAidAvailable && FingerAidSelected && Tools.SelectedTool.AllowFingerAid;
			if (FingerAidEnabled != flag2)
			{
				FingerAidEnabled = flag2;
				DisableMovePart = FingerAidEnabled;
			}
			if (CameraController.IsOrthographic)
			{
				CameraController.UpdateOrthographicSize();
			}
			UpdatePaintOrigin(null);
			if (SelectedPart != null)
			{
				IReadOnlyList<ICraftDecal> decals = SelectedPart.Part.Decals;
				for (int i = 0; i < decals.Count; i++)
				{
					decals[i].SetDirty();
				}
			}
		}

		public void UpdatePaintOrigin(Vector3? repositionDelta)
		{
			AircraftScript aircraft = _aircraft;
			_ = _paintOrigin;
			if (_paintOrigin != null && _aircraft != null)
			{
				if (repositionDelta.HasValue)
				{
					_paintOrigin.localPosition += repositionDelta.Value;
				}
				aircraft.Aircraft.PaintOrigin = _paintOrigin.localPosition;
				aircraft.Theme.UpdatePaintOrigin(_paintOrigin.localPosition);
			}
		}

		public void UpdatePartCenterGizmo(bool enabled, Vector3 position)
		{
			_centerOfPartGameObject.transform.position = position;
			_centerOfPartGameObject.SetActive(enabled);
		}

		public void UpdateSymmetryConfig()
		{
			Transform transform = Aircraft.MainCockpit.transform;
			Symmetry.UpdateConfig(transform.position, Vector3.right, Aircraft.Aircraft.MirrorPlaneOffset, transform.forward);
		}

		public Ray WorldPointToRay(Vector3 position)
		{
			Vector3 pos = CameraController.Camera.WorldToScreenPoint(position);
			return CameraController.Camera.ScreenPointToRay(pos);
		}

		private static void CreateGizmoLines(Transform transform, Color color)
		{
			List<VectorLine> list = new List<VectorLine>();
			float num = 5f;
			float width = 1.5f;
			Vector3 position = transform.position;
			list.Add(new VectorLine("Up", new Vector3[2]
			{
				Vector3.up * num + position,
				position
			}.ToList(), null, width));
			list.Add(new VectorLine("Down", new Vector3[2]
			{
				position - Vector3.up * num,
				position
			}.ToList(), null, width));
			list.Add(new VectorLine("Right", new Vector3[2]
			{
				position,
				Vector3.right * num + position
			}.ToList(), null, width));
			list.Add(new VectorLine("Left", new Vector3[2]
			{
				position,
				position - Vector3.right * num
			}.ToList(), null, width));
			list.Add(new VectorLine("Forward", new Vector3[2]
			{
				position,
				position + Vector3.forward * num
			}.ToList(), null, width));
			list.Add(new VectorLine("Backward", new Vector3[2]
			{
				position,
				position - Vector3.forward * num
			}.ToList(), null, width));
			foreach (VectorLine item in list)
			{
				item.color = color;
				item.Draw3D();
				item.rectTransform.SetParent(transform, worldPositionStays: true);
			}
		}

		private static bool IsDragablePart(GameObject objectHit)
		{
			return objectHit.transform.GetComponentInParent<PartScript>(includeInactive: true) != null;
		}

		private void OnCraftLoaded()
		{
			if (DesignerPartIntersectionManager != null)
			{
				UnityEngine.Object.Destroy(DesignerPartIntersectionManager);
			}
			DesignerPartIntersectionManager = new GameObject("IntersectionManager").AddComponent<DesignerPartIntersectionManager>();
			DesignerPartIntersectionManager.transform.SetParent(_aircraft.transform, worldPositionStays: false);
		}

		private void OnMainCockpitChanged(object sender, MainCockpitChangedEventArgs e)
		{
			PartScript newCockpit = e.NewCockpit;
			if ((object)newCockpit != null && newCockpit.Part.SymmetryId != 0)
			{
				PartMaterialScript partMaterialScript = e.NewCockpit.PartMaterialScript;
				bool selected = partMaterialScript.IsSelected || partMaterialScript.IsSelectedSymmetric;
				partMaterialScript.SetSelected(selected: false, updateSymmetricParts: true);
				Aircraft.Aircraft.Assembly.UnlinkSymmetricParts(e.NewCockpit.Part.SymmetryId, disableSymmetry: false);
				partMaterialScript.SetSelected(selected, updateSymmetricParts: false);
			}
		}

		private void OnSymmetryModeChanged(object sender, SymmetryModeChangeEventArgs e)
		{
			ShowMessage(e.NewMode switch
			{
				SymmetryMode.Disabled => "Mirror mode disabled", 
				SymmetryMode.Mirrored => "Mirror mode enabled", 
				SymmetryMode.Radial2x => "Symmetry mode set to Radial 2x", 
				SymmetryMode.Radial3x => "Symmetry mode set to Radial 3x", 
				SymmetryMode.Radial4x => "Symmetry mode set to Radial 4x", 
				_ => $"Symmetry mode set to {e.NewMode}", 
			});
		}

		private void RecalculateCenterOfLift()
		{
			float num = 0f;
			Vector3 zero = Vector3.zero;
			foreach (IWingScript wing in Aircraft.Wings)
			{
				Vector3 centre;
				float num2 = wing.GetProjectedAreaMoment(Vector3.up, out centre) * wing.LiftScale;
				zero += centre * num2;
				num += num2;
			}
			if (num > 0f)
			{
				Vector3 position = zero / num;
				_centerOfLiftGameObject.transform.position = position;
				_centerOfLiftGameObject.SetActive(ShowCenterOfLiftGizmo);
			}
			else
			{
				_centerOfLiftGameObject.transform.position = Vector3.zero;
			}
		}

		private void RecalculateCenterOfMass()
		{
		}

		private void RecalculateCenterOfThrust()
		{
			float num = 0f;
			Vector3 zero = Vector3.zero;
			HashSet<DesignerThrustTypes> hashSet = new HashSet<DesignerThrustTypes>();
			int num2 = 0;
			foreach (PartData part in Aircraft.Parts)
			{
				IDesignerThrust modifierWithInterface = part.PartScript.GetModifierWithInterface<IDesignerThrust>();
				if (modifierWithInterface != null)
				{
					zero += modifierWithInterface.DesignerCenterOfThrust * modifierWithInterface.DesignerThrust;
					num += modifierWithInterface.DesignerThrust;
					hashSet.Add(modifierWithInterface.DesignerThrustType);
					if (modifierWithInterface.DesignerThrustType == DesignerThrustTypes.PropAssembly || modifierWithInterface.DesignerThrustType == DesignerThrustTypes.LegacyProp)
					{
						num2++;
					}
				}
			}
			float totalThrust = 0f;
			Vector3 weightedThrustVector = Vector3.zero;
			_aircraft.VtolManagerScript.Refresh();
			_aircraft.VtolManagerScript.GetThrustInfo(out totalThrust, out weightedThrustVector);
			if (totalThrust > 0f)
			{
				hashSet.Add(DesignerThrustTypes.LegacyEngine);
				num += totalThrust;
				zero += weightedThrustVector;
			}
			if (num > 0f)
			{
				Vector3 position = zero / num;
				_centerOfThrustGameObject.transform.position = position;
			}
			else
			{
				_centerOfThrustGameObject.transform.position = Vector3.zero;
			}
			if (hashSet.Count > 1 && ShowCenterOfThrustGizmo && !_cotWarningMixingPropellersAndJets)
			{
				DesignerScript.DesignerUI.ShowMessage("Note: CoT is inaccurate in crafts using different engine types.");
				_cotWarningMixingPropellersAndJets = true;
			}
			else if (num2 > 1 && ShowCenterOfThrustGizmo && !_cotWarningMultiplePropsShown)
			{
				DesignerScript.DesignerUI.ShowMessage("Note: CoT is an approximation when multiple prop engines are used which have different configurations.");
				_cotWarningMultiplePropsShown = true;
			}
		}

		private IEnumerator RecalculateGizmos()
		{
			yield return null;
			if (!_linesCreated)
			{
				_linesCreated = true;
				CreateGizmoLines(_centerOfLiftGameObject.transform, Constants.Colors.PrimaryLight);
				CreateGizmoLines(_centerOfThrustGameObject.transform, new Color32(byte.MaxValue, 250, 146, byte.MaxValue));
				CreateGizmoLines(_centerOfMassGameObject.transform, new Color32(204, 96, 96, byte.MaxValue));
				CreateGizmoLines(_centerOfPartGameObject.transform, new Color32(102, 102, 102, byte.MaxValue));
			}
			RecalculateCenterOfMass();
			RecalculateCenterOfLift();
			RecalculateCenterOfThrust();
		}

		private bool RepositionAircraftOnGround(AircraftScript aircraftScript, ref Bounds bounds, float? threshold = null)
		{
			if (aircraftScript.Children.childCount > 0)
			{
				float num = bounds.min.y - 1.75f;
				float num2 = (bounds.min.x + bounds.max.x) / 2f;
				float num3 = (bounds.min.z + bounds.max.z) / 2f;
				float valueOrDefault = threshold.GetValueOrDefault();
				if (Mathf.Abs(num2) > valueOrDefault || Mathf.Abs(num) > valueOrDefault || Mathf.Abs(num3) > valueOrDefault)
				{
					Vector3 vector = new Vector3(num2, num, num3);
					Tools.SelectedTool?.OnAircraftRepositionStart(-vector);
					aircraftScript.transform.position -= vector;
					bounds = new Bounds(bounds.center - vector, bounds.size);
					UpdatePaintOrigin(-vector);
					Physics.SyncTransforms();
					Tools.SelectedTool?.OnAircraftRepositionEnd(-vector);
					return true;
				}
			}
			return false;
		}

		private void SelectPart(PartScript part, bool focus, RaycastHit? rayHit = null)
		{
			SelectPart(part);
			if (!focus || !(part != null))
			{
				return;
			}
			CenterViewOnPart(part);
			if (Tools.SelectedTool == Tools.ViewTool)
			{
				return;
			}
			if (part.HasModifier<WingScript>())
			{
				Tools.SelectWingAdjustmentTool();
			}
			else if (part.HasModifier<JWingScript>() || part.HasModifier<ControlSurfacePartScript>())
			{
				Tools.SelectJWingAdjustmentTool();
				if (rayHit.HasValue)
				{
					Tools.JWingTool.SelectSliceFromRayHit(rayHit.Value);
				}
			}
			else if (part.HasModifier<FuselageScript>())
			{
				Tools.StartFuselageTool();
			}
			else if (part.HasModifier<JFuselageScript>())
			{
				Tools.SelectTool(Tools.JFuselageTool);
			}
			else if (part.HasModifier<TrapezoidMeshModifierScript>())
			{
				Tools.SelectTool(Tools.TrapezoidShapeTool);
			}
			else
			{
				Tools.SelectMovePartTool();
				DesignerScript.DesignerUI.Flyouts.Selected = DesignerScript.DesignerUI.Flyouts.PartProperties;
			}
		}

		private void SelectPart(PartScript value)
		{
			if (!(value != _selectedPart))
			{
				return;
			}
			if (_selectedPart != null)
			{
				_selectedPart.IsSelected = false;
				_selectedPart.PartMaterialScript.SetSelected(selected: false, updateSymmetricParts: true);
				if (GhostViewEnabled)
				{
					_selectedPart.PartMaterialScript.IsHidden = true;
				}
			}
			_selectedPart = value;
			if (_selectedPart != null)
			{
				_selectedPart.IsSelected = true;
				if (Tools.SelectedTool.ShowSelectionHighlight)
				{
					_selectedPart.PartMaterialScript.SetSelected(selected: true, updateSymmetricParts: true);
				}
				if (GhostViewEnabled)
				{
					_selectedPart.PartMaterialScript.IsHidden = false;
				}
				Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerSelectPart);
			}
			if (this.SelectedPartChangedEvent != null)
			{
				this.SelectedPartChangedEvent(value);
			}
		}

		private IEnumerator StartFlightCoroutine()
		{
			yield return null;
			CrashDetection.SetFlag();
			DesignerScript.SaveDesignerCraft();
			_cameraTarget = CameraController.TargetPosition;
			_cameraPosition = CameraController.Camera.transform.position;
			_cameraRotation = CameraController.Camera.transform.rotation;
			if (Game.Instance.SceneManager.InFlightScene)
			{
				FlightSceneScript instance = FlightSceneScript.Instance;
				instance.LocalPlayer.NetworkPlayer.CraftId = "__editor__.xml";
				instance.LocalPlayer.SpawnAircraft();
				instance.Designer.Exit();
			}
			else
			{
				Game.Instance.SceneManager.LoadFlight("Designer");
			}
		}

		private IEnumerator UpdateAdaptiveBlockStates()
		{
			yield return new WaitForEndOfFrame();
			AdaptiveBlockScript.UpdateAdaptiveBlockStates(Aircraft.Parts);
		}
	}
}
