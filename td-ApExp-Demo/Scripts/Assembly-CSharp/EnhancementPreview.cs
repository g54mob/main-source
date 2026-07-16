using TMPro;
using UnityEngine;

public class EnhancementPreview : MonoBehaviour
{
	[field: SerializeField]
	public TextMeshProUGUI Name { get; private set; }

	[field: SerializeField]
	public TextMeshProUGUI Type { get; private set; }

	[field: SerializeField]
	public TextMeshProUGUI Description { get; private set; }

	public void SetPreview(Enhancement enhancement)
	{
		Name.text = enhancement.Name;
		Type.text = enhancement.GetEnhancementType();
		Description.text = enhancement.Description;
	}
}
