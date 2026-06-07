using SettingScripts;
using UnityEngine;

namespace ManagementScripts
{
	public class ParticlesMaster : MonoBehaviour
	{
		public static ParticlesMaster Instance;

		[SerializeField]
		private ParticleSystem pheromoneSpawnerR;

		[SerializeField]
		private ParticleSystem pheromoneSpawnerG;

		[SerializeField]
		private ParticleSystem pheromoneSpawnerB;

		private static readonly BoolUserSetting ShowPheromones = UserSettings.ShowPheromones;

		private static bool showPheromones;

		private static void UpdateShowPheromones(bool val)
		{
			showPheromones = val;
		}

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
				showPheromones = ShowPheromones.SubscribeTo<BoolUserSetting, bool>(UpdateShowPheromones);
			}
			else
			{
				Object.Destroy(this);
			}
		}

		public void EmitPheromonesAtPosition(Vector3 pos, float r = 0f, float g = 0f, float b = 0f)
		{
			if (showPheromones)
			{
				base.transform.position = pos;
				if (r >= 1f)
				{
					pheromoneSpawnerR.Emit((int)r);
				}
				if (g >= 1f)
				{
					pheromoneSpawnerG.Emit((int)g);
				}
				if (b >= 1f)
				{
					pheromoneSpawnerB.Emit((int)b);
				}
			}
		}

		public void CallToPosition(Vector3 pos)
		{
			base.transform.position = pos;
		}

		public void EmitRedPheromones(float amount)
		{
			if (showPheromones)
			{
				pheromoneSpawnerR.Emit((int)amount);
			}
		}

		public void EmitGreenPheromones(float amount)
		{
			if (showPheromones)
			{
				pheromoneSpawnerG.Emit((int)amount);
			}
		}

		public void EmitBluePheromones(float amount)
		{
			if (showPheromones)
			{
				pheromoneSpawnerB.Emit((int)amount);
			}
		}

		private void OnDestroy()
		{
			ShowPheromones.UnSubscribeTo<BoolUserSetting, bool>(UpdateShowPheromones);
		}
	}
}
