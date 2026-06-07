using DV.JObjectExtstensions;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class MultiplePortDecoderEncoder : SimComponent
	{
		private const string OUT_VALUE_SAVE_KEY = "out";

		private readonly Port outPort;

		private readonly Port[] inPorts;

		private readonly int combinations;

		private readonly float defaultOutputValue;

		private readonly float[,] values;

		private readonly bool saveState;

		private readonly bool useDefaultValueOnMatchNotFound;

		private readonly bool matchClosestOutputValue;

		private bool selfUpdatedPort;

		public override bool HasSaveData => saveState;

		public MultiplePortDecoderEncoder(MultiplePortDecoderEncoderDefinition multiplePortDecoderEncoderDef)
			: base(multiplePortDecoderEncoderDef.ID)
		{
			inPorts = new Port[multiplePortDecoderEncoderDef.inputPorts.Length];
			for (int i = 0; i < inPorts.Length; i++)
			{
				inPorts[i] = AddPort(multiplePortDecoderEncoderDef.inputPorts[i]);
				inPorts[i].ValueUpdatedInternally += InPortUpdated;
			}
			outPort = AddPort(multiplePortDecoderEncoderDef.outputPort);
			outPort.ValueUpdatedInternally += OutPortUpdated;
			combinations = multiplePortDecoderEncoderDef.combinations;
			defaultOutputValue = multiplePortDecoderEncoderDef.defaultOutputValue;
			values = new float[combinations, inPorts.Length + 1];
			for (int j = 0; j < values.GetLength(0); j++)
			{
				for (int k = 0; k < values.GetLength(1); k++)
				{
					values[j, k] = multiplePortDecoderEncoderDef.values[j][k];
				}
			}
			saveState = multiplePortDecoderEncoderDef.saveState;
			useDefaultValueOnMatchNotFound = multiplePortDecoderEncoderDef.useDefaultValueOnMatchNotFound;
			matchClosestOutputValue = multiplePortDecoderEncoderDef.matchClosestOutputValue;
			InPortUpdated(0f);
		}

		private void SetInPortValues(int combinationIndex)
		{
			selfUpdatedPort = true;
			for (int i = 0; i < inPorts.Length; i++)
			{
				inPorts[i].Value = values[combinationIndex, i];
			}
			selfUpdatedPort = false;
		}

		private void OutPortUpdated(float value)
		{
			if (selfUpdatedPort)
			{
				return;
			}
			int inPortValues = 0;
			float num = Mathf.Abs(value - values[0, inPorts.Length]);
			for (int i = 0; i < combinations; i++)
			{
				if (Mathf.Approximately(values[i, inPorts.Length], value))
				{
					SetInPortValues(i);
					return;
				}
				if (matchClosestOutputValue)
				{
					float num2 = Mathf.Abs(value - values[i, inPorts.Length]);
					if (num2 < num)
					{
						num = num2;
						inPortValues = i;
					}
				}
			}
			if (matchClosestOutputValue)
			{
				SetInPortValues(inPortValues);
			}
		}

		private void InPortUpdated(float _)
		{
			if (selfUpdatedPort)
			{
				return;
			}
			for (int i = 0; i < combinations; i++)
			{
				bool flag = true;
				for (int j = 0; j < inPorts.Length; j++)
				{
					if (!Mathf.Approximately(values[i, j], inPorts[j].Value))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					selfUpdatedPort = true;
					outPort.Value = values[i, inPorts.Length];
					selfUpdatedPort = false;
					return;
				}
			}
			if (useDefaultValueOnMatchNotFound)
			{
				outPort.Value = defaultOutputValue;
				Debug.LogWarning("MultiplePortDecoderEncoder found state not defined in inspector, using default value.");
			}
		}

		public override void Tick(float delta)
		{
		}

		public override JObject GetSaveStateData()
		{
			JObject jObject = new JObject();
			jObject.SetFloat("out", outPort.Value);
			return jObject;
		}

		public override void SetSaveStateData(JObject savedData)
		{
			float? num = savedData.GetFloat("out");
			if (num.HasValue)
			{
				outPort.Value = num.Value;
			}
			else
			{
				Debug.LogError("Unexpected state: Missing data for " + id + ".OUT_VALUE_SAVE_KEY. Loading ignored for this parameter.");
			}
		}
	}
}
