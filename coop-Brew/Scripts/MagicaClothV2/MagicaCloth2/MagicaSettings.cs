using UnityEngine;

namespace MagicaCloth2
{
	[AddComponentMenu("MagicaCloth2/MagicaSettings")]
	[HelpURL("https://magicasoft.jp/en/mc2_settings_component/")]
	public class MagicaSettings : ClothBehaviour
	{
		public enum RefreshMode
		{
			OnAwake = 0,
			EveryFrame = 1,
			OnStart = 2,
			Manual = 3
		}

		public RefreshMode refreshMode;

		[Range(30f, 150f)]
		public int simulationFrequency;

		[Range(1f, 5f)]
		public int maxSimulationCountPerFrame;

		public MagicaManager.InitializationLocation initializationLocation;

		public TimeManager.UpdateLocation updateLocation;

		public bool monitorPlayerLoop;

		[Min(0f)]
		public int splitProxyMeshVertexCount;

		protected void Awake()
		{
		}

		protected void Start()
		{
		}

		protected void Update()
		{
		}

		protected void OnValidate()
		{
		}

		public void Refresh()
		{
		}
	}
}
