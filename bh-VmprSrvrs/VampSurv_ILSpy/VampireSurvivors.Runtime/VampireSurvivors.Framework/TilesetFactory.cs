using System;
using System.Collections.Generic;
using System.IO;
using Cpp2ILInjected;
using Sirenix.OdinInspector;
using SuperTiled2Unity;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Tilemaps;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Validation;

namespace VampireSurvivors.Framework;

public class TilesetFactory : SerializedScriptableObject, IValidateReferences
{
	[Serializable]
	public class TilesetRefsDictionary : UnitySerializedDictionary<StageType, PrefabRefData>
	{
		public TilesetRefsDictionary()
		{
			((UnitySerializedDictionary<System.Int32Enum, object>)(object)this)._002Ector();
		}
	}

	[Serializable]
	public class PrefabRefData
	{
		private AssetReference _PrefabRef;

		public AssetReference PrefabRef
		{
			get
			{
				return _PrefabRef;
			}
			set
			{
				_PrefabRef = value;
			}
		}
	}

	[Serializable]
	public class TilesetPathsDictionary : UnitySerializedDictionary<StageType, TilesetPathData>
	{
		public TilesetPathsDictionary()
		{
			((UnitySerializedDictionary<System.Int32Enum, object>)(object)this)._002Ector();
		}
	}

	[Serializable]
	public class TilesetPathData
	{
		private string _TilemapPath;

		public string TilemapPath => Path.ChangeExtension(_TilemapPath, null);

		public string TilemapPathWithExtension => _TilemapPath;
	}

	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public Action<SuperMap> onComplete;

		internal void _003CLoadFromAddressablesAsync_003Eb__0(GameObject go)
		{
			Action<SuperMap> action = onComplete;
			if (onComplete != null)
			{
				if ((object)go != null && ((UnityEngine.Object)go).m_CachedPtr != (IntPtr)0)
				{
					SuperMap component = go.GetComponent<SuperMap>();
				}
				else
				{
					SuperMap component = null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v35 @ rbx_v2 (System.Action`1<SuperTiled2Unity.SuperMap>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private TilesetPathsDictionary _TilesetPaths;

	private TilesetRefsDictionary _TilesetRefs;

	private TilesetRefsDictionary _TilesetSupportRefs;

	private List<TilesetFactory> _LinkedFactories;

	private Dictionary<StageType, SuperMap> _mapInstances;

	private SuperMap LoadFromAddressables(DlcType? dlcType, StageType stageType, TilesetFactory factory)
	{
		if ((object)factory != null && factory._TilesetRefs != null)
		{
			object obj = ((Dictionary<System.Int32Enum, object>)(object)factory._TilesetRefs).get_Item((System.Int32Enum)stageType);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F948D0");
				GameObject gameObject = default(GameObject);
				if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
				{
					return gameObject.GetComponent<SuperMap>();
				}
				return null;
			}
		}
		return (SuperMap)(object)new NullReferenceException();
	}

	private void LoadFromAddressablesAsync(DlcType? dlcType, StageType stageType, TilesetFactory factory, Action<SuperMap> onComplete)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass6_0();
		Action<SuperMap> onComplete2 = default(Action<SuperMap>);
		CS_0024_003C_003E8__locals3.onComplete = onComplete2;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)factory._TilesetRefs).get_Item((System.Int32Enum)stageType);
		Action<GameObject> action = delegate(GameObject go)
		{
			Action<SuperMap> onComplete3 = CS_0024_003C_003E8__locals3.onComplete;
			if (CS_0024_003C_003E8__locals3.onComplete != null)
			{
				if ((object)go != null && ((UnityEngine.Object)go).m_CachedPtr != (IntPtr)0)
				{
					SuperMap component = go.GetComponent<SuperMap>();
				}
				else
				{
					SuperMap component = null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v35 @ rbx_v2 (System.Action`1<SuperTiled2Unity.SuperMap>)+18] (should have been resolved before IL gen)");
			}
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F95F40");
	}

