using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class EME_RibbonController : MonoBehaviour
{
	private enum RibbonState
	{
		TravelingToNewTarget,
		ReachedTarget,
		FadingOnTargetChanged,
		Disabled
	}

	private EME_Ribbon _ribbon;

	private float _travelToNewTargetDuration;

	private float _fadeTimeOnTargetChanged;

	private RibbonState _currentState;

	private float _timeInCurrentState;

	private float _toTargetPercent;

	private Vector3 _targetPosition;

	private Vector3 _nextTargetPosition;

	private Camera _mainCamera;

	public bool RibbonDisabled
	{
		get
		{
			//IL_0010: Expected O, but got I4
			object obj = _currentState - 3;
			return obj == null;
		}
	}

	private void Awake()
	{
		Camera main = Camera.main;
		_mainCamera = main;
	}

	public void DisableRibbon()
	{
		//IL_0034: Expected O, but got I4
		_currentState = RibbonState.Disabled;
		GameObject gameObject = _ribbon.gameObject;
		object obj = _currentState - 3;
		bool flag = obj == null;
		bool active = !flag;
		gameObject.SetActive(active);
	}

	public unsafe void UpdateRibbon(Vector3 playerPosition)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_01e4: Invalid comparison between I4 and F4
		//IL_022f: Expected F4, but got I4
		//IL_0032: Expected O, but got I4
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_023d: Invalid comparison between I4 and F4
		//IL_00c9: Invalid comparison between I4 and F4
		//IL_0288: Expected F4, but got I4
		//IL_0114: Expected F4, but got I4
		//IL_0688: Unknown result type (might be due to invalid IL or missing references)
		//IL_068d: Expected O, but got Unknown
		//IL_0122: Invalid comparison between I4 and F4
		//IL_03b0: Expected O, but got I
		//IL_016d: Expected F4, but got I4
		//IL_06b5: Expected I, but got O
		//IL_077f: Expected O, but got I
		//IL_079c: Expected O, but got I
		//IL_07c6: Expected O, but got I
		//IL_07e5: Invalid comparison between F4 and O
		//IL_040f: Expected O, but got I
		//IL_042c: Expected O, but got I
		//IL_048f: Expected O, but got F4
		//IL_0802: Unknown result type (might be due to invalid IL or missing references)
		//IL_0807: Expected O, but got Unknown
		//IL_0810: Unknown result type (might be due to invalid IL or missing references)
		//IL_0815: Expected O, but got Unknown
		//IL_0826: Expected O, but got I4
		//IL_030c: Expected O, but got I4
		//IL_06e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ed: Expected O, but got Unknown
		//IL_06f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fb: Expected O, but got Unknown
		//IL_0704: Unknown result type (might be due to invalid IL or missing references)
		//IL_0709: Expected O, but got Unknown
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_0536: Expected O, but got Unknown
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e2: Expected O, but got Unknown
		//IL_074b->IL0549: Incompatible stack heights: 1 vs 0
		//IL_04cf->IL0549: Incompatible stack heights: 1 vs 0
		//IL_0762->IL04fc: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = obj2 - 95;
		_ = 0;
		_ = 0;
		bool flag = _currentState == RibbonState.TravelingToNewTarget;
		if (!flag)
		{
			object obj3 = _currentState - 1;
			if (!flag)
			{
				object obj4 = obj3 - 1;
				if (!flag)
				{
					if ((nint)obj4 == 1)
					{
						return;
					}
					ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
					throw ex;
				}
				float deltaTime = PauseSystem.DeltaTime;
				EME_Ribbon ribbon = _ribbon;
				float num = (_timeInCurrentState = deltaTime + _timeInCurrentState) / _fadeTimeOnTargetChanged;
				if (!(0f > num))
				{
					if (num > 1f)
					{
						num = 1f;
					}
				}
				else
				{
					num = 0f;
				}
				if ((object)_ribbon == null)
				{
					goto IL_0549;
				}
				if (!(0f > num))
				{
					if (num > 1f)
					{
						num = 1f;
					}
				}
				else
				{
					num = 0f;
				}
				ribbon.FadeIn = num;
				if (_timeInCurrentState > _fadeTimeOnTargetChanged)
				{
					_targetPosition = _nextTargetPosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.EME_RibbonController)+50]");
					_ = 0;
					_currentState = RibbonState.TravelingToNewTarget;
					goto IL_05ea;
				}
			}
			goto IL_0338;
		}
		float deltaTime2 = PauseSystem.DeltaTime;
		EME_Ribbon ribbon2 = _ribbon;
		float num2 = (_timeInCurrentState = deltaTime2 + _timeInCurrentState) / _travelToNewTargetDuration;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		if ((object)_ribbon != null)
		{
			if (!(0f > num2))
			{
				if (num2 > 1f)
				{
					num2 = 1f;
				}
			}
			else
			{
				num2 = 0f;
			}
			ribbon2.FadeOut = num2;
			EME_Ribbon ribbon3 = _ribbon;
			if ((object)_ribbon != null)
			{
				ribbon3.FadeIn = 0f;
				if (!(_timeInCurrentState > _travelToNewTargetDuration))
				{
					goto IL_0338;
				}
				_currentState = RibbonState.ReachedTarget;
				goto IL_05ea;
			}
		}
		goto IL_0549;
		IL_05ea:
		if ((object)_ribbon != null)
		{
			GameObject gameObject = _ribbon.gameObject;
			if ((object)gameObject != null)
			{
				object obj5 = _currentState - 3;
				bool flag2 = obj5 == null;
				bool active = !flag2;
				gameObject.SetActive(active);
				goto IL_0338;
			}
		}
		goto IL_0549;
		IL_0549:
		throw new NullReferenceException();
		IL_0338:
		EME_Ribbon ribbon4 = _ribbon;
		if ((object)_ribbon != null)
		{
			object childTransform = ribbon4.ChildTransform;
			_ = playerPosition.x;
			_ = playerPosition.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdi_v11 (System.Object)+10]");
			bool flag3 = (nint)0 == 0;
			object obj6 = obj - 105;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdi_v11 (System.Object)+10]");
			Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj6);
			Bounds bounds = CameraExtensions.OrthographicBoundsIgnoringBorders(_mainCamera);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.EME_RibbonController)+44]");
			EME_Ribbon eME_Ribbon = (EME_Ribbon)0;
			_ = _targetPosition;
			_ = bounds.m_Center;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ rax_v36 (UnityEngine.Bounds)+10]");
			_ = 0;
			nint num3 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ rax_v38 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num4 = 0;
			_ = Vector3.forwardVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-65]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-65]");
			object obj7 = num5 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-69]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-69]");
			object obj8 = num6 * 0;
			object obj9 = obj7 + obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v924 @ rcx_v33 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v924 @ rcx_v33 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
			object obj10 = num7 * 0;
			float epsilon = Mathf.Epsilon;
			object obj11 = obj9 + obj10;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
				float num8 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-69]");
				epsilon = num8 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-55]");
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-65]");
				object obj12 = num9 * 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.EME_RibbonController)+44]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v924 @ rcx_v33 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
				object obj13 = num10 * 0;
				float num11 = (float)obj12 + epsilon;
				float num12 = num11 + (float)obj13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v924 @ rcx_v33 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
				float num13 = 0f * num12;
				float num14 = num13 / (float)obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.EME_RibbonController)+44]");
				float num15 = 0f - num14;
				eME_Ribbon = (EME_Ribbon)num15;
				Vector3 vector2 = default(Vector3);
				Vector3 vector = vector2;
			}
			else
			{
				Vector3 vector = _targetPosition;
			}
			object obj14 = obj - 89;
			object obj15 = obj - 41;
			object obj16 = Bounds.Contains_Injected(ref *(Bounds*)obj15, ref *(Vector3*)obj14);
			EME_Ribbon ribbon5;
			Vector3 endPosition;
			if (obj16 != null)
			{
				ribbon5 = _ribbon;
				if ((object)_ribbon == null)
				{
					goto IL_0549;
				}
				endPosition = (Vector3)(obj - 89);
				_ = _targetPosition;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.EME_RibbonController)+44]");
				_ = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.EME_RibbonController)+44]");
				_ = 0;
				_ = 0;
				_ = 0;
				_ = _targetPosition;
				object obj17 = obj - 105;
				object obj18 = obj - 73;
				object obj19 = obj - 41;
				Bounds.ClosestPoint_Injected(ref *(Bounds*)obj19, ref *(Vector3*)obj18, out *(Vector3*)obj17);
				ribbon5 = _ribbon;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-61]");
				_ = 0;
				if ((object)_ribbon == null)
				{
					goto IL_0549;
				}
				_ = 0;
				endPosition = (Vector3)(obj - 73);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-69]");
				_ = 0;
			}
			ribbon5.SetEndPosition(endPosition);
			return;
		}
		goto IL_0549;
	}

	public void SetNewTargetPosition(Vector3 newTargetPosition, bool skipFadeOut = false, bool skipFadeIn = false)
	{
		//IL_001d: Expected O, but got F4
		//IL_0060: Expected O, but got I4
		//IL_0096: Expected O, but got F4
		//IL_013a: Expected O, but got I4
		//IL_00d9: Expected O, but got I4
		if (!skipFadeOut)
		{
			_nextTargetPosition = (Vector3)newTargetPosition.x;
			_ = newTargetPosition.z;
		}
		else
		{
			_currentState = RibbonState.TravelingToNewTarget;
			GameObject gameObject = _ribbon.gameObject;
			object obj = _currentState - 3;
			bool flag = obj == null;
			bool active = !flag;
			gameObject.SetActive(active);
			_targetPosition = (Vector3)newTargetPosition.x;
			_ = newTargetPosition.z;
		}
		_timeInCurrentState = 0f;
		if (!skipFadeIn)
		{
			_currentState = RibbonState.TravelingToNewTarget;
			GameObject gameObject2 = _ribbon.gameObject;
			object obj2 = _currentState - 3;
			bool flag2 = obj2 == null;
			bool active2 = !flag2;
			gameObject2.SetActive(active2);
		}
		else
		{
			_currentState = RibbonState.ReachedTarget;
			GameObject gameObject3 = _ribbon.gameObject;
			object obj3 = _currentState - 3;
			bool flag3 = obj3 == null;
			bool active3 = !flag3;
			gameObject3.SetActive(active3);
			EME_Ribbon ribbon = _ribbon;
			ribbon.FadeOut = 1f;
			EME_Ribbon ribbon2 = _ribbon;
			ribbon2.FadeIn = 0f;
		}
	}

	private void ChangeState(RibbonState newState)
	{
		//IL_003e: Expected O, but got I4
		_currentState = newState;
		_timeInCurrentState = 0f;
		GameObject gameObject = _ribbon.gameObject;
		object obj = _currentState - 3;
		bool flag = obj == null;
		bool active = !flag;
		gameObject.SetActive(active);
	}

	public EME_RibbonController()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
