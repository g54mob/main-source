using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using Assets.Scripts.DebugScripts;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using ModApi.Ui.Inspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityFS;

namespace Assets.Scripts.Craft.Parts.Modifiers.Wing
{
	public class WingScript : PartModifierScript<WingData>, IAnalyzePerformance, IFlightStart, IGameLoopItem, IFlightUpdate, IDesignerStart
	{
		public delegate void WingUpdatedDelegate(WingScript wing);

		public enum WingPointType
		{
			RootLeadingEdge = 0,
			RootTrailingEdge = 1,
			TipLeadingEdge = 2,
			TipTrailingEdge = 3,
			TipPosition = 4,
			Thickness = 5
		}

		private static bool _showLiftVectorGlobal;

		private Aerofoil _aerofoil;

		private GameObject _colSphereGameObject;

		[SerializeField]
		private bool _debugEnabled;

		private MeshFilter _meshFilter;

		private bool _occluded;

		private IPartScript _part;

		private bool _suppressUpdateEvent;

		[Range(1f, 100f)]
		[SerializeField]
		private float _vectorGizmosScale = 1f;

		private MeshCollider _wingCollider;

		private WingMeshBuilder _wingMeshBuilder;

		private AttachPointScript _wingBaseAttachPoint;

		private AttachPointScript _wingTipAttachPoint;

		public static bool DrawCenterOfLiftBalls { get; set; }

		public static bool DrawCenterOfLiftBallsProportionalToMagnitude { get; set; }

		public static bool ShowLiftVectorGlobal
		{
			get
			{
				return _showLiftVectorGlobal;
			}
			set
			{
				DebugGizmos.DestroyAll();
				_showLiftVectorGlobal = value;
			}
		}

		public float AngleOfAttack { get; set; }

		public List<ControlSurfaceScript> ControlSurfaces { get; private set; }

		public bool DebugEnabled => _debugEnabled;

		public float DihedralAngle => Mathf.Atan2(base.Data.TipPosition.x, base.Data.TipPosition.y) * 57.29578f;

		public Vector3 Forward => base.transform.forward;

		public bool InvertAirfoil { get; set; }

		public bool IsWingTipAttached => base.Data.Part.AttachPoints[0].NumPartConnections > 0;

		public AudioSource JointCreakAudioSource { get; set; }

		public Vector3 LiftUp
		{
			get
			{
				if (!InvertAirfoil)
				{
					return Up;
				}
				return -Up;
			}
		}

		public float MaxFuelCapacity => base.Data.MaxFuelCapacity;

		public Mesh Mesh
		{
			get
			{
				return _meshFilter.mesh;
			}
			set
			{
				_meshFilter.mesh = value;
			}
		}

		public bool OnRightSide { get; private set; }

		public Vector3 Right => base.transform.up;

		public Vector3 RootLeadingEdge => Vector3.forward * base.Data.RootLeadingOffset;

		public Vector3 RootTrailingEdge => Vector3.forward * (0f - base.Data.RootTrailingOffset);

		public bool ShowLiftVector { get; private set; }

		public int SimulationSectionCount => Mathf.Clamp((int)(base.Data.WingSpan / base.Data.MinSectionLength), 1, 15);

		public Vector3 Thickness => new Vector3(0.5f * base.Data.Thickness, 0f, 0f);

		public Vector3 TipLeadingEdge => base.Data.TipPosition + Vector3.forward * base.Data.TipLeadingOffset;

		public Vector3 TipTrailingEdge => base.Data.TipPosition + Vector3.forward * (0f - base.Data.TipTrailingOffset);

		public Vector3 Up => base.transform.right;

		public bool UsesMachNumber => false;

		public UnityFS.Wing WingPhysicsScript { get; private set; }

		public Transform WingRoot { get; set; }

		public float WingSweep
		{
			get
			{
				float num = base.Data.RootLeadingOffset - base.Data.BaseChord * 0.5f;
				return base.Data.TipPosition.z + base.Data.TipLeadingOffset - base.Data.TipChord * 0.5f - num;
			}
		}

		public event WingUpdatedDelegate WingUpdated;

