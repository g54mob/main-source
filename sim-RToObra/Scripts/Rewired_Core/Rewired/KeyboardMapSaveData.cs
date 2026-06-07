namespace Rewired
{
	public sealed class KeyboardMapSaveData : ControllerMapSaveData
	{
		public KeyboardMap keyboardMap
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					while (true)
					{
						int num = -1120682319;
						while (true)
						{
							switch (num ^ -1120682317)
							{
							case 0:
								break;
							case 2:
								goto IL_002b;
							default:
								return null;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
							num = -1120682318;
						}
					}
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
