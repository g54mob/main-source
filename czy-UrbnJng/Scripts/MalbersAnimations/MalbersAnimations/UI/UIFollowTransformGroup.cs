using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.UI
{
	[DefaultExecutionOrder(-500)]
	public class UIFollowTransformGroup : MonoBehaviour
	{
		public class UIFollowItem
		{
			public GameObject worldObject;

			public GameObject UI;

			public UIFollowItem(GameObject world, GameObject ui)
			{
				worldObject = world;
				UI = ui;
			}
		}

		[Tooltip("Reference for the Camera")]
		public TransformReference Camera;

		[CreateScriptableAsset]
		public RuntimeGameObjects Set;

		[RequiredField]
		public GameObject ItemUI;

		private Camera cam;

		private List<UIFollowItem> items;

		[Tooltip("Hide the UI component if the Object is not in camera view. Set it to false to keep showning it")]
		public bool HideOffScreen = true;

		[Tooltip("Offset position for the tracked gameobject")]
		public Vector3 Offset = Vector3.zero;

		[Tooltip("Scale of the Instantiated prefab")]
		public Vector3 Scale = Vector3.one;

		private void Awake()
		{
			items = new List<UIFollowItem>();
			if (!Set)
			{
				base.enabled = false;
				Debug.LogWarning(base.name + " Does not have a runtime set to follow", this);
				return;
			}
			Set.Clear();
			if (Camera.Value != null)
			{
				cam = Camera.Value.GetComponent<Camera>();
				return;
			}
			cam = MTools.FindMainCamera();
			Camera.Value = cam.transform;
		}

		private void OnEnable()
		{
			if (ItemUI == null)
			{
				base.enabled = false;
				return;
			}
			if (Set != null)
			{
				Set.OnItemAdded.AddListener(OnItemAdded);
				Set.OnItemRemoved.AddListener(OnItemRemoved);
				Set.OnSetEmpty.AddListener(OnSetEmpty);
			}
			cam = MTools.FindMainCamera();
			items = new List<UIFollowItem>();
		}

		private void OnDisable()
		{
			if (Set != null)
			{
				Set.OnItemAdded.RemoveListener(OnItemAdded);
				Set.OnItemRemoved.RemoveListener(OnItemRemoved);
				Set.OnSetEmpty.RemoveListener(OnSetEmpty);
			}
		}

		public void ChangeObjectSet(RuntimeGameObjects newObjects)
		{
		}

		private void OnSetEmpty()
		{
		}

		private void OnItemRemoved(GameObject removedGo)
		{
			UIFollowItem uIFollowItem = items.Find((UIFollowItem x) => x.worldObject == removedGo);
			if (uIFollowItem != null)
			{
				Object.Destroy(uIFollowItem.UI);
				items.Remove(uIFollowItem);
			}
		}

		private void OnItemAdded(GameObject worldObject)
		{
			GameObject gameObject = Object.Instantiate(ItemUI);
			gameObject.name = "Icon - " + worldObject.name;
			gameObject.SetActive(value: true);
			gameObject.transform.SetParent(base.transform, worldPositionStays: false);
			items.Add(new UIFollowItem(worldObject, gameObject));
			gameObject.transform.localScale = Scale;
		}

		private void Update()
		{
			if (!cam || items.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < items.Count; i++)
			{
				Vector3 position = cam.WorldToScreenPoint(items[i].worldObject.transform.position + Offset);
				items[i].UI.transform.position = position;
				if (HideOffScreen)
				{
					items[i].UI.gameObject.SetActive(DoHideOffScreen(position));
					continue;
				}
				if (position.z < 0f)
				{
					position.y = ((!(position.y > (float)(Screen.height / 2))) ? Screen.height : 0);
				}
				items[i].UI.transform.position = new Vector3(Mathf.Clamp(position.x, 0f, Screen.width), Mathf.Clamp(position.y, 0f, Screen.height), 0f);
			}
		}

		private bool DoHideOffScreen(Vector3 position)
		{
			if (position.x < 0f || position.x > (float)Screen.width)
			{
				return false;
			}
			if (position.y < 0f || position.y > (float)Screen.height)
			{
				return false;
			}
			if (position.z < 0f)
			{
				return false;
			}
			return true;
		}
	}
}
