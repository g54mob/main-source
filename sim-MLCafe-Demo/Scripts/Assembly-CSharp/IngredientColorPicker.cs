using UnityEngine;

public class IngredientColorPicker : MonoBehaviour
{
	[SerializeField]
	private Color defaultColor;

	[SerializeField]
	private SkinnedMeshRenderer skinnedMeshRenderer;

	public void PickColorByMask(int mask = -1)
	{
		Color tagColor = defaultColor;
		if (mask > 0)
		{
			tagColor = AnomalyTag.GetTagColor(mask);
		}
		skinnedMeshRenderer.material.SetColor("_Color", tagColor);
	}
}
