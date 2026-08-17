using System;
using System.Collections.Generic;
using Coherence.Cloud;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;

namespace VampireSurvivors.UI;

public class OnlineDLCSection : MonoBehaviour
{
	private List<OnlineDLCIcon> _OnlineDLCIcons;

	private GameObject _DLCIconContainer;

	private OnlineDLCIcon _DLCIconPrefab;

	private GameObject _DLCInfoContainer;

	private TextMeshProUGUI _DLCInfoTitle;

	private TextMeshProUGUI _DLCInfoMessage;

	private bool _isPopulated;

	private Dictionary<LobbyPlayer, List<DlcType>> _playerOwnedDLCs;

	private List<DlcType> _availableDLCs;

	private void OnEnable()
	{
		Populate();
		_DLCInfoContainer.SetActive(value: false);
	}

	private void Populate()
	{
		if (_isPopulated)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186B58C00");
		Dictionary<DlcType, DlcData>.Enumerator enumerator = default(Dictionary<DlcType, DlcData>.Enumerator);
		if (enumerator.MoveNext())
		{
			GameObject dLCIconContainer = _DLCIconContainer;
			if ((object)_DLCIconContainer != null)
			{
				Transform parent = _DLCIconContainer.transform;
				OnlineDLCIcon onlineDLCIcon = UnityEngine.Object.Instantiate(_DLCIconPrefab, parent);
				bool flag = (object)onlineDLCIcon == null;
				dLCIconContainer = (GameObject)(object)_DLCIconPrefab;
				if (!flag)
				{
					onlineDLCIcon.DlcType = DlcType.Moonspell;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
					DlcType dlcType = DlcType.Moonspell;
					dLCIconContainer = (GameObject)(object)onlineDLCIcon.Image;
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		_isPopulated = true;
	}

	public void UpdateUI(List<DlcType> availableDLCs, Dictionary<LobbyPlayer, List<DlcType>> playerOwnedDLCs)
	{
		//IL_002c: Expected O, but got I4
		Debug.Log("Update DLC UI");
		_playerOwnedDLCs = playerOwnedDLCs;
		_availableDLCs = availableDLCs;
		List<OnlineDLCIcon>.Enumerator enumerator = default(List<OnlineDLCIcon>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<DlcType> availableDLCs2 = _availableDLCs;
			throw new NullReferenceException();
		}
	}

	public void UpdateDlcInfoPanel()
	{
		//IL_002c: Expected I, but got O
		//IL_004c: Expected I, but got O
		if (_OnlineDLCIcons != null)
		{
			List<OnlineDLCIcon>.Enumerator enumerator = default(List<OnlineDLCIcon>.Enumerator);
			if (enumerator.MoveNext())
			{
				EventSystem current = EventSystem.current;
				bool flag = (object)current == null;
				nint num = unchecked((nint)null);
				if (!flag)
				{
					GameObject currentSelected = current.m_CurrentSelected;
					num = unchecked((nint)null);
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			if ((object)_DLCInfoContainer != null)
			{
				_DLCInfoContainer.SetActive(value: false);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void PopulateInfoPanel(DlcType dlcType)
	{
		//IL_002e: Expected I, but got O
		//IL_0086: Expected I, but got O
		//IL_00c6: Expected I, but got O
		//IL_0109: Expected O, but got I
		//IL_0144: Expected I, but got O
		//IL_015d: Expected I, but got O
		//IL_035c: Expected I, but got O
		//IL_01fc: Expected I, but got O
		//IL_021e: Expected I, but got O
		//IL_022c: Expected I, but got O
		//IL_045c: Expected I, but got O
		//IL_0249: Expected I, but got O
		TextMeshProUGUI dLCInfoTitle = _DLCInfoTitle;
		nint num = (nint)typeof(DlcSystem);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v6 (Il2CppClass<VampireSurvivors.Framework.DLC.DlcSystem>)+B8]");
		nint num2 = 0;
		DlcCatalog dlcCatalog = DlcSystem._dlcCatalog;
		if ((object)DlcSystem._dlcCatalog != null)
		{
			bool flag = dlcCatalog._DlcData == null;
			num2 = (nint)dlcCatalog._DlcData;
			if (!flag)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)dlcCatalog._DlcData).get_Item((System.Int32Enum)dlcType);
				bool flag2 = obj == null;
				num2 = (nint)dlcCatalog._DlcData;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rax_v13 (System.Object)+20]");
					bool applyParameters = default(bool);
					GameObject localParametersRoot = default(GameObject);
					string overrideLanguage = default(string);
					bool allowLocalizedParameters = default(bool);
					string translation = LocalizationManager.GetTranslation((string)0, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
					bool flag3 = (object)_DLCInfoTitle == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rax_v13 (System.Object)+20]");
					num2 = 0;
					if (!flag3)
					{
						nint num3 = (nint)dLCInfoTitle;
						_DLCInfoTitle.text = translation;
						num2 = (nint)_availableDLCs;
						if (_availableDLCs != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99BA0");
							object obj2 = default(object);
							if (obj2 == null)
							{
								string translation2 = LocalizationManager.GetTranslation("onlineLang/DLCNotOwned", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
								Dictionary<LobbyPlayer, List<DlcType>> playerOwnedDLCs = _playerOwnedDLCs;
								bool flag4 = _playerOwnedDLCs == null;
								num2 = unchecked((nint)"onlineLang/DLCNotOwned");
								if (!flag4)
								{
									LobbyPlayer playerOwnedDLCs2 = (LobbyPlayer)_playerOwnedDLCs;
									nint num4 = unchecked((nint)null);
									nint num5 = 2;
									nint num6 = unchecked((nint)null);
									string text = translation2;
									Dictionary<LobbyPlayer, List<DlcType>>.Enumerator enumerator = default(Dictionary<LobbyPlayer, List<DlcType>>.Enumerator);
									if (enumerator.MoveNext())
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
										num2 = unchecked((nint)null);
										throw new NullReferenceException();
									}
									num2 = (nint)_DLCInfoMessage;
									if ((object)_DLCInfoMessage != null)
									{
										DlcCatalog dlcCatalog2 = DlcSystem._dlcCatalog;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v810 @ rax_v30 (VampireSurvivors.Framework.DLC.DlcCatalog)+558] (should have been resolved before IL gen)");
										return;
									}
								}
							}
							else
							{
								string translation3 = LocalizationManager.GetTranslation("onlineLang/DLCOwned", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
								bool flag5 = (object)_DLCInfoMessage == null;
								num2 = unchecked((nint)"onlineLang/DLCOwned");
								if (!flag5)
								{
									_DLCInfoMessage.text = translation3;
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void HideInfoPanel()
	{
		_DLCInfoContainer.SetActive(value: false);
	}

	public OnlineDLCSection()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
