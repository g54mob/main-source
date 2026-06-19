using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloraInfo : MonoBehaviour
{
	public Image floraImage;

	public Image highlightImage;

	public TextMeshProUGUI floraNameString;

	private float activeAlpha = 0.5f;

	private float inactiveAlpha;

	private float highlightAlpha = 0.25f;

	private bool isSelected;

	private bool isBoosted;

	private string boostedString = "+";

	private Color boostedColor = Color.white;

	private CursorUpdateArea owningCursorUpdateArea;

	private GutFloraResource resourceRef;

	private DogGutGUIManager guiManagerRef;

	public void SetFloraInfo(GutFloraResource info, DogGutGUIManager managerRef, CursorUpdateArea areaRef, bool boosted = false)
	{
		isBoosted = boosted;
		guiManagerRef = managerRef;
		owningCursorUpdateArea = areaRef;
		resourceRef = info;
		floraNameString.text = GetFloraName();
		floraImage.sprite = info.gutFloraPreviewSprite;
		floraImage.SetNativeSize();
		if (boosted)
		{
			boostedColor = info.gutFloraPrefab.GetComponent<GutFloraBase>().boostedColor;
			floraImage.color = boostedColor;
		}
		OnSetInactive();
	}

	public GutFloraResource GetFloraResource()
	{
		return resourceRef;
	}

	public string GetFloraName()
	{
		string text = resourceRef.floraNameLocalized;
		if (isBoosted)
		{
			text += boostedString;
		}
		return text;
	}

	public string GetFloraDescription()
	{
		return resourceRef.floraDescriptionLocalized;
	}

	public Sprite GetFloraPreviewSprite()
	{
		return resourceRef.gutFloraPreviewSprite;
	}

	public Color GetFloraTint()
	{
		return floraImage.color;
	}

	public void OnInfoStay()
	{
		if (owningCursorUpdateArea != null)
		{
			owningCursorUpdateArea.ReportCursorOverContent();
		}
	}

	public void OnInfoOver()
	{
		if (!isSelected)
		{
			highlightImage.color = new Color(highlightImage.color.r, highlightImage.color.g, highlightImage.color.b, highlightAlpha);
		}
	}

	public void OnInfoExit()
	{
		if (!isSelected)
		{
			highlightImage.color = new Color(highlightImage.color.r, highlightImage.color.g, highlightImage.color.b, inactiveAlpha);
		}
	}

	public void OnInfoClicked()
	{
		guiManagerRef.SetActiveFloraInfo(this);
	}

	public void OnSetActive()
	{
		isSelected = true;
		highlightImage.color = new Color(highlightImage.color.r, highlightImage.color.g, highlightImage.color.b, activeAlpha);
	}

	public void OnSetInactive()
	{
		isSelected = false;
		highlightImage.color = new Color(highlightImage.color.r, highlightImage.color.g, highlightImage.color.b, inactiveAlpha);
	}
}
