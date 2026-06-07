using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MalbersAnimations.UI
{
	[DefaultExecutionOrder(501)]
	public class StatMonitorUI : MonoBehaviour
	{
		public class StatUI
		{
			public Slider slider;

			public Stat stat;

			public Transform followTransform;

			public float lastValue;

			public UnityAction<float> OnStatValueChange = delegate
			{
			};
		}

		[Tooltip("Runtime Set that store all the Stat you want to monitor")]
		[RequiredField]
		public RuntimeStats Set;

		[Tooltip("Slider used to Represet the Stat on the UI")]
		[RequiredField]
		public Slider UIPrefab;

		[Tooltip("What stat inside the Stat Manager you want to monitor")]
		public StatID statID;

		[Tooltip("Reference for the Camera")]
		public TransformReference Camera;

		[Tooltip("Find a bone inside the Hierarchy of the Stat Manager")]
		public string FollowTransform = "Head";

		[Tooltip("Use the Normalize value of the Stat")]
		public bool Normalized = true;

		[Tooltip("When the Stat is Empty, Stop Monitoring it")]
		public bool RemoveOnEmpty = true;

		[Tooltip("Offset to Position the Slider UI on the screen")]
		public Vector3 Offset = Vector3.zero;

		[Tooltip("Scale of the Instantiated prefab")]
		public Vector3 Scale = Vector3.one;

		private List<StatUI> TrackedStats;

		private Camera MainCamera;

		private void Awake()
		{
			TrackedStats = new List<StatUI>();
			Set.Clear();
			if (Camera.Value != null)
			{
				MainCamera = Camera.Value.GetComponent<Camera>();
				return;
			}
			MainCamera = MTools.FindMainCamera();
			Camera.Value = MainCamera.transform;
		}

		private void OnEnable()
		{
			Set.OnItemAdded.AddListener(OnAddedStat);
			Set.OnItemRemoved.AddListener(OnRemovedStat);
		}

		private void OnDisable()
		{
			Set.OnItemAdded.RemoveListener(OnAddedStat);
			Set.OnItemRemoved.RemoveListener(OnRemovedStat);
		}

		private void OnAddedStat(Stats stats)
		{
			Stat stat = stats.Stat_Get(statID);
			if ((stat != null && !stat.Active) || stat.IsEmpty)
			{
				return;
			}
			StatUI item = new StatUI();
			item.stat = stats.Stat_Get(statID);
			Transform transform = stats.transform.FindGrandChild(FollowTransform);
			item.followTransform = ((transform != null) ? transform : stats.transform);
			item.slider = Object.Instantiate(UIPrefab, base.transform);
			item.slider.transform.localScale = Scale;
			item.slider.name = item.slider.name.Replace("(Clone)", "_");
			item.slider.name += stats.gameObject.name;
			item.lastValue = stat.Value;
			item.OnStatValueChange = delegate
			{
				item.slider.value = (Normalized ? item.stat.NormalizedValue : item.stat.Value);
				if (RemoveOnEmpty && item.stat.Value == item.stat.MinValue)
				{
					RemoveFromGroup(item);
				}
			};
			item.slider.value = (Normalized ? item.stat.NormalizedValue : item.stat.Value);
			item.stat.OnValueChange.AddListener(item.OnStatValueChange);
			TrackedStats.Add(item);
		}

		private void OnRemovedStat(Stats stats)
		{
			StatUI statUI = TrackedStats.Find((StatUI x) => x.stat.Owner == stats);
			if (statUI != null)
			{
				RemoveFromGroup(statUI);
			}
		}

		private void RemoveFromGroup(StatUI item)
		{
			item.stat.OnValueChange.RemoveListener(item.OnStatValueChange);
			item.OnStatValueChange = null;
			Object.Destroy(item.slider.gameObject);
			TrackedStats.Remove(item);
			Set.Item_Remove(item.stat.Owner);
		}

		private void LateUpdate()
		{
			TrackStatsWord();
		}

		private void TrackStatsWord()
		{
			if (MainCamera == null)
			{
				return;
			}
			foreach (StatUI trackedStat in TrackedStats)
			{
				if ((bool)trackedStat.followTransform)
				{
					Vector3 position = MainCamera.WorldToScreenPoint(trackedStat.followTransform.position + Offset);
					trackedStat.slider.transform.position = position;
					trackedStat.slider.gameObject.SetActive(DoHideOffScreen(position));
				}
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
