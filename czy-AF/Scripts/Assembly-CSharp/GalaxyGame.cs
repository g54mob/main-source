using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalaxyGame : MonoBehaviour
{
	public static Dictionary<string, Transform> elements = new Dictionary<string, Transform>();

	public static Transform target;

	public static int distance;

	public static List<Transform> weapons = new List<Transform>();

	private void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
		elements["camera"] = GameObject.Find("rig").transform;
		elements["ship"] = GameObject.Find("ship").transform;
		elements["target"] = GameObject.Find("target").transform;
		elements["pointer"] = GameObject.Find("pointer").transform;
		elements["crosshair"] = GameObject.Find("crosshair").transform;
		elements["distance"] = GameObject.Find("distance").transform;
		GameObject obj = Play.LoadModel("ship.model");
		obj.transform.SetParent(elements["ship"].transform);
		obj.name = "shipModel";
		foreach (Transform item in obj.transform)
		{
			if (item.name == "tracer")
			{
				Object.Instantiate(Resources.Load<GameObject>("Modules/Galaxy/Prefabs/tracer"), item);
				item.GetComponent<Renderer>().enabled = false;
			}
			if (item.name == "weapon")
			{
				weapons.Add(item);
				item.GetComponent<Renderer>().enabled = false;
			}
			item.GetComponent<Collider>().enabled = false;
		}
		foreach (Material datum in Swatches.data)
		{
			if (datum.name == "engine")
			{
				datum.EnableKeyword("_EMISSION");
				datum.SetColor("_EmissionColor", datum.GetColor("_Color") * Mathf.LinearToGammaSpace(100f));
			}
		}
		GenerateStation();
		for (int i = 0; i < 40; i++)
		{
			CreateEnemyShip();
		}
	}

	public static void Bullet(Vector3 start, Vector3 end)
	{
		GameObject obj = Object.Instantiate(Resources.Load<GameObject>("Modules/Galaxy/Prefabs/bullet"), start, Quaternion.identity);
		LineRenderer component = obj.GetComponent<LineRenderer>();
		component.SetPosition(0, start);
		component.SetPosition(1, end);
		Object.Destroy(obj, 0.05f);
	}

	private void CreateEnemyShip()
	{
		GameObject gameObject = Play.LoadModel("cargo.model");
		gameObject.name = "enemy";
		gameObject.transform.position = RandomSphere(100f, 200f);
		gameObject.AddComponent<GalaxyEnemy>().target = elements["ship"];
		Object.Instantiate(Resources.Load<GameObject>("Modules/Galaxy/Prefabs/tracerBig"), gameObject.transform);
		gameObject.AddComponent<SphereCollider>().radius = 1.5f;
	}

	private void GenerateStation()
	{
		GameObject obj = Play.LoadModel("station.model");
		obj.name = "station";
		obj.transform.position = new Vector3(Random.Range(-1000, 1000), 0f, Random.Range(-1000, 1000));
		obj.transform.localScale = new Vector3(4f, 4f, 4f);
		target = obj.transform;
	}

	public static Vector3 RandomSphere(float smallRadius, float largeRadius)
	{
		Vector3 insideUnitSphere = Random.insideUnitSphere;
		float magnitude = insideUnitSphere.magnitude;
		float num = smallRadius / largeRadius;
		return ((1f - num) * magnitude + num) / magnitude * largeRadius * insideUnitSphere;
	}

	private void Update()
	{
		elements["camera"].position = Vector3.Lerp(elements["camera"].position, elements["ship"].position, Time.deltaTime * 10f);
		elements["camera"].rotation = Quaternion.Lerp(elements["camera"].rotation, Quaternion.Euler(elements["ship"].eulerAngles.x, elements["ship"].eulerAngles.y, 0f), Time.deltaTime * 6f);
		distance = (int)Vector3.Distance(elements["ship"].position, target.position);
		elements["distance"].GetComponent<Text>().text = distance + " units";
		Vector3 normalized = (elements["ship"].position - target.position).normalized;
		float num = Vector3.SignedAngle(to: new Vector3(0f - normalized.x, 0f, 0f - normalized.z), from: Vector3.ProjectOnPlane(elements["ship"].forward, Vector3.up), axis: Vector3.up);
		elements["target"].rotation = Quaternion.Euler(0f, 0f, 0f - num);
		Color color = elements["pointer"].GetComponent<Image>().color;
		if (distance < 100)
		{
			color.a = (float)distance / 100f;
		}
		else
		{
			color.a = 1f;
		}
		elements["pointer"].GetComponent<Image>().color = color;
	}
}
