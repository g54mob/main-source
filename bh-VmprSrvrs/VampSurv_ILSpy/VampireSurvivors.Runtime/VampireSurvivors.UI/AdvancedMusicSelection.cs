using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI;

public class AdvancedMusicSelection : BasePopup
{
	public delegate void OnSelectionChanged();

	private enum NavigationPhase
	{
		TRACKS,
		SETTINGS,
		UNIVERSAL
	}

	private sealed class _003C_003Ec__DisplayClass60_0
	{
		public AdvancedMusicSelection _003C_003E4__this;

		public SoundManager.SoundConfig soundConfig;

		internal void _003CPlayAtSpeed_003Eb__0()
		{
			AdvancedMusicSelection advancedMusicSelection = _003C_003E4__this;
			TrackItemUI selectedTrack = advancedMusicSelection._selectedTrack;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A36C4]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			MusicData data = selectedTrack._data;
			selectedTrack._Title.text = data._003Ctitle_003Ek__BackingField;
			AdvancedMusicSelection advancedMusicSelection2 = _003C_003E4__this;
			int num = AddressableCache.CustomOperationHandles.FindEntry(advancedMusicSelection2._currentCacheName);
			if (num >= 0)
			{
				AdvancedMusicSelection advancedMusicSelection3 = _003C_003E4__this;
				TrackItemUI selectedTrack2 = advancedMusicSelection3._selectedTrack;
				SoundManager.PlayMusic(selectedTrack2._bgmType, soundConfig);
			}
		}
	}

	private sealed class _003CStart_003Ed__58(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public AdvancedMusicSelection _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0f22: Expected I4, but got I8
			//IL_00e4: Expected O, but got I4
			//IL_00ed: Expected O, but got I4
			//IL_0547: Expected O, but got I
			//IL_076e: Expected O, but got I
			//IL_0ac9: Expected O, but got I
			//IL_0afc: Expected O, but got I4
			//IL_0b19: Expected O, but got I
			//IL_0b4e: Expected O, but got I
			//IL_1288: Expected O, but got I4
			//IL_12b4: Expected I4, but got O
			//IL_13b6: Expected I, but got O
			//IL_13cc: Expected O, but got I
			//IL_13d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_13da: Expected O, but got Unknown
			//IL_0ea4: Expected I, but got O
			//IL_1400: Expected O, but got I4
			//IL_1417: Expected I, but got I8
			//IL_0e80: Expected I, but got I8
			//IL_00ba->IL0fad: Incompatible stack heights: 1 vs 0
			//IL_1022->IL0fad: Incompatible stack heights: 1 vs 0
			//IL_1088->IL0fad: Incompatible stack heights: 1 vs 0
			//IL_021e->IL0fad: Incompatible stack heights: 1 vs 0
			//IL_10ee->IL0fad: Incompatible stack heights: 1 vs 0
			//IL_02f4->IL0fad: Incompatible stack heights: 1 vs 0
			//IL_1154->IL0fad: Incompatible stack heights: 1 vs 0
			//IL_03ca->IL0fad: Incompatible stack heights: 1 vs 0
			//IL_147d->IL0fad: Incompatible stack heights: 1 vs 0
			//IL_050f->IL0fad: Incompatible stack heights: 1 vs 0
			//IL_04a0->IL0fad: Incompatible stack heights: 1 vs 0
			//IL_0567->IL0fad: Incompatible stack heights: 2 vs 0
			//IL_059e->IL0fad: Incompatible stack heights: 2 vs 0
			//IL_05cd->IL0fad: Incompatible stack heights: 2 vs 0
			//IL_0619->IL0fad: Incompatible stack heights: 2 vs 0
			//IL_14ac->IL0fad: Incompatible stack heights: 2 vs 0
			//IL_0736->IL0fad: Incompatible stack heights: 2 vs 0
			//IL_06c6->IL0fad: Incompatible stack heights: 2 vs 0
			//IL_078e->IL0fad: Incompatible stack heights: 3 vs 0
			//IL_07c5->IL0fad: Incompatible stack heights: 3 vs 0
			//IL_07f4->IL0fad: Incompatible stack heights: 3 vs 0
			//IL_0840->IL0fad: Incompatible stack heights: 3 vs 0
			//IL_11ef->IL0fad: Incompatible stack heights: 3 vs 0
			//IL_0966->IL0fad: Incompatible stack heights: 3 vs 0
			//IL_08f7->IL0fad: Incompatible stack heights: 3 vs 0
			//IL_1236->IL0fad: Incompatible stack heights: 3 vs 0
			//IL_1275->IL0fad: Incompatible stack heights: 3 vs 0
			//IL_0a1d->IL0fad: Incompatible stack heights: 3 vs 0
			//IL_0c2a->IL0fad: Incompatible stack heights: 3 vs 0
			//IL_0a91->IL0fad: Incompatible stack heights: 3 vs 0
			//IL_12f4->IL0fad: Incompatible stack heights: 3 vs 0
			//IL_0ae9->IL0fad: Incompatible stack heights: 4 vs 0
			//IL_0b39->IL0fad: Incompatible stack heights: 4 vs 0
			//IL_0c7f->IL0fad: Incompatible stack heights: 4 vs 0
			//IL_0b6e->IL0fad: Incompatible stack heights: 4 vs 0
			//IL_0cb8->IL0fad: Incompatible stack heights: 4 vs 0
			//IL_12c5->IL14b1: Incompatible stack heights: 4 vs 3
			//IL_0bda->IL0fad: Incompatible stack heights: 4 vs 0
			//IL_0d38->IL0fad: Incompatible stack heights: 4 vs 0
			//IL_0d6d->IL0fad: Incompatible stack heights: 4 vs 0
			//IL_0ef1->IL1440: Incompatible stack heights: 5 vs 0
			AdvancedMusicSelection advancedMusicSelection = _003C_003E4__this;
			PlayerOptionsData playerOptionsData;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					DataManager data = advancedMusicSelection._data;
					if (advancedMusicSelection._data != null)
					{
						bool flag = data._003CAllAlbumData_003Ek__BackingField == null;
						List<KeyValuePair<System.Int32Enum, object>> list = new List<KeyValuePair<System.Int32Enum, object>>((IEnumerable<KeyValuePair<System.Int32Enum, object>>)data._003CAllAlbumData_003Ek__BackingField);
						if (list != null)
						{
							List<KeyValuePair<AlbumType, AlbumData>>.Enumerator enumerator = (List<KeyValuePair<AlbumType, AlbumData>>.Enumerator)list;
							List<KeyValuePair<AlbumType, AlbumData>>.Enumerator enumerator2 = default(List<KeyValuePair<AlbumType, AlbumData>>.Enumerator);
							if (enumerator2.MoveNext())
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
								List<KeyValuePair<AlbumType, AlbumData>>.Enumerator enumerator3 = (List<KeyValuePair<AlbumType, AlbumData>>.Enumerator)0;
								List<KeyValuePair<AlbumType, AlbumData>>.Enumerator enumerator4 = (List<KeyValuePair<AlbumType, AlbumData>>.Enumerator)0;
								throw new NullReferenceException();
							}
							advancedMusicSelection._canInteract = false;
							PlayerOptions playerOptions = advancedMusicSelection._playerOptions;
							if (advancedMusicSelection._playerOptions != null)
							{
								if (playerOptions._onlineClientWithRunDataConfig == null)
								{
									if (playerOptions._hostGameConfig == null)
									{
										if (playerOptions._currentAdventureSaveData != null)
										{
											playerOptionsData = playerOptions._currentAdventureSaveData;
											if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
											{
												goto IL_104c;
											}
										}
										playerOptionsData = playerOptions._mainGameConfig;
										if (playerOptions._mainGameConfig == null)
										{
											goto IL_0fad;
										}
									}
									else
									{
										playerOptionsData = playerOptions._hostGameConfig;
									}
								}
								else
								{
									playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
								}
								goto IL_104c;
							}
						}
					}
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_1445;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Selectable defaultSelectedItem = _003C_003E4__this.GetDefaultSelectedItem();
					if ((object)defaultSelectedItem != null)
					{
						defaultSelectedItem.Select();
						goto IL_1445;
					}
				}
			}
			goto IL_0fad;
			IL_1482:
			List<BgmPlaybackType> playbackList = advancedMusicSelection._playbackList;
			PlayerOptionsData playerOptionsData2;
			if (advancedMusicSelection._playbackList != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				int num = default(int);
				advancedMusicSelection._playbackIndex = num;
				List<BgmPlaybackType> playbackList2 = advancedMusicSelection._playbackList;
				if (advancedMusicSelection._playbackList != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rcx_v45 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmPlaybackType>)+18]");
					bool flag2 = (nint)num >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rcx_v45 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmPlaybackType>)+10]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rcx_v45 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmPlaybackType>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rcx_v46+20+v224 @ rax_v60 (System.Int32)*4]");
						advancedMusicSelection._selectedPlayback = BgmPlaybackType.Lock_Selected;
						if (advancedMusicSelection._playerOptions != null)
						{
							PlayerOptionsData config = advancedMusicSelection._playerOptions.Config;
							if (config != null)
							{
								config._003CSelectedBGMPlayback_003Ek__BackingField = advancedMusicSelection._selectedPlayback;
								_003C_003E4__this.SetPlaybackName();
								PlayerOptions playerOptions2 = advancedMusicSelection._playerOptions;
								if (advancedMusicSelection._playerOptions != null)
								{
									if (playerOptions2._onlineClientWithRunDataConfig == null)
									{
										if (playerOptions2._hostGameConfig == null)
										{
											if (playerOptions2._currentAdventureSaveData != null)
											{
												PlayerOptionsData currentAdventureSaveData = playerOptions2._currentAdventureSaveData;
												if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
												{
													playerOptionsData2 = currentAdventureSaveData;
													goto IL_11d2;
												}
											}
											playerOptionsData2 = playerOptions2._mainGameConfig;
											if (playerOptions2._mainGameConfig == null)
											{
												goto IL_0fad;
											}
										}
										else
										{
											playerOptionsData2 = playerOptions2._hostGameConfig;
										}
									}
									else
									{
										playerOptionsData2 = playerOptions2._onlineClientWithRunDataConfig;
									}
									goto IL_11d2;
								}
							}
						}
					}
				}
			}
			goto IL_0fad;
			IL_1219:
			PlayerOptionsData playerOptionsData3;
			if ((object)advancedMusicSelection._LockSelected != null)
			{
				advancedMusicSelection._LockSelected.Initialize(playerOptionsData3._003CSelectedBGMSave_003Ek__BackingField);
				List<KeyValuePair<AlbumType, AlbumData>> albums = advancedMusicSelection._albums;
				bool flag3 = advancedMusicSelection._albums == null;
				int num2 = 0;
				List<KeyValuePair<System.Int32Enum, object>> list2 = null;
				if (!flag3)
				{
					object obj7 = default(object);
					Vector3 value2 = default(Vector3);
					while (true)
					{
						List<KeyValuePair<System.Int32Enum, object>> list3 = list2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2103 @ rax_v72 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.AlbumType, VampireSurvivors.Data.AlbumData>>)+18]");
						if ((nint)list3 < 0)
						{
							List<KeyValuePair<AlbumType, AlbumData>> albums2 = advancedMusicSelection._albums;
							if (advancedMusicSelection._albums == null)
							{
								break;
							}
							int num3 = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v143 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.AlbumType, VampireSurvivors.Data.AlbumData>>)+18]");
							bool flag4 = (nint)num3 >= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v143 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.AlbumType, VampireSurvivors.Data.AlbumData>>)+10]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v143 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.AlbumType, VampireSurvivors.Data.AlbumData>>)+10]");
							if ((nint)0 == 0)
							{
								break;
							}
							object obj3 = num2 + 2;
							object obj4 = obj3 + obj3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rcx_v110+8+v232 @ rax_v146*8]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rcx_v110+8+v232 @ rax_v146*8]");
							if ((nint)0 == 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rcx_v111+28]");
							object obj6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rcx_v111+28]");
							if ((nint)0 == 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rcx_v112+18]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
								if ((nint)obj7 != -1)
								{
									advancedMusicSelection._albumIndex = num2;
								}
							}
							List<KeyValuePair<System.Int32Enum, object>> list4 = (List<KeyValuePair<System.Int32Enum, object>>)(num2 + 1);
							albums = advancedMusicSelection._albums;
							bool flag5 = advancedMusicSelection._albums != null;
							num2 = (int)list4;
							list2 = list4;
							if (!flag5)
							{
								break;
							}
							continue;
						}
						_003C_003E4__this.SetTracksUnlocked();
						_003C_003E4__this.SpawnAlbums();
						_003C_003E4__this.SpawnTracksForAlbum();
						MultiplayerManager multiplayer = advancedMusicSelection._multiplayer;
						if (advancedMusicSelection._multiplayer == null)
						{
							break;
						}
						List<CoopSlotData> slotsSelections = multiplayer._slotsSelections;
						if (multiplayer._slotsSelections == null)
						{
							break;
						}
						bool flag6 = slotsSelections._size <= 0;
						CoopSlotData[] items = slotsSelections._items;
						if (slotsSelections._items == null)
						{
							break;
						}
						CoopSlotData coopSlotData = items[0];
						if (items[0] == null)
						{
							break;
						}
						advancedMusicSelection._player = coopSlotData.RewiredPlayer;
						UIHelper.ActiveInputType activeInput = UIHelper.ActiveInput;
						float endValue;
						if (activeInput == UIHelper.ActiveInputType.MOUSE)
						{
							advancedMusicSelection._navPhase = NavigationPhase.UNIVERSAL;
							_003C_003E4__this.VisuallyEnableInfoPanel();
							if ((object)advancedMusicSelection._AlbumGroup == null)
							{
								break;
							}
							advancedMusicSelection._AlbumGroup.alpha = 1f;
							if ((object)advancedMusicSelection._TrackGroup == null)
							{
								break;
							}
							advancedMusicSelection._TrackGroup.alpha = 1f;
							endValue = 1f;
						}
						else
						{
							Selectable defaultSelectedItem2 = _003C_003E4__this.GetDefaultSelectedItem();
							bool flag7 = (object)defaultSelectedItem2 == null;
							Selectable selectable = defaultSelectedItem2;
							if (!flag7)
							{
								selectable = (Selectable)(object)defaultSelectedItem2.ToString();
							}
							string message = "first selection : " + (string)(object)selectable;
							Debug.Log(message);
							_003C_003E4__this.SetTrackNavigation(defaultSelectedItem2);
							endValue = 1f;
						}
						UIHelper.OnInputMethodChanged value = _003C_003E4__this.OnInputMethodChanged;
						UIHelper.InputMethodChanged += value;
						object panel = advancedMusicSelection._Panel;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v882 @ rsi_v25 (System.Object)+10]");
						bool flag8 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v882 @ rsi_v25 (System.Object)+10]");
						Transform.set_localScale_Injected((IntPtr)0, ref value2);
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(advancedMusicSelection._Panel, endValue, 0.3f);
						TweenCallback tweenCallback = null;
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v780 @ r10_v2 (Il2CppMethodInfo)+8]");
						((Delegate)tweenCallback).method_ptr = (IntPtr)0;
						((Delegate)tweenCallback).method = (nint)__ldftn(AdvancedMusicSelection._003CStart_003Eb__58_0);
						((Delegate)tweenCallback).m_target = _003C_003E4__this;
						((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v780 @ r10_v2 (Il2CppMethodInfo)+4C]");
						object obj8 = (nint)0 >> 4;
						object obj9 = obj8 & 1;
						nint num5;
						if (obj9 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v780 @ r10_v2 (Il2CppMethodInfo)+52]");
							if ((nint)0 == 0)
							{
								num5 = unchecked((nint)6447293664L);
								goto IL_13f7;
							}
						}
						num5 = ((Delegate)tweenCallback).method_ptr;
						((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
						goto IL_13f7;
						IL_13f7:
						object obj10 = 24;
						((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2449 @ rax_v97 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 == 0)
							{
							}
						}
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
				}
			}
			goto IL_0fad;
			IL_0fad:
			throw new NullReferenceException();
			IL_10b2:
			PlayerOptionsData playerOptionsData4;
			advancedMusicSelection._initialBGMMod = playerOptionsData4._003CSelectedBGMMod_003Ek__BackingField;
			PlayerOptions playerOptions3 = advancedMusicSelection._playerOptions;
			if (advancedMusicSelection._playerOptions == null)
			{
				goto IL_0fad;
			}
			PlayerOptionsData playerOptionsData5;
			if (playerOptions3._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions3._hostGameConfig == null)
				{
					if (playerOptions3._currentAdventureSaveData != null)
					{
						playerOptionsData5 = playerOptions3._currentAdventureSaveData;
						if ((object)playerOptionsData5._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_1118;
						}
					}
					playerOptionsData5 = playerOptions3._mainGameConfig;
					if (playerOptions3._mainGameConfig == null)
					{
						goto IL_0fad;
					}
				}
				else
				{
					playerOptionsData5 = playerOptions3._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData5 = playerOptions3._onlineClientWithRunDataConfig;
			}
			goto IL_1118;
			IL_1445:
			return false;
			IL_1118:
			advancedMusicSelection._initialLockSelected = playerOptionsData5._003CSelectedBGMSave_003Ek__BackingField;
			PlayerOptions playerOptions4 = advancedMusicSelection._playerOptions;
			if (advancedMusicSelection._playerOptions == null)
			{
				goto IL_0fad;
			}
			if (playerOptions4._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions4._hostGameConfig == null)
				{
					PlayerOptionsData currentAdventureSaveData2;
					if (playerOptions4._currentAdventureSaveData != null)
					{
						currentAdventureSaveData2 = playerOptions4._currentAdventureSaveData;
						if ((object)currentAdventureSaveData2._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_1453;
						}
					}
					currentAdventureSaveData2 = playerOptions4._mainGameConfig;
					if (playerOptions4._mainGameConfig == null)
					{
						goto IL_0fad;
					}
				}
				else
				{
					PlayerOptionsData currentAdventureSaveData2 = playerOptions4._hostGameConfig;
				}
			}
			else
			{
				PlayerOptionsData currentAdventureSaveData2 = playerOptions4._onlineClientWithRunDataConfig;
			}
			goto IL_1453;
			IL_1453:
			List<BgmModType> speedList = advancedMusicSelection._speedList;
			if (advancedMusicSelection._speedList != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				int num6 = default(int);
				advancedMusicSelection._speedIndex = num6;
				List<BgmModType> speedList2 = advancedMusicSelection._speedList;
				if (advancedMusicSelection._speedList != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rcx_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+18]");
					bool flag9 = (nint)num6 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rcx_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+10]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rcx_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rcx_v36+20+v218 @ rax_v51 (System.Int32)*4]");
						advancedMusicSelection._selectedSpeed = BgmModType.Normal;
						if (advancedMusicSelection._playerOptions != null)
						{
							PlayerOptionsData config2 = advancedMusicSelection._playerOptions.Config;
							if (config2 != null)
							{
								config2._003CSelectedBGMMod_003Ek__BackingField = advancedMusicSelection._selectedSpeed;
								_003C_003E4__this.SetSpeedName();
								PlayerOptions playerOptions5 = advancedMusicSelection._playerOptions;
								if (advancedMusicSelection._playerOptions != null)
								{
									if (playerOptions5._onlineClientWithRunDataConfig == null)
									{
										if (playerOptions5._hostGameConfig == null)
										{
											PlayerOptionsData currentAdventureSaveData3;
											if (playerOptions5._currentAdventureSaveData != null)
											{
												currentAdventureSaveData3 = playerOptions5._currentAdventureSaveData;
												if ((object)currentAdventureSaveData3._003CSelectedAdventureType_003Ek__BackingField != null)
												{
													goto IL_1482;
												}
											}
											currentAdventureSaveData3 = playerOptions5._mainGameConfig;
											if (playerOptions5._mainGameConfig == null)
											{
												goto IL_0fad;
											}
										}
										else
										{
											PlayerOptionsData currentAdventureSaveData3 = playerOptions5._hostGameConfig;
										}
									}
									else
									{
										PlayerOptionsData currentAdventureSaveData3 = playerOptions5._onlineClientWithRunDataConfig;
									}
									goto IL_1482;
								}
							}
						}
					}
				}
			}
			goto IL_0fad;
			IL_104c:
			advancedMusicSelection._initialBGMType = playerOptionsData._003CSelectedBGM_003Ek__BackingField;
			PlayerOptions playerOptions6 = advancedMusicSelection._playerOptions;
			if (advancedMusicSelection._playerOptions == null)
			{
				goto IL_0fad;
			}
			if (playerOptions6._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions6._hostGameConfig == null)
				{
					if (playerOptions6._currentAdventureSaveData != null)
					{
						playerOptionsData4 = playerOptions6._currentAdventureSaveData;
						if ((object)playerOptionsData4._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_10b2;
						}
					}
					playerOptionsData4 = playerOptions6._mainGameConfig;
					if (playerOptions6._mainGameConfig == null)
					{
						goto IL_0fad;
					}
				}
				else
				{
					playerOptionsData4 = playerOptions6._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData4 = playerOptions6._onlineClientWithRunDataConfig;
			}
			goto IL_10b2;
			IL_11d2:
			if ((object)advancedMusicSelection._PlayOnlyDuringGameplay != null)
			{
				advancedMusicSelection._PlayOnlyDuringGameplay.InitialSet(playerOptionsData2._003CPlayBGMOnlyDuringRun_003Ek__BackingField);
				PlayerOptions playerOptions7 = advancedMusicSelection._playerOptions;
				if (advancedMusicSelection._playerOptions != null)
				{
					if (playerOptions7._onlineClientWithRunDataConfig == null)
					{
						if (playerOptions7._hostGameConfig == null)
						{
							if (playerOptions7._currentAdventureSaveData != null)
							{
								PlayerOptionsData currentAdventureSaveData4 = playerOptions7._currentAdventureSaveData;
								if ((object)currentAdventureSaveData4._003CSelectedAdventureType_003Ek__BackingField != null)
								{
									playerOptionsData3 = currentAdventureSaveData4;
									goto IL_1219;
								}
							}
							playerOptionsData3 = playerOptions7._mainGameConfig;
							if (playerOptions7._mainGameConfig == null)
							{
								goto IL_0fad;
							}
						}
						else
						{
							playerOptionsData3 = playerOptions7._hostGameConfig;
						}
					}
					else
					{
						playerOptionsData3 = playerOptions7._onlineClientWithRunDataConfig;
					}
					goto IL_1219;
				}
			}
			goto IL_0fad;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private RectTransform _AlbumContainer;

	private GameObject _AlbumPrefab;

	private UICarousel _Carousel;

	private CanvasGroup _AlbumGroup;

	private RectTransform _TrackContainer;

	private GameObject _TrackPrefab;

	private CanvasGroup _TrackGroup;

	private TextMeshProUGUI _Name;

	private TextMeshProUGUI _Author;

	private TextMeshProUGUI _Duration;

	private TextMeshProUGUI _Playback;

	private TextMeshProUGUI _Modifier;

	private TextMeshProUGUI _ModifierLabel;

	private TickBoxUI _PlayOnlyDuringGameplay;

	private Image _Icon;

	private Button _ModifierButton;

	private Button _ConfirmButton;

	private Button _PlaybackButton;

	private TickBoxUI _LockSelected;

	private RectTransform _Panel;

	private Button _CloseButton;

	private GameObject _InfoPanel;

	private float _HorizontalAlbumNavigationSensitivity = 0.25f;

	private OnSelectionChanged m_SelectedTrackChanged;

	private List<KeyValuePair<AlbumType, AlbumData>> _albums;

	private List<GameObject> _spawnedAlbums;

	private List<TrackItemUI> _spawnedTracks;

	private List<BgmModType> _speedList;

	private List<BgmPlaybackType> _playbackList;

	private BgmModType _selectedSpeed;

	private int _speedIndex;

	private BgmPlaybackType _selectedPlayback;

	private int _playbackIndex;

	private int _albumIndex;

	private Rewired.Player _player;

	private TrackItemUI _selectedTrack;

	private DataManager _data;

	private MultiplayerManager _multiplayer;

	private PlayerOptions _playerOptions;

	private DiContainer _diContainer;

	private BgmType _defaultSong;

	private bool _canInteract;

	private bool _axisReset;

	private int _currentTrackIndex;

	private string _currentCacheName;

	private BgmType _currentPlayingTrack;

	private bool _initialLockSelected;

	private BgmType _initialBGMType;

	private BgmModType _initialBGMMod;

	private NavigationPhase _navPhase;

	public event OnSelectionChanged SelectedTrackChanged
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 256;
			Delegate obj2 = this.m_SelectedTrackChanged;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnSelectionChanged);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 256;
			Delegate obj2 = this.m_SelectedTrackChanged;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnSelectionChanged);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	private void Construct(DataManager data, MultiplayerManager multi, PlayerOptions playerOptions)
	{
		_data = data;
		_multiplayer = multi;
		_playerOptions = playerOptions;
	}

	private void Awake()
	{
		//IL_01f4: Expected I4, but got O
		if ((object)_ConfirmButton != null)
		{
			TextMeshProUGUI componentInChildren = _ConfirmButton.GetComponentInChildren<TextMeshProUGUI>();
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("lang/account_age_gate_confirm", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			if ((object)componentInChildren != null)
			{
				componentInChildren.text = translation;
				if ((object)_ModifierLabel != null)
				{
					TextMeshProUGUI componentInChildren2 = _ModifierLabel.GetComponentInChildren<TextMeshProUGUI>();
					string translation2 = LocalizationManager.GetTranslation("lang/musicpanel_modifier", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
					if ((object)componentInChildren2 != null)
					{
						componentInChildren2.text = translation2;
						if ((object)_CloseButton != null)
						{
							TextMeshProUGUI componentInChildren3 = _CloseButton.GetComponentInChildren<TextMeshProUGUI>();
							string translation3 = LocalizationManager.GetTranslation("lang/topBar_back", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
							if ((object)componentInChildren3 != null)
							{
								componentInChildren3.text = translation3;
								AddSpeed(BgmModType.Normal);
								AddSpeed(BgmModType.Hyper);
								AddSpeed(BgmModType.Forsaken);
								AddPlayback(BgmPlaybackType.Lock_Selected);
								AddPlayback(BgmPlaybackType.Shuffle);
								AddPlayback(BgmPlaybackType.Play_All);
								AddPlayback(BgmPlaybackType.None);
								Action<bool> action = null;
								((AdvancedMusicSelection)(object)action).TogglePlayDuringRun((byte)(int)this != 0);
								if ((object)_PlayOnlyDuringGameplay != null)
								{
									_PlayOnlyDuringGameplay.AddOnToggle(action);
									UICarousel carousel = _Carousel;
									UICarousel.OnSelectionChanged b = ChangeAlbum;
									if ((object)_Carousel != null)
									{
										Delegate obj = carousel.SelectionChanged;
										while (true)
										{
											Delegate obj2 = Delegate.Combine(obj, b);
											bool flag = (object)obj2 == null;
											Delegate obj3 = null;
											if (!flag)
											{
												bool flag2 = (object)obj2.GetType() != typeof(UICarousel.OnSelectionChanged);
												obj3 = null;
												if (!flag2)
												{
													obj3 = obj2;
												}
												if ((object)obj3 == null)
												{
													break;
												}
											}
											bool flag3 = (object)obj == carousel.SelectionChanged;
											Delegate obj4;
											if ((object)obj == carousel.SelectionChanged)
											{
												carousel.SelectionChanged = (UICarousel.OnSelectionChanged)obj3;
												obj4 = obj;
											}
											else
											{
												obj4 = carousel.SelectionChanged;
											}
											Delegate obj5 = obj;
											if (!flag3)
											{
												obj5 = obj4;
											}
											bool flag4 = (object)obj5 != obj;
											obj = obj5;
											if (!flag4)
											{
												return;
											}
										}
										goto IL_03e5;
									}
								}
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_03e5;
		IL_03e5:
		throw new InvalidCastException();
	}

	private void ChangeAlbum(int index)
	{
		//IL_0013: Expected F4, but got I4
		//IL_002e: Expected O, but got I
		//IL_00a4: Expected O, but got I
		//IL_008d: Expected O, but got I
		//IL_0101: Expected O, but got I
		//IL_012e: Expected F4, but got I4
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		//IL_0134->IL04db: Incompatible stack heights: 1 vs 0
		//IL_0387->IL01e2: Incompatible stack heights: 1 vs 0
		List<TrackItemUI> spawnedTracks = _spawnedTracks;
		float num = 0f;
		List<TrackItemUI>.Enumerator enumerator = default(List<TrackItemUI>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v13 (System.Object)+100]");
			Tween tween = (Tween)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v13 (System.Object)+100]");
			if ((nint)0 != 0 && tween._003Cactive_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v13 (System.Object)+100]");
				TweenExtensions.Kill((Tween)0);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v13 (System.Object)+108]");
			Tween tween2 = (Tween)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v13 (System.Object)+108]");
			if ((nint)0 != 0 && tween2._003Cactive_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v13 (System.Object)+108]");
				TweenExtensions.Kill((Tween)0);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v13 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v13 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
			GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
			UnityEngine.Object.Destroy(obj2, 0f);
			num = 0f;
		}
		List<TrackItemUI> spawnedTracks2 = _spawnedTracks;
		int version = spawnedTracks2._version + 1;
		spawnedTracks2._version = version;
		spawnedTracks2._size = 0;
		if (spawnedTracks2._size > 0)
		{
			Array.Clear(spawnedTracks2._items, 0, spawnedTracks2._size);
			spawnedTracks = null;
		}
		SpawnTracksForAlbum();
		_selectedTrack = null;
		List<TrackItemUI> spawnedTracks3 = _spawnedTracks;
		TrackItemUI trackItemUI = null;
		TrackItemUI trackItemUI2 = null;
		TrackItemUI trackItemUI3 = null;
		TrackItemUI trackItemUI4 = default(TrackItemUI);
		Component component3 = default(Component);
		TrackItemUI selectedTrack = default(TrackItemUI);
		while ((nint)trackItemUI3 < spawnedTracks3._size)
		{
			List<TrackItemUI> spawnedTracks4 = _spawnedTracks;
			bool flag2 = (nint)trackItemUI >= spawnedTracks4._size;
			TrackItemUI[] items = spawnedTracks4._items;
			TrackItemUI component = items[(object)trackItemUI].GetComponent<TrackItemUI>();
			MusicData data = component._data;
			if (data._003CisUnlocked_003Ek__BackingField)
			{
				if ((object)trackItemUI2 == null || ((UnityEngine.Object)trackItemUI2).m_CachedPtr == (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					trackItemUI2 = trackItemUI4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				TrackItemUI component2 = component3.GetComponent<TrackItemUI>();
				PlayerOptionsData config = _playerOptions.Config;
				if (component2._bgmType == config._003CSelectedBGM_003Ek__BackingField)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					_selectedTrack = selectedTrack;
				}
			}
			trackItemUI = (TrackItemUI)(trackItemUI + 1);
			spawnedTracks3 = _spawnedTracks;
			trackItemUI3 = trackItemUI;
		}
		TrackItemUI selectedTrack2 = _selectedTrack;
		if ((object)_selectedTrack == null || ((UnityEngine.Object)selectedTrack2).m_CachedPtr == (IntPtr)0)
		{
			_selectedTrack = trackItemUI2;
		}
		TrackItemUI selectedTrack3 = _selectedTrack;
		if ((object)_selectedTrack != null && ((UnityEngine.Object)selectedTrack3).m_CachedPtr != (IntPtr)0)
		{
			Selectable component4 = _selectedTrack.GetComponent<Selectable>();
			component4.Select();
			return;
		}
		UIHelper.ActiveInputType activeInput = UIHelper.ActiveInput;
		if (activeInput == UIHelper.ActiveInputType.MOUSE)
		{
			SoundManager.StopMusic(_currentPlayingTrack);
		}
	}

	private unsafe void SpawnTracksForAlbum()
	{
		//IL_0316: Expected O, but got I
		//IL_00cd: Expected O, but got I
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0131: Expected O, but got I4
		//IL_0148: Expected O, but got Ref
		UICarousel carousel = _Carousel;
		List<GameObject> cachedItems = carousel._cachedItems;
		int currentIndex = carousel._currentIndex;
		if (carousel._currentIndex < cachedItems._size)
		{
			GameObject[] items = cachedItems._items;
			AlbumItemUI component = items[currentIndex].GetComponent<AlbumItemUI>();
			object obj = null;
			object obj2 = default(object);
			object obj3 = default(object);
			object obj5 = default(object);
			IntPtr intPtr = default(IntPtr);
			while (true)
			{
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ stack_-38_v14+1C]");
					if (obj3 == null)
					{
						object obj4 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ stack_-38_v14+18]");
						if ((nint)obj4 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ stack_-38_v14+10]");
							object obj6 = 0;
							object obj7 = obj5 + 1;
							DataManager data = _data;
							bool flag = data._003CAllMusicData_003Ek__BackingField == null;
							Dictionary<BgmType, MusicData> dictionary = data._003CAllMusicData_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdx_v23+20+v244 @ stack_-30_v13*4]");
							int num = ((Dictionary<System.Int32Enum, object>)(object)dictionary).FindEntry((System.Int32Enum)0);
							object obj8 = !flag;
							if (obj8 == null)
							{
								string text = ((Enum)(&intPtr)).ToString();
								string message = "No MusicData found for : " + text;
								Debug.LogWarning(message);
								obj5 = obj7;
							}
							else
							{
								DataManager data2 = _data;
								Dictionary<BgmType, MusicData> dictionary2 = data2._003CAllMusicData_003Ek__BackingField;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdx_v23+20+v244 @ stack_-30_v13*4]");
								object d = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).get_Item((System.Int32Enum)0);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdx_v23+20+v244 @ stack_-30_v13*4]");
								TrackItemUI trackItemUI = SpawnTrack(BgmType.BGM_Forest, (MusicData)d);
								obj5 = obj7;
							}
							continue;
						}
						break;
					}
					break;
				}
				throw new NullReferenceException();
			}
			bool flag2 = obj2 == null;
			obj = 0;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ stack_-38_v14+1C]");
				if (obj3 == null)
				{
					List<TrackItemUI> spawnedTracks = _spawnedTracks;
					if (spawnedTracks._size > 0)
					{
						TrackItemUI[] items2 = spawnedTracks._items;
						_selectedTrack = items2[0];
						GenerateTrackNavigation();
						_Author.text = "";
						return;
					}
					goto IL_02d2;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				obj = null;
			}
			throw new NullReferenceException();
		}
		goto IL_02d2;
		IL_02d2:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private IEnumerator Start()
	{
		_003CStart_003Ed__58 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe bool GetMusicData(BgmType bgmType, out MusicData musicData)
	{
		//IL_011b: Expected I4, but got O
		ref MusicData reference = ref *(MusicData*)null;
		DataManager data = _data;
		if (_data != null && data._003CAllMusicData_003Ek__BackingField != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)data._003CAllMusicData_003Ek__BackingField).FindEntry((System.Int32Enum)bgmType);
			if (num < 0)
			{
				return false;
			}
			DataManager data2 = _data;
			if (_data != null && data2._003CAllMusicData_003Ek__BackingField != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)data2._003CAllMusicData_003Ek__BackingField).get_Item((System.Int32Enum)bgmType);
				reference = ref *(MusicData*)obj;
				return true;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void PlayAtSpeed()
	{
		//IL_011b: Expected O, but got Ref
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Ref, but got Unknown
		//IL_00d5: Expected I8, but got I4
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected Ref, but got Unknown
		//IL_040d: Expected O, but got I4
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected Ref, but got Unknown
		//IL_01c7: Expected I8, but got I4
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected Ref, but got Unknown
		//IL_043b: Expected O, but got Ref
		//IL_03fa: Expected F4, but got I4
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Expected Ref, but got Unknown
		//IL_04f1: Expected I8, but got I4
		//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected Ref, but got Unknown
		//IL_0744: Expected O, but got I
		//IL_0754: Expected O, but got I
		//IL_060c: Expected O, but got I
		_003C_003Ec__DisplayClass60_0 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass60_0();
		CS_0024_003C_003E8__locals12._003C_003E4__this = this;
		string currentCacheName = _currentCacheName;
		object obj = "None";
		if ((object)_currentCacheName != "None")
		{
			if (_currentCacheName != null && "None" != null)
			{
				int stringLength = currentCacheName._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rdx_v3+10]");
				if ((nint)stringLength == 0)
				{
					ref byte second = ref *(byte*)("None" + 20);
					ulong length = (ulong)(currentCacheName._stringLength + currentCacheName._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref *(byte*)(_currentCacheName + 20), ref second, length))
					{
						goto IL_0205;
					}
				}
			}
			string currentCacheName2 = _currentCacheName;
			IntPtr intPtr = default(IntPtr);
			string text = ((Enum)(&intPtr)).ToString();
			if ((object)_currentCacheName != text)
			{
				if (_currentCacheName != null && text != null && currentCacheName2._stringLength == text._stringLength)
				{
					ref byte second2 = ref *(byte*)(text + 20);
					ulong length2 = (ulong)(currentCacheName2._stringLength + currentCacheName2._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref *(byte*)(_currentCacheName + 20), ref second2, length2))
					{
						goto IL_0205;
					}
				}
				ReleaseBGM();
			}
		}
		goto IL_0205;
		IL_0205:
		(CS_0024_003C_003E8__locals12.soundConfig = new SoundManager.SoundConfig()).Rate = 1f;
		TrackItemUI selectedTrack = _selectedTrack;
		bool musicData = GetMusicData(selectedTrack._bgmType, out var musicData2);
		PlayerOptionsData config = _playerOptions.Config;
		HyperMod hyperMod;
		if (config._003CSelectedBGMMod_003Ek__BackingField != BgmModType.Hyper)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if (config2._003CSelectedBGMMod_003Ek__BackingField != BgmModType.Forsaken)
			{
				goto IL_0705;
			}
			if (musicData2 == null || musicData2._003CforsakenMod_003Ek__BackingField == null)
			{
				return;
			}
			SoundManager.SoundConfig soundConfig = CS_0024_003C_003E8__locals12.soundConfig;
			ForsakenMod forsakenMod = musicData2._003CforsakenMod_003Ek__BackingField;
			soundConfig.Rate = forsakenMod._003Crate_003Ek__BackingField;
			hyperMod = (HyperMod)(object)musicData2._003CforsakenMod_003Ek__BackingField;
		}
		else
		{
			if (musicData2 == null || musicData2._003ChyperMod_003Ek__BackingField == null)
			{
				return;
			}
			SoundManager.SoundConfig soundConfig2 = CS_0024_003C_003E8__locals12.soundConfig;
			HyperMod hyperMod2 = musicData2._003ChyperMod_003Ek__BackingField;
			soundConfig2.Rate = hyperMod2._003Crate_003Ek__BackingField;
			hyperMod = musicData2._003ChyperMod_003Ek__BackingField;
		}
		SoundManager.SoundConfig soundConfig3 = CS_0024_003C_003E8__locals12.soundConfig;
		soundConfig3.Detune = hyperMod._003Cdetune_003Ek__BackingField;
		goto IL_0705;
		IL_0705:
		SoundManager.SoundConfig soundConfig4 = CS_0024_003C_003E8__locals12.soundConfig;
		soundConfig4.Volume = (float?)(object)1;
		SoundManager.SoundConfig soundConfig5 = CS_0024_003C_003E8__locals12.soundConfig;
		soundConfig5.Loop = true;
		IntPtr intPtr2 = default(IntPtr);
		string text2 = ((Enum)(&intPtr2)).ToString();
		string currentCacheName3 = _currentCacheName;
		bool flag2;
		if ((object)_currentCacheName != text2)
		{
			if (_currentCacheName != null && text2 != null && currentCacheName3._stringLength == text2._stringLength)
			{
				ref byte second3 = ref *(byte*)(text2 + 20);
				ulong length3 = (ulong)(currentCacheName3._stringLength + currentCacheName3._stringLength);
				bool flag = System.SpanHelpers.SequenceEqual(ref *(byte*)(_currentCacheName + 20), ref second3, length3);
				flag2 = flag;
				Action action = null;
			}
			else
			{
				flag2 = false;
				Action action = null;
				ref byte second3 = ref *(byte*)null;
				ulong length3 = (ulong)(nint)(&musicData2);
			}
		}
		else
		{
			flag2 = true;
			Action action = null;
			ref byte second3 = ref *(byte*)null;
			ulong length3 = (ulong)(nint)(&musicData2);
		}
		_currentCacheName = text2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
		DlcType? selectedTrack2 = (DlcType?)_selectedTrack;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ r8_v9 (System.Nullable`1<VampireSurvivors.Data.DlcType>)+D0]");
		object obj2 = default(object);
		bool flag3 = obj2 != null;
		bool flag4 = false;
		if (!flag3)
		{
			flag4 = flag2;
		}
		if (!flag4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A36C4]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ r8_v9 (System.Nullable`1<VampireSurvivors.Data.DlcType>)+D8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ r8_v9 (System.Nullable`1<VampireSurvivors.Data.DlcType>)+A8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rcx_v26+10]");
			string text3 = (string)0 + " (Loading...)";
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v120 @ r9_v6+558] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186B7F160");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ r8_v9 (System.Nullable`1<VampireSurvivors.Data.DlcType>)+D0]");
			DlcUtils dlcUtils = default(DlcUtils);
			DlcType? bgmDlcType = dlcUtils.GetBgmDlcType(BgmType.BGM_Forest, _data);
			Action action2 = delegate
			{
				AdvancedMusicSelection advancedMusicSelection = CS_0024_003C_003E8__locals12._003C_003E4__this;
				TrackItemUI selectedTrack4 = advancedMusicSelection._selectedTrack;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A36C4]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				MusicData data = selectedTrack4._data;
				selectedTrack4._Title.text = data._003Ctitle_003Ek__BackingField;
				AdvancedMusicSelection advancedMusicSelection2 = CS_0024_003C_003E8__locals12._003C_003E4__this;
				int num = AddressableCache.CustomOperationHandles.FindEntry(advancedMusicSelection2._currentCacheName);
				if (num >= 0)
				{
					AdvancedMusicSelection advancedMusicSelection3 = CS_0024_003C_003E8__locals12._003C_003E4__this;
					TrackItemUI selectedTrack5 = advancedMusicSelection3._selectedTrack;
					SoundManager.PlayMusic(selectedTrack5._bgmType, CS_0024_003C_003E8__locals12.soundConfig);
				}
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ r8_v9 (System.Nullable`1<VampireSurvivors.Data.DlcType>)+D0]");
			AudioLoader.LoadBgmAsync(BgmType.BGM_Forest, _currentCacheName, bgmDlcType, action2);
			Action action = action2;
			string currentCacheName4 = _currentCacheName;
			selectedTrack2 = bgmDlcType;
		}
		else
		{
			SoundManager.UpdateCurrentMusicWithConfig(CS_0024_003C_003E8__locals12.soundConfig);
			string currentCacheName4 = null;
		}
		TrackItemUI selectedTrack3 = _selectedTrack;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2CC0");
	}

	public void Confirm()
	{
		_playerOptions.Save();
		TrackItemUI selectedTrack = _selectedTrack;
		if ((object)_selectedTrack != null && ((UnityEngine.Object)selectedTrack).m_CachedPtr != (IntPtr)0)
		{
			TrackItemUI selectedTrack2 = _selectedTrack;
			if (_initialBGMType != selectedTrack2._bgmType)
			{
				SongSelectionPanel.UserHasChangedSong = true;
			}
			PlayerOptionsData config = _playerOptions.Config;
			TrackItemUI selectedTrack3 = _selectedTrack;
			config._003CSelectedBGM_003Ek__BackingField = selectedTrack3._bgmType;
			PlayerOptionsData config2 = _playerOptions.Config;
			if (config2._003CPlayBGMOnlyDuringRun_003Ek__BackingField)
			{
				TrackItemUI selectedTrack4 = _selectedTrack;
				SoundManager.StopMusic(selectedTrack4._bgmType);
			}
		}
		base.Hide();
		PopupManager.ClosePopup(_ID);
	}

	public void SetCurrentSelectedSong(BgmType current)
	{
		_defaultSong = current;
	}

	public void ClosePopup()
	{
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CPlayBGMOnlyDuringRun_003Ek__BackingField)
		{
			TrackItemUI selectedTrack = _selectedTrack;
			if ((object)_selectedTrack != null && ((UnityEngine.Object)selectedTrack).m_CachedPtr != (IntPtr)0)
			{
				TrackItemUI selectedTrack2 = _selectedTrack;
				SoundManager.StopMusic(selectedTrack2._bgmType);
			}
		}
		SongSelectionPanel.UserHasChangedSong = false;
		PlayerOptionsData config2 = _playerOptions.Config;
		config2._003CSelectedBGM_003Ek__BackingField = _initialBGMType;
		PlayerOptionsData config3 = _playerOptions.Config;
		config3._003CSelectedBGMMod_003Ek__BackingField = _initialBGMMod;
		PlayerOptionsData config4 = _playerOptions.Config;
		config4._003CSelectedBGMSave_003Ek__BackingField = _initialLockSelected;
		_currentCacheName = "None";
		ReleaseBGM();
		base.Hide();
		PopupManager.ClosePopup(_ID);
	}

	private void ReleaseBGM()
	{
		AddressableCache.ReleaseCustomOperationHandleGroup(_currentCacheName);
		AddressableCache.ReleaseCustomOperationHandleGroup("BGM");
	}

	private unsafe void OnDestroy()
	{
		//IL_01f8: Expected I, but got O
		//IL_020e: Expected O, but got I
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected O, but got Unknown
		//IL_0292: Expected I, but got O
		//IL_041d: Expected O, but got I4
		//IL_0434: Expected I, but got I8
		//IL_026e: Expected I, but got I8
		//IL_046b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0470: Expected O, but got Unknown
		//IL_008d->IL03c5: Incompatible stack heights: 1 vs 0
		//IL_048e->IL02d8: Incompatible stack heights: 1 vs 0
		UIHelper.OnInputMethodChanged value = OnInputMethodChanged;
		UIHelper.InputMethodChanged -= value;
		UICarousel carousel;
		UICarousel.OnSelectionChanged onSelectionChanged;
		if ((object)_Carousel != null)
		{
			_Carousel.Clear();
			if (_spawnedTracks != null)
			{
				List<TrackItemUI>.Enumerator enumerator = default(List<TrackItemUI>.Enumerator);
				while (enumerator.MoveNext())
				{
					object obj = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rdi_v12 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rdi_v12 (System.Object)+10]");
					IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
					GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
					UnityEngine.Object.Destroy(obj2, 0f);
				}
				List<GameObject> spawnedAlbums = _spawnedAlbums;
				if (_spawnedAlbums != null)
				{
					int version = spawnedAlbums._version + 1;
					spawnedAlbums._version = version;
					spawnedAlbums._size = 0;
					if (spawnedAlbums._size > 0)
					{
						Array.Clear(spawnedAlbums._items, 0, spawnedAlbums._size);
					}
					List<TrackItemUI> spawnedTracks = _spawnedTracks;
					if (_spawnedTracks != null)
					{
						int version2 = spawnedTracks._version + 1;
						spawnedTracks._version = version2;
						spawnedTracks._size = 0;
						if (spawnedTracks._size > 0)
						{
							Array.Clear(spawnedTracks._items, 0, spawnedTracks._size);
						}
						carousel = _Carousel;
						onSelectionChanged = null;
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ r9_v10 (Il2CppMethodInfo)+8]");
						((Delegate)onSelectionChanged).method_ptr = (IntPtr)0;
						((Delegate)onSelectionChanged).method = (nint)__ldftn(AdvancedMusicSelection.ChangeAlbum);
						((Delegate)onSelectionChanged).m_target = this;
						((Delegate)onSelectionChanged).method_code = (IntPtr)onSelectionChanged;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ r9_v10 (Il2CppMethodInfo)+4C]");
						object obj3 = (nint)0 >> 4;
						object obj4 = obj3 & 1;
						nint num2;
						if (obj4 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ r9_v10 (Il2CppMethodInfo)+52]");
							if ((nint)0 == 1)
							{
								num2 = unchecked((nint)6442485696L);
								goto IL_0414;
							}
						}
						num2 = ((Delegate)onSelectionChanged).method_ptr;
						((Delegate)onSelectionChanged).method_code = (IntPtr)((Delegate)onSelectionChanged).m_target;
						goto IL_0414;
					}
				}
			}
		}
		goto IL_035c;
		IL_035c:
		throw new NullReferenceException();
		IL_0414:
		object obj5 = 24;
		((Delegate)onSelectionChanged).extra_arg = unchecked((nint)6442485600L);
		if ((object)_Carousel != null)
		{
			Delegate obj6 = carousel.SelectionChanged;
			object obj7 = _Carousel + 80;
			bool flag6;
			do
			{
				Delegate obj8 = Delegate.Remove(obj6, onSelectionChanged);
				bool flag2 = (object)obj8 == null;
				Delegate obj9 = null;
				if (!flag2)
				{
					bool flag3 = (object)obj8.GetType() != typeof(UICarousel.OnSelectionChanged);
					obj9 = null;
					if (!flag3)
					{
						obj9 = obj8;
					}
					bool flag4 = (object)obj9 == null;
				}
				bool flag5 = obj6 == obj7;
				Delegate obj10;
				if (obj6 == obj7)
				{
					obj7 = obj9;
					obj10 = obj6;
				}
				else
				{
					obj10 = (Delegate)obj7;
				}
				Delegate obj11 = obj6;
				if (!flag5)
				{
					obj11 = obj10;
				}
				flag6 = (object)obj11 != obj6;
				obj6 = obj11;
			}
			while (flag6);
			return;
		}
		goto IL_035c;
	}

	private unsafe void SetTracksUnlocked()
	{
		//IL_0023: Expected O, but got I4
		//IL_002b: Expected O, but got Ref
		Dictionary<BgmType, MusicData>.Enumerator enumerator = default(Dictionary<BgmType, MusicData>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			object obj = 0;
			Dictionary<BgmType, MusicData>.Enumerator enumerator2 = (Dictionary<BgmType, MusicData>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private void TogglePlayDuringRun(bool isOn)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CPlayBGMOnlyDuringRun_003Ek__BackingField = isOn;
	}

	public void AddSpeed(BgmModType bgmMod)
	{
		//IL_0028: Expected O, but got I
		//IL_007d: Expected O, but got I
		List<System.Int32Enum> speedList = (List<System.Int32Enum>)(object)_speedList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v3+18]");
		if (num >= 0)
		{
			speedList.AddWithResize((System.Int32Enum)bgmMod);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj2 = (nint)0 + (nint)1;
	}

	private void AddPlayback(BgmPlaybackType pb)
	{
		//IL_0028: Expected O, but got I
		//IL_007d: Expected O, but got I
		List<System.Int32Enum> playbackList = (List<System.Int32Enum>)(object)_playbackList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v3+18]");
		if (num >= 0)
		{
			playbackList.AddWithResize((System.Int32Enum)pb);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj2 = (nint)0 + (nint)1;
	}

	public void SetSpeed(BgmModType speed)
	{
		//IL_005f: Expected O, but got I
		List<BgmModType> speedList = _speedList;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		List<BgmModType> speedList2 = _speedList;
		int num = default(int);
		_speedIndex = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v9+20+v56 @ rax_v10 (System.Int32)*4]");
			_selectedSpeed = BgmModType.Normal;
			PlayerOptionsData config = _playerOptions.Config;
			config._003CSelectedBGMMod_003Ek__BackingField = _selectedSpeed;
			SetSpeedName();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void SetPlayback(BgmPlaybackType pb)
	{
		//IL_005f: Expected O, but got I
		List<BgmPlaybackType> playbackList = _playbackList;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		List<BgmPlaybackType> playbackList2 = _playbackList;
		int num = default(int);
		_playbackIndex = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmPlaybackType>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmPlaybackType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v9+20+v56 @ rax_v10 (System.Int32)*4]");
			_selectedPlayback = BgmPlaybackType.Lock_Selected;
			PlayerOptionsData config = _playerOptions.Config;
			config._003CSelectedBGMPlayback_003Ek__BackingField = _selectedPlayback;
			SetPlaybackName();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void PreviousPlayback()
	{
		//IL_0072: Expected O, but got I
		int playbackIndex = _playbackIndex - 1;
		_playbackIndex = playbackIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A63AC]");
		if ((nint)0 < (nint)0)
		{
			List<BgmPlaybackType> playbackList = _playbackList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmPlaybackType>)+18]");
			int playbackIndex2 = (int)(-1);
			_playbackIndex = playbackIndex2;
		}
		List<BgmPlaybackType> playbackList2 = _playbackList;
		int playbackIndex3 = _playbackIndex;
		int playbackIndex4 = _playbackIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmPlaybackType>)+18]");
		if ((nint)playbackIndex4 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmPlaybackType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v1+20+v58 @ rcx_v2 (System.Int32)*4]");
			_selectedPlayback = BgmPlaybackType.Lock_Selected;
			PlayerOptionsData config = _playerOptions.Config;
			config._003CSelectedBGMPlayback_003Ek__BackingField = _selectedPlayback;
			SetPlaybackName();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void PreviousSpeed()
	{
		//IL_0072: Expected O, but got I
		int speedIndex = _speedIndex - 1;
		_speedIndex = speedIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A63AD]");
		if ((nint)0 < (nint)0)
		{
			List<BgmModType> speedList = _speedList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+18]");
			int speedIndex2 = (int)(-1);
			_speedIndex = speedIndex2;
		}
		List<BgmModType> speedList2 = _speedList;
		int speedIndex3 = _speedIndex;
		int speedIndex4 = _speedIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+18]");
		if ((nint)speedIndex4 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v1+20+v58 @ rcx_v2 (System.Int32)*4]");
			_selectedSpeed = BgmModType.Normal;
			PlayerOptionsData config = _playerOptions.Config;
			config._003CSelectedBGMMod_003Ek__BackingField = _selectedSpeed;
			SetSpeedName();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void NextSpeed()
	{
		//IL_0072: Expected O, but got I
		//IL_028c: Expected F4, but got I4
		List<BgmModType> speedList = _speedList;
		int num = ++_speedIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+18]");
		if ((nint)num >= (nint)0)
		{
			_speedIndex = 0;
		}
		int speedIndex = _speedIndex;
		int speedIndex2 = _speedIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+18]");
		SoundManager.SoundConfig soundConfig;
		HyperMod hyperMod;
		if ((nint)speedIndex2 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmModType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v4+20+v96 @ rcx_v7 (System.Int32)*4]");
			_selectedSpeed = BgmModType.Normal;
			PlayerOptionsData config = _playerOptions.Config;
			config._003CSelectedBGMMod_003Ek__BackingField = _selectedSpeed;
			PlayerOptionsData config2 = _playerOptions.Config;
			bool musicData = GetMusicData(config2._003CSelectedBGM_003Ek__BackingField, out var musicData2);
			soundConfig = SoundManager._003CCurrentMusicSoundConfig_003Ek__BackingField;
			PlayerOptionsData config3 = _playerOptions.Config;
			if (config3._003CSelectedBGMMod_003Ek__BackingField != BgmModType.Hyper)
			{
				PlayerOptionsData config4 = _playerOptions.Config;
				if (config4._003CSelectedBGMMod_003Ek__BackingField != BgmModType.Forsaken)
				{
					soundConfig.Rate = 1f;
					soundConfig.Detune = 1f;
				}
				else if (musicData2 != null && musicData2._003CforsakenMod_003Ek__BackingField != null)
				{
					ForsakenMod forsakenMod = musicData2._003CforsakenMod_003Ek__BackingField;
					soundConfig.Rate = forsakenMod._003Crate_003Ek__BackingField;
					hyperMod = (HyperMod)(object)musicData2._003CforsakenMod_003Ek__BackingField;
					goto IL_027a;
				}
			}
			else if (musicData2 != null && musicData2._003ChyperMod_003Ek__BackingField != null)
			{
				HyperMod hyperMod2 = musicData2._003ChyperMod_003Ek__BackingField;
				soundConfig.Rate = hyperMod2._003Crate_003Ek__BackingField;
				hyperMod = musicData2._003ChyperMod_003Ek__BackingField;
				goto IL_027a;
			}
			goto IL_0291;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0291:
		SoundManager.UpdateCurrentMusicWithConfig(SoundManager._003CCurrentMusicSoundConfig_003Ek__BackingField);
		SetSpeedName();
		return;
		IL_027a:
		soundConfig.Detune = hyperMod._003Cdetune_003Ek__BackingField;
		goto IL_0291;
	}

	public void NextPlayback()
	{
		//IL_0072: Expected O, but got I
		List<BgmPlaybackType> playbackList = _playbackList;
		int num = ++_playbackIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmPlaybackType>)+18]");
		if ((nint)num >= (nint)0)
		{
			_playbackIndex = 0;
		}
		int playbackIndex = _playbackIndex;
		int playbackIndex2 = _playbackIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmPlaybackType>)+18]");
		if ((nint)playbackIndex2 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmPlaybackType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4+20+v69 @ rcx_v7 (System.Int32)*4]");
			_selectedPlayback = BgmPlaybackType.Lock_Selected;
			PlayerOptionsData config = _playerOptions.Config;
			config._003CSelectedBGMPlayback_003Ek__BackingField = _selectedPlayback;
			if (_selectedPlayback != BgmPlaybackType.Lock_Selected)
			{
				PlayerOptionsData config2 = _playerOptions.Config;
				config2._003CSelectedBGMSave_003Ek__BackingField = false;
				SetPlaybackName();
			}
			else
			{
				PlayerOptionsData config3 = _playerOptions.Config;
				config3._003CSelectedBGMSave_003Ek__BackingField = true;
				SetPlaybackName();
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void OnInputMethodChanged(UIHelper.ActiveInputType newinput)
	{
		//IL_000e: Expected O, but got I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		object obj = newinput - 1;
		object obj2 = default(object);
		if (obj2 == null)
		{
			object obj3 = obj - 1;
			if (obj2 != null || (nint)obj3 == 1)
			{
				SetTrackNavigation();
			}
		}
		else
		{
			SetUniversalNavigation();
		}
	}

	private void Update()
	{
		//IL_04ad: Expected O, but got I4
		//IL_04c7: Expected O, but got I4
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		//IL_01ad: Invalid comparison between O and F4
		//IL_0351: Invalid comparison between F4 and I4
		if (!_canInteract)
		{
			return;
		}
		if (_navPhase == NavigationPhase.TRACKS)
		{
			EventSystem current = EventSystem.current;
			GameObject currentSelected = current.m_CurrentSelected;
			GameObject gameObject = _CloseButton.gameObject;
			bool flag = (object)gameObject == null;
			bool flag2 = (object)current.m_CurrentSelected == null;
			object obj = flag2 & flag;
			bool flag3 = obj == null;
			object obj2 = !flag3;
			if (obj2 != null)
			{
				return;
			}
			bool flag4;
			if ((object)gameObject != null)
			{
				if ((object)current.m_CurrentSelected != null)
				{
					object obj3 = (object)current.m_CurrentSelected - (object)gameObject;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0;
			}
			if (flag4)
			{
				return;
			}
			float axis = _player.GetAxis("UIHorizontal");
			if (axis > _HorizontalAlbumNavigationSensitivity && _axisReset)
			{
				_Carousel.MovePrevious();
				_axisReset = false;
			}
			float axis2 = _player.GetAxis("UIHorizontal");
			float horizontalAlbumNavigationSensitivity = _HorizontalAlbumNavigationSensitivity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj4 = horizontalAlbumNavigationSensitivity ^ 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)axis2) && _axisReset)
			{
				_Carousel.MoveNext();
				_axisReset = false;
			}
			if (_player.GetButtonDown(5))
			{
				TrackItemUI selectedTrack = _selectedTrack;
				if ((object)_selectedTrack != null && ((UnityEngine.Object)selectedTrack).m_CachedPtr != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
					TrackItemUI selectedTrack2 = _selectedTrack;
					object obj5 = default(object);
					if ((nint)obj5 != (nint)selectedTrack2._bgmType)
					{
						PlayAtSpeed();
					}
					else
					{
						TrackItemUI selectedTrack3 = _selectedTrack;
						selectedTrack3._holdSelection = true;
						_navPhase = NavigationPhase.SETTINGS;
						Button componentInParent = _Modifier.GetComponentInParent<Button>();
						componentInParent.Select();
						VisuallyEnableInfoPanel();
						_AlbumGroup.alpha = 0.6f;
						_TrackGroup.alpha = 0.6f;
					}
				}
			}
			float axis3 = _player.GetAxis("UIHorizontal");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018775FC51h\"");
			if (axis3 == 0f)
			{
				_axisReset = true;
			}
			if (_player.GetButtonDown(10) || _player.GetButtonDown(6))
			{
				ClosePopup();
			}
		}
		else if (_navPhase == NavigationPhase.SETTINGS && (_player.GetButtonDown(10) || _player.GetButtonDown(6)))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 830 Invalid \"Jump target not found in method: 0x18775FF70\"");
			throw new NullReferenceException();
		}
	}

	private void LateUpdate()
	{
	}

	private unsafe void VisuallyDisableInfoPanel()
	{
		//IL_002d: Expected O, but got I4
		//IL_0036: Expected O, but got I4
		//IL_0051: Expected O, but got Ref
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		Graphic[] componentsInChildren = _InfoPanel.GetComponentsInChildren<Graphic>(includeInactive: false);
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		while ((nint)obj2 < componentsInChildren.Length)
		{
			componentsInChildren[obj].color = (Color)(&obj3);
			obj++;
			obj2 = obj;
		}
	}

	private unsafe void VisuallyEnableInfoPanel()
	{
		//IL_002d: Expected O, but got I4
		//IL_0036: Expected O, but got I4
		//IL_0051: Expected O, but got Ref
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		Graphic[] componentsInChildren = _InfoPanel.GetComponentsInChildren<Graphic>(includeInactive: false);
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		while ((nint)obj2 < componentsInChildren.Length)
		{
			componentsInChildren[obj].color = (Color)(&obj3);
			obj++;
			obj2 = obj;
		}
	}

	private void VisuallyDisableTopPanel()
	{
		_AlbumGroup.alpha = 0.6f;
		_TrackGroup.alpha = 0.6f;
	}

	private void VisuallyEnableTopPanel()
	{
		_AlbumGroup.alpha = 1f;
		_TrackGroup.alpha = 1f;
	}

	private unsafe void SetTrackNavigation(Selectable defaultSelected = null)
	{
		//IL_0190: Expected I, but got O
		//IL_00c1: Expected I, but got O
		//IL_02af: Expected I, but got O
		//IL_0163: Expected O, but got Ref
		TrackItemUI selectedTrack = _selectedTrack;
		_navPhase = NavigationPhase.TRACKS;
		Component component2;
		nint num;
		if ((object)_selectedTrack == null || ((UnityEngine.Object)selectedTrack).m_CachedPtr == (IntPtr)0)
		{
			if ((object)defaultSelected == null || ((UnityEngine.Object)defaultSelected).m_CachedPtr == (IntPtr)0)
			{
				List<TrackItemUI> spawnedTracks = _spawnedTracks;
				num = (nint)defaultSelected;
				NavigationPhase navigationPhase = NavigationPhase.TRACKS;
				NavigationPhase navigationPhase2 = NavigationPhase.TRACKS;
				while ((int)navigationPhase < spawnedTracks._size)
				{
					List<TrackItemUI> spawnedTracks2 = _spawnedTracks;
					if ((int)navigationPhase2 < spawnedTracks2._size)
					{
						TrackItemUI[] items = spawnedTracks2._items;
						TrackItemUI component = items[(int)navigationPhase2].GetComponent<TrackItemUI>();
						MusicData data = component._data;
						spawnedTracks = _spawnedTracks;
						if (!data._003CisUnlocked_003Ek__BackingField)
						{
							navigationPhase2++;
							bool flag = _spawnedTracks != null;
							num = 0;
							navigationPhase = navigationPhase2;
							if (!flag)
							{
								throw new NullReferenceException();
							}
							continue;
						}
						goto IL_028b;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					throw new IndexOutOfRangeException();
				}
				goto IL_00df;
			}
		}
		else if ((object)defaultSelected == null || ((UnityEngine.Object)defaultSelected).m_CachedPtr == (IntPtr)0)
		{
			component2 = _selectedTrack;
			goto IL_0360;
		}
		nint num2 = (nint)defaultSelected;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rax_v31 (Il2CppClass<UnityEngine.UI.Selectable>)+3A0]");
		num = 0;
		defaultSelected.Select();
		goto IL_00df;
		IL_0360:
		Selectable component3 = component2.GetComponent<Selectable>();
		nint num3 = (nint)component3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ r8_v2 (Il2CppMethodInfo)+3A0]");
		num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v372 @ r8_v2 (Il2CppMethodInfo)+398] (should have been resolved before IL gen)");
		goto IL_00df;
		IL_00df:
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v742 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Graphic[] componentsInChildren = _InfoPanel.GetComponentsInChildren<Graphic>(includeInactive: false);
		NavigationPhase navigationPhase3 = NavigationPhase.TRACKS;
		NavigationPhase navigationPhase4 = NavigationPhase.TRACKS;
		object obj = default(object);
		while ((int)navigationPhase4 < componentsInChildren.Length)
		{
			componentsInChildren[(int)navigationPhase3].color = (Color)(&obj);
			navigationPhase3++;
			navigationPhase4 = navigationPhase3;
		}
		_AlbumGroup.alpha = 1f;
		_TrackGroup.alpha = 1f;
		return;
		IL_028b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
		Component component4 = default(Component);
		component2 = component4;
		goto IL_0360;
	}

	private int FindAlbumIndexForTrack(BgmType track)
	{
		int result = 0;
		List<KeyValuePair<AlbumType, AlbumData>>.Enumerator enumerator = default(List<KeyValuePair<AlbumType, AlbumData>>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			Enum obj = null;
			Enum obj2 = null;
			throw new NullReferenceException();
		}
		return result;
	}

	private void SetPhase3Navigation()
	{
		TrackItemUI selectedTrack = _selectedTrack;
		selectedTrack._holdSelection = true;
		_navPhase = NavigationPhase.SETTINGS;
		Button componentInParent = _Modifier.GetComponentInParent<Button>();
		componentInParent.Select();
		VisuallyEnableInfoPanel();
		_AlbumGroup.alpha = 0.6f;
		_TrackGroup.alpha = 0.6f;
	}

	private void SetUniversalNavigation()
	{
		_navPhase = NavigationPhase.UNIVERSAL;
		VisuallyEnableInfoPanel();
		_AlbumGroup.alpha = 1f;
		_TrackGroup.alpha = 1f;
	}

	public void SelectNextTrack()
	{
		List<TrackItemUI> spawnedTracks = _spawnedTracks;
		if (_currentTrackIndex < spawnedTracks._size)
		{
			SelectableUI.OnSetSelectorVisibility setSelectorVisibility = SelectableUI.SetSelectorVisibility;
			if (SelectableUI.SetSelectorVisibility != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v267.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			List<TrackItemUI> spawnedTracks2 = _spawnedTracks;
			if (++_currentTrackIndex >= spawnedTracks2._size)
			{
				_currentTrackIndex = 0;
			}
			int currentTrackIndex = _currentTrackIndex;
			if (_currentTrackIndex < spawnedTracks2._size)
			{
				TrackItemUI[] items = spawnedTracks2._items;
				Selectable component = items[currentTrackIndex].GetComponent<Selectable>();
				component.Select();
				UpdateInfoPanel();
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void SelectTrack(TrackItemUI track)
	{
		//IL_0204: Expected O, but got I4
		//IL_021e: Expected O, but got I4
		//IL_0187: Expected I, but got O
		List<TrackItemUI> spawnedTracks = _spawnedTracks;
		int num = 0;
		int num2 = 0;
		SelectableUI selectableUI = default(SelectableUI);
		Component component2 = default(Component);
		while (true)
		{
			if (num2 >= spawnedTracks._size)
			{
				return;
			}
			List<TrackItemUI> spawnedTracks2 = _spawnedTracks;
			if (num >= spawnedTracks2._size)
			{
				break;
			}
			TrackItemUI[] items = spawnedTracks2._items;
			TrackItemUI trackItemUI = items[num];
			bool flag = (object)items[num] == null;
			bool flag2 = (object)track == null;
			object obj = flag2 & flag;
			bool flag3 = obj == null;
			object obj2 = !flag3;
			if (obj2 == null)
			{
				bool flag4;
				if ((object)items[num] != null)
				{
					if ((object)track != null)
					{
						object obj3 = (object)track - (object)items[num];
						flag4 = obj3 == null;
					}
					else
					{
						flag4 = ((UnityEngine.Object)trackItemUI).m_CachedPtr == (IntPtr)0;
					}
				}
				else
				{
					flag4 = ((UnityEngine.Object)track).m_CachedPtr == (IntPtr)0;
				}
				if (!flag4)
				{
					goto IL_0245;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			selectableUI.Deselect();
			_currentTrackIndex = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			Selectable component = component2.GetComponent<Selectable>();
			nint num3 = (nint)component;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v58 @ r8_v5 (Il2CppMethodInfo)+398] (should have been resolved before IL gen)");
			goto IL_0245;
			IL_0245:
			spawnedTracks = _spawnedTracks;
			num++;
			num2 = num;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void SelectPreviousTrack()
	{
		List<TrackItemUI> spawnedTracks = _spawnedTracks;
		if (_currentTrackIndex < spawnedTracks._size)
		{
			SelectableUI.OnSetSelectorVisibility setSelectorVisibility = SelectableUI.SetSelectorVisibility;
			if (SelectableUI.SetSelectorVisibility != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v252.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			int currentTrackIndex = _currentTrackIndex - 1;
			_currentTrackIndex = currentTrackIndex;
			if ((nint)SelectableUI.SetSelectorVisibility < 0)
			{
				List<TrackItemUI> spawnedTracks2 = _spawnedTracks;
				int currentTrackIndex2 = spawnedTracks2._size - 1;
				_currentTrackIndex = currentTrackIndex2;
			}
			List<TrackItemUI> spawnedTracks3 = _spawnedTracks;
			int currentTrackIndex3 = _currentTrackIndex;
			if (_currentTrackIndex < spawnedTracks3._size)
			{
				TrackItemUI[] items = spawnedTracks3._items;
				Selectable component = items[currentTrackIndex3].GetComponent<Selectable>();
				component.Select();
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 221 Invalid \"Jump target not found in method: 0x187760CD0\"");
				throw new NullReferenceException();
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void UpdateInfoPanel()
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected Ref, but got Unknown
		//IL_00f3: Expected I8, but got I4
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected Ref, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected Ref, but got Unknown
		//IL_0243: Expected I8, but got I4
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected Ref, but got Unknown
		TrackItemUI selectedTrack = _selectedTrack;
		MusicData data = selectedTrack._data;
		_Author.enabled = true;
		string text = data._003Csource_003Ek__BackingField;
		string text2 = "";
		if ((object)data._003Csource_003Ek__BackingField == "")
		{
			goto IL_0185;
		}
		if (data._003Csource_003Ek__BackingField != null && "" != null && text._stringLength == text2._stringLength)
		{
			ref byte second = ref *(byte*)("" + 20);
			ulong length = (ulong)(text._stringLength + text._stringLength);
			if (System.SpanHelpers.SequenceEqual(ref *(byte*)(data._003Csource_003Ek__BackingField + 20), ref second, length))
			{
				goto IL_0185;
			}
		}
		TextMeshProUGUI author = _Author;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/musicpanel_origins", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		string text3 = data._003Csource_003Ek__BackingField;
		goto IL_02e7;
		IL_0185:
		string text4 = data._003Cauthor_003Ek__BackingField;
		if ((object)data._003Cauthor_003Ek__BackingField == "")
		{
			goto IL_02c7;
		}
		if (data._003Cauthor_003Ek__BackingField != null && "" != null && text4._stringLength == text2._stringLength)
		{
			ref byte second2 = ref *(byte*)("" + 20);
			ulong length2 = (ulong)(text4._stringLength + text4._stringLength);
			if (System.SpanHelpers.SequenceEqual(ref *(byte*)(data._003Cauthor_003Ek__BackingField + 20), ref second2, length2))
			{
				goto IL_02c7;
			}
		}
		author = _Author;
		translation = LocalizationManager.GetTranslation("lang/musicpanel_author", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		text3 = data._003Cauthor_003Ek__BackingField;
		goto IL_02e7;
		IL_02e7:
		string text5 = translation + " : " + text3;
		author.text = text5;
		return;
		IL_02c7:
		_Author.text = "";
	}

	public void Populate()
	{
		SetTracksUnlocked();
		SpawnAlbums();
		SpawnTracksForAlbum();
	}

	private void SetDefaultAlbumIndex()
	{
		//IL_0072: Expected O, but got I
		//IL_0085: Expected O, but got I4
		//IL_00a2: Expected O, but got I
		//IL_00b7: Expected O, but got I
		List<KeyValuePair<AlbumType, AlbumData>> albums = _albums;
		int num = 0;
		int num2 = 0;
		object obj6 = default(object);
		while (true)
		{
			int num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v9 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.AlbumType, VampireSurvivors.Data.AlbumData>>)+18]");
			if ((nint)num3 >= (nint)0)
			{
				return;
			}
			List<KeyValuePair<AlbumType, AlbumData>> albums2 = _albums;
			int num4 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v10 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.AlbumType, VampireSurvivors.Data.AlbumData>>)+18]");
			if ((nint)num4 >= (nint)0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v10 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.AlbumType, VampireSurvivors.Data.AlbumData>>)+10]");
			object obj = 0;
			object obj2 = num + 2;
			object obj3 = obj2 + obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v8+8+v108 @ rax_v13*8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v9+28]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v10+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				if ((nint)obj6 != -1)
				{
					_albumIndex = num;
				}
			}
			albums = _albums;
			num++;
			num2 = num;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private Selectable GetDefaultSelectedItem()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		List<TrackItemUI> spawnedTracks = _spawnedTracks;
		object obj = 0;
		object obj2 = 0;
		Component component = default(Component);
		while (true)
		{
			if ((nint)obj2 < spawnedTracks._size)
			{
				if ((nint)obj >= spawnedTracks._size)
				{
					break;
				}
				TrackItemUI[] items = spawnedTracks._items;
				TrackItemUI trackItemUI = items[obj];
				if (trackItemUI._bgmType != _defaultSong)
				{
					obj++;
					obj2 = obj;
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				return component.GetComponent<Selectable>();
			}
			if (spawnedTracks._size <= 0)
			{
				break;
			}
			TrackItemUI[] items2 = spawnedTracks._items;
			return items2[0].GetComponent<Selectable>();
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Selectable result = default(Selectable);
		return result;
	}

	private void SpawnAlbums()
	{
		List<KeyValuePair<AlbumType, AlbumData>> albums = _albums;
		if (_albums != null)
		{
			List<KeyValuePair<AlbumType, AlbumData>>.Enumerator enumerator = default(List<KeyValuePair<AlbumType, AlbumData>>.Enumerator);
			if (enumerator.MoveNext())
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(_AlbumPrefab, _AlbumContainer);
				bool flag = (object)gameObject == null;
				GameObject albumPrefab = _AlbumPrefab;
				if (!flag)
				{
					AlbumItemUI component = gameObject.GetComponent<AlbumItemUI>();
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					AlbumData albumData = null;
					albumPrefab = gameObject;
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			if ((object)_Carousel != null)
			{
				_Carousel.Initialize(_spawnedAlbums, _albumIndex);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void SetSelectedTrack(TrackItemUI t)
	{
		TrackItemUI selectedTrack = _selectedTrack;
		if ((object)_selectedTrack != null && ((UnityEngine.Object)selectedTrack).m_CachedPtr != (IntPtr)0)
		{
			TrackItemUI selectedTrack2 = _selectedTrack;
			selectedTrack2._holdSelection = false;
			selectedTrack2.ForceDeselect();
		}
		List<TrackItemUI> spawnedTracks = _spawnedTracks;
		int currentTrackIndex = Array.IndexOf((object[])spawnedTracks._items, (object)t, 0, spawnedTracks._size);
		_currentTrackIndex = currentTrackIndex;
		_selectedTrack = t;
		UpdateInfoPanel();
		UIHelper.ActiveInputType activeInput = UIHelper.ActiveInput;
		if (activeInput == UIHelper.ActiveInputType.MOUSE)
		{
			PlayAtSpeed();
		}
	}

	private unsafe void GenerateTrackNavigation()
	{
		//IL_0017: Expected O, but got I8
		//IL_0337: Expected O, but got Ref
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Expected O, but got Unknown
		//IL_022d: Expected O, but got Ref
		//IL_0523: Expected O, but got I4
		//IL_025e: Expected O, but got I4
		//IL_0282: Expected O, but got I4
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_030c: Expected O, but got I4
		//IL_02d3: Expected O, but got I4
		List<TrackItemUI> spawnedTracks = _spawnedTracks;
		Selectable selectable = null;
		object obj = 4294967295L;
		Selectable selectable2 = null;
		Component component2 = default(Component);
		Component component4 = default(Component);
		Component component6 = default(Component);
		Component component8 = default(Component);
		Component component11 = default(Component);
		object obj4 = default(object);
		while ((nint)selectable2 < spawnedTracks._size)
		{
			object obj2 = obj + 2;
			Selectable selectable3;
			while (true)
			{
				List<TrackItemUI> spawnedTracks2 = _spawnedTracks;
				bool flag = (nint)obj2 >= spawnedTracks2._size;
				selectable3 = null;
				if (flag)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				TrackItemUI component = component2.GetComponent<TrackItemUI>();
				MusicData data = component._data;
				if (!data._003CisUnlocked_003Ek__BackingField)
				{
					obj2++;
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Selectable component3 = component4.GetComponent<Selectable>();
				selectable3 = component3;
				break;
			}
			bool flag2 = (nint)obj < 0;
			object obj3 = obj;
			Selectable selectable4 = null;
			if (!flag2)
			{
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					TrackItemUI component5 = component6.GetComponent<TrackItemUI>();
					MusicData data2 = component5._data;
					if (!data2._003CisUnlocked_003Ek__BackingField)
					{
						obj3--;
						if ((data2._003CisUnlocked_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0))
						{
							selectable4 = null;
							break;
						}
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Selectable component7 = component8.GetComponent<Selectable>();
					selectable4 = component7;
					break;
				}
			}
			if ((object)selectable4 == null || ((UnityEngine.Object)selectable4).m_CachedPtr == (IntPtr)0)
			{
				Selectable component9 = _CloseButton.GetComponent<Selectable>();
				selectable4 = component9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			Selectable component10 = component11.GetComponent<Selectable>();
			component10.navigation = (Navigation)(&obj4);
			bool flag3 = (object)selectable3 == null;
			object obj5 = 0;
			if (!flag3)
			{
				bool flag4 = ((UnityEngine.Object)selectable3).m_CachedPtr == (IntPtr)0;
				obj5 = 0;
				if (!flag4)
				{
					VampireSurvivors.App.Tools.Extensions.SetNavigationDown(component10, selectable3);
					obj5 = 0;
				}
			}
			if ((object)selectable4 != null && ((UnityEngine.Object)selectable4).m_CachedPtr != (IntPtr)0)
			{
				VampireSurvivors.App.Tools.Extensions.SetNavigationUp(component10, selectable4);
				obj5 = 0;
			}
			spawnedTracks = _spawnedTracks;
			selectable = (Selectable)(selectable + 1);
			obj++;
			obj4 = 4;
			selectable2 = selectable;
		}
		Selectable closeButton = _CloseButton;
		_CloseButton.navigation = (Navigation)(&obj4);
		List<TrackItemUI> spawnedTracks3 = _spawnedTracks;
		Selectable selectable5 = null;
		Selectable selectable6 = null;
		Selectable target;
		Component component14 = default(Component);
		while (true)
		{
			bool flag5 = (nint)selectable6 >= spawnedTracks3._size;
			target = null;
			if (flag5)
			{
				break;
			}
			List<TrackItemUI> spawnedTracks4 = _spawnedTracks;
			if ((nint)selectable5 < spawnedTracks4._size)
			{
				TrackItemUI[] items = spawnedTracks4._items;
				TrackItemUI component12 = items[(object)selectable5].GetComponent<TrackItemUI>();
				MusicData data3 = component12._data;
				spawnedTracks3 = _spawnedTracks;
				if (data3._003CisUnlocked_003Ek__BackingField)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Selectable component13 = component14.GetComponent<Selectable>();
					target = component13;
					break;
				}
				selectable5 = (Selectable)(selectable5 + 1);
				bool flag6 = _spawnedTracks != null;
				selectable6 = selectable5;
				if (flag6)
				{
					continue;
				}
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
			throw new NullReferenceException();
		}
		VampireSurvivors.App.Tools.Extensions.SetNavigationDown(_CloseButton, target);
	}

	private unsafe void SetSpeedName()
	{
		//IL_0093: Expected O, but got Ref
		//IL_00a7: Expected O, but got I
		//IL_00b7: Expected O, but got I
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3+B8]");
		object newValue = 0;
		string text2 = text.Replace("BGM_", (string)newValue);
		string text3 = text2.ToLower();
		string term = "lang/musicMod_" + text3;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		_Modifier.text = translation;
	}

	private unsafe void SetPlaybackName()
	{
		//IL_001e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		_Playback.text = text;
	}

	private TrackItemUI SpawnTrack(BgmType t, MusicData d)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(_TrackPrefab, _TrackContainer);
		if ((object)gameObject != null)
		{
			TrackItemUI component = gameObject.GetComponent<TrackItemUI>();
			if (d != null)
			{
				Sprite sprite = SpriteManager.GetSprite(d._003Cicon_003Ek__BackingField);
				if ((object)component != null)
				{
					MusicData data = default(MusicData);
					AdvancedMusicSelection page = default(AdvancedMusicSelection);
					component.SetData(d._003Ctitle_003Ek__BackingField, sprite, t, data, page);
					List<object> spawnedTracks = (List<object>)(object)_spawnedTracks;
					if (_spawnedTracks != null)
					{
						int version = spawnedTracks._version + 1;
						spawnedTracks._version = version;
						object[] items = spawnedTracks._items;
						if (spawnedTracks._items != null)
						{
							if (spawnedTracks._size >= items.Length)
							{
								((List<object>)(object)_spawnedTracks).AddWithResize((object)component);
							}
							else
							{
								int size = spawnedTracks._size + 1;
								spawnedTracks._size = size;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							return component;
						}
					}
				}
			}
		}
		return (TrackItemUI)(object)new NullReferenceException();
	}

	public void ToggleLockSelected(bool b)
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedBGMSave_003Ek__BackingField = b;
	}

	public AdvancedMusicSelection()
	{
		List<KeyValuePair<AlbumType, AlbumData>> albums = new List<KeyValuePair<AlbumType, AlbumData>>();
		_albums = albums;
		_spawnedAlbums = new List<GameObject>();
		_spawnedTracks = new List<TrackItemUI>();
		_speedList = new List<BgmModType>();
		_playbackList = new List<BgmPlaybackType>();
		_selectedPlayback = BgmPlaybackType.None;
		_axisReset = true;
		_currentCacheName = "None";
		_navPhase = NavigationPhase.UNIVERSAL;
		base._002Ector();
	}

	private void _003CStart_003Eb__58_0()
	{
		_canInteract = true;
	}
}
