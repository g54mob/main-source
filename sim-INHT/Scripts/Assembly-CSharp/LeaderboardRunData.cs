using System;
using System.Collections.Generic;
using Newtonsoft.Json;

[Serializable]
public class LeaderboardRunData
{
	[Serializable]
	public class ActionData
	{
		public string ActionName;

		public string Details;

		public int ScoreDelta;

		public DateTime TimestampUTC;
	}

	public string Key;

	[JsonIgnore]
	public List<string> MapImages;

	private int _a;

	private int _b;

	private int _key;

	private int _salt;

	private int _check;

	private bool _t;

	public List<ActionData> Actions;

	public int Score
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool Check => false;

	public bool FinalCheck => false;

	private void FlagTamper()
	{
	}
}
