namespace Gh.Tk
{
	public class FireExtinguisherGameItem : LarderTileBoundGameItem
	{
		[PersistenceObjectReference]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public GameItem Barrel;

		public float MaxDistance;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public new FireExtinguisherGameItemTemplate Template
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		public bool IsLoaded()
		{
			return false;
		}

		protected FireExtinguisherGameItem()
		{
		}

		public FireExtinguisherGameItem(FireExtinguisherGameItemTemplate template, bool representsTemplate = false)
		{
		}
	}
}
