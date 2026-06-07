using System;
using System.Linq;
using Assets.Scripts.Craft.Parts.Events;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain.Tree;
using Jundroo.Common.Utils;
using NWH.VehiclePhysics2.Powertrain;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public class JDriveShaftScript : PowertrainModifierScript
	{
		[SerializeField]
		private Transform _bootEnd;

		private float _bootScale = 1f;

		[SerializeField]
		private Transform _bootStart;

		private Transform _connectionA;

		private Transform _connectionB;

		[SerializeField]
		private Transform _directionRoot;

		private bool _flipped;

		private PowertrainComponent _inputPowertrainComponent;

		private Vector3 _lastDirection;

		[SerializeField]
		private Transform _scaleRoot;

		[SerializeField]
		private Transform _spinRoot;

		public JDriveShaftData Data { get; private set; }

		public override PowertrainNode CreatePowertrainNode(PowertrainNodeConnection inputConnection)
		{
			if (inputConnection == null)
			{
				throw new ArgumentNullException("inputConnection");
			}
			PowertrainNode powertrainNode = new PowertrainNode(this, inputConnection);
			inputConnection.ChildConnectionTransform = Utilities.FindFirstGameObjectMyselfOrChildren("PowertrainInput", base.gameObject)?.transform;
			if (base.PartScript.Part.AttachPoints.Count >= 2)
			{
				PartConnection partConnection = null;
				_flipped = base.PartScript.Part.AttachPoints[1].PartConnections.Contains(inputConnection.PartConnection);
				partConnection = ((!_flipped) ? base.PartScript.Part.AttachPoints[1].PartConnections.FirstOrDefault() : base.PartScript.Part.AttachPoints[0].PartConnections.FirstOrDefault());
				if (partConnection != null)
				{
					IPowertrainNode otherPowertrainPartNode = PowertrainBuilder.GetOtherPowertrainPartNode(base.PartScript.Part, partConnection);
					PowertrainNodeConnection powertrainConnection = new PowertrainNodeConnection(powertrainNode, partConnection, null);
					powertrainConnection.MaxTotalGearRatio = inputConnection.MaxTotalGearRatio;
					PowertrainNode outputNode = otherPowertrainPartNode.CreatePowertrainNode(powertrainConnection);
					powertrainNode.AddChild(outputNode);
					powertrainNode.InitializePowertrain = delegate(IPowertrain powertrain, PowertrainComponent inputComponent)
					{
						_inputPowertrainComponent = inputComponent;
						PowertrainComponent result = outputNode?.InitializePowertrain?.Invoke(powertrain, inputComponent);
						if (!_flipped)
						{
							_connectionA = inputConnection.ParentConnectionTransform;
							_connectionB = powertrainConnection.ChildConnectionTransform;
							return result;
						}
						_connectionA = powertrainConnection.ChildConnectionTransform;
						_connectionB = inputConnection.ParentConnectionTransform;
						return result;
					};
				}
			}
			return powertrainNode;
		}

		public void Initialize(JDriveShaftData data)
		{
			Data = data;
			if (data.IsVisual)
			{
				base.PartScript.PartConnectionChanged += OnPartConnectionsChanged;
				if (_bootStart != null)
				{
					_bootScale = _bootStart.localScale.x;
				}
				if (base.LoadContext == CraftLoadContext.Designer)
				{
					base.PartScript.AttachPointScripts[0].transform.localPosition = Data.LocalAttachStart;
					base.PartScript.AttachPointScripts[1].transform.localPosition = Data.LocalAttachEnd;
					base.PartScript.AttachPointScripts[0].SupportsDragging = true;
					base.PartScript.AttachPointScripts[1].SupportsDragging = true;
				}
				else
				{
					Vector3 left = base.PartScript.transform.TransformPoint(Data.LocalAttachStart);
					Vector3 right = base.PartScript.transform.TransformPoint(Data.LocalAttachEnd);
					UpdateBeam(left, right);
				}
				UpdateBootVisuals();
			}
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				base.PartScript.Aircraft.OnAircraftStructureChanged += OnAircraftStructureChanged;
			}
		}

		public override void OnMirrored(PartData sourcePart)
		{
			base.OnMirrored(sourcePart);
			MirrorAttachPointPosition(base.PartScript.AttachPointScripts[0]);
			MirrorAttachPointPosition(base.PartScript.AttachPointScripts[1]);
		}

		public void OnSaveState()
		{
			Data.LocalAttachStart = base.PartScript.AttachPointScripts[0].transform.localPosition;
			Data.LocalAttachEnd = base.PartScript.AttachPointScripts[1].transform.localPosition;
		}

		public void UpdateBootVisuals()
		{
			_lastDirection = Vector3.zero;
			if (_bootStart != null)
			{
				_bootStart.gameObject.SetActive(Data.BootA);
				_bootEnd.gameObject.SetActive(Data.BootB);
				_bootStart.localScale = _bootScale * Data.Radius * Vector3.one;
				_bootEnd.localScale = _bootScale * Data.Radius * Vector3.one;
			}
		}

		protected void LateUpdate()
		{
			if (Data.IsVisual)
			{
				Transform connectionA = _connectionA;
				Vector3? vector = (((object)connectionA != null) ? new Vector3?(connectionA.position) : ((base.LoadContext == CraftLoadContext.Designer) ? new Vector3?(base.PartScript.AttachPointScripts[0].transform.position) : ((Vector3?)null)));
				Transform connectionB = _connectionB;
				Vector3? vector2 = (((object)connectionB != null) ? new Vector3?(connectionB.position) : ((base.LoadContext == CraftLoadContext.Designer) ? new Vector3?(base.PartScript.AttachPointScripts[1].transform.position) : ((Vector3?)null)));
				if (vector.HasValue && vector2.HasValue)
				{
					UpdateBeam(vector.Value, vector2.Value);
				}
			}
		}

		protected virtual void OnDestroy()
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				base.PartScript.Aircraft.OnAircraftStructureChanged -= OnAircraftStructureChanged;
			}
			if (Data.IsVisual)
			{
				base.PartScript.PartConnectionChanged -= OnPartConnectionsChanged;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
			registrar.RegisterUpdate(FlightLocalUnpaused, CraftUpdateFlags.FlightLocalUnpaused);
		}

		private void FlightLocalUnpaused(in CraftUpdateFrameData frame)
		{
			float? num = _inputPowertrainComponent?.inputTorque;
			if (Data.IsVisual && num.HasValue && num.Value != 0f)
			{
				float z = (_flipped ? 1f : (-1f)) * _inputPowertrainComponent.inputAngularVelocity * Time.deltaTime * 57.29578f;
				_spinRoot.localRotation *= Quaternion.Euler(0f, 0f, z);
			}
		}

		private Transform GetConnectedAttachPointTransform(AttachPointData ap)
		{
			return ap.PartConnections.FirstOrDefault()?.GetOtherAttachPoint(ap)?.AttachPointScript.transform;
		}

		private void MirrorAttachPointPosition(AttachPointScript attachPointScript)
		{
			if (Data.IsVisual)
			{
				Vector3 localPosition = attachPointScript.transform.localPosition;
				localPosition.y = 0f - localPosition.y;
				attachPointScript.transform.localPosition = localPosition;
			}
		}

		private void OnAircraftStructureChanged()
		{
			if (base.PartScript.Part.PartConnections.Count != 2)
			{
				_connectionA = null;
				_connectionB = null;
			}
		}

		private void OnPartConnectionsChanged(object sender, PartConnectionChangedEventArgs e)
		{
			UpdateDesignerConnections();
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			if (base.PartScript.LoadContext == CraftLoadContext.Designer)
			{
				UpdateDesignerConnections();
			}
		}

		private void UpdateAttachPointTypes()
		{
			if (Data.IsVisual)
			{
				AttachPointData attachPoint = base.PartScript.AttachPointScripts[0].AttachPoint;
				AttachPointData attachPoint2 = base.PartScript.AttachPointScripts[1].AttachPoint;
				if (IsConnectedToSeekerOf(attachPoint, AttachPointConnectionType.PowertrainInput))
				{
					attachPoint.SetConnectionTypes((AttachPointConnectionType)160, (AttachPointConnectionType)144);
					attachPoint2.SetConnectionTypes((AttachPointConnectionType)144, (AttachPointConnectionType)160);
					return;
				}
				if (IsConnectedToSeekerOf(attachPoint, AttachPointConnectionType.PowertrainOutput))
				{
					attachPoint.SetConnectionTypes((AttachPointConnectionType)144, (AttachPointConnectionType)160);
					attachPoint2.SetConnectionTypes((AttachPointConnectionType)160, (AttachPointConnectionType)144);
					return;
				}
				if (IsConnectedToSeekerOf(attachPoint2, AttachPointConnectionType.PowertrainInput))
				{
					attachPoint2.SetConnectionTypes((AttachPointConnectionType)160, (AttachPointConnectionType)144);
					attachPoint.SetConnectionTypes((AttachPointConnectionType)144, (AttachPointConnectionType)160);
					return;
				}
				if (IsConnectedToSeekerOf(attachPoint2, AttachPointConnectionType.PowertrainOutput))
				{
					attachPoint2.SetConnectionTypes((AttachPointConnectionType)144, (AttachPointConnectionType)160);
					attachPoint.SetConnectionTypes((AttachPointConnectionType)160, (AttachPointConnectionType)144);
					return;
				}
				AttachPointConnectionType seekType = (AttachPointConnectionType)176;
				AttachPointConnectionType receiveType = (AttachPointConnectionType)176;
				attachPoint.SetConnectionTypes(seekType, receiveType);
				attachPoint2.SetConnectionTypes(seekType, receiveType);
			}
			static bool IsConnectedToSeekerOf(AttachPointData myAp, AttachPointConnectionType typeTheySeek)
			{
				if (myAp.PartConnections.Count != 1)
				{
					return false;
				}
				return myAp.PartConnections[0].GetOtherAttachPoint(myAp).SeekType.HasFlag(typeTheySeek);
			}
		}

		private void UpdateBeam(Vector3 left, Vector3 right)
		{
			Vector3 vector = right - left;
			if ((vector - _lastDirection).sqrMagnitude < 0.0001f)
			{
				return;
			}
			_lastDirection = vector;
			Vector3 position = (left + right) / 2f;
			base.PartScript.transform.position = position;
			if (!(vector.sqrMagnitude < 0.0001f))
			{
				_directionRoot.transform.rotation = Quaternion.LookRotation(vector, Vector3.up);
				float magnitude = vector.magnitude;
				_scaleRoot.transform.localScale = new Vector3(Data.Radius, Data.Radius, magnitude);
				_bootStart.localPosition = new Vector3(0f, 0f, (0f - magnitude) / 2f);
				_bootEnd.localPosition = new Vector3(0f, 0f, magnitude / 2f);
				if (base.LoadContext == CraftLoadContext.Designer)
				{
					Vector3 normalized = vector.normalized;
					base.PartScript.AttachPointScripts[0].transform.position = left;
					base.PartScript.AttachPointScripts[0].transform.forward = -normalized;
					base.PartScript.AttachPointScripts[1].transform.position = right;
					base.PartScript.AttachPointScripts[1].transform.forward = normalized;
				}
			}
		}

		private void UpdateDesignerConnections()
		{
			_connectionA = GetConnectedAttachPointTransform(base.PartScript.Part.AttachPoints[0]);
			_connectionB = GetConnectedAttachPointTransform(base.PartScript.Part.AttachPoints[1]);
			UpdateAttachPointTypes();
		}
	}
}
