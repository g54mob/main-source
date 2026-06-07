using UnityEngine;
using UnityEngine.UI;

namespace Helios.GUI
{
	public class SimpleScrollSnap : MonoBehaviour
	{
		[SerializeField]
		private GameObject _goScrollbar;

		[SerializeField]
		private GameObject _goPagination;

		[SerializeField]
		private Sprite[] _arrPaginationSprites;

		private int _nbButtonIndex;

		private bool _isTimeToRun;

		private float _nbScrollPosition;

		private float _nbTimer;

		private float _nbDistance;

		private float[] _arrPosition;

		private Button _btnCliked;

		private Scrollbar _scrollbar;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void Snap(float distance, float[] pos, Button btn)
		{
		}

		public void WhichBtnClicked(Button btn)
		{
		}
	}
}
