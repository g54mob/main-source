using System;
using System.Collections.Generic;
using UnityEngine;

public class UsersDatabases : MonoBehaviour
{
	[Serializable]
	private class UserListWrapper
	{
		public List<User> users;
	}

	public static UsersDatabases instance;

	public Sprite[] Avatars;

	[SerializeField]
	public List<User> listusers;

	private void Awake()
	{
	}

	public void addUser(string firstName, string lastName, string department, int avatar)
	{
	}

	private string GenerateEmail(string firstName, string LastName)
	{
		return null;
	}

	public User GetUserById(int id)
	{
		return null;
	}

	public string NameUser(int id)
	{
		return null;
	}

	public string NameUserSystem(int id)
	{
		return null;
	}

	public string EmailUser(int id)
	{
		return null;
	}

	public int idAvatar(int id)
	{
		return 0;
	}

	public string UsersDatabasesToJson()
	{
		return null;
	}

	public void JsonToUsersDatabases(string json)
	{
	}
}
