using System;
using Pathfinding.Drawing;
using Pathfinding.Serialization;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	public abstract class VersionedMonoBehaviour : MonoBehaviourGizmos, ISerializationCallbackReceiver, IVersionedMonoBehaviourInternal, IEntityIndex
	{
		[SerializeField]
		[HideInInspector]
		private int version;

		int IEntityIndex.EntityIndex { get; set; }

		protected virtual void Awake()
		{
			if (Application.isPlaying)
			{
				if (version == 0)
				{
					Migrations migrations = new Migrations(int.MaxValue);
					OnUpgradeSerializedData(ref migrations, unityThread: true);
					version = migrations.allMigrations;
				}
				else
				{
					((IVersionedMonoBehaviourInternal)this).UpgradeFromUnityThread();
				}
			}
		}

		protected virtual void Reset()
		{
			Migrations migrations = new Migrations(int.MaxValue);
			OnUpgradeSerializedData(ref migrations, unityThread: true);
			version = migrations.allMigrations;
			DisableGizmosIcon();
		}

		private void DisableGizmosIcon()
		{
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			UpgradeSerializedData(isUnityThread: false);
		}

		protected void UpgradeSerializedData(bool isUnityThread)
		{
			Migrations migrations = new Migrations(version);
			OnUpgradeSerializedData(ref migrations, isUnityThread);
			if (!migrations.ignore)
			{
				if (migrations.IsLegacyFormat)
				{
					throw new Exception("Failed to migrate from the legacy format");
				}
				if ((migrations.finishedMigrations & ~migrations.allMigrations) != 0)
				{
					throw new Exception("Run more migrations than there are migrations to run. Finished: " + migrations.finishedMigrations.ToString("X") + " all: " + migrations.allMigrations.ToString("X"));
				}
				if (isUnityThread && (migrations.allMigrations & ~migrations.finishedMigrations) != 0)
				{
					throw new Exception("Some migrations were registered, but they did not run. Finished: " + migrations.finishedMigrations.ToString("X") + " all: " + migrations.allMigrations.ToString("X"));
				}
				version = migrations.finishedMigrations;
			}
		}

		protected virtual void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
			if (migrations.TryMigrateFromLegacyFormat(out var legacyVersion) && legacyVersion > 1)
			{
				throw new Exception("Reached base class without having migrated the legacy format, and the legacy version is not version 1.");
			}
		}

		void IVersionedMonoBehaviourInternal.UpgradeFromUnityThread()
		{
			UpgradeSerializedData(isUnityThread: true);
		}
	}
}
