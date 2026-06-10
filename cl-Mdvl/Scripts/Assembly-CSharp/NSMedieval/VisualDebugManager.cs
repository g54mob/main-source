using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Extensions;
using TMPro;
using UnityEngine;

namespace NSMedieval
{
	public class VisualDebugManager : MonoSingleton<VisualDebugManager>
	{
		[SerializeField]
		private static bool isEnabled;

		private const string LayerName = "Ignore Raycast";

		[SerializeField]
		private GameObject text3dTemplate;

		[SerializeField]
		private GameObject debugInfoSphere;

		[SerializeField]
		private VisualDebugType enabledType;

		private readonly Dictionary<string, HashSet<GameObject>> objects = new Dictionary<string, HashSet<GameObject>>();

		private readonly Dictionary<VisualDebugType, HashSet<string>> objectsByType = new Dictionary<VisualDebugType, HashSet<string>>();

		public static bool IsEnabled => isEnabled;

		public VisualDebugType EnabledType => enabledType;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public new static void OnDomainReload()
		{
			isEnabled = false;
		}

		public void EnableType(VisualDebugType type)
		{
			enabledType |= type;
		}

		public void DisableType(VisualDebugType type)
		{
			if ((EnabledType & type) != VisualDebugType.None)
			{
				enabledType &= ~type;
				HideForType(type);
			}
		}

		public void SetEnabled(bool value)
		{
			if (isEnabled && !value)
			{
				HideAll();
			}
			isEnabled = value;
		}

		public void HideForTag(string tag)
		{
			if (!isEnabled || !objects.ContainsKey(tag))
			{
				return;
			}
			foreach (GameObject item in objects[tag])
			{
				foreach (Transform child in item.GetChildren())
				{
					Object.Destroy(child.gameObject);
				}
				Object.Destroy(item);
			}
			objects.Remove(tag);
			foreach (KeyValuePair<VisualDebugType, HashSet<string>> item2 in objectsByType)
			{
				item2.Value.Remove(tag);
			}
		}

		public void HideAll()
		{
			foreach (GameObject item in objects.SelectMany((KeyValuePair<string, HashSet<GameObject>> pair) => pair.Value))
			{
				foreach (Transform child in item.GetChildren())
				{
					Object.Destroy(child.gameObject);
				}
				Object.Destroy(item);
			}
			objects.Clear();
			objectsByType.Clear();
		}

		public GameObject DrawSphere(VisualDebugType type, string tag, Vector3 pos, float radius, Color color)
		{
			if (!isEnabled || type == VisualDebugType.None || (enabledType & type) != type)
			{
				return null;
			}
			GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			gameObject.name = "debug_sphere";
			gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
			gameObject.transform.position = pos;
			gameObject.transform.localScale = new Vector3(radius, radius, radius);
			gameObject.GetComponent<Renderer>().material.color = color;
			RegisterDebugObject(type, tag, gameObject);
			return gameObject;
		}

		public DebugInfoSphere DrawInfoSphere(VisualDebugType type, string tag, string text, Vector3 pos, float radius, Color color)
		{
			if (!isEnabled || type == VisualDebugType.None || (enabledType & type) != type)
			{
				return null;
			}
			GameObject gameObject = Object.Instantiate(debugInfoSphere, pos, Quaternion.identity);
			gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
			gameObject.transform.position = pos;
			DebugInfoSphere component = gameObject.GetComponent<DebugInfoSphere>();
			component.SetSphereScale(radius);
			component.SetColor(color);
			component.SetText(text);
			RegisterDebugObject(type, tag, gameObject);
			return component;
		}

		public GameObject DrawRect(VisualDebugType type, string tag, Vector3 startPos, Vector3 endPos, Color color)
		{
			if (!isEnabled || (type != VisualDebugType.None && (enabledType & type) == 0))
			{
				return null;
			}
			Vector3 position = new Vector3(startPos.x + endPos.x, startPos.y + endPos.y, startPos.z + endPos.z) / 2f;
			Vector3 localScale = new Vector3(Mathf.Abs(startPos.x - endPos.x), 0.65f, Mathf.Abs(startPos.z - endPos.z));
			GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
			gameObject.name = "debug_cube";
			gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
			gameObject.transform.position = position;
			gameObject.transform.localScale = localScale;
			gameObject.GetComponent<Renderer>().material.color = color;
			RegisterDebugObject(type, tag, gameObject);
			return gameObject;
		}

		public GameObject DrawRectFromCenter(VisualDebugType type, string tag, Vector3 center, Vector3 scale, Color color, Vector3 rotation = default(Vector3))
		{
			if (!isEnabled || (type != VisualDebugType.None && (enabledType & type) == 0))
			{
				return null;
			}
			GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
			gameObject.name = "debug_cube";
			gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
			gameObject.transform.position = center;
			gameObject.transform.localScale = scale;
			gameObject.GetComponent<Renderer>().material.color = color;
			RegisterDebugObject(type, tag, gameObject);
			return gameObject;
		}

		public TextMeshPro Draw3dText(VisualDebugType type, string tag, string text, Vector3 position, Color color, float scale = 1f)
		{
			if (!isEnabled || (type != VisualDebugType.None && (enabledType & type) == 0))
			{
				return null;
			}
			GameObject gameObject = Object.Instantiate(text3dTemplate, position, Quaternion.identity);
			gameObject.transform.localScale *= scale;
			TextMeshPro textMeshPro = gameObject.GetComponent<TextMeshPro>();
			if (textMeshPro == null)
			{
				textMeshPro = gameObject.GetComponentInChildren<TextMeshPro>();
			}
			textMeshPro.text = text;
			textMeshPro.color = color;
			gameObject.transform.position = position;
			RegisterDebugObject(type, tag, gameObject);
			return textMeshPro;
		}

		public GameObject DrawLine(VisualDebugType type, string tag, Vector3 start, Vector3 end, Color color, float width = 0.1f)
		{
			if (!isEnabled || (type != VisualDebugType.None && (enabledType & type) == 0))
			{
				return null;
			}
			GameObject gameObject = new GameObject("debug_line");
			gameObject.transform.position = start;
			LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
			lineRenderer.material = new Material(Shader.Find("FoxyVoxel/UI/fv_path_line"));
			lineRenderer.startColor = color;
			lineRenderer.endColor = color;
			float startWidth = (lineRenderer.endWidth = width);
			lineRenderer.startWidth = startWidth;
			lineRenderer.SetPosition(0, start);
			lineRenderer.SetPosition(1, end);
			RegisterDebugObject(type, tag, gameObject);
			return gameObject;
		}

		public void HideForType(VisualDebugType type)
		{
			if (objectsByType.ContainsKey(type))
			{
				string[] array = objectsByType[type].ToArray();
				foreach (string text in array)
				{
					HideForTag(text);
				}
			}
		}

		public void RegisterCustomDebugElement(VisualDebugType type, string tag, GameObject gameObject)
		{
			RegisterDebugObject(type, tag, gameObject);
		}

		private void RegisterDebugObject(VisualDebugType type, string tag, GameObject gameObject)
		{
			if (!objects.ContainsKey(tag))
			{
				objects.Add(tag, new HashSet<GameObject>());
			}
			objects[tag].Add(gameObject);
			if (!objectsByType.ContainsKey(type))
			{
				objectsByType.Add(type, new HashSet<string>());
			}
			objectsByType[type].Add(tag);
		}

		private void Start()
		{
			isEnabled = false;
		}
	}
}
