using System.Collections.Generic;
using ModApi.Common.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vectrosity;

namespace Assets.Scripts.DebugScripts
{
	public static class DebugGizmos
	{
		private class Gizmo
		{
			public object GizmoObject { get; set; }

			public float LastAccessTime { get; set; }

			public Gizmo(object gizmoObject)
			{
				GizmoObject = gizmoObject;
				UpdateLastUsedTime();
			}

			public void UpdateLastUsedTime()
			{
				LastAccessTime = (DestroyWhilePaused ? Time.unscaledTime : Time.time);
			}
		}

		private static Dictionary<string, Gizmo> _balls;

		private static Dictionary<string, Gizmo> _capsules;

		private static Dictionary<string, Gizmo> _lines;

		private static Dictionary<string, Gizmo> _texts;

		public static bool DestroyWhilePaused { get; set; }

		public static float StaleTimeOut { get; set; }

		static DebugGizmos()
		{
			_balls = new Dictionary<string, Gizmo>();
			_capsules = new Dictionary<string, Gizmo>();
			_lines = new Dictionary<string, Gizmo>();
			_texts = new Dictionary<string, Gizmo>();
			DestroyWhilePaused = false;
			StaleTimeOut = 0.1f;
			SceneManager.sceneUnloaded += OnSceneUnloaded;
			SceneManager.sceneLoaded += OnsceneLoaded;
			Init();
		}

		public static void Destroy(string name)
		{
			Object.Destroy(GetBall(name, 0, Color.white, emissive: false, create: false)?.gameObject);
			Object.Destroy(GetLine(name, create: false)?.rectTransform.gameObject);
			Object.Destroy(GetText(name)?.gameObject);
			Object.Destroy(GetCapsule(name)?.gameObject);
			_balls.Remove(name);
			_lines.Remove(name);
			_texts.Remove(name);
			_capsules.Remove(name);
		}

		public static void DestroyAll()
		{
			DestroyAll(_balls);
			DestroyAll(_lines);
			DestroyAll(_capsules);
			DestroyAll(_texts);
		}

		public static void DestroyStale()
		{
			DestroyStale(StaleTimeOut, _balls);
			DestroyStale(StaleTimeOut, _capsules);
			DestroyStale(StaleTimeOut, _lines);
			DestroyStale(StaleTimeOut, _texts);
		}

		public static Transform DrawBall(string name, Vector3 position, float radius, Color color, bool emissive, int layer = 0)
		{
			Transform result = null;
			if (string.IsNullOrEmpty(name))
			{
				Debug.Log("Name must be supplied DebugGizmos.DrawXyz");
			}
			else
			{
				Transform ball = GetBall(name, layer, color, emissive, create: true);
				if (!Vector3d.IsNaN(position))
				{
					ball.position = position;
					ball.localScale = Vector3.one * radius * 2f;
					Material material = ball.GetComponent<MeshRenderer>().material;
					material.color = color;
					if (emissive)
					{
						material.SetColor("_EmissionColor", color);
					}
				}
				else
				{
					Debug.LogError("Attempt to assign NAN position to Debug Ball");
				}
				result = ball;
			}
			return result;
		}

		public static Transform DrawCapsule(string name, Vector3 position, Vector3 up, float radius, float height, Color color, bool emissive, int layer = 0)
		{
			Transform result = null;
			if (string.IsNullOrEmpty(name))
			{
				Debug.Log("Name must be supplied DebugGizmos.DrawXyz");
			}
			else
			{
				Transform capsule = GetCapsule(name, layer, color, emissive, create: true);
				if (!Vector3d.IsNaN(position))
				{
					capsule.position = position;
					capsule.localScale = new Vector3(radius * 2f, height / 2f, radius * 2f);
					capsule.GetComponent<MeshRenderer>().material.color = color;
				}
				else
				{
					Debug.LogError("Attempt to assign NAN position to Debug Capsule");
				}
				if (!Vector3d.IsNaN(up))
				{
					capsule.up = up;
				}
				else
				{
					Debug.LogError("Attempt to assign NAN up vector to Debug Capsule");
				}
				result = capsule;
			}
			return result;
		}

