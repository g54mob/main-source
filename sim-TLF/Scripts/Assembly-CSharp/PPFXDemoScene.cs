using UnityEngine;

public class PPFXDemoScene : MonoBehaviour
{
	public PPFXSpawnOnClick spawnScript;

	public GameObject plane;

	public GameObject pyramid;

	public GameObject cameraRotate;

	public Camera cam;

	private bool hideGUI;

	private bool hidePlane;

	private bool rotateCamera;

	private float zoomSlider = 60f;

	private int selectedIndex;

	public Texture2D logo;

	public GameObject[] prefabs;

	public Texture2D[] previews;

	private void Start()
	{
		prefabs = Resources.LoadAll<GameObject>("Library");
		previews = Resources.LoadAll<Texture2D>("library");
		spawnScript.inst = prefabs[0];
	}

	private void Update()
	{
		if (Input.GetKeyDown("h"))
		{
			if (hideGUI)
			{
				hideGUI = false;
			}
			else
			{
				hideGUI = true;
			}
		}
		if (Input.GetKeyDown("r"))
		{
			Reset();
		}
	}

	private void Reset()
	{
		GameObject gameObject = GameObject.Find("_Container");
		if (gameObject != null)
		{
			Object.Destroy(gameObject.gameObject);
		}
		Object.Destroy(GameObject.FindWithTag("pyramid").gameObject);
		Object.Instantiate(pyramid);
		cameraRotate.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
	}
}
