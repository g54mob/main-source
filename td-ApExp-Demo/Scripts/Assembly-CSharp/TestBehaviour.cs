using UnityEngine;

public class TestBehaviour : MonoBehaviour
{
	private Unit TargetUnit;

	private void Start()
	{
	}

	private void Update()
	{
		if (TargetUnit == null)
		{
			Target();
		}
		if (TargetUnit != null)
		{
			Vector3 position = TargetUnit.transform.position;
			Vector3 upwards = new Vector3(TargetUnit.transform.position.x, position.y) - base.transform.position;
			Quaternion to = Quaternion.LookRotation(Vector3.forward, upwards);
			base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, Time.deltaTime * 60f);
		}
	}

	private void Target()
	{
		if (Train.Instance.Modules != null && Train.Instance.Modules.Count > 0)
		{
			TargetUnit = Train.Instance.Modules[0];
		}
	}
}
