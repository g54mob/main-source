using UnityEngine;
using UnityEngine.Splines;

namespace Assets.Scripts.Environment.Roads
{
	[ExecuteInEditMode]
	public class Mesh2Spline : MonoBehaviour
	{
		[SerializeField]
		private SplineContainer _spline;

		[SerializeField]
		private int _sectionSize;

		[SerializeField]
		private Vector3 _offset;

		[ContextMenu("Sync Spline")]
		public void Sync()
		{
			Mesh sharedMesh = base.transform.GetComponent<MeshFilter>().sharedMesh;
			if (_spline.Splines.Count == 0)
			{
				_spline.AddSpline();
			}
			Spline spline = _spline.Splines[0];
			spline.Clear();
			Vector3 vector = base.transform.position + _offset + new Vector3(-8100f, 0f, 16200f);
			Vector3[] vertices = sharedMesh.vertices;
			for (int i = 0; i < vertices.Length - _sectionSize; i += _sectionSize)
			{
				Vector3 zero = Vector3.zero;
				for (int j = 0; j < _sectionSize; j++)
				{
					zero += vertices[i + j];
				}
				spline.Add(zero / _sectionSize + vector, TangentMode.Linear);
			}
		}
	}
}
