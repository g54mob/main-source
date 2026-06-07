using UnityEngine;

public class Ferry : MonoBehaviour
{
	private Bounds bounds;

	private HeadMotion headMotion;

	private Matrix4x4 baseMatrix;

	private Matrix4x4 baseMatrixInv;

	private Animator leanAnimator;

	private LaggedTransform leanLaggedTransform = new LaggedTransform();

	private LaggedTransform headLaggedTransform = new LaggedTransform();

	private void Start()
	{
		headMotion = HeadMotion.FindGlobalInstance();
		baseMatrix = base.transform.localToWorldMatrix;
		baseMatrixInv = base.transform.worldToLocalMatrix;
		Animator[] componentsInChildren = GetComponentsInChildren<Animator>();
		foreach (Animator animator in componentsInChildren)
		{
			if (animator.name.Contains("Ferry"))
			{
				leanAnimator = animator;
			}
		}
		BoxCollider component = GetComponent<BoxCollider>();
		bounds = component.bounds;
		component.enabled = false;
		FixedUpdate();
	}

	private void FixedUpdate()
	{
		leanLaggedTransform.Approach(WaveMotion.GetFerryMatrix(), 0.05f);
		headLaggedTransform.Approach(WaveMotion.GetFerryMatrix(), 0.3f);
	}

	private void Update()
	{
		Matrix4x4 m = baseMatrix * WaveMotion.GetFerryBase() * WaveMotion.GetFerryMatrix();
		base.transform.rotation = Util.QuaternionFromMatrix(m);
		base.transform.position = m.GetColumn(3);
		Vector3 eulerAngles = leanLaggedTransform.rot.eulerAngles;
		if (eulerAngles.x > 180f)
		{
			eulerAngles.x -= 360f;
		}
		if (eulerAngles.z > 180f)
		{
			eulerAngles.z -= 360f;
		}
		float value = Util.LerpScale(eulerAngles.x, -9f, 9f, 1f, -1f);
		float value2 = Util.LerpScale(eulerAngles.z, -9f, 9f, -1f, 1f);
		leanAnimator.SetFloat("BlendX", value);
		leanAnimator.SetFloat("BlendY", value2);
		Vector3 cameraWorldPositionWithoutOffset = headMotion.GetCameraWorldPositionWithoutOffset(HeadMotion.Id.FromWaves);
		if (bounds.Contains(cameraWorldPositionWithoutOffset))
		{
			Vector3 point = baseMatrixInv.MultiplyPoint(cameraWorldPositionWithoutOffset);
			Vector3 vector = m.MultiplyPoint(point);
			Vector3 offset = 1f * (vector - cameraWorldPositionWithoutOffset);
			headMotion.SetOffset(HeadMotion.Id.FromWaves, offset, 10);
		}
	}

	private void LateUpdate()
	{
	}
}
