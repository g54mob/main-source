using Restory.Data.InteractiveObjects;
using UnityEngine;

namespace Restory.Gameplay.SpawnPoints
{
	public class InteractiveObjectSpawnPoint : MonoBehaviour
	{
		[SerializeField]
		public InteractiveObjectInfo InteractiveObjectInfo;

		[SerializeField]
		public Transform PreviewContainer;
	}
}
