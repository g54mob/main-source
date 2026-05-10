namespace FluffyUnderware.DevTools
{
	public class ArrayExAttribute : DTAttribute, IDTFieldParsingAttribute
	{
		public bool Draggable;

		public bool ShowHeader;

		public bool ShowAdd;

		public bool ShowDelete;

		public bool DropTarget;

		public ArrayExAttribute()
			: base(0)
		{
		}
	}
}
