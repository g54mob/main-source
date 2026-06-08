public class FamilyMember : Person
{
	public string mom;

	public string dad;

	public string bornDate;

	public string deathDate;

	public FamilyMember(string firstName, string lastName, string mom, string dad, string born, string death)
		: base(firstName, lastName)
	{
		this.mom = mom;
		this.dad = dad;
		bornDate = born;
		deathDate = death;
	}

	public override string ToString()
	{
		return "'" + firstName + " " + lastName + "', '" + mom + "', '" + dad + "', " + bornDate + ", " + deathDate;
	}
}
