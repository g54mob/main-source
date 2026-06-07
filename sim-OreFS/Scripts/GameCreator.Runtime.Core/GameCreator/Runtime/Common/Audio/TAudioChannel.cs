using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;

namespace GameCreator.Runtime.Common.Audio
{
	public abstract class TAudioChannel : IAudioChannel
	{
		private const int ALLOCATE_BUFFER_BLOCK = 3;

		private readonly Transform m_Parent;

		private readonly Queue<AudioBuffer> m_AvailableBuffers = new Queue<AudioBuffer>();

		private readonly List<AudioBuffer> m_ActiveBuffers = new List<AudioBuffer>();

		private readonly Dictionary<int, int> m_AudioFrame = new Dictionary<int, int>();

		protected abstract float Volume { get; }

		protected abstract AudioMixerGroup AudioOutput { get; }

		protected TAudioChannel(Transform parent)
		{
			m_Parent = parent;
		}

		internal void Update()
		{
			for (int num = m_ActiveBuffers.Count - 1; num >= 0; num--)
			{
				AudioBuffer audioBuffer = m_ActiveBuffers[num];
				if (!audioBuffer.Update(Singleton<AudioManager>.Instance.Volume.CurrentMaster * Volume))
				{
					m_ActiveBuffers.RemoveAt(num);
					m_AvailableBuffers.Enqueue(audioBuffer);
				}
			}
		}

		public bool IsPlaying(AudioClip audioClip)
		{
			if (audioClip == null)
			{
				return false;
			}
			foreach (AudioBuffer activeBuffer in m_ActiveBuffers)
			{
				if (activeBuffer.AudioClip == audioClip)
				{
					return true;
				}
			}
			return false;
		}

		public bool IsPlaying(GameObject target)
		{
			if (target == null)
			{
				return false;
			}
			foreach (AudioBuffer activeBuffer in m_ActiveBuffers)
			{
				if (activeBuffer.Target == target)
				{
					return true;
				}
			}
			return false;
		}

		public bool IsPlaying(AudioClip audioClip, GameObject target)
		{
			if (target == null)
			{
				return false;
			}
			if (audioClip == null)
			{
				return false;
			}
			foreach (AudioBuffer activeBuffer in m_ActiveBuffers)
			{
				if (activeBuffer.Target == target && activeBuffer.AudioClip == audioClip)
				{
					return true;
				}
			}
			return false;
		}

		public void ChangePitch(AudioClip audioClip, GameObject target, float pitch)
		{
			if (target == null || audioClip == null)
			{
				return;
			}
			foreach (AudioBuffer activeBuffer in m_ActiveBuffers)
			{
				if (!(activeBuffer.Target != target) && !(activeBuffer.AudioClip != audioClip))
				{
					activeBuffer.Pitch = pitch;
				}
			}
		}

		public async Task Play(AudioClip audioClip, IAudioConfig audioConfig, Args args)
		{
			if (!(audioClip == null) && (!m_AudioFrame.TryGetValue(audioClip.GetHashCode(), out var value) || value != Time.frameCount))
			{
				if (m_AvailableBuffers.Count == 0)
				{
					AllocateAudioBuffers();
				}
				AudioBuffer audioBuffer = m_AvailableBuffers.Dequeue();
				m_ActiveBuffers.Add(audioBuffer);
				m_AudioFrame[audioBuffer.GetHashCode()] = Time.frameCount;
				await audioBuffer.Play(audioClip, audioConfig, args);
			}
		}

		public async Task Stop(AudioClip audioClip, float transitionOut)
		{
			if (audioClip == null)
			{
				return;
			}
			List<Task> list = new List<Task>();
			foreach (AudioBuffer activeBuffer in m_ActiveBuffers)
			{
				if (!(activeBuffer.AudioClip != audioClip))
				{
					list.Add(activeBuffer.Stop(transitionOut));
				}
			}
			await Task.WhenAll(list);
		}

		public async Task Stop(GameObject target, float transitionOut)
		{
			if (target == null)
			{
				return;
			}
			List<Task> list = new List<Task>();
			foreach (AudioBuffer activeBuffer in m_ActiveBuffers)
			{
				if (!(activeBuffer.Target != target))
				{
					list.Add(activeBuffer.Stop(transitionOut));
				}
			}
			await Task.WhenAll(list);
		}

		public async Task Stop(AudioClip audioClip, GameObject target, float transitionOut)
		{
			if (audioClip == null || target == null)
			{
				return;
			}
			List<Task> list = new List<Task>();
			foreach (AudioBuffer activeBuffer in m_ActiveBuffers)
			{
				if (!(activeBuffer.Target != target) && !(activeBuffer.AudioClip != audioClip))
				{
					list.Add(activeBuffer.Stop(transitionOut));
				}
			}
			await Task.WhenAll(list);
		}

		public async Task StopAll(float transition)
		{
			List<Task> list = new List<Task>();
			foreach (AudioBuffer activeBuffer in m_ActiveBuffers)
			{
				list.Add(activeBuffer.Stop(transition));
			}
			await Task.WhenAll(list);
		}

		private void AllocateAudioBuffers()
		{
			for (int i = 0; i < 3; i++)
			{
				AudioBuffer item = MakeAudioBuffer();
				m_AvailableBuffers.Enqueue(item);
			}
		}

		protected virtual AudioBuffer MakeAudioBuffer()
		{
			return new AudioBuffer(m_Parent, AudioOutput);
		}
	}
}
