using Libs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ShopCtrl : SingletonMonoBehaviour<ShopCtrl>
	{
		public TextMeshProUGUI pointText;

		[SerializeField]
		private GameObject defaultImage;

		[SerializeField]
		private GameObject emphasisImage;

		[SerializeField]
		private GameObject emphasisRenderImage;

		public Button shopButton;

		[SerializeField]
		private UILookEmphasis lookEmphasis;

		[SerializeField]
		private CanvasGroup canvasGroup;

		private int _researchMinCost;

		private int _redResearchMinCost;

		private bool _isEmphasis;

		public CanvasGroup CanvasGroup => null;

		private void Awake()
		{
		}

		public void Init()
		{
		}

		public void UpdateMaterialPoint()
		{
		}

		public void SwitchEmphasis()
		{
		}

		public void OnClickResearchButton()
		{
		}

		public void UpdateMinCost()
		{
		}

		public bool IsAvailablePurchase()
		{
			return false;
		}

		public void PlayEmphasis(bool isPushOk = true)
		{
		}

		public void StopEmphasis()
		{
		}

		public void OnSelectDialogGroup()
		{
		}

		public void OnSelectSceneSwitchGroup()
		{
		}

		public void OnSelectRelicGroup()
		{
		}

		public void CancelPadUI()
		{
		}
	}
}
