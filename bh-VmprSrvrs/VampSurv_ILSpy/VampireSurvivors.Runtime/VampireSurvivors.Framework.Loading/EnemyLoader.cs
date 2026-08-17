using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;

namespace VampireSurvivors.Framework.Loading;

public static class EnemyLoader
{
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public string customCacheGroup;

		public DlcType dlcType;
	}

	private sealed class _003C_003Ec__DisplayClass1_1
	{
		public string texName;

		public _003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals1;

		internal void _003CLoadDlcEnemyTexturesAsync_003Eb__0(Action cb)
		{
			//IL_0038: Expected I4, but got O
			//IL_005a: Expected O, but got I4
			_003C_003Ec__DisplayClass1_2 obj = new _003C_003Ec__DisplayClass1_2();
			obj.cb = cb;
			_003C_003Ec__DisplayClass1_0 obj2 = CS_0024_003C_003E8__locals1;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass1_2)(object)action)._003CLoadDlcEnemyTexturesAsync_003Eb__1((byte)(int)obj != 0);
			SpriteLoader.LoadTextureAsync(texName, obj2.customCacheGroup, (DlcType?)(object)1, action);
		}
	}

	private sealed class _003C_003Ec__DisplayClass1_2
	{
		public Action cb;

		internal void _003CLoadDlcEnemyTexturesAsync_003Eb__1(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public static void LoadDlcEnemyTextures(DlcType dlcType, DataManager dataManager, string customCacheGroup)
	{
		//IL_0061: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2A85]");
		bool flag = (nint)0 != 0;
		if (dataManager != null)
		{
			DlcType dlcType2 = default(DlcType);
			Dictionary<EnemyType, List<EnemyData>> convertedDlcEnemyData = dataManager.GetConvertedDlcEnemyData(dlcType2);
			List<string> list = new List<string>();
			if (convertedDlcEnemyData != null)
			{
				nint num = unchecked((nint)null);
				Dictionary<EnemyType, List<EnemyData>>.Enumerator enumerator = default(Dictionary<EnemyType, List<EnemyData>>.Enumerator);
				while (enumerator.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				}
				string text = string.Join(", ", list);
				string message = "Enemy Textures: " + text;
				Debug.Log(message);
				if (list != null)
				{
					int version = list._version + 1;
					list._version = version;
					list._size = 0;
					if (list._size > 0)
					{
						Array.Clear(list._items, 0, list._size);
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public static void LoadDlcEnemyTexturesAsync(DlcType dlcType, DataManager dataManager, string customCacheGroup, Action onComplete)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2A86]");
		bool flag = (nint)0 != 0;
		_003C_003Ec__DisplayClass1_0 obj = new _003C_003Ec__DisplayClass1_0();
		if (obj != null)
		{
			obj.customCacheGroup = customCacheGroup;
			obj.dlcType = dlcType;
			if (dataManager != null)
			{
				Dictionary<EnemyType, List<EnemyData>> convertedDlcEnemyData = dataManager.GetConvertedDlcEnemyData(dlcType);
				List<string> list = new List<string>();
				AsyncLoader asyncLoader = new AsyncLoader(onComplete);
				if (convertedDlcEnemyData != null)
				{
					Dictionary<EnemyType, List<EnemyData>>.Enumerator enumerator = default(Dictionary<EnemyType, List<EnemyData>>.Enumerator);
					while (enumerator.MoveNext())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					}
					string text = string.Join(", ", list);
					string message = "Enemy Textures: " + text;
					Debug.Log(message);
					if (list != null)
					{
						int version = list._version + 1;
						list._version = version;
						list._size = 0;
						if (list._size > 0)
						{
							Array.Clear(list._items, 0, list._size);
						}
						if (asyncLoader != null)
						{
							asyncLoader.Load();
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}
}
