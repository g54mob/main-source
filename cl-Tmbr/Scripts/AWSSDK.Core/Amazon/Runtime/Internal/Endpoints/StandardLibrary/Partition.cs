using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Amazon.Runtime.Endpoints;
using Amazon.Util.Internal;

namespace Amazon.Runtime.Internal.Endpoints.StandardLibrary
{
	public class Partition : PropertyBag
	{
		private static readonly ReaderWriterLockSlim _locker;

		private static Dictionary<string, PartitionAttributesShape> _partitionsByRegionName;

		private static Dictionary<string, PartitionAttributesShape> _partitionsByRegex;

		private static PartitionAttributesShape _defaultPartition;

		public string name
		{
			get
			{
				return (string)base["name"];
			}
			set
			{
				base["name"] = value;
			}
		}

		public string dnsSuffix
		{
			get
			{
				return (string)base["dnsSuffix"];
			}
			set
			{
				base["dnsSuffix"] = value;
			}
		}

		public string dualStackDnsSuffix
		{
			get
			{
				return (string)base["dualStackDnsSuffix"];
			}
			set
			{
				base["dualStackDnsSuffix"] = value;
			}
		}

		public bool supportsFIPS
		{
			get
			{
				return (bool)base["supportsFIPS"];
			}
			set
			{
				base["supportsFIPS"] = value;
			}
		}

		public bool supportsDualStack
		{
			get
			{
				return (bool)base["supportsDualStack"];
			}
			set
			{
				base["supportsDualStack"] = value;
			}
		}

		public string implicitGlobalRegion
		{
			get
			{
				return (string)base["implicitGlobalRegion"];
			}
			set
			{
				base["implicitGlobalRegion"] = value;
			}
		}

		internal static Partition FromPartitionData(PartitionAttributesShape data)
		{
			return new Partition
			{
				name = data.name,
				dnsSuffix = data.dnsSuffix,
				dualStackDnsSuffix = data.dualStackDnsSuffix,
				supportsFIPS = data.supportsFIPS,
				supportsDualStack = data.supportsDualStack,
				implicitGlobalRegion = data.implicitGlobalRegion
			};
		}

		public static void LoadPartitions(string partitionsFile)
		{
			if (!File.Exists(partitionsFile))
			{
				throw new AmazonClientException("Can't find partitions file: " + partitionsFile);
			}
			_locker.EnterWriteLock();
			try
			{
				PartitionFunctionShape partitionFunctionShape = JsonSerializerHelper.Deserialize<PartitionFunctionShape>(File.ReadAllText(partitionsFile), JsonSerializerContext.Default);
				_partitionsByRegionName.Clear();
				_partitionsByRegex.Clear();
				_defaultPartition = null;
				foreach (PartitionShape partition in partitionFunctionShape.partitions)
				{
					if (partition.id == "aws")
					{
						_defaultPartition = partition.outputs;
					}
					_partitionsByRegex.Add(partition.regionRegex, partition.outputs);
					foreach (string key in partition.regions.Keys)
					{
						_partitionsByRegionName.Add(key, partition.outputs);
					}
				}
			}
			finally
			{
				_locker.ExitWriteLock();
			}
		}

		internal static Partition GetPartitionByRegion(string region)
		{
			_locker.EnterReadLock();
			try
			{
				if (_partitionsByRegionName.TryGetValue(region, out var value))
				{
					return FromPartitionData(value);
				}
				foreach (string key in _partitionsByRegex.Keys)
				{
					if (Regex.IsMatch(region, key))
					{
						return FromPartitionData(_partitionsByRegex[key]);
					}
				}
				return FromPartitionData(_defaultPartition);
			}
			finally
			{
				_locker.ExitReadLock();
			}
		}

