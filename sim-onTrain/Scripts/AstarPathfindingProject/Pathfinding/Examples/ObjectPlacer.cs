using System.Collections;
using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("https://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_object_placer.php")]
	public class ObjectPlacer : MonoBehaviour
	{
		public GameObject go;

		public bool direct;

		public bool issueGUOs = true;

		private float lastPlacedTime;

		private void Update()
		{
			if (!Input.GetKey(KeyCode.LeftControl) && (Input.GetKeyDown("p") || (Input.GetKey("p") && Time.time - lastPlacedTime > 0.3f)))
			{
				PlaceObject();
			}
			if (Input.GetKeyDown("r"))
			{
				StartCoroutine(RemoveObject());
			}
		}

		public void PlaceObject()
		{
			lastPlacedTime = Time.time;
			if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, float.PositiveInfinity))
			{
				return;
			}
			Vector3 point = hitInfo.point;
			GameObject gameObject = Object.Instantiate(go, point, Quaternion.identity);
			if (issueGUOs)
			{
				GraphUpdateObject ob = new GraphUpdateObject(gameObject.GetComponent<Collider>().bounds);
				AstarPath.active.UpdateGraphs(ob);
				if (direct)
				{
					AstarPath.active.FlushGraphUpdates();
				}
			}
		}

		public IEnumerator RemoveObject()
		{
			if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, float.PositiveInfinity) || hitInfo.collider.isTrigger || hitInfo.transform.gameObject.name == "Ground")
			{
				yield break;
			}
			Bounds b = hitInfo.collider.bounds;
			Object.Destroy(hitInfo.collider);
			Object.Destroy(hitInfo.collider.gameObject);
			if (issueGUOs)
			{
				yield return new WaitForEndOfFrame();
				GraphUpdateObject ob = new GraphUpdateObject(b);
				AstarPath.active.UpdateGraphs(ob);
				if (direct)
				{
					AstarPath.active.FlushGraphUpdates();
				}
			}
		}
	}
}
