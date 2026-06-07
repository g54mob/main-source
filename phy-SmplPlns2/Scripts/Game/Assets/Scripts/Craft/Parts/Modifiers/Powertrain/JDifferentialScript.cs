using Assets.Scripts.Craft.Parts.Modifiers.Powertrain.Tree;
using Assets.Scripts.Flight;
using Jundroo.Common.Utils;
using NWH.VehiclePhysics2.Powertrain;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public class JDifferentialScript : PowertrainModifierScript
	{
		private DifferentialComponent _differential;

		private IInputController _input;

		[SerializeField]
		private Transform _scaleRoot;

		private UpdateAttachPointsScript _updateAttachPoints;

		public JDifferentialData Data { get; private set; }

		public override PowertrainNode CreatePowertrainNode(PowertrainNodeConnection inputConnection)
		{
			PowertrainNode powertrainNode = new PowertrainNode(this, inputConnection);
			AttachPointData item = base.PartScript.Part.AttachPoints[1];
			AttachPointData item2 = base.PartScript.Part.AttachPoints[2];
			if (inputConnection.PartConnection.AttachPointsA.Contains(item) || inputConnection.PartConnection.AttachPointsB.Contains(item) || inputConnection.PartConnection.AttachPointsA.Contains(item2) || inputConnection.PartConnection.AttachPointsB.Contains(item2))
			{
				Debug.LogWarning("Attempting to use output attach point as input attach point");
				return null;
			}
			inputConnection.ChildConnectionTransform = Utilities.FindFirstGameObjectMyselfOrChildren("PowertrainInput", base.gameObject)?.transform;
			PowertrainNode nodeA = PowertrainBuilder.CreateOutputNode(powertrainNode, base.PartScript, null, 1, "PowertrainOutputA");
			PowertrainNode nodeB = PowertrainBuilder.CreateOutputNode(powertrainNode, base.PartScript, null, 2, "PowertrainOutputB");
			powertrainNode.InitializePowertrain = delegate(IPowertrain powertrain, PowertrainComponent inputComponent)
			{
				float differentialLock = Data.DifferentialLock;
				float num = powertrain.EnginePeakTorque * inputConnection.MaxTotalGearRatio * 1.5f;
				float num2 = Mathf.Max(num, 100f) / 1500f;
				DifferentialComponent differentialComponent = new DifferentialComponent
				{
					name = $"Differential-{base.PartScript.Part.Id}",
					biasAB = 0.5f,
					inertia = powertrain.EngineInertia * 0.1f,
					powerStiffness = differentialLock * Data.PowerStiffness * num2,
					coastStiffness = differentialLock * Data.CoastStiffness * num2
				};
				if (differentialLock >= 0.99f)
				{
					differentialComponent.slipTorque = num * 100f;
				}
				else
				{
					differentialComponent.slipTorque = num * Mathf.Pow(differentialLock, 2f);
				}
				powertrain.Powertrain.differentials.Add(differentialComponent);
				differentialComponent.Output = nodeA?.InitializePowertrain?.Invoke(powertrain, differentialComponent);
				differentialComponent.OutputB = nodeB?.InitializePowertrain?.Invoke(powertrain, differentialComponent);
				if (differentialComponent.Output == null || differentialComponent.OutputB == null)
				{
					FlightSceneScript.Instance.FlightUI.ShowMessage($"{base.PartScript.Part.Name} #{base.PartScript.Part.Id} is not connected correctly and will not function properly.");
				}
				_differential = differentialComponent;
				return differentialComponent;
			};
			return powertrainNode;
		}

		public void Initialize(JDifferentialData data)
		{
			Data = data;
			_updateAttachPoints = GetComponent<UpdateAttachPointsScript>();
			UpdateScale();
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
			registrar.RegisterStart(OnFlightStartLocal, CraftUpdateFlags.FlightLocal);
			registrar.RegisterUpdate(OnFlightUpdateLocalUnpaused, CraftUpdateFlags.FlightLocalUnpaused);
		}

		private void OnFlightStartLocal(in CraftUpdateFrameData frame)
		{
			_input = GetInputController("bias");
		}

		private void OnFlightUpdateLocalUnpaused(in CraftUpdateFrameData frame)
		{
			if (_differential != null && _input != null)
			{
				_differential.biasAB = Mathf.InverseLerp(-1f, 1f, _input.Value);
			}
		}
	}
}
