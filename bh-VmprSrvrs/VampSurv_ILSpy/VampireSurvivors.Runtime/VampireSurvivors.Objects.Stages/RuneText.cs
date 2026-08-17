using Cpp2ILInjected;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace VampireSurvivors.Objects.Stages;

public class RuneText : GameMonoBehaviour
{
	private TextMeshPro _003CTextRenderer_003Ek__BackingField;

	private Tween _003CZTween_003Ek__BackingField;

	private Tween _003CAlphaTween_003Ek__BackingField;

	private float _003CZ_003Ek__BackingField;

	public TextMeshPro TextRenderer
	{
		get
		{
			return _003CTextRenderer_003Ek__BackingField;
		}
		set
		{
			_003CTextRenderer_003Ek__BackingField = value;
		}
	}

	public Tween ZTween
	{
		get
		{
			return _003CZTween_003Ek__BackingField;
		}
		set
		{
			_003CZTween_003Ek__BackingField = value;
		}
	}

	public Tween AlphaTween
	{
		get
		{
			return _003CAlphaTween_003Ek__BackingField;
		}
		set
		{
			_003CAlphaTween_003Ek__BackingField = value;
		}
	}

	public float Z
	{
		get
		{
			return _003CZ_003Ek__BackingField;
		}
		set
		{
			_003CZ_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		TextMeshPro componentInChildren = GetComponentInChildren<TextMeshPro>();
		_003CTextRenderer_003Ek__BackingField = componentInChildren;
	}

	public RuneText()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
