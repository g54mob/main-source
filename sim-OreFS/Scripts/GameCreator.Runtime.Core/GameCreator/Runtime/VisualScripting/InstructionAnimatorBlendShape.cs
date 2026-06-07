using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Blend Shape")]
	[Description("Changes the value of a Blend Shape parameter")]
	[Image(typeof(IconFace), ColorTheme.Type.Blue)]
	[Category("Animations/Change Blend Shape")]
	[Parameter("Skinned Mesh", "The Skinned Mesh Renderer component attached to the game object")]
	[Parameter("Blend Shape", "Name of the Blend Shape to change")]
	[Parameter("Value", "The target value of the blend shape")]
	[Parameter("Duration", "How long it takes to perform the transition")]
	[Parameter("Easing", "The change rate of the parameter over time")]
	[Parameter("Wait to Complete", "Whether to wait until the transition is finished")]
	[Keywords(new string[] { "Morph", "Target" })]
	public class InstructionAnimatorBlendShape : Instruction
	{
		[SerializeField]
		protected PropertyGetGameObject m_SkinnedMesh = new PropertyGetGameObject();

		[SerializeField]
		private PropertyGetString m_BlendShape = new PropertyGetString("Smile");

		[SerializeField]
		private ChangeDecimal m_Value = new ChangeDecimal(1f);

		[SerializeField]
		private Transition m_Transition = new Transition();

		public override string Title => $"Morph {m_BlendShape} on {m_SkinnedMesh} {m_Value}";

		protected override async Task Run(Args args)
		{
			GameObject gameObject = m_SkinnedMesh.Get(args);
			if (gameObject == null)
			{
				return;
			}
			SkinnedMeshRenderer skinnedMesh = gameObject.Get<SkinnedMeshRenderer>();
			if (skinnedMesh == null)
			{
				return;
			}
			string blendShapeName = m_BlendShape.Get(args);
			int blendShapeIndex = skinnedMesh.sharedMesh.GetBlendShapeIndex(blendShapeName);
			float blendShapeWeight = skinnedMesh.GetBlendShapeWeight(blendShapeIndex);
			float target = (float)m_Value.Get(blendShapeWeight, args);
			ITweenInput tween = new TweenInput<float>(blendShapeWeight, target, m_Transition.Duration, delegate(float a, float b, float t)
			{
				skinnedMesh.SetBlendShapeWeight(blendShapeIndex, Mathf.Lerp(a, b, t));
			}, Tween.GetHash(typeof(SkinnedMeshRenderer), $"blend-shape:{blendShapeIndex}"), m_Transition.EasingType, m_Transition.Time);
			Tween.To(gameObject, tween);
			if (m_Transition.WaitToComplete)
			{
				await Until(() => tween.IsFinished);
			}
		}
	}
}
