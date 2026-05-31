using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T12WidgetConveyor : MonoBehaviour
	{
		private MeshFilter _mesh;

		private Vector2[] _uv;

		private float _moveProgress;

		private void Start()
		{
			_mesh = GetComponent<MeshFilter>();
			_mesh.mesh.vertices = new Vector3[4]
			{
				new Vector3(0f, 0f, 0f),
				new Vector3(0f, 1f, 0f),
				new Vector3(1f, 1f, 0f),
				new Vector3(1f, 0f, 0f)
			};
			_mesh.mesh.triangles = new int[6] { 0, 1, 2, 0, 2, 3 };
			_uv = new Vector2[4]
			{
				new Vector2(0f, 0f),
				new Vector2(0f, 1f),
				new Vector2(0.5f, 1f),
				new Vector2(0.5f, 0f)
			};
			_mesh.mesh.uv = _uv;
		}

		private void Update()
		{
			_moveProgress += Time.deltaTime;
			if (_moveProgress > 1f)
			{
				_moveProgress = 0f;
			}
			float num = _moveProgress / 2f;
			_uv[0].x = (_uv[1].x = 0.5f - num);
			_uv[2].x = (_uv[3].x = _uv[0].x + 0.5f);
			_mesh.mesh.uv = _uv;
		}
	}
}
