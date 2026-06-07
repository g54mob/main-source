using UnityEngine;

public class EntranceVariantSignboard : MonoBehaviour
{
	public bool IsDefault;

	[SerializeField]
	private MeshRenderer m_NameBackgroundRenderer;

	[SerializeField]
	private Material m_DefaultMaterial;

	[SerializeField]
	private Material m_ColoredMaterial;

	public void SetDefault()
	{
	}

	public void ChangeNameBackgroundColor(Color color)
	{
	}
}
