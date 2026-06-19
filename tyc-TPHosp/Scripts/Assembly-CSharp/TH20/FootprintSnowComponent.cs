using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class FootprintSnowComponent : EntityTickComponent
	{
		[SerializeField]
		private float _spawnTime = 0.5f;

		[SerializeField]
		private float _footSpacing = 0.05f;

		[SerializeField]
		private ParticleSystem _particleSystem;

		private Character _character;

		private float _nextSpawn;

		private bool _foot;

		protected override Type ValidEntityType()
		{
			return typeof(Character);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_character = GetOwner<Character>();
		}

		public override void Tick()
		{
			base.Tick();
			_nextSpawn += _character.MovementSpeed * GameTime.deltaTime;
			if (_nextSpawn >= _spawnTime)
			{
				_nextSpawn -= _spawnTime;
				if (_character.RoomUsing == null)
				{
					SpawnFootprint();
				}
			}
		}

		private void SpawnFootprint()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(_particleSystem.gameObject);
			gameObject.transform.rotation = _character.Rotation;
			gameObject.transform.position = _character.Position + _character.Rotation * new Vector3(_foot ? (0f - _footSpacing) : _footSpacing, 0f, 0f);
			gameObject.GetComponent<ParticleSystem>().Play();
			_foot = !_foot;
		}
	}
}
