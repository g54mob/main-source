using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Material Float")]
	[Description("Changes over time the Float property of an instantiated material of a Renderer component")]
	[Image(typeof(IconNumber), ColorTheme.Type.Yellow)]
	[Category("Renderer/Change Material Float")]
	[Parameter("Property", "Name of the property to change")]
	[Parameter("Float", "Decimal target that the instantiated Material's property turns into")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the transition over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished or not")]
	[Keywords(new string[] { "Set", "Shader", "Hue" })]
	public class InstructionRendererChangeMaterialFloat : TInstructionRenderer
	{
		[SerializeField]
		private PropertyGetString m_Property = new PropertyGetString("_Glossiness");

		[SerializeField]
		private ChangeDecimal m_Decimal = new ChangeDecimal(1f);

		[Space]
		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Change {m_Property} of {m_Renderer} {m_Decimal}";

		protected override async Task Run(Args args)
		{
			GameObject gameObject = m_Renderer.Get(args);
			if (gameObject == null)
			{
				return;
			}
			Renderer renderer = gameObject.Get<Renderer>();
			if (renderer == null || renderer.material == null)
			{
				return;
			}
			string text = m_Property.Get(args);
			int propertyID = Shader.PropertyToID(text);
			float num = renderer.material.GetFloat(propertyID);
			float target = (float)m_Decimal.Get(num, args);
			ITweenInput tween = new TweenInput<float>(num, target, m_Transition.Duration, delegate(float a, float b, float t)
			{
				renderer.material.SetFloat(propertyID, Mathf.Lerp(a, b, t));
			}, Tween.GetHash(typeof(Renderer), text), m_Transition.EasingType, m_Transition.Time);
			Tween.To(gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
