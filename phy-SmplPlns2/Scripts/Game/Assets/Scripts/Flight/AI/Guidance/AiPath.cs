using SWS;
using UnityEngine;

namespace Assets.Scripts.Flight.AI.Guidance
{
	[RequireComponent(typeof(PathManager))]
	public class AiPath : MonoBehaviour
	{
		public enum PathType
		{
			Aerobatic = 0,
			General = 1,
			Landing = 2,
			Race = 3
		}

		public PathType Type = PathType.General;

		public PathManager PathManager { get; private set; }

		protected virtual void Awake()
		{
			PathManager = GetComponent<PathManager>();
		}

		protected virtual void Start()
		{
			if (Game.Instance.CurrentMap.Name == "Default Map")
			{
				AiManagerScript.Instance.RegisterAiFlightPath(this);
			}
		}
	}
}
