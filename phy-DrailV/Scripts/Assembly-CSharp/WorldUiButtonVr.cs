using System;
using System.Collections;
using DV.UI;
using DV.UIFramework;
using DV.VRTK_Extensions;
using TMPro;
using UnityEngine;
using VRTK;

public class WorldUiButtonVr : MonoBehaviour, ITooltip
{
	public TextMeshPro tooltipLabel;

	public bool active = true;

	public GameObject highlightObject;

	public GameObject clickObject;

	private Coroutine ClickCoro;

	private Action action;

	private Material clickMaterial;

	private TooltipHandler toolTipHandler;

	private VRTK_WorldUiButtonInteractable_DV interactable;

	[SerializeField]
	private AudioClip clickSound;

	[SerializeField]
	private AudioClip hoverSound;

	private Color clickColor;

	private Color goodClickColor = Color.white;

	private Color badClickColor = Color.red;

	private string translationKey;

	public bool OnlyUseInteractableText => false;

	public bool IsInteractable => interactable.isUsable;

	public IHoverable Hoverable
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public ITooltipIcons TooltipIcons => null;

	public event Action Used;

	public event Action Touched;

	public event Action Untouched;

	public virtual string GetTranslationKey()
	{
		return translationKey;
	}

	private void Awake()
	{
		BoxCollider component = GetComponent<BoxCollider>();
		if (component == null)
		{
			Debug.LogError("WorldUiButtonVr couldn't find a BoxCollider on '" + base.name + "'", this);
		}
		else if (!component.isTrigger)
		{
			Debug.LogError("WorldUiButtonVr has a BoxCollider that's not a trigger on '" + base.name + "', will be changed automatically. You need to fix it in prefab.", this);
			component.isTrigger = true;
		}
		toolTipHandler = base.transform.parent.GetComponentInChildren<TooltipHandler>();
	}

	private void Start()
	{
		interactable = base.gameObject.AddComponent<VRTK_WorldUiButtonInteractable_DV>();
		interactable.isGrabbable = false;
		interactable.isUsable = true;
		interactable.useOverrideButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
		interactable.InteractableObjectUsed += delegate
		{
			this.Used?.Invoke();
		};
		interactable.InteractableObjectTouched += delegate
		{
			this.Touched?.Invoke();
		};
		interactable.InteractableObjectUntouched += delegate
		{
			this.Untouched?.Invoke();
		};
		interactable.button = this;
		interactable.priority = 2;
		interactable.pipaExclusiveInteraction = true;
		Used += OnPressed;
		Touched += OnTouched;
		Untouched += OnUntouched;
		if ((bool)clickObject)
		{
			clickMaterial = clickObject.GetComponent<Renderer>().material;
		}
	}

	private void OnEnable()
	{
		if ((bool)highlightObject)
		{
			highlightObject.SetActive(value: false);
		}
		if ((bool)clickObject)
		{
			clickObject.SetActive(value: false);
		}
	}

	private void OnTouched()
	{
		if (toolTipHandler != null)
		{
			toolTipHandler.AddTooltipAndUpdate(this);
		}
		if (highlightObject != null)
		{
			highlightObject.SetActive(value: true);
		}
		if (hoverSound != null)
		{
			hoverSound.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
		}
	}

	private void OnUntouched()
	{
		if (toolTipHandler != null)
		{
			toolTipHandler.RemoveTooltipAndUpdate(this);
		}
		if (highlightObject != null)
		{
			highlightObject.SetActive(value: false);
		}
	}

	private void OnPressed()
	{
		if (active)
		{
			if (ClickCoro != null)
			{
				StopCoroutine(ClickCoro);
			}
			ClickCoro = StartCoroutine(Click());
			if (clickSound != null)
			{
				clickSound.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			}
		}
	}

	private IEnumerator Click()
	{
		if ((bool)clickObject)
		{
			clickObject.SetActive(value: true);
			clickMaterial.color = clickColor;
			yield return StartCoroutine(AnimateButtonTransparencyCoro(clickMaterial, 0f, 1f, 20f));
			yield return StartCoroutine(AnimateButtonTransparencyCoro(clickMaterial, 1f, 0f, 20f));
			clickObject.SetActive(value: false);
			action();
		}
		else
		{
			action();
		}
	}

	public void SetAction(Action action)
	{
		this.action = action;
	}

	public void SetClickFeedbackColor(bool good)
	{
		clickColor = (good ? goodClickColor : badClickColor);
	}

	private IEnumerator AnimateButtonTransparencyCoro(Material material, float transparencyFrom, float transparencyTo, float speed)
	{
		float current = transparencyFrom;
		float sign = Mathf.Sign(transparencyTo - transparencyFrom);
		while ((sign > 0f && current < transparencyTo) || (sign < 0f && current > transparencyTo))
		{
			current += speed * Time.unscaledDeltaTime * sign;
			current = Mathf.Clamp01(current);
			SetMaterialTransparency(material, current);
			yield return null;
		}
	}

	public void SetMaterialTransparency(Material material, float transparency)
	{
		if (!(material == null))
		{
			Color color = material.color;
			color.a = transparency;
			material.color = color;
		}
	}

	public string GetText()
	{
		throw new NotImplementedException();
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}
}
