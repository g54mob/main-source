using TMPro;
using UnityEngine;

public class GameTitle : MonoBehaviour
{
	public ParticleSystem GoldParticle;

	public TMP_Text Version;

	public TMP_Text LongEdition;

	public TMP_Text RelaxEdition;

	private int _garbageCount;

	private void Start()
	{
		Version.text = Installation.GetVersionString();
		LongEdition.gameObject.SetActive(value: false);
		RelaxEdition.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		VerifyGarbage();
		if (CharDisplay.HasHat)
		{
			LongEdition.gameObject.SetActive(value: true);
		}
		else
		{
			LongEdition.gameObject.SetActive(value: false);
		}
		if (CharDisplay.HasRelax)
		{
			RelaxEdition.gameObject.SetActive(value: true);
		}
		else
		{
			RelaxEdition.gameObject.SetActive(value: false);
		}
	}

	private void VerifyGarbage()
	{
		BoxCollider2D component = GetComponent<BoxCollider2D>();
		Collider2D[] array = Physics2D.OverlapBoxAll(component.bounds.center, component.bounds.size, 0f);
		for (int i = 0; i < array.Length; i++)
		{
			Garbage component2 = array[i].gameObject.GetComponent<Garbage>();
			if (component2 != null)
			{
				component2.gameObject.SetActive(value: false);
				Object.Destroy(component2);
				GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ui_title_fill);
				GoldParticle.Play();
				_garbageCount++;
				ChangeTitleColor();
			}
		}
	}

	private void ChangeTitleColor()
	{
		int num = 1;
		int num2 = 3;
		if (_garbageCount >= num && _garbageCount <= num2)
		{
			float num3 = (float)_garbageCount / (float)num2;
			if (num3 < 0f)
			{
				num3 = 0f;
			}
			if (num3 > 1f)
			{
				num3 = 1f;
			}
			GetComponent<TMP_Text>().color = new Color(1f, 1f - num3, 1f - num3);
		}
		if (_garbageCount >= num2 && !CharDisplay.HasHat)
		{
			CharDisplay.HasHat = true;
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ui_title_fully_fill);
		}
	}
}
