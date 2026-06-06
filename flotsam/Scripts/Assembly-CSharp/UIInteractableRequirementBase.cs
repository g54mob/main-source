using I2.Loc;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(UIInteractable))]
public abstract class UIInteractableRequirementBase : SceneBehaviour
{
	[SerializeField]
	private LocalizedString _tooltipMessage;

	private bool _isMet;

	public LocalizedString TooltipMessage => _tooltipMessage;

	public bool IsMet
	{
		get
		{
			return _isMet;
		}
		protected set
		{
			if (_isMet != value)
			{
				_isMet = value;
				if (this.ChangedEvent != null)
				{
					this.ChangedEvent();
				}
			}
		}
	}

	public event UnityAction ChangedEvent;

	public abstract bool ReturnIsMet();
}
