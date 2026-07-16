using UnityEngine;

public class ChatBubbleTrigger : MonoBehaviour
{
	private BoxCollider2D col;

	[SerializeField]
	private GameObject chatBubble;

	private void Start()
	{
		col = GetComponent<BoxCollider2D>();
	}

	private void Update()
	{
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		chatBubble.SetActive(value: true);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		chatBubble.SetActive(value: false);
	}
}
