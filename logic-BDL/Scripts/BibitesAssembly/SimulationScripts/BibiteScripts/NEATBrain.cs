using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SettingScripts;
using UnityEngine;

namespace SimulationScripts.BibiteScripts
{
	public class NEATBrain : MonoBehaviour
	{
		public enum Inputs
		{
			EnergyRatio = 0,
			Maturity = 1,
			LifeRatio = 2,
			Fullness = 3,
			Speed = 4,
			RotationSpeed = 5,
			IsGrabbing = 6,
			AttackedDamage = 7,
			EggStored = 8,
			BibiteCloseness = 9,
			BibiteAngle = 10,
			NBibites = 11,
			PlantCloseness = 12,
			PlantAngle = 13,
			NPlants = 14,
			MeatCloseness = 15,
			MeatAngle = 16,
			NMeats = 17,
			RedBibite = 18,
			GreenBibite = 19,
			BlueBibite = 20,
			Tic = 21,
			Minute = 22,
			TimeAlive = 23,
			PheroSense1 = 24,
			PheroSense2 = 25,
			PheroSense3 = 26,
			Phero1Angle = 27,
			Phero2Angle = 28,
			Phero3Angle = 29,
			Phero1Heading = 30,
			Phero2Heading = 31,
			Phero3Heading = 32
		}

		public enum Outputs
		{
			Accelerate = 0,
			Rotate = 1,
			Herding = 2,
			EggProduction = 3,
			Want2Lay = 4,
			Want2Eat = 5,
			Digestion = 6,
			Grab = 7,
			ClkReset = 8,
			PhereOut1 = 9,
			PhereOut2 = 10,
			PhereOut3 = 11,
			Want2Grow = 12,
			Want2Heal = 13,
			Want2Attack = 14
		}

		public enum NodeType
		{
			Input = 0,
			Sigmoid = 1,
			Linear = 2,
			TanH = 3,
			Sine = 4,
			ReLu = 5,
			Gaussian = 6,
			Latch = 7,
			Differential = 8,
			Abs = 9,
			Mult = 10,
			Integrator = 11,
			Inhibitory = 12,
			SoftLatch = 13
		}

		public struct Node
		{
			public NodeType Type;

			public float baseActivation;

			public string TypeName;

			public int Index;

			public long Inov;

			[NonSerialized]
			public int NIn;

			[NonSerialized]
			public int NOut;

			public string Desc;

			public float Value;

			public float LastInput;

			public float LastOutput;

			public NodeArchetype archetype
			{
				get
				{
					if (Index < NInputs)
					{
						return NodeArchetype.Input;
					}
					if (Index >= NInputs + NOutputs)
					{
						return NodeArchetype.Hidden;
					}
					return NodeArchetype.Output;
				}
			}

			public Node(NodeType type, long inov, string desc, int idx, int nIn, int nOut, float defaultAct = 0f)
			{
				Type = type;
				TypeName = type.ToString();
				Index = idx;
				Inov = inov;
				Desc = desc;
				NIn = nIn;
				NOut = nOut;
				Value = 0f;
				LastInput = 0f;
				LastOutput = 0f;
				baseActivation = defaultAct;
			}

			public JObject SaveForTemplate()
			{
				return new JObject
				{
					["Type"] = JToken.FromObject(Type),
					["Index"] = JToken.FromObject(Index),
					["Inov"] = JToken.FromObject(Inov),
					["Desc"] = JToken.FromObject(Desc),
					["baseActivation"] = JToken.FromObject(baseActivation)
				};
			}
		}

		public enum NodeArchetype
		{
			Input = 0,
			Output = 1,
			Hidden = 2
		}

		public struct Synaps
		{
			public long Inov;

			public int NodeIn;

			public int NodeOut;

			public float Weight;

			public bool En;

			public Synaps(long inov, int nodeI, int nodeO, float weight, bool en)
			{
				Inov = inov;
				NodeIn = nodeI;
				NodeOut = nodeO;
				Weight = weight;
				En = en;
			}
		}

		private BibitePheromoneOrgan pheromoneOrgan;

		private BibiteStomach stomach;

		private BibiteBody body;

		private BibiteGrowth growth;

		private BibiteGenes gene;

		private FieldOfView fow;

		private Pherosense phero;

		private InternalClock clk;

		public List<Node> nodese;

		public List<Synaps> synapse;

		public float mutationProbability;

		public float mutationVariance;

		private bool[] changeN;

		private bool[] changeS;

		private List<int> disabledSynapses = new List<int>();

		public int nHidden;

		public int nActiveInputs;

		public int nActiveOutputs;

		public int nSynaps;

		[SerializeField]
		public bool isReady;

		[SerializeField]
		public Node[] Nodes;

