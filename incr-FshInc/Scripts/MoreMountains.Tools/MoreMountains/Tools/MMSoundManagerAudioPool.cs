using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MoreMountains.Tools
{
	[Serializable]
	public class MMSoundManagerAudioPool
	{
		protected List<AudioSource> _pool;

		public virtual void FillAudioSourcePool(int poolSize, Transform parent)
		{
			if (_pool == null)
			{
				_pool = new List<AudioSource>();
			}
			if (poolSize <= 0 || _pool.Count >= poolSize)
			{
				return;
			}
			foreach (AudioSource item in _pool)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < poolSize; i++)
			{
				AddOneObjectToThePool(i, parent, active: false);
			}
		}

		public virtual IEnumerator AutoDisableAudioSource(float duration, AudioSource source, AudioClip clip, bool doNotAutoRecycleIfNotDonePlaying, float playbackTime, float playbackDuration)
		{
			if (clip != null)
			{
				while (source.time == 0f && source.isPlaying)
				{
					yield return null;
				}
			}
			if (source.resource != null)
			{
				while (source.isPlaying)
				{
					yield return null;
				}
			}
			float seconds = ((playbackDuration > 0f) ? playbackDuration : duration);
			yield return MMCoroutine.WaitForUnscaled(seconds);
			if (clip != null && source.clip != clip)
			{
				yield break;
			}
			if (doNotAutoRecycleIfNotDonePlaying)
			{
				float maxTime = ((!(clip != null)) ? (playbackTime + playbackDuration) : ((playbackDuration > 0f) ? (playbackTime + playbackDuration) : source.clip.length));
				if (clip != null)
				{
					while (source.time != 0f && source.time <= maxTime)
					{
						yield return null;
					}
				}
				if (source.resource != null)
				{
					while (source.isPlaying)
					{
						yield return null;
					}
				}
			}
			source.gameObject.SetActive(value: false);
		}

		public virtual AudioSource GetAvailableAudioSource(bool poolCanExpand, Transform parent)
		{
			foreach (AudioSource item in _pool)
			{
				if (!item.gameObject.activeInHierarchy)
				{
					item.gameObject.SetActive(value: true);
					return item;
				}
			}
			if (poolCanExpand)
			{
				return AddOneObjectToThePool(_pool.Count, parent, active: true);
			}
			return null;
		}

		protected virtual AudioSource AddOneObjectToThePool(int index, Transform parent, bool active)
		{
			GameObject gameObject = new GameObject("MMAudioSourcePool_" + index);
			SceneManager.MoveGameObjectToScene(gameObject.gameObject, parent.gameObject.scene);
			AudioSource audioSource = gameObject.AddComponent<AudioSource>();
			MMFollowTarget mMFollowTarget = gameObject.AddComponent<MMFollowTarget>();
			mMFollowTarget.enabled = false;
			mMFollowTarget.DisableSelfOnSetActiveFalse = true;
			gameObject.transform.SetParent(parent);
			gameObject.SetActive(active);
			_pool.Add(audioSource);
			return audioSource;
		}

		public virtual bool FreeSound(AudioSource sourceToStop)
		{
			foreach (AudioSource item in _pool)
			{
				if (item == sourceToStop)
				{
					item.Stop();
					item.gameObject.SetActive(value: false);
					return true;
				}
			}
			return false;
		}
	}
}
