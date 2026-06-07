using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.Data;

namespace VampireSurvivors.UI
{
	public class OnlineDLCIcon : Selectable
	{
		public DlcType DlcType;

		public Image Image;

		public OnlineDLCSection OnlineDLCSection;

		public GameObject UnavailableSprite;

		public void SetAvailable()
		{
		}

		public void SetUnavailable()
		{
		}

		public override void OnSelect(BaseEventData eventData)
		{
		}
	}
}
