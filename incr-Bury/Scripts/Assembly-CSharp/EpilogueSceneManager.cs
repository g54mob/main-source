using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EpilogueSceneManager : MonoBehaviour
{
	public static EpilogueSceneManager Singleton;

	[Header("Texts")]
	private int textBit_Index;

	private bool textSequenceActive;

	[SerializeField]
	private List<GameObject> textBits;

	private float currentFrameTiming;

	[SerializeField]
	private GameObject pressAnyButton_Text;

	private float textHint_Timer = 4f;

	private float textHint_Timer_Curr;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private void Start()
	{
		StartCoroutine(DelayBeforeStartingTextSequence());
		HideAllTextBits();
		pressAnyButton_Text.SetActive(value: false);
	}

	private void Update()
	{
		HandleTextSequence();
	}

	private IEnumerator DelayBeforeStartingTextSequence()
	{
		yield return new WaitForSeconds(4f);
		StartTextSequence();
	}

	private void StartTextSequence()
	{
		textHint_Timer_Curr = textHint_Timer;
		textBit_Index = 0;
		textSequenceActive = true;
		ShowTextBit(0);
	}

	private void HandleTextSequence()
	{
		if (!textSequenceActive)
		{
			return;
		}
		if (textHint_Timer_Curr > 0f)
		{
			textHint_Timer_Curr -= Time.deltaTime;
		}
		else
		{
			pressAnyButton_Text.SetActive(value: true);
		}
		if (Input.anyKeyDown)
		{
			pressAnyButton_Text.SetActive(value: false);
			if (textBit_Index + 1 < textBits.Count)
			{
				textBit_Index++;
				ShowTextBit(textBit_Index);
				textHint_Timer_Curr = textHint_Timer;
			}
			else
			{
				textSequenceActive = false;
				Debug.Log("Sequence over!");
				SceneManager.LoadScene("Credits");
			}
		}
	}

	private void HideAllTextBits()
	{
		foreach (GameObject textBit in textBits)
		{
			textBit.SetActive(value: false);
		}
	}

	private void ShowTextBit(int _index)
	{
		HideAllTextBits();
		if ((bool)textBits[_index])
		{
			textBits[_index].SetActive(value: true);
		}
	}
}
