using System;
using TMPro;
using UnityEngine;

public class LandmarkPanel : Panel
{
	[Header("References")]
	[Tooltip("The text component used to display the title of the landmark.")]
	[SerializeField]
	private TextMeshProUGUI _title;

	[Tooltip("The text component used to display the description of the landmark.")]
	[SerializeField]
	private TextMeshProUGUI _description;

	[Tooltip("Reference to the Action UIs")]
	[SerializeField]
	private LandmarkActionUI[] _landmarkActionUIs;

	[SerializeField]
	private LandmarkPanelProjectButtons _buttons;

	[SerializeField]
	private SelectableGroup _selectableGroup;

	private ActionsBehaviour _actionsBehaviour;

	private RectTransform _rectTransform;

	private Vector3 _disabledPosition;

	private Vector3 _enabledPosition;

	private void Awake()
	{
		_rectTransform = base.transform as RectTransform;
		_disabledPosition = _rectTransform.localPosition;
		_disabledPosition.x = _rectTransform.sizeDelta.x;
		_enabledPosition = _rectTransform.localPosition;
		_enabledPosition.x = -128f;
		_rectTransform.anchoredPosition = _disabledPosition;
	}

	private void OnEnable()
	{
		if (_actionsBehaviour != null)
		{
			DisplayLandmarkActionUIs(_actionsBehaviour);
		}
	}

	private void OnDisable()
	{
		DisableLandmarkActionUIs();
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (!TryGetLandmarkBehaviour(context, out var behaviour) || !base.Open(id, context))
		{
			return false;
		}
		_actionsBehaviour = behaviour;
		_buttons.Initialize(behaviour);
		_title.text = _actionsBehaviour.Name;
		_description.text = _actionsBehaviour.Description;
		DisplayLandmarkActionUIs(behaviour);
		_actionsBehaviour.IsPanelOpen = true;
		GameEventDispatcher.AddListener(GameEventType.LandmarkNotificationUpdate, OnLandmarkNotificationUpdate);
		return true;
	}

	private bool TryGetLandmarkBehaviour(IPanelContext context, out ActionsBehaviour behaviour)
	{
		behaviour = null;
		Landmark component;
		if (context is ActionsBehaviour actionsBehaviour)
		{
			behaviour = actionsBehaviour;
		}
		else if (Selector.SelectedType == ObjectType.Landmark && Selector.Selection.ObjectToSelect.TryGetComponent<Landmark>(out component))
		{
			behaviour = component.Behaviour as ActionsBehaviour;
		}
		return behaviour != null;
	}

	private void OnLandmarkNotificationUpdate(GameEvent gameEvent)
	{
		if (gameEvent is LandmarkNotificationEvent { LandmarkBehaviour: ActionsBehaviour landmarkBehaviour } && landmarkBehaviour == _actionsBehaviour)
		{
			DisplayLandmarkActionUIs(landmarkBehaviour);
		}
	}

	private void DisplayLandmarkActionUIs(ActionsBehaviour actionsBehaviour)
	{
		DisableLandmarkActionUIs();
		foreach (LandmarkAction action in actionsBehaviour.Actions)
		{
			if (!action.RequiresScouting || actionsBehaviour.IsScouted)
			{
				action.InitializeUI(this);
			}
		}
		_selectableGroup.Initialize(clearSelected: true);
	}

	private void DisableLandmarkActionUIs()
	{
		LandmarkActionUI[] landmarkActionUIs = _landmarkActionUIs;
		for (int i = 0; i < landmarkActionUIs.Length; i++)
		{
			landmarkActionUIs[i].gameObject.SetActive(value: false);
		}
	}

	public override void Close()
	{
		_actionsBehaviour.IsPanelOpen = false;
		_actionsBehaviour = null;
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkNotificationUpdate, OnLandmarkNotificationUpdate);
		if (!(base.gameObject == null) && base.gameObject.activeSelf)
		{
			if (Selector.Selection != null && Selector.Selection.Type == ObjectType.Landmark)
			{
				Selector.Deselect(Selector.Selection.gameObject);
			}
			PanelEvent.DispatchPanelClosedEvent(this);
		}
	}

	public T ReturnLandmarkActionUI<T>() where T : LandmarkActionUI
	{
		for (int i = 0; i < _landmarkActionUIs.Length; i++)
		{
			if (_landmarkActionUIs[i] is T result)
			{
				return result;
			}
		}
		throw new NotImplementedException(string.Format("There is no reference to '{0}'. Make sure it is added to the Landmark UIs on the LandmarkPanel prefab."));
	}
}
