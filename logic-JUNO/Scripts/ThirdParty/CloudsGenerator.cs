using UnityEngine;

public class CloudsGenerator : MonoBehaviour
{
	public float Density = 2f;

	public GameObject[] Prefabs = new GameObject[0];

	public Vector3 StartPos = Vector3.zero;

	public Vector3 EndPos = new Vector3(100f, 0f, 100f);

	public Texture2D HeightMap;

	private void Start()
	{
		int num = 0;
		Vector3 startPos = StartPos;
		while (startPos.z < EndPos.z)
		{
			startPos.z += Random.Range(Density / 2f, Density * 1.5f);
			startPos.x = StartPos.x;
			while (startPos.x < EndPos.x)
			{
				startPos.x += Random.Range(Density / 5f, Density * 5f);
				int x = (int)((float)HeightMap.width * startPos.x / (EndPos - StartPos).x);
				int y = (int)((float)HeightMap.height * startPos.z / (EndPos - StartPos).x);
				if (!(HeightMap.GetPixel(x, y).g < 0.75f))
				{
					_ = HeightMap.GetPixel(x, y).g * 46f - 30f;
					float num2 = HeightMap.GetPixel(x, y).b * 40f;
					num2 *= 5f;
					startPos.y = 150f;
					int num3 = Random.Range(0, Prefabs.Length);
					num++;
					GameObject obj = Object.Instantiate(Prefabs[num3], startPos, Quaternion.identity);
					obj.transform.localScale = new Vector3(num2, 10f, num2);
					obj.transform.parent = base.transform;
				}
			}
		}
		Debug.Log(num);
	}

	private void Update()
	{
		base.transform.position += Vector3.back * Time.deltaTime * 100f;
	}
}
