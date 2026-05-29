using System;
using System.Collections.Generic;
using Battle;
using UnityEngine;

namespace UI
{
	[Serializable]
	public class PlayUnlockData
	{
		public eLuggage id;

		public eUnit unitId;

		public eMiracle miracleId;

		public bool isUnlock;

		public int baseExp;

		public int skillLevel;

		public bool[] unlockSkillLevel;

		public double speedUpRate;

		public double outputInterval;

		private double _minOutputInterval;

		public int stockLuggage;

		private bool _isLockOutput;

		private int _outputCount;

		private List<eLuggage> _sources;

		public BuffSet<eAbilityEffectId> buffSet;

		private MstUnitDataEntities _mstUnitData;

		private MstMiracleDataEntities _mstMiracleData;

		private bool? _isColor;

		private List<eMachine> _needMachines;

		private List<eLuggage> _needSources;

		private int[] _triggerCounts;

		private Dictionary<eLuggage, List<BuffStatusRecord>>[] _buffStatusMapArray;

		public int GetExp => 0;

		public string DisplaySkillLevel => null;

		public double SpeedUpRate => 0.0;

		public (int BlendCount1, int BlendCount2, int BlendCount3, int CraftCount) ProductBuff => default((int, int, int, int));

		public double MinOutputInterval => 0.0;

		public double GetOutputInterval => 0.0;

		public bool IsLockOutput
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public List<eLuggage> Sources => null;

		public MstUnitDataEntities MstUnitData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsUnit => false;

		public MstMiracleDataEntities MstMiracleData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsMiracle => false;

		public bool IsBattleLuggage => false;

		public bool IsColor => false;

		public bool Createable => false;

		public List<eMachine> NeedMachines
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public List<eLuggage> NeedResources
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public bool FullOpenUnlockLevel => false;

		public int[] TriggerCounts => null;

		public Dictionary<eLuggage, List<BuffStatusRecord>>[] BuffStatusMapArray => null;

		public void AddStockLuggage(int add)
		{
		}

		public void AddOutputCount(int add)
		{
		}

		public void ResetOutputCount()
		{
		}

		public bool IsSallyLimit()
		{
			return false;
		}

		public bool IgnoreReward()
		{
			return false;
		}

		public int GetTriggerCount(int index)
		{
			return 0;
		}

		public eUnitRank GetRank()
		{
			return default(eUnitRank);
		}

		public bool ExistStatue()
		{
			return false;
		}

		public int GetSallyLimitCount()
		{
			return 0;
		}

		public static void ConvertUniqueLuggage(ref eLuggage luggage)
		{
		}

		public PlayUnlockData(MstLuggageDataEntities entities)
		{
		}

		public Color GetSkillColor()
		{
			return default(Color);
		}

		public void CheckSkill()
		{
		}

		public void UpdateSkillBuff(int level)
		{
		}

		public int NextUnlockLevel()
		{
			return 0;
		}

		public void UpUnlockSkillLevel(bool isRecord = true)
		{
		}

		public void UnlockUnit()
		{
		}

		private void UnlockAllSource()
		{
		}

		public string GetStatueText()
		{
			return null;
		}

		public eMachine GetStatueId()
		{
			return default(eMachine);
		}

		public Dictionary<eLuggage, List<BuffStatusRecord>> GetBuffBonusByAbility(MstLuggageAbilityDataEntities entity)
		{
			return null;
		}

		public void SetNeedSource()
		{
		}

		public static List<eMachine> GetNeedMachines(eLuggage luggage)
		{
			return null;
		}

		public List<eMachine> NotExsistMachine()
		{
			return null;
		}

		public List<eLuggage> NotExsistResource()
		{
			return null;
		}

		public List<eLuggage> NotExsistUnit()
		{
			return null;
		}

		private static bool CheckExistCutterSource(List<eLuggage> luggages)
		{
			return false;
		}

		private static bool CheckLargeCanvasSource(List<eLuggage> luggages)
		{
			return false;
		}

		private static bool CheckChuchuhouseSource(List<eLuggage> luggages)
		{
			return false;
		}

		private static bool CheckMixser(List<eLuggage> luggages)
		{
			return false;
		}

		private bool CheckExistInkBottleSource(List<eLuggage> luggages)
		{
			return false;
		}

		private bool IsOriginResource(MstLuggageDataEntities data)
		{
			return false;
		}

		public void ResetWait()
		{
		}

		public bool HasAttackType(eUnitAttackType value)
		{
			return false;
		}

		public bool HasActionType(eUnitActionType value)
		{
			return false;
		}

		public bool HasSource(eLuggage value)
		{
			return false;
		}
	}
}
