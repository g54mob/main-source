using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Events;

public abstract class UIelement : MonoBehaviour
{
	public List<UIelement> topUIElements;

	public List<UIelement> bottomUIElements;

	public List<UIelement> leftUIElements;

	public List<UIelement> rightUIElements;

	public List<UIelement> childElements;

	public bool selectFirstEnabledElementInList;

	public bool invokeSelectionEvents;

	public UnityEvent onElementSelectedEvent;

	public UnityEvent onElementDeselectedEvent;

	private bool leftClickWasHeldDownThisFrame;

	private bool rightClickWasHeldDownThisFrame;

	private bool mod1WasHeldDownThisFrame;

	private bool mod2WasHeldDownThisFrame;

	protected bool wasAutoActivated;

	public virtual bool isShowing => base.gameObject.activeInHierarchy;

	public virtual UIScrollWindow uiScrollWindow => null;

	public virtual float localScrollPosition => base.transform.localPosition.y;

	public virtual bool isVisibleOnScreen
	{
		get
		{
			if (base.isActiveAndEnabled && base.transform.lossyScale.x != 0f)
			{
				return base.transform.lossyScale.y != 0f;
			}
			return false;
		}
	}

	public virtual bool keepMouseActiveButHiddenOnHoverWhenUsingController => false;

	public World world => Manager.ecs.ClientWorld;

	public virtual bool isMenuOption => false;

	public bool leftClickIsHeldDown { get; private set; }

	public bool rightClickIsHeldDown { get; private set; }

	public bool mod1IsHeldDown { get; private set; }

	public bool mod2IsHeldDown { get; private set; }

	protected virtual void LateUpdate()
	{
		if (!leftClickWasHeldDownThisFrame)
		{
			leftClickIsHeldDown = false;
		}
		leftClickWasHeldDownThisFrame = false;
		if (!rightClickWasHeldDownThisFrame)
		{
			rightClickIsHeldDown = false;
		}
		rightClickWasHeldDownThisFrame = false;
		if (!mod1WasHeldDownThisFrame)
		{
			mod1IsHeldDown = false;
		}
		mod1WasHeldDownThisFrame = false;
		if (!mod2WasHeldDownThisFrame)
		{
			mod2IsHeldDown = false;
		}
		mod2WasHeldDownThisFrame = false;
	}

	protected virtual void OnDisable()
	{
		leftClickIsHeldDown = false;
		leftClickWasHeldDownThisFrame = false;
		rightClickIsHeldDown = false;
		rightClickWasHeldDownThisFrame = false;
		mod1IsHeldDown = false;
		mod1WasHeldDownThisFrame = false;
		mod2IsHeldDown = false;
		mod2WasHeldDownThisFrame = false;
	}

	public void Select()
	{
		if (!(Manager.ui.currentSelectedUIElement == this))
		{
			Manager.ui.OnUIElementSelected(this);
		}
	}

	public void LeftClick(bool mod1 = false, bool mod2 = false, bool autoActivated = false)
	{
		wasAutoActivated = autoActivated;
		OnLeftClicked(mod1, mod2);
	}

	public void RightClick(bool mod1 = false, bool mod2 = false)
	{
		OnRightClicked(mod1, mod2);
	}

	public void LeftClickHeldDown(bool mod1, bool mod2)
	{
		leftClickWasHeldDownThisFrame = true;
		leftClickIsHeldDown = true;
		mod1WasHeldDownThisFrame = mod1;
		mod1IsHeldDown = mod1;
		mod2WasHeldDownThisFrame = mod2;
		mod2IsHeldDown = mod2;
	}

	public void RightClickHeldDown(bool mod1, bool mod2)
	{
		rightClickWasHeldDownThisFrame = true;
		rightClickIsHeldDown = true;
		mod1WasHeldDownThisFrame = mod1;
		mod1IsHeldDown = mod1;
		mod2WasHeldDownThisFrame = mod2;
		mod2IsHeldDown = mod2;
	}

	public void InvokeOnElementSelectedEvent()
	{
		if (invokeSelectionEvents)
		{
			onElementSelectedEvent?.Invoke();
		}
	}

	public void InvokeOnElementDeselectedEvent()
	{
		if (invokeSelectionEvents)
		{
			onElementDeselectedEvent?.Invoke();
		}
	}

