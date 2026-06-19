using System.Collections.Generic;
using DG.Tweening;
using FMODUnity;
using UnityEngine;

namespace OUSystems.Basics.Audio
{
	public static class AudioOneshotExtensions
	{
		public static void PlayOneshot(this EventReference eventReference, Vector3 position = default(Vector3))
		{
		}

		public static void PlayOneshot(this EventReference eventReference, float volume = 1f, List<KeyValuePair<string, float>> parameters = null, Vector3 position = default(Vector3))
		{
		}

		public static void PlayOneshot(this EventReference eventReference, float volume = 1f, string parameter = null, float parameterValue = 0f, Vector3 position = default(Vector3))
		{
		}

		public static bool TryPlayOneshot(this EventReference eventReference, Vector3 position = default(Vector3))
		{
			return false;
		}

		public static Tween FadeVolume(this StudioEventEmitter emitter, float volume, float transitionTime)
		{
			return null;
		}

		public static Tween FadeVolume(this CustomEventEmitter emitter, float volume, float transitionTime)
		{
			return null;
		}
	}
}
