using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class FocusManager : MonoBehaviour
{
	private static FocusManager _instance;

	private bool _initialized;

	private IFocusTarget _currentTarget;

	private Selectable _currentSelectedSelectable;

	private IEnumerator _setFocusRoutine;

	public static UnityEvent<GameObject> CurrentSelectedGameObjectChanged { get; private set; } = new UnityEvent<GameObject>();

	public static GameObject CurrentSelectedGameObject { get; private set; }

	public static GameObject LastSelectedGameObject { get; private set; }

	private void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
			return;
		}
		Debug.Log("There is more than one instance of the FocusManager detected in the Scene!");
		base.enabled = false;
	}

	private IEnumerator Start()
	{
		while (EventSystem.current == null)
		{
			yield return null;
		}
		LastSelectedGameObject = EventSystem.current.currentSelectedGameObject;
		_initialized = true;
	}

	private void LateUpdate()
	{
		if (!_initialized)
		{
			return;
		}
		EventSystem current = EventSystem.current;
		if ((bool)current && CurrentSelectedGameObject != current.currentSelectedGameObject)
		{
			CurrentSelectedGameObjectChanged.Invoke(current.currentSelectedGameObject);
			LastSelectedGameObject = CurrentSelectedGameObject;
			CurrentSelectedGameObject = current.currentSelectedGameObject;
			if ((bool)CurrentSelectedGameObject && CurrentSelectedGameObject.TryGetComponent<Selectable>(out var component))
			{
				i_SetSelectedSelectable(component);
			}
		}
	}

	private void i_RequestFocus(IFocusTarget target)
	{
		if (target != null && target != _currentTarget && (_currentTarget == null || _currentTarget.Priority <= target.Priority))
		{
			ReleaseFocus(_currentTarget);
			_currentTarget = target;
			_currentTarget.OnFocusGained();
			RegainFocus(_currentTarget);
		}
	}

	private void i_ReleaseFocus(IFocusTarget target)
	{
		if (target != null && target == _currentTarget)
		{
			_currentTarget.OnFocusLost();
			_currentTarget = null;
		}
	}

	private void i_SetSelectedSelectable(Selectable selectable)
	{
		EventSystem current = EventSystem.current;
		if (selectable != _currentSelectedSelectable)
		{
			GameObject gameObject = (selectable ? selectable.gameObject : null);
			_currentSelectedSelectable = selectable;
			if (current.currentSelectedGameObject != gameObject)
			{
				current.SetSelectedGameObject(gameObject);
			}
			_currentTarget?.OnCurrentSelectedSelectableChanged(selectable);
		}
	}

	private void RegainFocus(IFocusTarget target)
	{
		if (target == _currentTarget)
		{
			if (_setFocusRoutine != null)
			{
				StopCoroutine(_setFocusRoutine);
			}
			_setFocusRoutine = SetFocusRoutine();
			StartCoroutine(_setFocusRoutine);
		}
	}

	private IEnumerator SetFocusRoutine()
	{
		while (!FlotsamInputManager.Initialized || EventSystem.current.alreadySelecting || _currentTarget == null || !_currentTarget.SelectedGameObjectIsActiveAndEnabled)
		{
			if (_currentTarget == null)
			{
				yield break;
			}
			yield return null;
		}
		EventSystem.current.SetSelectedGameObject(_currentTarget.SelectedGameObject);
	}

	public static void RequestFocus(IFocusTarget target)
	{
		_instance?.i_RequestFocus(target);
	}

	public static void ReleaseFocus(IFocusTarget target)
	{
		_instance?.i_ReleaseFocus(target);
	}

	public static void SetSelectedSelectable(Selectable selectable)
	{
		_instance?.i_SetSelectedSelectable(selectable);
	}
}
