using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public abstract class RadicalMenuOption : UIelement
{
	[Header("Settings:")]
	public float extraVerticalSpacing;

	public bool activeInSPStage = true;

	public bool activeInTitle;

	public bool activeInDebugOnly;

	public bool forceDeactive;

	public bool visibleButNotSelectableWhenInactive;

	public bool handleNavigationInternally;

	public PlatformFlags activeInPlatforms = (PlatformFlags)(-1);

	public StorefrontFlags activeInStoreFronts = (StorefrontFlags)(-1);

	public bool canBeActivated = true;

	public bool isOnOffToggle;

	public PugText labelText;

	public PugText valueText;

	public List<SelectionListener> selectionListeners;

	public string selectionListenerSourceTag;

	protected BoxCollider clickCollider;

	protected RadicalMenu parentMenu;

	protected PugTextEffectMenuOption[] menuOptionEffects;

	public override bool isMenuOption => true;

	private void OnValidate()
	{
		TryAssignComponentFromChild(ref labelText, "Label");
		TryAssignComponentFromChild(ref valueText, "Value");
	}

	private void TryAssignComponentFromChild<T>(ref T component, string childName) where T : Component
	{
		Transform transform = base.transform.Find(childName);
		if ((bool)transform)
		{
			T component2 = transform.GetComponent<T>();
			if ((bool)component2)
			{
				component = component2;
			}
		}
	}

	public virtual bool CanBeActivated()
	{
		return canBeActivated;
	}

	public virtual bool CanBeDeselected()
	{
		return true;
	}

	public bool IsSelected()
	{
		return parentMenu?.GetSelectedMenuOption() == this;
	}

	public virtual bool IsSelectionEnabled(bool visualOnly = false)
	{
		if (base.enabled && base.gameObject.activeInHierarchy)
		{
			return !ShouldBeGrayedOut();
		}
		return false;
	}

	private bool ShouldBeGrayedOut()
	{
		return GetActiveStateInCurrentScene() == OptionActiveState.GRAYED_OUT;
	}

	public virtual OptionActiveState GetActiveStateInCurrentScene()
	{
		if (activeInDebugOnly && !Manager.DEBUG_MODE)
		{
			return OptionActiveState.INACTIVE;
		}
		if (!PlatformStorefrontUtility.MatchesCurrent(activeInPlatforms, activeInStoreFronts) || forceDeactive)
		{
			return OptionActiveState.INACTIVE;
		}
		OptionActiveState result = OptionActiveState.INACTIVE;
		if (Manager.sceneHandler != null)
		{
			if (Manager.sceneHandler.isInGame)
			{
				result = (activeInSPStage ? OptionActiveState.ACTIVE : (visibleButNotSelectableWhenInactive ? OptionActiveState.GRAYED_OUT : OptionActiveState.INACTIVE));
			}
			else if (Manager.sceneHandler.isTitle)
			{
				result = (activeInTitle ? OptionActiveState.ACTIVE : (visibleButNotSelectableWhenInactive ? OptionActiveState.GRAYED_OUT : OptionActiveState.INACTIVE));
			}
			else
			{
				Debug.LogWarning("RadicalMenu is not supported in scene " + Manager.sceneHandler.gameObject.scene.name);
			}
		}
		return result;
	}

	protected virtual void Awake()
	{
		parentMenu = GetComponentInParent<RadicalMenu>();
		menuOptionEffects = GetComponentsInChildren<PugTextEffectMenuOption>(includeInactive: true);
		InitClickCollider();
	}

	protected virtual void Update()
	{
		UpdateClickCollider();
	}

	protected virtual void InitClickCollider()
	{
		if (labelText == null)
		{
			labelText = base.gameObject.GetComponent<PugText>();
		}
		if (clickCollider == null && (labelText != null || valueText != null))
		{
			clickCollider = base.gameObject.AddComponent<BoxCollider>();
			clickCollider.isTrigger = true;
		}
	}

	protected virtual void UpdateClickCollider()
	{
		if (clickCollider != null)
		{
			Rect rect;
			if (!(labelText != null) || !(valueText != null))
			{
				rect = ((!(labelText != null)) ? new Rect((Vector2)valueText.transform.position + valueText.dimensions.center, valueText.dimensions.size) : new Rect((Vector2)labelText.transform.position + labelText.dimensions.center, labelText.dimensions.size));
			}
			else
			{
				Vector2 vector = (Vector2)labelText.transform.position + labelText.dimensions.min;
				Vector2 vector2 = (Vector2)valueText.transform.position + valueText.dimensions.max;
				Vector2 position = (vector + vector2) / 2f;
				Vector2 size = vector2 - vector;
				rect = new Rect(position, size);
			}
			clickCollider.size = new Vector3(rect.width, rect.height, 0.5f);
			clickCollider.center = rect.position - (Vector2)base.transform.position;
			clickCollider.enabled = GetActiveStateInCurrentScene() == OptionActiveState.ACTIVE;
		}
	}

	public void SetParentMenu(RadicalMenu radicalMenu)
	{
		parentMenu = radicalMenu;
	}

	public virtual void OnParentMenuActivation()
	{
		if (menuOptionEffects == null || menuOptionEffects.Length == 0)
		{
			menuOptionEffects = GetComponents<PugTextEffectMenuOption>();
		}
	}

	public virtual void OnCleanupAndReset()
	{
	}

	public virtual void OnSelectedLateUpdate()
	{
	}

	public virtual void OnDeselectedLateUpdate()
	{
	}

	public virtual void OnPreSelected(UIelement previousInternalOption)
	{
	}

	public virtual UIelement GetInternalOption()
	{
		return null;
	}

	public override void OnSelected()
	{
		InvokeOnElementSelectedEvent();
		selectionListeners?.ForEach(delegate(SelectionListener listener)
		{
			listener.OnSelected(selectionListenerSourceTag);
		});
		if (menuOptionEffects != null)
		{
			PugTextEffectMenuOption[] array = menuOptionEffects;
			for (int num = 0; num < array.Length; num++)
			{
				array[num].OnSelected();
			}
		}
	}

	public override void OnDeselected(bool playEffect = true)
	{
		InvokeOnElementDeselectedEvent();
		selectionListeners?.ForEach(delegate(SelectionListener listener)
		{
			listener.OnDeselected(selectionListenerSourceTag);
		});
		if (menuOptionEffects == null)
		{
			return;
		}
		PugTextEffectMenuOption[] array = menuOptionEffects;
		foreach (PugTextEffectMenuOption pugTextEffectMenuOption in array)
		{
			if (playEffect)
			{
				pugTextEffectMenuOption.OnDeselected();
			}
			else
			{
				pugTextEffectMenuOption.EndEffectImmediate();
			}
		}
	}

	public virtual void OnActivated()
	{
	}

	public virtual bool OnSkimLeft()
	{
		return false;
	}

	public virtual bool OnSkimRight()
	{
		return false;
	}

	public virtual bool NavigateInternally(Direction.Id id)
	{
		return false;
	}

	public virtual bool IsOn()
	{
		return true;
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		OnActivated();
	}

	public override void OnRightClicked(bool mod1, bool mod2)
	{
	}
}
