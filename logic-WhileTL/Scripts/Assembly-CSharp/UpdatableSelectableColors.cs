using UnityEngine;
using UnityEngine.UI;

public class UpdatableSelectableColors : MonoBehaviour
{
	public string highlightedColorId;

	public string pressedColorId;

	private const bool selfDestroy = true;

	private static readonly Color defaultHighlightedColor = new Color(28f / 51f, 28f / 51f, 28f / 51f);

	private static readonly Color defaultPressedColor = new Color(10f / 51f, 10f / 51f, 10f / 51f);

	private Selectable selectable;

	private void Start()
	{
		selectable = base.gameObject.GetComponent<Selectable>();
		if (selectable == null)
		{
			Object.Destroy(this);
		}
		else if (Logic.staticDataLoaded)
		{
			SetButtonColors();
			Object.Destroy(this);
		}
		else
		{
			Logic.staticDataLoadedEvent.AddListener(StaticDataLoadedListener);
		}
	}

	private void StaticDataLoadedListener()
	{
		SetButtonColors();
		Object.Destroy(this);
	}

	private void SetButtonColors()
	{
		ColorBlock colors = selectable.colors;
		colors.highlightedColor = Logic.GetColorIfExists(highlightedColorId) ?? defaultHighlightedColor;
		colors.pressedColor = Logic.GetColorIfExists(pressedColorId) ?? defaultPressedColor;
		selectable.colors = colors;
	}

	private void OnDestroy()
	{
		Logic.staticDataLoadedEvent.RemoveListener(SetButtonColors);
	}
}
