using UnityEngine;
using UnityEngine.UI;

public class FishFarmHatcherySlot : MonoBehaviour
{
	private enum State
	{
		None = 0,
		Empty = 1,
		ReserveItem = 2,
		ImportItem = 3,
		Hungry = 4,
		Active = 5
	}

	[SerializeField]
	private Image _transitIcon;

	[SerializeField]
	private Image _activeIcon;

	[SerializeField]
	private Slider _slider;

	[Header("Animator")]
	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private string _emptyTrigger = "Empty";

	[SerializeField]
	private string _reserveItemTrigger = "ReserveItem";

	[SerializeField]
	private string _importItemTrigger = "ImportItem";

	[SerializeField]
	private string _hungryTrigger = "Hungry";

	[SerializeField]
	private string _activeTrigger = "Active";

	[SerializeField]
	private string _selectedParameter = "Selected";

	private State _activeState;

	private string _setTrigger;

	public AquaFarm.Fish BroodFish { get; private set; }

	private void OnEnable()
	{
		_setTrigger = null;
		SetState(EvaluateState());
	}

	private void LateUpdate()
	{
		State state = EvaluateState();
		if (_activeState != state)
		{
			SetState(EvaluateState());
		}
		if (BroodFish != null)
		{
			_slider.value = BroodFish.Progress;
		}
	}

	public void Initialize(AquaFarm.Fish broodfish, FishProperties activeFishProperties)
	{
		BroodFish = broodfish;
		_animator.SetBool(_selectedParameter, broodfish != null && broodfish.FishProperties == activeFishProperties);
		SetState(EvaluateState());
	}

	private void SetState(State state)
	{
		_activeState = state;
		switch (_activeState)
		{
		case State.Empty:
			_slider.value = 0f;
			SetAnimatorTrigger(_emptyTrigger);
			break;
		case State.ReserveItem:
			SetAnimatorTrigger(_reserveItemTrigger);
			_transitIcon.overrideSprite = BroodFish.FishProperties.Silhouette;
			break;
		case State.ImportItem:
			SetAnimatorTrigger(_importItemTrigger);
			_transitIcon.overrideSprite = BroodFish.FishProperties.Silhouette;
			break;
		case State.Hungry:
			if (string.IsNullOrEmpty(BroodFish.FishProperties.HungryTrigger))
			{
				SetAnimatorTrigger(_hungryTrigger);
			}
			else
			{
				SetAnimatorTrigger(BroodFish.FishProperties.HungryTrigger);
			}
			break;
		case State.Active:
			if (string.IsNullOrEmpty(BroodFish.FishProperties.ActiveTrigger))
			{
				SetAnimatorTrigger(_activeTrigger);
			}
			else
			{
				SetAnimatorTrigger(BroodFish.FishProperties.ActiveTrigger);
			}
			break;
		}
	}

	private void SetAnimatorTrigger(string trigger)
	{
		if (!(_setTrigger == trigger))
		{
			_animator.ResetTrigger(_emptyTrigger);
			_animator.ResetTrigger(_reserveItemTrigger);
			_animator.ResetTrigger(_importItemTrigger);
			_animator.ResetTrigger(_hungryTrigger);
			_animator.ResetTrigger(_activeTrigger);
			_animator.SetTrigger(trigger);
			_setTrigger = trigger;
		}
	}

	private State EvaluateState()
	{
		if (BroodFish == null)
		{
			return State.Empty;
		}
		if (BroodFish.BroodItem == null)
		{
			return State.ReserveItem;
		}
		if (BroodFish.IsWatingForBroodItem())
		{
			return State.ImportItem;
		}
		if (BroodFish.Hungry)
		{
			return State.Hungry;
		}
		return State.Active;
	}
}