	public virtual void OnSelected()
	{
		InvokeOnElementSelectedEvent();
	}

	public virtual void OnDeselected(bool playEffect = true)
	{
		InvokeOnElementDeselectedEvent();
	}

	public virtual void OnLeftClicked(bool mod1, bool mod2)
	{
	}

	public virtual void OnRightClicked(bool mod1, bool mod2)
	{
	}

	public virtual TextAndFormatFields GetHoverTitle()
	{
		return null;
	}

	public virtual HoverTitleIconType GetHoverTitleIconType()
	{
		return HoverTitleIconType.None;
	}

	public virtual List<TextAndFormatFields> GetHoverDescription()
	{
		return null;
	}

	public virtual List<TextAndFormatFields> GetHoverStats(bool previewReinforced)
	{
		return null;
	}

	public virtual ContainedObjectsBuffer GetContainedObject()
	{
		return default(ContainedObjectsBuffer);
	}

	public virtual List<PugDatabase.MaterialInfo> GetRequiredMaterials(bool isRepairing, bool isReinforcing)
	{
		return null;
	}

	public virtual CraftingSettings GetCraftingSettings()
	{
		return default(CraftingSettings);
	}

	public virtual bool MaterialsAreIngredients()
	{
		return false;
	}

	public virtual bool ShowRequiredMaterialsAmountNumberColor()
	{
		return true;
	}

	public virtual bool GetDurabilityOrFullnessOrXp(out int durability, out int maxDurability, out AmountType amountType)
	{
		durability = 0;
		maxDurability = 0;
		amountType = AmountType.Amount;
		return false;
	}

	public virtual bool GetLevel(out int level, out bool isMaxLevel)
	{
		level = 0;
		isMaxLevel = false;
		return false;
	}

	public virtual bool CoinValueIsBuyPrice()
	{
		return false;
	}

	public virtual bool CanBeRepaired(bool isReinforcing)
	{
		return false;
	}

	public virtual HoverWindowAlignment GetHoverWindowAlignment()
	{
		return HoverWindowAlignment.BOTTOM_RIGHT_OF_SCREEN;
	}

	public virtual UIelement GetClosestUIElement(Vector3 position)
	{
		if (childElements.Count > 0)
		{
			return GetClosestUIElementInList(childElements, position);
		}
		return this;
	}

	public virtual UIelement GetAdjacentUIElement(Direction.Id dir, Vector3 currentPosition)
	{
		return dir switch
		{
			Direction.Id.left => GetClosestUIElementInList(leftUIElements, currentPosition), 
			Direction.Id.right => GetClosestUIElementInList(rightUIElements, currentPosition), 
			Direction.Id.forward => GetClosestUIElementInList(topUIElements, currentPosition), 
			Direction.Id.back => GetClosestUIElementInList(bottomUIElements, currentPosition), 
			_ => null, 
		};
	}

	private UIelement GetClosestUIElementInList(List<UIelement> elements, Vector3 position)
	{
		UIelement result = null;
		float num = float.MaxValue;
		UIelement currentSelectedUIElement = Manager.ui.currentSelectedUIElement;
		foreach (UIelement element in elements)
		{
			if (!(element != null) || !element.isShowing || (!element.isVisibleOnScreen && !UIElementsSharesScrollWindow(currentSelectedUIElement, element)))
			{
				continue;
			}
			UIelement closestUIElement = element.GetClosestUIElement(position);
			if (closestUIElement != null && closestUIElement.isShowing && (closestUIElement.isVisibleOnScreen || UIElementsSharesScrollWindow(currentSelectedUIElement, closestUIElement)))
			{
				if (selectFirstEnabledElementInList)
				{
					result = closestUIElement;
					break;
				}
				float magnitude = (position - closestUIElement.transform.position).magnitude;
				if (magnitude < num)
				{
					result = closestUIElement;
					num = magnitude;
				}
			}
		}
		return result;
	}

	private bool UIElementsSharesScrollWindow(UIelement element1, UIelement element2)
	{
		if (element1 != null && element2 != null && element1.uiScrollWindow != null)
		{
			return element1.uiScrollWindow == element2.uiScrollWindow;
		}
		return false;
	}
}
