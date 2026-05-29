using System;

[Serializable]
public class User
{
	private static int idCounter;

	public int id_user;

	public bool isUser;

	public string firstName;

	public string lastName;

	public string department;

	public string email;

	public int avatar;

	public User(string firstName, string lastName, string department, string email, int avatar)
	{
	}
}
