using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.UI;

public class ReplaceSpriteInAdventure : MonoBehaviour
{
	private string SpriteToReplaceWith;

	private Sprite _baseSprite;

	private Image _image;

	private void Awake()
	{
		Image component = GetComponent<Image>();
		_image = component;
		Image image = _image;
		_baseSprite = image.m_Sprite;
	}

	private void OnEnable()
	{
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			_image.sprite = _baseSprite;
			return;
		}
		Sprite sprite = SpriteManager.GetSprite(SpriteToReplaceWith);
		_image.sprite = sprite;
	}

	public ReplaceSpriteInAdventure()
	{
		//IL_0058: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A349D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SpriteToReplaceWith = "AdventurePanel";
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
