using System;

namespace Assets.Nimbatus.Scripts.Persistence
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class GameSetting : Attribute
	{
		public readonly string Category;

		public GameSetting(string category)
		{
			Category = category;
		}
	}
}
