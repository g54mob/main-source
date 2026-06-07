using System.Linq;
using DV.Common;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.Utils;
using UnityEngine;

[ExecutionOrder(-120)]
public class UserManagerInstantiator : MonoBehaviour
{
	public bool inMemoryTestingMode;

	public UserManager userManagerPrefab;

	private void Awake()
	{
		if ((bool)SingletonBehaviour<UserManager>.Instance)
		{
			Debug.Log("[UserManagerInstantiator] doing nothing, UserManager already exists");
		}
		else
		{
			Debug.Log("[UserManagerInstantiator] instantiating a new UserManager");
			GameObject obj = Object.Instantiate(userManagerPrefab.gameObject);
			Object.DontDestroyOnLoad(obj);
			obj.name = base.name;
			obj.transform.SetSiblingIndex(base.transform.GetSiblingIndex());
			Debug.Log("Checking for save imports...");
			foreach (User user in SingletonBehaviour<UserManager>.Instance.Users)
			{
				int num = SaveGameImporter.CheckForImports(user);
				if (num > 0)
				{
					Debug.Log($"Imported {num} save(s) as sessions for {user.Name}");
				}
				else
				{
					Debug.Log("No new save imports for " + user.Name);
				}
				if (user.GameData["Progression_state"] != null || !user.Sessions.TryGetValue("Career", out var value))
				{
					continue;
				}
				foreach (IGameSession item in value)
				{
					if (item.LatestSave != null)
					{
						item.LatestSave.LoadData();
					}
				}
			}
			Debug.Log("Save importing phase done.");
			ProcessCmdArgs();
		}
		Object.Destroy(base.gameObject);
	}

	private static void ProcessCmdArgs()
	{
		string userOverride = null;
		for (int i = 0; i < Bootstrap.commandLineArgs.Length; i++)
		{
			if (i + 1 < Bootstrap.commandLineArgs.Length && !(Bootstrap.commandLineArgs[i] != "-user"))
			{
				userOverride = Bootstrap.commandLineArgs[i + 1];
				break;
			}
		}
		if (!string.IsNullOrWhiteSpace(userOverride))
		{
			Debug.Log("[UserManagerInstantiator] switching to user '" + userOverride + "' from Bootstrap");
			ushort result;
			User user = ((!ushort.TryParse(userOverride, out result) || result >= SingletonBehaviour<UserManager>.Instance.Users.Count) ? SingletonBehaviour<UserManager>.Instance.Users.FirstOrDefault((User u) => u.Name == userOverride) : SingletonBehaviour<UserManager>.Instance.Users[result]);
			if (user == null)
			{
				Debug.LogError("Failed to find user '" + userOverride + "'! Did you provide a valid name/index?");
			}
			else
			{
				SingletonBehaviour<UserManager>.Instance.SwitchUser(user);
			}
		}
	}
}
