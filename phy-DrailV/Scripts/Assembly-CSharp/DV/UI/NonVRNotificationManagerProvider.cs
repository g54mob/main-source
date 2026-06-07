using System.Linq;
using DV.UIFramework;
using DV.Utils;
using UnityEngine;

namespace DV.UI
{
	public class NonVRNotificationManagerProvider : ANotificationManagerProvider
	{
		public const string UI_ATTACH_POINT = "[pointer-anchor]";

		public NonVRLineRendererController nonVRLineRendererController;

		public RectTransform contentRoot;

		public NotificationManager notificationManager;

		public override RectTransform ContentRoot => contentRoot;

		private void Awake()
		{
			notificationManager.provider = this;
			nonVRLineRendererController.canvas = contentRoot.GetComponentInParent<Canvas>();
		}

		public override void AddWorldSpacePointer(GameObject notification, Transform to, bool targetIsUI, GameObject owner)
		{
			Transform sourceTransform = notification.GetComponentsInChildren<Transform>().First((Transform go) => go.name.Equals("[pointer-anchor]")).transform;
			if (targetIsUI)
			{
				RectTransform rectTransform = (RectTransform)to.GetComponentsInChildren<Transform>().FirstOrDefault((Transform go) => go.name.Equals("[pointer-anchor]"));
				SingletonBehaviour<UITutorialHighlighter>.Instance.Highlight(rectTransform ? rectTransform : (to as RectTransform));
				return;
			}
			nonVRLineRendererController.sourceTransform = sourceTransform;
			nonVRLineRendererController.attentionTransform = to;
			nonVRLineRendererController.owner = owner;
			if (nonVRLineRendererController.IsVisible)
			{
				nonVRLineRendererController.FreezePosition(1);
			}
			else
			{
				nonVRLineRendererController.ShowAfter(1);
			}
		}

		public override void ClearWorldSpacePointer(GameObject notification)
		{
			SingletonBehaviour<UITutorialHighlighter>.Instance.Unhighlight();
			nonVRLineRendererController.attentionTransform = null;
			nonVRLineRendererController.sourceTransform = null;
			nonVRLineRendererController.owner = null;
		}

		public override void OnNotificationAdded(GameObject notification)
		{
		}
	}
}
