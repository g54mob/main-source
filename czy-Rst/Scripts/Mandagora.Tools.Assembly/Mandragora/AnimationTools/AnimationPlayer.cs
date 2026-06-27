using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mandragora.AnimationTools
{
	public class AnimationPlayer
	{
		[Flags]
		public enum Mode
		{
			None = 0,
			CheckIdentity = 1,
			RandomStartFrame = 2,
			RandomAnimation = 4,
			PlayTrackList = 8,
			PlayReverseTrack = 0x10
		}

		public AnimationObject animationObject;

		public AnimationObject[] clones;

		private bool isPlaying;

		private bool isPause;

		private bool isReverse;

		public string threadName = "";

		private List<AnimationTrack> trackList = new List<AnimationTrack>();

		private string[] animationsArray;

		private Mode mode;

		private float dt;

		private Dictionary<string, Attachment> attachments = new Dictionary<string, Attachment>();

		public bool IsPlaying
		{
			get
			{
				if (isPlaying)
				{
					return !isPause;
				}
				return false;
			}
			private set
			{
				isPlaying = value;
			}
		}

		public string CurrentAnimationName { get; private set; }

		public string LastPlayedAnimationName { get; private set; }

		public bool Loop { get; private set; }

		public int TrackListLength
		{
			get
			{
				if (trackList == null)
				{
					return 0;
				}
				return trackList.Count;
			}
		}

		public bool IsReverse => isReverse;

		public AnimationTrack currentTrack
		{
			get
			{
				if (trackList.Count == 0)
				{
					trackList.Add(new AnimationTrack());
				}
				return trackList[trackList.Count - 1];
			}
		}

		private event OnStartEventHandler onStart;

		public event OnStartEventHandler OnStart
		{
			add
			{
				onStart -= value;
				onStart += value;
			}
			remove
			{
				onStart -= value;
			}
		}

		private event OnEndEventHandler onEnd;

		public event OnEndEventHandler OnEnd
		{
			add
			{
				onEnd -= value;
				onEnd += value;
			}
			remove
			{
				onEnd -= value;
			}
		}

		private event OnEndEventHandler onComplete;

		public event OnEndEventHandler OnComplete
		{
			add
			{
				onComplete -= value;
				onComplete += value;
			}
			remove
			{
				onComplete -= value;
			}
		}

		private event OnAnimationEvent onEvent;

		public event OnAnimationEvent OnEvent
		{
			add
			{
				onEvent -= value;
				onEvent += value;
			}
			remove
			{
				onEvent -= value;
			}
		}

		private event OnUpdateAnimation onUpdateAnimation;

		public event OnUpdateAnimation OnUpdate
		{
			add
			{
				onUpdateAnimation -= value;
				onUpdateAnimation += value;
			}
			remove
			{
				onUpdateAnimation -= value;
			}
		}

		public void SetPose(string animationName, int frameIndex)
		{
			if (string.IsNullOrEmpty(animationName))
			{
				try
				{
					currentTrack.Set(animationObject.data.dataAsset.animations[0]);
				}
				catch (Exception message)
				{
					Debug.Log(message);
				}
			}
			else
			{
				currentTrack.Set(animationObject.data.GetAnimation(animationName));
				if (currentTrack != null)
				{
					frameIndex = Mathf.Clamp(frameIndex, 0, currentTrack.animation.frames.Length - 1);
					currentTrack.CurrentFrame = frameIndex;
				}
			}
			NormalizeFrame();
		}

		public void Play(string[] animationsArray, bool loop = false, Mode mode = Mode.None)
		{
			if (!CheckIdentityMode(mode, animationsArray) && animationsArray != null)
			{
				string animationName = animationsArray[UnityEngine.Random.Range(0, animationsArray.Length)];
				this.animationsArray = animationsArray;
				this.mode = mode;
				Play(animationName, loop, mode | Mode.RandomAnimation);
			}
		}

		public void Play(string animationName, Mode mode)
		{
			Play(animationName, loop: false, mode);
		}

		public void Play(string animationName, bool loop = false, Mode mode = Mode.None)
		{
			if (animationObject != null && animationObject.editorSettings.isDebug)
			{
				Debug.Log(animationName);
			}
			if (!CheckIdentityMode(mode, animationName))
			{
				CheckRandomMode(mode);
				CheckTrackListMode(mode);
				isReverse = CheckReverseTrack(mode);
				if (AddTrack(animationName))
				{
					CurrentAnimationName = animationName;
				}
				if (currentTrack.animation != null)
				{
					IsPlaying = true;
					Loop = loop;
					dt = 0f;
				}
				CheckRandomFrameMode(mode);
				UpdateTracks(0f, threadName);
			}
		}

		public void GoToAndPlay(string animationName, int frameNumber, bool loop = false, Mode mode = Mode.None)
		{
			Play(animationName, loop, mode);
			currentTrack.CurrentFrame = Mathf.Clamp(frameNumber, 0, currentTrack.animation.frames.Length - 1);
		}

		public void GoToAndPause(string animationName, int frameNumber, bool loop = false, Mode mode = Mode.None)
		{
			GoToAndPlay(animationName, frameNumber, loop, mode);
			Pause();
		}

		private void CheckRandomMode(Mode mode)
		{
			if ((mode & Mode.RandomAnimation) != Mode.RandomAnimation && (this.mode & Mode.RandomAnimation) == Mode.RandomAnimation)
			{
				animationsArray = null;
				this.mode &= ~Mode.RandomAnimation;
			}
		}

		private void CheckRandomFrameMode(Mode mode)
		{
			if ((mode & Mode.RandomStartFrame) == Mode.RandomStartFrame)
			{
				currentTrack.SetRandomStartFrame();
			}
		}

		private void CheckTrackListMode(Mode mode)
		{
			if ((mode & Mode.PlayTrackList) != Mode.PlayTrackList)
			{
				ClearTracks();
			}
		}

		private bool CheckIdentityMode(Mode mode, string animationName)
		{
			if ((mode & Mode.CheckIdentity) == Mode.CheckIdentity && animationName == CurrentAnimationName && !string.IsNullOrEmpty(CurrentAnimationName))
			{
				return true;
			}
			return false;
		}

		private bool CheckIdentityMode(Mode mode, string[] animationNames)
		{
			if ((mode & Mode.CheckIdentity) == Mode.CheckIdentity && Equals(animationNames, animationsArray) && animationsArray != null)
			{
				return true;
			}
			return false;
		}

		private bool CheckReverseTrack(Mode mode)
		{
			return (mode & Mode.PlayReverseTrack) == Mode.PlayReverseTrack;
		}

		private bool Equals(string[] a, string[] b)
		{
			if (a == null || b == null)
			{
				return false;
			}
			if (a.Length == b.Length)
			{
				for (int i = 0; i < a.Length; i++)
				{
					if (!a[i].Equals(b[i]))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		public void PlayTrackList()
		{
			trackList.Reverse();
			PlayReverseTrackList();
		}

		public void PlayReverseTrackList()
		{
			for (int i = 0; i < trackList.Count; i++)
			{
				if (trackList[i] == null || trackList[i].animation == null)
				{
					trackList.Remove(trackList[i]);
				}
			}
			Play(null, Mode.PlayTrackList);
		}

		public bool AddTrack(string animationName, int countRepeat = 1)
		{
			Animation animation = animationObject.data.GetAnimation(animationName);
			if (animation != null)
			{
				AnimationTrack animationTrack = new AnimationTrack();
				animationTrack.Set(animation);
				for (int i = 0; i < countRepeat; i++)
				{
					trackList.Add(animationTrack);
				}
				return true;
			}
			return false;
		}

		public void ClearTracks()
		{
			trackList.Clear();
		}

		public void Pause()
		{
			isPause = true;
		}

		public void UnPause()
		{
			isPause = false;
		}

		public void Stop()
		{
			if (trackList.Count > 0)
			{
				trackList.RemoveAt(trackList.Count - 1);
			}
			if (trackList.Count == 0)
			{
				IsPlaying = false;
				currentTrack.Clear();
				Loop = false;
				animationsArray = null;
				mode = Mode.None;
				CurrentAnimationName = string.Empty;
			}
		}

		private void NormalizeFrame()
		{
			if (!AnimationTrack.IsNullOrEmpty(currentTrack))
			{
				Frame currentFrame = currentTrack.GetCurrentFrame();
				if (currentFrame != null)
				{
					SetFrameData(currentFrame);
				}
			}
		}

		public void UpdateTracks(float deltaTime = 0f, string thread = "")
		{
			if (threadName != thread || !IsPlaying)
			{
				return;
			}
			Frame currentFrame = currentTrack.GetCurrentFrame();
			if (dt == 0f)
			{
				SetFrame(currentFrame);
			}
			dt += deltaTime * animationObject.timeScale;
			if (dt >= currentFrame.time)
			{
				dt = 0f;
				if (IsReverse)
				{
					currentTrack.PrevFrame();
				}
				else
				{
					currentTrack.NextFrame();
				}
				EndListener();
			}
		}

		private void SetFrame(Frame frame)
		{
			if (frame != null)
			{
				try
				{
					SetFrameData(frame);
				}
				catch (Exception)
				{
				}
				StartListener();
				EventListener(frame);
			}
		}

		private void SetFrameData(Frame frame)
		{
			animationObject.data.SetSprite(frame.img);
			int num = ((!animationObject.FlipX) ? 1 : (-1));
			int num2 = ((!animationObject.FlipY) ? 1 : (-1));
			float x = (float)num * frame.x / (float)animationObject.data.dataAsset.pixelsPerUnits;
			float y = (float)num2 * frame.y / (float)animationObject.data.dataAsset.pixelsPerUnits;
			float z = animationObject.data.transform.localPosition.z;
			animationObject.data.transform.localPosition = new Vector3(x, y, z);
			if (clones != null)
			{
				for (int i = 0; i < clones.Length; i++)
				{
					clones[i].data.SetSprite(frame.img);
					clones[i].data.transform.localPosition = new Vector3(x, y, z);
				}
			}
			attachments.Clear();
			if (frame.attachments != null)
			{
				for (int j = 0; j < frame.attachments.Length; j++)
				{
					if (!attachments.ContainsKey(frame.attachments[j].name))
					{
						Attachment attachment = new Attachment(frame.attachments[j]);
						attachment.x = (float)num * attachment.x * (float)animationObject.data.dataAsset.pixelsPerUnits;
						attachment.y = (float)num2 * attachment.y * (float)animationObject.data.dataAsset.pixelsPerUnits;
						attachments.Add(attachment.name, attachment);
					}
				}
			}
			if (this.onUpdateAnimation != null)
			{
				this.onUpdateAnimation(frame);
			}
		}

		private void EventListener(Frame frame)
		{
			if (!string.IsNullOrEmpty(frame.eventName) && this.onEvent != null)
			{
				this.onEvent(frame.eventName);
			}
		}

		private void StartListener()
		{
			if (currentTrack.CurrentFrame == 0)
			{
				CurrentAnimationName = currentTrack.animation.name;
				LastPlayedAnimationName = currentTrack.animation.name;
				if (this.onStart != null)
				{
					this.onStart(CurrentAnimationName, Loop);
				}
			}
		}

		private void EndListener()
		{
			if (currentTrack.CurrentFrame != 0)
			{
				return;
			}
			if (this.onComplete != null)
			{
				this.onComplete(CurrentAnimationName);
			}
			if (Loop)
			{
				if (animationsArray != null)
				{
					Play(animationsArray, Loop, mode &= ~Mode.CheckIdentity);
				}
				return;
			}
			string currentAnimationName = CurrentAnimationName;
			Stop();
			if (this.onEnd != null)
			{
				this.onEnd(currentAnimationName);
			}
		}

		public Attachment GetAttachment(string name)
		{
			if (attachments.ContainsKey(name))
			{
				return attachments[name];
			}
			return null;
		}
	}
}
