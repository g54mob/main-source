using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[AddComponentMenu("Rewired/Touch Button")]
	public sealed class TouchButton : TouchInteractable
	{
		public enum ButtonType
		{
			Standard = 0,
			ToggleSwitch = 1
		}

		private enum phxNRzzCOfwAprEuEEPzkNyqysai
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum hCrsuvqVPqbUhmJeFMlGylBfrAap
		{
			Local = 0,
			TouchRegion = 1
		}

		[Serializable]
		public class AxisValueChangedEventHandler : UnityEvent<float>
		{
		}

		[Serializable]
		public class ButtonValueChangedEventHandler : UnityEvent<bool>
		{
		}

		[Serializable]
		public class ButtonDownEventHandler : UnityEvent
		{
		}

		[Serializable]
		public class ButtonUpEventHandler : UnityEvent
		{
		}

		private sealed class tylpSzSWzqXnMKKiVEuamMHPfTYI : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int jOSlPWWrBZMigKvMBZNbCIQwrTob;

			private object JohbssfqOHPiHJIVGTSlqaoCTRhpA;

			public float UdXZuDokmBJTcRvleYeoFvgkJfvr;

			public TouchButton HpgfEvUYIAniQFSxDDpoXXFRVDNh;

			public PositionType ZYdFuWaNiOTQrrdnropIQITQHdgOA;

			public Vector2 VnGftuzFcDtrUjjpfiXEUQIGXPrn;

			public phxNRzzCOfwAprEuEEPzkNyqysai eboaTcpxlHgBkKvTNfJrRQUCJFPf;

			private RectTransform XabOdculMFIueaGTmhxgUUKxqYflA;

			private Vector2 lQfBOMAAuUwsdEqWUHiedBzCurTRB;

			private float NHYBNPjSNluBRJcWKQgwSQRQtykP;

			private float GqTiFOrSPEgiaPzjRyXtjUWonZSj;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return JohbssfqOHPiHJIVGTSlqaoCTRhpA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return JohbssfqOHPiHJIVGTSlqaoCTRhpA;
				}
			}

			[DebuggerHidden]
			public tylpSzSWzqXnMKKiVEuamMHPfTYI(int P_0)
			{
				jOSlPWWrBZMigKvMBZNbCIQwrTob = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = jOSlPWWrBZMigKvMBZNbCIQwrTob;
				TouchButton hpgfEvUYIAniQFSxDDpoXXFRVDNh = HpgfEvUYIAniQFSxDDpoXXFRVDNh;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					jOSlPWWrBZMigKvMBZNbCIQwrTob = -1;
					goto IL_010c;
				}
				jOSlPWWrBZMigKvMBZNbCIQwrTob = -1;
				if (!(UdXZuDokmBJTcRvleYeoFvgkJfvr <= 0f))
				{
					XabOdculMFIueaGTmhxgUUKxqYflA = hpgfEvUYIAniQFSxDDpoXXFRVDNh.SeqvEgllFcYfioUgpBOnFeaUImqGA;
					lQfBOMAAuUwsdEqWUHiedBzCurTRB = LJvpobKSAwEwVFnZeCsPkLPxxOwo.KRLNtmRUhUuqiISMSeEuqNoiEgit(XabOdculMFIueaGTmhxgUUKxqYflA, ZYdFuWaNiOTQrrdnropIQITQHdgOA);
					float magnitude = (VnGftuzFcDtrUjjpfiXEUQIGXPrn - lQfBOMAAuUwsdEqWUHiedBzCurTRB).magnitude;
					if (!(magnitude < 0.01f))
					{
						hpgfEvUYIAniQFSxDDpoXXFRVDNh.YFYgdjIQemfeVQNtCLRWDXVvaBQIA = true;
						NHYBNPjSNluBRJcWKQgwSQRQtykP = magnitude / UdXZuDokmBJTcRvleYeoFvgkJfvr;
						GqTiFOrSPEgiaPzjRyXtjUWonZSj = 0f;
						goto IL_010c;
					}
				}
				goto IL_0119;
				IL_0119:
				hpgfEvUYIAniQFSxDDpoXXFRVDNh.vUKNXXoHkNibzDlFQTfnMsNKoqjI(eboaTcpxlHgBkKvTNfJrRQUCJFPf, VnGftuzFcDtrUjjpfiXEUQIGXPrn, ZYdFuWaNiOTQrrdnropIQITQHdgOA);
				return false;
				IL_010c:
				if (GqTiFOrSPEgiaPzjRyXtjUWonZSj <= 1f)
				{
					GqTiFOrSPEgiaPzjRyXtjUWonZSj += Time.unscaledDeltaTime / NHYBNPjSNluBRJcWKQgwSQRQtykP;
					LJvpobKSAwEwVFnZeCsPkLPxxOwo.BOaYZWscbxOwRlciicbcqDWEfYAx(XabOdculMFIueaGTmhxgUUKxqYflA, Vector2.Lerp(lQfBOMAAuUwsdEqWUHiedBzCurTRB, VnGftuzFcDtrUjjpfiXEUQIGXPrn, Mathf.SmoothStep(0f, 1f, GqTiFOrSPEgiaPzjRyXtjUWonZSj)), ZYdFuWaNiOTQrrdnropIQITQHdgOA);
					JohbssfqOHPiHJIVGTSlqaoCTRhpA = null;
					jOSlPWWrBZMigKvMBZNbCIQwrTob = 1;
					return true;
				}
				goto IL_0119;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		private const float sTUYGZmsoZhwhNMlCfmtCzQmOVLL = 20f;

		[Tooltip("The Custom Controller element that will receive input values from this control.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _targetCustomControllerElement = new CustomControllerElementTargetSetForFloat(new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		}));

		[Tooltip("The type of button.\nStandard: A momentary switch. Returns True while the button is pressed down.\nToggle Switch: Alternately turns on and off with each press.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonType _buttonType;

		[Tooltip("If true, the button can be turned on by a touch swipe that began in an area outside the button region. If false, the button can only be turned on by a direct press.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _activateOnSwipeIn;

		[Tooltip("If true, the button will stay on even if the touch that activated it moves outside the button region. If false, the button will turn off once the touch that activated it moves outside the button region.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _stayActiveOnSwipeOut = true;

		[Tooltip("Makes the axis value gradually change over time based on gravity and sensitivity as the button is pressed.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useDigitalAxisSimulation;

		[Tooltip("Speed (units/sec) that the axis value falls toward 0 when not pressed. A value of 1.0 means an axis value of 1 will drain to 0 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisGravity = 3f;

		[Tooltip("Speed to move toward an axis value of 1.0 in units/sec when pressed. A value of 1.0 means an axis value of 0 will reach 1 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisSensitivity = 3f;

		[Tooltip("The internal axis of the button. The axis is used for all value calculations.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis _axis = new StandaloneAxis();

		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the button's RectTransform. This can be useful if you want a larger area of the screen to act as a button.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchRegion _touchRegion;

		[Tooltip("If True, hovers/clicks/touches on the local button will be ignored and only Touch Region touches will be used. Otherwise, both touches on the button and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useTouchRegionOnly = true;

		[Tooltip("If True, the button will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a button and have the button graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _moveToTouchPosition;

		[Tooltip("If Move To Touch Position is enabled, this will make the button return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _returnOnRelease = true;

		[Tooltip("If True, the button will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _followTouchPosition;

		[Tooltip("Should the button animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnMoveToTouch = true;

		[Tooltip("The speed at which the button will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _moveToTouchSpeed = 2f;

		[Tooltip("Should the button animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnReturn = true;

		[Tooltip("The speed at which the button will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _returnSpeed = 2f;

		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _manageRaycasting = true;

		private float qwVmdjPQqPHSNPlpBeiHGKcXYJeVA;

		private float frQeYsjksKXigASZRKnfHbveBwWy;

		private TouchRegion JVnKKwGrjPEPUgagLfLrxcVglmYb;

		private Vector2 TVODKodAKwjCfzJgHhkSvtjZnrOVA;

		private bool YFYgdjIQemfeVQNtCLRWDXVvaBQIA;

		private bool yWRHpQmqZJaxmgfOgGUEexFqwwRjA;

		private phxNRzzCOfwAprEuEEPzkNyqysai kNUpwayLVbHxwQYaJxfgNgbSIttIA;

		private int jOOxQOthkOknziiSKjcPirghPxjV = int.MinValue;

		private int MwUbDUHcovaasUWMOuqrWTUHzYaV = int.MinValue;

		[NonSerialized]
		private bool YaukUGOCpMBqTUvjzTAhGtzAbzUT;

		[NonSerialized]
		private bool yBznAsIGvtvRxhBcRwVsWIunqnav;

		private IEnumerator JvHUtOEcXfKPbvTggHCbaFaxzwlv;

		private HzVIQCREYHZKnIVBMAJjqUnIsmmT nmIGajFRLlnpTvJGxVTkSpXhDFtgb = new HzVIQCREYHZKnIVBMAJjqUnIsmmT();

		private Action<phxNRzzCOfwAprEuEEPzkNyqysai> CvHRJJsNpMeAWgGgShXiidbUVGfvA;

		private Action<phxNRzzCOfwAprEuEEPzkNyqysai> AbsYDmWOYVCkIRDFzvBiHdKTZLYb;

		[Tooltip("Event sent when the axis value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisValueChangedEventHandler _onAxisValueChanged = new AxisValueChangedEventHandler();

		[Tooltip("Event sent when the button value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonValueChangedEventHandler _onButtonValueChanged = new ButtonValueChangedEventHandler();

		[Tooltip("Event sent when the button is pressed.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonDownEventHandler _onButtonDown = new ButtonDownEventHandler();

		[Tooltip("Event sent when the button is released.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonUpEventHandler _onButtonUp = new ButtonUpEventHandler();

		private Dictionary<int, PointerEventData> fqbYZmwJQwCktacOtjTImmPZNCyn;

		public CustomControllerElementTargetSetForFloat targetCustomControllerElement => _targetCustomControllerElement;

		public ButtonType buttonType
		{
			get
			{
				return _buttonType;
			}
			set
			{
				if (_buttonType != value)
				{
					_buttonType = value;
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public bool activateOnSwipeIn
		{
			get
			{
				return _activateOnSwipeIn;
			}
			set
			{
				if (_activateOnSwipeIn != value)
				{
					_activateOnSwipeIn = value;
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (NLBcJmjxdvJPwgPIwoMICRQlmXTnA())
				{
					return true;
				}
				return _stayActiveOnSwipeOut;
			}
			set
			{
				if (_stayActiveOnSwipeOut != value)
				{
					_stayActiveOnSwipeOut = value;
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public bool useDigitalAxisSimulation
		{
			get
			{
				return _useDigitalAxisSimulation;
			}
			set
			{
				if (_useDigitalAxisSimulation != value)
				{
					_useDigitalAxisSimulation = value;
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public float digitalAxisGravity
		{
			get
			{
				return _digitalAxisGravity;
			}
			set
			{
				if (_digitalAxisGravity != value)
				{
					_digitalAxisGravity = value;
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public float digitalAxisSensitivity
		{
			get
			{
				return _digitalAxisSensitivity;
			}
			set
			{
				if (_digitalAxisSensitivity != value)
				{
					_digitalAxisSensitivity = value;
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public TouchRegion touchRegion
		{
			get
			{
				return _touchRegion;
			}
			set
			{
				if (!(_touchRegion == value))
				{
					_touchRegion = value;
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public bool useTouchRegionOnly
		{
			get
			{
				return _useTouchRegionOnly;
			}
			set
			{
				if (_useTouchRegionOnly != value)
				{
					_useTouchRegionOnly = value;
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public bool moveToTouchPosition
		{
			get
			{
				return _moveToTouchPosition;
			}
			set
			{
				if (_moveToTouchPosition != value)
				{
					_moveToTouchPosition = value;
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public bool returnOnRelease
		{
			get
			{
				return _returnOnRelease;
			}
			set
			{
				if (_returnOnRelease != value)
				{
					_returnOnRelease = value;
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public bool followTouchPosition
		{
			get
			{
				return _followTouchPosition;
			}
			set
			{
				if (_followTouchPosition != value)
				{
					_followTouchPosition = value;
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public bool animateOnMoveToTouch
		{
			get
			{
				return _animateOnMoveToTouch;
			}
			set
			{
				if (_animateOnMoveToTouch != value)
				{
					_animateOnMoveToTouch = value;
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public float moveToTouchSpeed
		{
			get
			{
				return _moveToTouchSpeed;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, 20f);
				if (_moveToTouchSpeed != value)
				{
					_moveToTouchSpeed = value;
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public bool animateOnReturn
		{
			get
			{
				return _animateOnReturn;
			}
			set
			{
				if (_animateOnReturn != value)
				{
					_animateOnReturn = value;
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public float returnSpeed
		{
			get
			{
				return _returnSpeed;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, 20f);
				if (_returnSpeed != value)
				{
					_returnSpeed = value;
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public bool manageRaycasting
		{
			get
			{
				return _manageRaycasting;
			}
			set
			{
				if (_manageRaycasting != value)
				{
					_manageRaycasting = value;
					if (value)
					{
						DXyTdYrIgUEJnEPjrXtIJUgAxshiA();
					}
					else
					{
						nmIGajFRLlnpTvJGxVTkSpXhDFtgb.BPLLZVQfnDZCnQzmgiGmwLcmmkgm();
					}
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public int pointerId
		{
			get
			{
				return jOOxQOthkOknziiSKjcPirghPxjV;
			}
			set
			{
				jOOxQOthkOknziiSKjcPirghPxjV = value;
			}
		}

		public bool hasPointer => jOOxQOthkOknziiSKjcPirghPxjV != int.MinValue;

		internal StandaloneAxis axis => _axis;

		private Action<phxNRzzCOfwAprEuEEPzkNyqysai> moveStartedDelegate
		{
			get
			{
				if (CvHRJJsNpMeAWgGgShXiidbUVGfvA == null)
				{
					return CvHRJJsNpMeAWgGgShXiidbUVGfvA = CsusTlZfLfehUdKsSEFMxvnOhhWm;
				}
				return CvHRJJsNpMeAWgGgShXiidbUVGfvA;
			}
		}

		private Action<phxNRzzCOfwAprEuEEPzkNyqysai> moveEndedDelegate
		{
			get
			{
				if (AbsYDmWOYVCkIRDFzvBiHdKTZLYb == null)
				{
					return AbsYDmWOYVCkIRDFzvBiHdKTZLYb = ARBmmrRanoxleYVXCpHmqSagYqqG;
				}
				return AbsYDmWOYVCkIRDFzvBiHdKTZLYb;
			}
		}

		private float axisValue
		{
			get
			{
				if (!_useDigitalAxisSimulation)
				{
					return _axis.value;
				}
				return qwVmdjPQqPHSNPlpBeiHGKcXYJeVA;
			}
		}

		private float axisValuePrev
		{
			get
			{
				if (!_useDigitalAxisSimulation)
				{
					return _axis.valuePrev;
				}
				return frQeYsjksKXigASZRKnfHbveBwWy;
			}
		}

		private bool buttonValue => _axis.buttonValue;

		private bool buttonValuePrev => _axis.buttonValuePrev;

		private int effectivePointerId
		{
			get
			{
				if (jOOxQOthkOknziiSKjcPirghPxjV == int.MinValue)
				{
					return int.MinValue;
				}
				if (MwUbDUHcovaasUWMOuqrWTUHzYaV != int.MinValue)
				{
					return MwUbDUHcovaasUWMOuqrWTUHzYaV;
				}
				return jOOxQOthkOknziiSKjcPirghPxjV;
			}
		}

		public event UnityAction<float> AxisValueChangedEvent
		{
			add
			{
				_onAxisValueChanged.AddListener(value);
			}
			remove
			{
				_onAxisValueChanged.RemoveListener(value);
			}
		}

		public event UnityAction<bool> ButtonValueChangedEvent
		{
			add
			{
				_onButtonValueChanged.AddListener(value);
			}
			remove
			{
				_onButtonValueChanged.RemoveListener(value);
			}
		}

		public event UnityAction ButtonDownEvent
		{
			add
			{
				_onButtonDown.AddListener(value);
			}
			remove
			{
				_onButtonDown.RemoveListener(value);
			}
		}

		public event UnityAction ButtonUpEvent
		{
			add
			{
				_onButtonUp.AddListener(value);
			}
			remove
			{
				_onButtonUp.RemoveListener(value);
			}
		}

		[CustomObfuscation(rename = false)]
		private TouchButton()
		{
		}

		public void SetRawValue(float value)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				_axis.SetRawValue(value);
			}
		}

		public void SetDefaultPosition()
		{
			fjDHNsZRrtsquIesdVkLrLnXIaHdA(base.SeqvEgllFcYfioUgpBOnFeaUImqGA.anchoredPosition);
		}

		private void fjDHNsZRrtsquIesdVkLrLnXIaHdA(Vector2 P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				TVODKodAKwjCfzJgHhkSvtjZnrOVA = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				SQjZnVlCuUekQtSaJIvgqMGsJRjo(TVODKodAKwjCfzJgHhkSvtjZnrOVA, PositionType.Anchored, !instant && _animateOnReturn, _returnSpeed, phxNRzzCOfwAprEuEEPzkNyqysai.TowardHome);
			}
		}

		public void ReturnToDefaultPosition()
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				ReturnToDefaultPosition(instant: false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
			base.Awake();
			if (Application.isPlaying)
			{
				TVODKodAKwjCfzJgHhkSvtjZnrOVA = base.SeqvEgllFcYfioUgpBOnFeaUImqGA.anchoredPosition;
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				nMbUSjqRvMXOhIUBOhmbYPNbeahb();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				prOtrdqYwZXkFcvprrpMujpofLsg();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				nMbUSjqRvMXOhIUBOhmbYPNbeahb();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void Reset()
		{
			base.Reset();
			base.transitionType = TransitionTypeFlags.ColorTint;
		}

		internal void OnUpdate()
		{
			base.XadwAoSmPfgqpkILfIkgfANXfddcb();
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				VLsyYMBXoOoRXQIDiAudVEUfGOju();
				zNZOrcouAuDWwxcaAYTZvbQvwtKo();
				sLWUnapfhzKueZZudTByXhDmvRdQ();
				if (_followTouchPosition)
				{
					kLKABNHwXeHqCAbVxcJNhZgSKGMR(effectivePointerId);
				}
			}
		}

		internal bool OnInitialize()
		{
			if (!iedDOxkjfTrhublJdsoBBYzPiizQA())
			{
				return false;
			}
			return true;
		}

		internal void OnCustomControllerUpdate()
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && fWzcsqpjMiHugIFEsnxLnuyMnmGF)
			{
				BBGcGGKBcUWfsejCFzcKGieWiGAc(_targetCustomControllerElement, axisValue, _axis.buttonActivationThreshold);
			}
		}

		internal void OnSubscribeEvents()
		{
			VoyGgLGiGTrtcFKALFAAsPOudnYcb();
			_axis.AxisValueChangedEvent += fWCJlacETVgzITONqKlLQvIFuKWl;
			_axis.ButtonValueChangedEvent += tMPDtvkAMRPLxGloaoABthnuMdJMB;
			_axis.ButtonDownEvent += ECEtZHooVDQNiqgTdCnkffNCSJKS;
			_axis.ButtonUpEvent += aLDGiBCxzncHsSGMcMzUIpSUwwsLA;
		}

		internal void OnUnsubscribeEvents()
		{
			mKKrHnZUpVCHPdRTGsFNRlarfpEJ();
			_axis.AxisValueChangedEvent -= fWCJlacETVgzITONqKlLQvIFuKWl;
			_axis.ButtonValueChangedEvent -= tMPDtvkAMRPLxGloaoABthnuMdJMB;
			_axis.ButtonDownEvent -= ECEtZHooVDQNiqgTdCnkffNCSJKS;
			_axis.ButtonUpEvent -= aLDGiBCxzncHsSGMcMzUIpSUwwsLA;
		}

		internal void OnSetProperty()
		{
			MXkwbfQjWFfLiAPyzgGSCyXlFhQW();
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				nMbUSjqRvMXOhIUBOhmbYPNbeahb();
			}
		}

		internal void OnClear()
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				jOOxQOthkOknziiSKjcPirghPxjV = int.MinValue;
				MwUbDUHcovaasUWMOuqrWTUHzYaV = int.MinValue;
				YaukUGOCpMBqTUvjzTAhGtzAbzUT = false;
				yBznAsIGvtvRxhBcRwVsWIunqnav = false;
				if (_returnOnRelease && yWRHpQmqZJaxmgfOgGUEexFqwwRjA && (_moveToTouchPosition || _followTouchPosition))
				{
					ReturnToDefaultPosition(instant: true);
				}
				yWRHpQmqZJaxmgfOgGUEexFqwwRjA = false;
				YFYgdjIQemfeVQNtCLRWDXVvaBQIA = false;
				kNUpwayLVbHxwQYaJxfgNgbSIttIA = phxNRzzCOfwAprEuEEPzkNyqysai.None;
				eFEHUVlvDvxFzDWmdhXRKZtPDxOB();
				_axis.Clear();
				qwVmdjPQqPHSNPlpBeiHGKcXYJeVA = 0f;
				frQeYsjksKXigASZRKnfHbveBwWy = 0f;
				nMbUSjqRvMXOhIUBOhmbYPNbeahb();
			}
		}

		public override void ClearValue()
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				_axis.Clear();
				qwVmdjPQqPHSNPlpBeiHGKcXYJeVA = 0f;
				if (fWzcsqpjMiHugIFEsnxLnuyMnmGF)
				{
					base.HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.ClearElementValue(_targetCustomControllerElement);
				}
			}
		}

		internal bool IsPressed()
		{
			if (!base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				return false;
			}
			if (!PBRHZQINZfANWEOTugUlepRFdGfJ())
			{
				return false;
			}
			if (!_axis.buttonValue)
			{
				return _axis.value != 0f;
			}
			return true;
		}

		internal bool IsThisOrTouchRegionGameObject(GameObject gameObject)
		{
			if (gameObject == null)
			{
				return false;
			}
			if (base.plvFFPdzUNOHagtCgfoabMDAVjXWB(gameObject))
			{
				return true;
			}
			if (JVnKKwGrjPEPUgagLfLrxcVglmYb != null)
			{
				return JVnKKwGrjPEPUgagLfLrxcVglmYb.gameObject == gameObject;
			}
			return false;
		}

		private void sLWUnapfhzKueZZudTByXhDmvRdQ()
		{
			if (_useDigitalAxisSimulation)
			{
				if (_axis.buttonValue)
				{
					jNNsprqDtfeigxCwxWylBkLbHjfP();
				}
				else
				{
					woYUSjDipOOQRmAPOfPJQdIkhBsx();
				}
			}
		}

		private void jNNsprqDtfeigxCwxWylBkLbHjfP()
		{
			float num = ((_axis.value >= 0f) ? 1f : (-1f));
			float num2 = MathTools.Abs(_digitalAxisSensitivity);
			num *= num2 * Time.unscaledDeltaTime;
			num += qwVmdjPQqPHSNPlpBeiHGKcXYJeVA;
			num = MathTools.Clamp(num, -1f, 1f);
			VwtFvpcbfTEUpIWgilGrcEDcdNCJA(num, true);
		}

		private void woYUSjDipOOQRmAPOfPJQdIkhBsx()
		{
			float num = _digitalAxisGravity;
			if (num == 0f)
			{
				return;
			}
			float num2 = qwVmdjPQqPHSNPlpBeiHGKcXYJeVA;
			if (num2 != 0f)
			{
				float num3 = num * Time.unscaledDeltaTime;
				float num4;
				if (MathTools.Abs(num3) >= MathTools.Abs(num2))
				{
					num4 = 0f;
				}
				else
				{
					float num5 = ((num2 > 0f) ? (-1f) : 1f);
					num4 = num2 + num5 * num3;
				}
				VwtFvpcbfTEUpIWgilGrcEDcdNCJA(num4, true);
			}
		}

		private void VwtFvpcbfTEUpIWgilGrcEDcdNCJA(float P_0, bool P_1)
		{
			frQeYsjksKXigASZRKnfHbveBwWy = qwVmdjPQqPHSNPlpBeiHGKcXYJeVA;
			qwVmdjPQqPHSNPlpBeiHGKcXYJeVA = P_0;
			if (P_0 != frQeYsjksKXigASZRKnfHbveBwWy)
			{
				mqqgsskRuzXjTAiWvEdJawWAQYEob(null);
			}
			if (P_1 && P_0 != frQeYsjksKXigASZRKnfHbveBwWy)
			{
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void ttWZREZFUZfaAwqDHFkwwrKtafIFA()
		{
			if (_buttonType == ButtonType.ToggleSwitch)
			{
				if (buttonValue)
				{
					_axis.SetRawValue(_axis.rawZero);
				}
				else
				{
					_axis.SetRawValue(_axis.rawMax);
				}
			}
			else if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawMax);
			}
		}

		private void JsEAaeGmmTNhSDiMCTwFbFIhkhqaA()
		{
			if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawZero);
			}
		}

		private void nMbUSjqRvMXOhIUBOhmbYPNbeahb()
		{
			_targetCustomControllerElement.ClearElementCaches();
			zNZOrcouAuDWwxcaAYTZvbQvwtKo();
			DXyTdYrIgUEJnEPjrXtIJUgAxshiA();
		}

		private void DXyTdYrIgUEJnEPjrXtIJUgAxshiA()
		{
			if (_manageRaycasting)
			{
				nmIGajFRLlnpTvJGxVTkSpXhDFtgb.mCVECeXIEnTqWyaJNBwKcguewsyPA(base.transform, RhWsrbPreQbMmDkREOloUEvAxpXZ());
			}
		}

		private bool RhWsrbPreQbMmDkREOloUEvAxpXZ()
		{
			if (JVnKKwGrjPEPUgagLfLrxcVglmYb != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void mhQzGutOYIHtpvXotXEBeNvuMfdG(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				lhrAkblnAsvSgpqepcKTJOujQamsA(P_0);
				P_0.PointerDownEvent += FuwAGVVwsYsyLJgzuCLJakyOarEDA;
				P_0.PointerUpEvent += pIDBnkITBpggYhbONAaayVSXDfTHb;
				P_0.PointerEnterEvent += EARFXiFFZBbQDfjogrsWRNtpywxhB;
				P_0.PointerExitEvent += oMHFDmaSnamohnbawBYzKKNNECcW;
			}
		}

		private void lhrAkblnAsvSgpqepcKTJOujQamsA(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				P_0.PointerDownEvent -= FuwAGVVwsYsyLJgzuCLJakyOarEDA;
				P_0.PointerUpEvent -= pIDBnkITBpggYhbONAaayVSXDfTHb;
				P_0.PointerEnterEvent -= EARFXiFFZBbQDfjogrsWRNtpywxhB;
				P_0.PointerExitEvent -= oMHFDmaSnamohnbawBYzKKNNECcW;
			}
		}

		private void zNZOrcouAuDWwxcaAYTZvbQvwtKo()
		{
			if (!(JVnKKwGrjPEPUgagLfLrxcVglmYb == _touchRegion))
			{
				lhrAkblnAsvSgpqepcKTJOujQamsA(JVnKKwGrjPEPUgagLfLrxcVglmYb);
				JVnKKwGrjPEPUgagLfLrxcVglmYb = _touchRegion;
				mhQzGutOYIHtpvXotXEBeNvuMfdG(JVnKKwGrjPEPUgagLfLrxcVglmYb);
			}
		}

		private void lZaCPiGMjFzXbKpKGrVDLCpBcfFZA(Vector2 P_0, bool P_1, float P_2, phxNRzzCOfwAprEuEEPzkNyqysai P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = LJvpobKSAwEwVFnZeCsPkLPxxOwo.NmUvLnIKPPRNPnVYBPVVdtFTLjNy(base.uupfWdcRYmQCktvgNQvwZsMtFvqy, rectTransform, P_0);
			Vector2 pivot = base.SeqvEgllFcYfioUgpBOnFeaUImqGA.pivot;
			Vector2 sizeDelta = base.SeqvEgllFcYfioUgpBOnFeaUImqGA.sizeDelta;
			Vector3 localScale = base.SeqvEgllFcYfioUgpBOnFeaUImqGA.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			SQjZnVlCuUekQtSaJIvgqMGsJRjo(vector, PositionType.Local, P_1, P_2, P_3);
		}

		private void SQjZnVlCuUekQtSaJIvgqMGsJRjo(Vector2 P_0, PositionType P_1, bool P_2, float P_3, phxNRzzCOfwAprEuEEPzkNyqysai P_4)
		{
			if (YFYgdjIQemfeVQNtCLRWDXVvaBQIA && P_2 && kNUpwayLVbHxwQYaJxfgNgbSIttIA == P_4)
			{
				return;
			}
			if (YFYgdjIQemfeVQNtCLRWDXVvaBQIA && JvHUtOEcXfKPbvTggHCbaFaxzwlv != null)
			{
				eFEHUVlvDvxFzDWmdhXRKZtPDxOB();
				YFYgdjIQemfeVQNtCLRWDXVvaBQIA = false;
				kNUpwayLVbHxwQYaJxfgNgbSIttIA = phxNRzzCOfwAprEuEEPzkNyqysai.None;
			}
			if (base.uupfWdcRYmQCktvgNQvwZsMtFvqy == null)
			{
				Logger.LogWarning("Animation cannot be used without a Canvas.");
				P_2 = false;
			}
			else if (base.uupfWdcRYmQCktvgNQvwZsMtFvqy.renderMode == RenderMode.WorldSpace)
			{
				Logger.LogWarning("Animation can only be used with a screen space Canvas.");
				P_2 = false;
			}
			if (P_2)
			{
				Transform parent = base.transform;
				RectTransform rectTransform = base.vCJGjqsSTOYxIOmvZHZOSVVpifrv;
				Vector2 one = Vector2.one;
				while ((parent = parent.parent) != rectTransform && !(parent == null))
				{
					one.x *= parent.localScale.x;
					one.y *= parent.localScale.y;
				}
				Vector2 sizeDelta = rectTransform.sizeDelta;
				bool num = sizeDelta.x < sizeDelta.y;
				float num2 = MathTools.Max(sizeDelta.x, sizeDelta.y);
				float num3 = (num ? one.y : one.x);
				if (num3 == 0f)
				{
					num3 = 0.0001f;
				}
				P_3 = P_3 / num3 * num2;
				JvHUtOEcXfKPbvTggHCbaFaxzwlv = xNcNMAuOmjpBEOXeeZqQpblZiqmU(P_0, P_1, P_3, P_4);
				StartCoroutine(JvHUtOEcXfKPbvTggHCbaFaxzwlv);
				kNUpwayLVbHxwQYaJxfgNgbSIttIA = P_4;
				yWRHpQmqZJaxmgfOgGUEexFqwwRjA = true;
				moveStartedDelegate(P_4);
			}
			else
			{
				moveStartedDelegate(P_4);
				vUKNXXoHkNibzDlFQTfnMsNKoqjI(P_4, P_0, P_1);
			}
		}

		[IteratorStateMachine(typeof(tylpSzSWzqXnMKKiVEuamMHPfTYI))]
		private IEnumerator xNcNMAuOmjpBEOXeeZqQpblZiqmU(Vector2 P_0, PositionType P_1, float P_2, phxNRzzCOfwAprEuEEPzkNyqysai P_3)
		{
			return new tylpSzSWzqXnMKKiVEuamMHPfTYI(0)
			{
				HpgfEvUYIAniQFSxDDpoXXFRVDNh = this,
				VnGftuzFcDtrUjjpfiXEUQIGXPrn = P_0,
				ZYdFuWaNiOTQrrdnropIQITQHdgOA = P_1,
				UdXZuDokmBJTcRvleYeoFvgkJfvr = P_2,
				eboaTcpxlHgBkKvTNfJrRQUCJFPf = P_3
			};
		}

		private void vUKNXXoHkNibzDlFQTfnMsNKoqjI(phxNRzzCOfwAprEuEEPzkNyqysai P_0, Vector2 P_1, PositionType P_2)
		{
			LJvpobKSAwEwVFnZeCsPkLPxxOwo.BOaYZWscbxOwRlciicbcqDWEfYAx(base.SeqvEgllFcYfioUgpBOnFeaUImqGA, P_1, P_2);
			YFYgdjIQemfeVQNtCLRWDXVvaBQIA = false;
			kNUpwayLVbHxwQYaJxfgNgbSIttIA = phxNRzzCOfwAprEuEEPzkNyqysai.None;
			switch (P_0)
			{
			case phxNRzzCOfwAprEuEEPzkNyqysai.TowardHome:
				yWRHpQmqZJaxmgfOgGUEexFqwwRjA = false;
				break;
			case phxNRzzCOfwAprEuEEPzkNyqysai.TowardTouch:
				yWRHpQmqZJaxmgfOgGUEexFqwwRjA = true;
				break;
			}
			eFEHUVlvDvxFzDWmdhXRKZtPDxOB();
			moveEndedDelegate(P_0);
		}

		private void CsusTlZfLfehUdKsSEFMxvnOhhWm(phxNRzzCOfwAprEuEEPzkNyqysai P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && JVnKKwGrjPEPUgagLfLrxcVglmYb != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == phxNRzzCOfwAprEuEEPzkNyqysai.TowardTouch)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					nmIGajFRLlnpTvJGxVTkSpXhDFtgb.mCVECeXIEnTqWyaJNBwKcguewsyPA(base.transform, flag2);
				}
			}
		}

		private void ARBmmrRanoxleYVXCpHmqSagYqqG(phxNRzzCOfwAprEuEEPzkNyqysai P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && JVnKKwGrjPEPUgagLfLrxcVglmYb != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == phxNRzzCOfwAprEuEEPzkNyqysai.TowardHome)
				{
					flag = true;
					flag2 = RhWsrbPreQbMmDkREOloUEvAxpXZ();
				}
				if (flag)
				{
					nmIGajFRLlnpTvJGxVTkSpXhDFtgb.mCVECeXIEnTqWyaJNBwKcguewsyPA(base.transform, flag2);
				}
			}
		}

		private void kLKABNHwXeHqCAbVxcJNhZgSKGMR(int P_0)
		{
			if (TouchInteractable.HSdHFEwTqLmljSAXMrqWISAaJUgd(P_0))
			{
				lZaCPiGMjFzXbKpKGrVDLCpBcfFZA(TouchInteractable.GRqXcYGMGEOcqtDjGIZnCAiUOlaGA(P_0), false, 0f, phxNRzzCOfwAprEuEEPzkNyqysai.TowardTouch);
			}
		}

		private void eFEHUVlvDvxFzDWmdhXRKZtPDxOB()
		{
			if (JvHUtOEcXfKPbvTggHCbaFaxzwlv != null)
			{
				try
				{
					StopCoroutine(JvHUtOEcXfKPbvTggHCbaFaxzwlv);
				}
				catch
				{
				}
				JvHUtOEcXfKPbvTggHCbaFaxzwlv = null;
			}
		}

		private void VLsyYMBXoOoRXQIDiAudVEUfGOju()
		{
			if (hasPointer && !TouchInteractable.HSdHFEwTqLmljSAXMrqWISAaJUgd(effectivePointerId))
			{
				PointerEventData pointerEventData = nVidIJgvXJIbZCmXALQmbeoeLmgFb(effectivePointerId);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					YEyTxeCeEngYCgrzxdmwhXRepDMeB(pointerEventData);
				}
				else
				{
					OHeMbKqdETZZFFpJRVvyGzIouWpg();
				}
			}
		}

		private bool NLBcJmjxdvJPwgPIwoMICRQlmXTnA()
		{
			if (!_followTouchPosition)
			{
				return false;
			}
			if (_touchRegion != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void VmzAmCBMIqyiITAlatZWFviQNRHPA()
		{
			jOOxQOthkOknziiSKjcPirghPxjV = int.MinValue;
			MwUbDUHcovaasUWMOuqrWTUHzYaV = int.MinValue;
		}

		private bool OeeHnigGBNstPmQUJMmDbinFTeDt(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (jOOxQOthkOknziiSKjcPirghPxjV == int.MinValue)
			{
				return false;
			}
			if (jOOxQOthkOknziiSKjcPirghPxjV == P_0)
			{
				return true;
			}
			if (TouchInteractable.vYPGbuTavXEIDJeeAuBdpuxoOPlc(P_0) && MwUbDUHcovaasUWMOuqrWTUHzYaV != int.MinValue && P_0 == MwUbDUHcovaasUWMOuqrWTUHzYaV)
			{
				return true;
			}
			return false;
		}

		private PointerEventData XWtHpfqFCQgSYcQaxBoOkeheAxDZ(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = nVidIJgvXJIbZCmXALQmbeoeLmgFb(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.GRqXcYGMGEOcqtDjGIZnCAiUOlaGA(P_0);
			if (TouchInteractable.GIygVOeNjVaVjWDNqzboLLzUBflBA(P_0))
			{
				pointerEventData.eligibleForClick = true;
				pointerEventData.delta = Vector2.zero;
				pointerEventData.dragging = false;
				pointerEventData.useDragThreshold = true;
				pointerEventData.pressPosition = pointerEventData.position;
				pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
				if (pointerEventData.pointerEnter != P_1)
				{
					pointerEventData.pointerEnter = P_1;
				}
				float unscaledTime = Time.unscaledTime;
				if (P_1 == pointerEventData.lastPress)
				{
					if (unscaledTime - pointerEventData.clickTime < 0.3f)
					{
						int clickCount = pointerEventData.clickCount + 1;
						pointerEventData.clickCount = clickCount;
					}
					else
					{
						pointerEventData.clickCount = 1;
					}
					pointerEventData.clickTime = unscaledTime;
				}
				else
				{
					pointerEventData.clickCount = 1;
				}
				pointerEventData.pointerPress = P_1;
				pointerEventData.rawPointerPress = P_1;
				pointerEventData.clickTime = unscaledTime;
				pointerEventData.pointerDrag = P_1;
			}
			else
			{
				if (!TouchInteractable.vYPGbuTavXEIDJeeAuBdpuxoOPlc(P_0))
				{
					Logger.LogWarning("Unsupported pointerId: " + P_0);
					return null;
				}
				pointerEventData.eligibleForClick = true;
				pointerEventData.delta = Vector2.zero;
				pointerEventData.dragging = false;
				pointerEventData.useDragThreshold = true;
				pointerEventData.pressPosition = pointerEventData.position;
				pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
				float unscaledTime2 = Time.unscaledTime;
				if (P_1 == pointerEventData.lastPress)
				{
					if (unscaledTime2 - pointerEventData.clickTime < 0.3f)
					{
						int clickCount = pointerEventData.clickCount + 1;
						pointerEventData.clickCount = clickCount;
					}
					else
					{
						pointerEventData.clickCount = 1;
					}
					pointerEventData.clickTime = unscaledTime2;
				}
				else
				{
					pointerEventData.clickCount = 1;
				}
				pointerEventData.pointerPress = P_1;
				pointerEventData.rawPointerPress = P_1;
				pointerEventData.clickTime = unscaledTime2;
				pointerEventData.pointerDrag = P_1;
			}
			return pointerEventData;
		}

		private PointerEventData QaFPYqKLtIrSdFsxkNjyxqwKXnaC(int P_0)
		{
			PointerEventData pointerEventData = nVidIJgvXJIbZCmXALQmbeoeLmgFb(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.GIygVOeNjVaVjWDNqzboLLzUBflBA(P_0))
			{
				pointerEventData.eligibleForClick = false;
				pointerEventData.pointerPress = null;
				pointerEventData.rawPointerPress = null;
				pointerEventData.dragging = false;
				pointerEventData.pointerDrag = null;
				pointerEventData.pointerEnter = null;
			}
			else
			{
				if (!TouchInteractable.vYPGbuTavXEIDJeeAuBdpuxoOPlc(P_0))
				{
					Logger.LogWarning("Unsupported pointerId: " + P_0);
					return null;
				}
				pointerEventData.eligibleForClick = false;
				pointerEventData.pointerPress = null;
				pointerEventData.rawPointerPress = null;
				pointerEventData.dragging = false;
				pointerEventData.pointerDrag = null;
			}
			return pointerEventData;
		}

		private void YEyTxeCeEngYCgrzxdmwhXRepDMeB(PointerEventData P_0)
		{
			if (P_0 != null)
			{
				OnPointerUp(P_0);
				QaFPYqKLtIrSdFsxkNjyxqwKXnaC(effectivePointerId);
			}
		}

		private PointerEventData nVidIJgvXJIbZCmXALQmbeoeLmgFb(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return null;
			}
			if (fqbYZmwJQwCktacOtjTImmPZNCyn == null)
			{
				fqbYZmwJQwCktacOtjTImmPZNCyn = new Dictionary<int, PointerEventData>();
			}
			if (!fqbYZmwJQwCktacOtjTImmPZNCyn.TryGetValue(P_0, out var value))
			{
				value = new PointerEventData(EventSystem.current);
				value.pointerId = P_0;
				fqbYZmwJQwCktacOtjTImmPZNCyn.Add(P_0, value);
				if (TouchInteractable.vYPGbuTavXEIDJeeAuBdpuxoOPlc(P_0))
				{
					PointerEventData.InputButton button = P_0 switch
					{
						-1 => PointerEventData.InputButton.Left, 
						-2 => PointerEventData.InputButton.Right, 
						-3 => PointerEventData.InputButton.Middle, 
						_ => throw new NotImplementedException(), 
					};
					value.button = button;
				}
			}
			return value;
		}

		private void PZRHRcVCKVJrzxWRZWybdFpOskRM(PointerEventData P_0, hCrsuvqVPqbUhmJeFMlGylBfrAap P_1)
		{
			if (!hasPointer || OeeHnigGBNstPmQUJMmDbinFTeDt(P_0.pointerId))
			{
				if (PBRHZQINZfANWEOTugUlepRFdGfJ() && IsInteractable())
				{
					xuXAkebBQdqeswErJDNFCRGWMEHL(P_0.pointerId, P_0.pressPosition, P_1);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void QGjfOYDYPfHrYLwhEDdkrIyePAEs(PointerEventData P_0, hCrsuvqVPqbUhmJeFMlGylBfrAap P_1)
		{
			if ((!hasPointer || OeeHnigGBNstPmQUJMmDbinFTeDt(P_0.pointerId)) && !TouchInteractable.HSdHFEwTqLmljSAXMrqWISAaJUgd(effectivePointerId))
			{
				OHeMbKqdETZZFFpJRVvyGzIouWpg();
				base.OnPointerUp(P_0);
			}
		}

		private void qmxMlNqXWObFaXGTOTLwyUdqlEEx(PointerEventData P_0, hCrsuvqVPqbUhmJeFMlGylBfrAap P_1)
		{
			if (hasPointer && !OeeHnigGBNstPmQUJMmDbinFTeDt(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.vYPGbuTavXEIDJeeAuBdpuxoOPlc(P_0.pointerId);
			bool flag2 = false;
			MouseButtonFlags mouseButtonFlags = P_1 switch
			{
				hCrsuvqVPqbUhmJeFMlGylBfrAap.Local => base.allowedMouseButtons, 
				hCrsuvqVPqbUhmJeFMlGylBfrAap.TouchRegion => _touchRegion.allowedMouseButtons, 
				_ => throw new NotImplementedException(), 
			};
			if (_activateOnSwipeIn && PBRHZQINZfANWEOTugUlepRFdGfJ() && IsInteractable() && (!flag || TouchInteractable.tblDrhtvhdTFJgWkleujTILlbVxu(mouseButtonFlags)) && !YaukUGOCpMBqTUvjzTAhGtzAbzUT)
			{
				if (flag)
				{
					if (TouchInteractable.ilvBBLoOJPAulAFbbfMMVlRblJpFb(mouseButtonFlags, out var mwUbDUHcovaasUWMOuqrWTUHzYaV))
					{
						MwUbDUHcovaasUWMOuqrWTUHzYaV = mwUbDUHcovaasUWMOuqrWTUHzYaV;
					}
					else
					{
						MwUbDUHcovaasUWMOuqrWTUHzYaV = P_0.pointerId;
					}
				}
				flag2 = true;
			}
			base.OnPointerEnter(P_0);
			if (flag2)
			{
				GameObject gameObject = P_1 switch
				{
					hCrsuvqVPqbUhmJeFMlGylBfrAap.Local => base.gameObject, 
					hCrsuvqVPqbUhmJeFMlGylBfrAap.TouchRegion => JVnKKwGrjPEPUgagLfLrxcVglmYb.gameObject, 
					_ => throw new NotImplementedException(), 
				};
				PointerEventData pointerEventData = XWtHpfqFCQgSYcQaxBoOkeheAxDZ((MwUbDUHcovaasUWMOuqrWTUHzYaV != int.MinValue) ? MwUbDUHcovaasUWMOuqrWTUHzYaV : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					PZRHRcVCKVJrzxWRZWybdFpOskRM(pointerEventData, P_1);
				}
			}
			yBznAsIGvtvRxhBcRwVsWIunqnav = true;
		}

		private void baiNWFoDvppwCPElpfaMJrPXJAEK(PointerEventData P_0, hCrsuvqVPqbUhmJeFMlGylBfrAap P_1)
		{
			if (hasPointer && !OeeHnigGBNstPmQUJMmDbinFTeDt(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			if (!stayActiveOnSwipeOut && YaukUGOCpMBqTUvjzTAhGtzAbzUT)
			{
				OHeMbKqdETZZFFpJRVvyGzIouWpg();
			}
			base.OnPointerExit(P_0);
			yBznAsIGvtvRxhBcRwVsWIunqnav = false;
		}

		private void xuXAkebBQdqeswErJDNFCRGWMEHL(int P_0, Vector2 P_1, hCrsuvqVPqbUhmJeFMlGylBfrAap P_2)
		{
			jOOxQOthkOknziiSKjcPirghPxjV = P_0;
			YaukUGOCpMBqTUvjzTAhGtzAbzUT = true;
			if (_followTouchPosition)
			{
				kLKABNHwXeHqCAbVxcJNhZgSKGMR(P_0);
			}
			else if (P_2 == hCrsuvqVPqbUhmJeFMlGylBfrAap.TouchRegion && _moveToTouchPosition)
			{
				lZaCPiGMjFzXbKpKGrVDLCpBcfFZA(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, phxNRzzCOfwAprEuEEPzkNyqysai.TowardTouch);
			}
			ttWZREZFUZfaAwqDHFkwwrKtafIFA();
		}

		private void OHeMbKqdETZZFFpJRVvyGzIouWpg()
		{
			VmzAmCBMIqyiITAlatZWFviQNRHPA();
			YaukUGOCpMBqTUvjzTAhGtzAbzUT = false;
			if ((_followTouchPosition || _moveToTouchPosition) && _returnOnRelease && yWRHpQmqZJaxmgfOgGUEexFqwwRjA)
			{
				ReturnToDefaultPosition();
			}
			JsEAaeGmmTNhSDiMCTwFbFIhkhqaA();
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(JVnKKwGrjPEPUgagLfLrxcVglmYb != null) || !_useTouchRegionOnly))
			{
				PZRHRcVCKVJrzxWRZWybdFpOskRM(eventData, hCrsuvqVPqbUhmJeFMlGylBfrAap.Local);
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(JVnKKwGrjPEPUgagLfLrxcVglmYb != null) || !_useTouchRegionOnly))
			{
				QGjfOYDYPfHrYLwhEDdkrIyePAEs(eventData, hCrsuvqVPqbUhmJeFMlGylBfrAap.Local);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(JVnKKwGrjPEPUgagLfLrxcVglmYb != null) || !_useTouchRegionOnly))
			{
				qmxMlNqXWObFaXGTOTLwyUdqlEEx(eventData, hCrsuvqVPqbUhmJeFMlGylBfrAap.Local);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && (!(JVnKKwGrjPEPUgagLfLrxcVglmYb != null) || !_useTouchRegionOnly))
			{
				baiNWFoDvppwCPElpfaMJrPXJAEK(eventData, hCrsuvqVPqbUhmJeFMlGylBfrAap.Local);
			}
		}

		private void FuwAGVVwsYsyLJgzuCLJakyOarEDA(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				PZRHRcVCKVJrzxWRZWybdFpOskRM(P_0, hCrsuvqVPqbUhmJeFMlGylBfrAap.TouchRegion);
			}
		}

		private void pIDBnkITBpggYhbONAaayVSXDfTHb(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				QGjfOYDYPfHrYLwhEDdkrIyePAEs(P_0, hCrsuvqVPqbUhmJeFMlGylBfrAap.TouchRegion);
			}
		}

		private void EARFXiFFZBbQDfjogrsWRNtpywxhB(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				qmxMlNqXWObFaXGTOTLwyUdqlEEx(P_0, hCrsuvqVPqbUhmJeFMlGylBfrAap.TouchRegion);
			}
		}

		private void oMHFDmaSnamohnbawBYzKKNNECcW(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				baiNWFoDvppwCPElpfaMJrPXJAEK(P_0, hCrsuvqVPqbUhmJeFMlGylBfrAap.TouchRegion);
			}
		}

		private void fWCJlacETVgzITONqKlLQvIFuKWl(float P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && !_useDigitalAxisSimulation)
			{
				mqqgsskRuzXjTAiWvEdJawWAQYEob(null);
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void tMPDtvkAMRPLxGloaoABthnuMdJMB(bool P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				mqqgsskRuzXjTAiWvEdJawWAQYEob(null);
				_onButtonValueChanged.Invoke(P_0);
			}
		}

		private void ECEtZHooVDQNiqgTdCnkffNCSJKS()
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				mqqgsskRuzXjTAiWvEdJawWAQYEob(null);
				_onButtonDown.Invoke();
			}
		}

		private void aLDGiBCxzncHsSGMcMzUIpSUwwsLA()
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				mqqgsskRuzXjTAiWvEdJawWAQYEob(null);
				_onButtonUp.Invoke();
			}
		}
	}
}
