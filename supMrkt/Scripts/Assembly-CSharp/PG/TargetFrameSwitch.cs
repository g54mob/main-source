using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PG
{
	public class TargetFrameSwitch : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private TextMeshProUGUI CurrentFpsText;

		private void Start()
		{
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}
	}
}
