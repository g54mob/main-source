using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MMSpringTMPSoftness")]
	public class MMSpringTMPSoftness : MMSpringFloatComponent<TMP_Text>
	{
		protected override void ApplyValue(float newValue)
		{
			base.ApplyValue(newValue);
			Target.fontSharedMaterial.SetFloat(ShaderUtilities.ID_OutlineSoftness, newValue);
		}

		protected override void GrabCurrentValue()
		{
			FloatSpring.CurrentValue = Target.fontMaterial.GetFloat(ShaderUtilities.ID_OutlineSoftness);
		}
	}
}
