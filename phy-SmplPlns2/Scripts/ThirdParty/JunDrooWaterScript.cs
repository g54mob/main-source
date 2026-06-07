using UnityEngine;

[ExecuteInEditMode]
public class JunDrooWaterScript : MonoBehaviour
{
	public AnimationCurve layer1Curve;

	public float layer1Distance;

	public float layer1Duration;

	public float layer1Angle;

	public AnimationCurve layer2Curve;

	public float layer2Distance;

	public float layer2Duration;

	public float layer2Angle;

	private Vector4 _uv = new Vector4(0f, 0f, 0f, 0f);

	private int _propID;

	private Vector2 _layer1Start;

	private Vector2 _layer2Start;

	private Vector2 _layer1End;

	private Vector2 _layer2End;

	private float _layer1Time;

	private float _layer2Time;

	private void Start()
	{
		_propID = Shader.PropertyToID("_echoUVOffset");
		float num = Mathf.Sin(layer1Angle);
		float num2 = Mathf.Cos(layer1Angle);
		_layer1Start = new Vector2(0f, 0f);
		_layer2Start = new Vector2(0f, 0f);
		_layer1End = new Vector2(num * layer1Distance, num2 * layer1Distance);
		num = Mathf.Sin(layer2Angle);
		num2 = Mathf.Cos(layer2Angle);
		_layer2End = new Vector2(num * layer2Distance, num2 * layer2Distance);
	}

	private void Update()
	{
		float num = Mathf.Clamp(_layer1Time / layer1Duration, 0f, 1f);
		_layer1Time += Time.deltaTime;
		Vector2 vector = Vector2.Lerp(_layer1Start, _layer1End, layer1Curve.Evaluate(num));
		if (num >= 1f)
		{
			_layer1Time = 0f;
		}
		_uv.x = vector.x;
		_uv.y = vector.y;
		num = Mathf.Clamp(_layer2Time / layer2Duration, 0f, 1f);
		_layer2Time += Time.deltaTime;
		vector = Vector2.Lerp(_layer2Start, _layer2End, layer2Curve.Evaluate(num));
		if (num >= 1f)
		{
			_layer2Time = 0f;
		}
		_uv.z = vector.x;
		_uv.w = vector.y;
		Shader.SetGlobalVector(_propID, _uv);
	}
}
