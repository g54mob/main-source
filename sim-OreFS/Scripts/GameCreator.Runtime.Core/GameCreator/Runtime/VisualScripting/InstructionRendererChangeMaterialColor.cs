using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Material Color")]
	[Description("Changes over time the Color property of an instantiated material of a Renderer component")]
	[Image(typeof(IconColor), ColorTheme.Type.Yellow)]
	[Category("Renderer/Change Material Color")]
	[Parameter("Property", "Name of the property to change")]
	[Parameter("Color", "Color target that the instantiated Material turns into")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the transition over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished or not")]
	[Keywords(new string[] { "Set", "Shader", "Hue" })]
	public class InstructionRendererChangeMaterialColor : TInstructionRenderer
	{
		[SerializeField]
		private PropertyGetString m_Property = new PropertyGetString("_Color");

		[SerializeField]
		private ChangeColor m_Color = new ChangeColor();

		[Space]
		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Change {m_Property} of {m_Renderer} {m_Color}";

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
			Color color = renderer.material.GetColor(propertyID);
			Color target = m_Color.Get(color, args);
			ITweenInput tween = new TweenInput<Color>(color, target, m_Transition.Duration, delegate(Color a, Color b, float t)
			{
				renderer.material.SetColor(propertyID, Color.Lerp(a, b, t));
			}, Tween.GetHash(typeof(Renderer), text), m_Transition.EasingType, m_Transition.Time);
			Tween.To(gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
