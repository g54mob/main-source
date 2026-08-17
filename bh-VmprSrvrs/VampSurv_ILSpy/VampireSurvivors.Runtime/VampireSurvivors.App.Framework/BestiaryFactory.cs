using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Validation;

namespace VampireSurvivors.App.Framework;

public class BestiaryFactory : SerializedScriptableObject, IValidateReferences
{
	[Serializable]
	public class BestiaryEnemyPoolsDictionary : UnitySerializedDictionary<EnemyType, GameObject>
	{
		public BestiaryEnemyPoolsDictionary()
		{
			((UnitySerializedDictionary<global::System.Int32Enum, object>)(object)this)._002Ector();
		}
	}

	[Serializable]
	public class BestiaryEnemyRefDictionary : UnitySerializedDictionary<EnemyType, PrefabRefData>
	{
		public BestiaryEnemyRefDictionary()
		{
			((UnitySerializedDictionary<global::System.Int32Enum, object>)(object)this)._002Ector();
		}
	}

	[Serializable]
	public class PrefabRefData
	{
		private AssetReferenceT<GameObject> _PrefabRef;

		public AssetReferenceT<GameObject> PrefabRef
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

	private BestiaryEnemyPoolsDictionary _BestiaryEnemyPools;

	private BestiaryEnemyRefDictionary _BestiaryEnemyRefs;

	private List<BestiaryFactory> _LinkedFactories;

	public string CACHE_GROUP;

	public string CACHE_GROUP_UI;

	public unsafe GameObject GetBestiaryEnemyPrefab(EnemyType type)
	{
		//IL_0055: Expected O, but got I4
		//IL_005d: Expected O, but got Ref
		//IL_0303: Expected O, but got I4
		//IL_05f5: Expected O, but got Ref
		Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
		if (loadedDlc != null)
		{
			Dictionary<DlcType, BundleManifestData>.Enumerator enumerator = default(Dictionary<DlcType, BundleManifestData>.Enumerator);
			if (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				object obj = 0;
				Dictionary<DlcType, BundleManifestData>.Enumerator enumerator2 = (Dictionary<DlcType, BundleManifestData>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			if (_LinkedFactories != null)
			{
				List<BestiaryFactory>.Enumerator enumerator3 = default(List<BestiaryFactory>.Enumerator);
				while (enumerator3.MoveNext())
				{
					object obj2 = 0;
				}
				if (_BestiaryEnemyRefs != null)
				{
					int num = ((Dictionary<global::System.Int32Enum, object>)(object)_BestiaryEnemyRefs).FindEntry((global::System.Int32Enum)type);
					if (num < 0)
					{
						if (_BestiaryEnemyPools != null)
						{
							int num2 = ((Dictionary<global::System.Int32Enum, object>)(object)_BestiaryEnemyPools).FindEntry((global::System.Int32Enum)type);
							if (num2 < 0)
							{
								return null;
							}
							if (_BestiaryEnemyPools != null)
							{
								return (GameObject)((Dictionary<global::System.Int32Enum, object>)(object)_BestiaryEnemyPools).get_Item((global::System.Int32Enum)type);
							}
						}
					}
					else if (_BestiaryEnemyRefs != null)
					{
						object obj3 = ((Dictionary<global::System.Int32Enum, object>)(object)_BestiaryEnemyRefs).get_Item((global::System.Int32Enum)type);
						if (obj3 != null)
						{
							IntPtr intPtr = default(IntPtr);
							string text = ((Enum)(&intPtr)).ToString();
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F94830");
							GameObject result = default(GameObject);
							return result;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe List<string> ValidateReferences()
	{
		//IL_0027: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		//IL_00da: Expected O, but got I
		//IL_006c: Expected O, but got Ref
		//IL_0087: Expected O, but got Ref
		//IL_00ef: Expected O, but got I
		//IL_0162: Expected O, but got Ref
		//IL_017d: Expected O, but got Ref
		List<string> list = new List<string>();
		if (_BestiaryEnemyPools != null)
		{
			Dictionary<EnemyType, GameObject>.Enumerator enumerator = default(Dictionary<EnemyType, GameObject>.Enumerator);
			IntPtr intPtr = default(IntPtr);
			while (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				object obj = 0;
				if (false)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rbx_v16+10]");
					if ((nint)0 != 0)
					{
						continue;
					}
				}
				string item = ((Enum)(&intPtr)).ToString();
				bool flag = list == null;
				Enum obj2 = (Enum)(&intPtr);
				if (!flag)
				{
					list.Add(item);
					nint num = 0;
					continue;
				}
				throw new NullReferenceException();
			}
			if (_BestiaryEnemyRefs != null)
			{
				Dictionary<EnemyType, PrefabRefData>.Enumerator enumerator2 = default(Dictionary<EnemyType, PrefabRefData>.Enumerator);
				object obj6 = default(object);
				IntPtr intPtr2 = default(IntPtr);
				while (enumerator2.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					object obj3 = 0;
					Enum obj2 = (Enum)0;
					if (false)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v59+10]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v59+10]");
						bool flag2 = (nint)0 == 0;
						obj2 = (Enum)(object)typeof(AddressableLoader);
						if (!flag2)
						{
							object obj5 = obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1259 @ rdx_v21+248] (should have been resolved before IL gen)");
							if (obj6 == null)
							{
								string item2 = ((Enum)(&intPtr2)).ToString();
								bool flag3 = list == null;
								obj2 = (Enum)(&intPtr2);
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
				if (_LinkedFactories != null)
				{
					List<BestiaryFactory>.Enumerator enumerator3 = default(List<BestiaryFactory>.Enumerator);
					while (enumerator3.MoveNext())
					{
						BestiaryFactory bestiaryFactory = null;
					}
					return list;
				}
			}
		}
		throw new NullReferenceException();
	}

	public BestiaryFactory()
	{
		BestiaryEnemyPoolsDictionary bestiaryEnemyPools = (BestiaryEnemyPoolsDictionary)(object)new UnitySerializedDictionary<global::System.Int32Enum, object>();
		_BestiaryEnemyPools = bestiaryEnemyPools;
		_BestiaryEnemyRefs = (BestiaryEnemyRefDictionary)(object)new UnitySerializedDictionary<global::System.Int32Enum, object>();
		CACHE_GROUP = "Bestiary";
		CACHE_GROUP_UI = "BestiaryUI";
		((ScriptableObject)this)._002Ector();
	}
}
