using System;
using JetBrains.Annotations;
using UnityEngine;

namespace MyBox
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[PublicAPI]
	public class GuidComponent : MonoBehaviour, ISerializationCallbackReceiver
	{
		[SerializeField]
		private byte[] serializedGuid;

		private Guid _guid = Guid.Empty;

		public Guid Guid
		{
			get
			{
				if (_guid == Guid.Empty && serializedGuid != null && serializedGuid.Length == 16)
				{
					_guid = new Guid(serializedGuid);
				}
				return _guid;
			}
		}

		public string GuidString => Guid.ToString();

		public bool IsGuidAssigned()
		{
			return _guid != Guid.Empty;
		}

		private void CreateGuid()
		{
			if (serializedGuid == null || serializedGuid.Length != 16)
			{
				_guid = Guid.NewGuid();
				serializedGuid = _guid.ToByteArray();
			}
			else if (_guid == Guid.Empty)
			{
				_guid = new Guid(serializedGuid);
			}
			if (_guid != Guid.Empty && !GuidManager.Add(this))
			{
				serializedGuid = null;
				_guid = Guid.Empty;
				CreateGuid();
			}
		}

		public void OnBeforeSerialize()
		{
			if (_guid != Guid.Empty)
			{
				serializedGuid = _guid.ToByteArray();
			}
		}

		public void OnAfterDeserialize()
		{
			if (serializedGuid != null && serializedGuid.Length == 16)
			{
				_guid = new Guid(serializedGuid);
			}
		}

		private void Awake()
		{
			CreateGuid();
		}

		private void OnValidate()
		{
			CreateGuid();
		}

		public Guid GetGuid()
		{
			if (_guid == Guid.Empty && serializedGuid != null && serializedGuid.Length == 16)
			{
				_guid = new Guid(serializedGuid);
			}
			return _guid;
		}

		public void OnDestroy()
		{
			GuidManager.Remove(_guid);
		}
	}
}
