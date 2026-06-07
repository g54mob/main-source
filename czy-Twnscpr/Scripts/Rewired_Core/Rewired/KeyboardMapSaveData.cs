namespace Rewired
{
	public sealed class KeyboardMapSaveData : ControllerMapSaveData
	{
		public KeyboardMap keyboardMap => null;

		internal KeyboardMapSaveData(Keyboard keyboard, KeyboardMap map)
			: base(null, null)
		{
		}
	}
}
