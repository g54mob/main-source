namespace ES3Types
{
	public class ES3UserType_WingGizmoArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WingGizmoArray()
			: base(typeof(WingGizmo[]), ES3UserType_WingGizmo.Instance)
		{
			Instance = this;
		}
	}
}
