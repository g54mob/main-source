using Unity.Collections;
using UnityEngine.Animations;

namespace Animancer
{
	public class AnimatedFloat : AnimatedProperty<AnimatedFloat.Job, float>
	{
		public struct Job : IAnimationJob
		{
			public NativeArray<PropertyStreamHandle> properties;

			public NativeArray<float> values;

			public void ProcessRootMotion(AnimationStream stream)
			{
			}

			public void ProcessAnimation(AnimationStream stream)
			{
				for (int num = properties.Length - 1; num >= 0; num--)
				{
					values[num] = properties[num].GetFloat(stream);
				}
			}
		}

		public AnimatedFloat(IAnimancerComponent animancer, int propertyCount, NativeArrayOptions options = NativeArrayOptions.ClearMemory)
			: base(animancer, propertyCount, options)
		{
		}

		public AnimatedFloat(IAnimancerComponent animancer, string propertyName)
			: base(animancer, propertyName)
		{
		}

		public AnimatedFloat(IAnimancerComponent animancer, params string[] propertyNames)
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
