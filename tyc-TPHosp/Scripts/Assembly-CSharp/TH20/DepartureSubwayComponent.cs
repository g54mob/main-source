using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class DepartureSubwayComponent : MonoBehaviour
	{
		[SerializeField]
		private Transform _spawnPoint;

		private static readonly List<DepartureSubwayComponent> _subways = new List<DepartureSubwayComponent>();

		public static List<DepartureSubwayComponent> Subways => _subways;

		public static DepartureSubwayComponent RandomSubway()
		{
			if (_subways.Count != 0)
			{
				return _subways.RandomItem();
			}
			return null;
		}

		private void Awake()
		{
			_subways.Add(this);
		}

		private void OnDestroy()
		{
			_subways.Remove(this);
		}

		public Transform GetTransform()
		{
			return _spawnPoint;
		}
	}
}
