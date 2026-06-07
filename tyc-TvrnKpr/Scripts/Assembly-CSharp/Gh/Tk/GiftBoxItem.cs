namespace Gh.Tk
{
	public class GiftBoxItem : GameItem
	{
		[PersistenceOptIn]
		public string[] GiftContents;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public new GiftBoxItemTemplate Template
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		[PersistenceOptIn]
		public int GiftTier { get; set; }

		[PersistenceOptIn]
		public bool IsMiniBox { get; set; }

		public GiftBoxItem()
		{
		}

		public GiftBoxItem(GiftBoxItemTemplate template, bool representsTemplate = false)
		{
		}
	}
}
