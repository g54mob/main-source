using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects
{
	public class DestructibleChunk : MonoBehaviour
	{
		public bool InspectorDestruct;

		private AudioSource _audio;

		private FracturedChunk _chunk;

		private float _currentDamage;

		[SerializeField]
		private float _damageThreshold;

		[SerializeField]
		private DestructibleChunk[] _detachChunks;

		private float _playDelay;

		private bool _playedSound;

		public bool IsDetached => _chunk.IsDetachedChunk;

		public Rigidbody RigidBody { get; private set; }

		public void AddDamage(float damage)
		{
			_currentDamage += damage;
			if (_currentDamage >= _damageThreshold && _chunk != null)
			{
				DetachChunk();
			}
		}

		protected virtual void Start()
		{
			_chunk = GetComponent<FracturedChunk>();
			_audio = GetComponent<AudioSource>();
			RigidBody = GetComponent<Rigidbody>();
			if (RigidBody != null)
			{
				RigidBody.maxDepenetrationVelocity = 0.1f;
			}
			_playDelay = Random.Range(0f, 2f);
		}

		protected virtual void Update()
		{
			if (InspectorDestruct)
			{
				DetachChunk();
			}
			if (_chunk.IsDetachedChunk && !_playedSound && _audio != null)
			{
				if (_playDelay < 0f)
				{
					_playedSound = true;
					_audio.enabled = true;
				}
				else
				{
					_playDelay -= Time.deltaTime;
				}
			}
		}

		private void DetachChunk()
		{
			if (_chunk.IsDetachedChunk)
			{
				return;
			}
			_chunk.DetachFromObject();
			if (_detachChunks != null)
			{
				DestructibleChunk[] detachChunks = _detachChunks;
				for (int i = 0; i < detachChunks.Length; i++)
				{
					detachChunks[i].DetachChunk();
				}
			}
		}
	}
}
