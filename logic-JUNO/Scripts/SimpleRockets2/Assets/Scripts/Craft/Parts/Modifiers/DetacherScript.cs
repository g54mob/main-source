using System.Collections.Generic;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Flight.GameView;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class DetacherScript : PartModifierScript<DetacherData>, IDesignerStart, IGameLoopItem, IFlightStart, IFlightUpdate
	{
		private const float _baseFrequency = 20f;

		private const float _baseIntensity = 0.1f;

		private Transform _attachPointPositions;

		private ICameraShake _cameraShake;

		private float _intensity = -1f;

		private Transform _scalar;

		public void Detach()
		{
			foreach (AttachPoint attachPoint in base.PartScript.Data.AttachPoints)
			{
				if (!base.Data.TargetAttachPointNames.Contains(attachPoint.Name))
				{
					continue;
				}
				PartConnection[] array = attachPoint.PartConnections.ToArray();
				foreach (PartConnection partConnection in array)
				{
					if (!partConnection.IsPhysicsJoint)
					{
						continue;
					}
					IBodyJoint[] array2 = base.PartScript.BodyScript.Joints.ToArray();
					foreach (IBodyJoint bodyJoint in array2)
					{
						if (partConnection != bodyJoint.PartConnection)
						{
							continue;
						}
						IBodyJoint bodyJoint2 = bodyJoint;
						if (bodyJoint2 != null && !bodyJoint2.PartConnection.IsDestroyed)
						{
							float num = 5000f * ((base.Data.Version == 1) ? 1f : base.PartScript.Data.Mass) * base.Data.Force * 0.01f;
							Vector3 vector = num * base.PartScript.Transform.TransformDirection(Quaternion.Euler(attachPoint.Rotation) * -Vector3.forward);
							_intensity = 0.1f * num / base.PartScript.CraftScript.Mass;
							_cameraShake.AddShake(GetShakeIntensity, GetShakeFrequency);
							bodyJoint2.Destroy();
							IBodyScript bodyScript = base.PartScript.BodyScript;
							bodyScript.RigidBody.WakeUp();
							bodyScript.RigidBody.AddForceAtPosition(vector, base.PartScript.Transform.position, ForceMode.Impulse);
							bodyJoint.OtherBody(bodyScript).RigidBody.AddForceAtPosition(-vector, base.PartScript.Transform.position, ForceMode.Impulse);
							AudioSource componentInChildren = GetComponentInChildren<AudioSource>();
							if (componentInChildren != null)
							{
								componentInChildren.Play();
							}
						}
					}
				}
			}
		}

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			UpdateScale();
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			UpdateScale();
			_cameraShake = Game.Instance.FlightScene.ViewManager.GameView.GameCamera.CameraShake;
		}

		public void FlightUpdate(in FlightFrameData frame)
		{
			if (_intensity > 0f)
			{
				if (_intensity <= 0.01f)
				{
					_intensity = -1f;
					_cameraShake.RemoveShake(GetShakeIntensity, GetShakeFrequency);
				}
				else
				{
					_intensity *= 1f - 4f * Time.deltaTime;
				}
			}
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			UpdateScale(repositionAttachedParts: true);
		}

		public void UpdateScale(bool repositionAttachedParts = false)
		{
			if (!(base.Data.Part.PartType.Id == "DetacherSide1") || !(_scalar != null) || !(_attachPointPositions != null))
			{
				return;
			}
			_scalar.localScale = Vector3.one * base.Data.Scale;
			Dictionary<int, bool> movedParts = new Dictionary<int, bool>();
			foreach (Transform attachPointPosition in _attachPointPositions)
			{
				foreach (AttachPoint attachPoint in base.Data.Part.AttachPoints)
				{
					if (!(attachPoint.Name == attachPointPosition.name))
					{
						continue;
					}
					attachPoint.Scale = 1f * base.Data.Scale;
					Vector3 position = attachPoint.Position;
					attachPoint.Position = attachPointPosition.localPosition * base.Data.Scale + _scalar.localPosition * (1f - base.Data.Scale);
					if (!(attachPoint.AttachPointScript != null))
					{
						break;
					}
					if (repositionAttachedParts)
					{
						Vector3 position2 = attachPoint.Position;
						Vector3 delta = attachPoint.AttachPointScript.transform.parent.TransformVector(position2 - position);
						foreach (PartConnection partConnection in attachPoint.PartConnections)
						{
							DesignerUtilities.RepositionParts(base.Data.Part, partConnection, delta, movedParts);
						}
					}
					attachPoint.AttachPointScript.transform.localPosition = attachPoint.Position;
					break;
				}
			}
		}

		public override void OnActivated()
		{
			if (base.Data.DetachOnActivated)
			{
				Detach();
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			if (base.Data.Part.PartType.Id == "DetacherSide1")
			{
				_scalar = base.transform.Find("RadialDetacher");
				GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("AttachPointPositions", _scalar.gameObject);
				if (gameObject != null)
				{
					_attachPointPositions = gameObject.transform;
				}
				UpdateScale();
			}
		}

		private float GetShakeFrequency()
		{
			return 20f;
		}

		private float GetShakeIntensity()
		{
			return _intensity;
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			FlightUpdate(in frame);
		}
	}
}
