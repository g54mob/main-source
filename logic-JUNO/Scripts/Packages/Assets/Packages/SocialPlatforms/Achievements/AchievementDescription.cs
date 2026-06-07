using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Assets.Packages.SocialPlatforms.Achievements
{
	public class AchievementDescription : IAchievementDescription
	{
		public virtual string achievedDescription { get; set; }

		public virtual bool hidden { get; set; }

		public virtual string id { get; set; }

		public virtual Texture2D image { get; set; }

		public virtual int points { get; set; }

		public virtual string title { get; set; }

		public virtual string unachievedDescription { get; set; }
	}
}
