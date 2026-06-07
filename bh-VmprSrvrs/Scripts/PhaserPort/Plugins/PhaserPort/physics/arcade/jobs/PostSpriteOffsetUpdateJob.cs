using Unity.Collections;
using UnityEngine.Jobs;

namespace Plugins.PhaserPort.physics.arcade.jobs
{
	public struct PostSpriteOffsetUpdateJob : IJobParallelForTransform
	{
		[ReadOnly]
		public NativeArray<bool> _enabledArray;

		[ReadOnly]
		public NativeArray<bool> _movesArray;

		[ReadOnly]
		public NativeArray<bool> _validArray;

		[ReadOnly]
		public NativeArray<SpriteOffsetData> _spriteOffsetDataArray;

		public void Execute(int index, TransformAccess transform)
		{
		}
	}
}
