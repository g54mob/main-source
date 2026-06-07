using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Effects/Text Gradient")]
public class UITextGradient : BaseMeshEffect
{
	public Color m_color1;

	public Color m_color2;

	[Range(-180f, 180f)]
	public float m_angle;

	public override void ModifyMesh(VertexHelper vh)
	{
	}
}
