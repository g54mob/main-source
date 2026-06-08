using System.Text;
using UnityEngine;

namespace Kitchen.NetworkSupport
{
	public static class JoinCodeHelpers
	{
		public static readonly int Length = 6;

		public static readonly int FullLength = Length + 1;

		public static readonly string DataKey = "code";

		public const string FriendlyCharacters = "BDGHJMQRTVWXY346789";

		public static JoinCode Generate()
		{
			_ = "BDGHJMQRTVWXY346789".Length;
			StringBuilder stringBuilder = new StringBuilder(Length);
			for (int i = 0; i < Length; i++)
			{
				char value = "BDGHJMQRTVWXY346789"[Random.Range(0, "BDGHJMQRTVWXY346789".Length)];
				stringBuilder.Append(value);
			}
			return JoinCode.Create(stringBuilder.ToString());
		}
	}
}
