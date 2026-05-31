using System.Collections;
using UnityEngine;

namespace CTS
{
	public static class AnimationExtension
	{
		public static IEnumerator Play(this Animation animation, string clipName, bool useTimeScale)
		{
			Debug.Log("Overwritten Play animation, useTimeScale? " + useTimeScale);
			if (!useTimeScale)
			{
				Debug.Log("Started this animation! ( " + clipName + " ) ");
				AnimationState _currState = animation[clipName];
				bool isPlaying = true;
				float _progressTime = 0f;
				animation.Play(clipName);
				float _timeAtLastFrame = Time.realtimeSinceStartup;
				while (isPlaying)
				{
					float realtimeSinceStartup = Time.realtimeSinceStartup;
					float num = realtimeSinceStartup - _timeAtLastFrame;
					_timeAtLastFrame = realtimeSinceStartup;
					_progressTime += num;
					_currState.normalizedTime = _progressTime / _currState.length;
					animation.Sample();
					if (_progressTime >= _currState.length)
					{
						if (_currState.wrapMode != WrapMode.Loop)
						{
							isPlaying = false;
						}
						else
						{
							_progressTime = 0f;
						}
					}
					yield return new WaitForEndOfFrame();
				}
				yield return null;
			}
			else
			{
				animation.Play(clipName);
			}
		}
	}
}
