namespace FullInspector
{
	public class SharedInstance<TInstance, TSerializer> : BaseScriptableObject<TSerializer>, ISharedInstance where TSerializer : BaseSerializer
	{
		public int ID;

		public TInstance Instance;

		public int GetID
		{
			get
			{
				return ID;
			}
			set
			{
				ID = value;
			}
		}

		public object GetInstance => Instance;
	}
}
