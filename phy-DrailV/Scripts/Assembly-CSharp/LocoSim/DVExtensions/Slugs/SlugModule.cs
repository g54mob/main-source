using DV.MultipleUnit;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace LocoSim.DVExtensions.Slugs
{
	public class SlugModule : MonoBehaviour
	{
		[PortId(PortType.EXTERNAL_IN, PortValueType.VOLTS, true)]
		public string appliedVoltagePortId;

		[PortId(PortType.READONLY_OUT, PortValueType.OHMS, true)]
		public string effectiveResistancePortId;

		[PortId(PortType.READONLY_OUT, PortValueType.AMPS, true)]
		public string totalAmpsPortId;

		[FuseId]
		public string powerFuseId;

		private Port appliedVoltageExtIn;

		private Port effectiveResistanceReadOut;

		private Port totalAmpsReadOut;

		private Fuse powerFuse;

		private SlugsPowerProviderModule frontProvider;

		private SlugsPowerProviderModule rearProvider;

		private void Start()
		{
			TrainCar trainCar = TrainCar.Resolve(base.transform);
			SimulationFlow simulationFlow = ((!(trainCar != null)) ? null : trainCar.SimController?.simFlow);
			if (simulationFlow == null)
			{
				Debug.LogError("Couldn't find simFlow, SlugModule can't be properly initialized. Destroying self!", base.gameObject);
				Object.Destroy(this);
			}
			else if (!simulationFlow.TryGetPort(appliedVoltagePortId, out appliedVoltageExtIn) || !simulationFlow.TryGetPort(totalAmpsPortId, out totalAmpsReadOut) || !simulationFlow.TryGetPort(effectiveResistancePortId, out effectiveResistanceReadOut) || !simulationFlow.TryGetFuse(powerFuseId, out powerFuse))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: SlugModule isn't initialized properly. Destroying self!", base.gameObject);
				Object.Destroy(this);
			}
			else
			{
				totalAmpsReadOut.ValueUpdatedInternally += OnAmpsChange;
				effectiveResistanceReadOut.ValueUpdatedInternally += OnResistanceChange;
			}
		}

		public float AmpsPerProvider()
		{
			float num = ((frontProvider != null && rearProvider != null) ? 0.5f : 1f);
			return Mathf.Max(0f, totalAmpsReadOut.Value * num);
		}

		public float EffectiveResistancePerProvider()
		{
			float num = ((frontProvider != null && rearProvider != null) ? 2f : 1f);
			return effectiveResistanceReadOut.Value * num;
		}

		public void ConnectProvider(SlugsPowerProviderModule provider, MultipleUnitCable slugMuCable)
		{
			if (slugMuCable.isFront)
			{
				if (frontProvider != null)
				{
					Debug.LogError("Already have a front provider!");
					return;
				}
				frontProvider = provider;
			}
			else
			{
				if (rearProvider != null)
				{
					Debug.LogError("Already have a rear provider!");
					return;
				}
				rearProvider = provider;
			}
			provider.OnSlugAmpsChange();
			provider.OnSlugResistanceChange();
			OnAppliedVoltageChange();
			OnPowerFuseChange();
		}

		public void DisconnectProvider(SlugsPowerProviderModule provider)
		{
			if (provider == frontProvider)
			{
				frontProvider = null;
			}
			else
			{
				if (!(provider == rearProvider))
				{
					Debug.LogError("Tried to disconnect provider that is not connected!");
					return;
				}
				rearProvider = null;
			}
			OnAppliedVoltageChange();
			OnPowerFuseChange();
			OnAmpsChange(0f);
			OnResistanceChange(0f);
		}

		private void OnAmpsChange(float _)
		{
			if (frontProvider != null)
			{
				frontProvider.OnSlugAmpsChange();
			}
			if (rearProvider != null)
			{
				rearProvider.OnSlugAmpsChange();
			}
		}

		private void OnResistanceChange(float _)
		{
			if (frontProvider != null)
			{
				frontProvider.OnSlugResistanceChange();
			}
			if (rearProvider != null)
			{
				rearProvider.OnSlugResistanceChange();
			}
		}

		public void OnPowerFuseChange()
		{
			bool flag = frontProvider != null && frontProvider.PowerFuseState();
			bool flag2 = rearProvider != null && rearProvider.PowerFuseState();
			powerFuse.ChangeState(flag || flag2);
		}

		public void OnAppliedVoltageChange()
		{
			float num = ((frontProvider != null) ? frontProvider.GeneratorVoltage() : 0f);
			float num2 = ((rearProvider != null) ? rearProvider.GeneratorVoltage() : 0f);
			float num3 = num + num2;
			if (num > 0f && num2 > 0f)
			{
				num3 /= 2f;
			}
			appliedVoltageExtIn.Value = num3;
		}
	}
}