		[SerializeField]
		public Synaps[] Synapses;

		public List<int> brainTargets = new List<int>();

		public List<List<int>> brainLinks = new List<List<int>>();

		private readonly Inputs[] possibleFoodSourceAngles = new Inputs[3]
		{
			Inputs.PlantAngle,
			Inputs.BibiteAngle,
			Inputs.MeatAngle
		};

		public static readonly int NInputs = Enum.GetValues(typeof(Inputs)).Length;

		public static readonly int NOutputs = Enum.GetValues(typeof(Outputs)).Length;

		private static readonly int NNodesTypes = Enum.GetValues(typeof(NodeType)).Length;

		private static System.Random r = new System.Random();

		public static long nodeMaxInov = NInputs + NOutputs + 1;

		public static long connectionMaxInov = 1L;

		private static readonly FloatSetting BackgroundMutationChance = ScenarioSettings.Instance.backgroundMutationChance;

		private static readonly FloatSetting BackgroundMutationVariance = ScenarioSettings.Instance.backgroundMutationVariance;

		private static readonly BoolSetting PreventMutations = ScenarioSettings.Instance.preventMutations;

		private static readonly IntSetting SimTPS = ScenarioIndependentSettings.Instance.simTPS;

		private static readonly IntSetting BrainTPS = ScenarioIndependentSettings.Instance.brainTPS;

		private static readonly BoolSetting DisableHerding = ScenarioSettings.Instance.disableHerding;

		private static float backgroundMutationChance = BackgroundMutationChance.SubscribeTo<FloatSetting, float>(UpdateBackgroundMutationChance);

		private static float backgroundMutationVariance = BackgroundMutationVariance.SubscribeTo<FloatSetting, float>(UpdateBackgroundMutationVariance);

		private static bool preventMutations = PreventMutations.SubscribeTo<BoolSetting, bool>(UpdatePreventMutations);

		private static int simTPS = SimTPS.SubscribeTo<IntSetting, int>(UpdateSimTPS);

		private static int brainTPS = BrainTPS.SubscribeTo<IntSetting, int>(UpdateBrainTPS);

		private static bool herdingEnabled = !DisableHerding.SubscribeTo<BoolSetting, bool>(UpdateDisableHerding);

		public static float brainPeriod;

		public int nActiveNodes => nActiveInputs + nActiveOutputs + nHidden;

		public float brainUpkeepCost => (float)nSynaps * ScenarioSettings.Instance.synapseUpkeepCost.val + (float)nHidden * ScenarioSettings.Instance.neuronUpkeepCost.val;

		public static bool TypeHasBias(NodeType type)
		{
			if (type != NodeType.Input)
			{
				return type != NodeType.Integrator;
			}
			return false;
		}

		public static bool TypeUsesBiasDifferently(NodeType type)
		{
			if (type != NodeType.Integrator && type != NodeType.Mult && type != NodeType.Inhibitory)
			{
				return type == NodeType.SoftLatch;
			}
			return true;
		}

		public static bool TypeIsNonLinear(NodeType type)
		{
			if (type != NodeType.Differential && type != NodeType.Inhibitory && type != NodeType.Integrator && type != NodeType.Latch)
			{
				return type == NodeType.SoftLatch;
			}
			return true;
		}

		public float Output(Outputs output)
		{
			return Nodes[(int)(output + NInputs)].Value;
		}

		private static void UpdateBackgroundMutationChance(float val)
		{
			backgroundMutationChance = val;
		}

		private static void UpdateBackgroundMutationVariance(float val)
		{
			backgroundMutationVariance = val;
		}

		private static void UpdatePreventMutations(bool val)
		{
			preventMutations = val;
		}

		private static void UpdateBrainTPS(int val)
		{
			brainTPS = val;
			brainPeriod = (float)brainTPS / (float)simTPS;
		}

		private static void UpdateSimTPS(int val)
		{
			simTPS = val;
			brainPeriod = (float)brainTPS / (float)simTPS;
		}

		private static void UpdateDisableHerding(bool val)
		{
			herdingEnabled = !val;
		}

		private void Awake()
		{
			body = GetComponent<BibiteBody>();
			growth = GetComponent<BibiteGrowth>();
			gene = GetComponent<BibiteGenes>();
			pheromoneOrgan = GetComponent<BibitePheromoneOrgan>();
			fow = GetComponent<FieldOfView>();
			clk = GetComponent<InternalClock>();
			phero = GetComponent<Pherosense>();
		}

		public void ResumeBrain()
		{
			if (isReady)
			{
				nHidden = Nodes.Length - NInputs - NOutputs;
				nSynaps = Synapses.Length;
				ComputeActiveNeurons();
				ComputeProcessingStructure();
				StartUsedSystems();
				isReady = true;
			}
		}

