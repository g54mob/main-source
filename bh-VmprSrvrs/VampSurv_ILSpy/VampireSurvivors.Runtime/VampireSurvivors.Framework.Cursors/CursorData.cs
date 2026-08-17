using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Framework.Cursors;

public class CursorData
{
	public string AnimationName;

	public int AnimationStartingFrame;

	public int AnimationFramesCount;

	public int AnimationFrameRate;

	public Sprite CursorSprite;

	public Sprite IconSprite;

	public string CursorColorHex;

	public float CursorAlpha;

	public float CursorScale;

	public bool OnScreenPointAt;

	public float IconAlpha = 1f;

	public Vector3 OnScreenCursorOffset;

	public string Text;

	private float _cursorProportionOfScreenFromCenter = 0.45f;

	public CursorIndicator _CursorInstanceReference;

	public float CursorProportionOfScreenFromCenter
	{
		get
		{
			//IL_0018: Invalid comparison between F4 and O
			//IL_0047: Invalid comparison between O and F4
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1851B10F0");
			object obj = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1851B10F0");
				object obj2 = default(object);
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.57f))
				{
					return 0.38f;
				}
			}
			return _cursorProportionOfScreenFromCenter;
		}
		set
		{
			_cursorProportionOfScreenFromCenter = value;
		}
	}
}
