using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundEnviron : MonoBehaviour
{
	[Serializable]
	public class Source
	{
		public AudioSource source;

		public float defaultVolume;

		public SoundRoom.VolPan summingVolPan = new SoundRoom.VolPan();

		public string name
		{
			get
			{
				return source.name;
			}
		}

		public float volume
		{
			get
			{
				return source.volume;
			}
			set
			{
				source.volume = value * defaultVolume;
			}
		}

		public float pan
		{
			get
			{
				return source.panStereo;
			}
			set
			{
				source.panStereo = value;
			}
		}

		public Source(AudioSource source_)
		{
			source = source_;
			defaultVolume = source.volume;
		}

		public void Play()
		{
			source.Play();
		}
	}

	public List<AudioSource> unattachedSources;

	[Readonly]
	public List<Source> sources;

	[Readonly]
	public AudioListener audioListener;

	[Readonly]
	public List<SoundRoom> rooms;

	[Readonly]
	public List<SoundSphere> spheres;

	private float fade;

	private float fadeSpeed;

	private float duck;

	private bool ducking;

	private float duckSpeed = 1f;

	private SoundRoom.Listener listener = new SoundRoom.Listener();

	private List<SoundRoom.VolPan> volPans = new List<SoundRoom.VolPan>();

	public bool fadedOut
	{
		get
		{
			return fade < 0.001f;
		}
	}

	public bool fadingOut
	{
		get
		{
			return fadeSpeed < 0f;
		}
	}

	public float fadedVolumeLevel
	{
		get
		{
			return fade;
		}
	}

	private void Start()
	{
		foreach (Source source in sources)
		{
			volPans.Add(new SoundRoom.VolPan());
		}
		foreach (Source source2 in sources)
		{
			source2.Play();
			source2.volume = 0f;
		}
		fade = 0f;
		fadeSpeed = 1f / 3f;
	}

	public void DuckForOneFrame(bool setFullyDucked = false)
	{
		ducking = true;
		if (setFullyDucked)
		{
			duck = 1f;
		}
	}

	public void FadeOut(float duration)
	{
		if (duration == 0f)
		{
			fade = 0f;
			fadeSpeed = -1f;
		}
		else
		{
			fadeSpeed = -1f / duration;
		}
	}

	public void FadeIn(float duration)
	{
		if (duration == 0f)
		{
			fade = 1f;
			fadeSpeed = 1f;
		}
		else
		{
			fadeSpeed = 1f / duration;
		}
	}

	private void Update()
	{
		if (ducking)
		{
			duck = Mathf.Min(1f, duck + duckSpeed * Clock.play.deltaTime);
			ducking = false;
		}
		else
		{
			duck = Mathf.Max(0f, duck - duckSpeed * Clock.play.deltaTime);
		}
		fade = (1f - duck) * Mathf.Max(0f, Mathf.Min(1f, fade + fadeSpeed * Clock.active.deltaTime));
		foreach (AudioSource unattachedSource in unattachedSources)
		{
			unattachedSource.volume = fade;
		}
		if (rooms.Count > 0)
		{
			listener.Set(audioListener.transform.localToWorldMatrix);
			foreach (SoundRoom.VolPan volPan2 in volPans)
			{
				volPan2.Zero();
			}
			bool flag = false;
			foreach (SoundRoom room in rooms)
			{
				if (room.bounds.Contains(listener.pos))
				{
					room.Apply(listener, volPans);
					if (room.deadzone)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				foreach (SoundSphere sphere in spheres)
				{
					if (sphere.bounds.Contains(listener.pos))
					{
						sphere.Apply(listener, volPans);
					}
				}
			}
			for (int i = 0; i < volPans.Count; i++)
			{
				SoundRoom.VolPan volPan = volPans[i];
				Source source = sources[i];
				if (volPan.vol != 0f)
				{
					volPan.pan /= volPan.vol;
					volPan.vol = Mathf.Min(1f, volPan.vol);
				}
				source.volume = volPan.vol * fade;
				source.pan = volPan.pan;
			}
		}
		else
		{
			foreach (Source source2 in sources)
			{
				source2.volume = fade;
			}
		}
		if (!DebugMenu.IsOn("Show/Sound Rooms"))
		{
			return;
		}
		foreach (Source source3 in sources)
		{
			DebugDrawer.Watch(source3.name, new SoundRoom.VolPan(source3.volume, source3.pan));
		}
		DebugDrawer.World(delegate(DebugDrawer dd)
		{
			foreach (SoundRoom room2 in rooms)
			{
				dd.DrawBounds((!room2.deadzone) ? SoundRoom.normalColor : SoundRoom.deadzoneColor, room2.bounds);
			}
			foreach (SoundSphere sphere2 in spheres)
			{
				dd.DrawSphere(SoundRoom.normalColor, sphere2.transform.localToWorldMatrix);
			}
		});
	}

	public void SetDefaultVolume(AudioSource audioSource, float defaultVolume)
	{
		foreach (Source source in sources)
		{
			if (source.source == audioSource)
			{
				source.defaultVolume = defaultVolume;
			}
		}
	}
}
