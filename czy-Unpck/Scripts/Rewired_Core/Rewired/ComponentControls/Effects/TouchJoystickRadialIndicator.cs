using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.ComponentControls.Effects
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Joystick Radial Indicator")]
	[RequireComponent(typeof(RectTransform))]
	[ExecuteInEditMode]
	public sealed class TouchJoystickRadialIndicator : MonoBehaviour, IRegistrar<TouchJoystickAngleIndicator>
	{
		[Tooltip("If enabled, the indicators will be scaled based on the size of the RectTransform.")]
		public bool _scale = true;

		[Tooltip("If enabled, the aspect ratio will be determined from the Sprite's texture.")]
		public bool _preserveSpriteAspectRatio;

		[Tooltip("The scale ratio of the indicators to the current RectTransform's height. A ratio of 0.1 means the indicator will be 0.1 times the size of the RectTransform's height. This is useful if you need to be able to scale the transform and have the indicators also scale with it.")]
		[Range(0.01f, 1f)]
		public float _scaleRatio = 0.1f;

		[Range(0.01f, 10f)]
		[Tooltip("The horizontal component of the desired aspect ratio of the indicator.")]
		public float _aspectRatioX = 1f;

		[Range(0.01f, 10f)]
		[Tooltip("The vertical component of the desired aspect ratio of the indicator.")]
		public float _aspectRatioY = 1f;

		[Tooltip("Offsets the indicator position up by this proportion of its height. 1.0 = 1 unit high offset.")]
		public float _offset;

		private static readonly Vector2 jjxLXBFDFMQjLfSQuLErFGjXuat = new Vector2(0.5f, 0.5f);

		private RectTransform tmakEQDNEGzEeRqmFezXlvluWOF;

		private List<TouchJoystickAngleIndicator> bpYnPbGvOLTNWYJNNrgDNwVkjZe = new List<TouchJoystickAngleIndicator>(8);

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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
					return;
				}
				while (true)
				{
					_preserveSpriteAspectRatio = value;
					int num = 1638416046;
					while (true)
					{
						switch (num ^ 0x61A83EAF)
						{
						case 3:
							num = 1638416045;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							num = 1638416047;
							continue;
						case 0:
							return;
						}
						break;
					}
				}
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
				if (_scaleRatio == value)
				{
					return;
				}
				while (true)
				{
					_scaleRatio = value;
					int num = -1427062869;
					while (true)
					{
						switch (num ^ -1427062871)
						{
						case 0:
							goto IL_001c;
						case 1:
							break;
						default:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							return;
						}
						break;
						IL_001c:
						num = -1427062872;
					}
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
				if (_aspectRatioX != value)
				{
					_aspectRatioX = value;
					wWklIWMVIReShFCdZhfAVVyDQgX();
				}
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
				if (_aspectRatioY == value)
				{
					while (true)
					{
						switch (-788765983 ^ -788765984)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_aspectRatioY = value;
				wWklIWMVIReShFCdZhfAVVyDQgX();
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
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = 1790876438;
				goto IL_000e;
				IL_000e:
				switch (num ^ 0x6ABE9B15)
				{
				case 0:
					break;
				case 3:
					return;
				case 2:
					goto IL_0033;
				default:
					wWklIWMVIReShFCdZhfAVVyDQgX();
					return;
				}
				goto IL_0009;
				IL_0033:
				_offset = value;
				num = 1790876436;
				goto IL_000e;
			}
		}

		private RectTransform rectTransform => tmakEQDNEGzEeRqmFezXlvluWOF ?? (tmakEQDNEGzEeRqmFezXlvluWOF = GetComponent<RectTransform>());

		private void gMWeYSQSVhhMXuEGSGfJkaZFmFgC(TouchJoystickAngleIndicator P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (ListTools.AddIfUnique(bpYnPbGvOLTNWYJNNrgDNwVkjZe, P_0) && base.enabled)
			{
				while (true)
				{
					IL_004a:
					CNXJWwWmortQRrFSlKQtjwKUrjH(P_0);
					int num = 787125963;
					while (true)
					{
						switch (num ^ 0x2EEA96CA)
						{
						case 0:
							num = 787125960;
							continue;
						default:
							return;
						case 2:
							break;
						case 3:
							goto IL_004a;
						case 1:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		void IRegistrar<TouchJoystickAngleIndicator>.Register(TouchJoystickAngleIndicator P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in gMWeYSQSVhhMXuEGSGfJkaZFmFgC
			this.gMWeYSQSVhhMXuEGSGfJkaZFmFgC(P_0);
		}

		private void ZlsvURNpoaeoiSXgXbWWGisBZFVr(TouchJoystickAngleIndicator P_0)
		{
			if (!(P_0 == null))
			{
				bpYnPbGvOLTNWYJNNrgDNwVkjZe.Remove(P_0);
			}
		}

		void IRegistrar<TouchJoystickAngleIndicator>.Deregister(TouchJoystickAngleIndicator P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ZlsvURNpoaeoiSXgXbWWGisBZFVr
			this.ZlsvURNpoaeoiSXgXbWWGisBZFVr(P_0);
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			CjDHisSeARmOjYSoQJGPlaqNLFE();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (base.enabled)
			{
				nEVpbZlaWThYkwCYJuQVskqrtvw();
				CjDHisSeARmOjYSoQJGPlaqNLFE();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			CjDHisSeARmOjYSoQJGPlaqNLFE();
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			bpYnPbGvOLTNWYJNNrgDNwVkjZe.Clear();
		}

		private void CjDHisSeARmOjYSoQJGPlaqNLFE()
		{
			int num = bpYnPbGvOLTNWYJNNrgDNwVkjZe.Count - 1;
			TouchJoystickAngleIndicator touchJoystickAngleIndicator = default(TouchJoystickAngleIndicator);
			while (true)
			{
				int num2 = -1385496017;
				while (true)
				{
					switch (num2 ^ -1385496019)
					{
					case 0:
						break;
					default:
						return;
					case 5:
						num--;
						num2 = -1385496020;
						continue;
					case 6:
						touchJoystickAngleIndicator = bpYnPbGvOLTNWYJNNrgDNwVkjZe[num];
						if (touchJoystickAngleIndicator.image.IsNullOrDestroyed())
						{
							bpYnPbGvOLTNWYJNNrgDNwVkjZe.RemoveAt(num);
							num2 = -1385496024;
							continue;
						}
						goto case 4;
					case 1:
					{
						int num3;
						if (num < 0)
						{
							num2 = -1385496018;
							num3 = num2;
						}
						else
						{
							num2 = -1385496021;
							num3 = num2;
						}
						continue;
					}
					case 4:
						CNXJWwWmortQRrFSlKQtjwKUrjH(touchJoystickAngleIndicator);
						num2 = -1385496024;
						continue;
					case 2:
						num2 = -1385496020;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void CNXJWwWmortQRrFSlKQtjwKUrjH(TouchJoystickAngleIndicator P_0)
		{
			if (!UnityTools.IsActiveAndEnabled(P_0.image))
			{
				return;
			}
			float num = default(float);
			Vector2 pivot = default(Vector2);
			float num3 = default(float);
			while (true)
			{
				RectTransform rectTransform = P_0.rectTransform;
				if (rectTransform == this.rectTransform)
				{
					break;
				}
				while (true)
				{
					if (rectTransform == null)
					{
						return;
					}
					while (true)
					{
						IL_00e1:
						Rect rect = this.rectTransform.rect;
						int num2;
						if (_scale)
						{
							num = (num = _aspectRatioX / _aspectRatioY);
							num2 = 375363508;
							goto IL_0016;
						}
						goto IL_017f;
						IL_0016:
						while (true)
						{
							switch (num2 ^ 0x165F97BD)
							{
							case 8:
								num2 = 375363514;
								continue;
							case 6:
								break;
							case 4:
								goto end_IL_00e1;
							case 9:
							{
								if (_preserveSpriteAspectRatio && P_0.PogkjRsJMAKgTcINaikscnkYdltG(out var vector))
								{
									num = vector.x / vector.y;
									num2 = 375363516;
									continue;
								}
								goto case 1;
							}
							case 1:
							{
								Vector2 sizeDelta = new Vector2(rect.height * _scaleRatio * num, rect.height * _scaleRatio);
								rectTransform.sizeDelta = sizeDelta;
								num2 = 375363517;
								continue;
							}
							case 5:
								goto IL_00e1;
							case 7:
								goto end_IL_006d;
							case 2:
								pivot.y = num3 + _offset * -1f;
								num2 = 375363518;
								continue;
							case 10:
								goto IL_0155;
							case 0:
								goto IL_017f;
							default:
								rectTransform.pivot = pivot;
								return;
							}
							break;
						}
						goto IL_0052;
						IL_017f:
						num3 = (rect.height / 2f / rectTransform.rect.height - 1f) * -1f;
						if (rectTransform.anchorMin != jjxLXBFDFMQjLfSQuLErFGjXuat)
						{
							rectTransform.anchorMin = jjxLXBFDFMQjLfSQuLErFGjXuat;
							num2 = 375363511;
							goto IL_0016;
						}
						goto IL_0155;
						IL_0052:
						pivot = rectTransform.pivot;
						pivot.x = 0.5f;
						num2 = 375363519;
						goto IL_0016;
						IL_0155:
						if (rectTransform.anchorMax != jjxLXBFDFMQjLfSQuLErFGjXuat)
						{
							rectTransform.anchorMax = jjxLXBFDFMQjLfSQuLErFGjXuat;
							num2 = 375363515;
							goto IL_0016;
						}
						goto IL_0052;
						continue;
						end_IL_00e1:
						break;
					}
					continue;
					end_IL_006d:
					break;
				}
			}
		}

		private void wWklIWMVIReShFCdZhfAVVyDQgX()
		{
			CjDHisSeARmOjYSoQJGPlaqNLFE();
		}

		private void nEVpbZlaWThYkwCYJuQVskqrtvw()
		{
			Transform transform = base.transform;
			bpYnPbGvOLTNWYJNNrgDNwVkjZe.Clear();
			int childCount = transform.childCount;
			int num = 0;
			while (num < childCount)
			{
				while (true)
				{
					Transform child = transform.GetChild(num);
					int num2 = -1607598558;
					while (true)
					{
						switch (num2 ^ -1607598558)
						{
						case 3:
							num2 = -1607598557;
							continue;
						case 1:
							break;
						case 4:
							num++;
							num2 = -1607598560;
							continue;
						case 0:
						{
							TouchJoystickAngleIndicator component = child.GetComponent<TouchJoystickAngleIndicator>();
							if (component != null)
							{
								bpYnPbGvOLTNWYJNNrgDNwVkjZe.Add(component);
								num2 = -1607598554;
								continue;
							}
							goto case 4;
						}
						default:
							goto end_IL_0043;
						}
						break;
					}
					continue;
					end_IL_0043:
					break;
				}
			}
		}
	}
}
