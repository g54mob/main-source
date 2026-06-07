using UnityEngine;

namespace WaveHarmonic.Crest.Internal
{
	public abstract class CustomScriptableObject : ScriptableObject, ISerializationCallbackReceiver
	{
		[SerializeField]
		[HideInInspector]
		private protected int _Version;

		private protected virtual int Version => 0;

		private protected CustomScriptableObject()
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
