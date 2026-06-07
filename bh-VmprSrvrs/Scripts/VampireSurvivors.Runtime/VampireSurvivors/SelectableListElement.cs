using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VampireSurvivors
{
	public class SelectableListElement : Selectable
	{
		[SerializeField]
		private Selectable _RedirectSelectionTo;

		public override void OnSelect(BaseEventData eventData)
		{
		}
	}
}
