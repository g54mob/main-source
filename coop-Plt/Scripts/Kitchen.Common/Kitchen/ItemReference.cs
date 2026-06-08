namespace Kitchen
{
	public struct ItemReference
	{
		public int ID;

		public static implicit operator int(ItemReference ir)
		{
			return ir.ID;
		}

		public static implicit operator ItemReference(int id)
		{
			return new ItemReference
			{
				ID = id
			};
		}
	}
}
