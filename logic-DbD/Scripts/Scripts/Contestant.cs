public class Contestant
{
	private string attendee_id;

	private int itemsOwned;

	public Contestant(int attendee_id, int itemsOwned)
	{
		this.attendee_id = attendee_id.ToString("D5");
		this.itemsOwned = itemsOwned;
	}

	public override string ToString()
	{
		return $"'{attendee_id}', {itemsOwned}";
	}
}