		public static VectorLine DrawLine(string name, Vector3 p1, Vector3 p2, Color color, int layer = 0)
		{
			if (string.IsNullOrEmpty(name))
			{
				Debug.Log("Name must be supplied DebugGizmos.DrawXyz");
				return null;
			}
			VectorLine line = GetLine(name, create: true, layer);
			line.color = color;
			line.points3[0] = p1;
			line.points3[1] = p2;
			line.Draw3DAuto();
			return line;
		}

		public static VectorLine DrawRay(string name, Ray ray, float length, Color color, int layer = 0)
		{
			return DrawRay(name, ray.origin, ray.direction, length, color, layer);
		}

		public static VectorLine DrawRay(string name, Vector3 origin, Vector3 direction, float length, Color color, int layer = 0)
		{
			return DrawLine(name, origin, origin + direction.normalized * length, color, layer);
		}

		public static VectorLine DrawRay(string name, Vector3 origin, Vector3 vector, Color color, int layer = 0)
		{
			return DrawLine(name, origin, origin + vector, color, layer);
		}

		public static Transform DrawText(string name, Vector3 position, string text, Camera camera, Color color, bool emissive, int layer = 0)
		{
			Transform result = null;
			if (string.IsNullOrEmpty(name))
			{
				Debug.Log("Name must be supplied DebugGizmos.DrawXyz");
			}
			else
			{
				Transform text2 = GetText(name, camera, layer, color, emissive, create: true);
				if (!Vector3d.IsNaN(position))
				{
					Text component = text2.GetComponent<Text>();
					component.color = color;
					component.text = text;
					text2.position = component.canvas.worldCamera.WorldToScreenPoint(position);
				}
				else
				{
					Debug.LogError("Attempt to assign NAN position to Debug Text");
				}
				result = text2;
			}
			return result;
		}

		public static void DrawTransformOrientation(string name, Transform transform, float length)
		{
			if (string.IsNullOrEmpty(name))
			{
				Debug.Log("Name must be supplied DebugGizmos.DrawXyz");
				return;
			}
			DrawRay($"{name}_up", transform.position, transform.up, length, Color.green);
			DrawRay($"{name}_forward", transform.position, transform.forward, length, Color.blue);
			DrawRay($"{name}_right", transform.position, transform.right, length, Color.red);
		}

		public static Transform GetBall(string name, int layer, Color color, bool emissive, bool create)
		{
			if (create && !_balls.ContainsKey(name))
			{
				GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				gameObject.name = name;
				gameObject.layer = layer;
				gameObject.GetComponent<Collider>().enabled = false;
				if (color.a != 1f || emissive)
				{
					Material material = new Material(Shader.Find("Standard"));
					if (color.a != 1f)
					{
						material.SetFloat("_Mode", 2f);
						material.SetInt("_SrcBlend", 5);
						material.SetInt("_DstBlend", 10);
						material.SetInt("_ZWrite", 0);
						material.DisableKeyword("_ALPHATEST_ON");
						material.EnableKeyword("_ALPHABLEND_ON");
						material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
						material.renderQueue = 3000;
					}
					if (emissive)
					{
						material.SetColor("_EmissionColor", color);
						material.EnableKeyword("_EMISSION");
					}
					gameObject.GetComponent<MeshRenderer>().material = material;
				}
				_balls.Add(name, new Gizmo(gameObject.transform));
			}
			Transform result = null;
			Gizmo gizmo = (_balls.ContainsKey(name) ? _balls[name] : null);
			if (gizmo != null)
			{
				gizmo.UpdateLastUsedTime();
				result = gizmo.GizmoObject as Transform;
			}
			return result;
		}

		public static Transform GetCapsule(string name)
		{
			return GetCapsule(name, 0, Color.white, emissive: false, create: false);
		}

		public static Transform GetCapsule(string name, int layer, Color color, bool emissive, bool create)
		{
			if (create && !_capsules.ContainsKey(name))
			{
				GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
				gameObject.name = name;
				gameObject.layer = layer;
				gameObject.GetComponent<Collider>().enabled = false;
				if (color.a != 1f || emissive)
				{
					Material material = new Material(Shader.Find("Standard"));
					if (color.a != 1f)
					{
						material.SetFloat("_Mode", 2f);
						material.SetInt("_SrcBlend", 5);
						material.SetInt("_DstBlend", 10);
						material.SetInt("_ZWrite", 0);
						material.DisableKeyword("_ALPHATEST_ON");
						material.EnableKeyword("_ALPHABLEND_ON");
						material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
						material.renderQueue = 3000;
					}
					if (emissive)
					{
						material.SetColor("_EmissionColor", color);
					}
					gameObject.GetComponent<MeshRenderer>().material = material;
				}
				_capsules.Add(name, new Gizmo(gameObject.transform));
			}
			Transform result = null;
			Gizmo gizmo = (_capsules.ContainsKey(name) ? _capsules[name] : null);
			if (gizmo != null)
			{
				gizmo.UpdateLastUsedTime();
				result = gizmo.GizmoObject as Transform;
			}
			return result;
		}

