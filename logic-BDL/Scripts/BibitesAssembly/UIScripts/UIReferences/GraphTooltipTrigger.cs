using OneUseScripts;
using UIScripts.UIReferences.Graphs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIScripts.UIReferences
{
	public class GraphTooltipTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		private bool hovering;

		public BaseLineGraph graph;

		private RectTransform rt;

		private Camera cam;

		protected void Awake()
		{
			rt = GetComponent<RectTransform>();
			cam = UICamera.cam;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			hovering = true;
			ShowTooltip(show: true);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			hovering = false;
			ShowTooltip(show: false);
		}

		private void Update()
		{
			if (hovering)
			{
				RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, Input.mousePosition, cam, out var localPoint);
				graph.UpdateTooltip(localPoint.x);
			}
		}

		private void ShowTooltip(bool show)
		{
			hovering = show;
			graph.ShowTooltip(show);
		}

		protected void OnDisable()
		{
			if (hovering)
			{
				ShowTooltip(show: false);
			}
		}
	}
}
