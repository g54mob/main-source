using System;
using DV.Common;
using DV.ThingTypes;
using UnityEngine;

namespace DV
{
	[CreateAssetMenu(menuName = "DV/Game globals config")]
	public class Globals : ScriptableObject, IGameConfig
	{
		[Serializable]
		public class TrackType
		{
			public float age;

			public RailType railType;

			public BaseType baseType;
		}

		private const string DEFAULT_CONFIG_FILENAME = "DV_Globals";

		private static Globals _current;

		[SerializeField]
		private DVObjectModel types;

		[SerializeField]
		private GameParams gameParams;

		private GameParams gameParamsInstance;

		[SerializeField]
		private ItemsConfig items;

		[SerializeField]
		private TrackType[] railTypes;

		public static Globals G
		{
			get
			{
				if (_current == null)
				{
					Debug.Log("[Globals] fetching default config from resources");
					_current = Resources.Load<Globals>("DV_Globals");
				}
				return _current;
			}
		}

		public DVObjectModel Types => types;

		public GameParams GameParams
		{
			get
			{
				if (!(gameParamsInstance != null))
				{
					return gameParamsInstance = UnityEngine.Object.Instantiate(gameParams);
				}
				return gameParamsInstance;
			}
		}

		public ItemsConfig Items => items;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void AssignSelfToHelpers()
		{
			DVObjectModel.current = G.Types;
		}

		public void ClearGameParamsOverride()
		{
			UnityEngine.Object.Destroy(gameParamsInstance);
			gameParamsInstance = null;
		}

		public TrackType GetRailType(float age)
		{
			TrackType result = null;
			float num = float.PositiveInfinity;
			TrackType[] array = railTypes;
			foreach (TrackType trackType in array)
			{
				float num2 = Mathf.Abs(age - trackType.age);
				if (num2 < num)
				{
					num = num2;
					result = trackType;
				}
			}
			return result;
		}
	}
}
