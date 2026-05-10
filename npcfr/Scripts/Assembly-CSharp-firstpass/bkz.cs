using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Playables;

public abstract class bkz : MonoBehaviour
{
	[Serializable]
	public enum Mode
	{
		AnimationClips = 0,
		AnimationStates = 1,
		PlayableDirector = 2,
		Realtime = 3
	}

	public delegate void BakerDelegate(AnimationClip clip, float time);

	[Serializable]
	public class ClipSettings
	{
		[Serializable]
		public enum BasedUponRotation
		{
			Original = 0,
			BodyOrientation = 1
		}

		[Serializable]
		public enum BasedUponY
		{
			Original = 0,
			CenterOfMass = 1,
			Feet = 2
		}

		[Serializable]
		public enum BasedUponXZ
		{
			Original = 0,
			CenterOfMass = 1
		}

		public bool loopTime;

		public bool loopBlend;

		public float cycleOffset;

		public bool loopBlendOrientation;

		public BasedUponRotation basedUponRotation;

		public float orientationOffsetY;

		public bool loopBlendPositionY;

		public BasedUponY basedUponY;

		public float level;

		public bool loopBlendPositionXZ;

		public BasedUponXZ basedUponXZ;

		public bool mirror;
	}

	[Range(1f, 90f)]
	public int frameRate;

	[Range(0f, 0.1f)]
	public float keyReductionError;

	public Mode mode;

	public AnimationClip[] animationClips;

	public string[] animationStates;

	public string saveToFolder;

	public string appendName;

	public string saveName;

	[HideInInspector]
	public Animator animator;

	[HideInInspector]
	public PlayableDirector director;

	public BakerDelegate OnStartClip;

	public BakerDelegate OnUpdateClip;

	public bool inheritClipSettings;

	public ClipSettings clipSettings;

	protected bool thh;

	public bool the
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public float thf
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	protected float thg
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	private void jhz()
	{
	}

	public void eda()
	{
	}

	public void htl()
	{
	}

	public void kea()
	{
	}

	protected abstract Transform jif();

	protected abstract void jii(ref AnimationClip a);

	public void ior()
	{
	}

	public void lch()
	{
	}

	protected abstract void jih(float a);

	public void gqf()
	{
	}

	protected abstract void jij(float a, bool b);

	public void jio()
	{
	}

	public void jim()
	{
	}

	private void jia()
	{
	}

	public void cdy()
	{
	}

	private void jhx()
	{
	}

	protected abstract void jig();

	private void jhy()
	{
	}

	public void jin()
	{
	}
}
