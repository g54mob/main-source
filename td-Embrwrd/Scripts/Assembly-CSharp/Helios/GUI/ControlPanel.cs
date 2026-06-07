using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Helios.GUI
{
	public class ControlPanel : MonoBehaviour
	{
		private int _nbPage;

		private bool _isReady;

		private TextMeshProUGUI _textTitle;

		[SerializeField]
		private List<GameObject> _lsPanel;

		[SerializeField]
		private Transform _tfPanel;

		[SerializeField]
		private Button _btnPrev;

		[SerializeField]
		private Button _btnNext;

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
	}
}
