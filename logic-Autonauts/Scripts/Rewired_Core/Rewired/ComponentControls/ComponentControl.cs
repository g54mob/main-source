using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class ComponentControl : MonoBehaviour, IComponentControl
	{
		private sealed class YPjmRvxWxZfvBisxQteDgFLsSiS : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			public ComponentControl ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			private bool MoveNext()
			{
				int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
				while (true)
				{
					int num = -1220959905;
					while (true)
					{
						switch (num ^ -1220959908)
						{
						case 2:
							break;
						case 4:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							RDkWcsTpvDaNZojjIZONnoEBXPC = null;
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						case 0:
							num = -1220959907;
							continue;
						case 3:
							switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 0:
								break;
							case 1:
								goto IL_0044;
							default:
								goto IL_007f;
							}
							goto case 4;
						default:
							{
								return false;
							}
							IL_007f:
							num = -1220959908;
							continue;
							IL_0044:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.WMOIUVAoMMEQPQHrJmvWWfvqFVh())
							{
								ZzSaCQHlhEgTijsOQGwUlyKTOzqG.OnEnable();
								num = -1220959907;
								continue;
							}
							goto default;
						}
						break;
					}
				}
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public YPjmRvxWxZfvBisxQteDgFLsSiS(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
			}
		}

		private IComponentController _controller;

		[NonSerialized]
		private bool uvRIxvvRCxrfpiSXpAlvYqJtnEz;

		[NonSerialized]
		private bool BKhokncCOOeDOJggJQjiTucHbDn;

		private int _lastUpdateFrame = -1;

		internal abstract bool hasController { get; }

		internal bool initialized
		{
			get
			{
				return uvRIxvvRCxrfpiSXpAlvYqJtnEz;
			}
		}

		[CustomObfuscation(rename = false)]
		internal ComponentControl()
		{
		}

		public abstract void ClearValue();

		void IComponentControl.Update()
		{
			int frameCount = Time.frameCount;
			if (_lastUpdateFrame != frameCount)
			{
				_lastUpdateFrame = frameCount;
				OnUpdate();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			BKhokncCOOeDOJggJQjiTucHbDn = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!BKhokncCOOeDOJggJQjiTucHbDn)
			{
				while (true)
				{
					int num = -297387574;
					while (true)
					{
						switch (num ^ -297387573)
						{
						case 3:
							break;
						case 1:
							uvRIxvvRCxrfpiSXpAlvYqJtnEz = false;
							num = -297387575;
							continue;
						case 2:
							StartCoroutine(rfFmqeWxcjnMkcNChcwuHcBTbbWQ());
							BKhokncCOOeDOJggJQjiTucHbDn = true;
							return;
						case 0:
							goto end_IL_0008;
						default:
							goto IL_0067;
						}
						break;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			if (!Application.isPlaying)
			{
				return;
			}
			goto IL_0067;
			IL_0067:
			uQEBmSjyfRHnLAGcBmMfKMKLWzNM();
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (!Application.isPlaying)
			{
				while (true)
				{
					switch (0x7DDB1CC8 ^ 0x7DDB1CC9)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			hUFreFzoIXaPdPpDpZUYAbnaCzR();
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = -863147723;
			goto IL_000d;
			IL_000d:
			switch (num ^ -863147722)
			{
			case 2:
				break;
			default:
				return;
			case 3:
				return;
			case 0:
				goto IL_0032;
			case 1:
				return;
			}
			goto IL_0008;
			IL_0032:
			cIMxKKikLZEqzDDbOdedgdvAfBZi();
			num = -863147721;
			goto IL_000d;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnCanvasGroupChanged()
		{
			if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				return;
			}
			while (true)
			{
				lQzITVzDwIntKmhuxNCVjGJtnhE(false, false);
				int num = 620536044;
				while (true)
				{
					switch (num ^ 0x24FCA0ED)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0009:
					num = 620536047;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnTransformParentChanged()
		{
			if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				while (true)
				{
					switch (0x5EB660BB ^ 0x5EB660BA)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			lQzITVzDwIntKmhuxNCVjGJtnhE(false, false);
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDidApplyAnimationProperties()
		{
			bool uvRIxvvRCxrfpiSXpAlvYqJtnEz2 = uvRIxvvRCxrfpiSXpAlvYqJtnEz;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Reset()
		{
			bool uvRIxvvRCxrfpiSXpAlvYqJtnEz2 = uvRIxvvRCxrfpiSXpAlvYqJtnEz;
		}

		internal virtual void OnUpdate()
		{
		}

		internal virtual bool OnInitialize()
		{
			uvRIxvvRCxrfpiSXpAlvYqJtnEz = false;
			while (true)
			{
				int num = 776255124;
				while (true)
				{
					switch (num ^ 0x2E44B695)
					{
					case 0:
						break;
					case 1:
						if (!lQzITVzDwIntKmhuxNCVjGJtnhE(true, true))
						{
							goto IL_002f;
						}
						_controller.Register(this);
						return true;
					default:
						return false;
					}
					break;
					IL_002f:
					num = 776255127;
				}
			}
		}

		internal virtual void hUFreFzoIXaPdPpDpZUYAbnaCzR()
		{
			ClearValue();
			if (!_controller.IsNullOrDestroyed())
			{
				_controller.Deregister(this);
			}
			OnUnsubscribeEvents();
			uvRIxvvRCxrfpiSXpAlvYqJtnEz = false;
		}

		internal virtual void OnSubscribeEvents()
		{
			if (!_controller.IsNullOrDestroyed())
			{
				OnUnsubscribeEvents();
			}
		}

		internal virtual void OnUnsubscribeEvents()
		{
			_controller.IsNullOrDestroyed();
		}

		internal virtual void OnSetProperty()
		{
			if (uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				cIMxKKikLZEqzDDbOdedgdvAfBZi();
			}
		}

		internal virtual void OnClear()
		{
			bool uvRIxvvRCxrfpiSXpAlvYqJtnEz2 = uvRIxvvRCxrfpiSXpAlvYqJtnEz;
		}

		internal virtual void FindEventHandlers()
		{
		}

		internal bool WMOIUVAoMMEQPQHrJmvWWfvqFVh()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		internal bool NZeLTHDjxyfcTdsfWcwpAHDDJXtD()
		{
			return this == null;
		}

		internal IComponentController uTBWYexvbgNovlylPUvYgROmXuM()
		{
			return _controller;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		private IEnumerator rfFmqeWxcjnMkcNChcwuHcBTbbWQ()
		{
			YPjmRvxWxZfvBisxQteDgFLsSiS yPjmRvxWxZfvBisxQteDgFLsSiS = new YPjmRvxWxZfvBisxQteDgFLsSiS(0);
			while (true)
			{
				int num = -1128049661;
				while (true)
				{
					switch (num ^ -1128049662)
					{
					case 0:
						break;
					case 1:
						goto IL_0025;
					default:
						return yPjmRvxWxZfvBisxQteDgFLsSiS;
					}
					break;
					IL_0025:
					yPjmRvxWxZfvBisxQteDgFLsSiS.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					num = -1128049664;
				}
			}
		}

		private void uQEBmSjyfRHnLAGcBmMfKMKLWzNM()
		{
			if (!OnInitialize())
			{
				return;
			}
			while (true)
			{
				FindEventHandlers();
				int num = 143370426;
				while (true)
				{
					switch (num ^ 0x88BA8BA)
					{
					case 2:
						goto IL_0009;
					case 1:
						break;
					default:
						uvRIxvvRCxrfpiSXpAlvYqJtnEz = true;
						OnSubscribeEvents();
						return;
					}
					break;
					IL_0009:
					num = 143370427;
				}
			}
		}

		private bool lQzITVzDwIntKmhuxNCVjGJtnhE(bool P_0, bool P_1)
		{
			bool flag = false;
			try
			{
				IComponentController componentController = FindController();
				if (!_controller.IsNullOrDestroyed())
				{
					goto IL_0019;
				}
				goto IL_00e8;
				IL_0019:
				int num = 857562411;
				goto IL_001e;
				IL_001e:
				Type type = default(Type);
				while (true)
				{
					switch (num ^ 0x331D5D2C)
					{
					case 4:
						break;
					case 7:
						if (_controller != componentController)
						{
							flag = true;
							num = 857562413;
							continue;
						}
						goto IL_00e8;
					case 2:
						throw new Exception();
					case 6:
						if (_controller == null)
						{
							type = GetRequiredControllerType();
							num = 857562409;
							continue;
						}
						goto case 0;
					case 3:
						if (P_1)
						{
							Logger.LogError(type.Name + " could not be found. You must have a component that extends from " + type.Name + " on this or a parent GameObject.");
							num = 857562414;
							continue;
						}
						goto case 2;
					case 0:
						if (!P_0 && flag)
						{
							uQEBmSjyfRHnLAGcBmMfKMKLWzNM();
							num = 857562404;
							continue;
						}
						goto default;
					case 5:
						goto IL_00d1;
					case 1:
						goto IL_00e8;
					case 9:
						type = typeof(IComponentController);
						num = 857562415;
						continue;
					default:
						return true;
					}
					break;
					IL_00d1:
					int num2;
					if ((object)type == null)
					{
						num = 857562405;
						num2 = num;
					}
					else
					{
						num = 857562415;
						num2 = num;
					}
				}
				goto IL_0019;
				IL_00e8:
				_controller = componentController;
				num = 857562410;
				goto IL_001e;
			}
			catch
			{
				hUFreFzoIXaPdPpDpZUYAbnaCzR();
				return false;
			}
		}

		private void cIMxKKikLZEqzDDbOdedgdvAfBZi()
		{
			lQzITVzDwIntKmhuxNCVjGJtnhE(false, true);
		}

		private void ctMdhNXsUDUSRydNrODtEnkxXuA()
		{
			if (NZeLTHDjxyfcTdsfWcwpAHDDJXtD())
			{
				return;
			}
			if (!WMOIUVAoMMEQPQHrJmvWWfvqFVh())
			{
				while (true)
				{
					switch (0x2466117B ^ 0x24661179)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			OnUpdate();
		}
	}
}
