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
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Validation;

namespace VampireSurvivors.App.Framework;

public class GenericPoolFactory<T> : SerializedScriptableObject, IValidateReferences
{
	[Serializable]
	public class PoolsDictionary : UnitySerializedDictionary<T, ObjectPool>
	{
		public PoolsDictionary()
		{
			((UnitySerializedDictionary<global::System.Int32Enum, object>)(object)this)._002Ector();
		}
	}

	[Serializable]
	public class PoolRefsDictionary : UnitySerializedDictionary<T, PrefabRefData>
	{
		public PoolRefsDictionary()
		{
			((UnitySerializedDictionary<global::System.Int32Enum, object>)(object)this)._002Ector();
		}
	}

	[Serializable]
	public class PrefabRefData
	{
		private AssetReference _PoolRef;

		public AssetReference PoolRef
		{
			get
			{
				return _PoolRef;
			}
			set
			{
				_PoolRef = value;
			}
		}
	}

	private ObjectPool _DefaultPool;

	protected PoolsDictionary _Pools;

	protected PoolRefsDictionary _PoolRefs;

	private List<GenericPoolFactory<T>> _LinkedFactories;

	private readonly Dictionary<T, ObjectPool> _cachedPools;

	protected virtual GenericPoolFactory<T> GetDlcFactory(BundleManifestData bmd)
	{
		return null;
	}

