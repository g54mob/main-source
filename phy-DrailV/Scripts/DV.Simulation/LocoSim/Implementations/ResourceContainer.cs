using DV.JObjectExtstensions;
using LocoSim.Definitions;
using LocoSim.Resources;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class ResourceContainer : SimComponent
	{
		private const string CONTAINER_FILLED_PERCENTAGE_SAVE_KEY = "filled";

		public readonly ResourceContainerType resourceType;

		public readonly float capacity;

		public readonly Port refillExtIn;

		public readonly Port consumeExtIn;

		public readonly Port amountReadOut;

		public readonly Port normalizedReadOutPort;

		public readonly Port capacityReadOutPort;

		public override bool HasSaveData => true;

		public ResourceContainer(string id, ResourceContainerType resourceType, float defaultValue, float capacity, PortDefinition refillExtInPortDef, PortDefinition consumeExtInPortDef, PortDefinition amountReadOutDef, PortDefinition normalizedReadOutPortDef, PortDefinition capacityReadOutPortDef)
			: base(id)
		{
			this.resourceType = resourceType;
			this.capacity = capacity;
			refillExtIn = AddPort(refillExtInPortDef);
			consumeExtIn = AddPort(consumeExtInPortDef);
			amountReadOut = AddPort(amountReadOutDef, defaultValue);
			normalizedReadOutPort = AddPort(normalizedReadOutPortDef, defaultValue / capacity);
			capacityReadOutPort = AddPort(capacityReadOutPortDef, capacity);
			consumeExtIn.ValueUpdatedInternally += OnConsumptionValueUpdated;
			refillExtIn.ValueUpdatedInternally += OnRefillValueUpdated;
		}

		private void OnRefillValueUpdated(float refillValue)
		{
			if (refillValue != 0f)
			{
				amountReadOut.Value = Mathf.Clamp(amountReadOut.Value + refillValue, 0f, capacity);
				normalizedReadOutPort.Value = amountReadOut.Value / capacity;
				refillExtIn.Value = 0f;
			}
		}

		private void OnConsumptionValueUpdated(float consumeValue)
		{
			if (consumeValue != 0f)
			{
				amountReadOut.Value = Mathf.Clamp(amountReadOut.Value - consumeValue, 0f, capacity);
				normalizedReadOutPort.Value = amountReadOut.Value / capacity;
				consumeExtIn.Value = 0f;
			}
		}

		public override void Tick(float delta)
		{
		}

		public override JObject GetSaveStateData()
		{
			JObject jObject = new JObject();
			jObject.SetFloat("filled", normalizedReadOutPort.Value);
			return jObject;
		}

		public override void SetSaveStateData(JObject savedData)
		{
			float? num = savedData.GetFloat("filled");
			if (num.HasValue)
			{
				normalizedReadOutPort.Value = num.Value;
				amountReadOut.Value = num.Value * capacity;
			}
			else
			{
				Debug.LogError("Unexpected state: Missing data for " + id + ".CONTAINER_FILLED_PERCENTAGE_SAVE_KEY. Loading ignored for this parameter.");
			}
		}
	}
}
