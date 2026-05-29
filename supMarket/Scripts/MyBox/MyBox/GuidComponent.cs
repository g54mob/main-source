using System;
using UnityEngine;

namespace MyBox
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class GuidComponent : MonoBehaviour, ISerializationCallbackReceiver
	{
		private Guid _guid;

		[SerializeField]
		private byte[] serializedGuid;

		public Guid Guid => default(Guid);

		public string GuidString => null;

		public bool IsGuidAssigned()
		{
			return false;
		}

		private void CreateGuid()
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		private void Awake()
		{
		}

		private void OnValidate()
		{
		}

		public Guid GetGuid()
		{
			return default(Guid);
		}

		public void OnDestroy()
		{
		}
	}
}
