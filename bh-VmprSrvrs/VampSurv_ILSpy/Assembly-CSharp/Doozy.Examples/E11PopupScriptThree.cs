using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Examples;

public class E11PopupScriptThree : MonoBehaviour
{
	public enum PopupType
	{
		Error,
		Info,
		Warning,
		Whatever
	}

	public string PopupName;

	public Sprite ErrorSprite;

	public string ErrorTitle;

	public string ErrorMessage;

	public Color ErrorTextColor;

	public Sprite InfoSprite;

	public string InfoTitle;

	public string InfoMessage;

	public Color InfoTextColor;

	public Sprite WarningSprite;

	public string WarningTitle;

	public string WarningMessage;

	public Color WarningTextColor;

	public Sprite WhateverSprite;

	public string WhateverTitle;

	public string WhateverMessage;

	public Color WhateverTextColor;

	private UIPopup m_popup;

	public void ShowPopup(PopupType popupType)
	{
		//IL_03ed: Expected O, but got I4
		//IL_0baf: Expected I4, but got O
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Expected O, but got Unknown
		//IL_0be4: Expected I4, but got O
		//IL_0951: Expected I4, but got O
		//IL_0c28: Expected I4, but got O
		//IL_0986: Expected I4, but got O
		//IL_06f3: Expected I4, but got O
		//IL_0e50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e55: Expected O, but got Unknown
		//IL_0e5e: Expected I4, but got O
		//IL_0c5c: Expected I4, but got O
		//IL_09ca: Expected I4, but got O
		//IL_0728: Expected I4, but got O
		//IL_0495: Expected I4, but got O
		//IL_09fe: Expected I4, but got O
		//IL_076c: Expected I4, but got O
		//IL_0ca0: Expected I4, but got O
		//IL_04ca: Expected I4, but got O
		//IL_07a0: Expected I4, but got O
		//IL_0ce2: Expected I4, but got O
		//IL_0a42: Expected I4, but got O
		//IL_050e: Expected I4, but got O
		//IL_0cfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cff: Expected O, but got Unknown
		//IL_0d3f: Expected I4, but got O
		//IL_0a84: Expected I4, but got O
		//IL_07e4: Expected I4, but got O
		//IL_0542: Expected I4, but got O
		//IL_0d57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5c: Expected O, but got Unknown
		//IL_0d92: Expected I4, but got O
		//IL_0a9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa1: Expected O, but got Unknown
		//IL_0ae1: Expected I4, but got O
		//IL_0826: Expected I4, but got O
		//IL_0586: Expected I4, but got O
		//IL_0db2: Expected I4, but got O
		//IL_0af9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afe: Expected O, but got Unknown
		//IL_0b34: Expected I4, but got O
		//IL_083e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0843: Expected O, but got Unknown
		//IL_0883: Expected I4, but got O
		//IL_0e71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e76: Expected O, but got Unknown
		//IL_05c8: Expected I4, but got O
		//IL_0b54: Expected I4, but got O
		//IL_089b: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a0: Expected O, but got Unknown
		//IL_08d6: Expected I4, but got O
		//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Expected O, but got Unknown
		//IL_0625: Expected I4, but got O
		//IL_08f6: Expected I4, but got O
		//IL_063d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0642: Expected O, but got Unknown
		//IL_0678: Expected I4, but got O
		//IL_0698: Expected I4, but got O
		UIPopup popup = UIPopupManager.GetPopup(PopupName);
		m_popup = popup;
		UIPopup popup2 = m_popup;
		if ((object)m_popup == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdi_v2 (Doozy.Engine.UI.UIPopup)+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		UIPopup popup3 = m_popup;
		bool flag = (object)m_popup == null;
		PopupType popupType2 = popupType;
		Text component2;
		object obj4 = default(object);
		if (!flag)
		{
			UIPopupContentReferences data = popup3.Data;
			bool flag2 = popup3.Data == null;
			popupType2 = popupType;
			if (!flag2)
			{
				List<Image> images = data.Images;
				bool flag3 = data.Images == null;
				popupType2 = popupType;
				if (!flag3)
				{
					if (images._size <= 0)
					{
						goto IL_0e30;
					}
					Image[] items = images._items;
					bool flag4 = images._items == null;
					popupType2 = popupType;
					if (!flag4)
					{
						UIPopup popup4 = m_popup;
						UIPopupContentReferences data2 = popup4.Data;
						bool flag5 = popup4.Data == null;
						popupType2 = popupType;
						if (!flag5)
						{
							List<GameObject> labels = data2.Labels;
							bool flag6 = data2.Labels == null;
							popupType2 = popupType;
							if (!flag6)
							{
								if (labels._size <= 0)
								{
									goto IL_0e30;
								}
								GameObject[] items2 = labels._items;
								bool flag7 = labels._items == null;
								popupType2 = popupType;
								if (!flag7)
								{
									bool flag8 = (object)items2[0] == null;
									popupType2 = popupType;
									if (!flag8)
									{
										Text component = items2[0].GetComponent<Text>();
										UIPopup popup5 = m_popup;
										bool flag9 = (object)m_popup == null;
										popupType2 = popupType;
										if (!flag9)
										{
											UIPopupContentReferences data3 = popup5.Data;
											bool flag10 = popup5.Data == null;
											popupType2 = popupType;
											if (!flag10)
											{
												List<GameObject> labels2 = data3.Labels;
												bool flag11 = data3.Labels == null;
												popupType2 = popupType;
												if (!flag11)
												{
													if (labels2._size <= 1)
													{
														goto IL_0e30;
													}
													GameObject[] items3 = labels2._items;
													bool flag12 = labels2._items == null;
													popupType2 = popupType;
													if (!flag12)
													{
														bool flag13 = (object)items3[1] == null;
														popupType2 = popupType;
														if (!flag13)
														{
															component2 = items3[1].GetComponent<Text>();
															bool flag14 = popupType == PopupType.Error;
															if (!flag14)
															{
																object obj = popupType - 1;
																if (!flag14)
																{
																	object obj2 = obj - 1;
																	if (!flag14)
																	{
																		bool flag15 = (nint)obj2 != 1;
																		popupType2 = popupType;
																		if (flag15)
																		{
																			object obj3 = obj4 + 40;
																			object actualValue = (PopupType)obj3;
																			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("popupType", actualValue, null);
																			throw ex;
																		}
																		UIPopup popup6 = m_popup;
																		bool flag16 = (object)m_popup == null;
																		popupType2 = popupType;
																		if (!flag16)
																		{
																			Sprite[] array = new Sprite[1];
																			bool flag17 = array == null;
																			popupType2 = (PopupType)array;
																			if (!flag17)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																				bool flag18 = popup6.Data == null;
																				popupType2 = (PopupType)array;
																				if (!flag18)
																				{
																					popup6.Data.SetImagesSprites(array);
																					UIPopup popup7 = m_popup;
																					bool flag19 = (object)m_popup == null;
																					popupType2 = (PopupType)array;
																					if (!flag19)
																					{
																						string[] array2 = new string[2];
																						bool flag20 = array2 == null;
																						popupType2 = (PopupType)array2;
																						if (!flag20)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																							bool flag21 = popup7.Data == null;
																							popupType2 = (PopupType)array2;
																							if (!flag21)
																							{
																								popup7.Data.SetLabelsTexts(array2);
																								bool flag22 = (object)items[0] == null;
																								popupType2 = (PopupType)array2;
																								if (!flag22)
																								{
																									Color color = (Color)(obj4 - 24);
																									Color whateverTextColor = WhateverTextColor;
																									_ = WhateverTextColor;
																									items[0].color = color;
																									bool flag23 = (object)component == null;
																									popupType2 = (PopupType)array2;
																									if (!flag23)
																									{
																										Color color2 = (Color)(obj4 - 24);
																										whateverTextColor = WhateverTextColor;
																										_ = WhateverTextColor;
																										component.color = color2;
																										bool flag24 = (object)component2 == null;
																										popupType2 = (PopupType)array2;
																										if (!flag24)
																										{
																											whateverTextColor = WhateverTextColor;
																											popupType2 = (PopupType)array2;
																											goto IL_0e67;
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																	else
																	{
																		UIPopup popup8 = m_popup;
																		bool flag25 = (object)m_popup == null;
																		popupType2 = popupType;
																		if (!flag25)
																		{
																			Sprite[] array3 = new Sprite[1];
																			bool flag26 = array3 == null;
																			popupType2 = (PopupType)array3;
																			if (!flag26)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																				bool flag27 = popup8.Data == null;
																				popupType2 = (PopupType)array3;
																				if (!flag27)
																				{
																					popup8.Data.SetImagesSprites(array3);
																					UIPopup popup9 = m_popup;
																					bool flag28 = (object)m_popup == null;
																					popupType2 = (PopupType)array3;
																					if (!flag28)
																					{
																						string[] array4 = new string[2];
																						bool flag29 = array4 == null;
																						popupType2 = (PopupType)array4;
																						if (!flag29)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																							bool flag30 = popup9.Data == null;
																							popupType2 = (PopupType)array4;
																							if (!flag30)
																							{
																								popup9.Data.SetLabelsTexts(array4);
																								bool flag31 = (object)items[0] == null;
																								popupType2 = (PopupType)array4;
																								if (!flag31)
																								{
																									Color color3 = (Color)(obj4 - 24);
																									Color whateverTextColor = WarningTextColor;
																									_ = WarningTextColor;
																									items[0].color = color3;
																									bool flag32 = (object)component == null;
																									popupType2 = (PopupType)array4;
																									if (!flag32)
																									{
																										Color color4 = (Color)(obj4 - 24);
																										whateverTextColor = WarningTextColor;
																										_ = WarningTextColor;
																										component.color = color4;
																										bool flag33 = (object)component2 == null;
																										popupType2 = (PopupType)array4;
																										if (!flag33)
																										{
																											whateverTextColor = WarningTextColor;
																											popupType2 = (PopupType)array4;
																											goto IL_0e67;
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
																else
																{
																	UIPopup popup10 = m_popup;
																	bool flag34 = (object)m_popup == null;
																	popupType2 = popupType;
																	if (!flag34)
																	{
																		Sprite[] array5 = new Sprite[1];
																		bool flag35 = array5 == null;
																		popupType2 = (PopupType)array5;
																		if (!flag35)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																			bool flag36 = popup10.Data == null;
																			popupType2 = (PopupType)array5;
																			if (!flag36)
																			{
																				popup10.Data.SetImagesSprites(array5);
																				UIPopup popup11 = m_popup;
																				bool flag37 = (object)m_popup == null;
																				popupType2 = (PopupType)array5;
																				if (!flag37)
																				{
																					string[] array6 = new string[2];
																					bool flag38 = array6 == null;
																					popupType2 = (PopupType)array6;
																					if (!flag38)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																						bool flag39 = popup11.Data == null;
																						popupType2 = (PopupType)array6;
																						if (!flag39)
																						{
																							popup11.Data.SetLabelsTexts(array6);
																							bool flag40 = (object)items[0] == null;
																							popupType2 = (PopupType)array6;
																							if (!flag40)
																							{
																								Color color5 = (Color)(obj4 - 24);
																								Color whateverTextColor = InfoTextColor;
																								_ = InfoTextColor;
																								items[0].color = color5;
																								bool flag41 = (object)component == null;
																								popupType2 = (PopupType)array6;
																								if (!flag41)
																								{
																									Color color6 = (Color)(obj4 - 24);
																									whateverTextColor = InfoTextColor;
																									_ = InfoTextColor;
																									component.color = color6;
																									bool flag42 = (object)component2 == null;
																									popupType2 = (PopupType)array6;
																									if (!flag42)
																									{
																										whateverTextColor = InfoTextColor;
																										popupType2 = (PopupType)array6;
																										goto IL_0e67;
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
															else
															{
																UIPopup popup12 = m_popup;
																bool flag43 = (object)m_popup == null;
																popupType2 = popupType;
																if (!flag43)
																{
																	Sprite[] array7 = new Sprite[1];
																	bool flag44 = array7 == null;
																	popupType2 = (PopupType)array7;
																	if (!flag44)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		bool flag45 = popup12.Data == null;
																		popupType2 = (PopupType)array7;
																		if (!flag45)
																		{
																			popup12.Data.SetImagesSprites(array7);
																			UIPopup popup13 = m_popup;
																			bool flag46 = (object)m_popup == null;
																			popupType2 = (PopupType)array7;
																			if (!flag46)
																			{
																				string[] array8 = new string[2];
																				bool flag47 = array8 == null;
																				popupType2 = (PopupType)array8;
																				if (!flag47)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																					bool flag48 = popup13.Data == null;
																					popupType2 = (PopupType)array8;
																					if (!flag48)
																					{
																						popup13.Data.SetLabelsTexts(array8);
																						bool flag49 = (object)items[0] == null;
																						popupType2 = (PopupType)array8;
																						if (!flag49)
																						{
																							Color color7 = (Color)(obj4 - 24);
																							Color whateverTextColor = ErrorTextColor;
																							_ = ErrorTextColor;
																							items[0].color = color7;
																							bool flag50 = (object)component == null;
																							popupType2 = (PopupType)array8;
																							if (!flag50)
																							{
																								Color color8 = (Color)(obj4 - 24);
																								whateverTextColor = ErrorTextColor;
																								_ = ErrorTextColor;
																								component.color = color8;
																								bool flag51 = (object)component2 == null;
																								popupType2 = (PopupType)array8;
																								if (!flag51)
																								{
																									whateverTextColor = ErrorTextColor;
																									popupType2 = (PopupType)array8;
																									goto IL_0e67;
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0dcc;
		IL_0e30:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0dcc:
		throw new NullReferenceException();
		IL_0e67:
		Color color9 = (Color)(obj4 - 24);
		component2.color = color9;
		if ((object)m_popup != null)
		{
			m_popup.Show();
			return;
		}
		goto IL_0dcc;
	}

	public void ShowInfoPopup()
	{
		ShowPopup(PopupType.Info);
	}

	public void ShowWarningPopup()
	{
		ShowPopup(PopupType.Warning);
	}

	public void ShowErrorPopup()
	{
		ShowPopup(PopupType.Error);
	}

	public void ShowWhateverPopup()
	{
		ShowPopup(PopupType.Whatever);
	}

	public E11PopupScriptThree()
	{
		//IL_00f4: Expected O, but got I
		//IL_0116: Expected O, but got I
		//IL_0138: Expected O, but got I
		//IL_0045: Expected O, but got I
		//IL_00aa: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996CA43]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PopupName = "Popup3";
		ErrorTitle = "Error";
		ErrorMessage = "This is an ERROR message";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
		ErrorTextColor = (Color)0;
		InfoTitle = "Info";
		InfoMessage = "This is an INFO message";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A124D0]");
		InfoTextColor = (Color)0;
		WarningTitle = "Warning";
		WarningMessage = "This is a WARNING message";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12030]");
		WarningTextColor = (Color)0;
		WhateverTitle = "Whatever";
		WhateverMessage = "Hello world! WHATEVER!!! :)";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FC0]");
		WhateverTextColor = (Color)0;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ rcx_v13 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
