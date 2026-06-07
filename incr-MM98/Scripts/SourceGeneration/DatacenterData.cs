using UnityEngine;

[CreateAssetMenu(menuName = "Data/Datacenter", fileName = "Datacenter")]
public class DatacenterData : ScriptableData<Datacenter>
{
	public double cost;

	public double costEngineer = 1000.0;

	public float costEngineerScale = 1f;

	public float crashChance = 0.01f;

	public Datacenter prerequisite;

	protected override string LocalizationPrefix => "datacenter";

	protected override LocTable LocalizationTable => LocTable.Datacenters;

	public static implicit operator Datacenter(DatacenterData data)
	{
		return data?.ID ?? Datacenter.None;
	}

	public static implicit operator DatacenterData(Datacenter node)
	{
		return node.Data();
	}
}
