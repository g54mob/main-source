using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ThreadedMessageQueue<T> : IDisposable
	{
		private readonly int NprYZDKFyaeKdhKhlmVVmxXwKlfA;

		private readonly int uRUVTJOznzjyCGHjOALWLzBtUGPE;

		private readonly int KIhpsEocJmixLgopVeIYlmuYJFyz;

		private readonly bool vdaywPrThyrcIZGHizKEUpVKyhny;

		private ThreadHelper FBhTBCloRTksrXPdIRhzYVUCiBYB;

		private Queue<T> lhMPrjbRCsvDtrYzlGzZqzzDnVYJ;

		private Queue<T> YrPExokdkJbVahAXeYyFxlJEJZjg;

		private bool titAFvTkOTJqbZwzzviokBDGEiIM;

		private bool juAmOHdlEuZcdEbopfsigKMAJgtHb;

		private Action<T> VlLvuHfsEnpJyZozekRKhaVQCQTX;

		private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

		public ThreadedMessageQueue(int P_0, int P_1, int P_2, bool P_3, Action<T> P_4)
		{
			if (P_4 == null)
			{
				throw new ArgumentNullException("messageReceiverDelegate");
			}
			if (P_0 < 0)
			{
				P_0 = 0;
			}
			if (P_1 < 0)
			{
				P_1 = 0;
			}
			if (P_2 < 0)
			{
				P_2 = 0;
			}
			NprYZDKFyaeKdhKhlmVVmxXwKlfA = P_0;
			uRUVTJOznzjyCGHjOALWLzBtUGPE = P_1;
			KIhpsEocJmixLgopVeIYlmuYJFyz = P_2;
			vdaywPrThyrcIZGHizKEUpVKyhny = P_3;
			VlLvuHfsEnpJyZozekRKhaVQCQTX = P_4;
			lhMPrjbRCsvDtrYzlGzZqzzDnVYJ = new Queue<T>(P_0);
			YrPExokdkJbVahAXeYyFxlJEJZjg = new Queue<T>(P_0);
		}

		public void Enqueue(T message)
		{
			if (!zBFbVgFivIFkRriBBSLwgWJemDVY())
			{
				return;
			}
			lock (lhMPrjbRCsvDtrYzlGzZqzzDnVYJ)
			{
				if (NprYZDKFyaeKdhKhlmVVmxXwKlfA > 0)
				{
					while (lhMPrjbRCsvDtrYzlGzZqzzDnVYJ.Count >= NprYZDKFyaeKdhKhlmVVmxXwKlfA)
					{
						lhMPrjbRCsvDtrYzlGzZqzzDnVYJ.Dequeue();
					}
				}
				lhMPrjbRCsvDtrYzlGzZqzzDnVYJ.Enqueue(message);
			}
		}

		private bool zBFbVgFivIFkRriBBSLwgWJemDVY()
		{
			if (titAFvTkOTJqbZwzzviokBDGEiIM)
			{
				return false;
			}
			if (!nlzQIjcaveGwfYRGjIPPWvHGvgmu())
			{
				return false;
			}
			if (juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				return true;
			}
			juAmOHdlEuZcdEbopfsigKMAJgtHb = true;
			return true;
		}

		private bool nlzQIjcaveGwfYRGjIPPWvHGvgmu()
		{
			if (titAFvTkOTJqbZwzzviokBDGEiIM)
			{
				return false;
			}
			if (FBhTBCloRTksrXPdIRhzYVUCiBYB == null)
			{
				try
				{
					FBhTBCloRTksrXPdIRhzYVUCiBYB = ThreadHelper.CreateFixedTimeStep(uRUVTJOznzjyCGHjOALWLzBtUGPE, KIhpsEocJmixLgopVeIYlmuYJFyz);
					FBhTBCloRTksrXPdIRhzYVUCiBYB.ThreadUpdateEvent += tnVCzszeDfIDeEoeMJVWGUzaiznE;
					FBhTBCloRTksrXPdIRhzYVUCiBYB.Start(vdaywPrThyrcIZGHizKEUpVKyhny);
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (FBhTBCloRTksrXPdIRhzYVUCiBYB != null)
					{
						FBhTBCloRTksrXPdIRhzYVUCiBYB.Stop(vdaywPrThyrcIZGHizKEUpVKyhny);
					}
					titAFvTkOTJqbZwzzviokBDGEiIM = true;
					return false;
				}
			}
			if (!FBhTBCloRTksrXPdIRhzYVUCiBYB.isRunning)
			{
				FBhTBCloRTksrXPdIRhzYVUCiBYB.Start(vdaywPrThyrcIZGHizKEUpVKyhny);
			}
			else if (KIhpsEocJmixLgopVeIYlmuYJFyz > 0)
			{
				FBhTBCloRTksrXPdIRhzYVUCiBYB.ResetTimeout();
			}
			return true;
		}

		private void rGuPcNkUTZaSxkfMpdzteygdUIrt()
		{
			lock (lhMPrjbRCsvDtrYzlGzZqzzDnVYJ)
			{
				lock (YrPExokdkJbVahAXeYyFxlJEJZjg)
				{
					MiscTools.Swap(ref lhMPrjbRCsvDtrYzlGzZqzzDnVYJ, ref YrPExokdkJbVahAXeYyFxlJEJZjg);
				}
			}
		}

		private void tnVCzszeDfIDeEoeMJVWGUzaiznE()
		{
			rGuPcNkUTZaSxkfMpdzteygdUIrt();
			lock (YrPExokdkJbVahAXeYyFxlJEJZjg)
			{
				while (YrPExokdkJbVahAXeYyFxlJEJZjg.Count > 0)
				{
					try
					{
						VlLvuHfsEnpJyZozekRKhaVQCQTX(YrPExokdkJbVahAXeYyFxlJEJZjg.Dequeue());
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
			if (JChPmMbeaoLOGQvosPYqDDInSiCs)
			{
				return;
			}
			if (disposing)
			{
				if (lhMPrjbRCsvDtrYzlGzZqzzDnVYJ != null)
				{
					if (YrPExokdkJbVahAXeYyFxlJEJZjg != null)
					{
						lock (lhMPrjbRCsvDtrYzlGzZqzzDnVYJ)
						{
							lock (YrPExokdkJbVahAXeYyFxlJEJZjg)
							{
								lhMPrjbRCsvDtrYzlGzZqzzDnVYJ.Clear();
								YrPExokdkJbVahAXeYyFxlJEJZjg.Clear();
							}
						}
					}
					else
					{
						lock (lhMPrjbRCsvDtrYzlGzZqzzDnVYJ)
						{
							lhMPrjbRCsvDtrYzlGzZqzzDnVYJ.Clear();
						}
					}
				}
				else if (YrPExokdkJbVahAXeYyFxlJEJZjg != null)
				{
					lock (YrPExokdkJbVahAXeYyFxlJEJZjg)
					{
						YrPExokdkJbVahAXeYyFxlJEJZjg.Clear();
					}
				}
				if (FBhTBCloRTksrXPdIRhzYVUCiBYB != null)
				{
					FBhTBCloRTksrXPdIRhzYVUCiBYB.Dispose();
				}
			}
			JChPmMbeaoLOGQvosPYqDDInSiCs = true;
		}
	}
}
