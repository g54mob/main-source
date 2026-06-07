using System;
using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Utilities;
using Rewired;
using RewiredConsts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PajamaLlama;
using UnityEngine.UI;

public class SelectableGroup : MonoBehaviour, IFocusTarget, IMoveHandler, IEventSystemHandler
{
	private enum InitializeSelectedMode
	{
		Never = 0,
		IfNullOrInactive = 1,
		Always = 2
	}

	[Flags]
	private enum InputTypes
	{
		None = 0,
		KeyboardAndMouse = 1,
		Controller = 2,
		All = 3
	}

	private enum NavigationMode
	{
		InputModule = 0,
		OverrideInputModule = 1,
		Self = 2,
		Parent = 3,
		SelfOnMove = 4
	}

	private enum NavigationAxis
	{
		None = 0,
		Horizontal = 1,
		Vertical = 2
	}

	public enum InitializationMode
	{
		Awake = 0,
		Start = 1,
		Script = 2
	}

	private enum NavigationInputMode
	{
		GetButtonDown = 0,
		GetButtonRepeating = 1
	}

	private enum ManagedSelectableTypes
	{
		Children = 0,
		Descendants = 1,
		ChildrenMultipleParents = 2
	}

	[Serializable]
	private struct ParentArray
	{
		public Transform[] Parents;
	}

	public delegate bool NavigationInputHandler(int actionId);

	private readonly WaitForEndOfFrame WAIT_FOR_END_OF_FRAME = new WaitForEndOfFrame();

	[SerializeField]
	private ManagedSelectableTypes _managedSelectables;

	[SerializeField]
	[Tooltip("The transform that is the parent of the Selectables managed by this selectable group. NULL == this.transform.")]
	[ConditionalEnumHide("_managedSelectables", 0, false, HideInInspector = true)]
	private Transform _selectableParent;

	[SerializeField]
	[Tooltip("The transforms that are the parents of the Selectables managed by this selectable group")]
	[ConditionalEnumHide("_managedSelectables", 2, false, NestedField = "Parents", HideInInspector = true)]
	private ParentArray _selectableParents;

	[SerializeField]
	private InitializeSelectedMode _initializeSelected = InitializeSelectedMode.IfNullOrInactive;

	[SerializeField]
	[Tooltip("The selectable that is selected when the selectable group is initialized. NULL == first active child selectable")]
	[ConditionalEnumHide("_initializeSelected", 0, false, Inverse = true)]
	private Selectable _firstSelected;

	[SerializeField]
	[InterfaceReference(typeof(ISelectableGroupFirstSelectedProvider))]
	[ConditionalEnumHide("_initializeSelected", 0, false, Inverse = true)]
	private UnityEngine.Object _firstSelectedProvider;

	[SerializeField]
	private bool _deselectOnFocusLost;

	[SerializeField]
	private int _priority;

	[SerializeField]
	[Tooltip("The input types for which this SelectableGroup should be initialized.")]
	private InputTypes _supportedInputTypes = InputTypes.Controller;

	[SerializeField]
	private InitializationMode _initialization;

	[Header("Navigation")]
	[SerializeField]
	private NavigationMode _navigationMode;

	[SerializeField]
	private NavigationAxis _navigationAxis;

	[SerializeField]
	private NavigationInputMode _inputMode = NavigationInputMode.GetButtonRepeating;

	[SerializeField]
	[ActionIdProperty(typeof(RewiredConsts.Action))]
	private int _up = -1;

	[SerializeField]
	[ActionIdProperty(typeof(RewiredConsts.Action))]
	private int _right = -1;

	[SerializeField]
	[ActionIdProperty(typeof(RewiredConsts.Action))]
	private int _down = -1;

	[SerializeField]
	[ActionIdProperty(typeof(RewiredConsts.Action))]
	private int _left = -1;

	protected Selectable _selected;

	protected List<Selectable> _selectables;

	private List<SelectableGroup> _children;

	private bool _isActivating;

	private bool _hasFocus;

	private SelectableGroup _parentGroup;

	private Selectable _parentSelectable;

	private Selectable _parentNext;

