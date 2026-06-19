using System.Collections.Generic;
using Aggro.Core;

public static class DevCmdUtil
{
	public static bool TryGetEntityFromDevCmdName(string devCmdName, out Entity entity)
	{
		if (!GameUtil.isReady || string.IsNullOrEmpty(devCmdName))
		{
			entity = Entity.invalid;
			return false;
		}
		if (!int.TryParse(devCmdName.Substring(devCmdName.LastIndexOf('-') + 1), out var result))
		{
			entity = Entity.invalid;
			return false;
		}
		entity = new Entity(result, GameUtil.entityManager.GetIndexVersion(result), GameUtil.world);
		return entity.Exists();
	}

	public static string[] GetEntityNames<T>() where T : class
	{
		if (!GameUtil.isReady)
		{
			return new string[0];
		}
		ObjectQuery<T> objectQuery = GameUtil.entityManager.CreateObjectQuery<T>();
		objectQuery.Run();
		List<string> list = new List<string>();
		for (int i = 0; i < objectQuery.count; i++)
		{
			list.Add(objectQuery.GetEntity(i).devCmdName);
		}
		return list.ToArray();
	}
}
