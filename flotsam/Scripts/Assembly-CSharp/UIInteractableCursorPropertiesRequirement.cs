using UnityEngine;
using UnityEngine.UI;

public class UIInteractableCursorPropertiesRequirement : UIInteractableRequirementBase
{
	[SerializeField]
	private CursorProperties _cursorProperties;

	private Selectable _selectable;

	protected override void Awake()
	{
		base.Awake();
		_selectable = GetComponent<Selectable>();
		_cursorProperties.OnChangeCanBeDeactivated.AddListener(UpdateInteractable);
	}

	private void Start()
	{
		UpdateInteractable();
	}

	private void OnDestroy()
	{
		_cursorProperties.OnChangeCanBeDeactivated.RemoveListener(UpdateInteractable);
	}

	private void UpdateInteractable()
	{
		base.IsMet = ReturnIsMet();
	}

	public override bool ReturnIsMet()
	{
		if (!(GameManager.CursorManager.Properties != _cursorProperties))
		{
			return _cursorProperties.CanBeDeactivated;
		}
		return true;
	}
}
