using DV.Utils;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace DV.VFX
{
	public class HazmatRadioactiveEffect : MonoBehaviour
	{
		private const float RADIATION_DISTANCE = 50f;

		private const float RADIATION_DISTANCE_SQR = 2500f;

		private PostProcessVolume pp;

		private void Awake()
		{
			pp = GetComponentInChildren<PostProcessVolume>();
		}

		public void UpdateRadiationEffect()
		{
			Camera activeCamera = PlayerManager.ActiveCamera;
			if (!activeCamera)
			{
				return;
			}
			float num = 0f;
			foreach (HazmatGridTile item in SingletonBehaviour<HazmatTileManager>.Instance.GetTilesInDiamondAreaAroundWorldPosition(activeCamera.transform.position, 100f))
			{
				float radiation = item.GetRadiation();
				if (radiation != 0f)
				{
					Vector3 position = activeCamera.transform.position;
					position.y = 0f;
					float num2 = Vector3.SqrMagnitude(SingletonBehaviour<HazmatTileManager>.Instance.GetWorldPositionFromGridTile(item, usingWorldShift: true) - position);
					num2 /= 2500f;
					radiation *= 1f - num2;
					radiation = Mathf.Clamp01(radiation / 18000f);
					num = Mathf.Max(num, radiation);
				}
			}
			pp.weight = num;
			pp.enabled = num != 0f;
		}

		public void DisableRadiationEffect()
		{
			pp.weight = 0f;
			pp.enabled = false;
		}
	}
}
