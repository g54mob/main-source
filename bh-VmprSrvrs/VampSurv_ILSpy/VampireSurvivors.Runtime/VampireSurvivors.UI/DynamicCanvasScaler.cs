using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class DynamicCanvasScaler : MonoBehaviour
{
	private Vector2 _ReferenceResolution;

	private CanvasScaler _scaler;

	private float _referenceAspect;

	private Vector2 _CurrentResolution;

	private float _currentAspect;

	private float _panelWidth;

	private float _lerp;

	private void Start()
	{
		CanvasScaler component = GetComponent<CanvasScaler>();
		_scaler = component;
		Vector2 referenceResolution = _ReferenceResolution;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.DynamicCanvasScaler)+24]");
		if ((nint)referenceResolution <= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.DynamicCanvasScaler)+24]");
			float referenceAspect = 0f / (float)_ReferenceResolution;
			_referenceAspect = referenceAspect;
		}
		else
		{
			float num = (float)_ReferenceResolution;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.DynamicCanvasScaler)+24]");
			float referenceAspect2 = num / 0f;
			_referenceAspect = referenceAspect2;
		}
	}

	private void Update()
	{
		//IL_004c: Expected O, but got I4
		//IL_005b: Expected O, but got I4
		Vector2 vector = (Vector2)Screen.width;
		object obj = Screen.height;
		_CurrentResolution = vector;
		float currentAspect = (float)vector / (float)obj;
		_currentAspect = currentAspect;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector))
		{
			float num = _panelWidth / (float)_CurrentResolution;
			CanvasScaler scaler = _scaler;
			_lerp = num;
			scaler.m_MatchWidthOrHeight = num;
		}
	}

	public DynamicCanvasScaler()
	{
		//IL_000b: Expected O, but got I4
		//IL_0031: Expected I, but got O
		_ReferenceResolution = (Vector2)1156579328;
		_ = 1150681088;
		_panelWidth = 850f;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
