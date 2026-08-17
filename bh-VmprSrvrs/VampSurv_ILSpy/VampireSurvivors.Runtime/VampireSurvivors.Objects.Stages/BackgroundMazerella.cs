using System;
using System.Collections.Generic;
using System.Linq;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using SuperTiled2Unity;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundMazerella : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Tilemap, bool> _003C_003E9__16_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe bool _003CCreate_003Eb__16_0(Tilemap layer)
		{
			//IL_0135: Expected I4, but got O
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Expected Ref, but got Unknown
			//IL_00f2: Expected I8, but got I4
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3DB6]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)layer != null)
			{
				string name = ((UnityEngine.Object)layer).GetName();
				object obj = "Walls";
				if ((object)name != "Walls")
				{
					if (name != null && "Walls" != null)
					{
						int stringLength = name._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2+10]");
						if ((nint)stringLength == 0)
						{
							ref byte first = ref *(byte*)(name + 20);
							ulong length = (ulong)(name._stringLength + name._stringLength);
							return System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Walls" + 20), length);
						}
					}
					return false;
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private const float DancerSpawnDistanceFromPlayerSpawn = 1f;

	private const string LeftRelicName = "StartLeft";

	private const string RightRelicName = "StartRight";

	private const string PlayerSpawnName = "PlayerStart";

	private const string LeftDeadEndName = "DancerDeadEndLeft";

	private const string RightDeadEndName = "DancerDeadEndRight";

	private Bounds _leftDeadEndBounds;

	private Bounds _rightDeadEndBounds;

	private MazerellaDancerMazeNavigation _mazeNavigation;

	private const int PlayerStartNavigationNodeIndex = 84;

	private VampireSurvivors.Objects.Characters.CharacterController _player;

	private MazerellaTorinoSecretPositions _torinoSecretPositions;

	private EX_Boss_Colossus _colossus;

	private bool _colossusHasLeftMap;

	private bool _torinoUnlocked;

	private bool _isInverse;

	public unsafe override void Create()
	{
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected O, but got Unknown
		//IL_04bf: Expected O, but got Ref
		base.Create();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		GameObject defaultSupportMap = stage._tilingTileset.DefaultSupportMap;
		GameManager core2 = GM.Core;
		GameSessionData gameSessionData = core2._gameSessionData;
		_player = gameSessionData._activeCharacter;
		if ((object)defaultSupportMap != null && ((UnityEngine.Object)defaultSupportMap).m_CachedPtr != (IntPtr)0)
		{
			defaultSupportMap.SetActive(value: true);
			MazerellaDancerMazeNavigation component = defaultSupportMap.GetComponent<MazerellaDancerMazeNavigation>();
			_mazeNavigation = component;
			GameManager core3 = GM.Core;
			Stage stage2 = core3._stage;
			List<Tilemap> allLayers = stage2._tilingTileset.GetAllLayers();
			Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__16_0;
			if (_003C_003Ec._003C_003E9__16_0 == null)
			{
				predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__16_0 = delegate(Tilemap layer)
				{
					//IL_0135: Expected I4, but got O
					//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
					//IL_00db: Expected Ref, but got Unknown
					//IL_00f2: Expected I8, but got I4
					//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
					//IL_0101: Expected Ref, but got Unknown
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3DB6]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if ((object)layer == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					string text = ((UnityEngine.Object)layer).GetName();
					object obj4 = "Walls";
					if ((object)text != "Walls")
					{
						if (text != null && "Walls" != null)
						{
							int stringLength = text._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2+10]");
							if ((nint)stringLength == 0)
							{
								ref byte first = ref *(byte*)(text + 20);
								ulong length = (ulong)(text._stringLength + text._stringLength);
								return System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Walls" + 20), length);
							}
						}
						return false;
					}
					return true;
				});
			}
			object walls = Enumerable.FirstOrDefault(allLayers, predicate);
			_mazeNavigation.CreateNodes();
			_mazeNavigation.ProcessNavigationNodes((Tilemap)walls);
			_mazeNavigation.PrecalculateNavigationWeights();
			_mazeNavigation.CachePathBetweenDanceFloors();
			GameManager core4 = GM.Core;
			GameSessionData gameSessionData2 = core4._gameSessionData;
			Transform playerTransform = gameSessionData2._activeCharacter.transform;
			_mazeNavigation.UpdateNearestPositionToPlayer(playerTransform);
			CreateBoss();
			_leftDeadEndBounds = (Bounds)GenerateDeadEndBounds(EnemyMazerellaDancer.DancerSide.Left, stage._tilingTileset).m_Center;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v941 @ rax_v48 (UnityEngine.Bounds)+10]");
			_ = 0;
			_rightDeadEndBounds = (Bounds)GenerateDeadEndBounds(EnemyMazerellaDancer.DancerSide.Right, stage._tilingTileset).m_Center;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v945 @ rax_v49 (UnityEngine.Bounds)+10]");
			_ = 0;
			bool isInverse = GM.Core.IsStageVisuallyInverted();
			_isInverse = isInverse;
			GameManager core5 = GM.Core;
			PlayerOptionsData config = core5._playerOptions.Config;
			List<CharacterType> list = config._003CUnlockedCharacters_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rcx_v44 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			bool torinoUnlocked;
			if ((nint)0 == 0)
			{
				EnemyMazerellaDancer.DancerSide dancerSide = EnemyMazerellaDancer.DancerSide.Right;
				torinoUnlocked = false;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj2 = default(object);
				object obj = obj2 - -1;
				bool flag = obj == null;
				torinoUnlocked = !flag;
				EnemyMazerellaDancer.DancerSide dancerSide = EnemyMazerellaDancer.DancerSide.Left;
			}
			_torinoUnlocked = torinoUnlocked;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj3 = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Torino secret unlocked: {0}", (System.ParamsArray)(&obj3));
			Debug.Log(message);
			MazerellaTorinoSecretPositions component2 = defaultSupportMap.GetComponent<MazerellaTorinoSecretPositions>();
			_torinoSecretPositions = component2;
			GameManager core6 = GM.Core;
			if (!core6._multiplayer.IsOnlineMultiplayer || GM.Core.IsStageHost)
			{
				List<SuperObject> scriptsFromName = stage._tilingTileset.GetScriptsFromName("PlayerStart");
				SuperObject superObject = Enumerable.FirstOrDefault(scriptsFromName);
				if ((object)superObject != null && ((UnityEngine.Object)superObject).m_CachedPtr != (IntPtr)0)
				{
					SpawnDancer(superObject, EnemyMazerellaDancer.DancerSide.Left);
					SpawnDancer(superObject, EnemyMazerellaDancer.DancerSide.Right);
				}
				else
				{
					Debug.LogError("Couldn't find superObject with name PlayerStart");
				}
			}
		}
		else
		{
			Exception exception = new Exception("Couldn't find support map");
			Debug.LogException(exception);
		}
	}

	public void SetColossus(EX_Boss_Colossus colossus)
	{
		_colossus = colossus;
	}

	private unsafe Bounds GenerateDeadEndBounds(EnemyMazerellaDancer.DancerSide dancerSide, TilingTileset tilingTileset)
	{
		//IL_00d8: Expected native int or pointer, but got O
		//IL_0089: Expected O, but got I4
		//IL_0084: Expected native int or pointer, but got O
		bool flag = dancerSide != EnemyMazerellaDancer.DancerSide.Left;
		string text = "DancerDeadEndRight";
		if (!flag)
		{
			text = "DancerDeadEndLeft";
		}
		if ((object)tilingTileset != null)
		{
			List<Rectangle> scriptRectangularLocations = tilingTileset.GetScriptRectangularLocations(text, autoScaleAndOffset: true);
			Rectangle rectangle = Enumerable.FirstOrDefault(scriptRectangularLocations);
			Bounds bounds = default(Bounds);
			if (rectangle == null)
			{
				string message = "Couldn't find script rectangle with name " + text;
				Debug.LogError(message);
				((Bounds*)(nint)bounds)->m_Center = (Vector3)0;
				_ = 0;
				return bounds;
			}
			Vector3 center = default(Vector3);
			((Bounds*)(nint)bounds)->m_Center = center;
			return bounds;
		}
		return (Bounds)new NullReferenceException();
	}

	private unsafe void CreateBoss()
	{
		//IL_0082: Expected O, but got Ref
		GameManager core = GM.Core;
		Stage stage = core._stage;
		List<SuperObject> scriptsFromName = stage._tilingTileset.GetScriptsFromName("BossSpawn");
		List<SuperObject>.Enumerator enumerator = default(List<SuperObject>.Enumerator);
		if (scriptsFromName != null && scriptsFromName._size > 0 && enumerator.MoveNext())
		{
			List<SuperObject>.Enumerator enumerator2 = (List<SuperObject>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private void SpawnDancers(TilingTileset tilingTileset)
	{
		List<SuperObject> scriptsFromName = tilingTileset.GetScriptsFromName("PlayerStart");
		SuperObject superObject = Enumerable.FirstOrDefault(scriptsFromName);
		if ((object)superObject != null && ((UnityEngine.Object)superObject).m_CachedPtr != (IntPtr)0)
		{
			SpawnDancer(superObject, EnemyMazerellaDancer.DancerSide.Left);
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 166 Invalid \"Jump target not found in method: 0x186F85720\"");
		}
		Debug.LogError("Couldn't find superObject with name PlayerStart");
	}

	private void SpawnDancer(SuperObject playerSpawnPoint, EnemyMazerellaDancer.DancerSide dancerSide)
	{
		//IL_0181: Expected O, but got I4
		//IL_01b7: Expected O, but got I
		//IL_021e: Expected O, but got I
		//IL_01ff: Expected O, but got I
		//IL_0367: Expected O, but got I
		//IL_0367: Expected O, but got I
		//IL_0377: Expected O, but got I
		//IL_0386: Expected O, but got I4
		//IL_0663: Expected O, but got I
		//IL_0679: Expected O, but got I
		//IL_0532->IL04ad: Incompatible stack heights: 1 vs 0
		//IL_0060->IL04ad: Incompatible stack heights: 1 vs 0
		//IL_0093->IL04ad: Incompatible stack heights: 1 vs 0
		//IL_00c2->IL04ad: Incompatible stack heights: 1 vs 0
		//IL_0112->IL04ad: Incompatible stack heights: 2 vs 0
		//IL_0149->IL04ad: Incompatible stack heights: 3 vs 0
		//IL_0574->IL04ad: Incompatible stack heights: 3 vs 0
		//IL_01a1->IL04ad: Incompatible stack heights: 3 vs 0
		//IL_05a5->IL04ad: Incompatible stack heights: 3 vs 0
		//IL_024d->IL04ad: Incompatible stack heights: 3 vs 0
		//IL_05c7->IL04ad: Incompatible stack heights: 3 vs 0
		//IL_064e->IL04ad: Incompatible stack heights: 3 vs 0
		//IL_0311->IL04ad: Incompatible stack heights: 3 vs 0
		//IL_03b0->IL04ad: Incompatible stack heights: 3 vs 0
		//IL_062e->IL0345: Incompatible stack heights: 4 vs 3
		//IL_0697->IL03f6: Incompatible stack heights: 4 vs 3
		//IL_049d->IL04ad: Incompatible stack heights: 3 vs 0
		if (dancerSide == EnemyMazerellaDancer.DancerSide.Left)
		{
		}
		if ((object)playerSpawnPoint != null)
		{
			Transform transform = playerSpawnPoint.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				GameManager core = GM.Core;
				if ((object)GM.Core != null && (object)core._stage != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
					MazerellaDancerMazeNavigation mazeNavigation = _mazeNavigation;
					if ((object)_mazeNavigation != null)
					{
						List<MazerellaDancerMazeNavigation.NavigationNode> list = mazeNavigation._003CNavigationNodes_003Ek__BackingField;
						if (mazeNavigation._003CNavigationNodes_003Ek__BackingField != null)
						{
							bool flag2 = list._size <= 84;
							MazerellaDancerMazeNavigation.NavigationNode[] items = list._items;
							if (list._items != null)
							{
								bool flag3 = items.Length <= 84;
								bool flag4 = default(bool);
								if (flag4)
								{
									_ = 0;
									Action<bool> action = null;
									((EnemyMazerellaDancer)(object)action).InitAnimsCommand(flag4);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v29 (System.Boolean)+2C8]");
									if ((nint)0 != 0)
									{
										bool flag5 = dancerSide == EnemyMazerellaDancer.DancerSide.Left;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F5C410");
										_ = _mazeNavigation;
										((EnemyController)flag4).RetargetIfNecessary();
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v29 (System.Boolean)+F8]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v29 (System.Boolean)+F8]");
											VampireSurvivors.Objects.Characters.CharacterController component = ((Component)0).GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
											if (dancerSide == EnemyMazerellaDancer.DancerSide.Left)
											{
												Bounds leftDeadEndBounds = _leftDeadEndBounds;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundMazerella)+90]");
												object obj = 0;
											}
											else
											{
												Bounds leftDeadEndBounds = _rightDeadEndBounds;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundMazerella)+A8]");
												object obj = 0;
											}
											GameManager core2 = GM.Core;
											if ((object)GM.Core != null)
											{
												Stage stage = core2._stage;
												if ((object)core2._stage != null)
												{
													bool flag6 = dancerSide != EnemyMazerellaDancer.DancerSide.Left;
													Transform transform2 = (Transform)(object)"StartRight";
													if (!flag6)
													{
														transform2 = (Transform)(object)"StartLeft";
													}
													if ((object)stage._tilingTileset != null)
													{
														List<SuperObject> scriptsFromName = stage._tilingTileset.GetScriptsFromName((string)(object)transform2);
														SuperObject superObject = Enumerable.FirstOrDefault(scriptsFromName);
														if ((object)superObject != null && ((UnityEngine.Object)superObject).m_CachedPtr != (IntPtr)0)
														{
															Transform transform3 = superObject.transform;
															if ((object)transform3 == null)
															{
																goto IL_04ad;
															}
															bool flag7 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
															Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
															_ = 0;
														}
														else
														{
															string message = "Couldn't find superObject with name " + (string)(object)transform2;
															Debug.LogError(message);
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v29 (System.Boolean)+270]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v29 (System.Boolean)+270]");
															nint num = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v29 (System.Boolean)+88]");
															((MazerellaDancerMagnet)num).InitMagnet((Transform)0);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v29 (System.Boolean)+270]");
															object obj2 = 0;
															Action b = ((EnemyMazerellaDancer)flag4)._003CInitMagnet_003Eb__34_0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v29 (System.Boolean)+270]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rsi_v12+88]");
																Transform transform4 = (Transform)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v29 (System.Boolean)+270]");
																object obj3 = (nint)0 + (nint)136;
																bool flag12;
																do
																{
																	Delegate obj4 = Delegate.Combine((Delegate)(object)transform4, b);
																	bool flag8 = (object)obj4 == null;
																	Delegate obj5 = null;
																	if (!flag8)
																	{
																		bool flag9 = (object)obj4.GetType() != typeof(Action);
																		obj5 = null;
																		if (!flag9)
																		{
																			obj5 = obj4;
																		}
																		bool flag10 = (object)obj5 == null;
																	}
																	bool flag11 = transform4 == obj3;
																	Transform transform5;
																	if (transform4 == obj3)
																	{
																		obj3 = obj5;
																		transform5 = transform4;
																	}
																	else
																	{
																		transform5 = (Transform)obj3;
																	}
																	Transform transform6 = transform4;
																	if (!flag11)
																	{
																		transform6 = transform5;
																	}
																	flag12 = (object)transform6 != transform4;
																	transform4 = transform6;
																}
																while (flag12);
																MazerellaDancerMazeNavigation mazeNavigation2 = _mazeNavigation;
																if ((object)_mazeNavigation != null)
																{
																	_ = mazeNavigation2._003CCurrentTotalNormalizedPosition_003Ek__BackingField;
																	return;
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
		goto IL_04ad;
		IL_04ad:
		throw new NullReferenceException();
	}

	private unsafe void CheckForTorinoUnlock()
	{
		//IL_0164: Invalid comparison between F4 and I4
		//IL_018d: Expected O, but got I4
		//IL_0253: Expected O, but got I4
		//IL_0216: Expected O, but got I
		if (_torinoUnlocked || _isInverse || !_colossus)
		{
			return;
		}
		Component colossus = _colossus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rax_v7 (UnityEngine.Component)+260]");
		if ((nint)0 != 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rax_v7 (UnityEngine.Component)+444]");
		if ((nint)0 != 7)
		{
			return;
		}
		Transform transform = colossus.transform;
		Vector3 position = transform.position;
		MazerellaTorinoSecretPositions torinoSecretPositions = _torinoSecretPositions;
		Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
		Transform transform2 = _colossus.transform;
		Vector3 position2 = transform2.position;
		MazerellaTorinoSecretPositions torinoSecretPositions2 = _torinoSecretPositions;
		bool flag = torinoSecretPositions._colossusOutsideMapYThreshold < position.y;
		float num = torinoSecretPositions._colossusOutsideMapYThreshold - position.y;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj = flag4 & flag3;
		if (obj == null)
		{
			return;
		}
		Vector3 _unity_self = default(Vector3);
		Vector3 point = default(Vector3);
		object obj2 = Bounds.Contains_Injected(ref *(Bounds*)(&_unity_self), ref point);
		if (obj2 != null)
		{
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				UnlockTorino();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
			object obj3 = default(object);
			Action action = ((OnlineStageManager)obj3).MazerellaUnlockTorinoSecret;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rax_v27 (System.Object)+78]");
			bool flag5 = ((CoherenceSync)0).SendCommand(action, MessageTarget.All);
		}
	}

	public void UnlockTorino()
	{
		//IL_0087: Expected F4, but got I4
		if (!_torinoUnlocked)
		{
			Debug.Log("unlock torino secret");
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			bool flag = core._playerOptions.UnlockSecret(SecretType.BreakMazerellaWall, config);
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.ThingFound, 0f, 10, 0f, volume, rate, detune, loop, 1f);
			_torinoUnlocked = true;
		}
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		CheckForTorinoUnlock();
		MazerellaDancerMazeNavigation mazeNavigation = _mazeNavigation;
		if ((object)_mazeNavigation != null && ((UnityEngine.Object)mazeNavigation).m_CachedPtr != (IntPtr)0)
		{
			Transform playerTransform = _player.transform;
			_mazeNavigation.UpdateNearestPositionToPlayer(playerTransform);
		}
	}
}
