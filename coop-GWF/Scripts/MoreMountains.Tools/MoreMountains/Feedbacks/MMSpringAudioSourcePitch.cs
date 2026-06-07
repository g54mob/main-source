using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MMSpringAudioSourcePitch")]
	public class MMSpringAudioSourcePitch : MMSpringFloatComponent<AudioSource>
	{
		public override float TargetFloat
		{
			get
			{
				return Target.pitch;
			}
			set
			{
				Target.pitch = value;
			}
		}
	}
}
