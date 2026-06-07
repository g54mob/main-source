using UnityEngine;

public static class HazmatCurvesReferences
{
	private static HazmatCurveInfos _hazmatCurveInfos;

	public static HazmatCurveInfos HazmatCurveInfos => GetCurveInfos();

	private static HazmatCurveInfos GetCurveInfos()
	{
		if (_hazmatCurveInfos == null)
		{
			_hazmatCurveInfos = Resources.Load("HazmatCurveInfos") as HazmatCurveInfos;
		}
		return _hazmatCurveInfos;
	}
}
