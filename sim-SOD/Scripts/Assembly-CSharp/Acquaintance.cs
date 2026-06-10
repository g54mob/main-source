using System;
using System.Collections.Generic;

public class Acquaintance : IComparable<Acquaintance>
{
	public enum ConnectionType
	{
		friend = 0,
		neighbor = 1,
		housemate = 2,
		lover = 3,
		boss = 4,
		workTeam = 5,
		workOther = 6,
		regularCustomer = 7,
		regularStaff = 8,
		familiarResidence = 9,
		familiarWork = 10,
		publicFigure = 11,
		stranger = 12,
		paramour = 13,
		player = 14,
		anyoneNotPlayer = 15,
		friendOrWork = 16,
		knowsName = 17,
		anyAcquaintance = 18,
		anyone = 19,
		workNotBoss = 20,
		relationshipMatch = 21,
		corpDove = 22,
		spamVmail = 23,
		corpStarch = 24,
		corpIndigo = 25,
		corpKaizen = 26,
		corpElgen = 27,
		corpCandor = 28,
		flairQuotes = 29,
		randomSpamVmail = 30,
		noReplyVmail = 31,
		bookGrubs = 32,
		pestControl = 33,
		landlord = 34,
		groupMember = 35,
		storyPartner = 36
	}

	public Human from;

	public Human with;

	public ConnectionType secretConnection;

	public float compatible;

	public float known;

	public float like;

	[NonSerialized]
	public GroupsController.SocialGroup group;

	public List<ConnectionType> connections;

	public float customSort;

	public List<Evidence.DataKey> dataKeys;

	public List<Fact> connectionFacts;

	public static Comparison<Acquaintance> customComparison;

	public Acquaintance(Human newFrom, Human newWith, float newKnown, ConnectionType newConnection, ConnectionType newSecretConnection, GroupsController.SocialGroup newGroup)
	{
	}

	public void AddConnection(float newKnown, ConnectionType newConnection)
	{
	}

	public Acquaintance(CitySaveData.AcquaintanceCitySave data)
	{
	}

	public void SetupFacts()
	{
	}

	public float CalculateCompatible()
	{
		return 0f;
	}

	public Human GetOther(Human other)
	{
		return null;
	}

	public void AddKnow(float plusKnow)
	{
	}

	public void CalculateLike()
	{
	}

	public void OthersKnowledgeUpdate()
	{
	}

	public int CompareTo(Acquaintance comp)
	{
		return 0;
	}

	public CitySaveData.AcquaintanceCitySave GenerateSaveData()
	{
		return null;
	}
}
