using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Amazon.Util
{
	public class NetworkInterfaceMetadata
	{
		private string _path;

		private string _mac;

		private IEnumerable<string> _availableKeys;

		private Dictionary<string, string> _data = new Dictionary<string, string>();

		public string MacAddress => _mac;

		public string OwnerId => GetData("owner-id");

		public string Profile => GetData("profile");

		public string LocalHostname => GetData("local-hostname");

		public IEnumerable<string> LocalIPv4s => GetItems("local-ipv4s");

		public string PublicHostname => GetData("public-hostname");

		public IEnumerable<string> PublicIPv4s => GetItems("public-ipv4s");

		public IEnumerable<string> SecurityGroups => GetItems("security-groups");

		public IEnumerable<string> SecurityGroupIds => GetItems("security-group-ids");

		public string SubnetId => GetData("subnet-id");

		public string SubnetIPv4CidrBlock => GetData("subnet-ipv4-cidr-block");

		public string VpcId => GetData("vpc-id");

		private NetworkInterfaceMetadata()
		{
		}

		public NetworkInterfaceMetadata(string macAddress)
		{
			_mac = macAddress;
			_path = string.Format(CultureInfo.InvariantCulture, "/network/interfaces/macs/{0}/", _mac);
		}

		public IEnumerable<string> GetIpV4Association(string publicIp)
		{
			return EC2InstanceMetadata.GetItems(string.Format(CultureInfo.InvariantCulture, "{0}ipv4-associations/{1}", _path, publicIp));
		}

		private string GetData(string key)
		{
			if (_data.ContainsKey(key))
			{
				return _data[key];
			}
			if (_availableKeys == null)
			{
				_availableKeys = EC2InstanceMetadata.GetItems(_path);
			}
			if (_availableKeys.Contains(key))
			{
				_data[key] = EC2InstanceMetadata.GetData(_path + key);
				return _data[key];
			}
			return null;
		}

		private IEnumerable<string> GetItems(string key)
		{
			if (_availableKeys == null)
			{
				_availableKeys = EC2InstanceMetadata.GetItems(_path);
			}
			if (_availableKeys.Contains(key))
			{
				return EC2InstanceMetadata.GetItems(_path + key);
			}
			return new List<string>();
		}
	}
}
