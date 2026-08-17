using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using QFSW.MOP2;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Validation;
using VampireSurvivors.Objects;

namespace VampireSurvivors.App.Framework;

public class EnemyFactory : SerializedScriptableObject, IValidateReferences
{
	[Serializable]
	public class EnemyPoolsDictionary : UnitySerializedDictionary<EnemyType, GameObject>
	{
		public EnemyPoolsDictionary()
		{
			((UnitySerializedDictionary<global::System.Int32Enum, object>)(object)this)._002Ector();
		}
	}

	[Serializable]
	public class EnemyRefsDictionary : UnitySerializedDictionary<EnemyType, PrefabRefData>
	{
		public EnemyRefsDictionary()
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

	[Serializable]
	public class PrefabPathData
	{
		private string _PrefabPath;

		public string PrefabPath
		{
			get
			{
				return _PrefabPath;
			}
			set
			{
				_PrefabPath = value;
			}
		}

		public string PathWithoutExtension => Path.ChangeExtension(_PrefabPath, null);

		public string PathWithExtension => _PrefabPath;
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CFillUpPoolsAsync_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public EnemyFactory _003C_003E4__this;

		public CancellationToken ct;

		private SwitchToMainThreadAwaitable.Awaiter _003C_003Eu__1;

		private Dictionary<EnemyType, ObjectPool>.Enumerator _003C_003E7__wrap1;

