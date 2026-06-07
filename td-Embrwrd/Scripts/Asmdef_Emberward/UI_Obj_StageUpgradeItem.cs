using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Obj_StageUpgradeItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Transform node_icon;

	[SerializeField]
	private ParticleSystem particle_SelectedEffect;

	[SerializeField]
	private UI_StageUpgradeUnlockPopup.eUpgradeType upgradeType;

	public UI_StageUpgradeUnlockPopup.eUpgradeType UpgradeType => default(UI_StageUpgradeUnlockPopup.eUpgradeType);

	public void Toggle(bool isOn)
	{
	}

	public void PlaySelectedAnimation()
	{
	}

	public void ShakeEffect(float duration, float strengthMultiplier, float delay)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
