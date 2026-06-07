using System;
using System.Collections;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.Common;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Components;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MechanicalParts
{
	public class GrapplingHookProjectile : NimbatusObject
	{
		public enum EStickMode
		{
			None = 0,
			Rigidbody = 1,
			GameObject = 2
		}

		public LineRenderer LineRenderer;

		public int PointCount = 60;

		public float MaxAmplitude = 20f;

		private GrapplingHook _parent;

		private ConfigurableJoint _configJoint;

		private FixedJoint _fixedJoint;

		private Vector3 _offset;

		private bool _deployed;

		private bool _wantsToStick;

		private EStickMode _stickMode;

		private GameObject _stickObject;

		private float _currentLimit;

		private float CurrentLimit
		{
			get
			{
				return _currentLimit;
			}
			set
			{
				_currentLimit = Mathf.Clamp(value, 0.05f, _parent.MaxRange);
			}
		}

		public void Init(GrapplingHook parent)
		{
			_parent = parent;
			_configJoint = GetComponent<ConfigurableJoint>();
			_offset = base.transform.localPosition;
			ResetAll();
			Rigidbody.isKinematic = RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization;
		}

		public override void Update()
		{
			base.Update();
			if (ParentDead())
			{
				return;
			}
			if (_deployed)
			{
				LineRenderer.enabled = true;
				Vector3 position = _parent.transform.position;
				position = new Vector3(position.x, position.y, 1f);
				Vector3 vector = new Vector3(base.transform.position.x, base.transform.position.y, 1f) - position;
				float magnitude = vector.magnitude;
				float num = ((magnitude > 0.05f) ? Mathf.Clamp(CurrentLimit / magnitude - 1f, 0f, MaxAmplitude) : 0f);
				Vector3 vector2 = Vector3.Cross(vector, Vector3.forward);
				vector2.Normalize();
				LineRenderer.positionCount = PointCount;
				LineRenderer.SetPosition(0, position);
				for (int i = 1; i < PointCount; i++)
				{
					Vector3 vector3 = position + vector * ((float)i / (float)PointCount);
					float num2 = Mathf.Sin((float)i / ((float)PointCount - 1f) * 25f);
					Vector3 position2 = vector3 + vector2 * num2 * num;
					LineRenderer.SetPosition(i, position2);
				}
			}
			else if (LineRenderer != null)
			{
				LineRenderer.enabled = false;
			}
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (!_deployed || _parent.Returning || ParentDead())
			{
				return;
			}
			if (_stickMode != EStickMode.None && _fixedJoint == null)
			{
				Release();
			}
			if (_stickMode == EStickMode.Rigidbody && (_fixedJoint == null || _fixedJoint.connectedBody == null))
			{
				Release();
			}
			if (_stickMode == EStickMode.GameObject && (_stickObject == null || !_stickObject.activeInHierarchy || (_stickObject.layer == 8 && !TerrainModificationHelper.IsTerrainInArea(base.transform.position, base.transform.right, _parent.TerrainStickRadius, 360f))))
			{
				Release();
			}
			float num = (float)_parent.Strength / 100f * _parent.MaxRange * 2f * Time.fixedDeltaTime;
			if (_parent.Retracting)
			{
				CurrentLimit -= num;
				if (_stickMode == EStickMode.None && CurrentLimit < 2f && Vector2.Distance(base.transform.position, _parent.transform.position) < 4f)
				{
					Return();
				}
			}
			else if (_parent.Extending)
			{
				CurrentLimit += num;
			}
			ResetLinearLimit();
		}

		public void UpdateRotation(EWeaponRotation rotation)
		{
			if (_parent.HealthPool.CurrentState == EChemicalState.Frozen || _parent.HasNoInput)
			{
				base.transform.localRotation = _parent.LastProjectileRotation;
				return;
			}
			switch (rotation)
			{
			case EWeaponRotation.Cursor:
				base.transform.rotation = TransformHelper.Get2DRotationTowardsMouse(base.transform.position, RuntimeGlobals.Camera.Camera);
				break;
			case EWeaponRotation.Fixed:
				base.transform.localRotation = Quaternion.identity;
				break;
			default:
				throw new ArgumentOutOfRangeException("rotation", rotation, null);
			}
		}

		private bool ParentDead()
		{
			if (_parent == null || _parent.HealthPool.IsDead)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return true;
			}
			return false;
		}

		public void Fire()
		{
			_deployed = true;
			_wantsToStick = true;
			_parent.IsReadyToFire = false;
			_parent.InvokeRetracted(false);
			_configJoint.xMotion = ConfigurableJointMotion.Limited;
			_configJoint.yMotion = ConfigurableJointMotion.Limited;
			Rigidbody.AddForce(base.transform.right * _parent.ShootForce, ForceMode.Impulse);
		}

		private void Stick(Collision col)
		{
			DroneComponent component = col.gameObject.GetComponent<DroneComponent>();
			if (!(component != null) || component.SelectedCoating != ECoating.Frictionless)
			{
				_wantsToStick = false;
				Rigidbody.velocity = Vector3.zero;
				Rigidbody.angularVelocity = Vector3.zero;
				_fixedJoint = base.gameObject.AddComponent<FixedJoint>();
				_fixedJoint.enablePreprocessing = false;
				_fixedJoint.axis = Vector3.forward;
				_fixedJoint.breakForce = 20000f;
				_stickObject = col.gameObject;
				CurrentLimit = (_parent.transform.position - base.transform.position).magnitude;
				if (col.rigidbody == null)
				{
					_stickMode = EStickMode.GameObject;
				}
				else
				{
					_fixedJoint.connectedBody = col.rigidbody;
					_stickMode = EStickMode.Rigidbody;
				}
				_parent.InvokeHooked(true);
			}
		}

		public void Release()
		{
			if (_stickMode != EStickMode.None)
			{
				_parent.InvokeHooked(false);
			}
			if (_fixedJoint != null)
			{
				UnityEngine.Object.Destroy(_fixedJoint);
			}
			_stickObject = null;
			_stickMode = EStickMode.None;
		}

		public void Return()
		{
			if (!_parent.Returning && !ParentDead())
			{
				StartCoroutine(ReturnCoroutine());
			}
		}

		private IEnumerator ReturnCoroutine()
		{
			Release();
			_parent.Returning = true;
			CurrentLimit = 0f;
			Colliders.ForEach(delegate(Collider c)
			{
				c.enabled = false;
			});
			_configJoint.linearLimitSpring = new SoftJointLimitSpring
			{
				spring = 0f,
				damper = 0f
			};
			Vector3 pos = base.transform.position;
			float t = 0f;
			while (t < 1f && !ParentDead())
			{
				t += Time.deltaTime * 4f;
				base.transform.position = Vector3.Lerp(pos, _parent.transform.position, t);
				yield return null;
			}
			if (!ParentDead())
			{
				Colliders.ForEach(delegate(Collider c)
				{
					c.enabled = true;
				});
				Rigidbody.velocity = Vector3.zero;
				Rigidbody.angularVelocity = Vector3.zero;
				base.transform.localPosition = _offset;
				base.transform.localRotation = _parent.LastProjectileRotation;
				ResetAll();
				_deployed = false;
				_parent.Returning = false;
				_parent.IsReadyToFire = true;
				_parent.InvokeRetracted(true);
			}
		}

		private void ResetAll()
		{
			_configJoint.xMotion = ConfigurableJointMotion.Locked;
			_configJoint.yMotion = ConfigurableJointMotion.Locked;
			_configJoint.angularZMotion = ConfigurableJointMotion.Free;
			_configJoint.connectedAnchor = _offset;
			CurrentLimit = _parent.MaxRange;
			ResetLinearLimit();
		}

		private void ResetLinearLimit()
		{
			_configJoint.linearLimit = new SoftJointLimit
			{
				limit = CurrentLimit,
				bounciness = 0.1f,
				contactDistance = 0.1f
			};
			_configJoint.linearLimitSpring = new SoftJointLimitSpring
			{
				spring = 50f,
				damper = 4f
			};
		}

		public void OnCollisionEnter(Collision col)
		{
			if (!ParentDead() && _deployed && _wantsToStick && _parent.StickLayers.Contains(col.gameObject.layer))
			{
				Stick(col);
			}
		}
	}
}
