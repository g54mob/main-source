using UnityEngine;

public class CharacterPortrait
{
	public Texture2D Static;

	public Agent Agent { get; private set; }

	public GameObject DynamicGameObject { get; private set; }

	public CharacterPortrait(Agent agent, GameObject dynamicGameObject)
	{
		Agent = agent;
		DynamicGameObject = dynamicGameObject;
	}

	public CharacterPortrait(Agent agent, Texture2D staticPortrait)
	{
		Agent = agent;
		Static = staticPortrait;
	}
}
