using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;
using SuperTiled2Unity;
using UnityEngine;
using UnityEngine.Video;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Framework.Loading;

public class GameplayLoader
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<Action> _003C_003E9__11_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CLoad_003Eb__11_2(Action cb)
		{
			//IL_0029: Expected I4, but got O
			//IL_0046: Expected O, but got I4
			_003C_003Ec__DisplayClass11_1 obj = new _003C_003Ec__DisplayClass11_1();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass11_1)(object)action)._003CLoad_003Eb__3((byte)(int)obj != 0);
			bool flag = SpriteLoader.LoadTexture("character_pantalonerun", "Gameplay", (DlcType?)(object)0, action);
		}
	}

	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public DlcType? dlcTypeForStage;

		public GameplayLoader _003C_003E4__this;

		internal void _003CPreloadEnemies_003Eb__0(Action cb)
		{
			if ((object)dlcTypeForStage != null)
			{
				GameplayLoader gameplayLoader = _003C_003E4__this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.Loading.GameplayLoader+<>c__DisplayClass10_0)+14]");
				EnemyLoader.LoadDlcEnemyTexturesAsync(DlcType.Moonspell, gameplayLoader._dataManager, "Gameplay", cb);
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public GameplayLoader _003C_003E4__this;

		public Action onComplete;

		internal void _003CLoad_003Eb__0()
		{
			_003C_003E4__this.WaitAndRunCallback(onComplete);
		}

		internal void _003CLoad_003Eb__1(Action cb)
		{
			GameplayLoader gameplayLoader = _003C_003E4__this;
			GameManager gameManager = gameplayLoader._gameManager;
			Stage stage = gameManager._stage;
			stage._fancyBg.CustomPreload(cb);
		}
	}

	private sealed class _003C_003Ec__DisplayClass11_1
	{
		public Action cb;

		internal void _003CLoad_003Eb__3(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public DlcType? stageDlcType;
	}

	private sealed class _003C_003Ec__DisplayClass13_1
	{
		public string texture;

		public _003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals1;

		internal void _003CLoadTextures_003Eb__0(Action cb)
		{
			//IL_0035: Expected I4, but got O
			_003C_003Ec__DisplayClass13_2 obj = new _003C_003Ec__DisplayClass13_2();
			obj.CS_0024_003C_003E8__locals2 = this;
			obj.cb = cb;
			_003C_003Ec__DisplayClass13_0 obj2 = CS_0024_003C_003E8__locals1;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass13_2)(object)action)._003CLoadTextures_003Eb__1((byte)(int)obj != 0);
			bool flag = SpriteLoader.LoadTexture(texture, "Gameplay", obj2.stageDlcType, action);
		}
	}

	private sealed class _003C_003Ec__DisplayClass13_2
	{
		public Action cb;

		public _003C_003Ec__DisplayClass13_1 CS_0024_003C_003E8__locals2;

		public Action<bool> _003C_003E9__2;

		internal void _003CLoadTextures_003Eb__1(bool success)
		{
			//IL_0154: Expected O, but got I4
			//IL_011c: Expected I4, but got O
			if (!success)
			{
				_003C_003Ec__DisplayClass13_1 obj = CS_0024_003C_003E8__locals2;
				_003C_003Ec__DisplayClass13_0 obj2 = obj.CS_0024_003C_003E8__locals1;
				if ((nint)obj2.stageDlcType != (success ? 1 : 0))
				{
					string[] array = new string[5];
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					_003C_003Ec__DisplayClass13_1 obj3 = CS_0024_003C_003E8__locals2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					System.Int32Enum? int32Enum = default(System.Int32Enum?);
					string text = int32Enum.ToString();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					string message = string.Concat(array);
					Debug.LogWarning(message);
					_003C_003Ec__DisplayClass13_1 obj4 = CS_0024_003C_003E8__locals2;
					Action<bool> onComplete = _003C_003E9__2;
					if (_003C_003E9__2 == null)
					{
						Action<bool> action = null;
						((_003C_003Ec__DisplayClass13_2)(object)action)._003CLoadTextures_003Eb__2((byte)(int)this != 0);
						_003C_003E9__2 = action;
						onComplete = action;
					}
					bool flag = SpriteLoader.LoadTexture(obj4.texture, "Gameplay", (DlcType?)(object)0, onComplete);
					return;
				}
			}
			Action action2 = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v83.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}

		internal void _003CLoadTextures_003Eb__2(bool success2)
		{
			//IL_006e: Expected O, but got I
			IntPtr intPtr = default(IntPtr);
			string text = (string)(nint)intPtr;
			if (!success2)
			{
				_003C_003Ec__DisplayClass13_1 obj = CS_0024_003C_003E8__locals2;
				string message = "Cannot preload texture " + obj.texture + " from base game either :(";
				Debug.LogError(message);
				text = " from base game either :(";
			}
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v94.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public BgmType bgmToLoad;

		public GameplayLoader _003C_003E4__this;

		internal void _003CLoadBgm_003Eb__0(Action cb)
		{
			GameplayLoader gameplayLoader = _003C_003E4__this;
			DlcType? bgmDlcType = DlcSystem._utils.GetBgmDlcType(bgmToLoad, gameplayLoader._dataManager);
			AudioLoader.LoadBgmAsync(bgmToLoad, "Gameplay", bgmDlcType, cb);
		}
	}

	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public CharacterType characterType;

		public GameplayLoader _003C_003E4__this;
	}

	private sealed class _003C_003Ec__DisplayClass15_1
	{
		public string texture;

		public _003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals1;

		internal void _003CLoadCharacters_003Eb__0(Action cb)
		{
			//IL_0038: Expected I4, but got O
			_003C_003Ec__DisplayClass15_2 obj = new _003C_003Ec__DisplayClass15_2();
			obj.cb = cb;
			_003C_003Ec__DisplayClass15_0 obj2 = CS_0024_003C_003E8__locals1;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass15_2)(object)action)._003CLoadCharacters_003Eb__1((byte)(int)obj != 0);
			_003C_003Ec__DisplayClass15_0 obj3 = CS_0024_003C_003E8__locals1;
			GameplayLoader gameplayLoader = obj3._003C_003E4__this;
			string customCacheGroup = default(string);
			CharacterLoader.LoadCharacterTextureAsync(texture, obj2.characterType, action, gameplayLoader._dataManager, customCacheGroup);
		}
	}

	private sealed class _003C_003Ec__DisplayClass15_2
	{
		public Action cb;

		internal void _003CLoadCharacters_003Eb__1(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public DlcType? stageDlcType;
	}

	private sealed class _003C_003Ec__DisplayClass16_1
	{
		public string video;

		public _003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals1;

		internal void _003CLoadVideos_003Eb__0(Action cb)
		{
			_003C_003Ec__DisplayClass16_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass16_2();
			CS_0024_003C_003E8__locals2.cb = cb;
			_003C_003Ec__DisplayClass16_0 obj = CS_0024_003C_003E8__locals1;
			Action<VideoClip> onComplete = delegate
			{
				Action cb2 = CS_0024_003C_003E8__locals2.cb;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			};
			bool forceSync = default(bool);
			VideoLoader.LoadVideoInternal(video, "Gameplay", obj.stageDlcType, onComplete, forceSync);
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_2
	{
		public Action cb;

		internal void _003CLoadVideos_003Eb__1(VideoClip x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public GameplayLoader _003C_003E4__this;

		public Action onComplete;

		internal void _003CPreload_003Eb__0()
		{
			_003C_003E4__this.WaitAndRunCallback(onComplete);
		}
	}

	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public GameplayLoader _003C_003E4__this;

		public StageType stageType;

		internal void _003CPreloadTilesets_003Eb__0(Action cb)
		{
			_003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass8_1();
			CS_0024_003C_003E8__locals2.cb = cb;
			GameplayLoader gameplayLoader = _003C_003E4__this;
			Action<GameObject> onComplete = delegate
			{
				Action cb2 = CS_0024_003C_003E8__locals2.cb;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			};
			GameObject tilesetSupportPrefabInternal = gameplayLoader._tilesetFactory.GetTilesetSupportPrefabInternal(stageType, onComplete);
		}
	}

	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public Action cb;

		internal void _003CPreloadTilesets_003Eb__1(GameObject x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public KeyValuePair<CharacterType, List<string>> kvp;

		public GameplayLoader _003C_003E4__this;
	}

	private sealed class _003C_003Ec__DisplayClass9_1
	{
		public string texture;

		public _003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals1;

		internal void _003CPreloadCharacters_003Eb__0(Action cb)
		{
			//IL_0038: Expected I4, but got O
			//IL_0083: Expected I4, but got O
			_003C_003Ec__DisplayClass9_2 obj = new _003C_003Ec__DisplayClass9_2();
			obj.cb = cb;
			_003C_003Ec__DisplayClass9_0 obj2 = CS_0024_003C_003E8__locals1;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass9_2)(object)action)._003CPreloadCharacters_003Eb__1((byte)(int)obj != 0);
			_003C_003Ec__DisplayClass9_0 obj3 = CS_0024_003C_003E8__locals1;
			GameplayLoader gameplayLoader = obj3._003C_003E4__this;
			string customCacheGroup = default(string);
			CharacterLoader.LoadCharacterTextureAsync(texture, (CharacterType)obj2.kvp, action, gameplayLoader._dataManager, customCacheGroup);
		}
	}

	private sealed class _003C_003Ec__DisplayClass9_2
	{
		public Action cb;

		internal void _003CPreloadCharacters_003Eb__1(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CWaitAndRunCallback_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public Action callback;

		private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0087: Expected O, but got I4
			//IL_0092: Expected O, but got Ref
			//IL_00d6: Expected I4, but got I8
			//IL_00e1: Expected O, but got Ref
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (YieldAwaitable.YieldAwaiter)0;
				_003C_003E1__state = -1;
				Action action = callback;
				if (callback != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v76.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
				_003C_003E1__state = -2;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				if (asyncVoidMethodBuilder.m_synchronizationContext != null)
				{
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->NotifySynchronizationContextOfCompletion();
				}
			}
			else
			{
				_003C_003E1__state = 0;
				_003C_003Eu__1 = (YieldAwaitable.YieldAwaiter)0;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				YieldAwaitable.YieldAwaiter awaiter = default(YieldAwaitable.YieldAwaiter);
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public const string CACHE_GROUP_NAME = "Gameplay";

	private GameManager _gameManager;

	private DataManager _dataManager;

	private PlayerOptions _playerOptions;

	private TilesetFactory _tilesetFactory;

	private void Construct(GameManager gameManager, DataManager dataManager, PlayerOptions playerOptions, TilesetFactory tilesetFactory)
	{
		_gameManager = gameManager;
		_dataManager = dataManager;
		_playerOptions = playerOptions;
		TilesetFactory tilesetFactory2 = default(TilesetFactory);
		_tilesetFactory = tilesetFactory2;
	}

	private Dictionary<StageType, StageData> GetAllUsedStageData()
	{
		//IL_0132: Expected I4, but got O
		//IL_00cb: Expected O, but got I
		//IL_00e0: Expected O, but got I
		//IL_02e1: Expected O, but got I
		//IL_0115: Expected O, but got I
		Dictionary<StageType, StageData> dictionary = new Dictionary<StageType, StageData>();
		Dictionary<StageType, List<StageData>> convertedStages = _dataManager.GetConvertedStages();
		PlayerOptionsData config = _playerOptions.Config;
		int num = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).FindEntry((System.Int32Enum)config._003CSelectedStage_003Ek__BackingField);
		List<StageData> list;
		if (num >= 0)
		{
			object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)config._003CSelectedStage_003Ek__BackingField);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rax_v48 (System.Object)+18]");
				if ((nint)0 <= (nint)0)
				{
					goto IL_03b0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rax_v48 (System.Object)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v49+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v49+20]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rbx_v11+14]");
					list = (List<StageData>)0;
					goto IL_03ba;
				}
			}
		}
		list = null;
		goto IL_03ba;
		IL_03ba:
		if (list != null)
		{
			System.Int32Enum key = (System.Int32Enum)((object)list >> 32);
			int num2 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).FindEntry(key);
			if (num2 >= 0)
			{
				object obj4 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item(key);
				if (obj4 != null)
				{
					List<StageData> list2 = ((Dictionary<StageType, List<StageData>>)obj4).get_Item((StageType)key);
					if (list2 != null)
					{
						int num3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).FindEntry(key);
						if (num3 < 0)
						{
							object obj5 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item(key);
							object value;
							if (obj5 != null)
							{
								List<StageData> list3 = ((Dictionary<StageType, List<StageData>>)obj5).get_Item((StageType)key);
								value = list3;
							}
							else
							{
								value = null;
							}
							bool flag = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert(key, value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
						}
					}
				}
			}
		}
		int num4 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).FindEntry((System.Int32Enum)config._003CSelectedStage_003Ek__BackingField);
		if (num4 >= 0)
		{
			object obj6 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)config._003CSelectedStage_003Ek__BackingField);
			if (obj6 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rax_v22 (System.Object)+18]");
				if ((nint)0 <= (nint)0)
				{
					goto IL_03b0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rax_v22 (System.Object)+10]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v23+20]");
				if ((nint)0 != 0)
				{
					int num5 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).FindEntry((System.Int32Enum)config._003CSelectedStage_003Ek__BackingField);
					if (num5 < 0)
					{
						object obj8 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)config._003CSelectedStage_003Ek__BackingField);
						bool flag2 = obj8 == null;
						List<StageData> value2 = null;
						if (!flag2)
						{
							List<StageData> list4 = ((Dictionary<StageType, List<StageData>>)obj8).get_Item(config._003CSelectedStage_003Ek__BackingField);
							value2 = list4;
						}
						bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)config._003CSelectedStage_003Ek__BackingField, (object)value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					}
				}
			}
		}
		return dictionary;
		IL_03b0:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Dictionary<StageType, StageData> result = default(Dictionary<StageType, StageData>);
		return result;
	}

	public void Preload(Action onComplete)
	{
		//IL_024e: Expected I, but got O
		//IL_0282: Expected I, but got O
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass7_0();
		if (CS_0024_003C_003E8__locals13 != null)
		{
			CS_0024_003C_003E8__locals13._003C_003E4__this = this;
			CS_0024_003C_003E8__locals13.onComplete = onComplete;
			Dictionary<StageType, StageData> allUsedStageData = GetAllUsedStageData();
			Action onComplete2 = delegate
			{
				CS_0024_003C_003E8__locals13._003C_003E4__this.WaitAndRunCallback(CS_0024_003C_003E8__locals13.onComplete);
			};
			AsyncLoader asyncLoader = new AsyncLoader(onComplete2);
			if (allUsedStageData != null)
			{
				Dictionary<StageType, StageData>.Enumerator enumerator = default(Dictionary<StageType, StageData>.Enumerator);
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass8_0();
					bool flag = CS_0024_003C_003E8__locals17 == null;
					nint num = (nint)typeof(_003C_003Ec__DisplayClass8_0);
					if (!flag)
					{
						CS_0024_003C_003E8__locals17._003C_003E4__this = this;
						CS_0024_003C_003E8__locals17.stageType = StageType.FOREST;
						if ((object)_tilesetFactory != null)
						{
							SuperMap superMap = _tilesetFactory.CacheTilesetInstance(StageType.FOREST);
							Action<Action> loadCall = delegate(Action cb)
							{
								_003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass8_1();
								CS_0024_003C_003E8__locals20.cb = cb;
								GameplayLoader gameplayLoader = CS_0024_003C_003E8__locals17._003C_003E4__this;
								Action<GameObject> onComplete3 = delegate
								{
									Action cb2 = CS_0024_003C_003E8__locals20.cb;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
								};
								GameObject tilesetSupportPrefabInternal = gameplayLoader._tilesetFactory.GetTilesetSupportPrefabInternal(CS_0024_003C_003E8__locals17.stageType, onComplete3);
							};
							if (asyncLoader != null)
							{
								asyncLoader.Add(loadCall);
								_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals19 = new _003C_003Ec__DisplayClass10_0();
								bool flag2 = CS_0024_003C_003E8__locals19 == null;
								num = (nint)typeof(_003C_003Ec__DisplayClass10_0);
								if (!flag2)
								{
									CS_0024_003C_003E8__locals19._003C_003E4__this = this;
									if (DlcSystem._utils != null)
									{
										if ((object)(CS_0024_003C_003E8__locals19.dlcTypeForStage = DlcSystem._utils.GetStageDlcType(StageType.FOREST, _dataManager)) == null)
										{
											continue;
										}
										Action<Action> loadCall2 = delegate(Action cb)
										{
											if ((object)CS_0024_003C_003E8__locals19.dlcTypeForStage != null)
											{
												GameplayLoader gameplayLoader = CS_0024_003C_003E8__locals19._003C_003E4__this;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.Loading.GameplayLoader+<>c__DisplayClass10_0)+14]");
												EnemyLoader.LoadDlcEnemyTexturesAsync(DlcType.Moonspell, gameplayLoader._dataManager, "Gameplay", cb);
												return;
											}
											System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
											throw new NullReferenceException();
										};
										asyncLoader.Add(loadCall2);
										continue;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				PreloadCharacters(asyncLoader);
				if (asyncLoader != null)
				{
					asyncLoader.Load();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void PreloadTilesets(AsyncLoader loader, StageType stageType)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		CS_0024_003C_003E8__locals6.stageType = stageType;
		SuperMap superMap = _tilesetFactory.CacheTilesetInstance(stageType);
		Action<Action> loadCall = delegate(Action cb)
		{
			_003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass8_1();
			CS_0024_003C_003E8__locals7.cb = cb;
			GameplayLoader gameplayLoader = CS_0024_003C_003E8__locals6._003C_003E4__this;
			Action<GameObject> onComplete = delegate
			{
				Action cb2 = CS_0024_003C_003E8__locals7.cb;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			};
			GameObject tilesetSupportPrefabInternal = gameplayLoader._tilesetFactory.GetTilesetSupportPrefabInternal(CS_0024_003C_003E8__locals6.stageType, onComplete);
		};
		loader.Add(loadCall);
	}

	private unsafe void PreloadCharacters(AsyncLoader loader)
	{
		//IL_0036: Expected I, but got O
		//IL_0232: Expected O, but got I4
		//IL_011b: Expected O, but got Ref
		//IL_008e: Expected I, but got O
		//IL_016b: Expected O, but got I4
		//IL_0173: Expected O, but got Ref
		Dictionary<CharacterType, List<string>> texturesAndTypesForSelectedPlayers = CharacterLoader.GetTexturesAndTypesForSelectedPlayers(_playerOptions, _dataManager);
		List<CharacterType> list = null;
		Dictionary<CharacterType, List<string>>.Enumerator enumerator = default(Dictionary<CharacterType, List<string>>.Enumerator);
		List<string>.Enumerator enumerator2 = default(List<string>.Enumerator);
		while (enumerator.MoveNext())
		{
			_003C_003Ec__DisplayClass9_0 obj = new _003C_003Ec__DisplayClass9_0();
			bool flag = obj == null;
			nint num = (nint)typeof(_003C_003Ec__DisplayClass9_0);
			if (!flag)
			{
				obj._003C_003E4__this = this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				num = 0;
				obj.kvp = (KeyValuePair<CharacterType, List<string>>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rax_v50 (VampireSurvivors.Framework.Loading.GameplayLoader+<>c__DisplayClass9_0)+18]");
				if ((nint)0 == 0)
				{
					throw new NullReferenceException();
				}
				while (enumerator2.MoveNext())
				{
					_003C_003Ec__DisplayClass9_1 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass9_1();
					bool flag2 = CS_0024_003C_003E8__locals6 == null;
					num = (nint)typeof(_003C_003Ec__DisplayClass9_1);
					if (!flag2)
					{
						CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals1 = obj;
						CS_0024_003C_003E8__locals6.texture = null;
						Action<Action> loadCall = delegate(Action cb)
						{
							//IL_0038: Expected I4, but got O
							//IL_0083: Expected I4, but got O
							_003C_003Ec__DisplayClass9_2 obj4 = new _003C_003Ec__DisplayClass9_2();
							obj4.cb = cb;
							_003C_003Ec__DisplayClass9_0 obj5 = CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals1;
							Action<bool> action = null;
							((_003C_003Ec__DisplayClass9_2)(object)action)._003CPreloadCharacters_003Eb__1((byte)(int)obj4 != 0);
							_003C_003Ec__DisplayClass9_0 obj6 = CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals1;
							GameplayLoader gameplayLoader = obj6._003C_003E4__this;
							string customCacheGroup = default(string);
							CharacterLoader.LoadCharacterTextureAsync(CS_0024_003C_003E8__locals6.texture, (CharacterType)obj5.kvp, action, gameplayLoader._dataManager, customCacheGroup);
						};
						loader.Add(loadCall);
						list = null;
						continue;
					}
					throw new NullReferenceException();
				}
				continue;
			}
			throw new NullReferenceException();
		}
		Dictionary<StageType, StageData> allUsedStageData = GetAllUsedStageData();
		Dictionary<StageType, StageData> dictionary = allUsedStageData;
		Dictionary<StageType, StageData>.Enumerator enumerator3 = default(Dictionary<StageType, StageData>.Enumerator);
		object obj2 = default(object);
		List<VampireSurvivors.App.Data.FollowerData>.Enumerator enumerator5 = default(List<VampireSurvivors.App.Data.FollowerData>.Enumerator);
		while (true)
		{
			if (enumerator3.MoveNext())
			{
				bool flag3 = obj2 == null;
				List<VampireSurvivors.App.Data.FollowerData>.Enumerator enumerator4 = (List<VampireSurvivors.App.Data.FollowerData>.Enumerator)(&enumerator3);
				if (flag3)
				{
					break;
				}
				List<CharacterType> list2 = new List<CharacterType>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1116 @ stack_-90+1C0]");
				if ((nint)0 == 0)
				{
					throw new NullReferenceException();
				}
				if (enumerator5.MoveNext())
				{
					object obj3 = 0;
					enumerator4 = (List<VampireSurvivors.App.Data.FollowerData>.Enumerator)(&enumerator5);
					throw new NullReferenceException();
				}
				LoadCharacters(loader, list2);
				list = list2;
				dictionary = null;
				continue;
			}
			return;
		}
		throw new NullReferenceException();
	}

	private void PreloadEnemies(AsyncLoader loader, StageType stageType)
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals4._003C_003E4__this = this;
		if ((object)(CS_0024_003C_003E8__locals4.dlcTypeForStage = DlcSystem._utils.GetStageDlcType(stageType, _dataManager)) == null)
		{
			return;
		}
		Action<Action> loadCall = delegate(Action cb)
		{
			if ((object)CS_0024_003C_003E8__locals4.dlcTypeForStage != null)
			{
				GameplayLoader gameplayLoader = CS_0024_003C_003E8__locals4._003C_003E4__this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.Loading.GameplayLoader+<>c__DisplayClass10_0)+14]");
				EnemyLoader.LoadDlcEnemyTexturesAsync(DlcType.Moonspell, gameplayLoader._dataManager, "Gameplay", cb);
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			throw new NullReferenceException();
		};
		loader.Add(loadCall);
	}

	public unsafe void Load(Action onComplete)
	{
		//IL_03c5: Expected I, but got O
		//IL_007b: Expected I, but got O
		//IL_0278: Expected I, but got O
		//IL_02aa: Expected O, but got I
		//IL_00e8: Expected I, but got O
		//IL_01ed: Expected I, but got O
		//IL_0133: Expected I, but got O
		//IL_0155: Expected O, but got I4
		//IL_046c: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2AA3]");
		bool flag = (nint)0 != 0;
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass11_0();
		bool flag2 = CS_0024_003C_003E8__locals6 == null;
		nint num = (nint)typeof(_003C_003Ec__DisplayClass11_0);
		if (!flag2)
		{
			CS_0024_003C_003E8__locals6._003C_003E4__this = this;
			CS_0024_003C_003E8__locals6.onComplete = onComplete;
			Dictionary<StageType, StageData> allUsedStageData = GetAllUsedStageData();
			Action onComplete2 = delegate
			{
				CS_0024_003C_003E8__locals6._003C_003E4__this.WaitAndRunCallback(CS_0024_003C_003E8__locals6.onComplete);
			};
			AsyncLoader asyncLoader = new AsyncLoader(onComplete2);
			bool flag3 = allUsedStageData == null;
			num = (nint)asyncLoader;
			if (!flag3)
			{
				Dictionary<StageType, StageData>.Enumerator enumerator = default(Dictionary<StageType, StageData>.Enumerator);
				StageData stageData = default(StageData);
				while (enumerator.MoveNext())
				{
					if (stageData == null)
					{
						continue;
					}
					PreloadData preloadData = stageData._003Cpreload_003Ek__BackingField;
					if (stageData._003Cpreload_003Ek__BackingField != null)
					{
						nint num2 = (nint)typeof(DlcSystem);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rcx_v48 (Il2CppClass<VampireSurvivors.Framework.DLC.DlcSystem>)+E4]");
						flag = (nint)0 != 0;
						bool flag4 = ((Dictionary<StageType, StageData>.Enumerator*)typeof(DlcSystem))->MoveNext();
						bool flag5 = !flag4;
						nint num3 = (nint)typeof(DlcSystem);
						if (flag5)
						{
							throw new NullReferenceException();
						}
						DlcType? stageDlcType = ((DlcUtils)flag4).GetStageDlcType(StageType.FOREST, _dataManager);
						LoadTextures(asyncLoader, stageData._003Cpreload_003Ek__BackingField, stageDlcType);
						LoadBgm(asyncLoader, stageData._003Cpreload_003Ek__BackingField);
						LoadCharacters(asyncLoader, preloadData._003Ccharacters_003Ek__BackingField);
						LoadVideos(asyncLoader, stageData._003Cpreload_003Ek__BackingField, stageDlcType);
					}
					if (stageData._003CisRacingStage_003Ek__BackingField)
					{
						nint num4 = (nint)typeof(_003C_003Ec);
						Action<Action> loadCall = _003C_003Ec._003C_003E9__11_2;
						if (_003C_003Ec._003C_003E9__11_2 == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v803 @ rcx_v37 (Il2CppClass<VampireSurvivors.Framework.Loading.GameplayLoader+<>c>)+E4]");
							flag = 0 != (nint)_003C_003Ec._003C_003E9__11_2;
							Action<Action> action = (_003C_003Ec._003C_003E9__11_2 = delegate(Action cb)
							{
								//IL_0029: Expected I4, but got O
								//IL_0046: Expected O, but got I4
								_003C_003Ec__DisplayClass11_1 obj2 = new _003C_003Ec__DisplayClass11_1();
								obj2.cb = cb;
								Action<bool> action2 = null;
								((_003C_003Ec__DisplayClass11_1)(object)action2)._003CLoad_003Eb__3((byte)(int)obj2 != 0);
								bool flag7 = SpriteLoader.LoadTexture("character_pantalonerun", "Gameplay", (DlcType?)(object)0, action2);
							});
							nint num5 = (nint)typeof(_003C_003Ec);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v933 @ rax_v53 (Il2CppClass<VampireSurvivors.Framework.Loading.GameplayLoader+<>c>)+B8]");
							nint num3 = (nint)0 + (nint)8;
							loadCall = action;
						}
						if (asyncLoader == null)
						{
							throw new NullReferenceException();
						}
						asyncLoader.Add(loadCall);
					}
					List<CharacterType> tilesetCharacters = GetTilesetCharacters(stageData);
					LoadCharacters(asyncLoader, tilesetCharacters);
				}
				GameManager gameManager = _gameManager;
				bool flag6 = (object)_gameManager == null;
				num = (nint)(&enumerator);
				if (!flag6)
				{
					num = (nint)gameManager._stage;
					if ((object)gameManager._stage != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rcx_v5 (Il2CppClass<VampireSurvivors.Framework.Loading.GameplayLoader+<>c__DisplayClass11_0>)+228]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rcx_v5 (Il2CppClass<VampireSurvivors.Framework.Loading.GameplayLoader+<>c__DisplayClass11_0>)+228]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v788 @ rbx_v7+10]");
							if ((nint)0 != 0)
							{
								Action<Action> loadCall2 = delegate(Action cb)
								{
									GameplayLoader gameplayLoader = CS_0024_003C_003E8__locals6._003C_003E4__this;
									GameManager gameManager2 = gameplayLoader._gameManager;
									Stage stage = gameManager2._stage;
									stage._fancyBg.CustomPreload(cb);
								};
								if (asyncLoader == null)
								{
									goto IL_0393;
								}
								asyncLoader.Add(loadCall2);
							}
						}
						if (_playerOptions != null)
						{
							List<CharacterType> customMerchantCharacters = _playerOptions.GetCustomMerchantCharacters();
							LoadCharacters(asyncLoader, customMerchantCharacters);
							if (asyncLoader != null)
							{
								asyncLoader.Load();
								return;
							}
						}
					}
				}
			}
		}
		goto IL_0393;
		IL_0393:
		throw new NullReferenceException();
	}

	private void WaitAndRunCallback(Action callback)
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CWaitAndRunCallback_003Ed__12 stateMachine = default(_003CWaitAndRunCallback_003Ed__12);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private void LoadTextures(AsyncLoader loader, PreloadData preloadData, DlcType? stageDlcType)
	{
		//IL_0049: Expected I, but got O
		_003C_003Ec__DisplayClass13_0 obj = new _003C_003Ec__DisplayClass13_0();
		obj.stageDlcType = stageDlcType;
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass13_1 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass13_1();
				bool flag = CS_0024_003C_003E8__locals6 == null;
				nint num = (nint)typeof(_003C_003Ec__DisplayClass13_1);
				if (flag)
				{
					break;
				}
				CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals1 = obj;
				CS_0024_003C_003E8__locals6.texture = null;
				Action<Action> loadCall = delegate(Action cb)
				{
					//IL_0035: Expected I4, but got O
					_003C_003Ec__DisplayClass13_2 obj2 = new _003C_003Ec__DisplayClass13_2();
					obj2.CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals6;
					obj2.cb = cb;
					_003C_003Ec__DisplayClass13_0 obj3 = CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals1;
					Action<bool> action = null;
					((_003C_003Ec__DisplayClass13_2)(object)action)._003CLoadTextures_003Eb__1((byte)(int)obj2 != 0);
					bool flag2 = SpriteLoader.LoadTexture(CS_0024_003C_003E8__locals6.texture, "Gameplay", obj3.stageDlcType, action);
				};
				loader.Add(loadCall);
				continue;
			}
			return;
		}
		throw new NullReferenceException();
	}

	private void LoadBgm(AsyncLoader loader, PreloadData preloadData)
	{
		//IL_017d: Expected O, but got I
		//IL_0072: Expected O, but got I
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		AsyncLoader asyncLoader = null;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ stack_-38_v3+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ stack_-38_v3+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ stack_-38_v3+10]");
						object obj5 = 0;
						obj4++;
						_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass14_0();
						CS_0024_003C_003E8__locals5._003C_003E4__this = this;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v23+20+v497 @ rcx_v16*4]");
						CS_0024_003C_003E8__locals5.bgmToLoad = BgmType.BGM_Forest;
						Action<Action> loadCall = delegate(Action cb)
						{
							GameplayLoader gameplayLoader = CS_0024_003C_003E8__locals5._003C_003E4__this;
							DlcType? bgmDlcType = DlcSystem._utils.GetBgmDlcType(CS_0024_003C_003E8__locals5.bgmToLoad, gameplayLoader._dataManager);
							AudioLoader.LoadBgmAsync(CS_0024_003C_003E8__locals5.bgmToLoad, "Gameplay", bgmDlcType, cb);
						};
						loader.Add(loadCall);
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag = obj == null;
		asyncLoader = (AsyncLoader)0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ stack_-38_v3+1C]");
			if (obj2 == null)
			{
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			asyncLoader = null;
		}
		throw new NullReferenceException();
	}

	private unsafe void LoadCharacters(AsyncLoader loader, List<CharacterType> chars)
	{
		//IL_026f: Expected O, but got I
		//IL_0068: Expected O, but got I
		//IL_0174: Expected O, but got Ref
		//IL_00fe: Expected I, but got O
		object obj = default(object);
		object obj2 = default(object);
		nint num = default(nint);
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		GameplayLoader gameplayLoader;
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-B8_v3+1C]");
				if (obj2 != null)
				{
					break;
				}
				nint intPtr = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-B8_v3+18]");
				if (intPtr >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-B8_v3+10]");
				object obj3 = 0;
				num++;
				_003C_003Ec__DisplayClass15_0 obj4 = new _003C_003Ec__DisplayClass15_0();
				obj4._003C_003E4__this = this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v24+20+v602 @ rcx_v17 (Il2CppClass<VampireSurvivors.Framework.Loading.GameplayLoader+<>c__DisplayClass15_1>)*4]");
				obj4.characterType = CharacterType.VOID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v24+20+v602 @ rcx_v17 (Il2CppClass<VampireSurvivors.Framework.Loading.GameplayLoader+<>c__DisplayClass15_1>)*4]");
				List<string> texturesForCharacterType = CharacterLoader.GetTexturesForCharacterType(CharacterType.VOID, _playerOptions, _dataManager);
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass15_1 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass15_1();
					bool flag = CS_0024_003C_003E8__locals5 == null;
					nint num2 = (nint)typeof(_003C_003Ec__DisplayClass15_1);
					if (!flag)
					{
						CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1 = obj4;
						_ = 0;
						Action<Action> loadCall = delegate(Action cb)
						{
							//IL_0038: Expected I4, but got O
							_003C_003Ec__DisplayClass15_2 obj5 = new _003C_003Ec__DisplayClass15_2();
							obj5.cb = cb;
							_003C_003Ec__DisplayClass15_0 obj6 = CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1;
							Action<bool> action = null;
							((_003C_003Ec__DisplayClass15_2)(object)action)._003CLoadCharacters_003Eb__1((byte)(int)obj5 != 0);
							_003C_003Ec__DisplayClass15_0 obj7 = CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1;
							GameplayLoader gameplayLoader2 = obj7._003C_003E4__this;
							string customCacheGroup = default(string);
							CharacterLoader.LoadCharacterTextureAsync(CS_0024_003C_003E8__locals5.texture, obj6.characterType, action, gameplayLoader2._dataManager, customCacheGroup);
						};
						if (loader != null)
						{
							loader.Add(loadCall);
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				gameplayLoader = (GameplayLoader)(&enumerator);
				continue;
			}
			throw new NullReferenceException();
		}
		bool flag2 = obj == null;
		gameplayLoader = (GameplayLoader)0;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-B8_v3+1C]");
			if (obj2 == null)
			{
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			gameplayLoader = null;
		}
		throw new NullReferenceException();
	}

	private void LoadVideos(AsyncLoader loader, PreloadData preloadData, DlcType? stageDlcType)
	{
		//IL_0049: Expected I, but got O
		_003C_003Ec__DisplayClass16_0 obj = new _003C_003Ec__DisplayClass16_0();
		obj.stageDlcType = stageDlcType;
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			_003C_003Ec__DisplayClass16_1 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass16_1();
			bool flag = CS_0024_003C_003E8__locals7 == null;
			nint num = (nint)typeof(_003C_003Ec__DisplayClass16_1);
			if (flag)
			{
				break;
			}
			CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 = obj;
			CS_0024_003C_003E8__locals7.video = null;
			Action<Action> loadCall = delegate(Action cb)
			{
				_003C_003Ec__DisplayClass16_2 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass16_2();
				CS_0024_003C_003E8__locals8.cb = cb;
				_003C_003Ec__DisplayClass16_0 obj2 = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1;
				Action<VideoClip> onComplete = delegate
				{
					Action cb2 = CS_0024_003C_003E8__locals8.cb;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				};
				bool forceSync = default(bool);
				VideoLoader.LoadVideoInternal(CS_0024_003C_003E8__locals7.video, "Gameplay", obj2.stageDlcType, onComplete, forceSync);
			};
			loader.Add(loadCall);
		}
		throw new NullReferenceException();
	}

	private unsafe List<CharacterType> GetTilesetCharacters(StageData stageData)
	{
		//IL_02b7: Expected O, but got I4
		//IL_014f: Expected O, but got I4
		//IL_0157: Expected O, but got Ref
		List<CharacterType> list = new List<CharacterType>();
		if ((object)stageData._003Ccff_003Ek__BackingField != null)
		{
			if ((object)stageData._003Ccff_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				List<VampireSurvivors.App.Data.CustomMerchantData>.Enumerator enumerator = (List<VampireSurvivors.App.Data.CustomMerchantData>.Enumerator)0;
				throw new IndexOutOfRangeException();
			}
			object obj = (object?)stageData._003Ccff_003Ek__BackingField >> 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
		}
		GameManager gameManager = _gameManager;
		Stage stage = gameManager._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		if ((object)stage._tilingTileset != null && ((UnityEngine.Object)tilingTileset).m_CachedPtr != (IntPtr)0)
		{
			GameManager gameManager2 = _gameManager;
			Stage stage2 = gameManager2._stage;
			SuperMap defaultMap = stage2._tilingTileset.DefaultMap;
			List<CharacterType> charactersUsed = stage2._tilingTileset.GetCharactersUsed(defaultMap);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			((List<System.Int32Enum>)(object)list).InsertRange(0, (IEnumerable<System.Int32Enum>)charactersUsed);
		}
		List<VampireSurvivors.App.Data.CustomMerchantData>.Enumerator enumerator2 = default(List<VampireSurvivors.App.Data.CustomMerchantData>.Enumerator);
		if (enumerator2.MoveNext())
		{
			object obj2 = 0;
			List<VampireSurvivors.App.Data.CustomMerchantData>.Enumerator enumerator = (List<VampireSurvivors.App.Data.CustomMerchantData>.Enumerator)(&enumerator2);
			throw new NullReferenceException();
		}
		return list;
	}

	public unsafe static void LoadCoffinCharactersOnline()
	{
		//IL_0316: Expected O, but got I
		//IL_0125: Expected O, but got I
		//IL_01ea: Expected O, but got Ref
		//IL_0185: Expected I, but got O
		GameManager core = GM.Core;
		Stage stage = core._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		if ((object)stage._tilingTileset == null || ((UnityEngine.Object)tilingTileset).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		GameManager core3 = GM.Core;
		Stage stage3 = core3._stage;
		SuperMap defaultMap = stage3._tilingTileset.DefaultMap;
		List<CharacterType> charactersUsed = stage2._tilingTileset.GetCharactersUsed(defaultMap);
		object obj = default(object);
		object obj2 = default(object);
		nint num = default(nint);
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		TilingTileset tilingTileset2;
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-70_v4+1C]");
				if (obj2 != null)
				{
					break;
				}
				nint intPtr = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-70_v4+18]");
				if (intPtr >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-70_v4+10]");
				object obj3 = 0;
				num++;
				GameManager core4 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rdx_v15+20+v791 @ rcx_v26 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)*4]");
				List<string> texturesForCharacterType = CharacterLoader.GetTexturesForCharacterType(CharacterType.VOID, core4._playerOptions, core4._dataManager);
				while (enumerator.MoveNext())
				{
					nint num2 = (nint)typeof(GM);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v865 @ rax_v57 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
					nint num3 = 0;
					GameManager core5 = GM.Core;
					if ((object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rdx_v15+20+v791 @ rcx_v26 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)*4]");
						CharacterLoader.LoadCharacterTexture(null, CharacterType.VOID, core5._dataManager, "Gameplay");
						continue;
					}
					throw new NullReferenceException();
				}
				tilingTileset2 = (TilingTileset)(&enumerator);
				continue;
			}
			throw new NullReferenceException();
		}
		bool flag = obj == null;
		tilingTileset2 = (TilingTileset)0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-70_v4+1C]");
			if (obj2 == null)
			{
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			tilingTileset2 = null;
		}
		throw new NullReferenceException();
	}

	public void Release()
	{
		CharacterLoader.ClearCharacterTextures();
		AddressableCache.RemoveTexturesFromCacheAndSpriteManager("Gameplay");
		AddressableCache.ReleaseCustomOperationHandleGroup("Gameplay");
		TilesetFactory tilesetFactory = _tilesetFactory;
		tilesetFactory._mapInstances.Clear();
	}
}
