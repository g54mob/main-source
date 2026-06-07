using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkTonic.MasterAudio
{
	public static class AudioTransformExtensions
	{
		public static void FadeOutSoundGroupOfTransform(this Transform sourceTrans, string sType, float fadeTime)
		{
		}

		public static List<SoundGroupVariation> GetAllPlayingVariationsOfTransform(this Transform sourceTrans)
		{
			return null;
		}

		public static bool PlaySound3DAtTransformAndForget(this Transform sourceTrans, string sType, float volumePercentage = 1f, float? pitch = null, float delaySoundTime = 0f, string variationName = null)
		{
			return false;
		}

		public static PlaySoundResult PlaySound3DAtTransform(this Transform sourceTrans, string sType, float volumePercentage = 1f, float? pitch = null, float delaySoundTime = 0f, string variationName = null)
		{
			return null;
		}

		public static bool PlaySound3DFollowTransformAndForget(this Transform sourceTrans, string sType, float volumePercentage = 1f, float? pitch = null, float delaySoundTime = 0f, string variationName = null)
		{
			return false;
		}

		public static PlaySoundResult PlaySound3DFollowTransform(this Transform sourceTrans, string sType, float volumePercentage = 1f, float? pitch = null, float delaySoundTime = 0f, string variationName = null)
		{
			return null;
		}

		public static IEnumerator PlaySound3DAtTransformAndWaitUntilFinished(this Transform sourceTrans, string sType, float volumePercentage = 1f, float? pitch = null, float delaySoundTime = 0f, string variationName = null, double? timeToSchedulePlay = null, Action completedAction = null)
		{
			return null;
		}

		public static IEnumerator PlaySound3DFollowTransformAndWaitUntilFinished(this Transform sourceTrans, string sType, float volumePercentage = 1f, float? pitch = null, float delaySoundTime = 0f, string variationName = null, double? timeToSchedulePlay = null, Action completedAction = null)
		{
			return null;
		}

		public static void PauseAllSoundsOfTransform(Transform sourceTrans)
		{
		}

		public static void PauseBusOfTransform(this Transform sourceTrans, string busName)
		{
		}

		public static void PauseSoundGroupOfTransform(this Transform sourceTrans, string sType)
		{
		}

		public static void StopAllSoundsOfTransform(this Transform sourceTrans)
		{
		}

		public static void StopBusOfTransform(this Transform sourceTrans, string busName)
		{
		}

		public static void StopSoundGroupOfTransform(this Transform sourceTrans, string sType)
		{
		}

		public static void UnpauseAllSoundsOfTransform(this Transform sourceTrans)
		{
		}

		public static void UnpauseBusOfTransform(this Transform sourceTrans, string busName)
		{
		}

		public static void UnpauseSoundGroupOfTransform(this Transform sourceTrans, string sType)
		{
		}

		public static bool IsTransformPlayingSoundGroup(this Transform sourceTrans, string sType)
		{
			return false;
		}
	}
}
