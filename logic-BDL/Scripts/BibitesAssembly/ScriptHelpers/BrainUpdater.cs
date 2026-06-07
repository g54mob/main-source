using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using SimulationScripts.BibiteScripts;
using UnityEngine;
using Utility;

namespace ScriptHelpers
{
	public static class BrainUpdater
	{
		public static readonly List<VersionBrainChange> VersionChanges = new List<VersionBrainChange>
		{
			new VersionBrainChange
			{
				version = new Version(0, 6, 2, 1),
				removedInputs = new NodeChanges[0],
				addedInputs = new NodeChanges[1]
				{
					new NodeChanges(5, 1)
				},
				addedOutputs = new NodeChanges[0],
				removedOutputs = new NodeChanges[0]
			},
			new VersionBrainChange
			{
				version = new Version(0, 6, 0, 18),
				removedInputs = new NodeChanges[1]
				{
					new NodeChanges(32, 1)
				},
				addedInputs = new NodeChanges[0],
				addedOutputs = new NodeChanges[0],
				removedOutputs = new NodeChanges[1]
				{
					new NodeChanges(15, 1)
				}
			},
			new VersionBrainChange
			{
				version = new Version(0, 6, 0, 16),
				removedInputs = new NodeChanges[0],
				removedOutputs = new NodeChanges[0],
				addedInputs = new NodeChanges[0],
				addedOutputs = new NodeChanges[0],
				updateAfterFunction = UpdateTo0_6_0_16
			},
			new VersionBrainChange
			{
				version = new Version(0, 6, 0, 15),
				removedInputs = new NodeChanges[0],
				removedOutputs = new NodeChanges[0],
				addedInputs = new NodeChanges[0],
				addedOutputs = new NodeChanges[0],
				updateAfterFunction = UpdateTo0_6_0_15
			},
			new VersionBrainChange
			{
				version = new Version(0, 6, 0, 13),
				removedInputs = new NodeChanges[1]
				{
					new NodeChanges(0, 1)
				},
				removedOutputs = new NodeChanges[0],
				addedInputs = new NodeChanges[0],
				addedOutputs = new NodeChanges[0],
				updateAtEndFunction = UpdateTo0_6_0_13
			},
			new VersionBrainChange
			{
				version = new Version(0, 6, 0, 5),
				addedInputs = new NodeChanges[1]
				{
					new NodeChanges(8, 1)
				},
				removedOutputs = new NodeChanges[0],
				removedInputs = new NodeChanges[0],
				addedOutputs = new NodeChanges[1]
				{
					new NodeChanges(3, 1)
				},
				updateAfterFunction = UpdateTo0_6_0_5
			},
			new VersionBrainChange
			{
				version = new Version(0, 4, 0, 3),
				addedInputs = new NodeChanges[2]
				{
					new NodeChanges(28, 3),
					new NodeChanges(4, 1)
				},
				removedOutputs = new NodeChanges[0],
				removedInputs = new NodeChanges[0],
				addedOutputs = new NodeChanges[0]
			},
			new VersionBrainChange
			{
				version = new Version(0, 3),
				removedInputs = new NodeChanges[0],
				removedOutputs = new NodeChanges[0],
				addedInputs = new NodeChanges[0],
				addedOutputs = new NodeChanges[0]
			}
		};

		public static Dictionary<int, long> nodeInnovations = new Dictionary<int, long>();

		public static Dictionary<InOut, long> connectionInnovations = new Dictionary<InOut, long>();

		private static List<int> indexMap;

		private static List<int> progIndexMap;

		public static bool ChangesSinceVersion(Version version)
		{
			foreach (VersionBrainChange item in VersionChanges.OrderByDescending((VersionBrainChange v) => v.version))
			{
				if (version >= item.version)
				{
					return false;
				}
				if (!item.canBeUpdatedFromOlderVersion)
				{
					return true;
				}
				if (item.anyChanges)
				{
					return true;
				}
			}
			return false;
		}

		public static bool CanUpdateFromVersion(Version version)
		{
			foreach (VersionBrainChange item in VersionChanges.OrderByDescending((VersionBrainChange v) => v.version))
			{
				if (version >= item.version)
				{
					return true;
				}
				if (!item.canBeUpdatedFromOlderVersion)
				{
					return false;
				}
			}
			return true;
		}

		public static void UpdateBrainFromVersion(NEATBrain brain, Version version)
		{
			if (ChangesSinceVersion(version))
			{
				List<NEATBrain.Node> list = brain.Nodes.ToList();
				List<NEATBrain.Synaps> list2 = brain.Synapses.ToList();
				UpdateElementsFromVersion(list, list2, version);
				brain.Nodes = list.ToArray();
				brain.Synapses = list2.ToArray();
				brain.SetBaseNeuronsTypeAndDesc();
			}
		}

