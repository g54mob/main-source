public class CheckoutTime
{
	public string employeeId;

	public int checkinTime;

	public int checkoutTime;

	public CheckoutTime(int id, int checkin, int checkout)
	{
		employeeId = id.ToString();
		checkinTime = checkin;
		checkoutTime = checkout;
	}

	public override string ToString()
	{
		return $"'{employeeId}', {checkinTime}, {checkoutTime}";
	}
}
