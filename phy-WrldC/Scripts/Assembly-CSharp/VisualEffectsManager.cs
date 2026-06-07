using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UltimateReplay;
using UnityEngine;

public class VisualEffectsManager : MonoBehaviour
{
	[SerializeField]
	private Transform particlesTempFolder;

	[SerializeField]
	private Transform particlesPoolFolder;

	[SerializeField]
	private Transform decalsTempFolder;

	[SerializeField]
	private Transform decalsPoolFolder;

	private Dictionary<GameObject, List<ParticlesLifeControl>> particlesPool;

	private Dictionary<GameObject, List<DecalLifeControl>> decalsPool;

	private bool shouldReplayParticles;

	private bool shouldReplayDecals;

	public static VisualEffectsManager Instance => Singleton<VisualEffectsManager>.Instance;

	public static bool Exist => Singleton<VisualEffectsManager>.Exist;

	private void Awake()
	{
		particlesPool = new Dictionary<GameObject, List<ParticlesLifeControl>>();
		decalsPool = new Dictionary<GameObject, List<DecalLifeControl>>();
		shouldReplayParticles = true;
		shouldReplayDecals = true;
	}

	public IEnumerator PopulateVisualEffectsPool()
	{
		if (particlesPool.Count <= 0 && decalsPool.Count <= 0)
		{
			VisualEffectStylesData visualEffectStylesData = GameManager.Instance.GameStylesData.visualEffectStylesData;
			CreateParticlesPool(visualEffectStylesData.rbImpactParticlesList[0], 30);
			CreateParticlesPool(visualEffectStylesData.rbImpactParticlesList[1], 20);
			CreateParticlesPool(visualEffectStylesData.rbImpactParticlesList[2], 10);
			CreateParticlesPool(visualEffectStylesData.rbImpactParticlesList[3], 10);
			CreateParticlesPool(visualEffectStylesData.rbDragSparkParticles, 10);
			CreateParticlesPool(visualEffectStylesData.bbJointBreakParticlesPrefab, 10);
			CreateParticlesPool(visualEffectStylesData.cannonFireParticlesPrefab, 10);
			CreateParticlesPool(visualEffectStylesData.landMineExplosionPrefab, 10);
			CreateParticlesPool(visualEffectStylesData.tntCrateExplosionPrefab, 10);
			CreateParticlesPool(visualEffectStylesData.goldStarParticlesPrefab, 5);
			CreateParticlesPool(visualEffectStylesData.silverStarParticlesPrefab, 5);
			yield return new WaitForEndOfFrame();
			CreateDecalsPool(visualEffectStylesData.rbImpactDecalList[0], 30);
			CreateDecalsPool(visualEffectStylesData.rbImpactDecalList[1], 20);
			CreateDecalsPool(visualEffectStylesData.rbImpactDecalList[2], 10);
			CreateDecalsPool(visualEffectStylesData.rbImpactDecalList[3], 10);
			CreateDecalsPool(visualEffectStylesData.explosionDecalPrefab, 10);
			CreateDecalsPool(visualEffectStylesData.explosionDirtDecalPrefab, 10);
			yield return new WaitForEndOfFrame();
		}
	}

	private void CreateParticlesPool(GameObject particlesPrefab, int poolSize)
	{
		particlesPool.Add(particlesPrefab, new List<ParticlesLifeControl>());
		for (int i = 0; i < poolSize; i++)
		{
			GameObject obj = Object.Instantiate(particlesPrefab, particlesPoolFolder);
			ParticlesLifeControl component = obj.GetComponent<ParticlesLifeControl>();
			component.SetExistence(isExisting: false);
			component.ShouldDestroy = false;
			obj.AddComponent<ParticlesLifeControlReplay>();
			obj.AddComponent<ReplayObject>().RebuildComponentList();
			particlesPool[particlesPrefab].Add(component);
		}
	}

	public GameObject GetParticlesInstance(GameObject particlesPrefab)
	{
		ParticlesLifeControl particlesLifeControl = particlesPool[particlesPrefab].FirstOrDefault((ParticlesLifeControl particles) => !particles.IsExisting);
		if (particlesLifeControl != null)
		{
			particlesLifeControl.Recycle();
			particlesLifeControl.SetExistence(isExisting: true);
			return particlesLifeControl.gameObject;
		}
		particlesLifeControl = Object.Instantiate(particlesPrefab, particlesTempFolder).GetComponent<ParticlesLifeControl>();
		particlesLifeControl.ShouldDestroy = true;
		return particlesLifeControl.gameObject;
	}

