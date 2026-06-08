using System.Collections.Generic;
using UnityEngine;

public class SSNeutralStatic : StonescriptObject
{
	public SSNeutralStatic()
		: base("neutral")
	{
		DeclareFunction(New);
	}

	protected object New(List<object> parameters, InvocationContext ctx)
	{
		string text = ((parameters.Count > 0) ? (parameters[0] as string) : null);
		string name = text;
		if (string.IsNullOrEmpty(text))
		{
			name = "Neutral";
		}
		GameObject gameObject = new GameObject(name);
		Neutral neutral = gameObject.AddComponent<Neutral>();
		if (!string.IsNullOrEmpty(text))
		{
			neutral.id = text;
			neutral.instanceId = text;
		}
		GameStates.Singleton.level.AddCharacter(neutral);
		MultilayerSprite multilayerSprite = gameObject.AddComponent<MultilayerSprite>();
		multilayerSprite.nestedPosition = true;
		neutral.MySprite = multilayerSprite;
		return gameObject.AddComponent<SSScriptableObject>().Target;
	}
}
