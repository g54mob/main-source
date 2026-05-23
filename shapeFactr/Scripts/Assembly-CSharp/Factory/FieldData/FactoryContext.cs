using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Libs;
using UnityEngine;

namespace Factory.FieldData
{
	[Serializable]
	public class FactoryContext : ISerializationCallbackReceiver
	{
		[Serializable]
		public class AttachmentPrim
		{
			public eAttachment attachment;

			public string[] param;

			public AttachmentPrim(eAttachment attachment, string[] param)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		[Flags]
		public enum eFactoryAffectOption
		{
			None = 0,
			EnablePortPrioArrow = 1
		}

		public enum AltarOfSpiritType
		{
			None = 0,
			UnitOrParts = 1,
			Shigen = 2
		}

		public const string Version000 = "0.0.0";

		public const string Version010 = "0.1.0";

		public const string Version011 = "0.1.1";

		public const string Version020 = "0.2.0";

		public const string Version030 = "0.3.0";

		public const string Version031 = "0.3.1";

		public const string Version032 = "0.3.2";

		public static readonly Version SaveFcVersion;

		public string fcVersion;

		private Version _fcVersion;

		public double factoryReciprocalSpeed;

		public int factorySpeedGear;

		[SerializeField]
		private double factoryTimeSinceStartupAsDouble;

		public SRandom fcRandom;

		private static int _prohibitFactoryTargetFrame;

		private Dictionary<eAttachment, FactoryAttachment[]> attachmentDB;

		private Dictionary<eAttachment, double?> attachmentCacheD;

		private Dictionary<eAttachment, bool?> attachmentCacheB;

		[SerializeField]
		private List<AttachmentPrim> attachmentHistory;

		[SerializeField]
		private JDictionary<eMachine, StructureInventory> structurePaletteInventories;

		[SerializeField]
		private JDictionary<eMapExtension, MapAsset> mapAssets;

		private static int _getMinionCostWaveCount;

		private static int _getMinionCost;

		public eFactoryAffectOption factoryAffectOption;

		[SerializeField]
		public AltarOfSpiritType altarType;

		[SerializeField]
		public int spiritEnergyUnitOrParts;

		[SerializeField]
		public int spiritEnergyShigen;

		[SerializeField]
		public double boostByAltarOfSpiritFinishTime;

		public int mineshaftDemand;

		[IgnoreDataMember]
		public Version FcVersion
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public double FactoryTimeSinceStartupAsDouble => 0.0;

		public double FactoryDeltaTime { get; private set; }

		public static bool IsProhibitFactory { get; set; }

		public static bool IsProhibitFactoryTargetFrame => false;

		public static bool IsProhibitRemoveMachine { get; set; }

		public static bool IsProhibitRulerMode { get; set; }

		public bool IsBattlePhaseWait => false;

		private int _miniascapeLevel { get; set; }

		public JDictionary<eMapExtension, MapAsset> MapAssets => null;

		private int CostPool1 => 0;

		private int CostPool2 => 0;

		public static bool IsBattleWaitPhase => false;

		public bool EnableRemoveTimer => false;

		public bool EnablePortPrioArrow => false;

		public double BoostByAltarOfSpirit => 0.0;

		public string PrepareSaveFc(bool prettyPrint)
		{
			return null;
		}

		public bool RollPercentileDice(double score)
		{
			return false;
		}

		public static void SetProhibitFactoryTargetFrame(int waitForFrames)
		{
		}

		public void Init(eWriterId writerId, int seed)
		{
		}

		public void Restore(string fcJson)
		{
		}

		public List<MstMachineDataEntities> GetMachineDataListFromInventories()
		{
			return null;
		}

		public void AddInventory(StructureInventory inv, Vector2IntBundle? position = null)
		{
		}

		private void SafeAddInventory(eMachine machineID, StructureInventory inv, Vector2IntBundle? position = null)
		{
		}

		public void AddAttachment(eAttachment attachment, string[] param, bool restore = false)
		{
		}

		private bool GetBoolFromParam(string[] param)
		{
			return false;
		}

		public Dictionary<eAttachment, FactoryAttachment[]> GetAllAttachments()
		{
			return null;
		}

		public FactoryAttachment[] GetAttachments(eAttachment effectId)
		{
			return null;
		}

		public double GetFactoryAttachmentRate(eAttachment attachment, bool force = false)
		{
			return 0.0;
		}

		private double GetDoubleFromParam(string[] param)
		{
			return 0.0;
		}

		public double GetFactoryAttachmentRateAdd(eAttachment attachment)
		{
			return 0.0;
		}

		public bool IsFactoryAttachment(eAttachment attachment, bool force = false, bool array = false)
		{
			return false;
		}

		public int GetFactoryAttachmentCount(eAttachment attachment)
		{
			return 0;
		}

		public List<string[]> GetFactoryAttachmentArray(eAttachment attachment)
		{
			return null;
		}

		public int AnyFactoryAttachment(eAttachment[] extDatOutPortOpen)
		{
			return 0;
		}

		public bool CheckFactoryAttachmentCacheD(eAttachment attachment)
		{
			return false;
		}

		public void CountUpProduct(eLuggage product)
		{
		}

		public void CountUpProductWithLevel(eLuggage product, int level)
		{
		}

		public StructureInventory GetStructureInventory(eMachine machineID)
		{
			return null;
		}

		public double CountUpStructureInventory(eMachine machineID, double add = 1.0, Vector2IntBundle? bundle = null)
		{
			return 0.0;
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		private int GetLevelFromExp(int miniascapeExp)
		{
			return 0;
		}

		internal bool CheckLevelUp(int nowExp, int lastLevel, out MstExpDataEntities expData)
		{
			expData = null;
			return false;
		}

		public int GetMiniascapeLevel()
		{
			return 0;
		}

		public void UpdateFactoryTime(bool isPause)
		{
		}

		public void RestoreFactoryTime(double time)
		{
		}

		public bool IsFastUpdateStrict()
		{
			return false;
		}

		public void ChangeFactorySpeedGear(double speedGear)
		{
		}

		public void AddMapAsset(eMapExtension area, MapAsset mapAsset)
		{
		}

		public bool HasMapAsset(eMapExtension area)
		{
			return false;
		}

		public static bool IsValidBattleScene()
		{
			return false;
		}

		public static int GetMinionCost(int add = 0)
		{
			return 0;
		}

		public static int CountSweetsEffectedMinion()
		{
			return 0;
		}

		public static int CountAllMinion()
		{
			return 0;
		}

		public static int CountStatues()
		{
			return 0;
		}

		public bool CheckOptionChanged()
		{
			return false;
		}
	}
}
