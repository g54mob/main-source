using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DRooms : BasePC2D, IPositionOverrider, ISizeOverrider
{
	private sealed class _003C_003Ec__DisplayClass49_0
	{
		public string roomID;

		internal unsafe bool _003CEnterRoom_003Eb__0(Room room)
		{
			//IL_012f: Expected I4, but got O
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected Ref, but got Unknown
			//IL_00e8: Expected I8, but got I4
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected Ref, but got Unknown
			if (room != null)
			{
				string iD = room.ID;
				string text = roomID;
				if ((object)room.ID != roomID)
				{
					if (room.ID != null && roomID != null && iD._stringLength == text._stringLength)
					{
						ref byte second = ref *(byte*)(roomID + 20);
						ulong length = (ulong)(iD._stringLength + iD._stringLength);
						return System.SpanHelpers.SequenceEqual(ref *(byte*)(room.ID + 20), ref second, length);
					}
					return false;
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass52_0
	{
		public string roomName;

		internal unsafe bool _003CRemoveRoom_003Eb__0(Room obj)
		{
			//IL_012f: Expected I4, but got O
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected Ref, but got Unknown
			//IL_00e8: Expected I8, but got I4
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected Ref, but got Unknown
			if (obj != null)
			{
				string iD = obj.ID;
				string text = roomName;
				if ((object)obj.ID != roomName)
				{
					if (obj.ID != null && roomName != null && iD._stringLength == text._stringLength)
					{
						ref byte second = ref *(byte*)(roomName + 20);
						ulong length = (ulong)(iD._stringLength + iD._stringLength);
						return System.SpanHelpers.SequenceEqual(ref *(byte*)(obj.ID + 20), ref second, length);
					}
					return false;
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass54_0
	{
		public string roomID;

		internal unsafe bool _003CGetRoom_003Eb__0(Room obj)
		{
			//IL_012f: Expected I4, but got O
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected Ref, but got Unknown
			//IL_00e8: Expected I8, but got I4
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected Ref, but got Unknown
			if (obj != null)
			{
				string iD = obj.ID;
				string text = roomID;
				if ((object)obj.ID != roomID)
				{
					if (obj.ID != null && roomID != null && iD._stringLength == text._stringLength)
					{
						ref byte second = ref *(byte*)(roomID + 20);
						ulong length = (ulong)(iD._stringLength + iD._stringLength);
						return System.SpanHelpers.SequenceEqual(ref *(byte*)(obj.ID + 20), ref second, length);
					}
					return false;
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003CTestRoomRoutine_003Ed__56(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DRooms _003C_003E4__this;

		private WaitForSeconds _003CwaitForSeconds_003E5__2;

		private WaitForSecondsRealtime _003CwaitForSecondsRealtime_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_01f3: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_00a4: Expected I4, but got I8
			//IL_022a: Expected I4, but got O
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0071: Expected I4, but got I8
			ProCamera2DRooms proCamera2DRooms = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					object obj2 = obj - 1;
					if (!flag && (nint)obj2 != 1)
					{
						return false;
					}
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						goto IL_011d;
					}
				}
				else
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						WaitForSeconds waitForSeconds = null;
						waitForSeconds.m_Seconds = proCamera2DRooms.UpdateInterval;
						_003CwaitForSeconds_003E5__2 = waitForSeconds;
						WaitForSecondsRealtime waitForSecondsRealtime = null;
						waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = proCamera2DRooms.UpdateInterval;
						waitForSecondsRealtime.m_WaitUntilTime = -1f;
						_003CwaitForSecondsRealtime_003E5__3 = waitForSecondsRealtime;
						goto IL_011d;
					}
				}
				goto IL_021c;
			}
			_003C_003E1__state = -1;
			WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
			_003C_003E2__current = waitForEndOfFrame;
			_003C_003E1__state = 1;
			return true;
			IL_021c:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_011d:
			if (proCamera2DRooms.AutomaticRoomActivation)
			{
				_003C_003E4__this.TestRoom();
			}
			ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
			if ((object)proCamera2D != null)
			{
				if (!proCamera2D.IgnoreTimeScale)
				{
					_003C_003E2__current = _003CwaitForSeconds_003E5__2;
					_003C_003E1__state = 3;
					return true;
				}
				_003C_003E2__current = _003CwaitForSecondsRealtime_003E5__3;
				_003C_003E1__state = 2;
				return true;
			}
			goto IL_021c;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CTransitionRoutine_003Ed__58(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DRooms _003C_003E4__this;

		public float transitionDuration;

		public float targetSize;

		public EaseType transitionEaseType;

		public NumericBoundariesSettings numericBoundariesSettings;

		private float _003CinitialSize_003E5__2;

		private float _003CinitialCamPosH_003E5__3;

		private float _003CinitialCamPosV_003E5__4;

		private float _003Ct_003E5__5;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_017a: Expected I4, but got I8
			//IL_08b8: Expected I4, but got O
			//IL_0015: Expected O, but got I4
			//IL_0166: Expected I4, but got I8
			//IL_07e2: Invalid comparison between F4 and I4
			//IL_0052: Expected I4, but got I8
			//IL_0904: Invalid comparison between F4 and I4
			//IL_0140: Expected O, but got I
			//IL_058a: Invalid comparison between I and F4
			//IL_05f9: Invalid comparison between F4 and I
			//IL_064d: Invalid comparison between I and F4
			//IL_06c8: Invalid comparison between F4 and I
			//IL_0724: Invalid comparison between F4 and I4
			BasePC2D basePC2D = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj != 1)
					{
						goto IL_08e1;
					}
					_003C_003E1__state = -1;
					goto IL_09e6;
				}
				_003C_003E1__state = -1;
				goto IL_09ad;
			}
			_003C_003E1__state = -1;
			if ((object)_003C_003E4__this != null)
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B0]");
				if ((nint)0 != 0)
				{
					_ = 0;
					ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v43 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
						float num = 0f * 0.5f;
						_003CinitialSize_003E5__2 = num;
						Func<Vector3, float> vector3H = basePC2D.Vector3H;
						ProCamera2D proCamera2D2 = _003C_003E4__this.ProCamera2D;
						if ((object)proCamera2D2 != null)
						{
							Vector3 localPosition = proCamera2D2.LocalPosition;
							if (basePC2D.Vector3H != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v153 @ rbp_v10 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
								_003CinitialCamPosH_003E5__3 = localPosition.x;
								Func<Vector3, float> vector3V = basePC2D.Vector3V;
								ProCamera2D proCamera2D3 = _003C_003E4__this.ProCamera2D;
								if ((object)proCamera2D3 != null)
								{
									Vector3 localPosition2 = proCamera2D3.LocalPosition;
									if (basePC2D.Vector3V != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v154 @ rbp_v11 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
										_003CinitialCamPosV_003E5__4 = localPosition2.x;
										_003Ct_003E5__5 = 0f;
										goto IL_09ad;
									}
								}
							}
						}
					}
				}
			}
			goto IL_08aa;
			IL_09e6:
			if ((object)_003C_003E4__this != null)
			{
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+B0]");
				if ((nint)0 != 0)
				{
					_ = numericBoundariesSettings;
					object obj2 = (object)numericBoundariesSettings >> 8;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					_ = numericBoundariesSettings;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRooms+<TransitionRoutine>d__58)+44]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRooms+<TransitionRoutine>d__58)+44]");
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+A0]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+A0]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+60]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+64]");
						((UnityEvent<int, int>)num2).Invoke((int)num3, 0);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+60]");
					_ = 0;
					goto IL_08e1;
				}
			}
			goto IL_08aa;
			IL_08aa:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_09ad:
			object obj3 = default(object);
			while (true)
			{
				float num8;
				float num9;
				if (!(1f < _003Ct_003E5__5))
				{
					if (!(1E-45f > transitionDuration))
					{
						if ((object)_003C_003E4__this == null)
						{
							break;
						}
						ProCamera2D proCamera2D4 = _003C_003E4__this.ProCamera2D;
						if ((object)proCamera2D4 == null)
						{
							break;
						}
						if (proCamera2D4._003CDeltaTime_003Ek__BackingField > 1E-45f)
						{
							ProCamera2D proCamera2D5 = _003C_003E4__this.ProCamera2D;
							if ((object)proCamera2D5 == null)
							{
								break;
							}
							float num4 = proCamera2D5._003CDeltaTime_003Ek__BackingField / transitionDuration;
							float num5 = num4 + _003Ct_003E5__5;
							_003Ct_003E5__5 = num5;
						}
					}
					else
					{
						_003Ct_003E5__5 = 1.1f;
					}
					float num6 = targetSize;
					if (transitionDuration > 0f)
					{
						float num7 = Utils.EaseFromTo(_003CinitialSize_003E5__2, targetSize, _003Ct_003E5__5, transitionEaseType);
						num6 = num7;
					}
					if ((object)_003C_003E4__this == null)
					{
						break;
					}
					ProCamera2D proCamera2D6 = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D6 == null)
					{
						break;
					}
					num8 = proCamera2D6._cameraTargetHorizontalPositionSmoothed;
					ProCamera2D proCamera2D7 = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D7 == null)
					{
						break;
					}
					num9 = proCamera2D7._cameraTargetVerticalPositionSmoothed;
					ProCamera2D proCamera2D8 = _003C_003E4__this.ProCamera2D;
					if ((object)proCamera2D8 == null || (object)proCamera2D8.GameCamera == null)
					{
						break;
					}
					float aspect = proCamera2D8.GameCamera.aspect;
					float num10 = aspect * targetSize;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRooms+<TransitionRoutine>d__58)+44]");
					if ((nint)0 != 0)
					{
						float num11 = proCamera2D6._cameraTargetHorizontalPositionSmoothed - num10;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRooms+<TransitionRoutine>d__58)+48]");
						if (0f > num11)
						{
							num8 = (float)obj3 + num10;
							goto IL_091b;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRooms+<TransitionRoutine>d__58)+4C]");
					if ((nint)0 != 0)
					{
						float num12 = num10 + num8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRooms+<TransitionRoutine>d__58)+50]");
						if (num12 > 0f)
						{
							float num13 = (float)obj3 - num10;
							num8 = num13;
						}
					}
					goto IL_091b;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001851C4799h\"");
				if (transitionDuration != 0f)
				{
					goto IL_09e6;
				}
				if ((object)_003C_003E4__this == null)
				{
					break;
				}
				ProCamera2D proCamera2D9 = _003C_003E4__this.ProCamera2D;
				if ((object)proCamera2D9 == null)
				{
					break;
				}
				bool flag2 = proCamera2D9.UpdateType != UpdateType.FixedUpdate;
				WaitForFixedUpdate waitForFixedUpdate = null;
				if (!flag2)
				{
					bool flag3 = proCamera2D9.IgnoreTimeScale;
					waitForFixedUpdate = null;
					if (!flag3)
					{
						waitForFixedUpdate = proCamera2D9._waitForFixedUpdate;
					}
				}
				_003C_003E2__current = waitForFixedUpdate;
				_003C_003E1__state = 2;
				goto IL_0a1f;
				IL_0940:
				Func<float, float, float, Vector3> vectorHVD = basePC2D.VectorHVD;
				float num14 = Utils.EaseFromTo(_003CinitialCamPosH_003E5__3, num8, _003Ct_003E5__5, transitionEaseType);
				float num15 = Utils.EaseFromTo(_003CinitialCamPosV_003E5__4, num9, _003Ct_003E5__5, transitionEaseType);
				if (basePC2D.VectorHVD == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v156 @ rbp_v7 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v659 @ rax_v31+8]");
				_ = 0;
				if (!(transitionDuration > 0f))
				{
					continue;
				}
				ProCamera2D proCamera2D10 = _003C_003E4__this.ProCamera2D;
				if ((object)proCamera2D10 == null)
				{
					break;
				}
				bool flag4 = proCamera2D10.UpdateType != UpdateType.FixedUpdate;
				WaitForFixedUpdate waitForFixedUpdate2 = null;
				if (!flag4)
				{
					bool flag5 = proCamera2D10.IgnoreTimeScale;
					waitForFixedUpdate2 = null;
					if (!flag5)
					{
						waitForFixedUpdate2 = proCamera2D10._waitForFixedUpdate;
					}
				}
				_003C_003E2__current = waitForFixedUpdate2;
				_003C_003E1__state = 1;
				goto IL_0a1f;
				IL_091b:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRooms+<TransitionRoutine>d__58)+3C]");
				if ((nint)0 != 0)
				{
					float num16 = num9 - targetSize;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRooms+<TransitionRoutine>d__58)+40]");
					if (0f > num16)
					{
						num9 = (float)obj3 + targetSize;
						goto IL_0940;
					}
				}
				object obj4 = (object)numericBoundariesSettings >> 8;
				if (obj4 != null)
				{
					float num17 = targetSize + num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRooms+<TransitionRoutine>d__58)+38]");
					if (num17 > 0f)
					{
						float num18 = (float)obj3 - targetSize;
						num9 = num18;
					}
				}
				goto IL_0940;
				IL_0a1f:
				return true;
			}
			goto IL_08aa;
			IL_08e1:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	public const string ExtensionName = "Rooms";

	private int _currentRoomIndex;

	private int _previousRoomIndex;

	private float _003COriginalSize_003Ek__BackingField;

	public List<Room> Rooms;

	public float UpdateInterval;

	public bool UseTargetsMidPoint;

	public Transform TriggerTarget;

	public bool TransitionInstanlyOnStart;

	public bool RestoreOnRoomExit;

	public float RestoreDuration;

	public EaseType RestoreEaseType;

	public bool AutomaticRoomActivation;

	public bool UseRelativePosition;

	public RoomEvent OnStartedTransition;

	public RoomEvent OnFinishedTransition;

	public UnityEvent OnExitedAllRooms;

	private ProCamera2DNumericBoundaries _numericBoundaries;

	private NumericBoundariesSettings _defaultNumericBoundariesSettings;

	private bool _transitioning;

	private Vector3 _newPos;

	private float _newSize;

	private Coroutine _transitionRoutine;

	private int _currentRoomID;

	private int _poOrder;

	private int _soOrder;

	public int CurrentRoomIndex => _currentRoomIndex;

	public int PreviousRoomIndex => _previousRoomIndex;

	public Room CurrentRoom
	{
		get
		{
			if (_currentRoomIndex >= 0)
			{
				List<Room> rooms = Rooms;
				if (Rooms != null)
				{
					if (_currentRoomIndex >= rooms._size)
					{
						goto IL_00cb;
					}
					List<Room> rooms2 = Rooms;
					int currentRoomIndex = _currentRoomIndex;
					if (_currentRoomIndex < rooms2._size)
					{
						Room[] items = rooms2._items;
						if (rooms2._items != null)
						{
							return items[currentRoomIndex];
						}
					}
					else
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					}
				}
				return (Room)(object)new NullReferenceException();
			}
			goto IL_00cb;
			IL_00cb:
			return null;
		}
	}

	public float OriginalSize
	{
		get
		{
			return _003COriginalSize_003Ek__BackingField;
		}
		private set
		{
			_003COriginalSize_003Ek__BackingField = value;
		}
	}

	public int POOrder
	{
		get
		{
			return _poOrder;
		}
		set
		{
			_poOrder = value;
		}
	}

	public int SOOrder
	{
		get
		{
			return _soOrder;
		}
		set
		{
			_soOrder = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		ProCamera2D proCamera2D = base.ProCamera2D;
		ProCamera2DNumericBoundaries component = proCamera2D.GetComponent<ProCamera2DNumericBoundaries>();
		_numericBoundaries = component;
		NumericBoundariesSettings defaultNumericBoundariesSettings = default(NumericBoundariesSettings);
		_defaultNumericBoundariesSettings = defaultNumericBoundariesSettings;
		ProCamera2D proCamera2D2 = base.ProCamera2D;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v13 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
		float num = 0f * 0.5f;
		_003COriginalSize_003Ek__BackingField = num;
		ProCamera2D proCamera2D3 = base.ProCamera2D;
		proCamera2D3.AddPositionOverrider(this);
		ProCamera2D proCamera2D4 = base.ProCamera2D;
		proCamera2D4.AddSizeOverrider(this);
	}

	private unsafe void Start()
	{
		//IL_01d8: Expected O, but got Ref
		//IL_0258->IL01ce: Incompatible stack heights: 1 vs 0
		int instanceID = GetInstanceID();
		if (Rooms != null)
		{
			object obj = null;
			List<Room>.Enumerator enumerator = default(List<Room>.Enumerator);
			if (enumerator.MoveNext())
			{
				UnityEngine.Object obj2 = null;
				UnityEngine.Object obj3 = null;
				throw new NullReferenceException();
			}
			_003CTestRoomRoutine_003Ed__56 obj4 = null;
			obj4._003C_003E1__state = 0;
			obj4._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj4);
			if (!TransitionInstanlyOnStart)
			{
				return;
			}
			ProCamera2D proCamera2D = base.ProCamera2D;
			if ((object)proCamera2D != null)
			{
				if (!UseTargetsMidPoint)
				{
					Transform triggerTarget = TriggerTarget;
					if ((object)TriggerTarget != null && ((UnityEngine.Object)triggerTarget).m_CachedPtr != (IntPtr)0)
					{
						object triggerTarget2 = TriggerTarget;
						bool flag = (object)TriggerTarget == null;
						UnityEngine.Object obj3 = (UnityEngine.Object)(object)typeof(UnityEngine.Object);
						if (flag)
						{
							goto IL_015e;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdi_v11 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdi_v11 (System.Object)+10]");
						Transform.get_position_Injected((IntPtr)0, out Vector3 _);
					}
				}
				Vector3 vector = default(Vector3);
				int num = ComputeCurrentRoom((Vector3)(&vector));
				if (num != -1)
				{
					EnterRoom(num, useTransition: false);
				}
				return;
			}
		}
		goto IL_015e;
		IL_015e:
		throw new NullReferenceException();
	}

	protected override void OnDestroy()
	{
		Disable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag = ((List<object>)(object)proCamera2D2._positionOverriders).Remove((object)this);
			ProCamera2D proCamera2D3 = base.ProCamera2D;
			bool flag2 = ((List<object>)(object)proCamera2D3._sizeOverriders).Remove((object)this);
		}
	}

	public unsafe Vector3 OverridePosition(float deltaTime, Vector3 originalPosition)
	{
		//IL_009b: Expected O, but got I4
		//IL_0082: Expected native int or pointer, but got O
		//IL_00c0: Expected native int or pointer, but got O
		//IL_0054: Expected F4, but got I
		//IL_0063: Expected F4, but got O
		//IL_005e: Expected native int or pointer, but got O
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		float z;
		Vector3 vector = default(Vector3);
		if (obj != null && _transitioning)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRooms)+E4]");
			z = 0f;
			((Vector3*)(nint)vector)->x = (float)_newPos;
		}
		else
		{
			z = originalPosition.z;
			((Vector3*)(nint)vector)->x = originalPosition.x;
		}
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	public float OverrideSize(float deltaTime, float originalSize)
	{
		//IL_005f: Expected O, but got I4
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj != null && _transitioning)
		{
			return _newSize;
		}
		return originalSize;
	}

	public unsafe void TestRoom()
	{
		//IL_020b: Expected O, but got Ref
		//IL_02ab: Expected I4, but got I8
		//IL_02ba: Expected I4, but got I8
		//IL_017e: Expected O, but got Ref
		//IL_012f: Expected I4, but got I8
		//IL_028b->IL0201: Incompatible stack heights: 1 vs 0
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null)
		{
			Vector3 ret = default(Vector3);
			if (!UseTargetsMidPoint)
			{
				Transform triggerTarget = TriggerTarget;
				if ((object)TriggerTarget != null && ((UnityEngine.Object)triggerTarget).m_CachedPtr != (IntPtr)0)
				{
					object triggerTarget2 = TriggerTarget;
					if ((object)TriggerTarget == null)
					{
						goto IL_01d3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdi_v7 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdi_v7 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret);
				}
			}
			int num = ComputeCurrentRoom((Vector3)(&ret));
			if (num != -1)
			{
				if (_currentRoomIndex != num)
				{
					EnterRoom(num);
				}
			}
			else
			{
				if (_currentRoomIndex == -1)
				{
					return;
				}
				bool flag2 = !RestoreOnRoomExit;
				_currentRoomIndex = -1;
				_currentRoomID = -1;
				if (!flag2)
				{
					if (OnStartedTransition != null)
					{
						OnStartedTransition.Invoke(-1, _previousRoomIndex);
					}
					if (_transitionRoutine != null)
					{
						StopCoroutine(_transitionRoutine);
					}
					object obj = default(object);
					EaseType transitionEaseType = default(EaseType);
					IEnumerator routine = TransitionRoutine((NumericBoundariesSettings)(&obj), _003COriginalSize_003Ek__BackingField, RestoreDuration, transitionEaseType);
					Coroutine transitionRoutine = StartCoroutine(routine);
					_transitionRoutine = transitionRoutine;
				}
				if (OnExitedAllRooms != null)
				{
					OnExitedAllRooms.Invoke();
				}
			}
			return;
		}
		goto IL_01d3;
		IL_01d3:
		throw new NullReferenceException();
	}

	public int ComputeCurrentRoom(Vector3 targetPos)
	{
		//IL_0029: Expected I4, but got I8
		//IL_003f: Expected I4, but got I8
		//IL_00f0: Expected F4, but got I4
		//IL_00e2: Expected I, but got O
		//IL_0152: Expected F4, but got I4
		//IL_0144: Expected I, but got O
		//IL_020f: Expected F4, but got I
		//IL_020f: Expected F4, but got I
		List<Room> rooms = Rooms;
		bool flag = rooms._size <= 0;
		int num = -1;
		int num2 = 0;
		int num3 = -1;
		int num4 = 0;
		if (!flag)
		{
			float pointX = default(float);
			float pointY = default(float);
			bool flag3;
			int result = default(int);
			do
			{
				List<Room> rooms2 = Rooms;
				if (num2 < rooms2._size)
				{
					Room[] items = rooms2._items;
					Room room = items[num2];
					float num5;
					nint num6;
					if (UseRelativePosition)
					{
						num5 = _transform.position.x;
						num6 = unchecked((nint)null);
					}
					else
					{
						num5 = 0f;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					float num7;
					if (UseRelativePosition)
					{
						num7 = _transform.position.y;
						num6 = unchecked((nint)null);
					}
					else
					{
						num7 = 0f;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Func<Vector3, float> vector3H = Vector3H;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v197 @ rcx_v14 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					Func<Vector3, float> vector3V = Vector3V;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rcx_v16 (System.Func`2<UnityEngine.Vector3, System.Single>)+28]");
					num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v198 @ rcx_v16 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v13+1C]");
					float y = 0f + num7;
					float x = (float)room.Dimensions + num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v15+20]");
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rax_v16+24]");
					bool flag2 = Utils.IsInsideRectangle(x, y, num8, 0f, pointX, pointY);
					List<Room> rooms3 = Rooms;
					num2++;
					num = num4;
					if (!flag2)
					{
						num = num3;
					}
					flag3 = num2 < rooms3._size;
					float x2 = targetPos.x;
					float x3 = targetPos.x;
					num3 = num;
					num4 = num2;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
			while (flag3);
		}
		return num;
	}

	public void EnterRoom(int roomIndex, bool useTransition = true, bool forceEntrance = false)
	{
		//IL_0027: Expected O, but got I4
		if (roomIndex >= 0)
		{
			List<Room> rooms = Rooms;
			object obj = rooms._size - 1;
			if (roomIndex <= (nint)obj)
			{
				if (!forceEntrance)
				{
					List<Room> rooms2 = Rooms;
					if (roomIndex >= rooms2._size)
					{
						goto IL_0261;
					}
					Room[] items = rooms2._items;
					Room room = items[roomIndex];
					if (room.InternalID == _currentRoomID)
					{
						return;
					}
				}
				List<Room> rooms3 = Rooms;
				_previousRoomIndex = _currentRoomIndex;
				_currentRoomIndex = roomIndex;
				if (roomIndex < rooms3._size)
				{
					Room[] items2 = rooms3._items;
					Room room2 = items2[roomIndex];
					bool flag = OnStartedTransition == null;
					_currentRoomID = room2.InternalID;
					if (!flag)
					{
						OnStartedTransition.Invoke(roomIndex, _currentRoomIndex);
					}
					List<Room> rooms4 = Rooms;
					int currentRoomIndex = _currentRoomIndex;
					if (_currentRoomIndex < rooms4._size)
					{
						Room[] items3 = rooms4._items;
						TransitionToRoom(items3[currentRoomIndex], useTransition);
						return;
					}
				}
				goto IL_0261;
			}
		}
		int num = default(int);
		string text = num.ToString();
		string message = "Can't find room with index: " + text;
		Exception ex = new Exception(message);
		throw ex;
		IL_0261:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	public unsafe void EnterRoom(string roomID, bool useTransition = true, bool forceEntrance = false)
	{
		_003C_003Ec__DisplayClass49_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass49_0();
		CS_0024_003C_003E8__locals5.roomID = roomID;
		List<Room> rooms = Rooms;
		Predicate<Room> predicate = delegate(Room room)
		{
			//IL_012f: Expected I4, but got O
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected Ref, but got Unknown
			//IL_00e8: Expected I8, but got I4
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected Ref, but got Unknown
			if (room == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			string iD = room.ID;
			string roomID2 = CS_0024_003C_003E8__locals5.roomID;
			if ((object)room.ID != CS_0024_003C_003E8__locals5.roomID)
			{
				if (room.ID != null && CS_0024_003C_003E8__locals5.roomID != null && iD._stringLength == roomID2._stringLength)
				{
					ref byte second = ref *(byte*)(CS_0024_003C_003E8__locals5.roomID + 20);
					ulong length = (ulong)(iD._stringLength + iD._stringLength);
					return System.SpanHelpers.SequenceEqual(ref *(byte*)(room.ID + 20), ref second, length);
				}
				return false;
			}
			return true;
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805EA0E0");
		int num = default(int);
		if (num >= 0)
		{
			EnterRoom(num, useTransition, forceEntrance);
			return;
		}
		throw new NullReferenceException();
	}

	public unsafe void ExitRoom()
	{
		//IL_00ff: Expected I4, but got I8
		//IL_010e: Expected I4, but got I8
		//IL_008d: Expected O, but got Ref
		//IL_003e: Expected I4, but got I8
		bool flag = !RestoreOnRoomExit;
		_currentRoomIndex = -1;
		_currentRoomID = -1;
		if (!flag)
		{
			if (OnStartedTransition != null)
			{
				OnStartedTransition.Invoke(-1, _previousRoomIndex);
			}
			if (_transitionRoutine != null)
			{
				StopCoroutine(_transitionRoutine);
			}
			object obj = default(object);
			EaseType transitionEaseType = default(EaseType);
			IEnumerator routine = TransitionRoutine((NumericBoundariesSettings)(&obj), _003COriginalSize_003Ek__BackingField, RestoreDuration, transitionEaseType);
			Coroutine transitionRoutine = StartCoroutine(routine);
			_transitionRoutine = transitionRoutine;
		}
		if (OnExitedAllRooms != null)
		{
			OnExitedAllRooms.Invoke();
		}
	}

	public void AddRoom(float roomX, float roomY, float roomWidth, float roomHeight, float transitionDuration = 1f, EaseType transitionEaseType = EaseType.EaseInOut, bool scaleToFit = false, bool zoom = false, float zoomScale = 1.5f, string id = "")
	{
		//IL_0044: Expected F4, but got O
		Room room = new Room();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998C30D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		room.ID = "";
		string iD = default(string);
		room.ID = iD;
		IntPtr intPtr = default(IntPtr);
		room.TransitionEaseType = (EaseType)(nint)intPtr;
		bool scaleCameraToFit = default(bool);
		room.ScaleCameraToFit = scaleCameraToFit;
		bool zoom2 = default(bool);
		room.Zoom = zoom2;
		room.TransitionDuration = (float)id;
		float zoomScale2 = default(float);
		room.ZoomScale = zoomScale2;
		Rect dimensions = default(Rect);
		room.Dimensions = dimensions;
		int instanceID = GetInstanceID();
		List<Room> rooms = Rooms;
		int internalID = instanceID + rooms._size;
		room.InternalID = internalID;
		List<object> rooms2 = (List<object>)(object)Rooms;
		int version = rooms2._version + 1;
		rooms2._version = version;
		object[] items = rooms2._items;
		if (rooms2._size >= items.Length)
		{
			rooms2.AddWithResize((object)room);
			return;
		}
		int size = rooms2._size + 1;
		rooms2._size = size;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	public unsafe void RemoveRoom(string roomName)
	{
		_003C_003Ec__DisplayClass52_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass52_0();
		CS_0024_003C_003E8__locals6.roomName = roomName;
		Predicate<Room> match = delegate(Room obj)
		{
			//IL_012f: Expected I4, but got O
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected Ref, but got Unknown
			//IL_00e8: Expected I8, but got I4
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected Ref, but got Unknown
			if (obj == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			string iD = obj.ID;
			string roomName2 = CS_0024_003C_003E8__locals6.roomName;
			if ((object)obj.ID != CS_0024_003C_003E8__locals6.roomName)
			{
				if (obj.ID != null && CS_0024_003C_003E8__locals6.roomName != null && iD._stringLength == roomName2._stringLength)
				{
					ref byte second = ref *(byte*)(CS_0024_003C_003E8__locals6.roomName + 20);
					ulong length = (ulong)(iD._stringLength + iD._stringLength);
					return System.SpanHelpers.SequenceEqual(ref *(byte*)(obj.ID + 20), ref second, length);
				}
				return false;
			}
			return true;
		};
		Room room = Rooms.Find(match);
		if (room == null)
		{
			string message = CS_0024_003C_003E8__locals6.roomName + " not found in the Rooms list.";
			Debug.LogWarning(message);
		}
		else
		{
			bool flag = ((List<object>)(object)Rooms).Remove((object)room);
		}
	}

	public void SetDefaultNumericBoundariesSettings(NumericBoundariesSettings settings)
	{
		//IL_000f: Expected O, but got I4
		_defaultNumericBoundariesSettings = (NumericBoundariesSettings)settings.UseNumericBoundaries;
		_ = settings.UseLeftBoundary;
	}

	public unsafe Room GetRoom(string roomID)
	{
		_003C_003Ec__DisplayClass54_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass54_0();
		if (CS_0024_003C_003E8__locals6 != null)
		{
			CS_0024_003C_003E8__locals6.roomID = roomID;
			Predicate<Room> match = delegate(Room obj)
			{
				//IL_012f: Expected I4, but got O
				//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d1: Expected Ref, but got Unknown
				//IL_00e8: Expected I8, but got I4
				//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fb: Expected Ref, but got Unknown
				if (obj == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				string iD = obj.ID;
				string roomID2 = CS_0024_003C_003E8__locals6.roomID;
				if ((object)obj.ID != CS_0024_003C_003E8__locals6.roomID)
				{
					if (obj.ID != null && CS_0024_003C_003E8__locals6.roomID != null && iD._stringLength == roomID2._stringLength)
					{
						ref byte second = ref *(byte*)(CS_0024_003C_003E8__locals6.roomID + 20);
						ulong length = (ulong)(iD._stringLength + iD._stringLength);
						return System.SpanHelpers.SequenceEqual(ref *(byte*)(obj.ID + 20), ref second, length);
					}
					return false;
				}
				return true;
			};
			if (Rooms != null)
			{
				return Rooms.Find(match);
			}
		}
		return (Room)(object)new NullReferenceException();
	}

	public float GetCameraSizeForRoom(Rect roomRect)
	{
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			if ((object)proCamera2D2 != null)
			{
				float num = roomRect.m_Height;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rax_v4 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
				float num2 = num / 0f;
				float num3 = roomRect.m_Width / (float)proCamera2D._003CScreenSizeInWorldCoordinates_003Ek__BackingField;
				if (!(num2 > num3))
				{
					return roomRect.m_Height * 0.5f;
				}
				ProCamera2D proCamera2D3 = base.ProCamera2D;
				if ((object)proCamera2D3 != null && (object)proCamera2D3.GameCamera != null)
				{
					float aspect = proCamera2D3.GameCamera.aspect;
					float num4 = roomRect.m_Width / aspect;
					return num4 * 0.5f;
				}
			}
		}
		throw new NullReferenceException();
	}

	private IEnumerator TestRoomRoutine()
	{
		_003CTestRoomRoutine_003Ed__56 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void TransitionToRoom(Room room, bool useTransition = true)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0124: Expected O, but got I4
		//IL_0165: Expected O, but got I4
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_049a: Expected F4, but got I4
		//IL_05c6: Expected O, but got Ref
		//IL_03a0->IL04a8: Incompatible stack heights: 1 vs 0
		//IL_03db->IL04ca: Incompatible stack heights: 1 vs 0
		//IL_041e->IL04f0: Incompatible stack heights: 1 vs 0
		//IL_0461->IL0553: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (_transitionRoutine != null)
		{
			StopCoroutine(_transitionRoutine);
		}
		_ = 0;
		float num5;
		if (room != null)
		{
			if (UseRelativePosition)
			{
				object obj3 = _transform;
				if ((object)_transform == null)
				{
					goto IL_035d;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rsi_v18 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rsi_v18 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			}
			if (UseRelativePosition)
			{
				object obj4 = _transform;
				if ((object)_transform == null)
				{
					goto IL_035d;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rsi_v17 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rsi_v17 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			}
			_ = 1;
			object obj6;
			if (UseRelativePosition)
			{
				object obj5 = _transform;
				if ((object)_transform == null)
				{
					goto IL_035d;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rsi_v16 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rsi_v16 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 ret3);
				obj6 = ret3;
			}
			else
			{
				obj6 = 0;
			}
			object obj7 = (object)room.Dimensions + obj6;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [room @ rdx (Com.LuisPedroFonseca.ProCamera2D.Room)+20]");
			float num = 0f * 0.5f;
			float num2 = (float)obj7 - num;
			object obj9;
			if (UseRelativePosition)
			{
				object obj8 = _transform;
				if ((object)_transform == null)
				{
					goto IL_035d;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rsi_v15 (System.Object)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rsi_v15 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 ret4);
				obj9 = ret4;
			}
			else
			{
				obj9 = 0;
			}
			object obj10 = (object)room.Dimensions + obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [room @ rdx (Com.LuisPedroFonseca.ProCamera2D.Room)+20]");
			float num3 = 0f * 0.5f;
			float num4 = (float)obj10 + num3;
			ProCamera2D proCamera2D = base.ProCamera2D;
			if ((object)proCamera2D != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v28 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
				num5 = 0f * 0.5f;
				ProCamera2D proCamera2D2 = base.ProCamera2D;
				if ((object)proCamera2D2 != null)
				{
					ProCamera2D proCamera2D3 = base.ProCamera2D;
					if ((object)proCamera2D3 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v30 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
						object obj12 = default(object);
						object obj11 = obj12 / 0;
						object obj13 = obj12 / (object)proCamera2D2._003CScreenSizeInWorldCoordinates_003Ek__BackingField;
						float num6;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13))
						{
							num6 = (float)obj12 * 0.5f;
						}
						else
						{
							ProCamera2D proCamera2D4 = base.ProCamera2D;
							if ((object)proCamera2D4 == null || (object)proCamera2D4.GameCamera == null)
							{
								goto IL_035d;
							}
							float aspect = proCamera2D4.GameCamera.aspect;
							float num7 = (float)obj12 / aspect;
							float num8 = num7 * 0.5f;
							num6 = num8;
						}
						if (!room.ScaleCameraToFit)
						{
							if (room.Zoom)
							{
								float num9 = _003COriginalSize_003Ek__BackingField * room.ZoomScale;
								if (!(num6 < num9))
								{
									num5 = _003COriginalSize_003Ek__BackingField * room.ZoomScale;
									goto IL_0486;
								}
							}
							if (!(num5 > num6))
							{
								goto IL_0486;
							}
						}
						num5 = num6;
						goto IL_0486;
					}
				}
			}
		}
		goto IL_035d;
		IL_035d:
		throw new NullReferenceException();
		IL_0486:
		bool flag5 = !useTransition;
		float transitionDuration = 0f;
		if (!flag5)
		{
			transitionDuration = room.TransitionDuration;
		}
		NumericBoundariesSettings numericBoundariesSettings = (NumericBoundariesSettings)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
		_ = 257;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
		_ = 0;
		EaseType transitionEaseType = default(EaseType);
		IEnumerator routine = TransitionRoutine(numericBoundariesSettings, num5, transitionDuration, transitionEaseType);
		Coroutine transitionRoutine = StartCoroutine(routine);
		_transitionRoutine = transitionRoutine;
	}

	private IEnumerator TransitionRoutine(NumericBoundariesSettings numericBoundariesSettings, float targetSize, float transitionDuration = 1f, EaseType transitionEaseType = EaseType.EaseOut)
	{
		//IL_0024: Expected O, but got I4
		_003CTransitionRoutine_003Ed__58 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		EaseType transitionEaseType2 = default(EaseType);
		obj.transitionEaseType = transitionEaseType2;
		obj.numericBoundariesSettings = (NumericBoundariesSettings)numericBoundariesSettings.UseNumericBoundaries;
		obj.targetSize = targetSize;
		obj.transitionDuration = transitionDuration;
		_ = numericBoundariesSettings.UseLeftBoundary;
		return obj;
	}

	private unsafe void LimitToNumericBoundaries(ref float horizontalPos, ref float verticalPos, float halfCameraWidth, float halfCameraHeight, NumericBoundariesSettings numericBoundaries)
	{
		//IL_0049: Invalid comparison between I and F4
		//IL_00c5: Invalid comparison between F4 and I
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_01dd: Expected Ref, but got F4
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ stack_30+10]");
		float num2;
		if ((nint)0 != 0)
		{
			float num = horizontalPos - halfCameraWidth;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ stack_30+14]");
			if (0f > num)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ stack_30+14]");
				num2 = 0f + halfCameraWidth;
				goto IL_01d5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ stack_30+18]");
		if ((nint)0 != 0)
		{
			float num3 = halfCameraWidth + horizontalPos;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ stack_30+1C]");
			if (num3 > 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ stack_30+1C]");
				num2 = 0f - halfCameraWidth;
				goto IL_01d5;
			}
		}
		goto IL_01e2;
		IL_01e2:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ stack_30+8]");
		object obj2 = default(object);
		if ((nint)0 != 0)
		{
			object obj = verticalPos - obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ stack_30+C]");
			if (0 > (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ stack_30+C]");
				object obj3 = 0 + obj2;
				ref float reference = ref *(float*)obj3;
				return;
			}
		}
		object obj5 = default(object);
		object obj4 = obj5 >> 8;
		if (obj4 != null)
		{
			object obj6 = obj2 + verticalPos;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ stack_30+4]");
			if ((nint)obj6 > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ stack_30+4]");
				object obj7 = 0 - obj2;
				ref float reference = ref *(float*)obj7;
			}
		}
		return;
		IL_01d5:
		ref float reference2 = ref *(float*)num2;
		goto IL_01e2;
	}

	public ProCamera2DRooms()
	{
		//IL_00af: Expected I4, but got I8
		_currentRoomIndex = -1;
		List<Room> rooms = new List<Room>();
		Rooms = rooms;
		UpdateInterval = 0.1f;
		UseTargetsMidPoint = true;
		TransitionInstanlyOnStart = true;
		RestoreDuration = 1f;
		AutomaticRoomActivation = true;
		RoomEvent onStartedTransition = new RoomEvent();
		OnStartedTransition = onStartedTransition;
		RoomEvent onFinishedTransition = new RoomEvent();
		OnFinishedTransition = onFinishedTransition;
		OnExitedAllRooms = (UnityEvent)new UnityEventBase
		{
			m_InvokeArray = null
		};
		_currentRoomID = -1;
		_poOrder = 1001;
		_soOrder = 3001;
	}
}
