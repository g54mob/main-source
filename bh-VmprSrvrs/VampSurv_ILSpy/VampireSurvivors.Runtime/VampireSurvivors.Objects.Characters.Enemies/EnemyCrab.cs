using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyCrab : EnemyController
{
	private sealed class _003C_003Ec__DisplayClass35_0
	{
		public EnemyCrab _003C_003E4__this;

		public Bounds camBounds;

		internal void _003CDrownerWarning_003Eb__0()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyCrab+<>c__DisplayClass35_0)+24]");
			float num = 0f * 2f;
			float sizeX = num * 0.5f;
			_003C_003E4__this.SingleWarning(sizeX);
		}

		internal void _003CDrownerWarning_003Eb__1()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyCrab+<>c__DisplayClass35_0)+24]");
			float num = 0f * 2f;
			float sizeX = num * 0.75f;
			_003C_003E4__this.SingleWarning(sizeX);
		}

		internal void _003CDrownerWarning_003Eb__2()
		{
			//IL_00d7: Expected O, but got I
			//IL_0194->IL0110: Incompatible stack heights: 1 vs 0
			//IL_00af->IL0110: Incompatible stack heights: 1 vs 0
			//IL_00f3->IL0110: Incompatible stack heights: 1 vs 0
			EnemyCrab enemyCrab = _003C_003E4__this;
			if ((object)_003C_003E4__this != null)
			{
				GameSessionData gameSessionData = enemyCrab._gameSessionData;
				if (enemyCrab._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					Transform transform = gameSessionData._activeCharacter.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						Transform transform2 = (Transform)(object)_003C_003E4__this;
						if ((object)_003C_003E4__this != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v5 (UnityEngine.Transform)+280]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v5 (UnityEngine.Transform)+280]");
								Vector2 spawnPos = default(Vector2);
								bool forceSpawn = default(bool);
								GameObject gameObject = ((Stage)0).SpawnEnemy(EnemyType.BOSS_XLDROWNER, spawnPos, asRemote: false, forceSpawn);
								if ((object)gameObject != null)
								{
									EnemyDrowner component = gameObject.GetComponent<EnemyDrowner>();
									return;
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass36_0
	{
		public SpriteRenderer redWarning;

		public GameObject redWarningObject;

		public TweenCallback _003C_003E9__1;

		internal void _003CRedWarning_003Eb__0()
		{
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(redWarning, 0f, 0.1f);
			TweenCallback tweenCallback = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				tweenCallback = (_003C_003E9__1 = delegate
				{
					UnityEngine.Object.Destroy(redWarningObject, 0f);
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal void _003CRedWarning_003Eb__1()
		{
			UnityEngine.Object.Destroy(redWarningObject, 0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass37_0
	{
		public Transform singleWarningTransform;

		public GameObject singleWarningObject;

		public TweenCallback _003C_003E9__1;

		internal unsafe void _003CSingleWarning_003Eb__0()
		{
			//IL_0098: Expected O, but got Ref
			object obj = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(singleWarningTransform, (Vector3)(&obj), 0.2f);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 0.2f);
			TweenCallback tweenCallback = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				tweenCallback = (_003C_003E9__1 = delegate
				{
					UnityEngine.Object.Destroy(singleWarningObject, 0f);
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal void _003CSingleWarning_003Eb__1()
		{
			UnityEngine.Object.Destroy(singleWarningObject, 0f);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CSpawnPincers_003Ed__28 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public EnemyCrab _003C_003E4__this;

		private SwitchToMainThreadAwaitable.Awaiter _003C_003Eu__1;

		private UniTask.Awaiter _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0028: Expected O, but got I4
			//IL_0064: Expected O, but got I4
			//IL_0073: Expected I4, but got I8
			//IL_007c: Expected O, but got I4
			//IL_00ac: Expected O, but got I4
			//IL_00b5: Expected O, but got I4
			//IL_0205: Expected O, but got I4
			//IL_0210: Expected O, but got Ref
			//IL_01d4: Expected I4, but got I8
			//IL_01df: Expected O, but got Ref
			//IL_0261: Expected O, but got Ref
			//IL_0181: Expected O, but got Ref
			CancellationToken cancellationToken;
			UniTask.Awaiter awaiter;
			CancellationToken cancellationToken2 = default(CancellationToken);
			UniTask.Awaiter awaiter2;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (SwitchToMainThreadAwaitable.Awaiter)0;
				_003C_003E1__state = -1;
				cancellationToken = (CancellationToken)0;
			}
			else
			{
				if (_003C_003E1__state == 1)
				{
					awaiter = _003C_003Eu__2;
					_003C_003Eu__2 = (UniTask.Awaiter)0;
					_003C_003E1__state = -1;
					awaiter2 = (UniTask.Awaiter)0;
					goto IL_029a;
				}
				SwitchToMainThreadAwaitable.Awaiter awaiter3 = default(SwitchToMainThreadAwaitable.Awaiter);
				bool isCompleted = awaiter3.IsCompleted;
				bool flag = !isCompleted;
				cancellationToken2 = (CancellationToken)0;
				cancellationToken = (CancellationToken)0;
				if (flag)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (SwitchToMainThreadAwaitable.Awaiter)8;
					AsyncUniTaskVoidMethodBuilder asyncUniTaskVoidMethodBuilder = (AsyncUniTaskVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncUniTaskVoidMethodBuilder*)asyncUniTaskVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter3, ref this);
					return;
				}
			}
			cancellationToken2.ThrowIfCancellationRequested();
			_003C_003E4__this.SpawnLeftPincer();
			IUniTaskSource uniTaskSource = UniTask.WaitForEndOfFramePromise.Create(_003C_003E4__this, cancellationToken, cancelImmediately: false, out var token);
			UniTask.Awaiter awaiter4 = (UniTask.Awaiter)(&token);
			bool flag2 = uniTaskSource == null;
			awaiter = (UniTask.Awaiter)uniTaskSource;
			awaiter2 = (UniTask.Awaiter)_003C_003Eu__1;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"pextrw r9d,xmm6,4\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
				object obj = default(object);
				bool flag3 = obj != null;
				awaiter = (UniTask.Awaiter)uniTaskSource;
				awaiter2 = (UniTask.Awaiter)_003C_003Eu__1;
				if (!flag3)
				{
					_003C_003E1__state = 1;
					_003C_003Eu__2 = (UniTask.Awaiter)uniTaskSource;
					AsyncUniTaskVoidMethodBuilder asyncUniTaskVoidMethodBuilder2 = (AsyncUniTaskVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					UniTask.Awaiter awaiter5 = default(UniTask.Awaiter);
					((AsyncUniTaskVoidMethodBuilder*)asyncUniTaskVoidMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter5, ref this);
					return;
				}
			}
			goto IL_029a;
			IL_029a:
			if ((object)awaiter != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm7,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006070");
				awaiter4 = awaiter;
			}
			_003C_003E4__this.SpawnRightPincer();
			_003C_003E1__state = -2;
			object obj2 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1844336B0");
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

	private GameObject _RedWarningPrefab;

	private GameObject _SingleWarningPrefab;

	private Stage _stage;

	protected EnemyPincer _leftPincer;

	protected EnemyPincer _rightPincer;

	private EnemyDrowner _drowner;

	protected VampireSurvivors.Framework.TimerSystem.Timer _leftEvent;

	protected VampireSurvivors.Framework.TimerSystem.Timer _rightEvent;

	private bool _isPlayerBelow;

	private bool _drownerSummoned;

	private bool _freshlySpawned;

	private Vector2 _leftPincerPos;

	private Vector2 _rightPincerPos;

	private readonly Vector2 _leftOffset;

	private readonly Vector2 _rightOffset;

	private const float PincerRespawnDelayLeft = 1500f;

	private const float PincerRespawnDelayRight = 1500f;

	private const float SummonDelay = 6000f;

	private VampireSurvivors.Framework.TimerSystem.Timer _summonDelayTimer;

	private VampireSurvivors.Framework.TimerSystem.Timer _drownerWarningTimer1;

	private VampireSurvivors.Framework.TimerSystem.Timer _drownerWarningTimer2;

	private VampireSurvivors.Framework.TimerSystem.Timer _drownerWarningTimer3;

	protected override void FakeConstruct()
	{
		base.FakeConstruct();
		GameManager core = GM.Core;
		_stage = core._stage;
	}

	protected override void Awake()
	{
		base.Awake();
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		_003CSpawnPincers_003Ed__28 obj = default(_003CSpawnPincers_003Ed__28);
		obj.MoveNext();
		base._003CIsTeleportOnCull_003Ek__BackingField = true;
		_freshlySpawned = true;
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_05ce: Expected O, but got Ref
		//IL_0693: Expected O, but got Ref
		//IL_0643: Expected O, but got Ref
		//IL_0706: Expected O, but got Ref
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_018f: Expected O, but got I
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Expected O, but got Unknown
		//IL_0364: Expected O, but got I
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected O, but got Unknown
		//IL_0787: Expected O, but got Ref
		//IL_0270: Expected O, but got I
		//IL_08e4: Expected O, but got Ref
		//IL_0445: Expected O, but got I
		//IL_07f0: Expected O, but got Ref
		//IL_084a: Expected O, but got Ref
		//IL_0950: Expected O, but got Ref
		//IL_09aa: Expected O, but got Ref
		//IL_0612->IL0560: Incompatible stack heights: 1 vs 0
		//IL_06c9->IL0560: Incompatible stack heights: 2 vs 0
		//IL_065b->IL05ee: Incompatible stack heights: 3 vs 1
		//IL_01c3->IL0560: Incompatible stack heights: 3 vs 0
		//IL_0398->IL0560: Incompatible stack heights: 3 vs 0
		//IL_0865->IL074c: Incompatible stack heights: 13 vs 3
		//IL_09c1->IL0889: Incompatible stack heights: 13 vs 3
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.OnUpdate();
		GameSessionData gameSessionData = _gameSessionData;
		if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
		{
			Transform transform = gameSessionData._activeCharacter.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
				Camera main = Camera.main;
				Bounds bounds = CameraExtensions.OrthographicBounds(main);
				bool flag2 = !_freshlySpawned;
				_ = bounds.m_Center;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ rax_v74 (UnityEngine.Bounds)+10]");
				_ = 0;
				if (!flag2)
				{
					_freshlySpawned = false;
					Transform cachedTransform = _cachedTransform;
					bool flag3 = (object)_cachedTransform == null;
					_ = 0;
					bool flag4 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Camera camera = (Camera)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref *(Vector3*)camera);
				}
				Transform cachedTransform2 = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					_ = 0;
					_ = 0;
					bool flag5 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
					object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out *(Vector3*)obj4);
					Transform cachedTransform3 = _cachedTransform;
					if ((object)_cachedTransform != null)
					{
						_ = 0;
						_ = 0;
						bool flag6 = ((UnityEngine.Object)cachedTransform3).m_CachedPtr == (IntPtr)0;
						object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform3).m_CachedPtr, out *(Vector3*)obj5);
						Transform leftPincer = (Transform)(object)_leftPincer;
						if ((object)_leftPincer != null && ((UnityEngine.Object)leftPincer).m_CachedPtr != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
							object obj6 = 0 * _leftOffset;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
							Vector2 leftPincerPos = (Vector2)(obj6 + 0);
							_leftPincerPos = leftPincerPos;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-25]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyCrab)+2C8]");
							object obj7 = num * 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-35]");
							object obj8 = obj7 + 0;
							if ((object)_leftPincer == null)
							{
								goto IL_0560;
							}
							Transform transform2 = _leftPincer.transform;
							bool flag7 = (object)transform2 == null;
							_ = 0;
							bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
							Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj9);
							Transform leftPincer2 = (Transform)(object)_leftPincer;
							bool flag9 = (object)_EnemyRenderer == null;
							int sortingOrder = _EnemyRenderer.sortingOrder;
							bool flag10 = (object)_leftPincer == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1402 @ rbx_v44 (UnityEngine.Transform)+68]");
							bool flag11 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1402 @ rbx_v44 (UnityEngine.Transform)+68]");
							((Renderer)0).sortingOrder = 0;
							bool flag12 = (object)_leftPincer == null;
							Transform transform3 = _leftPincer.transform;
							Transform cachedTransform4 = _cachedTransform;
							bool flag13 = (object)_cachedTransform == null;
							_ = 0;
							bool flag14 = ((UnityEngine.Object)cachedTransform4).m_CachedPtr == (IntPtr)0;
							object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
							Transform.get_rotation_Injected(((UnityEngine.Object)cachedTransform4).m_CachedPtr, out *(Quaternion*)obj10);
							bool flag15 = (object)transform3 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1413 @ rax_v141 (UnityEngine.Transform)+10]");
							bool flag16 = (nint)0 == 0;
							object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1413 @ rax_v141 (UnityEngine.Transform)+10]");
							Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)obj11);
						}
						Transform rightPincer = (Transform)(object)_rightPincer;
						if ((object)_rightPincer != null && ((UnityEngine.Object)rightPincer).m_CachedPtr != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
							object obj12 = 0 * _rightOffset;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
							Vector2 rightPincerPos = (Vector2)(obj12 + 0);
							_rightPincerPos = rightPincerPos;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-25]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyCrab)+2D0]");
							object obj13 = num2 * 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-35]");
							object obj14 = obj13 + 0;
							if ((object)_rightPincer == null)
							{
								goto IL_0560;
							}
							Transform transform4 = _rightPincer.transform;
							bool flag17 = (object)transform4 == null;
							_ = 0;
							bool flag18 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
							object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
							Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)obj15);
							Transform rightPincer2 = (Transform)(object)_rightPincer;
							bool flag19 = (object)_EnemyRenderer == null;
							int sortingOrder2 = _EnemyRenderer.sortingOrder;
							bool flag20 = (object)_rightPincer == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1877 @ rbx_v41 (UnityEngine.Transform)+68]");
							bool flag21 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1877 @ rbx_v41 (UnityEngine.Transform)+68]");
							((Renderer)0).sortingOrder = 0;
							bool flag22 = (object)_rightPincer == null;
							Transform transform5 = _rightPincer.transform;
							object cachedTransform5 = _cachedTransform;
							bool flag23 = (object)_cachedTransform == null;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1702 @ rsi_v35 (System.Object)+10]");
							bool flag24 = (nint)0 == 0;
							object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1702 @ rsi_v35 (System.Object)+10]");
							Transform.get_rotation_Injected((IntPtr)0, out *(Quaternion*)obj16);
							bool flag25 = (object)transform5 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7]");
							_ = 0;
							bool flag26 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
							object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
							Transform.set_rotation_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Quaternion*)obj17);
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-35]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-15]");
						if (num3 <= 0 || _drownerSummoned)
						{
							return;
						}
						if (!_isPlayerBelow)
						{
							Action onComplete = delegate
							{
								_isPlayerBelow = false;
								SummonDrowner();
							};
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
							int repeat = default(int);
							TimerType type = default(TimerType);
							VampireSurvivors.Framework.TimerSystem.Timer summonDelayTimer = Timers.Register(6.0000005f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							_summonDelayTimer = summonDelayTimer;
						}
						_isPlayerBelow = true;
						return;
					}
				}
			}
		}
		goto IL_0560;
		IL_0560:
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (_summonDelayTimer != null)
		{
			_summonDelayTimer.Cancel();
		}
		if (_drownerWarningTimer1 != null)
		{
			_drownerWarningTimer1.Cancel();
		}
		if (_drownerWarningTimer2 != null)
		{
			_drownerWarningTimer2.Cancel();
		}
		if (_drownerWarningTimer3 != null)
		{
			_drownerWarningTimer3.Cancel();
		}
		if (_drownerSummoned)
		{
			EnemyDrowner drowner = _drowner;
			if ((object)_drowner != null && ((UnityEngine.Object)drowner).m_CachedPtr != (IntPtr)0)
			{
				_drowner.Dismiss();
			}
		}
		if (_leftEvent != null)
		{
			_leftEvent.Cancel();
		}
		if (_rightEvent != null)
		{
			_rightEvent.Cancel();
		}
		EnemyPincer leftPincer = _leftPincer;
		if ((object)_leftPincer != null && ((UnityEngine.Object)leftPincer).m_CachedPtr != (IntPtr)0)
		{
			_leftPincer.Disappear();
		}
		EnemyPincer rightPincer = _rightPincer;
		if ((object)_rightPincer != null && ((UnityEngine.Object)rightPincer).m_CachedPtr != (IntPtr)0)
		{
			_rightPincer.Disappear();
		}
		base.Despawn();
	}

	public override bool CanEnemyTeleport()
	{
		//IL_0088: Invalid comparison between F4 and O
		//IL_00b6: Invalid comparison between F4 and O
		//IL_00ea: Invalid comparison between O and F4
		//IL_0108: Invalid comparison between F4 and I4
		//IL_01d2: Expected O, but got I
		//IL_0347: Expected O, but got I
		//IL_021d: Invalid comparison between F4 and O
		//IL_024b: Invalid comparison between F4 and O
		//IL_027f: Invalid comparison between O and F4
		//IL_029d: Invalid comparison between F4 and I4
		//IL_03a0: Invalid comparison between F4 and O
		//IL_03ce: Invalid comparison between F4 and O
		//IL_01bd->IL049b: Incompatible stack heights: 1 vs 0
		//IL_01f2->IL049b: Incompatible stack heights: 1 vs 0
		//IL_0332->IL049b: Incompatible stack heights: 1 vs 0
		//IL_0367->IL049b: Incompatible stack heights: 1 vs 0
		//IL_0384->IL0590: Incompatible stack heights: 2 vs 1
		//IL_048d->IL0656: Incompatible stack heights: 2 vs 1
		//IL_02d4->IL0590: Incompatible stack heights: 2 vs 1
		//IL_0444->IL0656: Incompatible stack heights: 2 vs 1
		GameManager core = GM.Core;
		Rect enemiesDespawnRect;
		object obj2 = default(object);
		bool flag7;
		bool flag8;
		if ((object)GM.Core != null && (object)core._stage != null)
		{
			enemiesDespawnRect = core._stage.EnemiesDespawnRect;
			object enemyRenderer = _EnemyRenderer;
			if ((object)_EnemyRenderer != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rbx_v8 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rbx_v8 (System.Object)+10]");
				Renderer.get_bounds_Injected((IntPtr)0, out Bounds ret);
				object obj = default(object);
				float num = (float)obj * 2f;
				float num2 = 0f * 2f;
				float num3 = (float)ret + num;
				if (num3 > enemiesDespawnRect.m_XMin)
				{
					float num4 = (float)obj2 + enemiesDespawnRect.m_XMin;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) > System.Runtime.CompilerServices.Unsafe.As<Bounds, UIntPtr>(ref ret))
					{
						float num6 = default(float);
						float num5 = num6 + num2;
						bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
						num = num6;
						if (!flag2)
						{
							object obj3 = obj2 + obj2;
							bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6);
							float num7 = (float)obj3 - num6;
							bool flag4 = num7 == 0f;
							bool flag5 = !flag3;
							bool flag6 = !flag4;
							flag7 = flag6 & flag5;
							flag8 = false;
							num = num6;
							goto IL_0553;
						}
					}
				}
				flag7 = false;
				flag8 = false;
				goto IL_0553;
			}
		}
		goto IL_049b;
		IL_0590:
		EnemyPincer rightPincer = _rightPincer;
		bool flag9 = (object)_rightPincer == null;
		bool flag10 = false;
		if (!flag9)
		{
			bool flag11 = ((UnityEngine.Object)rightPincer).m_CachedPtr == (IntPtr)0;
			flag10 = false;
			if (!flag11)
			{
				object rightPincer2 = _rightPincer;
				if ((object)_rightPincer != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rbx_v16 (System.Object)+68]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rbx_v16 (System.Object)+68]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rbx_v17 (System.Object)+10]");
						bool flag12 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rbx_v17 (System.Object)+10]");
						Renderer.get_bounds_Injected((IntPtr)0, out Bounds ret2);
						object obj5 = default(object);
						float num8 = (float)obj5 * 2f;
						float num9 = 0f * 2f;
						float num10 = (float)ret2 + num8;
						if (num10 > enemiesDespawnRect.m_XMin)
						{
							float num11 = (float)obj2 + enemiesDespawnRect.m_XMin;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num11) > System.Runtime.CompilerServices.Unsafe.As<Bounds, UIntPtr>(ref ret2))
							{
								object obj6 = default(object);
								float num12 = (float)obj6 + num9;
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num12) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
								{
									object obj7 = obj2 + obj2;
									bool flag13 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6);
									object obj8 = obj7 - obj6;
									bool flag14 = obj8 == null;
									bool flag15 = !flag13;
									bool flag16 = !flag14;
									flag10 = flag16 & flag15;
									goto IL_0656;
								}
							}
						}
						flag10 = flag8;
						goto IL_0656;
					}
				}
				goto IL_049b;
			}
		}
		goto IL_0656;
		IL_0553:
		EnemyPincer leftPincer = _leftPincer;
		bool flag17 = (object)_leftPincer == null;
		bool flag18 = false;
		if (!flag17)
		{
			bool flag19 = ((UnityEngine.Object)leftPincer).m_CachedPtr == (IntPtr)0;
			flag18 = false;
			if (!flag19)
			{
				object leftPincer2 = _leftPincer;
				if ((object)_leftPincer != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rbx_v21 (System.Object)+68]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rbx_v21 (System.Object)+68]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rbx_v22 (System.Object)+10]");
						bool flag20 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rbx_v22 (System.Object)+10]");
						Renderer.get_bounds_Injected((IntPtr)0, out Bounds ret3);
						object obj10 = default(object);
						float num = (float)obj10 * 2f;
						float num2 = 0f * 2f;
						float num13 = (float)ret3 + num;
						if (num13 > enemiesDespawnRect.m_XMin)
						{
							float num14 = (float)obj2 + enemiesDespawnRect.m_XMin;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num14) > System.Runtime.CompilerServices.Unsafe.As<Bounds, UIntPtr>(ref ret3))
							{
								float num16 = default(float);
								float num15 = num16 + num2;
								bool flag21 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num15) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
								num = num16;
								if (!flag21)
								{
									object obj11 = obj2 + obj2;
									bool flag22 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num16);
									float num17 = (float)obj11 - num16;
									bool flag23 = num17 == 0f;
									bool flag24 = !flag22;
									bool flag25 = !flag23;
									flag18 = flag25 & flag24;
									num = num16;
									goto IL_0590;
								}
							}
						}
						flag18 = flag8;
						goto IL_0590;
					}
				}
				goto IL_049b;
			}
		}
		goto IL_0590;
		IL_0656:
		bool result;
		if (!flag7)
		{
			bool flag26 = (byte)((flag10 ? 1u : 0u) ^ 1u) != 0;
			bool flag27 = !flag18;
			result = flag26;
			if (!flag27)
			{
				result = flag8;
			}
		}
		else
		{
			result = false;
		}
		return result;
		IL_049b:
		throw new NullReferenceException();
	}

	private UniTaskVoid SpawnPincers()
	{
		//IL_001a: Expected O, but got I4
		_003CSpawnPincers_003Ed__28 obj = default(_003CSpawnPincers_003Ed__28);
		obj.MoveNext();
		return (UniTaskVoid)0;
	}

	private void SpawnLeftPincer()
	{
		//IL_00a8: Expected O, but got I
		//IL_021d: Expected I, but got O
		//IL_032e->IL02aa: Incompatible stack heights: 1 vs 0
		//IL_0119->IL02aa: Incompatible stack heights: 1 vs 0
		//IL_0154->IL02aa: Incompatible stack heights: 1 vs 0
		//IL_018d->IL02aa: Incompatible stack heights: 1 vs 0
		//IL_01c5->IL02aa: Incompatible stack heights: 1 vs 0
		//IL_01fd->IL02aa: Incompatible stack heights: 1 vs 0
		//IL_034c->IL0297: Incompatible stack heights: 2 vs 1
		EnemyPincer leftPincer = _leftPincer;
		if ((object)_leftPincer == null || ((UnityEngine.Object)leftPincer).m_CachedPtr == (IntPtr)0)
		{
			goto IL_00ad;
		}
		Component leftPincer2 = _leftPincer;
		if ((object)_leftPincer != null)
		{
			GameObject obj = _leftPincer.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rcx_v41 (UnityEngine.Component)+58]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rcx_v41 (UnityEngine.Component)+58]");
				((ObjectPool)0).Release(obj);
				goto IL_00ad;
			}
		}
		goto IL_02aa;
		IL_00ad:
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			if ((object)_stage != null)
			{
				Vector2 spawnPos = default(Vector2);
				bool forceSpawn = default(bool);
				GameObject gameObject = _stage.SpawnEnemy(EnemyType.BOSS_XLPINCER, spawnPos, asRemote: false, forceSpawn);
				if ((object)gameObject != null)
				{
					EnemyPincer component = gameObject.GetComponent<EnemyPincer>();
					_leftPincer = component;
					if ((object)_leftPincer != null)
					{
						_leftPincer.SetFlipX(flip: false);
						GameObject owner = base.gameObject;
						if ((object)_leftPincer != null)
						{
							_leftPincer.SetOwner(owner);
							EnemyPincer leftPincer3 = _leftPincer;
							if ((object)_leftPincer != null)
							{
								leftPincer3._003COnDead_003Ek__BackingField = null;
								EnemyPincer leftPincer4 = _leftPincer;
								if ((object)_leftPincer != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v722 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyCrab>)+4B0]");
									Action b = new Action(this, (IntPtr)0);
									nint num = (nint)this;
									Delegate obj2 = Delegate.Combine(leftPincer4._003COnDead_003Ek__BackingField, b);
									bool flag2 = (object)obj2 == null;
									Delegate obj3 = null;
									if (!flag2)
									{
										bool flag3 = (object)obj2.GetType() != typeof(Action);
										obj3 = null;
										if (!flag3)
										{
											obj3 = obj2;
										}
										bool flag4 = (object)obj3 == null;
									}
									leftPincer4._003COnDead_003Ek__BackingField = (Action)obj3;
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_02aa;
		IL_02aa:
		throw new NullReferenceException();
	}

	private void SpawnRightPincer()
	{
		//IL_00a8: Expected O, but got I
		//IL_021d: Expected I, but got O
		//IL_032e->IL02aa: Incompatible stack heights: 1 vs 0
		//IL_0119->IL02aa: Incompatible stack heights: 1 vs 0
		//IL_0154->IL02aa: Incompatible stack heights: 1 vs 0
		//IL_018d->IL02aa: Incompatible stack heights: 1 vs 0
		//IL_01c5->IL02aa: Incompatible stack heights: 1 vs 0
		//IL_01fd->IL02aa: Incompatible stack heights: 1 vs 0
		//IL_034c->IL0297: Incompatible stack heights: 2 vs 1
		EnemyPincer rightPincer = _rightPincer;
		if ((object)_rightPincer == null || ((UnityEngine.Object)rightPincer).m_CachedPtr == (IntPtr)0)
		{
			goto IL_00ad;
		}
		Component rightPincer2 = _rightPincer;
		if ((object)_rightPincer != null)
		{
			GameObject obj = _rightPincer.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rcx_v41 (UnityEngine.Component)+58]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rcx_v41 (UnityEngine.Component)+58]");
				((ObjectPool)0).Release(obj);
				goto IL_00ad;
			}
		}
		goto IL_02aa;
		IL_00ad:
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			if ((object)_stage != null)
			{
				Vector2 spawnPos = default(Vector2);
				bool forceSpawn = default(bool);
				GameObject gameObject = _stage.SpawnEnemy(EnemyType.BOSS_XLPINCER, spawnPos, asRemote: false, forceSpawn);
				if ((object)gameObject != null)
				{
					EnemyPincer component = gameObject.GetComponent<EnemyPincer>();
					_rightPincer = component;
					if ((object)_rightPincer != null)
					{
						_rightPincer.SetFlipX(flip: true);
						GameObject owner = base.gameObject;
						if ((object)_rightPincer != null)
						{
							_rightPincer.SetOwner(owner);
							EnemyPincer rightPincer3 = _rightPincer;
							if ((object)_rightPincer != null)
							{
								rightPincer3._003COnDead_003Ek__BackingField = null;
								EnemyPincer rightPincer4 = _rightPincer;
								if ((object)_rightPincer != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v722 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyCrab>)+4C0]");
									Action b = new Action(this, (IntPtr)0);
									nint num = (nint)this;
									Delegate obj2 = Delegate.Combine(rightPincer4._003COnDead_003Ek__BackingField, b);
									bool flag2 = (object)obj2 == null;
									Delegate obj3 = null;
									if (!flag2)
									{
										bool flag3 = (object)obj2.GetType() != typeof(Action);
										obj3 = null;
										if (!flag3)
										{
											obj3 = obj2;
										}
										bool flag4 = (object)obj3 == null;
									}
									rightPincer4._003COnDead_003Ek__BackingField = (Action)obj3;
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_02aa;
		IL_02aa:
		throw new NullReferenceException();
	}

	protected virtual void RegrowLeftPincer()
	{
		_leftPincer = null;
		Action onComplete = delegate
		{
			EnemyPincer leftPincer = _leftPincer;
			if ((object)_leftPincer != null && ((UnityEngine.Object)leftPincer).m_CachedPtr != (IntPtr)0)
			{
				EnemyPincer leftPincer2 = _leftPincer;
				if (!((EnemyController)leftPincer2)._003CIsDead_003Ek__BackingField)
				{
					return;
				}
			}
			SpawnLeftPincer();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		VampireSurvivors.Framework.TimerSystem.Timer leftEvent = Timers.Register(1.5000001f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_leftEvent = leftEvent;
		object cachedTransform = _cachedTransform;
		Transform cachedTransform2 = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
		Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out Vector3 ret);
		float num = (float)ret * 1.1f;
		if (!(num > 5f))
		{
		}
		bool flag2 = (object)_cachedTransform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rsi_v2 (System.Object)+10]");
		bool flag3 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rsi_v2 (System.Object)+10]");
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected((IntPtr)0, ref value);
	}

	protected virtual void RegrowRightPincer()
	{
		_rightPincer = null;
		Action onComplete = delegate
		{
			EnemyPincer rightPincer = _rightPincer;
			if ((object)_rightPincer != null && ((UnityEngine.Object)rightPincer).m_CachedPtr != (IntPtr)0)
			{
				EnemyPincer rightPincer2 = _rightPincer;
				if (!((EnemyController)rightPincer2)._003CIsDead_003Ek__BackingField)
				{
					return;
				}
			}
			SpawnRightPincer();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		VampireSurvivors.Framework.TimerSystem.Timer rightEvent = Timers.Register(1.5000001f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_rightEvent = rightEvent;
		object cachedTransform = _cachedTransform;
		Transform cachedTransform2 = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
		Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out Vector3 ret);
		float num = (float)ret * 1.1f;
		if (!(num > 4f))
		{
		}
		bool flag2 = (object)_cachedTransform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rsi_v2 (System.Object)+10]");
		bool flag3 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rsi_v2 (System.Object)+10]");
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected((IntPtr)0, ref value);
	}

	protected virtual void SummonDrowner()
	{
		//IL_0122->IL00c7: Incompatible stack heights: 1 vs 0
		GameSessionData gameSessionData = _gameSessionData;
		if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
		{
			Transform transform = gameSessionData._activeCharacter.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Transform cachedTransform = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
					object obj = default(object);
					object obj2 = default(object);
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) && !_drownerSummoned)
					{
						_drownerSummoned = true;
						DrownerWarning();
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void DismissDrowner()
	{
		if (_drownerSummoned)
		{
			EnemyDrowner drowner = _drowner;
			if ((object)_drowner != null && ((UnityEngine.Object)drowner).m_CachedPtr != (IntPtr)0)
			{
				_drowner.Dismiss();
			}
		}
	}

	private void DrownerWarning()
	{
		_003C_003Ec__DisplayClass35_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass35_0();
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		RedWarning();
		Camera main = Camera.main;
		CS_0024_003C_003E8__locals8.camBounds = (Bounds)CameraExtensions.OrthographicBounds(main).m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rax_v8 (UnityEngine.Bounds)+10]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (VampireSurvivors.Objects.Characters.Enemies.EnemyCrab+<>c__DisplayClass35_0)+24]");
		float num = 0f * 2f;
		float sizeX = num * 0.25f;
		SingleWarning(sizeX);
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyCrab+<>c__DisplayClass35_0)+24]");
			float num2 = 0f * 2f;
			float sizeX2 = num2 * 0.5f;
			CS_0024_003C_003E8__locals8._003C_003E4__this.SingleWarning(sizeX2);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		VampireSurvivors.Framework.TimerSystem.Timer drownerWarningTimer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_drownerWarningTimer1 = drownerWarningTimer;
		Action onComplete2 = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyCrab+<>c__DisplayClass35_0)+24]");
			float num2 = 0f * 2f;
			float sizeX2 = num2 * 0.75f;
			CS_0024_003C_003E8__locals8._003C_003E4__this.SingleWarning(sizeX2);
		};
		VampireSurvivors.Framework.TimerSystem.Timer drownerWarningTimer2 = Timers.Register(0.4f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_drownerWarningTimer2 = drownerWarningTimer2;
		Action onComplete3 = delegate
		{
			//IL_00d7: Expected O, but got I
			//IL_0194->IL0110: Incompatible stack heights: 1 vs 0
			//IL_00af->IL0110: Incompatible stack heights: 1 vs 0
			//IL_00f3->IL0110: Incompatible stack heights: 1 vs 0
			EnemyCrab enemyCrab = CS_0024_003C_003E8__locals8._003C_003E4__this;
			if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
			{
				GameSessionData gameSessionData = enemyCrab._gameSessionData;
				if (enemyCrab._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					Transform transform = gameSessionData._activeCharacter.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						Transform transform2 = (Transform)(object)CS_0024_003C_003E8__locals8._003C_003E4__this;
						if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v5 (UnityEngine.Transform)+280]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v5 (UnityEngine.Transform)+280]");
								Vector2 spawnPos = default(Vector2);
								bool forceSpawn = default(bool);
								GameObject gameObject = ((Stage)0).SpawnEnemy(EnemyType.BOSS_XLDROWNER, spawnPos, asRemote: false, forceSpawn);
								if ((object)gameObject != null)
								{
									EnemyDrowner component = gameObject.GetComponent<EnemyDrowner>();
									return;
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		};
		VampireSurvivors.Framework.TimerSystem.Timer drownerWarningTimer3 = Timers.Register(0.1f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_drownerWarningTimer3 = drownerWarningTimer3;
	}

	private unsafe void RedWarning()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0437: Expected O, but got Ref
		//IL_0487: Expected O, but got F4
		//IL_066b: Expected O, but got I4
		//IL_0495: Expected O, but got I4
		//IL_04d8: Expected O, but got Ref
		//IL_0534: Expected O, but got Ref
		//IL_0559: Expected O, but got Ref
		//IL_0581: Expected O, but got Ref
		//IL_05a6: Expected O, but got Ref
		//IL_05dd: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass36_0 CS_0024_003C_003E8__locals26 = new _003C_003Ec__DisplayClass36_0();
		GameObject redWarningObject = UnityEngine.Object.Instantiate(_RedWarningPrefab);
		TweenerCore<Color, Color, ColorOptions> tweenerCore;
		if (CS_0024_003C_003E8__locals26 != null)
		{
			CS_0024_003C_003E8__locals26.redWarningObject = redWarningObject;
			if ((object)CS_0024_003C_003E8__locals26.redWarningObject != null)
			{
				Transform transform = CS_0024_003C_003E8__locals26.redWarningObject.transform;
				if ((object)CS_0024_003C_003E8__locals26.redWarningObject != null)
				{
					SpriteRenderer componentInChildren = CS_0024_003C_003E8__locals26.redWarningObject.GetComponentInChildren<SpriteRenderer>(includeInactive: false);
					CS_0024_003C_003E8__locals26.redWarning = componentInChildren;
					SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(CS_0024_003C_003E8__locals26.redWarning, 0.25f);
					GameObject redWarning = (GameObject)(object)CS_0024_003C_003E8__locals26.redWarning;
					if ((object)CS_0024_003C_003E8__locals26.redWarning != null)
					{
						if (((UnityEngine.Object)redWarning).m_CachedPtr != (IntPtr)0)
						{
							Renderer.set_sortingOrder_Injected(((UnityEngine.Object)redWarning).m_CachedPtr, 9000);
							Vector2 newPivot = default(Vector2);
							Sprite sprite = SpriteManager.GetSprite("WhiteLine", newPivot, "vfx");
							if ((object)CS_0024_003C_003E8__locals26.redWarning != null)
							{
								CS_0024_003C_003E8__locals26.redWarning.sprite = sprite;
								Camera main = Camera.main;
								Bounds bounds = CameraExtensions.OrthographicBounds(main);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v795 @ rax_v79 (UnityEngine.Bounds)+10]");
								_ = 0;
								_ = 0;
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
								Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj3);
								Camera main2 = Camera.main;
								Transform parent = main2.transform;
								transform.SetParent(parent, worldPositionStays: true);
								Camera main3 = Camera.main;
								bool flag2 = ((UnityEngine.Object)main3).m_CachedPtr == (IntPtr)0;
								object obj4 = Camera.get_orthographicSize_Injected(((UnityEngine.Object)main3).m_CachedPtr);
								GameObject gameObject = (GameObject)Screen.height;
								object obj5 = Screen.width;
								Transform transform2 = CS_0024_003C_003E8__locals26.redWarning.transform;
								Sprite sprite2 = CS_0024_003C_003E8__locals26.redWarning.sprite;
								_ = 0;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rax_v99 (UnityEngine.Sprite)+10]");
								bool flag3 = (nint)0 == 0;
								object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rax_v99 (UnityEngine.Sprite)+10]");
								Sprite.get_bounds_Injected((IntPtr)0, out *(Bounds*)obj6);
								bool flag4 = (object)transform2 == null;
								_ = 1f;
								bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj7);
								_ = 0;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rax_v99 (UnityEngine.Sprite)+10]");
								bool flag6 = (nint)0 == 0;
								object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rax_v99 (UnityEngine.Sprite)+10]");
								Sprite.get_bounds_Injected((IntPtr)0, out *(Bounds*)obj8);
								_ = 0;
								_ = 0;
								bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
								Transform.get_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj9);
								_ = 0;
								_ = 0;
								bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								Transform.get_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj10);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-21]");
								_ = 0;
								bool flag9 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj11);
								tweenerCore = DOTweenModuleSprite.DOFade(CS_0024_003C_003E8__locals26.redWarning, 0.5f, 0.2f);
								TweenCallback tweenCallback2;
								if (tweenerCore != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2110 @ rax_v128 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2110 @ rax_v128 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
										if ((nint)0 == 0)
										{
											_ = 6;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2110 @ rax_v128 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2110 @ rax_v128 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
												float num = 0f * 6f;
											}
											TweenCallback tweenCallback = delegate
											{
												TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(CS_0024_003C_003E8__locals26.redWarning, 0f, 0.1f);
												TweenCallback tweenCallback4 = CS_0024_003C_003E8__locals26._003C_003E9__1;
												if (CS_0024_003C_003E8__locals26._003C_003E9__1 == null)
												{
													tweenCallback4 = (CS_0024_003C_003E8__locals26._003C_003E9__1 = delegate
													{
														UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals26.redWarningObject, 0f);
													});
												}
												if (tweenerCore2 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
													if ((nint)0 == 0)
													{
													}
												}
											};
											tweenCallback2 = tweenCallback;
											goto IL_033a;
										}
									}
								}
								TweenCallback tweenCallback3 = delegate
								{
									TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(CS_0024_003C_003E8__locals26.redWarning, 0f, 0.1f);
									TweenCallback tweenCallback4 = CS_0024_003C_003E8__locals26._003C_003E9__1;
									if (CS_0024_003C_003E8__locals26._003C_003E9__1 == null)
									{
										tweenCallback4 = (CS_0024_003C_003E8__locals26._003C_003E9__1 = delegate
										{
											UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals26.redWarningObject, 0f);
										});
									}
									if (tweenerCore2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
										if ((nint)0 == 0)
										{
										}
									}
								};
								bool flag10 = tweenerCore == null;
								tweenCallback2 = tweenCallback3;
								if (!flag10)
								{
									goto IL_033a;
								}
								goto IL_0369;
							}
						}
						else
						{
							UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(CS_0024_003C_003E8__locals26.redWarning);
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0369:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag11 = tweenerCore == null;
		return;
		IL_033a:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2110 @ rax_v128 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_0369;
	}

	private unsafe void SingleWarning(float sizeX)
	{
		//IL_0373: Expected O, but got Ref
		//IL_0256: Expected O, but got I4
		//IL_03b6: Expected O, but got F4
		//IL_03a8->IL028a: Incompatible stack heights: 5 vs 0
		_003C_003Ec__DisplayClass37_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass37_0();
		GameObject singleWarningObject = UnityEngine.Object.Instantiate(_SingleWarningPrefab);
		if (CS_0024_003C_003E8__locals14 != null)
		{
			CS_0024_003C_003E8__locals14.singleWarningObject = singleWarningObject;
			if ((object)CS_0024_003C_003E8__locals14.singleWarningObject != null)
			{
				Transform transform = CS_0024_003C_003E8__locals14.singleWarningObject.transform;
				if ((object)CS_0024_003C_003E8__locals14.singleWarningObject != null)
				{
					GameObject componentInChildren = (GameObject)(object)CS_0024_003C_003E8__locals14.singleWarningObject.GetComponentInChildren<SpriteRenderer>(includeInactive: false);
					if ((object)componentInChildren != null)
					{
						Transform singleWarningTransform = ((Component)(object)componentInChildren).transform;
						CS_0024_003C_003E8__locals14.singleWarningTransform = singleWarningTransform;
						TweenCallback singleWarningTransform2 = (TweenCallback)(object)CS_0024_003C_003E8__locals14.singleWarningTransform;
						bool flag = ((Delegate)singleWarningTransform2).method_ptr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected(((Delegate)singleWarningTransform2).method_ptr, ref value);
						bool flag2 = ((UnityEngine.Object)componentInChildren).m_CachedPtr == (IntPtr)0;
						Renderer.set_sortingOrder_Injected(((UnityEngine.Object)componentInChildren).m_CachedPtr, 9000);
						Vector2 newPivot = default(Vector2);
						Sprite sprite = SpriteManager.GetSprite("ExclamationMark", newPivot, "UI");
						((SpriteRenderer)(object)componentInChildren).sprite = sprite;
						Camera main = Camera.main;
						Bounds bounds = CameraExtensions.OrthographicBounds(main);
						bool flag3 = (object)transform == null;
						bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector2 value2 = default(Vector2);
						Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value2));
						Camera main2 = Camera.main;
						bool flag5 = (object)main2 == null;
						Transform parent = main2.transform;
						transform.SetParent(parent, worldPositionStays: true);
						object obj = default(object);
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(CS_0024_003C_003E8__locals14.singleWarningTransform, (Vector3)(&obj), 0.2f);
						TweenCallback tweenCallback = delegate
						{
							//IL_0098: Expected O, but got Ref
							object obj3 = default(object);
							TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(CS_0024_003C_003E8__locals14.singleWarningTransform, (Vector3)(&obj3), 0.2f);
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t, 0.2f);
							TweenCallback tweenCallback2 = CS_0024_003C_003E8__locals14._003C_003E9__1;
							if (CS_0024_003C_003E8__locals14._003C_003E9__1 == null)
							{
								tweenCallback2 = (CS_0024_003C_003E8__locals14._003C_003E9__1 = delegate
								{
									UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals14.singleWarningObject, 0f);
								});
							}
							if (tweenerCore2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 == 0)
								{
								}
							}
						};
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1240 @ rax_v65 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 == 0)
							{
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if (tweenerCore != null)
						{
							SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
							soundConfig.Volume = (float?)(object)1;
							soundConfig.Rate = 1f;
							object obj2 = UnityEngine.Random.value;
							float detune = (float)Vector3.oneVector * 500f;
							soundConfig.Rate = 1f;
							soundConfig.Detune = detune;
							float time = default(float);
							PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Pizza, soundConfig, 150f, 2, time);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public EnemyCrab()
	{
		//IL_0026: Expected O, but got I8
		//IL_0037: Expected O, but got I4
		_freshlySpawned = true;
		_leftOffset = (Vector2)3196730737L;
		_ = 1049582633;
		_rightOffset = (Vector2)1049247089;
		_ = 1049582633;
		base._002Ector();
	}

	private void _003COnUpdate_003Eb__25_0()
	{
		_isPlayerBelow = false;
		SummonDrowner();
	}

	private void _003CRegrowLeftPincer_003Eb__31_0()
	{
		EnemyPincer leftPincer = _leftPincer;
		if ((object)_leftPincer != null && ((UnityEngine.Object)leftPincer).m_CachedPtr != (IntPtr)0)
		{
			EnemyPincer leftPincer2 = _leftPincer;
			if (!((EnemyController)leftPincer2)._003CIsDead_003Ek__BackingField)
			{
				return;
			}
		}
		SpawnLeftPincer();
	}

	private void _003CRegrowRightPincer_003Eb__32_0()
	{
		EnemyPincer rightPincer = _rightPincer;
		if ((object)_rightPincer != null && ((UnityEngine.Object)rightPincer).m_CachedPtr != (IntPtr)0)
		{
			EnemyPincer rightPincer2 = _rightPincer;
			if (!((EnemyController)rightPincer2)._003CIsDead_003Ek__BackingField)
			{
				return;
			}
		}
		SpawnRightPincer();
	}
}
