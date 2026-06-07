using UnityEngine;

public class CharacterDeathMemory : MonoBehaviour
{
	public string charName;

	public bool skipIfDead;

	private void Start()
	{
		if (skipIfDead && PlayerPrefs.GetInt(charName + " is dead") == 1)
		{
			CurrentDayManager.Instance.Invoke("CompleteOccurrence", 0.1f);
			Object.Destroy(base.gameObject);
		}
	}

	public void Kill()
	{
		PlayerPrefs.SetInt(charName + " is dead", 1);
	}
}