		static Partition()
		{
			_locker = new ReaderWriterLockSlim();
			_partitionsByRegionName = new Dictionary<string, PartitionAttributesShape>();
			_partitionsByRegex = new Dictionary<string, PartitionAttributesShape>();
			PartitionAttributesShape partitionAttributesShape = new PartitionAttributesShape
			{
				name = "aws",
				dnsSuffix = "amazonaws.com",
				dualStackDnsSuffix = "api.aws",
				supportsFIPS = true,
				supportsDualStack = true,
				implicitGlobalRegion = "us-east-1"
			};
			_partitionsByRegex.Add("^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", partitionAttributesShape);
			_partitionsByRegionName.Add("af-south-1", partitionAttributesShape);
			_partitionsByRegionName.Add("ap-east-1", partitionAttributesShape);
			_partitionsByRegionName.Add("ap-northeast-1", partitionAttributesShape);
			_partitionsByRegionName.Add("ap-northeast-2", partitionAttributesShape);
			_partitionsByRegionName.Add("ap-northeast-3", partitionAttributesShape);
			_partitionsByRegionName.Add("ap-south-1", partitionAttributesShape);
			_partitionsByRegionName.Add("ap-south-2", partitionAttributesShape);
			_partitionsByRegionName.Add("ap-southeast-1", partitionAttributesShape);
			_partitionsByRegionName.Add("ap-southeast-2", partitionAttributesShape);
			_partitionsByRegionName.Add("ap-southeast-3", partitionAttributesShape);
			_partitionsByRegionName.Add("ap-southeast-4", partitionAttributesShape);
			_partitionsByRegionName.Add("ap-southeast-5", partitionAttributesShape);
			_partitionsByRegionName.Add("ap-southeast-7", partitionAttributesShape);
			_partitionsByRegionName.Add("aws-global", partitionAttributesShape);
			_partitionsByRegionName.Add("ca-central-1", partitionAttributesShape);
			_partitionsByRegionName.Add("ca-west-1", partitionAttributesShape);
			_partitionsByRegionName.Add("eu-central-1", partitionAttributesShape);
			_partitionsByRegionName.Add("eu-central-2", partitionAttributesShape);
			_partitionsByRegionName.Add("eu-north-1", partitionAttributesShape);
			_partitionsByRegionName.Add("eu-south-1", partitionAttributesShape);
			_partitionsByRegionName.Add("eu-south-2", partitionAttributesShape);
			_partitionsByRegionName.Add("eu-west-1", partitionAttributesShape);
			_partitionsByRegionName.Add("eu-west-2", partitionAttributesShape);
			_partitionsByRegionName.Add("eu-west-3", partitionAttributesShape);
			_partitionsByRegionName.Add("il-central-1", partitionAttributesShape);
			_partitionsByRegionName.Add("me-central-1", partitionAttributesShape);
			_partitionsByRegionName.Add("me-south-1", partitionAttributesShape);
			_partitionsByRegionName.Add("mx-central-1", partitionAttributesShape);
			_partitionsByRegionName.Add("sa-east-1", partitionAttributesShape);
			_partitionsByRegionName.Add("us-east-1", partitionAttributesShape);
			_partitionsByRegionName.Add("us-east-2", partitionAttributesShape);
			_partitionsByRegionName.Add("us-west-1", partitionAttributesShape);
			_partitionsByRegionName.Add("us-west-2", partitionAttributesShape);
			PartitionAttributesShape value = new PartitionAttributesShape
			{
				name = "aws-cn",
				dnsSuffix = "amazonaws.com.cn",
				dualStackDnsSuffix = "api.amazonwebservices.com.cn",
				supportsFIPS = true,
				supportsDualStack = true,
				implicitGlobalRegion = "cn-northwest-1"
			};
			_partitionsByRegex.Add("^cn\\-\\w+\\-\\d+$", value);
			_partitionsByRegionName.Add("aws-cn-global", value);
			_partitionsByRegionName.Add("cn-north-1", value);
			_partitionsByRegionName.Add("cn-northwest-1", value);
			PartitionAttributesShape value2 = new PartitionAttributesShape
			{
				name = "aws-us-gov",
				dnsSuffix = "amazonaws.com",
				dualStackDnsSuffix = "api.aws",
				supportsFIPS = true,
				supportsDualStack = true,
				implicitGlobalRegion = "us-gov-west-1"
			};
			_partitionsByRegex.Add("^us\\-gov\\-\\w+\\-\\d+$", value2);
			_partitionsByRegionName.Add("aws-us-gov-global", value2);
			_partitionsByRegionName.Add("us-gov-east-1", value2);
			_partitionsByRegionName.Add("us-gov-west-1", value2);
			PartitionAttributesShape value3 = new PartitionAttributesShape
			{
				name = "aws-iso",
				dnsSuffix = "c2s.ic.gov",
				dualStackDnsSuffix = "c2s.ic.gov",
				supportsFIPS = true,
				supportsDualStack = false,
				implicitGlobalRegion = "us-iso-east-1"
			};
			_partitionsByRegex.Add("^us\\-iso\\-\\w+\\-\\d+$", value3);
			_partitionsByRegionName.Add("aws-iso-global", value3);
			_partitionsByRegionName.Add("us-iso-east-1", value3);
			_partitionsByRegionName.Add("us-iso-west-1", value3);
			PartitionAttributesShape value4 = new PartitionAttributesShape
			{
				name = "aws-iso-b",
				dnsSuffix = "sc2s.sgov.gov",
				dualStackDnsSuffix = "sc2s.sgov.gov",
				supportsFIPS = true,
				supportsDualStack = false,
				implicitGlobalRegion = "us-isob-east-1"
			};
			_partitionsByRegex.Add("^us\\-isob\\-\\w+\\-\\d+$", value4);
			_partitionsByRegionName.Add("aws-iso-b-global", value4);
			_partitionsByRegionName.Add("us-isob-east-1", value4);
			PartitionAttributesShape value5 = new PartitionAttributesShape
			{
				name = "aws-iso-e",
				dnsSuffix = "cloud.adc-e.uk",
				dualStackDnsSuffix = "cloud.adc-e.uk",
				supportsFIPS = true,
				supportsDualStack = false,
				implicitGlobalRegion = "eu-isoe-west-1"
			};
			_partitionsByRegex.Add("^eu\\-isoe\\-\\w+\\-\\d+$", value5);
			_partitionsByRegionName.Add("aws-iso-e-global", value5);
			_partitionsByRegionName.Add("eu-isoe-west-1", value5);
			PartitionAttributesShape value6 = new PartitionAttributesShape
			{
				name = "aws-iso-f",
				dnsSuffix = "csp.hci.ic.gov",
				dualStackDnsSuffix = "csp.hci.ic.gov",
				supportsFIPS = true,
				supportsDualStack = false,
				implicitGlobalRegion = "us-isof-south-1"
			};
			_partitionsByRegex.Add("^us\\-isof\\-\\w+\\-\\d+$", value6);
			_partitionsByRegionName.Add("aws-iso-f-global", value6);
			_partitionsByRegionName.Add("us-isof-east-1", value6);
			_partitionsByRegionName.Add("us-isof-south-1", value6);
			PartitionAttributesShape value7 = new PartitionAttributesShape
			{
				name = "aws-eusc",
				dnsSuffix = "amazonaws.eu",
				dualStackDnsSuffix = "amazonaws.eu",
				supportsFIPS = true,
				supportsDualStack = false,
				implicitGlobalRegion = "eusc-de-east-1"
			};
			_partitionsByRegex.Add("^eusc\\-(de)\\-\\w+\\-\\d+$", value7);
			_partitionsByRegionName.Add("eusc-de-east-1", value7);
			_defaultPartition = partitionAttributesShape;
		}
	}
}
