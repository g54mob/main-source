using System.Collections.Generic;
using MessagePack;

[MessagePackObject(false)]
public class DebuggerStateDto
{
	[Key(0)]
	public List<int> Staged = new List<int>();

	[Key(1)]
	public HashSet<int> Glitched = new HashSet<int>();

	[Key(2)]
	public bool Hotfixing;

	[Key(3)]
	public bool Compiling;

	[Key(4)]
	public float Progress;

	[Key(5)]
	public float GlitchTimerCurrent;

	[Key(6)]
	public float GlitchTimerDuration;

	[Key(7)]
	public float BonusDecayTimerCurrent;

	[Key(8)]
	public float BonusDecayTimerDuration;

	[Key(9)]
	public float BonusDecayRate;

	[Key(10)]
	public float BonusGrowthTimerCurrent;

	[Key(11)]
	public float BonusGrowthTimerDuration;

	[Key(12)]
	public float BonusGrowthRate;
}
