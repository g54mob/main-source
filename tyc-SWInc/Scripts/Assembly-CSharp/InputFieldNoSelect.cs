using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputFieldNoSelect : InputField
{
	private int _fP;

	private int _aP;

	private bool _updateP;

	public override void OnDeselect(BaseEventData eventData)
	{
		_aP = base.selectionAnchorPosition;
		_fP = base.selectionFocusPosition;
		base.OnDeselect(eventData);
	}

	public override void OnSelect(BaseEventData eventData)
	{
		_updateP = true;
		base.OnSelect(eventData);
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		if (_updateP)
		{
			base.selectionAnchorPosition = _aP;
			base.selectionFocusPosition = _fP;
			_updateP = false;
		}
	}
}
