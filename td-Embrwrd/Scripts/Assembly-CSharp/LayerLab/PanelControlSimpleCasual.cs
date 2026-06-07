using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LayerLab
{
	public class PanelControlSimpleCasual : MonoBehaviour
	{
		private int page;

		private bool isReady;

		[SerializeField]
		private List<GameObject> panelLight;

		[SerializeField]
		private List<GameObject> panelDark;

		private TextMeshProUGUI textTitle;

		[SerializeField]
		private Transform panelTransformLight;

		[SerializeField]
		private Transform panelTransformDark;

		[SerializeField]
		private Button buttonPrev;

		[SerializeField]
		private Button buttonNext;

		private bool isDarakMode;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void Click_Prev()
		{
		}

		public void Click_Next()
		{
		}

		private void SetArrowActive()
		{
		}

		private void CheckControl()
		{
		}

		public void Click_Mode()
		{
		}

		private void SetMode()
		{
		}
	}
}
