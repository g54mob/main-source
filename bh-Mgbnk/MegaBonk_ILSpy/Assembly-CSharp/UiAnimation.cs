using Assets.Scripts.UI.Animation;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class UiAnimation : MonoBehaviour
{
	public MaskableGraphic element;

	private MaskableGraphic[] subElements;

	private bool checkedChildren;

	private float scaleTarget;

	private float scaleTimer;

	private float scaleTimespan;

	private float fromScale;

	private EEasing scaleEasing;

	private void Awake()
	{
		MaskableGraphic[] componentsInChildren = GetComponentsInChildren<MaskableGraphic>();
		subElements = componentsInChildren;
	}

	private void CheckSubElements()
	{
		if (!checkedChildren)
		{
			checkedChildren = true;
			MaskableGraphic[] componentsInChildren = GetComponentsInChildren<MaskableGraphic>();
			subElements = componentsInChildren;
		}
	}

	public void CrossFadeAndScaleIn(float time, EEasing easing = EEasing.Linear)
	{
		//IL_0065: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_00f0: Expected O, but got I4
		//IL_00f9: Expected O, but got I4
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		if (!checkedChildren)
		{
			checkedChildren = true;
			MaskableGraphic[] componentsInChildren = GetComponentsInChildren<MaskableGraphic>();
			subElements = componentsInChildren;
		}
		if (!checkedChildren)
		{
			checkedChildren = true;
			MaskableGraphic[] componentsInChildren2 = GetComponentsInChildren<MaskableGraphic>();
			subElements = componentsInChildren2;
		}
		MaskableGraphic[] array = subElements;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			array[obj].CrossFadeAlpha(0f, 0f, ignoreTimeScale: true);
			obj++;
			obj2 = obj;
		}
		if (!checkedChildren)
		{
			checkedChildren = true;
			MaskableGraphic[] componentsInChildren3 = GetComponentsInChildren<MaskableGraphic>();
			subElements = componentsInChildren3;
		}
		MaskableGraphic[] array2 = subElements;
		object obj3 = 0;
		object obj4 = 0;
		while ((nint)obj4 < array2.Length)
		{
			array2[obj3].CrossFadeAlpha(1f, time, ignoreTimeScale: true);
			obj3++;
			obj4 = obj3;
		}
		Scale(0f, 0f, easing);
		Scale(1f, time, easing);
	}

	public void ScaleIn(float time, EEasing easing = EEasing.Linear)
	{
		if (!checkedChildren)
		{
			checkedChildren = true;
			MaskableGraphic[] componentsInChildren = GetComponentsInChildren<MaskableGraphic>();
			subElements = componentsInChildren;
		}
		Scale(0f, 0f, easing);
		Scale(1f, time, easing);
	}

	public void CrossFade(float alpha, float time)
	{
		//IL_0041: Expected O, but got I4
		//IL_004a: Expected O, but got I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		if (!checkedChildren)
		{
			checkedChildren = true;
			MaskableGraphic[] componentsInChildren = GetComponentsInChildren<MaskableGraphic>();
			subElements = componentsInChildren;
		}
		MaskableGraphic[] array = subElements;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			array[obj].CrossFadeAlpha(alpha, time, ignoreTimeScale: true);
			obj++;
			obj2 = obj;
		}
	}

	public unsafe void Scale(float scale, float time, EEasing easing = EEasing.Linear)
	{
		//IL_0095: Invalid comparison between F4 and I4
		//IL_00dd: Expected O, but got Ref
		if (!checkedChildren)
		{
			checkedChildren = true;
			MaskableGraphic[] componentsInChildren = GetComponentsInChildren<MaskableGraphic>();
			subElements = componentsInChildren;
		}
		Transform transform = element.transform;
		fromScale = transform.localScale.x;
		scaleTimer = 0f;
		scaleEasing = easing;
		scaleTarget = scale;
		scaleTimespan = time;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018052D741h\"");
		if (time == 0f)
		{
			scaleTimer = 1f;
			Transform transform2 = element.transform;
			float num = default(float);
			transform2.localScale = (Vector3)(&num);
		}
	}

	private unsafe void Update()
	{
		//IL_0065: Invalid comparison between I4 and F4
		//IL_00b0: Expected F4, but got I4
		//IL_0118: Invalid comparison between I4 and F4
		//IL_0163: Expected F4, but got I4
		//IL_0175: Expected O, but got Ref
		if (!(1f > scaleTimer))
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		float num = deltaTime / scaleTimespan;
		float num2 = num + scaleTimer;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		scaleTimer = num2;
		Transform transform = element.transform;
		float num3 = scaleTimer;
		if (scaleEasing == EEasing.InOutCirc)
		{
			num3 = Easing.InOutCirc(num3);
		}
		else if (scaleEasing == EEasing.OutCirc)
		{
			num3 = Easing.OutCirc(num3);
		}
		if (!(0f > num3))
		{
			if (num3 > 1f)
			{
				num3 = 1f;
			}
		}
		else
		{
			num3 = 0f;
		}
		float num4 = default(float);
		transform.localScale = (Vector3)(&num4);
	}

	private float GetEaseValue(float value, EEasing easing)
	{
		return easing switch
		{
			EEasing.InOutCirc => Easing.InOutCirc(value), 
			EEasing.OutCirc => Easing.OutCirc(value), 
			_ => value, 
		};
	}
}
