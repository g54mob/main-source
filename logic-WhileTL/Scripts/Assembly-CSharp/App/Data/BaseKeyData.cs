namespace App.Data
{
	public abstract class BaseKeyData
	{
		public string KeyName = string.Empty;

		public int KeyHash;

		public int GetHash()
		{
			if (KeyHash == 0)
			{
				KeyHash = KeyName.GetHashCode();
			}
			return KeyHash;
		}
	}
}
