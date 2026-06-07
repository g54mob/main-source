using System;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain.Tree;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public class JDriveHubScript : PowertrainModifierScript
	{
		private RigidbodySpinnerComponent _spinner;

		public JDriveHubData Data { get; private set; }

		public override PowertrainNode CreatePowertrainNode(PowertrainNodeConnection inputConnection)
		{
			if (inputConnection == null)
			{
				throw new ArgumentNullException("inputConnection");
			}
			inputConnection.ChildConnectionTransform = Utilities.FindFirstGameObjectMyselfOrChildren("PowertrainInput", base.gameObject)?.transform;
			return new PowertrainNode(this, inputConnection)
			{
				InitializePowertrain = delegate
				{
					_spinner = new RigidbodySpinnerComponent
					{
						Reversed = Data.IsReversed
					};
					UpdateSpinnerBodies(_spinner);
					return _spinner;
				}
			};
		}

		public void Initialize(JDriveHubData data)
		{
			Data = data;
		}

		public void OnPropertiesChanged()
		{
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart, CraftUpdateFlags.FlightLocal);
		}

		private void OnAircraftStructureChanged()
		{
			if (base.LoadContext == CraftLoadContext.Flight && _spinner != null)
			{
				UpdateSpinnerBodies(_spinner);
				SetupJoint();
			}
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			base.PartScript.Aircraft.OnAircraftStructureChanged += OnAircraftStructureChanged;
			SetupJoint();
		}

		private void SetupJoint()
		{
			ConfigurableJoint configurableJoint = null;
			int num = 0;
			if (base.PartScript.Part.AttachPoints.Count > num)
			{
				AttachPointData attachPointData = base.PartScript.Part.AttachPoints[num];
				if (attachPointData.PartConnections.Count == 1)
				{
					foreach (BodyJoint joint in base.PartScript.Body.Joints)
					{
						ConfigurableJoint jointForAttachPoint = joint.GetJointForAttachPoint(attachPointData);
						if (jointForAttachPoint != null)
						{
							configurableJoint = jointForAttachPoint;
							break;
						}
					}
				}
			}
			if (configurableJoint != null)
			{
				JointDrive angularXDrive = configurableJoint.angularXDrive;
				angularXDrive.positionDamper = 0f;
				angularXDrive.positionSpring = 0f;
				configurableJoint.angularXDrive = angularXDrive;
			}
		}

		private void UpdateSpinnerBodies(RigidbodySpinnerComponent spinner)
		{
			if (_spinner != null)
			{
				_spinner.targetRigidbody = base.PartScript.Body.RigidBody.PhysxRigidBody;
				_spinner.targetRigidbody.maxAngularVelocity = 100f;
				_spinner.sourceRigidbody = null;
				PartConnection partConnection = base.PartScript.Part.AttachPoints[0].PartConnections.FirstOrDefault();
				if (partConnection != null)
				{
					PartData otherPart = partConnection.GetOtherPart(base.PartScript.Part);
					_spinner.sourceRigidbody = otherPart.PartScript.Body.RigidBody.PhysxRigidBody;
					_spinner.localSpinAxis = _spinner.targetRigidbody.transform.InverseTransformDirection(-base.transform.up);
				}
			}
		}
	}
}
