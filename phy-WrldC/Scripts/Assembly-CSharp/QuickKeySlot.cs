using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuickKeySlot : MonoBehaviour, IRecyclableObject, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private KeyAssignment keyAssignment;

	public DefaultKeyIO DefaultKeyIO { get; private set; }

	public string ObjectTypeId { get; set; }

	public event Action<QuickKeySlot> OnKeyAssigned;

	public event Action OnKeyBeginingAssignment;

	public event Action OnKeyEndingAssignment;

	private void Awake()
	{
		keyAssignment = GetComponentInChildren<KeyAssignment>();
		keyAssignment.OnKeyAssignment += KeyAssignmentHandler;
		keyAssignment.OnKeyBeginingAssigment += delegate
		{
			this.OnKeyBeginingAssignment?.Invoke();
		};
		keyAssignment.OnKeyEndingAssigment += delegate
		{
			this.OnKeyEndingAssignment?.Invoke();
		};
	}

	public void Initialize(DefaultKeyIO defaultKeyIO)
	{
		DefaultKeyIO = defaultKeyIO;
		keyAssignment.SetKey(defaultKeyIO.KeyValue, defaultKeyIO.AxisValue);
		string text = LanguagesManager.Instance.GetText(defaultKeyIO.ParentBlockBodyModel.ParentBlockModel.Schematic.Name);
		string text2 = LanguagesManager.Instance.GetText(defaultKeyIO.BaseName);
		keyAssignment.SetLabel(text + " - " + text2);
		keyAssignment.IsAxisSensitive = defaultKeyIO.IsAxisSensitive;
		keyAssignment.IsKeyControlledByLogic = defaultKeyIO.IsAttachedInWritableSocketIO();
	}

	public void SetCurrentKey(KeyCode key, AxisCode axis)
	{
		keyAssignment.SetKey(key, axis);
	}

	public (KeyCode key, AxisCode axis) GetCurrentAssignedKey()
	{
		return (key: keyAssignment.Key, axis: keyAssignment.Axis);
	}

	public void SetAxisEnabled(bool isEnabled)
	{
		keyAssignment.IsAxisEnabled = isEnabled;
	}

	private void KeyAssignmentHandler(KeyCode key, AxisCode axis)
	{
		if (DefaultKeyIO != null)
		{
			this.OnKeyAssigned?.Invoke(this);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		SetBlockOutlineVisibility(isVisible: true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		SetBlockOutlineVisibility(isVisible: false);
	}

	public void SetBlockOutlineVisibility(bool isVisible)
	{
		if (DefaultKeyIO != null && DefaultKeyIO.ParentBlockBodyModel != null)
		{
			CreationModel parentCreationModel = DefaultKeyIO.ParentBlockBodyModel.ParentBlockModel.ParentCreationModel;
			if (parentCreationModel != null)
			{
				int id = DefaultKeyIO.ParentBlockBodyModel.ParentBlockModel.Id;
				parentCreationModel.SetBlockOutline(id, isVisible, Util.OutlineColorParser(Color.green));
			}
		}
	}

	public bool RefreshKeyControlledByLogic()
	{
		bool flag = DefaultKeyIO.IsAttachedInWritableSocketIO();
		keyAssignment.IsKeyControlledByLogic = flag;
		return flag;
	}

	public void OnInstantiation()
	{
	}

	public void OnUnistantiation()
	{
		this.OnKeyAssigned = null;
		this.OnKeyBeginingAssignment = null;
		this.OnKeyEndingAssignment = null;
		SetBlockOutlineVisibility(isVisible: false);
		DefaultKeyIO = null;
	}
}
