using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.UserManagement.Integration
{
	public abstract class AJSONDataUpgrader : ScriptableObject
	{
		public abstract int InputVersion { get; }

		public abstract JObject Upgrade(UserManager manager, string path, IStorageProvider storage, JObject json);
	}
}
