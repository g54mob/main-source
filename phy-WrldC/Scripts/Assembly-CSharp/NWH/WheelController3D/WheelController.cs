using System;
using System.Collections.Generic;
using UnityEngine;

namespace NWH.WheelController3D
{
	[Serializable]
	public class WheelController : MonoBehaviour
	{
		[Serializable]
		public class FrictionPreset
		{
			public enum FrictionPresetEnum
			{
				TarmacDry = 0,
				TarmacWet = 1,
				Gravel = 2,
				Grass = 3,
				Sand = 4,
				Snow = 5,
				Ice = 6,
				Generic = 7,
				Tracks = 8,
				Arcade = 9
			}

			public string name;

			public Vector4 BCDE;

			[SerializeField]
			private AnimationCurve curve;

			public static FrictionPreset TarmacDry = new FrictionPreset("TarmacDry", new Vector4(12.5f, 2.05f, 0.92f, 0.97f));

			public static FrictionPreset TarmacWet = new FrictionPreset("TarmacWet", new Vector4(13.2f, 2.35f, 0.82f, 1f));

			public static FrictionPreset Gravel = new FrictionPreset("Gravel", new Vector4(9f, 1.1f, 0.8f, 1f));

			public static FrictionPreset Grass = new FrictionPreset("Grass", new Vector4(8.4f, 1.3f, 0.5f, 0.4f));

			public static FrictionPreset Sand = new FrictionPreset("Sand", new Vector4(8f, 1.2f, 0.6f, 0.5f));

			public static FrictionPreset Snow = new FrictionPreset("Snow", new Vector4(8.5f, 1.1f, 0.4f, 0.9f));

			public static FrictionPreset Ice = new FrictionPreset("Ice", new Vector4(4f, 2f, 0.1f, 1f));

			public static FrictionPreset Generic = new FrictionPreset("Generic", new Vector4(8f, 1.9f, 0.8f, 0.99f));

			public static FrictionPreset Tracks = new FrictionPreset("Tracks", new Vector4(0.1f, 2f, 15f, 1f));

			public static FrictionPreset Arcade = new FrictionPreset("Arcade", new Vector4(4f, 1f, 2f, 0.5f));

			[SerializeField]
			public static List<FrictionPreset> FrictionPresetList;

			public AnimationCurve Curve => curve;

			public FrictionPreset(string name, Vector4 BCDE)
			{
				this.name = name;
				this.BCDE = BCDE;
				curve = GenerateFrictionCurve(BCDE);
				if (FrictionPresetList == null)
				{
					FrictionPresetList = new List<FrictionPreset>();
				}
				FrictionPresetList.Add(this);
			}

			public static AnimationCurve GenerateFrictionCurve(Vector4 p)
			{
				AnimationCurve animationCurve = new AnimationCurve();
				Keyframe[] array = new Keyframe[60];
				for (int i = 0; i < array.Length; i++)
				{
					float num = (float)i / 59f;
					float frictionValue = GetFrictionValue(num, p);
					animationCurve.AddKey(num, frictionValue);
				}
				return animationCurve;
			}

			private static float GetFrictionValue(float slip, Vector4 p)
			{
				float x = p.x;
				float y = p.y;
				float z = p.z;
				float w = p.w;
				float num = Mathf.Abs(slip);
				return z * Mathf.Sin(y * Mathf.Atan(x * num - w * (x * num - Mathf.Atan(x * num))));
			}
		}

		public enum Side
		{
			Left = -1,
			Right = 1,
			Center = 0,
			Auto = 2
		}

		[Serializable]
		public class Friction
		{
			public float forceCoefficient = 1.1f;

			public float slipCoefficient = 1f;

			public float maxForce;

			public float slip;

			public float speed;

			public float force;
		}

		[Serializable]
		private class Damper
		{
			public AnimationCurve dampingCurve;

			public float unitBumpForce = 800f;

			public float unitReboundForce = 1000f;

			public float force;

			public float maxForce;
		}

		[Serializable]
		private class Spring
		{
			public float maxLength = 0.3f;

			public AnimationCurve forceCurve;

			public float maxForce = 22000f;

			public float length;

			public float prevLength;

			public float compressionPercent;

			public float force;

			public float velocity;

			public Vector3 targetPoint;

			public float overflow;

			public float prevOverflow;

			public float overflowVelocity;

			public float bottomOutForce;

			public bool bottomedOut;

			public bool overExtended;
		}

		[Serializable]
		public class Wheel
		{
			public float mass = 25f;

			public float rimOffset;

			public float tireRadius = 0.4f;

			public float width = 0.25f;

			public float rpm;

			public Vector3 prevWorldPosition;

			public Vector3 worldPosition;

			public Vector3 prevGroundPoint;

			public Quaternion worldRotation;

			public AnimationCurve camberCurve;

			public float camberAngle;

			public float inertia;

			public float angularVelocity;

			public float freeRollingAngularVelocity;

			public float residualAngularVelocity;

			public float steerAngle;

			public float rotationAngle;

			public GameObject visual;

			public GameObject nonRotating;

			public GameObject rim;

			public Transform rimCollider;

			public Vector3 up;

			public Vector3 inside;

			public Vector3 forward;

			public Vector3 right;

			public Vector3 velocity;

			public Vector3 prevVelocity;

			public Vector3 acceleration;

			public float tireLoad;

			public float motorTorque;

			public float brakeTorque;

			public Vector3 nonRotatingPostionOffset;

			public void Initialize(WheelController wc)
			{
				inertia = 0.5f * mass * (tireRadius * tireRadius + tireRadius * tireRadius);
				rim = new GameObject();
				rim.name = "RimCollider";
				rim.transform.position = wc.transform.position + wc.transform.right * rimOffset * (float)wc.vehicleSide;
				rim.transform.parent = wc.transform;
				rim.layer = LayerMask.NameToLayer("Ignore Raycast");
				if (wc.useRimCollider && visual != null)
				{
					MeshFilter meshFilter = rim.AddComponent<MeshFilter>();
					meshFilter.name = "Rim Mesh Filter";
					meshFilter.mesh = wc.GenerateRimColliderMesh(visual.transform);
					meshFilter.mesh.name = "Rim Mesh";
					MeshCollider meshCollider = rim.AddComponent<MeshCollider>();
					meshCollider.name = "Rim MeshCollider";
					meshCollider.convex = true;
					meshCollider.material = new PhysicMaterial
					{
						staticFriction = 0f,
						dynamicFriction = 0f,
						bounciness = 0.3f
					};
					wc.wheel.rimCollider = rim.transform;
				}
			}

