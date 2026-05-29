using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PG
{
	public class QualitySwitch : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		public TextMeshProUGUI CurrentFpsText;

		private int QualityIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		private void Start()
		{
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}
	}
}
