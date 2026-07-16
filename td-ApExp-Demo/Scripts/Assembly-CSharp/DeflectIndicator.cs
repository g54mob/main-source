using UnityEngine;
using UnityEngine.UI;

public class DeflectIndicator : MonoBehaviour
{
	[SerializeField]
	private GameObject deflectVertLayoutGroup;

	[SerializeField]
	private Image[] deflectCDImages;

	[SerializeField]
	private Image[] deflectCDFills;

	public void SetDeflectsActive(bool active)
	{
		deflectVertLayoutGroup.SetActive(active);
	}

	public void SetDeflectChargeMax(int max)
	{
		for (int i = 0; i < deflectCDImages.Length; i++)
		{
			if (i >= max)
			{
				deflectCDImages[i].gameObject.SetActive(value: false);
			}
			else
			{
				deflectCDImages[i].gameObject.SetActive(value: true);
			}
		}
	}

	public void UpdateDeflect(float normalizedTime)
	{
		for (int i = 0; i < deflectCDImages.Length; i++)
		{
			if (i > Train.Instance.moduleDeflect.deflectCharges)
			{
				deflectCDFills[i].fillAmount = 0f;
			}
			else if (i == Train.Instance.moduleDeflect.deflectCharges)
			{
				deflectCDFills[i].fillAmount = normalizedTime;
			}
			else
			{
				deflectCDFills[i].fillAmount = 1f;
			}
		}
	}
}
