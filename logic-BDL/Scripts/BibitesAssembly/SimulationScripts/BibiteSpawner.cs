using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UnityEngine;
using Utility;

namespace SimulationScripts
{
	public class BibiteSpawner : MonoBehaviour
	{
		private GameObject spawned;

		private BibiteGenes eggGene;

		private NEATBrain spawnedBrain;

		private static readonly BoolSetting BibiteLimit = ScenarioIndependentSettings.Instance.limitBibiteBirth;

		private static readonly IntSetting LimitNumber = ScenarioIndependentSettings.Instance.bibiteLimit;

		private static readonly FloatSetting SpawnRate = ScenarioIndependentSettings.Instance.virginSpawnRate;

		private static bool bibiteLimit = BibiteLimit.SubscribeTo<BoolSetting, bool>(UpdateBibiteLimit);

		private static int limitNumber = LimitNumber.SubscribeTo<IntSetting, int>(UpdateLimitNumber);

		private static float spawnRate = SpawnRate.SubscribeTo<FloatSetting, float>(UpdateSpawnRate);

		private List<BibiteSpawnInfo> bibiteSpawnInfos = new List<BibiteSpawnInfo>();

		private int nEntity => WorldObjectsSpawner.Instance.nBibite;

		private static void UpdateBibiteLimit(bool val)
		{
			bibiteLimit = val;
		}

		private static void UpdateLimitNumber(int val)
		{
			limitNumber = val;
		}

		private static void UpdateSpawnRate(float val)
		{
			spawnRate = val;
		}

		public void StartSpawner()
		{
			ResumeSpawner();
			bibiteSpawnInfos.ForEach(delegate(BibiteSpawnInfo i)
			{
				i.template.AlignInnovationsWithSim();
			});
		}

		public void ResumeSpawner()
		{
			bibiteSpawnInfos.Clear();
			ScenarioSettings.Instance.bibites.ForEach(delegate(BibiteSettings b)
			{
				if (BibiteTemplate.Exists(b.filePath, b.isExternal))
				{
					bibiteSpawnInfos.Add(new BibiteSpawnInfo(b));
				}
				else
				{
					PopupManager.DisplayError("Load System", "The bibite template " + b.filePath + " was not found in your template folder.");
				}
			});
			DistributeSpawnPriority();
			ScenarioSettings.onBibiteAdded.AddListener(SettingsAdded);
			ScenarioSettings.onBibiteRemoved.AddListener(SettingsRemoved);
			ScenarioSettings.bibiteSpawnPriorityChanged.AddListener(DistributeSpawnPriority);
			ScenarioSettings.onBibiteSpawningChanged.AddListener(SettingsSpawnChanged);
			StartCoroutine("SpawnEntity", 1f);
		}

		private void SettingsSpawnChanged(BibiteSettings changed)
		{
			BibiteSpawnInfo bibiteSpawnInfo = bibiteSpawnInfos.FirstOrDefault((BibiteSpawnInfo i) => i.settings == changed);
			if (bibiteSpawnInfo != null)
			{
				bibiteSpawnInfo.UpdateDescendantCount();
				if (bibiteSpawnInfo.settings.spawnType.val == SpawnType.OneTime)
				{
					bibiteSpawnInfo.oneTimeSpawned = bibiteSpawnInfo.minimumMet;
					bibiteSpawnInfo.spawnProgress = (float)bibiteSpawnInfo.missingToMinimumBibites + 0.1f;
				}
				else
				{
					bibiteSpawnInfo.oneTimeSpawned = false;
				}
				DistributeSpawnPriority();
			}
		}

		private void SettingsAdded(BibiteSettings added)
		{
			BibiteSpawnInfo bibiteSpawnInfo = new BibiteSpawnInfo(added);
			bibiteSpawnInfo.template.AlignInnovationsWithSim();
			bibiteSpawnInfos.Add(bibiteSpawnInfo);
			DistributeSpawnPriority();
		}

		private void SettingsRemoved(BibiteSettings removed)
		{
			if (removed == null)
			{
				bibiteSpawnInfos.Clear();
				return;
			}
			BibiteSpawnInfo item = bibiteSpawnInfos.FirstOrDefault((BibiteSpawnInfo i) => i.settings == removed);
			bibiteSpawnInfos.Remove(item);
			DistributeSpawnPriority();
		}

		private void DistributeSpawnPriority()
		{
			float spawnTotal = bibiteSpawnInfos.Where((BibiteSpawnInfo i) => !i.oneTimeSpawn).Sum((BibiteSpawnInfo i) => i.settings.spawnPriority.val);
			bibiteSpawnInfos.ForEach(delegate(BibiteSpawnInfo i)
			{
				i.spawnShare = i.settings.spawnPriority.val / spawnTotal;
			});
		}

		private IEnumerator SpawnEntity(float delay)
		{
			WaitForSeconds wait = new WaitForSeconds(delay);
			yield return null;
			while (true)
			{
				if (bibiteSpawnInfos.Count <= 0)
				{
					yield return wait;
					continue;
				}
				int num = Mathf.Min(bibiteLimit ? limitNumber : 2147483647);
				int nToLimit = num - nEntity;
				bibiteSpawnInfos.ForEach(delegate(BibiteSpawnInfo i)
				{
					i.UpdateDescendantCount();
				});
				if (bibiteSpawnInfos.All((BibiteSpawnInfo i) => i.minimumMet) || nToLimit < 1)
				{
					yield return wait;
					continue;
				}
				bibiteSpawnInfos.ForEach(delegate(BibiteSpawnInfo info)
				{
					if (!info.minimumMet && !info.oneTimeSpawned)
					{
						if (!info.oneTimeSpawn)
						{
							info.spawnProgress += spawnRate * info.spawnShare * delay;
						}
						int num2 = Mathf.Min(info.missingToMinimumBibites, nToLimit);
						while (info.spawnProgress >= 1f && !info.minimumMet && num2 > 0)
						{
							info.spawnProgress -= 1f;
							Vector2 vector = ((info.zone == null) ? ZoneManager.instance.GetRandomPositionInZone() : info.zone.GetSpawnLocation());
							WorldObjectsSpawner instance = WorldObjectsSpawner.Instance;
							BibiteTemplate template = info.template;
							RandomizeGenes val = info.settings.randomizeGenes.val;
							Tagging val2 = info.settings.tagging.val;
							GrowthAtSpawn val3 = info.settings.growthAtSpawn.val;
							Vector3? pos = vector;
							string val4 = info.settings.customTag.val;
							instance.SpawnBibiteFromTemplate(template, val, val2, val3, pos, null, val4);
							num2--;
							nToLimit--;
						}
						if (info.oneTimeSpawn && info.spawnProgress < 1f)
						{
							info.oneTimeSpawned = true;
							info.settings.minimumNumber.SetValue(0);
						}
					}
				});
				yield return wait;
			}
		}
	}
}
