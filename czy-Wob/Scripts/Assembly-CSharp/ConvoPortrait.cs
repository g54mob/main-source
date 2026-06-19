using UnityEngine;

public class ConvoPortrait : MonoBehaviour
{
	public delegate void EmotionChangeCallback(Emotion prevEmotion, Emotion newEmotion);

	private EmotionChangeCallback currentEmotionChangeCallback;

	public GameObject defaultPortrait;

	public GameObject angryPortrait;

	public GameObject happyPortrait;

	public GameObject winkingPortrait;

	public GameObject gaspPortrait;

	private Emotion currentEmotion;

	private InchwormBounce bounceScript;

	private void Start()
	{
		SetAllEmotionsInactive();
		SetEmotion(Emotion.defaultEmotion, requestBounce: false);
		bounceScript = GetComponent<InchwormBounce>();
	}

	public void SetEmotionCallback(EmotionChangeCallback newCallback)
	{
		currentEmotionChangeCallback = newCallback;
	}

	private void SetAllEmotionsInactive()
	{
		foreach (Emotion value in EnumUtils.GetValues<Emotion>())
		{
			GetObjectForEmotion(value).SetActive(value: false);
		}
	}

	public void SetEmotion(Emotion newEmotion, bool requestBounce = true)
	{
		if (currentEmotion != newEmotion)
		{
			if (currentEmotionChangeCallback != null)
			{
				currentEmotionChangeCallback(currentEmotion, newEmotion);
			}
			GetObjectForEmotion(currentEmotion).SetActive(value: false);
			GetObjectForEmotion(newEmotion).SetActive(value: true);
			currentEmotion = newEmotion;
			if (requestBounce && currentEmotion != Emotion.defaultEmotion)
			{
				bounceScript.RequestBounce();
			}
		}
	}

	private GameObject GetObjectForEmotion(Emotion emotion)
	{
		switch (emotion)
		{
		case Emotion.empty:
			return defaultPortrait;
		case Emotion.defaultEmotion:
			return defaultPortrait;
		case Emotion.happy:
			return happyPortrait;
		case Emotion.angry:
			return angryPortrait;
		case Emotion.winking:
			return winkingPortrait;
		case Emotion.gasp:
			return gaspPortrait;
		default:
			Debug.LogError("Invalid emotion passed to GetObjectForEmotion: " + emotion);
			return null;
		}
	}
}
