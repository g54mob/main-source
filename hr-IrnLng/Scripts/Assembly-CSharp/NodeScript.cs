using UnityEngine;

public class NodeScript : MonoBehaviour, ISaveObject
{
	public struct NodeData
	{
		public bool Did;
	}

	public GameObject MarkerPrefab;

	public float PictureAngle;

	[HideInInspector]
	public MapMarkerScript MyMarker;

	public string cheevotext;

	private NodeData MyData;

	public string MyID => base.gameObject.name + base.transform.position.ToString();

	private void Awake()
	{
		GameObject gameObject = Object.Instantiate(MarkerPrefab);
		gameObject.transform.parent = GameObject.Find("MapCanvas").transform;
		MyMarker = gameObject.GetComponent<MapMarkerScript>();
		MyMarker.SetMarkerSource(base.transform.gameObject);
		MyMarker.MyCoors.x = base.transform.position.x;
		MyMarker.MyCoors.y = base.transform.position.z;
		MyMarker.MyAngle = PictureAngle;
		MyMarker.cheevotext = cheevotext;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public object SaveData()
	{
		MyData.Did = MyMarker.GetComponent<MapMarkerScript>().CheckStatus();
		return MyData;
	}

	public void LoadData(object dataIn)
	{
		MyData = (NodeData)dataIn;
		MyMarker.GetComponent<MapMarkerScript>().SetStatus(MyData.Did);
	}
}
