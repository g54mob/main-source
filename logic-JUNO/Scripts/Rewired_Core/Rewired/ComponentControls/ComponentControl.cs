using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class ComponentControl : MonoBehaviour, IComponentControl
	{
		private sealed class adHCTibgESffoqEUKXtphtlZqTPx : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int yDXVQtCmAQavJhAxAzDfdNvpwvBRA;

			private object BhqLECTxgyLksrhvAxruyKOyFRidA;

			public ComponentControl GSZgbQHGekBQoNYPKvJsqiogNjZH;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return BhqLECTxgyLksrhvAxruyKOyFRidA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return BhqLECTxgyLksrhvAxruyKOyFRidA;
				}
			}

			[DebuggerHidden]
			public adHCTibgESffoqEUKXtphtlZqTPx(int P_0)
			{
				yDXVQtCmAQavJhAxAzDfdNvpwvBRA = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = yDXVQtCmAQavJhAxAzDfdNvpwvBRA;
				ComponentControl gSZgbQHGekBQoNYPKvJsqiogNjZH = GSZgbQHGekBQoNYPKvJsqiogNjZH;
				switch (num)
				{
				default:
					return false;
				case 0:
					yDXVQtCmAQavJhAxAzDfdNvpwvBRA = -1;
					BhqLECTxgyLksrhvAxruyKOyFRidA = null;
					yDXVQtCmAQavJhAxAzDfdNvpwvBRA = 1;
					return true;
				case 1:
					yDXVQtCmAQavJhAxAzDfdNvpwvBRA = -1;
					if (!gSZgbQHGekBQoNYPKvJsqiogNjZH.PBRHZQINZfANWEOTugUlepRFdGfJ())
					{
						return false;
					}
					gSZgbQHGekBQoNYPKvJsqiogNjZH.OnEnable();
					return false;
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
		}

		private IComponentController _controller;

		[NonSerialized]
		private bool BjlfIuQfCAAKtFAUXmDhAzZxoKgJ;

		[NonSerialized]
		private bool iMCSTaWUcHdmdvBHEcNwtXbwpPdt;

		private int _lastUpdateFrame = -1;

		internal abstract bool fWzcsqpjMiHugIFEsnxLnuyMnmGF { get; }

		internal bool yISpryJPgsMScBhfNPMzRXpbpssc => BjlfIuQfCAAKtFAUXmDhAzZxoKgJ;

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
				XadwAoSmPfgqpkILfIkgfANXfddcb();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			iMCSTaWUcHdmdvBHEcNwtXbwpPdt = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!iMCSTaWUcHdmdvBHEcNwtXbwpPdt)
			{
				BjlfIuQfCAAKtFAUXmDhAzZxoKgJ = false;
				StartCoroutine(BguBtrggzmbkNWdGoqSXBzQBOTMPc());
				iMCSTaWUcHdmdvBHEcNwtXbwpPdt = true;
			}
			else if (Application.isPlaying)
			{
				RMPDKKfsBGMfiDhUwhOgyumqjkuQ();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (Application.isPlaying)
			{
				wQKmMovSfAoHEelJWXdWfyQHxdvP();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (BjlfIuQfCAAKtFAUXmDhAzZxoKgJ)
			{
				AECxBlVZoqKmotYgzTArTePybCbX();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnCanvasGroupChanged()
		{
			if (BjlfIuQfCAAKtFAUXmDhAzZxoKgJ)
			{
				eyCUOppnGgszCYoAlUVUjOuSCyjY(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnTransformParentChanged()
		{
			if (BjlfIuQfCAAKtFAUXmDhAzZxoKgJ)
			{
				eyCUOppnGgszCYoAlUVUjOuSCyjY(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDidApplyAnimationProperties()
		{
			_ = BjlfIuQfCAAKtFAUXmDhAzZxoKgJ;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Reset()
		{
			_ = BjlfIuQfCAAKtFAUXmDhAzZxoKgJ;
		}

		internal virtual void XadwAoSmPfgqpkILfIkgfANXfddcb()
		{
		}

		internal virtual bool kQSdBYbKoLxckNhngUuODXUumNm()
		{
			BjlfIuQfCAAKtFAUXmDhAzZxoKgJ = false;
			if (!eyCUOppnGgszCYoAlUVUjOuSCyjY(true, true))
			{
				return false;
			}
			_controller.Register(this);
			return true;
		}

		internal virtual void wQKmMovSfAoHEelJWXdWfyQHxdvP()
		{
			ClearValue();
			if (!_controller.IsNullOrDestroyed())
			{
				_controller.Deregister(this);
			}
			zCjnzoEBxLKqWxdjJrurUSAyOlmA();
			BjlfIuQfCAAKtFAUXmDhAzZxoKgJ = false;
		}

		internal virtual void HAvmCSbdxkijLlEaJbzuvcLzMOvB()
		{
			if (!_controller.IsNullOrDestroyed())
			{
				zCjnzoEBxLKqWxdjJrurUSAyOlmA();
			}
		}

		internal virtual void zCjnzoEBxLKqWxdjJrurUSAyOlmA()
		{
			_controller.IsNullOrDestroyed();
		}

		internal virtual void GsBcXKiqrkqzLgoLvZRKojGmaLbaA()
		{
			if (BjlfIuQfCAAKtFAUXmDhAzZxoKgJ)
			{
				AECxBlVZoqKmotYgzTArTePybCbX();
			}
		}

		internal virtual void prOtrdqYwZXkFcvprrpMujpofLsg()
		{
			_ = BjlfIuQfCAAKtFAUXmDhAzZxoKgJ;
		}

		internal virtual void nXumCRMnDCjEenDugoLTYqsFcIGd()
		{
		}

		internal bool PBRHZQINZfANWEOTugUlepRFdGfJ()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		internal bool aRhZbmfBYfGRahvrizgOWqeldBib()
		{
			return this == null;
		}

		internal IComponentController aIdRCmPaDeGXwbkKhErvDnPFSYEkb()
		{
			return _controller;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		[IteratorStateMachine(typeof(adHCTibgESffoqEUKXtphtlZqTPx))]
		private IEnumerator BguBtrggzmbkNWdGoqSXBzQBOTMPc()
		{
			return new adHCTibgESffoqEUKXtphtlZqTPx(0)
			{
				GSZgbQHGekBQoNYPKvJsqiogNjZH = this
			};
		}

		private void RMPDKKfsBGMfiDhUwhOgyumqjkuQ()
		{
			if (kQSdBYbKoLxckNhngUuODXUumNm())
			{
				nXumCRMnDCjEenDugoLTYqsFcIGd();
				BjlfIuQfCAAKtFAUXmDhAzZxoKgJ = true;
				HAvmCSbdxkijLlEaJbzuvcLzMOvB();
			}
		}

		private bool eyCUOppnGgszCYoAlUVUjOuSCyjY(bool P_0, bool P_1)
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
					if (type == null)
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
					RMPDKKfsBGMfiDhUwhOgyumqjkuQ();
				}
				return true;
			}
			catch
			{
				wQKmMovSfAoHEelJWXdWfyQHxdvP();
				return false;
			}
		}

		private void AECxBlVZoqKmotYgzTArTePybCbX()
		{
			eyCUOppnGgszCYoAlUVUjOuSCyjY(false, true);
		}

		private void AIPxVYiferOXEauFDSIyjdhLLjCW()
		{
			if (!aRhZbmfBYfGRahvrizgOWqeldBib() && PBRHZQINZfANWEOTugUlepRFdGfJ())
			{
				XadwAoSmPfgqpkILfIkgfANXfddcb();
			}
		}
	}
}