	public void SetParticlesReplayStatus(bool shouldRemoveFromReplay)
	{
		if ((shouldReplayParticles && !shouldRemoveFromReplay) || (!shouldReplayParticles && shouldRemoveFromReplay))
		{
			return;
		}
		foreach (List<ParticlesLifeControl> value in particlesPool.Values)
		{
			foreach (ParticlesLifeControl item in value)
			{
				if (shouldRemoveFromReplay)
				{
					ParticlesLifeControlReplay component = item.gameObject.GetComponent<ParticlesLifeControlReplay>();
					if (component != null)
					{
						Object.Destroy(component);
					}
					ReplayObject component2 = item.gameObject.GetComponent<ReplayObject>();
					if (component2 != null)
					{
						Object.Destroy(component2);
					}
				}
				else
				{
					item.gameObject.AddComponent<ParticlesLifeControlReplay>();
					item.gameObject.AddComponent<ReplayObject>().RebuildComponentList();
				}
			}
		}
		shouldReplayParticles = !shouldRemoveFromReplay;
	}

	private void CreateDecalsPool(GameObject decalPrefab, int poolSize)
	{
		decalsPool.Add(decalPrefab, new List<DecalLifeControl>());
		for (int i = 0; i < poolSize; i++)
		{
			GameObject obj = Object.Instantiate(decalPrefab, decalsPoolFolder);
			DecalLifeControl component = obj.GetComponent<DecalLifeControl>();
			component.SetExistence(isExisting: false);
			component.ShouldDestroy = false;
			obj.AddComponent<DecalLifeControlReplay>();
			obj.AddComponent<ReplayObject>().RebuildComponentList();
			decalsPool[decalPrefab].Add(component);
		}
	}

	public GameObject GetDecalInstance(GameObject decalPrefab)
	{
		DecalLifeControl decalLifeControl = decalsPool[decalPrefab].FirstOrDefault((DecalLifeControl decal) => !decal.IsExisting);
		if (decalLifeControl != null)
		{
			decalLifeControl.Recycle();
			decalLifeControl.SetExistence(isExisting: true);
			return decalLifeControl.gameObject;
		}
		decalLifeControl = Object.Instantiate(decalPrefab, decalsTempFolder).GetComponent<DecalLifeControl>();
		decalLifeControl.ShouldDestroy = true;
		return decalLifeControl.gameObject;
	}

	public void SetDecalsReplayStatus(bool shouldRemoveFromReplay)
	{
		if ((shouldReplayDecals && !shouldRemoveFromReplay) || (!shouldReplayDecals && shouldRemoveFromReplay))
		{
			return;
		}
		foreach (List<DecalLifeControl> value in decalsPool.Values)
		{
			foreach (DecalLifeControl item in value)
			{
				if (shouldRemoveFromReplay)
				{
					DecalLifeControlReplay component = item.gameObject.GetComponent<DecalLifeControlReplay>();
					if (component != null)
					{
						Object.Destroy(component);
					}
					ReplayObject component2 = item.gameObject.GetComponent<ReplayObject>();
					if (component2 != null)
					{
						Object.Destroy(component2);
					}
				}
				else
				{
					item.gameObject.AddComponent<DecalLifeControlReplay>();
					item.gameObject.AddComponent<ReplayObject>().RebuildComponentList();
				}
			}
		}
		shouldReplayDecals = !shouldRemoveFromReplay;
	}

	public void DestroyAllEffects()
	{
		foreach (Transform item in particlesTempFolder)
		{
			Object.Destroy(item.gameObject);
		}
		foreach (Transform item2 in decalsTempFolder)
		{
			Object.Destroy(item2.gameObject);
		}
		foreach (List<ParticlesLifeControl> value in particlesPool.Values)
		{
			foreach (ParticlesLifeControl item3 in value)
			{
				item3.SetExistence(isExisting: false);
			}
		}
		foreach (List<DecalLifeControl> value2 in decalsPool.Values)
		{
			foreach (DecalLifeControl item4 in value2)
			{
				item4.SetExistence(isExisting: false);
			}
		}
	}
}
