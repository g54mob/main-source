using UnityEngine;

namespace Jundroo.SocialPlatforms
{
	public interface IAchievementDescription
	{
		string achievedDescription { get; }

		bool hidden { get; }

		string id { get; set; }

		Texture2D image { get; }

		int points { get; }

		string title { get; }

		string unachievedDescription { get; }
	}
}
