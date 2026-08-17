using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOnEnable : MonoBehaviour
{
	public RawImage cg;

	public TextMeshProUGUI text;

	private unsafe void OnEnable()
	{
		//IL_005f: Expected O, but got Ref
		cg.CrossFadeAlpha(0f, 0f, ignoreTimeScale: true);
		cg.CrossFadeAlpha(1f, 0.2f, ignoreTimeScale: true);
		Transform transform = text.transform;
		object obj = default(object);
		transform.localScale = (Vector3)(&obj);
	}

	private unsafe void Update()
	{
		//IL_00bf: Invalid comparison between I4 and F4
		//IL_008a: Expected F4, but got I4
		//IL_009c: Expected O, but got Ref
		Transform transform = text.transform;
		Transform transform2 = text.transform;
		Vector3 localScale = transform2.localScale;
		float deltaTime = Time.deltaTime;
		float num = deltaTime * 15f;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = default(float);
		transform.localScale = (Vector3)(&num2);
	}
}
