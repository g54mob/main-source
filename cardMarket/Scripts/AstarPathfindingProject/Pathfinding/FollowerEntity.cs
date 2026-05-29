using Pathfinding.Serialization;
using UnityEngine;

namespace Pathfinding
{
	public sealed class FollowerEntity : VersionedMonoBehaviour
	{
		public void Start()
		{
			Debug.LogError("The FollowerEntity component requires at least version 1.0 of the 'Entities' package to be installed. You can install it using the Unity package manager.");
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
			migrations.IgnoreMigrationAttempt();
		}
	}
}
