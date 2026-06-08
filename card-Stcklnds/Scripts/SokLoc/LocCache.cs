using System.Collections.Generic;

public static class LocCache
{
	private const int MAX_CACHE_COUNT = 1000;

	private static Dictionary<LocRequest, string> cache = new Dictionary<LocRequest, string>(new LocRequestComparer());

	private static List<LocRequest> requests = new List<LocRequest>();

	public static string FillInCached(string s, LocParam[] locParams)
	{
		LocRequest locRequest = new LocRequest(s, locParams);
		if (!cache.ContainsKey(locRequest))
		{
			cache[locRequest] = FillIn(locRequest);
			requests.Add(locRequest);
			if (requests.Count >= 1000)
			{
				cache.Remove(requests[0]);
				requests.RemoveAt(0);
			}
		}
		return cache[locRequest];
	}

	private static string FillIn(LocRequest request)
	{
		string text = request.Text;
		LocParam[] array = request.Params;
		for (int i = 0; i < array.Length; i++)
		{
			LocParam locParam = array[i];
			text = text.Replace("[" + locParam.Name + "]", locParam.Value);
		}
		return text;
	}
}
