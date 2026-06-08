using UnityEngine;
using UnityEngine.EventSystems;

namespace Dorfromantik.Area
{
	public class AreaSignpost : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		private Area area;

		private AreaManager areaManager;

		internal void Initialize(Area area, AreaManager areaManager)
		{
			this.area = area;
			this.areaManager = areaManager;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			areaManager.PickPreviewAreaAsPlayable(area);
		}

		internal void Terminate()
		{
			Object.Destroy(base.gameObject);
		}
	}
}
