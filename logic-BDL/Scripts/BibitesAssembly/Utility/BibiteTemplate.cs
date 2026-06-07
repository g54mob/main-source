using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace Utility
{
	public class BibiteTemplate : ISaveable
	{
		[NonSerialized]
		public bool isExternal;

		[NonSerialized]
		public string filePath;

		[NonSerialized]
		public string fullPath;

		[NonSerialized]
		public bool isOfficial;

		[NonSerialized]
		public bool isTemplate = true;

		[SerializeField]
		public string name;

		[SerializeField]
		public string speciesName;

		[SerializeField]
		public string description;

		[SerializeField]
		public int generation;

		[SerializeField]
		public string version;

		[NonSerialized]
		public bool updated;

		[NonSerialized]
		public Dictionary<long, Vector2> nodeAnchors = new Dictionary<long, Vector2>();

		[NonSerialized]
		public NEATBrain.Node[] nodes;

		[NonSerialized]
		public NEATBrain.Synaps[] synapses;

		[NonSerialized]
		public float[] genes;

		public bool IsValid => Version.CanParse(version);

		public BibiteTemplate(string path, bool external = false)
		{
			isExternal = external;
			if (isExternal)
			{
				fullPath = path;
			}
			filePath = path;
			string extension = Path.GetExtension(path);
			JObject jObject = null;
			bool flag = extension == ".bb8";
			isTemplate = !flag;
			if (flag)
			{
				name = Path.GetFileName(path).Replace(".bb8", "");
				if (!isExternal)
				{
					fullPath = Path.Combine(SaveSystem.savedBibitePath, filePath);
				}
				jObject = JObject.Parse(File.ReadAllText(fullPath));
				if (jObject["isOfficial"] != null)
				{
					isOfficial = jObject["isOfficial"].ToObject<bool>();
				}
				if (jObject["desc"] != null)
				{
					description = jObject["desc"].ToString();
				}
				if (jObject["version"] != null)
				{
					version = jObject["version"].ToString();
				}
				if (jObject["name"] != null)
				{
					speciesName = jObject["name"].ToString();
				}
				else
				{
					speciesName = name.ToSpeciesFormat();
				}
				if (jObject["genes"] != null)
				{
					genes = new float[BibiteGenes.NGene];
					string[] names = Enum.GetNames(typeof(BibiteGenes.Genes));
					foreach (string text in names)
					{
						int num = (int)Enum.Parse(typeof(BibiteGenes.Genes), text);
						if (jObject["genes"]["genes"][text] != null)
						{
							genes[num] = jObject["genes"]["genes"][text].ToObject<float>();
						}
						else
						{
							genes[num] = BibiteEditorSettings.SettingOfGene(num).DefaultValue;
						}
					}
					generation = jObject["genes"]["gen"].ToObject<int>();
				}
				if (jObject["brain"]?["Nodes"] != null)
				{
					nodes = jObject["brain"]["Nodes"].ToObject<NEATBrain.Node[]>();
				}
				if (jObject["brain"]?["Synapses"] != null)
				{
					synapses = jObject["brain"]["Synapses"].ToObject<NEATBrain.Synaps[]>();
				}
			}
			else if (extension == ".bb8template")
			{
				if (!isExternal)
				{
					fullPath = Path.Combine(SaveSystem.bibiteTemplatePath, filePath);
				}
				jObject = JObject.Parse(File.ReadAllText(fullPath));
				LoadState(jObject);
				speciesName = name.ToSpeciesFormat();
			}
			if (version != null && BibiteUpdater.UpdateTemplateToPresentVersion(this, jObject, flag))
			{
				updated = true;
			}
		}

		public BibiteTemplate(GameObject bibite)
		{
			BibiteGenes component = bibite.GetComponent<BibiteGenes>();
			NEATBrain component2 = bibite.GetComponent<NEATBrain>();
			genes = component.genes;
			name = component.speciesTag;
			if (component.species != null)
			{
				speciesName = component.species.name;
				if (component.species.template.nodeAnchors.Count > 0)
				{
					nodeAnchors = component.species.template.nodeAnchors.ToDictionary((KeyValuePair<long, Vector2> p) => p.Key, (KeyValuePair<long, Vector2> p) => p.Value);
				}
			}
			nodes = component2.Nodes;
			synapses = component2.Synapses;
			version = Version.Present.ToString();
		}

		public BibiteTemplate(BibiteBody bibite)
		{
			BibiteGenes gene = bibite.gene;
			NEATBrain brain = bibite.brain;
			genes = gene.genes;
			if (gene.species != null)
			{
				speciesName = gene.species.name;
			}
			else
			{
				speciesName = (string.IsNullOrEmpty(gene.speciesTag) ? SpeciesNameGenerator.RandomName() : gene.speciesTag);
			}
			name = speciesName;
			nodes = brain.Nodes;
			synapses = brain.Synapses;
			version = Version.Present.ToString();
		}

		public BibiteTemplate()
		{
			version = Version.Present.ToString();
		}

		public BibiteTemplate(BibiteTemplate template)
		{
			name = template.name;
			speciesName = template.speciesName;
			description = template.description;
			generation = template.generation;
			version = template.version;
			nodes = template.nodes;
			synapses = template.synapses;
			genes = template.genes;
			nodeAnchors = template.nodeAnchors;
		}

		public static bool Exists(string file, bool external)
		{
			string extension = Path.GetExtension(file);
			string path;
			if (external)
			{
				path = file;
			}
			else if (extension == ".bb8")
			{
				path = Path.Combine(SaveSystem.savedBibitePath, file);
			}
			else
			{
				if (!(extension == ".bb8template"))
				{
					return false;
				}
				path = Path.Combine(SaveSystem.bibiteTemplatePath, file);
			}
			return File.Exists(path);
		}

		public JObject SaveState()
		{
			version = Version.Present.ToString();
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
			if (nodeAnchors.Count > 0)
			{
				jObject["nodeAnchors"] = JToken.FromObject(nodeAnchors);
			}
			if (isOfficial)
			{
				jObject["isOfficial"] = true;
			}
			return jObject;
		}

		public JObject SaveStateOfficial()
		{
			JObject jObject = SaveState();
			jObject["isOfficial"] = true;
			return jObject;
		}

		public JObject SaveStateForSpecies()
		{
			JObject jObject = new JObject();
			jObject["version"] = Version.Present.ToString();
			JArray jArray = new JArray();
			NEATBrain.Node[] array = nodes;
			foreach (NEATBrain.Node node in array)
			{
				jArray.Add(node.SaveForTemplate());
			}
			jObject["nodes"] = jArray;
			if (nodeAnchors.Count > 0)
			{
				jObject["nodeAnchors"] = JToken.FromObject(nodeAnchors);
			}
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

		public void LoadState(JObject state)
		{
			SerializationHelper.DeserializeGeneralObject(this, state);
			nodes = state["nodes"].ToObject<NEATBrain.Node[]>();
			synapses = state["synapses"].ToObject<NEATBrain.Synaps[]>();
			if (state["nodeAnchors"] != null)
			{
				nodeAnchors = state["nodeAnchors"].ToObject<Dictionary<long, Vector2>>();
			}
			if (string.IsNullOrEmpty(version))
			{
				version = Version.Present.ToString();
			}
			genes = new float[BibiteGenes.NGene];
			if (Version.Parse(version) < new Version(0, 6, 0, 1))
			{
				float[] array = state["genes"].ToObject<float[]>();
				for (int i = 0; i < array.Length; i++)
				{
					genes[i] = array[i];
				}
			}
			else
			{
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
			if (state["isOfficial"] != null)
			{
				isOfficial = state["isOfficial"].ToObject<bool>();
			}
			if (version != null && BibiteUpdater.UpdateTemplateToPresentVersion(this, state, isSaved: false))
			{
				updated = true;
			}
		}

		public void AlignInnovationsWithSim()
		{
			Dictionary<long, Vector2> dictionary = new Dictionary<long, Vector2>();
			for (int i = 0; i < nodes.Length; i++)
			{
				long inov = nodes[i].Inov;
				if (i >= NEATBrain.NInputs + NEATBrain.NOutputs)
				{
					nodes[i].Inov = NEATBrain.nodeMaxInov++;
				}
				if (nodeAnchors.Count > 0 && nodeAnchors.ContainsKey(inov))
				{
					Vector2 value = nodeAnchors[inov];
					dictionary.Add(nodes[i].Inov, value);
				}
			}
			for (int j = 0; j < synapses.Length; j++)
			{
				synapses[j].Inov = NEATBrain.connectionMaxInov++;
			}
		}

		public void AlignInnovationsWithTemplate(BibiteTemplate template)
		{
			for (int i = 0; i < nodes.Length; i++)
			{
				if (i < template.nodes.Length)
				{
					nodes[i].Inov = template.nodes[i].Inov;
				}
				else
				{
					nodes[i].Inov = NEATBrain.nodeMaxInov++;
				}
			}
			for (int j = 0; j < synapses.Length; j++)
			{
				if (j < template.synapses.Length)
				{
					synapses[j].Inov = template.synapses[j].Inov;
				}
				else
				{
					synapses[j].Inov = NEATBrain.connectionMaxInov++;
				}
			}
		}
	}
}
