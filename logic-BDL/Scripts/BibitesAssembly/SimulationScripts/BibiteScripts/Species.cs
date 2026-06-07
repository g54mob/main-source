using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using OneUseScripts;
using ScriptHelpers;
using SettingScripts;
using UnityEngine;
using UnityEngine.Events;
using Utility;

namespace SimulationScripts.BibiteScripts
{
	public class Species : ISaveable
	{
		[NonSerialized]
		public BibiteTemplate template;

		public static long speciesMaxID = 1L;

		[SerializeField]
		public long speciesID;

		[SerializeField]
		public double timeCreation;

		[SerializeField]
		public int generationOfFirstSpecimen;

		[SerializeField]
		public bool favorite;

		[SerializeField]
		public string genericName;

		[SerializeField]
		public string specificName;

		[SerializeField]
		public string description = "";

		[NonSerialized]
		public string parentName;

		[NonSerialized]
		public long parentID;

		[NonSerialized]
		public Species parentSpecies;

		[NonSerialized]
		public Species rootSpecies;

		[NonSerialized]
		public List<Species> children = new List<Species>();

		[NonSerialized]
		public List<BibiteBody> bibites = new List<BibiteBody>();

		[NonSerialized]
		public List<EggHatching> eggs = new List<EggHatching>();

		[NonSerialized]
		public UnityEvent onSpeciesChange = new UnityEvent();

		[NonSerialized]
		public LogLikeSpeciesDataArray speciesData;

		public bool absoluteKeep
		{
			get
			{
				if (!favorite)
				{
					return parentSpecies == null;
				}
				return true;
			}
		}

		public int count => bibites.Count + eggs.Count;

		public float energy => bibites.Sum((BibiteBody b) => b.totalEnergy) + eggs.Sum((EggHatching e) => (!e.aborting) ? e.energy : 0f);

		public string name => genericName + " " + specificName;

		public Species(BibiteTemplate bibiteTemplate)
		{
			speciesID = speciesMaxID++;
			timeCreation = TimeKeeper.simulatedTime;
			template = bibiteTemplate;
			string[] array = (string.IsNullOrEmpty(template.speciesName) ? template.name : template.speciesName).Split(' ');
			genericName = array[0].Capitalize();
			specificName = ((array.Length > 1) ? array[1].ToLower() : array[0].ToLower());
			template.speciesName = name;
			template.name = name;
			rootSpecies = this;
			speciesData = new LogLikeSpeciesDataArray(isTemplate: true);
		}

		public Species(BibiteBody fromBibite, Species parent = null)
		{
			speciesID = speciesMaxID++;
			timeCreation = TimeKeeper.simulatedTime;
			generationOfFirstSpecimen = fromBibite.gene.generation;
			template = new BibiteTemplate(fromBibite);
			if (parent != null)
			{
				parentSpecies = parent;
				genericName = parentSpecies.genericName;
				parentSpecies.children.Add(this);
				rootSpecies = parent.rootSpecies;
				if (parent.template.nodeAnchors.Count > 0)
				{
					template.nodeAnchors = parent.template.nodeAnchors.ToDictionary((KeyValuePair<long, Vector2> p) => p.Key, (KeyValuePair<long, Vector2> p) => p.Value);
				}
			}
			else
			{
				rootSpecies = this;
			}
			this.GenerateNewName();
			template.speciesName = name;
			template.name = name;
			speciesData = new LogLikeSpeciesDataArray(isTemplate: false);
		}

		public Species()
		{
			template = new BibiteTemplate();
			speciesData = new LogLikeSpeciesDataArray(isTemplate: false);
		}

		public void Changed()
		{
			onSpeciesChange.Invoke();
		}

		public int GetDescendantCount()
		{
			int num = count;
			foreach (Species child in children)
			{
				num += child.GetDescendantCount();
			}
			return num;
		}

		public float GeneticDistanceToIndividual(float[] individualGenes, NEATBrain.Node[] individualNodes, NEATBrain.Synaps[] individualConnections)
		{
			return GeneDistanceToIndividual(individualGenes) + BrainDistanceToIndividual(individualNodes, individualConnections);
		}

