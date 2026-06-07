using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ThreadedMessageQueue<T> : IDisposable
	{
		private readonly int YbstzdZaHvrRUDrxhvOIwRswiSd;

		private readonly int deLcfxQlroiAwsAsCJOMDFkGkjJ;

		private readonly int BhgKHqwvPnugDUlQDnPLiEjtppk;

		private readonly bool mplcBthrvxLxQAfoAaPHNYOjnNlQ;

		private ThreadHelper CogoXqfgoUvretoPEYaoWIkbAAZ;

		private Queue<T> cvDHIVdiUzFSbeXKrLmYkXiwAPOa;

		private Queue<T> XTAclOePoUXewLksqnLSzPKzYpb;

		private bool iGaqCHVEOQgpbvJMvjetJqAnxOU;

		private bool uvRIxvvRCxrfpiSXpAlvYqJtnEz;

		private Action<T> WKOFTjJfYuzMoibKmuzNadOrSoZs;

		private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

		public ThreadedMessageQueue(int maxQueueSize, int threadRefreshRateFPS, int threadAutoKillTimeoutMS, bool threadBlockOnStartAndStop, Action<T> messageReceiverDelegate)
		{
			if (messageReceiverDelegate == null)
			{
				throw new ArgumentNullException("messageReceiverDelegate");
			}
			if (maxQueueSize < 0)
			{
				maxQueueSize = 0;
			}
			if (threadRefreshRateFPS < 0)
			{
				threadRefreshRateFPS = 0;
			}
			if (threadAutoKillTimeoutMS < 0)
			{
				threadAutoKillTimeoutMS = 0;
			}
			YbstzdZaHvrRUDrxhvOIwRswiSd = maxQueueSize;
			deLcfxQlroiAwsAsCJOMDFkGkjJ = threadRefreshRateFPS;
			BhgKHqwvPnugDUlQDnPLiEjtppk = threadAutoKillTimeoutMS;
			mplcBthrvxLxQAfoAaPHNYOjnNlQ = threadBlockOnStartAndStop;
			WKOFTjJfYuzMoibKmuzNadOrSoZs = messageReceiverDelegate;
			cvDHIVdiUzFSbeXKrLmYkXiwAPOa = new Queue<T>(maxQueueSize);
			XTAclOePoUXewLksqnLSzPKzYpb = new Queue<T>(maxQueueSize);
		}

		public void Enqueue(T message)
		{
			if (!uQEBmSjyfRHnLAGcBmMfKMKLWzNM())
			{
				return;
			}
			lock (cvDHIVdiUzFSbeXKrLmYkXiwAPOa)
			{
				if (YbstzdZaHvrRUDrxhvOIwRswiSd > 0)
				{
					goto IL_005a;
				}
				goto IL_007e;
				IL_005a:
				int num;
				int num2;
				if (cvDHIVdiUzFSbeXKrLmYkXiwAPOa.Count >= YbstzdZaHvrRUDrxhvOIwRswiSd)
				{
					num = -763839098;
					num2 = num;
				}
				else
				{
					num = -763839101;
					num2 = num;
				}
				goto IL_0026;
				IL_007e:
				cvDHIVdiUzFSbeXKrLmYkXiwAPOa.Enqueue(message);
				num = -763839103;
				goto IL_0026;
				IL_0026:
				while (true)
				{
					switch (num ^ -763839102)
					{
					case 0:
						num = -763839098;
						continue;
					default:
						return;
					case 4:
						cvDHIVdiUzFSbeXKrLmYkXiwAPOa.Dequeue();
						num = -763839104;
						continue;
					case 2:
						break;
					case 1:
						goto IL_007e;
					case 3:
						return;
					}
					break;
				}
				goto IL_005a;
			}
		}

		private bool uQEBmSjyfRHnLAGcBmMfKMKLWzNM()
		{
			if (iGaqCHVEOQgpbvJMvjetJqAnxOU)
			{
				return false;
			}
			if (!ymkrTVsttbjnneijraQGWqGdeWaf())
			{
				goto IL_0012;
			}
			int num;
			if (uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				num = 995472102;
				goto IL_0017;
			}
			uvRIxvvRCxrfpiSXpAlvYqJtnEz = true;
			return true;
			IL_0017:
			switch (num ^ 0x3B55B2E4)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				return true;
			}
			goto IL_0012;
			IL_0012:
			num = 995472101;
			goto IL_0017;
		}

		private bool ymkrTVsttbjnneijraQGWqGdeWaf()
		{
			if (iGaqCHVEOQgpbvJMvjetJqAnxOU)
			{
				return false;
			}
			if (CogoXqfgoUvretoPEYaoWIkbAAZ == null)
			{
				bool result = default(bool);
				try
				{
					CogoXqfgoUvretoPEYaoWIkbAAZ = ThreadHelper.CreateFixedTimeStep(deLcfxQlroiAwsAsCJOMDFkGkjJ, BhgKHqwvPnugDUlQDnPLiEjtppk);
					CogoXqfgoUvretoPEYaoWIkbAAZ.ThreadUpdateEvent += eASDrYzhBmVRwaVPOObNEmaDUuh;
					CogoXqfgoUvretoPEYaoWIkbAAZ.Start(mplcBthrvxLxQAfoAaPHNYOjnNlQ);
					while (true)
					{
						IL_0055:
						int num = 205979164;
						while (true)
						{
							switch (num ^ 0xC46FE1D)
							{
							case 0:
								break;
							default:
								goto end_IL_005a;
							case 1:
								goto IL_0073;
							case 2:
								goto end_IL_005a;
							}
							goto IL_0055;
							IL_0073:
							result = true;
							num = 205979167;
							continue;
							end_IL_005a:
							break;
						}
						break;
					}
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, true);
					if (CogoXqfgoUvretoPEYaoWIkbAAZ != null)
					{
						goto IL_009b;
					}
					goto IL_00d9;
					IL_009b:
					int num2 = 205979166;
					goto IL_00a0;
					IL_00a0:
					while (true)
					{
						switch (num2 ^ 0xC46FE1D)
						{
						case 2:
							break;
						default:
							goto end_IL_0081;
						case 3:
							CogoXqfgoUvretoPEYaoWIkbAAZ.Stop(mplcBthrvxLxQAfoAaPHNYOjnNlQ);
							num2 = 205979161;
							continue;
						case 4:
							goto IL_00d9;
						case 1:
							result = false;
							num2 = 205979165;
							continue;
						case 0:
							goto end_IL_0081;
						}
						break;
					}
					goto IL_009b;
					IL_00d9:
					iGaqCHVEOQgpbvJMvjetJqAnxOU = true;
					num2 = 205979164;
					goto IL_00a0;
					end_IL_0081:;
				}
				return result;
			}
			if (!CogoXqfgoUvretoPEYaoWIkbAAZ.isRunning)
			{
				goto IL_00ff;
			}
			goto IL_013a;
			IL_013a:
			int num3;
			if (BhgKHqwvPnugDUlQDnPLiEjtppk > 0)
			{
				CogoXqfgoUvretoPEYaoWIkbAAZ.ResetTimeout();
				num3 = 205979166;
				goto IL_0104;
			}
			goto IL_0155;
			IL_0155:
			return true;
			IL_00ff:
			num3 = 205979164;
			goto IL_0104;
			IL_0104:
			while (true)
			{
				switch (num3 ^ 0xC46FE1D)
				{
				case 0:
					break;
				case 1:
					CogoXqfgoUvretoPEYaoWIkbAAZ.Start(mplcBthrvxLxQAfoAaPHNYOjnNlQ);
					num3 = 205979166;
					continue;
				case 2:
					goto IL_013a;
				default:
					goto IL_0155;
				}
				break;
			}
			goto IL_00ff;
		}

		private void eHpGVxiaHSmblGNbxSwcupzUskx()
		{
			lock (cvDHIVdiUzFSbeXKrLmYkXiwAPOa)
			{
				lock (XTAclOePoUXewLksqnLSzPKzYpb)
				{
					MiscTools.Swap(ref cvDHIVdiUzFSbeXKrLmYkXiwAPOa, ref XTAclOePoUXewLksqnLSzPKzYpb);
				}
			}
		}

		private void eASDrYzhBmVRwaVPOObNEmaDUuh()
		{
			eHpGVxiaHSmblGNbxSwcupzUskx();
			lock (XTAclOePoUXewLksqnLSzPKzYpb)
			{
				while (XTAclOePoUXewLksqnLSzPKzYpb.Count > 0)
				{
					try
					{
						WKOFTjJfYuzMoibKmuzNadOrSoZs(XTAclOePoUXewLksqnLSzPKzYpb.Dequeue());
					}
					catch (Exception ex)
					{
						Logger.LogError("An exception occurred while sending message.\nMessage: " + ex.Message, true);
					}
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~ThreadedMessageQueue()
		{
			Dispose(false);
		}

		protected void Dispose(bool disposing)
		{
			if (QQqHByfwytAJSuMZiCPjJlZYHKG)
			{
				return;
			}
			while (disposing)
			{
				int num = -1187942669;
				while (true)
				{
					switch (num ^ -1187942669)
					{
					case 2:
						num = -1187942670;
						continue;
					case 1:
						break;
					default:
						goto IL_0034;
					}
					break;
				}
				continue;
				IL_0034:
				if (cvDHIVdiUzFSbeXKrLmYkXiwAPOa != null)
				{
					if (XTAclOePoUXewLksqnLSzPKzYpb != null)
					{
						lock (cvDHIVdiUzFSbeXKrLmYkXiwAPOa)
						{
							lock (XTAclOePoUXewLksqnLSzPKzYpb)
							{
								cvDHIVdiUzFSbeXKrLmYkXiwAPOa.Clear();
								XTAclOePoUXewLksqnLSzPKzYpb.Clear();
							}
						}
					}
					else
					{
						lock (cvDHIVdiUzFSbeXKrLmYkXiwAPOa)
						{
							cvDHIVdiUzFSbeXKrLmYkXiwAPOa.Clear();
						}
					}
				}
				else if (XTAclOePoUXewLksqnLSzPKzYpb != null)
				{
					lock (XTAclOePoUXewLksqnLSzPKzYpb)
					{
						XTAclOePoUXewLksqnLSzPKzYpb.Clear();
					}
				}
				if (CogoXqfgoUvretoPEYaoWIkbAAZ == null)
				{
					break;
				}
				while (true)
				{
					int num2 = -1187942670;
					while (true)
					{
						switch (num2 ^ -1187942669)
						{
						case 2:
							break;
						case 1:
							CogoXqfgoUvretoPEYaoWIkbAAZ.Dispose();
							num2 = -1187942669;
							continue;
						default:
							goto end_IL_0027;
						}
						break;
					}
				}
				continue;
				end_IL_0027:
				break;
			}
			QQqHByfwytAJSuMZiCPjJlZYHKG = true;
		}
	}
}
