using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MMSpringVignetteCenter_URP")]
	public class MMSpringVignetteCenter_URP : MMSpringVector2Component<Volume>
	{
		protected Vignette _vignette;

		public override Vector2 TargetVector2
		{
			get
			{
				return _vignette.center.value;
			}
			set
			{
				_vignette.center.Override(value);
			}
		}

		protected override void Initialization()
		{
			if (Target == null)
			{
				Target = base.gameObject.GetComponent<Volume>();
			}
			Target.profile.TryGet<Vignette>(out _vignette);
			base.Initialization();
		}
	}
}