		public void CopyBrain(Node[] parentNodes, Synaps[] parentSynapses, bool mutate, bool finalizeRightAway = true, bool checkForFloatingHidden = false)
		{
			nodese = new List<Node>();
			synapse = new List<Synaps>();
			nHidden = parentNodes.Length - NInputs - NOutputs;
			mutationProbability = gene.genes[11];
			mutationVariance = gene.genes[10] + backgroundMutationVariance + gene.mutationIncreases.intensityIncrease;
			foreach (Node node in parentNodes)
			{
				CopyNode(node);
			}
			foreach (Synaps syn in parentSynapses)
			{
				CopySynaps(syn);
			}
			nSynaps = synapse.Count;
			if (mutate && !preventMutations)
			{
				disabledSynapses.Clear();
				for (int j = 0; j < nSynaps; j++)
				{
					if (!synapse[j].En)
					{
						disabledSynapses.Add(j);
					}
				}
				int num = r.NextPoisson(mutationProbability + backgroundMutationChance + gene.mutationIncreases.probabilityIncrease);
				for (int k = 0; k < num; k++)
				{
					if (r.NextDouble() < (double)ScenarioSettings.Instance.synapseMutationChance.val)
					{
						MutateSynapses();
					}
					else
					{
						MutateNeurons();
					}
				}
			}
			if (checkForFloatingHidden)
			{
				for (int l = NInputs + NOutputs; l < nodese.Count; l++)
				{
					if (nodese[l].NIn < 1 || nodese[l].NOut < 1)
					{
						RemoveNeuron(l--);
					}
				}
			}
			if (finalizeRightAway)
			{
				FinalizeEditing();
			}
		}

		public void FinalizeEditing()
		{
			Nodes = new Node[NInputs + NOutputs + nHidden];
			Synapses = new Synaps[nSynaps];
			for (int i = 0; i < nSynaps; i++)
			{
				Synapses[i].Inov = synapse[i].Inov;
				Synapses[i].NodeIn = synapse[i].NodeIn;
				Synapses[i].NodeOut = synapse[i].NodeOut;
				Synapses[i].Weight = synapse[i].Weight;
				Synapses[i].En = synapse[i].En;
			}
			for (int j = 0; j < NInputs + NOutputs + nHidden; j++)
			{
				Nodes[j].Inov = nodese[j].Inov;
				Nodes[j].Type = nodese[j].Type;
				Nodes[j].TypeName = nodese[j].TypeName;
				Nodes[j].Desc = nodese[j].Desc;
				Nodes[j].NIn = nodese[j].NIn;
				Nodes[j].NOut = nodese[j].NOut;
				Nodes[j].Index = nodese[j].Index;
				Nodes[j].baseActivation = nodese[j].baseActivation;
			}
			nodese.Clear();
			synapse.Clear();
			for (int k = 0; k < NInputs + NOutputs + nHidden; k++)
			{
				Nodes[k].Index = k;
			}
			for (int l = NInputs; l < NInputs + NOutputs + nHidden; l++)
			{
				ExecuteNeuron(ref Nodes[l], 0f, brainPeriod);
			}
			ComputeActiveNeurons();
			ComputeProcessingStructure();
			StartUsedSystems();
			isReady = true;
		}

		private void ComputeActiveNeurons()
		{
			nActiveInputs = 0;
			nActiveOutputs = 0;
			for (int i = 0; i < NInputs + NOutputs + nHidden; i++)
			{
				Nodes[i].NIn = 0;
				Nodes[i].NOut = 0;
				if (Nodes[i].Type == NodeType.SoftLatch)
				{
					Nodes[i].baseActivation = Mathf.Clamp(Nodes[i].baseActivation, 0.1f, 100f);
				}
			}
			for (int j = 0; j < nSynaps; j++)
			{
				if (Synapses[j].NodeIn != Synapses[j].NodeOut)
				{
					Nodes[Synapses[j].NodeIn].NOut++;
					Nodes[Synapses[j].NodeOut].NIn++;
				}
			}
			for (int k = NInputs + NOutputs; k < Nodes.Length; k++)
			{
				if (Nodes[k].NIn < 1 || Nodes[k].NOut < 1)
				{
					CopyBrain(Nodes, Synapses, mutate: false, finalizeRightAway: true, checkForFloatingHidden: true);
					return;
				}
			}
			for (int l = 0; l < NInputs + NOutputs; l++)
			{
				if (l < NInputs && Nodes[l].NOut > 0)
				{
					nActiveInputs++;
				}
				if (Nodes[l].NIn > 0)
				{
					nActiveOutputs++;
				}
			}
		}

