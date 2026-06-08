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
		private sealed class jOPXsCoVDhTTgLXTrSxKWKipWVh : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			public ComponentController syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			private bool MoveNext()
			{
				int num;
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				default:
					num = -1063211641;
					goto IL_001a;
				case 0:
					break;
				case 1:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = -1063211642;
						goto IL_001a;
					}
					IL_001a:
					while (true)
					{
						switch (num ^ -1063211644)
						{
						case 0:
							break;
						case 2:
							syCPfFbHYMDOvEPjTnPLBqiOhsPv.POOLsDGSQBqeMtHOQtJgSqyMaxe();
							num = -1063211643;
							continue;
						case 4:
							goto end_IL_0008;
						case 3:
							num = -1063211643;
							continue;
						default:
							return false;
						}
						break;
					}
					goto default;
					end_IL_0008:
					break;
				}
				isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
				ubyTdixGSFKGaFQFZdQnpwgWIvJ = null;
				isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
				return true;
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
			public jOPXsCoVDhTTgLXTrSxKWKipWVh(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
			}
		}

		[NonSerialized]
		private bool PwPWygBTznyByBIyaAyqEfnsXBM;

		[NonSerialized]
		private bool yjvlZiOEvWQYLsFDGkEbJOEAvCG;

		private List<IComponentControl> _controls = new List<IComponentControl>(10);

		internal bool initialized => PwPWygBTznyByBIyaAyqEfnsXBM;

		[CustomObfuscation(rename = false)]
		internal ComponentController()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			yjvlZiOEvWQYLsFDGkEbJOEAvCG = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Update()
		{
			if (!PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				return;
			}
			IComponentControl componentControl = default(IComponentControl);
			while (true)
			{
				int num = _controls.Count - 1;
				int num2 = 353958080;
				while (true)
				{
					switch (num2 ^ 0x1518F8C4)
					{
					case 2:
						num2 = 353958081;
						continue;
					default:
						return;
					case 5:
						break;
					case 3:
						componentControl = _controls[num];
						if (componentControl.IsNullOrDestroyed())
						{
							_controls.RemoveAt(num);
							num2 = 353958082;
							continue;
						}
						goto case 0;
					case 4:
					{
						int num3;
						if (num < 0)
						{
							num2 = 353958085;
							num3 = num2;
						}
						else
						{
							num2 = 353958087;
							num3 = num2;
						}
						continue;
					}
					case 6:
						num--;
						num2 = 353958080;
						continue;
					case 0:
						componentControl.Update();
						num2 = 353958082;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!yjvlZiOEvWQYLsFDGkEbJOEAvCG)
			{
				goto IL_0008;
			}
			goto IL_0046;
			IL_0008:
			int num = 729861232;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x2B80CC71)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				StartCoroutine(KjCyLbLNNdHspjQPElrnMRLSicFO());
				yjvlZiOEvWQYLsFDGkEbJOEAvCG = true;
				return;
			case 0:
				goto IL_0046;
			case 3:
				return;
			}
			goto IL_0008;
			IL_0046:
			POOLsDGSQBqeMtHOQtJgSqyMaxe();
			num = 729861234;
			goto IL_000d;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (!PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				while (true)
				{
					switch (-260385079 ^ -260385077)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			erHIwspAqyvfsFjxpigiGUNoawW();
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (!PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				return;
			}
			while (true)
			{
				wWklIWMVIReShFCdZhfAVVyDQgX();
				int num = 1232353738;
				while (true)
				{
					switch (num ^ 0x497439CA)
					{
					case 2:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0009:
					num = 1232353739;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
			_controls.Clear();
		}

		internal virtual bool KeoQNyZvcuilfnGKgmHgqyJYGhr()
		{
			return true;
		}

		internal virtual void NjkGaTSbjeAmPqdpyKMonMbyiMJ()
		{
			erHIwspAqyvfsFjxpigiGUNoawW();
		}

		internal virtual void erHIwspAqyvfsFjxpigiGUNoawW()
		{
		}

		private void zEzDrCPhBQbeOCjtoQDUlMjxkYJ(IComponentControl P_0)
		{
			if (!P_0.IsNullOrDestroyed())
			{
				ListTools.AddIfUnique(_controls, P_0);
			}
		}

		void IRegistrar<IComponentControl>.Register(IComponentControl P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in zEzDrCPhBQbeOCjtoQDUlMjxkYJ
			this.zEzDrCPhBQbeOCjtoQDUlMjxkYJ(P_0);
		}

		private void MeQfHDvJDyBhUwyhdeOgykZcaQA(IComponentControl P_0)
		{
			if (P_0.IsNullOrDestroyed())
			{
				while (true)
				{
					switch (0x74045B1F ^ 0x74045B1E)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			_controls.Remove(P_0);
		}

		void IRegistrar<IComponentControl>.Deregister(IComponentControl P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MeQfHDvJDyBhUwyhdeOgykZcaQA
			this.MeQfHDvJDyBhUwyhdeOgykZcaQA(P_0);
		}

		public virtual void ClearControlValues()
		{
			if (!PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				goto IL_0008;
			}
			goto IL_0087;
			IL_0008:
			int num = -406006294;
			goto IL_000d;
			IL_000d:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -406006291)
				{
				case 8:
					break;
				case 0:
				{
					int num3;
					if (_controls[num2].IsNullOrDestroyed())
					{
						num = -406006293;
						num3 = num;
					}
					else
					{
						num = -406006289;
						num3 = num;
					}
					continue;
				}
				case 4:
					num = -406006292;
					continue;
				case 7:
					return;
				case 6:
					_controls.RemoveAt(num2);
					num = -406006295;
					continue;
				case 3:
					goto IL_0087;
				case 2:
					_controls[num2].ClearValue();
					num = -406006292;
					continue;
				case 1:
					num2--;
					num = -406006296;
					continue;
				default:
					if (num2 < 0)
					{
						return;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0008;
			IL_0087:
			num2 = _controls.Count - 1;
			num = -406006296;
			goto IL_000d;
		}

		private void POOLsDGSQBqeMtHOQtJgSqyMaxe()
		{
			if (!KeoQNyZvcuilfnGKgmHgqyJYGhr())
			{
				return;
			}
			while (true)
			{
				PwPWygBTznyByBIyaAyqEfnsXBM = true;
				int num = 86576890;
				while (true)
				{
					switch (num ^ 0x5290EFB)
					{
					case 0:
						goto IL_0009;
					case 2:
						break;
					default:
						NjkGaTSbjeAmPqdpyKMonMbyiMJ();
						return;
					}
					break;
					IL_0009:
					num = 86576889;
				}
			}
		}

		private void wWklIWMVIReShFCdZhfAVVyDQgX()
		{
			_ = initialized;
		}

		private IEnumerator KjCyLbLNNdHspjQPElrnMRLSicFO()
		{
			jOPXsCoVDhTTgLXTrSxKWKipWVh jOPXsCoVDhTTgLXTrSxKWKipWVh2 = new jOPXsCoVDhTTgLXTrSxKWKipWVh(0);
			jOPXsCoVDhTTgLXTrSxKWKipWVh2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			return jOPXsCoVDhTTgLXTrSxKWKipWVh2;
		}
	}
}
