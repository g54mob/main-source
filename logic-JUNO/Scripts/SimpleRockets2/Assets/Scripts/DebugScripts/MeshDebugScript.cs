using ModApi;
using UnityEngine;

namespace Assets.Scripts.DebugScripts
{
	public class MeshDebugScript : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _boundsMax = Vector3.zero;

		[SerializeField]
		private Vector3 _boundsMin = Vector3.zero;

		[SerializeField]
		private Vector3 _boundsSize = Vector3.zero;

		[SerializeField]
		private int _countMeshes;

		[SerializeField]
		private int _countTriangles;

		[SerializeField]
		private int _countVertices;

		[ContextMenu("Calculate")]
		private void Calculate()
		{
			CalculateBounds();
			CalculateStats();
		}

		private void CalculateBounds()
		{
			MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>();
			Bounds? bounds = null;
			MeshRenderer[] array = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array)
			{
				bounds = (bounds.HasValue ? new Bounds?(Utilities.ExpandBounds(bounds.Value, meshRenderer.bounds)) : new Bounds?(meshRenderer.bounds));
			}
			_boundsSize = bounds.Value.size;
			_boundsMin = bounds.Value.min;
			_boundsMax = bounds.Value.max;
			Debug.LogFormat("Size: {0}, Min: {1}: Max: {2}", _boundsSize, _boundsMin, _boundsMax);
		}

		private void CalculateStats()
		{
			MeshFilter[] componentsInChildren = GetComponentsInChildren<MeshFilter>();
			_countVertices = 0;
			_countTriangles = 0;
			_countMeshes = 0;
			MeshFilter[] array = componentsInChildren;
			foreach (MeshFilter meshFilter in array)
			{
				_countMeshes++;
				_countVertices += meshFilter.mesh.vertices.Length;
				_countTriangles += meshFilter.mesh.triangles.Length;
			}
		}
	}
}
