using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class ScreenshotFrame : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private RectTransform masterRt;

		public RectTransform center;

		public RectTransform margins;

		[SerializeField]
		private RectTransform top;

		[SerializeField]
		private RectTransform bottom;

		[SerializeField]
		private RectTransform left;

		[SerializeField]
		private RectTransform right;

		[SerializeField]
		private int width;

		[SerializeField]
		private int height;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		public void SetSize(int width, int height)
		{
		}

		public void UpdateSize()
		{
		}

		private void SetRect(RectTransform rt, float minX, float maxX, float minY, float maxY)
		{
		}
	}
}
