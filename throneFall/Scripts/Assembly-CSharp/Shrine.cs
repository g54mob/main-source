using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : MonoBehaviour, ISaveLoad
{
	public static TagManager tagManager;

	private static List<TaggedObject> shrinesFound = new List<TaggedObject>();

	private static List<TaggedObject> shrinesFoundB = new List<TaggedObject>();

	private static List<TagManager.ETag> mustHaveTags = new List<TagManager.ETag>();

	private static List<TagManager.ETag> mayNotHaveTags = new List<TagManager.ETag>();

	[SerializeField]
	private ProductionBar productionBar;

	private float currentXp;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float maxXp = 1000f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float collectionRange = 10f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private int incomeOnceUnlocked = 2;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float strengthBonusOnAdditionalShrine = 1.2f;

	[SerializeField]
	private List<GameObject> disableOnComplete;

	[SerializeField]
	private List<GameObject> enableOnComplete;

	[SerializeField]
	private BuildSlot parentBuildSlot;

	[SerializeField]
	private Mesh replacementMesh;

	[SerializeField]
	private ParticleSystem upgradeParticles;

	[SerializeField]
	private ParticleSystem levelParticle;

	private bool shrineHasBeenActivated;

	public float CollectionRange
	{
		get
		{
			return collectionRange;
		}
		set
		{
			collectionRange = value;
		}
	}

	public int IncomeOnceUnlocked => incomeOnceUnlocked;

	public BuildSlot ParentBuildSlot => parentBuildSlot;

	public bool ShrineHasBeenActivated => shrineHasBeenActivated;

	private void Start()
	{
		MakeProgressAndUpdateBar();
	}

	public void AdjustRequiredXp(float _multi)
	{
		maxXp *= _multi;
		MakeProgressAndUpdateBar();
	}

	public void MakeProgressAndUpdateBar(float _xpGain = 0f)
	{
		if (!shrineHasBeenActivated)
		{
			currentXp += _xpGain;
			levelParticle.Play();
			if (currentXp >= maxXp)
			{
				ActivateShrine(_calledFromSaveLoad: false);
			}
			else
			{
				productionBar.UpdateVisual(currentXp / maxXp + 0.001f);
			}
		}
	}

	[ContextMenu("ACTIVATE")]
	private void DebugActivate()
	{
		ActivateShrine(_calledFromSaveLoad: false);
	}

	private void ActivateShrine(bool _calledFromSaveLoad)
	{
		if (shrineHasBeenActivated && !_calledFromSaveLoad)
		{
			return;
		}
		if (tagManager == null)
		{
			tagManager = TagManager.instance;
		}
		upgradeParticles.Play();
		foreach (GameObject item in disableOnComplete)
		{
			item.SetActive(value: false);
		}
		foreach (GameObject item2 in enableOnComplete)
		{
			item2.SetActive(value: true);
		}
		GetComponentInParent<BuildSlot>().GoldIncome += incomeOnceUnlocked;
		parentBuildSlot.ReplaceMeshExternal(replacementMesh);
		shrineHasBeenActivated = true;
		if (mustHaveTags.Count != 1 || !tagManager)
		{
			tagManager = TagManager.instance;
			mustHaveTags.Clear();
			mustHaveTags.Add(TagManager.ETag.PlayerShrine);
			mayNotHaveTags.Clear();
		}
		tagManager.FindAllTaggedObjectsWithTags(shrinesFoundB, mustHaveTags, mayNotHaveTags);
		if (!_calledFromSaveLoad)
		{
			foreach (TaggedObject item3 in shrinesFoundB)
			{
				Shrine component = item3.GetComponent<Shrine>();
				if (!(component == this) && component.ShrineHasBeenActivated)
				{
					UpgradeMyPower();
					component.UpgradeMyPower();
				}
			}
			return;
		}
		foreach (TaggedObject item4 in shrinesFoundB)
		{
			Shrine component2 = item4.GetComponent<Shrine>();
			if (!(component2 == this) && component2.ShrineHasBeenActivated)
			{
				UpgradeMyPower();
			}
		}
	}

	public static void DeathOfUnitAt(Vector3 _position, float _unitsOriginalHealth)
	{
		if (!tagManager)
		{
			tagManager = TagManager.instance;
			mustHaveTags.Clear();
			mustHaveTags.Add(TagManager.ETag.PlayerShrine);
			mayNotHaveTags.Clear();
		}
		tagManager.FindAllTaggedObjectsWithTags(shrinesFound, mustHaveTags, mayNotHaveTags);
		foreach (TaggedObject item in shrinesFound)
		{
			Shrine shrine = item.Shrine;
			if ((_position - shrine.transform.position).magnitude <= shrine.collectionRange)
			{
				shrine.MakeProgressAndUpdateBar(_unitsOriginalHealth);
			}
		}
	}

	public void OnBeforeMainLoadPass(string guid)
	{
	}

	public void OnAfterMainLoadPass(string guid)
	{
	}

	public void OnSave(string guid)
	{
		MatchSaveLoadHandler.SaveValue(guid, "currentXp", currentXp);
		MatchSaveLoadHandler.SaveValue(guid, "shrineHasBeenActivated", shrineHasBeenActivated);
	}

	public void OnLoad(string guid)
	{
		MatchSaveLoadHandler.TryLoadValue(guid, "currentXp", ref currentXp);
		MatchSaveLoadHandler.TryLoadValue(guid, "shrineHasBeenActivated", ref shrineHasBeenActivated);
		if (shrineHasBeenActivated)
		{
			StartCoroutine(ActivateShrineDelayedInSaveLoad());
		}
	}

	private IEnumerator ActivateShrineDelayedInSaveLoad()
	{
		yield return null;
		yield return null;
		ActivateShrine(_calledFromSaveLoad: true);
	}

	public void UpgradeMyPower()
	{
		AutoAttack[] componentsInChildren = GetComponentsInChildren<AutoAttack>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].DamageMultiplyer *= strengthBonusOnAdditionalShrine;
		}
	}
}
