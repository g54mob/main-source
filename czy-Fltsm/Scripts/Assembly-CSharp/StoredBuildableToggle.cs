using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoredBuildableToggle : BuildableToggle
{
	public int Count;

	[SerializeField]
	private TextMeshProUGUI _counterText;

	[SerializeField]
	private MoveBuildableCursorProperties _cursorProperties;

	private void OnDisable()
	{
		base.transform.localRotation = Quaternion.identity;
		base.transform.localScale = Vector3.one;
	}

	public override void Initialize(IPlaceable placeable)
	{
		base.Initialize(placeable);
		base.gameObject.SetActive(value: false);
		UpdateText();
	}

	public void Increment()
	{
		Count++;
		Toggle(toggled: false);
		UpdateText();
	}

	public void Add(int count)
	{
		Count += count;
		Toggle(toggled: false);
		UpdateText();
	}

	public bool Decrement()
	{
		Count--;
		UpdateText();
		return Count > 0;
	}

	public bool Remove(int count)
	{
		Count -= count;
		UpdateText();
		return Count > 0;
	}

	public void UpdateText()
	{
		_counterText.text = Count.ToString();
		CheckRequirementsImmediately();
	}

	protected override void Click(BaseEventData eventData)
	{
		if (eventData is PointerEventData { button: PointerEventData.InputButton.Left })
		{
			Submit(eventData);
		}
	}

	public override void Trigger()
	{
		Submit(null);
	}

	protected override void Submit(BaseEventData eventData)
	{
		if (base.Interactable)
		{
			if ((bool)BuildableToggle._activeToggle)
			{
				BuildableToggle._activeToggle.Toggle(toggled: false);
			}
			BuildableToggle._activeToggle = this;
			Toggle(toggled: true);
			_cursorProperties.SetSelectedPlaceableProperties(base.Placeable);
		}
	}

	protected override void Enter(BaseEventData eventData = null)
	{
	}

	protected override void Exit(BaseEventData eventData)
	{
	}

	protected override void Select(BaseEventData eventData)
	{
	}

	protected override void Deselect(BaseEventData eventData)
	{
	}

	protected override void OnCursorDeactivated(CursorProperties cursorProperties, bool canceled)
	{
		Toggle(toggled: false);
		BuildableToggle._activeToggle = null;
	}

	public override void CheckRequirementsImmediately()
	{
		base.Interactable = 0 < Count;
		base.gameObject.SetActive(base.Interactable);
	}
}
