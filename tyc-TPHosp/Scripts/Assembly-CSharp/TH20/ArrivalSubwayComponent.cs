using System.Collections.Generic;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ArrivalSubwayComponent : ArrivalBaseComponent
	{
		private static readonly List<ArrivalSubwayComponent> _spawnPoints = new List<ArrivalSubwayComponent>();

		public static ArrivalSubwayComponent RandomPoint()
		{
			if (_spawnPoints.Count != 0)
			{
				return _spawnPoints.RandomItem();
			}
			return null;
		}

		private void Awake()
		{
			_spawnPoints.Add(this);
		}

		private void OnDestroy()
		{
			_spawnPoints.Remove(this);
		}
	}
}
