using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval
{
	public class DebugGizmoPainter : MonoSingleton<DebugGizmoPainter>
	{
		private interface IDebugGizmoPaintable
		{
			float ExpireTimestamp { get; }

			string GroupId { get; set; }

			void Draw();
		}

		private class DebugSphere : IDebugGizmoPaintable
		{
			public string GroupId { get; set; }

			public Vector3 Position { get; set; }

			public float Radius { get; set; }

			public Color Color { get; set; }

			public float ExpireTimestamp { get; set; }

			public void Draw()
			{
				Color color = Gizmos.color;
				Gizmos.color = Color;
				Gizmos.DrawSphere(Position, Radius);
				Gizmos.color = color;
			}
		}

		private class DebugCube : IDebugGizmoPaintable
		{
			public string GroupId { get; set; }

			public Vector3 Center { get; set; }

			public Vector3 Size { get; set; }

			public Color Color { get; set; }

			public float ExpireTimestamp { get; set; }

			public bool WireFrame { get; set; }

			public void Draw()
			{
				Color color = Gizmos.color;
				Gizmos.color = Color;
				if (WireFrame)
				{
					Gizmos.DrawWireCube(Center, Size);
				}
				else
				{
					Gizmos.DrawCube(Center, Size);
				}
				Gizmos.color = color;
			}
		}

		private class DebugLine : IDebugGizmoPaintable
		{
			public string GroupId { get; set; }

			public Vector3 Start { get; set; }

			public Vector3 End { get; set; }

			public Color Color { get; set; }

			public float ExpireTimestamp { get; set; }

			public void Draw()
			{
				Color color = Gizmos.color;
				Gizmos.color = Color;
				Gizmos.DrawLine(Start, End);
				Gizmos.color = color;
			}
		}

		private class DebugLineTransform : IDebugGizmoPaintable
		{
			public string GroupId { get; set; }

			public Transform Start { get; set; }

			public Transform End { get; set; }

			public Vector3 Offset { get; set; }

			public Color Color { get; set; }

			public float ExpireTimestamp { get; set; }

			public void Draw()
			{
				Color color = Gizmos.color;
				Gizmos.color = Color;
				Gizmos.DrawLine(Start.position + Offset, End.position + Offset);
				Gizmos.color = color;
			}
		}

		private static float CurrentTime;

		private readonly ConcurrentDictionary<string, List<IDebugGizmoPaintable>> activeGizmoGroups = new ConcurrentDictionary<string, List<IDebugGizmoPaintable>>();

		private readonly ConcurrentBag<IDebugGizmoPaintable> gizmosToAdd = new ConcurrentBag<IDebugGizmoPaintable>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void DomainReload()
		{
			CurrentTime = 0f;
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawSphere(Vector3 position, float radius, Color color, float duration, string groupId = "")
		{
			DebugSphere item = new DebugSphere
			{
				GroupId = groupId,
				Position = position,
				Radius = radius,
				Color = color,
				ExpireTimestamp = ((duration < 0f) ? (-1f) : (CurrentTime + duration))
			};
			MonoSingleton<DebugGizmoPainter>.Instance.gizmosToAdd.Add(item);
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawCube(Vector3 center, Vector3 size, Color color, float duration, bool wireFrame = false, string groupId = "")
		{
			DebugCube item = new DebugCube
			{
				GroupId = groupId,
				Center = center,
				Size = size,
				Color = color,
				WireFrame = wireFrame,
				ExpireTimestamp = ((duration < 0f) ? (-1f) : (CurrentTime + duration))
			};
			MonoSingleton<DebugGizmoPainter>.Instance.gizmosToAdd.Add(item);
		}

		[Conditional("UNITY_EDITOR")]
		public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration, string groupId = "")
		{
			DebugLine item = new DebugLine
			{
				GroupId = groupId,
				Start = start,
				End = end,
				Color = color,
				ExpireTimestamp = ((duration < 0f) ? (-1f) : (CurrentTime + duration))
			};
			MonoSingleton<DebugGizmoPainter>.Instance.gizmosToAdd.Add(item);
		}

		[Conditional("UNITY_EDITOR")]
		public static void RemoveGroup(string groupId)
		{
			if (MonoSingleton<DebugGizmoPainter>.Instance.activeGizmoGroups.TryGetValue(groupId, out var value))
			{
				value.Clear();
			}
		}

		protected override void Awake()
		{
			Object.Destroy(base.gameObject);
		}

		private void Update()
		{
			CurrentTime = Time.time;
			IDebugGizmoPaintable result;
			while (gizmosToAdd.TryTake(out result))
			{
				activeGizmoGroups.GetOrAdd(result.GroupId, new List<IDebugGizmoPaintable>()).Add(result);
			}
		}

		private IEnumerator _ClearExpiredCoroutine()
		{
			while (true)
			{
				if (activeGizmoGroups.Count >= 9999)
				{
					Log.Error("Too many gizmos, old groups will be removed as new ones come in (max is 10k)", "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DebugGizmoPainter.cs");
				}
				while (activeGizmoGroups.Count >= 9999)
				{
					activeGizmoGroups.Remove(activeGizmoGroups.Keys.First(), out var _);
				}
				yield return new WaitForSeconds(1f);
				foreach (List<IDebugGizmoPaintable> value2 in activeGizmoGroups.Values)
				{
					int num = 0;
					while (num < value2.Count)
					{
						if (value2[num].ExpireTimestamp > 0f && CurrentTime > value2[num].ExpireTimestamp)
						{
							value2.RemoveAt(num);
						}
						else
						{
							num++;
						}
					}
				}
			}
		}

		private void OnDrawGizmos()
		{
			foreach (List<IDebugGizmoPaintable> value in activeGizmoGroups.Values)
			{
				foreach (IDebugGizmoPaintable item in value)
				{
					item.Draw();
				}
			}
		}
	}
}
