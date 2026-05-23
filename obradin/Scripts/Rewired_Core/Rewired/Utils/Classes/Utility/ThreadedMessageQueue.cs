using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ThreadedMessageQueue<T> : IDisposable
	{
		private readonly int pzaiqLrJolSdtvaFJdGRRskSbec;

		private readonly int WBfvgaxdsNQFSvGwNIGecXShaC;

		private readonly int iYosAjSwJnvFygvFveTRTutbdyr;

		private readonly bool NSdSEgHftreGfBRvWNZBErWjlCaJ;

		private ThreadHelper xgExdbVyAKUPeHviEQuSfAnlZIs;

		private Queue<T> JsJRLMHhOlifEhbTNkmSXHoonYTG;

		private Queue<T> ghUgzDQSaGJRBfduCReQSOtdsfy;

		private bool ZtgCzKdfGSWUWDTDXtkdTKMjYBN;

		private bool PkVqugVNIpoYIMpSDcpjdJRrnVs;

		private Action<T> pwKyOoZgIablLfHRQNrLyOQhWxQA;

		private bool vsurYtRlepcrpAzAENwjqjJEZPT;

		public ThreadedMessageQueue(int maxQueueSize, int threadRefreshRateFPS, int threadAutoKillTimeoutMS, bool threadBlockOnStartAndStop, Action<T> messageReceiverDelegate)
		{
			while (true)
			{
				int num = 1148718334;
				while (true)
				{
					switch (num ^ 0x44780CFB)
					{
					case 3:
						break;
					case 5:
					{
						int num2;
						if (messageReceiverDelegate == null)
						{
							num = 1148718323;
							num2 = num;
						}
						else
						{
							num = 1148718331;
							num2 = num;
						}
						continue;
					}
					case 8:
						throw new ArgumentNullException("messageReceiverDelegate");
					case 0:
					{
						int num3;
						if (maxQueueSize >= 0)
						{
							num = 1148718330;
							num3 = num;
						}
						else
						{
							num = 1148718332;
							num3 = num;
						}
						continue;
					}
					case 7:
						maxQueueSize = 0;
						num = 1148718330;
						continue;
					case 2:
						if (threadAutoKillTimeoutMS < 0)
						{
							threadAutoKillTimeoutMS = 0;
							num = 1148718335;
							continue;
						}
						goto case 4;
					case 1:
						if (threadRefreshRateFPS < 0)
						{
							threadRefreshRateFPS = 0;
							num = 1148718329;
							continue;
						}
						goto case 2;
					case 4:
						pzaiqLrJolSdtvaFJdGRRskSbec = maxQueueSize;
						WBfvgaxdsNQFSvGwNIGecXShaC = threadRefreshRateFPS;
						iYosAjSwJnvFygvFveTRTutbdyr = threadAutoKillTimeoutMS;
						NSdSEgHftreGfBRvWNZBErWjlCaJ = threadBlockOnStartAndStop;
						pwKyOoZgIablLfHRQNrLyOQhWxQA = messageReceiverDelegate;
						num = 1148718333;
						continue;
					default:
						JsJRLMHhOlifEhbTNkmSXHoonYTG = new Queue<T>(maxQueueSize);
						ghUgzDQSaGJRBfduCReQSOtdsfy = new Queue<T>(maxQueueSize);
						return;
					}
					break;
				}
			}
		}

		public void Enqueue(T message)
		{
			if (!PQSWvFQilTgIeaqvfFMnhhGbNgSO())
			{
				return;
			}
			lock (JsJRLMHhOlifEhbTNkmSXHoonYTG)
			{
				if (pzaiqLrJolSdtvaFJdGRRskSbec > 0)
				{
					while (true)
					{
						int num = 1143208425;
						while (true)
						{
							switch (num ^ 0x4423F9EA)
							{
							case 4:
								break;
							case 3:
								num = 1143208427;
								continue;
							case 0:
								JsJRLMHhOlifEhbTNkmSXHoonYTG.Dequeue();
								num = 1143208427;
								continue;
							case 1:
								goto IL_005f;
							default:
								goto end_IL_001f;
							}
							break;
							IL_005f:
							int num2;
							if (JsJRLMHhOlifEhbTNkmSXHoonYTG.Count >= pzaiqLrJolSdtvaFJdGRRskSbec)
							{
								num = 1143208426;
								num2 = num;
							}
							else
							{
								num = 1143208424;
								num2 = num;
							}
						}
						continue;
						end_IL_001f:
						break;
					}
				}
				JsJRLMHhOlifEhbTNkmSXHoonYTG.Enqueue(message);
			}
		}

		private bool PQSWvFQilTgIeaqvfFMnhhGbNgSO()
		{
			if (ZtgCzKdfGSWUWDTDXtkdTKMjYBN)
			{
				return false;
			}
			if (!XwuqsUGexhhAYMAeLaSYinCpSZhc())
			{
				return false;
			}
			if (PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				return true;
			}
			PkVqugVNIpoYIMpSDcpjdJRrnVs = true;
			return true;
		}

		private bool XwuqsUGexhhAYMAeLaSYinCpSZhc()
		{
			if (ZtgCzKdfGSWUWDTDXtkdTKMjYBN)
			{
				return false;
			}
			if (xgExdbVyAKUPeHviEQuSfAnlZIs == null)
			{
				bool result = default(bool);
				try
				{
					xgExdbVyAKUPeHviEQuSfAnlZIs = ThreadHelper.CreateFixedTimeStep(WBfvgaxdsNQFSvGwNIGecXShaC, iYosAjSwJnvFygvFveTRTutbdyr);
					while (true)
					{
						IL_002c:
						int num = -1185255037;
						while (true)
						{
							switch (num ^ -1185255038)
							{
							case 2:
								break;
							case 1:
								goto IL_004a;
							default:
								xgExdbVyAKUPeHviEQuSfAnlZIs.Start(NSdSEgHftreGfBRvWNZBErWjlCaJ);
								result = true;
								goto end_IL_0031;
							}
							goto IL_002c;
							IL_004a:
							xgExdbVyAKUPeHviEQuSfAnlZIs.ThreadUpdateEvent += NdOsURLOPikvHKCYeQXLzgkLJhk;
							num = -1185255038;
							continue;
							end_IL_0031:
							break;
						}
						break;
					}
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, true);
					while (true)
					{
						IL_0093:
						int num2 = -1185255039;
						while (true)
						{
							switch (num2 ^ -1185255038)
							{
							case 0:
								break;
							default:
								goto end_IL_0098;
							case 3:
								if (xgExdbVyAKUPeHviEQuSfAnlZIs != null)
								{
									xgExdbVyAKUPeHviEQuSfAnlZIs.Stop(NSdSEgHftreGfBRvWNZBErWjlCaJ);
									num2 = -1185255037;
									continue;
								}
								goto case 1;
							case 1:
								ZtgCzKdfGSWUWDTDXtkdTKMjYBN = true;
								result = false;
								num2 = -1185255040;
								continue;
							case 2:
								goto end_IL_0098;
							}
							goto IL_0093;
							continue;
							end_IL_0098:
							break;
						}
						break;
					}
				}
				return result;
			}
			if (!xgExdbVyAKUPeHviEQuSfAnlZIs.isRunning)
			{
				xgExdbVyAKUPeHviEQuSfAnlZIs.Start(NSdSEgHftreGfBRvWNZBErWjlCaJ);
			}
			else
			{
				while (iYosAjSwJnvFygvFveTRTutbdyr > 0)
				{
					xgExdbVyAKUPeHviEQuSfAnlZIs.ResetTimeout();
					int num3 = -1185255037;
					while (true)
					{
						switch (num3 ^ -1185255038)
						{
						case 0:
							num3 = -1185255040;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0126;
						}
						break;
					}
					continue;
					end_IL_0126:
					break;
				}
			}
			return true;
		}

		private void PVjLAqGGTYLOSsfqJWsuJihUUpc()
		{
			lock (JsJRLMHhOlifEhbTNkmSXHoonYTG)
			{
				lock (ghUgzDQSaGJRBfduCReQSOtdsfy)
				{
					MiscTools.Swap(ref JsJRLMHhOlifEhbTNkmSXHoonYTG, ref ghUgzDQSaGJRBfduCReQSOtdsfy);
				}
			}
		}

		private void NdOsURLOPikvHKCYeQXLzgkLJhk()
		{
			PVjLAqGGTYLOSsfqJWsuJihUUpc();
			lock (ghUgzDQSaGJRBfduCReQSOtdsfy)
			{
				while (ghUgzDQSaGJRBfduCReQSOtdsfy.Count > 0)
				{
					try
					{
						pwKyOoZgIablLfHRQNrLyOQhWxQA(ghUgzDQSaGJRBfduCReQSOtdsfy.Dequeue());
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
			if (vsurYtRlepcrpAzAENwjqjJEZPT)
			{
				return;
			}
			while (disposing)
			{
				if (JsJRLMHhOlifEhbTNkmSXHoonYTG != null)
				{
					if (ghUgzDQSaGJRBfduCReQSOtdsfy != null)
					{
						int num = -309377000;
						while (true)
						{
							switch (num ^ -309376998)
							{
							case 0:
								num = -309376997;
								continue;
							case 1:
								break;
							default:
								goto IL_0044;
							}
							break;
						}
						continue;
					}
					lock (JsJRLMHhOlifEhbTNkmSXHoonYTG)
					{
						JsJRLMHhOlifEhbTNkmSXHoonYTG.Clear();
					}
				}
				else if (ghUgzDQSaGJRBfduCReQSOtdsfy != null)
				{
					lock (ghUgzDQSaGJRBfduCReQSOtdsfy)
					{
						ghUgzDQSaGJRBfduCReQSOtdsfy.Clear();
					}
				}
				goto IL_00d0;
				IL_0044:
				lock (JsJRLMHhOlifEhbTNkmSXHoonYTG)
				{
					lock (ghUgzDQSaGJRBfduCReQSOtdsfy)
					{
						JsJRLMHhOlifEhbTNkmSXHoonYTG.Clear();
						ghUgzDQSaGJRBfduCReQSOtdsfy.Clear();
					}
				}
				goto IL_00d0;
				IL_00d0:
				if (xgExdbVyAKUPeHviEQuSfAnlZIs != null)
				{
					xgExdbVyAKUPeHviEQuSfAnlZIs.Dispose();
				}
				break;
			}
			vsurYtRlepcrpAzAENwjqjJEZPT = true;
		}
	}
}
