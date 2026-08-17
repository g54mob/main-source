using System;
using UnityEngine;

namespace Assets.Scripts.Audio.Music;

public class MusicTrack : ScriptableObject, IComparable<MusicTrack>
{
	public bool isEnabled = true;

	public bool isInJukebox;

	public bool isInRandomPool = true;

	public int maxStageCompatibility = 999;

	public MusicCategory category;

	public string trackName;

	public AudioClip intro;

	public AudioClip loop;

	public void LoadToMemory()
	{
		if (intro != null)
		{
			bool flag = intro.LoadAudioData();
		}
		if (loop != null)
		{
			bool flag2 = loop.LoadAudioData();
		}
	}

	public void UnloadFromMemory()
	{
		if (intro != null)
		{
			bool flag = intro.UnloadAudioData();
		}
		if (loop != null)
		{
			bool flag2 = loop.UnloadAudioData();
		}
	}

	public bool IsLoadedInMemory()
	{
		//IL_0121: Expected I4, but got O
		//IL_0078: Expected O, but got I4
		//IL_00f7: Expected O, but got I4
		bool flag;
		if (intro == null)
		{
			flag = true;
		}
		else
		{
			if ((object)intro == null)
			{
				goto IL_0113;
			}
			AudioDataLoadState loadState = intro.loadState;
			object obj = loadState - 2;
			bool flag2 = obj == null;
			flag = flag2;
		}
		bool flag3 = loop != null;
		bool flag4 = true;
		if (flag3)
		{
			if ((object)loop == null)
			{
				goto IL_0113;
			}
			AudioDataLoadState loadState2 = loop.loadState;
			object obj2 = loadState2 - 2;
			bool flag5 = obj2 == null;
			flag4 = flag5;
		}
		return flag4 & flag;
		IL_0113:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe int CompareTo(MusicTrack other)
	{
		//IL_007a: Expected I4, but got O
		//IL_0047: Expected I4, but got O
		//IL_0058: Expected O, but got Ref
		if (other != null)
		{
			if ((object)other != null)
			{
				object obj = default(object);
				object target = (MusicCategory)obj;
				IntPtr intPtr = default(IntPtr);
				return ((Enum)(&intPtr)).CompareTo(target);
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
		return 1;
	}
}
