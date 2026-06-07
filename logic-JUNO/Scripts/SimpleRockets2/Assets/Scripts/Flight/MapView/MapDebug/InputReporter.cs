using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Flight.MapView.MapDebug
{
	public class InputReporter : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		public void OnPointerClick(PointerEventData eventData)
		{
			Debug.LogFormat("InputReporter Clicked: {0}", base.name);
		}
	}
}
