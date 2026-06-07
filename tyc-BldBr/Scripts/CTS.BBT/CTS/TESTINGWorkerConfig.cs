using CTS.BBT;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class TESTINGWorkerConfig : MonoBehaviour
	{
		[field: SerializeField]
		[field: Range(1f, 20f)]
		[field: BoxGroup("Level")]
		public int _startLevel { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Level")]
		public WorkerPowerFeature.e_PowerFeatures[] _powers { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Priority")]
		public bool StartAutonome { get; private set; } = true;

		[field: SerializeField]
		[field: BoxGroup("Priority")]
		public ChoreCategory[] chores { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Needs")]
		public bool EnableHappyness { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Needs")]
		public bool EnableThirst { get; private set; }
	}
}
