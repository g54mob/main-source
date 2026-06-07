using System;

[Serializable]
public class MstBlendDataEntities
{
	public int primaryId;

	public eLuggage blendId;

	public eLuggage blend_source1;

	public int blend_count1;

	public eLuggage blend_source2;

	public int blend_count2;

	public eLuggage blend_source3;

	public int blend_count3;

	public eLuggage blend_source4;

	public int blend_count4;

	public eLuggage blend_source5;

	public int blend_count5;

	public eLuggage blend_source6;

	public int blend_count6;

	public float craftSpeed;

	public int craftCount;

	public bool isHidden;

	public bool isTrial;

	public bool isEarly;

	public eSecondaryMachineCategory machineId1;

	public eSecondaryMachineCategory machineId2;

	public eSecondaryMachineCategory machineId3;

	public eSecondaryMachineCategory machineId4;

	public eSecondaryMachineCategory machineId5;

	public bool HasSource(eLuggage source, int materialCount)
	{
		return false;
	}

	public int GetMaterialCount()
	{
		return 0;
	}

	public bool CheckMachine(eSecondaryMachineCategory secondaryMachineCategory)
	{
		return false;
	}

	public override string ToString()
	{
		return null;
	}
}