		static WingScript()
		{
			SceneManager.activeSceneChanged += OnActiveSceneChanged;
			StaticInitialize();
		}

		public WingScript()
		{
			ControlSurfaces = new List<ControlSurfaceScript>();
		}

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			base.Data.DesignStart();
		}

		public ControlSurfaceScript AddControlSurface(int start, int length, string inputId, int maxDeflectionDegree, bool invert, bool invertOnMirror = false)
		{
			ControlSurfaceScript result = ControlSurfaceData.Create(base.PartScript.Data, start, length, inputId, maxDeflectionDegree, invert, invertOnMirror).CreateScript() as ControlSurfaceScript;
			SortControlSurfaces();
			UpdateWingShape();
			return result;
		}

		public void Awake()
		{
			ControlSurfaces = new List<ControlSurfaceScript>();
			GameObject obj = base.gameObject;
			obj.name = obj.name + "_" + base.gameObject.GetInstanceID();
		}

		public void DeleteControlSurface(ControlSurfaceScript controlSurfaceScript)
		{
			Symmetry.RemovePartModifier(base.PartScript, controlSurfaceScript.Data);
			ControlSurfaces.Remove(controlSurfaceScript);
			_part.PartMaterialScript.RemoveRenderer(controlSurfaceScript.MeshRenderer);
			controlSurfaceScript.Data.RemoveModifier();
		}

		public Vector3 DrawCenterOfLiftOnWing()
		{
			float magnitude;
			return DrawCenterOfLiftOnWing(out magnitude);
		}

		public Vector3 DrawCenterOfLiftOnWing(out float magnitude, CraftScript alternateAircraftToDrawOn = null)
		{
			if (_colSphereGameObject == null)
			{
				_colSphereGameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				_colSphereGameObject.GetComponent<Collider>().enabled = false;
				_colSphereGameObject.GetComponent<MeshRenderer>().material.color = new Color(0f, 0.6f, 0f, 0f);
			}
			Vector3 aerodynamicCenterWorldSpace = WingPhysicsScript.AerodynamicCenterWorldSpace;
			magnitude = WingPhysicsScript.LiftForceMagnitude;
			if (alternateAircraftToDrawOn == null)
			{
				_colSphereGameObject.transform.position = aerodynamicCenterWorldSpace;
			}
			else
			{
				CraftScript componentInParent = base.gameObject.GetComponentInParent<CraftScript>();
				Vector3 vector = componentInParent.CenterOfMass.localPosition - componentInParent.CenterOfMass.InverseTransformPoint(aerodynamicCenterWorldSpace);
				_colSphereGameObject.transform.position = alternateAircraftToDrawOn.CenterOfMass.TransformPoint(alternateAircraftToDrawOn.CenterOfMass.localPosition - vector);
			}
			if (DrawCenterOfLiftBallsProportionalToMagnitude)
			{
				float num = Mathf.Max(magnitude * 0.01f, 0.13f);
				_colSphereGameObject.transform.localScale = new Vector3(num, num, num);
			}
			return _colSphereGameObject.transform.position;
		}

		public Vector3 FindPylonPosition(Vector3 worldPosition)
		{
			Vector3 position = base.transform.InverseTransformPoint(worldPosition);
			position.x = Utilities.SnapToGrid(position.x, 0.125f);
			position.y = Utilities.SnapToGrid(position.y, 0.125f);
			position.z = Utilities.SnapToGrid(position.z, 0.125f);
			return base.transform.TransformPoint(position);
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			UpdateInverted();
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			if (WingPhysicsScript != null && base.Data.WingPhysicsEnabled)
			{
				bool isOccluded = base.PartScript.Data.PartDrag.IsOccluded;
				if (_occluded != isOccluded)
				{
					_occluded = isOccluded;
					WingPhysicsScript.gameObject.SetActive(!_occluded);
				}
				WingPhysicsScript.FluidDensity = Mathf.Lerp(Mathf.Clamp(_part.CraftScript.AtmosphereSample.AirDensity, 0f, 5f), 10f, base.PartScript.WaterPhysics.UnderWaterAmount);
			}
		}

		public override float GetEstimatedDragForce()
		{
			if (base.Data.WingPhysicsEnabled && WingPhysicsScript != null)
			{
				return WingPhysicsScript.DragForceMagnitude;
			}
			return 0f;
		}

