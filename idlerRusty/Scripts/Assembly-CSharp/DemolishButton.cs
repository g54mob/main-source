using UnityEngine;

public class DemolishButton : MonoBehaviour
{
	[SerializeField]
	private Sprite removeIcontip;

	public void SelectDemolish()
	{
		GameManager.ins.state = GameManager.State.CanDemolish;
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
		TooltipSystem.ShowIcontip(removeIcontip);
	}
}