			public void GenerateCamberCurve(float camberAtBottom, float camberAtTop)
			{
				AnimationCurve animationCurve = new AnimationCurve();
				animationCurve.AddKey(0f, camberAtBottom);
				animationCurve.AddKey(1f, camberAtTop);
				camberCurve = animationCurve;
			}
		}

		[Serializable]
		public class WheelHit
		{
			[SerializeField]
			public RaycastHit raycastHit;

			public float angleForward;

			public float distanceFromTire;

			public Vector2 offset;

			[HideInInspector]
			public float weight;

			public bool valid;

			public float curvatureOffset;

			public Vector3 groundPoint;

			public Vector3 forwardDir;

			public float forwardSlip;

			public Vector3 sidewaysDir;

			public float sidewaysSlip;

			public float force;

			public Vector3 point => groundPoint;

			public Vector3 normal => raycastHit.normal;

			public Collider collider => raycastHit.collider;

			public void Copy(WheelHit hit, bool copyHit)
			{
				if (copyHit)
				{
					raycastHit = hit.raycastHit;
				}
				angleForward = hit.angleForward;
				distanceFromTire = hit.distanceFromTire;
				offset.x = hit.offset.x;
				offset.y = hit.offset.y;
				weight = hit.weight;
				curvatureOffset = hit.curvatureOffset;
			}
		}

		[SerializeField]
		public Wheel wheel;

		[SerializeField]
		private Spring spring;

		[SerializeField]
		private Damper damper;

		[SerializeField]
		private Friction fFriction;

		[SerializeField]
		private Friction sFriction;

		[SerializeField]
		private WheelHit[] wheelHits;

		[SerializeField]
		private LayerMask scanIgnoreLayers = 1048580;

		[SerializeField]
		private int forwardScanResolution = 8;

		[SerializeField]
		private int sideToSideScanResolution = 3;

		[SerializeField]
		private bool hasHit = true;

		[SerializeField]
		private bool prevHasHit = true;

		public bool debug;

		[SerializeField]
		public GameObject parent;

		private Rigidbody parentRigidbody;

		public bool useRimCollider;

		[SerializeField]
		private Side vehicleSide = Side.Auto;

		public FrictionPreset.FrictionPresetEnum activeFrictionPresetEnum;

		public FrictionPreset activeFrictionPreset;

		public WheelHit wheelHit = new WheelHit();

		private WheelHit smoothedWheelHit = new WheelHit();

		public bool singleRay;

		public WheelHit singleWheelHit = new WheelHit();

		[HideInInspector]
		public bool trackedVehicle;

		private Quaternion steerQuaternion;

		private Quaternion camberQuaternion;

		private Quaternion totalRotation;

		private float boundsX;

		private float boundsY;

		private float boundsZ;

		private float boundsW;

		private float stepX;

		private float stepY;

		private float rayLength;

		private int minDistRayIndex;

		private WheelHit wheelRay;

		private float n;

		private float minWeight = float.PositiveInfinity;

		private float maxWeight;

		private float weightSum;

		private int validCount;

		[NonSerialized]
		private Vector3 hitPointSum = Vector3.zero;

		[NonSerialized]
		private Vector3 normalSum = Vector3.zero;

		[NonSerialized]
		private Vector3 point;

		[NonSerialized]
		private Vector3 normal;

		private float weight;

		private float forwardSum;

		private float sideSum;

		private float angleSum;

		private float offsetSum;

		private Vector3 transformUp;

		private Vector3 transformForward;

		private Vector3 transformRight;

		private Vector3 transformPosition;

		private Quaternion transformRotation;

		public bool applyForceToOthers;

		public float maxPutDownForce;

		private RaycastHit tmpRaycastHit;

		private Vector3 origin;

		private Vector3 alternateForwardNormal;

		private Vector3 totalForce;

		private Vector3 forcePoint;

		private Vector3 hitDir;

		private Vector3 predictedDistance;

		private Vector3 wheelDown;

		private Vector3 offsetPrecalc;

		private float prevForwardSpeed;

		private float prevFreeRollingAngularVelocity;

		private Vector3 projectedNormal;

		private Vector3 projectedAltNormal;

		public float brakeTorque
		{
			get
			{
				return wheel.brakeTorque;
			}
			set
			{
				if (value >= 0f)
				{
					wheel.brakeTorque = value;
					return;
				}
				wheel.brakeTorque = 0f;
				Debug.LogWarning("Brake torque must be positive and so was set to 0.");
			}
		}

		public bool isGrounded
		{
			get
			{
				if (hasHit)
				{
					return true;
				}
				return false;
			}
		}

		public float mass
		{
			get
			{
				return wheel.mass;
			}
			set
			{
				wheel.mass = value;
			}
		}

		public float motorTorque
		{
			get
			{
				return wheel.motorTorque;
			}
			set
			{
				wheel.motorTorque = value;
			}
		}

		public float radius
		{
			get
			{
				return tireRadius;
			}
			set
			{
				tireRadius = value;
			}
		}

		public float rimOffset
		{
			get
			{
				return wheel.rimOffset;
			}
			set
			{
				wheel.rimOffset = value;
			}
		}

		public float tireRadius
		{
			get
			{
				return wheel.tireRadius;
			}
			set
			{
				wheel.tireRadius = value;
			}
		}

		public float tireWidth
		{
			get
			{
				return wheel.width;
			}
			set
			{
				wheel.width = value;
			}
		}

		public float rpm => wheel.rpm;

		public float steerAngle
		{
			get
			{
				return wheel.steerAngle;
			}
			set
			{
				wheel.steerAngle = value;
			}
		}

		public float camber => wheel.camberAngle;

		public float springCompression => 1f - spring.compressionPercent;

		public float springVelocity => spring.velocity;

		public bool springBottomedOut => spring.bottomedOut;

		public bool springOverExtended => spring.overExtended;

		public float suspensionForce
		{
			get
			{
				return spring.force;
			}
			set
			{
				spring.force = value;
			}
		}

		public float springMaximumForce
		{
			get
			{
				return spring.maxForce;
			}
			set
			{
				spring.maxForce = value;
			}
		}

