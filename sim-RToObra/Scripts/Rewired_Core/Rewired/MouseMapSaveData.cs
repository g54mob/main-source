namespace Rewired
{
	public sealed class MouseMapSaveData : ControllerMapSaveData
	{
		public MouseMap keyboardMap
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					while (true)
					{
						int num = -1275708960;
						while (true)
						{
							switch (num ^ -1275708958)
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
							num = -1275708957;
						}
					}
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
