using System.Collections.Generic;
using Stonescript;
using Stonescript.Runtime;
using UnityEngine;

public class SSLevel : StonescriptObject
{
	private Level level;

	public Machine stonescript;

	public AStonescriptGameModel gameModel;

	private List<IFunction> updateCallbacks = new List<IFunction>();

	public SSLevel(Level level, SSNativeObject<Data.Quest> quest)
		: base(quest.Source.id)
	{
		this.level = level;
		DeclareVariable("quest", quest);
		DeclareFunction(Preload);
		DeclareFunction(Spawn);
		DeclareFunction(Remove);
		DeclareFunction(Leave);
		DeclareFunction(RegisterUpdate);
		DeclareFunction(GetTime);
		DeclareFunction(Draw);
		DeclareFunction(FindCharacter);
		DeclareFunction(FindAllEnemies);
		DeclareFunction(SetCompletable);
		DeclareFunction(AddSprite);
		DeclareFunction(RemoveSprite);
		DeclareGetter("loops", () => level.loops);
	}

	public void UpdateTic()
	{
		for (int i = 0; i < updateCallbacks.Count; i++)
		{
			updateCallbacks[i].Invoke();
		}
	}

	public object GetTime(List<object> parameters, InvocationContext ctx)
	{
		return GameStates.Singleton.level.gameTime;
	}

