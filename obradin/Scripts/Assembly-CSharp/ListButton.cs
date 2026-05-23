using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ListButton : MonoBehaviour, IMoveHandler, IEventSystemHandler
{
	[Readonly]
	public Button button;

	[Readonly]
	public InvertButton invertButton;

	[Readonly]
	public LayoutElement[] textLayouts;

	public Image arrowImageL;

	public Image arrowImageR;

	public Text[] texts;

	public Image strikeImage;

	public bool isLastItemOnPage;

	private int numColumns;

	private static Color colorWhite = new Color(0f, 0f, 1f, 1f);

	private static Color colorGrey = new Color(0f, 0f, 1f, 0.25f);

	public bool hasValue
	{
		get
		{
			for (int i = 0; i < texts.Length; i++)
			{
				if (texts[i].isActiveAndEnabled && texts[i].text.HasValue())
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool arrowsVisible
	{
		set
		{
			arrowImageL.gameObject.SetActive(value);
			arrowImageR.gameObject.SetActive(value);
		}
	}

	public bool strikeVisible
	{
		set
		{
			strikeImage.gameObject.SetActive(value);
		}
	}

	public bool greyedOut
	{
		set
		{
			for (int i = 0; i < texts.Length; i++)
			{
				texts[i].color = ((!value) ? colorWhite : colorGrey);
			}
		}
	}

	public string[] columns
	{
		set
		{
			if (numColumns == 1)
			{
				texts[0].text = value[0];
				return;
			}
			if (value.Length == 1)
			{
				texts[0].text = value[0];
				textLayouts[0].enabled = false;
				for (int i = 1; i < texts.Length; i++)
				{
					texts[i].gameObject.SetActive(false);
				}
				return;
			}
			for (int j = 0; j < numColumns; j++)
			{
				textLayouts[j].enabled = true;
				texts[j].gameObject.SetActive(true);
			}
			for (int k = 0; k < value.Length && k < texts.Length; k++)
			{
				texts[k].text = value[k];
			}
			for (int l = value.Length; l < texts.Length; l++)
			{
				texts[l].text = string.Empty;
			}
		}
	}

	public void SetSingleColumn(TextAnchor alignment)
	{
		numColumns = 1;
		texts[0].gameObject.SetActive(true);
		texts[0].alignment = alignment;
		textLayouts[0].enabled = false;
		for (int i = 1; i < texts.Length; i++)
		{
			texts[i].gameObject.SetActive(false);
		}
		if (invertButton != null)
		{
			invertButton.Reset();
		}
	}

	public void SetMultiColumn(float[] columnWidths, float padding, TextAnchor[] alignments)
	{
		numColumns = columnWidths.Length;
		for (int i = 0; i < columnWidths.Length && i < texts.Length; i++)
		{
			texts[i].gameObject.SetActive(true);
			texts[i].alignment = ((alignments == null || i >= alignments.Length) ? TextAnchor.MiddleCenter : alignments[i]);
			textLayouts[i].enabled = true;
			textLayouts[i].minWidth = columnWidths[i] + padding;
			textLayouts[i].preferredWidth = columnWidths[i] + padding;
		}
		for (int j = columnWidths.Length; j < texts.Length; j++)
		{
			texts[j].gameObject.SetActive(false);
		}
		if (invertButton != null)
		{
			invertButton.Reset();
		}
	}

	public void ClearAllText()
	{
		for (int i = 0; i < numColumns; i++)
		{
			textLayouts[i].enabled = true;
			texts[i].gameObject.SetActive(true);
		}
		for (int j = 0; j < texts.Length; j++)
		{
			texts[j].text = " ";
		}
	}

	public void OnMove(AxisEventData eventData)
	{
		if (eventData.moveDir == MoveDirection.Left)
		{
			eventData.Use();
			GetComponentInParent<ListPanel>().OnClickPrevPage();
		}
		else if (eventData.moveDir == MoveDirection.Right)
		{
			eventData.Use();
			GetComponentInParent<ListPanel>().OnClickNextPage();
		}
		else if (eventData.moveDir == MoveDirection.Up && button.navigation.selectOnUp == null)
		{
			eventData.Use();
			GetComponentInParent<ListPanel>().GoDelta(-1, false);
		}
		else if (eventData.moveDir == MoveDirection.Down && (button.navigation.selectOnDown == null || isLastItemOnPage))
		{
			eventData.Use();
			GetComponentInParent<ListPanel>().GoDelta(1, false);
		}
	}
}
