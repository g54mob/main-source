using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ObjectInstanceTracker : IDisposable
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public class Wrapper<T> : IDisposable where T : class
		{
			public readonly T instance;

			public readonly uint instanceId;

			private readonly ObjectInstanceTracker CcCAhQShrtDhvKDVxQPCNYghmVA;

			private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

			public Wrapper(T instance)
				: this(instance, Default)
			{
			}

			public Wrapper(T instance, ObjectInstanceTracker tracker)
			{
				if (instance == null)
				{
					throw new ArgumentNullException("instance");
				}
				if (tracker == null)
				{
					throw new ArgumentNullException("tracker");
				}
				this.instance = instance;
				CcCAhQShrtDhvKDVxQPCNYghmVA = tracker;
				instanceId = tracker.Register(instance);
			}

			public void Dispose()
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}

			~Wrapper()
			{
				Dispose(disposing: false);
			}

			protected virtual void Dispose(bool disposing)
			{
				if (xRygqjRmTtURDPiwlgMmFcdNBrr)
				{
					return;
				}
				while (true)
				{
					int num;
					if (CcCAhQShrtDhvKDVxQPCNYghmVA != null)
					{
						CcCAhQShrtDhvKDVxQPCNYghmVA.Unregister(instanceId);
						num = 1795180748;
						goto IL_000e;
					}
					goto IL_004d;
					IL_000e:
					while (true)
					{
						switch (num ^ 0x6B0048CC)
						{
						case 3:
							num = 1795180749;
							continue;
						default:
							return;
						case 1:
							break;
						case 0:
							goto IL_004d;
						case 2:
							return;
						}
						break;
					}
					continue;
					IL_004d:
					xRygqjRmTtURDPiwlgMmFcdNBrr = true;
					num = 1795180750;
					goto IL_000e;
				}
			}
		}

		private static ObjectInstanceTracker BgVAlBbqHGOjWMKDVziUeWXeAbTf;

		private readonly Dictionary<uint, object> LnvbjdisRibUKDtIIurMCLeEainT = new Dictionary<uint, object>();

		private readonly object YpuegkWxujbfnMfHUlVMrfRPfuG = new object();

		private uint TXztSEPlNCmulrjhaCBSAEVJtII;

		private int vDOjWSFwejAQRWbOeCXIiDiruUZh;

		private bool qnZgssCoxnXhNxnAHEOPShBkPAR;

		public static ObjectInstanceTracker Default => BgVAlBbqHGOjWMKDVziUeWXeAbTf ?? (BgVAlBbqHGOjWMKDVziUeWXeAbTf = new ObjectInstanceTracker());

		public uint Register(object instance)
		{
			if (instance == null)
			{
				goto IL_0003;
			}
			goto IL_0037;
			IL_0003:
			int num = -1194883286;
			goto IL_0008;
			IL_0008:
			uint num2 = default(uint);
			switch (num ^ -1194883288)
			{
			case 3:
				break;
			case 2:
				throw new ArgumentNullException("instance");
			case 1:
				goto IL_0037;
			default:
				return num2;
			}
			goto IL_0003;
			IL_0037:
			vDOjWSFwejAQRWbOeCXIiDiruUZh++;
			num2 = TXztSEPlNCmulrjhaCBSAEVJtII++;
			LnvbjdisRibUKDtIIurMCLeEainT.Add(num2, instance);
			num = -1194883288;
			goto IL_0008;
		}

		public void Unregister(uint instanceId)
		{
			vDOjWSFwejAQRWbOeCXIiDiruUZh--;
			while (true)
			{
				int num = -203310019;
				while (true)
				{
					switch (num ^ -203310020)
					{
					case 0:
						break;
					case 1:
						if (vDOjWSFwejAQRWbOeCXIiDiruUZh < 0)
						{
							goto IL_0035;
						}
						goto default;
					default:
						lock (YpuegkWxujbfnMfHUlVMrfRPfuG)
						{
							LnvbjdisRibUKDtIIurMCLeEainT.Remove(instanceId);
							return;
						}
					}
					break;
					IL_0035:
					vDOjWSFwejAQRWbOeCXIiDiruUZh = 0;
					num = -203310018;
				}
			}
		}

		public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
		{
			bool result = default(bool);
			lock (YpuegkWxujbfnMfHUlVMrfRPfuG)
			{
				if (!LnvbjdisRibUKDtIIurMCLeEainT.TryGetValue(instanceId, out var value))
				{
					instance = null;
					goto IL_0024;
				}
				goto IL_007d;
				IL_006d:
				instance = null;
				result = false;
				int num = 1182067159;
				goto IL_0029;
				IL_0024:
				num = 1182067154;
				goto IL_0029;
				IL_0029:
				while (true)
				{
					switch (num ^ 0x4674E9D3)
					{
					case 2:
						break;
					default:
						goto end_IL_000d;
					case 1:
						result = false;
						num = 1182067157;
						continue;
					case 3:
						goto end_IL_000d;
					case 6:
						goto end_IL_000d;
					case 5:
						goto IL_006d;
					case 0:
						goto IL_007d;
					case 4:
						goto end_IL_000d;
					}
					break;
				}
				goto IL_0024;
				IL_007d:
				if (value is T)
				{
					instance = (T)value;
					result = true;
					num = 1182067152;
					goto IL_0029;
				}
				goto IL_006d;
				end_IL_000d:;
			}
			return result;
		}

		public void Dispose()
		{
			XUyPrOkreNDOTTMFamEakBsuIHM(true);
			GC.SuppressFinalize(this);
		}

		private void XUyPrOkreNDOTTMFamEakBsuIHM(bool P_0)
		{
			if (qnZgssCoxnXhNxnAHEOPShBkPAR)
			{
				return;
			}
			while (true)
			{
				int num = -716169711;
				while (true)
				{
					switch (num ^ -716169712)
					{
					case 0:
						num = -716169710;
						continue;
					case 2:
						break;
					case 1:
					{
						int num2;
						if (this == BgVAlBbqHGOjWMKDVziUeWXeAbTf)
						{
							num = -716169709;
							num2 = num;
						}
						else
						{
							num = -716169708;
							num2 = num;
						}
						continue;
					}
					case 3:
						BgVAlBbqHGOjWMKDVziUeWXeAbTf = null;
						num = -716169708;
						continue;
					default:
						qnZgssCoxnXhNxnAHEOPShBkPAR = true;
						return;
					}
					break;
				}
			}
		}

		~ObjectInstanceTracker()
		{
			XUyPrOkreNDOTTMFamEakBsuIHM(false);
		}
	}
}
