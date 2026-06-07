namespace Rewired
{
	public sealed class CustomControllerMapSaveData : ControllerMapSaveData
	{
		public CustomController customController => null;

		public CustomControllerMap customControllerMap => null;

		public int customControllerSourceId => 0;

		internal CustomControllerMapSaveData(CustomController P_0, CustomControllerMap P_1)
			: base(null, null)
		{
		}
	}
}
