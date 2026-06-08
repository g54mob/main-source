using System.Collections.Generic;
using UnityEngine;

public class SSDecorationStatic : StonescriptObject
{
	public SSDecorationStatic()
		: base("decoration")
	{
		DeclareFunction(New);
	}

	protected object New(List<object> parameters, InvocationContext ctx)
	{
		string text = ((parameters.Count > 0) ? (parameters[0] as string) : null);
		string name = text;
		if (string.IsNullOrEmpty(text))
		{
			name = "Decoration";
		}
		GameObject gameObject = new GameObject(name);
		Decoration decoration = gameObject.AddComponent<Decoration>();
		if (!string.IsNullOrEmpty(text))
		{
			decoration.id = text;
			decoration.instanceId = text;
		}
		GameStates.Singleton.level.AddCharacter(decoration);
		MultilayerSprite multilayerSprite = gameObject.AddComponent<MultilayerSprite>();
		multilayerSprite.nestedPosition = true;
		decoration.MySprite = multilayerSprite;
		return gameObject.AddComponent<SSScriptableObject>().Target;
	}
}
