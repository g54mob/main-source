using UnityEngine;

public class IncomeModifyer : MonoBehaviour
{
	public BuildSlot buildSlot;

	public BuildingInteractor buildingInteractor;

	private void Start()
	{
		buildingInteractor.IncomeModifiers.Add(this);
	}

	public virtual void OnDawn()
	{
	}
}
