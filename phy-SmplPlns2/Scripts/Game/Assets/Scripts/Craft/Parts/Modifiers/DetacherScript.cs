using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Events;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class DetacherScript : PartModifierScript
	{
		private class JointToDestroy
		{
			public bool ApplyForceAtCenterOfMass { get; private set; }

			public Vector3 DetachForce { get; private set; }

			public BodyJoint Joint { get; private set; }

			public JointToDestroy(BodyJoint joint, Vector3 detachForce, bool applyForceAtCenterOfMass)
			{
				Joint = joint;
				DetachForce = detachForce;
				ApplyForceAtCenterOfMass = applyForceAtCenterOfMass;
			}
		}

		private Func<bool> _activateFunc;

		private AudioSource _audio;

		private bool _detaching;

		private float _detachTimer;

		private int _frames;

		private PartScript _part;

		public DetacherData Detacher { get; private set; }

		public bool IsDamaged { get; protected set; }

		public bool IsDetached { get; set; }

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public void Detach()
		{
			if (base.LoadContext != CraftLoadContext.Flight || IsDetached)
			{
				return;
			}
			IsDetached = true;
			List<JointToDestroy> list = new List<JointToDestroy>();
			Vector3? vector = null;
			if (Detacher.Direction == DetacherData.DetacherDirection.Forward)
			{
				vector = base.PartScript.transform.forward;
			}
			foreach (int item in Detacher.AttachPointsToDetach)
			{
				AttachPointData attachPointData = base.PartScript.Part.AttachPoints[item];
				foreach (BodyJoint joint2 in _part.Body.Joints)
				{
					if (base.PartScript.Body == joint2.BodyA)
					{
						foreach (AttachPointData item2 in joint2.PartConnection.AttachPointsA)
						{
							if (item2 == attachPointData)
							{
								AttachPointData attachPointData2 = joint2.PartConnection.AttachPointsB.FirstOrDefault();
								bool applyForceAtCenterOfMass = attachPointData2?.DetachAtCenterOfMass ?? false;
								float num = attachPointData2?.DetachForceScale ?? 1f;
								Vector3 vector2 = vector ?? base.PartScript.transform.TransformDirection(item2.Normal);
								list.Add(new JointToDestroy(joint2, vector2 * num, applyForceAtCenterOfMass));
							}
						}
						continue;
					}
					foreach (AttachPointData item3 in joint2.PartConnection.AttachPointsB)
					{
						if (item3 == attachPointData)
						{
							AttachPointData attachPointData3 = joint2.PartConnection.AttachPointsA.FirstOrDefault();
							bool applyForceAtCenterOfMass2 = attachPointData3?.DetachAtCenterOfMass ?? false;
							float num2 = attachPointData3?.DetachForceScale ?? 1f;
							Vector3 vector3 = vector ?? base.PartScript.transform.TransformDirection(item3.Normal);
							list.Add(new JointToDestroy(joint2, vector3 * num2, applyForceAtCenterOfMass2));
						}
					}
				}
			}
			foreach (JointToDestroy item4 in list)
			{
				BodyJoint joint = item4.Joint;
				Vector3 detachForce = item4.DetachForce;
				if (!joint.PartConnection.IsDestroyed)
				{
					joint.Break(playSound: false);
					joint.BodyA.RigidBody.WakeUp();
					joint.BodyB.RigidBody.WakeUp();
					ApplySleepingBodyHackWhenBreakingJoint(joint);
					if (base.PartScript.Aircraft.InertiaTensorRecalculationEnabled)
					{
						joint.BodyA.RecalculateInertiaTensor = true;
						joint.BodyB.RecalculateInertiaTensor = true;
					}
					BodyScript bodyScript = ((!(joint.BodyA == _part.Body)) ? joint.BodyA : joint.BodyB);
					Vector3 position = base.PartScript.transform.position;
					if (item4.ApplyForceAtCenterOfMass)
					{
						position = bodyScript.RigidBody.worldCenterOfMass;
					}
					float detacherForce = Detacher.DetacherForce;
					if (detacherForce > 0f && float.IsFinite(detacherForce))
					{
						bodyScript.RigidBody.AddForceAtPosition(detachForce * (detacherForce * 0.01f), position, ForceMode.Impulse);
					}
					_audio.Play();
					ApplySpecialDetachmentLogic(bodyScript);
				}
			}
			base.PartScript.Aircraft.AircraftStructureChanged();
			base.PartScript.Aircraft.QueueDragRecalculation();
		}

		public void Initialize(DetacherData detacher)
		{
			Detacher = detacher;
			_audio = GetComponent<AudioSource>();
			_audio.volume = Detacher.DesignerForce;
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level >= PartDamageLevel.Moderate)
			{
				float value = UnityEngine.Random.value;
				if (value < 0.25f && !IsDamaged)
				{
					IsDamaged = true;
				}
				else if (value < 0.5f)
				{
					Detach();
				}
				else if (value < 0.9f)
				{
					Detacher.DetacherForce *= UnityEngine.Random.value;
				}
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightLocalUnpaused);
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocalUnpaused);
		}

		private static void ApplySleepingBodyHackWhenBreakingJoint(BodyJoint joint)
		{
			IRigidBody bodyA = joint.BodyA.RigidBody;
			IRigidBody bodyB = joint.BodyB.RigidBody;
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				bodyA?.PhysxRigidBody?.WakeUp();
				bodyB?.PhysxRigidBody?.WakeUp();
			}, 2);
		}

		private void ApplySpecialDetachmentLogic(BodyScript detachedBody)
		{
			if (detachedBody.PartGroups.Count == 1 && detachedBody.PartGroups[0].Parts.Count == 1)
			{
				PartScript partScript = detachedBody.PartGroups[0].Parts[0];
				BombScript modifier = partScript.GetModifier<BombScript>();
				if (modifier != null)
				{
					modifier.LaunchedViaDetacher = true;
				}
				MissileScript modifier2 = partScript.GetModifier<MissileScript>();
				if (modifier2 != null)
				{
					modifier2.LaunchedViaDetacher = true;
				}
				RocketWeaponScript modifier3 = partScript.GetModifier<RocketWeaponScript>();
				if (modifier3 != null)
				{
					modifier3.LaunchedViaDetacher = true;
				}
			}
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (_frames > 10 && _activateFunc() && Detacher.Enabled && !_detaching && !IsDetached)
			{
				_detaching = true;
				_detachTimer = Detacher.Delay;
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_part = base.transform.GetComponent<PartScript>();
			if (Detacher.Group == "Disabled")
			{
				_activateFunc = () => false;
			}
			else
			{
				_activateFunc = base.PartScript.Aircraft.Controls.GetActivatorGetter(Detacher.Group, base.PartScript);
			}
			return UniTask.CompletedTask;
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			_frames++;
			if (_frames > 10)
			{
				if (_detaching && _detachTimer <= 0f)
				{
					Detach();
					_detaching = false;
				}
				else if (_detachTimer > 0f)
				{
					_detachTimer -= frame.DeltaTime;
				}
			}
		}
	}
}
