using Pug.Conversion;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class FactionConverter : SingleAuthoringComponentConverter<FactionAuthoring>
{
	private BlobAssetReference<FactionCD.FactionsCanAttackLookUp> _factionsLookUpRef;

	protected override void Convert(FactionAuthoring authoring)
	{
		if (Application.isPlaying)
		{
			if (_factionsLookUpRef == BlobAssetReference<FactionCD.FactionsCanAttackLookUp>.Null)
			{
				_factionsLookUpRef = InitializeFactionsLookUp();
			}
			AddComponentData(new FactionCD
			{
				faction = authoring.faction,
				originalFaction = authoring.faction,
				factionsLookUp = _factionsLookUpRef,
				pvpTeam = -1
			});
			if (authoring.GetComponent<PlayerAuthoring>() != null)
			{
				EnsureHasComponent<PvPTeamPendingInitializeCD>();
			}
		}
	}

	private BlobAssetReference<FactionCD.FactionsCanAttackLookUp> InitializeFactionsLookUp()
	{
		BooleanMatrix factionsLookupMatrix = Manager.mod.FactionsLookupMatrix;
		if (factionsLookupMatrix == null)
		{
			Debug.LogError("No FactionsLookUp");
			return default(BlobAssetReference<FactionCD.FactionsCanAttackLookUp>);
		}
		int num = 30;
		using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp);
		BlobBuilderArray<ulong> blobBuilderArray = blobBuilder.Allocate(ref blobBuilder.ConstructRoot<FactionCD.FactionsCanAttackLookUp>().canAttackBitMask, num);
		for (int i = 0; i < num; i++)
		{
			ulong num2 = 0uL;
			for (int j = 0; j < num; j++)
			{
				if (factionsLookupMatrix[j, i])
				{
					num2 |= (ulong)(1L << j);
				}
			}
			blobBuilderArray[i] = num2;
		}
		BlobAssetReference<FactionCD.FactionsCanAttackLookUp> blobAsset = blobBuilder.CreateBlobAssetReference<FactionCD.FactionsCanAttackLookUp>(Allocator.Persistent);
		base.BlobAssetStore.TryAdd(ref blobAsset);
		return blobAsset;
	}
}
