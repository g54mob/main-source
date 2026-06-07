using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;

namespace UI
{
	[RequireComponent(typeof(EventTrigger))]
	public class UIMouseOverElement : MonoBehaviour
	{
		[SerializeField]
		private UIMouseOverCtrl.eUIMouseOverType type;

		[SerializeField]
		private LocalizedString title;

		[Header("Message or ValueGetter（どちらかのみ有効）")]
		[SerializeField]
		private LocalizedString message;

		[SerializeField]
		private GameObject valueGetter;

		[Header("方角指定")]
		[SerializeField]
		private UIMouseOverCtrl.eUIMouseOverAnchorPosition anchor;

		public void OnTriggerMouseOver()
		{
		}

		public void OnCancelMouseOver()
		{
		}
	}
}
