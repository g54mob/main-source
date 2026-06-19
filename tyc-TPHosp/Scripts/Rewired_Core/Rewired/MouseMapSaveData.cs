namespace Rewired
{
	public sealed class MouseMapSaveData : ControllerMapSaveData
	{
		public MouseMap keyboardMap
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				return (MouseMap)_map;
			}
		}

		internal MouseMapSaveData(Mouse mouse, MouseMap map)
			: base(mouse, map)
		{
		}
	}
}
