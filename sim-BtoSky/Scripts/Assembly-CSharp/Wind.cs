using System;
using UnityEngine;

public class Wind : MonoBehaviour
{
	[Header("Horizontal Wind Settings (수평 바람)")]
	public float baseStrength = 3f;

	public float gustStrength = 2f;

	public float directionChangeSpeed = 0.1f;

	public float strengthChangeSpeed = 0.5f;

	[Header("Vertical Wind Settings (수직 바람)")]
	[Tooltip("위아래로 부는 바람의 최대 세기입니다. 수평 바람보다 작게 설정하는 것이 자연스럽습니다.")]
	public float verticalStrength = 1f;

	public float verticalChangeSpeed = 0.3f;

	public Vector3 wind;

	private float eventTimer;

	private float noiseOffsetStrength;

	private float noiseOffsetDir;

	private float noiseOffsetVertical;

	public static event Action<Vector3> OnWindDirChanged;

	private void Start()
	{
		GameManager.S.windManager = this;
		noiseOffsetStrength = UnityEngine.Random.Range(0f, 1000f);
		noiseOffsetDir = UnityEngine.Random.Range(0f, 1000f);
		noiseOffsetVertical = UnityEngine.Random.Range(0f, 1000f);
	}

	private void Update()
	{
		float num = Mathf.PerlinNoise(Time.time * strengthChangeSpeed + noiseOffsetStrength, 0f);
		float num2 = baseStrength + num * gustStrength;
		float num3 = Mathf.PerlinNoise(Time.time * directionChangeSpeed + noiseOffsetDir, 0f) * 360f;
		Vector3 vector = new Vector3(Mathf.Cos(num3 * (MathF.PI / 180f)), 0f, Mathf.Sin(num3 * (MathF.PI / 180f)));
		float num4 = (Mathf.PerlinNoise(0f, Time.time * verticalChangeSpeed + noiseOffsetVertical) * 2f - 1f) * verticalStrength;
		wind = vector * num2;
		wind.y += num4;
		eventTimer += Time.deltaTime;
		if (eventTimer >= 2f)
		{
			Wind.OnWindDirChanged?.Invoke(wind);
			eventTimer = 0f;
		}
	}
}
