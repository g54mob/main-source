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
		private sealed class tPvbVWNINPSnGIfeapWkVPpkPGh : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			public ComponentControl iKQXbXnVtIaMZEJNeigQJWAHqUx;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			private bool MoveNext()
			{
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 0:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					aimBzjfQfPyaeQqysAQJISCBhELB = null;
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
					return true;
				case 1:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						int num = -968168786;
						while (true)
						{
							switch (num ^ -968168787)
							{
							case 0:
								num = -968168785;
								continue;
							case 2:
								break;
							case 3:
								if (iKQXbXnVtIaMZEJNeigQJWAHqUx.vWWTQEuzSAtwkwTidoREbMzaAEi())
								{
									iKQXbXnVtIaMZEJNeigQJWAHqUx.OnEnable();
									num = -968168788;
									continue;
								}
								goto end_IL_0008;
							default:
								goto end_IL_0008;
							}
							break;
						}
						goto case 0;
					}
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
			public tPvbVWNINPSnGIfeapWkVPpkPGh(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
			}
		}

		private IComponentController _controller;

		[NonSerialized]
		private bool PkVqugVNIpoYIMpSDcpjdJRrnVs;

		[NonSerialized]
		private bool uwxnzeOJCWeabnBzbinsyKaDDKm;

		private int _lastUpdateFrame = -1;

		internal abstract bool hasController { get; }

		internal bool initialized
		{
			get
			{
				return PkVqugVNIpoYIMpSDcpjdJRrnVs;
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
			if (_lastUpdateFrame == frameCount)
			{
				goto IL_000f;
			}
			goto IL_0039;
			IL_000f:
			int num = 904758352;
			goto IL_0014;
			IL_0014:
			switch (num ^ 0x35ED8453)
			{
			case 0:
				break;
			case 3:
				return;
			case 1:
				goto IL_0039;
			default:
				OnUpdate();
				return;
			}
			goto IL_000f;
			IL_0039:
			_lastUpdateFrame = frameCount;
			num = 904758353;
			goto IL_0014;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			uwxnzeOJCWeabnBzbinsyKaDDKm = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!uwxnzeOJCWeabnBzbinsyKaDDKm)
			{
				while (true)
				{
					int num = 760656369;
					while (true)
					{
						switch (num ^ 0x2D56B1F0)
						{
						case 0:
							break;
						case 2:
							return;
						case 3:
							StartCoroutine(UFZGxhuVwflbRAOHVycmPgDJfkRE());
							num = 760656373;
							continue;
						case 1:
							PkVqugVNIpoYIMpSDcpjdJRrnVs = false;
							num = 760656371;
							continue;
						case 5:
							uwxnzeOJCWeabnBzbinsyKaDDKm = true;
							num = 760656370;
							continue;
						case 6:
							goto end_IL_0008;
						default:
							goto IL_007d;
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
			goto IL_007d;
			IL_007d:
			PQSWvFQilTgIeaqvfFMnhhGbNgSO();
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			while (true)
			{
				ESBHzKHIUPqtKrgOXCXYdArebmS();
				int num = -874191986;
				while (true)
				{
					switch (num ^ -874191986)
					{
					case 2:
						goto IL_0008;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0008:
					num = -874191985;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				NVWqZPEZaDhGVdcEuqvABdsUKUL();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnCanvasGroupChanged()
		{
			if (PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				YUpNMWDdcElWfUDzNMGTYQRrnsV(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnTransformParentChanged()
		{
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = 1154031412;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x44C91F37)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				return;
			case 1:
				goto IL_0032;
			case 2:
				return;
			}
			goto IL_0008;
			IL_0032:
			YUpNMWDdcElWfUDzNMGTYQRrnsV(false, false);
			num = 1154031413;
			goto IL_000d;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDidApplyAnimationProperties()
		{
			bool pkVqugVNIpoYIMpSDcpjdJRrnV = PkVqugVNIpoYIMpSDcpjdJRrnVs;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Reset()
		{
			bool pkVqugVNIpoYIMpSDcpjdJRrnV = PkVqugVNIpoYIMpSDcpjdJRrnVs;
		}

		internal virtual void OnUpdate()
		{
		}

		internal virtual bool OnInitialize()
		{
			PkVqugVNIpoYIMpSDcpjdJRrnVs = false;
			if (!YUpNMWDdcElWfUDzNMGTYQRrnsV(true, true))
			{
				return false;
			}
			_controller.Register(this);
			return true;
		}

		internal virtual void ESBHzKHIUPqtKrgOXCXYdArebmS()
		{
			ClearValue();
			while (true)
			{
				int num = 1051518036;
				while (true)
				{
					switch (num ^ 0x3EACE455)
					{
					case 2:
						break;
					case 1:
					{
						int num2;
						if (_controller.IsNullOrDestroyed())
						{
							num = 1051518037;
							num2 = num;
						}
						else
						{
							num = 1051518038;
							num2 = num;
						}
						continue;
					}
					case 3:
						_controller.Deregister(this);
						num = 1051518037;
						continue;
					default:
						OnUnsubscribeEvents();
						PkVqugVNIpoYIMpSDcpjdJRrnVs = false;
						return;
					}
					break;
				}
			}
		}

		internal virtual void OnSubscribeEvents()
		{
			if (_controller.IsNullOrDestroyed())
			{
				goto IL_000d;
			}
			goto IL_0037;
			IL_000d:
			int num = 1622666730;
			goto IL_0012;
			IL_0012:
			switch (num ^ 0x60B7EDEB)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				return;
			case 3:
				goto IL_0037;
			case 0:
				return;
			}
			goto IL_000d;
			IL_0037:
			OnUnsubscribeEvents();
			num = 1622666731;
			goto IL_0012;
		}

		internal virtual void OnUnsubscribeEvents()
		{
			_controller.IsNullOrDestroyed();
		}

		internal virtual void OnSetProperty()
		{
			if (PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				NVWqZPEZaDhGVdcEuqvABdsUKUL();
			}
		}

		internal virtual void OnClear()
		{
			bool pkVqugVNIpoYIMpSDcpjdJRrnV = PkVqugVNIpoYIMpSDcpjdJRrnVs;
		}

		internal virtual void FindEventHandlers()
		{
		}

		internal bool vWWTQEuzSAtwkwTidoREbMzaAEi()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		internal bool umueQObHjgIFkfOkmqetfqLVJGol()
		{
			return this == null;
		}

		internal IComponentController LKDXaxXfiiwGAVtjdSCKBcNgYPZ()
		{
			return _controller;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		private IEnumerator UFZGxhuVwflbRAOHVycmPgDJfkRE()
		{
			tPvbVWNINPSnGIfeapWkVPpkPGh tPvbVWNINPSnGIfeapWkVPpkPGh2 = new tPvbVWNINPSnGIfeapWkVPpkPGh(0);
			while (true)
			{
				int num = 1285865097;
				while (true)
				{
					switch (num ^ 0x4CA4BE88)
					{
					case 0:
						break;
					case 1:
						goto IL_0025;
					default:
						return tPvbVWNINPSnGIfeapWkVPpkPGh2;
					}
					break;
					IL_0025:
					tPvbVWNINPSnGIfeapWkVPpkPGh2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
					num = 1285865098;
				}
			}
		}

		private void PQSWvFQilTgIeaqvfFMnhhGbNgSO()
		{
			if (!OnInitialize())
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = -1250068670;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1250068669)
			{
			case 3:
				break;
			case 1:
				return;
			case 2:
				goto IL_0032;
			default:
				PkVqugVNIpoYIMpSDcpjdJRrnVs = true;
				OnSubscribeEvents();
				return;
			}
			goto IL_0008;
			IL_0032:
			FindEventHandlers();
			num = -1250068669;
			goto IL_000d;
		}

		private bool YUpNMWDdcElWfUDzNMGTYQRrnsV(bool P_0, bool P_1)
		{
			bool flag = false;
			try
			{
				IComponentController componentController = FindController();
				if (!_controller.IsNullOrDestroyed() && _controller != componentController)
				{
					flag = true;
					goto IL_0027;
				}
				goto IL_00b8;
				IL_002c:
				int num;
				Type type = default(Type);
				while (true)
				{
					switch (num ^ 0x2EBB876D)
					{
					case 3:
						break;
					case 8:
						throw new Exception();
					case 5:
						if (_controller == null)
						{
							type = GetRequiredControllerType();
							num = 784041834;
							continue;
						}
						goto IL_00f7;
					case 6:
						if (P_1)
						{
							Logger.LogError(type.Name + " could not be found. You must have a component that extends from " + type.Name + " on this or a parent GameObject.");
							num = 784041829;
							continue;
						}
						goto case 8;
					case 9:
						goto IL_00b8;
					case 2:
						goto IL_00c9;
					case 7:
						goto IL_00e0;
					case 10:
						goto IL_00f7;
					case 0:
						type = typeof(IComponentController);
						num = 784041835;
						continue;
					case 1:
						PQSWvFQilTgIeaqvfFMnhhGbNgSO();
						num = 784041833;
						continue;
					default:
						return true;
					}
					break;
					IL_00e0:
					int num2;
					if (type != null)
					{
						num = 784041835;
						num2 = num;
					}
					else
					{
						num = 784041837;
						num2 = num;
					}
					continue;
					IL_00c9:
					int num3;
					if (!flag)
					{
						num = 784041833;
						num3 = num;
					}
					else
					{
						num = 784041836;
						num3 = num;
					}
					continue;
					IL_00f7:
					int num4;
					if (P_0)
					{
						num = 784041833;
						num4 = num;
					}
					else
					{
						num = 784041839;
						num4 = num;
					}
				}
				goto IL_0027;
				IL_00b8:
				_controller = componentController;
				num = 784041832;
				goto IL_002c;
				IL_0027:
				num = 784041828;
				goto IL_002c;
			}
			catch
			{
				ESBHzKHIUPqtKrgOXCXYdArebmS();
				return false;
			}
		}

		private void NVWqZPEZaDhGVdcEuqvABdsUKUL()
		{
			YUpNMWDdcElWfUDzNMGTYQRrnsV(false, true);
		}

		private void DPSbkWnOWLjrwEEUDVWndTgnDYB()
		{
			if (!umueQObHjgIFkfOkmqetfqLVJGol())
			{
				if (!vWWTQEuzSAtwkwTidoREbMzaAEi())
				{
					goto IL_0010;
				}
				goto IL_003a;
			}
			return;
			IL_003a:
			OnUpdate();
			int num = -1736994986;
			goto IL_0015;
			IL_0010:
			num = -1736994987;
			goto IL_0015;
			IL_0015:
			switch (num ^ -1736994988)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				return;
			case 0:
				goto IL_003a;
			case 2:
				return;
			}
			goto IL_0010;
		}
	}
}
