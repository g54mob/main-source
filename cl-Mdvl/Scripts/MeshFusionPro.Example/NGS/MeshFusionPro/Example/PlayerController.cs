using UnityEngine;

namespace NGS.MeshFusionPro.Example
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField]
		private Camera _camera;

		private bool _hitterEnabled = true;

		public void Update()
		{
			if (Input.GetMouseButtonDown(0) && _hitterEnabled)
			{
				Hit();
			}
		}

		private void ToggleHitter()
		{
			_hitterEnabled = !_hitterEnabled;
		}

		private void Hit()
		{
			Ray ray = _camera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
			if (Physics.Raycast(ray, out var hitInfo))
			{
				hitInfo.collider.GetComponent<IHittable>()?.Hitted(ray, hitInfo);
			}
		}
	}
}
