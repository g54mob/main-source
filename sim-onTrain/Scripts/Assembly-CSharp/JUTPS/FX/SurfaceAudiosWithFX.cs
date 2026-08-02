using System;
using System.Collections.Generic;
using UnityEngine;

namespace JUTPS.FX
{
	[Serializable]
	public class SurfaceAudiosWithFX
	{
		public string SurfaceTag;

		public List<AudioClip> AudioClips = new List<AudioClip>(4);

		public List<GameObject> Effects = new List<GameObject>(4);

		public SurfaceAudiosWithFX(string tagName = "Skin")
		{
			SurfaceTag = tagName;
		}

		public static void PlayRandomAudioFX(AudioSource audioSource, List<SurfaceAudiosWithFX> SurfaceAudioClips, string surfaceTag = "Untagged")
		{
			bool flag = false;
			for (int i = 0; i < SurfaceAudioClips.Count; i++)
			{
				if (SurfaceAudioClips[i].SurfaceTag == surfaceTag)
				{
					audioSource.PlayOneShot(SurfaceAudioClips[i].AudioClips[UnityEngine.Random.Range(0, SurfaceAudioClips[i].AudioClips.Count)]);
					return;
				}
			}
			if (!flag)
			{
				audioSource.PlayOneShot(SurfaceAudioClips[0].AudioClips[UnityEngine.Random.Range(0, SurfaceAudioClips[0].AudioClips.Count)]);
			}
		}

		public static GameObject SpawnRandomFX(List<SurfaceAudiosWithFX> SurfaceAudioClips, Vector3 FXPosition, Quaternion FXRotation = default(Quaternion), string surfaceTag = "Untagged", float timeToDestroy = 5f, bool HideInHierarchy = true)
		{
			bool flag = false;
			for (int i = 0; i < SurfaceAudioClips.Count; i++)
			{
				if (SurfaceAudioClips[i].SurfaceTag == surfaceTag && SurfaceAudioClips[i].Effects.Count > 0)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(SurfaceAudioClips[i].Effects[UnityEngine.Random.Range(0, SurfaceAudioClips[i].Effects.Count)], FXPosition, FXRotation);
					if (HideInHierarchy)
					{
						gameObject.hideFlags = HideFlags.HideInHierarchy;
					}
					UnityEngine.Object.Destroy(gameObject, timeToDestroy);
					return gameObject;
				}
			}
			if (!flag)
			{
				if (SurfaceAudioClips[0].Effects.Count > 0)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate(SurfaceAudioClips[0].Effects[UnityEngine.Random.Range(0, SurfaceAudioClips[0].Effects.Count)], FXPosition, FXRotation);
					if (HideInHierarchy)
					{
						gameObject2.hideFlags = HideFlags.HideInHierarchy;
					}
					UnityEngine.Object.Destroy(gameObject2, timeToDestroy);
					return gameObject2;
				}
				return null;
			}
			return null;
		}

		public static GameObject Play(AudioSource audioSource, List<SurfaceAudiosWithFX> SurfaceAudioClips, Vector3 FXPosition, Quaternion FXRotation = default(Quaternion), Transform Parent = null, string surfaceTag = "Untagged", float timeToDestroy = 5f, bool HideInHierarchy = true)
		{
			if (SurfaceAudioClips.Count == 0 || audioSource == null)
			{
				return null;
			}
			bool flag = false;
			for (int i = 0; i < SurfaceAudioClips.Count; i++)
			{
				if (!(SurfaceAudioClips[i].SurfaceTag == surfaceTag))
				{
					continue;
				}
				audioSource.PlayOneShot(SurfaceAudioClips[i].AudioClips[UnityEngine.Random.Range(0, SurfaceAudioClips[i].AudioClips.Count)]);
				if (SurfaceAudioClips[i].Effects.Count > 0)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(SurfaceAudioClips[i].Effects[UnityEngine.Random.Range(0, SurfaceAudioClips[i].Effects.Count)], FXPosition, FXRotation);
					gameObject.transform.SetParent(Parent);
					if (HideInHierarchy)
					{
						gameObject.hideFlags = HideFlags.HideInHierarchy;
					}
					UnityEngine.Object.Destroy(gameObject, timeToDestroy);
					flag = true;
					return gameObject;
				}
				return null;
			}
			if (!flag)
			{
				audioSource.PlayOneShot(SurfaceAudioClips[0].AudioClips[UnityEngine.Random.Range(0, SurfaceAudioClips[0].AudioClips.Count)]);
				if (SurfaceAudioClips[0].Effects.Count > 0)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate(SurfaceAudioClips[0].Effects[UnityEngine.Random.Range(0, SurfaceAudioClips[0].Effects.Count)], FXPosition, FXRotation);
					gameObject2.transform.SetParent(Parent);
					if (HideInHierarchy)
					{
						gameObject2.hideFlags = HideFlags.HideInHierarchy;
					}
					UnityEngine.Object.Destroy(gameObject2, timeToDestroy);
					return gameObject2;
				}
				return null;
			}
			return null;
		}
	}
}
