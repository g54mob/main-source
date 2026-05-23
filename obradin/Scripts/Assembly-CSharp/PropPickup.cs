using UnityEngine;

public class PropPickup : MonoBehaviour
{
	public string inventoryId;

	public string takenAnimState;

	public string postTakenAnimState;

	public string dialogId;

	private Animator modelAnimator;

	private bool taken;

	private void OnEnable()
	{
		if (modelAnimator == null)
		{
			modelAnimator = GetComponentInChildren<Animator>();
		}
		if (SaveData.it.HaveInventory(inventoryId))
		{
			ApplyTaken();
		}
	}

	private void Update()
	{
		if (!taken && modelAnimator.GetCurrentAnimatorStateInfo(0).IsName(takenAnimState))
		{
			ApplyTaken();
		}
	}

	private void ApplyTaken()
	{
		taken = true;
		if (!SaveData.it.HaveInventory(inventoryId))
		{
			SaveData.it.GiveInventory(inventoryId);
			if (Game.instance != null && !string.IsNullOrEmpty(dialogId))
			{
				Game.instance.ShowDialog(dialogId, new Dialog.Extra().SetWantBlackFramesAfter(true));
			}
		}
		if (!string.IsNullOrEmpty(postTakenAnimState))
		{
			modelAnimator.Play(postTakenAnimState);
		}
	}
}
