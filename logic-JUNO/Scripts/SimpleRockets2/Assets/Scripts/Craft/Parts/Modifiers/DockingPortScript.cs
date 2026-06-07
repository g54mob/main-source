using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.Audio;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Modifiers;
using ModApi.Design;
using ModApi.Flight.UI;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class DockingPortScript : PartModifierScript<DockingPortData>, IFlightFixedUpdate, IGameLoopItem, IFlightUpdate, IDockingPortScript
	{
		private const float ResetTime = 10f;

		private Transform _attachPointPositions;

		private DockingColliderScript _dockingCollider;

		private float _dockingPowerReducer;

		private float _dockResetTimer;

		private float _inspectorDockingStatusPercentage;

		private float _magneticAngularForce;

		private ConfigurableJoint _magneticJoint;

		private float _magneticJointForce;

		private float _magnetOverride = 1f;

		private float _magnetOvertimeAugmentation = -10f;

		private DockingPortScript _otherDockingPort;

		private Transform _scalar;

		private DockingPortScript _statusPort;

		Rigidbody IDockingPortScript.Body => base.PartScript.BodyScript.RigidBody;

		public AttachPoint DockingAttachPoint => base.PartScript.Data.AttachPoints[1];

		public float DockingTime { get; private set; }

		public float InspectorDockingStatusPercentage => _inspectorDockingStatusPercentage;

		public bool IsColliderReadyForDocking
		{
			get
			{
				return _dockingCollider.gameObject.activeSelf;
			}
			set
			{
				_dockingCollider.gameObject.SetActive(value);
			}
		}

		public bool IsDocked => DockingAttachPoint.PartConnections.Count > 0;

		public bool IsDocking
		{
			get
			{
				if (_otherDockingPort != null)
				{
					if (!(_magneticJoint != null))
					{
						return _otherDockingPort._magneticJoint != null;
					}
					return true;
				}
				return false;
			}
		}

		public bool IsReadyForDocking
		{
			get
			{
				if (IsColliderReadyForDocking)
				{
					return base.PartScript.Data.Activated;
				}
				return false;
			}
		}

		public bool IsUndocking => _dockResetTimer > 0f;

		public DockingPortScript OtherDockingPort => _otherDockingPort;

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			if (!(_otherDockingPort != null))
			{
				return;
			}
			float magnitude = (_otherDockingPort.GetJointWorldPosition() - GetJointWorldPosition()).magnitude;
			if (magnitude > 1.5f || _otherDockingPort.PartScript.Data.IsDestroyed)
			{
				DestroyMagneticJoint(readyForDocking: true);
			}
			else
			{
				if (!(_magneticJoint != null))
				{
					return;
				}
				float num = Vector3.Dot(-base.transform.up, _otherDockingPort.transform.up);
				float value = (num - 0.99f) / 0.01f * Mathf.Lerp(1f, 0f, Mathf.Clamp01(magnitude * 20f));
				_inspectorDockingStatusPercentage = Mathf.Clamp01(value);
				_otherDockingPort._inspectorDockingStatusPercentage = _inspectorDockingStatusPercentage;
				float angularDrag = Mathf.Lerp(0.05f, 1f, num);
				_magneticJoint.connectedBody.angularDrag = angularDrag;
				base.PartScript.BodyScript.RigidBody.angularDrag = angularDrag;
				_otherDockingPort.PartScript.BodyScript.RigidBody.angularDrag = angularDrag;
				if (num > 0.9999f && magnitude <= 0.01f)
				{
					CompleteDockConnection();
					return;
				}
				if (_magnetOvertimeAugmentation < 20f)
				{
					_magnetOvertimeAugmentation += frame.DeltaTime;
				}
				float num2 = 5000f * _dockingPowerReducer * Mathf.Max(1f, _magnetOvertimeAugmentation) * base.Data.MagnetForce * _magnetOverride * _otherDockingPort.Data.MagnetForce * _otherDockingPort._magnetOverride;
				_magneticJointForce = 0.01f * num2;
				_magneticAngularForce = 2f * _magneticJointForce;
				SetMagneticJointForces(_magneticJointForce, _magneticAngularForce);
			}
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			if (_dockResetTimer > 0f)
			{
				_dockResetTimer -= frame.DeltaTime;
			}
			else if (!IsDocked && !IsDocking && !IsColliderReadyForDocking)
			{
				IsColliderReadyForDocking = true;
			}
		}

		public string GetStatus()
		{
			if (_statusPort != null)
			{
				return _statusPort.GetStatus();
			}
			string result = null;
			if (!base.PartScript.Data.Activated)
			{
				result = "Disabled";
			}
			else if (IsColliderReadyForDocking)
			{
				result = "Ready";
			}
			else if (IsDocking)
			{
				result = $"Docking ({Units.GetPercentageString(_inspectorDockingStatusPercentage)})";
			}
			else if (IsDocked)
			{
				result = "Docked";
			}
			else if (_dockResetTimer > 0f)
			{
				result = "Undocking";
			}
			return result;
		}

		public override void OnDeactivated()
		{
			base.OnDeactivated();
			if (IsDocked)
			{
				Undock();
			}
			if (IsDocking)
			{
				AbortDocking();
			}
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			model.Add(new TextModel("Status", () => GetStatus()));
			IconButtonModel iconButtonModel = new IconButtonModel("Ui/Sprites/Flight/IconPartInspectorUndock", delegate
			{
				Undock();
			}, "Undock");
			iconButtonModel.DetermineVisibility = () => IsDocked;
			model.IconButtonRow.Add(iconButtonModel);
			TextModel textModel = new TextModel("Overtime Power Boost:", () => Utilities.FormatPercentage(Mathf.Max(1f, _magnetOvertimeAugmentation)));
			textModel.DetermineVisibility = () => IsDocking;
			model.Add(textModel);
			model.Add(new SliderModel("Magnetic Force", () => _magnetOverride, delegate(float x)
			{
				_magnetOverride = x;
			}, 0f, 1.2f));
		}

		public override void OnPhysicsChanged(bool enabled)
		{
			base.OnPhysicsChanged(enabled);
			if (!enabled && _magneticJoint != null)
			{
				DestroyMagneticJoint(readyForDocking: true);
			}
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			if (!created)
			{
				UpdateScale(repositionAttachedParts: true);
			}
		}

		public void OnTouchDockingPort(DockingPortScript otherDockingPort)
		{
			if (IsReadyForDocking && otherDockingPort.IsReadyForDocking)
			{
				Dock(otherDockingPort);
			}
		}

		public void Undock()
		{
			if (!base.PartScript.CraftScript.IsPhysicsEnabled || DockingAttachPoint.PartConnections.Count != 1)
			{
				return;
			}
			DockingPortScript otherDockingPort = null;
			PartConnection partConnection = DockingAttachPoint.PartConnections[0];
			foreach (IBodyJoint joint in base.PartScript.BodyScript.Joints)
			{
				if (joint.PartConnection != partConnection)
				{
					continue;
				}
				PartData otherPart = partConnection.GetOtherPart(base.PartScript.Data);
				otherDockingPort = otherPart.PartScript.GetModifier<DockingPortScript>();
				if (otherDockingPort != null)
				{
					otherDockingPort._dockResetTimer = 10f;
					otherDockingPort.IsColliderReadyForDocking = false;
					otherDockingPort.DockingTime = 0f;
				}
				_dockResetTimer = 10f;
				IsColliderReadyForDocking = false;
				DockingTime = 0f;
				Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
				foreach (Collider collider in componentsInChildren)
				{
					if (collider.enabled)
					{
						collider.enabled = false;
						collider.enabled = true;
					}
				}
				joint.Destroy();
				Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Flight.DockDisconnect, base.transform.position, userInterfaceSound: false);
				break;
			}
			if (!(otherDockingPort != null))
			{
				return;
			}
			UnityEventDispatcher.Instance.ExecuteYield<WaitForFixedUpdate>(delegate(int? x)
			{
				if (x == 0)
				{
					Vector3 force = 10f * (base.PartScript.CraftScript.CenterOfMass.position - otherDockingPort.PartScript.CraftScript.CenterOfMass.position).normalized;
					base.PartScript.BodyScript.RigidBody.WakeUp();
					base.PartScript.BodyScript.RigidBody.AddForceAtPosition(force, base.PartScript.CraftScript.CenterOfMass.position, ForceMode.Impulse);
				}
			}, 2);
		}

		public void UpdateScale(bool repositionAttachedParts = false)
		{
			if (!(_scalar != null))
			{
				return;
			}
			_scalar.localScale = base.Data.ScaledScale * Vector3.one;
			Dictionary<int, bool> movedParts = new Dictionary<int, bool>();
			foreach (Transform attachPointTransform in _attachPointPositions)
			{
				AttachPoint attachPoint = base.Data.Part.AttachPoints.Where((AttachPoint x) => x.Name == attachPointTransform.name).FirstOrDefault();
				if (attachPoint == null)
				{
					continue;
				}
				attachPoint.Scale = 0.5f * base.Data.ScaledScale;
				Vector3 position = attachPointTransform.position;
				attachPoint.Position = base.transform.InverseTransformPoint(position);
				if (!(attachPoint.AttachPointScript != null))
				{
					continue;
				}
				if (repositionAttachedParts)
				{
					Vector3 delta = position - attachPoint.AttachPointScript.transform.position;
					foreach (PartConnection partConnection in attachPoint.PartConnections)
					{
						DesignerUtilities.RepositionParts(base.Data.Part, partConnection, delta, movedParts);
					}
				}
				attachPoint.AttachPointScript.transform.localPosition = attachPoint.Position;
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_dockingCollider = GetComponentInChildren<DockingColliderScript>();
			_scalar = base.transform.Find("Scalar");
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("AttachPointPositions", _scalar.gameObject);
			if (gameObject != null)
			{
				_attachPointPositions = gameObject.transform;
			}
			IsColliderReadyForDocking = false;
			UpdateScale();
		}

		private static ConfigurableJoint CreateJoint(IBodyScript jointBody, Vector3 jointPosition, Vector3 jointAxis, Vector3 secondaryAxis, Rigidbody connectedBody, Vector3 connectedPosition)
		{
			ConfigurableJoint configurableJoint = jointBody.GameObject.AddComponent<ConfigurableJoint>();
			configurableJoint.connectedBody = connectedBody;
			configurableJoint.autoConfigureConnectedAnchor = false;
			configurableJoint.axis = jointAxis;
			configurableJoint.secondaryAxis = secondaryAxis;
			configurableJoint.anchor = jointPosition;
			configurableJoint.connectedAnchor = connectedPosition;
			configurableJoint.xMotion = ConfigurableJointMotion.Free;
			configurableJoint.yMotion = ConfigurableJointMotion.Free;
			configurableJoint.zMotion = ConfigurableJointMotion.Free;
			configurableJoint.angularXMotion = ConfigurableJointMotion.Free;
			configurableJoint.angularYMotion = ConfigurableJointMotion.Free;
			configurableJoint.angularZMotion = ConfigurableJointMotion.Free;
			configurableJoint.enableCollision = true;
			return configurableJoint;
		}

		private void AbortDocking()
		{
			DestroyMagneticJoint(readyForDocking: true);
		}

		private void CompleteDockConnection()
		{
			ICraftScript craftScript = base.PartScript.CraftScript;
			ICraftScript craftScript2 = _otherDockingPort.PartScript.CraftScript;
			if (craftScript2.CraftNode.IsPlayer && !craftScript.CraftNode.IsPlayer)
			{
				ICraftScript craftScript3 = craftScript;
				ICraftScript craftScript4 = craftScript2;
				craftScript2 = craftScript3;
				craftScript = craftScript4;
			}
			if (_otherDockingPort.PartScript.CraftScript != base.PartScript.CraftScript)
			{
				StartCoroutine(OnDockingCompleteNextFrame(craftScript.CraftNode.Name, craftScript.CraftNode.NodeId, craftScript2.CraftNode.Name, craftScript2.CraftNode.NodeId));
				CraftSplitter.MergeCraftNode(craftScript2.CraftNode as CraftNode, craftScript.CraftNode as CraftNode);
			}
			CraftBuilder.CreateBodyJoint(CreateDockingPartConnection(_otherDockingPort, craftScript));
			base.PartScript.PrimaryCollider.enabled = false;
			base.PartScript.PrimaryCollider.enabled = true;
			float dockingTime = (DockingTime = Time.time);
			_otherDockingPort.DockingTime = dockingTime;
			DestroyMagneticJoint(readyForDocking: false);
			INavSphere navSphere = Game.Instance.FlightScene?.FlightSceneUI.NavSphere;
			if (navSphere != null && navSphere.HeadingLocked && navSphere.LockedIndicator == NavSphereIndicatorType.Target)
			{
				navSphere.UnlockHeading();
			}
			CraftControls craftControls = base.PartScript.CraftScript?.ActiveCommandPod?.Controls;
			if (craftControls != null)
			{
				craftControls.Pitch = 0f;
				craftControls.Yaw = 0f;
				craftControls.Roll = 0f;
				craftControls.TranslateForward = 0f;
				craftControls.TranslateRight = 0f;
				craftControls.TranslateUp = 0f;
			}
			Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Flight.DockConnect, base.transform.position, userInterfaceSound: false);
		}

		private PartConnection CreateDockingPartConnection(DockingPortScript otherPort, ICraftScript craftScript)
		{
			PartConnection partConnection = new PartConnection(base.PartScript.Data, otherPort.PartScript.Data);
			partConnection.AddAttachment(DockingAttachPoint, otherPort.DockingAttachPoint);
			craftScript.Data.Assembly.AddPartConnection(partConnection);
			IBodyScript bodyScript = base.PartScript.BodyScript;
			IBodyScript bodyScript2 = otherPort.PartScript.BodyScript;
			partConnection.BodyJointData = new BodyJointData(partConnection);
			partConnection.BodyJointData.Axis = Vector3.right;
			partConnection.BodyJointData.SecondaryAxis = Vector3.up;
			partConnection.BodyJointData.Position = bodyScript.Transform.InverseTransformPoint(base.PartScript.Transform.TransformPoint(DockingAttachPoint.Position));
			partConnection.BodyJointData.ConnectedPosition = bodyScript2.Transform.InverseTransformPoint(otherPort.PartScript.Transform.TransformPoint(otherPort.DockingAttachPoint.Position));
			partConnection.BodyJointData.BreakTorque = 400000f * base.Data.Scale;
			partConnection.BodyJointData.JointType = BodyJointData.BodyJointType.Docking;
			partConnection.BodyJointData.Body = bodyScript.Data;
			partConnection.BodyJointData.ConnectedBody = bodyScript2.Data;
			return partConnection;
		}

		private void DestroyMagneticJoint(bool readyForDocking)
		{
			if (_magneticJoint != null)
			{
				_magneticJoint.connectedBody.angularDrag = 0.05f;
				base.PartScript.BodyScript.RigidBody.angularDrag = 0.05f;
				IsColliderReadyForDocking = readyForDocking;
				_otherDockingPort.IsColliderReadyForDocking = readyForDocking;
				Object.DestroyImmediate(_magneticJoint);
				_magneticJoint = null;
				_otherDockingPort._statusPort = null;
				_otherDockingPort = null;
				base.PartScript.CraftScript.DockComplete -= OnDockComplete;
				base.PartScript.CraftScript.DockBegin -= OnDockBegin;
			}
		}

		private void Dock(DockingPortScript otherPort)
		{
			_otherDockingPort = otherPort;
			_otherDockingPort._statusPort = this;
			IsColliderReadyForDocking = false;
			otherPort.IsColliderReadyForDocking = false;
			IBodyScript bodyScript = base.PartScript.BodyScript;
			IBodyScript bodyScript2 = otherPort.PartScript.BodyScript;
			Vector3 jointPosition = GetJointPosition();
			Vector3 jointPosition2 = otherPort.GetJointPosition();
			if (_otherDockingPort._magneticJoint == null)
			{
				_magneticJoint = CreateJoint(bodyScript, jointPosition, bodyScript.Transform.InverseTransformDirection(base.transform.up), bodyScript.Transform.InverseTransformDirection(base.transform.right), bodyScript2.RigidBody, jointPosition2);
				_magnetOvertimeAugmentation = -10f;
				_magneticJointForce = 0f;
				_magneticAngularForce = 0f;
				SetMagneticJointForces(_magneticJointForce, _magneticAngularForce);
				Quaternion targetBodyLocalRotation = Quaternion.FromToRotation(bodyScript.Transform.InverseTransformDirection(otherPort.transform.up), bodyScript.Transform.InverseTransformDirection(-base.transform.up));
				CraftBuilder.SetJointTargetRotation(_magneticJoint, targetBodyLocalRotation);
			}
			else
			{
				_magneticJoint = null;
			}
			_dockingPowerReducer = 1f;
			base.PartScript.CraftScript.OnDockBegin(this, _otherDockingPort);
			base.PartScript.CraftScript.DockComplete += OnDockComplete;
			base.PartScript.CraftScript.DockBegin += OnDockBegin;
		}

		private Vector3 GetJointPosition()
		{
			return base.PartScript.BodyScript.Transform.InverseTransformPoint(GetJointWorldPosition());
		}

		private Vector3 GetJointWorldPosition()
		{
			return base.PartScript.Transform.TransformPoint(DockingAttachPoint.Position);
		}

		private void OnDockBegin(IDockingPortScript portA, IDockingPortScript portB)
		{
			if (portA.Body == base.PartScript.BodyScript.RigidBody || portB.Body == base.PartScript.BodyScript.RigidBody)
			{
				_dockingPowerReducer *= 0.1f;
			}
		}

		private void OnDockComplete(string playerCraftName, int playerNodeId, string otherCraftName, int otherNodeId)
		{
			if (IsDocking)
			{
				AbortDocking();
			}
		}

		private IEnumerator OnDockingCompleteNextFrame(string playerCraftName, int playerNodeId, string otherCraftName, int otherNodeId)
		{
			yield return null;
			(base.PartScript.CraftScript as CraftScript).OnDockComplete(playerCraftName, playerNodeId, otherCraftName, otherNodeId);
		}

		private void SetMagneticJointForces(float jointForce, float angularForce)
		{
			JointDrive jointDrive = new JointDrive
			{
				maximumForce = jointForce,
				positionSpring = jointForce,
				positionDamper = 10f
			};
			_magneticJoint.xDrive = jointDrive;
			_magneticJoint.yDrive = jointDrive;
			_magneticJoint.zDrive = jointDrive;
			_magneticJoint.rotationDriveMode = RotationDriveMode.XYAndZ;
			JointDrive jointDrive2 = new JointDrive
			{
				maximumForce = angularForce,
				positionSpring = angularForce,
				positionDamper = 20f
			};
			_magneticJoint.targetAngularVelocity = Vector3.zero;
			_magneticJoint.slerpDrive = jointDrive2;
			_magneticJoint.angularXDrive = jointDrive2;
			_magneticJoint.angularYZDrive = jointDrive2;
		}
	}
}
