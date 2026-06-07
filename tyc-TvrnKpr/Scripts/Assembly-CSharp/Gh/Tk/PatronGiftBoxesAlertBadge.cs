using UnityEngine.Scripting;

namespace Gh.Tk
{
	[Preserve]
	[InitializeOnGameStarted]
	public class PatronGiftBoxesAlertBadge : AlertBadgeBase
	{
		private GiftBoxGameItemVisual[] _giftBoxes;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void Reset()
		{
		}

		private void Invalidate()
		{
		}

		protected override bool UpdateInternal()
		{
			return false;
		}

		protected override void OnClick(Alert_3DUIView source)
		{
		}
	}
}
