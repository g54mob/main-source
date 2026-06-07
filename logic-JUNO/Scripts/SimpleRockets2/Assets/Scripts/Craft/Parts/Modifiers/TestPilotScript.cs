using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight;
using ModApi.Flight.GameView;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Planet;
using ModApi.Settings;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class TestPilotScript : PartModifierScript<TestPilotData>, IDesignerStart, IGameLoopItem, IFlightStart, IFlightFixedUpdate
	{
		private enum RagDollAnimation
		{
			Static = 0
		}

		private class RagdollBoneInfo
		{
			public Rigidbody Body { get; set; }

			public float BuoyancyScaler { get; set; }

			public Vector3 CenterOfBuoyancyOffset { get; set; }

			public Collider Collider { get; set; }

			public CapsuleCollider ColliderAsCapsule { get; set; }

			public float ColliderVolume { get; set; }
		}

		private const float PilotDragCoefficientTimesArea = 1f / 6f;

		private const float RagdollProtectionBegin = 500f;

		private const float RagdollProtectionEnd = 100f;

		private const float TensorScale = 10f;

		private const float WaterImpactVelocityEnableProtection = 100f;

		[SerializeField]
		private bool _animatorEnabled;

		private float _averageBoneMass;

		private List<RagdollBoneInfo> _boneInfos = new List<RagdollBoneInfo>();

		private bool _detached;

		private float _dragCoefficientTimeAreaPerBody;

		private FixedJoint _footAnchorJointLeft;

		private FixedJoint _footAnchorJointRight;

		private FixedJoint _jointToPart;

		private Vector3? _lastVelocity;

		private Setting<PhysicsQualitySettings.RagdollPhysicsQuality> _qualitySetting;

		private Animator _ragdollAnimator;

		private bool _ragdollProtectionEnabled;

		private Rigidbody _ragdollRootRigidBody;

		private bool _updateGForceCalculations;

		public float Acceleration { get; private set; }

		public float InstantaneousEarthGs { get; private set; }

		public float SmoothEarthGs { get; private set; }

		public float SmoothEarthGsMax { get; private set; }

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			CommonStart();
			SetRagdollKinematic(kinematic: true);
			SetRagdollAnimationState(enabled: false, null);
		}

		public override void FlightEnd()
		{
			base.FlightEnd();
			UpdateCraftEventSubscription(subscribe: false, base.PartScript.CraftScript);
		}

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			Rigidbody rigidBody = base.PartScript.BodyScript.RigidBody;
			if (_updateGForceCalculations && _lastVelocity.HasValue)
			{
				Vector3 vector = (rigidBody.velocity - _lastVelocity.Value) / frame.DeltaTime;
				ICraftNode craftNode = base.PartScript.CraftScript.CraftNode;
				if (craftNode != null && craftNode.InContactWithPlanet)
				{
					vector += base.PartScript.BodyScript.CraftScript.GravityForce;
				}
				Acceleration = vector.magnitude;
				SmoothEarthGs = Mathf.Lerp(b: InstantaneousEarthGs = Acceleration / 9.80665f, a: SmoothEarthGs, t: 25f * frame.DeltaTime);
				if (SmoothEarthGs > SmoothEarthGsMax)
				{
					SmoothEarthGsMax = Mathf.Lerp(SmoothEarthGsMax, SmoothEarthGs, 25f * frame.DeltaTime);
				}
			}
			if (!_ragdollProtectionEnabled && InstantaneousEarthGs > 500f)
			{
				SetRagdollProtection(enableProtection: true);
			}
			if (_ragdollProtectionEnabled)
			{
				if (InstantaneousEarthGs < 100f)
				{
					SetRagdollProtection(enableProtection: false);
				}
			}
			else if (_detached)
			{
				FixedUpdateDetached();
			}
			else
			{
				FixedUpdateAttached();
			}
			if (_updateGForceCalculations)
			{
				_lastVelocity = rigidBody.velocity;
			}
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			CommonStart();
			base.PartScript.WaterPhysics.WaterEntered += OnWaterEntered;
			base.PartScript.WaterPhysics.WaterExited += OnWaterExited;
			MatchRagdollToPartVelocity();
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				MatchRagdollToPartVelocity();
			});
			SetQuality(Game.Instance.QualitySettings.Physics.RagdollPhysics);
			Game.Instance.QualitySettings.Physics.RagdollPhysics.Changed += OnRagdollPhysicsQualityChanged;
			base.PartScript.MovedToNewCraft += OnMovedToNewCraft;
			base.PartScript.CraftScript.Initialized += OnCraftInitialized;
			SetRagdollEnabled(enabled: true);
			SetGForceCalculationsEnabled(enabled: true);
		}

		public override void OnConnectedToPart(PartConnectedEventData e)
		{
			base.OnConnectedToPart(e);
			base.Data.AnchorFeet = e.ThisAttachPoint.Name == "Feet";
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			model.Add(new TextModel("Gs", () => GetGsDisplayString(SmoothEarthGs)));
			model.Add(new TextModel("Max Gs", () => GetGsDisplayString(SmoothEarthGsMax)));
			model.Add(new TextModel("State", () => GetHumanState(SmoothEarthGsMax)));
			model.Add(new TextButtonModel("Reset Max Gs", delegate
			{
				SmoothEarthGsMax = 0f;
			}));
		}

		public override void RecalculateFrameState(Vector3 positionDelta, Vector3 velocityDelta)
		{
			base.RecalculateFrameState(positionDelta, velocityDelta);
			foreach (RagdollBoneInfo boneInfo in _boneInfos)
			{
				Rigidbody body = boneInfo.Body;
				if (base.PartScript.BodyScript.RigidBody != body)
				{
					body.velocity += velocityDelta;
				}
			}
			_lastVelocity = base.PartScript.BodyScript.RigidBody.velocity;
		}

		private static float GetColliderVolume(Rigidbody body)
		{
			float mass = body.mass;
			body.SetDensity(5f);
			float result = body.mass / 5f;
			body.mass = mass;
			return result;
		}

		private static string GetHumanState(float g)
		{
			if (g > 100f)
			{
				return "Pancake dead";
			}
			if (g > 75f)
			{
				return "Ultra dead";
			}
			if (g > 50f)
			{
				return "Deader than a doornail";
			}
			if (g > 25f)
			{
				return "Very dead";
			}
			if (g > 18f)
			{
				return "Dead";
			}
			if (g > 12f)
			{
				return "Unconscious";
			}
			if (g > 7f)
			{
				return "Sick";
			}
			return "Alive";
		}

		private void AnchorRagdoll(Rigidbody body)
		{
			DestroyJoint(_jointToPart);
			DestroyJoint(_footAnchorJointLeft);
			DestroyJoint(_footAnchorJointRight);
			Rigidbody componentInChildren = GetComponentInChildren<Rigidbody>();
			_jointToPart = componentInChildren.gameObject.AddComponent<FixedJoint>();
			_jointToPart.connectedBody = body;
			_jointToPart.autoConfigureConnectedAnchor = true;
			if (base.Data.AnchorFeet)
			{
				Rigidbody component = componentInChildren.transform.Find("RightHip/RightKnee").GetComponent<Rigidbody>();
				_footAnchorJointRight = component.gameObject.AddComponent<FixedJoint>();
				_footAnchorJointRight.connectedBody = body;
				Rigidbody component2 = componentInChildren.transform.Find("LeftHip/LeftKnee").GetComponent<Rigidbody>();
				_footAnchorJointLeft = component2.gameObject.AddComponent<FixedJoint>();
				_footAnchorJointLeft.connectedBody = body;
			}
		}

		private void CommonStart()
		{
			List<Rigidbody> list = base.gameObject.GetComponentsInChildren<Rigidbody>().ToList();
			float num = 0f;
			foreach (Rigidbody item2 in list)
			{
				item2.useGravity = false;
				item2.drag = 0f;
				item2.mass *= 0.01f;
				item2.angularDrag = 5f;
				item2.inertiaTensor *= 10f;
				Collider component = item2.GetComponent<Collider>();
				TestPilotBuoyancyConfigScript component2 = item2.gameObject.GetComponent<TestPilotBuoyancyConfigScript>();
				RagdollBoneInfo item = new RagdollBoneInfo
				{
					Body = item2,
					Collider = component,
					ColliderAsCapsule = (component as CapsuleCollider),
					ColliderVolume = GetColliderVolume(item2),
					BuoyancyScaler = ((component2 != null) ? component2.BuoyancyScale : 1f),
					CenterOfBuoyancyOffset = ((component2 != null) ? component2.CenterOfBuoyancy : Vector3.zero)
				};
				_boneInfos.Add(item);
				num += item2.mass;
			}
			_ragdollAnimator = base.transform.GetComponentInChildren<Animator>();
			_ragdollRootRigidBody = _ragdollAnimator.transform.Find("Hips").gameObject.GetComponent<Rigidbody>();
			SetRagdollAnimationState(enabled: false, null);
			_dragCoefficientTimeAreaPerBody = 1f / 6f / (float)_boneInfos.Count;
			_averageBoneMass = num / (float)_boneInfos.Count;
		}

		private void DestroyJoint(Joint joint)
		{
			if (joint != null)
			{
				Object.Destroy(joint);
			}
		}

		private void DetachRagdoll()
		{
			Object.Destroy(_jointToPart);
			if (base.Data.AnchorFeet)
			{
				Object.Destroy(_footAnchorJointRight);
				Object.Destroy(_footAnchorJointLeft);
			}
			if ((bool)base.PartScript.BodyScript.RigidBody)
			{
				Rigidbody rigidBody = base.PartScript.BodyScript.RigidBody;
				rigidBody.gameObject.name = rigidBody.name + "(body transplanted)";
				Object.Destroy(rigidBody);
			}
			_ragdollRootRigidBody.transform.SetParent(base.PartScript.CraftScript.Transform, worldPositionStays: true);
			base.PartScript.BodyScript.Transform.SetParent(_ragdollRootRigidBody.transform, worldPositionStays: true);
			base.PartScript.BodyScript.Transform.localPosition = Vector3.zero;
			base.PartScript.BodyScript.SetBody(_ragdollRootRigidBody);
			base.PartScript.BodyScript.ApplyStandardForces = false;
			SetRagdollVelocities(Game.Instance.FlightScene.ViewManager.GameView.ReferenceFrame.PlanetToFrameVelocity(base.PartScript.CraftScript.CraftNode.Orbit.Velocity));
			_detached = true;
		}

		private void FixedUpdateAttached()
		{
			IBodyScript bodyScript = base.PartScript.BodyScript;
			Vector3 vector = Vector3.zero;
			if (!base.PartScript.Data.PartDrag.IsOccluded && bodyScript.FluidDensity != 0f)
			{
				vector = GetDragAccel(bodyScript.VelocityMagnitude, bodyScript.VelocityNormalized, bodyScript.VelocitySquared, _averageBoneMass, bodyScript.FluidDensity);
			}
			Vector3 gravityForce = base.PartScript.CraftScript.GravityForce;
			foreach (RagdollBoneInfo boneInfo in _boneInfos)
			{
				Rigidbody body = boneInfo.Body;
				Vector3 force = vector + gravityForce;
				body.AddForceAtPosition(force, body.position, ForceMode.Acceleration);
			}
		}

		private void FixedUpdateDetached()
		{
			float airDensity = base.PartScript.CraftScript.AtmosphereSample.AirDensity;
			Vector3 gravityForce = base.PartScript.CraftScript.GravityForce;
			PositionBiomeData positionBiomeData = ((FlightSceneScript.Instance != null) ? FlightSceneScript.Instance.CraftBiomeData : null);
			foreach (RagdollBoneInfo boneInfo in _boneInfos)
			{
				Collider collider = boneInfo.Collider;
				float colliderSubmergedPercent = base.PartScript.CraftScript.GetColliderSubmergedPercent(collider);
				Rigidbody body = boneInfo.Body;
				float num = ((!(colliderSubmergedPercent > 0f)) ? airDensity : (positionBiomeData?.WaterConfig.Density ?? 1000f));
				float sqrMagnitude = body.velocity.sqrMagnitude;
				Vector3 dragAccel = GetDragAccel(Mathf.Sqrt(sqrMagnitude), body.velocity.normalized, sqrMagnitude, body.mass, num * colliderSubmergedPercent);
				Vector3 vector = -gravityForce * colliderSubmergedPercent * boneInfo.BuoyancyScaler + dragAccel + gravityForce;
				if (boneInfo.ColliderAsCapsule != null)
				{
					CapsuleCollider colliderAsCapsule = boneInfo.ColliderAsCapsule;
					Vector3 vector2 = colliderAsCapsule.transform.position + colliderAsCapsule.center + boneInfo.CenterOfBuoyancyOffset;
					Vector3 vector3 = colliderAsCapsule.transform.forward * colliderAsCapsule.height * 0.5f;
					Vector3 force = vector * 0.5f;
					body.AddForceAtPosition(force, vector2 + vector3, ForceMode.Acceleration);
					body.AddForceAtPosition(force, vector2 - vector3, ForceMode.Acceleration);
				}
				else
				{
					body.AddForceAtPosition(vector, body.position + boneInfo.CenterOfBuoyancyOffset, ForceMode.Acceleration);
				}
			}
		}

		private Vector3 GetDragAccel(float velocityMag, Vector3 velocityNormalized, float velocitySquared, float mass, float fluidDensity)
		{
			return -velocityNormalized * Mathf.Clamp(DragPhysics.GetDragForceMagnitude(velocitySquared, _dragCoefficientTimeAreaPerBody, 1f, fluidDensity) / mass, 0f, velocityMag);
		}

		private string GetGsDisplayString(float earthGs)
		{
			if (base.PartScript.CraftScript.IsPhysicsEnabled)
			{
				return earthGs.ToString("n1");
			}
			return "N/A";
		}

		private void MatchRagdollToPartVelocity()
		{
			Rigidbody rigidBody = base.PartScript.BodyScript.RigidBody;
			Vector3 velocity = rigidBody.velocity;
			Vector3 angularVelocity = rigidBody.angularVelocity;
			foreach (RagdollBoneInfo boneInfo in _boneInfos)
			{
				Rigidbody body = boneInfo.Body;
				body.velocity = velocity;
				body.angularVelocity = angularVelocity;
			}
			_lastVelocity = velocity;
		}

		private void OnCraftInitialized(ICraftScript craftScript)
		{
			if (base.PartScript.CraftScript.Data.Assembly.Parts.Count == 1)
			{
				DetachRagdoll();
			}
			else
			{
				AnchorRagdoll(base.PartScript.BodyScript.RigidBody);
			}
			UpdateCraftEventSubscription(subscribe: true, base.PartScript.CraftScript);
		}

		private void OnDestroy()
		{
			if (Game.InFlightScene)
			{
				PhysicsQualitySettings physicsQualitySettings = Game.Instance.QualitySettings?.Physics;
				if (physicsQualitySettings != null)
				{
					physicsQualitySettings.RagdollPhysics.Changed -= OnRagdollPhysicsQualityChanged;
				}
			}
		}

		private void OnMovedToNewCraft(ICraftScript oldCraft, ICraftScript newCraft)
		{
			oldCraft.Initialized -= OnCraftInitialized;
			newCraft.Initialized += OnCraftInitialized;
			UpdateCraftEventSubscription(subscribe: false, oldCraft);
		}

		private void OnPhysicsChanged(bool enabled, PhysicsChangeReason reason)
		{
			if (reason != PhysicsChangeReason.Warp && reason != PhysicsChangeReason.FlightEnd)
			{
				SetRagdollEnabled(enabled);
			}
		}

		private void OnPhysicsDisabled(ICraftNode source, PhysicsChangeReason reason)
		{
			OnPhysicsChanged(enabled: false, reason);
		}

		private void OnPhysicsEnabled(ICraftNode source, PhysicsChangeReason reason)
		{
			OnPhysicsChanged(enabled: true, reason);
		}

		private void OnRagdollPhysicsQualityChanged(object sender, SettingChangedEventArgs<PhysicsQualitySettings.RagdollPhysicsQuality> e)
		{
			SetQuality(e.Setting);
		}

		private void OnTimeMultiplierModeChanged(TimeMultiplierModeChangedEvent e)
		{
			if (e.EnteredWarpMode)
			{
				SetRagdollKinematic(kinematic: true);
			}
			else if (e.ExitedWarpMode)
			{
				SetRagdollKinematic(kinematic: false);
			}
		}

		private void OnValidate()
		{
			if (_ragdollAnimator != null && _ragdollAnimator.enabled != _animatorEnabled)
			{
				SetRagdollAnimationState(_animatorEnabled, RagDollAnimation.Static);
			}
		}

		private void OnWaterEntered(IPartWaterPhysics source)
		{
			if (base.PartScript.BodyScript.RigidBody.velocity.magnitude > 100f)
			{
				SetRagdollProtection(enableProtection: true);
			}
		}

		private void OnWaterExited(IPartWaterPhysics source)
		{
			if (_ragdollProtectionEnabled)
			{
				SetRagdollProtection(enableProtection: false);
			}
		}

		private void SetGForceCalculationsEnabled(bool enabled)
		{
			_updateGForceCalculations = enabled;
			if (!enabled)
			{
				_lastVelocity = null;
			}
		}

		private void SetQuality(Setting<PhysicsQualitySettings.RagdollPhysicsQuality> ragdollPhysics)
		{
			_qualitySetting = ragdollPhysics;
			switch (_qualitySetting.Value)
			{
			case PhysicsQualitySettings.RagdollPhysicsQuality.High:
				_ragdollAnimator.updateMode = AnimatorUpdateMode.Normal;
				break;
			case PhysicsQualitySettings.RagdollPhysicsQuality.Ultra:
				_ragdollAnimator.updateMode = AnimatorUpdateMode.AnimatePhysics;
				break;
			}
		}

		private void SetRagdollAnimationState(bool enabled, RagDollAnimation? anim)
		{
			_ragdollAnimator.enabled = enabled;
			_animatorEnabled = enabled;
		}

		private void SetRagdollEnabled(bool enabled)
		{
			if (enabled)
			{
				SetRagdollAnimationState(enabled: false, null);
				if (!_detached)
				{
					MatchRagdollToPartVelocity();
				}
			}
			else
			{
				SetRagdollAnimationState(enabled: true, RagDollAnimation.Static);
			}
		}

		private void SetRagdollKinematic(bool kinematic)
		{
			foreach (RagdollBoneInfo boneInfo in _boneInfos)
			{
				Rigidbody body = boneInfo.Body;
				body.isKinematic = kinematic;
				if (!kinematic)
				{
					body.velocity = base.PartScript.BodyScript.RigidBody.velocity;
					body.angularVelocity = Vector3.zero;
				}
			}
			SetGForceCalculationsEnabled(!kinematic);
		}

		private void SetRagdollProtection(bool enableProtection)
		{
			if (enableProtection)
			{
				SetRagdollEnabled(enabled: false);
			}
			else
			{
				SetRagdollEnabled(enabled: true);
			}
			_ragdollProtectionEnabled = enableProtection;
		}

		private void SetRagdollVelocities(Vector3 velocity)
		{
			foreach (RagdollBoneInfo boneInfo in _boneInfos)
			{
				boneInfo.Body.velocity = velocity;
			}
		}

		private void UpdateCraftEventSubscription(bool subscribe, ICraftScript craft)
		{
			if (craft == null)
			{
				return;
			}
			if (subscribe)
			{
				craft.CraftNode.PhysicsDisabled += OnPhysicsDisabled;
				craft.CraftNode.PhysicsEnabled += OnPhysicsEnabled;
				craft.TimeMultiplierModeChanged += OnTimeMultiplierModeChanged;
				return;
			}
			if (craft.CraftNode != null)
			{
				craft.CraftNode.PhysicsDisabled -= OnPhysicsDisabled;
				craft.CraftNode.PhysicsEnabled -= OnPhysicsEnabled;
			}
			craft.TimeMultiplierModeChanged -= OnTimeMultiplierModeChanged;
		}
	}
}
