using System.Collections.Generic;
using System.Linq;
using Aggro.Core.Networking;
using DevCmdLine;
using Unity.Mathematics;
using UnityEngine;

public class DevCmdSpawn : MonoBehaviour
{
	public string uiCategory;

	public bool uiOverrideName;

	public string uiOverridenName;

	public bool spawnOnGround;

	private static Dictionary<string, GameObject> _nameToPrefab;

	private static GameObject[] _prefabs;

	[RuntimeInitializeOnLoadMethod]
	private static void RuntimeInitialize()
	{
		_nameToPrefab = null;
		_prefabs = null;
	}

	public static bool TryGetPrefab(string name, out GameObject prefab)
	{
		CheckCreateCache();
		return _nameToPrefab.TryGetValue(name, out prefab);
	}

	public static GameObject[] GetPrefabs()
	{
		CheckCreateCache();
		return _prefabs;
	}

	[DevCmd("spawn", "Spawns a prefab in front of the player.\r\n\r\nUsage:\r\n    spawn <prefab>\r\n        Spawns the supplied prefab in front of the player.", new string[] { })]
	[DevCmdVerify("^[\\S]+$")]
	public static void SpawnDevCmd(DevCmdArg[] args)
	{
		if (!GameUtil.isReady)
		{
			Debug.LogWarning("Entity world is not ready!");
			return;
		}
		if (!GameUtil.TryGetLocalPlayer(out var player))
		{
			Debug.LogWarning("Local player not found!");
			return;
		}
		CheckCreateCache();
		if (!_nameToPrefab.ContainsKey(args[0].value))
		{
			Debug.LogWarning("Invalid prefab name! (" + args[0].value + ")");
			return;
		}
		Vector3 vector = player.transform.position + Vector3.up;
		Vector3 vector2 = vector + player.transform.forward * 3f + UnityEngine.Random.insideUnitSphere * 0.25f;
		Ray ray = new Ray
		{
			origin = vector,
			direction = (vector2 - vector).normalized
		};
		if (Physics.Raycast(ray, out var hitInfo, math.distance(vector, vector2), 2048))
		{
			vector2 = hitInfo.point + -ray.direction;
		}
		NetworkAggroManagerBase<NetworkDevCmds>.instance.CmdSpawnPrefab(args[0].value, vector2, Quaternion.identity);
	}

	[DevCmdCompleteFunction("spawn", "", DevCmdCompleteFlags.Default)]
	private static string[] SpawnDevCmdComplete()
	{
		CheckCreateCache();
		return _nameToPrefab.Keys.ToArray();
	}

	private static void CheckCreateCache()
	{
		if (_nameToPrefab != null)
		{
			return;
		}
		_nameToPrefab = new Dictionary<string, GameObject>();
		GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
		foreach (GameObject gameObject in array)
		{
			if (!(gameObject.transform.parent != null) && !gameObject.scene.IsValid() && gameObject.TryGetComponent<DevCmdSpawn>(out var component) && component.enabled && !gameObject.name.EndsWith("-base") && !gameObject.name.EndsWith("-DUPEME") && !gameObject.name.EndsWith("-template"))
			{
				_nameToPrefab[gameObject.name.Replace(" ", "")] = gameObject;
			}
		}
		_prefabs = _nameToPrefab.Values.ToArray();
	}
}