		public static VectorLine GetLine(string name, bool create, int layer = 0)
		{
			if (create && !_lines.ContainsKey(name))
			{
				VectorLine vectorLine = new VectorLine(name, new List<Vector3>(2)
				{
					Vector3.zero,
					Vector3.zero
				}, 2f);
				vectorLine.rectTransform.gameObject.layer = layer;
				_lines.Add(name, new Gizmo(vectorLine));
			}
			Gizmo gizmo = (_lines.ContainsKey(name) ? _lines[name] : null);
			VectorLine result = null;
			if (gizmo != null)
			{
				gizmo.UpdateLastUsedTime();
				result = gizmo.GizmoObject as VectorLine;
			}
			return result;
		}

		public static void SetCamera(Camera camera)
		{
			VectorLine.SetCamera3D(camera);
		}

		private static void DestroyAll(Dictionary<string, Gizmo> gizmosToDestroy)
		{
			foreach (KeyValuePair<string, Gizmo> item in gizmosToDestroy)
			{
				DestroyGizmo(item.Value);
			}
			gizmosToDestroy.Clear();
		}

		private static void DestroyGizmo(Gizmo gizmo)
		{
			object gizmoObject = gizmo.GizmoObject;
			Transform transform = ((!(gizmoObject is VectorLine)) ? (gizmoObject as Transform) : (gizmoObject as VectorLine).rectTransform);
			if (transform != null)
			{
				Object.Destroy(transform.gameObject);
			}
		}

		private static void DestroyStale(float staleTimeSeconds, Dictionary<string, Gizmo> gizmosToCheck)
		{
			float num = (DestroyWhilePaused ? Time.unscaledTime : Time.time);
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, Gizmo> item in gizmosToCheck)
			{
				if (item.Value.LastAccessTime + staleTimeSeconds < num)
				{
					DestroyGizmo(item.Value);
					list.Add(item.Key);
				}
			}
			foreach (string item2 in list)
			{
				gizmosToCheck.Remove(item2);
			}
		}

		private static Transform GetText(string name)
		{
			return GetText(name, null, 0, Color.white, emissive: false, create: false);
		}

		private static Transform GetText(string name, Camera camera, int layer, Color color, bool emissive, bool create)
		{
			if (create && !_texts.ContainsKey(name))
			{
				Canvas canvas = new GameObject(name).AddComponent<Canvas>();
				canvas.renderMode = RenderMode.ScreenSpaceOverlay;
				canvas.worldCamera = ((camera != null) ? camera : Camera.main);
				Text text = new GameObject("Text").AddComponent<Text>();
				text.transform.SetParent(canvas.transform);
				text.enabled = true;
				text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
				text.alignment = TextAnchor.UpperLeft;
				text.rectTransform.anchorMin = Vector2.zero;
				text.rectTransform.anchorMax = Vector2.zero;
				text.rectTransform.pivot = new Vector2(0f, 0.95f);
				text.FontTextureChanged();
				text.gameObject.layer = canvas.gameObject.layer;
				_texts.Add(name, new Gizmo(text.transform));
			}
			Transform result = null;
			Gizmo gizmo = (_texts.ContainsKey(name) ? _texts[name] : null);
			if (gizmo != null)
			{
				gizmo.UpdateLastUsedTime();
				result = gizmo.GizmoObject as Transform;
			}
			return result;
		}

		private static void Init()
		{
			SetCamera(Camera.main);
			UnityEventDispatcher.Instance.Register(delegate
			{
				DestroyStale();
			}, UnityEventDispatcher.EventType.LateUpdate);
		}

		private static void OnsceneLoaded(Scene scene, LoadSceneMode mode)
		{
			Init();
		}

		private static void OnSceneUnloaded(Scene scene)
		{
			DestroyAll();
		}
	}
}
