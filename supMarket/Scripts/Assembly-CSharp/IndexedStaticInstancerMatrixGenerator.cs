using UnityEngine;

[RequireComponent(typeof(IndexedStaticInstancer))]
public class IndexedStaticInstancerMatrixGenerator : MonoBehaviour
{
	[SerializeField]
	private int m_Count;

	[SerializeField]
	private Vector3 m_StartPosition;

	[SerializeField]
	private float m_PerInstanceOffset;

	[SerializeField]
	private AnimationCurve m_Curve;

	[SerializeField]
	private float m_CurveMultiplier;

	[SerializeField]
	private float m_AnglePerZ;

	public Matrix4x4 GetMatrix(int index)
	{
		return default(Matrix4x4);
	}
}
