using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using QFSW.MOP2;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Validation;

namespace VampireSurvivors.App.Framework;

public class PickupFactory : SerializedScriptableObject, IValidateReferences
{
	[Serializable]
	public class PickupsDictionary : UnitySerializedDictionary<ItemType, GameObject>
	{
		public PickupsDictionary()
		{
			((UnitySerializedDictionary<global::System.Int32Enum, object>)(object)this)._002Ector();
		}
	}

	[Serializable]
	public class PickupRefsDictionary : UnitySerializedDictionary<ItemType, PrefabRefData>
	{
		public PickupRefsDictionary()
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

	private PickupsDictionary _Pickups;

	private PickupRefsDictionary _PickupRefs;

	private List<PickupFactory> _LinkedFactories;

	private readonly Dictionary<ItemType, ObjectPool> _cachedPools;

	public void GeneratePools()
	{
		//IL_006f: Expected O, but got I4
		//IL_006f: Expected O, but got I
		//IL_008a: Expected O, but got I4
		Dictionary<ItemType, GameObject>.Enumerator enumerator = default(Dictionary<ItemType, GameObject>.Enumerator);
		while (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			GeneratePool(ItemType.VOID, null, 1);
		}
		Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
		Dictionary<DlcType, BundleManifestData>.Enumerator enumerator2 = default(Dictionary<DlcType, BundleManifestData>.Enumerator);
		object obj = default(object);
		while (enumerator2.MoveNext())
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ stack_-80+90]");
				MergeFactoryAndGenerate((PickupFactory)0, (DlcType?)(object)1);
				continue;
			}
			throw new NullReferenceException();
		}
		List<PickupFactory>.Enumerator enumerator3 = default(List<PickupFactory>.Enumerator);
		while (enumerator3.MoveNext())
		{
			MergeFactoryAndGenerate(null, (DlcType?)(object)0);
		}
	}

	public ObjectPool GetPool(ItemType itemType)
	{
		if (_cachedPools != null)
		{
			int num = ((Dictionary<global::System.Int32Enum, object>)(object)_cachedPools).FindEntry((global::System.Int32Enum)itemType);
			if (num < 0)
			{
				return null;
			}
			if (_cachedPools != null)
			{
				return (ObjectPool)((Dictionary<global::System.Int32Enum, object>)(object)_cachedPools).get_Item((global::System.Int32Enum)itemType);
			}
		}
		return (ObjectPool)(object)new NullReferenceException();
	}

	public void PurgePools()
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		Dictionary<ItemType, ObjectPool>.ValueCollection values = _cachedPools.Values;
		MasterObjectPooler masterObjectPooler = null;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		ObjectPool pool = default(ObjectPool);
		while (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ stack_-28_v10+2C]");
			if (obj2 == null)
			{
				object obj3 = obj4;
				bool flag;
				do
				{
					object obj5 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ stack_-28_v10+20]");
					if ((nint)obj5 < 0)
					{
						obj4 = obj3 + 1;
						object obj6 = obj3 * 2;
						object obj7 = obj3 + obj6;
						object obj8 = obj7 * 8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ stack_-28_v10+18]");
						object obj9 = 0 + obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ rax_v33+20]");
						flag = (nint)0 < (nint)0;
						obj3 = obj4;
						continue;
					}
					_cachedPools.Clear();
					return;
				}
				while (flag);
				MasterObjectPooler._003CInstance_003Ek__BackingField.RemoveAndDestroyPoolInstance(pool);
				continue;
			}
			global::System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			masterObjectPooler = null;
			break;
		}
		throw new NullReferenceException();
	}

	private unsafe void GeneratePool(ItemType itemType, GameObject prefab, int poolSize = 50)
	{
		//IL_0041: Expected O, but got Ref
		//IL_0069: Expected I4, but got I8
		int num = ((Dictionary<global::System.Int32Enum, object>)(object)_cachedPools).FindEntry((global::System.Int32Enum)itemType);
		if (num < 0)
		{
			object obj = default(object);
			string text = ((Enum)(&obj)).ToString();
			ObjectPool objectPool = ObjectPool.Create(prefab, text, poolSize, -1);
			if (!objectPool._003CInitialized_003Ek__BackingField)
			{
				objectPool._003CInitialized_003Ek__BackingField = true;
				objectPool.AutoFillName();
				objectPool.Populate(objectPool._defaultSize);
			}
			MasterObjectPooler._003CInstance_003Ek__BackingField.AddPool(objectPool._name, objectPool);
			bool flag = ((Dictionary<global::System.Int32Enum, object>)(object)_cachedPools).TryInsert((global::System.Int32Enum)itemType, (object)objectPool, global::System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
	}

	private void MergeFactoryAndGenerate(PickupFactory other, DlcType? dlcType)
	{
		if ((object)other == null || ((UnityEngine.Object)other).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Dictionary<ItemType, PrefabRefData>.Enumerator enumerator = default(Dictionary<ItemType, PrefabRefData>.Enumerator);
		GameObject prefab = default(GameObject);
		while (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			nint num = 0;
			ItemType itemType = ItemType.VOID;
			if (false)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F94830");
				GeneratePool(ItemType.VOID, prefab, 1);
				continue;
			}
			throw new NullReferenceException();
		}
		Dictionary<ItemType, GameObject>.Enumerator enumerator2 = default(Dictionary<ItemType, GameObject>.Enumerator);
		while (enumerator2.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			GeneratePool(ItemType.VOID, null, 1);
		}
	}

	public List<string> ValidateReferences()
	{
		return new List<string>();
	}

	public PickupFactory()
	{
		PickupsDictionary pickups = (PickupsDictionary)(object)new UnitySerializedDictionary<global::System.Int32Enum, object>();
		_Pickups = pickups;
		_PickupRefs = (PickupRefsDictionary)(object)new UnitySerializedDictionary<global::System.Int32Enum, object>();
		_cachedPools = new Dictionary<ItemType, ObjectPool>();
		((ScriptableObject)this)._002Ector();
	}
}
