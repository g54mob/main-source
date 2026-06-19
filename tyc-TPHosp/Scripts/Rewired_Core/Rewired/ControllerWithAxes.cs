using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Data.Mapping;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerWithAxes : ControllerWithMap
	{
		private sealed class iKMTboMDEJjJtAHcDPyvpmypNJcS : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public ControllerWithAxes kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public ControllerPollingInfo kKJECiTVfAJZgnULJRAkLMXLMqj;

			public ControllerPollingInfo wLqqPgYzuQMtzrkIaTsPGGuRAKz;

			public IEnumerator<ControllerPollingInfo> SHtGtYgrEUImnpzFIFydLCmusev;

			public IEnumerator<ControllerPollingInfo> nIMupPmXiMQMVGgKVMsOgMkfgXWC;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				iKMTboMDEJjJtAHcDPyvpmypNJcS iKMTboMDEJjJtAHcDPyvpmypNJcS2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					iKMTboMDEJjJtAHcDPyvpmypNJcS2 = this;
				}
				else
				{
					iKMTboMDEJjJtAHcDPyvpmypNJcS2 = new iKMTboMDEJjJtAHcDPyvpmypNJcS(0);
					iKMTboMDEJjJtAHcDPyvpmypNJcS2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				return iKMTboMDEJjJtAHcDPyvpmypNJcS2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (ReInput._id != kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
						{
							ReInput.CheckInitialized(kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
							break;
						}
						SHtGtYgrEUImnpzFIFydLCmusev = ((Controller)kdBZqupjvsCsVkwJiOeEQzkEDVO).PollForAllElements().GetEnumerator();
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_00a6;
					case 2:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_00a6;
					case 4:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
							goto IL_0107;
						}
						IL_00a6:
						if (SHtGtYgrEUImnpzFIFydLCmusev.MoveNext())
						{
							kKJECiTVfAJZgnULJRAkLMXLMqj = SHtGtYgrEUImnpzFIFydLCmusev.Current;
							ajbaQItphrIyqhowgmMTfPkCBvcN = kKJECiTVfAJZgnULJRAkLMXLMqj;
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
							return true;
						}
						IrxYGAlkSktKdxAsgKtZaHyJYuc();
						nIMupPmXiMQMVGgKVMsOgMkfgXWC = kdBZqupjvsCsVkwJiOeEQzkEDVO.PollForAllAxes().GetEnumerator();
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
						goto IL_0107;
						IL_0107:
						if (nIMupPmXiMQMVGgKVMsOgMkfgXWC.MoveNext())
						{
							wLqqPgYzuQMtzrkIaTsPGGuRAKz = nIMupPmXiMQMVGgKVMsOgMkfgXWC.Current;
							ajbaQItphrIyqhowgmMTfPkCBvcN = wLqqPgYzuQMtzrkIaTsPGGuRAKz;
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 4;
							return true;
						}
						YqXvIDauWxccIABYRYvIjwOtdhO();
						break;
					}
					return false;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
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

			void IDisposable.Dispose()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 1:
				case 2:
					try
					{
					}
					finally
					{
						IrxYGAlkSktKdxAsgKtZaHyJYuc();
					}
					break;
				}
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 3:
				case 4:
					try
					{
						break;
					}
					finally
					{
						YqXvIDauWxccIABYRYvIjwOtdhO();
					}
				}
			}

			[DebuggerHidden]
			public iKMTboMDEJjJtAHcDPyvpmypNJcS(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}

			private void IrxYGAlkSktKdxAsgKtZaHyJYuc()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				if (SHtGtYgrEUImnpzFIFydLCmusev != null)
				{
					SHtGtYgrEUImnpzFIFydLCmusev.Dispose();
				}
			}

			private void YqXvIDauWxccIABYRYvIjwOtdhO()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				if (nIMupPmXiMQMVGgKVMsOgMkfgXWC != null)
				{
					nIMupPmXiMQMVGgKVMsOgMkfgXWC.Dispose();
				}
			}
		}

		private sealed class HFTxFqoAcdJpktdTrBgVbQUlZsrG : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public ControllerWithAxes kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public ControllerPollingInfo UaSaxwfjTBCBpJrFVjvFgpAaQWGA;

			public ControllerPollingInfo bGDTDApETXMWQkQPMZaxWXBzRNF;

			public IEnumerator<ControllerPollingInfo> zMnrnqYXrskeymePEivzekdfzdcG;

			public IEnumerator<ControllerPollingInfo> gkmDRrRgIaJOUjTatrkkGFsnVvl;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				HFTxFqoAcdJpktdTrBgVbQUlZsrG hFTxFqoAcdJpktdTrBgVbQUlZsrG;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					hFTxFqoAcdJpktdTrBgVbQUlZsrG = this;
				}
				else
				{
					hFTxFqoAcdJpktdTrBgVbQUlZsrG = new HFTxFqoAcdJpktdTrBgVbQUlZsrG(0);
					hFTxFqoAcdJpktdTrBgVbQUlZsrG.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				return hFTxFqoAcdJpktdTrBgVbQUlZsrG;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (ReInput._id != kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
						{
							ReInput.CheckInitialized(kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
							break;
						}
						zMnrnqYXrskeymePEivzekdfzdcG = ((Controller)kdBZqupjvsCsVkwJiOeEQzkEDVO).PollForAllElementsDown().GetEnumerator();
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_00a6;
					case 2:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						goto IL_00a6;
					case 4:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
							goto IL_0107;
						}
						IL_00a6:
						if (zMnrnqYXrskeymePEivzekdfzdcG.MoveNext())
						{
							UaSaxwfjTBCBpJrFVjvFgpAaQWGA = zMnrnqYXrskeymePEivzekdfzdcG.Current;
							ajbaQItphrIyqhowgmMTfPkCBvcN = UaSaxwfjTBCBpJrFVjvFgpAaQWGA;
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
							return true;
						}
						nRKcPWCiSBWosPijcObpnzfwqES();
						gkmDRrRgIaJOUjTatrkkGFsnVvl = kdBZqupjvsCsVkwJiOeEQzkEDVO.PollForAllAxes().GetEnumerator();
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
						goto IL_0107;
						IL_0107:
						if (gkmDRrRgIaJOUjTatrkkGFsnVvl.MoveNext())
						{
							bGDTDApETXMWQkQPMZaxWXBzRNF = gkmDRrRgIaJOUjTatrkkGFsnVvl.Current;
							ajbaQItphrIyqhowgmMTfPkCBvcN = bGDTDApETXMWQkQPMZaxWXBzRNF;
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 4;
							return true;
						}
						XGSeoVfTVLCAzgmHyNRzdkHABVsT();
						break;
					}
					return false;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
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

			void IDisposable.Dispose()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 1:
				case 2:
					try
					{
					}
					finally
					{
						nRKcPWCiSBWosPijcObpnzfwqES();
					}
					break;
				}
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 3:
				case 4:
					try
					{
						break;
					}
					finally
					{
						XGSeoVfTVLCAzgmHyNRzdkHABVsT();
					}
				}
			}

			[DebuggerHidden]
			public HFTxFqoAcdJpktdTrBgVbQUlZsrG(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}

			private void nRKcPWCiSBWosPijcObpnzfwqES()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				if (zMnrnqYXrskeymePEivzekdfzdcG != null)
				{
					zMnrnqYXrskeymePEivzekdfzdcG.Dispose();
				}
			}

			private void XGSeoVfTVLCAzgmHyNRzdkHABVsT()
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
				if (gkmDRrRgIaJOUjTatrkkGFsnVvl != null)
				{
					gkmDRrRgIaJOUjTatrkkGFsnVvl.Dispose();
				}
			}
		}

		private sealed class YdhjQkcKRGLuNllDPSkcbAmkCLIs : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public ControllerWithAxes kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int CRgsncgrweLPgpLUiUQCzJolIPh;

			public Pole LpSlKfCreXVALKLBLqYAPOXBXcR;

			public int PYeRLjCXtqqiYCjpjxtGLXggYWv;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				YdhjQkcKRGLuNllDPSkcbAmkCLIs ydhjQkcKRGLuNllDPSkcbAmkCLIs;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					ydhjQkcKRGLuNllDPSkcbAmkCLIs = this;
				}
				else
				{
					ydhjQkcKRGLuNllDPSkcbAmkCLIs = new YdhjQkcKRGLuNllDPSkcbAmkCLIs(0);
					ydhjQkcKRGLuNllDPSkcbAmkCLIs.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				return ydhjQkcKRGLuNllDPSkcbAmkCLIs;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (ReInput._id != kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						break;
					}
					kdBZqupjvsCsVkwJiOeEQzkEDVO.UpdatePollingFrameTracking();
					kdBZqupjvsCsVkwJiOeEQzkEDVO.PdUmIuFjpvgYdFYtXRBcWMqzooX();
					CRgsncgrweLPgpLUiUQCzJolIPh = 0;
					goto IL_0100;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_00f2;
					}
					IL_0100:
					if (CRgsncgrweLPgpLUiUQCzJolIPh >= kdBZqupjvsCsVkwJiOeEQzkEDVO._axisCount)
					{
						break;
					}
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.IsPolledAxisActive(CRgsncgrweLPgpLUiUQCzJolIPh, out LpSlKfCreXVALKLBLqYAPOXBXcR, out PYeRLjCXtqqiYCjpjxtGLXggYWv))
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = new ControllerPollingInfo(success: true, -1, kdBZqupjvsCsVkwJiOeEQzkEDVO.id, kdBZqupjvsCsVkwJiOeEQzkEDVO._name, kdBZqupjvsCsVkwJiOeEQzkEDVO._type, ControllerElementType.Axis, CRgsncgrweLPgpLUiUQCzJolIPh, LpSlKfCreXVALKLBLqYAPOXBXcR, kdBZqupjvsCsVkwJiOeEQzkEDVO.ZBMEOTEbHBcUeYYftsfiohhXNEse.GetElementIdentifierName(PYeRLjCXtqqiYCjpjxtGLXggYWv), PYeRLjCXtqqiYCjpjxtGLXggYWv, KeyCode.None);
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_00f2;
					IL_00f2:
					CRgsncgrweLPgpLUiUQCzJolIPh++;
					goto IL_0100;
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
			public YdhjQkcKRGLuNllDPSkcbAmkCLIs(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		protected readonly int _axisCount;

		protected readonly int _axis2DCount;

		protected readonly Axis[] axes;

		protected readonly ReadOnlyCollection<Axis> axes_readOnly;

		protected readonly Axis2D[] axes2D;

		protected readonly ReadOnlyCollection<Axis2D> axes2D_readOnly;

		protected CalibrationMap _calibrationMap;

		private float[] gKRgaJTPBGzTRoXFNJRzUbwKar;

		private uint HIkLbfmCjdfLqmvrWeeZFEwelpd = uint.MaxValue;

		private Func<int, int> EHjfIXnMykxpPqRUXTndyqPmaOz;

		public int axisCount
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return 0;
				}
				return _axisCount;
			}
		}

		public int axis2DCount
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return 0;
				}
				return _axis2DCount;
			}
		}

		public IList<Axis> Axes
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return EmptyObjects<Axis>.EmptyReadOnlyIListT;
				}
				return axes_readOnly;
			}
		}

		public IList<Axis2D> Axes2D
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return EmptyObjects<Axis2D>.EmptyReadOnlyIListT;
				}
				return axes2D_readOnly;
			}
		}

		public CalibrationMap calibrationMap
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				return _calibrationMap;
			}
		}

		public IList<ControllerElementIdentifier> AxisElementIdentifiers
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return ZBMEOTEbHBcUeYYftsfiohhXNEse.axisElementIdentifiers_readOnly;
			}
		}

		internal ControllerWithAxes(int controllerId, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, ControllerType type, Guid hardwareTypeGuid, int axisCount, int buttonCount, bool[] isButtonPressureSensitive, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, hardwareName, hardwareIdentifier, type, hardwareTypeGuid, buttonCount, isButtonPressureSensitive, hardwareMap, extension, dataUpdater)
		{
			_axisCount = axisCount;
			axes = new Axis[axisCount];
			for (int i = 0; i < axisCount; i++)
			{
				axes[i] = new Axis(this, hardwareMap.axisElementIdentifierIds[i], "Axis " + i, hardwareMap.hwAxisRanges[i], hardwareMap.hwAxisInfo[i]);
				sPDBUryojEPTZhjXiDvYbSylxsi(axes[i]);
			}
			axes_readOnly = new ReadOnlyCollection<Axis>(axes);
			_calibrationMap = new CalibrationMap(hardwareMap.hwAxisCalibrationData);
			_axis2DCount = hardwareMap.axis2DCount;
			axes2D = new Axis2D[_axis2DCount];
			for (int j = 0; j < _axis2DCount; j++)
			{
				try
				{
					HardwareJoystickMap.CompoundElement axis2DData = hardwareMap.GetAxis2DData(j);
					if (axis2DData == null)
					{
						Logger.LogError("Error creating Axis2D from hardware map! CompoundElement is null!");
						axes2D[j] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + j, null, null, 0, 0, null);
						continue;
					}
					int axisIndex = hardwareMap.GetAxisIndex(axis2DData.componentElementIdentifiers[0]);
					int axisIndex2 = hardwareMap.GetAxisIndex(axis2DData.componentElementIdentifiers[1]);
					if (axisIndex < 0 || axisIndex >= _axisCount || axisIndex2 < 0 || axisIndex2 >= _axisCount)
					{
						axes2D[j] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + j, null, null, 0, 0, null);
					}
					else
					{
						axes2D[j] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + j, axes[axisIndex], axes[axisIndex2], axisIndex, axisIndex2, _calibrationMap);
					}
				}
				catch
				{
					Logger.LogError("Error creating Axis2D from hardware map! An exception was thrown.");
					axes2D[j] = new Axis2D(this, -1, "Axis 2D " + j, null, null, 0, 0, null);
				}
			}
			axes2D_readOnly = new ReadOnlyCollection<Axis2D>(axes2D);
			vYWAwBSRrgERTkFycstZgDhvKkg();
			EHjfIXnMykxpPqRUXTndyqPmaOz = hardwareMap.GetAxisIndex;
		}

		public override Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			if (ZBMEOTEbHBcUeYYftsfiohhXNEse == null)
			{
				return null;
			}
			Element elementById = base.GetElementById(elementIdentifierId);
			if (elementById != null)
			{
				return elementById;
			}
			int axisIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0)
			{
				return null;
			}
			return axes[axisIndex];
		}

		public int GetAxisIndexById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return -1;
			}
			return ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementIdentifierId);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].value;
		}

		public float GetAxisPrev(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].valuePrev;
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].valueRaw;
		}

		public float GetAxisRawPrev(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].valueRawPrev;
		}

		public double GetAxisTimeActive(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].timeActive;
		}

		public double GetAxisTimeInactive(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].timeInactive;
		}

		public double GetAxisLastTimeActive(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].lastTimeActive;
		}

		public double GetAxisLastTimeInactive(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].lastTimeInactive;
		}

		public double GetAxisRawTimeActive(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].timeActiveRaw;
		}

		public double GetAxisRawTimeInactive(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].timeInactiveRaw;
		}

		public double GetAxisRawLastTimeActive(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].lastTimeActiveRaw;
		}

		public double GetAxisRawLastTimeInactive(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].lastTimeInactiveRaw;
		}

		public float GetAxisById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			int axisIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].value;
		}

		public float GetAxisPrevById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			int axisIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valuePrev;
		}

		public float GetAxisRawById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			int axisIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRaw;
		}

		public float GetAxisRawPrevById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			int axisIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRawPrev;
		}

		public double GetAxisTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			int axisIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActive;
		}

		public double GetAxisTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			int axisIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactive;
		}

		public double GetAxisLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			int axisIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActive;
		}

		public double GetAxisLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			int axisIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactive;
		}

		public double GetAxisRawTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			int axisIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActiveRaw;
		}

		public double GetAxisRawTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			int axisIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactiveRaw;
		}

		public double GetAxisRawLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			int axisIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActiveRaw;
		}

		public double GetAxisRawLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			int axisIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactiveRaw;
		}

		public Vector2 GetAxis2D(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return Vector2.zero;
			}
			if (index < 0 || index >= _axis2DCount)
			{
				return default(Vector2);
			}
			return axes2D[index].value;
		}

		public Vector2 GetAxis2DPrev(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return Vector2.zero;
			}
			if (index < 0 || index >= _axis2DCount)
			{
				return default(Vector2);
			}
			return axes2D[index].valuePrev;
		}

		public Vector2 GetAxis2DRaw(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return Vector2.zero;
			}
			if (index < 0 || index >= _axis2DCount)
			{
				return default(Vector2);
			}
			return axes2D[index].valueRaw;
		}

		public Vector2 GetAxis2DRawPrev(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return Vector2.zero;
			}
			if (index < 0 || index >= _axis2DCount)
			{
				return default(Vector2);
			}
			return axes2D[index].valueRawPrev;
		}

		public override double GetLastTimeActive()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public override double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return MathTools.Max(base.GetLastTimeActive(useRawValues), GetLastTimeAnyAxisActive(useRawValues));
		}

		public override double GetLastTimeAnyElementChanged()
		{
			return GetLastTimeAnyElementChanged(useRawValues: false);
		}

		public override double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return MathTools.Max(base.GetLastTimeAnyElementChanged(useRawValues), GetLastTimeAnyAxisChanged(useRawValues));
		}

		public double GetLastTimeAnyAxisActive()
		{
			return GetLastTimeAnyAxisActive(useRawValues: false);
		}

		public double GetLastTimeAnyAxisActive(bool useRawValues)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (axes == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < axes.Length; i++)
			{
				double num2 = (useRawValues ? axes[i].lastTimeActiveRaw : axes[i].lastTimeActive);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		public double GetLastTimeAnyAxisChanged()
		{
			return GetLastTimeAnyAxisChanged(useRawValues: false);
		}

		public double GetLastTimeAnyAxisChanged(bool useRawValues)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (axes == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < axes.Length; i++)
			{
				double num2 = (useRawValues ? axes[i].lastTimeValueChangedRaw : axes[i].lastTimeValueChanged);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		public override ControllerPollingInfo PollForFirstElement()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
			}
			ControllerPollingInfo result = base.PollForFirstElement();
			if (result.success)
			{
				return result;
			}
			return PollForFirstAxis();
		}

		public override ControllerPollingInfo PollForFirstElementDown()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
			}
			ControllerPollingInfo result = base.PollForFirstElementDown();
			if (result.success)
			{
				return result;
			}
			return PollForFirstAxis();
		}

		public ControllerPollingInfo PollForFirstAxis()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
			}
			UpdatePollingFrameTracking();
			PdUmIuFjpvgYdFYtXRBcWMqzooX();
			for (int i = 0; i < _axisCount; i++)
			{
				if (IsPolledAxisActive(i, out var pole, out var elementIdentifierId))
				{
					return new ControllerPollingInfo(success: true, -1, id, _name, _type, ControllerElementType.Axis, i, pole, ZBMEOTEbHBcUeYYftsfiohhXNEse.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
				}
			}
			return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			iKMTboMDEJjJtAHcDPyvpmypNJcS iKMTboMDEJjJtAHcDPyvpmypNJcS2 = new iKMTboMDEJjJtAHcDPyvpmypNJcS(-2);
			iKMTboMDEJjJtAHcDPyvpmypNJcS2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			return iKMTboMDEJjJtAHcDPyvpmypNJcS2;
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			HFTxFqoAcdJpktdTrBgVbQUlZsrG hFTxFqoAcdJpktdTrBgVbQUlZsrG = new HFTxFqoAcdJpktdTrBgVbQUlZsrG(-2);
			hFTxFqoAcdJpktdTrBgVbQUlZsrG.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			return hFTxFqoAcdJpktdTrBgVbQUlZsrG;
		}

		public IEnumerable<ControllerPollingInfo> PollForAllAxes()
		{
			YdhjQkcKRGLuNllDPSkcbAmkCLIs ydhjQkcKRGLuNllDPSkcbAmkCLIs = new YdhjQkcKRGLuNllDPSkcbAmkCLIs(-2);
			ydhjQkcKRGLuNllDPSkcbAmkCLIs.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			return ydhjQkcKRGLuNllDPSkcbAmkCLIs;
		}

		private void PdUmIuFjpvgYdFYtXRBcWMqzooX()
		{
			if (gKRgaJTPBGzTRoXFNJRzUbwKar == null)
			{
				gKRgaJTPBGzTRoXFNJRzUbwKar = new float[_axisCount];
			}
			if (LCEchZHKMBGDvROfPCrYfJUjifo != HIkLbfmCjdfLqmvrWeeZFEwelpd)
			{
				HIkLbfmCjdfLqmvrWeeZFEwelpd = LCEchZHKMBGDvROfPCrYfJUjifo;
				UpdateLoopType currentUpdateLoop = ReInput.currentUpdateLoop;
				for (int i = 0; i < _axisCount; i++)
				{
					gKRgaJTPBGzTRoXFNJRzUbwKar[i] = axes[i].CPMWbfylhDSGhCfNRrDSmWgKhLh(currentUpdateLoop, _calibrationMap.GetAxis(i));
				}
			}
		}

		protected virtual bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (axes[index].tfkhmJMDJkUYFJkJuabHOpbuotU != null)
			{
				if (axes[index].tfkhmJMDJkUYFJkJuabHOpbuotU._excludeFromPolling)
				{
					return false;
				}
				if (axes[index].tfkhmJMDJkUYFJkJuabHOpbuotU._dataFormat == AxisCoordinateMode.Relative)
				{
					return false;
				}
			}
			float num = axes[index].CPMWbfylhDSGhCfNRrDSmWgKhLh(ReInput.currentUpdateLoop, _calibrationMap.GetAxis(index));
			float value = num - gKRgaJTPBGzTRoXFNJRzUbwKar[index];
			if (MathTools.Abs(value) <= axes[index].effectivePollingDeadZone)
			{
				return false;
			}
			pole = ((!(MathTools.Sign(value) >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = ZBMEOTEbHBcUeYYftsfiohhXNEse.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			return true;
		}

		public bool ImportCalibrationMapFromXmlString(string xmlString)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return calibrationMap.ImportXmlString(xmlString);
		}

		public bool ImportCalibrationMapFromJsonString(string jsonString)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return calibrationMap.ImportJsonString(jsonString);
		}

		internal override void qLvftnPJXcUYQsqiHkMAPRekFwO(UpdateLoopType P_0)
		{
			base.qLvftnPJXcUYQsqiHkMAPRekFwO(P_0);
			bool flag = ReInput.IsInputAllowed(_type);
			bool flag2 = _type == ControllerType.Joystick || _type == ControllerType.Custom;
			bool flag3 = _type == ControllerType.Joystick && ReInput.checkNeverPressed;
			bool flag4 = _type == ControllerType.Joystick && !ebxBmtwxyRprAbJBnnRdvbVCKbL.hasReceivedInput;
			for (int i = 0; i < _axisCount; i++)
			{
				axes[i].pGQZJmpiRkCWlzaFUJGfZbpqbMe(P_0);
				if (!flag || flag4 || (flag3 && !ebxBmtwxyRprAbJBnnRdvbVCKbL.axisHasBeenPressedOSXLinux[i]))
				{
					axes[i].valueRaw = _calibrationMap.GetAxis(i).calibratedZero;
					axes[i].bKiWnSvYpRHosHAsrGxZSmPPriW();
					continue;
				}
				axes[i].valueRaw = ebxBmtwxyRprAbJBnnRdvbVCKbL.axisValues[i];
				if (flag2)
				{
					axes[i].SYbNxlddkXMZgPoboCCPZovlGCrc(_calibrationMap.GetAxis(i));
				}
				else
				{
					axes[i].SYbNxlddkXMZgPoboCCPZovlGCrc();
				}
			}
			for (int j = 0; j < _axis2DCount; j++)
			{
				axes2D[j].zAgCsBucdziQVBRjAkuDNPybKpO();
			}
			for (int k = 0; k < _axisCount; k++)
			{
				axes[k].joYkqpNLolDFqeVuoISINtayeWJ();
			}
		}

		internal bool ZvsqMyoYsqIgSAwCsiZaxBMNYOU(ActionElementMap P_0, int P_1, bool P_2, bool P_3, out float P_4)
		{
			P_4 = 0f;
			ControllerElementType elementType = P_0._elementType;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int ofrrxjPHuwNabkrGucUvSPRIAGB = P_0.ofrrxjPHuwNabkrGucUvSPRIAGB;
			if (ofrrxjPHuwNabkrGucUvSPRIAGB < 0 || ofrrxjPHuwNabkrGucUvSPRIAGB >= _axisCount)
			{
				return false;
			}
			float num = ((!P_3) ? (P_2 ? axes[ofrrxjPHuwNabkrGucUvSPRIAGB].valueRaw : axes[ofrrxjPHuwNabkrGucUvSPRIAGB].value) : (P_2 ? axes[ofrrxjPHuwNabkrGucUvSPRIAGB].valueRawPrev : axes[ofrrxjPHuwNabkrGucUvSPRIAGB].valuePrev));
			if (MathTools.Approximately(num, 0f))
			{
				return true;
			}
			switch (elementType)
			{
			case ControllerElementType.Axis:
			{
				if (P_0._axisRange == AxisRange.Full)
				{
					if (P_0._invert)
					{
						num *= -1f;
					}
					break;
				}
				bool flag = ((MathTools.Sign(num) > 0f) ? true : false);
				if (flag && P_0._axisRange == AxisRange.Positive)
				{
					num = ((num >= 0f) ? num : 0f);
					if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
				else if (!flag && P_0._axisRange == AxisRange.Negative)
				{
					num = ((num <= 0f) ? num : 0f);
					if (P_0._axisContribution == Pole.Positive)
					{
						num *= -1f;
					}
				}
				else
				{
					num = 0f;
				}
				break;
			}
			case ControllerElementType.Button:
				if (P_0._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
				break;
			}
			P_4 = num;
			return true;
		}

		internal override void UqhYnihUfIHBqSaeTWbwiJVKQLu(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			if (!(P_0 is ControllerMapWithAxes controllerMapWithAxes))
			{
				Logger.LogWarning("Map type must inherit from ControllerMapWithAxes!");
				return;
			}
			base.UqhYnihUfIHBqSaeTWbwiJVKQLu(P_0);
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			for (int i = 0; i < axisMaps.Count; i++)
			{
				sSQYMATtZixpYjjUsqaWsAupijI(P_0, axisMaps[i]);
			}
			for (int num = axisMaps.Count - 1; num >= 0; num--)
			{
				if (axisMaps[num].elementIndex < 0)
				{
					P_0.DeleteElementMap(axisMaps[num].fOjavGziuUSawAgvwyVARpyRBVx);
				}
			}
		}

		internal override void sSQYMATtZixpYjjUsqaWsAupijI(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				base.sSQYMATtZixpYjjUsqaWsAupijI(P_0, P_1);
				if (P_1._elementType == ControllerElementType.Axis)
				{
					P_1.WydnbjhvuRfUebKtXVYHLAcSJCu(P_0);
				}
			}
		}

		internal void vYWAwBSRrgERTkFycstZgDhvKkg()
		{
			for (int i = 0; i < axisCount; i++)
			{
				switch (axes[i].tfkhmJMDJkUYFJkJuabHOpbuotU._specialAxisType)
				{
				case SpecialAxisType.None:
					_calibrationMap.Axes[i].calibrationMode = AlternateAxisCalibrationType.Default;
					break;
				case SpecialAxisType.Throttle:
					_calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(ReInput.configVars.throttleCalibrationMode);
					break;
				default:
					throw new NotImplementedException();
				}
			}
		}

		internal override void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
		{
			base.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			for (int i = 0; i < _axisCount; i++)
			{
				if (axes[i] != null)
				{
					axes[i].Reset();
				}
			}
		}

		[CompilerGenerated]
		private IEnumerable<ControllerPollingInfo> xlGoCKiAfmQtQdQJfqsFlvuNiO()
		{
			return base.PollForAllElements();
		}

		[CompilerGenerated]
		private IEnumerable<ControllerPollingInfo> ycRTliCKqgARkeGbHIgRDUHDMnMl()
		{
			return base.PollForAllElementsDown();
		}
	}
}
