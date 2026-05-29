using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T9HeliumSpawner : MonoBehaviour
	{
		[SerializeField]
		private T9HeliumParticle _particlePrefab;

		[SerializeField]
		private float _spawnDelay;

		[SerializeField]
		private ActiveWorldFrame _parent;

		private float _spawnTimer;

		private void Start()
		{
			_spawnTimer = _spawnDelay;
			_parent = GetComponentInParent<ActiveWorldFrame>();
		}

		private void Update()
		{
			_spawnTimer -= Time.deltaTime;
			if (_spawnTimer < 0f)
			{
				T9HeliumParticle t9HeliumParticle = Object.Instantiate(_particlePrefab, _parent.transform);
				t9HeliumParticle.transform.position = base.transform.position;
				Vector2 vector = new Vector2(SeededRandom.Global.RandomRange(-1f, 1f), SeededRandom.Global.RandomRange(0f, 1f));
				Rigidbody2D component = t9HeliumParticle.GetComponent<Rigidbody2D>();
				component.AddForce(vector * 4f, ForceMode2D.Impulse);
				component.angularVelocity = SeededRandom.Global.RandomRange(-90f, 90f);
				_spawnTimer = _spawnDelay;
			}
		}
	}
}
