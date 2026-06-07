using UnityEngine;

public class VirusEvent : MonoBehaviour
{
	private SpriteRenderer sr;

	private bool canInteract;

	[SerializeField]
	private GameObject virus;

	private Vector3 hoverSize = new Vector3(1.125f, 1.125f);

	private int numberOfClicks = 20;

	private float timer1;

	private float timer0;

	private float timerA;

	private void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		sr.enabled = false;
		if (GameManager.ins.missing404 == " found! ")
		{
			virus.SetActive(value: true);
			virus.transform.position = Vector2.zero;
			canInteract = false;
		}
		else
		{
			virus.SetActive(value: false);
			canInteract = true;
		}
	}

	private void Update()
	{
		if (canInteract && Input.GetMouseButtonDown(0) && mouseIsInsideHoverOverArea())
		{
			numberOfClicks--;
			if (numberOfClicks < 0)
			{
				sr.enabled = true;
			}
			if (numberOfClicks < -1)
			{
				numberOfClicks = 10;
				sr.enabled = false;
			}
		}
		if (sr.enabled && Input.GetKeyDown(KeyCode.Alpha1))
		{
			timer1 = 2f;
		}
		if (sr.enabled && Input.GetKeyDown(KeyCode.Alpha0))
		{
			timer0 = 2f;
		}
		if (sr.enabled && Input.GetKeyDown(KeyCode.A))
		{
			timerA = 2f;
		}
		if (timer1 > 0f)
		{
			timer1 -= Time.deltaTime;
		}
		if (timer0 > 0f)
		{
			timer0 -= Time.deltaTime;
		}
		if (timerA > 0f)
		{
			timerA -= Time.deltaTime;
		}
		if (timer1 > 0f && timer0 > 0f && timerA > 0f)
		{
			virus.SetActive(value: true);
			virus.transform.position = base.transform.position;
			canInteract = false;
			sr.enabled = false;
			GameManager.ins.missing404 = " found! ";
		}
	}

	private bool mouseIsInsideHoverOverArea()
	{
		bool result = false;
		Vector2 mousePositionInWorld = GameManager.ins.mousePositionInWorld;
		if (mousePositionInWorld.x < base.transform.position.x + hoverSize.x / 2f && mousePositionInWorld.x > base.transform.position.x - hoverSize.x / 2f && mousePositionInWorld.y < base.transform.position.y + hoverSize.y / 2f && mousePositionInWorld.y > base.transform.position.y - hoverSize.y / 2f)
		{
			result = true;
		}
		return result;
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(base.transform.position, hoverSize);
	}
}
