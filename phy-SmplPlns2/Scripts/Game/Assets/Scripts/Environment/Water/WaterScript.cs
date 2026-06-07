using UnityEngine;
using WaveHarmonic.Crest;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.RelativeSpace;

namespace Assets.Scripts.Environment.Water
{
	public class WaterScript : MonoBehaviour
	{
		public const string CrestFloatingOriginKeyword = "CREST_FLOATING_ORIGIN";

		public static WaterScript Instance { get; private set; }

		public void OnFloatingOriginUpdated(Vector3 oldOffset, Vector3 newOffset)
		{
			Vector3 position = base.transform.position;
			position.y = GameWorld.Instance.SeaLevel.GetValueOrDefault() - newOffset.y;
			base.transform.position = position;
			if (TasharenWater.instance != null)
			{
				TasharenWater.instance.UpdateFloatingOriginOffset(newOffset);
			}
			if (ManagerBehaviour<WaterRenderer>.Instance != null)
			{
				Vector3 obj = newOffset - oldOffset;
				Shader.SetGlobalVector(ShiftingOrigin.ShaderIDs.s_ShiftingOriginOffset, -newOffset);
				ShiftingOrigin.OnShift?.Invoke(obj);
			}
		}

		protected virtual void Awake()
		{
			Instance = this;
			Shader.EnableKeyword("CREST_FLOATING_ORIGIN");
		}
	}
}
