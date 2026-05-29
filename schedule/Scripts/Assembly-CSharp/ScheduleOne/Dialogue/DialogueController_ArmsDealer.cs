using System;
using System.Collections.Generic;
using ScheduleOne.ItemFramework;
using ScheduleOne.Quests;

namespace ScheduleOne.Dialogue
{
	public class DialogueController_ArmsDealer : DialogueController
	{
		[Serializable]
		public class WeaponOption
		{
			public bool IsAvailable;

			public string NotAvailableReason;

			public StorableItemDefinition Item;

			public string Name => null;

			public float Price => 0f;
		}

		public List<WeaponOption> MeleeWeapons;

		public List<WeaponOption> RangedWeapons;

		public List<WeaponOption> Ammo;

		public ItemDefinition RDX;

		public ItemDefinition Bomb;

		private List<WeaponOption> allWeapons;

		private WeaponOption chosenWeapon;

		private Quest_DefeatCartel questDefeatCartel;

		private void Awake()
		{
		}

		protected override void Start()
		{
		}

		public override void ChoiceCallback(string choiceLabel)
		{
		}

		public override void ModifyChoiceList(string dialogueLabel, ref List<DialogueChoiceData> existingChoices)
		{
		}

		private List<DialogueChoiceData> GetWeaponChoices(List<WeaponOption> options)
		{
			return null;
		}

		public override bool CheckChoice(string choiceLabel, out string invalidReason)
		{
			invalidReason = null;
			return false;
		}

		public override string ModifyDialogueText(string dialogueLabel, string dialogueText)
		{
			return null;
		}

		private void TradeRDXForBomb()
		{
		}
	}
}
