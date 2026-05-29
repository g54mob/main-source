using System;

namespace __Project__.Scripts.Meta
{
	[Serializable]
	public class SaveFileRoot
	{
		public TypedWrapper<SaveManager.ProgressionContainer> Progression;

		public TypedWrapper<SaveManager.OnboardingContaioner> Onboarding;

		public TypedWrapper<SaveManager.PriceContainer> Price;

		public TypedWrapper<SaveManager.ExpensesData> Expenses;

		public TypedWrapper<SaveManager.EmployeesData> Employees;

		public TypedWrapper<SaveManager.StorageData> Storage;

		public TypedWrapper<SaveManager.CustomizationContainer> NewCustomization;

		public TypedWrapper<SaveManager.CleaningContainer> Cleaning;

		public TypedWrapper<SaveManager.SettingsContainer> Settings;

		public TypedWrapper<SaveManager.OrdersContainer> OnlineOrders;
	}
}
