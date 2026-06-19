using ModIO.Util;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ModIOBrowser.Implementation
{
	public class SelectableFeatureImage : MonoBehaviour, IMoveHandler, IEventSystemHandler, ISelectHandler, IDeselectHandler
	{
		public void OnMove(AxisEventData eventData)
		{
			if (eventData.moveDir == MoveDirection.Left)
			{
				SelfInstancingMonoSingleton<Home>.Instance.PageFeaturedRow(right: false);
			}
			else if (eventData.moveDir == MoveDirection.Right)
			{
				SelfInstancingMonoSingleton<Home>.Instance.PageFeaturedRow(right: true);
			}
		}

		public void OnSelect(BaseEventData eventData)
		{
			SelfInstancingMonoSingleton<Home>.Instance.FeaturedItemSelect(state: true);
		}

		public void OnDeselect(BaseEventData eventData)
		{
			SelfInstancingMonoSingleton<Home>.Instance.FeaturedItemSelect(state: false);
		}
	}
}
