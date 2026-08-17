using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestItem : MonoBehaviour
{
	public RawImage icon;

	public TextMeshProUGUI t_amountText;

	public AudioClip clipPositive;

	public AudioClip clipNegative;

	public AudioSource audioSource;

	public unsafe void Set(ItemData itemData, int amount)
	{
		//IL_0029: Expected O, but got Ref
		//IL_0058: Expected O, but got Ref
		icon.texture = itemData.icon;
		object obj = default(object);
		t_amountText.color = (Color)(&obj);
		if (amount < 0)
		{
			t_amountText.color = (Color)(&obj);
		}
		int num = default(int);
		string text = num.ToString();
		t_amountText.text = text;
		if (num <= 0)
		{
			audioSource.clip = clipNegative;
		}
		else
		{
			audioSource.clip = clipPositive;
		}
	}
}