		public AnimationCurve springCurve
		{
			get
			{
				return spring.forceCurve;
			}
			set
			{
				spring.forceCurve = value;
			}
		}

		public float springLength
		{
			get
			{
				return spring.maxLength;
			}
			set
			{
				spring.maxLength = value;
			}
		}

		public float springTravel => spring.length;

		public Vector3 springTravelPoint => base.transform.position - base.transform.up * spring.length;

		public float damperForce => damper.force;

		public float damperUnitReboundForce
		{
			get
			{
				return damper.unitReboundForce;
			}
			set
			{
				damper.unitReboundForce = value;
			}
		}

		public float damperUnitBumpForce
		{
			get
			{
				return damper.unitBumpForce;
			}
			set
			{
				damper.unitBumpForce = value;
			}
		}

		public AnimationCurve damperCurve
		{
			get
			{
				return damper.dampingCurve;
			}
			set
			{
				damper.dampingCurve = value;
			}
		}

		public Friction forwardFriction
		{
			get
			{
				return fFriction;
			}
			set
			{
				fFriction = value;
			}
		}

		public Friction sideFriction
		{
			get
			{
				return sFriction;
			}
			set
			{
				sFriction = value;
			}
		}

		public float MaxPutDownForce => maxPutDownForce;

		public Side VehicleSide
		{
			get
			{
				return vehicleSide;
			}
			set
			{
				vehicleSide = value;
			}
		}

		public float speed => fFriction.speed;

		public int ForwardScanResolution
		{
			get
			{
				return forwardScanResolution;
			}
			set
			{
				forwardScanResolution = value;
				if (forwardScanResolution < 1)
				{
					forwardScanResolution = 1;
					Debug.LogWarning("Forward scan resolution must be > 0.");
				}
			}
		}

		public int SideToSideScanResolution
		{
			get
			{
				return sideToSideScanResolution;
			}
			set
			{
				sideToSideScanResolution = value;
				if (sideToSideScanResolution < 1)
				{
					sideToSideScanResolution = 1;
					Debug.LogWarning("Side to side scan resolution must be > 0.");
				}
			}
		}

		public GameObject Parent
		{
			get
			{
				return parent;
			}
			set
			{
				parent = value;
			}
		}

		public GameObject Visual
		{
			get
			{
				return wheel.visual;
			}
			set
			{
				wheel.visual = value;
			}
		}

		public GameObject NonRotating
		{
			get
			{
				return wheel.nonRotating;
			}
			set
			{
				wheel.nonRotating = value;
			}
		}

		public Vector3 pointVelocity => parentRigidbody.GetPointVelocity(wheel.worldPosition);

		public float angularVelocity => wheel.angularVelocity;

		public LayerMask ScanIgnoreLayers
		{
			get
			{
				return scanIgnoreLayers;
			}
			set
			{
				scanIgnoreLayers = value;
			}
		}

		public void GetWorldPose(out Vector3 pos, out Quaternion quat)
		{
			pos = wheel.worldPosition;
			quat = wheel.worldRotation;
		}

		public bool GetGroundHit(out WheelHit hit)
		{
			hit = wheelHit;
			return hasHit;
		}

		public void SetCamber(float camberAtTop, float camberAtBottom)
		{
			wheel.GenerateCamberCurve(camberAtTop, camberAtBottom);
		}

		public void SetCamber(float camber)
		{
			wheel.GenerateCamberCurve(camber, camber);
		}

		public void SetCamber(AnimationCurve curve)
		{
			wheel.camberCurve = curve;
		}

		public void SetActiveFrictionPreset(FrictionPreset fp)
		{
			activeFrictionPresetEnum = (FrictionPreset.FrictionPresetEnum)Enum.Parse(typeof(FrictionPreset.FrictionPresetEnum), fp.name);
			activeFrictionPreset = fp;
		}

		public void SetActiveFrictionPreset(FrictionPreset.FrictionPresetEnum fpe)
		{
			activeFrictionPresetEnum = fpe;
			activeFrictionPreset = GetFrictionPreset((int)fpe);
		}

		public FrictionPreset GetFrictionPreset(int index)
		{
			return activeFrictionPreset = FrictionPreset.FrictionPresetList[index];
		}

		private void OnDrawGizmosSelected()
		{
			if (!Application.isPlaying)
			{
				transformPosition = base.transform.position;
			}
			Gizmos.color = Color.green;
			Vector3 vector = base.transform.forward * 0.07f;
			Vector3 vector2 = base.transform.up * spring.maxLength;
			Gizmos.DrawLine(transformPosition - vector, transformPosition + vector);
			Gizmos.DrawLine(transformPosition - vector2 - vector, transformPosition - vector2 + vector);
			Gizmos.DrawLine(transformPosition, transformPosition - vector2);
			_ = Vector3.zero;
			if (!Application.isPlaying && wheel.visual != null)
			{
				wheel.worldPosition = wheel.visual.transform.position;
				wheel.up = wheel.visual.transform.up;
				wheel.forward = wheel.visual.transform.forward;
				wheel.right = wheel.visual.transform.right;
			}
			Gizmos.DrawSphere(wheel.worldPosition, 0.02f);
			Gizmos.color = Color.green;
			DrawWheelGizmo(wheel.tireRadius, wheel.width, wheel.worldPosition, wheel.up, wheel.forward, wheel.right);
			if (!debug || !Application.isPlaying)
			{
				return;
			}
			Gizmos.color = Color.red;
			Gizmos.DrawRay(new Ray(wheel.worldPosition, wheel.up));
			Gizmos.color = Color.green;
			Gizmos.DrawRay(new Ray(wheel.worldPosition, wheel.forward));
			Gizmos.color = Color.blue;
			Gizmos.DrawRay(new Ray(wheel.worldPosition, wheel.right));
			Gizmos.color = Color.yellow;
			Gizmos.DrawRay(new Ray(wheel.worldPosition, wheel.inside));
			if (spring.length < 0.01f)
			{
				Gizmos.color = Color.red;
			}
			else if (spring.length > spring.maxLength - 0.01f)
			{
				Gizmos.color = Color.yellow;
			}
			else
			{
				Gizmos.color = Color.green;
			}
			if (!hasHit)
			{
				return;
			}
			float num = 0f;
			float num2 = float.PositiveInfinity;
			float num3 = 0f;
			WheelHit[] array = wheelHits;
			foreach (WheelHit wheelHit in array)
			{
				if (wheelHit.valid)
				{
					num += wheelHit.weight;
					if (wheelHit.weight < num2)
					{
						num2 = wheelHit.weight;
					}
					if (wheelHit.weight > num3)
					{
						num3 = wheelHit.weight;
					}
				}
			}
			array = wheelHits;
			foreach (WheelHit wheelHit2 in array)
			{
				if (wheelHit2.valid)
				{
					float t = (wheelHit2.weight - num2) / (num3 - num2);
					Gizmos.color = Color.Lerp(Color.black, Color.white, t);
					Gizmos.DrawSphere(wheelHit2.point, 0.04f);
					Gizmos.color = new Color(1f, 1f, 1f, 0.5f);
					Gizmos.DrawLine(wheelHit2.point, wheelHit2.point + wheel.up * wheelHit2.distanceFromTire);
				}
			}
			Gizmos.color = Color.cyan;
			Gizmos.DrawRay(new Ray(this.wheelHit.point, this.wheelHit.forwardDir));
			Gizmos.color = Color.magenta;
			Gizmos.DrawRay(new Ray(this.wheelHit.point, this.wheelHit.sidewaysDir));
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(this.wheelHit.point, 0.04f);
			Gizmos.DrawLine(this.wheelHit.point, this.wheelHit.point + this.wheelHit.normal * 1f);
			Gizmos.DrawSphere(forcePoint, 0.06f);
			Gizmos.color = Color.yellow;
			Vector3 normalized = (wheel.worldPosition - this.wheelHit.point).normalized;
			Gizmos.DrawLine(this.wheelHit.point, this.wheelHit.point + normalized * 1f);
			Gizmos.color = Color.magenta;
			Gizmos.DrawCube(spring.targetPoint, new Vector3(0.1f, 0.1f, 0.04f));
		}