		public bool GetNextControlSurfaceSpot(out int start, out int length)
		{
			bool[] array = new bool[SimulationSectionCount];
			foreach (ControlSurfaceScript controlSurface in ControlSurfaces)
			{
				for (int i = controlSurface.Data.Start; i < controlSurface.Data.End; i++)
				{
					array[i] = true;
				}
			}
			int num = -1;
			int num2 = 0;
			for (int num3 = array.Length - 1; num3 >= 0; num3--)
			{
				if (!array[num3])
				{
					num = num3;
					num2++;
				}
				else
				{
					if (num >= 0)
					{
						break;
					}
					num2 = 0;
				}
			}
			if (num >= 0)
			{
				start = num;
				length = num2;
				return true;
			}
			start = 0;
			length = 0;
			return false;
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			OnCraftStructureChanged(craftScript);
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			if (Game.InDesignerScene)
			{
				UpdateInverted();
			}
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			if (base.Data.WingPhysicsEnabled && WingPhysicsScript != null)
			{
				model.Add(new TextModel("Lift Force", () => Units.GetForceString(WingPhysicsScript.LiftForceMagnitude) ?? ""));
				model.Add(new TextModel("Drag Force", () => Units.GetForceString(WingPhysicsScript.DragForceMagnitude) ?? ""));
				model.Add(new TextModel("AoA", () => Units.GetAngleString(WingPhysicsScript.AngleOfAttack, 2) ?? ""));
			}
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			groupModel.Add(new TextModel("Area", () => Units.GetDistanceString(base.Data.WingArea, useAbsoluteValue: true, Units.UnitPrecisionMode.Normal, isArea: true), null, "The area of the wing."));
			groupModel.Add(new TextModel("Span", () => Units.GetDistanceString(base.Data.WingSpan), null, "The length of the wing."));
			groupModel.Add(new TextModel("Thickness", () => Units.GetDistanceString(base.Data.Thickness), null, "The thickness of the wing."));
			groupModel.Add(new TextModel("Snap Point", () => Units.GetForceString(base.Data.WingStrength), null, "The amount of force under which the wing would snap."));
			groupModel.Add(new CurveModel("Drag Coefficients", () => WingPhysicsScript.CD, delegate(AnimationCurve value)
			{
				base.Data.CDrag = value;
			}));
			groupModel.Add(new CurveModel("Lift Coefficients", () => WingPhysicsScript.CL, delegate(AnimationCurve value)
			{
				base.Data.CLift = value;
			}));
		}

		public override void OnPartDestroyed()
		{
			base.OnPartDestroyed();
			UpdateEventSubscriptions(subscribe: false);
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			UpdateWing();
		}

		public void RegisterControlSurface(ControlSurfaceScript controlSurfaceScript)
		{
			ControlSurfaces.Add(controlSurfaceScript);
			UpdateWingShape();
		}

		public Vector3 SnapWingPoint(Vector3 position, WingPointType wingPointType)
		{
			float num = Game.Instance.Settings.Game.Designer.GridSize;
			float y = 0f;
			float num2 = position.z;
			float num3 = 12.5f;
			float num4 = 0.5f;
			float num5 = 50f;
			IGameStateValidator validator = Game.Instance.GameState.Validator;
			if (validator.IsCareerMode)
			{
				num3 = Mathf.Min(validator.ItemValue("Wing.Edge"), num3);
				num4 = Mathf.Min(0.5f * validator.ItemValue("Wing.Thickness"), num4);
				num5 = Mathf.Min(validator.ItemValue("Wing.Length"), num5);
			}
			switch (wingPointType)
			{
			case WingPointType.TipPosition:
				y = Mathf.Clamp(Utilities.SnapToGrid(position.y, num), 0.01f, num5);
				break;
			case WingPointType.TipLeadingEdge:
			case WingPointType.TipTrailingEdge:
				num2 -= base.Data.TipPosition.z;
				break;
			default:
				return new Vector3(Mathf.Clamp(Utilities.SnapToGrid(position.x, num * 0.5f), 0.01f, num4), 0f, 0f);
			case WingPointType.RootLeadingEdge:
			case WingPointType.RootTrailingEdge:
				break;
			}
			num2 = Mathf.Clamp(Utilities.SnapToGrid(num2, num), 0f - num3, num3);
			return new Vector3(0f, y, num2);
		}

