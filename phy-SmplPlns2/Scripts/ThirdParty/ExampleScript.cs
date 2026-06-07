using UnityEngine;

public class ExampleScript : MonoBehaviour
{
	public enum ExampleEnum
	{
		Walk = 0,
		Run = 1,
		Sprint = 2
	}

	public enum ExampleEnum2
	{
		Crouch = 0,
		Stand = 1,
		Jump = 2
	}

	public bool BooleanValue;

	public float FloatValue;

	public int IntValue;

	public Vector2 Vector2Value;

	public Vector3 Vector3Value;

	public Color ColorValue;

	public Color32 Color32Value;

	public string StringValue;

	public ExampleEnum EnumValue;

	private void Update()
	{
		BooleanValue = Mathf.Repeat(Time.time, 1f) > 0.5f;
		FloatValue = Mathf.PingPong(Time.realtimeSinceStartup, 1f);
		IntValue = Mathf.FloorToInt(FloatValue * 10f);
		Vector2Value = GetComponent<Rigidbody2D>().linearVelocity;
		Vector3Value = base.transform.position;
		ColorValue = Color.Lerp(DebugGraph.DefaultBlue, new Color(1f, 0.75f, 0.25f), Mathf.PingPong(Time.realtimeSinceStartup, 1f));
		Color32Value = ColorValue;
		StringValue = "Hello World! The Current Frame Number Is: " + Time.frameCount;
		EnumValue = (ExampleEnum)(Time.frameCount % 3);
		float num = Mathf.Sin(Mathf.Repeat(Time.time, 6.28f));
		float num2 = Mathf.Cos(Mathf.Repeat(Time.time, 6.28f));
		DebugGraph.Log("Color Gradient", ColorValue);
		DebugGraph.Write("String", StringValue);
		DebugGraph.Log("Vector3", Input.mousePosition);
		DebugGraph.Log("Vector4", new Vector4(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
		base.transform.Rotate(Vector3.up, Time.deltaTime * 90f);
		DebugGraph.Log("Quaternion", base.transform.rotation);
		DebugGraph.Log("Rect", new Rect(0f, 0f, 100f, 100f));
		DebugGraph.Draw(new Vector2(num * Time.time, num2 * Time.time));
		DebugGraph.MultiLog("Related Variables", DebugGraph.DefaultRed, num, "Sin");
		DebugGraph.MultiLog("Related Variables", DebugGraph.DefaultGreen, num2, "Cos");
		DebugGraph.Log(FloatValue);
		DebugGraph.MultiLog(num2 * 1.1f);
		DebugGraph.MultiLog(num2 * 1.2f);
		DebugGraph.MultiLog(num2 * 1.3f, "C");
		DebugGraph.MultiLog(num2 * 1.4f, "D");
		DebugGraph.MultiLog(num2 * 1.5f, "E");
		for (int i = 0; i < 10; i++)
		{
			DebugGraph.MultiLog(DebugGraph.GetUniqueColor(i), num * (1f + (float)i * 0.1f), i.ToString());
		}
		DebugGraph.Log(Mathf.FloorToInt(num * 10f));
		DebugGraph.Log(Mathf.RoundToInt(Mathf.PerlinNoise(Time.time, Time.time) * 1f) > 0);
		DebugGraph.MultiLog(EnumValue);
		DebugGraph.MultiLog((ExampleEnum2)(Mathf.PerlinNoise(Time.time, Time.time) * 3f));
	}
}
