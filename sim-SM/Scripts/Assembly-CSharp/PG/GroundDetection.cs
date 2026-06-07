using System.Collections.Generic;
using UnityEngine;

namespace PG
{
	public class GroundDetection : Singleton<GroundDetection>
	{
		[SerializeField]
		private GroundType DefaultGroundType;

		[SerializeField]
		private List<GroundConfig> Configs;

		private Dictionary<GameObject, IGroundEntity> GroundsDictionary;

		private Dictionary<GroundType, GroundConfig> ConfigsDict;

		private GroundConfig DefaultGroundConfig;

		public static GroundConfig GetDefaultGroundConfig => null;

		public static GroundConfig GetGroundConfig(GroundType type)
		{
			return null;
		}

		protected override void AwakeSingleton()
		{
		}

		public static IGroundEntity GetGroundEntity(GameObject go)
		{
			return null;
		}
	}
}
