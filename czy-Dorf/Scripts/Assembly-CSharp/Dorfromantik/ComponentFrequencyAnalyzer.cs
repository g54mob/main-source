using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Dorfromantik
{
	public class ComponentFrequencyAnalyzer : MonoBehaviour
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<ComponentCountInfo, int> _003C_003E9__3_0;

			public static Func<NameFrequency, int> _003C_003E9__3_1;

			internal int _003CAnalyze_003Eb__3_0(ComponentCountInfo x)
			{
				return x.count;
			}

			internal int _003CAnalyze_003Eb__3_1(NameFrequency x)
			{
				return x.count;
			}
		}

		[SerializeField]
		private List<ComponentCountInfo> componentFrequency = new List<ComponentCountInfo>();

		private Dictionary<string, ComponentCountInfo> componentCountByType = new Dictionary<string, ComponentCountInfo>();

		private Dictionary<string, List<string>> categories = new Dictionary<string, List<string>>
		{
			{
				"House Instancing",
				new List<string> { "House" }
			},
			{
				"Vehicle Paths",
				new List<string> { "VehicleSegmentPath", "PathPoints", "VehiclePath", "Paths" }
			},
			{
				"Quest Tile Instancing",
				new List<string> { "Tree", "Grass", "Stone", "Flower", "Edge" }
			},
			{
				"Group Segment",
				new List<string> { "Group_", "GroupSegment" }
			},
			{
				"Field Instancing",
				new List<string> { "WheatField", "Field_" }
			},
			{
				"Special Tiles",
				new List<string> { "ClockTower", "Clocktower", "Roof", "QuestGiver", "Ground_Cluster", "GroundCluster", "GroundPatches" }
			},
			{
				"TileGround",
				new List<string> { "Ground" }
			},
			{
				"Water Decoration",
				new List<string> { "WaterDecoration", "Ice", "Reed" }
			},
			{
				"River Instancing",
				new List<string> { "Lake", "River" }
			},
			{
				"Train Track Instancing",
				new List<string> { "Traintrack" }
			},
			{
				"Village Decoration",
				new List<string> { "Greenery", "VillageDecoration", "Crate", "Bush", "Vase", "Pumpkin" }
			},
			{
				"TileSlot",
				new List<string> { "TileSlot", "HexagonPlane" }
			},
			{
				"ElementGroup",
				new List<string> { "Village", "Forest", "Agriculture", "Water", "Train" }
			}
		};

		private void Analyze()
		{
			componentFrequency.Clear();
			componentCountByType.Clear();
			Component[] array = UnityEngine.Object.FindObjectsOfType<Component>();
			foreach (Component obj in array)
			{
				string text = obj.GetType().Name;
				if (!componentCountByType.ContainsKey(text))
				{
					ComponentCountInfo componentCountInfo = new ComponentCountInfo
					{
						componentType = text
					};
					componentFrequency.Add(componentCountInfo);
					componentCountByType.Add(text, componentCountInfo);
				}
				componentCountByType[text].count++;
				string[] array2 = obj.gameObject.name.Split(' ');
				for (int j = 1; j < array2.Length; j++)
				{
					array2[j] = array2[j - 1] + " " + array2[j];
				}
				List<NameFrequency> list = componentCountByType[text].nameFrequencies;
				Dictionary<string, NameFrequency> dictionary = componentCountByType[text].nameFrequencyByName;
				string[] array3 = array2;
				foreach (string key in array3)
				{
					if (!dictionary.ContainsKey(key))
					{
						NameFrequency nameFrequency = new NameFrequency();
						nameFrequency.name = key;
						list.Add(nameFrequency);
						dictionary.Add(key, nameFrequency);
					}
					dictionary[key].count++;
					list = dictionary[key].subNameFrequencies;
					dictionary = dictionary[key].subNameFrequencyByName;
				}
			}
			componentFrequency = Enumerable.ToList(Enumerable.OrderByDescending(componentFrequency, (ComponentCountInfo x) => x.count));
			foreach (ComponentCountInfo item in componentFrequency)
			{
				item.nameFrequencies = Enumerable.ToList(Enumerable.OrderByDescending(item.nameFrequencies, (NameFrequency x) => x.count));
				foreach (NameFrequency nameFrequency2 in item.nameFrequencies)
				{
					nameFrequency2.MergeWithSubNameFrequencies();
					nameFrequency2.SortSubNameFrequencies();
				}
			}
		}

		private void ExportReport(string outputFileName = "ComponentAnalyzer")
		{
			string text = Application.persistentDataPath + $"{outputFileName}_{DateTime.Now:yyyy-MM-dd}.csv";
			StreamWriter streamWriter = new StreamWriter(text);
			streamWriter.WriteLine("ComponentType,ComponentName,Count,SubnameCount, Category");
			foreach (ComponentCountInfo item in componentFrequency)
			{
				streamWriter.WriteLine($"{item.componentType},{item.count}");
				foreach (NameFrequency nameFrequency in item.nameFrequencies)
				{
					foreach (string nameFrequencyLine in nameFrequency.GetNameFrequencyLines())
					{
						string text2 = "";
						foreach (KeyValuePair<string, List<string>> category in categories)
						{
							foreach (string item2 in category.Value)
							{
								if (nameFrequencyLine.Contains(item2))
								{
									text2 = category.Key;
									break;
								}
							}
							if (text2 != "")
							{
								break;
							}
						}
						streamWriter.WriteLine(item.componentType.Replace(',', ' ') + ", " + nameFrequencyLine + ", " + text2);
					}
				}
			}
			streamWriter.Flush();
			streamWriter.Close();
			Debug.Log("file generated! " + text);
		}
	}
}
