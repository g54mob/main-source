using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PeopleTemplate : MonoBehaviour
{
	public enum EntryExitType
	{
		SLIDE = 0,
		SCALE = 1
	}

	public GameObject textBox;

	public GameObject portrait;

	public GameObject dialogueBoxHolder;

	public int holderNum;

	public bool alreadyLoaded;

	public EntryExitType entryExitType;

	private GameObject instantiatedTextBox;

	private GameObject instantiatedPortrait;

	private static float easeDuration = 0.25f;

	private static Vector3 easeInVector = new Vector3(40f, 0f, 0f);

	private static Vector3 easeOutVector = new Vector3(40f, 0f, 0f);

	private Vector3 defaultScale;

	private float maxWidth;

	private TextMeshPro textRef;

	private Inchworm inchworm;

	private ConvoPortrait portraitScriptRef;

	private void Awake()
	{
		inchworm = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
	}

	public void PreloadText()
	{
		SetText("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-=`[]\\;',./~!@#$%^&*()_+{}|:\"<>?", playAudio: false);
		HideText();
	}

	public void loadTemplate(Inchworm.EaseCallback callback)
	{
		if (!alreadyLoaded)
		{
			base.gameObject.transform.position = Vector3.zero;
		}
		instantiatedTextBox = textBox;
		instantiatedPortrait = portrait;
		instantiatedTextBox.SetActive(value: true);
		instantiatedPortrait.SetActive(value: true);
		textRef = instantiatedTextBox.GetComponentInChildren<TextMeshPro>();
		PreloadText();
		portraitScriptRef = instantiatedPortrait.GetComponentInChildren<ConvoPortrait>();
		if (alreadyLoaded)
		{
			dialogueBoxHolder.SetActive(value: true);
			dialogueBoxHolder.GetComponent<DialogueBox>().RequestScaleLoad(callback);
			return;
		}
		List<GameObject> list = new List<GameObject>();
		list.Add(instantiatedTextBox);
		inchworm.RequestEase(list, -easeInVector, easeDuration, adjustStartingPos: true, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, callback);
		list = new List<GameObject>();
		list.Add(instantiatedPortrait);
		inchworm.RequestEase(list, easeInVector, easeDuration * 0.75f);
	}

	public void RequestEmotionChange(Emotion newEmotion)
	{
		portraitScriptRef.SetEmotion(newEmotion);
	}

	public void UnloadTemplate(Inchworm.EaseCallback callback, Vector3? easeVector = null)
	{
		SetText("");
		Vector3 vector = ((!easeVector.HasValue) ? easeOutVector : easeVector.Value);
		if (entryExitType == EntryExitType.SLIDE)
		{
			inchworm.RequestEase(instantiatedTextBox, vector, easeDuration, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticIn, Inchworm.EaseType.Position, callback);
			inchworm.RequestEase(instantiatedPortrait, -vector, easeDuration * 0.75f, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticIn);
		}
		else
		{
			instantiatedPortrait.SetActive(value: false);
			dialogueBoxHolder.GetComponent<DialogueBox>().RequestScaleUnload(callback);
		}
	}

	public float GetMaxWidth()
	{
		if (maxWidth == 0f)
		{
			maxWidth = textRef.rectTransform.rect.width;
		}
		return maxWidth;
	}

	public void SetText(string text, bool playAudio = true)
	{
		if (instantiatedTextBox == null)
		{
			Debug.LogError("No text box has been instantiated yet.");
		}
		else
		{
			textRef.text = text;
		}
	}

	public void SetMaxVisibleCharacters(int maxChars)
	{
		if (instantiatedTextBox == null)
		{
			Debug.LogError("No text box has been instantiated yet.");
		}
		else
		{
			textRef.maxVisibleCharacters = maxChars;
		}
	}

	public void HideText()
	{
		if (instantiatedTextBox == null)
		{
			Debug.LogError("No text box has been instantiated yet.");
			return;
		}
		defaultScale = textRef.transform.localScale;
		textRef.transform.localScale = Vector3.zero;
	}

	public void UnhideText()
	{
		if (instantiatedTextBox == null)
		{
			Debug.LogError("No text box has been instantiated yet.");
		}
		else
		{
			textRef.transform.localScale = defaultScale;
		}
	}

	public void Unload(bool destroyPortrait = true)
	{
		if (destroyPortrait)
		{
			Object.Destroy(instantiatedTextBox);
			Object.Destroy(instantiatedPortrait);
		}
		else
		{
			instantiatedTextBox.SetActive(value: false);
		}
		portraitScriptRef = null;
	}
}
