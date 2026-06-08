public class Credit
{
	private string name;

	private string role;

	private string credit;

	public Credit(string name, string role, string credit)
	{
		this.name = name;
		this.role = role;
		this.credit = credit;
	}

	public override string ToString()
	{
		return "'" + name + "', '" + role + "', '" + credit + "'";
	}
}
