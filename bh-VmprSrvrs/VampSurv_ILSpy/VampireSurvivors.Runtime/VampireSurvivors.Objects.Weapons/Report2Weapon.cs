using System;
using System.Collections;
using System.Collections.Generic;
using Coherence;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.UI;

namespace VampireSurvivors.Objects.Weapons;

public class Report2Weapon : ReportWeapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__22_0;

		public static TweenCallback _003C_003E9__22_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CScreenShake_003Eb__22_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -3f;
		}

		internal void _003CScreenShake_003Eb__22_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private sealed class _003CPerformVote_003Ed__18(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public Report2Weapon _003C_003E4__this;

		public List<EnemyType> enemyTypes;

		private float _003Ct_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0098: Expected I4, but got I8
			//IL_0029: Expected O, but got I4
			//IL_007f: Expected I4, but got I8
			//IL_0066: Expected I4, but got I8
			//IL_024e: Expected O, but got I4
			//IL_1125: Expected F4, but got I4
			//IL_0791: Expected F4, but got I4
			//IL_113c: Expected O, but got F4
			//IL_1168: Expected F4, but got I4
			//IL_0b65: Expected O, but got I
			//IL_0e4d: Expected I, but got O
			//IL_0a98: Expected F4, but got I4
			//IL_0aa6: Expected F4, but got O
			//IL_0aaf: Expected F4, but got I4
			//IL_0192: Expected F4, but got I4
			//IL_117f: Expected O, but got F4
			//IL_0bf4: Expected I4, but got O
			//IL_0344: Expected O, but got I
			//IL_0c41: Expected I, but got O
			//IL_0cc3: Expected O, but got I4
			//IL_1203: Expected I, but got O
			//IL_1219: Expected O, but got I
			//IL_1222: Unknown result type (might be due to invalid IL or missing references)
			//IL_1227: Expected O, but got Unknown
			//IL_0d5f: Expected I, but got O
			//IL_124d: Expected O, but got I4
			//IL_1264: Expected I, but got I8
			//IL_0407: Expected O, but got I
			//IL_0d3b: Expected I, but got I8
			//IL_0484: Expected O, but got I
			//IL_0850: Expected I4, but got O
			//IL_04d9: Expected O, but got I
			//IL_052e: Expected O, but got I
			//IL_0634: Expected O, but got I
			//IL_06f5: Expected F4, but got I
			//IL_0592: Expected O, but got I
			//IL_0f2a: Expected O, but got Ref
			//IL_0727: Unknown result type (might be due to invalid IL or missing references)
			//IL_072c: Expected O, but got Unknown
			//IL_08a1: Expected I, but got O
			//IL_0750: Expected O, but got I4
			//IL_10f4: Expected F4, but got I4
			//IL_0ac6->IL0db9: Incompatible stack heights: 6 vs 0
			//IL_01a5->IL0e52: Incompatible stack heights: 5 vs 2
			//IL_01aa->IL01aa: Incompatible stack heights: 5 vs 2
			//IL_0fca->IL0d89: Incompatible stack heights: 5 vs 4
			//IL_0c64->IL0c64: Incompatible stack heights: 9 vs 8
			//IL_1023->IL0d89: Incompatible stack heights: 6 vs 4
			//IL_104a->IL0d89: Incompatible stack heights: 6 vs 4
			//IL_0821->IL0d89: Incompatible stack heights: 6 vs 4
			//IL_0d7b->IL0d7b: Incompatible stack heights: 9 vs 0
			//IL_086d->IL0d89: Incompatible stack heights: 6 vs 4
			//IL_10aa->IL0d89: Incompatible stack heights: 7 vs 4
			//IL_08e6->IL0d89: Incompatible stack heights: 7 vs 4
			//IL_06e5->IL0f19: Incompatible stack heights: 24 vs 23
			//IL_08c4->IL08c4: Incompatible stack heights: 8 vs 7
			//IL_075e->IL0f48: Incompatible stack heights: 25 vs 4
			//IL_061a->IL0f14: Incompatible stack heights: 26 vs 23
			//IL_0943->IL0d89: Incompatible stack heights: 7 vs 4
			//IL_1107->IL0ddb: Incompatible stack heights: 8 vs 0
			Report2Weapon report2Weapon = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			Report2VotingScreenOption report2VotingScreenOption;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj != 1)
					{
						goto IL_0d7b;
					}
					_003C_003E1__state = -1;
					report2VotingScreenOption = null;
					goto IL_0db9;
				}
				_003C_003E1__state = -1;
				report2VotingScreenOption = null;
				goto IL_0ddb;
			}
			_003C_003E1__state = -1;
			bool flag2 = (object)_003C_003E4__this == null;
			bool flag3 = (nint)report2Weapon._votingScreenOptionsContainer < 0;
			bool flag4 = (object)report2Weapon._votingScreenOptionsContainer == null;
			int childCount = report2Weapon._votingScreenOptionsContainer.childCount;
			int num = childCount - 1;
			float? num4 = default(float?);
			if (!flag3)
			{
				bool flag8;
				do
				{
					bool flag5 = (object)report2Weapon._votingScreenOptionsContainer == null;
					Transform child = report2Weapon._votingScreenOptionsContainer.GetChild(num);
					bool flag6 = (object)child == null;
					bool flag7 = ((UnityEngine.Object)child).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)child).m_CachedPtr);
					GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
					nint num2 = (nint)typeof(UnityEngine.Object);
					UnityEngine.Object.Destroy(obj2, 0f);
					num--;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3003 @ rcx_v134 (Il2CppClass<UnityEngine.Object>)+E4]");
					flag8 = (nint)0 >= (nint)0;
					float num3 = 0f;
					num4 = num4;
				}
				while (flag8);
			}
			List<Report2VotingScreenOption> votingOptions = report2Weapon._votingOptions;
			bool flag9 = report2Weapon._votingOptions == null;
			int version = votingOptions._version + 1;
			votingOptions._version = version;
			votingOptions._size = 0;
			if (votingOptions._size > 0)
			{
				Array.Clear(votingOptions._items, 0, votingOptions._size);
				object obj3 = 0;
			}
			bool flag10 = enemyTypes == null;
			List<EnemyType> list = enemyTypes;
			Report2VotingScreenOption report2VotingScreenOption2 = null;
			Report2VotingScreenOption report2VotingScreenOption3 = null;
			float value = default(float);
			float num8 = default(float);
			float num9 = default(float);
			float num6 = default(float);
			while (true)
			{
				Report2VotingScreenOption report2VotingScreenOption4 = report2VotingScreenOption3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1942 @ rax_v174 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
				if ((nint)report2VotingScreenOption4 < 0)
				{
					Report2VotingScreenOption report2VotingScreenOption5 = UnityEngine.Object.Instantiate(report2Weapon._votingScreenOptionPrefab, report2Weapon._votingScreenOptionsContainer, worldPositionStays: false);
					bool flag11 = (object)report2VotingScreenOption5 == null;
					bool flag12 = ((UnityEngine.Object)report2VotingScreenOption5).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)report2VotingScreenOption5).m_CachedPtr);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
					bool flag13 = (object)transform == null;
					bool flag14 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
					bool flag15 = report2Weapon._dataManager == null;
					Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = report2Weapon._dataManager.GetConvertedEnemyData();
					List<EnemyType> list2 = enemyTypes;
					bool flag16 = enemyTypes == null;
					Report2VotingScreenOption report2VotingScreenOption6 = report2VotingScreenOption2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2386 @ rcx_v208 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
					bool flag17 = (nint)report2VotingScreenOption6 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2386 @ rcx_v208 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2386 @ rcx_v208 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
					bool flag18 = (nint)0 == 0;
					Report2VotingScreenOption report2VotingScreenOption7 = report2VotingScreenOption2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2383 @ rdx_v101+18]");
					bool flag19 = (nint)report2VotingScreenOption7 >= 0;
					bool flag20 = convertedEnemyData == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2383 @ rdx_v101+20+v278 @ rbp_v36 (VampireSurvivors.Report2VotingScreenOption)*4]");
					object obj5 = ((Dictionary<System.Int32Enum, object>)(object)convertedEnemyData).get_Item((System.Int32Enum)0);
					bool flag21 = obj5 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2435 @ rax_v248 (System.Object)+18]");
					bool flag22 = (nint)0 <= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2435 @ rax_v248 (System.Object)+10]");
					Report2VotingScreenOption report2VotingScreenOption8 = (Report2VotingScreenOption)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2435 @ rax_v248 (System.Object)+10]");
					bool flag23 = (nint)0 == 0;
					bool flag24 = (nint)((MonoBehaviour)report2VotingScreenOption8).m_CancellationTokenSource <= 0;
					Report2VotingScreenOption nineSliceSprite = (Report2VotingScreenOption)(object)report2VotingScreenOption8._nineSliceSprite;
					bool flag25 = (object)report2VotingScreenOption8._nineSliceSprite == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rbx_v49 (VampireSurvivors.Report2VotingScreenOption)+D8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rbx_v49 (VampireSurvivors.Report2VotingScreenOption)+D8]");
					bool flag26 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ rax_v249+18]");
					bool flag27 = (nint)0 <= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ rax_v249+10]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ rax_v249+10]");
					bool flag28 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rcx_v210+18]");
					bool flag29 = (nint)0 <= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rcx_v210+20]");
					string text = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rbx_v49 (VampireSurvivors.Report2VotingScreenOption)+BC]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rcx_v210+20]");
						bool flag30 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rcx_v210+20]");
						string text2 = ((string)0).Replace("_0.png", "");
						bool flag31 = text2 == null;
						string text3 = text2.Replace(".png", "");
						bool flag32 = text3 == null;
						string text4 = text3.Replace("_0", "");
						string text5 = text4 + "_i01";
						text = text5;
					}
					string spriteName = text;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rbx_v49 (VampireSurvivors.Report2VotingScreenOption)+C8]");
					Sprite sprite = SpriteManager.GetSprite(spriteName, (string)0);
					if (nineSliceSprite._screenShakeTween != null)
					{
						bool flag33 = nineSliceSprite._screenShakeTween == null;
						object obj8 = (object)nineSliceSprite._screenShakeTween >> 32;
						object obj9 = obj8 >> 16;
						object obj10 = obj8 >> 8;
						float num5 = (float)obj9 / 255f;
						num6 = (float)obj10 / 255f;
						float num3 = (float)obj8 / 255f;
						float num7 = num8;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
						float num7 = 0f;
						num6 = num8;
					}
					report2VotingScreenOption5.SetVoteTargetSprite(sprite, (Color)(&num9));
					bool flag34 = report2Weapon._votingOptions == null;
					((List<object>)(object)report2Weapon._votingOptions).Add((object)report2VotingScreenOption5);
					list = enemyTypes;
					report2VotingScreenOption2 = (Report2VotingScreenOption)(report2VotingScreenOption2 + 1);
					bool flag35 = enemyTypes == null;
					object obj3 = 0;
					report2VotingScreenOption3 = report2VotingScreenOption2;
					continue;
				}
				break;
			}
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_EmergencyMeeting, 1000f, 10, 0f, num4, rate, detune, loop, 1f);
			object votingScreenDisplay = report2Weapon._votingScreenDisplay;
			if ((object)report2Weapon._votingScreenDisplay != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2325 @ rbx_v40 (System.Object)+10]");
				bool flag36 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2325 @ rbx_v40 (System.Object)+10]");
				IntPtr gcHandlePtr3 = GameObject.get_transform_Injected((IntPtr)0);
				Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
				if ((object)transform2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2932 @ rax_v184 (UnityEngine.Transform)+10]");
					bool flag37 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2932 @ rax_v184 (UnityEngine.Transform)+10]");
					Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value));
					if (UIHelper.IsPortrait)
					{
					}
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
						{
							TweenConfig tweenConfig = new TweenConfig();
							object[] array = new object[1];
							int num10 = (int)report2Weapon._votingScreenDisplay;
							if ((object)report2Weapon._votingScreenDisplay != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2233 @ rsi_v43 (System.Int32)+10]");
								bool flag38 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2233 @ rsi_v43 (System.Int32)+10]");
								IntPtr gcHandlePtr4 = GameObject.get_transform_Injected((IntPtr)0);
								Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
								if (array != null)
								{
									if ((object)transform3 != null)
									{
										nint num11 = (nint)array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj11 = default(object);
										bool flag39 = obj11 == null;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig != null)
									{
										_ = 1140457472;
										_ = 1;
										_ = 1;
										MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
										Transform votingScreenDisplay2 = (Transform)(object)report2Weapon._votingScreenDisplay;
										if ((object)report2Weapon._votingScreenDisplay != null)
										{
											bool flag40 = ((UnityEngine.Object)votingScreenDisplay2).m_CachedPtr == (IntPtr)0;
											GameObject.SetActive_Injected(((UnityEngine.Object)votingScreenDisplay2).m_CachedPtr, true);
											_003Ct_003E5__2 = 0f;
											float num7 = 0f;
											report2VotingScreenOption = null;
											float num3 = 10f;
											goto IL_0ddb;
										}
									}
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
			IL_1244:
			object obj12 = 24;
			TweenCallback tweenCallback;
			((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
			TweenConfig tweenConfig2;
			tweenConfig2.onComplete = tweenCallback;
			MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
			goto IL_0d7b;
			IL_0db9:
			if (!(0.5f > _003Ct_003E5__2))
			{
				bool flag41 = (object)_003C_003E4__this == null;
				List<EnemyType> list3 = enemyTypes;
				int voteTarget = report2Weapon._voteTarget;
				bool flag42 = enemyTypes == null;
				int voteTarget2 = report2Weapon._voteTarget;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ rax_v88 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
				bool flag43 = (nint)voteTarget2 >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ rax_v88 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
				object obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ rax_v88 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
				bool flag44 = (nint)0 == 0;
				int voteTarget3 = report2Weapon._voteTarget;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rcx_v76+18]");
				bool flag45 = (nint)voteTarget3 >= (nint)0;
				Report2Weapon report2Weapon2 = _003C_003E4__this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rcx_v76+20+v322 @ r8_v36 (System.Int32)*4]");
				report2Weapon2.EraseEnemyType(EnemyType.BAT1);
				tweenConfig2 = new TweenConfig();
				object[] array2 = new object[1];
				int num12 = (int)report2Weapon._votingScreenDisplay;
				bool flag46 = (object)report2Weapon._votingScreenDisplay == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rsi_v31 (System.Int32)+10]");
				bool flag47 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rsi_v31 (System.Int32)+10]");
				IntPtr gcHandlePtr5 = GameObject.get_transform_Injected((IntPtr)0);
				Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
				bool flag48 = array2 == null;
				if ((object)transform4 != null)
				{
					nint num13 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj14 = default(object);
					bool flag49 = obj14 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				bool flag50 = tweenConfig2 == null;
				tweenConfig2.targets = array2;
				tweenConfig2.duration = 500f;
				tweenConfig2.delay = 750f;
				tweenConfig2.localY = (float?)(object)1;
				tweenCallback = null;
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ r10_v30 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback).method = (nint)__ldftn(Report2Weapon.HideVotingScreen);
				((Delegate)tweenCallback).m_target = _003C_003E4__this;
				((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ r10_v30 (Il2CppMethodInfo)+4C]");
				object obj15 = (nint)0 >> 4;
				object obj16 = obj15 & 1;
				nint num15;
				if (obj16 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ r10_v30 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num15 = unchecked((nint)6447293664L);
						goto IL_1244;
					}
				}
				num15 = ((Delegate)tweenCallback).method_ptr;
				((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
				goto IL_1244;
			}
			bool flag51 = PauseSystem._paused;
			float num16 = 0f;
			if (!flag51)
			{
				object obj17 = Time.deltaTime;
				num16 = num6;
			}
			float num17 = num16 + _003Ct_003E5__2;
			_003C_003E2__current = report2VotingScreenOption;
			_003Ct_003E5__2 = num17;
			_003C_003E1__state = 2;
			goto IL_118c;
			IL_118c:
			return true;
			IL_0d7b:
			return false;
			IL_0ddb:
			if (!(0.75f > _003Ct_003E5__2))
			{
				bool flag52 = (object)_003C_003E4__this == null;
				List<Report2VotingScreenOption> votingOptions2 = report2Weapon._votingOptions;
				int voteTarget4 = report2Weapon._voteTarget;
				bool flag53 = report2Weapon._votingOptions == null;
				bool flag54 = report2Weapon._voteTarget >= votingOptions2._size;
				Report2VotingScreenOption[] items = votingOptions2._items;
				bool flag55 = votingOptions2._items == null;
				bool flag56 = report2Weapon._voteTarget >= items.Length;
				bool flag57 = (object)items[voteTarget4] == null;
				items[voteTarget4].AddVote();
				PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_VoteScreenPlayerDead, 1250f, 10, 0f, num4, rate, detune, loop, 1f);
				_003Ct_003E5__2 = (float)report2VotingScreenOption;
				float num7 = 0f;
				num6 = 0.4f;
				float num3 = 1250f;
				goto IL_0db9;
			}
			bool flag58 = PauseSystem._paused;
			float num18 = 0f;
			if (!flag58)
			{
				object obj18 = Time.deltaTime;
				num18 = 0.75f;
			}
			float num19 = num18 + _003Ct_003E5__2;
			_003C_003E2__current = report2VotingScreenOption;
			_003Ct_003E5__2 = num19;
			_003C_003E1__state = 1;
			goto IL_118c;
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

	private GameObject _votingScreenDisplay;

	private Report2VotingScreenOption _votingScreenOptionPrefab;

	private Transform _votingScreenOptionsContainer;

	private SpriteRenderer _votingScreenBackground;

	private List<Report2VotingScreenOption> _votingOptions;

	private int _voteTarget;

	private float _votingTimer;

	private bool _isVotingScreenOpen;

	private float _votingDelay;

	private MultiTargetTween _screenShakeTween;

	private bool _shouldBeVisible;

	public float VotingInterval()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldownFinal(0.35f);
		object obj = default(object);
		return (float)obj * _votingDelay;
	}

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Screen_9slice", "vfx");
		_votingScreenBackground.sprite = sprite;
		Vector2 size = default(Vector2);
		_votingScreenBackground.size = size;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		((Weapon)this).InitWeapon(characterController, weaponType);
		GameObject gameObject = base._reportImage.gameObject;
		gameObject.SetActive(value: false);
		base._deadBodyDisplay.SetActive(value: false);
		_votingScreenDisplay.SetActive(value: false);
		Transform transform = _votingScreenDisplay.transform;
		Camera main = Camera.main;
		Transform parent = main.transform;
		transform.SetParent(parent, worldPositionStays: true);
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if (characterController._isDead || characterController.IsDisconnectedFromOnlinePlay)
		{
			return;
		}
		float deltaTime = PauseSystem.DeltaTime;
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num = (_votingTimer = deltaTime + _votingTimer);
		float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldown();
		float num3 = num + characterController2._003CSilentCooldown_003Ek__BackingField;
		bool flag = !(0.1f < num3);
		float num4 = 0.1f;
		if (!flag)
		{
			num4 = num3;
		}
		float num5 = num4 * _votingDelay;
		if (_votingTimer > num5 && !_isVotingScreenOpen && _shouldBeVisible)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
			if (characterController3._coherenceSync.HasStateAuthority)
			{
				_votingTimer = 0f;
				_isVotingScreenOpen = true;
				ShowVotingScreen();
			}
		}
	}

	private void EmergencyMeeting()
	{
		_isVotingScreenOpen = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x1873CC770\"");
	}

	private void ShowVotingScreen()
	{
		//IL_007e: Expected I, but got O
		//IL_044e: Expected O, but got I
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Expected O, but got Unknown
		//IL_04c3: Expected O, but got I
		//IL_0668: Expected O, but got I4
		//IL_04ae: Expected O, but got I8
		GameManager core = GM.Core;
		VampireSurvivors.Objects.Characters.CharacterController characterController;
		Action<long, byte[], int> action;
		if ((object)GM.Core != null)
		{
			PhysicsGroup enemies = core.Enemies;
			if (core.Enemies != null)
			{
				List<EnemyType> list = new List<EnemyType>();
				if (((Group)enemies).children != null)
				{
					HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
					if (enumerator.MoveNext())
					{
						nint num = (nint)typeof(EnemyController);
						int num2 = 0;
						int num3 = 0;
						throw new NullReferenceException();
					}
					if (list != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rax_v18 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
						if ((nint)0 <= (nint)0)
						{
							HideVotingScreen();
							return;
						}
						Extensions.Shuffle(list);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rax_v18 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
						if ((nint)0 > (nint)4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rax_v18 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
							int num3 = (int)(-4);
							list.RemoveRange(4, num3);
							nint num4 = 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rax_v18 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
						int voteTarget = UnityEngine.Random.RandomRangeInt(0, 0);
						_voteTarget = voteTarget;
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null && core2._multiplayer != null)
						{
							if (!core2._multiplayer.IsOnlineMultiplayer)
							{
								IEnumerator routine = PerformVote(list);
								Coroutine coroutine = StartCoroutine(routine);
								return;
							}
							byte[] array = SerializationUtils.SerializeEnum(list);
							characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
							{
								action = null;
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r9_v10 (Il2CppMethodInfo)+8]");
								_ = 0;
								_ = 0;
								_ = ((Equipment)this)._003COwner_003Ek__BackingField;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r9_v10 (Il2CppMethodInfo)+4C]");
								object obj = (nint)0 >> 4;
								object obj2 = obj & 1;
								object obj3;
								if (obj2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r9_v10 (Il2CppMethodInfo)+52]");
									if ((nint)0 == 3)
									{
										obj3 = 6447779152L;
										goto IL_065f;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v901 @ rax_v36 (System.Action`3<System.Int64, System.Byte[], System.Int32>)+10]");
								obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v901 @ rax_v36 (System.Action`3<System.Int64, System.Byte[], System.Int32>)+20]");
								_ = 0;
								goto IL_065f;
							}
						}
					}
				}
			}
		}
		goto IL_053c;
		IL_065f:
		object obj4 = 24;
		_ = 6447779024L;
		if ((object)OnlineStageManager._instance != null)
		{
			long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
			if ((object)characterController._coherenceSync != null)
			{
				object param = default(object);
				int param2 = default(int);
				bool flag = characterController._coherenceSync.SendCommand((Action<long, object, int>)action, MessageTarget.All, startingOnlineClientFrame, param, param2);
				return;
			}
		}
		goto IL_053c;
		IL_053c:
		throw new NullReferenceException();
	}

	public unsafe void OnlinePerformVote(List<EnemyType> enemyTypes, int voteTarget)
	{
		//IL_018b: Expected O, but got Ref
		//IL_01c6: Expected O, but got I
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_00ad: Expected O, but got Ref
		_voteTarget = voteTarget;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		System.ParamsArray paramsArray2 = default(System.ParamsArray);
		string text = string.FormatHelper((IFormatProvider)null, "Vote Target: {0}. Enemies: ", (System.ParamsArray)(&paramsArray2));
		string text2 = null;
		string text3 = text;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		int num = default(int);
		System.ParamsArray paramsArray3 = default(System.ParamsArray);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ stack_-B8_v7+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ stack_-B8_v7+18]");
					if ((nint)obj3 < 0)
					{
						obj4++;
						object arg2 = (EnemyType)num;
						paramsArray2 = new System.ParamsArray(arg2);
						string text4 = string.FormatHelper((IFormatProvider)null, "{0}, ", (System.ParamsArray)(&paramsArray3));
						string text5 = text3 + text4;
						text3 = text5;
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag = obj == null;
		text2 = (string)0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ stack_-B8_v7+1C]");
			if (obj2 == null)
			{
				Debug.Log(text3);
				IEnumerator routine = PerformVote(enemyTypes);
				Coroutine coroutine = StartCoroutine(routine);
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			text2 = null;
		}
		throw new NullReferenceException();
	}

	private IEnumerator PerformVote(List<EnemyType> enemyTypes)
	{
		_003CPerformVote_003Ed__18 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.enemyTypes = enemyTypes;
		return obj;
	}

	private float GetTargetVotingScreenDisplayLocalYPos()
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		float num = ((!UIHelper.IsPortrait) ? 0.7f : 2f);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float height = renderer.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj = height ^ 0;
		float num2 = (float)obj * 0.5f;
		return num2 + num;
	}

	private void EraseEnemyType(EnemyType type)
	{
		//IL_0050: Expected O, but got I4
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01d5: Expected O, but got I4
		//IL_0125: Expected O, but got I4
		//IL_0183: Invalid comparison between F4 and I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
		bool flag = (nint)stage._spawnedEnemies < 0;
		object obj = spawnedEnemies._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			List<EnemyController> spawnedEnemies2 = stage2._spawnedEnemies;
			if ((nint)obj >= spawnedEnemies2._size)
			{
				break;
			}
			EnemyController[] items = spawnedEnemies2._items;
			EnemyController enemyController = items[obj];
			bool flag2 = (nint)items[obj] < 0;
			if ((object)items[obj] != null)
			{
				flag2 = (nint)((UnityEngine.Object)enemyController).m_CachedPtr < 0;
				if (((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
				{
					object obj2 = enemyController._enemyType - type;
					flag2 = (nint)obj2 < 0;
					if (enemyController._enemyType == type)
					{
						float value = enemyController._maxHp;
						float num = 66f - enemyController._maxHp;
						flag2 = num < 0f;
						if (66f > enemyController._maxHp)
						{
							value = 66f;
						}
						items[obj].GetDamaged(value, HitVfxType.None, 0f, WeaponType.VOID, hasKb: false);
						ScreenShake();
					}
				}
			}
			obj--;
			object obj3 = !flag2;
			if (obj3 == null)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void HideVotingScreen()
	{
		//IL_0018: Expected O, but got Ref
		if (_votingOptions != null)
		{
			List<Report2VotingScreenOption>.Enumerator enumerator = default(List<Report2VotingScreenOption>.Enumerator);
			if (enumerator.MoveNext())
			{
				GameObject gameObject = null;
				List<Report2VotingScreenOption>.Enumerator enumerator2 = (List<Report2VotingScreenOption>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			GameObject votingScreenDisplay = _votingScreenDisplay;
			if ((object)_votingScreenDisplay != null)
			{
				bool flag = ((UnityEngine.Object)votingScreenDisplay).m_CachedPtr == (IntPtr)0;
				GameObject.SetActive_Injected(((UnityEngine.Object)votingScreenDisplay).m_CachedPtr, false);
				_isVotingScreenOpen = false;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void ScreenShake()
	{
		//IL_00e2: Expected I, but got O
		//IL_0162: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CScreenShakeEnabled_003Ek__BackingField)
		{
			return;
		}
		if (_screenShakeTween != null)
		{
			_screenShakeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		if (main.followOffset != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 24f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = 12;
		tweenConfig.x = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__22_0;
		if (_003C_003Ec._003C_003E9__22_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__22_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = -3f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__22_1;
		if (_003C_003Ec._003C_003E9__22_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__22_1 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = 0f;
				followOffset.y = 0f;
			});
		}
		tweenConfig.onComplete = onComplete;
		MultiTargetTween screenShakeTween = Tweens.Add(tweenConfig);
		_screenShakeTween = screenShakeTween;
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		_shouldBeVisible = visible;
	}

	public Report2Weapon()
	{
		List<Report2VotingScreenOption> votingOptions = new List<Report2VotingScreenOption>();
		_votingOptions = votingOptions;
		_votingDelay = 15f;
		_shouldBeVisible = true;
		List<VampireSurvivors.Objects.Characters.CharacterController> reportedPlayers = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		base._reportedPlayers = reportedPlayers;
		((Weapon)this)._002Ector();
	}
}