		private void DrawWheelGizmo(float radius, float width, Vector3 position, Vector3 up, Vector3 forward, Vector3 right)
		{
			float num = width / 2f;
			float f = 0f;
			float num2 = radius * Mathf.Cos(f);
			float num3 = radius * Mathf.Sin(f);
			Vector3 vector = position + up * num3 + forward * num2;
			Vector3 vector2 = vector;
			for (f = 0f; f <= (float)Math.PI * 2f; f += (float)Math.PI / 12f)
			{
				num2 = radius * Mathf.Cos(f);
				num3 = radius * Mathf.Sin(f);
				vector2 = position + up * num3 + forward * num2;
				Gizmos.DrawLine(vector - right * num, vector2 - right * num);
				Gizmos.DrawLine(vector + right * num, vector2 + right * num);
				Gizmos.DrawLine(vector - right * num, vector + right * num);
				Gizmos.DrawLine(vector - right * num, vector2 + right * num);
				vector = vector2;
			}
		}

		private void Awake()
		{
			Initialize();
		}

		public void Start()
		{
			if (wheel.visual != null)
			{
				wheel.worldPosition = wheel.visual.transform.position;
				wheel.up = wheel.visual.transform.up;
				wheel.forward = wheel.visual.transform.forward;
				wheel.right = wheel.visual.transform.right;
			}
			if (wheel.nonRotating != null)
			{
				wheel.nonRotatingPostionOffset = base.transform.InverseTransformDirection(wheel.nonRotating.transform.position - wheel.visual.transform.position);
			}
			wheel.Initialize(this);
			parentRigidbody = parent.GetComponent<Rigidbody>();
			boundsX = (0f - wheel.width) / 2f;
			boundsY = 0f - wheel.tireRadius;
			boundsZ = wheel.width / 2f + 1E-06f;
			boundsW = wheel.tireRadius + 1E-06f;
			stepX = ((sideToSideScanResolution == 1) ? 1f : (wheel.width / (float)(sideToSideScanResolution - 1)));
			stepY = ((forwardScanResolution == 1) ? 1f : (wheel.tireRadius * 2f / (float)(forwardScanResolution - 1)));
			wheelHits = new WheelHit[forwardScanResolution * sideToSideScanResolution];
			int num = 0;
			for (float num2 = boundsX; num2 <= boundsZ; num2 += stepX)
			{
				int num3 = 0;
				for (float num4 = boundsY; num4 <= boundsW; num4 += stepY)
				{
					int num5 = num * forwardScanResolution + num3;
					WheelHit wheelHit = new WheelHit();
					wheelHit.angleForward = Mathf.Asin(num4 / (wheel.tireRadius + 1E-06f));
					wheelHit.curvatureOffset = Mathf.Cos(wheelHit.angleForward) * wheel.tireRadius;
					float x = num2;
					if (sideToSideScanResolution == 1)
					{
						x = 0f;
					}
					wheelHit.offset = new Vector2(x, num4);
					wheelHits[num5] = wheelHit;
					num3++;
				}
				num++;
			}
			spring.length = spring.maxLength * 0.5f;
			scanIgnoreLayers = ~(int)scanIgnoreLayers;
		}

		public void FixedUpdate()
		{
			prevHasHit = hasHit;
			transformPosition = base.transform.position;
			transformRotation = base.transform.rotation;
			transformForward = base.transform.forward;
			transformRight = base.transform.right;
			transformUp = base.transform.up;
			if (!parentRigidbody.IsSleeping())
			{
				HitUpdate();
				SuspensionUpdate();
				CalculateWheelDirectionsAndRotations();
				WheelUpdate();
				FrictionUpdate();
				UpdateForces();
			}
		}

		private void CalculateWheelDirectionsAndRotations()
		{
			steerQuaternion = Quaternion.AngleAxis(wheel.steerAngle, transformUp);
			camberQuaternion = Quaternion.AngleAxis((float)(0 - vehicleSide) * wheel.camberAngle, transformForward);
			totalRotation = steerQuaternion * camberQuaternion;
			wheel.up = totalRotation * transformUp;
			wheel.forward = totalRotation * transformForward;
			wheel.right = totalRotation * transformRight;
			wheel.inside = wheel.right * (0 - vehicleSide);
		}

