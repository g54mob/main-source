using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Stages;

public class Rune : GameMonoBehaviour
{
	private SpriteRenderer _003CSpriteRenderer_003Ek__BackingField;

	private SpriteAnimation _003CSpriteAnimation_003Ek__BackingField;

	private Tween _003CZTween_003Ek__BackingField;

	private Tween _003CAlphaTween_003Ek__BackingField;

	private float _003CZ_003Ek__BackingField;

	public SpriteRenderer SpriteRenderer
	{
		get
		{
			return _003CSpriteRenderer_003Ek__BackingField;
		}
		set
		{
			_003CSpriteRenderer_003Ek__BackingField = value;
		}
	}

	public SpriteAnimation SpriteAnimation
	{
		get
		{
			return _003CSpriteAnimation_003Ek__BackingField;
		}
		set
		{
			_003CSpriteAnimation_003Ek__BackingField = value;
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
		GameObject gameObject = base.gameObject;
		SpriteRenderer spriteRenderer = ((!gameObject.TryGetComponent<SpriteRenderer>(out var component)) ? gameObject.AddComponent<SpriteRenderer>() : component);
		_003CSpriteRenderer_003Ek__BackingField = spriteRenderer;
		GameObject gameObject2 = base.gameObject;
		SpriteAnimation spriteAnimation = ((!gameObject2.TryGetComponent<SpriteAnimation>(out var component2)) ? gameObject2.AddComponent<SpriteAnimation>() : component2);
		_003CSpriteAnimation_003Ek__BackingField = spriteAnimation;
	}

	public Rune()
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
