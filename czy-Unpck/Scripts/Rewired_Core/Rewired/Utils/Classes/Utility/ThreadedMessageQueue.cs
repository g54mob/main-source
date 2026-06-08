using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ThreadedMessageQueue<T> : IDisposable
	{
		private readonly int xdwhWwBjoxauLQwEsCYZGiYvxpMA;

		private readonly int UgFDRccxOgyjhNuDLEeHJsMXlni;

		private readonly int mHwabdAZablQMrebUDyEmRPykqH;

		private readonly bool DnhmbaJJCdyuFSTPhmbCGBmwJAC;

		private ThreadHelper fqsCBjdBBAqwxHGTJtzpEGieeHqQ;

		private Queue<T> PQFjuGDltvFBkqidmDFLagKpwOh;

		private Queue<T> cySqMZAJXUybjwpZfboJpogyryU;

		private bool HFkKVChhvESkmWpzwPLuarkiTPt;

		private bool PwPWygBTznyByBIyaAyqEfnsXBM;

		private Action<T> heMwLqDAbyHkpIMdnMaWfFekGhu;

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

		public ThreadedMessageQueue(int maxQueueSize, int threadRefreshRateFPS, int threadAutoKillTimeoutMS, bool threadBlockOnStartAndStop, Action<T> messageReceiverDelegate)
		{
			while (true)
			{
				int num = 1692947971;
				while (true)
				{
					switch (num ^ 0x64E85600)
					{
					case 6:
						break;
					default:
						return;
					case 0:
						UgFDRccxOgyjhNuDLEeHJsMXlni = threadRefreshRateFPS;
						mHwabdAZablQMrebUDyEmRPykqH = threadAutoKillTimeoutMS;
						DnhmbaJJCdyuFSTPhmbCGBmwJAC = threadBlockOnStartAndStop;
						heMwLqDAbyHkpIMdnMaWfFekGhu = messageReceiverDelegate;
						num = 1692947970;
						continue;
					case 7:
						if (threadAutoKillTimeoutMS < 0)
						{
							threadAutoKillTimeoutMS = 0;
							num = 1692947973;
							continue;
						}
						goto case 5;
					case 9:
						threadRefreshRateFPS = 0;
						num = 1692947975;
						continue;
					case 3:
						if (messageReceiverDelegate == null)
						{
							throw new ArgumentNullException("messageReceiverDelegate");
						}
						goto case 1;
					case 1:
						if (maxQueueSize < 0)
						{
							maxQueueSize = 0;
							num = 1692947976;
							continue;
						}
						goto case 8;
					case 2:
						PQFjuGDltvFBkqidmDFLagKpwOh = new Queue<T>(maxQueueSize);
						cySqMZAJXUybjwpZfboJpogyryU = new Queue<T>(maxQueueSize);
						num = 1692947972;
						continue;
					case 8:
					{
						int num2;
						if (threadRefreshRateFPS >= 0)
						{
							num = 1692947975;
							num2 = num;
						}
						else
						{
							num = 1692947977;
							num2 = num;
						}
						continue;
					}
					case 5:
						xdwhWwBjoxauLQwEsCYZGiYvxpMA = maxQueueSize;
						num = 1692947968;
						continue;
					case 4:
						return;
					}
					break;
				}
			}
		}

		public void Enqueue(T message)
		{
			if (!POOLsDGSQBqeMtHOQtJgSqyMaxe())
			{
				while (true)
				{
					switch (0x50BEE5DA ^ 0x50BEE5D8)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			lock (PQFjuGDltvFBkqidmDFLagKpwOh)
			{
				if (xdwhWwBjoxauLQwEsCYZGiYvxpMA > 0)
				{
					while (true)
					{
						int num;
						int num2;
						if (PQFjuGDltvFBkqidmDFLagKpwOh.Count >= xdwhWwBjoxauLQwEsCYZGiYvxpMA)
						{
							num = 1354687961;
							num2 = num;
						}
						else
						{
							num = 1354687963;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x50BEE5D8)
							{
							case 0:
								num = 1354687961;
								continue;
							case 1:
								PQFjuGDltvFBkqidmDFLagKpwOh.Dequeue();
								num = 1354687962;
								continue;
							case 2:
								break;
							default:
								goto end_IL_007b;
							}
							break;
						}
						continue;
						end_IL_007b:
						break;
					}
				}
				PQFjuGDltvFBkqidmDFLagKpwOh.Enqueue(message);
			}
		}

		private bool POOLsDGSQBqeMtHOQtJgSqyMaxe()
		{
			if (HFkKVChhvESkmWpzwPLuarkiTPt)
			{
				return false;
			}
			if (!BLojMYGzGzwkmTIAuatTfUggLHZd())
			{
				return false;
			}
			if (PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				return true;
			}
			PwPWygBTznyByBIyaAyqEfnsXBM = true;
			return true;
		}

		private bool BLojMYGzGzwkmTIAuatTfUggLHZd()
		{
			if (HFkKVChhvESkmWpzwPLuarkiTPt)
			{
				return false;
			}
			if (fqsCBjdBBAqwxHGTJtzpEGieeHqQ == null)
			{
				try
				{
					fqsCBjdBBAqwxHGTJtzpEGieeHqQ = ThreadHelper.CreateFixedTimeStep(UgFDRccxOgyjhNuDLEeHJsMXlni, mHwabdAZablQMrebUDyEmRPykqH);
					fqsCBjdBBAqwxHGTJtzpEGieeHqQ.ThreadUpdateEvent += ReWtOZFlieWvrDhaFtwIYbSOiVM;
					fqsCBjdBBAqwxHGTJtzpEGieeHqQ.Start(DnhmbaJJCdyuFSTPhmbCGBmwJAC);
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (fqsCBjdBBAqwxHGTJtzpEGieeHqQ != null)
					{
						fqsCBjdBBAqwxHGTJtzpEGieeHqQ.Stop(DnhmbaJJCdyuFSTPhmbCGBmwJAC);
					}
					HFkKVChhvESkmWpzwPLuarkiTPt = true;
					return false;
				}
			}
			if (!fqsCBjdBBAqwxHGTJtzpEGieeHqQ.isRunning)
			{
				goto IL_009c;
			}
			goto IL_00db;
			IL_00db:
			int num;
			if (mHwabdAZablQMrebUDyEmRPykqH > 0)
			{
				fqsCBjdBBAqwxHGTJtzpEGieeHqQ.ResetTimeout();
				num = 1623830154;
				goto IL_00a1;
			}
			goto IL_00fd;
			IL_00fd:
			return true;
			IL_009c:
			num = 1623830155;
			goto IL_00a1;
			IL_00a1:
			while (true)
			{
				switch (num ^ 0x60C9AE8A)
				{
				case 3:
					break;
				case 1:
					fqsCBjdBBAqwxHGTJtzpEGieeHqQ.Start(DnhmbaJJCdyuFSTPhmbCGBmwJAC);
					num = 1623830152;
					continue;
				case 4:
					goto IL_00db;
				case 2:
					num = 1623830154;
					continue;
				default:
					goto IL_00fd;
				}
				break;
			}
			goto IL_009c;
		}

		private void LIpiGqGLcWmOqvcQwFoncHHNDxY()
		{
			lock (PQFjuGDltvFBkqidmDFLagKpwOh)
			{
				lock (cySqMZAJXUybjwpZfboJpogyryU)
				{
					MiscTools.Swap(ref PQFjuGDltvFBkqidmDFLagKpwOh, ref cySqMZAJXUybjwpZfboJpogyryU);
				}
			}
		}

		private void ReWtOZFlieWvrDhaFtwIYbSOiVM()
		{
			LIpiGqGLcWmOqvcQwFoncHHNDxY();
			lock (cySqMZAJXUybjwpZfboJpogyryU)
			{
				while (cySqMZAJXUybjwpZfboJpogyryU.Count > 0)
				{
					try
					{
						heMwLqDAbyHkpIMdnMaWfFekGhu(cySqMZAJXUybjwpZfboJpogyryU.Dequeue());
					}
					catch (Exception ex)
					{
						Logger.LogError("An exception occurred while sending message.\nMessage: " + ex.Message, requiredThreadSafety: true);
					}
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~ThreadedMessageQueue()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				return;
			}
			if (disposing)
			{
				if (PQFjuGDltvFBkqidmDFLagKpwOh != null)
				{
					if (cySqMZAJXUybjwpZfboJpogyryU != null)
					{
						lock (PQFjuGDltvFBkqidmDFLagKpwOh)
						{
							lock (cySqMZAJXUybjwpZfboJpogyryU)
							{
								PQFjuGDltvFBkqidmDFLagKpwOh.Clear();
								while (true)
								{
									IL_0047:
									int num = 880354430;
									while (true)
									{
										switch (num ^ 0x3479247F)
										{
										case 0:
											break;
										default:
											goto end_IL_004c;
										case 1:
											goto IL_0065;
										case 2:
											goto end_IL_004c;
										}
										goto IL_0047;
										IL_0065:
										cySqMZAJXUybjwpZfboJpogyryU.Clear();
										num = 880354429;
										continue;
										end_IL_004c:
										break;
									}
									break;
								}
							}
						}
					}
					else
					{
						lock (PQFjuGDltvFBkqidmDFLagKpwOh)
						{
							PQFjuGDltvFBkqidmDFLagKpwOh.Clear();
						}
					}
				}
				else if (cySqMZAJXUybjwpZfboJpogyryU != null)
				{
					lock (cySqMZAJXUybjwpZfboJpogyryU)
					{
						cySqMZAJXUybjwpZfboJpogyryU.Clear();
					}
				}
				if (fqsCBjdBBAqwxHGTJtzpEGieeHqQ != null)
				{
					fqsCBjdBBAqwxHGTJtzpEGieeHqQ.Dispose();
					goto IL_00e6;
				}
			}
			goto IL_0104;
			IL_00eb:
			int num2;
			switch (num2 ^ 0x3479247F)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				goto IL_0104;
			case 1:
				return;
			}
			goto IL_00e6;
			IL_0104:
			xRygqjRmTtURDPiwlgMmFcdNBrr = true;
			num2 = 880354430;
			goto IL_00eb;
			IL_00e6:
			num2 = 880354429;
			goto IL_00eb;
		}
	}
}
