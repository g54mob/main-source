using UnityEngine;

namespace UI.Xml.CustomAttributes
{
	public class AnimationSpeedAttribute : CustomXmlAttribute
	{
		public override bool UsesApplyMethod => true;

		public override eAttributeGroup AttributeGroup => eAttributeGroup.Animation;

		public override string DefaultValue => "1";

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			float speed = float.Parse(value);
			Animator animator = xmlElement.GetComponent<Animator>();
			if (animator == null)
			{
				animator = xmlElement.gameObject.AddComponent<Animator>();
			}
			animator.speed = speed;
			_ = (bool)xmlElement.CanvasGroup;
		}
	}
}
