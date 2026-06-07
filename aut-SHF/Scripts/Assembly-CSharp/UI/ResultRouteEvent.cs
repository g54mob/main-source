using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ResultRouteEvent : MonoBehaviour
	{
		[SerializeField]
		private Image _researchFrame;

		[SerializeField]
		private Image _mainIcon;

		[SerializeField]
		private Image _routeEventIcon;

		[SerializeField]
		private GameObject _failedImage;

		[SerializeField]
		private GameObject _loadObject;

		private bool IsChoiceEvent(eRouteEvent type)
		{
			return false;
		}

		public void InitComponent(WaveLog waveLog, bool isLast = false)
		{
		}
	}
}
