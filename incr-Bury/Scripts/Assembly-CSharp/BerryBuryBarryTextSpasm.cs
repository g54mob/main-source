using TMPro;
using UnityEngine;

public class BerryBuryBarryTextSpasm : MonoBehaviour
{
	private TMP_Text tmpText;

	[SerializeField]
	private string[] wordsList;

	[SerializeField]
	private Vector2 timeRandoMinMax;

	private float timer_Curr;

	private void Awake()
	{
		tmpText = GetComponent<TMP_Text>();
	}

	private void Update()
	{
		if (timer_Curr > 0f)
		{
			timer_Curr -= Time.deltaTime;
			return;
		}
		timer_Curr = Random.Range(timeRandoMinMax.x, timeRandoMinMax.y);
		tmpText.text = wordsList[Random.Range(0, wordsList.Length)];
	}
}
