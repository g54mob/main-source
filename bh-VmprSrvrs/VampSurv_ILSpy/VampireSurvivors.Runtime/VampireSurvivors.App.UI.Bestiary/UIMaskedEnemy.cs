using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.App.UI.Bestiary;

public class UIMaskedEnemy : MonoBehaviour
{
	private Image _Mask;

	public void SetupMask(EnemyType enemyType)
	{
		//IL_0071: Expected O, but got I4
		//IL_0012: Expected O, but got I8
		//IL_002c: Expected O, but got I8
		object obj = enemyType - 190;
		if ((nint)obj <= 12)
		{
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdx_v3+6BFDFE8+v38 @ rax_v2*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ rcx_v6 (should have been resolved before IL gen)");
		}
		Sprite sprite = SpriteManager.GetSprite("", "enemies2");
		_Mask.sprite = sprite;
	}

	public UIMaskedEnemy()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
