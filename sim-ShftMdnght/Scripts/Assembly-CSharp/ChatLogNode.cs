using System.Collections;
using TMPro;
using UnityEngine;

public class ChatLogNode : MonoBehaviour
{
	public TextMeshProUGUI nameText;

	public TextMeshProUGUI subtitleText;

	public GameObject correct;

	public GameObject incorrect;

	public Animator anim;

	public void Start_()
	{
		anim.SetBool("Show", value: true);
		StartCoroutine(RevealTextUniversal());
	}

	private IEnumerator RevealTextUniversal()
	{
		yield return null;
		subtitleText.ForceMeshUpdate();
		int total = subtitleText.textInfo.characterCount;
		subtitleText.maxVisibleCharacters = 0;
		float charProgress = 0f;
		int visible = 0;
		while (visible < total)
		{
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			float num = Mathf.Max(1E-05f, 0.022f);
			charProgress += unscaledDeltaTime / num;
			int num2 = (int)charProgress;
			if (num2 > 0)
			{
				charProgress -= (float)num2;
				visible = Mathf.Min(total, visible + num2);
				subtitleText.maxVisibleCharacters = visible;
			}
			yield return null;
		}
		subtitleText.maxVisibleCharacters = total;
		subtitleText.ForceMeshUpdate();
		Invoke("Disappear", 3f);
	}

	private void Disappear()
	{
		anim.SetBool("Show", value: false);
	}
}
