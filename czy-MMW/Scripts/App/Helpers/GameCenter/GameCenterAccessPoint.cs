using UnityEngine;

namespace Helpers.GameCenter
{
	public class GameCenterAccessPoint : IGameCenterAccessPoint
	{
		public bool IsAvailable()
		{
			return GameCenterShared.GCIsAccessPointAvailable();
		}

		public void Show()
		{
			GameCenterShared.GCShowAccessPoint();
		}

		public void Hide()
		{
			GameCenterShared.GCHideAccessPoint();
		}

		public Rect GetRect()
		{
			return new Rect(GameCenterShared.GCGetAccessPointOriginX(), GameCenterShared.GCGetAccessPointOriginY(), GameCenterShared.GCGetAccessPointSizeWidth(), GameCenterShared.GCGetAccessPointSizeHeight());
		}

		public void Select()
		{
			GameCenterShared.GCSelectAccessPoint();
		}
	}
}
