using UnityEngine;
using UnityEngine.Playables;

namespace JSAM
{
	public abstract class BaseJSAMPlayableBehaviour<T> : PlayableBehaviour where T : BaseAudioFileObject
	{
		public float Volume = 1f;

		public double StartTime;

		public BaseAudioFileObject Audio;

		public GameObject helperObject;

		protected AudioSource helperSource;

		public static int SOURCES = -1;

		public int UUID;

		protected BaseAudioChannelHelper<T> helper;

		protected virtual BaseAudioChannelHelper<T> Helper
		{
			get
			{
				if (helperObject == null)
				{
					helperObject = GameObject.Find("JSAM" + UUID);
					if (helperObject == null)
					{
						UUID = ++SOURCES;
						helperObject = new GameObject("JSAM" + UUID);
						helperSource = helperObject.AddComponent<AudioSource>();
						helperSource.playOnAwake = false;
					}
					InitAudioHelper();
					helperObject.hideFlags = HideFlags.HideAndDontSave;
				}
				if (helperSource == null)
				{
					helperSource = helperObject.GetComponent<AudioSource>();
				}
				return helper;
			}
		}

		protected abstract void InitAudioHelper();

		protected void UpdateTime(Playable playable)
		{
			helperSource.time = Mathf.Min((float)StartTime + (float)playable.GetTime(), helperSource.clip.length - 1E-06f);
		}
	}
}
