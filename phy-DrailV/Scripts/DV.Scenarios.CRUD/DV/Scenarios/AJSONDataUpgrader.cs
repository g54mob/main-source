using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;

namespace DV.Scenarios
{
	public abstract class AJSONDataUpgrader
	{
		public abstract int InputVersion { get; }

		public abstract void Upgrade(JObject obj, string fileName, IStorageProvider storage, int targetVersion);
	}
}