		public BrainDifferences BrainDifferencesToIndividual(NEATBrain.Node[] individualNodes, NEATBrain.Synaps[] individualConnections)
		{
			NEATBrain.Synaps[] synapses = template.synapses;
			int num = template.synapses.Length;
			int num2 = individualConnections.Length;
			int n = Mathf.Max(num, num2);
			int num3 = template.nodes.Length;
			int num4 = individualNodes.Length;
			Mathf.Max(num3, num4);
			int num5 = 0;
			BrainDifferences result = new BrainDifferences(n);
			int num6 = 0;
			int num7 = 0;
			float num8 = 0f;
			int num9 = 0;
			int num10 = 0;
			int num11 = 0;
			int num12 = 0;
			while (num9 < num && num10 < num2)
			{
				NEATBrain.Synaps synaps = synapses[num9];
				NEATBrain.Synaps synaps2 = individualConnections[num10];
				if (synaps.Inov == synaps2.Inov)
				{
					num6++;
					float num13 = synaps.Weight - synaps2.Weight;
					float dist = Mathf.Abs(num13 / (Mathf.Abs(synaps.Weight) + 1f));
					if (!Mathf.Approximately(num13, 0f))
					{
						result.connectionDeltas.Add(new ConnectionDelta
						{
							i = num9,
							inov = synaps.Inov,
							delta = num13,
							dist = dist
						});
					}
					if (synaps.En != synaps2.En)
					{
						num8 += 1f;
						result.toggled.Add(synaps.Inov);
					}
					num9++;
					num10++;
					continue;
				}
				num7++;
				if (synaps.Inov > synaps2.Inov)
				{
					if (!result.disjoint2.Contains(synaps2.Inov))
					{
						result.disjoint2.Add(synaps2.Inov);
					}
					num10++;
				}
				else
				{
					if (!result.disjoint1.Contains(synaps.Inov))
					{
						result.disjoint1.Add(synaps.Inov);
					}
					num9++;
				}
			}
			while (num11 < num3 && num12 < num4)
			{
				NEATBrain.Node node = template.nodes[num11];
				NEATBrain.Node node2 = individualNodes[num12];
				if (node.Inov == node2.Inov)
				{
					num11++;
					num12++;
					float num14 = node.baseActivation - node2.baseActivation;
					if (Mathf.Abs(node.baseActivation) > 0f || Mathf.Abs(node2.baseActivation) > 0f)
					{
						num5++;
						if (!Mathf.Approximately(num14, 0f))
						{
							result.activationDelta.Add(new ActivationDelta
							{
								delta = num14,
								i = num11 - 1,
								inov = node.Inov
							});
						}
					}
				}
				else if (node.Inov > node2.Inov)
				{
					num12++;
				}
				else
				{
					num11++;
				}
			}
			num7 += num - num9 + (num2 - num10);
			for (int i = num9; i < num; i++)
			{
				result.disjoint1.Add(synapses[i].Inov);
			}
			for (int j = num10; j < num2; j++)
			{
				result.disjoint2.Add(individualConnections[j].Inov);
			}
			for (int k = 0; k < result.activationDelta.Count; k++)
			{
				ActivationDelta value = result.activationDelta[k];
				value.dist = Mathf.Abs(value.delta) / (float)Mathf.Max(num5, 1);
				result.activationDelta[k] = value;
			}
			for (int l = 0; l < result.connectionDeltas.Count; l++)
			{
				ConnectionDelta value2 = result.connectionDeltas[l];
				value2.dist = Mathf.Abs(value2.dist) / Mathf.Sqrt(Mathf.Max(num6, 1));
				result.connectionDeltas[l] = value2;
			}
			result.nDisjointConnections = num7;
			result.nCommonConnections = num6;
			result.nToggleConnections = num8;
			return result;
		}

		public float BrainDistanceToIndividual(NEATBrain.Node[] individualNodes, NEATBrain.Synaps[] individualConnections)
		{
			return BrainDifferencesToIndividual(individualNodes, individualConnections).totalDistance;
		}

		public float GeneDistanceToIndividual(float[] individualGenes)
		{
			float[] genes = template.genes;
			float num = 0f;
			for (int i = 0; i < genes.Length; i++)
			{
				num += Math.Abs((genes[i] - individualGenes[i]) / BibiteEditorSettings.geneSettingsOrdered[i].maxValue);
			}
			return num;
		}

		public void LogSpeciesData()
		{
			speciesData.Push(new SpeciesDataPoint(this));
		}

		public void AddToSpecies(BibiteBody bibite)
		{
			bibites.Add(bibite);
		}

		public void AddToSpecies(EggHatching egg)
		{
			eggs.Add(egg);
		}

		public void RemoveFromSpecies(BibiteBody bibite)
		{
			bibites.Remove(bibite);
		}

		public void RemoveFromSpecies(EggHatching egg)
		{
			eggs.Remove(egg);
		}

		public JObject SaveState()
		{
			JObject jObject = SerializationHelper.SerializeGeneralObject(this);
			if (parentSpecies != null)
			{
				jObject["parentID"] = parentSpecies.speciesID;
			}
			jObject["template"] = template.SaveStateForSpecies();
			return jObject;
		}

		public void LoadState(JObject state)
		{
			SerializationHelper.DeserializeGeneralObject(this, state);
			SerializationHelper.DeserializeObject(template, state["template"]);
			template.name = name;
			template.speciesName = name;
			if (state["parentID"] != null)
			{
				parentID = state["parentID"].ToObject<long>();
			}
		}

		public override string ToString()
		{
			return name;
		}
	}
}