		public void SortControlSurfaces()
		{
			for (int i = 0; i < ControlSurfaces.Count; i++)
			{
				for (int j = i + 1; j < ControlSurfaces.Count; j++)
				{
					if (ControlSurfaces[i].Data.Start > ControlSurfaces[j].Data.Start)
					{
						List<ControlSurfaceScript> controlSurfaces = ControlSurfaces;
						int index = j;
						List<ControlSurfaceScript> controlSurfaces2 = ControlSurfaces;
						int index2 = i;
						ControlSurfaceScript controlSurfaceScript = ControlSurfaces[i];
						ControlSurfaceScript controlSurfaceScript2 = ControlSurfaces[j];
						ControlSurfaceScript controlSurfaceScript3 = (controlSurfaces[index] = controlSurfaceScript);
						controlSurfaceScript3 = (controlSurfaces2[index2] = controlSurfaceScript2);
					}
				}
			}
		}

		public void UnregisterControlSurface(ControlSurfaceScript controlSurfaceScript)
		{
			ControlSurfaces.Remove(controlSurfaceScript);
			if (Game.InDesignerScene)
			{
				UpdateWingShape();
			}
		}

		public void Update()
		{
			if (base.Data.WingPhysicsEnabled && (ShowLiftVector || ShowLiftVectorGlobal))
			{
				UpdateLiftVectorLine();
				WingPhysicsScript.DebugEnabled = DebugEnabled;
			}
		}

		public void UpdateAirfoil(string airfoil)
		{
			if (base.Data.Version > 2)
			{
				IResourceLoader resourceLoader = Game.Instance.ResourceLoader;
				_aerofoil = resourceLoader.LoadAirfoil(airfoil switch
				{
					"Flat Bottom" => "Clark-Y", 
					"Semi-Symmetric" => "NACA23012", 
					"Symmetric" => "NACA0012", 
					"Fin" => "NACAFIN", 
					_ => airfoil, 
				});
			}
			else
			{
				IResourceLoader resourceLoader = Game.Instance.ResourceLoader;
				_aerofoil = resourceLoader.LoadAirfoil(airfoil switch
				{
					"Flat Bottom" => "NACA23016", 
					"Semi-Symmetric" => "NACA23015", 
					"Symmetric" => "NACA0009", 
					"Fin" => "NACAFIN", 
					_ => airfoil, 
				});
			}
		}

		public void UpdateWing()
		{
			_suppressUpdateEvent = true;
			UpdateInverted();
			_suppressUpdateEvent = false;
			float num = 0f;
			for (int i = 0; i < ControlSurfaces.Count; i++)
			{
				num += (float)Math.Abs(ControlSurfaces[i].Data.End - ControlSurfaces[i].Data.Start);
			}
			base.Data.ControlSurfacePriceMultiplier = 1f + 0.05f * (float)ControlSurfaces.Count + 0.1f * num * base.Data.HingeDistanceFromTrailingEdge;
			RaiseWingUpdatedIfAppropriate();
		}

