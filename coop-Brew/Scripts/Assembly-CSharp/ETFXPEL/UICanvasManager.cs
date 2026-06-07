using UnityEngine;
using UnityEngine.UI;

namespace ETFXPEL
{
	public class UICanvasManager : MonoBehaviour
	{
		public static UICanvasManager GlobalAccess;

		public bool MouseOverButton;

		public Text PENameText;

		public Text ToolTipText;

		private RaycastHit rayHit;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void UpdateToolTip(ButtonTypes toolTipType)
		{
		}

		public void ClearToolTip()
		{
		}

		private void SelectPreviousPE()
		{
		}

		private void SelectNextPE()
		{
		}

		private void SpawnCurrentParticleEffect()
		{
		}

		public void UIButtonClick(ButtonTypes buttonTypeClicked)
		{
		}
	}
}
