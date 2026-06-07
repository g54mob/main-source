using UnityEngine;

public class RemoveButton : MonoBehaviour
{
	[SerializeField]
	private Sprite removeIcontip;

	public void SelectRemove()
	{
		GameManager.ins.state = GameManager.State.CanRemoveCrop;
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
		TooltipSystem.ShowIcontip(removeIcontip);
	}

	public void SelectRemoveCropSign()
	{
		GameManager.ins.state = GameManager.State.CanRemoveSign;
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
		TooltipSystem.ShowIcontip(removeIcontip);
	}
}
