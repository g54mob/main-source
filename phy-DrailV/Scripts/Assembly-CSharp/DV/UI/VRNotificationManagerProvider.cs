using System.Collections;
using DV.UIFramework;
using DV.Utils;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

namespace DV.UI
{
	public class VRNotificationManagerProvider : ANotificationManagerProvider
	{
		private const float VR_LINE_WIDTH_MULTIPLIER = 0.4f;

		public NotificationManager notificationManager;

		public GameObject tutorialFloatiePrefab;

		public Vector3 fakeHeadOffset = new Vector3(0f, -0.2f, 0f);

		private Floatie floatie;

		private RectTransform contentRoot;

		private Transform fakeHeadTransform;

		public override RectTransform ContentRoot => contentRoot;

		private void Awake()
		{
			notificationManager.provider = this;
		}

		private IEnumerator Start()
		{
			while (!PlayerManager.PlayerCamera)
			{
				yield return null;
			}
			GameObject gameObject = Object.Instantiate(tutorialFloatiePrefab, Vector3.zero, Quaternion.identity, VRTK_DeviceFinder.PlayAreaTransform());
			floatie = gameObject.GetComponent<Floatie>();
			contentRoot = floatie.GetComponentInChildren<HorizontalOrVerticalLayoutGroup>().transform as RectTransform;
			Transform parent = PlayerManager.PlayerCamera.transform;
			fakeHeadTransform = new GameObject("VRNotificationFloatieAnchor").transform;
			fakeHeadTransform.SetParent(parent, worldPositionStays: false);
			fakeHeadTransform.localPosition = fakeHeadOffset;
			floatie.head = fakeHeadTransform;
			floatie.lineStartPoint = new GameObject().transform;
			floatie.lineStartPoint.transform.parent = floatie.transform;
			floatie.lineWidth *= 0.4f;
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				Object.Destroy(fakeHeadTransform.gameObject);
			}
		}

		public override void AddWorldSpacePointer(GameObject notification, Transform to, bool targetIsUI, GameObject owner)
		{
			RectTransform rectTransform = notification.transform as RectTransform;
			if (rectTransform != null)
			{
				floatie.lineStartPoint.position = rectTransform.TransformPoint(rectTransform.rect.center);
			}
			if (targetIsUI)
			{
				SingletonBehaviour<UITutorialHighlighter>.Instance.Highlight(to as RectTransform);
			}
			else
			{
				floatie.attentionPoint = to;
			}
		}

		public override void ClearWorldSpacePointer(GameObject notification)
		{
			SingletonBehaviour<UITutorialHighlighter>.Instance.Unhighlight();
			floatie.attentionPoint = null;
		}

		public override void OnNotificationAdded(GameObject notification)
		{
			Transform transform = PlayerManager.PlayerCamera.transform;
			Vector3 position = transform.position + transform.forward * floatie.distanceFromHead;
			floatie.transform.position = position;
			floatie.transform.rotation = transform.rotation;
		}
	}
}
