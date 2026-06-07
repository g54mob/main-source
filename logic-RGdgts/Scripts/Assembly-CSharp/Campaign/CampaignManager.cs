using System.Collections.Generic;
using NodeCanvas.StateMachines;
using UnityEngine;

namespace Campaign
{
	public class CampaignManager : GameplayManager, ILogOrigin
	{
		private static CampaignManager _instance;

		public FSMOwner campaignFsm;

		public GameObject dayObject;

		private CampaignDayFSMOwner dayFsm;

		private HashSet<GameplayInteraction> lockedInteractions;

		private HashSet<GameplayInteraction> availableInteractions;

		public Dictionary<GameplayVariable, Data> variables;

		private Dictionary<ModuleGestaltVariationEnum, int> modulesCount;

		private HashSet<ModuleGestaltVariationEnum> availableModules;

		private Dictionary<ModuleGestaltVariationEnum, HashSet<ICampaignModulesCountListener>> moduleListeners;

		private Dictionary<MotherboardSectionEnum, int> motherboardsCount;

		private HashSet<MotherboardSectionEnum> availableMotherboards;

		private Dictionary<MotherboardSectionEnum, HashSet<ICampaignMotherboardsCountListener>> motherboardListeners;

		public static CampaignManager Instance => null;

		public override void Init()
		{
		}

		public override bool SkipIntro()
		{
			return false;
		}

		public void OnNewDay(CampaignDay day)
		{
		}

		public void RefreshModuleDrawer(ModuleGestaltVariationEnum moduleGestaltVariationId)
		{
		}

		public void SetModuleCount(ModuleGestaltVariationEnum moduleGestaltVariationId, int count)
		{
		}

		public int GetModuleCount(ModuleGestaltVariationEnum moduleGestaltVariationId)
		{
			return 0;
		}

		public void RegisterModulesCountListener(ModuleGestaltVariationEnum moduleGestaltVariationId, ICampaignModulesCountListener listener)
		{
		}

		public void UnregisterModulesCountListener(ModuleGestaltVariationEnum moduleGestaltVariationId, ICampaignModulesCountListener listener)
		{
		}

		public void RefreshMotherboardDrawer()
		{
		}

		public void SetMotherboardCount(MotherboardSectionEnum motherboardSectionId, int count)
		{
		}

		public int GetMotherboardCount(MotherboardSectionEnum motherboardSectionId)
		{
			return 0;
		}

		public void RegisterMotherboardCountListener(MotherboardSectionEnum motherboardSectionId, ICampaignMotherboardsCountListener listener)
		{
		}

		public void UnregisterMotherboardsCountListener(MotherboardSectionEnum motherboardSectionId, ICampaignMotherboardsCountListener listener)
		{
		}

		public override void OnDayEndInteraction()
		{
		}

		private void ResetLockedInteractions()
		{
		}

		public void OnDayEnd()
		{
		}

		public void SetInteractionLock(GameplayInteraction interaction, bool isLocked)
		{
		}

		public void SetInteractionAvailable(GameplayInteraction interaction, bool isAvailable)
		{
		}

		public override bool IsLocked(GameplayInteraction interaction)
		{
			return false;
		}

		public override bool IsAvailable(GameplayInteraction interaction)
		{
			return false;
		}

		public override bool IsModuleAvailable(ModuleGestaltVariationEnum variation)
		{
			return false;
		}

		public override bool IsModuleVisibleInDrawer(ModuleGestaltVariationEnum variation)
		{
			return false;
		}

		public void AddModuleCount(ModuleGestaltVariationEnum moduleGestaltVariationId, int count)
		{
		}

		public void RemoveModuleCount(ModuleGestaltVariationEnum moduleGestaltVariationId, int count)
		{
		}

		public void SetModuleAvailable(ModuleGestaltVariationEnum moduleGestaltVariationId, bool isAvailable)
		{
		}

		public void AddMotherboardCount(MotherboardSectionEnum motherboardSectionId, int count)
		{
		}

		public void RemoveMotherboardCount(MotherboardSectionEnum motherboardSectionId, int count)
		{
		}

		public void SetMotherboardAvailable(MotherboardSectionEnum motherboardSectionId, bool isAvailable)
		{
		}

		public override bool IsMotherboardAvailable(MotherboardSectionEnum variation)
		{
			return false;
		}

		public override bool IsMotherboardVisibleInDrawer(MotherboardSectionEnum variation)
		{
			return false;
		}
	}
}
