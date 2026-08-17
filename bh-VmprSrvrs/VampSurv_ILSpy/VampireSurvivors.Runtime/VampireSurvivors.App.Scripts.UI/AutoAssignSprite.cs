using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.App.Scripts.UI;

public class AutoAssignSprite : MonoBehaviour
{
	private string _SpriteName;

	private string _TextureName;

	private void Start()
	{
		string spriteName = _SpriteName;
		if (_SpriteName == null || spriteName._stringLength <= 0)
		{
			return;
		}
		string textureName = _TextureName;
		if (_TextureName != null && textureName._stringLength > 0)
		{
			Image component = GetComponent<Image>();
			if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
			{
				Sprite sprite = SpriteManager.GetSprite(_SpriteName, _TextureName);
				component.sprite = sprite;
			}
		}
	}

	public AutoAssignSprite()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
