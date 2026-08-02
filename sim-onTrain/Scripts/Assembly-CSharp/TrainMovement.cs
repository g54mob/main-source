using UnityEngine;
using UnityEngine.UI;

public class TrainMovement : MonoBehaviour
{
	[Header("Movement Settings")]
	public float speed = 10f;

	public KeyCode startKey = KeyCode.Space;

	[Header("UI Settings")]
	public Text timerText;

	[Header("Debug Info")]
	[SerializeField]
	private bool isMoving;

	[SerializeField]
	private float timer;

	[SerializeField]
	private string timerDisplay = "00:00";

	private void Start()
	{
		if (timerText != null)
		{
			timerText.text = "00:00";
		}
		timerDisplay = "00:00";
	}

	private void Update()
	{
		if (Input.GetKeyDown(startKey) && !isMoving)
		{
			isMoving = true;
			timer = 0f;
		}
		if (isMoving)
		{
			base.transform.Translate(0f, 0f, speed * Time.deltaTime);
			timer += Time.deltaTime;
			UpdateTimerUI();
		}
	}

	private void UpdateTimerUI()
	{
		int num = Mathf.FloorToInt(timer / 60f);
		int num2 = Mathf.FloorToInt(timer % 60f);
		string text = (timerDisplay = $"{num:00}:{num2:00}");
		if (timerText != null)
		{
			timerText.text = text;
		}
	}

	public void StopMovement()
	{
		isMoving = false;
	}

	public void ResumeMovement()
	{
		isMoving = true;
	}
}
