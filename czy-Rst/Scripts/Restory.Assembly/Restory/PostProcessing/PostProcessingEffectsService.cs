using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

namespace Restory.PostProcessing
{
	public class PostProcessingEffectsService : MonoBehaviour
	{
		[Serializable]
		public class Entry
		{
			public PostProcessingEffectType Effect;

			public GameObject Prefab;

			[HideInInspector]
			public Volume Instance;

			[HideInInspector]
			public Tween Tween;

			public bool IsActive;
		}

		[SerializeField]
		private Entry[] entries;

		private void Awake()
		{
			for (int i = 0; i < entries.Length; i++)
			{
				for (int j = 0; j < entries.Length; j++)
				{
					if (i != j && entries[i].Effect == entries[j].Effect)
					{
						Debug.LogError($"[{this}] contains several entries with effect [{entries[i].Effect}], which is not supported!");
					}
				}
			}
			Entry[] array = entries;
			foreach (Entry obj in array)
			{
				obj.Instance = UnityEngine.Object.Instantiate(obj.Prefab, base.transform).GetComponent<Volume>();
				obj.Instance.weight = 0f;
				obj.IsActive = false;
			}
		}

		public void TurnOnEffectAnimated(PostProcessingEffectType effect, float duration)
		{
			Entry[] array = entries;
			foreach (Entry entry in array)
			{
				if (entry.Effect == effect)
				{
					if (entry.IsActive)
					{
						Debug.Log($"IAF Warning: [{this}] tried to turn on an effect [{effect}], but it is already active!", entry.Instance.gameObject);
						return;
					}
					entry.IsActive = true;
					LaunchTween(entry, 1f, duration);
					return;
				}
			}
			Debug.LogError($"IAF Error: [{this}] tried to turn on an effect [{effect}], but it has no corresponding entry!");
		}

		public void TurnOffEffectAnimated(PostProcessingEffectType effect, float duration)
		{
			Entry[] array = entries;
			foreach (Entry entry in array)
			{
				if (entry.Effect == effect)
				{
					if (!entry.IsActive)
					{
						Debug.Log($"IAF Warning: [{this}] tried to turn off an effect [{effect}], but it is already inactive!", entry.Instance.gameObject);
						return;
					}
					entry.IsActive = false;
					LaunchTween(entry, 0f, duration);
					return;
				}
			}
			Debug.LogError($"IAF Error: [{this}] tried to turn off an effect [{effect}], but it has no corresponding entry!");
		}

		private static void LaunchTween(Entry entry, float finalEffectWeightValue, float duration)
		{
			if (entry.Tween.IsActive())
			{
				entry.Tween.Kill();
			}
			entry.Tween = DOTween.To(() => entry.Instance.weight, delegate(float value)
			{
				entry.Instance.weight = Mathf.Clamp01(value);
			}, finalEffectWeightValue, duration).SetUpdate(UpdateType.Normal, isIndependentUpdate: true).OnKill(delegate
			{
				entry.Instance.weight = finalEffectWeightValue;
			});
		}
	}
}
