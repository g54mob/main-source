using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.ComponentControls.Effects
{
	[RequireComponent(typeof(RectTransform))]
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public sealed class TouchJoystickRadialIndicator : MonoBehaviour, IRegistrar<TouchJoystickAngleIndicator>
	{
		[Tooltip("If enabled, the indicators will be scaled based on the size of the RectTransform.")]
		public bool _scale = true;

		[Tooltip("If enabled, the aspect ratio will be determined from the Sprite's texture.")]
		public bool _preserveSpriteAspectRatio;

		[Range(0.01f, 1f)]
		[Tooltip("The scale ratio of the indicators to the current RectTransform's height. A ratio of 0.1 means the indicator will be 0.1 times the size of the RectTransform's height. This is useful if you need to be able to scale the transform and have the indicators also scale with it.")]
		public float _scaleRatio = 0.1f;

		[Range(0.01f, 10f)]
		[Tooltip("The horizontal component of the desired aspect ratio of the indicator.")]
		public float _aspectRatioX = 1f;

		[Range(0.01f, 10f)]
		[Tooltip("The vertical component of the desired aspect ratio of the indicator.")]
		public float _aspectRatioY = 1f;

		[Tooltip("Offsets the indicator position up by this proportion of its height. 1.0 = 1 unit high offset.")]
		public float _offset;

		private static readonly Vector2 pgtBlDdNaQgwJnsmPMeJHykMcoQH = new Vector2(0.5f, 0.5f);

		private RectTransform jWsAaYZljMxgOQUIkeMAAFRfBYz;

		private List<TouchJoystickAngleIndicator> hkrdRDBUCSbdvaTtBuEdgyOESnCx = new List<TouchJoystickAngleIndicator>(8);

		public bool scale
		{
			get
			{
				return _scale;
			}
			set
			{
				if (_scale != value)
				{
					_scale = value;
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
				}
			}
		}

		public bool preserveSpriteAspectRatio
		{
			get
			{
				return _preserveSpriteAspectRatio;
			}
			set
			{
				if (_preserveSpriteAspectRatio == value)
				{
					goto IL_0009;
				}
				goto IL_0037;
				IL_0009:
				int num = -376231569;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ -376231571)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						return;
					case 3:
						goto IL_0037;
					case 4:
						wQiEPKGVkSYAiCZoyTUamohUIKKd();
						num = -376231572;
						continue;
					case 1:
						return;
					}
					break;
				}
				goto IL_0009;
				IL_0037:
				_preserveSpriteAspectRatio = value;
				num = -376231575;
				goto IL_000e;
			}
		}

		public float scaleRatio
		{
			get
			{
				return _scaleRatio;
			}
			set
			{
				value = MathTools.Clamp(value, 0.01f, 1f);
				if (_scaleRatio != value)
				{
					_scaleRatio = value;
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
				}
			}
		}

		public float aspectRatioX
		{
			get
			{
				return _aspectRatioX;
			}
			set
			{
				value = MathTools.Clamp(value, 0.01f, 10f);
				if (_aspectRatioX == value)
				{
					goto IL_001b;
				}
				goto IL_0045;
				IL_001b:
				int num = -1708843218;
				goto IL_0020;
				IL_0020:
				switch (num ^ -1708843217)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					return;
				case 0:
					goto IL_0045;
				case 2:
					return;
				}
				goto IL_001b;
				IL_0045:
				_aspectRatioX = value;
				wQiEPKGVkSYAiCZoyTUamohUIKKd();
				num = -1708843219;
				goto IL_0020;
			}
		}

		public float aspectRatioY
		{
			get
			{
				return _aspectRatioY;
			}
			set
			{
				value = MathTools.Clamp(value, 0.01f, 10f);
				if (_aspectRatioY != value)
				{
					_aspectRatioY = value;
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
				}
			}
		}

		public float offset
		{
			get
			{
				return _offset;
			}
			set
			{
				if (_offset == value)
				{
					return;
				}
				while (true)
				{
					_offset = value;
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
					int num = 952711708;
					while (true)
					{
						switch (num ^ 0x38C93A1E)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_000a:
						num = 952711711;
					}
				}
			}
		}

		private RectTransform rectTransform
		{
			get
			{
				return jWsAaYZljMxgOQUIkeMAAFRfBYz ?? (jWsAaYZljMxgOQUIkeMAAFRfBYz = GetComponent<RectTransform>());
			}
		}

		void IRegistrar<TouchJoystickAngleIndicator>.Register(TouchJoystickAngleIndicator P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (ListTools.AddIfUnique(hkrdRDBUCSbdvaTtBuEdgyOESnCx, P_0))
				{
					num = 1384776148;
					num2 = num;
				}
				else
				{
					num = 1384776145;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x528A01D0)
					{
					case 0:
						num = 1384776147;
						continue;
					default:
						return;
					case 2:
						KRVFzSAGLbzTcEyxGHvVNUMJQtBd(P_0);
						num = 1384776145;
						continue;
					case 4:
						if (!base.enabled)
						{
							return;
						}
						goto case 2;
					case 3:
						break;
					case 1:
						return;
					}
					break;
				}
			}
		}

		void IRegistrar<TouchJoystickAngleIndicator>.Deregister(TouchJoystickAngleIndicator P_0)
		{
			if (P_0 == null)
			{
				while (true)
				{
					switch (-650128345 ^ -650128346)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			hkrdRDBUCSbdvaTtBuEdgyOESnCx.Remove(P_0);
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			GaPGzihQRREONtDylTkOTUYWFNol();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (base.enabled)
			{
				jVNsXZnUhZvoYrIwqHjCJSMoAbOJ();
				GaPGzihQRREONtDylTkOTUYWFNol();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			GaPGzihQRREONtDylTkOTUYWFNol();
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			hkrdRDBUCSbdvaTtBuEdgyOESnCx.Clear();
		}

		private void GaPGzihQRREONtDylTkOTUYWFNol()
		{
			int num = hkrdRDBUCSbdvaTtBuEdgyOESnCx.Count - 1;
			TouchJoystickAngleIndicator touchJoystickAngleIndicator = default(TouchJoystickAngleIndicator);
			while (true)
			{
				int num2 = -701957128;
				while (true)
				{
					switch (num2 ^ -701957123)
					{
					case 0:
						break;
					case 5:
						num2 = -701957127;
						continue;
					case 2:
						KRVFzSAGLbzTcEyxGHvVNUMJQtBd(touchJoystickAngleIndicator);
						num2 = -701957124;
						continue;
					case 3:
						touchJoystickAngleIndicator = hkrdRDBUCSbdvaTtBuEdgyOESnCx[num];
						if (touchJoystickAngleIndicator.image.IsNullOrDestroyed())
						{
							hkrdRDBUCSbdvaTtBuEdgyOESnCx.RemoveAt(num);
							num2 = -701957124;
							continue;
						}
						goto case 2;
					case 1:
						num--;
						num2 = -701957127;
						continue;
					default:
						if (num < 0)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		private void KRVFzSAGLbzTcEyxGHvVNUMJQtBd(TouchJoystickAngleIndicator P_0)
		{
			if (!UnityTools.IsActiveAndEnabled(P_0.image))
			{
				return;
			}
			float num6 = default(float);
			Rect rect = default(Rect);
			float num4 = default(float);
			Vector2 pivot = default(Vector2);
			while (true)
			{
				RectTransform rectTransform = P_0.rectTransform;
				int num;
				int num2;
				if (rectTransform == this.rectTransform)
				{
					num = 924067953;
					num2 = num;
				}
				else
				{
					num = 924067956;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x37142876)
					{
					case 12:
						num = 924067964;
						continue;
					case 13:
					{
						num6 = (rect.height / 2f / rectTransform.rect.height - 1f) * -1f;
						int num7;
						if (rectTransform.anchorMin != pgtBlDdNaQgwJnsmPMeJHykMcoQH)
						{
							num = 924067955;
							num7 = num;
						}
						else
						{
							num = 924067954;
							num7 = num;
						}
						continue;
					}
					case 7:
						return;
					case 3:
					{
						Vector2 sizeDelta = new Vector2(rect.height * _scaleRatio * num4, rect.height * _scaleRatio);
						rectTransform.sizeDelta = sizeDelta;
						num = 924067963;
						continue;
					}
					case 14:
					{
						int num5;
						if (!_preserveSpriteAspectRatio)
						{
							num = 924067957;
							num5 = num;
						}
						else
						{
							num = 924067958;
							num5 = num;
						}
						continue;
					}
					case 9:
						num4 = (num4 = _aspectRatioX / _aspectRatioY);
						num = 924067960;
						continue;
					case 2:
						if (rectTransform == null)
						{
							return;
						}
						goto case 1;
					case 8:
						rectTransform.anchorMax = pgtBlDdNaQgwJnsmPMeJHykMcoQH;
						num = 924067952;
						continue;
					case 6:
						pivot = rectTransform.pivot;
						pivot.x = 0.5f;
						pivot.y = num6 + _offset * -1f;
						num = 924067965;
						continue;
					case 0:
					{
						Vector2 vector;
						if (P_0.FYqANZihtIgQbnChZTLtBHGRmzL(out vector))
						{
							num4 = vector.x / vector.y;
							num = 924067957;
							continue;
						}
						goto case 3;
					}
					case 5:
						rectTransform.anchorMin = pgtBlDdNaQgwJnsmPMeJHykMcoQH;
						num = 924067954;
						continue;
					case 10:
						break;
					case 4:
					{
						int num3;
						if (!(rectTransform.anchorMax != pgtBlDdNaQgwJnsmPMeJHykMcoQH))
						{
							num = 924067952;
							num3 = num;
						}
						else
						{
							num = 924067966;
							num3 = num;
						}
						continue;
					}
					case 1:
					{
						rect = this.rectTransform.rect;
						int num8;
						if (!_scale)
						{
							num = 924067963;
							num8 = num;
						}
						else
						{
							num = 924067967;
							num8 = num;
						}
						continue;
					}
					default:
						rectTransform.pivot = pivot;
						return;
					}
					break;
				}
			}
		}

		private void wQiEPKGVkSYAiCZoyTUamohUIKKd()
		{
			GaPGzihQRREONtDylTkOTUYWFNol();
		}

		private void jVNsXZnUhZvoYrIwqHjCJSMoAbOJ()
		{
			Transform transform = base.transform;
			hkrdRDBUCSbdvaTtBuEdgyOESnCx.Clear();
			int childCount = transform.childCount;
			int num2 = default(int);
			while (true)
			{
				int num = -108050542;
				while (true)
				{
					switch (num ^ -108050541)
					{
					case 0:
						break;
					case 1:
						num2 = 0;
						num = -108050537;
						continue;
					case 3:
						num2++;
						num = -108050537;
						continue;
					case 2:
					{
						Transform child = transform.GetChild(num2);
						TouchJoystickAngleIndicator component = child.GetComponent<TouchJoystickAngleIndicator>();
						if (component != null)
						{
							hkrdRDBUCSbdvaTtBuEdgyOESnCx.Add(component);
							num = -108050544;
							continue;
						}
						goto case 3;
					}
					default:
						if (num2 >= childCount)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}
	}
}
