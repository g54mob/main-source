using System.Collections.Generic;
using ScheduleOne.Economy;
using ScheduleOne.ItemFramework;
using ScheduleOne.Quests;
using ScheduleOne.UI.Handover;
using UnityEngine;

namespace ScheduleOne.NPCs
{
	public class Billy : NPC
	{
		public const int REQUESTED_PRODUCT_AMOUNT = 20;

		public const string REQUESTED_PRODUCT_ID = "cocaine";

		[Header("References")]
		public Contract TradeContract;

		public ItemDefinition RDXDefinition;

		private Customer customerComp;

		private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBillyAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBillyAssembly_002DCSharp_002Edll_Excuted;

		public override void Awake()
		{
		}

		public void OpenRDXTradeHandover()
		{
		}

		private void HandoverOutcome(HandoverScreen.EHandoverOutcome outcome, List<ItemInstance> givenItems, float payment)
		{
		}

		private float GetSucccessChance(List<ItemInstance> items, float price)
		{
			return 0f;
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

		protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002EBilly_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