		private void ComputeProcessingStructure()
		{
			brainTargets = new List<int>();
			brainLinks = new List<List<int>>();
			for (int i = 0; i < nSynaps; i++)
			{
				if (Synapses[i].En && (herdingEnabled || Synapses[i].NodeOut != 2))
				{
					int num = brainTargets.IndexOf(Synapses[i].NodeOut);
					if (num < 0)
					{
						brainTargets.Add(Synapses[i].NodeOut);
						brainLinks.Add(new List<int>());
						List<List<int>> list = brainLinks;
						list[list.Count - 1].Add(i);
					}
					else
					{
						brainLinks[num].Add(i);
					}
				}
			}
		}

		private void StartUsedSystems()
		{
			if (phero != null && Nodes[24].NOut + Nodes[25].NOut + Nodes[26].NOut + Nodes[27].NOut + Nodes[28].NOut + Nodes[29].NOut + Nodes[30].NOut + Nodes[31].NOut + Nodes[32].NOut > 0)
			{
				phero.StartPherosensing();
			}
			if (!(fow == null))
			{
				int num = 0;
				num += (((herdingEnabled ? (Nodes[NInputs + 2].NIn + ((!Mathf.Approximately(Nodes[NInputs + 2].baseActivation, 0f)) ? 1 : 0)) : 0) + Nodes[11].NOut + Nodes[10].NOut + Nodes[9].NOut + Nodes[18].NOut + Nodes[19].NOut + Nodes[20].NOut > 0) ? 1 : 0);
				num += ((Nodes[14].NOut + Nodes[13].NOut + Nodes[12].NOut > 0) ? 2 : 0);
				num += ((Nodes[17].NOut + Nodes[16].NOut + Nodes[15].NOut > 0) ? 4 : 0);
				if (gene.Gene(BibiteGenes.Genes.ViewAngle) * gene.Gene(BibiteGenes.Genes.ViewRadius) <= 0f)
				{
					num = 0;
				}
				fow.StartSeeing(num);
			}
		}

		public void Thinker()
		{
			UpdateSenses();
			float num = 0f;
			for (int i = 0; i < brainTargets.Count; i++)
			{
				int num2 = brainTargets[i];
				num = ((Nodes[num2].Type == NodeType.Mult) ? 1f : 0f);
				for (int j = 0; j < brainLinks[i].Count; j++)
				{
					float num3 = Synapses[brainLinks[i][j]].Weight * Nodes[Synapses[brainLinks[i][j]].NodeIn].LastOutput;
					num = ((Nodes[num2].Type != NodeType.Mult) ? (num + num3) : (num * num3));
				}
				ExecuteNeuron(ref Nodes[num2], num, brainPeriod);
			}
		}

		public void UpdateSenses()
		{
			for (int i = 0; i < NInputs; i++)
			{
				Nodes[i].LastOutput = Nodes[i].Value;
			}
			Nodes[0].Value = body.Energy.Amount / body.Energy.MaxAmount;
			Nodes[1].Value = growth.growth;
			Nodes[2].Value = body.healthRatio;
			Nodes[3].Value = body.stomach.fullness;
			Nodes[4].Value = body.move.NormalizedVelocity;
			Nodes[5].Value = body.move.AngularVelocity;
			Nodes[6].Value = body.mouth.nHeld;
			float value = ((body.health > 0f) ? Mathf.Min(1f, 2f * body.attackedDmg / body.health) : 0f);
			Nodes[7].Value = value;
			Nodes[8].Value = body.eggLayer.nEgg;
			Nodes[9].Value = fow.bibiteConcentrationWeight;
			Nodes[10].Value = fow.bibiteConcentrationAngle;
			Nodes[12].Value = fow.pelletConcentrationWeight;
			Nodes[13].Value = fow.pelletConcentrationAngle;
			Nodes[15].Value = fow.meatConcentrationWeight;
			Nodes[16].Value = fow.meatConcentrationAngle;
			Nodes[11].Value = (float)fow.nBibite / 4f;
			Nodes[14].Value = (float)fow.nPlants / 4f;
			Nodes[17].Value = (float)fow.nMeat / 4f;
			Nodes[18].Value = fow.targetR;
			Nodes[19].Value = fow.targetG;
			Nodes[20].Value = fow.targetB;
			Nodes[21].Value = clk.tic;
			Nodes[22].Value = clk.chronoTime / 60f;
			Nodes[23].Value = clk.timeAlive / 60f;
			Nodes[24].Value = (float)Math.Tanh(phero.pheroSum1 / 5f);
			Nodes[25].Value = (float)Math.Tanh(phero.pheroSum2 / 5f);
			Nodes[26].Value = (float)Math.Tanh(phero.pheroSum3 / 5f);
			Nodes[27].Value = phero.angleToPhero1;
			Nodes[28].Value = phero.angleToPhero2;
			Nodes[29].Value = phero.angleToPhero3;
			Nodes[30].Value = phero.angleToPhero1Heading;
			Nodes[31].Value = phero.angleToPhero2Heading;
			Nodes[32].Value = phero.angleToPhero3Heading;
		}

