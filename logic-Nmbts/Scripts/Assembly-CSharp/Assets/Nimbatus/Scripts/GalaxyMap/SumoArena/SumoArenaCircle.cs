using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.SumoArena
{
	public class SumoArenaCircle : MonoBehaviour
	{
		private SumoArenaManager _manager;

		private Renderer _renderer;

		public SphereCollider CircleCollider;

		public void Init(SumoArenaManager manager)
		{
			_manager = manager;
			_renderer = GetComponent<Renderer>();
		}

		public void SetColor(Color color)
		{
			_renderer.material.color = color;
		}

		public void SetRadius(float radius)
		{
			base.transform.localScale = new Vector3(radius * 2f, radius * 2f, 1f);
			CircleCollider.radius = radius;
		}

		public void OnTriggerExit(Collider other)
		{
			_manager.TriggerCircleCollision(other);
		}
	}
}
