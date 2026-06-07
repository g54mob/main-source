using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Persistence
{
	public abstract class UniqueScriptableObject : SerializedScriptableObject
	{
		[SerializeField]
		[ReadOnly]
		public string UniqueId;

		[ContextMenu("GenerateNewUniqueId")]
		public void GenerateNewUniqueId()
		{
			UniqueId = Guid.NewGuid().ToString();
		}
	}
}