		private void HitUpdate()
		{
			float num = float.PositiveInfinity;
			wheelDown = -wheel.up;
			float num2 = spring.maxLength - spring.length;
			rayLength = wheel.tireRadius * 2.1f + num2;
			offsetPrecalc = transformPosition - transformUp * spring.length + wheel.up * wheel.tireRadius - wheel.inside * wheel.rimOffset;
			int num3 = 0;
			minDistRayIndex = -1;
			hasHit = false;
			if (singleRay)
			{
				singleWheelHit.valid = false;
				if (Physics.Raycast(offsetPrecalc, wheelDown, out singleWheelHit.raycastHit, rayLength + wheel.tireRadius, scanIgnoreLayers))
				{
					float num4 = singleWheelHit.raycastHit.distance - wheel.tireRadius - wheel.tireRadius;
					if (num4 > num2)
					{
						return;
					}
					singleWheelHit.valid = true;
					hasHit = true;
					singleWheelHit.distanceFromTire = num4;
					this.wheelHit.raycastHit = singleWheelHit.raycastHit;
					this.wheelHit.Copy(singleWheelHit, copyHit: false);
					this.wheelHit.groundPoint = this.wheelHit.raycastHit.point;
					this.wheelHit.raycastHit.point += wheel.up * wheel.tireRadius;
					this.wheelHit.curvatureOffset = wheel.tireRadius;
				}
			}
			else
			{
				for (int i = 0; i < wheelHits.Length; i++)
				{
					WheelHit wheelHit = wheelHits[i];
					wheelHit.valid = false;
					origin.x = wheel.forward.x * wheelHit.offset.y + wheel.right.x * wheelHit.offset.x + offsetPrecalc.x;
					origin.y = wheel.forward.y * wheelHit.offset.y + wheel.right.y * wheelHit.offset.x + offsetPrecalc.y;
					origin.z = wheel.forward.z * wheelHit.offset.y + wheel.right.z * wheelHit.offset.x + offsetPrecalc.z;
					if (Physics.Raycast(origin, wheelDown, out tmpRaycastHit, rayLength + wheelHit.curvatureOffset, scanIgnoreLayers))
					{
						float num5 = tmpRaycastHit.distance - wheelHit.curvatureOffset - wheel.tireRadius;
						if (num5 > num2)
						{
							continue;
						}
						wheelHit.valid = true;
						wheelHit.raycastHit = tmpRaycastHit;
						wheelHit.distanceFromTire = num5;
						num3++;
						if (num5 < num)
						{
							num = num5;
							minDistRayIndex = i;
						}
					}
					wheelHits[i] = wheelHit;
				}
				CalculateAverageWheelHit();
			}
			if (hasHit)
			{
				this.wheelHit.forwardDir = Vector3.Normalize(Vector3.Cross(this.wheelHit.normal, -wheel.right));
				this.wheelHit.sidewaysDir = Quaternion.AngleAxis(90f, this.wheelHit.normal) * this.wheelHit.forwardDir;
			}
		}

		private void CalculateAverageWheelHit()
		{
			int num = 0;
			n = wheelHits.Length;
			minWeight = float.PositiveInfinity;
			maxWeight = 0f;
			weightSum = 0f;
			validCount = 0;
			hitPointSum = Vector3.zero;
			normalSum = Vector3.zero;
			weight = 0f;
			forwardSum = 0f;
			sideSum = 0f;
			angleSum = 0f;
			offsetSum = 0f;
			validCount = 0;
			for (int i = 0; (float)i < n; i++)
			{
				wheelRay = wheelHits[i];
				if (wheelRay.valid)
				{
					weight = wheel.tireRadius - wheelRay.distanceFromTire;
					weight = weight * weight * weight * weight * weight;
					if (weight < minWeight)
					{
						minWeight = weight;
					}
					else if (weight > maxWeight)
					{
						maxWeight = weight;
					}
					weightSum += weight;
					validCount++;
					normal = wheelRay.raycastHit.normal;
					point = wheelRay.raycastHit.point;
					hitPointSum.x += point.x * weight;
					hitPointSum.y += point.y * weight;
					hitPointSum.z += point.z * weight;
					normalSum.x += normal.x * weight;
					normalSum.y += normal.y * weight;
					normalSum.z += normal.z * weight;
					forwardSum += wheelRay.offset.y * weight;
					sideSum += wheelRay.offset.x * weight;
					angleSum += wheelRay.angleForward * weight;
					offsetSum += wheelRay.curvatureOffset * weight;
					num++;
				}
			}
			if (validCount == 0 || minDistRayIndex < 0)
			{
				hasHit = false;
				return;
			}
			wheelHit.raycastHit.point = hitPointSum / weightSum;
			wheelHit.offset.y = forwardSum / weightSum;
			wheelHit.offset.x = sideSum / weightSum;
			wheelHit.angleForward = angleSum / weightSum;
			wheelHit.raycastHit.normal = Vector3.Normalize(normalSum / weightSum);
			wheelHit.curvatureOffset = offsetSum / weightSum;
			wheelHit.raycastHit.point += wheel.up * wheelHit.curvatureOffset;
			if (prevHasHit && smoothedWheelHit != null)
			{
				float num2 = (float)forwardScanResolution / wheel.tireRadius;
				float t = Mathf.Clamp(parentRigidbody.GetPointVelocity(wheelHit.raycastHit.point).magnitude * parentRigidbody.GetPointVelocity(wheelHit.raycastHit.point).magnitude * Time.fixedDeltaTime * num2, 0.15f, 1f);
				smoothedWheelHit.raycastHit.point = Vector3.Lerp(smoothedWheelHit.raycastHit.point, wheelHit.raycastHit.point, t);
				smoothedWheelHit.raycastHit.normal = Vector3.Lerp(smoothedWheelHit.raycastHit.normal, wheelHit.raycastHit.normal, t);
				smoothedWheelHit.offset = Vector2.Lerp(smoothedWheelHit.offset, wheelHit.offset, t);
				smoothedWheelHit.angleForward = Mathf.Lerp(smoothedWheelHit.angleForward, wheelHit.angleForward, t);
				wheelHit.raycastHit = wheelHits[minDistRayIndex].raycastHit;
				wheelHit.Copy(smoothedWheelHit, copyHit: false);
				wheelHit.raycastHit.point = smoothedWheelHit.raycastHit.point;
				wheelHit.raycastHit.normal = smoothedWheelHit.raycastHit.normal;
			}
			else
			{
				smoothedWheelHit.Copy(wheelHit, copyHit: true);
			}
			wheelHit.groundPoint = wheelHit.raycastHit.point - wheel.up * wheelHit.curvatureOffset;
			hasHit = true;
		}

