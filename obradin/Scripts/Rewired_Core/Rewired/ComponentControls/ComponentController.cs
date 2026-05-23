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
		private sealed class fVXIBWkgnfdbGAItUOWZzsGiNrX : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			public ComponentController iKQXbXnVtIaMZEJNeigQJWAHqUx;

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
				int num;
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 0:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					num = 1379785274;
					goto IL_001c;
				case 1:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = 1379785272;
						goto IL_001c;
					}
					IL_001c:
					while (true)
					{
						switch (num ^ 0x523DDA3B)
						{
						case 0:
							num = 1379785273;
							continue;
						case 2:
							break;
						case 3:
							iKQXbXnVtIaMZEJNeigQJWAHqUx.PQSWvFQilTgIeaqvfFMnhhGbNgSO();
							num = 1379785279;
							continue;
						case 5:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							return true;
						case 1:
							aimBzjfQfPyaeQqysAQJISCBhELB = null;
							num = 1379785278;
							continue;
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
			public fVXIBWkgnfdbGAItUOWZzsGiNrX(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
			}
		}

		[NonSerialized]
		private bool PkVqugVNIpoYIMpSDcpjdJRrnVs;

		[NonSerialized]
		private bool uwxnzeOJCWeabnBzbinsyKaDDKm;

		private List<IComponentControl> _controls = new List<IComponentControl>(10);

		internal bool initialized
		{
			get
			{
				return PkVqugVNIpoYIMpSDcpjdJRrnVs;
			}
		}

		[CustomObfuscation(rename = false)]
		internal ComponentController()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			uwxnzeOJCWeabnBzbinsyKaDDKm = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Update()
		{
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				return;
			}
			IComponentControl componentControl = default(IComponentControl);
			while (true)
			{
				int num = _controls.Count - 1;
				int num2 = 1691962231;
				while (true)
				{
					switch (num2 ^ 0x64D94B77)
					{
					case 2:
						num2 = 1691962230;
						continue;
					default:
						return;
					case 3:
						componentControl.Update();
						num2 = 1691962226;
						continue;
					case 7:
						componentControl = _controls[num];
						num2 = 1691962225;
						continue;
					case 5:
						num--;
						num2 = 1691962231;
						continue;
					case 6:
						if (componentControl.IsNullOrDestroyed())
						{
							_controls.RemoveAt(num);
							num2 = 1691962226;
							continue;
						}
						goto case 3;
					case 0:
					{
						int num3;
						if (num >= 0)
						{
							num2 = 1691962224;
							num3 = num2;
						}
						else
						{
							num2 = 1691962227;
							num3 = num2;
						}
						continue;
					}
					case 1:
						break;
					case 4:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!uwxnzeOJCWeabnBzbinsyKaDDKm)
			{
				StartCoroutine(ITElLdViqdCgTLGvrBGokvbHgub());
				uwxnzeOJCWeabnBzbinsyKaDDKm = true;
				return;
			}
			while (true)
			{
				PQSWvFQilTgIeaqvfFMnhhGbNgSO();
				int num = -1880246151;
				while (true)
				{
					switch (num ^ -1880246149)
					{
					case 0:
						goto IL_001d;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_001d:
					num = -1880246150;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				return;
			}
			while (true)
			{
				OnUnsubscribeEvents();
				int num = -2077859008;
				while (true)
				{
					switch (num ^ -2077859008)
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
					num = -2077859007;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				return;
			}
			while (true)
			{
				wQiEPKGVkSYAiCZoyTUamohUIKKd();
				int num = -1387289849;
				while (true)
				{
					switch (num ^ -1387289851)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0009:
					num = -1387289852;
				}
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
			if (P_0.IsNullOrDestroyed())
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = 606971849;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x242DA7CA)
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
			ListTools.AddIfUnique(_controls, P_0);
			num = 606971848;
			goto IL_000d;
		}

		void IRegistrar<IComponentControl>.Deregister(IComponentControl P_0)
		{
			if (P_0.IsNullOrDestroyed())
			{
				while (true)
				{
					switch (-889164501 ^ -889164503)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			_controls.Remove(P_0);
		}

		public virtual void ClearControlValues()
		{
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				return;
			}
			while (true)
			{
				int num = _controls.Count - 1;
				int num2 = 1227932175;
				while (true)
				{
					switch (num2 ^ 0x4930C20F)
					{
					case 2:
						num2 = 1227932169;
						continue;
					case 4:
						num--;
						num2 = 1227932170;
						continue;
					case 3:
						if (_controls[num].IsNullOrDestroyed())
						{
							_controls.RemoveAt(num);
							num2 = 1227932171;
							continue;
						}
						goto case 1;
					case 0:
						num2 = 1227932170;
						continue;
					case 1:
						_controls[num].ClearValue();
						num2 = 1227932171;
						continue;
					case 6:
						break;
					default:
						if (num < 0)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		private void PQSWvFQilTgIeaqvfFMnhhGbNgSO()
		{
			if (!OnInitialize())
			{
				return;
			}
			while (true)
			{
				PkVqugVNIpoYIMpSDcpjdJRrnVs = true;
				OnSubscribeEvents();
				int num = -1664630297;
				while (true)
				{
					switch (num ^ -1664630299)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0009:
					num = -1664630300;
				}
			}
		}

		private void wQiEPKGVkSYAiCZoyTUamohUIKKd()
		{
			bool initialized2 = initialized;
		}

		private IEnumerator ITElLdViqdCgTLGvrBGokvbHgub()
		{
			fVXIBWkgnfdbGAItUOWZzsGiNrX fVXIBWkgnfdbGAItUOWZzsGiNrX2 = new fVXIBWkgnfdbGAItUOWZzsGiNrX(0);
			fVXIBWkgnfdbGAItUOWZzsGiNrX2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			return fVXIBWkgnfdbGAItUOWZzsGiNrX2;
		}
	}
}
