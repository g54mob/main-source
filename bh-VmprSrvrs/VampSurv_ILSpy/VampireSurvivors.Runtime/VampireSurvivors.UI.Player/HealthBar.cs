using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI.Player;

public class HealthBar : MonoBehaviour
{
	private Image _HealthBar;

	private Image _HealthBarFill;

	private VampireSurvivors.Objects.Characters.CharacterController _character;

	private void Awake()
	{
		VampireSurvivors.Objects.Characters.CharacterController componentInParent = GetComponentInParent<VampireSurvivors.Objects.Characters.CharacterController>();
		_character = componentInParent;
		Sprite unpackedSprite = SpriteManager.GetUnpackedSprite("UISquare");
		_HealthBarFill.sprite = unpackedSprite;
		_HealthBar.sprite = unpackedSprite;
	}

	private void Update()
	{
		//IL_0040: Expected F4, but got I4
		VampireSurvivors.Objects.Characters.CharacterController character = _character;
		float num = _character.MaxHp();
		object obj = default(object);
		bool flag = obj == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E01B0Ch\"");
		float fillAmount = 0f;
		if (!flag)
		{
			float num2 = _character.MaxHp();
			fillAmount = character._currentHp / (float)obj;
		}
		_HealthBarFill.fillAmount = fillAmount;
	}

	public void ToggleVisible(bool visible)
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(visible);
	}

	public HealthBar()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