		public static void ExecuteNeuron(ref Node node, float input, float period)
		{
			if (!TypeUsesBiasDifferently(node.Type))
			{
				input += node.baseActivation;
			}
			else if (node.Type == NodeType.Mult)
			{
				input *= node.baseActivation;
			}
			node.LastOutput = (node.Value = Mathf.Clamp(node.Type switch
			{
				NodeType.Input => input, 
				NodeType.Sigmoid => 1f / (1f + Mathf.Pow(MathF.E, 0f - input)), 
				NodeType.Linear => input, 
				NodeType.TanH => (float)Math.Tanh(input), 
				NodeType.Sine => Mathf.Sin(input), 
				NodeType.ReLu => Mathf.Max(input, 0f), 
				NodeType.Gaussian => 1f / (1f + Mathf.Pow(input, 2f)), 
				NodeType.Latch => (input >= 1f) ? 1f : ((input < 0f) ? 0f : node.LastOutput), 
				NodeType.Differential => (input - node.LastInput) / period, 
				NodeType.Abs => Mathf.Abs(input), 
				NodeType.Mult => input, 
				NodeType.Integrator => node.LastOutput + input * period, 
				NodeType.Inhibitory => input - node.LastInput + node.LastOutput * Mathf.Exp((0f - node.baseActivation) * period), 
				NodeType.SoftLatch => SoftLatchFunc(node, input), 
				_ => 0f, 
			}, -1024f, 1024f));
			node.LastInput = input;
		}

		public void MutateSynapses()
		{
			float num = UnityEngine.Random.Range(0f, 1f);
			if (num < ScenarioSettings.Instance.synapseAddChance.val)
			{
				AddSynapse();
				return;
			}
			num -= ScenarioSettings.Instance.synapseAddChance.val;
			if (num < ScenarioSettings.Instance.synapseChangeChance.val)
			{
				ChangeSynapseStrength();
				return;
			}
			num -= ScenarioSettings.Instance.synapseChangeChance.val;
			if (num < ScenarioSettings.Instance.synapseFlipChance.val)
			{
				FlipSynapse();
				return;
			}
			num -= ScenarioSettings.Instance.synapseFlipChance.val;
			if (num < ScenarioSettings.Instance.synapseToggleChance.val)
			{
				ToggleSynapseEnabled();
				return;
			}
			num -= ScenarioSettings.Instance.synapseToggleChance.val;
			if (num < ScenarioSettings.Instance.synapseRemoveChance.val)
			{
				RemoveDisabledSynapse();
			}
			else
			{
				num -= ScenarioSettings.Instance.synapseRemoveChance.val;
			}
		}

		public int AddSynapse(int? nodeInIndex = null, int? nodeOutIndex = null, float? strength = null, bool enabledState = true)
		{
			int valueOrDefault = nodeInIndex.GetValueOrDefault();
			if (!nodeInIndex.HasValue)
			{
				valueOrDefault = ((UnityEngine.Random.Range(0, NInputs + nHidden) < NInputs) ? GetInputIndex() : GetHiddenIndex());
				nodeInIndex = valueOrDefault;
			}
			valueOrDefault = nodeOutIndex.GetValueOrDefault();
			if (!nodeOutIndex.HasValue)
			{
				valueOrDefault = UnityEngine.Random.Range(NInputs, NInputs + NOutputs + nHidden);
				nodeOutIndex = valueOrDefault;
			}
			if (!herdingEnabled && nodeOutIndex == NInputs + 2)
			{
				return AddSynapse(nodeInIndex, null, strength, enabledState);
			}
			float valueOrDefault2 = strength.GetValueOrDefault();
			if (!strength.HasValue)
			{
				valueOrDefault2 = r.NextGaussian(0f, 0.5f);
				strength = valueOrDefault2;
			}
			int num = synapse.IndexOf(synapse.FirstOrDefault((Synaps s) => s.NodeIn == nodeInIndex && s.NodeOut == nodeOutIndex));
			if (num >= 0)
			{
				ChangeSynapseStrength(num, synapse[num].Weight + strength);
				return -1;
			}
			Node value = nodese[nodeInIndex.Value];
			value.NOut++;
			nodese[nodeInIndex.Value] = value;
			value = nodese[nodeOutIndex.Value];
			value.NIn++;
			nodese[nodeOutIndex.Value] = value;
			nSynaps++;
			synapse.Add(new Synaps(connectionMaxInov++, nodeInIndex.Value, nodeOutIndex.Value, strength.Value, enabledState));
			return nSynaps - 1;
		}

