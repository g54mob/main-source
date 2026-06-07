using UnityEngine;

public class InspectCropButton : MonoBehaviour
{
	[SerializeField]
	private Sprite inspectIcontip;

	public void SelectInspect()
	{
		GameManager.ins.state = GameManager.State.CanInspectCrops;
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
		TooltipSystem.ShowIcontip(inspectIcontip);
	}
}
