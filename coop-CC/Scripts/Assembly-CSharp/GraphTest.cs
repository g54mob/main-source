using UnityEngine;

public class GraphTest : MonoBehaviour
{
	private void Update()
	{
		GraphDebug.GraphValue("MyValue", new Vector2(Time.time, Time.time), Color.green);
	}
}
