using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UIFramework
{
	public class CollapsibleElementVisualController : MonoBehaviour
	{
		[SerializeField]
		private CollapsibleElement collapsibleElement;

		[SerializeField]
		private Image collapseIndicatorImage;

		[SerializeField]
		private GameObject selectionButtonContainer;

		[SerializeField]
		private TextMeshProUGUI elementText;

		[SerializeField]
		private Color categoryTextColor = Color.white;

		[SerializeField]
		private Color articleTextColor = Color.cyan;

		[SerializeField]
		private Color searchMatchColor = Color.yellow;

		private static readonly Quaternion collapsedIndicatorRotation = Quaternion.identity;

		private static readonly Quaternion expandedIndicatorRotation = Quaternion.Euler(0f, 0f, -90f);

		private void Awake()
		{
			if (collapsibleElement == null)
			{
				Debug.LogError("CollapsibleElementVisualController: collapsibleElement is null. Visuals will be unchanged.", this);
				return;
			}
			if (collapseIndicatorImage == null)
			{
				Debug.LogError("CollapsibleElementVisualController: collapseIndicatorImage is null. Visuals will be unchanged.", this);
				return;
			}
			collapsibleElement.TextChangeRequested += OnTextChangeRequested;
			collapsibleElement.CollapsedChanged += OnCollapseChanged;
			collapsibleElement.SelectionChanged += OnSelectionChanged;
			collapsibleElement.SearchMatchChanged += OnSearchMatchChanged;
			OnCollapseChanged(collapsibleElement, collapsibleElement.IsCollapsed);
		}

		private void OnSelectionChanged(CollapsibleElement _, bool selected)
		{
			if (selectionButtonContainer != null)
			{
				selectionButtonContainer.SetActive(selected);
			}
		}

		private void OnSearchMatchChanged(CollapsibleElement _, bool matched)
		{
			UpdateColor(matched);
		}

		private void OnDestroy()
		{
			if (!(collapsibleElement == null))
			{
				collapsibleElement.CollapsedChanged -= OnCollapseChanged;
				collapsibleElement.TextChangeRequested -= OnTextChangeRequested;
				collapsibleElement.SelectionChanged -= OnSelectionChanged;
				collapsibleElement.SearchMatchChanged -= OnSearchMatchChanged;
			}
		}

		private void OnTextChangeRequested(CollapsibleElement _, string text)
		{
			elementText.text = text;
			UpdateColor(searchMatched: false);
			if (collapsibleElement.isLeaf && collapseIndicatorImage != null)
			{
				collapseIndicatorImage.color = Color.clear;
			}
		}

		private void OnCollapseChanged(CollapsibleElement _, bool collapsed)
		{
			if (!(collapseIndicatorImage == null))
			{
				collapseIndicatorImage.transform.localRotation = (collapsed ? collapsedIndicatorRotation : expandedIndicatorRotation);
			}
		}

		private void UpdateColor(bool searchMatched)
		{
			Color color = (searchMatched ? searchMatchColor : ((!collapsibleElement.isLeaf) ? categoryTextColor : articleTextColor));
			elementText.color = color;
		}
	}
}
