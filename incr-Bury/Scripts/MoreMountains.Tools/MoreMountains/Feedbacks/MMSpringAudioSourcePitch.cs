using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring Audio Source Pitch")]
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
