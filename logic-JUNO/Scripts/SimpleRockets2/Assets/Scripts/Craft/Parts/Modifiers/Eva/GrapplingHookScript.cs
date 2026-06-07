using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Eva
{
	public class GrapplingHookScript : MonoBehaviour
	{
		private LineRenderer _grapplingHookLine;

		private Vector3d _grapplingHookWarpPositionOffset;

		private ITimeManager _timeManager;

		public bool AutoDeleteToBody { get; private set; }

		public Rigidbody BodyFrom { get; private set; }

		public Rigidbody BodyTo { get; private set; }

		public ICraftScript CraftFrom { get; private set; }

		public ICraftScript CraftGrappled { get; private set; }

		public ICraftScript CraftTo { get; private set; }

		public EvaScript EvaFrom { get; private set; }

		public EvaScript EvaTo { get; private set; }

		public SpringJoint GrapplingHookJoint { get; private set; }

		public Vector3 LineOffsetFrom { get; set; } = Vector3.zero;

		public Vector3 LineOffsetTo { get; set; } = Vector3.zero;

		public IPartScript PartFrom { get; private set; }

		public IPartScript PartTo { get; private set; }

		public Vector3 PositionFrom { get; private set; }

		public Vector3 PositionTo { get; private set; }

		public static GrapplingHookScript Connect(Rigidbody bodyFrom, IPartScript partFrom, Vector3 positionFrom, Rigidbody bodyTo, IPartScript partTo, Vector3 positionTo)
		{
			GrapplingHookScript grapplingHookScript = bodyFrom.gameObject.AddComponent<GrapplingHookScript>();
			grapplingHookScript.AttachGrapplingHook(bodyFrom, partFrom, positionFrom, bodyTo, partTo, positionTo);
			return grapplingHookScript;
		}

		public static GrapplingHookScript ConnectViaRaycast(Rigidbody bodyFrom, IPartScript partFrom, Vector3 positionFrom, Ray ray, float maxDist)
		{
			GrapplingHookScript grapplingHookScript = null;
			bool bodyAutoCreated;
			RaycastHit hit;
			PartScript partHit;
			Rigidbody bodyFromRay = GetBodyFromRay(ray, maxDist, out bodyAutoCreated, out hit, out partHit);
			if (bodyFromRay != null && bodyFrom != bodyFromRay)
			{
				grapplingHookScript = Connect(bodyFrom, partFrom, positionFrom, bodyFromRay, partHit, hit.point);
				grapplingHookScript.AutoDeleteToBody = bodyAutoCreated;
			}
			return grapplingHookScript;
		}

		public float AdjustTetherLength(float adjustmentScalar, float maxLength)
		{
			float result = 0f;
			if (GrapplingHookJoint != null)
			{
				float num = (GrapplingHookJoint.transform.TransformPoint(GrapplingHookJoint.anchor) - GrapplingHookJoint.connectedBody.transform.TransformPoint(GrapplingHookJoint.connectedAnchor)).magnitude;
				if (GrapplingHookJoint.maxDistance < num)
				{
					num = GrapplingHookJoint.maxDistance;
				}
				float num2 = adjustmentScalar * Mathf.Clamp(0.1f * num, 1f * Time.deltaTime, 15f * Time.deltaTime);
				if (num2 > 0f)
				{
					GrapplingHookJoint.maxDistance = Mathf.Clamp(GrapplingHookJoint.maxDistance + num2, 0f, maxLength);
				}
				else
				{
					GrapplingHookJoint.maxDistance = num + num2;
				}
				result = GrapplingHookJoint.maxDistance;
			}
			return result;
		}

		public void Awake()
		{
			_timeManager = Game.Instance.FlightScene.TimeManager;
			_timeManager.TimeMultiplierModeChanging += OnTimeMultiplierModeChanging;
			GrapplingHookManagerScript.Instance.Register(this);
		}

		private static Rigidbody GetBodyFromRay(Ray ray, float maxDist, out bool bodyAutoCreated, out RaycastHit hit, out PartScript partHit)
		{
			bodyAutoCreated = false;
			Rigidbody rigidbody = null;
			partHit = null;
			if (Physics.Raycast(ray, out hit, maxDist, -1543503872, QueryTriggerInteraction.Ignore))
			{
				partHit = hit.collider.gameObject.GetComponentInParent<PartScript>();
				rigidbody = hit.collider.gameObject.GetComponentInParent<Rigidbody>();
				if (rigidbody == null)
				{
					bodyAutoCreated = true;
					rigidbody = hit.collider.gameObject.AddComponent<Rigidbody>();
					rigidbody.isKinematic = true;
				}
			}
			return rigidbody;
		}

		private static EvaScript GetEvaScript(ICraftScript craftScript)
		{
			EvaScript result = null;
			if (craftScript != null)
			{
				EvaScript[] componentsInChildren = craftScript.Transform.GetComponentsInChildren<EvaScript>();
				if (componentsInChildren.Length == 1 && componentsInChildren[0].EvaActive)
				{
					result = componentsInChildren[0];
				}
			}
			return result;
		}

		private SpringJoint AttachGrapplingHook(Rigidbody bodyFrom, IPartScript partFrom, Vector3 positionFrom, Rigidbody bodyTo, IPartScript partTo, Vector3 positionTo)
		{
			SpringJoint springJoint = bodyTo.gameObject.AddComponent<SpringJoint>();
			springJoint.autoConfigureConnectedAnchor = false;
			springJoint.enableCollision = true;
			springJoint.anchor = bodyTo.transform.InverseTransformPoint(positionTo);
			springJoint.connectedBody = bodyFrom;
			springJoint.connectedAnchor = bodyFrom.transform.InverseTransformPoint(positionFrom);
			float magnitude = (positionTo - positionFrom).magnitude;
			springJoint.minDistance = 0f;
			springJoint.maxDistance = magnitude;
			springJoint.spring = 1000f;
			springJoint.damper = 500f;
			GrapplingHookJoint = springJoint;
			BodyTo = bodyTo;
			BodyFrom = bodyFrom;
			PartFrom = partFrom;
			PartTo = partTo;
			PositionTo = springJoint.connectedAnchor;
			PositionFrom = springJoint.anchor;
			CraftTo = bodyTo.GetComponentInParent<CraftScript>();
			CraftFrom = bodyFrom.GetComponentInParent<CraftScript>();
			EvaFrom = GetEvaScript(CraftFrom);
			EvaTo = GetEvaScript(CraftTo);
			CreateHookLineRenderer();
			return springJoint;
		}

		private void CreateHookLineRenderer()
		{
			GameObject gameObject = new GameObject("GrapplingHookLine");
			gameObject.transform.parent = base.gameObject.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = Vector3.zero;
			_grapplingHookLine = gameObject.AddComponent<LineRenderer>();
			_grapplingHookLine.positionCount = 2;
			_grapplingHookLine.textureMode = LineTextureMode.Tile;
			_grapplingHookLine.enabled = false;
			_grapplingHookLine.material = Game.Instance.ResourceLoader.LoadMaterial("Craft/Parts/Materials/GrapplingHookRope");
			_grapplingHookLine.endWidth = 0.05f;
			_grapplingHookLine.startWidth = 0.05f;
			_grapplingHookLine.numCapVertices = 4;
		}

		private void DestroyHookLineRenderer()
		{
			Object.Destroy(_grapplingHookLine.gameObject);
			_grapplingHookLine = null;
		}

		private void OnDestroy()
		{
			RemoveGrapplingHook();
			DestroyHookLineRenderer();
			if (_timeManager != null)
			{
				_timeManager.TimeMultiplierModeChanging -= OnTimeMultiplierModeChanging;
			}
			GrapplingHookManagerScript.Instance?.UnRegister(this);
		}

		private void OnTimeMultiplierModeChanging(TimeMultiplierModeChangedEvent e)
		{
			if (e.PreviousMode.WarpMode != e.CurrentMode.WarpMode && e.CurrentMode.WarpMode)
			{
				OnWarpAboutToBeEntered();
			}
		}

		private void OnWarpAboutToBeEntered()
		{
			if (CraftTo != null && CraftFrom != null)
			{
				_grapplingHookWarpPositionOffset = CraftTo.CraftNode.Orbit.Position - CraftFrom.CraftNode.Orbit.Position;
				CraftFrom.CraftNode.SetStateVectorsAtDefaultTime(CraftFrom.CraftNode.Orbit.Position, GrapplingHookManagerScript.Instance.GetWarpVelocity(this));
			}
		}

		private void RemoveGrapplingHook()
		{
			if (GrapplingHookJoint != null)
			{
				Object.DestroyImmediate(GrapplingHookJoint);
			}
			if (AutoDeleteToBody && BodyTo != null)
			{
				Object.DestroyImmediate(BodyTo);
			}
			GrapplingHookJoint = null;
			_grapplingHookLine.enabled = false;
			CraftGrappled = null;
		}

		private void Update()
		{
			if (_timeManager.CurrentMode.WarpMode && CraftTo != null && CraftFrom != null)
			{
				CraftFrom.CraftNode.SetStateVectorsAtDefaultTime(CraftTo.CraftNode.Orbit.Position - _grapplingHookWarpPositionOffset, GrapplingHookManagerScript.Instance.GetWarpVelocity(this));
			}
			if (GrapplingHookJoint != null && GrapplingHookJoint.connectedBody != null)
			{
				_grapplingHookLine.enabled = true;
				_grapplingHookLine.SetPosition(0, GrapplingHookJoint.transform.TransformPoint(GrapplingHookJoint.anchor + LineOffsetTo));
				_grapplingHookLine.SetPosition(1, GrapplingHookJoint.connectedBody.transform.TransformPoint(GrapplingHookJoint.connectedAnchor + LineOffsetFrom));
			}
			else
			{
				_grapplingHookLine.enabled = false;
			}
		}
	}
}