	public SuperMap CacheTilesetInstance(StageType stageType)
	{
		//IL_009f: Expected O, but got I4
		//IL_00a8: Expected O, but got I4
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_01b8->IL01b8: Incompatible stack heights: 4 vs 3
		//IL_0241->IL00b2: Incompatible stack heights: 5 vs 2
		SuperMap tilesetPrefabInternal = GetTilesetPrefabInternal(stageType);
		if ((object)tilesetPrefabInternal != null && ((UnityEngine.Object)tilesetPrefabInternal).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830B46D0");
			GameObject gameObject = tilesetPrefabInternal.gameObject;
			bool flag = (object)gameObject == null;
			SuperTileLayer[] componentsInChildren = gameObject.GetComponentsInChildren<SuperTileLayer>(includeInactive: false);
			bool flag2 = componentsInChildren == null;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < componentsInChildren.Length)
			{
				bool flag3 = (object)componentsInChildren[obj] == null;
				Tilemap component = componentsInChildren[obj].GetComponent<Tilemap>();
				bool flag4 = (object)component == null;
				bool flag5 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
				Tilemap.ClearAllTiles_Injected(((UnityEngine.Object)component).m_CachedPtr);
				obj++;
				obj2 = obj;
			}
			bool flag6 = _mapInstances == null;
			int num = ((Dictionary<System.Int32Enum, object>)(object)_mapInstances).FindEntry((System.Int32Enum)stageType);
			SuperMap superMap = default(SuperMap);
			if (num < 0)
			{
				bool flag7 = _mapInstances == null;
				bool flag8 = ((Dictionary<System.Int32Enum, object>)(object)_mapInstances).TryInsert((System.Int32Enum)stageType, (object)superMap, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			}
			return superMap;
		}
		return null;
	}