		public int ChangeSynapseStrength(int? index = null, float? strength = null)
		{
			if (nSynaps == 0)
			{
				AddSynapse();
			}
			int num = index ?? UnityEngine.Random.Range(0, nSynaps);
			Synaps value = synapse[num];
			value.Weight = strength ?? (value.Weight + r.NextMutationValue(value.Weight, mutationVariance, 1f));
			synapse[num] = value;
			return num;
		}

		public int FlipSynapse(int? targetSynaps = null)
		{
			if (nSynaps == 0)
			{
				AddSynapse();
			}
			int num = targetSynaps ?? UnityEngine.Random.Range(0, nSynaps);
			Synaps value = synapse[num];
			value.Weight *= -1f;
			synapse[num] = value;
			return num;
		}

		public int ToggleSynapseEnabled(int? targetSynapse = null)
		{
			if (nSynaps == 0)
			{
				AddSynapse();
			}
			int num = targetSynapse ?? UnityEngine.Random.Range(0, nSynaps);
			Synaps value = synapse[num];
			if (value.En)
			{
				value.En = false;
				disabledSynapses.Add(num);
			}
			else
			{
				value.En = true;
				disabledSynapses.Remove(num);
			}
			synapse[num] = value;
			return num;
		}

		private void RemoveDisabledSynapse()
		{
			if (disabledSynapses.Count > 0)
			{
				int index = UnityEngine.Random.Range(0, disabledSynapses.Count);
				RemoveSynapse(disabledSynapses[index]);
			}
			else
			{
				ToggleSynapseEnabled();
			}
		}

		public void RemoveSynapse(int? sel = null, bool fromRemovedNeuron = false)
		{
			if (nSynaps > 0)
			{
				Synaps synaps = synapse[sel ?? UnityEngine.Random.Range(0, nSynaps)];
				if (!fromRemovedNeuron)
				{
					changeN = new bool[nHidden];
					changeS = new bool[nSynaps];
				}
				Node value = nodese[synaps.NodeIn];
				value.NOut--;
				nodese[synaps.NodeIn] = value;
				if (synaps.NodeIn > NInputs + NOutputs && (value.NIn < 1 || value.NOut < 1) && !changeN[synaps.NodeIn - NOutputs - NInputs])
				{
					RemoveNeuron(synaps.NodeIn, fromSynapseRemoval: true);
				}
				value = nodese[synaps.NodeOut];
				value.NIn--;
				nodese[synaps.NodeOut] = value;
				if (synaps.NodeOut > NInputs + NOutputs && (value.NIn < 1 || value.NOut < 1) && !changeN[synaps.NodeOut - NOutputs - NInputs])
				{
					RemoveNeuron(synaps.NodeOut, fromSynapseRemoval: true);
				}
				changeS[sel.Value] = true;
				disabledSynapses.Remove(sel.Value);
				if (!fromRemovedNeuron)
				{
					FinishRemovalProcess();
				}
			}
		}

		private void MutateNeurons()
		{
			float num = UnityEngine.Random.Range(0f, 1f);
			if (num < ScenarioSettings.Instance.neuronDefaultChance.val)
			{
				ChangeDefaultAct();
				return;
			}
			num -= ScenarioSettings.Instance.neuronDefaultChance.val;
			if (num < ScenarioSettings.Instance.neuronChangeChance.val)
			{
				ChangeNeuronType();
				return;
			}
			num -= ScenarioSettings.Instance.neuronChangeChance.val;
			if (num < ScenarioSettings.Instance.neuronAddChance.val)
			{
				AddNeuron();
				return;
			}
			num -= ScenarioSettings.Instance.neuronRemoveChance.val;
			if (num < ScenarioSettings.Instance.neuronRemoveChance.val)
			{
				RemoveNeuron();
			}
			else
			{
				num -= ScenarioSettings.Instance.neuronChangeChance.val;
			}
		}

		public void RemoveNeuron(int? sel = null, bool fromSynapseRemoval = false)
		{
			if (sel < NInputs + NOutputs || nHidden <= 0)
			{
				return;
			}
			int valueOrDefault = sel.GetValueOrDefault();
			if (!sel.HasValue)
			{
				valueOrDefault = UnityEngine.Random.Range(NInputs + NOutputs, NInputs + NOutputs + nHidden);
				sel = valueOrDefault;
			}
			if (!fromSynapseRemoval)
			{
				changeN = new bool[nHidden];
				changeS = new bool[nSynaps];
			}
			changeN[sel.Value - NInputs - NOutputs] = true;
			for (int i = 0; i < nSynaps; i++)
			{
				if ((synapse[i].NodeIn == sel || synapse[i].NodeOut == sel) && !changeS[i])
				{
					RemoveSynapse(i, fromRemovedNeuron: true);
				}
			}
			if (!fromSynapseRemoval)
			{
				FinishRemovalProcess();
			}
		}

