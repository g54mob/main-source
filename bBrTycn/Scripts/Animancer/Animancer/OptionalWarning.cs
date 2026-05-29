using System;

namespace Animancer
{
	[Flags]
	public enum OptionalWarning
	{
		ProOnly = 1,
		CreateGraphWhileDisabled = 2,
		CreateGraphDuringGuiEvent = 4,
		AnimatorDisabled = 8,
		NativeControllerHumanoid = 0x10,
		NativeControllerHybrid = 0x20,
		DuplicateEvent = 0x40,
		EndEventInterrupt = 0x80,
		UselessEvent = 0x100,
		LockedEvents = 0x200,
		UnsupportedEvents = 0x400,
		UnsupportedSpeed = 0x800,
		UnsupportedIK = 0x1000,
		MixerMinChildren = 0x2000,
		MixerSynchronizeZeroLength = 0x4000,
		CustomFadeBounds = 0x8000,
		CustomFadeNotNull = 0x10000,
		AnimatorSpeed = 0x20000,
		UnusedNode = 0x40000,
		PlayableAssetAnimatorBinding = 0x80000,
		CloneComplexState = 0x100000,
		All = -1
	}
}
