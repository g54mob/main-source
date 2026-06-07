using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FightButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public BossController bc;

	public Button fightButton;

	public Button stopButton;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!bc.isFighting && bc.character.bossID <= 300)
		{
			bc.beginFight();
			stopButton.gameObject.SetActive(value: true);
		}
	}

	private void Start()
	{
		stopButton.enabled = false;
	}

	private void Update()
	{
	}
}
