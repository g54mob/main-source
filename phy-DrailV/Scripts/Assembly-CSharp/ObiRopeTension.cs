using Obi;
using UnityEngine;

public class ObiRopeTension : MonoBehaviour
{
	public AnimationCurve tensionToValue;

	[Header("Outputs (read-only)")]
	public float tension;

	public float value;

	private float initialRestLength;

	private ObiRope rope;

	private void Awake()
	{
		rope = GetComponent<ObiRope>();
		initialRestLength = rope.RestLength;
	}

	private void Update()
	{
		tension = rope.CalculateLength() / initialRestLength;
		value = tensionToValue.Evaluate(tension);
	}
}
