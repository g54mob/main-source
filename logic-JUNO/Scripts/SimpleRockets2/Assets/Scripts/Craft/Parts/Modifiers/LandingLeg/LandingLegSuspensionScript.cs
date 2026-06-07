using System;
using System.Collections.Generic;
using System.Linq;
using ModApi;
using ModApi.Audio;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight;
using ModApi.Flight.Sim;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingLeg
{
	public class LandingLegSuspensionScript : PartModifierScript<LandingLegSuspensionData>, IFlightFixedUpdate, IGameLoopItem, IFlightStart
	{
		private class IgnoredGameObject
		{
			public bool Active;

			public GameObject GameObject;

			public int Layer;
		}

		private const float DefaultDamper = 750f;

		private const float DefaultSpring = 1500f;

		private float _collisionSoundCooldown = 1f;

		private float _currentSpringForce;

		private float _damper;

		private float _forwardSlip;

		private float _frictionNormal = 1f;

		private float _frictionOffroad = 1f;

		private Vector3 _groundVelocity;

		private List<IgnoredGameObject> _ignoredGameObjects;

		private bool _isGrounded;

		private Collider _lastGroundCollider;

		private float _maxDamper;

		private float _maxNormalForce;

		private float _maxSpringForce;

		private Transform _rayOrigin;

		private float _sidewaysSlip;

		private float _springForce;

		private float _surfaceFriction;

		private float _suspensionCompressionPrev;

		public bool CollideWithCraftLayer { get; private set; }

		public float CurrentDistance => base.Data.SuspensionDistance - base.Data.SuspensionCompression;

		public float ExtensionPercentage { get; set; }

		public Vector3 LastGroundNormal { get; private set; }

		public float Scale { get; private set; } = 1f;

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			if (base.Data.SuspensionType == LandingLegSuspensionData.LandingLegSuspensionType.Rigid)
			{
				return;
			}
			if (ExtensionPercentage > 0f)
			{
				base.PartScript.BodyScript.SetCollidingWithTerrainFlag(null);
				UpdateSuspension();
				if (_isGrounded)
				{
					CalculateSlips();
					CalculateForce();
					base.PartScript.BodyScript.SetCollidingWithTerrainFlag(true);
				}
				_collisionSoundCooldown -= Time.deltaTime;
			}
			else if (_isGrounded)
			{
				ResetGroundedState();
			}
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			UpdateSuspsensionSettings();
			if (base.Data.SuspensionType != LandingLegSuspensionData.LandingLegSuspensionType.Rigid)
			{
				Utilities.FindFirstGameObjectMyselfOrChildren("RigidCollider", base.gameObject).SetActive(value: false);
			}
			Game.Instance.FlightScene.PlayerChangedSoi += OnPlayerChangedSoi;
		}

		public void IgnoreGameObjectInRaycast(GameObject g)
		{
			if (_ignoredGameObjects == null)
			{
				_ignoredGameObjects = new List<IgnoredGameObject>();
			}
			IgnoredGameObject item = new IgnoredGameObject
			{
				GameObject = g
			};
			_ignoredGameObjects.Add(item);
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			UpdateSuspsensionSettings();
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			model.Add(new TextModel("Spring Force", () => Units.GetForceString(_currentSpringForce)));
		}

		public void ResetGroundedState()
		{
			base.Data.SuspensionCompression = 0f;
			_isGrounded = false;
			_groundVelocity = Vector3.zero;
			_lastGroundCollider = null;
			_currentSpringForce = 0f;
		}

		public void SetGroundedState(Collider groundCollider, Vector3 groundNormal, Vector3 contactPoint)
		{
			LastGroundNormal = groundNormal;
			_isGrounded = true;
			if (groundCollider != _lastGroundCollider)
			{
				_surfaceFriction = groundCollider.material.dynamicFriction;
				if (groundCollider.TryGetComponent<TireFrictionDefinition>(out var component))
				{
					_surfaceFriction *= Mathf.Lerp(_frictionNormal, _frictionOffroad, component.OffroadPercentage);
				}
				else
				{
					_surfaceFriction *= _frictionOffroad;
				}
				PlaySound(!groundCollider.gameObject.name.StartsWith("PlanetPhysicsQuad"));
				_lastGroundCollider = groundCollider;
			}
			Rigidbody attachedRigidbody = groundCollider.attachedRigidbody;
			if (attachedRigidbody != null)
			{
				_groundVelocity = attachedRigidbody.velocity;
			}
			else
			{
				_groundVelocity = Vector3.zero;
			}
		}

		protected virtual void OnDestroy()
		{
			IFlightScene flightScene = Game.Instance.FlightScene;
			if (flightScene != null)
			{
				flightScene.PlayerChangedSoi -= OnPlayerChangedSoi;
			}
		}

		protected override void OnInitialized()
		{
			_rayOrigin = Utilities.FindFirstGameObjectMyselfOrChildren("RayOrigin", base.PartScript.GameObject).transform;
		}

		private void CalculateForce()
		{
			float num = base.Data.SuspensionCompression * Scale * _springForce;
			float num2 = (base.Data.SuspensionCompression - _suspensionCompressionPrev) * Scale;
			if (num2 < 0f)
			{
				num2 = 0f;
			}
			float f = num2 / Time.deltaTime * _damper;
			f = Mathf.Sign(f) * Mathf.Min(Mathf.Abs(f), _maxDamper);
			num += f;
			float num3 = Mathf.Max(1500f * Scale * Scale * 40f, _maxSpringForce);
			if (num > num3)
			{
				base.PartScript.TakeDamage(1000f * Time.deltaTime * (num / num3 - 1f));
			}
			if (num > _maxSpringForce)
			{
				num = _maxSpringForce;
			}
			Vector3 vector = _rayOrigin.up * num;
			_currentSpringForce = num;
			vector = Vector3.Project(vector, -base.PartScript.CraftScript.GravityNormal);
			float num4 = Mathf.Min(num, _maxNormalForce);
			Vector3 vector2 = Vector3.ProjectOnPlane(num4 * (0f - _forwardSlip) * _surfaceFriction * _rayOrigin.forward, LastGroundNormal);
			Vector3 vector3 = Vector3.ProjectOnPlane(num4 * (0f - _sidewaysSlip) * _surfaceFriction * _rayOrigin.right, LastGroundNormal);
			Vector3 vector4 = vector2 + vector3;
			vector += vector4;
			base.PartScript.BodyScript.RigidBody.AddForceAtPosition(vector, _rayOrigin.position);
		}

		private void CalculateSlips()
		{
			Vector3 lhs = base.PartScript.BodyScript.RigidBody.GetPointVelocity(_rayOrigin.transform.position) + base.PartScript.CraftScript.ReferenceFrame.FrameSurfaceVelocity - _groundVelocity;
			Vector3 forward = _rayOrigin.forward;
			Vector3 right = _rayOrigin.right;
			_forwardSlip = Mathf.Clamp(Vector3.Dot(lhs, forward), -1f, 1f);
			_sidewaysSlip = Mathf.Clamp(Vector3.Dot(lhs, right), -1f, 1f);
		}

		private void OnPlayerChangedSoi(ICraftNode playerCraftNode, IPlanetNode newParent)
		{
			UpdateSuspsensionSettings();
		}

		private void PlaySound(bool concrete)
		{
			if (_collisionSoundCooldown <= 0f)
			{
				float num = 0.3f;
				if (concrete)
				{
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Flight.MetalCollisionConcrete, _rayOrigin.position).volume = num;
				}
				else
				{
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Flight.PartCollisionGround, _rayOrigin.position).volume = num * num;
				}
				_collisionSoundCooldown = 1f;
			}
		}

		private void UpdateSuspension()
		{
			int num = 603979776;
			if (CollideWithCraftLayer)
			{
				num |= int.MinValue;
			}
			Vector3 direction = -_rayOrigin.up;
			Vector3 position = _rayOrigin.position;
			int num2 = ((_ignoredGameObjects != null) ? _ignoredGameObjects.Count : 0);
			if (num2 > 0)
			{
				for (int i = 0; i < num2; i++)
				{
					IgnoredGameObject ignoredGameObject = _ignoredGameObjects[i];
					ignoredGameObject.Active = ignoredGameObject.GameObject.activeInHierarchy;
					if (ignoredGameObject.Active)
					{
						ignoredGameObject.Layer = ignoredGameObject.GameObject.layer;
						ignoredGameObject.GameObject.layer = 2;
					}
				}
			}
			float maxDistance = base.Data.SuspensionDistance * Scale;
			RaycastHit hitInfo;
			bool flag = Physics.Raycast(position, direction, out hitInfo, maxDistance, num, QueryTriggerInteraction.Ignore);
			if (num2 > 0)
			{
				for (int j = 0; j < num2; j++)
				{
					IgnoredGameObject ignoredGameObject2 = _ignoredGameObjects[j];
					if (ignoredGameObject2.Active)
					{
						ignoredGameObject2.GameObject.layer = ignoredGameObject2.Layer;
					}
				}
			}
			if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == 31)
			{
				PartScript componentInParent = hitInfo.collider.GetComponentInParent<PartScript>();
				if (componentInParent != null)
				{
					if (componentInParent.CraftScript == base.PartScript.CraftScript)
					{
						flag = false;
						IgnoreGameObjectInRaycast(hitInfo.collider.gameObject);
					}
				}
				else
				{
					flag = false;
					IgnoreGameObjectInRaycast(hitInfo.collider.gameObject);
				}
			}
			if (flag)
			{
				SetGroundedState(hitInfo.collider, hitInfo.normal, hitInfo.point);
				_suspensionCompressionPrev = base.Data.SuspensionCompression;
				base.Data.SuspensionCompression = base.Data.SuspensionDistance - hitInfo.distance / Scale;
				_ = base.Data.SuspensionCompression;
				_ = base.Data.SuspensionDistance;
			}
			else
			{
				ResetGroundedState();
			}
		}

		private void UpdateSuspsensionSettings()
		{
			Scale = _rayOrigin.lossyScale.y;
			if (Game.InFlightScene)
			{
				_damper = 750f * base.Data.Damper;
				float mass = base.PartScript.CraftScript.Mass;
				float num = (float)base.PartScript.CraftScript.CraftNode.Parent.PlanetData.SurfaceGravity;
				int num2 = 3;
				if (base.PartScript.Data.SymmetryId.HasValue)
				{
					num2 = base.PartScript.CraftScript.Data.Assembly.Parts.Where(delegate(PartData x)
					{
						Guid? symmetryId = x.SymmetryId;
						Guid? symmetryId2 = base.PartScript.Data.SymmetryId;
						if (symmetryId.HasValue != symmetryId2.HasValue)
						{
							return false;
						}
						return !symmetryId.HasValue || symmetryId.GetValueOrDefault() == symmetryId2.GetValueOrDefault();
					}).Count();
				}
				IBodyScript bodyScript = base.PartScript.BodyScript;
				if (bodyScript != null && bodyScript.Data.Parts.Count == 1)
				{
					_springForce = 0f;
					_maxSpringForce = 0f;
					_damper = 0f;
				}
				else if (base.Data.SuspensionType == LandingLegSuspensionData.LandingLegSuspensionType.Auto)
				{
					float num3 = (base.Data.MaxSuspensionDistance - base.Data.MinSuspensionDistance) * Scale;
					float num4 = base.Data.TargetCompression * num3;
					_springForce = mass * num / ((float)num2 * num4);
					_maxNormalForce = mass * num / (float)num2;
					_damper = _springForce / 4f * base.Data.Damper;
				}
				else if (base.Data.SuspensionType == LandingLegSuspensionData.LandingLegSuspensionType.Manual)
				{
					_springForce = 1500f * base.Data.Spring * Scale;
					_maxNormalForce = mass * num / (float)num2;
				}
			}
			else
			{
				_springForce = 0f;
			}
			_maxSpringForce = _springForce * 8f;
			_maxDamper = _damper * 4f;
		}
	}
}
