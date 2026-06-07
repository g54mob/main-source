using PajamaLlama.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LayoutElement))]
public class DotScaler : MonoBehaviour
{
	[SerializeField]
	[Tooltip("This is the increments by which the object will scale it's preferred width, this needs to be equal to the monospace+character width to work")]
	private float _incrementStep = 17.5f;

	[SerializeField]
	private LayoutElement _layoutElement;

	[SerializeField]
	private TextMeshProUGUI _textComponent;

	private void OnEnable()
	{
		FinalUpdate.RegisterEndOfFrameOneShot(AdjustPreferredWidth);
	}

	private void AdjustPreferredWidth()
	{
		if (_textComponent != null && _layoutElement != null)
		{
			_layoutElement.preferredWidth = Mathf.Ceil(_textComponent.preferredWidth / _incrementStep) * _incrementStep;
		}
	}
}
