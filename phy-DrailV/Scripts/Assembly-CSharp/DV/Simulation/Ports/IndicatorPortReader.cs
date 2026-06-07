using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Ports
{
	public class IndicatorPortReader : MonoBehaviour
	{
		[PortId(null, null, false)]
		public string portId;

		[Header("Optional")]
		[PortId(null, null, false)]
		public string indicatorRangeScalerPortId;

		[FuseId]
		public string fuseId;

		public bool useZeroAsDefaultValue;

		[Header("Value modifiers")]
		public float valueMultiplier = 1f;

		public float valueOffset;

		public bool useAbsoluteValue;

		private Indicator indicator;

		private Port normalizedInputScalerPort;

		private Port port;

		private Fuse fuse;

		private float originalMinValue;

		private float originalMaxValue;

		private float indicatorRangeScaler = 1f;

		private bool HasAssignedFuse => !string.IsNullOrWhiteSpace(fuseId);

		public void Init(Port port, Fuse fuse, Port normalizedInputScalerPort)
		{
			indicator = GetComponent<Indicator>();
			if (indicator == null)
			{
				Debug.LogError("Can't find Indicator on " + base.gameObject.name + ". Ignoring init");
				return;
			}
			originalMinValue = indicator.minValue;
			originalMaxValue = indicator.maxValue;
			this.port = port;
			this.fuse = fuse;
			this.normalizedInputScalerPort = normalizedInputScalerPort;
			if (normalizedInputScalerPort != null)
			{
				normalizedInputScalerPort.ValueUpdatedInternally += InputScalerPortUpdated;
				InputScalerPortUpdated(normalizedInputScalerPort.Value);
			}
			OnValueUpdate(port.Value);
			port.ValueUpdatedInternally += OnValueUpdate;
			if (fuse != null)
			{
				fuse.StateUpdated += OnFuseUpdated;
			}
		}

		public void Deinit()
		{
			if (normalizedInputScalerPort != null)
			{
				normalizedInputScalerPort.ValueUpdatedInternally -= InputScalerPortUpdated;
			}
			if (port != null)
			{
				port.ValueUpdatedInternally -= OnValueUpdate;
			}
			if (fuse != null)
			{
				fuse.StateUpdated -= OnFuseUpdated;
			}
		}

		private void InputScalerPortUpdated(float value)
		{
			indicatorRangeScaler = value;
			indicator.minValue = indicatorRangeScaler * originalMinValue;
			indicator.maxValue = indicatorRangeScaler * originalMaxValue;
			OnValueUpdate(port.Value);
		}

		private void OnValueUpdate(float newValue)
		{
			if (fuse != null && !fuse.State)
			{
				indicator.Value = (useZeroAsDefaultValue ? 0f : indicator.minValue);
				return;
			}
			float num = newValue * valueMultiplier + valueOffset;
			if (useAbsoluteValue)
			{
				num = Mathf.Abs(num);
			}
			indicator.Value = num * indicatorRangeScaler;
		}

		private void OnFuseUpdated(bool _)
		{
			OnValueUpdate(port.Value);
		}
	}
}
