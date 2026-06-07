namespace Rewired
{
	public sealed class MouseMapSaveData : ControllerMapSaveData
	{
		public MouseMap keyboardMap
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				return (MouseMap)_map;
			}
		}

		internal MouseMapSaveData(Mouse P_0, MouseMap P_1)
			: base(P_0, P_1)
		{
		}
	}
}
