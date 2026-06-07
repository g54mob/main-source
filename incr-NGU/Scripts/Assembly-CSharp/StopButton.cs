using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StopButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public BossController bc;

	public Button stopButton;

	public void OnPointerClick(PointerEventData eventData)
	{
		bc.beginFight();
		stopButton.gameObject.SetActive(value: false);
	}

	private void Start()
	{
		stopButton.gameObject.SetActive(value: false);
	}

	private void Update()
	{
	}
}
