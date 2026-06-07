using Dhs5.Utility.Settings;
using FMODUnity;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("Audio/World", Scope.Project)]
	public class WorldAudioSettings : CustomSettings<WorldAudioSettings>
	{
		[Header("Music")]
		[SerializeField]
		private EventReference m_music;

		[Header("Box")]
		[SerializeField]
		private EventReference m_boxGrab;

		[SerializeField]
		private EventReference m_boxOpen;

		[SerializeField]
		private EventReference m_boxDrop;

		[Header("Market Store")]
		[SerializeField]
		private EventReference m_marketStoreOpen;

		[SerializeField]
		private EventReference m_marketStorePurchase;

		[Header("Door")]
		[SerializeField]
		private EventReference m_doorOpen;

		[SerializeField]
		private EventReference m_doorClose;

		[Header("Player")]
		[Header("Footsteps")]
		[SerializeField]
		private EnumValues<EGroundType, EventReference> m_playerFootsteps;

		[Header("CashRegister")]
		[SerializeField]
		private EventReference m_cashRegisterOpen;

		[SerializeField]
		private EventReference m_cashRegisterArticle;

		[SerializeField]
		private EventReference m_cashRegisterBills;

		[SerializeField]
		private EventReference m_cashRegisterCoins;

		[Tooltip("m_cashRegisterCashValidate")]
		[SerializeField]
		private EventReference m_cashRegisterCashValidate;

		[Tooltip("m_cashRegisterCardMachineButtonClick")]
		[SerializeField]
		private EventReference m_cashRegisterCardMachineButtonClick;

		[Tooltip("m_cashRegisterCardMachineValidate")]
		[SerializeField]
		private EventReference m_cashRegisterCardMachineValidate;

		[Header("Sign")]
		[SerializeField]
		private EventReference m_signOpen;

		[SerializeField]
		private EventReference m_signClose;

		[Header("Furniture")]
		[SerializeField]
		private EventReference m_furniturePlace;

		[Header("Shelf")]
		[SerializeField]
		private EventReference m_shelfItemAdd;

		[Header("ReserveDesk")]
		[SerializeField]
		private EventReference m_reserveDeskOpen;

		[Header("Bin")]
		[SerializeField]
		private EventReference m_bin;

		[Header("Figurine")]
		[SerializeField]
		private EventReference m_figurineBoxStartOpen;

		[SerializeField]
		private EventReference m_figurineBoxShake;

		[SerializeField]
		private EventReference m_figurineBoxOpened;

		[SerializeField]
		private EventReference m_figurinePieceBasic;

		[SerializeField]
		private EventReference m_figurinePieceLarge;

		[SerializeField]
		private EventReference m_figurinePieceHero;

		[SerializeField]
		private EventReference m_figurineAssemble;

		[SerializeField]
		private EventReference m_figurineAssembleCompleted;

		[SerializeField]
		private EventReference m_figurinePaintFail;

		[SerializeField]
		private EventReference m_figurinePaintOk;

		[SerializeField]
		private EventReference m_figurinePaintGreat;

		[SerializeField]
		private EventReference m_figurinePaintPerfect;

		public static EventReference Music => CustomSettings<WorldAudioSettings>.I.m_music;

		public static EventReference BoxGrab => CustomSettings<WorldAudioSettings>.I.m_boxGrab;

		public static EventReference BoxOpen => CustomSettings<WorldAudioSettings>.I.m_boxOpen;

		public static EventReference BoxDrop => CustomSettings<WorldAudioSettings>.I.m_boxDrop;

		public static EventReference MarketStoreOpen => CustomSettings<WorldAudioSettings>.I.m_marketStoreOpen;

		public static EventReference MarketStorePurchase => CustomSettings<WorldAudioSettings>.I.m_marketStorePurchase;

		public static EventReference DoorOpen => CustomSettings<WorldAudioSettings>.I.m_doorOpen;

		public static EventReference DoorClose => CustomSettings<WorldAudioSettings>.I.m_doorClose;

		public static EventReference CashRegisterOpen => CustomSettings<WorldAudioSettings>.I.m_cashRegisterOpen;

		public static EventReference CashRegisterArticle => CustomSettings<WorldAudioSettings>.I.m_cashRegisterArticle;

		public static EventReference CashRegisterBills => CustomSettings<WorldAudioSettings>.I.m_cashRegisterBills;

		public static EventReference CashRegisterCoins => CustomSettings<WorldAudioSettings>.I.m_cashRegisterCoins;

		public static EventReference CashRegisterCashValidate => CustomSettings<WorldAudioSettings>.I.m_cashRegisterCashValidate;

		public static EventReference CashRegisterCardMachineButtonClick => CustomSettings<WorldAudioSettings>.I.m_cashRegisterCardMachineButtonClick;

		public static EventReference CashRegisterCardMachineValidate => CustomSettings<WorldAudioSettings>.I.m_cashRegisterCardMachineValidate;

		public static EventReference SignOpen => CustomSettings<WorldAudioSettings>.I.m_signOpen;

		public static EventReference SignClose => CustomSettings<WorldAudioSettings>.I.m_signClose;

		public static EventReference FurniturePlace => CustomSettings<WorldAudioSettings>.I.m_furniturePlace;

		public static EventReference ShelfItemAdd => CustomSettings<WorldAudioSettings>.I.m_shelfItemAdd;

		public static EventReference ReserveDeskOpen => CustomSettings<WorldAudioSettings>.I.m_reserveDeskOpen;

		public static EventReference Bin => CustomSettings<WorldAudioSettings>.I.m_bin;

		public static EventReference FigurineBoxStartOpen => CustomSettings<WorldAudioSettings>.I.m_figurineBoxStartOpen;

		public static EventReference FigurineBoxShake => CustomSettings<WorldAudioSettings>.I.m_figurineBoxShake;

		public static EventReference FigurineBoxOpened => CustomSettings<WorldAudioSettings>.I.m_figurineBoxOpened;

		public static EventReference FigurinePieceBasic => CustomSettings<WorldAudioSettings>.I.m_figurinePieceBasic;

		public static EventReference FigurinePieceLarge => CustomSettings<WorldAudioSettings>.I.m_figurinePieceLarge;

		public static EventReference FigurinePieceHero => CustomSettings<WorldAudioSettings>.I.m_figurinePieceHero;

		public static EventReference FigurineAssemble => CustomSettings<WorldAudioSettings>.I.m_figurineAssemble;

		public static EventReference FigurineAssembleCompleted => CustomSettings<WorldAudioSettings>.I.m_figurineAssembleCompleted;

		public static EventReference FigurinePaintFail => CustomSettings<WorldAudioSettings>.I.m_figurinePaintFail;

		public static EventReference FigurinePaintOk => CustomSettings<WorldAudioSettings>.I.m_figurinePaintOk;

		public static EventReference FigurinePaintGreat => CustomSettings<WorldAudioSettings>.I.m_figurinePaintGreat;

		public static EventReference FigurinePaintPrefect => CustomSettings<WorldAudioSettings>.I.m_figurinePaintPerfect;

		public static EventReference PlayerFootsteps(EGroundType groundType)
		{
			return CustomSettings<WorldAudioSettings>.I.m_playerFootsteps[groundType];
		}
	}
}
