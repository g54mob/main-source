using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace VampireSurvivors.App.UI
{
	public class InputSelectableUI : MonoBehaviour, ISubmitHandler, IEventSystemHandler, IDeselectHandler, ISelectHandler
	{
		[SerializeField]
		private TMP_InputField _InputField;

		public bool _HasFocus;

		public void OnSubmit(BaseEventData eventData)
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}
	}
}