	private NavigationInputHandler _navigationInputHandler;

	public InitializationMode Initialization => _initialization;

	public int Priority => _priority;

	public Selectable Selected => _selected;

	public GameObject SelectedGameObject
	{
		get
		{
			if (_navigationMode == NavigationMode.SelfOnMove)
			{
				return base.gameObject;
			}
			if (!_selected)
			{
				return null;
			}
			return _selected.gameObject;
		}
	}

	public bool SelectedGameObjectIsActiveAndEnabled
	{
		get
		{
			if ((bool)_selected)
			{
				return _selected.isActiveAndEnabled;
			}
			return false;
		}
	}

	protected bool Initialized { get; private set; }

	public virtual bool IsCurrentlySelected { get; private set; }

	protected bool ItHandlesInput
	{
		get
		{
			if (_navigationMode != NavigationMode.InputModule)
			{
				return _navigationMode != NavigationMode.SelfOnMove;
			}
			return false;
		}
	}

	protected virtual void Awake()
	{
		if (_initialization == InitializationMode.Awake)
		{
			Initialize();
		}
	}

	protected virtual void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
		if (Initialized)
		{
			Activate();
		}
		StartCoroutine(OnEndOfFrame());
	}

	protected virtual void Start()
	{
		if (_initialization == InitializationMode.Start)
		{
			Initialize();
		}
	}

	protected virtual void LateUpdate()
	{
		if (!Initialized || !HasActiveSupportedInputType())
		{
			return;
		}
		if (RequiresFocus())
		{
			FocusManager.RequestFocus(this);
		}
		if (_hasFocus && ItHandlesInput)
		{
			Selectable selectable = null;
			if (_navigationInputHandler(_up))
			{
				selectable = FindSelectableOnUp();
			}
			else if (_navigationInputHandler(_right))
			{
				selectable = FindSelectableOnRight();
			}
			else if (_navigationInputHandler(_down))
			{
				selectable = FindSelectableOnDown();
			}
			else if (_navigationInputHandler(_left))
			{
				selectable = FindSelectableOnLeft();
			}
			if ((bool)selectable)
			{
				Select(selectable);
			}
		}
	}

	private IEnumerator OnEndOfFrame()
	{
		while (base.isActiveAndEnabled)
		{
			yield return WAIT_FOR_END_OF_FRAME;
			IsCurrentlySelected = (bool)EventSystem.current && EventSystem.current.currentSelectedGameObject == SelectedGameObject;
		}
	}

	protected virtual void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
		Deactivate();
	}

	public virtual void Initialize(bool clearSelected = false)
	{
		Transform transform = (_selectableParent ? _selectableParent : base.transform);
		if (_selectables == null)
		{
			_selectables = new List<Selectable>();
		}
		else
		{
			_selectables.Clear();
		}
		switch (_managedSelectables)
		{
		case ManagedSelectableTypes.Children:
			PopulateChildSelectabled(transform);
			break;
		case ManagedSelectableTypes.Descendants:
			transform.GetComponentsInChildren(includeInactive: true, _selectables);
			break;
		case ManagedSelectableTypes.ChildrenMultipleParents:
		{
			Transform[] parents = _selectableParents.Parents;
			foreach (Transform parent in parents)
			{
				PopulateChildSelectabled(parent);
			}
			break;
		}
		}
		if (clearSelected)
		{
			_selected = null;
		}
		if (base.enabled)
		{
			Activate();
		}
		if (_inputMode == NavigationInputMode.GetButtonDown)
		{
			_navigationInputHandler = FlotsamInputManager.GetButtonDown;
		}
		else
		{
			_navigationInputHandler = FlotsamInputManager.GetButtonRepeating;
		}
		Initialized = true;
	}

	private void PopulateChildSelectabled(Transform parent)
	{
		for (int i = 0; i < parent.childCount; i++)
		{
			Selectable component = parent.GetChild(i).GetComponent<Selectable>();
			if ((bool)component)
			{
				_selectables.Add(component);
			}
		}
	}

	public void OnFocusGained()
	{
		_hasFocus = true;
		EventSystem.current.sendNavigationEvents = _navigationMode != NavigationMode.OverrideInputModule;
	}

	public void OnFocusLost()
	{
		EventSystem current = EventSystem.current;
		_hasFocus = false;
		if ((bool)current)
		{
			current.sendNavigationEvents = true;
			if (_deselectOnFocusLost && current.currentSelectedGameObject == SelectedGameObject)
			{
				current.SetSelectedGameObject(null);
			}
		}
	}

	public void OnCurrentSelectedSelectableChanged(Selectable currentSelectedSelectable)
	{
		if (ManagesSelectable(currentSelectedSelectable))
		{
			_selected = currentSelectedSelectable;
		}
		else
		{
			IsCurrentlySelected = false;
		}
	}

	public bool ManagesSelectable(Selectable selectable)
	{
		if (_selectables.IsNullOrEmpty())
		{
			return false;
		}
		if (_selectables.Contains(selectable))
		{
			return true;
		}
		if (_children.IsNullOrEmpty())
		{
			return false;
		}
		foreach (SelectableGroup child in _children)
		{
			if (child.ManagesSelectable(selectable))
			{
				return true;
			}
		}
		return false;
	}

	protected virtual Selectable FindSelectableOnUp()
	{
		if (!_selected)
		{
			return null;
		}
		return _selected.navigation.selectOnUp;
	}

	protected virtual Selectable FindSelectableOnRight()
	{
		if (!_selected)
		{
			return null;
		}
		return _selected.navigation.selectOnRight;
	}

	protected virtual Selectable FindSelectableOnDown()
	{
		if (!_selected)
		{
			return null;
		}
		return _selected.navigation.selectOnDown;
	}

	protected virtual Selectable FindSelectableOnLeft()
	{
		if (!_selected)
		{
			return null;
		}
		return _selected.navigation.selectOnLeft;
	}

	protected virtual void UpdateNavigation()
	{
		if (_navigationAxis == NavigationAxis.None || !TryReturnFirstSelectable(out var selectable, out var i))
		{
			return;
		}
		Selectable selectable2 = null;
		Selectable previous;
		for (i++; i < _selectables.Count; i++)
		{
			Selectable selectable3 = _selectables[i];
			if (selectable3.isActiveAndEnabled)
			{
				previous = selectable2;
				selectable2 = selectable;
				selectable = selectable3;
				SetNavigation(selectable2, previous, selectable);
			}
		}
		previous = selectable2;
		selectable2 = selectable;
		SetNavigation(selectable2, previous, null);
		if ((bool)_parentGroup)
		{
			UpdateParentChildNavigation(_parentGroup, this);
		}
		else
		{
			if (_children.IsNullOrEmpty())
			{
				return;
			}
			foreach (SelectableGroup child in _children)
			{
				UpdateParentChildNavigation(this, child);
			}
		}
	}

	private void UpdateParentChildNavigation(SelectableGroup parent, SelectableGroup child)
	{
		if (!child._selectables.IsNullOrEmpty())
		{
			Selectable selectable = child._selectables[0];
			List<Selectable> selectables = child._selectables;
			Selectable selectable2 = selectables[selectables.Count - 1];
			Selectable nextSelectable = parent.GetNextSelectable(child._parentSelectable);
			if (GetNextNavigationSelectable(child._parentSelectable) != selectable)
			{
				OverrideNavigation(_navigationAxis, child._parentSelectable, selectable);
			}
			if (GetNextNavigationSelectable(selectable2) != nextSelectable)
			{
				OverrideNavigation(_navigationAxis, selectable2, nextSelectable);
				child._parentNext = nextSelectable;
			}
		}
	}

	private void SetNavigation(Selectable current, Selectable previous, Selectable next)
	{
		Navigation navigation = current.navigation;
		navigation.mode = Navigation.Mode.Explicit;
		switch (_navigationAxis)
		{
		case NavigationAxis.Horizontal:
			navigation.selectOnUp = null;
			navigation.selectOnRight = next;
			navigation.selectOnDown = null;
			navigation.selectOnLeft = previous;
			break;
		case NavigationAxis.Vertical:
			navigation.selectOnUp = previous;
			navigation.selectOnRight = null;
			navigation.selectOnDown = next;
			navigation.selectOnLeft = null;
			break;
		}
		current.navigation = navigation;
	}

	public bool TrySelect(Selectable selectable)
	{
		if (HasActiveSupportedInputType())
		{
			if (_navigationMode == NavigationMode.Parent && _parentGroup != null)
			{
				return _parentGroup.TrySelect(selectable);
			}
			if (ManagesSelectable(selectable))
			{
				Select(selectable);
				return true;
			}
		}
		return false;
	}

	public void DeselectSelected()
	{
		Deselect();
		_selected = null;
	}

	protected virtual void Select(Selectable selectable)
	{
		switch (_navigationMode)
		{
		case NavigationMode.InputModule:
			_selected = selectable;
			if (_hasFocus)
			{
				FocusManager.SetSelectedSelectable(selectable);
			}
			break;
		case NavigationMode.OverrideInputModule:
			_selected = selectable;
			FocusManager.SetSelectedSelectable(selectable);
			break;
		case NavigationMode.Self:
		case NavigationMode.SelfOnMove:
			Deselect();
			_selected = selectable;
			if ((bool)_selected)
			{
				_selected.OnSelect(null);
			}
			break;
		case NavigationMode.Parent:
			break;
		}
	}

	private void SelectIfNotNull(Selectable selectable)
	{
		if ((bool)selectable)
		{
			Select(selectable);
		}
	}

	protected virtual void Deselect()
	{
		if ((bool)_selected)
		{
			_selected.OnDeselect(null);
		}
	}

	protected virtual void SetFirstSelected()
	{
		Selectable selectable;
		int i;
		if ((bool)_firstSelected)
		{
			Select(_firstSelected);
		}
		else if (_firstSelectedProvider is ISelectableGroupFirstSelectedProvider selectableGroupFirstSelectedProvider && selectableGroupFirstSelectedProvider.TryGetFirstSelected(out selectable))
		{
			Select(selectable);
		}
		else if (TryReturnFirstSelectable(out selectable, out i))
		{
			Select(selectable);
		}
	}

	private bool TryReturnFirstSelectable(out Selectable selectable, out int i, int startIndex = 0)
	{
		if (_selectables.IsNullOrEmpty())
		{
			i = -1;
			selectable = null;
			return false;
		}
		for (i = startIndex; i < _selectables.Count; i++)
		{
			selectable = _selectables[i];
			if (selectable.isActiveAndEnabled)
			{
				return true;
			}
		}
		i = -1;
		selectable = null;
		return false;
	}

	private bool HasActiveSupportedInputType()
	{
		if (_supportedInputTypes != InputTypes.All && (_supportedInputTypes & InputTypes.KeyboardAndMouse) == 0)
		{
			if ((_supportedInputTypes & InputTypes.Controller) != InputTypes.None)
			{
				return FlotsamInputManager.IsJoystick;
			}
			return false;
		}
		return true;
	}

	public void Addchild(Selectable parent, SelectableGroup selectableGroup)
	{
		if (!_selectables.Contains(parent))
		{
			Debug.LogError("You are trying to child a SelectableGroup to selectable that is not part of this selectable group");
			return;
		}
		if (HasChild(selectableGroup))
		{
			Debug.LogError("A selectable group can not be childed to the same SelectableGroup more than once.");
			return;
		}
		if (selectableGroup._navigationMode != NavigationMode.Parent)
		{
			Debug.LogError("Only SelectableGroups that use NavigationMode.Parent can be added as a child SelectableGroup.");
			return;
		}
		if (_navigationAxis != selectableGroup._navigationAxis)
		{
			Debug.LogError("Currenly only selectabe groups that operate on the same NavigationAxis can have a parent - child relationship.");
			return;
		}
		Selectable nextNavigationSelectable = GetNextNavigationSelectable(parent);
		OverrideNavigation(_navigationAxis, parent, selectableGroup._selectables[0]);
		OverrideNavigation(_navigationAxis, selectableGroup._selectables[selectableGroup._selectables.Count - 1], nextNavigationSelectable);
		if (_children == null)
		{
			_children = new List<SelectableGroup>();
		}
		selectableGroup._parentGroup = this;
		selectableGroup._parentSelectable = parent;
		selectableGroup._parentNext = nextNavigationSelectable;
		_children.Add(selectableGroup);
	}

	public void RemoveChild(SelectableGroup child)
	{
		if (!(child._parentGroup != this))
		{
			Selectable parentSelectable = child._parentSelectable;
			OverrideNavigation(_navigationAxis, child._parentSelectable, child._parentNext);
			child._parentGroup = null;
			child._parentSelectable = null;
			child._parentNext = null;
			_children.Remove(child);
			if (child._selectables.Contains(Selected))
			{
				Select(parentSelectable);
			}
		}
	}

	public void RemoveChildren()
	{
		if (!_children.IsNullOrEmpty())
		{
			int count = _children.Count;
			while (0 < count--)
			{
				RemoveChild(_children[count]);
			}
		}
	}

	private bool HasChild(SelectableGroup selectableGroup)
	{
		if (!_children.IsNullOrEmpty())
		{
			return _children.Contains(selectableGroup);
		}
		return false;
	}

	private void OverrideNavigation(NavigationAxis axis, Selectable from, Selectable to)
	{
		Navigation navigation = (from ? from.navigation : default(Navigation));
		Navigation navigation2 = (to ? to.navigation : default(Navigation));
		switch (axis)
		{
		case NavigationAxis.Horizontal:
			navigation.selectOnRight = to;
			navigation2.selectOnLeft = from;
			break;
		case NavigationAxis.Vertical:
			navigation.selectOnDown = to;
			navigation2.selectOnUp = from;
			break;
		}
		if ((bool)from)
		{
			from.navigation = navigation;
		}
		if ((bool)to)
		{
			to.navigation = navigation2;
		}
	}

	private void OnActiveInputUpdated(GameEvent gameEvent)
	{
		if (HasActiveSupportedInputType())
		{
			Activate();
		}
		else
		{
			Deactivate();
		}
	}

	public void Activate()
	{
		if (!_isActivating)
		{
			_isActivating = true;
			FinalUpdate.RegisterOneShot(OnActivate);
		}
	}

	private void OnActivate()
	{
		if (!_isActivating)
		{
			return;
		}
		_isActivating = false;
		if (!base.isActiveAndEnabled || !HasActiveSupportedInputType())
		{
			return;
		}
		UpdateNavigation();
		switch (_initializeSelected)
		{
		case InitializeSelectedMode.IfNullOrInactive:
			if (_selected == null || !_selected.isActiveAndEnabled || !ManagesSelectable(_selected))
			{
				SetFirstSelected();
			}
			break;
		case InitializeSelectedMode.Always:
			SetFirstSelected();
			break;
		}
		switch (_navigationMode)
		{
		case NavigationMode.Self:
			OnFocusGained();
			if (_selected != null)
			{
				_selected.OnSelect(null);
			}
			break;
		case NavigationMode.Parent:
			if ((bool)_parentGroup)
			{
				OverrideNavigation(_navigationAxis, _parentSelectable, _selectables[0]);
				OverrideNavigation(_navigationAxis, _selectables[_selectables.Count - 1], _parentNext);
			}
			break;
		default:
			FocusManager.RequestFocus(this);
			break;
		}
	}

	private void Deactivate()
	{
		_isActivating = false;
		switch (_navigationMode)
		{
		case NavigationMode.Self:
			OnFocusLost();
			return;
		case NavigationMode.SelfOnMove:
			if (_deselectOnFocusLost && (bool)_selected)
			{
				_selected.OnDeselect(null);
			}
			break;
		case NavigationMode.Parent:
			return;
		}
		FocusManager.ReleaseFocus(this);
	}

	public bool RequiresFocus()
	{
		NavigationMode navigationMode = _navigationMode;
		if ((uint)navigationMode <= 1u || navigationMode == NavigationMode.SelfOnMove)
		{
			return !_hasFocus;
		}
		return false;
	}

	public bool TryGetSelectedComponent<T>(List<T> components, out T selectedComponent) where T : Component
	{
		selectedComponent = null;
		if (_selected == null || components.IsNullOrEmpty())
		{
			return false;
		}
		foreach (T component in components)
		{
			if (component.gameObject == _selected.gameObject)
			{
				selectedComponent = component;
				return true;
			}
		}
		return false;
	}

	protected bool IsInInputModuleNavigationMode()
	{
		return _navigationMode == NavigationMode.InputModule;
	}

	private Selectable GetNextNavigationSelectable(Selectable selectable)
	{
		switch (_navigationAxis)
		{
		case NavigationAxis.Horizontal:
			return selectable.navigation.selectOnRight;
		case NavigationAxis.Vertical:
			return selectable.navigation.selectOnDown;
		default:
			Debug.LogErrorFormat("NavigationAxis '{0}' is currently not supported by SelectableGroup.AddChild");
			return null;
		}
	}

	private Selectable GetNextSelectable(Selectable selectable)
	{
		for (int i = _selectables.IndexOf(selectable) + 1; i >= 0 && i < _selectables.Count; i++)
		{
			Selectable selectable2 = _selectables[i];
			if (selectable2.isActiveAndEnabled)
			{
				return selectable2;
			}
		}
		return null;
	}

	public void SelectUp()
	{
		if (_navigationMode == NavigationMode.Self)
		{
			SelectIfNotNull(FindSelectableOnUp());
		}
		else
		{
			Debug.LogError("To be able to use SelectableGroup.SelectPrevious, make sure 'Navigation Mode' is set to 'Self'!");
		}
	}

	public void SelectRight()
	{
		if (_navigationMode == NavigationMode.Self)
		{
			SelectIfNotNull(FindSelectableOnRight());
		}
		else
		{
			Debug.LogError("To be able to use SelectableGroup.SelectPrevious, make sure 'Navigation Mode' is set to 'Self'!");
		}
	}

	public void SelectDown()
	{
		if (_navigationMode == NavigationMode.Self)
		{
			SelectIfNotNull(FindSelectableOnDown());
		}
		else
		{
			Debug.LogError("To be able to use SelectableGroup.SelectPrevious, make sure 'Navigation Mode' is set to 'Self'!");
		}
	}

	public void SelectLeft()
	{
		if (_navigationMode == NavigationMode.Self)
		{
			SelectIfNotNull(FindSelectableOnLeft());
		}
		else
		{
			Debug.LogError("To be able to use SelectableGroup.SelectPrevious, make sure 'Navigation Mode' is set to 'Self'!");
		}
	}

	public void SelectPrevious()
	{
		switch (_navigationAxis)
		{
		case NavigationAxis.Vertical:
			SelectUp();
			break;
		case NavigationAxis.Horizontal:
			SelectLeft();
			break;
		default:
			Debug.LogError("NavigationAxis not supported!");
			break;
		}
	}

	public void SelectNext()
	{
		switch (_navigationAxis)
		{
		case NavigationAxis.Vertical:
			SelectDown();
			break;
		case NavigationAxis.Horizontal:
			SelectRight();
			break;
		default:
			Debug.LogError("NavigationAxis not supported!");
			break;
		}
	}

	public void OnMove(AxisEventData axisEventData)
	{
		if (_navigationMode != NavigationMode.SelfOnMove || !HasActiveSupportedInputType())
		{
			return;
		}
		if (RequiresFocus())
		{
			FocusManager.RequestFocus(this);
		}
		if (_hasFocus)
		{
			Selectable selectable = null;
			switch (axisEventData.moveDir)
			{
			case MoveDirection.Up:
				selectable = FindSelectableOnUp();
				break;
			case MoveDirection.Right:
				selectable = FindSelectableOnRight();
				break;
			case MoveDirection.Down:
				selectable = FindSelectableOnDown();
				break;
			case MoveDirection.Left:
				selectable = FindSelectableOnLeft();
				break;
			}
			if ((bool)selectable)
			{
				Select(selectable);
			}
		}
	}
}
