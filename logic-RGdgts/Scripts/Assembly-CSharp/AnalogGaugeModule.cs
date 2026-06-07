using UnityEngine;

public class AnalogGaugeModule : Module
{
	public enum Commands
	{

	}

	public Transform gauge;

	public float startAngle;

	public float endAngle;

	public float maxOvershoot;

	public float mul;

	public float pow;

	public float damp;

	public float maxSpeed;

	public float maxAcc;

	private ModuleProperty valueProperty;

	private float angle;

	private float speed;

	private float wantedAngle => 0f;

	protected override void OnSetupFinished()
	{
	}

	private void Update()
	{
	}
}
