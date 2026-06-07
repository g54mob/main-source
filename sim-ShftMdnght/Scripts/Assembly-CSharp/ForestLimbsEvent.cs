using TMPro;
using UnityEngine;

public class ForestLimbsEvent : MonoBehaviour
{
	public GameObject[] limbs;

	public TextMeshProUGUI limbsRemaining;

	public GameObject limbsObjective;

	public GameObject existingFence;

	private bool done;

	public static ForestLimbsEvent Instance { get; private set; }

	private void OnEnable()
	{
		StoreManager.Instance.NewObjective("Objectives", "Head to the Forest");
	}

	public void StartEvent()
	{
		if (!done)
		{
			CheckHowManyLimbsLeft();
			limbsObjective.SetActive(value: true);
		}
	}

	public void CheckHowManyLimbsLeft()
	{
		if (done)
		{
			return;
		}
		Invoke("CheckHowManyLimbsLeft", 0.3f);
		int num = 0;
		GameObject[] array = limbs;
		for (int i = 0; i < array.Length; i++)
		{
			if (!array[i].activeInHierarchy)
			{
				num++;
			}
		}
		limbsRemaining.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		limbsRemaining.text = num + " / 15";
		if (num >= 15)
		{
			done = true;
			CancelInvoke("CheckHowManyLimbsLeft");
			limbsObjective.SetActive(value: false);
			Invoke("DisableLimbsObjective", 1f);
			Invoke("DisableLimbsObjective", 0.1f);
			Invoke("DisableLimbsObjective", 2f);
			StoreManager.Instance.SetAlert("OBJECTIVE COMPLETE", "green");
			if (ClientPlayer.Instance.isServer)
			{
				CurrentDayManager.Instance.CompleteOccurrence();
			}
		}
	}

	private void DisableLimbsObjective()
	{
		limbsObjective.SetActive(value: false);
	}

	private void Start()
	{
		existingFence.SetActive(value: false);
		Instance = this;
	}
}
