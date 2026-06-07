using System;
using System.Collections.Generic;
using ManagementScripts;
using ScriptHelpers;
using SimulationScripts;
using UIScripts;
using UIScripts.InfoHandles;
using UnityEngine;

namespace Utility
{
	public class DataLogger : MonoBehaviour, ISaveableBin
	{
		[NonSerialized]
		public static DataLogger Instance;

		[SerializeField]
		private float progress;

		[SerializeField]
		private int nMinutes;

		private float periodSeconds = 60f;

		private float speciesLogPeriod = SerialSpeciesConfig.acquisitionFactor;

		private int nMinutesInHour = 60;

		[NonSerialized]
		public List<IDataPointStream> parallelDataStreams;

		private SaveableBinStack saveableStack;

		public BibiteTracker tracker;

		public InformationPanel infoPanel;

		public static readonly LogLikeConfig ParallelDetailedConfig = new LogLikeConfig(new LogLikeFormat[6]
		{
			new LogLikeFormat(60, 10),
			new LogLikeFormat(60, 3),
			new LogLikeFormat(96, 6),
			new LogLikeFormat(112, 8),
			new LogLikeFormat(112, 7),
			new LogLikeFormat(104)
		}, Timescale.Minutes);

		public static readonly LogLikeConfig SerialHeavyConfig = new LogLikeConfig(new LogLikeFormat[7]
		{
			new LogLikeFormat(6, 3),
			new LogLikeFormat(6, 4),
			new LogLikeFormat(8, 2),
			new LogLikeFormat(9, 7),
			new LogLikeFormat(6, 4),
			new LogLikeFormat(8, 2),
			new LogLikeFormat(8)
		}, Timescale.Hours);

		public static readonly LogLikeConfig SerialSpeciesConfig = new LogLikeConfig
		{
			acquisition = Timescale.Minutes,
			acquisitionFactor = 5,
			formats = new LogLikeFormat[11]
			{
				new LogLikeFormat(12, 2),
				new LogLikeFormat(12, 3),
				new LogLikeFormat(18, 2),
				new LogLikeFormat(36, 3),
				new LogLikeFormat(32, 2),
				new LogLikeFormat(36, 2),
				new LogLikeFormat(30, 2),
				new LogLikeFormat(30, 2),
				new LogLikeFormat(30, 5),
				new LogLikeFormat(24, 3),
				LogLikeFormat.Infinite()
			}
		};

		public DataParallelStreamGroup<DataPoint4> biomassDataStreamGroup = new DataParallelStreamGroup<DataPoint4>(ParallelDetailedConfig, new DataStreamDescription[4]
		{
			new DataStreamDescription
			{
				label = "Bibites",
				description = "The biomass level of bibites (and eggs) in the simulation",
				color = Color.white
			},
			new DataStreamDescription
			{
				label = "Plants",
				description = "The biomass level of plant pellets in your simulation",
				color = Color.green
			},
			new DataStreamDescription
			{
				label = "Meats",
				description = "The biomass level of meat pellets in your simulation",
				color = Color.red
			},
			new DataStreamDescription
			{
				label = "Free",
				description = "The free biomass level of your simulation. This represents the available biomass to grow more plants if need be.",
				color = Color.yellow
			}
		})
		{
			title = "Biomass Data",
			description = "The historic biomass levels (total energy equivalence) of your simulation",
			textFormat = new FloatValueFormat
			{
				units = "E",
				SI = true,
				precision = 2
			}
		};

		public DataParallelStreamGroup<DataPoint3> countDataStreamGroup = new DataParallelStreamGroup<DataPoint3>(ParallelDetailedConfig, new DataStreamDescription[3]
		{
			new DataStreamDescription
			{
				label = "Bibites",
				description = "The number of bibites (and eggs) in the simulation",
				color = Color.white
			},
			new DataStreamDescription
			{
				label = "Plants",
				description = "The number of plant pellets in the simulation",
				color = Color.green
			},
			new DataStreamDescription
			{
				label = "Meats",
				description = "The number of meat pellets in the simulation",
				color = Color.red
			}
		})
		{
			title = "Entities Count Data",
			description = "The historic count of each type of entities in your simulation",
			textFormat = new FloatValueFormat
			{
				isInt = true
			}
		};

