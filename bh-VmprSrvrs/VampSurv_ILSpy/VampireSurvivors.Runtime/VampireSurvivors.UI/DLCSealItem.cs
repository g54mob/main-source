using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.UI;

public class DLCSealItem : MonoBehaviour
{
	private TextMeshProUGUI _Name;

	private Image _ToggleIcon;

	private bool _isBanished;

	private MegaSealPanel _megaSealPanel;

	private ContentGroupType _type;

	public void SetDLCData(MegaSealPanel seal, ContentGroupType t, bool isBanished)
	{
		_isBanished = isBanished;
		_megaSealPanel = seal;
		_type = t;
		string localizedName = ContentGroupMethods.GetLocalizedName(t);
		_Name.text = localizedName;
		ApplySetting();
		Button component = GetComponent<Button>();
		UnityAction call = Toggle;
		component.m_OnClick.AddListener(call);
	}

	public void RefreshText()
	{
		string localizedName = ContentGroupMethods.GetLocalizedName(_type);
		_Name.text = localizedName;
	}

	private void Toggle()
	{
		bool isBanished = !_isBanished;
		_isBanished = isBanished;
		ApplySetting();
	}

	private void ApplySetting()
	{
		string spriteName = (_isBanished ? "no16" : "yes16");
		Sprite sprite = SpriteManager.GetSprite(spriteName, "ui");
		_ToggleIcon.sprite = sprite;
		bool updatePage = default(bool);
		_megaSealPanel.SetBanished(_type, _isBanished, playSound: true, updatePage);
	}

	public void SetUnBanished()
	{
		_isBanished = false;
		ApplySetting();
	}

	public DLCSealItem()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
