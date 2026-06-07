using UnityEngine;

public class MoveButton : MonoBehaviour
{
	[SerializeField]
	private Sprite moveIcontip;

	public void SelectMoveBuilding()
	{
		GridSystem.ins.EnableMovingLine(value: false);
		GameManager.ins.state = GameManager.State.CanMoveBuilding;
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
		TooltipSystem.ShowIcontip(moveIcontip);
	}

	public void SelectMoveAnimal()
	{
		GridSystem.ins.EnableMovingLine(value: false);
		GameManager.ins.state = GameManager.State.CanMoveAnimal;
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
		TooltipSystem.ShowIcontip(moveIcontip);
	}
}
