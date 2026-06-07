using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModularOptions
{
	[RequireComponent(typeof(Selectable), typeof(AudioSource))]
	[AddComponentMenu("Modular Options/Selectable UI Sound")]
	public class SelectableUISound : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, ISubmitHandler, ISelectHandler, IDeselectHandler
	{
		[Tooltip("Reference to ScriptableObject containing sound data. Create a new one by right-clicking in the Project-window and clicking DataContainer/UI/SelectableSound")]
		public SelectableUISoundData soundData;

		private AudioSource audioSource;

		private void Awake()
		{
		}

		public void OnPointerClick(PointerEventData _eventData)
		{
		}

		public void OnPointerEnter(PointerEventData _eventData)
		{
		}

		public void OnPointerExit(PointerEventData _eventData)
		{
		}

		public void OnSubmit(BaseEventData _eventData)
		{
		}

		public void OnSelect(BaseEventData _eventData)
		{
		}

		public void OnDeselect(BaseEventData _eventData)
		{
		}

		private void PlayIfNotNull(AudioClip _clip)
		{
		}
	}
}
