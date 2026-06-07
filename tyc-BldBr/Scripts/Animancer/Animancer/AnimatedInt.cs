using Unity.Collections;
using UnityEngine.Animations;

namespace Animancer
{
	public class AnimatedInt : AnimatedProperty<AnimatedInt.Job, int>
	{
		public struct Job : IAnimationJob
		{
			public NativeArray<PropertyStreamHandle> properties;

			public NativeArray<int> values;

			public void ProcessRootMotion(AnimationStream stream)
			{
			}

			public void ProcessAnimation(AnimationStream stream)
			{
				for (int num = properties.Length - 1; num >= 0; num--)
				{
					values[num] = properties[num].GetInt(stream);
				}
			}
		}

		public AnimatedInt(IAnimancerComponent animancer, int propertyCount, NativeArrayOptions options = NativeArrayOptions.ClearMemory)
			: base(animancer, propertyCount, options)
		{
		}

		public AnimatedInt(IAnimancerComponent animancer, string propertyName)
			: base(animancer, propertyName)
		{
		}

		public AnimatedInt(IAnimancerComponent animancer, params string[] propertyNames)
			: base(animancer, propertyNames)
		{
		}

		protected override void CreateJob()
		{
			_Job = new Job
			{
				properties = _Properties,
				values = _Values
			};
		}
	}
}
