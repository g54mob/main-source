using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Effects/4 Corners Gradient")]
public class UICornersGradient : BaseMeshEffect
{
	public Color m_topLeftColor;

	public Color m_topRightColor;

	public Color m_bottomRightColor;

	public Color m_bottomLeftColor;

	public override void ModifyMesh(VertexHelper vh)
	{
	}
}
