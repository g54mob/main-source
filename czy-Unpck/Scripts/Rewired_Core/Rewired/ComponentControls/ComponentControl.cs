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
		private sealed class tRzXHEZExNKkcNdHNbKrGcrnqNZE : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			public ComponentControl syCPfFbHYMDOvEPjTnPLBqiOhsPv;

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
				case 1:
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					int num2;
					if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.pmYjhUyltIKROfKAKRLTAORpQYO())
					{
						num = 1262635354;
						num2 = num;
					}
					else
					{
						num = 1262635357;
						num2 = num;
					}
					goto IL_001c;
				}
				case 0:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = 1262635356;
						goto IL_001c;
					}
					IL_001c:
					while (true)
					{
						switch (num ^ 0x4B42495E)
						{
						case 0:
							num = 1262635359;
							continue;
						case 4:
							syCPfFbHYMDOvEPjTnPLBqiOhsPv.OnEnable();
							num = 1262635357;
							continue;
						case 2:
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = null;
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							return true;
						case 1:
							break;
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
			public tRzXHEZExNKkcNdHNbKrGcrnqNZE(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
			}
		}

		private IComponentController _controller;

		[NonSerialized]
		private bool PwPWygBTznyByBIyaAyqEfnsXBM;

		[NonSerialized]
		private bool yjvlZiOEvWQYLsFDGkEbJOEAvCG;

		private int _lastUpdateFrame = -1;

		internal abstract bool hasController { get; }

		internal bool initialized => PwPWygBTznyByBIyaAyqEfnsXBM;

		[CustomObfuscation(rename = false)]
		internal ComponentControl()
		{
		}

		public abstract void ClearValue();

		private void ULrHDjtmtkiHKsePDwllexGSAmd()
		{
			int frameCount = Time.frameCount;
			while (true)
			{
				switch (-1071115831 ^ -1071115832)
				{
				case 0:
					continue;
				case 1:
					if (_lastUpdateFrame == frameCount)
					{
						return;
					}
					break;
				}
				break;
			}
			_lastUpdateFrame = frameCount;
			spiCZIbBixHwkYmPEBFXAXTGsXtO();
		}

		void IComponentControl.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ULrHDjtmtkiHKsePDwllexGSAmd
			this.ULrHDjtmtkiHKsePDwllexGSAmd();
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			yjvlZiOEvWQYLsFDGkEbJOEAvCG = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!yjvlZiOEvWQYLsFDGkEbJOEAvCG)
			{
				while (true)
				{
					int num = -251259614;
					while (true)
					{
						switch (num ^ -251259613)
						{
						case 5:
							break;
						case 0:
							goto end_IL_0008;
						case 4:
							return;
						case 3:
							yjvlZiOEvWQYLsFDGkEbJOEAvCG = true;
							num = -251259609;
							continue;
						case 1:
							PwPWygBTznyByBIyaAyqEfnsXBM = false;
							StartCoroutine(CgFJIxeWZvHgvJcjsPIjwirGelf());
							num = -251259616;
							continue;
						default:
							goto IL_0072;
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
			goto IL_0072;
			IL_0072:
			POOLsDGSQBqeMtHOQtJgSqyMaxe();
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (Application.isPlaying)
			{
				EQHdDQNsbTQwauBkuCcNKSLfwaa();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
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
				NPOFSRfAiJHJstoMPmTkHgTRYCc();
				int num = -1942221120;
				while (true)
				{
					switch (num ^ -1942221119)
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
					num = -1942221117;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnCanvasGroupChanged()
		{
			if (!PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				while (true)
				{
					switch (0x545A2838 ^ 0x545A283A)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			MRhoXKNRTSsrZPHrkpESjCnsadr(false, false);
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnTransformParentChanged()
		{
			if (PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				MRhoXKNRTSsrZPHrkpESjCnsadr(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDidApplyAnimationProperties()
		{
			_ = PwPWygBTznyByBIyaAyqEfnsXBM;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Reset()
		{
			_ = PwPWygBTznyByBIyaAyqEfnsXBM;
		}

		internal virtual void spiCZIbBixHwkYmPEBFXAXTGsXtO()
		{
		}

		internal virtual bool KeoQNyZvcuilfnGKgmHgqyJYGhr()
		{
			PwPWygBTznyByBIyaAyqEfnsXBM = false;
			if (!MRhoXKNRTSsrZPHrkpESjCnsadr(true, true))
			{
				return false;
			}
			_controller.Register(this);
			return true;
		}

		internal virtual void EQHdDQNsbTQwauBkuCcNKSLfwaa()
		{
			ClearValue();
			if (!_controller.IsNullOrDestroyed())
			{
				_controller.Deregister(this);
			}
			erHIwspAqyvfsFjxpigiGUNoawW();
			PwPWygBTznyByBIyaAyqEfnsXBM = false;
		}

		internal virtual void NjkGaTSbjeAmPqdpyKMonMbyiMJ()
		{
			if (!_controller.IsNullOrDestroyed())
			{
				erHIwspAqyvfsFjxpigiGUNoawW();
			}
		}

		internal virtual void erHIwspAqyvfsFjxpigiGUNoawW()
		{
			_controller.IsNullOrDestroyed();
		}

		internal virtual void wWklIWMVIReShFCdZhfAVVyDQgX()
		{
			if (!PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				while (true)
				{
					switch (-1923308454 ^ -1923308453)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			NPOFSRfAiJHJstoMPmTkHgTRYCc();
		}

		internal virtual void QBogclsViwEODeiCNJnFOileABHD()
		{
			_ = PwPWygBTznyByBIyaAyqEfnsXBM;
		}

		internal virtual void bDqKNfDLkzsEdxLPBgplGtPGTwPI()
		{
		}

		internal bool pmYjhUyltIKROfKAKRLTAORpQYO()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		internal bool sAoctQjASyGxKJKUXfHqVIbIHCY()
		{
			return this == null;
		}

		internal IComponentController TAPfjlgREenQuGvVOUpFiufnACp()
		{
			return _controller;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		private IEnumerator CgFJIxeWZvHgvJcjsPIjwirGelf()
		{
			tRzXHEZExNKkcNdHNbKrGcrnqNZE tRzXHEZExNKkcNdHNbKrGcrnqNZE2 = new tRzXHEZExNKkcNdHNbKrGcrnqNZE(0);
			tRzXHEZExNKkcNdHNbKrGcrnqNZE2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			return tRzXHEZExNKkcNdHNbKrGcrnqNZE2;
		}

		private void POOLsDGSQBqeMtHOQtJgSqyMaxe()
		{
			if (KeoQNyZvcuilfnGKgmHgqyJYGhr())
			{
				bDqKNfDLkzsEdxLPBgplGtPGTwPI();
				PwPWygBTznyByBIyaAyqEfnsXBM = true;
				NjkGaTSbjeAmPqdpyKMonMbyiMJ();
			}
		}

		private bool MRhoXKNRTSsrZPHrkpESjCnsadr(bool P_0, bool P_1)
		{
			bool flag = false;
			bool result = default(bool);
			try
			{
				IComponentController componentController = FindController();
				if (!_controller.IsNullOrDestroyed() && _controller != componentController)
				{
					flag = true;
					goto IL_0021;
				}
				goto IL_0095;
				IL_00c3:
				result = true;
				goto end_IL_0002;
				IL_0058:
				Type type = default(Type);
				int num;
				if (P_1)
				{
					Logger.LogError(type.Name + " could not be found. You must have a component that extends from " + type.Name + " on this or a parent GameObject.");
					num = -1642319908;
					goto IL_0026;
				}
				goto IL_004b;
				IL_0021:
				num = -1642319906;
				goto IL_0026;
				IL_0026:
				switch (num ^ -1642319908)
				{
				case 5:
					break;
				case 0:
					goto IL_004b;
				case 4:
					goto IL_0058;
				case 1:
					goto IL_0082;
				case 2:
					goto IL_0095;
				default:
					goto IL_00c3;
				}
				goto IL_0021;
				IL_0095:
				_controller = componentController;
				if (_controller == null)
				{
					type = GetRequiredControllerType();
					if ((object)type == null)
					{
						type = typeof(IComponentController);
						num = -1642319912;
						goto IL_0026;
					}
					goto IL_0058;
				}
				goto IL_0082;
				IL_0082:
				if (!P_0 && flag)
				{
					POOLsDGSQBqeMtHOQtJgSqyMaxe();
					num = -1642319905;
					goto IL_0026;
				}
				goto IL_00c3;
				IL_004b:
				throw new Exception();
				end_IL_0002:;
			}
			catch
			{
				while (true)
				{
					IL_00c8:
					int num2 = -1642319907;
					while (true)
					{
						switch (num2 ^ -1642319908)
						{
						case 2:
							break;
						default:
							goto end_IL_00cd;
						case 1:
							goto IL_00e6;
						case 0:
							goto end_IL_00cd;
						}
						goto IL_00c8;
						IL_00e6:
						EQHdDQNsbTQwauBkuCcNKSLfwaa();
						result = false;
						num2 = -1642319908;
						continue;
						end_IL_00cd:
						break;
					}
					break;
				}
			}
			return result;
		}

		private void NPOFSRfAiJHJstoMPmTkHgTRYCc()
		{
			MRhoXKNRTSsrZPHrkpESjCnsadr(false, true);
		}

		private void JsQGOItozNmPIFaykvruIwIeIMf()
		{
			if (sAoctQjASyGxKJKUXfHqVIbIHCY())
			{
				return;
			}
			if (!pmYjhUyltIKROfKAKRLTAORpQYO())
			{
				while (true)
				{
					switch (-473664925 ^ -473664927)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			spiCZIbBixHwkYmPEBFXAXTGsXtO();
		}
	}
}
