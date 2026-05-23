using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Folio : MonoBehaviour
{
	public FolioSpec spec;

	public BookSpec.FolioSource source;

	public bool includeMeshPins;

	public bool showExtraNavBorder = true;

	public List<FolioPin> pins;

	public GameObject pinsHolder;

	private Vector2? holderSize_;

	private Vector2 focus_;

	private FolioNav nav;

	private bool initted;

	private string focusPinId;

	private Canvas canvas;

	private Dictionary<string, FolioPin> pinDict = new Dictionary<string, FolioPin>();

	public float extraBorder
	{
		get
		{
			return (nav != null && showExtraNavBorder) ? 30 : 0;
		}
	}

	public Vector2 holderSize
	{
		get
		{
			if (!holderSize_.HasValue)
			{
				RectTransform rectTransform = base.transform.parent as RectTransform;
				Vector2 size = rectTransform.rect.size;
				if (size.x < 1f)
				{
					LayoutElement component = rectTransform.GetComponent<LayoutElement>();
					if (component != null)
					{
						size.x = Mathf.Max(component.minWidth, component.preferredWidth);
						size.y = Mathf.Max(component.minHeight, component.preferredHeight);
					}
					if (size.x < 1f)
					{
						Debug.LogErrorFormat("Invalid Folio holderSize: {0} {1}", Util.GetObjectPath(base.gameObject), size);
					}
				}
				holderSize_ = size;
			}
			return holderSize_.Value;
		}
	}

	public Vector2 focus
	{
		get
		{
			return focus_;
		}
		set
		{
			focus_ = value;
			RectTransform rectTransform = base.transform as RectTransform;
			Vector3 localScale = rectTransform.localScale;
			Vector2 anchoredPosition = new Vector2(Mathf.Clamp((0f - focus_.x) * localScale.x + holderSize.x * 0.5f, (0f - spec.size.x) * localScale.x + holderSize.x, 0f), Mathf.Clamp(focus_.y * localScale.y - holderSize.y * 0.5f, 0f - extraBorder, spec.size.y * localScale.y - holderSize.y + extraBorder));
			rectTransform.anchoredPosition = anchoredPosition;
			if (nav != null)
			{
				nav.SetFocusInFolio(focus_);
			}
		}
	}

	public bool hasVisibleMeshPin
	{
		get
		{
			if (!includeMeshPins)
			{
				return false;
			}
			foreach (FolioPin pin in pins)
			{
				if (pin.spec.mesh != null && pin.isActiveAndEnabled)
				{
					return true;
				}
			}
			return false;
		}
	}

	public void BeginRefresh()
	{
		if (!initted)
		{
			foreach (FolioPin pin in pins)
			{
				pinDict.Add(pin.spec.id, pin);
			}
			nav = GetComponent<FolioNav>();
			initted = true;
		}
		foreach (FolioPin pin2 in pins)
		{
			pin2.touched = false;
		}
	}

	public void SetFocusPin(string pinId)
	{
		if (pinDict.ContainsKey(pinId))
		{
			focusPinId = pinId;
			FolioPin folioPin = pinDict[pinId];
			if (folioPin.dynamicPosition)
			{
				Vector2 anchoredPosition = folioPin.rt.anchoredPosition;
				focus = new Vector2(anchoredPosition.x, 0f - anchoredPosition.y);
			}
			else
			{
				focus = pinDict[pinId].spec.rect.center;
			}
		}
		else
		{
			focusPinId = null;
		}
	}

	public void ShowPin(string pinId, Sprite overrideSprite = null, Material overrideMaterial = null)
	{
		if (!pinDict.ContainsKey(pinId))
		{
			return;
		}
		FolioPin folioPin = pinDict[pinId];
		folioPin.touched = true;
		if (!(folioPin.image != null))
		{
			return;
		}
		if (!folioPin.localized)
		{
			if (overrideSprite == null)
			{
				overrideSprite = ((!(pinId == focusPinId)) ? folioPin.spec.sprite : folioPin.spec.focusedSprite);
			}
			if (folioPin.image.sprite != overrideSprite)
			{
				folioPin.image.sprite = overrideSprite;
			}
		}
		if (overrideMaterial == null)
		{
			overrideMaterial = folioPin.spec.material;
		}
		if (folioPin.image.material != overrideMaterial)
		{
			folioPin.image.material = overrideMaterial;
		}
	}

	public void ShowPin(string pinId, Vector2 pos, Vector2 dir)
	{
		if (!pinDict.ContainsKey(pinId))
		{
			Debug.LogWarning("Pin not found: " + pinId);
			return;
		}
		FolioPin folioPin = pinDict[pinId];
		folioPin.touched = true;
		folioPin.dynamicPosition = true;
		RectTransform rt = folioPin.rt;
		rt.anchoredPosition = new Vector2(pos.x, pos.y - spec.size.y);
		rt.localRotation = Quaternion.Euler(0f, 0f, 57.29578f * Mathf.Atan2(dir.y, dir.x) + 90f);
	}

	public void EndRefresh()
	{
		RectTransform rectTransform = base.transform as RectTransform;
		Vector3 localScale = rectTransform.localScale;
		Vector2 vector = new Vector2(holderSize.x / localScale.x, holderSize.y / localScale.y);
		Rect other = new Rect((0f - rectTransform.anchoredPosition.x) / localScale.x, rectTransform.anchoredPosition.y / localScale.y, vector.x, vector.y);
		foreach (FolioPin pin in pins)
		{
			bool active = pin.touched && (nav != null || pin.spec.mesh != null || pin.spec.rect.Overlaps(other));
			pin.gameObject.SetActive(active);
		}
	}

	public FolioPin GetPinUnder(Vector2 posInSpecSpace)
	{
		FolioPin folioPin = null;
		float num = 1000000f;
		foreach (FolioPin pin in pins)
		{
			if (pin.isActiveAndEnabled && pin.spec.selectable && pin.spec.rect.Contains(posInSpecSpace))
			{
				float sqrMagnitude = (pin.spec.rect.center - posInSpecSpace).sqrMagnitude;
				if (folioPin == null || sqrMagnitude < num)
				{
					folioPin = pin;
					num = sqrMagnitude;
				}
			}
		}
		return folioPin;
	}
}
