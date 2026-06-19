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
		private sealed class bxyqOjJZQhUUKselqbzieGldEoUt : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			public ComponentControl kdBZqupjvsCsVkwJiOeEQzkEDVO;

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
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.zCDiilIuMmyrwiYynasIRcHvrxTh())
					{
						kdBZqupjvsCsVkwJiOeEQzkEDVO.OnEnable();
					}
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
			public bxyqOjJZQhUUKselqbzieGldEoUt(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
			}
		}

		private IComponentController _controller;

		[NonSerialized]
		private bool XrAXpRFFCZWxSkTUXpVlgetwinP;

		[NonSerialized]
		private bool oOuSSVGPIwoirFTzfHbghNSAtdR;

		private int _lastUpdateFrame = -1;

		internal abstract bool hasController { get; }

		internal bool initialized => XrAXpRFFCZWxSkTUXpVlgetwinP;

		[CustomObfuscation(rename = false)]
		internal ComponentControl()
		{
		}

		public abstract void ClearValue();

		private void QZubMIJrOEibclHzaPImaKKSUHih()
		{
			int frameCount = Time.frameCount;
			if (_lastUpdateFrame != frameCount)
			{
				_lastUpdateFrame = frameCount;
				yQdUgprBXDEoWjnetusIxRhMmAu();
			}
		}

		void IComponentControl.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in QZubMIJrOEibclHzaPImaKKSUHih
			this.QZubMIJrOEibclHzaPImaKKSUHih();
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			oOuSSVGPIwoirFTzfHbghNSAtdR = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!oOuSSVGPIwoirFTzfHbghNSAtdR)
			{
				XrAXpRFFCZWxSkTUXpVlgetwinP = false;
				StartCoroutine(AQsYSlioTSzDHiXXeykDSlbCPmN());
				oOuSSVGPIwoirFTzfHbghNSAtdR = true;
			}
			else if (Application.isPlaying)
			{
				BlPUAqMlztMmaYIlhKUlkimOHBj();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (Application.isPlaying)
			{
				KsAOKrZKgtucIHEQBDfCyMDnLoz();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				ZBDmBmYoVxMpOXnsuZypYbLJAdh();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnCanvasGroupChanged()
		{
			if (XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				OwsdNfDhieGppsibBdCXDMrmfHk(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnTransformParentChanged()
		{
			if (XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				OwsdNfDhieGppsibBdCXDMrmfHk(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDidApplyAnimationProperties()
		{
			_ = XrAXpRFFCZWxSkTUXpVlgetwinP;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Reset()
		{
			_ = XrAXpRFFCZWxSkTUXpVlgetwinP;
		}

		internal virtual void yQdUgprBXDEoWjnetusIxRhMmAu()
		{
		}

		internal virtual bool USdTaHHNWIGWTOHgBLrxEkaEfPs()
		{
			XrAXpRFFCZWxSkTUXpVlgetwinP = false;
			if (!OwsdNfDhieGppsibBdCXDMrmfHk(true, true))
			{
				return false;
			}
			_controller.Register(this);
			return true;
		}

		internal virtual void KsAOKrZKgtucIHEQBDfCyMDnLoz()
		{
			ClearValue();
			if (!_controller.IsNullOrDestroyed())
			{
				_controller.Deregister(this);
			}
			eyUExPEfJOvDMpgTWfZhKmVaJVBB();
			XrAXpRFFCZWxSkTUXpVlgetwinP = false;
		}

		internal virtual void BxlLqiGbAIUodNYPXhhbDFpwdiA()
		{
			if (!_controller.IsNullOrDestroyed())
			{
				eyUExPEfJOvDMpgTWfZhKmVaJVBB();
			}
		}

		internal virtual void eyUExPEfJOvDMpgTWfZhKmVaJVBB()
		{
			_controller.IsNullOrDestroyed();
		}

		internal virtual void qdlBanCKskFYgFyewDKidbPGRpbJ()
		{
			if (XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				ZBDmBmYoVxMpOXnsuZypYbLJAdh();
			}
		}

		internal virtual void IEbkrYeiXOaqriLcwiYMyUdsreAF()
		{
			_ = XrAXpRFFCZWxSkTUXpVlgetwinP;
		}

		internal virtual void bAbhGMEVPDxqJQQfarYktRFMyZO()
		{
		}

		internal bool zCDiilIuMmyrwiYynasIRcHvrxTh()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		internal bool qmntlHvdgGVuMciwwolslpmUnZI()
		{
			return this == null;
		}

		internal IComponentController FdIjkMLxxEEuKvbbblAIIHxpmdo()
		{
			return _controller;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		private IEnumerator AQsYSlioTSzDHiXXeykDSlbCPmN()
		{
			bxyqOjJZQhUUKselqbzieGldEoUt bxyqOjJZQhUUKselqbzieGldEoUt2 = new bxyqOjJZQhUUKselqbzieGldEoUt(0);
			bxyqOjJZQhUUKselqbzieGldEoUt2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			return bxyqOjJZQhUUKselqbzieGldEoUt2;
		}

		private void BlPUAqMlztMmaYIlhKUlkimOHBj()
		{
			if (USdTaHHNWIGWTOHgBLrxEkaEfPs())
			{
				bAbhGMEVPDxqJQQfarYktRFMyZO();
				XrAXpRFFCZWxSkTUXpVlgetwinP = true;
				BxlLqiGbAIUodNYPXhhbDFpwdiA();
			}
		}

		private bool OwsdNfDhieGppsibBdCXDMrmfHk(bool P_0, bool P_1)
		{
			bool flag = false;
			try
			{
				IComponentController componentController = FindController();
				if (!_controller.IsNullOrDestroyed() && _controller != componentController)
				{
					flag = true;
				}
				_controller = componentController;
				if (_controller == null)
				{
					Type type = GetRequiredControllerType();
					if ((object)type == null)
					{
						type = typeof(IComponentController);
					}
					if (P_1)
					{
						Logger.LogError(type.Name + " could not be found. You must have a component that extends from " + type.Name + " on this or a parent GameObject.");
					}
					throw new Exception();
				}
				if (!P_0 && flag)
				{
					BlPUAqMlztMmaYIlhKUlkimOHBj();
				}
				return true;
			}
			catch
			{
				KsAOKrZKgtucIHEQBDfCyMDnLoz();
				return false;
			}
		}

		private void ZBDmBmYoVxMpOXnsuZypYbLJAdh()
		{
			OwsdNfDhieGppsibBdCXDMrmfHk(false, true);
		}

		private void HJZfBnfvGrUpsjeKJEYdyoCmChag()
		{
			if (!qmntlHvdgGVuMciwwolslpmUnZI() && zCDiilIuMmyrwiYynasIRcHvrxTh())
			{
				yQdUgprBXDEoWjnetusIxRhMmAu();
			}
		}
	}
}
