using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Jundroo.Common.Utils;
using UnityEngine;
using UnityFS;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class WingScript : PartModifierScript, IVariableOutput, IWingScript
	{
		public delegate void WingUpdatedDelegate(WingScript wing);

		public enum WingPointType
		{
			RootLeadingEdge = 0,
			RootTrailingEdge = 1,
			TipLeadingEdge = 2,
			TipTrailingEdge = 3,
			TipPosition = 4
		}

		public bool WingPhysicsEnabled = true;

		private GameObject _colSphereGameObject;

		private float _currentAngleOfAttack;

		private MeshFilter _meshFilter;

		private PartScript _part;

		private Vector3 _structuralPanelDragForce;

		private GameObject _wingAttachTipGameObject;

		private MeshCollider _wingCollider;

		private WingMeshBuilder _wingMeshBuilder;

		private GameObject _wingTipConnector;

		public static bool DrawCenterOfLiftBalls { get; set; }

		public static bool DrawCenterOfLiftBallsProportionalToMagnitude { get; set; }

		public float AngleOfAttack { get; set; }

		public List<ControlSurfaceScript> ControlSurfaces { get; private set; }

		public float DihedralAngle => Mathf.Atan2(Wing.TipPosition.x, Wing.TipPosition.y) * 57.29578f;

		public bool IsWingTipAvailable => _part.AttachPointScripts[1].AttachPoint.IsAvailable;

		public AudioSource JointCreakAudioSource { get; set; }

		public float MaxFuelCapacity
		{
			get
			{
				float num = (Wing.BaseChord - 0.5f + Wing.TipChord - 0.5f) / 2f * (Wing.WingSpan - 0.5f);
				if (num < 0f)
				{
					num = 0f;
				}
				float num2 = num * 0.1f * 1000f;
				if (num2 >= 19f)
				{
					return num2;
				}
				return 0f;
			}
		}

		public Mesh Mesh
		{
			get
			{
				return _meshFilter.mesh;
			}
			set
			{
				Mesh mesh = _meshFilter.mesh;
				if (mesh != null)
				{
					UnityEngine.Object.Destroy(mesh);
				}
				_meshFilter.mesh = value;
				string text = value.name;
				Mesh mesh2 = _meshFilter.mesh;
				value.name = text;
				if (value != mesh2)
				{
					Debug.LogWarning($"Wing mesh leaked. Original: {value.name} ({value.GetInstanceID()}), After Assignment: {mesh2.name} ({mesh2.GetInstanceID()})");
				}
				base.PartScript.ReinitializeCraftDecalRenderers();
			}
		}

		public Vector3 RootLeadingEdge => Vector3.forward * Wing.RootLeadingOffset;

		public Vector3 RootTrailingEdge => Vector3.forward * (0f - Wing.RootTrailingOffset);

		public int SimulationSectionCount => Wing.SimulationSectionCount;

		public Vector3 TipLeadingEdge => Wing.TipPosition + Vector3.forward * Wing.TipLeadingOffset;

		public Vector3 TipTrailingEdge => Wing.TipPosition + Vector3.forward * (0f - Wing.TipTrailingOffset);

		public WingData Wing { get; set; }

		public float WingAreaProjectedOnGround
		{
			get
			{
				Vector3 vector = base.transform.TransformPoint(RootLeadingEdge);
				Vector3 vector2 = base.transform.TransformPoint(TipLeadingEdge);
				float num = Mathf.Abs(vector.x - vector2.x);
				return (Wing.BaseChord + Wing.TipChord) / 2f * num;
			}
		}

		public Wing WingPhysicsScript { get; set; }

		public Transform WingRoot { get; set; }

		public float WingSweep
		{
			get
			{
				float num = Wing.RootLeadingOffset - Wing.BaseChord / 2f;
				return Wing.TipPosition.z + Wing.TipLeadingOffset - Wing.TipChord / 2f - num;
			}
		}

		float IWingScript.LiftScale => Wing.LiftScale;

		bool IWingScript.PhysicsEnabled => WingPhysicsEnabled;

		[VariableOutput("Drag Force")]
		private float DragMag => WingPhysicsScript.DragForceMagnitude / 0.01f;

		[VariableOutput("Lift Force")]
		private float LiftMag => WingPhysicsScript.SignedLiftForceMagnitude / 0.01f;

		public event WingUpdatedDelegate WingUpdated;

		static WingScript()
		{
			DrawCenterOfLiftBalls = false;
			DrawCenterOfLiftBallsProportionalToMagnitude = true;
		}

		public WingScript()
		{
			ControlSurfaces = new List<ControlSurfaceScript>();
		}

		public static WingScript GetWingScriptFromPart(PartScript partScript)
		{
			return partScript.GetModifier<WingScript>();
		}

		float IWingScript.GetArea()
		{
			return Wing.WingArea;
		}

		float IWingScript.GetProjectedAreaMoment(Vector3 axis, out Vector3 centre)
		{
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				WingPhysicsScript.PrecalculateSections();
			}
			WingPhysicsScript.Simulate(applyForces: false);
			base.transform.TransformPoint(RootLeadingEdge);
			Vector3 vector = base.transform.TransformPoint(TipLeadingEdge);
			float magnitude = Vector3.ProjectOnPlane(vector - vector, axis).magnitude;
			centre = WingPhysicsScript.AerodynamicCenterWorldSpace;
			return (Wing.BaseChord + Wing.TipChord) / 2f * magnitude;
		}

		Vector3 IWingScript.GetCentreOfLift(out float lift)
		{
			if (!WingPhysicsEnabled)
			{
				lift = 0f;
				return default(Vector3);
			}
			lift = WingPhysicsScript.LiftForceMagnitude;
			return WingPhysicsScript.AerodynamicCenterWorldSpace;
		}

		public ControlSurfaceScript AddControlSurface(int start, int length, string inputId, int maxDeflectionDegree, bool invert)
		{
			ControlSurfaceData controlSurfaceData = new ControlSurfaceData(start, length, inputId, maxDeflectionDegree, invert);
			Wing.ControlSurfaces.Add(controlSurfaceData);
			return CreateControlSurfaceScript(controlSurfaceData, createPhysics: false);
		}

		public ControlSurfaceScript CreateControlSurfaceScript(ControlSurfaceData controlSurface, bool createPhysics)
		{
			GameObject obj = new GameObject("Control Surface");
			obj.transform.parent = WingRoot.transform;
			obj.transform.localRotation = Quaternion.identity;
			obj.transform.localScale = Vector3.one;
			obj.transform.localPosition = Vector3.zero;
			ControlSurfaceScript controlSurfaceScript = obj.AddComponent<ControlSurfaceScript>();
			controlSurfaceScript.CreateComponents();
			controlSurfaceScript.WingScript = this;
			controlSurfaceScript.ControlSurface = controlSurface;
			DecalTargetScript decalTargetScript = controlSurfaceScript.gameObject.AddComponent<DecalTargetScript>();
			decalTargetScript.AddRenderer(controlSurfaceScript.MeshRenderer);
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				_wingCollider.GetComponent<DecalTargetColliderScript>().DecalTargets.Add(decalTargetScript);
			}
			_part.PartMaterialScript.AddRenderer(controlSurfaceScript.MeshRenderer, null, null, new int[1] { 1 }, excludeFromCombine: true, excludeFromDrag: false);
			ControlSurfaces.Add(controlSurfaceScript);
			controlSurfaceScript.Initialize(_part, createPhysics);
			return controlSurfaceScript;
		}

		public void DeleteControlSurface(ControlSurfaceScript controlSurfaceScript)
		{
			Wing.ControlSurfaces.Remove(controlSurfaceScript.ControlSurface);
			ControlSurfaces.Remove(controlSurfaceScript);
			_part.PartMaterialScript.RemoveRenderer(controlSurfaceScript.MeshRenderer, destroy: true);
			controlSurfaceScript.transform.parent = null;
			UnityEngine.Object.Destroy(controlSurfaceScript.gameObject);
		}

		public Vector3 DrawCenterOfLiftOnWing()
		{
			float magnitude;
			return DrawCenterOfLiftOnWing(out magnitude);
		}

		public Vector3 DrawCenterOfLiftOnWing(out float magnitude, AircraftScript alternateAircraftToDrawOn = null)
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
				AircraftScript componentInParent = base.transform.GetComponentInParent<AircraftScript>(includeInactive: true);
				Vector3 vector = componentInParent.MainCockpit.transform.localPosition - componentInParent.MainCockpit.transform.InverseTransformPoint(aerodynamicCenterWorldSpace);
				_colSphereGameObject.transform.position = alternateAircraftToDrawOn.MainCockpit.transform.TransformPoint(alternateAircraftToDrawOn.MainCockpit.transform.localPosition - vector);
			}
			if (DrawCenterOfLiftBallsProportionalToMagnitude)
			{
				float num = Mathf.Max(magnitude / 10000f, 0.13f);
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

		public void Initialize(PartScript part, bool createPhysics)
		{
			_part = part;
			WingRoot = _part.transform.Find("WingRoot");
			GameObject gameObject = WingRoot.Find("Mesh").gameObject;
			_meshFilter = gameObject.GetComponent<MeshFilter>();
			_wingTipConnector = _part.transform.Find("ConnectionTip").gameObject;
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				_wingAttachTipGameObject = _part.AttachPointScripts[1].gameObject;
			}
			else
			{
				_wingTipConnector.SetActive(value: false);
				_part.transform.Find("ConnectionRoot").gameObject.SetActive(value: false);
			}
			_wingCollider = WingRoot.Find("Collider").GetComponent<MeshCollider>();
			WingPhysicsEnabled = Wing.WingPhysicsEnabled && base.PartScript.PhysicsEnabled;
			GameObject gameObject2 = new GameObject("WingPhysics");
			gameObject2.transform.parent = WingRoot;
			WingPhysicsScript = gameObject2.AddComponent<Wing>();
			WingPhysicsScript.Aircraft = _part.Aircraft;
			WingPhysicsScript.SimulateRealtime = createPhysics;
			WingPhysicsScript.DragScale = base.PartScript.Part.DragScale;
			WingPhysicsScript.LiftScale = Wing.LiftScale;
			UpdateWingPhysics();
			if (createPhysics)
			{
				BodyScript componentInParent = base.transform.GetComponentInParent<BodyScript>(includeInactive: true);
				WingPhysicsScript.GameObjectWithRigidBody = componentInParent.gameObject;
				if (Wing.WingArea < 0.25f)
				{
					WingPhysicsEnabled = false;
				}
			}
			foreach (ControlSurfaceData controlSurface in Wing.ControlSurfaces)
			{
				CreateControlSurfaceScript(controlSurface, createPhysics);
			}
			if (!WingPhysicsEnabled)
			{
				WingPhysicsScript.gameObject.SetActive(value: false);
			}
			PartMaterialScript component = part.GetComponent<PartMaterialScript>();
			_wingMeshBuilder = new WingMeshBuilder(this, component);
			UpdateWingShape();
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (ControlSurfaces != null && ControlSurfaces.Count > 0)
			{
				ControlSurfaceScript controlSurfaceScript = ControlSurfaces[UnityEngine.Random.Range(0, ControlSurfaces.Count)];
				float value = UnityEngine.Random.value;
				if (value < 0.15f * (float)level)
				{
					controlSurfaceScript.Damaged = true;
				}
				else if (value < 0.3f * (float)level)
				{
					controlSurfaceScript.ControlSurface.MaxDeflectionDegree /= 2;
				}
			}
		}

		public Vector3 SnapWingPoint(Vector3 position, WingPointType wingPointType)
		{
			float x = 0f;
			float y = 0f;
			float num = 0f;
			switch (wingPointType)
			{
			case WingPointType.RootLeadingEdge:
				num = Utilities.SnapToGrid(position.z, 0.25f);
				if (num < 0.125f)
				{
					num = 0.125f;
				}
				break;
			case WingPointType.RootTrailingEdge:
				num = Utilities.SnapToGrid(position.z, 0.25f);
				if (num > -0.125f)
				{
					num = -0.125f;
				}
				break;
			case WingPointType.TipLeadingEdge:
				num = Utilities.SnapToGrid(position.z - Wing.TipPosition.z, 0.25f);
				if (num < 0f)
				{
					num = 0f;
				}
				break;
			case WingPointType.TipTrailingEdge:
				num = Utilities.SnapToGrid(position.z - Wing.TipPosition.z, 0.25f);
				if (num > 0f)
				{
					num = 0f;
				}
				break;
			case WingPointType.TipPosition:
				x = Utilities.SnapToGrid(position.x, 0.25f);
				y = Utilities.SnapToGrid(position.y, 0.25f);
				num = Utilities.SnapToGrid(position.z, 0.25f);
				break;
			}
			return new Vector3(x, y, num);
		}

		public void SortControlSurfaces()
		{
			for (int i = 0; i < ControlSurfaces.Count; i++)
			{
				for (int j = i + 1; j < ControlSurfaces.Count; j++)
				{
					if (ControlSurfaces[i].ControlSurface.Start > ControlSurfaces[j].ControlSurface.Start)
					{
						ControlSurfaceScript value = ControlSurfaces[i];
						ControlSurfaces[i] = ControlSurfaces[j];
						ControlSurfaces[j] = value;
					}
				}
			}
		}

		public void UpdateFuel()
		{
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				FuelTankScript modifier = base.PartScript.GetModifier<FuelTankScript>();
				if (modifier != null)
				{
					float fuelPercentage = Wing.FuelPercentage;
					modifier.FuelTank.Capacity = MaxFuelCapacity * fuelPercentage;
					modifier.FuelTank.Fuel = modifier.FuelTank.Capacity;
				}
			}
		}

		public void UpdateOutputs()
		{
		}

		public void UpdateWingPoint(Vector3 position, WingPointType wingPointType, bool snapPosition = true)
		{
			if (snapPosition)
			{
				position = SnapWingPoint(position, wingPointType);
			}
			switch (wingPointType)
			{
			case WingPointType.RootLeadingEdge:
				Wing.RootLeadingOffset = position.z;
				break;
			case WingPointType.RootTrailingEdge:
				Wing.RootTrailingOffset = 0f - position.z;
				break;
			case WingPointType.TipLeadingEdge:
				Wing.TipLeadingOffset = position.z;
				break;
			case WingPointType.TipTrailingEdge:
				Wing.TipTrailingOffset = 0f - position.z;
				break;
			case WingPointType.TipPosition:
				if (snapPosition && position.y < 0.25f)
				{
					position.y = 0.25f;
				}
				Wing.TipPosition = position;
				break;
			}
			UpdateWingPhysics();
			UpdateWingShape();
		}

		public void UpdateWingShape()
		{
			for (int i = 0; i < ControlSurfaces.Count; i++)
			{
				for (int j = i + 1; j < ControlSurfaces.Count; j++)
				{
					if (ControlSurfaces[i].ControlSurface.Start > ControlSurfaces[j].ControlSurface.Start)
					{
						ControlSurfaceScript value = ControlSurfaces[i];
						ControlSurfaces[i] = ControlSurfaces[j];
						ControlSurfaces[j] = value;
					}
				}
			}
			_wingMeshBuilder.UpdateMesh();
			float z = Wing.RootLeadingOffset - Wing.BaseChord / 2f;
			WingRoot.localPosition = new Vector3(0f, 0f, z);
			WingRoot.localRotation = Quaternion.Euler(new Vector3(0f, AngleOfAttack, 0f - DihedralAngle));
			Mesh sharedMesh = _wingCollider.sharedMesh;
			if (sharedMesh != null)
			{
				UnityEngine.Object.Destroy(sharedMesh);
			}
			_wingCollider.sharedMesh = _wingMeshBuilder.BuildColliderMesh();
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				_wingAttachTipGameObject.transform.localPosition = Wing.TipPosition;
				_wingTipConnector.transform.localPosition = Wing.TipPosition;
			}
			ControlSurfaceScript[] array = ControlSurfaces.ToArray();
			foreach (ControlSurfaceScript controlSurfaceScript in array)
			{
				if (controlSurfaceScript.ControlSurface.Start >= SimulationSectionCount)
				{
					DeleteControlSurface(controlSurfaceScript);
				}
				else if (controlSurfaceScript.ControlSurface.End > SimulationSectionCount)
				{
					controlSurfaceScript.ControlSurface.End = SimulationSectionCount;
				}
			}
			float num = 0.70710677f;
			float num2 = Math.Min(Wing.TipChord, Wing.BaseChord) * Wing.WingSpan;
			float num3 = Math.Abs(Wing.BaseChord - Wing.TipChord) * Wing.WingSpan / 2f;
			float num4 = Wing.WingSpan * (num2 * 0.5f + num3 * num) / (num2 + num3);
			Vector3 position = default(Vector3);
			position.x = 0f;
			position.z = WingSweep / 2f;
			if (Wing.BaseChord < Wing.TipChord)
			{
				position.y = num4;
			}
			else
			{
				position.y = Wing.WingSpan - num4;
			}
			position = WingRoot.TransformPoint(position);
			position = _part.transform.InverseTransformPoint(position);
			_part.Part.CenterOfMass = position;
			UpdateFuel();
			this.WingUpdated?.Invoke(this);
		}

		protected virtual void OnDestroy()
		{
			if (_wingCollider.sharedMesh != null)
			{
				UnityEngine.Object.Destroy(_wingCollider.sharedMesh);
				_wingCollider.sharedMesh = null;
			}
		}

		protected virtual void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawRay(_wingCollider.bounds.center, _structuralPanelDragForce * 0.099999994f);
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocalUnpaused);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightLocalUnpaused);
		}

		private static float SnapToGridEdge(float value)
		{
			if (value > 0f)
			{
				return (float)(int)(value / 0.25f) * 0.25f + 0.125f;
			}
			return (float)(int)(value / 0.25f) * 0.25f - 0.125f;
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (!WingPhysicsEnabled && base.PartScript.PhysicsEnabled)
			{
				IRigidBody rigidBody = base.PartScript.Body.RigidBody;
				Vector3 vector = -rigidBody.velocity;
				float num = Vector3.Dot(WingPhysicsScript.transform.up, -vector.normalized);
				Vector3 normalized = vector.normalized;
				_currentAngleOfAttack = num * 90f;
				float num2 = WingPhysicsScript.Aerofoil.CD.Evaluate(_currentAngleOfAttack);
				_structuralPanelDragForce = normalized * (Wing.WingArea * 0.5f * WingPhysicsScript.FluidDensityRatio * num2 * vector.sqrMagnitude * 0.01f);
				rigidBody.AddForceAtPosition(_structuralPanelDragForce, _wingCollider.bounds.center);
			}
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			WingPhysicsScript.WaveDragMultiplier = base.PartScript.Body.DragPhysics.WaveDragMultiplier;
			if (base.PartScript.EstimateOfUnderwaterPercent > 0f)
			{
				float num = Mathf.Clamp(base.PartScript.EstimateOfUnderwaterPercent, 0f, 1f);
				WingPhysicsScript.FluidDensityRatio = _part.Aircraft.AtmosphereSample.AirDensityRatio + 10f * num;
				WingPhysicsScript.Underwater = true;
			}
			else
			{
				WingPhysicsScript.FluidDensityRatio = _part.Aircraft.AtmosphereSample.AirDensityRatio;
				WingPhysicsScript.Underwater = false;
			}
			if (!WingPhysicsEnabled)
			{
				WingPhysicsScript.gameObject.SetActive(value: false);
			}
		}

		private Vector3 UpdatePoint(Vector3 position, Vector3 currentPosition, Vector3 oppositePosition, float minDistance, float maxDistance)
		{
			Vector3 normalized = (currentPosition - oppositePosition).normalized;
			float num = (position - oppositePosition).magnitude;
			if (num < minDistance)
			{
				num = minDistance;
			}
			else if (num > maxDistance)
			{
				num = maxDistance;
			}
			return oppositePosition + normalized * num;
		}

		private void UpdateWingPhysics()
		{
			int physicsSimulationSectionCount = Wing.PhysicsSimulationSectionCount;
			WingPhysicsScript.SectionCount = physicsSimulationSectionCount;
			WingPhysicsScript.WingTipSweep = WingSweep;
			WingPhysicsScript.WingTipAngle = 0f;
			if (Wing.BaseChord > 0f)
			{
				WingPhysicsScript.WingTipWidthZeroToOne = Wing.TipChord / Wing.BaseChord;
			}
			else
			{
				WingPhysicsScript.WingTipWidthZeroToOne = 0f;
			}
			string airfoilName = Wing.Airfoil;
			if (Wing.Airfoil == "Flat Bottom")
			{
				airfoilName = "NACA23016";
			}
			else if (Wing.Airfoil == "Semi-Symmetric")
			{
				airfoilName = "NACA23015";
			}
			else if (Wing.Airfoil == "Symmetric")
			{
				airfoilName = "NACA0009";
			}
			Aerofoil airfoil = AircraftScript.GetAirfoil(airfoilName);
			WingPhysicsScript.Aerofoil = airfoil;
			if (!Wing.Inverted)
			{
				WingPhysicsScript.transform.localScale = new Vector3(0f - Wing.WingSpan, 1f, Wing.BaseChord);
				WingPhysicsScript.transform.localPosition = new Vector3(0f, Wing.WingSpan / 2f);
				WingPhysicsScript.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));
			}
			else
			{
				WingPhysicsScript.transform.localScale = new Vector3(Wing.WingSpan, 1f, Wing.BaseChord);
				WingPhysicsScript.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
				WingPhysicsScript.transform.localPosition = new Vector3(0f, Wing.WingSpan / 2f);
			}
		}
	}
}
