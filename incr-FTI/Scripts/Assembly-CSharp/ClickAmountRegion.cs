using UnityEngine;
using UnityEngine.Events;

public class ClickAmountRegion : MonoBehaviour
{
	public LabelButton button1;

	public LabelButton button5;

	public LabelButton button10;

	public LabelButton button50;

	public LabelButton buttonMax;

	private SingleSelectionManager singleSelectionManager;

	private LabelButton[] _labelButtons;

	public UnityAction<int> changedAmountDelegate;

	public void Initialize()
	{
		singleSelectionManager = new SingleSelectionManager(OnSelectionChangedByManager);
		button1.AddPointerClickTrigger(OnPressed1);
		button5.AddPointerClickTrigger(OnPressed5);
		button10.AddPointerClickTrigger(OnPressed10);
		button50.AddPointerClickTrigger(OnPressed50);
		buttonMax.AddPointerClickTrigger(OnPressedMax);
		_labelButtons = new LabelButton[5];
		_labelButtons[0] = button1;
		_labelButtons[1] = button5;
		_labelButtons[2] = button10;
		_labelButtons[3] = button50;
		_labelButtons[4] = buttonMax;
		LabelButton[] labelButtons = _labelButtons;
		for (int i = 0; i < labelButtons.Length; i++)
		{
			labelButtons[i].buttonState = CustomButtonState.Background;
		}
	}

	public void OnSelectionChangedByManager(EntityId id, bool nextState)
	{
		int intId = id.intId;
		if (intId < _labelButtons.Length)
		{
			_labelButtons[intId].isSelected = nextState;
		}
		if (nextState)
		{
			changedAmountDelegate?.Invoke(intId);
		}
	}

	public void SetAmount()
	{
	}

	private EntityId GetButtonId(int index)
	{
		return new EntityId(index, EntityType.None);
	}

	private void OnPressed1()
	{
		singleSelectionManager.SetSelectionState(GetButtonId(0), nextState: true);
	}

	private void OnPressed5()
	{
		singleSelectionManager.SetSelectionState(GetButtonId(1), nextState: true);
	}

	private void OnPressed10()
	{
		singleSelectionManager.SetSelectionState(GetButtonId(2), nextState: true);
	}

	private void OnPressed50()
	{
		singleSelectionManager.SetSelectionState(GetButtonId(3), nextState: true);
	}

	private void OnPressedMax()
	{
		singleSelectionManager.SetSelectionState(GetButtonId(4), nextState: true);
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
