using System;
using System.Runtime.InteropServices;
using FMOD;

[Serializable]
[StructLayout((LayoutKind)0)]
public class TimelineInfo
{
	public int CurrentBeat;

	public int CurrentBar;

	public float CurrentTempo;

	public int CurrentPositionMs;

	public int SongLengthMs;

	public StringWrapper LastMarker;

	public int ElapsedBeats;

	public float LastBeatTime;
}
