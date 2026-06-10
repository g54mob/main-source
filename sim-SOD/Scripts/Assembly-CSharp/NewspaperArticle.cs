using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newspaper_data", menuName = "Database/Newspaper Article")]
public class NewspaperArticle : SoCustomComparison
{
	public enum Category
	{
		general = 0,
		murder = 1,
		ad = 2,
		foreignAffairs = 3,
		murderSecond = 4
	}

	public enum ContextSource
	{
		nothing = 0,
		lastMurder = 1,
		player = 2,
		randomCitizen = 3,
		randomCriminal = 4,
		randomGroup = 5
	}

	[Header("Debug")]
	public bool disabled;

	[Header("Setup")]
	public string ddsReference;

	public Category category;

	[Tooltip("The next generated newspaper will try to feature one of the following")]
	public List<NewspaperArticle> followupStories;

	public ContextSource context;
}
