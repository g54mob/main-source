using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Construction : MonoBehaviour
{
	[SerializeField]
	private BuildingDeconstructable _deconstructable;

	[SerializeField]
	private PaymentGroup _payment;

	[SerializeField]
	private PaymentCollector _paymentCollector;

	[SerializeField]
	private ConstructionUI _constructionUI;

	public Building Building;

	[field: SerializeField]
	public BuildingAsset BuildingAsset { get; private set; }

	public PaymentGroup Payment => null;

	public static List<Construction> Constructions { get; private set; }

	public static event Action<Construction> AnnounceConstructionStarted
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action<Construction> AnnounceConstructionDestroyed
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Set(BuildingAsset buildingAsset)
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void Initiate()
	{
	}

	private IEnumerable<ItemStack> GetCompositeItems()
	{
		return null;
	}

	private void OnDestroy()
	{
	}

	public void Complete()
	{
	}
}
