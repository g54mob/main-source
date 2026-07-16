using System.Linq;
using UnityEngine;

public abstract class WorkstationCore : MonoBehaviour, IDataPersistence
{
	public enum WorkstationProcessingType
	{
		Manual = 0,
		Automatic = 1
	}

	[SerializeField]
	private string workstationName;

	public WorkstationComponent[] workstationComponents;

	private bool isLoading;

	[SerializeField]
	protected bool useProcessingTime;

	[SerializeField]
	protected float processingDuration = 3f;

	protected float remainingProcessingTime;

	protected bool isProcessing;

	public WorkstationProcessingType processingType;

	void IDataPersistence.SaveData(ref GameData data)
	{
		OnSave(ref data);
	}

	void IDataPersistence.LoadData(GameData data, bool isNewGameData)
	{
		isLoading = true;
		OnLoad(data);
		OnInit();
	}

	protected WorkstationComponent GetWorkstationComponent(int index)
	{
		return workstationComponents[index];
	}

	protected WorkstationComponent GetWorkstationComponent(string tag)
	{
		return workstationComponents.FirstOrDefault((WorkstationComponent x) => x.GetTag().ToLower() == tag.ToLower());
	}

	private void Start()
	{
		if (!isLoading)
		{
			remainingProcessingTime = processingDuration;
			OnInit();
		}
	}

	private void Update()
	{
		if (processingType != WorkstationProcessingType.Manual && isProcessing)
		{
			OnProcessingAutomatic();
		}
	}

	public abstract void OnInit();

	protected virtual void OnSave(ref GameData data)
	{
	}

	protected virtual void OnLoad(GameData data)
	{
	}

	public abstract void OnPlayerInteraction(CharacterControllerComponent character);

	public virtual void OnPlayerAction(CharacterControllerComponent character)
	{
	}

	public virtual void OnPlayerHoldingInteraction(CharacterControllerComponent character)
	{
	}

	public virtual void OnPlayerHoldingStopped(CharacterControllerComponent character)
	{
	}

	protected virtual void OnProcessingManual()
	{
	}

	protected virtual void OnProcessingAutomatic()
	{
	}
}
