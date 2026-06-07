using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using QFSW.MOP2;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Validation;
using VampireSurvivors.Objects;

namespace VampireSurvivors.App.Framework
{
	[CreateAssetMenu(fileName = "EnemyFactory", menuName = "VampireSurvivors/New EnemyFactory")]
	public class EnemyFactory : SerializedScriptableObject, IValidateReferences
	{
		[Serializable]
		public class EnemyPoolsDictionary : UnitySerializedDictionary<EnemyType, GameObject>
		{
		}

		[Serializable]
		public class EnemyRefsDictionary : UnitySerializedDictionary<EnemyType, PrefabRefData>
		{
		}

		[Serializable]
		public class PrefabRefData
		{
			[SerializeField]
			private AssetReferenceT<GameObject> _PrefabRef;

			public AssetReferenceT<GameObject> PrefabRef
			{
				get
				{
					return null;
				}
				set
				{
				}
			}
		}

		[Serializable]
		public class PrefabPathData
		{
			[SerializeField]
			private string _PrefabPath;

			public string PrefabPath
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public string PathWithoutExtension => null;

			public string PathWithExtension => null;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CFillUpPoolsAsync_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public EnemyFactory _003C_003E4__this;

			public CancellationToken ct;

			private SwitchToMainThreadAwaitable.Awaiter _003C_003Eu__1;

			private Dictionary<EnemyType, ObjectPool>.Enumerator _003C_003E7__wrap1;

			private UniTask.Awaiter _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[SerializeField]
		private GameObject _DefaultEnemyPrefab;

		[SerializeField]
		private EnemyPoolsDictionary _EnemyPools;

		[SerializeField]
		private EnemyRefsDictionary _EnemyRefs;

		[SerializeField]
		private List<EnemyFactory> _LinkedFactories;

		private readonly Dictionary<EnemyType, ObjectPool> _cachedEnemyPools;

		private readonly Dictionary<GameObject, ObjectPool> _cachedPoolsByPrefab;

		public GameObject GetEnemyPrefab(EnemyType enemyType)
		{
			return null;
		}

		public void InitPools(Stage stage, DataManager dataManager)
		{
		}

		private void MergeInNewEnemies(EnemyFactory other)
		{
		}

		private void MergeInNewDlcEnemies(EnemyFactory other, DlcType dlcType)
		{
		}

		public ObjectPool GetEnemyPool(string enemyTypeString)
		{
			return null;
		}

		public ObjectPool GetEnemyPool(EnemyType enemyType)
		{
			return null;
		}

		public void PurgePools()
		{
		}

		private void GeneratePool(EnemyType et, GameObject prefab, int poolSize = 50)
		{
		}

		[AsyncStateMachine(typeof(_003CFillUpPoolsAsync_003Ed__14))]
		private UniTask FillUpPoolsAsync(CancellationToken ct)
		{
			return default(UniTask);
		}

		public List<string> ValidateReferences()
		{
			return null;
		}
	}
}