		private void SuspensionUpdate()
		{
			spring.prevOverflow = spring.overflow;
			spring.overflow = 0f;
			if (hasHit && Vector3.Dot(wheelHit.raycastHit.normal, transformUp) > 0.1f)
			{
				spring.bottomedOut = (spring.overExtended = false);
				if (singleRay)
				{
					spring.targetPoint = wheelHit.raycastHit.point - wheel.right * wheel.rimOffset * (float)vehicleSide;
				}
				else
				{
					spring.targetPoint = wheelHit.raycastHit.point + wheel.up * wheel.tireRadius * 0.027f - wheel.forward * wheelHit.offset.y - wheel.right * wheelHit.offset.x - wheel.right * wheel.rimOffset * (float)vehicleSide;
				}
				spring.length = parent.transform.InverseTransformPoint(transformPosition).y - parent.transform.InverseTransformPoint(spring.targetPoint).y;
				if (spring.length < 0f)
				{
					spring.overflow = 0f - spring.length;
					spring.length = 0f;
					spring.bottomedOut = true;
				}
				else if (spring.length > spring.maxLength)
				{
					hasHit = false;
					spring.length = spring.maxLength;
					spring.overExtended = true;
				}
			}
			else
			{
				spring.length = Mathf.Lerp(spring.length, spring.maxLength, Time.fixedDeltaTime * 8f);
			}
			spring.velocity = (spring.length - spring.prevLength) / Time.fixedDeltaTime;
			spring.compressionPercent = (spring.maxLength - spring.length) / spring.maxLength;
			spring.force = spring.maxForce * spring.forceCurve.Evaluate(spring.compressionPercent);
			spring.overflowVelocity = 0f;
			if (spring.overflow > 0f)
			{
				spring.overflowVelocity = (spring.overflow - spring.prevOverflow) / Time.fixedDeltaTime;
				spring.bottomOutForce = parentRigidbody.mass * (0f - Physics.gravity.y) * Mathf.Clamp(spring.overflowVelocity, 0f, float.PositiveInfinity) * 0.0225f;
				parentRigidbody.AddForceAtPosition(spring.bottomOutForce * transformUp, transformPosition, ForceMode.Impulse);
			}
			else
			{
				damper.maxForce = ((spring.length < spring.prevLength) ? damper.unitBumpForce : damper.unitReboundForce);
				if (spring.length <= spring.prevLength)
				{
					damper.force = damper.unitBumpForce * damper.dampingCurve.Evaluate(Mathf.Abs(spring.velocity));
				}
				else
				{
					damper.force = (0f - damper.unitReboundForce) * damper.dampingCurve.Evaluate(Mathf.Abs(spring.velocity));
				}
			}
			spring.prevLength = spring.length;
		}

		private void WheelUpdate()
		{
			wheel.prevWorldPosition = wheel.worldPosition;
			wheel.worldPosition = transformPosition - transformUp * spring.length - wheel.inside * wheel.rimOffset;
			wheel.prevVelocity = wheel.velocity;
			wheel.velocity = parentRigidbody.GetPointVelocity(wheel.worldPosition);
			wheel.acceleration = (wheel.velocity - wheel.prevVelocity) / Time.fixedDeltaTime;
			wheel.camberAngle = wheel.camberCurve.Evaluate(spring.length / spring.maxLength);
			wheel.tireLoad = Mathf.Clamp(spring.force + damper.force, 0f, float.PositiveInfinity);
			if (hasHit)
			{
				wheelHit.force = wheel.tireLoad;
			}
			wheel.rotationAngle = wheel.rotationAngle % 360f + wheel.angularVelocity * 57.29578f * Time.fixedDeltaTime;
			Quaternion quaternion = Quaternion.AngleAxis(wheel.rotationAngle, base.transform.right);
			wheel.worldRotation = totalRotation * quaternion * transformRotation;
			if (wheel.visual != null)
			{
				wheel.visual.transform.position = wheel.worldPosition;
				wheel.visual.transform.rotation = wheel.worldRotation;
			}
			if (wheel.nonRotating != null)
			{
				wheel.nonRotating.transform.rotation = totalRotation * transformRotation;
				wheel.nonRotating.transform.position = wheel.worldPosition + base.transform.TransformDirection(totalRotation * wheel.nonRotatingPostionOffset);
			}
			if (useRimCollider)
			{
				wheel.rim.transform.position = wheel.worldPosition;
				wheel.rim.transform.rotation = steerQuaternion * camberQuaternion * transformRotation;
			}
		}