		public int AddNeuron(int? fromSynaps = null, NodeType? newNodeType = null, string desc = "")
		{
			if (nSynaps < 1)
			{
				AddSynapse();
			}
			int valueOrDefault = fromSynaps.GetValueOrDefault();
			if (!fromSynaps.HasValue)
			{
				valueOrDefault = UnityEngine.Random.Range(0, nSynaps);
				fromSynaps = valueOrDefault;
			}
			NodeType nodeType = (NodeType)(((int?)newNodeType) ?? UnityEngine.Random.Range(1, NNodesTypes));
			nHidden++;
			desc = ((desc != "") ? desc : ("Hidden" + (nHidden - 1)));
			float defaultAct = 0f;
			switch (nodeType)
			{
			case NodeType.Inhibitory:
				defaultAct = Mathf.Pow(10f, UnityEngine.Random.Range(-2f, 1f));
				break;
			case NodeType.Mult:
				defaultAct = 1f;
				break;
			case NodeType.SoftLatch:
				defaultAct = Mathf.Pow(10f, UnityEngine.Random.Range(-1f, 1f));
				break;
			}
			nodese.Add(new Node(nodeType, ++nodeMaxInov, desc, GetHiddenIndex(nHidden - 1), 1, 1, defaultAct));
			Synaps value = synapse[fromSynaps.Value];
			value.En = false;
			synapse[fromSynaps.Value] = value;
			nSynaps += 2;
			bool flag = UnityEngine.Random.value >= 0.5f;
			synapse.Add(new Synaps(connectionMaxInov++, value.NodeIn, nodese.Count - 1, flag ? value.Weight : 1f, en: true));
			synapse.Add(new Synaps(connectionMaxInov++, nodese.Count - 1, value.NodeOut, flag ? 1f : value.Weight, en: true));
			return nodese.Count - 1;
		}

		public int ChangeDefaultAct(int? targetNode = null, float? newValue = null)
		{
			int num = targetNode ?? GetRandomNonInput();
			Node value = nodese[num];
			if (value.Type == NodeType.Integrator)
			{
				return ChangeDefaultAct();
			}
			value.baseActivation = newValue ?? (value.baseActivation + r.NextMutationValue(value.baseActivation, mutationVariance, 1f, value.Type == NodeType.Inhibitory));
			if (value.Type == NodeType.Inhibitory)
			{
				value.baseActivation = Mathf.Clamp(value.baseActivation, 0.0001f, 10f);
			}
			else if (value.Type == NodeType.SoftLatch)
			{
				value.baseActivation = Mathf.Clamp(value.baseActivation, 0.1f, 100f);
			}
			nodese[num] = value;
			return num;
		}

		public int ChangeNeuronType(int? targetNode = null, NodeType? newType = null)
		{
			if (nHidden < 1)
			{
				return AddNeuron();
			}
			int hiddenIndex = GetHiddenIndex(targetNode);
			Node value = nodese[hiddenIndex];
			value.Type = (NodeType)(((int?)newType) ?? UnityEngine.Random.Range(1, NNodesTypes));
			NodeType type = value.Type;
			if (type == NodeType.Inhibitory || type == NodeType.Mult)
			{
				value.baseActivation = Mathf.Clamp(Mathf.Abs(value.baseActivation), 0.1f, 1f);
			}
			else if (value.Type == NodeType.Integrator)
			{
				value.baseActivation = 0f;
			}
			else if (value.Type == NodeType.SoftLatch)
			{
				value.baseActivation = Mathf.Clamp(value.baseActivation, 0.1f, 100f);
			}
			nodese[hiddenIndex] = value;
			return hiddenIndex;
		}

		public void FinishRemovalProcess()
		{
			for (int num = nHidden - 1; num >= 0; num--)
			{
				if (changeN[num])
				{
					nHidden--;
					nodese.RemoveAt(num + NInputs + NOutputs);
					for (int i = 0; i < nSynaps; i++)
					{
						if (synapse[i].NodeIn >= num + NInputs + NOutputs)
						{
							Synaps value = synapse[i];
							value.NodeIn--;
							synapse[i] = value;
						}
						if (synapse[i].NodeOut >= num + NInputs + NOutputs)
						{
							Synaps value2 = synapse[i];
							value2.NodeOut--;
							synapse[i] = value2;
						}
					}
				}
			}
			for (int num2 = nSynaps - 1; num2 >= 0; num2--)
			{
				if (changeS[num2])
				{
					nSynaps--;
					synapse.RemoveAt(num2);
				}
			}
			disabledSynapses.Clear();
			for (int j = 0; j < nSynaps; j++)
			{
				if (!synapse[j].En)
				{
					disabledSynapses.Add(j);
				}
			}
		}

