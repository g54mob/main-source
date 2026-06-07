using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamingIsLove.Footsteps
{
	[Serializable]
	public class FootstepEffect
	{
		[Header("Walk (Fallback: Run > Sprint)")]
		[Tooltip("Audio clips used at walking speed.\nIf no clips are defined (i.e. size 0), uses run and sprint clips as fallback (in that order).")]
		public List<AudioClip> walkAudioClips = new List<AudioClip>();

		[Tooltip("Prefabs used at walking speed.\nIf no prefabs are defined (i.e. size 0), uses run and sprint prefabs as fallback (in that order).")]
		public List<FootstepPrefab> walkPrefabs = new List<FootstepPrefab>();

		[Header("Run (Fallback: Walk > Sprint)")]
		[Tooltip("Audio clips used at running speed.\nIf no clips are defined (i.e. size 0), uses walk and sprint clips as fallback (in that order).")]
		public List<AudioClip> runAudioClips = new List<AudioClip>();

		[Tooltip("Prefabs used at running speed.\nIf no prefabs are defined (i.e. size 0), uses walk and sprint prefabs as fallback (in that order).")]
		public List<FootstepPrefab> runPrefabs = new List<FootstepPrefab>();

		[Header("Sprint (Fallback: Run > Walk)")]
		[Tooltip("Audio clips used at sprinting speed.\nIf no clips are defined (i.e. size 0), uses run and walk clips as fallback (in that order).")]
		public List<AudioClip> sprintAudioClips = new List<AudioClip>();

		[Tooltip("Prefabs used at sprinting speed.\nIf no prefabs are defined (i.e. size 0), uses run and walk prefabs as fallback (in that order).")]
		public List<FootstepPrefab> sprintPrefabs = new List<FootstepPrefab>();

		[Header("Jump")]
		[Tooltip("Audio clips used on jumping.")]
		public List<AudioClip> jumpAudioClips = new List<AudioClip>();

		[Tooltip("Prefabs used on jumping.")]
		public List<FootstepPrefab> jumpPrefabs = new List<FootstepPrefab>();

		[Header("Land")]
		[Tooltip("Audio clips used on landing.")]
		public List<AudioClip> landAudioClips = new List<AudioClip>();

		[Tooltip("Prefabs used on landing.")]
		public List<FootstepPrefab> landPrefabs = new List<FootstepPrefab>();

		[Header("Custom Effects")]
		[Tooltip("Custom footstep effects can be played by using a matching custom effect name.")]
		public List<FootstepCustomEffect> customEffects = new List<FootstepCustomEffect>();

		public virtual AudioClip GetClip(FootstepType type, string customName)
		{
			if (FootstepType.Walk == type)
			{
				if (walkAudioClips.Count > 0)
				{
					return walkAudioClips[UnityEngine.Random.Range(0, walkAudioClips.Count - 1)];
				}
				if (runAudioClips.Count > 0)
				{
					return runAudioClips[UnityEngine.Random.Range(0, runAudioClips.Count - 1)];
				}
				if (sprintAudioClips.Count > 0)
				{
					return sprintAudioClips[UnityEngine.Random.Range(0, sprintAudioClips.Count - 1)];
				}
			}
			else if (FootstepType.Run == type)
			{
				if (runAudioClips.Count > 0)
				{
					return runAudioClips[UnityEngine.Random.Range(0, runAudioClips.Count - 1)];
				}
				if (walkAudioClips.Count > 0)
				{
					return walkAudioClips[UnityEngine.Random.Range(0, walkAudioClips.Count - 1)];
				}
				if (sprintAudioClips.Count > 0)
				{
					return sprintAudioClips[UnityEngine.Random.Range(0, sprintAudioClips.Count - 1)];
				}
			}
			else if (FootstepType.Sprint == type)
			{
				if (sprintAudioClips.Count > 0)
				{
					return sprintAudioClips[UnityEngine.Random.Range(0, sprintAudioClips.Count - 1)];
				}
				if (runAudioClips.Count > 0)
				{
					return runAudioClips[UnityEngine.Random.Range(0, runAudioClips.Count - 1)];
				}
				if (walkAudioClips.Count > 0)
				{
					return walkAudioClips[UnityEngine.Random.Range(0, walkAudioClips.Count - 1)];
				}
			}
			else if (FootstepType.Jump == type)
			{
				if (jumpAudioClips.Count > 0)
				{
					return jumpAudioClips[UnityEngine.Random.Range(0, jumpAudioClips.Count - 1)];
				}
			}
			else if (FootstepType.Land == type)
			{
				if (landAudioClips.Count > 0)
				{
					return landAudioClips[UnityEngine.Random.Range(0, landAudioClips.Count - 1)];
				}
			}
			else if (FootstepType.Custom == type && customEffects.Count > 0)
			{
				for (int i = 0; i < customEffects.Count; i++)
				{
					if (customEffects[i].customName == customName)
					{
						return customEffects[i].GetClip();
					}
				}
			}
			return null;
		}

		public virtual FootstepPrefab GetPrefab(FootstepType type, string customName)
		{
			if (FootstepType.Walk == type)
			{
				if (walkPrefabs.Count > 0)
				{
					return walkPrefabs[UnityEngine.Random.Range(0, walkPrefabs.Count - 1)];
				}
				if (runPrefabs.Count > 0)
				{
					return runPrefabs[UnityEngine.Random.Range(0, runPrefabs.Count - 1)];
				}
				if (sprintPrefabs.Count > 0)
				{
					return sprintPrefabs[UnityEngine.Random.Range(0, sprintPrefabs.Count - 1)];
				}
			}
			else if (FootstepType.Run == type)
			{
				if (runPrefabs.Count > 0)
				{
					return runPrefabs[UnityEngine.Random.Range(0, runPrefabs.Count - 1)];
				}
				if (walkPrefabs.Count > 0)
				{
					return walkPrefabs[UnityEngine.Random.Range(0, walkPrefabs.Count - 1)];
				}
				if (sprintPrefabs.Count > 0)
				{
					return sprintPrefabs[UnityEngine.Random.Range(0, sprintPrefabs.Count - 1)];
				}
			}
			else if (FootstepType.Sprint == type)
			{
				if (sprintPrefabs.Count > 0)
				{
					return sprintPrefabs[UnityEngine.Random.Range(0, sprintPrefabs.Count - 1)];
				}
				if (runPrefabs.Count > 0)
				{
					return runPrefabs[UnityEngine.Random.Range(0, runPrefabs.Count - 1)];
				}
				if (walkPrefabs.Count > 0)
				{
					return walkPrefabs[UnityEngine.Random.Range(0, walkPrefabs.Count - 1)];
				}
			}
			else if (FootstepType.Jump == type)
			{
				if (jumpPrefabs.Count > 0)
				{
					return jumpPrefabs[UnityEngine.Random.Range(0, jumpPrefabs.Count - 1)];
				}
			}
			else if (FootstepType.Land == type)
			{
				if (landPrefabs.Count > 0)
				{
					return landPrefabs[UnityEngine.Random.Range(0, landPrefabs.Count - 1)];
				}
			}
			else if (FootstepType.Custom == type && customEffects.Count > 0)
			{
				for (int i = 0; i < customEffects.Count; i++)
				{
					if (customEffects[i].customName == customName)
					{
						return customEffects[i].GetPrefab();
					}
				}
			}
			return null;
		}
	}
}
