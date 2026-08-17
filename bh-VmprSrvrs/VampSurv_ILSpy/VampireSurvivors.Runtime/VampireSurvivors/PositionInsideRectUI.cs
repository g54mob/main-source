using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class PositionInsideRectUI : MonoBehaviour
{
	private RectTransform _rectTransform;

	private float _width;

	private float _height;

	private float _xSize;

	private float _ySize;

	private void Awake()
	{
		//IL_001e: Expected F4, but got O
		RectTransform component = GetComponent<RectTransform>();
		_rectTransform = component;
		Vector2 sizeDelta = _rectTransform.sizeDelta;
		_width = (float)sizeDelta;
		float xSize = (float)sizeDelta * 0.5f;
		float num = default(float);
		_height = num;
		float ySize = num * 0.5f;
		_xSize = xSize;
		_ySize = ySize;
	}

	public void PlaceInside(RectTransform target, float x, float y)
	{
		target.SetParent(_rectTransform, worldPositionStays: false);
		bool flag = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)target).m_CachedPtr, ref value);
		Vector2 vector = default(Vector2);
		target.pivot = vector;
		target.anchoredPosition = vector;
	}

	public PositionInsideRectUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