	public SuperMap GetCachedTilesetInstance(StageType stageType)
	{
		if (_mapInstances != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)_mapInstances).FindEntry((System.Int32Enum)stageType);
			if (num < 0)
			{
				return null;
			}
			if (_mapInstances != null)
			{
				return (SuperMap)((Dictionary<System.Int32Enum, object>)(object)_mapInstances).get_Item((System.Int32Enum)stageType);
			}
		}
		return (SuperMap)(object)new NullReferenceException();
	}

	public void ClearCachedTilesets()
	{
		_mapInstances.Clear();
	}

	private unsafe SuperMap GetTilesetPrefabInternal(StageType stageType, Action<SuperMap> onComplete = null)
	{
		//IL_0246: Expected O, but got I4
		//IL_025e: Expected O, but got I4
		//IL_0266: Expected O, but got Ref
		//IL_0546: Expected O, but got I4
		//IL_052c: Expected O, but got I4
		//IL_0461: Expected O, but got I4
		DlcType? result;
		if (_LinkedFactories != null)
		{
			List<TilesetFactory>.Enumerator enumerator = default(List<TilesetFactory>.Enumerator);
			while (enumerator.MoveNext())
			{
				TilesetFactory tilesetFactory = null;
			}
			Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
			if (loadedDlc != null)
			{
				object obj = 2;
				Dictionary<DlcType, BundleManifestData>.Enumerator enumerator2 = default(Dictionary<DlcType, BundleManifestData>.Enumerator);
				if (enumerator2.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					object obj2 = 0;
					Dictionary<System.Int32Enum, object> dictionary = (Dictionary<System.Int32Enum, object>)(&enumerator2);
					throw new NullReferenceException();
				}
				if (_TilesetRefs != null)
				{
					int num = ((Dictionary<System.Int32Enum, object>)(object)_TilesetRefs).FindEntry((System.Int32Enum)stageType);
					if (num >= 0)
					{
						if (onComplete != null)
						{
							Action<SuperMap> onComplete2 = default(Action<SuperMap>);
							LoadFromAddressablesAsync((DlcType?)(object)0, stageType, this, onComplete2);
							return null;
						}
						return LoadFromAddressables((DlcType?)(object)0, stageType, this);
					}
					if (_TilesetPaths != null)
					{
						int num2 = ((Dictionary<System.Int32Enum, object>)(object)_TilesetPaths).FindEntry((System.Int32Enum)stageType);
						bool flag = num2 < 0;
						result = (DlcType?)(object)0;
						if (flag)
						{
							goto IL_06a9;
						}
						if (_TilesetPaths != null)
						{
							object obj3 = ((Dictionary<System.Int32Enum, object>)(object)_TilesetPaths).get_Item((System.Int32Enum)stageType);
							if (obj3 != null)
							{
								string tilemapPath = ((TilesetPathData)obj3).TilemapPath;
								SuperMap superMap = Resources.Load<SuperMap>(tilemapPath);
								result = (DlcType?)superMap;
								goto IL_06a9;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_06a9:
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ r8 (System.Action`1<SuperTiled2Unity.SuperMap>)+18] (should have been resolved before IL gen)");
		}
		return (SuperMap)result;
	}

	public GameObject GetTilesetSupportPrefab(StageType stageType)
	{
		return GetTilesetSupportPrefabInternal(stageType);
	}

	public void GetTilesetSupportPrefabAsync(StageType stageType, Action<GameObject> onComplete)
	{
		GameObject tilesetSupportPrefabInternal = GetTilesetSupportPrefabInternal(stageType, onComplete);
	}

	private unsafe GameObject GetTilesetSupportPrefabInternal(StageType stageType, Action<GameObject> onComplete = null)
	{
		//IL_0029: Expected O, but got I4
		//IL_01b0: Expected O, but got I4
		//IL_01c8: Expected O, but got I4
		//IL_01d0: Expected O, but got Ref
		GameObject result;
		if (_LinkedFactories != null)
		{
			List<TilesetFactory>.Enumerator enumerator = default(List<TilesetFactory>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = 0;
			}
			Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
			if (loadedDlc != null)
			{
				object obj2 = 2;
				Dictionary<DlcType, BundleManifestData>.Enumerator enumerator2 = default(Dictionary<DlcType, BundleManifestData>.Enumerator);
				if (enumerator2.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					object obj3 = 0;
					Dictionary<DlcType, BundleManifestData>.Enumerator enumerator3 = (Dictionary<DlcType, BundleManifestData>.Enumerator)(&enumerator2);
					throw new NullReferenceException();
				}
				if (_TilesetSupportRefs != null)
				{
					int num = ((Dictionary<System.Int32Enum, object>)(object)_TilesetSupportRefs).FindEntry((System.Int32Enum)stageType);
					if (num < 0)
					{
						if (_TilesetPaths != null)
						{
							int num2 = ((Dictionary<System.Int32Enum, object>)(object)_TilesetPaths).FindEntry((System.Int32Enum)stageType);
							bool flag = num2 < 0;
							result = null;
							if (flag)
							{
								goto IL_080c;
							}
							if (_TilesetPaths != null)
							{
								object obj4 = ((Dictionary<System.Int32Enum, object>)(object)_TilesetPaths).get_Item((System.Int32Enum)stageType);
								if (obj4 != null)
								{
									string tilemapPath = ((TilesetPathData)obj4).TilemapPath;
									string path = tilemapPath + "_Support";
									GameObject gameObject = Resources.Load<GameObject>(path);
									result = gameObject;
									goto IL_080c;
								}
							}
						}
					}
					else if (onComplete != null)
					{
						if (_TilesetSupportRefs != null)
						{
							object obj5 = ((Dictionary<System.Int32Enum, object>)(object)_TilesetSupportRefs).get_Item((System.Int32Enum)stageType);
							if (obj5 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F95F40");
								return null;
							}
						}
					}
					else if (_TilesetSupportRefs != null)
					{
						object obj6 = ((Dictionary<System.Int32Enum, object>)(object)_TilesetSupportRefs).get_Item((System.Int32Enum)stageType);
						if (obj6 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F948D0");
							GameObject result2 = default(GameObject);
							return result2;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_080c:
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ r8 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
		}
		return result;
	}

	public bool ContainsStage(StageType stageType)
	{
		if (_TilesetPaths == null)
		{
			return false;
		}
		int num = ((Dictionary<System.Int32Enum, object>)(object)_TilesetPaths).FindEntry((System.Int32Enum)stageType);
		int num2 = num >> 31;
		return (byte)(num2 ^ 1) != 0;
	}

	public unsafe List<string> ValidateReferences()
	{
		//IL_002c: Expected O, but got Ref
		//IL_0047: Expected O, but got Ref
		//IL_0094: Expected O, but got I4
		//IL_009a: Expected O, but got I
		//IL_00af: Expected O, but got I
		//IL_018a: Expected O, but got I4
		//IL_0190: Expected O, but got I
		//IL_01a5: Expected O, but got I
		//IL_0122: Expected O, but got Ref
		//IL_013d: Expected O, but got Ref
		//IL_0218: Expected O, but got Ref
		//IL_0233: Expected O, but got Ref
		List<string> list = new List<string>();
		if (_TilesetPaths != null)
		{
			Dictionary<StageType, TilesetPathData>.Enumerator enumerator = default(Dictionary<StageType, TilesetPathData>.Enumerator);
			IntPtr intPtr = default(IntPtr);
			while (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				if (0 == 0)
				{
					string item = ((Enum)(&intPtr)).ToString();
					bool flag = list == null;
					Enum obj = (Enum)(&intPtr);
					if (flag)
					{
						throw new NullReferenceException();
					}
					list.Add(item);
					nint num = 0;
				}
			}
			if (_TilesetRefs != null)
			{
				Dictionary<StageType, PrefabRefData>.Enumerator enumerator2 = default(Dictionary<StageType, PrefabRefData>.Enumerator);
				object obj5 = default(object);
				IntPtr intPtr2 = default(IntPtr);
				while (enumerator2.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					object obj2 = 0;
					Enum obj = (Enum)0;
					if (false)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v89+10]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v89+10]");
						bool flag2 = (nint)0 == 0;
						obj = (Enum)(object)typeof(AddressableLoader);
						if (!flag2)
						{
							object obj4 = obj3;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1394 @ rdx_v35+248] (should have been resolved before IL gen)");
							if (obj5 == null)
							{
								string item2 = ((Enum)(&intPtr2)).ToString();
								bool flag3 = list == null;
								obj = (Enum)(&intPtr2);
								if (flag3)
								{
									throw new NullReferenceException();
								}
								list.Add(item2);
								nint num = 0;
							}
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				if (_TilesetSupportRefs != null)
				{
					Dictionary<StageType, PrefabRefData>.Enumerator enumerator3 = default(Dictionary<StageType, PrefabRefData>.Enumerator);
					object obj9 = default(object);
					IntPtr intPtr3 = default(IntPtr);
					while (enumerator3.MoveNext())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
						object obj6 = 0;
						Enum obj = (Enum)0;
						if (false)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v63+10]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v63+10]");
							bool flag4 = (nint)0 == 0;
							obj = (Enum)(object)typeof(AddressableLoader);
							if (!flag4)
							{
								object obj8 = obj7;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1588 @ rdx_v28+248] (should have been resolved before IL gen)");
								if (obj9 == null)
								{
									string item3 = ((Enum)(&intPtr3)).ToString();
									bool flag5 = list == null;
									obj = (Enum)(&intPtr3);
									if (flag5)
									{
										throw new NullReferenceException();
									}
									list.Add(item3);
									nint num = 0;
								}
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					if (_LinkedFactories != null)
					{
						List<TilesetFactory>.Enumerator enumerator4 = default(List<TilesetFactory>.Enumerator);
						if (enumerator4.MoveNext())
						{
							TilesetFactory tilesetFactory = null;
							throw new NullReferenceException();
						}
						return list;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public TilesetFactory()
	{
		TilesetPathsDictionary tilesetPaths = (TilesetPathsDictionary)(object)new UnitySerializedDictionary<System.Int32Enum, object>();
		_TilesetPaths = tilesetPaths;
		_TilesetRefs = (TilesetRefsDictionary)(object)new UnitySerializedDictionary<System.Int32Enum, object>();
		_TilesetSupportRefs = (TilesetRefsDictionary)(object)new UnitySerializedDictionary<System.Int32Enum, object>();
		_mapInstances = new Dictionary<StageType, SuperMap>();
		((ScriptableObject)this)._002Ector();
	}
}
