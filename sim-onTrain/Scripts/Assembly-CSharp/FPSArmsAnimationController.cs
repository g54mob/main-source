using HQFPSTemplate;
using UnityEngine;

public class FPSArmsAnimationController : MonoBehaviour
{
	[Header("References")]
	[Tooltip("FPS Arms Animator - GetComponent ile otomatik bulunur veya manuel atanabilir")]
	public Animator fpsArmsAnimator;

	[Header("Debug")]
	[SerializeField]
	private bool isCPRActive;

	private EastUpPlayerItemManager itemManager;

	private void Start()
	{
		itemManager = GetComponent<EastUpPlayerItemManager>();
		UpdateAnimatorReference();
	}

	private void UpdateAnimatorReference()
	{
		if (!(itemManager != null))
		{
			return;
		}
		EquipmentInventoryAdder fpsInventory = itemManager.fpsInventory;
		if (fpsInventory != null && fpsInventory.equipmentHandler != null && fpsInventory.equipmentHandler.FPArmsHandler != null)
		{
			Animator animator = fpsInventory.equipmentHandler.FPArmsHandler.Animator;
			if (animator != null)
			{
				fpsArmsAnimator = animator;
			}
		}
	}

	private void Update()
	{
		if (isCPRActive)
		{
			UpdateAnimatorReference();
			if (fpsArmsAnimator != null)
			{
				fpsArmsAnimator.SetBool(AnimationKeys.CPRAnimation, value: true);
			}
		}
	}

	public void StartCPR()
	{
		isCPRActive = true;
		if (itemManager != null)
		{
			itemManager.SetCPRHolster(active: true);
		}
		UpdateAnimatorReference();
		if (fpsArmsAnimator != null)
		{
			fpsArmsAnimator.SetBool(AnimationKeys.CPRAnimation, value: true);
		}
		Debug.Log("[FPSArmsAnimationController] CPR animation started");
	}

	public void StopCPR()
	{
		isCPRActive = false;
		UpdateAnimatorReference();
		if (fpsArmsAnimator != null)
		{
			fpsArmsAnimator.SetBool(AnimationKeys.CPRAnimation, value: false);
		}
		if (itemManager != null)
		{
			itemManager.SetCPRHolster(active: false);
		}
		Debug.Log("[FPSArmsAnimationController] CPR animation stopped");
	}

	public bool IsCPRActive()
	{
		return isCPRActive;
	}
}
