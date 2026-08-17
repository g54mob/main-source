using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors;

public class ReportDeadBodyDisplay : MonoBehaviour
{
	private SpriteRenderer _BubbleSpriteRenderer;

	private SpriteRenderer _SkullSpriteRenderer;

	private SpriteRenderer _Line1Renderer;

	private SpriteRenderer _Line2Renderer;

	private void Awake()
	{
		Sprite sprite = SpriteManager.GetSprite("bubbleSphere", "vfx");
		_BubbleSpriteRenderer.sprite = sprite;
		Sprite sprite2 = SpriteManager.GetSprite("SkullToken", "items");
		_SkullSpriteRenderer.sprite = sprite2;
		Sprite sprite3 = SpriteManager.GetSprite("WhiteLineH", "vfx");
		_Line1Renderer.sprite = sprite3;
		Sprite sprite4 = SpriteManager.GetSprite("WhiteLineH", "vfx");
		_Line2Renderer.sprite = sprite4;
	}

	public ReportDeadBodyDisplay()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
