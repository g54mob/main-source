using CTS.BBT;

namespace CTS
{
	public class StoreMenuButton : InterfaceButton
	{
		public static StoreMenuButton Instance { get; private set; }

		protected override void Awake()
		{
			base.Awake();
			Instance = this;
		}

		private void OnDestroy()
		{
			Instance = null;
		}

		public override void ForceHiding()
		{
			canvasToShow.QuickHide();
		}

		public void ForceShowingItem(StockItemSO item)
		{
			canvasToShow.QuickShow();
			for (int i = 0; i < canvasToHide.Length; i++)
			{
				canvasToHide[i].QuickHide();
			}
		}
	}
}
