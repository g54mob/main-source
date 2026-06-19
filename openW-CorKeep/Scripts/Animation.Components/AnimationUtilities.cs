using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.NetCode;

public static class AnimationUtilities
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void TriggerAnimation(int animID, NetworkTick currentTick, DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer)
	{
		AnimationBuffer item = new AnimationBuffer
		{
			Tick = currentTick,
			animID = animID
		};
		animationBuffer.AddToRingBuffer(ref animationBufferPointer, in item);
	}
}
