using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour, ISavable
{
	private Character controlledCharacter;

	public Character ControlledCharacter => controlledCharacter;

	protected virtual void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	public virtual void Possess(Character newCharacter)
	{
		controlledCharacter = newCharacter;
		controlledCharacter.OnPosses(this);
	}

	public virtual void OnSave()
	{
	}

	public virtual void OnPreLoad()
	{
	}

	public virtual void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
