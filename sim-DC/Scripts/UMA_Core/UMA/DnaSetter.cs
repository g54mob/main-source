namespace UMA
{
	public class DnaSetter
	{
		public string Name;

		public float Value;

		public string Category;

		protected UMADnaBase Owner;

		public int OwnerIndex { get; private set; }

		public DnaSetter(string name, float value, int ownerIndex, UMADnaBase owner, string category)
		{
		}

		public void Set(float val)
		{
		}

		public void Set()
		{
		}

		public float Get()
		{
			return 0f;
		}
	}
}
