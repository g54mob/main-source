using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain.Tree;
using Assets.Scripts.Design.Symmetry;
using Jundroo.Common.Utils;
using NWH.VehiclePhysics2.Powertrain;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public class JGearboxScript : PowertrainModifierScript, IMagicPowertrainSource, IEngineScaleResponder
	{
		private List<IPowertrainNode> _magicSinks;

		[SerializeField]
		private Transform _scaleRoot;

		private UpdateAttachPointsScript _updateAttachPoints;

		public JGearboxData Data { get; private set; }

		public override PowertrainNode CreatePowertrainNode(PowertrainNodeConnection inputConnection)
		{
			if (inputConnection == null)
			{
				throw new ArgumentNullException("inputConnection");
			}
			AttachPointData item = base.PartScript.Part.AttachPoints[1];
			if (inputConnection.PartConnection.AttachPointsA.Contains(item) || inputConnection.PartConnection.AttachPointsB.Contains(item))
			{
				Debug.LogWarning("Attempting to use output attach point as input attach point");
				return null;
			}
			inputConnection.ChildConnectionTransform = Utilities.FindFirstGameObjectMyselfOrChildren("PowertrainInput", base.gameObject)?.transform;
			PowertrainNode powertrainNode = new PowertrainNode(this, inputConnection);
			PowertrainNode outputNode = PowertrainBuilder.CreateOutputNode(powertrainNode, base.PartScript, _magicSinks, 1, "PowertrainOutput", Data.GearRatio);
			powertrainNode.InitializePowertrain = delegate(IPowertrain powertrain, PowertrainComponent inputComponent)
			{
				GearboxComponent gearboxComponent = new GearboxComponent
				{
					name = $"Gearbox-{base.PartScript.Part.Id}",
					inertia = 0.01f,
					GearRatio = Data.GearRatio * (Data.IsReversed ? (-1f) : 1f)
				};
				gearboxComponent.Output = outputNode?.InitializePowertrain?.Invoke(powertrain, gearboxComponent);
				return gearboxComponent;
			};
			return powertrainNode;
		}

		public void Initialize(JGearboxData data)
		{
			Data = data;
			_updateAttachPoints = GetComponent<UpdateAttachPointsScript>();
			UpdateScale();
		}

		public void OnEngineScaleChanged(float scaleRatio)
		{
			AttachPointScript attachPointScript = base.PartScript.AttachPointScripts[1];
			Vector3 position = attachPointScript.transform.position;
			Data.SizePercentage *= scaleRatio;
			UpdateScale();
			PartConnection partConnection = attachPointScript.AttachPoint.PartConnections.FirstOrDefault();
			if (partConnection != null && !partConnection.GetOtherPart(base.PartScript.Part).TryGetModifier<JDriveShaftData>(out var _))
			{
				SymmetryUtility.MoveConnectedParts(base.PartScript.Part, attachPointScript.AttachPoint, null, position, null, ignoreSymmetricParts: true);
			}
		}

		public void RegisterSink(IPowertrainNode node)
		{
			if (_magicSinks == null)
			{
				_magicSinks = new List<IPowertrainNode>();
			}
			_magicSinks.Add(node);
		}

		public void UpdateScale()
		{
			_scaleRoot.localScale = Data.Size * Vector3.one;
			if (base.PartScript.LoadContext == CraftLoadContext.Designer)
			{
				_updateAttachPoints.UpdateAttachPoints(base.PartScript, updateAttachedParts: false);
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart, CraftUpdateFlags.FlightLocal);
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
		}
	}
}
