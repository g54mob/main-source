using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LayoutElement))]
public class LayoutElementWidthMatcher : MonoBehaviour
{
	[Tooltip("Layout width that needs to be matched.")]
	[SerializeField]
	private LayoutGroup _matchingLayoutGroup;

	private LayoutElement _layoutElement;

	protected void Awake()
	{
		_layoutElement = GetComponent<LayoutElement>();
	}

	protected void LateUpdate()
	{
		UpdateWidth();
	}

	private void UpdateWidth()
	{
		_layoutElement.preferredWidth = _matchingLayoutGroup.preferredWidth;
	}
}
