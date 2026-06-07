using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Data.Mapping;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerWithAxes : ControllerWithMap
	{
		private sealed class SdVEcmbPSxGdXckAgPturdlnnmiNc : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int gJloSEGEfjeQmNHbyFRvfsjmFiiib;

			private ControllerPollingInfo UtsgOeNwiddvLTbCLRhaFDRdrVzb;

			private int FUdBKFdaEaOMCVSGsyEMIWFiDiMTA;

			public ControllerWithAxes wOgPnrVmKkYqVRHyxKqKHHHAoBsE;

			private int NqCbkGFflsscxvNwHlNHPRBeBaHHA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return UtsgOeNwiddvLTbCLRhaFDRdrVzb;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return UtsgOeNwiddvLTbCLRhaFDRdrVzb;
				}
			}

			[DebuggerHidden]
			public SdVEcmbPSxGdXckAgPturdlnnmiNc(int P_0)
			{
				gJloSEGEfjeQmNHbyFRvfsjmFiiib = P_0;
				FUdBKFdaEaOMCVSGsyEMIWFiDiMTA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = gJloSEGEfjeQmNHbyFRvfsjmFiiib;
				ControllerWithAxes controllerWithAxes = wOgPnrVmKkYqVRHyxKqKHHHAoBsE;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					gJloSEGEfjeQmNHbyFRvfsjmFiiib = -1;
					goto IL_00a8;
				}
				gJloSEGEfjeQmNHbyFRvfsjmFiiib = -1;
				if (ReInput._id != controllerWithAxes.FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(controllerWithAxes.FtWUXMFFyhqCthzgjKfOhWsryipI);
					return false;
				}
				controllerWithAxes.UpdatePollingFrameTracking();
				controllerWithAxes.GjWOvkQCWQxWQfTeKbkxCqPIOLAj();
				NqCbkGFflsscxvNwHlNHPRBeBaHHA = 0;
				goto IL_00ba;
				IL_00ba:
				if (NqCbkGFflsscxvNwHlNHPRBeBaHHA < controllerWithAxes._axisCount)
				{
					if (controllerWithAxes.IsPolledAxisActive(NqCbkGFflsscxvNwHlNHPRBeBaHHA, out var pole, out var elementIdentifierId))
					{
						UtsgOeNwiddvLTbCLRhaFDRdrVzb = new ControllerPollingInfo(true, -1, controllerWithAxes.id, controllerWithAxes._name, controllerWithAxes._type, ControllerElementType.Axis, NqCbkGFflsscxvNwHlNHPRBeBaHHA, pole, controllerWithAxes.XRregwEugLWeubJCKxSQAwUDapNP.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
						gJloSEGEfjeQmNHbyFRvfsjmFiiib = 1;
						return true;
					}
					goto IL_00a8;
				}
				return false;
				IL_00a8:
				NqCbkGFflsscxvNwHlNHPRBeBaHHA++;
				goto IL_00ba;
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

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				SdVEcmbPSxGdXckAgPturdlnnmiNc sdVEcmbPSxGdXckAgPturdlnnmiNc;
				if (gJloSEGEfjeQmNHbyFRvfsjmFiiib == -2 && FUdBKFdaEaOMCVSGsyEMIWFiDiMTA == Environment.CurrentManagedThreadId)
				{
					gJloSEGEfjeQmNHbyFRvfsjmFiiib = 0;
					sdVEcmbPSxGdXckAgPturdlnnmiNc = this;
				}
				else
				{
					sdVEcmbPSxGdXckAgPturdlnnmiNc = new SdVEcmbPSxGdXckAgPturdlnnmiNc(0);
					sdVEcmbPSxGdXckAgPturdlnnmiNc.wOgPnrVmKkYqVRHyxKqKHHHAoBsE = wOgPnrVmKkYqVRHyxKqKHHHAoBsE;
				}
				return sdVEcmbPSxGdXckAgPturdlnnmiNc;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class MaLXdemlVkVjORicKfbTLhfjIIAC : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int oHDOUCXKMkUefBtfRrhbAjETAetj;

			private ControllerPollingInfo eSAmUdPsqihcWNojxvWCvpvdjakx;

			private int oAioipNBZjHsUyetJboXflNJtLSCA;

			public ControllerWithAxes nzBOIhZlqKegBbMyhYAotedhBBHDA;

			private IEnumerator<ControllerPollingInfo> zfACoPKyyrGqZvlzRQyjMYNAvazM;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return eSAmUdPsqihcWNojxvWCvpvdjakx;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return eSAmUdPsqihcWNojxvWCvpvdjakx;
				}
			}

			[DebuggerHidden]
			public MaLXdemlVkVjORicKfbTLhfjIIAC(int P_0)
			{
				oHDOUCXKMkUefBtfRrhbAjETAetj = P_0;
				oAioipNBZjHsUyetJboXflNJtLSCA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (oHDOUCXKMkUefBtfRrhbAjETAetj)
				{
				case -3:
				case 1:
					try
					{
						break;
					}
					finally
					{
						HPcYuOkibrzvxeeVYhYBSYRvipRL();
					}
				case -4:
				case 2:
					try
					{
						break;
					}
					finally
					{
						taToiJyTHYUmFbhdFSGoVadzfCUG();
					}
				case -2:
				case -1:
				case 0:
					break;
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = oHDOUCXKMkUefBtfRrhbAjETAetj;
					ControllerWithAxes controllerWithAxes = nzBOIhZlqKegBbMyhYAotedhBBHDA;
					switch (num)
					{
					default:
						return false;
					case 0:
						oHDOUCXKMkUefBtfRrhbAjETAetj = -1;
						if (ReInput._id != controllerWithAxes.FtWUXMFFyhqCthzgjKfOhWsryipI)
						{
							ReInput.CheckInitialized(controllerWithAxes.FtWUXMFFyhqCthzgjKfOhWsryipI);
							return false;
						}
						zfACoPKyyrGqZvlzRQyjMYNAvazM = ((Controller)controllerWithAxes).PollForAllElements().GetEnumerator();
						oHDOUCXKMkUefBtfRrhbAjETAetj = -3;
						goto IL_0092;
					case 1:
						oHDOUCXKMkUefBtfRrhbAjETAetj = -3;
						goto IL_0092;
					case 2:
						{
							oHDOUCXKMkUefBtfRrhbAjETAetj = -4;
							break;
						}
						IL_0092:
						if (zfACoPKyyrGqZvlzRQyjMYNAvazM.MoveNext())
						{
							ControllerPollingInfo current = zfACoPKyyrGqZvlzRQyjMYNAvazM.Current;
							eSAmUdPsqihcWNojxvWCvpvdjakx = current;
							oHDOUCXKMkUefBtfRrhbAjETAetj = 1;
							return true;
						}
						HPcYuOkibrzvxeeVYhYBSYRvipRL();
						zfACoPKyyrGqZvlzRQyjMYNAvazM = null;
						zfACoPKyyrGqZvlzRQyjMYNAvazM = controllerWithAxes.PollForAllAxes().GetEnumerator();
						oHDOUCXKMkUefBtfRrhbAjETAetj = -4;
						break;
					}
					if (zfACoPKyyrGqZvlzRQyjMYNAvazM.MoveNext())
					{
						ControllerPollingInfo current2 = zfACoPKyyrGqZvlzRQyjMYNAvazM.Current;
						eSAmUdPsqihcWNojxvWCvpvdjakx = current2;
						oHDOUCXKMkUefBtfRrhbAjETAetj = 2;
						return true;
					}
					taToiJyTHYUmFbhdFSGoVadzfCUG();
					zfACoPKyyrGqZvlzRQyjMYNAvazM = null;
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

			private void HPcYuOkibrzvxeeVYhYBSYRvipRL()
			{
				oHDOUCXKMkUefBtfRrhbAjETAetj = -1;
				if (zfACoPKyyrGqZvlzRQyjMYNAvazM != null)
				{
					zfACoPKyyrGqZvlzRQyjMYNAvazM.Dispose();
				}
			}

			private void taToiJyTHYUmFbhdFSGoVadzfCUG()
			{
				oHDOUCXKMkUefBtfRrhbAjETAetj = -1;
				if (zfACoPKyyrGqZvlzRQyjMYNAvazM != null)
				{
					zfACoPKyyrGqZvlzRQyjMYNAvazM.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				MaLXdemlVkVjORicKfbTLhfjIIAC maLXdemlVkVjORicKfbTLhfjIIAC;
				if (oHDOUCXKMkUefBtfRrhbAjETAetj == -2 && oAioipNBZjHsUyetJboXflNJtLSCA == Environment.CurrentManagedThreadId)
				{
					oHDOUCXKMkUefBtfRrhbAjETAetj = 0;
					maLXdemlVkVjORicKfbTLhfjIIAC = this;
				}
				else
				{
					maLXdemlVkVjORicKfbTLhfjIIAC = new MaLXdemlVkVjORicKfbTLhfjIIAC(0);
					maLXdemlVkVjORicKfbTLhfjIIAC.nzBOIhZlqKegBbMyhYAotedhBBHDA = nzBOIhZlqKegBbMyhYAotedhBBHDA;
				}
				return maLXdemlVkVjORicKfbTLhfjIIAC;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class iKFWkSTSLgiMsqXybEWYyJiNJaT : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int COUFFlBTjGIvMsChSVJJuYipFqQTA;

			private ControllerPollingInfo JpCeVLskeqplmtMfwVxEenNautQA;

			private int taYBHMcTHqIDALhYHcCrHqfBMPuNb;

			public ControllerWithAxes uVRBpbRdmBFaHPYcGbsMGIZxOXQq;

			private IEnumerator<ControllerPollingInfo> cyoXjHHbdAEOtUAgjisvJwnilXcG;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return JpCeVLskeqplmtMfwVxEenNautQA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return JpCeVLskeqplmtMfwVxEenNautQA;
				}
			}

			[DebuggerHidden]
			public iKFWkSTSLgiMsqXybEWYyJiNJaT(int P_0)
			{
				COUFFlBTjGIvMsChSVJJuYipFqQTA = P_0;
				taYBHMcTHqIDALhYHcCrHqfBMPuNb = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				switch (COUFFlBTjGIvMsChSVJJuYipFqQTA)
				{
				case -3:
				case 1:
					try
					{
						break;
					}
					finally
					{
						RBCoEBFhHOfMTRnrdFLGIupWhdjnA();
					}
				case -4:
				case 2:
					try
					{
						break;
					}
					finally
					{
						rDeVfONgjgAzschZIoMCltmypxMTA();
					}
				case -2:
				case -1:
				case 0:
					break;
				}
			}

			private bool MoveNext()
			{
				try
				{
					int cOUFFlBTjGIvMsChSVJJuYipFqQTA = COUFFlBTjGIvMsChSVJJuYipFqQTA;
					ControllerWithAxes controllerWithAxes = uVRBpbRdmBFaHPYcGbsMGIZxOXQq;
					switch (cOUFFlBTjGIvMsChSVJJuYipFqQTA)
					{
					default:
						return false;
					case 0:
						COUFFlBTjGIvMsChSVJJuYipFqQTA = -1;
						if (ReInput._id != controllerWithAxes.FtWUXMFFyhqCthzgjKfOhWsryipI)
						{
							ReInput.CheckInitialized(controllerWithAxes.FtWUXMFFyhqCthzgjKfOhWsryipI);
							return false;
						}
						cyoXjHHbdAEOtUAgjisvJwnilXcG = ((Controller)controllerWithAxes).PollForAllElementsDown().GetEnumerator();
						COUFFlBTjGIvMsChSVJJuYipFqQTA = -3;
						goto IL_0092;
					case 1:
						COUFFlBTjGIvMsChSVJJuYipFqQTA = -3;
						goto IL_0092;
					case 2:
						{
							COUFFlBTjGIvMsChSVJJuYipFqQTA = -4;
							break;
						}
						IL_0092:
						if (cyoXjHHbdAEOtUAgjisvJwnilXcG.MoveNext())
						{
							ControllerPollingInfo current = cyoXjHHbdAEOtUAgjisvJwnilXcG.Current;
							JpCeVLskeqplmtMfwVxEenNautQA = current;
							COUFFlBTjGIvMsChSVJJuYipFqQTA = 1;
							return true;
						}
						RBCoEBFhHOfMTRnrdFLGIupWhdjnA();
						cyoXjHHbdAEOtUAgjisvJwnilXcG = null;
						cyoXjHHbdAEOtUAgjisvJwnilXcG = controllerWithAxes.PollForAllAxes().GetEnumerator();
						COUFFlBTjGIvMsChSVJJuYipFqQTA = -4;
						break;
					}
					if (cyoXjHHbdAEOtUAgjisvJwnilXcG.MoveNext())
					{
						ControllerPollingInfo current2 = cyoXjHHbdAEOtUAgjisvJwnilXcG.Current;
						JpCeVLskeqplmtMfwVxEenNautQA = current2;
						COUFFlBTjGIvMsChSVJJuYipFqQTA = 2;
						return true;
					}
					rDeVfONgjgAzschZIoMCltmypxMTA();
					cyoXjHHbdAEOtUAgjisvJwnilXcG = null;
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

			private void RBCoEBFhHOfMTRnrdFLGIupWhdjnA()
			{
				COUFFlBTjGIvMsChSVJJuYipFqQTA = -1;
				if (cyoXjHHbdAEOtUAgjisvJwnilXcG != null)
				{
					cyoXjHHbdAEOtUAgjisvJwnilXcG.Dispose();
				}
			}

			private void rDeVfONgjgAzschZIoMCltmypxMTA()
			{
				COUFFlBTjGIvMsChSVJJuYipFqQTA = -1;
				if (cyoXjHHbdAEOtUAgjisvJwnilXcG != null)
				{
					cyoXjHHbdAEOtUAgjisvJwnilXcG.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				iKFWkSTSLgiMsqXybEWYyJiNJaT iKFWkSTSLgiMsqXybEWYyJiNJaT2;
				if (COUFFlBTjGIvMsChSVJJuYipFqQTA == -2 && taYBHMcTHqIDALhYHcCrHqfBMPuNb == Environment.CurrentManagedThreadId)
				{
					COUFFlBTjGIvMsChSVJJuYipFqQTA = 0;
					iKFWkSTSLgiMsqXybEWYyJiNJaT2 = this;
				}
				else
				{
					iKFWkSTSLgiMsqXybEWYyJiNJaT2 = new iKFWkSTSLgiMsqXybEWYyJiNJaT(0);
					iKFWkSTSLgiMsqXybEWYyJiNJaT2.uVRBpbRdmBFaHPYcGbsMGIZxOXQq = uVRBpbRdmBFaHPYcGbsMGIZxOXQq;
				}
				return iKFWkSTSLgiMsqXybEWYyJiNJaT2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		protected readonly int _axisCount;

		protected readonly int _axis2DCount;

		protected readonly Axis[] axes;

		protected readonly ReadOnlyCollection<Axis> axes_readOnly;

		protected readonly Axis2D[] axes2D;

		protected readonly ReadOnlyCollection<Axis2D> axes2D_readOnly;

		protected CalibrationMap _calibrationMap;

		private float[] RqxeixCGxEMjhFYeixFgNsFORuNLc;

		private uint OkRpGbruhVPdnYlSCtpvRBMUrKSS = uint.MaxValue;

		private Func<int, int> KdMrBEDpHPXkFeMqqaUviLngrTMc;

		public int axisCount
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return 0;
				}
				return _axisCount;
			}
		}

		public int axis2DCount
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return 0;
				}
				return _axis2DCount;
			}
		}

		public IList<Axis> Axes
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return EmptyObjects<Axis>.EmptyReadOnlyIListT;
				}
				return axes_readOnly;
			}
		}

		public IList<Axis2D> Axes2D
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return EmptyObjects<Axis2D>.EmptyReadOnlyIListT;
				}
				return axes2D_readOnly;
			}
		}

		public CalibrationMap calibrationMap
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return null;
				}
				return _calibrationMap;
			}
		}

		public IList<ControllerElementIdentifier> AxisElementIdentifiers
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return XRregwEugLWeubJCKxSQAwUDapNP.axisElementIdentifiers_readOnly;
			}
		}

		internal ControllerWithAxes(int P_0, InputSource P_1, string P_2, string P_3, string P_4, ControllerType P_5, Guid P_6, int P_7, int P_8, bool[] P_9, HardwareControllerMap_Game P_10, Extension P_11, ControllerDataUpdater P_12)
			: base(P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_8, P_9, P_10, P_11, P_12)
		{
			_axisCount = P_7;
			axes = new Axis[P_7];
			for (int i = 0; i < P_7; i++)
			{
				axes[i] = new Axis(this, P_10.axisElementIdentifierIds[i], "Axis " + i, P_10.hwAxisRanges[i], P_10.hwAxisInfo[i]);
				CVjGIDIJiXhwLsmsFrqeTAHhDbES(axes[i]);
			}
			axes_readOnly = new ReadOnlyCollection<Axis>(axes);
			_calibrationMap = new CalibrationMap(P_10.hwAxisCalibrationData);
			_axis2DCount = P_10.axis2DCount;
			axes2D = new Axis2D[_axis2DCount];
			for (int j = 0; j < _axis2DCount; j++)
			{
				try
				{
					HardwareJoystickMap.CompoundElement axis2DData = P_10.GetAxis2DData(j);
					if (axis2DData == null)
					{
						Logger.LogError("Error creating Axis2D from hardware map! CompoundElement is null!");
						axes2D[j] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + j, null, null, 0, 0, null);
						continue;
					}
					int axisIndex = P_10.GetAxisIndex(axis2DData.componentElementIdentifiers[0]);
					int axisIndex2 = P_10.GetAxisIndex(axis2DData.componentElementIdentifiers[1]);
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
				finally
				{
					jfCHyspoaXTmfkKJWHiciLsUNkMe(axes2D[j]);
				}
			}
			axes2D_readOnly = new ReadOnlyCollection<Axis2D>(axes2D);
			nnWiZSZUzJCNkjsnzBDCVlIWArtg();
			KdMrBEDpHPXkFeMqqaUviLngrTMc = P_10.GetAxisIndex;
		}

		public override Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return null;
			}
			if (XRregwEugLWeubJCKxSQAwUDapNP == null)
			{
				return null;
			}
			Element elementById = base.GetElementById(elementIdentifierId);
			if (elementById != null)
			{
				return elementById;
			}
			int axisIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0)
			{
				return null;
			}
			return axes[axisIndex];
		}

		public int GetAxisIndexById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return -1;
			}
			return XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementIdentifierId);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0f;
			}
			int axisIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].value;
		}

		public float GetAxisPrevById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0f;
			}
			int axisIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valuePrev;
		}

		public float GetAxisRawById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0f;
			}
			int axisIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRaw;
		}

		public float GetAxisRawPrevById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0f;
			}
			int axisIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRawPrev;
		}

		public double GetAxisTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			int axisIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActive;
		}

		public double GetAxisTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			int axisIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactive;
		}

		public double GetAxisLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			int axisIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActive;
		}

		public double GetAxisLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			int axisIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactive;
		}

		public double GetAxisRawTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			int axisIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActiveRaw;
		}

		public double GetAxisRawTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			int axisIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeInactiveRaw;
		}

		public double GetAxisRawLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			int axisIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActiveRaw;
		}

		public double GetAxisRawLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			int axisIndex = XRregwEugLWeubJCKxSQAwUDapNP.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeInactiveRaw;
		}

		public Vector2 GetAxis2D(int index)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public override double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
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
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
			}
			UpdatePollingFrameTracking();
			GjWOvkQCWQxWQfTeKbkxCqPIOLAj();
			for (int i = 0; i < _axisCount; i++)
			{
				if (IsPolledAxisActive(i, out var pole, out var elementIdentifierId))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Axis, i, pole, XRregwEugLWeubJCKxSQAwUDapNP.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
				}
			}
			return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
		}

		[IteratorStateMachine(typeof(MaLXdemlVkVjORicKfbTLhfjIIAC))]
		public override IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return new MaLXdemlVkVjORicKfbTLhfjIIAC(-2)
			{
				nzBOIhZlqKegBbMyhYAotedhBBHDA = this
			};
		}

		[IteratorStateMachine(typeof(iKFWkSTSLgiMsqXybEWYyJiNJaT))]
		public override IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return new iKFWkSTSLgiMsqXybEWYyJiNJaT(-2)
			{
				uVRBpbRdmBFaHPYcGbsMGIZxOXQq = this
			};
		}

		[IteratorStateMachine(typeof(SdVEcmbPSxGdXckAgPturdlnnmiNc))]
		public IEnumerable<ControllerPollingInfo> PollForAllAxes()
		{
			return new SdVEcmbPSxGdXckAgPturdlnnmiNc(-2)
			{
				wOgPnrVmKkYqVRHyxKqKHHHAoBsE = this
			};
		}

		private void GjWOvkQCWQxWQfTeKbkxCqPIOLAj()
		{
			if (RqxeixCGxEMjhFYeixFgNsFORuNLc == null)
			{
				RqxeixCGxEMjhFYeixFgNsFORuNLc = new float[_axisCount];
			}
			if (JAAAseaTSCwNzLFBwjMtADgjEIfgc != OkRpGbruhVPdnYlSCtpvRBMUrKSS)
			{
				OkRpGbruhVPdnYlSCtpvRBMUrKSS = JAAAseaTSCwNzLFBwjMtADgjEIfgc;
				UpdateLoopType currentUpdateLoop = ReInput.currentUpdateLoop;
				for (int i = 0; i < _axisCount; i++)
				{
					RqxeixCGxEMjhFYeixFgNsFORuNLc[i] = axes[i].VOiIvPlSYkhtBtHcBsgbHHVDiiyF(currentUpdateLoop, _calibrationMap.GetAxis(i));
				}
			}
		}

		protected virtual bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (axes[index].ecxPoTuiSHhzEinOJuPZQXPtumTW != null)
			{
				if (axes[index].ecxPoTuiSHhzEinOJuPZQXPtumTW._excludeFromPolling)
				{
					return false;
				}
				if (axes[index].ecxPoTuiSHhzEinOJuPZQXPtumTW._dataFormat == AxisCoordinateMode.Relative)
				{
					return false;
				}
			}
			float value = axes[index].VOiIvPlSYkhtBtHcBsgbHHVDiiyF(ReInput.currentUpdateLoop, _calibrationMap.GetAxis(index)) - RqxeixCGxEMjhFYeixFgNsFORuNLc[index];
			if (MathTools.Abs(value) <= axes[index].StwpIgWxDqfQXZRhKpNYDDFYqJRQ)
			{
				return false;
			}
			pole = ((!(MathTools.Sign(value) >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = XRregwEugLWeubJCKxSQAwUDapNP.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			return true;
		}

		public bool ImportCalibrationMapFromXmlString(string xmlString)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			return calibrationMap.ImportXmlString(xmlString);
		}

		public bool ImportCalibrationMapFromJsonString(string jsonString)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			return calibrationMap.ImportJsonString(jsonString);
		}

		internal virtual void SVeqpnebqgINoIMLuzyySxsVmmWd(UpdateLoopType P_0)
		{
			base.WpPadHsJSmWHmPNyDjEbriEWORwq(P_0);
			bool flag = ReInput.IsInputAllowed(_type);
			bool flag2 = _type == ControllerType.Joystick || _type == ControllerType.Custom;
			bool flag3 = _type == ControllerType.Joystick && ReInput.checkNeverPressed;
			bool flag4 = _type == ControllerType.Joystick && !jaSaHPudVtcyecnoPKkgZIAqgGJr.hasReceivedInput;
			for (int i = 0; i < _axisCount; i++)
			{
				axes[i].kPbLcuwUoNvwvGBjaIkoFKFLQPgXA(P_0);
				if (!flag || flag4 || (flag3 && !jaSaHPudVtcyecnoPKkgZIAqgGJr.axisHasBeenPressedOSXLinux[i]))
				{
					axes[i].valueRaw = _calibrationMap.GetAxis(i).calibratedZero;
					axes[i].NcVotDFoRjhcILgHyezybLBxCgtoA();
					continue;
				}
				axes[i].valueRaw = jaSaHPudVtcyecnoPKkgZIAqgGJr.axisValues[i];
				if (flag2)
				{
					axes[i].MZtEBsDfBgdNwKjXPShCaOiLYNtfA(_calibrationMap.GetAxis(i));
				}
				else
				{
					axes[i].DcZSbafwbVkAyCDKiCeTiIhvqEUj();
				}
			}
			for (int j = 0; j < _axis2DCount; j++)
			{
				axes2D[j].cmHUboBhuFVUuLBwwxJdXXLnrsIx();
			}
			for (int k = 0; k < _axisCount; k++)
			{
				axes[k].cKxkfBKpjqDddPJmSatuPVIjrVeG();
			}
		}

		internal bool aPIflIGGTRTchvDHqKrPQgyOxRkM(ActionElementMap P_0, int P_1, bool P_2, bool P_3, out float P_4)
		{
			P_4 = 0f;
			ControllerElementType elementType = P_0._elementType;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int rLYEVHHFczfqTKqknfIMkkwHoRbL = P_0.rLYEVHHFczfqTKqknfIMkkwHoRbL;
			if (rLYEVHHFczfqTKqknfIMkkwHoRbL < 0 || rLYEVHHFczfqTKqknfIMkkwHoRbL >= _axisCount)
			{
				return false;
			}
			float num = ((!P_3) ? (P_2 ? axes[rLYEVHHFczfqTKqknfIMkkwHoRbL].valueRaw : axes[rLYEVHHFczfqTKqknfIMkkwHoRbL].value) : (P_2 ? axes[rLYEVHHFczfqTKqknfIMkkwHoRbL].valueRawPrev : axes[rLYEVHHFczfqTKqknfIMkkwHoRbL].valuePrev));
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
				bool flag = MathTools.Sign(num) > 0f;
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

		internal virtual void pNNAdEuPzXajVENqthIypQQNhIco(ControllerMap P_0)
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
			base.CFaHiJEFpgwiVcWJwPEuwOjLMzZm(P_0);
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			for (int i = 0; i < axisMaps.Count; i++)
			{
				YTencsjPWuJIOCxnxAitAELcIHlkA(P_0, axisMaps[i]);
			}
			for (int num = axisMaps.Count - 1; num >= 0; num--)
			{
				if (axisMaps[num].elementIndex < 0)
				{
					P_0.DeleteElementMap(axisMaps[num].oFUAyzlkDBdPoonWGgEIgJYWTzJOA);
				}
			}
		}

		internal virtual void VPjeohORsfJatrcvLMcSRofWpVKf(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				base.YTencsjPWuJIOCxnxAitAELcIHlkA(P_0, P_1);
				if (P_1._elementType == ControllerElementType.Axis)
				{
					P_1.PZvEkWRBkXBIEonMjbHYqghRdEUeA(P_0);
				}
			}
		}

		internal void nnWiZSZUzJCNkjsnzBDCVlIWArtg()
		{
			for (int i = 0; i < axisCount; i++)
			{
				switch (axes[i].ecxPoTuiSHhzEinOJuPZQXPtumTW._specialAxisType)
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

		internal virtual void ankcONBsyjJMRKuhOFZSQbGRfwHsA()
		{
			base.oiLcdkgzyxvAnauVHzgHdoryrXqiA();
			for (int i = 0; i < _axisCount; i++)
			{
				if (axes[i] != null)
				{
					axes[i].Reset();
				}
			}
		}

		[DebuggerHidden]
		[CompilerGenerated]
		private IEnumerable<ControllerPollingInfo> WxAMFFyHCHhyGHZPOIfkSHUCNVBVA()
		{
			return base.PollForAllElements();
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> btinmrYxsCATBftIfgGhgdaenqso()
		{
			return base.PollForAllElementsDown();
		}
	}
}