	public void InitPools()
	{
		//IL_0284: Expected O, but got I
		//IL_02f2: Expected O, but got I
		//IL_0302: Expected O, but got I
		//IL_0049: Expected O, but got I
		//IL_0203: Expected O, but got I
		//IL_0213: Expected O, but got I
		//IL_00ea: Expected O, but got I
		//IL_037d: Expected O, but got I
		//IL_038d: Expected O, but got I
		//IL_023c: Expected O, but got I
		//IL_024c: Expected O, but got I
		//IL_01bd: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+58]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+58]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdi_v1+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+58]");
				ObjectPool objectPool = (ObjectPool)0;
				if (!objectPool._003CInitialized_003Ek__BackingField)
				{
					objectPool._003CInitialized_003Ek__BackingField = true;
					objectPool.AutoFillName();
					objectPool.Populate(objectPool._defaultSize);
				}
			}
		}
		object obj4 = default(object);
		Dictionary<DlcType, BundleManifestData>.Enumerator enumerator = default(Dictionary<DlcType, BundleManifestData>.Enumerator);
		object obj9 = default(object);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ stack_10_v3+20]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ rcx_v10+C0]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184A16D70");
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				ObjectPool objectPool2 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
					int num = ((Dictionary<global::System.Int32Enum, object>)0).FindEntry((global::System.Int32Enum)0);
					int num2 = num >> 31;
					int num3 = num2 ^ 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
					if ((nint)0 == 0)
					{
						if (0 == 0)
						{
							break;
						}
						if ((objectPool2._003CInitialized_003Ek__BackingField ? 1 : 0) == num3)
						{
							objectPool2._003CInitialized_003Ek__BackingField = true;
							((ObjectPool)null).AutoFillName();
							((ObjectPool)null).Populate(objectPool2._defaultSize, PopulateMethod.Set);
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
						bool flag = ((Dictionary<global::System.Int32Enum, object>)0).TryInsert((global::System.Int32Enum)0, (object)null, global::System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					}
					continue;
				}
				throw new NullReferenceException();
			}
			Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
			while (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				GenericPoolFactory<T> dlcFactory = GetDlcFactory((BundleManifestData)null);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ stack_10_v3+20]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v891 @ rdx_v15+C0]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1835EECE0");
			}
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ stack_10_v4+20]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v993 @ rcx_v19+C0]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1849DB9F0");
				if (obj9 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ stack_10_v4+20]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ rcx_v21+C0]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1835EECE0");
					continue;
				}
				break;
			}
			return;
		}
		throw new NullReferenceException();
	}

	public ObjectPool GetPool(T poolType)
	{
		//IL_003e: Expected I4, but got O
		//IL_003e: Expected O, but got I
		//IL_006f: Expected O, but got I
		//IL_00aa: Expected I4, but got O
		//IL_00aa: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
			int num = ((Dictionary<global::System.Int32Enum, object>)0).FindEntry((global::System.Int32Enum)poolType);
			if (num < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+58]");
				return (ObjectPool)0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
				return (ObjectPool)((Dictionary<global::System.Int32Enum, object>)0).get_Item((global::System.Int32Enum)poolType);
			}
		}
		return (ObjectPool)(object)new NullReferenceException();
	}

	public Dictionary<T, ObjectPool> GetAllPools()
	{
		//IL_000d: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
		return (Dictionary<T, ObjectPool>)0;
	}

	public void PurgePools()
	{
		//IL_01bf: Expected O, but got I
		//IL_004a: Expected O, but got I
		//IL_016f: Expected O, but got I
		//IL_017f: Expected O, but got I
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+58]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+58]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rbx_v1+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+58]");
				((ObjectPool)0).Purge();
			}
		}
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184775EB0");
		ObjectPool objectPool = null;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj5 = default(object);
		ObjectPool objectPool2 = default(ObjectPool);
		while (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ stack_-38_v10+2C]");
			if (obj3 == null)
			{
				object obj4 = obj5;
				bool flag;
				do
				{
					object obj6 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ stack_-38_v10+20]");
					if ((nint)obj6 < 0)
					{
						obj5 = obj4 + 1;
						object obj7 = obj4 * 2;
						object obj8 = obj4 + obj7;
						object obj9 = obj8 * 8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ stack_-38_v10+18]");
						object obj10 = 0 + obj9;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v676 @ rax_v42+20]");
						flag = (nint)0 < (nint)0;
						obj4 = obj5;
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_10_v10+20]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v714 @ rdx_v15+C0]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1847763D0");
					return;
				}
				while (flag);
				objectPool2.Purge();
				continue;
			}
			global::System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			objectPool = null;
			break;
		}
		throw new NullReferenceException();
	}

	private void InitPool(T poolType, ObjectPool pool)
	{
		//IL_0019: Expected I4, but got O
		//IL_0019: Expected O, but got I
		//IL_00b3: Expected I4, but got O
		//IL_00b3: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
		int num = ((Dictionary<global::System.Int32Enum, object>)0).FindEntry((global::System.Int32Enum)poolType);
		if (num < 0)
		{
			if (!pool._003CInitialized_003Ek__BackingField)
			{
				pool._003CInitialized_003Ek__BackingField = true;
				pool.AutoFillName();
				pool.Populate(pool._defaultSize);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
			bool flag = ((Dictionary<global::System.Int32Enum, object>)0).TryInsert((global::System.Int32Enum)poolType, (object)pool, global::System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
	}

	private void MergeFactoryAndInitPool(GenericPoolFactory<T> other, DlcType? dlcType)
	{
		//IL_03e0: Expected O, but got I
		//IL_03f0: Expected O, but got I
		//IL_0065: Expected O, but got I
		//IL_0075: Expected O, but got I
		//IL_0085: Expected O, but got I
		//IL_009a: Expected O, but got I
		//IL_0470: Expected O, but got I
		//IL_0480: Expected O, but got I
		//IL_0452: Expected O, but got I
		//IL_0109: Expected O, but got I
		//IL_0134: Expected O, but got I4
		//IL_0221: Expected O, but got I
		//IL_0289: Expected O, but got I
		//IL_01d5: Expected O, but got I
		//IL_02f8: Expected O, but got I
		//IL_0339: Expected O, but got I
		if ((object)other == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [other @ rdx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		object obj3 = default(object);
		ObjectPool objectPool = default(ObjectPool);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ stack_20_v3+20]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ rcx_v11+C0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184A16D70");
			if (obj3 == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ stack_20_v3+20]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rcx_v36+C0]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v585 @ rax_v69+158]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rdi_v10+20]");
			Dictionary<global::System.Int32Enum, object> dictionary = (Dictionary<global::System.Int32Enum, object>)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			global::System.Int32Enum int32Enum = (global::System.Int32Enum)0;
			if (false)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F948D0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
				bool flag = (nint)0 == 0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
					int num = ((Dictionary<global::System.Int32Enum, object>)0).FindEntry((global::System.Int32Enum)0);
					int num2 = num >> 31;
					int num3 = num2 ^ 1;
					object obj7 = !flag;
					if (obj7 == null)
					{
						if ((object)objectPool == null)
						{
							throw new NullReferenceException();
						}
						if ((objectPool._003CInitialized_003Ek__BackingField ? 1 : 0) == num3)
						{
							objectPool._003CInitialized_003Ek__BackingField = true;
							objectPool.AutoFillName();
							objectPool.Populate(objectPool._defaultSize);
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
						bool flag2 = ((Dictionary<global::System.Int32Enum, object>)0).TryInsert((global::System.Int32Enum)0, (object)objectPool, global::System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					}
					continue;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		object obj10 = default(object);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ stack_20_v7+20]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v870 @ rcx_v18+C0]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184A16D70");
			if (obj10 == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			ObjectPool objectPool2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
			Dictionary<global::System.Int32Enum, object> dictionary = (Dictionary<global::System.Int32Enum, object>)0;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
				int num4 = ((Dictionary<global::System.Int32Enum, object>)0).FindEntry((global::System.Int32Enum)0);
				int num5 = num4 >> 31;
				int num6 = num5 ^ 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
				if ((nint)0 == 0)
				{
					bool flag4 = 0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
					dictionary = (Dictionary<global::System.Int32Enum, object>)0;
					if (flag4)
					{
						throw new NullReferenceException();
					}
					if ((objectPool2._003CInitialized_003Ek__BackingField ? 1 : 0) == num6)
					{
						objectPool2._003CInitialized_003Ek__BackingField = true;
						((ObjectPool)null).AutoFillName();
						((ObjectPool)null).Populate(objectPool2._defaultSize, PopulateMethod.Set);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
					dictionary = (Dictionary<global::System.Int32Enum, object>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+78]");
					bool flag5 = ((Dictionary<global::System.Int32Enum, object>)0).TryInsert((global::System.Int32Enum)0, (object)null, global::System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				}
				continue;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public unsafe List<string> ValidateReferences()
	{
		//IL_0333: Expected O, but got I
		//IL_0343: Expected O, but got I
		//IL_0027: Expected O, but got I4
		//IL_03ce: Expected O, but got I
		//IL_03de: Expected O, but got I
		//IL_00cf: Expected O, but got I
		//IL_00df: Expected O, but got I
		//IL_00ef: Expected O, but got I
		//IL_0104: Expected O, but got I
		//IL_011c: Expected O, but got I4
		//IL_0450: Expected O, but got I
		//IL_0460: Expected O, but got I
		//IL_0074: Expected O, but got Ref
		//IL_008f: Expected O, but got Ref
		//IL_0131: Expected O, but got I
		//IL_01ac: Expected O, but got Ref
		//IL_01c7: Expected O, but got Ref
		List<string> list = new List<string>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+60]");
		if ((nint)0 != 0)
		{
			object obj3 = default(object);
			object obj5 = default(object);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ stack_10_v8+20]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rcx_v12+C0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184A16D70");
				if (obj3 == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				object obj4 = 0;
				if (false)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rbx_v16+10]");
					if ((nint)0 != 0)
					{
						continue;
					}
				}
				string item = ((Enum)(&obj5)).ToString();
				bool flag = list == null;
				Enum obj6 = (Enum)(&obj5);
				if (!flag)
				{
					list.Add(item);
					nint num = 0;
					continue;
				}
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+68]");
			if ((nint)0 != 0)
			{
				object obj9 = default(object);
				object obj16 = default(object);
				object obj17 = default(object);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ stack_10_v9+20]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v899 @ rcx_v16+C0]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184A16D70");
					if (obj9 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ stack_10_v9+20]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v946 @ rcx_v35+C0]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v947 @ rax_v68+158]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v567 @ rbx_v12+20]");
					Enum obj6 = (Enum)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					object obj13 = 0;
					if (false)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ rax_v72+10]");
						object obj14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ rax_v72+10]");
						bool flag2 = (nint)0 == 0;
						obj6 = (Enum)(object)typeof(AddressableLoader);
						if (!flag2)
						{
							object obj15 = obj14;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1299 @ rdx_v22+248] (should have been resolved before IL gen)");
							if (obj16 == null)
							{
								string item2 = ((Enum)(&obj17)).ToString();
								bool flag3 = list == null;
								obj6 = (Enum)(&obj17);
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Framework.GenericPoolFactory`1<T>)+70]");
				if ((nint)0 != 0)
				{
					object obj20 = default(object);
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v814 @ stack_10_v10+20]");
						object obj18 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1293 @ rcx_v20+C0]");
						object obj19 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1849DB9F0");
						if (obj20 != null)
						{
							Enum obj21 = null;
							continue;
						}
						break;
					}
					return list;
				}
			}
		}
		throw new NullReferenceException();
	}

	public GenericPoolFactory()
	{
		nint num = 0;
		UnitySerializedDictionary<global::System.Int32Enum, object> unitySerializedDictionary = new UnitySerializedDictionary<global::System.Int32Enum, object>();
		nint num2 = 0;
		UnitySerializedDictionary<global::System.Int32Enum, object> unitySerializedDictionary2 = new UnitySerializedDictionary<global::System.Int32Enum, object>();
		nint num3 = 0;
		object obj = null;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18485AFD0");
		((ScriptableObject)this)._002Ector();
	}
}
