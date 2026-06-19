#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class AnimationSFXLoopMaintainer : MonoBehaviour
	{
		private struct ActiveAudioLoop
		{
			public string AudioEventName;

			public AudioEmitter AudioEmmitter;

			public AnimationClip AnimationClip;
		}

		private readonly List<ActiveAudioLoop> _audioLoops = new List<ActiveAudioLoop>(8);

		private readonly List<AnimatorClipInfo> _animatorClipInfoCache = new List<AnimatorClipInfo>(8);

		private readonly List<AnimatorClipInfo> _animatorNextClipInfoCache = new List<AnimatorClipInfo>(8);

		private readonly List<string> _clipsToRemoveCache = new List<string>(8);

		private readonly List<string> _clipsPlayingCache = new List<string>(8);

		private Animator _animator;

		protected void Start()
		{
			_animator = GetComponent<Animator>();
		}

		protected void Update()
		{
			_clipsToRemoveCache.Clear();
			_clipsPlayingCache.Clear();
			int layerCount = _animator.layerCount;
			for (int i = 0; i < layerCount; i++)
			{
				_animatorClipInfoCache.Clear();
				_animator.GetCurrentAnimatorClipInfo(i, _animatorClipInfoCache);
				_animatorNextClipInfoCache.Clear();
				_animator.GetNextAnimatorClipInfo(i, _animatorNextClipInfoCache);
				foreach (ActiveAudioLoop audioLoop in _audioLoops)
				{
					bool flag = false;
					foreach (AnimatorClipInfo item in _animatorClipInfoCache)
					{
						if (audioLoop.AnimationClip == item.clip)
						{
							flag = true;
							break;
						}
					}
					foreach (AnimatorClipInfo item2 in _animatorNextClipInfoCache)
					{
						if (audioLoop.AnimationClip == item2.clip)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						_clipsPlayingCache.Add(audioLoop.AudioEventName);
					}
				}
			}
			foreach (ActiveAudioLoop audioLoop2 in _audioLoops)
			{
				bool flag2 = false;
				foreach (string item3 in _clipsPlayingCache)
				{
					if (audioLoop2.AudioEventName == item3)
					{
						flag2 = true;
					}
				}
				if (!flag2)
				{
					Logging.Info("No anim clip playing for event {0}, stopping emitter", audioLoop2.AudioEventName);
					if (AudioManager.Instance != null)
					{
						AudioManager.Instance.Stop(audioLoop2.AudioEmmitter);
					}
					_clipsToRemoveCache.Add(audioLoop2.AudioEventName);
				}
			}
			foreach (string item4 in _clipsToRemoveCache)
			{
				RemoveActiveAudioLoop(item4);
			}
		}

		private bool IsAudioLoopActive(string audioEventName)
		{
			foreach (ActiveAudioLoop audioLoop in _audioLoops)
			{
				if (audioLoop.AudioEventName == audioEventName)
				{
					return true;
				}
			}
			return false;
		}

		private bool RemoveActiveAudioLoop(string audioEventName)
		{
			for (int i = 0; i < _audioLoops.Count; i++)
			{
				if (_audioLoops[i].AudioEventName == audioEventName)
				{
					Logging.Info("{0} audio loop removed (RemoveActiveAudioLoop)", audioEventName);
					_audioLoops.RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		private bool FindAndRemoveActiveAudioLoop(string audioEventName, out ActiveAudioLoop activeAudioLoop)
		{
			for (int i = 0; i < _audioLoops.Count; i++)
			{
				ActiveAudioLoop activeAudioLoop2 = _audioLoops[i];
				if (activeAudioLoop2.AudioEventName == audioEventName)
				{
					activeAudioLoop = activeAudioLoop2;
					_audioLoops.RemoveAt(i);
					return true;
				}
			}
			activeAudioLoop = default(ActiveAudioLoop);
			return false;
		}

		public void BeginAudioLoopMaintainer(string audioEventName, AnimationClip animationClip)
		{
			if (AudioManager.Instance != null)
			{
				if (!IsAudioLoopActive(audioEventName))
				{
					AudioEmitter audioEmitter = AudioManager.Instance.Play(audioEventName, base.gameObject);
					if (audioEmitter != null)
					{
						_audioLoops.Add(new ActiveAudioLoop
						{
							AudioEventName = audioEventName,
							AudioEmmitter = audioEmitter,
							AnimationClip = animationClip
						});
					}
					else
					{
						Logging.Warning(LogChannels.Animation, "Can't find audio event '{0}' on {1}", audioEventName, base.transform.gameObject.name);
					}
				}
				else
				{
					Logging.Warning(LogChannels.Animation, "Can't start audio loop '{0}' on {1} because it is already playing", audioEventName, base.transform.gameObject.name);
				}
			}
			if (_audioLoops.Count > 0)
			{
				base.enabled = true;
			}
		}

		public void EndAudioLoopMaintainer(string audioEventName)
		{
			if (AudioManager.Instance != null)
			{
				if (FindAndRemoveActiveAudioLoop(audioEventName, out var activeAudioLoop))
				{
					Logging.Info("{0} audio loop stopped", audioEventName);
					AudioManager.Instance.Stop(activeAudioLoop.AudioEmmitter);
				}
				else
				{
					Logging.Warning(LogChannels.Animation, "Can't end audio loop '{0}' on {1} because it isnt playing", audioEventName, base.gameObject.name);
				}
			}
			if (_audioLoops.Count == 0)
			{
				base.enabled = false;
			}
		}

		public void EndAllAudioLoops()
		{
			foreach (ActiveAudioLoop audioLoop in _audioLoops)
			{
				Logging.Info("{0} audio loop stopped", audioLoop.AudioEventName);
				AudioManager.Instance.Stop(audioLoop.AudioEmmitter);
			}
			_audioLoops.Clear();
		}
	}
}