		private void FrictionUpdate()
		{
			prevForwardSpeed = fFriction.speed;
			Vector3 lhs = parentRigidbody.GetPointVelocity(wheelHit.raycastHit.point);
			if (hasHit)
			{
				fFriction.speed = Vector3.Dot(lhs, wheelHit.forwardDir);
				sFriction.speed = Vector3.Dot(lhs, wheelHit.sidewaysDir);
			}
			else
			{
				fFriction.speed = (sFriction.speed = 0f);
			}
			float min = 3f - Mathf.Clamp(lhs.magnitude, 0f, 3f);
			float num = Mathf.Clamp(Mathf.Abs(wheel.angularVelocity * wheel.tireRadius), min, float.PositiveInfinity);
			sFriction.slip = 0f;
			sFriction.force = 0f;
			if (hasHit)
			{
				if (trackedVehicle)
				{
					SetActiveFrictionPreset(FrictionPreset.Tracks);
				}
				sFriction.slip = ((fFriction.speed == 0f) ? 0f : (Mathf.Atan(sFriction.speed / num) * 57.29578f / 80f));
				sFriction.force = Mathf.Sign(sFriction.slip) * activeFrictionPreset.Curve.Evaluate(Mathf.Abs(sFriction.slip)) * wheel.tireLoad * sFriction.forceCoefficient * 1.3f;
			}
			wheel.freeRollingAngularVelocity = fFriction.speed / wheel.tireRadius;
			float num2 = wheel.mass * wheel.tireRadius * wheel.tireRadius;
			float num3 = wheel.motorTorque / wheel.tireRadius;
			float num4 = Mathf.Abs(wheel.brakeTorque / wheel.tireRadius);
			fFriction.slip = 0f;
			if (hasHit)
			{
				float num5 = Mathf.Clamp(Mathf.Abs(fFriction.speed), 0.22f, float.PositiveInfinity);
				fFriction.slip = ((num5 == 0f) ? 0f : ((wheel.angularVelocity * wheel.tireRadius - fFriction.speed) / num5 * fFriction.slipCoefficient));
			}
			float time = Mathf.Clamp(Mathf.Abs(fFriction.slip), 0.05f, float.PositiveInfinity);
			if (!trackedVehicle)
			{
				maxPutDownForce = activeFrictionPreset.Curve.Evaluate(time) * wheel.tireLoad * fFriction.forceCoefficient * 1.3f;
			}
			else
			{
				maxPutDownForce = wheel.tireLoad * fFriction.forceCoefficient * 1.3f;
			}
			float num6 = Mathf.Sign(num3) * Mathf.Clamp(maxPutDownForce - Mathf.Abs(num3), 0f, float.PositiveInfinity);
			float num7 = ((num2 == 0f) ? 0f : (num6 * wheel.tireRadius / num2 * Time.fixedDeltaTime));
			float num8 = Mathf.Sign(num3) * Mathf.Clamp(Mathf.Abs(num3) - maxPutDownForce, 0f, float.PositiveInfinity);
			float num9 = ((num2 == 0f) ? 0f : (num8 * wheel.tireRadius / num2 * Time.fixedDeltaTime));
			wheel.residualAngularVelocity += num9 - num7;
			if (num3 >= 0f)
			{
				wheel.residualAngularVelocity = Mathf.Clamp(wheel.residualAngularVelocity, 0f, float.PositiveInfinity);
			}
			else
			{
				wheel.residualAngularVelocity = Mathf.Clamp(wheel.residualAngularVelocity, float.NegativeInfinity, 0f);
			}
			if (!hasHit && prevHasHit)
			{
				wheel.residualAngularVelocity = prevFreeRollingAngularVelocity;
			}
			wheel.angularVelocity = wheel.freeRollingAngularVelocity + wheel.residualAngularVelocity;
			float num10 = ((num2 == 0f) ? 0f : ((0f - Mathf.Sign(wheel.angularVelocity)) * (num4 * wheel.tireRadius / num2) * Time.fixedDeltaTime));
			if (wheel.angularVelocity < 0f)
			{
				wheel.angularVelocity = Mathf.Clamp(wheel.angularVelocity + num10, float.NegativeInfinity, 0f);
			}
			else
			{
				wheel.angularVelocity = Mathf.Clamp(wheel.angularVelocity + num10, 0f, float.PositiveInfinity);
			}
			wheel.residualAngularVelocity = Mathf.Sign(wheel.residualAngularVelocity) * Mathf.Clamp(Mathf.Abs(wheel.residualAngularVelocity), 0f, 1000f);
			if (hasHit && num4 != 0f && Mathf.Abs(num3) < num4 && num4 < maxPutDownForce)
			{
				wheel.angularVelocity = wheel.freeRollingAngularVelocity;
			}
			if (trackedVehicle)
			{
				wheel.angularVelocity = wheel.freeRollingAngularVelocity;
			}
			if (hasHit)
			{
				float f = fFriction.speed;
				if (lhs.magnitude < 1f)
				{
					f = Mathf.SmoothStep(prevForwardSpeed, fFriction.speed, Time.fixedDeltaTime * 2f);
				}
				fFriction.force = Mathf.Clamp(num3 - Mathf.Sign(fFriction.speed) * Mathf.Clamp01(Mathf.Abs(f)) * num4, 0f - maxPutDownForce, maxPutDownForce) * fFriction.forceCoefficient;
			}
			else
			{
				fFriction.force = 0f;
			}
			wheel.rpm = wheel.angularVelocity * 9.55f;
			if (fFriction.maxForce > 0f)
			{
				fFriction.force = Mathf.Clamp(fFriction.force, 0f - fFriction.maxForce, fFriction.maxForce);
			}
			if (sFriction.maxForce > 0f)
			{
				sFriction.force = Mathf.Clamp(sFriction.force, 0f - sFriction.maxForce, sFriction.maxForce);
			}
			if (hasHit)
			{
				wheelHit.forwardSlip = fFriction.slip;
				wheelHit.sidewaysSlip = sFriction.slip;
			}
			prevFreeRollingAngularVelocity = wheel.freeRollingAngularVelocity;
		}

		private void UpdateForces()
		{
			if (!hasHit)
			{
				return;
			}
			Vector3 vector = wheelHit.point;
			Vector3 lhs = wheelHit.raycastHit.normal;
			hitDir.x = wheel.worldPosition.x - vector.x;
			hitDir.y = wheel.worldPosition.y - vector.y;
			hitDir.z = wheel.worldPosition.z - vector.z;
			float num = Mathf.Sqrt(hitDir.x * hitDir.x + hitDir.y * hitDir.y + hitDir.z * hitDir.z);
			alternateForwardNormal.x = hitDir.x / num;
			alternateForwardNormal.y = hitDir.y / num;
			alternateForwardNormal.z = hitDir.z / num;
			if (!(Vector3.Dot(lhs, transformUp) > 0.1f))
			{
				return;
			}
			float num2 = Mathf.Clamp(spring.force + damper.force, 0f, float.PositiveInfinity);
			float num3 = 0f;
			float num4 = fFriction.speed;
			if (num4 < 0f)
			{
				num4 = 0f - num4;
			}
			if (num4 < 8f)
			{
				projectedNormal = Vector3.ProjectOnPlane(wheelHit.normal, wheel.right);
				float num5 = Mathf.Sqrt(projectedNormal.x * projectedNormal.x + projectedNormal.y * projectedNormal.y + projectedNormal.z * projectedNormal.z);
				projectedNormal.x /= num5;
				projectedNormal.y /= num5;
				projectedNormal.z /= num5;
				projectedAltNormal = Vector3.ProjectOnPlane(alternateForwardNormal, wheel.right);
				num5 = Mathf.Sqrt(projectedAltNormal.x * projectedAltNormal.x + projectedAltNormal.y * projectedAltNormal.y + projectedAltNormal.z * projectedAltNormal.z);
				projectedAltNormal.x /= num5;
				projectedAltNormal.y /= num5;
				projectedAltNormal.z /= num5;
				float num6 = Vector3.Dot(projectedNormal, projectedAltNormal);
				if (num6 < 0f)
				{
					num6 = 0f - num6;
				}
				num3 = (1f - num6) * num2 * (0f - Mathf.Sign(wheelHit.angleForward));
			}
			totalForce.x = num3 * wheel.forward.x + num2 * lhs.x + wheelHit.sidewaysDir.x * (0f - sFriction.force) + wheelHit.forwardDir.x * fFriction.force;
			totalForce.y = num3 * wheel.forward.y + num2 * lhs.y + wheelHit.sidewaysDir.y * (0f - sFriction.force) + wheelHit.forwardDir.y * fFriction.force;
			totalForce.z = num3 * wheel.forward.z + num2 * lhs.z + wheelHit.sidewaysDir.z * (0f - sFriction.force) + wheelHit.forwardDir.z * fFriction.force;
			forcePoint.x = (vector.x * 3f + spring.targetPoint.x) / 4f;
			forcePoint.y = (vector.y * 3f + spring.targetPoint.y) / 4f;
			forcePoint.z = (vector.z * 3f + spring.targetPoint.z) / 4f;
			parentRigidbody.AddForceAtPosition(totalForce, forcePoint);
			if (applyForceToOthers && (bool)wheelHit.raycastHit.rigidbody)
			{
				wheelHit.raycastHit.rigidbody.AddForceAtPosition(-totalForce, forcePoint);
			}
		}