		private void CopyNode(Node node)
		{
			nodese.Add(new Node(node.Type, node.Inov, node.Desc, node.Index, node.NIn, node.NOut, node.baseActivation));
		}

		private void CopySynaps(Synaps syn)
		{
			int num = synapse.IndexOf(synapse.FirstOrDefault((Synaps s) => s.NodeIn == syn.NodeIn && s.NodeOut == syn.NodeOut));
			if (num >= 0)
			{
				synapse[num] = new Synaps(synapse[num].Inov, syn.NodeIn, syn.NodeOut, syn.Weight + synapse[num].Weight, synapse[num].En);
			}
			else
			{
				synapse.Add(new Synaps(syn.Inov, syn.NodeIn, syn.NodeOut, syn.Weight, syn.En));
			}
		}

		public void SetBaseNeuronsTypeAndDesc()
		{
			SetBaseNeuronsTypeAndDesc(Nodes);
		}

		public static void SetBaseNeuronsTypeAndDesc(Node[] nodes)
		{
			for (int i = 0; i < NInputs; i++)
			{
				nodes[i].Type = NodeType.Input;
				nodes[i].Desc = Enum.GetName(typeof(Inputs), i);
				nodes[i].Index = i;
			}
			for (int j = NInputs; j < NInputs + NOutputs; j++)
			{
				nodes[j].Type = NodeType.Sigmoid;
				nodes[j].Desc = Enum.GetName(typeof(Outputs), j - NInputs);
				nodes[j].Index = j;
			}
			nodes[NInputs].Type = NodeType.TanH;
			nodes[NInputs + 1].Type = NodeType.TanH;
			nodes[NInputs + 2].Type = NodeType.TanH;
			nodes[NInputs + 7].Type = NodeType.TanH;
			nodes[NInputs + 3].Type = NodeType.TanH;
			nodes[NInputs + 5].Type = NodeType.TanH;
			nodes[NInputs + 9].Type = NodeType.ReLu;
			nodes[NInputs + 10].Type = NodeType.ReLu;
			nodes[NInputs + 11].Type = NodeType.ReLu;
			for (int k = NInputs + NOutputs; k < nodes.Length; k++)
			{
				nodes[k].Index = k;
			}
		}

		private static int GetInputIndex(Inputs? input = null)
		{
			return ((int?)input) ?? UnityEngine.Random.Range(0, NInputs - 1);
		}

		private static int GetOutputIndex(Outputs? output)
		{
			return NInputs + (((int?)output) ?? UnityEngine.Random.Range(0, NOutputs));
		}

		private int GetHiddenIndex(int? hidden = null)
		{
			return NInputs + NOutputs + (hidden ?? UnityEngine.Random.Range(0, nHidden));
		}

		private int GetRandomNonInput()
		{
			return UnityEngine.Random.Range(NInputs, NInputs + NOutputs + nHidden);
		}

		private int GetRandomNodeIndex()
		{
			return UnityEngine.Random.Range(0, NInputs + NOutputs + nHidden);
		}

		public static float DefaultBaseActivationOfType(NodeType type)
		{
			return type switch
			{
				NodeType.Mult => 1f, 
				NodeType.Inhibitory => 1f, 
				NodeType.SoftLatch => 5f, 
				_ => 0f, 
			};
		}

		private void OnDestroy()
		{
			body = null;
			growth = null;
			gene = null;
			pheromoneOrgan = null;
			fow = null;
			clk = null;
			phero = null;
		}

		public static float SoftLatchFunc(Node node, float x)
		{
			float baseActivation = node.baseActivation;
			float lastOutput = node.LastOutput;
			float num = node.LastInput;
			if (x >= 0.999f)
			{
				return 1f;
			}
			if (x <= 0.001f)
			{
				return 0f;
			}
			if (num >= 0.999f)
			{
				num = 1f;
			}
			if (num <= 0.001f)
			{
				num = 0f;
			}
			float num2 = 0f;
			if (x < num)
			{
				return lastOutput / (1f - Mathf.Exp((0f - baseActivation) * num)) * (1f - Mathf.Exp((0f - baseActivation) * x));
			}
			float num3 = (lastOutput - Mathf.Exp(baseActivation * (num - 1f))) / (1f - Mathf.Exp(baseActivation * (num - 1f)));
			return num3 + (1f - num3) * Mathf.Exp(baseActivation * (x - 1f));
		}
	}
}
