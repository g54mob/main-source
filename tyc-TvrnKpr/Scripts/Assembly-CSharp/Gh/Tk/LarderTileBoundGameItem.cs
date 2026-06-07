namespace Gh.Tk
{
	public class LarderTileBoundGameItem : GameItem
	{
		[PersistenceObjectReference]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		[PersistenceAllowBrokenReferenceOnLoad]
		public Larder_Tile BoundToLarder;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public new LarderTileBoundGameItemTemplate Template
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		protected LarderTileBoundGameItem()
		{
		}

		public LarderTileBoundGameItem(LarderTileBoundGameItemTemplate template, bool representsTemplate = false)
		{
		}
	}
}
