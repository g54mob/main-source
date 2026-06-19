using System.Collections.Generic;
using Aggro.Core;
using DevCmdLine;
using Unity.Collections;
using UnityEngine;

public static class BoxDevCmds
{
	[DevCmd("box", "Interact with boxes.\r\n\r\nUsage:\r\n    box [<substring>]\r\n        Prints all currently known boxes. If substring is supplied then only boxes\r\n        who's names contain the substring (case insensitive).\r\n\r\n    box -destroy <box>\r\n        Destroys the supplied box.\r\n\r\n    box -camera <box>\r\n        Locks the camera to the box.\r\n\r\n    box -cameraunlock\r\n        Unlocks the camera from a box.\r\n\r\n    box -camerafix", new string[] { "destroy", "camera", "cameraunlock", "camerafix" })]
	[DevCmdVerify("^$")]
	[DevCmdVerify("^[\\S]+$")]
	[DevCmdVerify("^-destroy [\\S]+$")]
	[DevCmdVerify("^-camera [\\S]+$")]
	[DevCmdVerify("^-cameraunlock$")]
	[DevCmdVerify("^-camerafix")]
	private static void BoxDevCmd(DevCmdArg[] args)
	{
		if (!GameUtil.isReady)
		{
			Debug.LogWarning("Entity world is not ready!");
			return;
		}
		if (args.Length == 0 || args[0].name == "")
		{
			List<string> list = new List<string>(DevCmdUtil.GetEntityNames<Grabbable>());
			if (args.Length != 0)
			{
				string value = args[0].value.ToLowerInvariant();
				for (int i = 0; i < list.Count; i++)
				{
					if (!list[i].ToLowerInvariant().Contains(value))
					{
						list.RemoveAtSwapBack(i);
						i--;
					}
				}
			}
			list.Sort();
			string text = $"Box Count: {list.Count}\n";
			for (int j = 0; j < list.Count; j++)
			{
				text = text + "  " + list[j] + "\n";
			}
			Debug.Log(text);
			return;
		}
		Entity entity;
		switch (args[0].name)
		{
		case "camera":
			if (DevCmdUtil.TryGetEntityFromDevCmdName(args[0].value, out entity))
			{
				if (AggroManagerBase<CameraController>.ManagerExists())
				{
					AggroManagerBase<CameraController>.instance.LockToEntity(entity);
				}
				else
				{
					Debug.LogWarning("Camera Controller doesn't exist!");
				}
			}
			else
			{
				Debug.LogWarning("Could not find a box with name! (" + args[0].value + ")");
			}
			break;
		case "destroy":
			if (DevCmdUtil.TryGetEntityFromDevCmdName(args[0].value, out entity))
			{
				EntityUtil.Destroy(entity);
			}
			else
			{
				Debug.LogWarning("Could not find a box with name! (" + args[0].value + ")");
			}
			break;
		case "cameraunlock":
			if (AggroManagerBase<CameraController>.ManagerExists())
			{
				AggroManagerBase<CameraController>.instance.FollowPlayer();
			}
			else
			{
				Debug.LogWarning("Camera Controller doesn't exist!");
			}
			break;
		case "camerafix":
			if (AggroManagerBase<CameraController>.ManagerExists() && AggroManagerBase<NavAreaManager>.ManagerExists())
			{
				AggroManagerBase<CameraController>.instance.SetToPosition(AggroManagerBase<NavAreaManager>.instance.debugFixPos);
			}
			else
			{
				Debug.LogWarning("Camera Controller or Nav Area Manager doesn't exist!");
			}
			break;
		default:
			Debug.LogWarning("Unknown argument! (" + args[0].name + ")");
			break;
		}
	}

	[DevCmdCompleteFunction("box", "camera", DevCmdCompleteFlags.Sort)]
	[DevCmdCompleteFunction("box", "destroy", DevCmdCompleteFlags.Sort)]
	private static string[] HealthBoxDevComplete()
	{
		return DevCmdUtil.GetEntityNames<Grabbable>();
	}
}
