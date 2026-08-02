using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[AddComponentMenu("Ultimate Radial Menu/Pointer")]
public class UltimateRadialMenuPointer : MonoBehaviour
{
	public enum SnappingOption
	{
		Instant = 0,
		Smooth = 1,
		Free = 2
	}

	[Serializable]
	public class PointerStyle
	{
		public int buttonCount;

		public Sprite pointerSprite;
	}

	public enum SetSiblingIndex
	{
		Disabled = 0,
		First = 1,
		Last = 2
	}

	public UltimateRadialMenu radialMenu;

	public RectTransform pointerTransform;

	public Image pointerImage;

	public float pointerSize = 0.25f;

	public float targetingSpeed = 5f;

	public SnappingOption snappingOption = SnappingOption.Smooth;

	private Quaternion targetRotation;

	public float rotationOffset = 90f;

	public bool colorChange;

	public bool changeOverTime;

	public float fadeInDuration = 0.25f;

	public float fadeOutDuration = 0.5f;

	public Color normalColor = Color.white;

	public Color activeColor = Color.white;

	private bool radialMenuFocused;

	public bool usePointerStyle;

	public List<PointerStyle> PointerStyles = new List<PointerStyle>();

	public SetSiblingIndex setSiblingIndex;

	private void Awake()
	{
		if (Application.isPlaying && radialMenu == null)
		{
			radialMenu = GetComponentInParent<UltimateRadialMenu>();
			if (radialMenu == null)
			{
				Debug.LogError("Ultimate Radial Menu Pointer\nThere is not a Ultimate Radial Menu assigned to this pointer. This component was not able to find a Ultimate Radial Menu in any parent objects either. Disabling this component to avoid errors.");
				base.enabled = false;
			}
		}
	}

	private void Start()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		radialMenu.OnUpdatePositioning += OnUpdatePositioning;
		radialMenu.OnRadialButtonEnter += OnRadialButtonEnter;
		radialMenu.OnRadialMenuLostFocus += OnRadialMenuLostFocus;
		radialMenu.OnRadialMenuDisabled += OnRadialMenuDisabled;
		radialMenu.OnRadialMenuButtonCountModified += OnRadialMenuButtonCountModified;
		radialMenu = GetComponentInParent<UltimateRadialMenu>();
		if (radialMenu == null)
		{
			Debug.LogError("Ultimate Radial Menu Pointer\nThis component is not placed within an Ultimate Radial Menu. Disabling this component to avoid errors.");
			base.enabled = false;
			return;
		}
		pointerTransform = GetComponent<RectTransform>();
		if (pointerTransform == null)
		{
			Debug.LogError("Ultimate Radial Menu Pointer\nThis gameObject does not have an RectTransform component. Disabling this component to avoid errors.");
			base.enabled = false;
			return;
		}
		pointerImage = GetComponent<Image>();
		if (pointerImage == null)
		{
			Debug.LogError("Ultimate Radial Menu Pointer\nThis gameObject does not have an Image component. Disabling this component to avoid errors.");
			base.enabled = false;
			return;
		}
		if (colorChange && pointerImage != null)
		{
			pointerImage.color = normalColor;
		}
		OnRadialMenuButtonCountModified(radialMenu.UltimateRadialButtonList.Count);
	}

	private void OnRadialMenuLostFocus()
	{
		if (radialMenuFocused && colorChange && pointerImage != null && !changeOverTime)
		{
			pointerImage.color = normalColor;
		}
		radialMenuFocused = false;
	}

	private void OnRadialButtonEnter(int index)
	{
		if (pointerTransform != null)
		{
			targetRotation = Quaternion.Euler(0f, 0f, radialMenu.UltimateRadialButtonList[index].angle - rotationOffset);
			if (!radialMenuFocused || snappingOption == SnappingOption.Instant)
			{
				pointerTransform.localRotation = targetRotation;
			}
		}
		if (!radialMenuFocused && colorChange && pointerImage != null)
		{
			if (changeOverTime)
			{
				StartCoroutine(UpdateColor());
			}
			else
			{
				pointerImage.color = activeColor;
			}
		}
		radialMenuFocused = true;
	}

	private void OnRadialMenuDisabled()
	{
		if (radialMenuFocused && colorChange && pointerImage != null && !changeOverTime)
		{
			pointerImage.color = normalColor;
		}
		radialMenuFocused = false;
	}

	private void OnRadialMenuButtonCountModified(int buttonCount)
	{
		if (!usePointerStyle)
		{
			return;
		}
		for (int num = PointerStyles.Count - 1; num >= 0; num--)
		{
			if (PointerStyles[num].buttonCount <= buttonCount)
			{
				pointerImage.sprite = PointerStyles[num].pointerSprite;
				break;
			}
		}
		if (setSiblingIndex != SetSiblingIndex.Disabled)
		{
			if (setSiblingIndex == SetSiblingIndex.Last)
			{
				base.transform.SetAsLastSibling();
			}
			else if (setSiblingIndex == SetSiblingIndex.First && base.transform.GetSiblingIndex() > 0)
			{
				base.transform.SetAsFirstSibling();
			}
		}
	}

	private void OnUpdatePositioning()
	{
		if (pointerTransform != null)
		{
			float num = radialMenu.GetComponent<RectTransform>().sizeDelta.x * pointerSize;
			pointerTransform.sizeDelta = new Vector2(num, num);
			pointerTransform.position = radialMenu.BasePosition;
			if (!Application.isPlaying && radialMenu.UltimateRadialButtonList.Count > 0)
			{
				pointerTransform.localRotation = Quaternion.Euler(0f, 0f, radialMenu.UltimateRadialButtonList[0].angle - rotationOffset);
			}
		}
	}

	private void Update()
	{
		if (!Application.isPlaying)
		{
			OnUpdatePositioning();
		}
		else if (snappingOption != SnappingOption.Instant && !(pointerTransform == null))
		{
			if (snappingOption == SnappingOption.Free)
			{
				pointerTransform.localRotation = Quaternion.Slerp(pointerTransform.localRotation, Quaternion.Euler(0f, 0f, radialMenu.GetCurrentInputAngle - rotationOffset), Time.unscaledDeltaTime * targetingSpeed);
			}
			else
			{
				pointerTransform.localRotation = Quaternion.Slerp(pointerTransform.localRotation, targetRotation, Time.unscaledDeltaTime * targetingSpeed);
			}
		}
	}

	private IEnumerator UpdateColor()
	{
		radialMenuFocused = true;
		float fadeInSpeed = 1f / fadeInDuration;
		for (float t = 0f; t < 1f; t += Time.unscaledDeltaTime * fadeInSpeed)
		{
			if (!radialMenuFocused)
			{
				break;
			}
			if (float.IsInfinity(fadeInSpeed))
			{
				break;
			}
			pointerImage.color = Color.Lerp(normalColor, activeColor, t);
			yield return null;
		}
		if (radialMenuFocused)
		{
			pointerImage.color = activeColor;
		}
		while (radialMenuFocused)
		{
			yield return null;
		}
		float fadeOutSpeed = 1f / fadeOutDuration;
		for (float t = 0f; t < 1f; t += Time.unscaledDeltaTime * fadeOutSpeed)
		{
			if (radialMenuFocused)
			{
				break;
			}
			if (float.IsInfinity(fadeOutDuration))
			{
				break;
			}
			pointerImage.color = Color.Lerp(activeColor, normalColor, t);
			yield return null;
		}
		if (!radialMenuFocused)
		{
			pointerImage.color = normalColor;
		}
	}
}
