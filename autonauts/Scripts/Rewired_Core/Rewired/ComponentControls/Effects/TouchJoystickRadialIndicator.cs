using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.ComponentControls.Effects
{
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
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

		[Tooltip("The horizontal component of the desired aspect ratio of the indicator.")]
		[Range(0.01f, 10f)]
		public float _aspectRatioX = 1f;

		[Tooltip("The vertical component of the desired aspect ratio of the indicator.")]
		[Range(0.01f, 10f)]
		public float _aspectRatioY = 1f;

		[Tooltip("Offsets the indicator position up by this proportion of its height. 1.0 = 1 unit high offset.")]
		public float _offset;

		private static readonly Vector2 OGlxsEdFmEuZyGexjAcHNxcKvfF = new Vector2(0.5f, 0.5f);

		private RectTransform YncvgNpHbAbJtmjXIuIOrVLnpRs;

		private List<TouchJoystickAngleIndicator> GWptMUsWAAGCQzGwKjOrJJIKysi = new List<TouchJoystickAngleIndicator>(8);

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
					TzavSRkIcUdUXyGrWDQoLGzUgZXD();
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
					while (true)
					{
						switch (-1599919231 ^ -1599919232)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_preserveSpriteAspectRatio = value;
				TzavSRkIcUdUXyGrWDQoLGzUgZXD();
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
					TzavSRkIcUdUXyGrWDQoLGzUgZXD();
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
				while (true)
				{
					int num = -454102843;
					while (true)
					{
						switch (num ^ -454102844)
						{
						case 0:
							break;
						case 1:
							if (_aspectRatioX != value)
							{
								goto IL_0045;
							}
							return;
						case 2:
							goto IL_0045;
						default:
							TzavSRkIcUdUXyGrWDQoLGzUgZXD();
							return;
						}
						break;
						IL_0045:
						_aspectRatioX = value;
						num = -454102841;
					}
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
					return;
				}
				while (true)
				{
					_aspectRatioY = value;
					int num = 849224196;
					while (true)
					{
						switch (num ^ 0x329E2205)
						{
						case 0:
							goto IL_001c;
						case 2:
							break;
						default:
							TzavSRkIcUdUXyGrWDQoLGzUgZXD();
							return;
						}
						break;
						IL_001c:
						num = 849224199;
					}
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
					int num = 139050171;
					while (true)
					{
						switch (num ^ 0x849BCBB)
						{
						case 2:
							goto IL_000a;
						case 1:
							break;
						default:
							TzavSRkIcUdUXyGrWDQoLGzUgZXD();
							return;
						}
						break;
						IL_000a:
						num = 139050170;
					}
				}
			}
		}

		private RectTransform rectTransform
		{
			get
			{
				return YncvgNpHbAbJtmjXIuIOrVLnpRs ?? (YncvgNpHbAbJtmjXIuIOrVLnpRs = GetComponent<RectTransform>());
			}
		}

		void IRegistrar<TouchJoystickAngleIndicator>.Register(TouchJoystickAngleIndicator P_0)
		{
			if (P_0 == null)
			{
				goto IL_0009;
			}
			goto IL_003d;
			IL_0009:
			int num = -1243105146;
			goto IL_000e;
			IL_000e:
			switch (num ^ -1243105150)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				goto IL_002f;
			case 3:
				goto IL_003d;
			case 4:
				return;
			case 2:
				return;
			}
			goto IL_0009;
			IL_003d:
			if (!ListTools.AddIfUnique(GWptMUsWAAGCQzGwKjOrJJIKysi, P_0) || !base.enabled)
			{
				return;
			}
			goto IL_002f;
			IL_002f:
			fUNwyPiQHpCgFGVagovJrHYBssQ(P_0);
			num = -1243105152;
			goto IL_000e;
		}

		void IRegistrar<TouchJoystickAngleIndicator>.Deregister(TouchJoystickAngleIndicator P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				GWptMUsWAAGCQzGwKjOrJJIKysi.Remove(P_0);
				int num = -772948133;
				while (true)
				{
					switch (num ^ -772948135)
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
					num = -772948136;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			jqJZcnkGPZHtoIfzTwiQGxIGwYbi();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (!base.enabled)
			{
				return;
			}
			while (true)
			{
				OIJKQAPwnBuLfPMlEenIghUqAqR();
				int num = 1106343765;
				while (true)
				{
					switch (num ^ 0x41F17755)
					{
					case 2:
						goto IL_0009;
					case 1:
						break;
					default:
						jqJZcnkGPZHtoIfzTwiQGxIGwYbi();
						return;
					}
					break;
					IL_0009:
					num = 1106343764;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			jqJZcnkGPZHtoIfzTwiQGxIGwYbi();
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			GWptMUsWAAGCQzGwKjOrJJIKysi.Clear();
		}

		private void jqJZcnkGPZHtoIfzTwiQGxIGwYbi()
		{
			int num = GWptMUsWAAGCQzGwKjOrJJIKysi.Count - 1;
			while (num >= 0)
			{
				while (true)
				{
					TouchJoystickAngleIndicator touchJoystickAngleIndicator = GWptMUsWAAGCQzGwKjOrJJIKysi[num];
					int num2 = -242686228;
					while (true)
					{
						switch (num2 ^ -242686232)
						{
						case 0:
							num2 = -242686226;
							continue;
						case 6:
							break;
						case 5:
							fUNwyPiQHpCgFGVagovJrHYBssQ(touchJoystickAngleIndicator);
							num2 = -242686230;
							continue;
						case 4:
							goto IL_0063;
						case 2:
							num--;
							num2 = -242686229;
							continue;
						case 1:
							GWptMUsWAAGCQzGwKjOrJJIKysi.RemoveAt(num);
							num2 = -242686230;
							continue;
						default:
							goto end_IL_0041;
						}
						break;
						IL_0063:
						int num3;
						if (!touchJoystickAngleIndicator.image.IsNullOrDestroyed())
						{
							num2 = -242686227;
							num3 = num2;
						}
						else
						{
							num2 = -242686231;
							num3 = num2;
						}
					}
					continue;
					end_IL_0041:
					break;
				}
			}
		}

		private void fUNwyPiQHpCgFGVagovJrHYBssQ(TouchJoystickAngleIndicator P_0)
		{
			if (!UnityTools.IsActiveAndEnabled(P_0.image))
			{
				return;
			}
			Rect rect = default(Rect);
			float num4 = default(float);
			float num3 = default(float);
			while (true)
			{
				RectTransform rectTransform = P_0.rectTransform;
				int num = -1173848217;
				while (true)
				{
					switch (num ^ -1173848217)
					{
					case 2:
						num = -1173848221;
						continue;
					case 9:
					{
						Vector2 sizeDelta = new Vector2(rect.height * _scaleRatio * num3, rect.height * _scaleRatio);
						rectTransform.sizeDelta = sizeDelta;
						num = -1173848222;
						continue;
					}
					case 3:
						if (rectTransform == null)
						{
							return;
						}
						goto case 10;
					case 1:
					{
						Vector2 vector;
						if (P_0.qkeYeOQbfKKvGHDcjvPfoqOTmaO(out vector))
						{
							num3 = vector.x / vector.y;
							num = -1173848210;
							continue;
						}
						goto case 9;
					}
					case 5:
						num4 = (rect.height / 2f / rectTransform.rect.height - 1f) * -1f;
						if (rectTransform.anchorMin != OGlxsEdFmEuZyGexjAcHNxcKvfF)
						{
							rectTransform.anchorMin = OGlxsEdFmEuZyGexjAcHNxcKvfF;
							num = -1173848224;
							continue;
						}
						goto case 7;
					case 10:
						rect = this.rectTransform.rect;
						if (_scale)
						{
							num3 = (num3 = _aspectRatioX / _aspectRatioY);
							num = -1173848223;
							continue;
						}
						goto case 5;
					case 7:
						if (rectTransform.anchorMax != OGlxsEdFmEuZyGexjAcHNxcKvfF)
						{
							rectTransform.anchorMax = OGlxsEdFmEuZyGexjAcHNxcKvfF;
							num = -1173848209;
							continue;
						}
						goto default;
					case 4:
						break;
					case 0:
						if (rectTransform == this.rectTransform)
						{
							return;
						}
						goto case 3;
					case 6:
					{
						int num2;
						if (_preserveSpriteAspectRatio)
						{
							num = -1173848218;
							num2 = num;
						}
						else
						{
							num = -1173848210;
							num2 = num;
						}
						continue;
					}
					default:
					{
						Vector2 pivot = rectTransform.pivot;
						pivot.x = 0.5f;
						pivot.y = num4 + _offset * -1f;
						rectTransform.pivot = pivot;
						return;
					}
					}
					break;
				}
			}
		}

		private void TzavSRkIcUdUXyGrWDQoLGzUgZXD()
		{
			jqJZcnkGPZHtoIfzTwiQGxIGwYbi();
		}

		private void OIJKQAPwnBuLfPMlEenIghUqAqR()
		{
			Transform transform = base.transform;
			GWptMUsWAAGCQzGwKjOrJJIKysi.Clear();
			int childCount = transform.childCount;
			int num2 = default(int);
			TouchJoystickAngleIndicator component = default(TouchJoystickAngleIndicator);
			while (true)
			{
				int num = -223417227;
				while (true)
				{
					switch (num ^ -223417232)
					{
					case 4:
						break;
					case 6:
						num2++;
						num = -223417229;
						continue;
					case 2:
						if (component != null)
						{
							GWptMUsWAAGCQzGwKjOrJJIKysi.Add(component);
							num = -223417226;
							continue;
						}
						goto case 6;
					case 5:
						num2 = 0;
						num = -223417232;
						continue;
					case 0:
						num = -223417229;
						continue;
					case 1:
					{
						Transform child = transform.GetChild(num2);
						component = child.GetComponent<TouchJoystickAngleIndicator>();
						num = -223417230;
						continue;
					}
					default:
						if (num2 >= childCount)
						{
							return;
						}
						goto case 1;
					}
					break;
				}
			}
		}
	}
}
