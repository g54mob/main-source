using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring Bloom Intensity URP")]
	public class MMSpringBloomIntensity_URP : MMSpringFloatComponent<Volume>
	{
		protected Bloom _bloom;

		public override float TargetFloat
		{
			get
			{
				return _bloom.intensity.value;
			}
			set
			{
				_bloom.intensity.Override(value);
			}
		}

		protected override void Initialization()
		{
			if (Target == null)
			{
				Target = base.gameObject.GetComponent<Volume>();
			}
			Target.profile.TryGet<Bloom>(out _bloom);
			base.Initialization();
		}
	}
}
