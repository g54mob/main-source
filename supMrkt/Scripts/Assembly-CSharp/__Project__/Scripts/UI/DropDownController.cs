using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace __Project__.Scripts.UI
{
	[RequireComponent(typeof(TMP_Dropdown))]
	[DisallowMultipleComponent]
	public class DropDownController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[Tooltip("Indexes that should be ignored. Indexes are 0 based.")]
		public List<int> indexesToDisable;

		private TMP_Dropdown _dropdown;

		private void Awake()
		{
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}

		public void EnableOption(int index, bool enable)
		{
		}

		public void EnableOption(string label, bool enable)
		{
		}
	}
}
