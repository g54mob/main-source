using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[Version(2, 0, 1)]
[Title(" Change Image Fill Amount")]
[Description("Only for image components of type FILLED")]
[Category("UI/Change Image Fill Amount")]
[Keywords(new string[] { "Image", "Fill", "Amount", "Change" })]
[Image(typeof(IconUIImage), ColorTheme.Type.TextLight)]
[Parameter("Image", "The GameObject with the Image Component")]
[Parameter("Value", "The target value you want the Fill Amount to be Set")]
public class InstructionUIChangeImageFillAmount : Instruction
{
	[SerializeField]
	private PropertyGetGameObject m_Image = GetGameObjectInstance.Create();

	[SerializeField]
	private PropertyGetDecimal m_Value = new PropertyGetDecimal();

	[SerializeField]
	private Transition m_Transition = new Transition();

	public override string Title => $"Change {m_Image} Fill Amount to {m_Value}";

	protected override async Task Run(Args args)
	{
		GameObject gameObject = m_Image.Get(args);
		double num = m_Value.Get(args);
		if (gameObject == null)
		{
			return;
		}
		Image image = gameObject.Get<Image>();
		if (image == null || image.type != Image.Type.Filled)
		{
			return;
		}
		float fillAmount = image.fillAmount;
		float target = (float)num;
		ITweenInput tween = new TweenInput<float>(fillAmount, target, m_Transition.Duration, delegate(float a, float b, float t)
		{
			image.fillAmount = Mathf.LerpUnclamped(a, b, t);
		}, Tween.GetHash(typeof(Transform), "fillAmount"), m_Transition.EasingType, m_Transition.Time);
		Tween.To(gameObject, tween);
		if (m_Transition.WaitToComplete)
		{
			await Until(() => tween.IsFinished);
		}
	}
}
