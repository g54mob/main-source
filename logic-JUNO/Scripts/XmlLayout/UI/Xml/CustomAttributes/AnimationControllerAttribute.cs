using UnityEngine;

namespace UI.Xml.CustomAttributes
{
	public class AnimationControllerAttribute : CustomXmlAttribute
	{
		public override bool UsesApplyMethod => true;

		public override eAttributeGroup AttributeGroup => eAttributeGroup.Animation;

		public override string DefaultValue => "Animation/XmlLayoutAnimationController";

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			RuntimeAnimatorController runtimeAnimatorController = value.ToRuntimeAnimatorController();
			Animator animator = xmlElement.GetComponent<Animator>();
			if (animator == null)
			{
				animator = xmlElement.gameObject.AddComponent<Animator>();
			}
			_ = (bool)xmlElement.CanvasGroup;
			animator.runtimeAnimatorController = runtimeAnimatorController;
		}
	}
}
