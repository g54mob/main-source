using System;

namespace HQFPSTemplate
{
	public class IdGenerator
	{
		private static Random m_Random = new Random();

		public static string GenerateStringId()
		{
			string text = Convert.ToBase64String(GetRandom(4));
			return text.Remove(text.Length - 3);
		}

		public static int GenerateIntegerId()
		{
			return m_Random.Next(-9999999, 9999999);
		}

		private static byte[] GetRandom(int size)
		{
			byte[] array = new byte[size];
			m_Random.NextBytes(array);
			return array;
		}
	}
}