		private UniTask.Awaiter _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_01ba: Expected O, but got Ref
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0224: Expected O, but got Ref
			//IL_01d8: Expected O, but got I
			//IL_01f8: Expected O, but got I8
			//IL_0201: Expected O, but got I4
			//IL_0211: Expected O, but got I
			//IL_00a1: Expected O, but got Ref
			//IL_006e: Expected O, but got I4
			//IL_017d: Expected O, but got I4
			//IL_0188: Expected O, but got Ref
			//IL_0473: Expected O, but got Ref
			//IL_0292: Expected O, but got I
			//IL_03f0: Expected O, but got Ref
			//IL_048e: Expected O, but got I4
			//IL_0497: Expected O, but got I4
			//IL_0306: Expected O, but got I
			//IL_010a: Expected O, but got Ref
			//IL_0398: Expected O, but got I4
			//IL_0340: Expected O, but got I
			//IL_03c3: Expected O, but got I4
			//IL_0159: Expected O, but got Ref
			//IL_0162: Expected O, but got I4
			//IL_0421: Expected O, but got Ref
			//IL_0376: Expected O, but got I
			EnemyFactory enemyFactory = _003C_003E4__this;
			CancellationToken cancellationToken = default(CancellationToken);
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (SwitchToMainThreadAwaitable.Awaiter)0;
				_003C_003E1__state = -1;
			}
			else
			{
				if (_003C_003E1__state == 1)
				{
					goto IL_01a0;
				}
				SwitchToMainThreadAwaitable.Awaiter awaiter = default(SwitchToMainThreadAwaitable.Awaiter);
				bool isCompleted = awaiter.IsCompleted;
				bool flag = !isCompleted;
				cancellationToken = (CancellationToken)0;
				if (flag)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (SwitchToMainThreadAwaitable.Awaiter)8;
					AsyncUniTaskMethodBuilder asyncUniTaskMethodBuilder = (AsyncUniTaskMethodBuilder)global::System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncUniTaskMethodBuilder*)asyncUniTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			cancellationToken.ThrowIfCancellationRequested();
			bool flag2 = (object)enemyFactory == null;
			CancellationToken cancellationToken2 = (CancellationToken)(&cancellationToken);
			global::System.ParamsArray paramsArray2 = default(global::System.ParamsArray);
			UniTask.Awaiter awaiter2;
			global::System.ParamsArray paramsArray;
			CancellationToken cachedEnemyPools;
			object obj;
			if (!flag2)
			{
				cancellationToken2 = (CancellationToken)enemyFactory._cachedEnemyPools;
				if (enemyFactory._cachedEnemyPools != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg = default(object);
					paramsArray = new global::System.ParamsArray(arg);
					string message = string.FormatHelper((IFormatProvider)null, "Cached Pool Count: {0}", (global::System.ParamsArray)(&paramsArray2));
					Debug.Log(message);
					cachedEnemyPools = (CancellationToken)enemyFactory._cachedEnemyPools;
					_003C_003E7__wrap1 = (Dictionary<EnemyType, ObjectPool>.Enumerator)enemyFactory._cachedEnemyPools;
					_ = 0;
					_ = 2;
					awaiter2 = (UniTask.Awaiter)global::System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 56));
					obj = 0;
					goto IL_01a0;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
			IL_01a0:
			object obj2 = default(object);
			bool flag3 = (nint)obj2 != 1;
			global::System.ParamsArray paramsArray3 = (global::System.ParamsArray)(&obj2);
			if (flag3)
			{
				goto IL_0216;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ stack_8_v6 (<FillUpPoolsAsync>d__14&)+60]");
			UniTask.Awaiter awaiter3 = (UniTask.Awaiter)0;
			_ = 0;
			ref _003CFillUpPoolsAsync_003Ed__14 reference = ref *(_003CFillUpPoolsAsync_003Ed__14*)4294967295L;
			obj2 = 4294967295L;
			obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ stack_8_v6 (<FillUpPoolsAsync>d__14&)+60]");
			UniTask.Awaiter awaiter4 = (UniTask.Awaiter)0;
			goto IL_0534;
			IL_0512:
			reference = ref *(_003CFillUpPoolsAsync_003Ed__14*)4294967294L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ stack_8_v6 (<FillUpPoolsAsync>d__14&)+8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			return;
			IL_0534:
			bool flag4 = (object)awaiter3 == null;
			awaiter2 = awaiter3;
			paramsArray3 = (global::System.ParamsArray)awaiter3;
			if (!flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006070");
				cachedEnemyPools = (CancellationToken)(&(ref reference));
				awaiter2 = awaiter3;
				paramsArray3 = (global::System.ParamsArray)awaiter3;
			}
			goto IL_0216;
			IL_0216:
			Dictionary<EnemyType, ObjectPool>.Enumerator enumerator = (Dictionary<EnemyType, ObjectPool>.Enumerator)global::System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref reference, 56));
			if (((Dictionary<EnemyType, ObjectPool>.Enumerator*)enumerator)->MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ stack_8_v6 (<FillUpPoolsAsync>d__14&)+20]");
				bool flag5 = (nint)0 == 0;
				cancellationToken2 = (CancellationToken)typeof(CancellationToken);
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ stack_8_v6 (<FillUpPoolsAsync>d__14&)+20]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ rax_v52+20]");
					if ((nint)0 >= (nint)2)
					{
						goto IL_0512;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ stack_8_v6 (<FillUpPoolsAsync>d__14&)+48]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ stack_8_v6 (<FillUpPoolsAsync>d__14&)+48]");
					((ObjectPool)0).Populate(200);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ stack_8_v6 (<FillUpPoolsAsync>d__14&)+20]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ stack_8_v6 (<FillUpPoolsAsync>d__14&)+20]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1133 @ rax_v49+20]");
						if ((nint)0 >= (nint)2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ stack_8_v6 (<FillUpPoolsAsync>d__14&)+48]");
							((ObjectPool)0).Purge();
						}
					}
					bool cancelImmediately = default(bool);
					UniTask uniTask = UniTask.DelayFrame(10, PlayerLoopTiming.Update, (CancellationToken)0, cancelImmediately);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1842F6520");
					object obj5 = default(object);
					bool flag6 = obj5 == null;
					cachedEnemyPools = (CancellationToken)0;
					awaiter3 = awaiter3;
					if (!flag6)
					{
						goto IL_0534;
					}
					reference = ref *(_003CFillUpPoolsAsync_003Ed__14*)1;
					AsyncUniTaskMethodBuilder asyncUniTaskMethodBuilder2 = (AsyncUniTaskMethodBuilder)global::System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref reference, 8));
					((AsyncUniTaskMethodBuilder*)asyncUniTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter4, ref reference);
					return;
				}
				throw new NullReferenceException();
			}
			_ = 0;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg2 = default(object);
			paramsArray = new global::System.ParamsArray(arg2);
			string message2 = string.FormatHelper((IFormatProvider)null, "{0} pools filled", (global::System.ParamsArray)(&paramsArray2));
			Debug.Log(message2);
			cachedEnemyPools = (CancellationToken)0;
			obj = 0;
			paramsArray3 = paramsArray;
			goto IL_0512;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private GameObject _DefaultEnemyPrefab;

	private EnemyPoolsDictionary _EnemyPools;

	private EnemyRefsDictionary _EnemyRefs;

	private List<EnemyFactory> _LinkedFactories;

	private readonly Dictionary<EnemyType, ObjectPool> _cachedEnemyPools;

	private readonly Dictionary<GameObject, ObjectPool> _cachedPoolsByPrefab;

	public unsafe GameObject GetEnemyPrefab(EnemyType enemyType)
	{
		//IL_008f: Expected O, but got I4
		//IL_0097: Expected O, but got Ref
		//IL_037b: Expected O, but got I4
		if (_EnemyPools != null)
		{
			int num = ((Dictionary<global::System.Int32Enum, object>)(object)_EnemyPools).FindEntry((global::System.Int32Enum)enemyType);
			if (_EnemyPools == null)
			{
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
						List<EnemyFactory>.Enumerator enumerator3 = default(List<EnemyFactory>.Enumerator);
						while (enumerator3.MoveNext())
						{
							object obj2 = 0;
						}
						return _DefaultEnemyPrefab;
					}
				}
			}
			else if (_EnemyPools != null)
			{
				return (GameObject)((Dictionary<global::System.Int32Enum, object>)(object)_EnemyPools).get_Item((global::System.Int32Enum)enemyType);
			}
		}
		throw new NullReferenceException();
	}

	public void InitPools(Stage stage, DataManager dataManager)
	{
		//IL_0035: Expected O, but got I
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		if (_EnemyPools != null)
		{
			Dictionary<EnemyType, GameObject>.Enumerator enumerator = default(Dictionary<EnemyType, GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				Dictionary<global::System.Int32Enum, object> dictionary = (Dictionary<global::System.Int32Enum, object>)0;
				if (dataManager != null)
				{
					Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = dataManager.GetConvertedEnemyData();
					bool flag = convertedEnemyData == null;
					dictionary = (Dictionary<global::System.Int32Enum, object>)(object)convertedEnemyData;
					if (!flag)
					{
						int num = ((Dictionary<global::System.Int32Enum, object>)(object)convertedEnemyData).FindEntry((global::System.Int32Enum)0);
						if (!flag)
						{
							GeneratePool(EnemyType.BAT1, null, 1);
						}
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
			if (loadedDlc != null)
			{
				Dictionary<DlcType, BundleManifestData>.Enumerator enumerator2 = default(Dictionary<DlcType, BundleManifestData>.Enumerator);
				while (enumerator2.MoveNext())
				{
					bool flag2 = (object)stage == null;
					Dictionary<global::System.Int32Enum, object> dictionary = (Dictionary<global::System.Int32Enum, object>)(object)DlcSystem._utils;
					if (!flag2)
					{
						bool flag3 = DlcSystem._utils == null;
						dictionary = (Dictionary<global::System.Int32Enum, object>)(object)DlcSystem._utils;
						if (!flag3)
						{
							DlcType? stageDlcType = DlcSystem._utils.GetStageDlcType(stage._stageType, dataManager);
							dictionary = (Dictionary<global::System.Int32Enum, object>)((object?)stageDlcType >> 32);
							bool flag4 = dictionary == null;
							object obj = (_003F?)stageDlcType & flag4;
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
								DlcType dlcType = DlcType.Moonspell;
								throw new NullReferenceException();
							}
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				if (_LinkedFactories != null)
				{
					List<EnemyFactory>.Enumerator enumerator3 = default(List<EnemyFactory>.Enumerator);
					while (enumerator3.MoveNext())
					{
						MergeInNewEnemies(null);
					}
					GeneratePool(EnemyType.BAT1, _DefaultEnemyPrefab, 500);
					if (_cachedPoolsByPrefab != null)
					{
						_cachedPoolsByPrefab.Clear();
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void MergeInNewEnemies(EnemyFactory other)
	{
		if ((object)other == null || ((UnityEngine.Object)other).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Dictionary<EnemyType, PrefabRefData>.Enumerator enumerator = default(Dictionary<EnemyType, PrefabRefData>.Enumerator);
		GameObject prefab = default(GameObject);
		while (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			EnemyType enemyType = EnemyType.BAT1;
			nint num = 0;
			if (false)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F94830");
				GeneratePool(EnemyType.BAT1, prefab, 1);
				continue;
			}
			throw new NullReferenceException();
		}
		Dictionary<EnemyType, GameObject>.Enumerator enumerator2 = default(Dictionary<EnemyType, GameObject>.Enumerator);
		while (enumerator2.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			GeneratePool(EnemyType.BAT1, null, 1);
		}
	}

	private void MergeInNewDlcEnemies(EnemyFactory other, DlcType dlcType)
	{
		if ((object)other == null || ((UnityEngine.Object)other).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Dictionary<EnemyType, PrefabRefData>.Enumerator enumerator = default(Dictionary<EnemyType, PrefabRefData>.Enumerator);
		GameObject prefab = default(GameObject);
		while (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			nint num = 0;
			EnemyType enemyType = EnemyType.BAT1;
			if (false)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F94830");
				GeneratePool(EnemyType.BAT1, prefab, 1);
				continue;
			}
			throw new NullReferenceException();
		}
		Dictionary<EnemyType, GameObject>.Enumerator enumerator2 = default(Dictionary<EnemyType, GameObject>.Enumerator);
		while (enumerator2.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			GeneratePool(EnemyType.BAT1, null, 1);
		}
	}

	public ObjectPool GetEnemyPool(string enemyTypeString)
	{
		//IL_0012: Expected O, but got I4
		ObjectPool result = (ObjectPool)Enum.Parse<EnemyType>(enemyTypeString);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 46 Invalid \"Jump target not found in method: 0x186C20A80\"");
		return result;
	}

	public ObjectPool GetEnemyPool(EnemyType enemyType)
	{
		if (_cachedEnemyPools != null)
		{
			int num = ((Dictionary<global::System.Int32Enum, object>)(object)_cachedEnemyPools).FindEntry((global::System.Int32Enum)enemyType);
			if (num >= 0)
			{
				if (_cachedEnemyPools != null)
				{
					return (ObjectPool)((Dictionary<global::System.Int32Enum, object>)(object)_cachedEnemyPools).get_Item((global::System.Int32Enum)enemyType);
				}
			}
			else if (_cachedEnemyPools != null)
			{
				return (ObjectPool)((Dictionary<global::System.Int32Enum, object>)(object)_cachedEnemyPools).get_Item((global::System.Int32Enum)0);
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
		Dictionary<EnemyType, ObjectPool>.ValueCollection values = _cachedEnemyPools.Values;
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
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v567 @ rax_v34+20]");
						flag = (nint)0 < (nint)0;
						obj3 = obj4;
						continue;
					}
					_cachedEnemyPools.Clear();
					_cachedPoolsByPrefab.Clear();
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

	private unsafe void GeneratePool(EnemyType et, GameObject prefab, int poolSize = 50)
	{
		//IL_045a: Expected O, but got Ref
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected Ref, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected Ref, but got Unknown
		//IL_00d3: Expected I8, but got I4
		//IL_026e: Expected O, but got I4
		//IL_0285: Expected O, but got Ref
		//IL_02a8: Expected I4, but got I8
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		if (text != null)
		{
			string text2 = text.ToLowerInvariant();
			if (text2 != null)
			{
				object obj = "test";
				if ((object)text2 == "test")
				{
					return;
				}
				if ("test" != null)
				{
					int stringLength = text2._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rdx_v6+10]");
					if ((nint)stringLength == 0)
					{
						ref byte first = ref *(byte*)(text2 + 20);
						ref byte second = ref *(byte*)("test" + 20);
						ulong length = (ulong)(text2._stringLength + text2._stringLength);
						if (global::System.SpanHelpers.SequenceEqual(ref first, ref second, length))
						{
							return;
						}
					}
				}
				bool flag = _cachedPoolsByPrefab == null;
				if (!flag)
				{
					int num = _cachedPoolsByPrefab.FindEntry(prefab);
					if (flag)
					{
						goto IL_0231;
					}
					if (_cachedPoolsByPrefab != null)
					{
						ObjectPool objectPool = _cachedPoolsByPrefab.get_Item(prefab);
						if ((object)objectPool == null || ((UnityEngine.Object)objectPool).m_CachedPtr == (IntPtr)0)
						{
							goto IL_0231;
						}
						if (_cachedEnemyPools != null)
						{
							int num2 = ((Dictionary<global::System.Int32Enum, object>)(object)_cachedEnemyPools).FindEntry((global::System.Int32Enum)et);
							if (num2 >= 0)
							{
								return;
							}
							if (_cachedEnemyPools != null)
							{
								bool flag2 = ((Dictionary<global::System.Int32Enum, object>)(object)_cachedEnemyPools).TryInsert((global::System.Int32Enum)et, (object)objectPool, global::System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								return;
							}
						}
					}
				}
			}
		}
		goto IL_0435;
		IL_0435:
		throw new NullReferenceException();
		IL_0231:
		bool flag3 = _cachedEnemyPools == null;
		if (!flag3)
		{
			int num3 = ((Dictionary<global::System.Int32Enum, object>)(object)_cachedEnemyPools).FindEntry((global::System.Int32Enum)et);
			object obj2 = !flag3;
			if (obj2 != null)
			{
				return;
			}
			IntPtr intPtr2 = default(IntPtr);
			string text3 = ((Enum)(&intPtr2)).ToString();
			ObjectPool objectPool2 = ObjectPool.Create(prefab, text3, poolSize, -1);
			if ((object)objectPool2 != null)
			{
				objectPool2._incrementalInstanceNames = true;
				if (!objectPool2._003CInitialized_003Ek__BackingField)
				{
					objectPool2._003CInitialized_003Ek__BackingField = true;
					objectPool2.AutoFillName();
					objectPool2.Populate(objectPool2._defaultSize);
				}
				if ((object)MasterObjectPooler._003CInstance_003Ek__BackingField != null)
				{
					MasterObjectPooler._003CInstance_003Ek__BackingField.AddPool(objectPool2._name, objectPool2);
					if (_cachedEnemyPools != null)
					{
						bool flag4 = ((Dictionary<global::System.Int32Enum, object>)(object)_cachedEnemyPools).TryInsert((global::System.Int32Enum)et, (object)objectPool2, global::System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
						if (_cachedPoolsByPrefab != null)
						{
							bool flag5 = ((Dictionary<object, object>)(object)_cachedPoolsByPrefab).TryInsert((object)prefab, (object)objectPool2, global::System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							if (objectPool2._pooledObjects != null)
							{
								List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
								if (!enumerator.MoveNext())
								{
									return;
								}
								GameObject gameObject = null;
								throw new NullReferenceException();
							}
						}
					}
				}
			}
		}
		goto IL_0435;
	}

	private unsafe UniTask FillUpPoolsAsync(CancellationToken ct)
	{
		//IL_002b: Expected native int or pointer, but got O
		_003CFillUpPoolsAsync_003Ed__14 obj = default(_003CFillUpPoolsAsync_003Ed__14);
		obj.MoveNext();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1832216A0");
		UniTask uniTask = default(UniTask);
		object source = default(object);
		global::System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, source);
		return uniTask;
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
		if (_EnemyPools != null)
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
			if (_EnemyRefs != null)
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
					List<EnemyFactory>.Enumerator enumerator3 = default(List<EnemyFactory>.Enumerator);
					while (enumerator3.MoveNext())
					{
						EnemyFactory enemyFactory = null;
					}
					return list;
				}
			}
		}
		throw new NullReferenceException();
	}

	public EnemyFactory()
	{
		EnemyPoolsDictionary enemyPools = (EnemyPoolsDictionary)(object)new UnitySerializedDictionary<global::System.Int32Enum, object>();
		_EnemyPools = enemyPools;
		_EnemyRefs = (EnemyRefsDictionary)(object)new UnitySerializedDictionary<global::System.Int32Enum, object>();
		_cachedEnemyPools = new Dictionary<EnemyType, ObjectPool>();
		_cachedPoolsByPrefab = new Dictionary<GameObject, ObjectPool>();
		((ScriptableObject)this)._002Ector();
	}
}
