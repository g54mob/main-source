using System.Collections.Generic;
using DV.UserManagement.Data;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.UserManagement.Integration
{
	public abstract class ASaveSnapshotUpgrader : ScriptableObject
	{
		public abstract int InputVersion { get; }

		public abstract JObject Upgrade(UserManager manager, string fileName, List<(int Type, byte[] Data)> customChunks, IStorageProvider storage, GameSession session, JObject json);
	}
}