		public void UpdateWingPoint(Vector3 position, WingPointType wingPointType, bool propagate = true, bool snap = true)
		{
			WingScript wingScript = null;
			AttachPoint attachPoint = ((!propagate) ? null : ((wingPointType != WingPointType.RootLeadingEdge && wingPointType != WingPointType.RootTrailingEdge) ? base.PartScript.AttachPointScripts.Where((AttachPointScript x) => !x.AttachPoint.CanSeek && !x.AttachPoint.IsSurfaceAttachPoint).First().AttachPoint : base.PartScript.AttachPointScripts.Where((AttachPointScript x) => x.AttachPoint.CanSeek && !x.AttachPoint.IsSurfaceAttachPoint).First().AttachPoint));
			if (attachPoint != null && attachPoint.PartConnections.Count > 0)
			{
				wingScript = attachPoint.PartConnections[0].GetOtherPart(base.PartScript.Data).PartScript.GetModifier<WingScript>();
				if (wingScript != null && (!wingScript.Data.AutoResize || attachPoint.PartConnections[0].Attachments[0].AttachPointB.IsSurfaceAttachPoint))
				{
					wingScript = null;
				}
			}
			if (snap)
			{
				position = SnapWingPoint(position, wingPointType);
			}
			float num = 0f;
			switch (wingPointType)
			{
			case WingPointType.RootLeadingEdge:
				num = position.z - base.Data.RootLeadingOffset;
				if (position.z < 0.05f && num < 0f)
				{
					base.transform.position += base.transform.TransformVector(new Vector3(0f, 0f, num));
					base.Data.RootTrailingOffset = Mathf.Max(0.05f, base.Data.RootTrailingOffset + num);
					UpdateWingPoint(base.Data.TipPosition - new Vector3(0f, 0f, num), WingPointType.TipPosition);
					Symmetry.UpdatePartPositions(new List<IPartScript> { base.PartScript });
				}
				else
				{
					base.Data.RootLeadingOffset = position.z;
				}
				if (wingScript != null)
				{
					wingScript.UpdateWingPoint(wingScript.transform.InverseTransformPoint(base.transform.position) + position, WingPointType.TipLeadingEdge, propagate: false);
					UpdateWingPoint(new Vector3(0.5f * wingScript.Data.Thickness * wingScript.Data.TipChord / wingScript.Data.BaseChord, 0f, 0f), WingPointType.Thickness, propagate: true, snap: false);
					Symmetry.SynchronizePartModifiers(wingScript.PartScript);
				}
				else
				{
					UpdateWingPoint(new Vector3(0.5f * base.Data.Thickness, 0f, 0f), WingPointType.Thickness, propagate: true, snap: false);
				}
				break;
			case WingPointType.RootTrailingEdge:
				num = position.z - base.Data.RootTrailingOffset;
				if (0f - position.z < 0.05f && num > 0f)
				{
					base.transform.position += base.transform.TransformVector(new Vector3(0f, 0f, num));
					base.Data.RootLeadingOffset = Mathf.Max(0.05f, base.Data.RootLeadingOffset - num);
					UpdateWingPoint(base.Data.TipPosition - new Vector3(0f, 0f, num), WingPointType.TipPosition);
					Symmetry.UpdatePartPositions(new List<IPartScript> { base.PartScript });
				}
				else
				{
					base.Data.RootTrailingOffset = 0f - position.z;
				}
				if (wingScript != null)
				{
					wingScript.UpdateWingPoint(wingScript.transform.InverseTransformPoint(base.transform.position) + position, WingPointType.TipTrailingEdge, propagate: false);
					UpdateWingPoint(new Vector3(0.5f * wingScript.Data.Thickness * wingScript.Data.TipChord / wingScript.Data.BaseChord, 0f, 0f), WingPointType.Thickness, propagate: true, snap: false);
					Symmetry.SynchronizePartModifiers(wingScript.PartScript);
				}
				else
				{
					UpdateWingPoint(new Vector3(0.5f * base.Data.Thickness, 0f, 0f), WingPointType.Thickness, propagate: true, snap: false);
				}
				break;
			case WingPointType.TipLeadingEdge:
				base.Data.TipLeadingOffset = position.z;
				if (position.z < 0f)
				{
					base.Data.TipLeadingOffset = 0f;
					base.Data.TipTrailingOffset = Mathf.Max(0f, base.Data.TipTrailingOffset + position.z);
					UpdateWingPoint(base.Data.TipPosition + new Vector3(0f, 0f, position.z), WingPointType.TipPosition);
				}
				if (wingScript != null)
				{
					wingScript.UpdateWingPoint(new Vector3(base.Data.Thickness * base.Data.TipChord / base.Data.BaseChord * 0.5f, 0f, 0f), WingPointType.Thickness, propagate: true, snap: false);
					wingScript.UpdateWingPoint(wingScript.transform.InverseTransformPoint(base.transform.position) + position + base.Data.TipPosition, WingPointType.RootLeadingEdge, propagate: false);
					Symmetry.SynchronizePartModifiers(wingScript.PartScript);
				}
				break;
			case WingPointType.TipTrailingEdge:
				base.Data.TipTrailingOffset = 0f - position.z;
				if (position.z > 0f)
				{
					base.Data.TipTrailingOffset = 0f;
					base.Data.TipLeadingOffset = Mathf.Max(0f, base.Data.TipLeadingOffset - position.z);
					UpdateWingPoint(base.Data.TipPosition + new Vector3(0f, 0f, position.z), WingPointType.TipPosition);
				}
				if (wingScript != null)
				{
					wingScript.UpdateWingPoint(new Vector3(base.Data.Thickness * base.Data.TipChord / base.Data.BaseChord * 0.5f, 0f, 0f), WingPointType.Thickness, propagate: true, snap: false);
					wingScript.UpdateWingPoint(wingScript.transform.InverseTransformPoint(base.transform.position) + position + base.Data.TipPosition, WingPointType.RootTrailingEdge, propagate: false);
					Symmetry.SynchronizePartModifiers(wingScript.PartScript);
				}
				break;
			case WingPointType.Thickness:
				base.Data.Thickness = 2f * position.x;
				if (wingScript != null)
				{
					wingScript.UpdateWingPoint(new Vector3(base.Data.Thickness * base.Data.TipChord / base.Data.BaseChord * 0.5f, 0f, 0f), WingPointType.Thickness, propagate: true, snap: false);
					Symmetry.SynchronizePartModifiers(wingScript.PartScript);
				}
				break;
			case WingPointType.TipPosition:
			{
				float num2 = 0.05f;
				base.Data.TipPosition = ((position.y > num2) ? position : position.SetY(num2));
				break;
			}
			}
			UpdateWing();
		}

