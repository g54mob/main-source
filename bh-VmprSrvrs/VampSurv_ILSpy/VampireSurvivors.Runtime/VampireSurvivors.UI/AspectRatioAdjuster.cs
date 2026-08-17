using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;

namespace VampireSurvivors.UI;

public class AspectRatioAdjuster : MonoBehaviour
{
	private AspectRatioFitter _fitter;

	private bool isPortrait;

	private void OnEnable()
	{
		Action<Vector2> action = null;
		((AspectRatioAdjuster)(object)action).OnResolutionChanged((Vector2)this);
		ResolutionManager.OnResolutionChange += action;
		Apply();
	}

	private void OnDisable()
	{
		Action<Vector2> action = null;
		((AspectRatioAdjuster)(object)action).OnResolutionChanged((Vector2)this);
		ResolutionManager.OnResolutionChange -= action;
	}

	public void OnResolutionChanged(Vector2 newRes)
	{
		Apply();
	}

	private void Apply()
	{
		//IL_0064: Expected O, but got I4
		//IL_00e1: Expected O, but got I4
		//IL_00b1: Expected O, but got I4
		//IL_0194: Expected O, but got I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		Debug.Log("Applying");
		object obj = Screen.height;
		object obj2 = Screen.width;
		object obj3 = obj - obj2;
		object obj4 = obj ^ obj2;
		object obj5 = obj ^ obj3;
		object obj6 = obj4 & obj5;
		bool flag = (nint)obj6 < 0;
		bool flag2 = (nint)obj3 < 0;
		bool flag3 = obj3 == null;
		bool flag4 = flag2 == flag;
		bool flag5 = !flag3;
		bool flag6 = flag5 & flag4;
		isPortrait = flag6;
		AspectRatioFitter component = GetComponent<AspectRatioFitter>();
		_fitter = component;
		AspectRatioFitter component3;
		if (!isPortrait)
		{
			Component component2 = (Component)(_fitter + 36);
			component3 = component2.GetComponent<AspectRatioFitter>();
		}
		else
		{
			object obj7 = Screen.width;
			object obj8 = Screen.height;
			Component component4 = (Component)(_fitter + 36);
			component3 = component4.GetComponent<AspectRatioFitter>();
		}
		if ((object)component3 != null)
		{
			_fitter.UpdateRect();
		}
	}

	public AspectRatioAdjuster()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