	public object RegisterUpdate(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || !(parameters[0] is IFunction))
		{
			throw new RuntimeException(ctx, "RegisterUpdate expects a function parameter but recieved something else.");
		}
		IFunction item = parameters[0] as IFunction;
		updateCallbacks.Add(item);
		return null;
	}

	public object Draw(List<object> parameters, InvocationContext ctx)
	{
		int num = 0;
		Character character = null;
		if (parameters[num] is StonescriptObject)
		{
			character = (parameters[num] as StonescriptObject).Scriptable.GetComponent<Character>();
			num++;
		}
		string str = parameters[num] as string;
		gameModel.Print(str, character);
		return null;
	}

	public object SpawnDecoration(List<object> parameters, InvocationContext ctx)
	{
		GameObject gameObject = new GameObject("Decoration");
		gameObject.AddComponent<Decoration>();
		gameObject.AddComponent<MultilayerSprite>();
		return gameObject.AddComponent<SSScriptableObject>().Target;
	}

	private object SpawnFromData(StonescriptObject spawnData)
	{
		string obj = spawnData.GetVariable("id") as string;
		if (string.IsNullOrEmpty(obj))
		{
			throw new StonescriptRuntimeException("You must specify an id for the spawned object.");
		}
		GameObject gameObject = new GameObject(obj);
		string text = (spawnData.IsVariable("type") ? (spawnData.GetVariable("type") as string) : "character");
		Character character = null;
		if (!(text == "character"))
		{
			if (!(text == "decoration"))
			{
				throw new StonescriptRuntimeException("Invalid spawn type \"" + text + "\".");
			}
			character = gameObject.AddComponent<Decoration>();
		}
		else
		{
			character = gameObject.AddComponent<Character>();
		}
		int positionX = 0;
		int positionZ = 0;
		if (spawnData.IsVariable("positionX"))
		{
			positionX = (int)spawnData.GetVariable("positionX");
		}
		if (spawnData.IsVariable("positionY"))
		{
			positionZ = (int)spawnData.GetVariable("positionY");
		}
		if (character != null)
		{
			character.PositionX = positionX;
			character.PositionZ = positionZ;
			level.AddCharacter(character);
		}
		MultilayerSprite multilayerSprite = gameObject.AddComponent<MultilayerSprite>();
		if (spawnData.IsVariable("source"))
		{
			GameObject gameObject2 = new GameObject("Animation");
			gameObject2.transform.SetParent(gameObject.transform);
			AsciiSprite asciiSprite = gameObject2.AddComponent<AsciiSprite>();
			string text2 = spawnData.GetVariable("source") as string;
			text2 = text2.Replace("\\n", "\n");
			asciiSprite.Load(text2);
			multilayerSprite.additionalLayers.Add(asciiSprite);
			AsciiAnimation asciiAnimation = gameObject2.AddComponent<AsciiAnimation>();
			asciiAnimation.playOnStart = true;
			asciiAnimation.looping = true;
		}
		if (character != null)
		{
			character.MySprite = multilayerSprite;
		}
		return gameObject.AddComponent<SSScriptableObject>().Target;
	}

	private object Preload(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || !(parameters[0] is string))
		{
			throw new StonescriptRuntimeException("Preload requires string parameter");
		}
		string text = parameters[0] as string;
		Utils.PreloadAsyncPrefab(text);
		Debug.LogWarning("Preloading: " + text);
		return null;
	}

	public object Spawn(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0)
		{
			throw new StonescriptRuntimeException("Spawn requires parameters");
		}
		int num = 0;
		if (parameters[num] is StonescriptObject)
		{
			StonescriptObject spawnData = parameters[num++] as StonescriptObject;
			return SpawnFromData(spawnData);
		}
		string text = parameters[num++] as string;
		GameObject gameObject = Utils.LoadPrefab(text);
		if (gameObject == null)
		{
			throw new StonescriptRuntimeException("Unable to spawn \"" + text + "\".");
		}
		GameObject gameObject2 = Object.Instantiate(gameObject);
		Character component = gameObject2.GetComponent<Character>();
		if (component != null)
		{
			if (parameters.Count > num && parameters[num] is int)
			{
				int positionX = (int)parameters[num++];
				int positionZ = (int)parameters[num++];
				component.PositionX = positionX;
				component.PositionZ = positionZ;
			}
			if (parameters.Count > num && parameters[num] is string)
			{
				component.instanceId = parameters[num++] as string;
			}
			level.AddCharacter(component);
			SSScriptableObject sSScriptableObject = component.GetComponent<SSScriptableObject>();
			if (sSScriptableObject == null)
			{
				sSScriptableObject = gameObject2.AddComponent<SSScriptableObject>();
			}
			return sSScriptableObject.Target;
		}
		AsciiSprite component2 = gameObject2.GetComponent<AsciiSprite>();
		if (component2 != null)
		{
			int num2 = (int)parameters[1];
			int num3 = (int)parameters[2];
			component2.pivotX = -num2;
			component2.pivotY = -num3;
			SSScriptableObject sSScriptableObject2 = gameObject2.GetComponent<SSScriptableObject>();
			if (sSScriptableObject2 == null)
			{
				sSScriptableObject2 = gameObject2.AddComponent<SSScriptableObject>();
			}
			GameStates.Singleton.level.AddObject(component2);
			return sSScriptableObject2.Target;
		}
		return null;
	}

	public object Remove(List<object> parameters, InvocationContext ctx)
	{
		StonescriptObject stonescriptObject = null;
		if (parameters.Count == 0)
		{
			throw new StonescriptRuntimeException("level.Remove expects an object or object id.");
		}
		if (parameters[0] is StonescriptObject)
		{
			stonescriptObject = parameters[0] as StonescriptObject;
		}
		else if (parameters[0] is string)
		{
			string instanceId = parameters[0] as string;
			Character character = level.Characters.Find((Character c) => c.instanceId == instanceId);
			if (character != null)
			{
				stonescriptObject = character.GetComponent<SSScriptableObject>().Target;
			}
		}
		if (stonescriptObject == null)
		{
			return null;
		}
		SSScriptableObject scriptable = stonescriptObject.Scriptable;
		if (scriptable != null)
		{
			Character component = scriptable.GetComponent<Character>();
			if (component != null)
			{
				level.RemoveCharacter(component);
				Object.Destroy(component.gameObject);
				return null;
			}
			AsciiSprite component2 = scriptable.GetComponent<AsciiSprite>();
			if (component2 != null)
			{
				level.RemoveObject(component2);
				Object.Destroy(component2.gameObject);
				return null;
			}
		}
		throw new StonescriptRuntimeException("level.Remove expects an object or object id.");
	}

	public object FindCharacter(List<object> parameters, InvocationContext ctx)
	{
		string instanceId = parameters[0] as string;
		Character character = level.Characters.Find((Character c) => c != null && c.isActiveAndEnabled && c.instanceId == instanceId);
		if (character == null)
		{
			return null;
		}
		SSScriptableObject sSScriptableObject = character.GetComponent<SSScriptableObject>();
		if (sSScriptableObject == null)
		{
			sSScriptableObject = character.gameObject.AddComponent<SSScriptableObject>();
		}
		return sSScriptableObject.Target;
	}

	public object FindAllEnemies(List<object> parameters, InvocationContext ctx)
	{
		StonescriptArray stonescriptArray = new StonescriptArray();
		List<StonescriptObject> list = level.Enemies.ConvertAll((Enemy c) => c?.GetComponent<SSScriptableObject>()?.Target);
		list.RemoveAll((StonescriptObject sso) => sso == null);
		stonescriptArray.AddRange(list);
		return stonescriptArray;
	}

	public object AddSprite(List<object> parameters, InvocationContext ctx)
	{
		AsciiSprite component = (parameters[0] as StonescriptObject).Scriptable.GetComponent<AsciiSprite>();
		level.AddObject(component);
		return null;
	}

	public object RemoveSprite(List<object> parameters, InvocationContext ctx)
	{
		AsciiSprite component = (parameters[0] as StonescriptObject).Scriptable.GetComponent<AsciiSprite>();
		level.RemoveObject(component);
		return null;
	}

	public object Leave(List<object> parameters, InvocationContext ctx)
	{
		GameStates.Singleton.LeaveQuest();
		return null;
	}

	public object SetCompletable(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0)
		{
			throw new StonescriptRuntimeException("level.SetCompletable expects at least 1 parameter.");
		}
		if (parameters.Count == 1)
		{
			if (parameters[0] == null)
			{
				level.completable = null;
				return null;
			}
			if (parameters[0] is bool)
			{
				bool completable = (bool)parameters[0];
				level.completable = () => completable;
				return null;
			}
		}
		int num = 0;
		IFunction callbackFunc = parameters[num++] as IFunction;
		List<object> prms = new List<object>();
		if (num < parameters.Count)
		{
			if (!(parameters[num] is StonescriptArray))
			{
				throw new StonescriptRuntimeException("Invalid callback parameters: array expected.");
			}
			StonescriptArray collection = parameters[num] as StonescriptArray;
			prms.AddRange(collection);
			num++;
		}
		if (callbackFunc == null)
		{
			throw new StonescriptRuntimeException("Invalid callback for level.SetCompletable");
		}
		level.completable = () => (bool)callbackFunc.Invoke(prms);
		return null;
	}
}
