using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;

namespace VampireSurvivors.Framework;

public class AssetReferenceLibrary : SerializedScriptableObject
{
	[Serializable]
	public class AssetRefsDictionary : UnitySerializedDictionary<string, PrefabRefData>
	{
		public AssetRefsDictionary()
		{
			((UnitySerializedDictionary<object, object>)(object)this)._002Ector();
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

	private AssetRefsDictionary _AssetRefs;

	public unsafe AssetReference GetAssetReference(string key)
	{
		//IL_0048: Expected O, but got Ref
		//IL_0066: Expected O, but got I
		//IL_00da: Expected O, but got I
		//IL_013b: Expected O, but got I
		//IL_015d: Expected O, but got I
		//IL_01bc: Expected O, but got I
		Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
		if (loadedDlc != null)
		{
			Dictionary<DlcType, BundleManifestData>.Enumerator enumerator = default(Dictionary<DlcType, BundleManifestData>.Enumerator);
			object obj = default(object);
			while (enumerator.MoveNext())
			{
				bool flag = obj == null;
				Dictionary<DlcType, BundleManifestData>.Enumerator enumerator2 = (Dictionary<DlcType, BundleManifestData>.Enumerator)(&enumerator);
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ stack_-30+A0]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ stack_-30+A0]");
					if ((nint)0 == 0)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rdi_v12+10]");
					if ((nint)0 == 0)
					{
						continue;
					}
					bool flag2 = obj == null;
					enumerator2 = (Dictionary<DlcType, BundleManifestData>.Enumerator)typeof(UnityEngine.Object);
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ stack_-30+A0]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ stack_-30+A0]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v39+58]");
							bool flag3 = (nint)0 == 0;
							if (!flag3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v39+58]");
								int num = ((Dictionary<string, PrefabRefData>)0).FindEntry(key);
								if (!flag3)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ stack_-30+A0]");
									object obj4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ stack_-30+A0]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rax_v44+58]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rax_v44+58]");
											PrefabRefData prefabRefData = ((Dictionary<string, PrefabRefData>)0).get_Item(key);
											if (prefabRefData != null)
											{
												return prefabRefData._PrefabRef;
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
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
			if (_AssetRefs != null)
			{
				int num2 = ((Dictionary<string, PrefabRefData>)_AssetRefs).FindEntry(key);
				if (num2 < 0)
				{
					return null;
				}
				if (_AssetRefs != null)
				{
					PrefabRefData prefabRefData2 = ((Dictionary<string, PrefabRefData>)_AssetRefs).get_Item(key);
					if (prefabRefData2 != null)
					{
						return prefabRefData2._PrefabRef;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public AssetReferenceLibrary()
	{
		AssetRefsDictionary assetRefs = (AssetRefsDictionary)(object)new UnitySerializedDictionary<object, object>();
		_AssetRefs = assetRefs;
		((ScriptableObject)this)._002Ector();
	}
}
