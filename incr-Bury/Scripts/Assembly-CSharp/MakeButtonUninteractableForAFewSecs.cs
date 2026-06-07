using UnityEngine;
using UnityEngine.UI;

public class MakeButtonUninteractableForAFewSecs : MonoBehaviour
{
	private float timeBeforeActive = 0.4f;

	private Button ourButton;

	private void Awake()
	{
		ourButton = GetComponent<Button>();
	}

	private void Start()
	{
		ourButton.interactable = false;
	}

	private void Update()
	{
		if (timeBeforeActive > 0f)
		{
			timeBeforeActive -= Time.deltaTime;
			return;
		}
		ourButton.interactable = true;
		base.enabled = false;
	}
}
