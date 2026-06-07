using DV.Localization;

namespace DV.ServicePenalty.UI
{
	public static class CareerManagerLocalization
	{
		public const string CURRENCY_SIGN = "$";

		public static string INVALID_SELECTION => LocalizationAPI.L("carman/invalid_selection");

		public static string INSERT_WALLET_TO_PAY => LocalizationAPI.L("carman/insert_wallet");

		public static string PLEASE_SELECT => LocalizationAPI.L("carman/please_select");

		public static string FEES => LocalizationAPI.L("carman/fees");

		public static string FEES_TOTAL => LocalizationAPI.L("carman/fees_total");

		public static string LICENSES => LocalizationAPI.L("carman/licenses");

		public static string STATS => LocalizationAPI.L("carman/stats");

		public static string OWNED_VEHICLES => LocalizationAPI.L("carman/owned_vehicles");

		public static string INSURANCE_COPAY_MET => LocalizationAPI.L("carman/insurance_copay_met");

		public static string INSURANCE_CLEARED_ALL_FEES => LocalizationAPI.L("carman/insurance_cleared_all_fees");

		public static string PRESS_PRINT_FOR_DETAILS => LocalizationAPI.L("carman/press_print");

		public static string DO_YOU_HAVE_MANUAL_SERVICE => LocalizationAPI.L("carman/do_you_have_manual_service");

		public static string YOU_COULD_SAVE_MONEY => LocalizationAPI.L("carman/you_could_save_money");

		public static string NO_FEES_CAN_BUY_LICENSES => LocalizationAPI.L("carman/no_fees_can_buy_licenses");

		public static string DEPOSITED => LocalizationAPI.L("carman/deposited_colon");

		public static string LICENSE_COLON => LocalizationAPI.L("carman/license_colon");

		public static string OWNED => LocalizationAPI.L("carman/owned");

		public static string MONEY_CURRENT => LocalizationAPI.L("carman/money_current");

		public static string ACTIVE_JOBS => LocalizationAPI.L("carman/active_jobs");

		public static string COPAY_REMAINING => LocalizationAPI.L("carman/copay_remaining");

		public static string COPAY_TOTAL => LocalizationAPI.L("carman/copay_total");

		public static string FEE_TOLERANCE => LocalizationAPI.L("carman/fee_tolerance");

		public static string TIME_BONUS_DEADLINE_TOTAL => LocalizationAPI.L("carman/time_bonus_deadline_total");

		public static string LICENSES_OWNED => LocalizationAPI.L("carman/licenses_owned");

		public static string FEES_NOT_CLEARED_LINE1 => LocalizationAPI.L("carman/fees_not_cleared_line1");

		public static string FEES_NOT_CLEARED_LINE2 => LocalizationAPI.L("carman/fees_not_cleared_line2");

		public static string NO_OWNED_VEHICLES => LocalizationAPI.L("carman/no_owned_vehicles");

		public static string OWNED_VEHICLE_MANUAL_SERVICE => LocalizationAPI.L("carman/owned_vehicles_manual_service");

		public static string UNAVAILABLE_IN_SANDBOX => LocalizationAPI.L("carman/unavailable_in_sandbox");

		public static string PAY_FEES_TO_REDUCE_COPAY(string arg)
		{
			return LocalizationAPI.L("carman/pay_fees_to_reduce_copay", arg);
		}

		public static string PAY_TO_CLEAR_ALL_FEES(string arg)
		{
			return LocalizationAPI.L("carman/pay_to_clear_all_fees", arg);
		}

		public static string FEE_TITLE(string arg)
		{
			return LocalizationAPI.L("carman/fee_title_format", arg);
		}

		public static string NEED_TO_OWN(string arg)
		{
			return LocalizationAPI.L("carman/need_to_own", arg);
		}
	}
}
