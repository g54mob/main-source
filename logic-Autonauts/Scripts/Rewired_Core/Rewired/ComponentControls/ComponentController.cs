using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class ComponentController : MonoBehaviour, IRegistrar<IComponentControl>, IComponentController
	{
		private sealed class YhZXCDMaHhCudsmdqAhHOAImSDS : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			public ComponentController ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

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
				int num;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 0:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					num = 1641437351;
					goto IL_001c;
				case 1:
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						ZzSaCQHlhEgTijsOQGwUlyKTOzqG.uQEBmSjyfRHnLAGcBmMfKMKLWzNM();
						num = 1641437344;
						goto IL_001c;
					}
					IL_001c:
					while (true)
					{
						switch (num ^ 0x61D658A4)
						{
						case 0:
							num = 1641437349;
							continue;
						case 1:
							break;
						case 3:
							RDkWcsTpvDaNZojjIZONnoEBXPC = null;
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							num = 1641437350;
							continue;
						case 2:
							return true;
						default:
							goto end_IL_0008;
						}
						break;
					}
					goto case 0;
					end_IL_0008:
					break;
				}
				return false;
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
			public YhZXCDMaHhCudsmdqAhHOAImSDS(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
			}
		}

		[NonSerialized]
		private bool uvRIxvvRCxrfpiSXpAlvYqJtnEz;

		[NonSerialized]
		private bool BKhokncCOOeDOJggJQjiTucHbDn;

		private List<IComponentControl> _controls = new List<IComponentControl>(10);

		internal bool initialized
		{
			get
			{
				return uvRIxvvRCxrfpiSXpAlvYqJtnEz;
			}
		}

		[CustomObfuscation(rename = false)]
		internal ComponentController()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			BKhokncCOOeDOJggJQjiTucHbDn = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Update()
		{
			if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				return;
			}
			IComponentControl componentControl = default(IComponentControl);
			while (true)
			{
				int num = _controls.Count - 1;
				int num2 = -218953271;
				while (true)
				{
					switch (num2 ^ -218953269)
					{
					case 4:
						num2 = -218953270;
						continue;
					default:
						return;
					case 2:
					{
						int num3;
						if (num < 0)
						{
							num2 = -218953272;
							num3 = num2;
						}
						else
						{
							num2 = -218953267;
							num3 = num2;
						}
						continue;
					}
					case 7:
						num2 = -218953266;
						continue;
					case 0:
						componentControl.Update();
						num2 = -218953266;
						continue;
					case 6:
						componentControl = _controls[num];
						if (componentControl.IsNullOrDestroyed())
						{
							_controls.RemoveAt(num);
							num2 = -218953268;
							continue;
						}
						goto case 0;
					case 1:
						break;
					case 5:
						num--;
						num2 = -218953271;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!BKhokncCOOeDOJggJQjiTucHbDn)
			{
				while (true)
				{
					switch (-1675762117 ^ -1675762118)
					{
					case 2:
						continue;
					case 1:
						StartCoroutine(pGWwmqlwBdzwWxkXVWwwHrODlmO());
						BKhokncCOOeDOJggJQjiTucHbDn = true;
						return;
					}
					break;
				}
			}
			uQEBmSjyfRHnLAGcBmMfKMKLWzNM();
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				while (true)
				{
					switch (-1134681866 ^ -1134681865)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			OnUnsubscribeEvents();
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				TzavSRkIcUdUXyGrWDQoLGzUgZXD();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
			_controls.Clear();
		}

		internal virtual bool OnInitialize()
		{
			return true;
		}

		internal virtual void OnSubscribeEvents()
		{
			OnUnsubscribeEvents();
		}

		internal virtual void OnUnsubscribeEvents()
		{
		}

		void IRegistrar<IComponentControl>.Register(IComponentControl P_0)
		{
			if (!P_0.IsNullOrDestroyed())
			{
				ListTools.AddIfUnique(_controls, P_0);
			}
		}

		void IRegistrar<IComponentControl>.Deregister(IComponentControl P_0)
		{
			if (!P_0.IsNullOrDestroyed())
			{
				_controls.Remove(P_0);
			}
		}

		public virtual void ClearControlValues()
		{
			if (!uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				return;
			}
			while (true)
			{
				int num = _controls.Count - 1;
				int num2 = -1432777094;
				while (true)
				{
					switch (num2 ^ -1432777094)
					{
					case 4:
						num2 = -1432777092;
						continue;
					default:
						return;
					case 6:
						break;
					case 5:
						num--;
						num2 = -1432777094;
						continue;
					case 2:
						if (_controls[num].IsNullOrDestroyed())
						{
							_controls.RemoveAt(num);
							num2 = -1432777089;
							continue;
						}
						goto case 1;
					case 1:
						_controls[num].ClearValue();
						num2 = -1432777089;
						continue;
					case 0:
					{
						int num3;
						if (num >= 0)
						{
							num2 = -1432777096;
							num3 = num2;
						}
						else
						{
							num2 = -1432777095;
							num3 = num2;
						}
						continue;
					}
					case 3:
						return;
					}
					break;
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
				uvRIxvvRCxrfpiSXpAlvYqJtnEz = true;
				int num = -137144249;
				while (true)
				{
					switch (num ^ -137144250)
					{
					case 0:
						goto IL_0009;
					case 2:
						break;
					default:
						OnSubscribeEvents();
						return;
					}
					break;
					IL_0009:
					num = -137144252;
				}
			}
		}

		private void TzavSRkIcUdUXyGrWDQoLGzUgZXD()
		{
			bool initialized2 = initialized;
		}

		private IEnumerator pGWwmqlwBdzwWxkXVWwwHrODlmO()
		{
			YhZXCDMaHhCudsmdqAhHOAImSDS yhZXCDMaHhCudsmdqAhHOAImSDS = new YhZXCDMaHhCudsmdqAhHOAImSDS(0);
			yhZXCDMaHhCudsmdqAhHOAImSDS.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			return yhZXCDMaHhCudsmdqAhHOAImSDS;
		}
	}
}
