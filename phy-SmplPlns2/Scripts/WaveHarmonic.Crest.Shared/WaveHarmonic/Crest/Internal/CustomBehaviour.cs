using UnityEngine;

namespace WaveHarmonic.Crest.Internal
{
	public abstract class CustomBehaviour : MonoBehaviour, ISerializationCallbackReceiver
	{
		private bool _AfterStart;

		[SerializeField]
		[HideInInspector]
		private protected int _Version;

		private protected virtual int Version => 0;

		private protected virtual void Awake()
		{
		}

		protected void Start()
		{
			_AfterStart = true;
			OnStart();
		}

		private protected virtual void Initialize()
		{
		}

		private protected virtual void OnStart()
		{
			Initialize();
		}

		private protected virtual void OnEnable()
		{
			if (_AfterStart)
			{
				Initialize();
			}
		}

		private protected CustomBehaviour()
		{
			_Version = Version;
		}

		private protected virtual void OnMigrate()
		{
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (_Version < Version)
			{
				OnMigrate();
				_Version = Version;
			}
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}
	}
}
