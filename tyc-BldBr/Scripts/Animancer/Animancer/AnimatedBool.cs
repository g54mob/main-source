using Unity.Collections;
using UnityEngine.Animations;

namespace Animancer
{
	public class AnimatedBool : AnimatedProperty<AnimatedBool.Job, bool>
	{
		public struct Job : IAnimationJob
		{
			public NativeArray<PropertyStreamHandle> properties;

			public NativeArray<bool> values;

			public void ProcessRootMotion(AnimationStream stream)
			{
			}

			public void ProcessAnimation(AnimationStream stream)
			{
				for (int num = properties.Length - 1; num >= 0; num--)
				{
					values[num] = properties[num].GetBool(stream);
				}
			}
		}

		public AnimatedBool(IAnimancerComponent animancer, int propertyCount, NativeArrayOptions options = NativeArrayOptions.ClearMemory)
			: base(animancer, propertyCount, options)
		{
		}

		public AnimatedBool(IAnimancerComponent animancer, string propertyName)
			: base(animancer, propertyName)
		{
		}

		public AnimatedBool(IAnimancerComponent animancer, params string[] propertyNames)
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
