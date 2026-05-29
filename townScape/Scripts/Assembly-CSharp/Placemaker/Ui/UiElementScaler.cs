using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class UiElementScaler : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private RectTransform childRectTransform;

		public void OnSetup(UiMaster master)
		{
		}

		public void OnStart(UiMaster master)
		{
		}

		private new void OnEnable()
		{
		}

		private void OnDimensionsChange()
		{
		}

		private void SetRect()
		{
		}
	}
}