		public DataParallelStreamGroup<DataPoint6> brainSizeDataStreamGroup = new DataParallelStreamGroup<DataPoint6>(ParallelDetailedConfig, new DataStreamDescription[6]
		{
			new DataStreamDescription
			{
				label = "Min Nodes",
				description = "The smallest number of brain nodes in the population",
				color = new Color(0.5f, 1f, 0.5f)
			},
			new DataStreamDescription
			{
				label = "Mean Nodes",
				description = "The average number of brain nodes in the population",
				color = Color.green
			},
			new DataStreamDescription
			{
				label = "Max Nodes",
				description = "The biggest number of brain nodes in the population",
				color = new Color(0f, 0.5f, 0f)
			},
			new DataStreamDescription
			{
				label = "Min Connections",
				description = "The smallest number of brain connections in the population",
				color = new Color(0.65f, 0.65f, 1f)
			},
			new DataStreamDescription
			{
				label = "Mean Connections",
				description = "The average number of brain connections in the population",
				color = Color.blue
			},
			new DataStreamDescription
			{
				label = "Max Connections",
				description = "The biggest number of brain connections in the population",
				color = new Color(0f, 0f, 0.5f)
			}
		})
		{
			title = "Brain Size Data",
			description = "The brain size, for both nodes and connections, range of you bibites over time",
			textFormat = new FloatValueFormat
			{
				isInt = true
			}
		};

		public DataParallelStreamGroup<DataPoint4> ageDataStreamGroup = new DataParallelStreamGroup<DataPoint4>(ParallelDetailedConfig, new DataStreamDescription[4]
		{
			new DataStreamDescription
			{
				label = "Bottom 25th percentile Age",
				description = "The age at which 25% of the bibites in your simulation are younger than this.",
				color = Color.white
			},
			new DataStreamDescription
			{
				label = "Median Age",
				description = "The age at which 50% of the bibites in your simulation are younger than this.",
				color = new Color(0.5f, 1f, 0.5f)
			},
			new DataStreamDescription
			{
				label = "Top 25th percentile Age",
				description = "The age at which 25% of the bibites in your simulation are older than this.",
				color = Color.green
			},
			new DataStreamDescription
			{
				label = "Max Age",
				description = "The age of the oldest bibite in the sim",
				color = new Color(0f, 0.5f, 0f)
			}
		})
		{
			title = "Age Data",
			description = "The age distribution of bibites in your simulation.",
			textFormat = new FloatValueFormat
			{
				units = "h",
				precision = 2,
				SI = false
			}
		};

		public DataParallelStreamGroup<DataPoint4> deathAgeDataStreamGroup = new DataParallelStreamGroup<DataPoint4>(ParallelDetailedConfig, new DataStreamDescription[4]
		{
			new DataStreamDescription
			{
				label = "Bottom 25th percentile Age",
				description = "The age at which 25% of the bibites in your simulation die younger than this.",
				color = Color.white
			},
			new DataStreamDescription
			{
				label = "Median Age",
				description = "The age at which 50% of the bibites in your simulation die younger than this.",
				color = new Color(0.5f, 1f, 0.5f)
			},
			new DataStreamDescription
			{
				label = "Top 25th percentile Age",
				description = "The age at which 25% of the bibites in your simulation die older than this.",
				color = Color.green
			},
			new DataStreamDescription
			{
				label = "Max Age",
				description = "The age of death of the bibite that lived the longest",
				color = new Color(0f, 0.5f, 0f)
			}
		})
		{
			title = "Age of Death Data",
			description = "The Age of death distribution of bibites in your simulation. \n*Using a rolling buffer of 1 hour*",
			textFormat = new FloatValueFormat
			{
				units = "h",
				precision = 2,
				SI = false
			}
		};

		public DataParallelStreamGroup<DataPoint6> eggsLaidDataStreamGroup = new DataParallelStreamGroup<DataPoint6>(ParallelDetailedConfig, new DataStreamDescription[6]
		{
			new DataStreamDescription
			{
				label = "Median eggs laid",
				description = "Half of the bibites have laid at least this many eggs.",
				color = new Color(0.66f, 0.66f, 1f)
			},
			new DataStreamDescription
			{
				label = "70th percentile eggs laid",
				description = "Only 30% of the bibites have laid more eggs than this.",
				color = new Color(0.33f, 0.33f, 1f)
			},
			new DataStreamDescription
			{
				label = "80th percentile eggs laid",
				description = "Only 20% of the bibites have laid more eggs than this.",
				color = Color.blue
			},
			new DataStreamDescription
			{
				label = "90th percentile eggs laid",
				description = "Only 10% of the bibites have laid more eggs than this.",
				color = new Color(0f, 0f, 0.66f)
			},
			new DataStreamDescription
			{
				label = "Max eggs laid",
				description = "The most number of eggs laid by a bibite",
				color = new Color(0f, 0f, 0.33f)
			},
			new DataStreamDescription
			{
				label = "Average eggs laid",
				description = "The average number of eggs laid per bibite across your simulation",
				color = Color.white
			}
		})
		{
			title = "Egg Laying Data",
			description = "The number of eggs laid by bibites in their lifetime.",
			textFormat = new FloatValueFormat
			{
				isInt = true,
				SI = false
			}
		};

