using System.Collections;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public class ForceDirectedGraph
	{
		public static IEnumerator ForceDirectGraph<T>(Graph<T> graph, Dictionary<T, Vector3> graphPositions)
		{
			Dictionary<Vertex<T>, Vector2> velocity = new Dictionary<Vertex<T>, Vector2>();
			Dictionary<Vertex<T>, Vector2> position = new Dictionary<Vertex<T>, Vector2>();
			foreach (Vertex<T> vertex in graph.Vertices)
			{
				velocity.Add(vertex, Vector2.zero);
				Vector3 vector = Random.onUnitSphere * 0.1f * 0.5f;
				if (graphPositions.ContainsKey(vertex.Data))
				{
					vector += graphPositions[vertex.Data];
				}
				else
				{
					vector += graphPositions[vertex.IncidentEdges[0].GetPartnerVertex(vertex).Data];
				}
				position.Add(vertex, new Vector2(vector.x, vector.z));
			}
			float totalEnergy = 10f;
			while (totalEnergy > 1f)
			{
				totalEnergy = 0f;
				foreach (Vertex<T> vertex2 in graph.Vertices)
				{
					Vector2 zero = Vector2.zero;
					foreach (Vertex<T> vertex3 in graph.Vertices)
					{
						if (vertex3 != vertex2)
						{
							Vector2 vector2 = position[vertex2] - position[vertex3];
							zero += vector2.normalized * 10f / (Mathf.Pow(vector2.magnitude + 0.1f, 2f) * 0.5f);
						}
					}
					foreach (Edge<T> emanatingEdge in vertex2.EmanatingEdges)
					{
						Vector2 vector3 = position[emanatingEdge.ToVertex] - position[vertex2];
						float num = 0.1f - vector3.magnitude;
						zero += vector3.normalized * (100f * num * -0.5f);
					}
					zero += -position[vertex2].normalized * 15f;
					velocity[vertex2] = (velocity[vertex2] + zero * Time.deltaTime) * 0.9f;
					position[vertex2] += velocity[vertex2] * Time.deltaTime;
					graphPositions[vertex2.Data] = new Vector3(position[vertex2].x, 0f, position[vertex2].y);
					totalEnergy += velocity[vertex2].sqrMagnitude;
				}
				yield return 0;
			}
		}
	}
}
