using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Loaders;

namespace ScheduleOne.Storage
{
	public class StorageManager : NetworkSingleton<StorageManager>, IBaseSaveable, ISaveable
	{
		private StorageLoader loader;

		private bool NetworkInitialize___EarlyScheduleOne_002EStorage_002EStorageManagerAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002EStorage_002EStorageManagerAssembly_002DCSharp_002Edll_Excuted;

		public string SaveFolderName => null;

		public string SaveFileName => null;

		public Loader Loader => null;

		public bool ShouldSaveUnderFolder => false;

		public List<string> LocalExtraFiles { get; set; }

		public List<string> LocalExtraFolders { get; set; }

		public bool HasChanged { get; set; }

		public int LoadOrder { get; }

		public override void Awake()
		{
		}

		public virtual void InitializeSaveable()
		{
		}

		public virtual string GetSaveString()
		{
			return null;
		}

		public override void NetworkInitialize___Early()
		{
		}

		public override void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		protected virtual void Awake_UserLogic_ScheduleOne_002EStorage_002EStorageManager_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
