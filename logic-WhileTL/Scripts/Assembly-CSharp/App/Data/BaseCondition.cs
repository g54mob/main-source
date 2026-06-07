namespace App.Data
{
	public class BaseCondition : BaseKeyData
	{
		public int ExtraMoney = -1;

		public bool IsValid()
		{
			return KeyName != string.Empty;
		}
	}
}
