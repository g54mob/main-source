using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LayoutElement))]
public class LayoutElementWidthClamper : MonoBehaviour
{
	[SerializeField]
	private float _maxWidth = 300f;

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
		_layoutElement.preferredWidth = Mathf.Clamp(_layoutElement.preferredWidth, 0f, _maxWidth);
	}
}