		public static bool UpdateTemplateToPresentVersion(BibiteTemplate template)
		{
			Version version = Version.Parse(template.version);
			if (!ChangesSinceVersion(version))
			{
				return false;
			}
			List<NEATBrain.Node> list = template.nodes.ToList();
			List<NEATBrain.Synaps> list2 = template.synapses.ToList();
			List<int> list3 = UpdateElementsFromVersion(list, list2, version);
			if (template.nodeAnchors != null && template.nodeAnchors.Count > 0)
			{
				Dictionary<long, Vector2> dictionary = new Dictionary<long, Vector2>();
				foreach (KeyValuePair<long, Vector2> nodeAnchor in template.nodeAnchors)
				{
					for (int i = 0; i < list3.Count; i++)
					{
						if (list3[i] >= 0 && template.nodes[i].Inov == nodeAnchor.Key)
						{
							dictionary.Add(list[list3[i]].Inov, nodeAnchor.Value);
							break;
						}
					}
				}
				template.nodeAnchors = dictionary;
			}
			template.nodes = list.ToArray();
			template.synapses = list2.ToArray();
			NEATBrain.SetBaseNeuronsTypeAndDesc(template.nodes);
			foreach (VersionBrainChange item in from v in VersionChanges
				where v.version > version
				orderby v.version
				select v)
			{
				item.updateTemplateFunction?.Invoke(template);
			}
			return true;
		}

		private static List<int> UpdateElementsFromVersion(List<NEATBrain.Node> nodes, List<NEATBrain.Synaps> synapses, Version fromVersion)
		{
			int num = NEATBrain.NInputs;
			int num2 = NEATBrain.NOutputs;
			int num3 = 0;
			new List<int>();
			List<VersionBrainChange> source = VersionChanges.Where((VersionBrainChange v) => v.version > fromVersion && v.anyChanges).ToList();
			indexMap = Enumerable.Range(0, num + num2).ToList();
			foreach (VersionBrainChange item in source.OrderByDescending((VersionBrainChange v) => v.version))
			{
				foreach (NodeChanges item2 in item.addedOutputs.OrderBy((NodeChanges v) => v.Position))
				{
					indexMap.RemoveRange(num + item2.Position, item2.Amount);
					num2 -= item2.Amount;
					num3 += item2.Amount;
				}
				foreach (NodeChanges item3 in item.addedInputs.OrderBy((NodeChanges v) => v.Position))
				{
					indexMap.RemoveRange(item3.Position, item3.Amount);
					num -= item3.Amount;
					num3 += item3.Amount;
				}
				foreach (NodeChanges item4 in item.removedInputs.OrderBy((NodeChanges v) => v.Position))
				{
					for (int num4 = 0; num4 < item4.Amount; num4++)
					{
						indexMap.Insert(item4.Position, -1);
					}
					num += item4.Amount;
					num3 -= item4.Amount;
				}
				foreach (NodeChanges item5 in item.removedOutputs.OrderBy((NodeChanges v) => v.Position))
				{
					for (int num5 = 0; num5 < item5.Amount; num5++)
					{
						indexMap.Insert(num + item5.Position, -1);
					}
					num2 += item5.Amount;
					num3 -= item5.Amount;
				}
			}
			_ = nodes.Count;
			for (int num6 = num + num2; num6 < nodes.Count; num6++)
			{
				indexMap.Add(num6 + num3);
			}
			progIndexMap = indexMap.ToList();
			foreach (VersionBrainChange item6 in source.OrderBy((VersionBrainChange v) => v.version))
			{
				item6.updateBeforeFunction?.Invoke(nodes, synapses);
				foreach (NodeChanges item7 in item6.removedOutputs.OrderByDescending((NodeChanges v) => v.Position))
				{
					nodes.RemoveRange(num + item7.Position, item7.Amount);
					progIndexMap.RemoveRange(num + item7.Position, item7.Amount);
					num2 -= item7.Amount;
				}
				foreach (NodeChanges item8 in item6.removedInputs.OrderByDescending((NodeChanges v) => v.Position))
				{
					nodes.RemoveRange(item8.Position, item8.Amount);
					progIndexMap.RemoveRange(item8.Position, item8.Amount);
					num -= item8.Amount;
				}
				foreach (NodeChanges item9 in item6.addedInputs.OrderBy((NodeChanges v) => v.Position))
				{
					int amount = item9.Amount;
					for (int num7 = 0; num7 < amount; num7++)
					{
						nodes.Insert(item9.Position, default(NEATBrain.Node));
						progIndexMap.Insert(item9.Position, item9.Position + num7);
					}
					num += amount;
				}
				foreach (NodeChanges item10 in item6.addedOutputs.OrderBy((NodeChanges v) => v.Position))
				{
					int amount2 = item10.Amount;
					for (int num8 = 0; num8 < amount2; num8++)
					{
						nodes.Insert(num + item10.Position, default(NEATBrain.Node));
						progIndexMap.Insert(num + item10.Position, num + item10.Position + num8);
					}
					num2 += amount2;
				}
				if (item6.updateAfterFunction != null)
				{
					item6.updateAfterFunction(nodes, synapses);
				}
			}
			if (num != NEATBrain.NInputs || num2 != NEATBrain.NOutputs)
			{
				PopupManager.DisplayError("Bibite Updater", "There was an error loading this bibite, the inputs+outputs counts did not match up with the supposed numbers from its version " + fromVersion.ToString());
			}
			foreach (VersionBrainChange item11 in source.OrderBy((VersionBrainChange v) => v.version))
			{
				if (item11.updateAtEndFunction != null)
				{
					item11.updateAtEndFunction(nodes, synapses);
				}
			}
			for (int num9 = 0; num9 < nodes.Count; num9++)
			{
				NEATBrain.Node value = nodes[num9];
				value.Index = num9;
				if (num9 < NEATBrain.NInputs + NEATBrain.NOutputs)
				{
					value.Inov = num9 + 1;
				}
				else
				{
					value.Inov += num3;
				}
				nodes[num9] = value;
			}
			synapses.RemoveAll((NEATBrain.Synaps s) => indexMap[s.NodeIn] < 0 || indexMap[s.NodeOut] < 0);
			for (int num10 = 0; num10 < synapses.Count; num10++)
			{
				synapses[num10] = new NEATBrain.Synaps
				{
					En = synapses[num10].En,
					Inov = synapses[num10].Inov,
					Weight = synapses[num10].Weight,
					NodeIn = indexMap[synapses[num10].NodeIn],
					NodeOut = indexMap[synapses[num10].NodeOut]
				};
			}
			return indexMap;
		}

