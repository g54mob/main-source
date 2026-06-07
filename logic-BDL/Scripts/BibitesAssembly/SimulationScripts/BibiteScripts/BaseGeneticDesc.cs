using System;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SettingScripts;

namespace SimulationScripts.BibiteScripts
{
	public class BaseGeneticDesc : ISaveable
	{
		[NonSerialized]
		public NEATBrain.Node[] nodes;

		[NonSerialized]
		public NEATBrain.Synaps[] synapses;

		[NonSerialized]
		public float[] genes;

		public virtual JObject SaveState()
		{
			JObject jObject = SerializationHelper.SerializeGeneralObject(this);
			JArray jArray = new JArray();
			NEATBrain.Node[] array = nodes;
			foreach (NEATBrain.Node node in array)
			{
				jArray.Add(node.SaveForTemplate());
			}
			jObject["nodes"] = jArray;
			JArray jArray2 = new JArray();
			NEATBrain.Synaps[] array2 = synapses;
			foreach (NEATBrain.Synaps synaps in array2)
			{
				jArray2.Add(JToken.FromObject(synaps));
			}
			jObject["synapses"] = jArray2;
			JToken jToken = (jObject["genes"] = new JObject());
			JToken jToken3 = jToken;
			string[] names = Enum.GetNames(typeof(BibiteGenes.Genes));
			foreach (string text in names)
			{
				jToken3[text] = JToken.FromObject(genes[(int)Enum.Parse(typeof(BibiteGenes.Genes), text)]);
			}
			return jObject;
		}

		public virtual void LoadState(JObject state)
		{
			SerializationHelper.DeserializeGeneralObject(this, state);
			nodes = state["nodes"].ToObject<NEATBrain.Node[]>();
			synapses = state["synapses"].ToObject<NEATBrain.Synaps[]>();
			genes = new float[BibiteGenes.NGene];
			string[] names = Enum.GetNames(typeof(BibiteGenes.Genes));
			foreach (string text in names)
			{
				int num = (int)Enum.Parse(typeof(BibiteGenes.Genes), text);
				if (state["genes"][text] != null)
				{
					genes[num] = state["genes"][text].ToObject<float>();
				}
				else
				{
					genes[num] = BibiteEditorSettings.SettingOfGene(num).DefaultValue;
				}
			}
		}
	}
}
