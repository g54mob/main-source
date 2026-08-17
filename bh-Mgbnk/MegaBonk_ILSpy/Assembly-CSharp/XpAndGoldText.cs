using Assets.Scripts.Utility;
using TMPro;
using UnityEngine;

public class XpAndGoldText : MonoBehaviour
{
	public string prefix;

	public TextMeshProUGUI text;

	private float timeout = 1f;

	private int amount;

	private float startFadeTime;

	private float fadeTime = 0.75f;

	private float timeToFade = 0.75f;

	public unsafe void Add(int amount)
	{
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected I4, but got Unknown
		//IL_00b7: Expected O, but got Ref
		if (amount >= 0)
		{
			GameObject gameObject = base.gameObject;
			if (!gameObject.activeInHierarchy)
			{
				GameObject gameObject2 = base.gameObject;
				gameObject2.SetActive(value: true);
				this.amount = 0;
			}
			Transform transform = base.transform;
			if (2f > transform.localScale.x)
			{
				Transform transform2 = base.transform;
				Vector3 localScale = transform2.localScale;
				object obj = default(object);
				transform2.localScale = (Vector3)(&obj);
			}
			int num = this.amount + amount;
			this.amount = num;
			int num2 = this + 52;
			string text = ((int*)num2)->ToString();
			string text2 = prefix + text;
			this.text.text = text2;
			float num3 = MyTime.time + timeToFade;
			startFadeTime = num3;
		}
	}

	private unsafe void Update()
	{
		//IL_0136: Invalid comparison between I4 and F4
		//IL_004e: Expected F4, but got I4
		//IL_0060: Expected O, but got Ref
		//IL_01af: Invalid comparison between I4 and F4
		//IL_00be: Expected F4, but got I4
		Transform transform = base.transform;
		Transform transform2 = base.transform;
		Vector3 localScale = transform2.localScale;
		float deltaTime = Time.deltaTime;
		float num = deltaTime * 6f;
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
		TMP_Text tMP_Text;
		float alpha;
		if (!(MyTime.time > startFadeTime))
		{
			tMP_Text = text;
			alpha = 1f;
		}
		else
		{
			float num3 = MyTime.time - startFadeTime;
			float num4 = num3 / timeToFade;
			if (!(0f > num4))
			{
				if (num4 > 1f)
				{
					num4 = 1f;
				}
			}
			else
			{
				num4 = 0f;
			}
			tMP_Text = text;
			alpha = 1f - num4;
		}
		tMP_Text.alpha = alpha;
		float num5 = fadeTime + startFadeTime;
		if (MyTime.time > num5)
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
		}
	}
}
