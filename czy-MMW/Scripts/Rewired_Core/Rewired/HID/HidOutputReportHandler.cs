using System;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HidOutputReportHandler : IDisposable
	{
		[CustomObfuscation(rename = false)]
		public delegate bool WriteReportDelegate(OutputReport report);

		private class XfqjvRcjFGnJdLQbuTdYpLiEGXuxA : IDisposable
		{
			private bool MIIBaTQqVRSJSuoMRjYUWdSvXOuy;

			private OutputReport RJJaIAwdjbYXMXbNTIQjHFPOlQShA;

			private NativeBuffer bPWWdbsyfaIrrcvITJILuvhDHAzB;

			private bool fMSrouczcdxEnyHboiabyDqQckiFA;

			public bool EGAnchvySCtMCTpSnGURZvxLLrEK => MIIBaTQqVRSJSuoMRjYUWdSvXOuy;

			public XfqjvRcjFGnJdLQbuTdYpLiEGXuxA()
			{
				bPWWdbsyfaIrrcvITJILuvhDHAzB = new NativeBuffer(0);
			}

			public void aOqooHglNKbYrxUGKhuKMMMvRlCK(ref OutputReport P_0)
			{
				MIIBaTQqVRSJSuoMRjYUWdSvXOuy = false;
				if (!P_0.IsValid)
				{
					return;
				}
				RJJaIAwdjbYXMXbNTIQjHFPOlQShA = P_0;
				if (bPWWdbsyfaIrrcvITJILuvhDHAzB.Length >= P_0.bufferLength || bPWWdbsyfaIrrcvITJILuvhDHAzB.Resize(P_0.bufferLength, preserveData: false))
				{
					try
					{
						bPWWdbsyfaIrrcvITJILuvhDHAzB.Write(P_0.buffer, P_0.bufferLength, P_0.bufferLength);
					}
					catch
					{
						return;
					}
					RJJaIAwdjbYXMXbNTIQjHFPOlQShA.buffer = bPWWdbsyfaIrrcvITJILuvhDHAzB.Pointer;
					RJJaIAwdjbYXMXbNTIQjHFPOlQShA.bufferLength = bPWWdbsyfaIrrcvITJILuvhDHAzB.Length;
					MIIBaTQqVRSJSuoMRjYUWdSvXOuy = true;
				}
			}

			public OutputReport RmTsyImRxODLswrrrKmhoOBMvXIg()
			{
				if (!MIIBaTQqVRSJSuoMRjYUWdSvXOuy)
				{
					return default(OutputReport);
				}
				MIIBaTQqVRSJSuoMRjYUWdSvXOuy = false;
				return RJJaIAwdjbYXMXbNTIQjHFPOlQShA;
			}

			public OutputReport jQhHEPaJAbTHunKpkHEfWaZdzBRG()
			{
				if (!MIIBaTQqVRSJSuoMRjYUWdSvXOuy)
				{
					return default(OutputReport);
				}
				return RJJaIAwdjbYXMXbNTIQjHFPOlQShA;
			}

			public void qvfAJEjFkKpwArAhlrIPRvwUouVGA()
			{
				RJJaIAwdjbYXMXbNTIQjHFPOlQShA.Clear();
				MIIBaTQqVRSJSuoMRjYUWdSvXOuy = false;
			}

			public void Dispose()
			{
				zPScbGrBIRaZOCGnqKWFhgDBIMFG(true);
				GC.SuppressFinalize(this);
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			protected virtual void fVmKKqzxQzOtwdFZfjGNqvifNosD()
			{
				try
				{
					zPScbGrBIRaZOCGnqKWFhgDBIMFG(false);
				}
				finally
				{
					base.Finalize();
				}
			}

			protected virtual void zPScbGrBIRaZOCGnqKWFhgDBIMFG(bool P_0)
			{
				if (!fMSrouczcdxEnyHboiabyDqQckiFA)
				{
					if (P_0 && bPWWdbsyfaIrrcvITJILuvhDHAzB != null)
					{
						bPWWdbsyfaIrrcvITJILuvhDHAzB.Dispose();
					}
					fMSrouczcdxEnyHboiabyDqQckiFA = true;
				}
			}
		}

		private const bool dsrnsBCeNJwXZniLwQCiZWCmlubT = false;

		private const int RjFaqhUpmEdiSGiezHAJLoFNrBfAb = 100;

		private const int udssGrKTzzbGfKoKQTUPHoaMmDvC = 10000;

		private ThreadHelper kyLYixvgVKTRMjxxjOabhPQqeCiA;

		private XfqjvRcjFGnJdLQbuTdYpLiEGXuxA cQxvVjftirCfVIJfxvLqkOuJtEGC;

		private XfqjvRcjFGnJdLQbuTdYpLiEGXuxA GQEZPCqAaxUhLpJHBgwJDgysbqNP;

		private bool KxIOaAOEIVexflsiJwzkaTawbvqh;

		private bool YWNXkpRuNCYVoXsKbokvCqqyxJh;

		private readonly object zDTKowoHVnEWmwcgHuHlhDyoNQmg;

		private WriteReportDelegate NvrAcGCAVESOPYwAKlPnLeRykAXM;

		private bool BiUHsEuISeUhkkaHavHVXjPcCxXK;

		public HidOutputReportHandler(WriteReportDelegate P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("writeReportDelegate");
			}
			NvrAcGCAVESOPYwAKlPnLeRykAXM = P_0;
			cQxvVjftirCfVIJfxvLqkOuJtEGC = new XfqjvRcjFGnJdLQbuTdYpLiEGXuxA();
			GQEZPCqAaxUhLpJHBgwJDgysbqNP = new XfqjvRcjFGnJdLQbuTdYpLiEGXuxA();
			zDTKowoHVnEWmwcgHuHlhDyoNQmg = new object();
		}

		public void WriteReport(OutputReport report)
		{
			lock (zDTKowoHVnEWmwcgHuHlhDyoNQmg)
			{
				if (BiUHsEuISeUhkkaHavHVXjPcCxXK || !report.IsValid || !atmkyCXXEwOotwlsEtqXINpWbeov())
				{
					return;
				}
				lock (cQxvVjftirCfVIJfxvLqkOuJtEGC)
				{
					cQxvVjftirCfVIJfxvLqkOuJtEGC.aOqooHglNKbYrxUGKhuKMMMvRlCK(ref report);
				}
			}
		}

		public void Clear()
		{
			if (cQxvVjftirCfVIJfxvLqkOuJtEGC != null)
			{
				if (GQEZPCqAaxUhLpJHBgwJDgysbqNP != null)
				{
					lock (cQxvVjftirCfVIJfxvLqkOuJtEGC)
					{
						lock (GQEZPCqAaxUhLpJHBgwJDgysbqNP)
						{
							cQxvVjftirCfVIJfxvLqkOuJtEGC.qvfAJEjFkKpwArAhlrIPRvwUouVGA();
							GQEZPCqAaxUhLpJHBgwJDgysbqNP.qvfAJEjFkKpwArAhlrIPRvwUouVGA();
							return;
						}
					}
				}
				lock (cQxvVjftirCfVIJfxvLqkOuJtEGC)
				{
					cQxvVjftirCfVIJfxvLqkOuJtEGC.qvfAJEjFkKpwArAhlrIPRvwUouVGA();
					return;
				}
			}
			if (GQEZPCqAaxUhLpJHBgwJDgysbqNP != null)
			{
				lock (GQEZPCqAaxUhLpJHBgwJDgysbqNP)
				{
					GQEZPCqAaxUhLpJHBgwJDgysbqNP.qvfAJEjFkKpwArAhlrIPRvwUouVGA();
				}
			}
		}

		private bool atmkyCXXEwOotwlsEtqXINpWbeov()
		{
			if (KxIOaAOEIVexflsiJwzkaTawbvqh)
			{
				return false;
			}
			if (!rlmDJGIGMoqBhRkmfHcgeKVEExaMc())
			{
				return false;
			}
			if (YWNXkpRuNCYVoXsKbokvCqqyxJh)
			{
				return true;
			}
			YWNXkpRuNCYVoXsKbokvCqqyxJh = true;
			return true;
		}

		private bool rlmDJGIGMoqBhRkmfHcgeKVEExaMc()
		{
			if (KxIOaAOEIVexflsiJwzkaTawbvqh)
			{
				return false;
			}
			if (kyLYixvgVKTRMjxxjOabhPQqeCiA == null)
			{
				try
				{
					kyLYixvgVKTRMjxxjOabhPQqeCiA = ThreadHelper.CreateFixedTimeStep(100, 10000);
					kyLYixvgVKTRMjxxjOabhPQqeCiA.ThreadUpdateEvent += DMrfVQnvrjVPrNNosiIfgVegczDk;
					kyLYixvgVKTRMjxxjOabhPQqeCiA.ThreadStartedEvent += lRztOzbvZljbqMXFKZibYNBXFSCh;
					kyLYixvgVKTRMjxxjOabhPQqeCiA.ThreadPreStopEvent += dGxrudlDgbEeXahGjdELpfkUazFX;
					kyLYixvgVKTRMjxxjOabhPQqeCiA.Start(wait: false);
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (kyLYixvgVKTRMjxxjOabhPQqeCiA != null)
					{
						kyLYixvgVKTRMjxxjOabhPQqeCiA.Stop(wait: false);
					}
					KxIOaAOEIVexflsiJwzkaTawbvqh = true;
					return false;
				}
			}
			if (!kyLYixvgVKTRMjxxjOabhPQqeCiA.isRunning)
			{
				kyLYixvgVKTRMjxxjOabhPQqeCiA.Start(wait: false);
			}
			else
			{
				kyLYixvgVKTRMjxxjOabhPQqeCiA.ResetTimeout();
			}
			return true;
		}

		private void RrPJQHYhqTaDNiFxTdtmdfidHtibA()
		{
			lock (cQxvVjftirCfVIJfxvLqkOuJtEGC)
			{
				lock (GQEZPCqAaxUhLpJHBgwJDgysbqNP)
				{
					MiscTools.Swap(ref cQxvVjftirCfVIJfxvLqkOuJtEGC, ref GQEZPCqAaxUhLpJHBgwJDgysbqNP);
				}
			}
		}

		private void lRztOzbvZljbqMXFKZibYNBXFSCh()
		{
		}

		private void dGxrudlDgbEeXahGjdELpfkUazFX()
		{
		}

		private void DMrfVQnvrjVPrNNosiIfgVegczDk()
		{
			RrPJQHYhqTaDNiFxTdtmdfidHtibA();
			lock (GQEZPCqAaxUhLpJHBgwJDgysbqNP)
			{
				if (!GQEZPCqAaxUhLpJHBgwJDgysbqNP.EGAnchvySCtMCTpSnGURZvxLLrEK)
				{
					return;
				}
				try
				{
					NvrAcGCAVESOPYwAKlPnLeRykAXM(GQEZPCqAaxUhLpJHBgwJDgysbqNP.RmTsyImRxODLswrrrKmhoOBMvXIg());
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred while sending HID output report.\nMessage: " + ex.Message, requiredThreadSafety: true);
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~HidOutputReportHandler()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (BiUHsEuISeUhkkaHavHVXjPcCxXK)
			{
				return;
			}
			lock (zDTKowoHVnEWmwcgHuHlhDyoNQmg)
			{
				if (disposing)
				{
					Clear();
					if (kyLYixvgVKTRMjxxjOabhPQqeCiA != null)
					{
						kyLYixvgVKTRMjxxjOabhPQqeCiA.Dispose();
					}
				}
				BiUHsEuISeUhkkaHavHVXjPcCxXK = true;
			}
		}
	}
}
