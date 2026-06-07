using System;
using Libs;
using UnityEngine;

namespace SaveData
{
	[Serializable]
	public class PlayArchiveData : ISerializationCallbackReceiver
	{
		[SerializeField]
		private JDictionary<string, LuggageArchive> _archiveLuggageDict;

		[SerializeField]
		private JDictionary<string, MachineArchive> _archiveMachineDict;

		[SerializeField]
		private JDictionary<string, RelicArchive> _archiveRelicDict;

		[SerializeField]
		private JDictionary<string, EnemyArchive> _archiveEnemyDict;

		[SerializeField]
		private JDictionary<string, MasterArchive> _archiveMasterDict;

		[SerializeField]
		private JDictionary<string, ResearchArchive> _archiveResearchDict;

		[SerializeField]
		private JDictionary<string, ResearchItemArchive> _archiveResearchItemDict;

		[SerializeField]
		private JDictionary<string, FeatureArchive> _archiveFeatureDict;

		[SerializeField]
		private JDictionary<string, ChallengeArchive> _archiveChallengeDict;

		public JDictionary<string, LuggageArchive> ArchiveLuggageDict
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JDictionary<string, MachineArchive> ArchiveMachineDict
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JDictionary<string, RelicArchive> ArchiveRelicDict
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JDictionary<string, EnemyArchive> ArchiveEnemyDict
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JDictionary<string, MasterArchive> ArchiveMasterDict
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JDictionary<string, ResearchArchive> ArchiveResearch
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JDictionary<string, ResearchItemArchive> ArchiveResearchItem
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JDictionary<string, FeatureArchive> ArchiveFeature
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JDictionary<string, ChallengeArchive> ArchiveChallenge
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void RegisterInitialCollection()
		{
		}

		public void RegisterPermanentUnlock(bool isUpdate = true)
		{
		}

		public JDictionary<string, T> GetArchiveDict<T>() where T : ArchiveData
		{
			return null;
		}

		public bool TryGetArchiveData(eArchiveCategory category, string key, out ArchiveData result)
		{
			result = null;
			return false;
		}

		public bool IsUnlockItem(eArchiveCategory category, string key)
		{
			return false;
		}

		public bool RegisterArchiveBase(eArchiveCategory category, string key, bool everGet, bool isRead, bool isPermanent)
		{
			return false;
		}

		public bool RegisterLuggageArchive(string key, LuggageArchive newArchive)
		{
			return false;
		}

		public bool RegisterMachineArchive(string key, MachineArchive newArchive)
		{
			return false;
		}

		public bool RegisterRelicArchive(string key, RelicArchive newArchive)
		{
			return false;
		}

		public bool RegisterEnemyArchive(string key, EnemyArchive newArchive)
		{
			return false;
		}

		public bool RegisterMasterArchive(string key, MasterArchive newArchive)
		{
			return false;
		}

		public bool RegisterResearchArchive(string key, ResearchArchive newArchive)
		{
			return false;
		}

		public bool RegisterResearchItemArchive(string key, ResearchItemArchive newArchive)
		{
			return false;
		}

		public bool RegisterFeatureArchive(string key, FeatureArchive newArchive)
		{
			return false;
		}

		public bool RegisterChallengeArchive(string key, ChallengeArchive newArchive)
		{
			return false;
		}

		public void UpdateArchiveBase(eArchiveCategory category, string key, bool? everGet = null, bool? isRead = null, bool? isPermanent = null)
		{
		}

		public void AllRead()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public void OnBeforeSerialize()
		{
		}
	}
}
