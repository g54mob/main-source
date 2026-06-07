using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class AssignmentPriorityBoxBase : UIComponent, IPointerClickHandler, IEventSystemHandler
{
	[Header("References")]
	[SerializeField]
	private Image _background;

	[SerializeField]
	private GroupPrefabDisplay _affinityGroup;

	[Header("Animation")]
	[SerializeField]
	private bool _tmpUseAnimation;

	[SerializeField]
	private string _enabledAnimatorParameter = "Enabled";

	[SerializeField]
	private string _priorityAnimatorParameter = "Priority";

	[SerializeField]
	private string _affinityAnimatorParameter = "Affinity";

	[Header("Visuals")]
	[SerializeField]
	private Sprite _noPriority;

	[SerializeField]
	private Sprite _lowestPriority;

	[SerializeField]
	private Sprite _defaultPriority;

	[SerializeField]
	private Sprite _highestPriority;

	[Space(10f)]
	[SerializeField]
	private Image _imageToChange;

	private GUIAudio _GUIAudio;

	public AssignmentPriority Priority { get; private set; }

	public Image Background => _background;

	public void Initialize(AssignmentPriority priority, int affinity = 0)
	{
		_GUIAudio = GetComponent<GUIAudio>();
		Priority = priority;
		if (_tmpUseAnimation)
		{
			SetAnimatorInteger(_affinityAnimatorParameter, affinity);
		}
		else
		{
			_affinityGroup.Display(affinity);
		}
	}

	public virtual void OnPointerClick(PointerEventData eventData)
	{
		if (IsEnabled() && eventData.button != PointerEventData.InputButton.Middle)
		{
			switch (eventData.button)
			{
			case PointerEventData.InputButton.Left:
				UpdatePriority(increase: true);
				break;
			case PointerEventData.InputButton.Right:
				UpdatePriority(increase: false);
				break;
			}
			Refresh();
		}
	}

	public void UpdatePriority(bool increase, bool refresh = false)
	{
		if (!IsEnabled())
		{
			return;
		}
		AssignmentPriority assignmentPriority = Priority;
		if (increase)
		{
			if (assignmentPriority < AssignmentPriority.Highest)
			{
				assignmentPriority++;
			}
		}
		else if (AssignmentPriority.None < assignmentPriority)
		{
			assignmentPriority--;
		}
		if (assignmentPriority == Priority)
		{
			_GUIAudio.PlayGUIClickError();
			return;
		}
		_GUIAudio.OnToggleValueChanged(increase);
		Priority = assignmentPriority;
		if (refresh)
		{
			Refresh();
		}
	}

	public virtual void Refresh()
	{
		SetAnimatorBool(_enabledAnimatorParameter, IsEnabled());
		if (_tmpUseAnimation)
		{
			SetAnimatorInteger(_priorityAnimatorParameter, (int)Priority);
			return;
		}
		switch (Priority)
		{
		case AssignmentPriority.None:
			_imageToChange.sprite = _noPriority;
			break;
		case AssignmentPriority.Lowest:
			_imageToChange.sprite = _lowestPriority;
			break;
		case AssignmentPriority.Default:
			_imageToChange.sprite = _defaultPriority;
			break;
		case AssignmentPriority.Highest:
			_imageToChange.sprite = _highestPriority;
			break;
		}
	}

	protected abstract bool IsEnabled();
}
