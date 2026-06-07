using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class ShapekeyPingPong : MonoBehaviour
{
	public AnimationCurve curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

	public float speed = 6f;

	private SkinnedMeshRenderer sr;

	private float clock;

	private void Start()
	{
		sr = GetComponent<SkinnedMeshRenderer>();
		clock = Random.value;
	}

	private void Update()
	{
		clock += Time.deltaTime;
		sr.SetBlendShapeWeight(0, curve.Evaluate(clock) * 100f);
	}
}
