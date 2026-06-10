namespace Rewired
{
	public sealed class MouseMapSaveData : ControllerMapSaveData
	{
		public MouseMap keyboardMap => null;

		internal MouseMapSaveData(Mouse mouse, MouseMap map)
			: base(null, null)
		{
		}
	}
}
