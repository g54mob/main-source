using UnityEngine;

public class PlayerEventScript : MonoBehaviour, ISaveObject
{
	public struct EventData
	{
		public bool DoingFirstPause;

		public bool DidRadioChatter;

		public bool DidFirstMusic;

		public bool PressedMap;

		public bool PressedBriefing;
	}

	public EventData MyData;

	private float FirstPauseDelay;

	public float FirstPauseSpeed;

	public AudioSource RadioChatter;

	public AudioSource FirstMusic;

	public CanvasGroup Tutorial;

	public float DepthIndicatorSpeed;

	public DepthMeterScript Meter;

	private SaveLoadManagerScript Save;

	public string MyID => "Player_Event_Manager";

	private void Start()
	{
		FirstPauseDelay = 1f;
		MyData.DoingFirstPause = true;
		MyData.DidRadioChatter = false;
		Save = GameObject.Find("GameManager").GetComponent<SaveLoadManagerScript>();
	}

	private void LateUpdate()
	{
		if (!MyData.DidRadioChatter)
		{
			RadioChatter.Play();
			MyData.DidRadioChatter = true;
		}
		if (!MyData.DidFirstMusic)
		{
			FirstMusic.Play();
			MyData.DidFirstMusic = true;
		}
		if (MyData.DoingFirstPause)
		{
			Meter.IncreaseLerp(Time.deltaTime * DepthIndicatorSpeed);
		}
		FirstPauseDelay -= Time.deltaTime * FirstPauseSpeed;
		if (FirstPauseDelay <= 0f)
		{
			_ = MyData.DoingFirstPause;
			FirstPauseDelay = 0f;
			MyData.DoingFirstPause = false;
			Tutorial.alpha = 1f;
		}
		if (MyData.PressedMap && MyData.PressedBriefing)
		{
			Tutorial.alpha = 0f;
		}
	}

	public object SaveData()
	{
		return MyData;
	}

	public void LoadData(object dataIn)
	{
		MyData = (EventData)dataIn;
	}
}