		public void Initialize()
		{
			if (parent == null)
			{
				parent = FindParent();
			}
			if (wheel == null)
			{
				wheel = new Wheel();
			}
			if (spring == null)
			{
				spring = new Spring();
			}
			if (damper == null)
			{
				damper = new Damper();
			}
			if (fFriction == null)
			{
				fFriction = new Friction();
			}
			if (sFriction == null)
			{
				sFriction = new Friction();
			}
			if (springCurve == null || springCurve.keys.Length == 0)
			{
				springCurve = GenerateDefaultSpringCurve();
			}
			if (damperCurve == null || damperCurve.keys.Length == 0)
			{
				damperCurve = GenerateDefaultDamperCurve();
			}
			if (wheel.camberCurve == null || wheel.camberCurve.keys.Length == 0)
			{
				wheel.GenerateCamberCurve(0f, 0f);
			}
			if (activeFrictionPreset == null)
			{
				activeFrictionPreset = FrictionPreset.TarmacDry;
			}
			if (vehicleSide == Side.Auto && parent != null)
			{
				vehicleSide = DetermineSide(base.transform.position, parent.transform);
			}
		}

		private GameObject FindParent()
		{
			Transform transform = base.transform;
			while (transform != null)
			{
				if ((bool)transform.GetComponent<Rigidbody>())
				{
					return transform.gameObject;
				}
				transform = transform.parent;
			}
			return null;
		}

		private AnimationCurve GenerateDefaultSpringCurve()
		{
			AnimationCurve animationCurve = new AnimationCurve();
			animationCurve.AddKey(0f, 0f);
			animationCurve.AddKey(1f, 1f);
			return animationCurve;
		}

		private AnimationCurve GenerateDefaultDamperCurve()
		{
			AnimationCurve animationCurve = new AnimationCurve();
			animationCurve.AddKey(0f, 0f);
			animationCurve.AddKey(100f, 400f);
			return animationCurve;
		}

		public Mesh GenerateRimColliderMesh(Transform rt)
		{
			Mesh mesh = new Mesh();
			List<Vector3> list = new List<Vector3>();
			List<int> list2 = new List<int>();
			float num = wheel.width / 1.6f;
			float f = 0f;
			float num2 = (float)Math.PI / 18f;
			float num3 = tireRadius * 0.5f * Mathf.Cos(f);
			float num4 = tireRadius * 0.5f * Mathf.Sin(f);
			Vector3 vector = rt.InverseTransformPoint(wheel.worldPosition + wheel.up * num4 + wheel.forward * num3);
			int num5 = 0;
			for (f = num2; f <= (float)Math.PI * 2f + num2; f += (float)Math.PI / 12f)
			{
				if (f <= (float)Math.PI - num2)
				{
					num3 = tireRadius * 0.93f * Mathf.Cos(f);
					num4 = tireRadius * 0.93f * Mathf.Sin(f);
				}
				else
				{
					num3 = tireRadius * 0.1f * Mathf.Cos(f);
					num4 = tireRadius * 0.1f * Mathf.Sin(f);
				}
				Vector3 vector2 = rt.InverseTransformPoint(wheel.worldPosition + wheel.up * num4 + wheel.forward * num3);
				Vector3 item = vector - rt.InverseTransformDirection(wheel.right) * num;
				Vector3 item2 = vector2 - rt.InverseTransformDirection(wheel.right) * num;
				Vector3 item3 = vector + rt.InverseTransformDirection(wheel.right) * num;
				Vector3 item4 = vector2 + rt.InverseTransformDirection(wheel.right) * num;
				list.Add(item);
				list.Add(item2);
				list.Add(item3);
				list.Add(item4);
				list2.Add(num5 + 3);
				list2.Add(num5 + 1);
				list2.Add(num5);
				list2.Add(num5);
				list2.Add(num5 + 2);
				list2.Add(num5 + 3);
				vector = vector2;
				num5 += 4;
			}
			mesh.vertices = list.ToArray();
			mesh.triangles = list2.ToArray();
			mesh.RecalculateBounds();
			mesh.RecalculateNormals();
			mesh.RecalculateTangents();
			return mesh;
		}

		private Vector3 Vector3Average(List<Vector3> vectors)
		{
			Vector3 zero = Vector3.zero;
			foreach (Vector3 vector in vectors)
			{
				zero += vector;
			}
			return zero / vectors.Count;
		}

		private float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n)
		{
			return Mathf.Atan2(Vector3.Dot(n, Vector3.Cross(v1, v2)), Vector3.Dot(v1, v2)) * 57.29578f;
		}

		public Side DetermineSide(Vector3 pointPosition, Transform referenceTransform)
		{
			if (referenceTransform.InverseTransformPoint(pointPosition).x < 0f)
			{
				return Side.Left;
			}
			return Side.Right;
		}
	}
}
