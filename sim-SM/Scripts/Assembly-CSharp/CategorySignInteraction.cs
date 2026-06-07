using UnityEngine;

public class CategorySignInteraction : Interaction
{
	private CategorySign m_CategorySign;

	private bool m_PlacingMode;

	public NetworkCategorySignInteraction NetworkCategorySignInteraction;

	private PlayerInstance m_PlayerInstance;

	private bool m_InAnimationTransition;

	public override IInteractable Interactable
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public CategorySign CurrentCategorySign => null;

	public override bool Enable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool PlacingMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private PlayerInstance PlayerInstance => null;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnUse(bool down)
	{
	}

	private void OnCancel()
	{
	}

	private void OnRotate(bool clockvise)
	{
	}

	private void OnClose()
	{
	}

	private void BoxUpCategorySign()
	{
	}

	public void BoxUpCategorySignNetwork()
	{
	}

	private void TryPlaceCategorySign()
	{
	}

	public void PlaceCategorySign(Vector3 playSoundPosition)
	{
	}

	public void CloseCategoryMenu()
	{
	}

	public void SetCategorySign(CategorySign CategorySign)
	{
	}

	public void MovingHints(bool show)
	{
	}

	public void OnDayFinished()
	{
	}

	public void CancelInteractionForOnlyMultiplayer()
	{
	}
}
