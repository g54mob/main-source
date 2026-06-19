using Pug.Sprite;
using Pug.UnityExtensions;
using UnityEngine;

public class UISpecialAim : MonoBehaviour
{
	[SerializeField]
	private Transform _mortarAimPointer;

	[SerializeField]
	private Transform _mortarColliderPointer;

	[SerializeField]
	private SpriteRenderer _mortarAimRenderer;

	[SerializeField]
	private SpriteObject _mortarColliderIconSO;

	private void Awake()
	{
		HideAll();
	}

	public void LateUpdate()
	{
		if (Manager.ecs.ClientWorld == null)
		{
			HideAll();
		}
		base.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
	}

	public void HideAll()
	{
		HideMortarAim();
		HideMortarCollider();
	}

	public void ShowMortarAim(Color color, float pointerFade)
	{
		_mortarAimRenderer.color = color;
		_mortarAimRenderer.SetAlpha(pointerFade);
	}

	public void HideMortarAim()
	{
		_mortarAimRenderer.color = new Color(1f, 1f, 1f, 0f);
	}

	public void ShowMortarCollider(Color color, float pointerFade)
	{
		color.a = pointerFade;
		_mortarColliderIconSO.color = color;
	}

	public void HideMortarCollider()
	{
		_mortarColliderIconSO.color = new Color(1f, 1f, 1f, 0f);
	}

	public void SetMortarAimPosition(Vector2 position)
	{
		_mortarAimPointer.localPosition = RoundToPixelPerfectPosition.RoundPosition(position);
	}

	public void SetMortarColliderPosition(Vector2 position)
	{
		_mortarColliderPointer.localPosition = RoundToPixelPerfectPosition.RoundPosition(position);
	}

	public void UpdateMortarAimState(bool isOnCooldown, bool hasMana)
	{
		int currentAnimationHash = _mortarColliderIconSO.currentAnimationHash;
		bool flag = currentAnimationHash == -1753203768 || currentAnimationHash == -528020642;
		int num = (isOnCooldown ? (-1949102368) : 1260321794);
		if (currentAnimationHash != num && !flag)
		{
			_mortarColliderIconSO.PlayAnimation(num);
		}
	}
}
