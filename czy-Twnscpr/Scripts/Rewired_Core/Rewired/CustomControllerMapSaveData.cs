namespace Rewired
{
	public sealed class CustomControllerMapSaveData : ControllerMapSaveData
	{
		public CustomController customController => null;

		public CustomControllerMap customControllerMap => null;

		public int customControllerSourceId => 0;

		internal CustomControllerMapSaveData(CustomController customController, CustomControllerMap map)
			: base(null, null)
		{
		}
	}
}