		public DataParallelStreamGroup<DataPoint2> birthDeathDataStreamGroup = new DataParallelStreamGroup<DataPoint2>(ParallelDetailedConfig, new DataStreamDescription[2]
		{
			new DataStreamDescription
			{
				label = "Bibite Birth",
				description = "The number of bibite birth since the last point",
				color = Color.white
			},
			new DataStreamDescription
			{
				label = "Bibite Death",
				description = "The number of bibite that died since the last point",
				color = Color.red
			}
		}, DataPointCompress<DataPoint2>.Sum)
		{
			title = "Birth/Death Data",
			description = "The birth/death numbers for bibites between each step",
			textFormat = new FloatValueFormat
			{
				isInt = true,
				SI = false,
				precision = 0
			}
		};

		public GenesBucketsStreamGroup genesStreamGroup = new GenesBucketsStreamGroup();

		public void Awake()
		{
			Instance = this;
			parallelDataStreams = new List<IDataPointStream> { biomassDataStreamGroup, countDataStreamGroup, ageDataStreamGroup, brainSizeDataStreamGroup, deathAgeDataStreamGroup, eggsLaidDataStreamGroup, birthDeathDataStreamGroup };
			saveableStack = new SaveableBinStack
			{
				stack = new List<ISaveableBin>
				{
					biomassDataStreamGroup,
					countDataStreamGroup,
					genesStreamGroup,
					brainSizeDataStreamGroup,
					ageDataStreamGroup,
					deathAgeDataStreamGroup,
					new SaveableBinElement(eggsLaidDataStreamGroup, new Version(0, 6, 0, 9)),
					new SaveableBinElement(birthDeathDataStreamGroup, new Version(0, 6, 0, 9))
				}
			};
		}

		private void Start()
		{
			tracker = BibiteTracker.instance;
			infoPanel = InformationPanel.Instance;
			SetLogActions();
		}

		private void SetLogActions()
		{
			biomassDataStreamGroup.logAction = tracker.GetBiomassData;
			countDataStreamGroup.logAction = tracker.GetCountData;
			brainSizeDataStreamGroup.logAction = tracker.GetBrainSizeData;
			ageDataStreamGroup.logAction = tracker.GetAgeData;
			deathAgeDataStreamGroup.logAction = tracker.GetAgeOfDeathData;
			eggsLaidDataStreamGroup.logAction = tracker.GetEggLaidData;
			birthDeathDataStreamGroup.logAction = tracker.GetBirthDeathCount;
			genesStreamGroup.logAction = tracker.GetCurrentGenesBuckets;
		}

		private void FixedUpdate()
		{
			progress += Time.fixedDeltaTime;
			if (!(progress < periodSeconds))
			{
				progress -= periodSeconds;
				parallelDataStreams.ForEach(delegate(IDataPointStream s)
				{
					s.Log();
				});
				nMinutes++;
				if ((float)nMinutes % speciesLogPeriod == 0f)
				{
					GlobalLineageManager.Instance.LogSpeciesInfo();
					ZoneManager.instance.LogAllZonesData();
				}
				if (nMinutes >= nMinutesInHour)
				{
					nMinutes -= nMinutesInHour;
					genesStreamGroup.Log();
				}
			}
		}

		public int BytesSpace()
		{
			return 8 + saveableStack.BytesSpace();
		}

		public byte[] SaveStateBin(byte[] bytes = null, int offset = 0)
		{
			if (bytes == null)
			{
				bytes = new byte[BytesSpace()];
				offset = 0;
			}
			Buffer.BlockCopy(BitConverter.GetBytes(progress), 0, bytes, offset, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(nMinutes), 0, bytes, offset + 4, 4);
			saveableStack.SaveStateBin(bytes, offset + 8);
			return bytes;
		}

		public void LoadStateBin(byte[] bytes, Version version, int offset = 0, int nBytes = -1)
		{
			if (nBytes < 1)
			{
				nBytes = bytes.Length;
			}
			int num = offset + nBytes;
			if (nBytes != 0)
			{
				progress = BitConverter.ToSingle(bytes, offset);
				nMinutes = BitConverter.ToInt32(bytes, offset + 4);
				offset += 8;
				saveableStack.LoadStateBin(bytes, version, offset, num - offset);
			}
		}
	}
}
