using UnityEngine;

public class NodeManagerScript : MonoBehaviour
{
	private MapMarkerScript[] NodeLibrary;

	public float PositionError;

	public float AngleError;

	public MonsterModelTriggerScript Monster;

	private SubController SMan;

	private void Start()
	{
		GetNodes();
		SMan = GameObject.Find("FakeSub").GetComponent<SubController>();
	}

	private void Update()
	{
		Vector2 pos = new Vector2(SMan.transform.position.x, SMan.transform.position.z);
		CheckForFinal(pos);
	}

	public void GetNodes()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("NodeTag");
		NodeLibrary = new MapMarkerScript[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			NodeLibrary[i] = array[i].GetComponent<NodeScript>().MyMarker;
		}
	}

	public int CheckNodes(Vector2 pos, float a)
	{
		GetNodes();
		for (int i = 0; i < NodeLibrary.Length; i++)
		{
			float num = Mathf.Abs((NodeLibrary[i].MyCoors - pos).magnitude);
			float num2 = Mathf.Abs(NodeLibrary[i].MyAngle - a);
			if (num <= PositionError && num2 <= AngleError)
			{
				return i;
			}
		}
		return -1;
	}

	public void PictureTaken(Vector2 pos, float a)
	{
		int num = CheckNodes(pos, a);
		if (num != -1)
		{
			NodeLibrary[num].SetStatus(b: true);
		}
	}

	public void CheckForFinal(Vector2 pos)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < NodeLibrary.Length; i++)
		{
			if (!NodeLibrary[i].CheckStatus())
			{
				num++;
				num2 = i;
			}
		}
		if (num <= 1 && Mathf.Abs((NodeLibrary[num2].MyCoors - pos).magnitude) <= PositionError)
		{
			Monster.DoActivate = true;
		}
	}
}
