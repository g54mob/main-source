using UnityEngine;

public class FurMotion : MonoBehaviour
{
	public Transform referenceTransform;

	public Renderer rendererTarget;

	public float motionFalloff = 0.5f;

	private Material furMat;

	private Vector3 lastPos;

	private void Awake()
	{
		lastPos = referenceTransform.localPosition;
		if (rendererTarget.materials.Length >= 2)
		{
			furMat = rendererTarget.materials[1];
		}
	}

	private void FixedUpdate()
	{
		UpdateFurVars();
	}

	private void UpdateFurVars()
	{
		if (furMat == null)
		{
			lastPos = referenceTransform.localPosition;
			return;
		}
		Vector3 vector = referenceTransform.localPosition - lastPos;
		vector = new Vector3(vector.x, vector.z, vector.y);
		Vector3 vector2 = furMat.GetVector("_MotionVector");
		vector2 *= motionFalloff;
		if (vector2 != Vector3.zero && vector2.magnitude < 0.0001f)
		{
			vector2 = Vector3.zero;
		}
		furMat.SetVector("_MotionVector", vector + vector2);
		lastPos = referenceTransform.localPosition;
	}
}
