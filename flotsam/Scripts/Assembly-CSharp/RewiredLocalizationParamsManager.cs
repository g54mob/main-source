using I2.Loc;
using UnityEngine;

public class RewiredLocalizationParamsManager : MonoBehaviour, ILocalizationParamsManager
{
	public const string REWIRED_PREFIX = "RWRD:";

	[SerializeField]
	private RewiredGlyphProvider _glyphProvider;

	private void OnEnable()
	{
		LocalizationManager.ParamManagers.Add(this);
	}

	private void OnDisable()
	{
		LocalizationManager.ParamManagers.Remove(this);
	}

	public string GetParameterValue(string param)
	{
		if (param.StartsWith("RWRD:"))
		{
			using ListPool<int>.List list = ListPool<int>.Get();
			param.Replace("RWRD:", string.Empty).SplitInt(',', list);
			if (_glyphProvider.TryGetActionsParameterValue(list, out var value))
			{
				return value;
			}
		}
		return null;
	}
}
