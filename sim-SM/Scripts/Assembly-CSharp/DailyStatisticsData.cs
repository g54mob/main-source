using System;

[Serializable]
public class DailyStatisticsData
{
	public int SatisfiedCustomerCount;

	public int CouldntFindProduct;

	public int ExpensiveProducts;

	public int ShortChangeAmount;

	public int HarmedCustomerCount;

	public int TotalCustomerCount;

	public int StorePoint;

	public float CheckoutIncome;

	public float SupplyCosts;

	public float UpgradeCosts;

	public float CustomizationCosts;

	public float BillCosts;

	public float VendingIncome;

	public float RentCosts;

	public float LoanIncome;

	public float LoanPayment;

	public float StaffPayment;

	public float PaintCosts;

	public float FloorBoxCosts;

	public void Clear()
	{
	}
}
