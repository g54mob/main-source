namespace NSEipix.Base
{
	public abstract class IndexedModel : Model
	{
		private int index;

		public int Index => index;

		internal void SetModelIndex(int index)
		{
			this.index = index;
		}
	}
}
