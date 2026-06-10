using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring Depth Of Field Focal Length URP")]
	public class MMSpringDepthOfFieldFocalLength_URP : MMSpringFloatComponent<Volume>
	{
		protected DepthOfField _depthOfField;

		public override float TargetFloat
		{
			get
			{
				return _depthOfField.focalLength.value;
			}
			set
			{
				_depthOfField.focalLength.Override(value);
			}
		}

		protected override void Initialization()
		{
			if (Target == null)
			{
				Target = base.gameObject.GetComponent<Volume>();
			}
			Target.profile.TryGet<DepthOfField>(out _depthOfField);
			base.Initialization();
		}
	}
}
