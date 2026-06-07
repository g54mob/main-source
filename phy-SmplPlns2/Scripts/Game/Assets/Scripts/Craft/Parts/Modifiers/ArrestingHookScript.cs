using System;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class ArrestingHookScript : PartModifierScript
	{
		private AudioSource _audio;

		private bool _audioPlaying;

		private bool _activeBefore;

		private Func<bool> _activationFunc;

		private Transform _hinge;

		private Vector3 _hingeDefaultEulerAngles;

		private Vector3 _lastCastPoint;

		private Transform _pivot;

		private Vector3 _pivotDefaultEulerAngles;

		public bool Active { get; set; }

		public float CableDeceleration => Hook.CableDeceleration;

		public ArrestingHookData Hook { get; private set; }

		public bool Hooked { get; set; }

		public Vector3 HookPoint => HookTransform.position;

		public Transform HookTransform { get; private set; }

		public Vector3 LastCableForce { get; set; }

		public void Initialize(ArrestingHookData arrestingHook)
		{
			Hook = arrestingHook;
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				_activationFunc = base.PartScript.Aircraft.Controls.GetActivatorGetter(Hook.ActivationGroup, base.PartScript);
			}
			HookTransform = Utilities.FindFirstGameObjectMyselfOrChildren("HookPoint", base.gameObject).transform;
			_pivot = Utilities.FindFirstGameObjectMyselfOrChildren("Pivot", base.gameObject).transform;
			_hinge = Utilities.FindFirstGameObjectMyselfOrChildren("Hinge", base.gameObject).transform;
			_pivotDefaultEulerAngles = _pivot.localEulerAngles;
			_hingeDefaultEulerAngles = _hinge.localEulerAngles;
			_audio = base.transform.GetComponent<AudioSource>();
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocalUnpaused);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightDefault | CraftUpdateFlags.DesignerScene);
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			Active = _activationFunc();
			if (Active && !Hooked)
			{
				Vector3 vector = HookPoint - _lastCastPoint;
				if (Physics.Raycast(new Ray(_lastCastPoint, vector.normalized), out var hitInfo, vector.magnitude, 25, QueryTriggerInteraction.Collide) && hitInfo.collider.TryGetComponent<ArrestingCable>(out var component) && !component.InUse)
				{
					component.Arrest(this);
				}
				Collider[] array = Physics.OverlapSphere(HookPoint + Vector3.down * 0.075f, 0.05f, -30, QueryTriggerInteraction.Ignore);
				for (int i = 0; i < array.Length; i++)
				{
					if (!(array[i].GetComponentInParent<ArrestingHookScript>() != null))
					{
						_pivot.localRotation = Quaternion.RotateTowards(_pivot.localRotation, Quaternion.Euler(_pivotDefaultEulerAngles.x, _pivotDefaultEulerAngles.y, _pivotDefaultEulerAngles.z), Time.fixedDeltaTime * 100f * Mathf.Max(0.51f, 0f - base.PartScript.Body.RigidBody.velocity.y));
						_audioPlaying = false;
						break;
					}
				}
			}
			_lastCastPoint = HookPoint;
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (frame.CraftLoadContext == CraftLoadContext.Designer)
			{
				if (Hook.EditingProperties)
				{
					_pivot.localRotation = Quaternion.RotateTowards(_pivot.localRotation, Quaternion.Euler(0f - Hook.DeployedAngle, _pivotDefaultEulerAngles.y, _pivotDefaultEulerAngles.z), frame.DeltaTime * 50f);
					Hook.EditingProperties = false;
				}
				else
				{
					_pivot.localRotation = Quaternion.RotateTowards(_pivot.localRotation, Quaternion.Euler(_pivotDefaultEulerAngles.x, _pivotDefaultEulerAngles.y, _pivotDefaultEulerAngles.z), frame.DeltaTime * 50f);
				}
			}
			else
			{
				if (frame.Paused)
				{
					return;
				}
				float num;
				if (Active)
				{
					if (!_activeBefore)
					{
						_activeBefore = true;
						_audioPlaying = true;
					}
					if (Hooked && !Utilities.CompareVector3s(LastCableForce, Vector3.zero))
					{
						Vector3 eulerAngles = Quaternion.LookRotation(base.transform.InverseTransformPoint(base.transform.position.normalized - LastCableForce.normalized)).eulerAngles;
						num = Quaternion.Angle(_pivot.localRotation, Quaternion.Euler(eulerAngles.x, _pivotDefaultEulerAngles.y, _pivotDefaultEulerAngles.x));
						_pivot.localRotation = Quaternion.RotateTowards(_pivot.localRotation, Quaternion.Euler(eulerAngles.x, _pivotDefaultEulerAngles.y, _pivotDefaultEulerAngles.x), frame.DeltaTime * 100f);
						_hinge.localRotation = Quaternion.RotateTowards(_hinge.localRotation, Quaternion.Euler(_hingeDefaultEulerAngles.x, eulerAngles.y + 90f, _hingeDefaultEulerAngles.x), frame.DeltaTime * 100f);
					}
					else
					{
						num = Quaternion.Angle(_pivot.localRotation, Quaternion.Euler(0f - Hook.DeployedAngle, _pivotDefaultEulerAngles.y, _pivotDefaultEulerAngles.z));
						_pivot.localRotation = Quaternion.RotateTowards(_pivot.localRotation, Quaternion.Euler(0f - Hook.DeployedAngle, _pivotDefaultEulerAngles.y, _pivotDefaultEulerAngles.z), frame.DeltaTime * 50f);
						_hinge.localRotation = Quaternion.RotateTowards(_hinge.localRotation, Quaternion.Euler(_hingeDefaultEulerAngles), frame.DeltaTime * 50f);
					}
				}
				else
				{
					if (_activeBefore)
					{
						_activeBefore = false;
						_audioPlaying = true;
					}
					num = Quaternion.Angle(_pivot.localRotation, Quaternion.Euler(_pivotDefaultEulerAngles));
					_pivot.localRotation = Quaternion.RotateTowards(_pivot.localRotation, Quaternion.Euler(_pivotDefaultEulerAngles), frame.DeltaTime * 50f);
					_hinge.localRotation = Quaternion.RotateTowards(_hinge.localRotation, Quaternion.Euler(_hingeDefaultEulerAngles), frame.DeltaTime * 50f);
				}
				if (_audioPlaying)
				{
					if (num <= 1f)
					{
						_audioPlaying = false;
						_audio.Stop();
					}
					else if (!_audio.isPlaying)
					{
						_audio.Play();
						_audio.timeSamples = (int)(UnityEngine.Random.value * (float)_audio.clip.samples);
					}
				}
				else if (_audio.isPlaying)
				{
					_audio.Stop();
				}
			}
		}
	}
}
