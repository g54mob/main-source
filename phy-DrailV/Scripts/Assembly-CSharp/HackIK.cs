using DV.Utils;
using JetBrains.Annotations;
using RootMotion.FinalIK;
using UnityEngine;

[ExecuteBefore(typeof(ChainCouplerInteraction))]
public class HackIK : MonoBehaviour
{
	private const float THRESHOLD_SQR = 9.999999E-09f;

	[SerializeField]
	private IK[] iks;

	[SerializeField]
	private float smoothDampTime = 0.2f;

	[SerializeField]
	private float smoothDampMaxSpeed = 0.07f;

	[SerializeField]
	private Vector2 minMaxLength = new Vector2(0.1f, 0.4f);

	[Range(0f, 1f)]
	public float target;

	private Transform nut1;

	private Transform nut2;

	private Vector3 refVel;

	[UsedImplicitly]
	[Header("Debug")]
	public bool didSomething;

	private void Awake()
	{
		IKSolverHeuristic iKSolverHeuristic = (IKSolverHeuristic)iks[0].GetIKSolver();
		nut1 = iKSolverHeuristic.bones[2].transform;
		nut2 = iKSolverHeuristic.bones[3].transform;
	}

	private void OnEnable()
	{
		target = Mathf.InverseLerp(minMaxLength.x, minMaxLength.y, Vector3.Distance(nut1.position, nut2.position));
	}

	private void Update()
	{
		Vector3 vector = nut2.position - nut1.position;
		float num = Mathf.Lerp(minMaxLength.x, minMaxLength.y, target);
		Vector3 vector2 = Vector3.SmoothDamp(vector, vector.normalized * num, ref refVel, smoothDampTime, smoothDampMaxSpeed, Time.deltaTime) - vector;
		if (didSomething = vector2.sqrMagnitude > 9.999999E-09f)
		{
			for (int i = 0; i < iks.Length; i++)
			{
				((IKSolverHeuristic)iks[i].GetIKSolver()).bones[3].transform.position += vector2;
			}
		}
	}
}
