namespace Rewired
{
	public sealed class KeyboardMapSaveData : ControllerMapSaveData
	{
		public KeyboardMap keyboardMap
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				return (KeyboardMap)_map;
			}
		}

		internal KeyboardMapSaveData(Keyboard keyboard, KeyboardMap map)
			: base(keyboard, map)
		{
		}
	}
}
