using UnityEngine;
using UnityEngine.Rendering;

namespace SnapshotShaders.URP
{
	public class WorldScanExample : MonoBehaviour
	{
		[SerializeField]
		private float scanSpeed;

		[SerializeField]
		private float scanDuration;

		[SerializeField]
		private Volume worldScanVolume;

		private WorldScanSettings worldScanSettings;

		private void Start()
		{
			if (!(worldScanVolume == null) && !(worldScanVolume.profile == null))
			{
				worldScanVolume.profile.TryGet<WorldScanSettings>(out worldScanSettings);
			}
		}

		private void Update()
		{
			if (worldScanSettings != null)
			{
				float value = Time.time % scanDuration * scanSpeed;
				worldScanSettings.scanDistance.value = value;
			}
		}
	}
}
