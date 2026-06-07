using DV.MultipleUnit;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace LocoSim.DVExtensions.Slugs
{
	public class SlugsPowerProviderModule : MonoBehaviour
	{
		[PortId(PortType.READONLY_OUT, PortValueType.VOLTS, false)]
		public string generatorVoltagePortId;

		[PortId(PortType.EXTERNAL_IN, PortValueType.OHMS, true)]
		public string slugsEffectiveResistancePortId;

		[PortId(PortType.EXTERNAL_IN, PortValueType.AMPS, true)]
		public string slugsTotalAmpsPortId;

		[FuseId]
		public string powerFuseId;

		private Port generatorVoltageReadOut;

		private Port slugsEffectiveResistancePort;

		private Port slugsTotalAmpsPort;

		private Fuse powerFuse;

		private MultipleUnitModule muModule;

		private SlugModule frontSlug;

		private SlugModule rearSlug;

		private void Start()
		{
			TrainCar trainCar = TrainCar.Resolve(base.transform);
			muModule = ((trainCar != null) ? trainCar.muModule : null);
			if (muModule == null)
			{
				Debug.LogError("Couldn't find muModule, SlugsPowerProviderModule can't be properly initialized. Destroying self!", base.gameObject);
				Object.Destroy(this);
				return;
			}
			SimulationFlow simulationFlow = ((!(trainCar != null)) ? null : trainCar.SimController?.simFlow);
			if (simulationFlow == null)
			{
				Debug.LogError("Couldn't find simFlow, SlugsPowerProviderModule can't be properly initialized. Destroying self!", base.gameObject);
				Object.Destroy(this);
				return;
			}
			if (!simulationFlow.TryGetPort(generatorVoltagePortId, out generatorVoltageReadOut) || !simulationFlow.TryGetPort(slugsEffectiveResistancePortId, out slugsEffectiveResistancePort) || !simulationFlow.TryGetPort(slugsTotalAmpsPortId, out slugsTotalAmpsPort) || !simulationFlow.TryGetFuse(powerFuseId, out powerFuse))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: SlugsPowerProviderModule isn't initialized properly. Destroying self!", base.gameObject);
				Object.Destroy(this);
				return;
			}
			powerFuse.StateUpdated += OnPowerFuseChange;
			generatorVoltageReadOut.ValueUpdatedInternally += OnGeneratorVoltageChange;
			muModule.FrontCable.ConnectionChanged += OnSlugsConnectionChange;
			muModule.RearCable.ConnectionChanged += OnSlugsConnectionChange;
			RefreshSlugConnections();
			OnSlugAmpsChange();
			OnSlugResistanceChange();
			OnGeneratorVoltageChange(0f);
		}

		private void OnDestroy()
		{
			powerFuse.StateUpdated -= OnPowerFuseChange;
			generatorVoltageReadOut.ValueUpdatedInternally -= OnGeneratorVoltageChange;
			muModule.FrontCable.ConnectionChanged -= OnSlugsConnectionChange;
			muModule.RearCable.ConnectionChanged -= OnSlugsConnectionChange;
		}

		private void RefreshSlugConnections()
		{
			SlugModule slugModule = frontSlug;
			MultipleUnitCable connectedTo = muModule.FrontCable.connectedTo;
			frontSlug = connectedTo?.muModule?.GetComponentInChildren<SlugModule>();
			if (frontSlug != slugModule)
			{
				if (slugModule != null)
				{
					slugModule.DisconnectProvider(this);
				}
				if (frontSlug != null)
				{
					frontSlug.ConnectProvider(this, connectedTo);
				}
			}
			SlugModule slugModule2 = rearSlug;
			MultipleUnitCable connectedTo2 = muModule.RearCable.connectedTo;
			rearSlug = connectedTo2?.muModule?.GetComponentInChildren<SlugModule>();
			if (rearSlug != slugModule2)
			{
				if (slugModule2 != null)
				{
					slugModule2.DisconnectProvider(this);
				}
				if (rearSlug != null)
				{
					rearSlug.ConnectProvider(this, connectedTo2);
				}
			}
			if (frontSlug == null && rearSlug == null)
			{
				OnSlugAmpsChange();
				OnSlugResistanceChange();
			}
		}

		private void OnSlugsConnectionChange(bool _, bool __)
		{
			RefreshSlugConnections();
		}

		public bool PowerFuseState()
		{
			return powerFuse.State;
		}

		private void OnPowerFuseChange(bool _)
		{
			if (frontSlug != null)
			{
				frontSlug.OnPowerFuseChange();
			}
			if (rearSlug != null)
			{
				rearSlug.OnPowerFuseChange();
			}
		}

		public void OnSlugAmpsChange()
		{
			float num = ((frontSlug != null) ? frontSlug.AmpsPerProvider() : 0f);
			float num2 = ((rearSlug != null) ? rearSlug.AmpsPerProvider() : 0f);
			slugsTotalAmpsPort.ExternalValueUpdate(num + num2);
		}

		public void OnSlugResistanceChange()
		{
			float num = ((frontSlug != null) ? frontSlug.EffectiveResistancePerProvider() : float.PositiveInfinity);
			float num2 = ((rearSlug != null) ? rearSlug.EffectiveResistancePerProvider() : float.PositiveInfinity);
			slugsEffectiveResistancePort.ExternalValueUpdate(1f / (1f / num + 1f / num2));
		}

		public float GeneratorVoltage()
		{
			return generatorVoltageReadOut.Value;
		}

		private void OnGeneratorVoltageChange(float _)
		{
			if (frontSlug != null)
			{
				frontSlug.OnAppliedVoltageChange();
			}
			if (rearSlug != null)
			{
				rearSlug.OnAppliedVoltageChange();
			}
		}
	}
}
