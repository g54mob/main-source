using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ArrivalBaseComponent : MonoBehaviour
	{
		[SerializeField]
		private Transform _spawnPoint;

		public Transform GetTransform()
		{
			return _spawnPoint;
		}

		public string GetScenePath()
		{
			return GameObjectUtils.ObjectFullScenePath(base.transform);
		}

		public int GetID()
		{
			return GetScenePath().GetHashCode();
		}
	}
}