		private static void UpdateTo0_6_0_16(List<NEATBrain.Node> nodes, List<NEATBrain.Synaps> synapses)
		{
			NEATBrain.Node value = nodes[38];
			float num = 0.28f;
			float num2 = 0.528f;
			value.Type = NEATBrain.NodeType.TanH;
			value.TypeName = "TanH";
			value.baseActivation = num * value.baseActivation + num2;
			for (int i = 0; i < synapses.Count; i++)
			{
				if (synapses[i].NodeOut == 38)
				{
					NEATBrain.Synaps value2 = synapses[i];
					value2.Weight *= num;
					synapses[i] = value2;
				}
			}
			nodes[38] = value;
		}

		private static void UpdateTo0_6_0_15(List<NEATBrain.Node> nodes, List<NEATBrain.Synaps> synapses)
		{
			NEATBrain.Node value = nodes[38];
			if (Mathf.Approximately(value.baseActivation, 0f))
			{
				value.baseActivation = 2.5f;
			}
			nodes[38] = value;
		}

		private static void UpdateTo0_6_0_13(List<NEATBrain.Node> nodes, List<NEATBrain.Synaps> synapses)
		{
			foreach (NEATBrain.Synaps item in synapses.Where((NEATBrain.Synaps s) => s.NodeIn == 0 && s.En))
			{
				int num = indexMap[item.NodeOut];
				if (num >= 0)
				{
					NEATBrain.Node value = nodes[num];
					value.baseActivation += item.Weight;
					nodes[num] = value;
				}
			}
			for (int num2 = 0; num2 < synapses.Count; num2++)
			{
				NEATBrain.Synaps value2 = synapses[num2];
				if (value2.NodeIn == 0)
				{
					value2.NodeIn = Random.Range(1, 14);
					value2.En = false;
					synapses[num2] = value2;
				}
			}
			for (int num3 = 0; num3 < nodes.Count; num3++)
			{
				NEATBrain.Node value3 = nodes[num3];
				if (value3.Type == NEATBrain.NodeType.Mult)
				{
					if (value3.baseActivation == 0f)
					{
						value3.baseActivation = 1f;
					}
					nodes[num3] = value3;
				}
			}
		}

		private static void UpdateTo0_6_0_5(List<NEATBrain.Node> nodes, List<NEATBrain.Synaps> synapses)
		{
			NEATBrain.Node value = nodes[37];
			value.baseActivation = 0.2f;
			nodes[37] = value;
			InOut key = new InOut
			{
				iIn = 0,
				iOut = 0
			};
			for (int i = 0; i < synapses.Count; i++)
			{
				NEATBrain.Synaps value2 = synapses[i];
				if (value2.Inov == 0L)
				{
					key.iIn = value2.NodeIn;
					key.iOut = value2.NodeOut;
					if (connectionInnovations.ContainsKey(key))
					{
						value2.Inov = connectionInnovations[key];
					}
					else
					{
						long num = NEATBrain.connectionMaxInov++;
						connectionInnovations.Add(key, num);
						value2.Inov = num;
					}
					synapses[i] = value2;
				}
			}
		}
	}
}
