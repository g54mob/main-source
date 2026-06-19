using Pug.Conversion;
using Pug.UnityExtensions;
using UnityEngine;

public class AffectObjectWhenMelodyPlayedConverter : SingleAuthoringComponentConverter<AffectObjectWhenMelodyPlayedAuthoring>
{
	protected override void Convert(AffectObjectWhenMelodyPlayedAuthoring authoring)
	{
		if (authoring.customLoot.Count > 0)
		{
			EnsureHasBuffer<ItemsToAddToNewObjectBuffer>();
			foreach (ObjectData item in authoring.customLoot)
			{
				int amount = item.amount;
				if (item.objectID == ObjectID.None)
				{
					amount = 0;
				}
				else
				{
					ObjectInfo objectInfo = PugDatabase.GetObjectInfo(item.objectID, item.variation);
					if (objectInfo == null)
					{
						Debug.LogError($"Object {item.objectID} {item.variation} in {authoring.name} not found in database");
						continue;
					}
					if (!objectInfo.isStackable)
					{
						amount = objectInfo.initialAmount;
					}
				}
				AddToBuffer(new ItemsToAddToNewObjectBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = item.objectID,
						variation = item.variation,
						amount = amount
					}
				});
			}
		}
		AddComponentData(new AffectObjectWhenMelodyPlayedCD
		{
			listening = authoring.listening,
			humCooldown = authoring.humCooldown,
			hearRange = authoring.hearRange,
			changeObjectID = authoring.changeObjectID,
			newObjectId = authoring.newObjectId,
			newVariation = authoring.newVariation,
			weakenWhenAffected = authoring.weakenWhenAffected,
			removeMelodyListener = authoring.removeMelodyListener,
			removeOldColliders = authoring.removeOldColliders,
			tableLoot = authoring.tableLoot,
			melodyProgress = 0,
			scale = 0,
			playerHoldingInstrumentExists = false,
			melodyID = MelodyID.None,
			humIndex = -1,
			timer = default(TimerSimple)
		});
		EnsureHasBuffer<MelodiesBuffer>();
		foreach (MelodyID melodyID in authoring.melodyIDList)
		{
			AddToBuffer(new MelodiesBuffer
			{
				melodyID = melodyID
			});
		}
		EnsureHasBuffer<TrackedNotesBuffer>();
	}
}