		public void UpdateWingShape()
		{
			WingData data = base.Data;
			for (int i = 0; i < ControlSurfaces.Count; i++)
			{
				for (int j = i + 1; j < ControlSurfaces.Count; j++)
				{
					if (ControlSurfaces[i].Data.Start > ControlSurfaces[j].Data.Start)
					{
						List<ControlSurfaceScript> controlSurfaces = ControlSurfaces;
						int index = j;
						List<ControlSurfaceScript> controlSurfaces2 = ControlSurfaces;
						int index2 = i;
						ControlSurfaceScript controlSurfaceScript = ControlSurfaces[i];
						ControlSurfaceScript controlSurfaceScript2 = ControlSurfaces[j];
						ControlSurfaceScript controlSurfaceScript3 = (controlSurfaces[index] = controlSurfaceScript);
						controlSurfaceScript3 = (controlSurfaces2[index2] = controlSurfaceScript2);
					}
				}
			}
			if (data.IsStylish)
			{
				data.ThicknessDelta = _aerofoil.ThicknessDelta;
				data.ThicknessOffset = _aerofoil.ThicknessOffset;
				data.LeadingBulge = _aerofoil.LeadingBulge;
				data.ThicknessTip = data.Thickness * data.TipChord / data.BaseChord;
			}
			_wingMeshBuilder.UpdateMesh();
			float z = data.RootLeadingOffset - data.BaseChord * 0.5f;
			WingRoot.SetLocalPositionAndRotation(new Vector3(0f, 0f, z), Quaternion.Euler(new Vector3(0f, AngleOfAttack, 0f - DihedralAngle)));
			_wingCollider.sharedMesh = _wingMeshBuilder.BuildColliderMesh();
			if (Game.InDesignerScene)
			{
				_wingTipAttachPoint.transform.localPosition = data.TipPosition;
				_wingTipAttachPoint.AttachPoint.Position = data.TipPosition;
				float min = Mathf.Clamp(Mathf.Sqrt(data.Thickness), 0.1f, 2f);
				_wingBaseAttachPoint.AttachPoint.Scale = Mathf.Clamp(0.25f * data.BaseChord, min, 2f);
				_wingTipAttachPoint.AttachPoint.Scale = Mathf.Clamp(0.25f * data.TipChord, min, 2f);
			}
			ControlSurfaceScript[] array = ControlSurfaces.ToArray();
			foreach (ControlSurfaceScript controlSurfaceScript6 in array)
			{
				if (controlSurfaceScript6.Data.Start >= SimulationSectionCount)
				{
					DeleteControlSurface(controlSurfaceScript6);
				}
				else if (controlSurfaceScript6.Data.End > SimulationSectionCount)
				{
					controlSurfaceScript6.Data.End = SimulationSectionCount;
				}
			}
			float num = 0.70710677f;
			float num2 = Math.Min(data.TipChord, data.BaseChord) * data.WingSpan;
			float num3 = Math.Abs(data.BaseChord - data.TipChord) * data.WingSpan / 2f;
			float num4 = data.WingSpan * (num2 * 0.5f + num3 * num) / (num2 + num3);
			Vector3 position = default(Vector3);
			position.x = 0f;
			position.z = WingSweep / 2f;
			if (data.BaseChord < data.TipChord)
			{
				position.y = num4;
			}
			else
			{
				position.y = data.WingSpan - num4;
			}
			position = WingRoot.TransformPoint(position);
			position = _part.GameObject.transform.InverseTransformPoint(position);
			_part.Data.Config.CenterOfMass = position;
			if (Game.InDesignerScene)
			{
				data.UpdateFuel();
			}
			else
			{
				data.InitialiseStyles();
			}
			base.PartScript.InitializeColliders();
			RaiseWingUpdatedIfAppropriate();
			if (Game.InDesignerScene)
			{
				WingPhysicsScript?.UpdateStaticAerodynamicCenter();
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_part = base.PartScript;
			WingRoot = new GameObject("WingRoot").transform;
			WingRoot.gameObject.layer = 31;
			WingRoot.parent = _part.GameObject.transform;
			UpdateAirfoil(base.Data.Airfoil);
			GameObject gameObject = new GameObject("Mesh");
			gameObject.layer = 31;
			gameObject.transform.parent = WingRoot;
			_meshFilter = gameObject.AddComponent<MeshFilter>();
			MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
			if (Game.InDesignerScene)
			{
				_wingTipAttachPoint = _part.AttachPointScripts[0];
				_wingBaseAttachPoint = _part.AttachPointScripts[1];
			}
			_wingCollider = base.transform.Find("Collider").GetComponent<MeshCollider>();
			if (_wingCollider == null)
			{
				Debug.Log("You fucked up");
			}
			_wingCollider.transform.SetParent(WingRoot, worldPositionStays: false);
			GameObject gameObject2 = new GameObject("WingPhysics");
			gameObject2.layer = 31;
			gameObject2.transform.parent = WingRoot;
			WingPhysicsScript = gameObject2.AddComponent<UnityFS.Wing>();
			WingPhysicsScript.SimulateRealtime = Game.InFlightScene;
			_wingMeshBuilder = new WingMeshBuilder(this, _part.PartMaterialScript);
			UpdateInverted();
			WingPhysicsScript.PartScript = base.PartScript;
			WingPhysicsScript.gameObject.SetActive(base.Data.WingPhysicsEnabled);
			UpdateEventSubscriptions(subscribe: true);
			_part.PartMaterialScript.AddRenderer(renderer);
		}

		private static void OnActiveSceneChanged(Scene newScene, Scene oldScene)
		{
			StaticInitialize();
		}

		private static void StaticInitialize()
		{
			DrawCenterOfLiftBalls = true;
			DrawCenterOfLiftBallsProportionalToMagnitude = true;
			_showLiftVectorGlobal = false;
		}

		private bool IsOnRightSide()
		{
			if (base.Data.CraftSide == WingData.CraftSideType.Auto && base.PartScript.CraftScript?.PrimaryCommandPod != null)
			{
				bool flag = Vector3.Dot(Up, base.PartScript.CraftScript.PrimaryCommandPod.PilotSeatOrientation.up) < -0.01f;
				if (Game.InFlightScene)
				{
					base.Data.CraftSide = (flag ? WingData.CraftSideType.Right : WingData.CraftSideType.Left);
				}
				return flag;
			}
			return base.Data.CraftSide == WingData.CraftSideType.Right;
		}

		private void OnDataInvertAirfoilChanged(bool newVal, bool oldVal)
		{
			UpdateInverted();
		}

		private void RaiseWingUpdatedIfAppropriate()
		{
			if (!_suppressUpdateEvent)
			{
				this.WingUpdated?.Invoke(this);
			}
		}

		private void UpdateEventSubscriptions(bool subscribe)
		{
			if (subscribe)
			{
				base.Data.InvertAirfoilChanged += OnDataInvertAirfoilChanged;
			}
			else
			{
				base.Data.InvertAirfoilChanged -= OnDataInvertAirfoilChanged;
			}
		}

		private void UpdateInverted()
		{
			OnRightSide = IsOnRightSide();
			InvertAirfoil = (base.Data.InvertAirfoil ? (!OnRightSide) : OnRightSide);
			if (base.Data.WingPhysicsEnabled)
			{
				WingPhysicsScript.transform.localScale = new Vector3(InvertAirfoil ? base.Data.WingSpan : (0f - base.Data.WingSpan), 1f, base.Data.BaseChord);
				WingPhysicsScript.transform.SetLocalPositionAndRotation(new Vector3(0f, base.Data.WingSpan * 0.5f), Quaternion.Euler(new Vector3(0f, 0f, InvertAirfoil ? 90 : (-90))));
				UpdateWingPhysics();
			}
			UpdateWingShape();
			RaiseWingUpdatedIfAppropriate();
		}

		private void UpdateLiftVectorLine()
		{
			Vector3 vector2;
			Vector3 vector5;
			if (Game.InFlightScene)
			{
				float num = _vectorGizmosScale * (DebugEnabled ? 1f : 0.01f);
				Vector3 vector = 5f * base.Data.Thickness * (InvertAirfoil ? (-base.transform.right) : base.transform.right);
				Vector3 liftForceVector = WingPhysicsScript.LiftForceVector;
				float num2 = liftForceVector.magnitude * num;
				vector2 = liftForceVector.normalized * num2;
				Vector3 dragForceVector = WingPhysicsScript.DragForceVector;
				float num3 = dragForceVector.magnitude * num;
				Vector3 vector3 = dragForceVector.normalized * num3;
				Vector3 momentumForceVector = WingPhysicsScript.MomentumForceVector;
				float num4 = momentumForceVector.magnitude * num;
				Vector3 vector4 = momentumForceVector.normalized * num4;
				vector5 = WingPhysicsScript.AerodynamicCenterWorldSpace + base.PartScript.BodyScript.RigidBody.velocity * Time.fixedDeltaTime;
				DebugGizmos.DrawRay(base.gameObject.name + " - Drag", vector5 + vector, vector3, Color.red);
				DebugGizmos.DrawRay(base.gameObject.name + " - Moment", vector5 + vector, vector4, Color.blue);
			}
			else
			{
				vector5 = WingPhysicsScript.transform.TransformPoint(WingPhysicsScript.AerodynamicCenterLocalSpace);
				vector2 = LiftUp * 2f;
			}
			DebugGizmos.DrawRay(base.gameObject.name + " - Lift", vector5, vector2, Color.green);
		}

		private void UpdateWingPhysics()
		{
			int num = SimulationSectionCount;
			if (base.PartScript.Data.GetModifier<ControlSurfaceData>() == null)
			{
				num = ((!base.Data.AllowControlSurfaces) ? 1 : (num / 2));
			}
			if (num < 1)
			{
				num = 1;
			}
			WingPhysicsScript.SectionCount = num;
			WingPhysicsScript.WingTipSweep = WingSweep;
			WingPhysicsScript.WingTipAngle = 0f;
			if (base.Data.BaseChord > 0f)
			{
				WingPhysicsScript.WingTipWidthZeroToOne = base.Data.TipChord / base.Data.BaseChord;
			}
			else
			{
				WingPhysicsScript.WingTipWidthZeroToOne = 0f;
			}
			WingPhysicsScript.CD = base.Data.CDrag ?? _aerofoil.CD;
			WingPhysicsScript.CL = base.Data.CLift ?? _aerofoil.CL;
			WingPhysicsScript.CM = _aerofoil.CM;
			WingPhysicsScript.MaxBreakForce = base.Data.WingStrength;
			WingPhysicsScript.Version = base.Data.Version;
		}
	}
}
