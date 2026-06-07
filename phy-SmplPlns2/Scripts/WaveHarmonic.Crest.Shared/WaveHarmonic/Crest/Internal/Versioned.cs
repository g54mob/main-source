using System;
using UnityEngine;

namespace WaveHarmonic.Crest.Internal
{
	[Serializable]
	public abstract class Versioned : ISerializationCallbackReceiver
	{
		[SerializeField]
		[HideInInspector]
		private protected int _Version;

		private protected virtual int Version => 0;

		private protected Versioned()
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
