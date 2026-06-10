using UnityEngine;

public class ToolHelper : MonoBehaviour
{
	[SerializeField]
	private Transform particlePosition;

	public Vector3 ParticlePosition
	{
		get
		{
			if (!(particlePosition == null))
			{
				return particlePosition.position;
			}
			return Vector3.zero;
		}
	}

	public Transform ParticleTransform => particlePosition;
}
