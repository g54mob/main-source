using DV.Utils;
using UnityEngine;

namespace DV.VFX
{
	public class TerrainImposterController : MonoBehaviour
	{
		private MeshRenderer terrainRenderer;

		private ReflectionProbeScheduler scheduler;

		private static readonly int sp_ViewHeight = Shader.PropertyToID("_ViewHeight");

		private static readonly int sp_TerrainProbeHeight = Shader.PropertyToID("_TerrainProbeHeight");

		private static readonly int sp_EnvProbeHeight = Shader.PropertyToID("_EnvProbeHeight");

		private static readonly int sp_WaterLevel = Shader.PropertyToID("_WaterLevel");

		private void Awake()
		{
			terrainRenderer = GetComponent<MeshRenderer>();
			if (!terrainRenderer)
			{
				Debug.LogError("TerrainImposterController doesn't have a MeshRenderer attached, can't function, destroying self");
				Object.Destroy(this);
			}
		}

		private void Start()
		{
			if ((bool)SingletonBehaviour<ReflectionProbeScheduler>.Instance)
			{
				scheduler = SingletonBehaviour<ReflectionProbeScheduler>.Instance;
			}
		}

		private void LateUpdate()
		{
			if ((bool)PlayerManager.ActiveCamera)
			{
				terrainRenderer.material.SetFloat(sp_ViewHeight, PlayerManager.ActiveCamera.transform.position.y);
				terrainRenderer.material.SetFloat(sp_WaterLevel, LevelInfo.WaterLevel);
			}
			if ((bool)scheduler)
			{
				if ((bool)scheduler.BaseProbe)
				{
					terrainRenderer.material.SetFloat(sp_TerrainProbeHeight, scheduler.BaseProbe.transform.position.y);
				}
				if ((bool)scheduler.FullEnvironmentProbe)
				{
					terrainRenderer.material.SetFloat(sp_EnvProbeHeight, scheduler.FullEnvironmentProbe.transform.position.y);
				}
			}
		}
	}
}
