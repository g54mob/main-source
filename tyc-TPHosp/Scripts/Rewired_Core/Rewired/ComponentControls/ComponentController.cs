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
		private sealed class ddQSdpkTsBCrQyOpUSKRwmodTuu : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			public ComponentController kdBZqupjvsCsVkwJiOeEQzkEDVO;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					ajbaQItphrIyqhowgmMTfPkCBvcN = null;
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
					return true;
				case 1:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					kdBZqupjvsCsVkwJiOeEQzkEDVO.BlPUAqMlztMmaYIlhKUlkimOHBj();
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
			public ddQSdpkTsBCrQyOpUSKRwmodTuu(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
			}
		}

		[NonSerialized]
		private bool XrAXpRFFCZWxSkTUXpVlgetwinP;

		[NonSerialized]
		private bool oOuSSVGPIwoirFTzfHbghNSAtdR;

		private List<IComponentControl> _controls = new List<IComponentControl>(10);

		internal bool initialized => XrAXpRFFCZWxSkTUXpVlgetwinP;

		[CustomObfuscation(rename = false)]
		internal ComponentController()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			oOuSSVGPIwoirFTzfHbghNSAtdR = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Update()
		{
			if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				return;
			}
			for (int num = _controls.Count - 1; num >= 0; num--)
			{
				IComponentControl componentControl = _controls[num];
				if (componentControl.IsNullOrDestroyed())
				{
					_controls.RemoveAt(num);
				}
				else
				{
					componentControl.Update();
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!oOuSSVGPIwoirFTzfHbghNSAtdR)
			{
				StartCoroutine(ISNoGWHPwDQUNvcvhBYwhOJONTM());
				oOuSSVGPIwoirFTzfHbghNSAtdR = true;
			}
			else
			{
				BlPUAqMlztMmaYIlhKUlkimOHBj();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				eyUExPEfJOvDMpgTWfZhKmVaJVBB();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				qdlBanCKskFYgFyewDKidbPGRpbJ();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
			_controls.Clear();
		}

		internal virtual bool USdTaHHNWIGWTOHgBLrxEkaEfPs()
		{
			return true;
		}

		internal virtual void BxlLqiGbAIUodNYPXhhbDFpwdiA()
		{
			eyUExPEfJOvDMpgTWfZhKmVaJVBB();
		}

		internal virtual void eyUExPEfJOvDMpgTWfZhKmVaJVBB()
		{
		}

		private void rVaacnHsiuDCmOXVXFaZsRzvUbC(IComponentControl P_0)
		{
			if (!P_0.IsNullOrDestroyed())
			{
				ListTools.AddIfUnique(_controls, P_0);
			}
		}

		void IRegistrar<IComponentControl>.Register(IComponentControl P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in rVaacnHsiuDCmOXVXFaZsRzvUbC
			this.rVaacnHsiuDCmOXVXFaZsRzvUbC(P_0);
		}

		private void QuXbIcjreKNBgMXTKlxxlURkglLg(IComponentControl P_0)
		{
			if (!P_0.IsNullOrDestroyed())
			{
				_controls.Remove(P_0);
			}
		}

		void IRegistrar<IComponentControl>.Deregister(IComponentControl P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in QuXbIcjreKNBgMXTKlxxlURkglLg
			this.QuXbIcjreKNBgMXTKlxxlURkglLg(P_0);
		}

		public virtual void ClearControlValues()
		{
			if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				return;
			}
			for (int num = _controls.Count - 1; num >= 0; num--)
			{
				if (_controls[num].IsNullOrDestroyed())
				{
					_controls.RemoveAt(num);
				}
				else
				{
					_controls[num].ClearValue();
				}
			}
		}

		private void BlPUAqMlztMmaYIlhKUlkimOHBj()
		{
			if (USdTaHHNWIGWTOHgBLrxEkaEfPs())
			{
				XrAXpRFFCZWxSkTUXpVlgetwinP = true;
				BxlLqiGbAIUodNYPXhhbDFpwdiA();
			}
		}

		private void qdlBanCKskFYgFyewDKidbPGRpbJ()
		{
			_ = initialized;
		}

		private IEnumerator ISNoGWHPwDQUNvcvhBYwhOJONTM()
		{
			ddQSdpkTsBCrQyOpUSKRwmodTuu ddQSdpkTsBCrQyOpUSKRwmodTuu2 = new ddQSdpkTsBCrQyOpUSKRwmodTuu(0);
			ddQSdpkTsBCrQyOpUSKRwmodTuu2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			return ddQSdpkTsBCrQyOpUSKRwmodTuu2;
		}
	}
}
