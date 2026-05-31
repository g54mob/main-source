using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;
using Rewired.Utils.Classes;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public sealed class Player
	{
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerHelper
		{
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class oGxLIbtQJutfkgrQAOyMQWoBTj : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public ConflictCheckingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int sdUcfBHJKZrpwNGKHzcwwlwLVTI;

					public int qsPOrjVoFKLUWZUgvOumbnMylMT;

					public JoystickMap VJzhVlrBOcGBCCFZprAmLnYqptl;

					public JoystickMap QAgyYUmecnNCVLpzuecMsGLCdJP;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public bool uutDYsXUWncZDaAJTeaAWthFzri;

					public bool HmXfeIizRcPIeSaeglGADvomlCL;

					public int HQtLpUmCzxFDuZIHxlHYJDWeFPNh;

					public Joystick bmdRjyvpDAdNWrjVTVZNPdHWOUe;

					public ElementAssignmentConflictInfo HOllefZkDakGCMoEIRjJyKOTxIS;

					public IEnumerator<ElementAssignmentConflictInfo> KhGpffQvSShZLgutkAsXUAXCByy;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						oGxLIbtQJutfkgrQAOyMQWoBTj oGxLIbtQJutfkgrQAOyMQWoBTj2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							oGxLIbtQJutfkgrQAOyMQWoBTj2 = this;
						}
						else
						{
							oGxLIbtQJutfkgrQAOyMQWoBTj2 = new oGxLIbtQJutfkgrQAOyMQWoBTj(0);
							oGxLIbtQJutfkgrQAOyMQWoBTj2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						oGxLIbtQJutfkgrQAOyMQWoBTj2.sdUcfBHJKZrpwNGKHzcwwlwLVTI = qsPOrjVoFKLUWZUgvOumbnMylMT;
						oGxLIbtQJutfkgrQAOyMQWoBTj2.VJzhVlrBOcGBCCFZprAmLnYqptl = QAgyYUmecnNCVLpzuecMsGLCdJP;
						oGxLIbtQJutfkgrQAOyMQWoBTj2.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						oGxLIbtQJutfkgrQAOyMQWoBTj2.uutDYsXUWncZDaAJTeaAWthFzri = HmXfeIizRcPIeSaeglGADvomlCL;
						return oGxLIbtQJutfkgrQAOyMQWoBTj2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (sdUcfBHJKZrpwNGKHzcwwlwLVTI < 0 || VJzhVlrBOcGBCCFZprAmLnYqptl == null)
								{
									break;
								}
								HQtLpUmCzxFDuZIHxlHYJDWeFPNh = 0;
								goto IL_012c;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_010b;
								}
								IL_010b:
								if (KhGpffQvSShZLgutkAsXUAXCByy.MoveNext())
								{
									HOllefZkDakGCMoEIRjJyKOTxIS = KhGpffQvSShZLgutkAsXUAXCByy.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = HOllefZkDakGCMoEIRjJyKOTxIS;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								VsEQLXLZEyDDAXgyUaBojZWaWiTo();
								goto IL_011e;
								IL_011e:
								HQtLpUmCzxFDuZIHxlHYJDWeFPNh++;
								goto IL_012c;
								IL_012c:
								if (HQtLpUmCzxFDuZIHxlHYJDWeFPNh >= GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Count)
								{
									break;
								}
								bmdRjyvpDAdNWrjVTVZNPdHWOUe = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[HQtLpUmCzxFDuZIHxlHYJDWeFPNh].FKtcxmBappHTSHGoccIYREwbpfog;
								if (bmdRjyvpDAdNWrjVTVZNPdHWOUe.id == sdUcfBHJKZrpwNGKHzcwwlwLVTI)
								{
									KhGpffQvSShZLgutkAsXUAXCByy = GxphHAMqMhNBLjnlhXuBQmXaALiE.bliAUPfXkkEIHTXgYKALWgNvOeE(ControllerType.Joystick, sdUcfBHJKZrpwNGKHzcwwlwLVTI, VJzhVlrBOcGBCCFZprAmLnYqptl, IftNYOsoyZKKlecDyJEriHNLMeG, uutDYsXUWncZDaAJTeaAWthFzri, GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[HQtLpUmCzxFDuZIHxlHYJDWeFPNh].VhZfrlASXHRPSRCbfcxNqUcSXtJ).GetEnumerator();
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_010b;
								}
								goto IL_011e;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								VsEQLXLZEyDDAXgyUaBojZWaWiTo();
							}
						}
					}

					[DebuggerHidden]
					public oGxLIbtQJutfkgrQAOyMQWoBTj(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void VsEQLXLZEyDDAXgyUaBojZWaWiTo()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (KhGpffQvSShZLgutkAsXUAXCByy != null)
						{
							KhGpffQvSShZLgutkAsXUAXCByy.Dispose();
						}
					}
				}

				private sealed class ECmWJgrqbFVoufDOwJuKnsNMFDk : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public ConflictCheckingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int sdUcfBHJKZrpwNGKHzcwwlwLVTI;

					public int qsPOrjVoFKLUWZUgvOumbnMylMT;

					public JoystickMap VJzhVlrBOcGBCCFZprAmLnYqptl;

					public JoystickMap QAgyYUmecnNCVLpzuecMsGLCdJP;

					public ActionElementMap JDEKtLtSnUsjrIbhVeZfySvvFnT;

					public ActionElementMap NkBrCorifFgAHeRDTEXXfZaiuzJS;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public bool uutDYsXUWncZDaAJTeaAWthFzri;

					public bool HmXfeIizRcPIeSaeglGADvomlCL;

					public int MnCtmvwLnTifWFWdMfUSRnJWQyDB;

					public Joystick bOGcMMyUFeTPBansyHBwDBFVUiF;

					public ElementAssignmentConflictInfo fzlRZOzxpgbgTtLkEIpfNFgmHAVh;

					public IEnumerator<ElementAssignmentConflictInfo> DJLFbGiaKxpuLLzyGGMfIUUmvjL;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						ECmWJgrqbFVoufDOwJuKnsNMFDk eCmWJgrqbFVoufDOwJuKnsNMFDk;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							eCmWJgrqbFVoufDOwJuKnsNMFDk = this;
						}
						else
						{
							eCmWJgrqbFVoufDOwJuKnsNMFDk = new ECmWJgrqbFVoufDOwJuKnsNMFDk(0);
							eCmWJgrqbFVoufDOwJuKnsNMFDk.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						eCmWJgrqbFVoufDOwJuKnsNMFDk.sdUcfBHJKZrpwNGKHzcwwlwLVTI = qsPOrjVoFKLUWZUgvOumbnMylMT;
						eCmWJgrqbFVoufDOwJuKnsNMFDk.VJzhVlrBOcGBCCFZprAmLnYqptl = QAgyYUmecnNCVLpzuecMsGLCdJP;
						eCmWJgrqbFVoufDOwJuKnsNMFDk.JDEKtLtSnUsjrIbhVeZfySvvFnT = NkBrCorifFgAHeRDTEXXfZaiuzJS;
						eCmWJgrqbFVoufDOwJuKnsNMFDk.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						eCmWJgrqbFVoufDOwJuKnsNMFDk.uutDYsXUWncZDaAJTeaAWthFzri = HmXfeIizRcPIeSaeglGADvomlCL;
						return eCmWJgrqbFVoufDOwJuKnsNMFDk;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (sdUcfBHJKZrpwNGKHzcwwlwLVTI < 0 || JDEKtLtSnUsjrIbhVeZfySvvFnT == null)
								{
									break;
								}
								MnCtmvwLnTifWFWdMfUSRnJWQyDB = 0;
								goto IL_0132;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0111;
								}
								IL_0111:
								if (DJLFbGiaKxpuLLzyGGMfIUUmvjL.MoveNext())
								{
									fzlRZOzxpgbgTtLkEIpfNFgmHAVh = DJLFbGiaKxpuLLzyGGMfIUUmvjL.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = fzlRZOzxpgbgTtLkEIpfNFgmHAVh;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								PTaRwkqOeUGABUqYxAVLLggxoaV();
								goto IL_0124;
								IL_0124:
								MnCtmvwLnTifWFWdMfUSRnJWQyDB++;
								goto IL_0132;
								IL_0132:
								if (MnCtmvwLnTifWFWdMfUSRnJWQyDB >= GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Count)
								{
									break;
								}
								bOGcMMyUFeTPBansyHBwDBFVUiF = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[MnCtmvwLnTifWFWdMfUSRnJWQyDB].FKtcxmBappHTSHGoccIYREwbpfog;
								if (bOGcMMyUFeTPBansyHBwDBFVUiF.id == sdUcfBHJKZrpwNGKHzcwwlwLVTI)
								{
									DJLFbGiaKxpuLLzyGGMfIUUmvjL = GxphHAMqMhNBLjnlhXuBQmXaALiE.bliAUPfXkkEIHTXgYKALWgNvOeE(ControllerType.Joystick, sdUcfBHJKZrpwNGKHzcwwlwLVTI, VJzhVlrBOcGBCCFZprAmLnYqptl, JDEKtLtSnUsjrIbhVeZfySvvFnT, IftNYOsoyZKKlecDyJEriHNLMeG, uutDYsXUWncZDaAJTeaAWthFzri, GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[MnCtmvwLnTifWFWdMfUSRnJWQyDB].VhZfrlASXHRPSRCbfcxNqUcSXtJ).GetEnumerator();
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0111;
								}
								goto IL_0124;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								PTaRwkqOeUGABUqYxAVLLggxoaV();
							}
						}
					}

					[DebuggerHidden]
					public ECmWJgrqbFVoufDOwJuKnsNMFDk(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void PTaRwkqOeUGABUqYxAVLLggxoaV()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (DJLFbGiaKxpuLLzyGGMfIUUmvjL != null)
						{
							DJLFbGiaKxpuLLzyGGMfIUUmvjL.Dispose();
						}
					}
				}

				private sealed class eHSJHlvPfDQrBCCNuSjMHHLBrjH : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public ConflictCheckingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ElementAssignmentConflictCheck CNxRWxtJdpKgAXgEBkMvLnqPffs;

					public ElementAssignmentConflictCheck VliyeXpMEMSvNHleVqLftHsOCYq;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public bool uutDYsXUWncZDaAJTeaAWthFzri;

					public bool HmXfeIizRcPIeSaeglGADvomlCL;

					public int vYKitmLeZUgSZbNdBepgEXXvFclp;

					public Joystick StVOdRbsEAuLIzzgMGmAwwCYonu;

					public ElementAssignmentConflictInfo ZpxBzcHUDySQlCbrJoLsSvdhRusC;

					public IEnumerator<ElementAssignmentConflictInfo> tnQcGBCZYGaKMbdTcQHGCbdjVFCM;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						eHSJHlvPfDQrBCCNuSjMHHLBrjH eHSJHlvPfDQrBCCNuSjMHHLBrjH2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							eHSJHlvPfDQrBCCNuSjMHHLBrjH2 = this;
						}
						else
						{
							eHSJHlvPfDQrBCCNuSjMHHLBrjH2 = new eHSJHlvPfDQrBCCNuSjMHHLBrjH(0);
							eHSJHlvPfDQrBCCNuSjMHHLBrjH2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						eHSJHlvPfDQrBCCNuSjMHHLBrjH2.CNxRWxtJdpKgAXgEBkMvLnqPffs = VliyeXpMEMSvNHleVqLftHsOCYq;
						eHSJHlvPfDQrBCCNuSjMHHLBrjH2.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						eHSJHlvPfDQrBCCNuSjMHHLBrjH2.uutDYsXUWncZDaAJTeaAWthFzri = HmXfeIizRcPIeSaeglGADvomlCL;
						return eHSJHlvPfDQrBCCNuSjMHHLBrjH2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (CNxRWxtJdpKgAXgEBkMvLnqPffs.controllerId < 0 || CNxRWxtJdpKgAXgEBkMvLnqPffs.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									break;
								}
								vYKitmLeZUgSZbNdBepgEXXvFclp = 0;
								goto IL_0135;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0114;
								}
								IL_0114:
								if (tnQcGBCZYGaKMbdTcQHGCbdjVFCM.MoveNext())
								{
									ZpxBzcHUDySQlCbrJoLsSvdhRusC = tnQcGBCZYGaKMbdTcQHGCbdjVFCM.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = ZpxBzcHUDySQlCbrJoLsSvdhRusC;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								dedPcggbtIXsxRUXEtiAxySiCWp();
								goto IL_0127;
								IL_0127:
								vYKitmLeZUgSZbNdBepgEXXvFclp++;
								goto IL_0135;
								IL_0135:
								if (vYKitmLeZUgSZbNdBepgEXXvFclp >= GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Count)
								{
									break;
								}
								StVOdRbsEAuLIzzgMGmAwwCYonu = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[vYKitmLeZUgSZbNdBepgEXXvFclp].FKtcxmBappHTSHGoccIYREwbpfog;
								if (StVOdRbsEAuLIzzgMGmAwwCYonu.id == CNxRWxtJdpKgAXgEBkMvLnqPffs.controllerId)
								{
									tnQcGBCZYGaKMbdTcQHGCbdjVFCM = GxphHAMqMhNBLjnlhXuBQmXaALiE.bliAUPfXkkEIHTXgYKALWgNvOeE(CNxRWxtJdpKgAXgEBkMvLnqPffs, IftNYOsoyZKKlecDyJEriHNLMeG, uutDYsXUWncZDaAJTeaAWthFzri, GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[vYKitmLeZUgSZbNdBepgEXXvFclp].VhZfrlASXHRPSRCbfcxNqUcSXtJ).GetEnumerator();
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0114;
								}
								goto IL_0127;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								dedPcggbtIXsxRUXEtiAxySiCWp();
							}
						}
					}

					[DebuggerHidden]
					public eHSJHlvPfDQrBCCNuSjMHHLBrjH(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void dedPcggbtIXsxRUXEtiAxySiCWp()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (tnQcGBCZYGaKMbdTcQHGCbdjVFCM != null)
						{
							tnQcGBCZYGaKMbdTcQHGCbdjVFCM.Dispose();
						}
					}
				}

				private sealed class PRolEOsepAzDlcjXuDaUAtRYdFXQ : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public ConflictCheckingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int tXqXJTjBxuSTGyameRbOFiBRaTk;

					public int zhMonKvpOLkvrBNtkyLqdqaacQk;

					public CustomControllerMap VxhXRlirnaUoFJNezjXbylAnbCh;

					public CustomControllerMap cZWuOBOpCJthSgelvekCWzFQsfH;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public bool uutDYsXUWncZDaAJTeaAWthFzri;

					public bool HmXfeIizRcPIeSaeglGADvomlCL;

					public int qvPhkhOyOeLFXEqnzwLVQcrwlMq;

					public CustomController JzWmgOBggdeMMYYJvFrgkbaiZLK;

					public ElementAssignmentConflictInfo NCzgILpqEUlIbtYDBrJqHlhMxEm;

					public IEnumerator<ElementAssignmentConflictInfo> VELCAySPqoFPpmgNYzFygFNIydJ;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						PRolEOsepAzDlcjXuDaUAtRYdFXQ pRolEOsepAzDlcjXuDaUAtRYdFXQ;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							pRolEOsepAzDlcjXuDaUAtRYdFXQ = this;
						}
						else
						{
							pRolEOsepAzDlcjXuDaUAtRYdFXQ = new PRolEOsepAzDlcjXuDaUAtRYdFXQ(0);
							pRolEOsepAzDlcjXuDaUAtRYdFXQ.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						pRolEOsepAzDlcjXuDaUAtRYdFXQ.tXqXJTjBxuSTGyameRbOFiBRaTk = zhMonKvpOLkvrBNtkyLqdqaacQk;
						pRolEOsepAzDlcjXuDaUAtRYdFXQ.VxhXRlirnaUoFJNezjXbylAnbCh = cZWuOBOpCJthSgelvekCWzFQsfH;
						pRolEOsepAzDlcjXuDaUAtRYdFXQ.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						pRolEOsepAzDlcjXuDaUAtRYdFXQ.uutDYsXUWncZDaAJTeaAWthFzri = HmXfeIizRcPIeSaeglGADvomlCL;
						return pRolEOsepAzDlcjXuDaUAtRYdFXQ;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (tXqXJTjBxuSTGyameRbOFiBRaTk < 0 || VxhXRlirnaUoFJNezjXbylAnbCh == null)
								{
									break;
								}
								qvPhkhOyOeLFXEqnzwLVQcrwlMq = 0;
								goto IL_012d;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_010c;
								}
								IL_010c:
								if (VELCAySPqoFPpmgNYzFygFNIydJ.MoveNext())
								{
									NCzgILpqEUlIbtYDBrJqHlhMxEm = VELCAySPqoFPpmgNYzFygFNIydJ.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = NCzgILpqEUlIbtYDBrJqHlhMxEm;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								ltGbcKDAFnsctwxMecbRieBdxOyo();
								goto IL_011f;
								IL_011f:
								qvPhkhOyOeLFXEqnzwLVQcrwlMq++;
								goto IL_012d;
								IL_012d:
								if (qvPhkhOyOeLFXEqnzwLVQcrwlMq >= GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Count)
								{
									break;
								}
								JzWmgOBggdeMMYYJvFrgkbaiZLK = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[qvPhkhOyOeLFXEqnzwLVQcrwlMq].FKtcxmBappHTSHGoccIYREwbpfog;
								if (JzWmgOBggdeMMYYJvFrgkbaiZLK.id == tXqXJTjBxuSTGyameRbOFiBRaTk)
								{
									VELCAySPqoFPpmgNYzFygFNIydJ = GxphHAMqMhNBLjnlhXuBQmXaALiE.bliAUPfXkkEIHTXgYKALWgNvOeE(ControllerType.Custom, tXqXJTjBxuSTGyameRbOFiBRaTk, VxhXRlirnaUoFJNezjXbylAnbCh, IftNYOsoyZKKlecDyJEriHNLMeG, uutDYsXUWncZDaAJTeaAWthFzri, GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[qvPhkhOyOeLFXEqnzwLVQcrwlMq].VhZfrlASXHRPSRCbfcxNqUcSXtJ).GetEnumerator();
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_010c;
								}
								goto IL_011f;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								ltGbcKDAFnsctwxMecbRieBdxOyo();
							}
						}
					}

					[DebuggerHidden]
					public PRolEOsepAzDlcjXuDaUAtRYdFXQ(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void ltGbcKDAFnsctwxMecbRieBdxOyo()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (VELCAySPqoFPpmgNYzFygFNIydJ != null)
						{
							VELCAySPqoFPpmgNYzFygFNIydJ.Dispose();
						}
					}
				}

				private sealed class hTEEKJpYLHsBxpaDUZRWBrUnrqj : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public ConflictCheckingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int tXqXJTjBxuSTGyameRbOFiBRaTk;

					public int zhMonKvpOLkvrBNtkyLqdqaacQk;

					public CustomControllerMap VxhXRlirnaUoFJNezjXbylAnbCh;

					public CustomControllerMap cZWuOBOpCJthSgelvekCWzFQsfH;

					public ActionElementMap JDEKtLtSnUsjrIbhVeZfySvvFnT;

					public ActionElementMap NkBrCorifFgAHeRDTEXXfZaiuzJS;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public bool uutDYsXUWncZDaAJTeaAWthFzri;

					public bool HmXfeIizRcPIeSaeglGADvomlCL;

					public int rJfbtuNrCwGjTJKMiLVknteTjQUj;

					public CustomController reBoqdftXkdJDGAcViEbKajetjE;

					public ElementAssignmentConflictInfo HFEURlXIcphapipGTkjHBQWxOfS;

					public IEnumerator<ElementAssignmentConflictInfo> JypIOfkXhUwodtiYCoavnswppOM;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						hTEEKJpYLHsBxpaDUZRWBrUnrqj hTEEKJpYLHsBxpaDUZRWBrUnrqj2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							hTEEKJpYLHsBxpaDUZRWBrUnrqj2 = this;
						}
						else
						{
							hTEEKJpYLHsBxpaDUZRWBrUnrqj2 = new hTEEKJpYLHsBxpaDUZRWBrUnrqj(0);
							hTEEKJpYLHsBxpaDUZRWBrUnrqj2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						hTEEKJpYLHsBxpaDUZRWBrUnrqj2.tXqXJTjBxuSTGyameRbOFiBRaTk = zhMonKvpOLkvrBNtkyLqdqaacQk;
						hTEEKJpYLHsBxpaDUZRWBrUnrqj2.VxhXRlirnaUoFJNezjXbylAnbCh = cZWuOBOpCJthSgelvekCWzFQsfH;
						hTEEKJpYLHsBxpaDUZRWBrUnrqj2.JDEKtLtSnUsjrIbhVeZfySvvFnT = NkBrCorifFgAHeRDTEXXfZaiuzJS;
						hTEEKJpYLHsBxpaDUZRWBrUnrqj2.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						hTEEKJpYLHsBxpaDUZRWBrUnrqj2.uutDYsXUWncZDaAJTeaAWthFzri = HmXfeIizRcPIeSaeglGADvomlCL;
						return hTEEKJpYLHsBxpaDUZRWBrUnrqj2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (tXqXJTjBxuSTGyameRbOFiBRaTk < 0 || JDEKtLtSnUsjrIbhVeZfySvvFnT == null)
								{
									break;
								}
								rJfbtuNrCwGjTJKMiLVknteTjQUj = 0;
								goto IL_0133;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0112;
								}
								IL_0112:
								if (JypIOfkXhUwodtiYCoavnswppOM.MoveNext())
								{
									HFEURlXIcphapipGTkjHBQWxOfS = JypIOfkXhUwodtiYCoavnswppOM.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = HFEURlXIcphapipGTkjHBQWxOfS;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								qcAMYQqklxQpKiLbzRqVBVXYOtG();
								goto IL_0125;
								IL_0125:
								rJfbtuNrCwGjTJKMiLVknteTjQUj++;
								goto IL_0133;
								IL_0133:
								if (rJfbtuNrCwGjTJKMiLVknteTjQUj >= GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Count)
								{
									break;
								}
								reBoqdftXkdJDGAcViEbKajetjE = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[rJfbtuNrCwGjTJKMiLVknteTjQUj].FKtcxmBappHTSHGoccIYREwbpfog;
								if (reBoqdftXkdJDGAcViEbKajetjE.id == tXqXJTjBxuSTGyameRbOFiBRaTk)
								{
									JypIOfkXhUwodtiYCoavnswppOM = GxphHAMqMhNBLjnlhXuBQmXaALiE.bliAUPfXkkEIHTXgYKALWgNvOeE(ControllerType.Custom, tXqXJTjBxuSTGyameRbOFiBRaTk, VxhXRlirnaUoFJNezjXbylAnbCh, JDEKtLtSnUsjrIbhVeZfySvvFnT, IftNYOsoyZKKlecDyJEriHNLMeG, uutDYsXUWncZDaAJTeaAWthFzri, GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[rJfbtuNrCwGjTJKMiLVknteTjQUj].VhZfrlASXHRPSRCbfcxNqUcSXtJ).GetEnumerator();
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0112;
								}
								goto IL_0125;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								qcAMYQqklxQpKiLbzRqVBVXYOtG();
							}
						}
					}

					[DebuggerHidden]
					public hTEEKJpYLHsBxpaDUZRWBrUnrqj(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void qcAMYQqklxQpKiLbzRqVBVXYOtG()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (JypIOfkXhUwodtiYCoavnswppOM != null)
						{
							JypIOfkXhUwodtiYCoavnswppOM.Dispose();
						}
					}
				}

				private sealed class EHnLIndlFvThgKwcFVfxIUTgtqV : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public ConflictCheckingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ElementAssignmentConflictCheck CNxRWxtJdpKgAXgEBkMvLnqPffs;

					public ElementAssignmentConflictCheck VliyeXpMEMSvNHleVqLftHsOCYq;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public bool uutDYsXUWncZDaAJTeaAWthFzri;

					public bool HmXfeIizRcPIeSaeglGADvomlCL;

					public int aGowoHHpVMHCvwnknzQnHEoKLKP;

					public CustomController pfKbtLjQVMPoPCPihAuFzsTPPJfq;

					public ElementAssignmentConflictInfo jZRTbjgDTAmnmUAwvjEeaOtlzDV;

					public IEnumerator<ElementAssignmentConflictInfo> AihbkpihjLhuuTsztIvrPJxeaP;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						EHnLIndlFvThgKwcFVfxIUTgtqV eHnLIndlFvThgKwcFVfxIUTgtqV;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							eHnLIndlFvThgKwcFVfxIUTgtqV = this;
						}
						else
						{
							eHnLIndlFvThgKwcFVfxIUTgtqV = new EHnLIndlFvThgKwcFVfxIUTgtqV(0);
							eHnLIndlFvThgKwcFVfxIUTgtqV.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						eHnLIndlFvThgKwcFVfxIUTgtqV.CNxRWxtJdpKgAXgEBkMvLnqPffs = VliyeXpMEMSvNHleVqLftHsOCYq;
						eHnLIndlFvThgKwcFVfxIUTgtqV.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						eHnLIndlFvThgKwcFVfxIUTgtqV.uutDYsXUWncZDaAJTeaAWthFzri = HmXfeIizRcPIeSaeglGADvomlCL;
						return eHnLIndlFvThgKwcFVfxIUTgtqV;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (CNxRWxtJdpKgAXgEBkMvLnqPffs.controllerId < 0 || CNxRWxtJdpKgAXgEBkMvLnqPffs.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									break;
								}
								aGowoHHpVMHCvwnknzQnHEoKLKP = 0;
								goto IL_0135;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0114;
								}
								IL_0114:
								if (AihbkpihjLhuuTsztIvrPJxeaP.MoveNext())
								{
									jZRTbjgDTAmnmUAwvjEeaOtlzDV = AihbkpihjLhuuTsztIvrPJxeaP.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = jZRTbjgDTAmnmUAwvjEeaOtlzDV;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								iISzTWwkAiExeppdAooPpULfdKA();
								goto IL_0127;
								IL_0127:
								aGowoHHpVMHCvwnknzQnHEoKLKP++;
								goto IL_0135;
								IL_0135:
								if (aGowoHHpVMHCvwnknzQnHEoKLKP >= GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Count)
								{
									break;
								}
								pfKbtLjQVMPoPCPihAuFzsTPPJfq = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[aGowoHHpVMHCvwnknzQnHEoKLKP].FKtcxmBappHTSHGoccIYREwbpfog;
								if (pfKbtLjQVMPoPCPihAuFzsTPPJfq.id == CNxRWxtJdpKgAXgEBkMvLnqPffs.controllerId)
								{
									AihbkpihjLhuuTsztIvrPJxeaP = GxphHAMqMhNBLjnlhXuBQmXaALiE.bliAUPfXkkEIHTXgYKALWgNvOeE(CNxRWxtJdpKgAXgEBkMvLnqPffs, IftNYOsoyZKKlecDyJEriHNLMeG, uutDYsXUWncZDaAJTeaAWthFzri, GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[aGowoHHpVMHCvwnknzQnHEoKLKP].VhZfrlASXHRPSRCbfcxNqUcSXtJ).GetEnumerator();
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0114;
								}
								goto IL_0127;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								iISzTWwkAiExeppdAooPpULfdKA();
							}
						}
					}

					[DebuggerHidden]
					public EHnLIndlFvThgKwcFVfxIUTgtqV(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void iISzTWwkAiExeppdAooPpULfdKA()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (AihbkpihjLhuuTsztIvrPJxeaP != null)
						{
							AihbkpihjLhuuTsztIvrPJxeaP.Dispose();
						}
					}
				}

				private sealed class xNztvvvWLQMHcmbVsSdoMlaDbXjd<T> : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo> where T : ControllerMap
				{
					private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public ConflictCheckingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ControllerType qJuMVwaZQbscppRQUiOFNfhpiVN;

					public ControllerType tzNVSSJYEEurgoRRcPJzhibzRlw;

					public int nteuTcuuyNPUTsVraRspZcsOdtt;

					public int sNTdfjDyfxaSaQmJvfYryRePNuP;

					public T SAeBxWsQfFFAIAKeeJctixiCVXWf;

					public T LTcBMeSMNRjbHilwVWWHCEqhiOba;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public bool uutDYsXUWncZDaAJTeaAWthFzri;

					public bool HmXfeIizRcPIeSaeglGADvomlCL;

					public global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> msXOjBMcKQOlcnrFEgjiaModemAg;

					public global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> zrOvHCuPwAazxpKpxrevmrIsALV;

					public InputMapCategory YmndODufnNTyXBGoHnNqXHuIDqd;

					public int qivNFKribHAXWfxZBlPvvklveel;

					public ControllerMap AdHOShWuDZZCDreymZHMKRpIprx;

					public ElementAssignmentConflictInfo JaSXblParsmQyPTYdigKSVQbaDv;

					public ElementAssignmentConflictInfo pFbduLeDEhmOTlBJjmOxYwGTpRhv;

					public IEnumerator<ElementAssignmentConflictInfo> EgkwNcFzAjvoFJSOfbbgCWBJMlQ;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						xNztvvvWLQMHcmbVsSdoMlaDbXjd<T> xNztvvvWLQMHcmbVsSdoMlaDbXjd2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							xNztvvvWLQMHcmbVsSdoMlaDbXjd2 = this;
						}
						else
						{
							xNztvvvWLQMHcmbVsSdoMlaDbXjd2 = new xNztvvvWLQMHcmbVsSdoMlaDbXjd<T>(0);
							xNztvvvWLQMHcmbVsSdoMlaDbXjd2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						xNztvvvWLQMHcmbVsSdoMlaDbXjd2.qJuMVwaZQbscppRQUiOFNfhpiVN = tzNVSSJYEEurgoRRcPJzhibzRlw;
						xNztvvvWLQMHcmbVsSdoMlaDbXjd2.nteuTcuuyNPUTsVraRspZcsOdtt = sNTdfjDyfxaSaQmJvfYryRePNuP;
						xNztvvvWLQMHcmbVsSdoMlaDbXjd2.SAeBxWsQfFFAIAKeeJctixiCVXWf = LTcBMeSMNRjbHilwVWWHCEqhiOba;
						xNztvvvWLQMHcmbVsSdoMlaDbXjd2.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						xNztvvvWLQMHcmbVsSdoMlaDbXjd2.uutDYsXUWncZDaAJTeaAWthFzri = HmXfeIizRcPIeSaeglGADvomlCL;
						xNztvvvWLQMHcmbVsSdoMlaDbXjd2.msXOjBMcKQOlcnrFEgjiaModemAg = zrOvHCuPwAazxpKpxrevmrIsALV;
						return xNztvvvWLQMHcmbVsSdoMlaDbXjd2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (msXOjBMcKQOlcnrFEgjiaModemAg == null || SAeBxWsQfFFAIAKeeJctixiCVXWf == null)
								{
									break;
								}
								YmndODufnNTyXBGoHnNqXHuIDqd = ReInput.mapping.GetMapCategory(SAeBxWsQfFFAIAKeeJctixiCVXWf.categoryId);
								if (YmndODufnNTyXBGoHnNqXHuIDqd == null)
								{
									break;
								}
								qivNFKribHAXWfxZBlPvvklveel = 0;
								goto IL_01a9;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0185;
								}
								IL_01a9:
								if (qivNFKribHAXWfxZBlPvvklveel >= msXOjBMcKQOlcnrFEgjiaModemAg.Count)
								{
									break;
								}
								AdHOShWuDZZCDreymZHMKRpIprx = msXOjBMcKQOlcnrFEgjiaModemAg[qivNFKribHAXWfxZBlPvvklveel];
								if ((!IftNYOsoyZKKlecDyJEriHNLMeG || AdHOShWuDZZCDreymZHMKRpIprx.enabled) && (uutDYsXUWncZDaAJTeaAWthFzri || !GxphHAMqMhNBLjnlhXuBQmXaALiE.iPjDxoaipsmAFaublSaQReZEvXT(YmndODufnNTyXBGoHnNqXHuIDqd, AdHOShWuDZZCDreymZHMKRpIprx)))
								{
									EgkwNcFzAjvoFJSOfbbgCWBJMlQ = AdHOShWuDZZCDreymZHMKRpIprx.ElementAssignmentConflicts(SAeBxWsQfFFAIAKeeJctixiCVXWf, IftNYOsoyZKKlecDyJEriHNLMeG).GetEnumerator();
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0185;
								}
								goto IL_019b;
								IL_019b:
								qivNFKribHAXWfxZBlPvvklveel++;
								goto IL_01a9;
								IL_0185:
								if (EgkwNcFzAjvoFJSOfbbgCWBJMlQ.MoveNext())
								{
									JaSXblParsmQyPTYdigKSVQbaDv = EgkwNcFzAjvoFJSOfbbgCWBJMlQ.Current;
									ref ElementAssignmentConflictInfo reference = ref pFbduLeDEhmOTlBJjmOxYwGTpRhv;
									reference = new ElementAssignmentConflictInfo(JaSXblParsmQyPTYdigKSVQbaDv);
									pFbduLeDEhmOTlBJjmOxYwGTpRhv.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									pFbduLeDEhmOTlBJjmOxYwGTpRhv.controllerType = qJuMVwaZQbscppRQUiOFNfhpiVN;
									pFbduLeDEhmOTlBJjmOxYwGTpRhv.controllerId = nteuTcuuyNPUTsVraRspZcsOdtt;
									WCNlIsEdYuVTqbNYvICUPcTebLU = pFbduLeDEhmOTlBJjmOxYwGTpRhv;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								DcYeQiPzDvjJYVowcUTczaqmHGq();
								goto IL_019b;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								DcYeQiPzDvjJYVowcUTczaqmHGq();
							}
						}
					}

					[DebuggerHidden]
					public xNztvvvWLQMHcmbVsSdoMlaDbXjd(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void DcYeQiPzDvjJYVowcUTczaqmHGq()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (EgkwNcFzAjvoFJSOfbbgCWBJMlQ != null)
						{
							EgkwNcFzAjvoFJSOfbbgCWBJMlQ.Dispose();
						}
					}
				}

				private sealed class NctdunImAnxkxTYEtMgzqZAPEGf<T> : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo> where T : ControllerMap
				{
					private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public ConflictCheckingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ControllerType qJuMVwaZQbscppRQUiOFNfhpiVN;

					public ControllerType tzNVSSJYEEurgoRRcPJzhibzRlw;

					public int nteuTcuuyNPUTsVraRspZcsOdtt;

					public int sNTdfjDyfxaSaQmJvfYryRePNuP;

					public T SAeBxWsQfFFAIAKeeJctixiCVXWf;

					public T LTcBMeSMNRjbHilwVWWHCEqhiOba;

					public ActionElementMap BNpOSJRceZAgEirMYviolwgJoKV;

					public ActionElementMap tRBqmsewkInWhxWpvmsWzSxgrCd;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public bool uutDYsXUWncZDaAJTeaAWthFzri;

					public bool HmXfeIizRcPIeSaeglGADvomlCL;

					public global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> msXOjBMcKQOlcnrFEgjiaModemAg;

					public global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> zrOvHCuPwAazxpKpxrevmrIsALV;

					public InputMapCategory ISqdhDPqQEANztiginUyPvwvQrU;

					public int lEiblanjrAejVNwVMSVBYsigbDpb;

					public ControllerMap jNlCyCSxHJKpJHpSobqaHhVnQFs;

					public ElementAssignmentConflictInfo IdJadXiuNmMAImTKuuTqiapowfw;

					public ElementAssignmentConflictInfo GtDjaJXbLCymPrpRbFuiEgcbKqo;

					public IEnumerator<ElementAssignmentConflictInfo> iQMbcEaVSprJgFXsUoAkWmhNTkA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						NctdunImAnxkxTYEtMgzqZAPEGf<T> nctdunImAnxkxTYEtMgzqZAPEGf;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							nctdunImAnxkxTYEtMgzqZAPEGf = this;
						}
						else
						{
							nctdunImAnxkxTYEtMgzqZAPEGf = new NctdunImAnxkxTYEtMgzqZAPEGf<T>(0);
							nctdunImAnxkxTYEtMgzqZAPEGf.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						nctdunImAnxkxTYEtMgzqZAPEGf.qJuMVwaZQbscppRQUiOFNfhpiVN = tzNVSSJYEEurgoRRcPJzhibzRlw;
						nctdunImAnxkxTYEtMgzqZAPEGf.nteuTcuuyNPUTsVraRspZcsOdtt = sNTdfjDyfxaSaQmJvfYryRePNuP;
						nctdunImAnxkxTYEtMgzqZAPEGf.SAeBxWsQfFFAIAKeeJctixiCVXWf = LTcBMeSMNRjbHilwVWWHCEqhiOba;
						nctdunImAnxkxTYEtMgzqZAPEGf.BNpOSJRceZAgEirMYviolwgJoKV = tRBqmsewkInWhxWpvmsWzSxgrCd;
						nctdunImAnxkxTYEtMgzqZAPEGf.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						nctdunImAnxkxTYEtMgzqZAPEGf.uutDYsXUWncZDaAJTeaAWthFzri = HmXfeIizRcPIeSaeglGADvomlCL;
						nctdunImAnxkxTYEtMgzqZAPEGf.msXOjBMcKQOlcnrFEgjiaModemAg = zrOvHCuPwAazxpKpxrevmrIsALV;
						return nctdunImAnxkxTYEtMgzqZAPEGf;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (msXOjBMcKQOlcnrFEgjiaModemAg == null || BNpOSJRceZAgEirMYviolwgJoKV == null)
								{
									break;
								}
								ISqdhDPqQEANztiginUyPvwvQrU = ((SAeBxWsQfFFAIAKeeJctixiCVXWf != null) ? ReInput.mapping.GetMapCategory(SAeBxWsQfFFAIAKeeJctixiCVXWf.categoryId) : null);
								lEiblanjrAejVNwVMSVBYsigbDpb = 0;
								goto IL_01a4;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0180;
								}
								IL_0180:
								if (iQMbcEaVSprJgFXsUoAkWmhNTkA.MoveNext())
								{
									IdJadXiuNmMAImTKuuTqiapowfw = iQMbcEaVSprJgFXsUoAkWmhNTkA.Current;
									ref ElementAssignmentConflictInfo gtDjaJXbLCymPrpRbFuiEgcbKqo = ref GtDjaJXbLCymPrpRbFuiEgcbKqo;
									gtDjaJXbLCymPrpRbFuiEgcbKqo = new ElementAssignmentConflictInfo(IdJadXiuNmMAImTKuuTqiapowfw);
									GtDjaJXbLCymPrpRbFuiEgcbKqo.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									GtDjaJXbLCymPrpRbFuiEgcbKqo.controllerType = qJuMVwaZQbscppRQUiOFNfhpiVN;
									GtDjaJXbLCymPrpRbFuiEgcbKqo.controllerId = nteuTcuuyNPUTsVraRspZcsOdtt;
									WCNlIsEdYuVTqbNYvICUPcTebLU = GtDjaJXbLCymPrpRbFuiEgcbKqo;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								pGzAWegZSNwQoMqtkGhpKBeUpiW();
								goto IL_0196;
								IL_01a4:
								if (lEiblanjrAejVNwVMSVBYsigbDpb >= msXOjBMcKQOlcnrFEgjiaModemAg.Count)
								{
									break;
								}
								jNlCyCSxHJKpJHpSobqaHhVnQFs = msXOjBMcKQOlcnrFEgjiaModemAg[lEiblanjrAejVNwVMSVBYsigbDpb];
								if ((!IftNYOsoyZKKlecDyJEriHNLMeG || jNlCyCSxHJKpJHpSobqaHhVnQFs.enabled) && (uutDYsXUWncZDaAJTeaAWthFzri || !GxphHAMqMhNBLjnlhXuBQmXaALiE.iPjDxoaipsmAFaublSaQReZEvXT(ISqdhDPqQEANztiginUyPvwvQrU, jNlCyCSxHJKpJHpSobqaHhVnQFs)))
								{
									iQMbcEaVSprJgFXsUoAkWmhNTkA = jNlCyCSxHJKpJHpSobqaHhVnQFs.ElementAssignmentConflicts(BNpOSJRceZAgEirMYviolwgJoKV, IftNYOsoyZKKlecDyJEriHNLMeG).GetEnumerator();
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0180;
								}
								goto IL_0196;
								IL_0196:
								lEiblanjrAejVNwVMSVBYsigbDpb++;
								goto IL_01a4;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								pGzAWegZSNwQoMqtkGhpKBeUpiW();
							}
						}
					}

					[DebuggerHidden]
					public NctdunImAnxkxTYEtMgzqZAPEGf(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void pGzAWegZSNwQoMqtkGhpKBeUpiW()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (iQMbcEaVSprJgFXsUoAkWmhNTkA != null)
						{
							iQMbcEaVSprJgFXsUoAkWmhNTkA.Dispose();
						}
					}
				}

				private sealed class ZYWDicrJIubEFxDYjBDqhqHBuEzV<T> : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo> where T : ControllerMap
				{
					private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public ConflictCheckingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ElementAssignmentConflictCheck CNxRWxtJdpKgAXgEBkMvLnqPffs;

					public ElementAssignmentConflictCheck VliyeXpMEMSvNHleVqLftHsOCYq;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public bool uutDYsXUWncZDaAJTeaAWthFzri;

					public bool HmXfeIizRcPIeSaeglGADvomlCL;

					public global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> msXOjBMcKQOlcnrFEgjiaModemAg;

					public global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> zrOvHCuPwAazxpKpxrevmrIsALV;

					public Player dAwUfxrLXcwUmyuNSIFxolxuDJo;

					public ControllerMap MGUXOgwjDLBdsFzbJcHPKiHkSjTH;

					public InputMapCategory JiwdMeEhqedzyrmjXbjyhfXFGrV;

					public int fwYSLVWePTAeQaMcNHEpcMScgGIV;

					public ControllerMap vxeqZTAvAOcBcEapmyplcCFMIlV;

					public ElementAssignmentConflictInfo iZInEpnlYQSHvmAwzfQtcSbhpvx;

					public ElementAssignmentConflictInfo WMJlhRchQbEwfKuZbtFEbWNieWW;

					public IEnumerator<ElementAssignmentConflictInfo> dkopEvsGIyOoecuMEbHbMGieSMc;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						ZYWDicrJIubEFxDYjBDqhqHBuEzV<T> zYWDicrJIubEFxDYjBDqhqHBuEzV;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							zYWDicrJIubEFxDYjBDqhqHBuEzV = this;
						}
						else
						{
							zYWDicrJIubEFxDYjBDqhqHBuEzV = new ZYWDicrJIubEFxDYjBDqhqHBuEzV<T>(0);
							zYWDicrJIubEFxDYjBDqhqHBuEzV.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						zYWDicrJIubEFxDYjBDqhqHBuEzV.CNxRWxtJdpKgAXgEBkMvLnqPffs = VliyeXpMEMSvNHleVqLftHsOCYq;
						zYWDicrJIubEFxDYjBDqhqHBuEzV.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						zYWDicrJIubEFxDYjBDqhqHBuEzV.uutDYsXUWncZDaAJTeaAWthFzri = HmXfeIizRcPIeSaeglGADvomlCL;
						zYWDicrJIubEFxDYjBDqhqHBuEzV.msXOjBMcKQOlcnrFEgjiaModemAg = zrOvHCuPwAazxpKpxrevmrIsALV;
						return zYWDicrJIubEFxDYjBDqhqHBuEzV;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (msXOjBMcKQOlcnrFEgjiaModemAg == null)
								{
									break;
								}
								dAwUfxrLXcwUmyuNSIFxolxuDJo = ReInput.players.GetPlayer(CNxRWxtJdpKgAXgEBkMvLnqPffs.playerId);
								if (dAwUfxrLXcwUmyuNSIFxolxuDJo == null)
								{
									break;
								}
								MGUXOgwjDLBdsFzbJcHPKiHkSjTH = dAwUfxrLXcwUmyuNSIFxolxuDJo.controllers.maps.GetMap(CNxRWxtJdpKgAXgEBkMvLnqPffs.controllerType, CNxRWxtJdpKgAXgEBkMvLnqPffs.controllerId, CNxRWxtJdpKgAXgEBkMvLnqPffs.controllerMapId);
								JiwdMeEhqedzyrmjXbjyhfXFGrV = ((MGUXOgwjDLBdsFzbJcHPKiHkSjTH != null) ? ReInput.mapping.GetMapCategory(MGUXOgwjDLBdsFzbJcHPKiHkSjTH.categoryId) : ReInput.mapping.GetMapCategory(CNxRWxtJdpKgAXgEBkMvLnqPffs.controllerMapCategoryId));
								if (JiwdMeEhqedzyrmjXbjyhfXFGrV == null)
								{
									break;
								}
								fwYSLVWePTAeQaMcNHEpcMScgGIV = 0;
								goto IL_0219;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_01f5;
								}
								IL_020b:
								fwYSLVWePTAeQaMcNHEpcMScgGIV++;
								goto IL_0219;
								IL_01f5:
								if (dkopEvsGIyOoecuMEbHbMGieSMc.MoveNext())
								{
									iZInEpnlYQSHvmAwzfQtcSbhpvx = dkopEvsGIyOoecuMEbHbMGieSMc.Current;
									ref ElementAssignmentConflictInfo wMJlhRchQbEwfKuZbtFEbWNieWW = ref WMJlhRchQbEwfKuZbtFEbWNieWW;
									wMJlhRchQbEwfKuZbtFEbWNieWW = new ElementAssignmentConflictInfo(iZInEpnlYQSHvmAwzfQtcSbhpvx);
									WMJlhRchQbEwfKuZbtFEbWNieWW.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WMJlhRchQbEwfKuZbtFEbWNieWW.controllerType = CNxRWxtJdpKgAXgEBkMvLnqPffs.controllerType;
									WMJlhRchQbEwfKuZbtFEbWNieWW.controllerId = CNxRWxtJdpKgAXgEBkMvLnqPffs.controllerId;
									WCNlIsEdYuVTqbNYvICUPcTebLU = WMJlhRchQbEwfKuZbtFEbWNieWW;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								tHnltBLEdoiXbFdjtgUPIZHkpPqa();
								goto IL_020b;
								IL_0219:
								if (fwYSLVWePTAeQaMcNHEpcMScgGIV >= msXOjBMcKQOlcnrFEgjiaModemAg.Count)
								{
									break;
								}
								vxeqZTAvAOcBcEapmyplcCFMIlV = msXOjBMcKQOlcnrFEgjiaModemAg[fwYSLVWePTAeQaMcNHEpcMScgGIV];
								if ((!IftNYOsoyZKKlecDyJEriHNLMeG || vxeqZTAvAOcBcEapmyplcCFMIlV.enabled) && (uutDYsXUWncZDaAJTeaAWthFzri || !GxphHAMqMhNBLjnlhXuBQmXaALiE.iPjDxoaipsmAFaublSaQReZEvXT(JiwdMeEhqedzyrmjXbjyhfXFGrV, vxeqZTAvAOcBcEapmyplcCFMIlV)))
								{
									dkopEvsGIyOoecuMEbHbMGieSMc = vxeqZTAvAOcBcEapmyplcCFMIlV.ElementAssignmentConflicts(CNxRWxtJdpKgAXgEBkMvLnqPffs, IftNYOsoyZKKlecDyJEriHNLMeG).GetEnumerator();
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_01f5;
								}
								goto IL_020b;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								tHnltBLEdoiXbFdjtgUPIZHkpPqa();
							}
						}
					}

					[DebuggerHidden]
					public ZYWDicrJIubEFxDYjBDqhqHBuEzV(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void tHnltBLEdoiXbFdjtgUPIZHkpPqa()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (dkopEvsGIyOoecuMEbHbMGieSMc != null)
						{
							dkopEvsGIyOoecuMEbHbMGieSMc.Dispose();
						}
					}
				}

				private readonly Player UeMLjuGiSFGfRltYoIYxjRdaYAm;

				private readonly ControllerHelper ugKyZyJTGtYLrHpCFnUKcqkaRKt;

				private readonly int VumWnlylMgxSbyJcluXptXvaaZa;

				internal ConflictCheckingHelper(Player player, ControllerHelper parent)
				{
					VumWnlylMgxSbyJcluXptXvaaZa = ReInput.id;
					UeMLjuGiSFGfRltYoIYxjRdaYAm = player;
					ugKyZyJTGtYLrHpCFnUKcqkaRKt = parent;
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					if (controllerMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => zhujiPtyKIUjoJCDAQdnKNLUPlG(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => OeUBbydtpfOEUXnYjUawdpyeLgY(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => WOrwUiciyJarkTlBnIeByaWUJVp(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => vcZSgcvWFniPEnEIAHADcJQUMHp(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					if (controllerMap == null || elementMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => zhujiPtyKIUjoJCDAQdnKNLUPlG(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => OeUBbydtpfOEUXnYjUawdpyeLgY(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => WOrwUiciyJarkTlBnIeByaWUJVp(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => vcZSgcvWFniPEnEIAHADcJQUMHp(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return zhujiPtyKIUjoJCDAQdnKNLUPlG(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return OeUBbydtpfOEUXnYjUawdpyeLgY(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return WOrwUiciyJarkTlBnIeByaWUJVp(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return vcZSgcvWFniPEnEIAHADcJQUMHp(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => imEfSDkTIsHIrdjAsQkcBtRagVfm(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => ThxRjdhbdGwOScyNlVNcNNEabZk(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => gmNpsZOqpLCaFvPmdoNPCGBdyub(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => XJBGBuwJZJlkBVsljPjUrsJRvfS(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (controllerMap == null || elementMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => imEfSDkTIsHIrdjAsQkcBtRagVfm(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => ThxRjdhbdGwOScyNlVNcNNEabZk(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => gmNpsZOqpLCaFvPmdoNPCGBdyub(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => XJBGBuwJZJlkBVsljPjUrsJRvfS(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return imEfSDkTIsHIrdjAsQkcBtRagVfm(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return ThxRjdhbdGwOScyNlVNcNNEabZk(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return gmNpsZOqpLCaFvPmdoNPCGBdyub(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return XJBGBuwJZJlkBVsljPjUrsJRvfS(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipRemovedMaps: false, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipRemovedMaps)
				{
					return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipRemovedMaps, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipRemovedMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => DLIMZofEHfKMVzGoYPfxNoBGWcU(controllerId, controllerMap as JoystickMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => erFMILoUPJnXxMYLEOrnNomHvks(controllerMap as KeyboardMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => QCvuesJWWfHNnEKFAzDYjoBeahQk(controllerMap as MouseMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => AvCaXpbgoguTJtawZMHGCOLuGFcO(controllerId, controllerMap as CustomControllerMap, skipRemovedMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipRemovedMaps: false, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipRemovedMaps)
				{
					return RemoveElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipRemovedMaps, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipRemovedMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => DLIMZofEHfKMVzGoYPfxNoBGWcU(controllerId, controllerMap as JoystickMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => erFMILoUPJnXxMYLEOrnNomHvks(controllerMap as KeyboardMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Mouse => QCvuesJWWfHNnEKFAzDYjoBeahQk(controllerMap as MouseMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						ControllerType.Custom => AvCaXpbgoguTJtawZMHGCOLuGFcO(controllerId, controllerMap as CustomControllerMap, elementMap, skipRemovedMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipRemovedMaps: false, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipRemovedMaps)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipRemovedMaps, forceCheckAllCategories: false);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipRemovedMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return DLIMZofEHfKMVzGoYPfxNoBGWcU(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return erFMILoUPJnXxMYLEOrnNomHvks(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return QCvuesJWWfHNnEKFAzDYjoBeahQk(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return AvCaXpbgoguTJtawZMHGCOLuGFcO(conflictCheck, skipRemovedMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap)
				{
					return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (controllerMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => jNFRBfgbfyiqxfrUufoAeQcqEIC(controllerId, controllerMap as JoystickMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => ezLAEUGBATCEUqTUGfseNvMiBHpH(controllerMap as KeyboardMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => TBPAicmNmEBkNlZBZjQKpZeTSlA(controllerMap as MouseMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => YPzgJpJeGVyhUpFDrUjfNGIIDRxE(controllerId, controllerMap as CustomControllerMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (controllerMap == null || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => jNFRBfgbfyiqxfrUufoAeQcqEIC(controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Keyboard => ezLAEUGBATCEUqTUGfseNvMiBHpH(controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Mouse => TBPAicmNmEBkNlZBZjQKpZeTSlA(controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						ControllerType.Custom => YPzgJpJeGVyhUpFDrUjfNGIIDRxE(controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return jNFRBfgbfyiqxfrUufoAeQcqEIC(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return ezLAEUGBATCEUqTUGfseNvMiBHpH(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return TBPAicmNmEBkNlZBZjQKpZeTSlA(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return YPzgJpJeGVyhUpFDrUjfNGIIDRxE(conflictCheck, skipDisabledMaps, forceCheckAllCategories);
					}
					throw new NotImplementedException();
				}

				private bool zhujiPtyKIUjoJCDAQdnKNLUPlG(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Count; i++)
					{
						Joystick fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0 && VlaMtTxmVVGJapbbMRZinKLlrxa(ControllerType.Joystick, P_0, P_1, P_2, P_3, ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ))
						{
							return true;
						}
					}
					return false;
				}

				private bool zhujiPtyKIUjoJCDAQdnKNLUPlG(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Count; i++)
					{
						Joystick fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0 && VlaMtTxmVVGJapbbMRZinKLlrxa(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ))
						{
							return true;
						}
					}
					return false;
				}

				private bool zhujiPtyKIUjoJCDAQdnKNLUPlG(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Count; i++)
					{
						Joystick fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0.controllerId && VlaMtTxmVVGJapbbMRZinKLlrxa(P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ))
						{
							return true;
						}
					}
					return false;
				}

				private bool OeUBbydtpfOEUXnYjUawdpyeLgY(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return VlaMtTxmVVGJapbbMRZinKLlrxa(ControllerType.Keyboard, 0, P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.keyboardMapSet);
				}

				private bool OeUBbydtpfOEUXnYjUawdpyeLgY(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return VlaMtTxmVVGJapbbMRZinKLlrxa(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, ugKyZyJTGtYLrHpCFnUKcqkaRKt.keyboardMapSet);
				}

				private bool OeUBbydtpfOEUXnYjUawdpyeLgY(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return VlaMtTxmVVGJapbbMRZinKLlrxa(P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.keyboardMapSet);
				}

				private bool WOrwUiciyJarkTlBnIeByaWUJVp(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return VlaMtTxmVVGJapbbMRZinKLlrxa(ControllerType.Mouse, 0, P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.mouseMapSet);
				}

				private bool WOrwUiciyJarkTlBnIeByaWUJVp(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return VlaMtTxmVVGJapbbMRZinKLlrxa(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, ugKyZyJTGtYLrHpCFnUKcqkaRKt.mouseMapSet);
				}

				private bool WOrwUiciyJarkTlBnIeByaWUJVp(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					return VlaMtTxmVVGJapbbMRZinKLlrxa(P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.mouseMapSet);
				}

				private bool vcZSgcvWFniPEnEIAHADcJQUMHp(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return false;
					}
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Count; i++)
					{
						CustomController fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0 && VlaMtTxmVVGJapbbMRZinKLlrxa(ControllerType.Custom, P_0, P_1, P_2, P_3, ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ))
						{
							return true;
						}
					}
					return false;
				}

				private bool vcZSgcvWFniPEnEIAHADcJQUMHp(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Count; i++)
					{
						CustomController fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0 && VlaMtTxmVVGJapbbMRZinKLlrxa(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ))
						{
							return true;
						}
					}
					return false;
				}

				private bool vcZSgcvWFniPEnEIAHADcJQUMHp(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Count; i++)
					{
						CustomController fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0.controllerId && VlaMtTxmVVGJapbbMRZinKLlrxa(P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ))
						{
							return true;
						}
					}
					return false;
				}

				private IEnumerable<ElementAssignmentConflictInfo> imEfSDkTIsHIrdjAsQkcBtRagVfm(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					oGxLIbtQJutfkgrQAOyMQWoBTj oGxLIbtQJutfkgrQAOyMQWoBTj2 = new oGxLIbtQJutfkgrQAOyMQWoBTj(-2);
					oGxLIbtQJutfkgrQAOyMQWoBTj2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					oGxLIbtQJutfkgrQAOyMQWoBTj2.qsPOrjVoFKLUWZUgvOumbnMylMT = P_0;
					oGxLIbtQJutfkgrQAOyMQWoBTj2.QAgyYUmecnNCVLpzuecMsGLCdJP = P_1;
					oGxLIbtQJutfkgrQAOyMQWoBTj2.TGDalxAGxtEWicADkzmraNyMfPny = P_2;
					oGxLIbtQJutfkgrQAOyMQWoBTj2.HmXfeIizRcPIeSaeglGADvomlCL = P_3;
					return oGxLIbtQJutfkgrQAOyMQWoBTj2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> imEfSDkTIsHIrdjAsQkcBtRagVfm(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					ECmWJgrqbFVoufDOwJuKnsNMFDk eCmWJgrqbFVoufDOwJuKnsNMFDk = new ECmWJgrqbFVoufDOwJuKnsNMFDk(-2);
					eCmWJgrqbFVoufDOwJuKnsNMFDk.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					eCmWJgrqbFVoufDOwJuKnsNMFDk.qsPOrjVoFKLUWZUgvOumbnMylMT = P_0;
					eCmWJgrqbFVoufDOwJuKnsNMFDk.QAgyYUmecnNCVLpzuecMsGLCdJP = P_1;
					eCmWJgrqbFVoufDOwJuKnsNMFDk.NkBrCorifFgAHeRDTEXXfZaiuzJS = P_2;
					eCmWJgrqbFVoufDOwJuKnsNMFDk.TGDalxAGxtEWicADkzmraNyMfPny = P_3;
					eCmWJgrqbFVoufDOwJuKnsNMFDk.HmXfeIizRcPIeSaeglGADvomlCL = P_4;
					return eCmWJgrqbFVoufDOwJuKnsNMFDk;
				}

				private IEnumerable<ElementAssignmentConflictInfo> imEfSDkTIsHIrdjAsQkcBtRagVfm(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					eHSJHlvPfDQrBCCNuSjMHHLBrjH eHSJHlvPfDQrBCCNuSjMHHLBrjH2 = new eHSJHlvPfDQrBCCNuSjMHHLBrjH(-2);
					eHSJHlvPfDQrBCCNuSjMHHLBrjH2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					eHSJHlvPfDQrBCCNuSjMHHLBrjH2.VliyeXpMEMSvNHleVqLftHsOCYq = P_0;
					eHSJHlvPfDQrBCCNuSjMHHLBrjH2.TGDalxAGxtEWicADkzmraNyMfPny = P_1;
					eHSJHlvPfDQrBCCNuSjMHHLBrjH2.HmXfeIizRcPIeSaeglGADvomlCL = P_2;
					return eHSJHlvPfDQrBCCNuSjMHHLBrjH2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> ThxRjdhbdGwOScyNlVNcNNEabZk(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return bliAUPfXkkEIHTXgYKALWgNvOeE(ControllerType.Keyboard, 0, P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.keyboardMapSet);
				}

				private IEnumerable<ElementAssignmentConflictInfo> ThxRjdhbdGwOScyNlVNcNNEabZk(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return bliAUPfXkkEIHTXgYKALWgNvOeE(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, ugKyZyJTGtYLrHpCFnUKcqkaRKt.keyboardMapSet);
				}

				private IEnumerable<ElementAssignmentConflictInfo> ThxRjdhbdGwOScyNlVNcNNEabZk(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return bliAUPfXkkEIHTXgYKALWgNvOeE(P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.keyboardMapSet);
				}

				private IEnumerable<ElementAssignmentConflictInfo> gmNpsZOqpLCaFvPmdoNPCGBdyub(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return bliAUPfXkkEIHTXgYKALWgNvOeE(ControllerType.Mouse, 0, P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.mouseMapSet);
				}

				private IEnumerable<ElementAssignmentConflictInfo> gmNpsZOqpLCaFvPmdoNPCGBdyub(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return bliAUPfXkkEIHTXgYKALWgNvOeE(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, ugKyZyJTGtYLrHpCFnUKcqkaRKt.mouseMapSet);
				}

				private IEnumerable<ElementAssignmentConflictInfo> gmNpsZOqpLCaFvPmdoNPCGBdyub(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return bliAUPfXkkEIHTXgYKALWgNvOeE(P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.mouseMapSet);
				}

				private IEnumerable<ElementAssignmentConflictInfo> XJBGBuwJZJlkBVsljPjUrsJRvfS(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					PRolEOsepAzDlcjXuDaUAtRYdFXQ pRolEOsepAzDlcjXuDaUAtRYdFXQ = new PRolEOsepAzDlcjXuDaUAtRYdFXQ(-2);
					pRolEOsepAzDlcjXuDaUAtRYdFXQ.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					pRolEOsepAzDlcjXuDaUAtRYdFXQ.zhMonKvpOLkvrBNtkyLqdqaacQk = P_0;
					pRolEOsepAzDlcjXuDaUAtRYdFXQ.cZWuOBOpCJthSgelvekCWzFQsfH = P_1;
					pRolEOsepAzDlcjXuDaUAtRYdFXQ.TGDalxAGxtEWicADkzmraNyMfPny = P_2;
					pRolEOsepAzDlcjXuDaUAtRYdFXQ.HmXfeIizRcPIeSaeglGADvomlCL = P_3;
					return pRolEOsepAzDlcjXuDaUAtRYdFXQ;
				}

				private IEnumerable<ElementAssignmentConflictInfo> XJBGBuwJZJlkBVsljPjUrsJRvfS(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					hTEEKJpYLHsBxpaDUZRWBrUnrqj hTEEKJpYLHsBxpaDUZRWBrUnrqj2 = new hTEEKJpYLHsBxpaDUZRWBrUnrqj(-2);
					hTEEKJpYLHsBxpaDUZRWBrUnrqj2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					hTEEKJpYLHsBxpaDUZRWBrUnrqj2.zhMonKvpOLkvrBNtkyLqdqaacQk = P_0;
					hTEEKJpYLHsBxpaDUZRWBrUnrqj2.cZWuOBOpCJthSgelvekCWzFQsfH = P_1;
					hTEEKJpYLHsBxpaDUZRWBrUnrqj2.NkBrCorifFgAHeRDTEXXfZaiuzJS = P_2;
					hTEEKJpYLHsBxpaDUZRWBrUnrqj2.TGDalxAGxtEWicADkzmraNyMfPny = P_3;
					hTEEKJpYLHsBxpaDUZRWBrUnrqj2.HmXfeIizRcPIeSaeglGADvomlCL = P_4;
					return hTEEKJpYLHsBxpaDUZRWBrUnrqj2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> XJBGBuwJZJlkBVsljPjUrsJRvfS(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					EHnLIndlFvThgKwcFVfxIUTgtqV eHnLIndlFvThgKwcFVfxIUTgtqV = new EHnLIndlFvThgKwcFVfxIUTgtqV(-2);
					eHnLIndlFvThgKwcFVfxIUTgtqV.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					eHnLIndlFvThgKwcFVfxIUTgtqV.VliyeXpMEMSvNHleVqLftHsOCYq = P_0;
					eHnLIndlFvThgKwcFVfxIUTgtqV.TGDalxAGxtEWicADkzmraNyMfPny = P_1;
					eHnLIndlFvThgKwcFVfxIUTgtqV.HmXfeIizRcPIeSaeglGADvomlCL = P_2;
					return eHnLIndlFvThgKwcFVfxIUTgtqV;
				}

				private int DLIMZofEHfKMVzGoYPfxNoBGWcU(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Count; i++)
					{
						Joystick fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0)
						{
							num += waTFRqucGiavEOKaxwXQoiNdWqN(ControllerType.Joystick, P_0, P_1, P_2, P_3, ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ);
						}
					}
					return num;
				}

				private int DLIMZofEHfKMVzGoYPfxNoBGWcU(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Count; i++)
					{
						Joystick fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0)
						{
							num += waTFRqucGiavEOKaxwXQoiNdWqN(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ);
						}
					}
					return num;
				}

				private int DLIMZofEHfKMVzGoYPfxNoBGWcU(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Count; i++)
					{
						Joystick fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0.controllerId)
						{
							num += waTFRqucGiavEOKaxwXQoiNdWqN(P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ);
						}
					}
					return num;
				}

				private int erFMILoUPJnXxMYLEOrnNomHvks(KeyboardMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return waTFRqucGiavEOKaxwXQoiNdWqN(ControllerType.Keyboard, 0, P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.keyboardMapSet);
				}

				private int erFMILoUPJnXxMYLEOrnNomHvks(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return waTFRqucGiavEOKaxwXQoiNdWqN(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, ugKyZyJTGtYLrHpCFnUKcqkaRKt.keyboardMapSet);
				}

				private int erFMILoUPJnXxMYLEOrnNomHvks(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return waTFRqucGiavEOKaxwXQoiNdWqN(P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.keyboardMapSet);
				}

				private int QCvuesJWWfHNnEKFAzDYjoBeahQk(MouseMap P_0, bool P_1 = false, bool P_2 = false)
				{
					return waTFRqucGiavEOKaxwXQoiNdWqN(ControllerType.Mouse, 0, P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.mouseMapSet);
				}

				private int QCvuesJWWfHNnEKFAzDYjoBeahQk(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false)
				{
					return waTFRqucGiavEOKaxwXQoiNdWqN(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, ugKyZyJTGtYLrHpCFnUKcqkaRKt.mouseMapSet);
				}

				private int QCvuesJWWfHNnEKFAzDYjoBeahQk(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return waTFRqucGiavEOKaxwXQoiNdWqN(P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.mouseMapSet);
				}

				private int AvCaXpbgoguTJtawZMHGCOLuGFcO(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Count; i++)
					{
						CustomController fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0)
						{
							num += waTFRqucGiavEOKaxwXQoiNdWqN(ControllerType.Custom, P_0, P_1, P_2, P_3, ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ);
						}
					}
					return num;
				}

				private int AvCaXpbgoguTJtawZMHGCOLuGFcO(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Count; i++)
					{
						CustomController fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0)
						{
							num += waTFRqucGiavEOKaxwXQoiNdWqN(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ);
						}
					}
					return num;
				}

				private int AvCaXpbgoguTJtawZMHGCOLuGFcO(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Count; i++)
					{
						CustomController fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0.controllerId)
						{
							num += waTFRqucGiavEOKaxwXQoiNdWqN(P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ);
						}
					}
					return num;
				}

				private int jNFRBfgbfyiqxfrUufoAeQcqEIC(int P_0, JoystickMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Count; i++)
					{
						Joystick fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0)
						{
							num += uYwxIBEwgxONcHwzfXTGnIioFcq(ControllerType.Joystick, P_0, P_1, P_2, P_3, ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ, P_4);
						}
					}
					return num;
				}

				private int jNFRBfgbfyiqxfrUufoAeQcqEIC(int P_0, JoystickMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Count; i++)
					{
						Joystick fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0)
						{
							num += uYwxIBEwgxONcHwzfXTGnIioFcq(ControllerType.Joystick, P_0, P_1, P_2, P_3, P_4, ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ, P_5);
						}
					}
					return num;
				}

				private int jNFRBfgbfyiqxfrUufoAeQcqEIC(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Count; i++)
					{
						Joystick fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0.controllerId)
						{
							num += uYwxIBEwgxONcHwzfXTGnIioFcq(P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ, P_3);
						}
					}
					return num;
				}

				private int ezLAEUGBATCEUqTUGfseNvMiBHpH(KeyboardMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return uYwxIBEwgxONcHwzfXTGnIioFcq(ControllerType.Keyboard, 0, P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.keyboardMapSet, P_3);
				}

				private int ezLAEUGBATCEUqTUGfseNvMiBHpH(KeyboardMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return uYwxIBEwgxONcHwzfXTGnIioFcq(ControllerType.Keyboard, 0, P_0, P_1, P_2, P_3, ugKyZyJTGtYLrHpCFnUKcqkaRKt.keyboardMapSet, P_4);
				}

				private int ezLAEUGBATCEUqTUGfseNvMiBHpH(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return uYwxIBEwgxONcHwzfXTGnIioFcq(P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.keyboardMapSet, P_3);
				}

				private int TBPAicmNmEBkNlZBZjQKpZeTSlA(MouseMap P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					return uYwxIBEwgxONcHwzfXTGnIioFcq(ControllerType.Mouse, 0, P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.mouseMapSet, P_3);
				}

				private int TBPAicmNmEBkNlZBZjQKpZeTSlA(MouseMap P_0, ActionElementMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					return uYwxIBEwgxONcHwzfXTGnIioFcq(ControllerType.Mouse, 0, P_0, P_1, P_2, P_3, ugKyZyJTGtYLrHpCFnUKcqkaRKt.mouseMapSet, P_4);
				}

				private int TBPAicmNmEBkNlZBZjQKpZeTSlA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					return uYwxIBEwgxONcHwzfXTGnIioFcq(P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.mouseMapSet, P_3);
				}

				private int YPzgJpJeGVyhUpFDrUjfNGIIDRxE(int P_0, CustomControllerMap P_1, bool P_2 = false, bool P_3 = false, List<ActionElementMap> P_4 = null)
				{
					if (P_0 < 0 || P_1 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Count; i++)
					{
						CustomController fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0)
						{
							num += uYwxIBEwgxONcHwzfXTGnIioFcq(ControllerType.Custom, P_0, P_1, P_2, P_3, ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ, P_4);
						}
					}
					return num;
				}

				private int YPzgJpJeGVyhUpFDrUjfNGIIDRxE(int P_0, CustomControllerMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, List<ActionElementMap> P_5 = null)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Count; i++)
					{
						CustomController fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0)
						{
							num += uYwxIBEwgxONcHwzfXTGnIioFcq(ControllerType.Custom, P_0, P_1, P_2, P_3, P_4, ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ, P_5);
						}
					}
					return num;
				}

				private int YPzgJpJeGVyhUpFDrUjfNGIIDRxE(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, List<ActionElementMap> P_3 = null)
				{
					if (P_0.controllerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Count; i++)
					{
						CustomController fKtcxmBappHTSHGoccIYREwbpfog = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].FKtcxmBappHTSHGoccIYREwbpfog;
						if (fKtcxmBappHTSHGoccIYREwbpfog.id == P_0.controllerId)
						{
							num += uYwxIBEwgxONcHwzfXTGnIioFcq(P_0, P_1, P_2, ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ, P_3);
						}
					}
					return num;
				}

				private bool VlaMtTxmVVGJapbbMRZinKLlrxa<T>(ControllerType P_0, int P_1, T P_2, bool P_3, bool P_4, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> P_5) where T : ControllerMap
				{
					if (P_5 == null || P_2 == null)
					{
						return false;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_2.categoryId);
					if (mapCategory == null)
					{
						return false;
					}
					for (int i = 0; i < P_5.Count; i++)
					{
						ControllerMap controllerMap = P_5[i];
						if ((!P_3 || controllerMap.enabled) && (P_4 || !iPjDxoaipsmAFaublSaQReZEvXT(mapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_2, P_3))
						{
							return true;
						}
					}
					return false;
				}

				private bool VlaMtTxmVVGJapbbMRZinKLlrxa<T>(ControllerType P_0, int P_1, T P_2, ActionElementMap P_3, bool P_4, bool P_5, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> P_6) where T : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return false;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					for (int i = 0; i < P_6.Count; i++)
					{
						ControllerMap controllerMap = P_6[i];
						if ((!P_4 || controllerMap.enabled) && (P_5 || !iPjDxoaipsmAFaublSaQReZEvXT(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool VlaMtTxmVVGJapbbMRZinKLlrxa<T>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> P_3) where T : ControllerMap
				{
					if (P_3 == null)
					{
						return false;
					}
					Player player = ReInput.players.GetPlayer(P_0.playerId);
					if (player == null)
					{
						return false;
					}
					ControllerMap map = player.controllers.maps.GetMap(P_0.controllerType, P_0.controllerId, P_0.controllerMapId);
					InputMapCategory inputMapCategory = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(P_0.controllerMapCategoryId));
					if (inputMapCategory == null)
					{
						return false;
					}
					for (int i = 0; i < P_3.Count; i++)
					{
						ControllerMap controllerMap = P_3[i];
						if ((!P_1 || controllerMap.enabled) && (P_2 || !iPjDxoaipsmAFaublSaQReZEvXT(inputMapCategory, controllerMap)) && controllerMap.DoesElementAssignmentConflict(P_0, P_1))
						{
							return true;
						}
					}
					return false;
				}

				private IEnumerable<ElementAssignmentConflictInfo> bliAUPfXkkEIHTXgYKALWgNvOeE<T>(ControllerType P_0, int P_1, T P_2, bool P_3, bool P_4, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> P_5) where T : ControllerMap
				{
					xNztvvvWLQMHcmbVsSdoMlaDbXjd<T> xNztvvvWLQMHcmbVsSdoMlaDbXjd2 = new xNztvvvWLQMHcmbVsSdoMlaDbXjd<T>(-2);
					xNztvvvWLQMHcmbVsSdoMlaDbXjd2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					xNztvvvWLQMHcmbVsSdoMlaDbXjd2.tzNVSSJYEEurgoRRcPJzhibzRlw = P_0;
					xNztvvvWLQMHcmbVsSdoMlaDbXjd2.sNTdfjDyfxaSaQmJvfYryRePNuP = P_1;
					xNztvvvWLQMHcmbVsSdoMlaDbXjd2.LTcBMeSMNRjbHilwVWWHCEqhiOba = P_2;
					xNztvvvWLQMHcmbVsSdoMlaDbXjd2.TGDalxAGxtEWicADkzmraNyMfPny = P_3;
					xNztvvvWLQMHcmbVsSdoMlaDbXjd2.HmXfeIizRcPIeSaeglGADvomlCL = P_4;
					xNztvvvWLQMHcmbVsSdoMlaDbXjd2.zrOvHCuPwAazxpKpxrevmrIsALV = P_5;
					return xNztvvvWLQMHcmbVsSdoMlaDbXjd2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> bliAUPfXkkEIHTXgYKALWgNvOeE<T>(ControllerType P_0, int P_1, T P_2, ActionElementMap P_3, bool P_4, bool P_5, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> P_6) where T : ControllerMap
				{
					NctdunImAnxkxTYEtMgzqZAPEGf<T> nctdunImAnxkxTYEtMgzqZAPEGf = new NctdunImAnxkxTYEtMgzqZAPEGf<T>(-2);
					nctdunImAnxkxTYEtMgzqZAPEGf.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					nctdunImAnxkxTYEtMgzqZAPEGf.tzNVSSJYEEurgoRRcPJzhibzRlw = P_0;
					nctdunImAnxkxTYEtMgzqZAPEGf.sNTdfjDyfxaSaQmJvfYryRePNuP = P_1;
					nctdunImAnxkxTYEtMgzqZAPEGf.LTcBMeSMNRjbHilwVWWHCEqhiOba = P_2;
					nctdunImAnxkxTYEtMgzqZAPEGf.tRBqmsewkInWhxWpvmsWzSxgrCd = P_3;
					nctdunImAnxkxTYEtMgzqZAPEGf.TGDalxAGxtEWicADkzmraNyMfPny = P_4;
					nctdunImAnxkxTYEtMgzqZAPEGf.HmXfeIizRcPIeSaeglGADvomlCL = P_5;
					nctdunImAnxkxTYEtMgzqZAPEGf.zrOvHCuPwAazxpKpxrevmrIsALV = P_6;
					return nctdunImAnxkxTYEtMgzqZAPEGf;
				}

				private IEnumerable<ElementAssignmentConflictInfo> bliAUPfXkkEIHTXgYKALWgNvOeE<T>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> P_3) where T : ControllerMap
				{
					ZYWDicrJIubEFxDYjBDqhqHBuEzV<T> zYWDicrJIubEFxDYjBDqhqHBuEzV = new ZYWDicrJIubEFxDYjBDqhqHBuEzV<T>(-2);
					zYWDicrJIubEFxDYjBDqhqHBuEzV.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					zYWDicrJIubEFxDYjBDqhqHBuEzV.VliyeXpMEMSvNHleVqLftHsOCYq = P_0;
					zYWDicrJIubEFxDYjBDqhqHBuEzV.TGDalxAGxtEWicADkzmraNyMfPny = P_1;
					zYWDicrJIubEFxDYjBDqhqHBuEzV.HmXfeIizRcPIeSaeglGADvomlCL = P_2;
					zYWDicrJIubEFxDYjBDqhqHBuEzV.zrOvHCuPwAazxpKpxrevmrIsALV = P_3;
					return zYWDicrJIubEFxDYjBDqhqHBuEzV;
				}

				private int waTFRqucGiavEOKaxwXQoiNdWqN<T>(ControllerType P_0, int P_1, T P_2, bool P_3, bool P_4, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> P_5) where T : ControllerMap
				{
					if (P_5 == null || P_2 == null)
					{
						return 0;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_2.categoryId);
					if (mapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_5.Count; i++)
					{
						ControllerMap controllerMap = P_5[i];
						if ((!P_3 || controllerMap.enabled) && (P_4 || !iPjDxoaipsmAFaublSaQReZEvXT(mapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_2, P_3);
						}
					}
					return num;
				}

				private int waTFRqucGiavEOKaxwXQoiNdWqN<T>(ControllerType P_0, int P_1, T P_2, ActionElementMap P_3, bool P_4, bool P_5, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> P_6) where T : ControllerMap
				{
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.Count; i++)
					{
						ControllerMap controllerMap = P_6[i];
						if ((!P_4 || controllerMap.enabled) && (P_5 || !iPjDxoaipsmAFaublSaQReZEvXT(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_3, P_4);
						}
					}
					return num;
				}

				private int waTFRqucGiavEOKaxwXQoiNdWqN<T>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> P_3) where T : ControllerMap
				{
					if (P_3 == null)
					{
						return 0;
					}
					Player player = ReInput.players.GetPlayer(P_0.playerId);
					if (player == null)
					{
						return 0;
					}
					ControllerMap map = player.controllers.maps.GetMap(P_0.controllerType, P_0.controllerId, P_0.controllerMapId);
					InputMapCategory inputMapCategory = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(P_0.controllerMapCategoryId));
					if (inputMapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_3.Count; i++)
					{
						ControllerMap controllerMap = P_3[i];
						if ((!P_1 || controllerMap.enabled) && (P_2 || !iPjDxoaipsmAFaublSaQReZEvXT(inputMapCategory, controllerMap)))
						{
							num += controllerMap.RemoveElementAssignmentConflicts(P_0, P_1);
						}
					}
					return num;
				}

				private int uYwxIBEwgxONcHwzfXTGnIioFcq<T>(ControllerType P_0, int P_1, T P_2, bool P_3, bool P_4, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> P_5, List<ActionElementMap> P_6 = null) where T : ControllerMap
				{
					P_6?.Clear();
					if (P_5 == null || P_2 == null)
					{
						return 0;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_2.categoryId);
					if (mapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_5.Count; i++)
					{
						ControllerMap controllerMap = P_5[i];
						if ((!P_3 || controllerMap.enabled) && (P_4 || !iPjDxoaipsmAFaublSaQReZEvXT(mapCategory, controllerMap)))
						{
							num += controllerMap.uYwxIBEwgxONcHwzfXTGnIioFcq(P_2, P_3, P_6, true);
						}
					}
					return num;
				}

				private int uYwxIBEwgxONcHwzfXTGnIioFcq<T>(ControllerType P_0, int P_1, T P_2, ActionElementMap P_3, bool P_4, bool P_5, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> P_6, List<ActionElementMap> P_7 = null) where T : ControllerMap
				{
					P_7?.Clear();
					if (P_6 == null || P_3 == null)
					{
						return 0;
					}
					InputMapCategory inputMapCategory = ((P_2 != null) ? ReInput.mapping.GetMapCategory(P_2.categoryId) : null);
					int num = 0;
					for (int i = 0; i < P_6.Count; i++)
					{
						ControllerMap controllerMap = P_6[i];
						if ((!P_4 || controllerMap.enabled) && (P_5 || !iPjDxoaipsmAFaublSaQReZEvXT(inputMapCategory, controllerMap)))
						{
							num += controllerMap.uYwxIBEwgxONcHwzfXTGnIioFcq(P_3, P_4, P_7, true);
						}
					}
					return num;
				}

				private int uYwxIBEwgxONcHwzfXTGnIioFcq<T>(ElementAssignmentConflictCheck P_0, bool P_1, bool P_2, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<T> P_3, List<ActionElementMap> P_4 = null) where T : ControllerMap
				{
					P_4?.Clear();
					if (P_3 == null)
					{
						return 0;
					}
					Player player = ReInput.players.GetPlayer(P_0.playerId);
					if (player == null)
					{
						return 0;
					}
					ControllerMap map = player.controllers.maps.GetMap(P_0.controllerType, P_0.controllerId, P_0.controllerMapId);
					InputMapCategory inputMapCategory = ((map != null) ? ReInput.mapping.GetMapCategory(map.categoryId) : ReInput.mapping.GetMapCategory(P_0.controllerMapCategoryId));
					if (inputMapCategory == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < P_3.Count; i++)
					{
						ControllerMap controllerMap = P_3[i];
						if ((!P_1 || controllerMap.enabled) && (P_2 || !iPjDxoaipsmAFaublSaQReZEvXT(inputMapCategory, controllerMap)))
						{
							num += controllerMap.uYwxIBEwgxONcHwzfXTGnIioFcq(P_0, P_1, P_4, true);
						}
					}
					return num;
				}

				private bool iPjDxoaipsmAFaublSaQReZEvXT(InputMapCategory P_0, ControllerMap P_1)
				{
					if (P_0 == null || P_1 == null)
					{
						return false;
					}
					if (P_0.checkConflictsWithAllCategories)
					{
						return false;
					}
					IList<int> checkConflictsCategoryIds = P_0.checkConflictsCategoryIds;
					if (checkConflictsCategoryIds == null)
					{
						return true;
					}
					for (int i = 0; i < checkConflictsCategoryIds.Count; i++)
					{
						if (checkConflictsCategoryIds[i] == P_1.categoryId)
						{
							return false;
						}
					}
					return true;
				}
			}

			internal interface GqqVmTmEPnWlhtHJrWWOcCmltOt
			{
				LEYwjXNPaJjLrFHUDPJUhWSYyxmR this[int index] { get; }

				ControllerType controllerType { get; }

				int Count { get; }

				bool qUMsmxJoDabnMgpnPbuRnplJapZC(Controller P_0);

				bool qUMsmxJoDabnMgpnPbuRnplJapZC(int P_0);

				void xBnLqyjdZjJraDJKyHVWmGRDquG(int P_0);

				void xBnLqyjdZjJraDJKyHVWmGRDquG(Controller P_0);

				void AwAkOvTQBbpundzBkvKAJQrGudy(int P_0);

				Controller ZqzzcVLLrMBIUyLpDAZiOGBIopG(int P_0);

				Controller nzOJKNVhwbNfErkEKCbnggvNzLZ(string P_0);

				int iFNXApJjlWtDZdwedJFKpfGAMok(Controller P_0);

				int iFNXApJjlWtDZdwedJFKpfGAMok(int P_0);

				int gdwrrUnehPrKtLJLcQDWjGmMxLw(string P_0);

				void VcHhfbFqwxAmqhwBHKVJpDjlfufe();

				LEYwjXNPaJjLrFHUDPJUhWSYyxmR CXouiQVNNifvOhfkUWFfiMKCNFx(int P_0);

				LEYwjXNPaJjLrFHUDPJUhWSYyxmR CXouiQVNNifvOhfkUWFfiMKCNFx(Controller P_0);

				void WLmhwxVIRpQznYyjnRtiVlRHzYd(LEYwjXNPaJjLrFHUDPJUhWSYyxmR P_0);
			}

			internal interface LEYwjXNPaJjLrFHUDPJUhWSYyxmR
			{
				SaFIhRkKoaFsJonuErfrovvvDai mapSet { get; }

				Controller controller { get; }

				double lastActiveTime { get; }
			}

			internal sealed class CiBOuMFOJpyCeTavwEkrJOcXHWu<TController, TMap> : GqqVmTmEPnWlhtHJrWWOcCmltOt where TController : Controller where TMap : ControllerMap
			{
				public class aLsWzHkpJEuncBoWNDXtzbFVdTda : LEYwjXNPaJjLrFHUDPJUhWSYyxmR
				{
					public TController FKtcxmBappHTSHGoccIYREwbpfog;

					public global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<TMap> VhZfrlASXHRPSRCbfcxNqUcSXtJ;

					public double sPMIadIcxtEofwtFsVfURTiBSsl;

					Controller LEYwjXNPaJjLrFHUDPJUhWSYyxmR.controller => FKtcxmBappHTSHGoccIYREwbpfog;

					SaFIhRkKoaFsJonuErfrovvvDai LEYwjXNPaJjLrFHUDPJUhWSYyxmR.mapSet => VhZfrlASXHRPSRCbfcxNqUcSXtJ;

					double LEYwjXNPaJjLrFHUDPJUhWSYyxmR.lastActiveTime => sPMIadIcxtEofwtFsVfURTiBSsl;

					public aLsWzHkpJEuncBoWNDXtzbFVdTda(TController controller, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<TMap> mapSet)
					{
						FKtcxmBappHTSHGoccIYREwbpfog = controller;
						VhZfrlASXHRPSRCbfcxNqUcSXtJ = mapSet;
					}

					public void ztehiAbBWLMJjiUjLbqrHIvSSTE()
					{
						sPMIadIcxtEofwtFsVfURTiBSsl = ReInput.unscaledTime;
					}
				}

				private List<aLsWzHkpJEuncBoWNDXtzbFVdTda> fHYhNBaQNYWfQUnIKASBnOPzYNC;

				private List<TController> CcuArxKiMBIHLfvQxbURmiupmIfb;

				private ReadOnlyCollection<TController> hlzFVqZNeRXsYKFJnAHIeiRrNnAu;

				private readonly ControllerType VkxeQjDVSfumjFSZdzmQHhgPgAwE;

				public int Count => fHYhNBaQNYWfQUnIKASBnOPzYNC.Count;

				public IList<TController> Controllers_readOnly => hlzFVqZNeRXsYKFJnAHIeiRrNnAu;

				public aLsWzHkpJEuncBoWNDXtzbFVdTda this[int index] => fHYhNBaQNYWfQUnIKASBnOPzYNC[index];

				public ControllerType controllerType => VkxeQjDVSfumjFSZdzmQHhgPgAwE;

				LEYwjXNPaJjLrFHUDPJUhWSYyxmR GqqVmTmEPnWlhtHJrWWOcCmltOt.this[int index] => fHYhNBaQNYWfQUnIKASBnOPzYNC[index];

				public CiBOuMFOJpyCeTavwEkrJOcXHWu()
				{
					if (!object.ReferenceEquals(XqmnYoifzflCsKxcFaHDewlkEkh.aJrrqGyLCDRlBrfkAGETCWIFCyIz<TController>(), typeof(TMap)))
					{
						throw new Exception(typeof(TController).Name + " cannot be used with a map of type " + typeof(TMap).Name);
					}
					VkxeQjDVSfumjFSZdzmQHhgPgAwE = XqmnYoifzflCsKxcFaHDewlkEkh.COrXrkTEKmpseQxNMlRJlIhLHQU(typeof(TController));
					fHYhNBaQNYWfQUnIKASBnOPzYNC = new List<aLsWzHkpJEuncBoWNDXtzbFVdTda>();
					CcuArxKiMBIHLfvQxbURmiupmIfb = new List<TController>();
					hlzFVqZNeRXsYKFJnAHIeiRrNnAu = new ReadOnlyCollection<TController>(CcuArxKiMBIHLfvQxbURmiupmIfb);
				}

				public aLsWzHkpJEuncBoWNDXtzbFVdTda CXouiQVNNifvOhfkUWFfiMKCNFx(int P_0)
				{
					if (VkxeQjDVSfumjFSZdzmQHhgPgAwE == ControllerType.Keyboard || VkxeQjDVSfumjFSZdzmQHhgPgAwE == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = iFNXApJjlWtDZdwedJFKpfGAMok(P_0);
					if (num < 0)
					{
						return null;
					}
					return fHYhNBaQNYWfQUnIKASBnOPzYNC[num];
				}

				public aLsWzHkpJEuncBoWNDXtzbFVdTda CXouiQVNNifvOhfkUWFfiMKCNFx(TController P_0)
				{
					if (P_0 == null)
					{
						return null;
					}
					return CXouiQVNNifvOhfkUWFfiMKCNFx(P_0.id);
				}

				public void WLmhwxVIRpQznYyjnRtiVlRHzYd(aLsWzHkpJEuncBoWNDXtzbFVdTda P_0)
				{
					if (P_0 != null)
					{
						fHYhNBaQNYWfQUnIKASBnOPzYNC.Add(P_0);
						CcuArxKiMBIHLfvQxbURmiupmIfb.Add(P_0.FKtcxmBappHTSHGoccIYREwbpfog);
					}
				}

				public void xBnLqyjdZjJraDJKyHVWmGRDquG(int P_0)
				{
					if (VkxeQjDVSfumjFSZdzmQHhgPgAwE == ControllerType.Keyboard || VkxeQjDVSfumjFSZdzmQHhgPgAwE == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = iFNXApJjlWtDZdwedJFKpfGAMok(P_0);
					if (num < 0)
					{
						return;
					}
					for (int i = 0; i < fHYhNBaQNYWfQUnIKASBnOPzYNC.Count; i++)
					{
						if (fHYhNBaQNYWfQUnIKASBnOPzYNC[i].FKtcxmBappHTSHGoccIYREwbpfog.id == P_0)
						{
							AwAkOvTQBbpundzBkvKAJQrGudy(i);
							break;
						}
					}
				}

				void GqqVmTmEPnWlhtHJrWWOcCmltOt.xBnLqyjdZjJraDJKyHVWmGRDquG(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in xBnLqyjdZjJraDJKyHVWmGRDquG
					this.xBnLqyjdZjJraDJKyHVWmGRDquG(P_0);
				}

				public void xBnLqyjdZjJraDJKyHVWmGRDquG(TController P_0)
				{
					if (P_0 != null && P_0.type == VkxeQjDVSfumjFSZdzmQHhgPgAwE)
					{
						xBnLqyjdZjJraDJKyHVWmGRDquG(P_0.id);
					}
				}

				public void AwAkOvTQBbpundzBkvKAJQrGudy(int P_0)
				{
					if (P_0 >= 0 && P_0 < fHYhNBaQNYWfQUnIKASBnOPzYNC.Count)
					{
						fHYhNBaQNYWfQUnIKASBnOPzYNC.RemoveAt(P_0);
						CcuArxKiMBIHLfvQxbURmiupmIfb.RemoveAt(P_0);
					}
				}

				void GqqVmTmEPnWlhtHJrWWOcCmltOt.AwAkOvTQBbpundzBkvKAJQrGudy(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in AwAkOvTQBbpundzBkvKAJQrGudy
					this.AwAkOvTQBbpundzBkvKAJQrGudy(P_0);
				}

				public TController ZqzzcVLLrMBIUyLpDAZiOGBIopG(int P_0)
				{
					if (VkxeQjDVSfumjFSZdzmQHhgPgAwE == ControllerType.Keyboard || VkxeQjDVSfumjFSZdzmQHhgPgAwE == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					int num = iFNXApJjlWtDZdwedJFKpfGAMok(P_0);
					if (num < 0)
					{
						return null;
					}
					return fHYhNBaQNYWfQUnIKASBnOPzYNC[num].FKtcxmBappHTSHGoccIYREwbpfog;
				}

				public bool qUMsmxJoDabnMgpnPbuRnplJapZC(int P_0)
				{
					if (VkxeQjDVSfumjFSZdzmQHhgPgAwE == ControllerType.Keyboard || VkxeQjDVSfumjFSZdzmQHhgPgAwE == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return false;
					}
					for (int i = 0; i < fHYhNBaQNYWfQUnIKASBnOPzYNC.Count; i++)
					{
						if (fHYhNBaQNYWfQUnIKASBnOPzYNC[i].FKtcxmBappHTSHGoccIYREwbpfog.id == P_0)
						{
							return true;
						}
					}
					return false;
				}

				bool GqqVmTmEPnWlhtHJrWWOcCmltOt.qUMsmxJoDabnMgpnPbuRnplJapZC(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in qUMsmxJoDabnMgpnPbuRnplJapZC
					return this.qUMsmxJoDabnMgpnPbuRnplJapZC(P_0);
				}

				public bool qUMsmxJoDabnMgpnPbuRnplJapZC(TController P_0)
				{
					if (P_0 == null)
					{
						return false;
					}
					if (P_0.type != VkxeQjDVSfumjFSZdzmQHhgPgAwE)
					{
						return false;
					}
					return qUMsmxJoDabnMgpnPbuRnplJapZC(P_0.id);
				}

				public int iFNXApJjlWtDZdwedJFKpfGAMok(int P_0)
				{
					if (VkxeQjDVSfumjFSZdzmQHhgPgAwE == ControllerType.Keyboard || VkxeQjDVSfumjFSZdzmQHhgPgAwE == ControllerType.Mouse)
					{
						P_0 = 0;
					}
					if (P_0 < 0)
					{
						return -1;
					}
					for (int i = 0; i < fHYhNBaQNYWfQUnIKASBnOPzYNC.Count; i++)
					{
						if (fHYhNBaQNYWfQUnIKASBnOPzYNC[i].FKtcxmBappHTSHGoccIYREwbpfog.id == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				int GqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in iFNXApJjlWtDZdwedJFKpfGAMok
					return this.iFNXApJjlWtDZdwedJFKpfGAMok(P_0);
				}

				public int iFNXApJjlWtDZdwedJFKpfGAMok(TController P_0)
				{
					if (P_0 == null)
					{
						return -1;
					}
					if (P_0.type != VkxeQjDVSfumjFSZdzmQHhgPgAwE)
					{
						return -1;
					}
					return iFNXApJjlWtDZdwedJFKpfGAMok(P_0.id);
				}

				public int gdwrrUnehPrKtLJLcQDWjGmMxLw(string P_0)
				{
					if (P_0 == null || P_0 == string.Empty)
					{
						return -1;
					}
					for (int i = 0; i < fHYhNBaQNYWfQUnIKASBnOPzYNC.Count; i++)
					{
						if (fHYhNBaQNYWfQUnIKASBnOPzYNC[i].FKtcxmBappHTSHGoccIYREwbpfog.tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
						{
							return i;
						}
					}
					return -1;
				}

				int GqqVmTmEPnWlhtHJrWWOcCmltOt.gdwrrUnehPrKtLJLcQDWjGmMxLw(string P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in gdwrrUnehPrKtLJLcQDWjGmMxLw
					return this.gdwrrUnehPrKtLJLcQDWjGmMxLw(P_0);
				}

				public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
				{
					fHYhNBaQNYWfQUnIKASBnOPzYNC.Clear();
					CcuArxKiMBIHLfvQxbURmiupmIfb.Clear();
				}

				void GqqVmTmEPnWlhtHJrWWOcCmltOt.VcHhfbFqwxAmqhwBHKVJpDjlfufe()
				{
					//ILSpy generated this explicit interface implementation from .override directive in VcHhfbFqwxAmqhwBHKVJpDjlfufe
					this.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
				}

				private LEYwjXNPaJjLrFHUDPJUhWSYyxmR CoKzSjZwXEybMqAYmdIUmDJavwT(int P_0)
				{
					return CXouiQVNNifvOhfkUWFfiMKCNFx(P_0);
				}

				LEYwjXNPaJjLrFHUDPJUhWSYyxmR GqqVmTmEPnWlhtHJrWWOcCmltOt.CXouiQVNNifvOhfkUWFfiMKCNFx(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in CoKzSjZwXEybMqAYmdIUmDJavwT
					return this.CoKzSjZwXEybMqAYmdIUmDJavwT(P_0);
				}

				private LEYwjXNPaJjLrFHUDPJUhWSYyxmR CoKzSjZwXEybMqAYmdIUmDJavwT(Controller P_0)
				{
					if (P_0 as TController == null)
					{
						return null;
					}
					return CXouiQVNNifvOhfkUWFfiMKCNFx(P_0 as TController);
				}

				LEYwjXNPaJjLrFHUDPJUhWSYyxmR GqqVmTmEPnWlhtHJrWWOcCmltOt.CXouiQVNNifvOhfkUWFfiMKCNFx(Controller P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in CoKzSjZwXEybMqAYmdIUmDJavwT
					return this.CoKzSjZwXEybMqAYmdIUmDJavwT(P_0);
				}

				private void AyMtOjTCNznKnxgUtFqQhsgrzUBl(LEYwjXNPaJjLrFHUDPJUhWSYyxmR P_0)
				{
					WLmhwxVIRpQznYyjnRtiVlRHzYd((aLsWzHkpJEuncBoWNDXtzbFVdTda)P_0);
				}

				void GqqVmTmEPnWlhtHJrWWOcCmltOt.WLmhwxVIRpQznYyjnRtiVlRHzYd(LEYwjXNPaJjLrFHUDPJUhWSYyxmR P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in AyMtOjTCNznKnxgUtFqQhsgrzUBl
					this.AyMtOjTCNznKnxgUtFqQhsgrzUBl(P_0);
				}

				private void lvpHzMTPrLNflfVfyjBWWRnddq(Controller P_0)
				{
					xBnLqyjdZjJraDJKyHVWmGRDquG(P_0 as TController);
				}

				void GqqVmTmEPnWlhtHJrWWOcCmltOt.xBnLqyjdZjJraDJKyHVWmGRDquG(Controller P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in lvpHzMTPrLNflfVfyjBWWRnddq
					this.lvpHzMTPrLNflfVfyjBWWRnddq(P_0);
				}

				private Controller uhlNmQVAxwtzYJZogRLmyGEEOKS(int P_0)
				{
					return ZqzzcVLLrMBIUyLpDAZiOGBIopG(P_0);
				}

				Controller GqqVmTmEPnWlhtHJrWWOcCmltOt.ZqzzcVLLrMBIUyLpDAZiOGBIopG(int P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in uhlNmQVAxwtzYJZogRLmyGEEOKS
					return this.uhlNmQVAxwtzYJZogRLmyGEEOKS(P_0);
				}

				private bool GCSCGeGRLTUyUksWEwvwsOPEUF(Controller P_0)
				{
					return qUMsmxJoDabnMgpnPbuRnplJapZC(P_0 as TController);
				}

				bool GqqVmTmEPnWlhtHJrWWOcCmltOt.qUMsmxJoDabnMgpnPbuRnplJapZC(Controller P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in GCSCGeGRLTUyUksWEwvwsOPEUF
					return this.GCSCGeGRLTUyUksWEwvwsOPEUF(P_0);
				}

				private int ilPJRUsGWpBhBLaKRBpsAAfSuKt(Controller P_0)
				{
					return iFNXApJjlWtDZdwedJFKpfGAMok(P_0 as TController);
				}

				int GqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(Controller P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in ilPJRUsGWpBhBLaKRBpsAAfSuKt
					return this.ilPJRUsGWpBhBLaKRBpsAAfSuKt(P_0);
				}

				private Controller tWPSjaYbZbBvubdTBWRNZrqObOJ(string P_0)
				{
					int num = gdwrrUnehPrKtLJLcQDWjGmMxLw(P_0);
					if (num < 0)
					{
						return null;
					}
					return fHYhNBaQNYWfQUnIKASBnOPzYNC[num].FKtcxmBappHTSHGoccIYREwbpfog;
				}

				Controller GqqVmTmEPnWlhtHJrWWOcCmltOt.nzOJKNVhwbNfErkEKCbnggvNzLZ(string P_0)
				{
					//ILSpy generated this explicit interface implementation from .override directive in tWPSjaYbZbBvubdTBWRNZrqObOJ
					return this.tWPSjaYbZbBvubdTBWRNZrqObOJ(P_0);
				}
			}

			internal class ESxitgnzJOKaHGGExYoKxkgWcPJJ
			{
				public readonly int eBADKEfFkgpzzTponatpcvPGNRUi;

				private ControllerType[] QirxUbfWlSsKlufEQMYvaMILhRq;

				private GqqVmTmEPnWlhtHJrWWOcCmltOt[] lfgHStUdQhmOGyivkzSVtBfBVaO;

				public GqqVmTmEPnWlhtHJrWWOcCmltOt rlRqYWeSrZSmdwKmEJMJPHTplWA(int P_0)
				{
					return lfgHStUdQhmOGyivkzSVtBfBVaO[P_0];
				}

				public ControllerType PJmyOahSkMBgfbHBeqRHjtHEWWb(int P_0)
				{
					return QirxUbfWlSsKlufEQMYvaMILhRq[P_0];
				}

				public ESxitgnzJOKaHGGExYoKxkgWcPJJ(int length)
				{
					eBADKEfFkgpzzTponatpcvPGNRUi = MathTools.Max(0, length);
					QirxUbfWlSsKlufEQMYvaMILhRq = new ControllerType[length];
					lfgHStUdQhmOGyivkzSVtBfBVaO = new GqqVmTmEPnWlhtHJrWWOcCmltOt[length];
				}

				public GqqVmTmEPnWlhtHJrWWOcCmltOt voXpBfThsCGWCMHojROqTcsZaAs(ControllerType P_0)
				{
					for (int i = 0; i < eBADKEfFkgpzzTponatpcvPGNRUi; i++)
					{
						if (P_0 == QirxUbfWlSsKlufEQMYvaMILhRq[i])
						{
							return lfgHStUdQhmOGyivkzSVtBfBVaO[i];
						}
					}
					throw new Exception("Value is not in the set.");
				}

				public void KFygjWdigylybvJFqAHIIdLZxfwa(int P_0, ControllerType P_1, GqqVmTmEPnWlhtHJrWWOcCmltOt P_2)
				{
					QirxUbfWlSsKlufEQMYvaMILhRq[P_0] = P_1;
					lfgHStUdQhmOGyivkzSVtBfBVaO[P_0] = P_2;
				}
			}

			private class BkWacRVcSqktKoxKKLjyunbsXrx
			{
				public class SIJZlQxwimktYHKcVVfKUnkmxyn
				{
					public int sdUcfBHJKZrpwNGKHzcwwlwLVTI;

					public global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<JoystickMap> VhZfrlASXHRPSRCbfcxNqUcSXtJ;

					public double PlfBhVKChjwFIAQSRxnPWLyCaBq;

					public SIJZlQxwimktYHKcVVfKUnkmxyn(int joystickId, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<JoystickMap> mapSet, double lastConnectedTime)
					{
						sdUcfBHJKZrpwNGKHzcwwlwLVTI = joystickId;
						VhZfrlASXHRPSRCbfcxNqUcSXtJ = mapSet;
						PlfBhVKChjwFIAQSRxnPWLyCaBq = lastConnectedTime;
					}
				}

				private readonly List<SIJZlQxwimktYHKcVVfKUnkmxyn> DBNLceLJjOSJnIoFWvBsUwReOrv;

				private readonly Player UeMLjuGiSFGfRltYoIYxjRdaYAm;

				public BkWacRVcSqktKoxKKLjyunbsXrx(Player player)
				{
					UeMLjuGiSFGfRltYoIYxjRdaYAm = player;
					DBNLceLJjOSJnIoFWvBsUwReOrv = new List<SIJZlQxwimktYHKcVVfKUnkmxyn>();
				}

				public void TXPDIkiKZyOgtxZjjNIOUuEOnmW(Joystick P_0, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<JoystickMap> P_1)
				{
					for (int i = 0; i < DBNLceLJjOSJnIoFWvBsUwReOrv.Count; i++)
					{
						SIJZlQxwimktYHKcVVfKUnkmxyn sIJZlQxwimktYHKcVVfKUnkmxyn = DBNLceLJjOSJnIoFWvBsUwReOrv[i];
						if (sIJZlQxwimktYHKcVVfKUnkmxyn.sdUcfBHJKZrpwNGKHzcwwlwLVTI == P_0.id)
						{
							sIJZlQxwimktYHKcVVfKUnkmxyn.VhZfrlASXHRPSRCbfcxNqUcSXtJ = P_1;
							sIJZlQxwimktYHKcVVfKUnkmxyn.PlfBhVKChjwFIAQSRxnPWLyCaBq = ReInput.realTime;
							return;
						}
					}
					SIJZlQxwimktYHKcVVfKUnkmxyn item = new SIJZlQxwimktYHKcVVfKUnkmxyn(P_0.id, P_1, ReInput.realTime);
					DBNLceLJjOSJnIoFWvBsUwReOrv.Add(item);
				}

				public void TXPDIkiKZyOgtxZjjNIOUuEOnmW(CiBOuMFOJpyCeTavwEkrJOcXHWu<Joystick, JoystickMap>.aLsWzHkpJEuncBoWNDXtzbFVdTda P_0)
				{
					TXPDIkiKZyOgtxZjjNIOUuEOnmW(P_0.FKtcxmBappHTSHGoccIYREwbpfog, P_0.VhZfrlASXHRPSRCbfcxNqUcSXtJ);
				}

				public void FxzCwAtYmxSdgMTfOdnyfaPfUEa()
				{
					for (int i = 0; i < DBNLceLJjOSJnIoFWvBsUwReOrv.Count; i++)
					{
						if (!UeMLjuGiSFGfRltYoIYxjRdaYAm.controllers.ContainsController(ControllerType.Joystick, DBNLceLJjOSJnIoFWvBsUwReOrv[i].sdUcfBHJKZrpwNGKHzcwwlwLVTI))
						{
							DBNLceLJjOSJnIoFWvBsUwReOrv[i].VhZfrlASXHRPSRCbfcxNqUcSXtJ = null;
						}
					}
				}

				public SIJZlQxwimktYHKcVVfKUnkmxyn gvqEbQFhpyMkfjXoFHFMRwMMJtS(int P_0)
				{
					int num = iFNXApJjlWtDZdwedJFKpfGAMok(P_0);
					if (num < 0)
					{
						return null;
					}
					return DBNLceLJjOSJnIoFWvBsUwReOrv[num];
				}

				public bool qUMsmxJoDabnMgpnPbuRnplJapZC(int P_0)
				{
					for (int i = 0; i < DBNLceLJjOSJnIoFWvBsUwReOrv.Count; i++)
					{
						if (DBNLceLJjOSJnIoFWvBsUwReOrv[i].sdUcfBHJKZrpwNGKHzcwwlwLVTI == P_0)
						{
							return true;
						}
					}
					return false;
				}

				public int iFNXApJjlWtDZdwedJFKpfGAMok(int P_0)
				{
					for (int i = 0; i < DBNLceLJjOSJnIoFWvBsUwReOrv.Count; i++)
					{
						if (DBNLceLJjOSJnIoFWvBsUwReOrv[i].sdUcfBHJKZrpwNGKHzcwwlwLVTI == P_0)
						{
							return i;
						}
					}
					return -1;
				}

				public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
				{
					DBNLceLJjOSJnIoFWvBsUwReOrv.Clear();
				}
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Browsable(false)]
			public sealed class MapHelper : CodeHelper
			{
				private sealed class dDDyylvQQWScOGizGPGPZFgdDiO : IDisposable, IEnumerator, IEnumerable, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private ControllerMap WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int tYzFcoTGHgqADNpPBKSawQUdQVO;

					public int etsZCfMKvFTOzTkAyfeDfwstfaO;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt sBMCpmuVQycVBEeFQhDgeXyGogqf;

					public int bicTZbTpLoFlUAIFIbDZeMkJicuX;

					public int SvchdANTlYErxnYOncawFqTNaJW;

					public SaFIhRkKoaFsJonuErfrovvvDai sjjSVcORsQMkhBNHKAfyNDXRWLg;

					public int ToFaLDIVauUOqnHYdiqEpAXfMbG;

					public int DigaoQfaKBPgmsehCKvHGaqlYwh;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						dDDyylvQQWScOGizGPGPZFgdDiO dDDyylvQQWScOGizGPGPZFgdDiO2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							dDDyylvQQWScOGizGPGPZFgdDiO2 = this;
						}
						else
						{
							dDDyylvQQWScOGizGPGPZFgdDiO2 = new dDDyylvQQWScOGizGPGPZFgdDiO(0);
							dDDyylvQQWScOGizGPGPZFgdDiO2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return dDDyylvQQWScOGizGPGPZFgdDiO2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 0:
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
							{
								ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
								break;
							}
							tYzFcoTGHgqADNpPBKSawQUdQVO = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
							etsZCfMKvFTOzTkAyfeDfwstfaO = 0;
							goto IL_0154;
						case 1:
							{
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								DigaoQfaKBPgmsehCKvHGaqlYwh++;
								goto IL_0119;
							}
							IL_0119:
							if (DigaoQfaKBPgmsehCKvHGaqlYwh < ToFaLDIVauUOqnHYdiqEpAXfMbG)
							{
								WCNlIsEdYuVTqbNYvICUPcTebLU = sjjSVcORsQMkhBNHKAfyNDXRWLg[DigaoQfaKBPgmsehCKvHGaqlYwh];
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								return true;
							}
							SvchdANTlYErxnYOncawFqTNaJW++;
							goto IL_0135;
							IL_0135:
							if (SvchdANTlYErxnYOncawFqTNaJW < bicTZbTpLoFlUAIFIbDZeMkJicuX)
							{
								sjjSVcORsQMkhBNHKAfyNDXRWLg = sBMCpmuVQycVBEeFQhDgeXyGogqf[SvchdANTlYErxnYOncawFqTNaJW].mapSet;
								ToFaLDIVauUOqnHYdiqEpAXfMbG = sjjSVcORsQMkhBNHKAfyNDXRWLg.Count;
								DigaoQfaKBPgmsehCKvHGaqlYwh = 0;
								goto IL_0119;
							}
							etsZCfMKvFTOzTkAyfeDfwstfaO++;
							goto IL_0154;
							IL_0154:
							if (etsZCfMKvFTOzTkAyfeDfwstfaO >= tYzFcoTGHgqADNpPBKSawQUdQVO)
							{
								break;
							}
							sBMCpmuVQycVBEeFQhDgeXyGogqf = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(etsZCfMKvFTOzTkAyfeDfwstfaO);
							bicTZbTpLoFlUAIFIbDZeMkJicuX = sBMCpmuVQycVBEeFQhDgeXyGogqf.Count;
							SvchdANTlYErxnYOncawFqTNaJW = 0;
							goto IL_0135;
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
					public dDDyylvQQWScOGizGPGPZFgdDiO(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class EpmsBefYkGxMsyxkxWyqxSexvzC<T> : IDisposable, IEnumerator, IEnumerable, IEnumerable<T>, IEnumerator<T> where T : ControllerMap
				{
					private T WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ControllerType nhJnOmjPsjJofPlPEKnkAzdMizE;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt wQaysoStVbojPVrkXcXBYeDrESk;

					public int EBiIvWdeZhKdUJSBlMafOJamGwKv;

					public int ILQeokxXAKQKNsriNLROhiEXGKu;

					public SaFIhRkKoaFsJonuErfrovvvDai QxUDtQKvSgAQsbHDbIkHzXPaYNHR;

					public int zPTFcjMrrKAmkEmnLqHeJoXZeitx;

					public int JPKRSZNKqokURQgXBQEhbfSYcfE;

					public int AJmDgVjsdErHcFlFqyNaEQnZZHr;

					public int JgcLMfjEAtyWkbmDhkSCEnHLFOJc;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt jqvNLMYHbomjKmoBYDCcMujlaxe;

					public int ftHSHrcBPHwEFltSoMAxCdFENdt;

					public int HWDECWrWjRvIyteJKDuvwaQsVVw;

					public SaFIhRkKoaFsJonuErfrovvvDai YSceztFYeDpYJqAfbGCdqCEeAHl;

					public int sZVjEQYpmPVpolbHlAGkBfMUuaA;

					public int MzynclDXEtKBZWNECjghDNGTjdvj;

					public T tjXWfJBHpfWozsnLTeJbijSiTgq;

					T IEnumerator<T>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<T> IEnumerable<T>.GetEnumerator()
					{
						EpmsBefYkGxMsyxkxWyqxSexvzC<T> epmsBefYkGxMsyxkxWyqxSexvzC;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							epmsBefYkGxMsyxkxWyqxSexvzC = this;
						}
						else
						{
							epmsBefYkGxMsyxkxWyqxSexvzC = new EpmsBefYkGxMsyxkxWyqxSexvzC<T>(0);
							epmsBefYkGxMsyxkxWyqxSexvzC.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return epmsBefYkGxMsyxkxWyqxSexvzC;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<T>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 0:
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
							{
								ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
								break;
							}
							if (XqmnYoifzflCsKxcFaHDewlkEkh.ctIasoEjDOEPmNnnXJueFDtghIqF<T>(out nhJnOmjPsjJofPlPEKnkAzdMizE))
							{
								wQaysoStVbojPVrkXcXBYeDrESk = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(nhJnOmjPsjJofPlPEKnkAzdMizE);
								EBiIvWdeZhKdUJSBlMafOJamGwKv = wQaysoStVbojPVrkXcXBYeDrESk.Count;
								ILQeokxXAKQKNsriNLROhiEXGKu = 0;
								goto IL_0127;
							}
							AJmDgVjsdErHcFlFqyNaEQnZZHr = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
							JgcLMfjEAtyWkbmDhkSCEnHLFOJc = 0;
							goto IL_026b;
						case 1:
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							JPKRSZNKqokURQgXBQEhbfSYcfE++;
							goto IL_010b;
						case 2:
							{
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								goto IL_0222;
							}
							IL_024c:
							if (HWDECWrWjRvIyteJKDuvwaQsVVw < ftHSHrcBPHwEFltSoMAxCdFENdt)
							{
								YSceztFYeDpYJqAfbGCdqCEeAHl = jqvNLMYHbomjKmoBYDCcMujlaxe[HWDECWrWjRvIyteJKDuvwaQsVVw].mapSet;
								sZVjEQYpmPVpolbHlAGkBfMUuaA = YSceztFYeDpYJqAfbGCdqCEeAHl.Count;
								MzynclDXEtKBZWNECjghDNGTjdvj = 0;
								goto IL_0230;
							}
							JgcLMfjEAtyWkbmDhkSCEnHLFOJc++;
							goto IL_026b;
							IL_0230:
							if (MzynclDXEtKBZWNECjghDNGTjdvj < sZVjEQYpmPVpolbHlAGkBfMUuaA)
							{
								tjXWfJBHpfWozsnLTeJbijSiTgq = YSceztFYeDpYJqAfbGCdqCEeAHl[MzynclDXEtKBZWNECjghDNGTjdvj] as T;
								if (tjXWfJBHpfWozsnLTeJbijSiTgq != null)
								{
									WCNlIsEdYuVTqbNYvICUPcTebLU = tjXWfJBHpfWozsnLTeJbijSiTgq;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								goto IL_0222;
							}
							HWDECWrWjRvIyteJKDuvwaQsVVw++;
							goto IL_024c;
							IL_026b:
							if (JgcLMfjEAtyWkbmDhkSCEnHLFOJc >= AJmDgVjsdErHcFlFqyNaEQnZZHr)
							{
								break;
							}
							jqvNLMYHbomjKmoBYDCcMujlaxe = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(JgcLMfjEAtyWkbmDhkSCEnHLFOJc);
							ftHSHrcBPHwEFltSoMAxCdFENdt = jqvNLMYHbomjKmoBYDCcMujlaxe.Count;
							HWDECWrWjRvIyteJKDuvwaQsVVw = 0;
							goto IL_024c;
							IL_0127:
							if (ILQeokxXAKQKNsriNLROhiEXGKu < EBiIvWdeZhKdUJSBlMafOJamGwKv)
							{
								QxUDtQKvSgAQsbHDbIkHzXPaYNHR = wQaysoStVbojPVrkXcXBYeDrESk[ILQeokxXAKQKNsriNLROhiEXGKu].mapSet;
								zPTFcjMrrKAmkEmnLqHeJoXZeitx = QxUDtQKvSgAQsbHDbIkHzXPaYNHR.Count;
								JPKRSZNKqokURQgXBQEhbfSYcfE = 0;
								goto IL_010b;
							}
							break;
							IL_0222:
							MzynclDXEtKBZWNECjghDNGTjdvj++;
							goto IL_0230;
							IL_010b:
							if (JPKRSZNKqokURQgXBQEhbfSYcfE < zPTFcjMrrKAmkEmnLqHeJoXZeitx)
							{
								WCNlIsEdYuVTqbNYvICUPcTebLU = (T)QxUDtQKvSgAQsbHDbIkHzXPaYNHR[JPKRSZNKqokURQgXBQEhbfSYcfE];
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								return true;
							}
							ILQeokxXAKQKNsriNLROhiEXGKu++;
							goto IL_0127;
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
					public EpmsBefYkGxMsyxkxWyqxSexvzC(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class vaqXRiPfXgugvDbjBeBEBBvXoVt : IDisposable, IEnumerator, IEnumerable, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private ControllerMap WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ControllerType guEuWFKSUNviYZgARiewhDnEceT;

					public ControllerType dCrCLiKKKlaSSJCUCnULxHTQLiPz;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt FJgAAiAZVdBEjVSOvNHifXFfzoZu;

					public int fZMkOacUAmGckQWkfUnxbfGFano;

					public int cBqQbNqoGTajbKEDBZCcNYbnTAB;

					public SaFIhRkKoaFsJonuErfrovvvDai BXWltsVymWZjqVJkavBYJoLWcUt;

					public int SqAwExZJLBzyEEFFJylLaVCzGsX;

					public int YAzyYQHHAdSKQDSmenlXeJdhKSE;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						vaqXRiPfXgugvDbjBeBEBBvXoVt vaqXRiPfXgugvDbjBeBEBBvXoVt2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							vaqXRiPfXgugvDbjBeBEBBvXoVt2 = this;
						}
						else
						{
							vaqXRiPfXgugvDbjBeBEBBvXoVt2 = new vaqXRiPfXgugvDbjBeBEBBvXoVt(0);
							vaqXRiPfXgugvDbjBeBEBBvXoVt2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						vaqXRiPfXgugvDbjBeBEBBvXoVt2.guEuWFKSUNviYZgARiewhDnEceT = dCrCLiKKKlaSSJCUCnULxHTQLiPz;
						return vaqXRiPfXgugvDbjBeBEBBvXoVt2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 0:
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
							{
								ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
								break;
							}
							FJgAAiAZVdBEjVSOvNHifXFfzoZu = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(guEuWFKSUNviYZgARiewhDnEceT);
							fZMkOacUAmGckQWkfUnxbfGFano = FJgAAiAZVdBEjVSOvNHifXFfzoZu.Count;
							cBqQbNqoGTajbKEDBZCcNYbnTAB = 0;
							goto IL_010e;
						case 1:
							{
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								YAzyYQHHAdSKQDSmenlXeJdhKSE++;
								goto IL_00f2;
							}
							IL_010e:
							if (cBqQbNqoGTajbKEDBZCcNYbnTAB >= fZMkOacUAmGckQWkfUnxbfGFano)
							{
								break;
							}
							BXWltsVymWZjqVJkavBYJoLWcUt = FJgAAiAZVdBEjVSOvNHifXFfzoZu[cBqQbNqoGTajbKEDBZCcNYbnTAB].mapSet;
							SqAwExZJLBzyEEFFJylLaVCzGsX = BXWltsVymWZjqVJkavBYJoLWcUt.Count;
							YAzyYQHHAdSKQDSmenlXeJdhKSE = 0;
							goto IL_00f2;
							IL_00f2:
							if (YAzyYQHHAdSKQDSmenlXeJdhKSE < SqAwExZJLBzyEEFFJylLaVCzGsX)
							{
								WCNlIsEdYuVTqbNYvICUPcTebLU = BXWltsVymWZjqVJkavBYJoLWcUt[YAzyYQHHAdSKQDSmenlXeJdhKSE];
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								return true;
							}
							cBqQbNqoGTajbKEDBZCcNYbnTAB++;
							goto IL_010e;
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
					public vaqXRiPfXgugvDbjBeBEBBvXoVt(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class awCHfNhIWzAMhalgTrGtneiDqiZ : IDisposable, IEnumerator, IEnumerable, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private ControllerMap WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int LZYmkpJdDrlFtkHjqyUubFKNUCs;

					public int kHPEEBGwlYJndavghTRnPpnmDafU;

					public int aKWWEQFxaAOCXhJXJHJVBkzGiMK;

					public int UytxGlKrjtFBGSDaPebGFAiOiRyl;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt dLVWcKZAqVCJRDCvwMpuLUTnEig;

					public int uexyqpooKMEMinGpxNqnDMFmUDw;

					public int SHtnaLmAqQloSoqApDuufaPcYTho;

					public SaFIhRkKoaFsJonuErfrovvvDai FzafuVKvYqbgbjgyGCgnCEmiQBiu;

					public int FkygLAlyKXeUdOcAgfmCnYjWqzz;

					public int RqzJCdjHQCSkcLHJdoTAsauxWJN;

					public ControllerMap LknSzsOvZCIKZnyuIMAJwoiITcG;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						awCHfNhIWzAMhalgTrGtneiDqiZ awCHfNhIWzAMhalgTrGtneiDqiZ2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							awCHfNhIWzAMhalgTrGtneiDqiZ2 = this;
						}
						else
						{
							awCHfNhIWzAMhalgTrGtneiDqiZ2 = new awCHfNhIWzAMhalgTrGtneiDqiZ(0);
							awCHfNhIWzAMhalgTrGtneiDqiZ2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						awCHfNhIWzAMhalgTrGtneiDqiZ2.LZYmkpJdDrlFtkHjqyUubFKNUCs = kHPEEBGwlYJndavghTRnPpnmDafU;
						return awCHfNhIWzAMhalgTrGtneiDqiZ2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 0:
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
							{
								ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
								break;
							}
							aKWWEQFxaAOCXhJXJHJVBkzGiMK = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
							UytxGlKrjtFBGSDaPebGFAiOiRyl = 0;
							goto IL_0173;
						case 1:
							{
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								goto IL_012a;
							}
							IL_0154:
							if (SHtnaLmAqQloSoqApDuufaPcYTho < uexyqpooKMEMinGpxNqnDMFmUDw)
							{
								FzafuVKvYqbgbjgyGCgnCEmiQBiu = dLVWcKZAqVCJRDCvwMpuLUTnEig[SHtnaLmAqQloSoqApDuufaPcYTho].mapSet;
								FkygLAlyKXeUdOcAgfmCnYjWqzz = FzafuVKvYqbgbjgyGCgnCEmiQBiu.Count;
								RqzJCdjHQCSkcLHJdoTAsauxWJN = 0;
								goto IL_0138;
							}
							UytxGlKrjtFBGSDaPebGFAiOiRyl++;
							goto IL_0173;
							IL_0138:
							if (RqzJCdjHQCSkcLHJdoTAsauxWJN < FkygLAlyKXeUdOcAgfmCnYjWqzz)
							{
								LknSzsOvZCIKZnyuIMAJwoiITcG = FzafuVKvYqbgbjgyGCgnCEmiQBiu[RqzJCdjHQCSkcLHJdoTAsauxWJN];
								if (LknSzsOvZCIKZnyuIMAJwoiITcG.categoryId == LZYmkpJdDrlFtkHjqyUubFKNUCs)
								{
									WCNlIsEdYuVTqbNYvICUPcTebLU = LknSzsOvZCIKZnyuIMAJwoiITcG;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									return true;
								}
								goto IL_012a;
							}
							SHtnaLmAqQloSoqApDuufaPcYTho++;
							goto IL_0154;
							IL_0173:
							if (UytxGlKrjtFBGSDaPebGFAiOiRyl >= aKWWEQFxaAOCXhJXJHJVBkzGiMK)
							{
								break;
							}
							dLVWcKZAqVCJRDCvwMpuLUTnEig = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(UytxGlKrjtFBGSDaPebGFAiOiRyl);
							uexyqpooKMEMinGpxNqnDMFmUDw = dLVWcKZAqVCJRDCvwMpuLUTnEig.Count;
							SHtnaLmAqQloSoqApDuufaPcYTho = 0;
							goto IL_0154;
							IL_012a:
							RqzJCdjHQCSkcLHJdoTAsauxWJN++;
							goto IL_0138;
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
					public awCHfNhIWzAMhalgTrGtneiDqiZ(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class ffyrMHEovQdezjEFSLCFjcyxZRA<T> : IDisposable, IEnumerator, IEnumerable, IEnumerable<T>, IEnumerator<T> where T : ControllerMap
				{
					private T WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int LZYmkpJdDrlFtkHjqyUubFKNUCs;

					public int kHPEEBGwlYJndavghTRnPpnmDafU;

					public ControllerType gsKcZXjqTaVMbQqflPhCicYfuMf;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt BDLPONgjATrJvygoHlnBnTAtnhU;

					public int FFZdzAgYDDszeiFcEBguAONfoLZv;

					public int KSAMgQDokiVisLovbCfMcRsUmPHO;

					public SaFIhRkKoaFsJonuErfrovvvDai cJsTgspMbnacpFRcBPrelLpWkYex;

					public int QPjwClshlDiNWlQpoCLUKaBhmIi;

					public int FTFjrVBdLTcAdJZUQbXdanPPPtir;

					public ControllerMap HwloSRJPHnTQlYhuIcborOEeWNN;

					public int CQgBZCzxiKjOIeDGXNmnmbIdMiwf;

					public int IfUWFypmMlTUnPlLbcdFzBOGcZGb;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt KUjcvwzNUpsTfUYNMBgOLISdysz;

					public int xEGXBjbDdrWVmliLJxjhpYSNaBk;

					public int IRZhYtdwkBKYJVdHfQELACmfZcx;

					public SaFIhRkKoaFsJonuErfrovvvDai wIcbAkDCeMHQyQDefCrCCiSEbcuw;

					public int ssmdUhJijxdVmccBHDVxOGwCjgr;

					public int orQofUKfNAFxdHQgxYbcjycWHaOU;

					public T PttJkxprTVRNZhyiWFhfKdMkFTnH;

					T IEnumerator<T>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<T> IEnumerable<T>.GetEnumerator()
					{
						ffyrMHEovQdezjEFSLCFjcyxZRA<T> ffyrMHEovQdezjEFSLCFjcyxZRA2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							ffyrMHEovQdezjEFSLCFjcyxZRA2 = this;
						}
						else
						{
							ffyrMHEovQdezjEFSLCFjcyxZRA2 = new ffyrMHEovQdezjEFSLCFjcyxZRA<T>(0);
							ffyrMHEovQdezjEFSLCFjcyxZRA2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						ffyrMHEovQdezjEFSLCFjcyxZRA2.LZYmkpJdDrlFtkHjqyUubFKNUCs = kHPEEBGwlYJndavghTRnPpnmDafU;
						return ffyrMHEovQdezjEFSLCFjcyxZRA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<T>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 0:
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
							{
								ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
								break;
							}
							if (XqmnYoifzflCsKxcFaHDewlkEkh.ctIasoEjDOEPmNnnXJueFDtghIqF<T>(out gsKcZXjqTaVMbQqflPhCicYfuMf))
							{
								BDLPONgjATrJvygoHlnBnTAtnhU = GxphHAMqMhNBLjnlhXuBQmXaALiE.HKsQgrgAzvFmgvjbLwphvDQOADyD<T>();
								FFZdzAgYDDszeiFcEBguAONfoLZv = BDLPONgjATrJvygoHlnBnTAtnhU.Count;
								KSAMgQDokiVisLovbCfMcRsUmPHO = 0;
								goto IL_0136;
							}
							CQgBZCzxiKjOIeDGXNmnmbIdMiwf = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
							IfUWFypmMlTUnPlLbcdFzBOGcZGb = 0;
							goto IL_0293;
						case 1:
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							goto IL_010c;
						case 2:
							{
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								goto IL_024a;
							}
							IL_0274:
							if (IRZhYtdwkBKYJVdHfQELACmfZcx < xEGXBjbDdrWVmliLJxjhpYSNaBk)
							{
								wIcbAkDCeMHQyQDefCrCCiSEbcuw = KUjcvwzNUpsTfUYNMBgOLISdysz[IRZhYtdwkBKYJVdHfQELACmfZcx].mapSet;
								ssmdUhJijxdVmccBHDVxOGwCjgr = wIcbAkDCeMHQyQDefCrCCiSEbcuw.Count;
								orQofUKfNAFxdHQgxYbcjycWHaOU = 0;
								goto IL_0258;
							}
							IfUWFypmMlTUnPlLbcdFzBOGcZGb++;
							goto IL_0293;
							IL_0258:
							if (orQofUKfNAFxdHQgxYbcjycWHaOU < ssmdUhJijxdVmccBHDVxOGwCjgr)
							{
								PttJkxprTVRNZhyiWFhfKdMkFTnH = wIcbAkDCeMHQyQDefCrCCiSEbcuw[orQofUKfNAFxdHQgxYbcjycWHaOU] as T;
								if (PttJkxprTVRNZhyiWFhfKdMkFTnH != null && PttJkxprTVRNZhyiWFhfKdMkFTnH.categoryId == LZYmkpJdDrlFtkHjqyUubFKNUCs)
								{
									WCNlIsEdYuVTqbNYvICUPcTebLU = PttJkxprTVRNZhyiWFhfKdMkFTnH;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								goto IL_024a;
							}
							IRZhYtdwkBKYJVdHfQELACmfZcx++;
							goto IL_0274;
							IL_010c:
							FTFjrVBdLTcAdJZUQbXdanPPPtir++;
							goto IL_011a;
							IL_0136:
							if (KSAMgQDokiVisLovbCfMcRsUmPHO < FFZdzAgYDDszeiFcEBguAONfoLZv)
							{
								cJsTgspMbnacpFRcBPrelLpWkYex = BDLPONgjATrJvygoHlnBnTAtnhU[KSAMgQDokiVisLovbCfMcRsUmPHO].mapSet;
								QPjwClshlDiNWlQpoCLUKaBhmIi = cJsTgspMbnacpFRcBPrelLpWkYex.Count;
								FTFjrVBdLTcAdJZUQbXdanPPPtir = 0;
								goto IL_011a;
							}
							break;
							IL_0293:
							if (IfUWFypmMlTUnPlLbcdFzBOGcZGb >= CQgBZCzxiKjOIeDGXNmnmbIdMiwf)
							{
								break;
							}
							KUjcvwzNUpsTfUYNMBgOLISdysz = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(IfUWFypmMlTUnPlLbcdFzBOGcZGb);
							xEGXBjbDdrWVmliLJxjhpYSNaBk = KUjcvwzNUpsTfUYNMBgOLISdysz.Count;
							IRZhYtdwkBKYJVdHfQELACmfZcx = 0;
							goto IL_0274;
							IL_011a:
							if (FTFjrVBdLTcAdJZUQbXdanPPPtir < QPjwClshlDiNWlQpoCLUKaBhmIi)
							{
								HwloSRJPHnTQlYhuIcborOEeWNN = cJsTgspMbnacpFRcBPrelLpWkYex[FTFjrVBdLTcAdJZUQbXdanPPPtir];
								if (HwloSRJPHnTQlYhuIcborOEeWNN.categoryId == LZYmkpJdDrlFtkHjqyUubFKNUCs)
								{
									WCNlIsEdYuVTqbNYvICUPcTebLU = (T)HwloSRJPHnTQlYhuIcborOEeWNN;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									return true;
								}
								goto IL_010c;
							}
							KSAMgQDokiVisLovbCfMcRsUmPHO++;
							goto IL_0136;
							IL_024a:
							orQofUKfNAFxdHQgxYbcjycWHaOU++;
							goto IL_0258;
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
					public ffyrMHEovQdezjEFSLCFjcyxZRA(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class QztIjuDSOUegBZEMHGDBqhpUjX : IDisposable, IEnumerator, IEnumerable, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private ControllerMap WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int LZYmkpJdDrlFtkHjqyUubFKNUCs;

					public int kHPEEBGwlYJndavghTRnPpnmDafU;

					public ControllerType guEuWFKSUNviYZgARiewhDnEceT;

					public ControllerType dCrCLiKKKlaSSJCUCnULxHTQLiPz;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt ZmkGyfXEffVONeYHSRbWInMLivJ;

					public int dEtanXGxuGRnCgbMVHOCzlvzHrUr;

					public int sLkbEhPzNkTotkolrNDtrxFGPzj;

					public SaFIhRkKoaFsJonuErfrovvvDai SvXEKWepaqhYipEDYIIYpueBqCIv;

					public int MjKeoEikNRvOSDpzjdgAMSEHXClQ;

					public int YWOjCTRJVxkTCHAddmivbfIJuFr;

					public ControllerMap TrmIQKabTFMvtuPJwnLeOdfQAGc;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						QztIjuDSOUegBZEMHGDBqhpUjX qztIjuDSOUegBZEMHGDBqhpUjX;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							qztIjuDSOUegBZEMHGDBqhpUjX = this;
						}
						else
						{
							qztIjuDSOUegBZEMHGDBqhpUjX = new QztIjuDSOUegBZEMHGDBqhpUjX(0);
							qztIjuDSOUegBZEMHGDBqhpUjX.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						qztIjuDSOUegBZEMHGDBqhpUjX.LZYmkpJdDrlFtkHjqyUubFKNUCs = kHPEEBGwlYJndavghTRnPpnmDafU;
						qztIjuDSOUegBZEMHGDBqhpUjX.guEuWFKSUNviYZgARiewhDnEceT = dCrCLiKKKlaSSJCUCnULxHTQLiPz;
						return qztIjuDSOUegBZEMHGDBqhpUjX;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 0:
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
							{
								ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
								break;
							}
							ZmkGyfXEffVONeYHSRbWInMLivJ = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(guEuWFKSUNviYZgARiewhDnEceT);
							dEtanXGxuGRnCgbMVHOCzlvzHrUr = ZmkGyfXEffVONeYHSRbWInMLivJ.Count;
							sLkbEhPzNkTotkolrNDtrxFGPzj = 0;
							goto IL_012d;
						case 1:
							{
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								goto IL_0103;
							}
							IL_0103:
							YWOjCTRJVxkTCHAddmivbfIJuFr++;
							goto IL_0111;
							IL_0111:
							if (YWOjCTRJVxkTCHAddmivbfIJuFr < MjKeoEikNRvOSDpzjdgAMSEHXClQ)
							{
								TrmIQKabTFMvtuPJwnLeOdfQAGc = SvXEKWepaqhYipEDYIIYpueBqCIv[YWOjCTRJVxkTCHAddmivbfIJuFr];
								if (TrmIQKabTFMvtuPJwnLeOdfQAGc.categoryId == LZYmkpJdDrlFtkHjqyUubFKNUCs)
								{
									WCNlIsEdYuVTqbNYvICUPcTebLU = TrmIQKabTFMvtuPJwnLeOdfQAGc;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									return true;
								}
								goto IL_0103;
							}
							sLkbEhPzNkTotkolrNDtrxFGPzj++;
							goto IL_012d;
							IL_012d:
							if (sLkbEhPzNkTotkolrNDtrxFGPzj >= dEtanXGxuGRnCgbMVHOCzlvzHrUr)
							{
								break;
							}
							SvXEKWepaqhYipEDYIIYpueBqCIv = ZmkGyfXEffVONeYHSRbWInMLivJ[sLkbEhPzNkTotkolrNDtrxFGPzj].mapSet;
							MjKeoEikNRvOSDpzjdgAMSEHXClQ = SvXEKWepaqhYipEDYIIYpueBqCIv.Count;
							YWOjCTRJVxkTCHAddmivbfIJuFr = 0;
							goto IL_0111;
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
					public QztIjuDSOUegBZEMHGDBqhpUjX(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class EWrEopscmUMLVkKxHJOMvLMSRUM : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

					public int gmlZVSBTtPIWuYPylEQcoNUGUio;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public int atHmpXUPtNaSqcKJwEqiDOBiGPAw;

					public int CDOHEkKgpTsEfarjhyeQeOjbpaA;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt zzvftHVLjZhvhcPUJskmpcAdhnHF;

					public int hnYFGkIQmCNlqCKBTSkcbLWQBtZS;

					public int BLaWUXslGJdDvDKwdrZPjrhoQhv;

					public SaFIhRkKoaFsJonuErfrovvvDai uIvGhiQuHbWfMmBpaxnESMgLLVL;

					public int fLYlBDFreyAPGUKYLQbJpWNafvl;

					public int BtEpBmMobtgsprZimJNhWcOUpyF;

					public ControllerMap MnCjwqmBGWotudUTqgcbwrDddivf;

					public ActionElementMap NHYxqyMYHwbIEuRaQxmYhoZwhWu;

					public IEnumerator<ActionElementMap> gzuFCwVrgmgPcOYbFkOgtlYDuoD;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						EWrEopscmUMLVkKxHJOMvLMSRUM eWrEopscmUMLVkKxHJOMvLMSRUM;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							eWrEopscmUMLVkKxHJOMvLMSRUM = this;
						}
						else
						{
							eWrEopscmUMLVkKxHJOMvLMSRUM = new EWrEopscmUMLVkKxHJOMvLMSRUM(0);
							eWrEopscmUMLVkKxHJOMvLMSRUM.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						eWrEopscmUMLVkKxHJOMvLMSRUM.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = gmlZVSBTtPIWuYPylEQcoNUGUio;
						eWrEopscmUMLVkKxHJOMvLMSRUM.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						return eWrEopscmUMLVkKxHJOMvLMSRUM;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
								{
									ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
									break;
								}
								if (aCGiPaCCkBbVoaUFLfEYHFYRMYCM < 0)
								{
									break;
								}
								atHmpXUPtNaSqcKJwEqiDOBiGPAw = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
								CDOHEkKgpTsEfarjhyeQeOjbpaA = 0;
								goto IL_01f5;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0196;
								}
								IL_01d6:
								if (BLaWUXslGJdDvDKwdrZPjrhoQhv < hnYFGkIQmCNlqCKBTSkcbLWQBtZS)
								{
									uIvGhiQuHbWfMmBpaxnESMgLLVL = zzvftHVLjZhvhcPUJskmpcAdhnHF[BLaWUXslGJdDvDKwdrZPjrhoQhv].mapSet;
									fLYlBDFreyAPGUKYLQbJpWNafvl = uIvGhiQuHbWfMmBpaxnESMgLLVL.Count;
									BtEpBmMobtgsprZimJNhWcOUpyF = 0;
									goto IL_01b7;
								}
								CDOHEkKgpTsEfarjhyeQeOjbpaA++;
								goto IL_01f5;
								IL_0196:
								if (gzuFCwVrgmgPcOYbFkOgtlYDuoD.MoveNext())
								{
									NHYxqyMYHwbIEuRaQxmYhoZwhWu = gzuFCwVrgmgPcOYbFkOgtlYDuoD.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = NHYxqyMYHwbIEuRaQxmYhoZwhWu;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								wCdKiazaqaBEDsocMIvkMrfrzHx();
								goto IL_01a9;
								IL_01a9:
								BtEpBmMobtgsprZimJNhWcOUpyF++;
								goto IL_01b7;
								IL_01f5:
								if (CDOHEkKgpTsEfarjhyeQeOjbpaA >= atHmpXUPtNaSqcKJwEqiDOBiGPAw)
								{
									break;
								}
								zzvftHVLjZhvhcPUJskmpcAdhnHF = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(CDOHEkKgpTsEfarjhyeQeOjbpaA);
								hnYFGkIQmCNlqCKBTSkcbLWQBtZS = zzvftHVLjZhvhcPUJskmpcAdhnHF.Count;
								BLaWUXslGJdDvDKwdrZPjrhoQhv = 0;
								goto IL_01d6;
								IL_01b7:
								if (BtEpBmMobtgsprZimJNhWcOUpyF < fLYlBDFreyAPGUKYLQbJpWNafvl)
								{
									MnCjwqmBGWotudUTqgcbwrDddivf = uIvGhiQuHbWfMmBpaxnESMgLLVL[BtEpBmMobtgsprZimJNhWcOUpyF];
									if ((!IftNYOsoyZKKlecDyJEriHNLMeG || MnCjwqmBGWotudUTqgcbwrDddivf.enabled) && MnCjwqmBGWotudUTqgcbwrDddivf.ContainsAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM))
									{
										gzuFCwVrgmgPcOYbFkOgtlYDuoD = MnCjwqmBGWotudUTqgcbwrDddivf.ButtonMapsWithAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM, IftNYOsoyZKKlecDyJEriHNLMeG).GetEnumerator();
										SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
										goto IL_0196;
									}
									goto IL_01a9;
								}
								BLaWUXslGJdDvDKwdrZPjrhoQhv++;
								goto IL_01d6;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								wCdKiazaqaBEDsocMIvkMrfrzHx();
							}
						}
					}

					[DebuggerHidden]
					public EWrEopscmUMLVkKxHJOMvLMSRUM(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void wCdKiazaqaBEDsocMIvkMrfrzHx()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (gzuFCwVrgmgPcOYbFkOgtlYDuoD != null)
						{
							gzuFCwVrgmgPcOYbFkOgtlYDuoD.Dispose();
						}
					}
				}

				private sealed class IMNgPGONEWasPVwLXyblKOpzqoc : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

					public int gmlZVSBTtPIWuYPylEQcoNUGUio;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public int EJJvaFVVeSRHNcagEwOlKbNBsJD;

					public int fpoOxbDfGpfqMmJkUfasXKezKCb;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt ucWkrmlWukjQqAGLkRQNyPPbcxFH;

					public int KqjYGlGuCPEQvqCHxfNQJegnowA;

					public int HAQBnBjrwJyLkBXKnFjeSQOBcSCa;

					public SaFIhRkKoaFsJonuErfrovvvDai hPQURfebMeosMZwMUDyPoKqyAZO;

					public int xzsUqGRZDKsMhqdGOllRVwwrRIo;

					public int AnmElRhxwnErvwAjecWPvWRKyTK;

					public ControllerMapWithAxes mrGtXqsqyHphjpIaaeXbiOFMIiBF;

					public ActionElementMap zggQhyumphlZItkgjsLhKcqbFzK;

					public IEnumerator<ActionElementMap> NAhjMGdPRbRUZNQOekLdFEysuAlb;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						IMNgPGONEWasPVwLXyblKOpzqoc iMNgPGONEWasPVwLXyblKOpzqoc;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							iMNgPGONEWasPVwLXyblKOpzqoc = this;
						}
						else
						{
							iMNgPGONEWasPVwLXyblKOpzqoc = new IMNgPGONEWasPVwLXyblKOpzqoc(0);
							iMNgPGONEWasPVwLXyblKOpzqoc.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						iMNgPGONEWasPVwLXyblKOpzqoc.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = gmlZVSBTtPIWuYPylEQcoNUGUio;
						iMNgPGONEWasPVwLXyblKOpzqoc.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						return iMNgPGONEWasPVwLXyblKOpzqoc;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
								{
									ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
									break;
								}
								if (aCGiPaCCkBbVoaUFLfEYHFYRMYCM < 0)
								{
									break;
								}
								EJJvaFVVeSRHNcagEwOlKbNBsJD = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
								fpoOxbDfGpfqMmJkUfasXKezKCb = 0;
								goto IL_0205;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_01a6;
								}
								IL_01e6:
								if (HAQBnBjrwJyLkBXKnFjeSQOBcSCa < KqjYGlGuCPEQvqCHxfNQJegnowA)
								{
									hPQURfebMeosMZwMUDyPoKqyAZO = ucWkrmlWukjQqAGLkRQNyPPbcxFH[HAQBnBjrwJyLkBXKnFjeSQOBcSCa].mapSet;
									xzsUqGRZDKsMhqdGOllRVwwrRIo = hPQURfebMeosMZwMUDyPoKqyAZO.Count;
									AnmElRhxwnErvwAjecWPvWRKyTK = 0;
									goto IL_01c7;
								}
								fpoOxbDfGpfqMmJkUfasXKezKCb++;
								goto IL_0205;
								IL_01b9:
								AnmElRhxwnErvwAjecWPvWRKyTK++;
								goto IL_01c7;
								IL_01a6:
								if (NAhjMGdPRbRUZNQOekLdFEysuAlb.MoveNext())
								{
									zggQhyumphlZItkgjsLhKcqbFzK = NAhjMGdPRbRUZNQOekLdFEysuAlb.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = zggQhyumphlZItkgjsLhKcqbFzK;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								CKemwdGFVHlRtlolUzMlQdQffuXc();
								goto IL_01b9;
								IL_0205:
								if (fpoOxbDfGpfqMmJkUfasXKezKCb >= EJJvaFVVeSRHNcagEwOlKbNBsJD)
								{
									break;
								}
								ucWkrmlWukjQqAGLkRQNyPPbcxFH = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(fpoOxbDfGpfqMmJkUfasXKezKCb);
								KqjYGlGuCPEQvqCHxfNQJegnowA = ucWkrmlWukjQqAGLkRQNyPPbcxFH.Count;
								HAQBnBjrwJyLkBXKnFjeSQOBcSCa = 0;
								goto IL_01e6;
								IL_01c7:
								if (AnmElRhxwnErvwAjecWPvWRKyTK < xzsUqGRZDKsMhqdGOllRVwwrRIo)
								{
									mrGtXqsqyHphjpIaaeXbiOFMIiBF = hPQURfebMeosMZwMUDyPoKqyAZO[AnmElRhxwnErvwAjecWPvWRKyTK] as ControllerMapWithAxes;
									if (mrGtXqsqyHphjpIaaeXbiOFMIiBF != null && (!IftNYOsoyZKKlecDyJEriHNLMeG || mrGtXqsqyHphjpIaaeXbiOFMIiBF.enabled) && mrGtXqsqyHphjpIaaeXbiOFMIiBF.ContainsAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM))
									{
										NAhjMGdPRbRUZNQOekLdFEysuAlb = mrGtXqsqyHphjpIaaeXbiOFMIiBF.AxisMapsWithAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM, IftNYOsoyZKKlecDyJEriHNLMeG).GetEnumerator();
										SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
										goto IL_01a6;
									}
									goto IL_01b9;
								}
								HAQBnBjrwJyLkBXKnFjeSQOBcSCa++;
								goto IL_01e6;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								CKemwdGFVHlRtlolUzMlQdQffuXc();
							}
						}
					}

					[DebuggerHidden]
					public IMNgPGONEWasPVwLXyblKOpzqoc(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void CKemwdGFVHlRtlolUzMlQdQffuXc()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (NAhjMGdPRbRUZNQOekLdFEysuAlb != null)
						{
							NAhjMGdPRbRUZNQOekLdFEysuAlb.Dispose();
						}
					}
				}

				private sealed class YoPCXohQmtrXMGOivtZkUvBhpDB : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

					public int gmlZVSBTtPIWuYPylEQcoNUGUio;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public int xeSTXMcospJrwMdadjiGzqjCfMD;

					public int mzZwoHBBvoKpHABOpiSCkCyLZtjh;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt OVvgHqfyQDMZwIrNAkRJPFelrQe;

					public int yVFiEUenseBfWSJZsjcAsjCWbmee;

					public int LyqGslhsUInuFrkCqHJRXeOjACCL;

					public SaFIhRkKoaFsJonuErfrovvvDai MGAzUPJMPhfSaaoGmgkpoTwpWDEL;

					public int iHpeidocuDywUNkWGzKTOgtZcbB;

					public int iWYZAkZMdDtmfeEAdUQdGCnfIcak;

					public ControllerMap PXTcUraAuFXHaLWcvIYHHMfcQUdj;

					public ActionElementMap iKHxWCXyRVaPMKSGArtOFTTZCCn;

					public IEnumerator<ActionElementMap> DEcDmAxiwAEGIHDzhkYkjHTGrQA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						YoPCXohQmtrXMGOivtZkUvBhpDB yoPCXohQmtrXMGOivtZkUvBhpDB;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							yoPCXohQmtrXMGOivtZkUvBhpDB = this;
						}
						else
						{
							yoPCXohQmtrXMGOivtZkUvBhpDB = new YoPCXohQmtrXMGOivtZkUvBhpDB(0);
							yoPCXohQmtrXMGOivtZkUvBhpDB.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						yoPCXohQmtrXMGOivtZkUvBhpDB.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = gmlZVSBTtPIWuYPylEQcoNUGUio;
						yoPCXohQmtrXMGOivtZkUvBhpDB.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						return yoPCXohQmtrXMGOivtZkUvBhpDB;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
								{
									ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
									break;
								}
								if (aCGiPaCCkBbVoaUFLfEYHFYRMYCM < 0)
								{
									break;
								}
								xeSTXMcospJrwMdadjiGzqjCfMD = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
								mzZwoHBBvoKpHABOpiSCkCyLZtjh = 0;
								goto IL_01f5;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0196;
								}
								IL_01d6:
								if (LyqGslhsUInuFrkCqHJRXeOjACCL < yVFiEUenseBfWSJZsjcAsjCWbmee)
								{
									MGAzUPJMPhfSaaoGmgkpoTwpWDEL = OVvgHqfyQDMZwIrNAkRJPFelrQe[LyqGslhsUInuFrkCqHJRXeOjACCL].mapSet;
									iHpeidocuDywUNkWGzKTOgtZcbB = MGAzUPJMPhfSaaoGmgkpoTwpWDEL.Count;
									iWYZAkZMdDtmfeEAdUQdGCnfIcak = 0;
									goto IL_01b7;
								}
								mzZwoHBBvoKpHABOpiSCkCyLZtjh++;
								goto IL_01f5;
								IL_0196:
								if (DEcDmAxiwAEGIHDzhkYkjHTGrQA.MoveNext())
								{
									iKHxWCXyRVaPMKSGArtOFTTZCCn = DEcDmAxiwAEGIHDzhkYkjHTGrQA.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = iKHxWCXyRVaPMKSGArtOFTTZCCn;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								XTwTvrkPsVCFNGBSnDRhCtOfBBm();
								goto IL_01a9;
								IL_01a9:
								iWYZAkZMdDtmfeEAdUQdGCnfIcak++;
								goto IL_01b7;
								IL_01f5:
								if (mzZwoHBBvoKpHABOpiSCkCyLZtjh >= xeSTXMcospJrwMdadjiGzqjCfMD)
								{
									break;
								}
								OVvgHqfyQDMZwIrNAkRJPFelrQe = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(mzZwoHBBvoKpHABOpiSCkCyLZtjh);
								yVFiEUenseBfWSJZsjcAsjCWbmee = OVvgHqfyQDMZwIrNAkRJPFelrQe.Count;
								LyqGslhsUInuFrkCqHJRXeOjACCL = 0;
								goto IL_01d6;
								IL_01b7:
								if (iWYZAkZMdDtmfeEAdUQdGCnfIcak < iHpeidocuDywUNkWGzKTOgtZcbB)
								{
									PXTcUraAuFXHaLWcvIYHHMfcQUdj = MGAzUPJMPhfSaaoGmgkpoTwpWDEL[iWYZAkZMdDtmfeEAdUQdGCnfIcak];
									if ((!IftNYOsoyZKKlecDyJEriHNLMeG || PXTcUraAuFXHaLWcvIYHHMfcQUdj.enabled) && PXTcUraAuFXHaLWcvIYHHMfcQUdj.ContainsAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM))
									{
										DEcDmAxiwAEGIHDzhkYkjHTGrQA = PXTcUraAuFXHaLWcvIYHHMfcQUdj.ElementMapsWithAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM, IftNYOsoyZKKlecDyJEriHNLMeG).GetEnumerator();
										SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
										goto IL_0196;
									}
									goto IL_01a9;
								}
								LyqGslhsUInuFrkCqHJRXeOjACCL++;
								goto IL_01d6;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								XTwTvrkPsVCFNGBSnDRhCtOfBBm();
							}
						}
					}

					[DebuggerHidden]
					public YoPCXohQmtrXMGOivtZkUvBhpDB(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void XTwTvrkPsVCFNGBSnDRhCtOfBBm()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (DEcDmAxiwAEGIHDzhkYkjHTGrQA != null)
						{
							DEcDmAxiwAEGIHDzhkYkjHTGrQA.Dispose();
						}
					}
				}

				private sealed class niejlyKuLHahjvMtAXbNkbPNqmf : IDisposable, IEnumerator, IEnumerable, IEnumerable<ControllerMap>, IEnumerator<ControllerMap>
				{
					private ControllerMap WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ControllerType guEuWFKSUNviYZgARiewhDnEceT;

					public ControllerType dCrCLiKKKlaSSJCUCnULxHTQLiPz;

					public int wtKbEuOgpmCyodusgKCfdeRTDQVb;

					public int vwsWqbAxZchMsrPtAyVDSdLCrYZ;

					public int LZYmkpJdDrlFtkHjqyUubFKNUCs;

					public int kHPEEBGwlYJndavghTRnPpnmDafU;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt ZlmzzPoKFLUQzQWEoOPFTBdYeRl;

					public int aAuqPIAxGoddXECHyQczJiGihJYa;

					public IList<ControllerMap> DhbOBQHRBjIPpBFpqChokUBUkFaw;

					public int OTVjMQoRhCrPgFqNjfpmAiKqENSa;

					ControllerMap IEnumerator<ControllerMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerMap> IEnumerable<ControllerMap>.GetEnumerator()
					{
						niejlyKuLHahjvMtAXbNkbPNqmf niejlyKuLHahjvMtAXbNkbPNqmf2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							niejlyKuLHahjvMtAXbNkbPNqmf2 = this;
						}
						else
						{
							niejlyKuLHahjvMtAXbNkbPNqmf2 = new niejlyKuLHahjvMtAXbNkbPNqmf(0);
							niejlyKuLHahjvMtAXbNkbPNqmf2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						niejlyKuLHahjvMtAXbNkbPNqmf2.guEuWFKSUNviYZgARiewhDnEceT = dCrCLiKKKlaSSJCUCnULxHTQLiPz;
						niejlyKuLHahjvMtAXbNkbPNqmf2.wtKbEuOgpmCyodusgKCfdeRTDQVb = vwsWqbAxZchMsrPtAyVDSdLCrYZ;
						niejlyKuLHahjvMtAXbNkbPNqmf2.LZYmkpJdDrlFtkHjqyUubFKNUCs = kHPEEBGwlYJndavghTRnPpnmDafU;
						return niejlyKuLHahjvMtAXbNkbPNqmf2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerMap>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 0:
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							ZlmzzPoKFLUQzQWEoOPFTBdYeRl = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(guEuWFKSUNviYZgARiewhDnEceT);
							aAuqPIAxGoddXECHyQczJiGihJYa = ZlmzzPoKFLUQzQWEoOPFTBdYeRl.iFNXApJjlWtDZdwedJFKpfGAMok(wtKbEuOgpmCyodusgKCfdeRTDQVb);
							if (aAuqPIAxGoddXECHyQczJiGihJYa < 0)
							{
								break;
							}
							DhbOBQHRBjIPpBFpqChokUBUkFaw = ZlmzzPoKFLUQzQWEoOPFTBdYeRl[aAuqPIAxGoddXECHyQczJiGihJYa].mapSet.Maps;
							OTVjMQoRhCrPgFqNjfpmAiKqENSa = 0;
							goto IL_00e2;
						case 1:
							{
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								goto IL_00d4;
							}
							IL_00d4:
							OTVjMQoRhCrPgFqNjfpmAiKqENSa++;
							goto IL_00e2;
							IL_00e2:
							if (OTVjMQoRhCrPgFqNjfpmAiKqENSa >= DhbOBQHRBjIPpBFpqChokUBUkFaw.Count)
							{
								break;
							}
							if (DhbOBQHRBjIPpBFpqChokUBUkFaw[OTVjMQoRhCrPgFqNjfpmAiKqENSa].categoryId == LZYmkpJdDrlFtkHjqyUubFKNUCs)
							{
								WCNlIsEdYuVTqbNYvICUPcTebLU = DhbOBQHRBjIPpBFpqChokUBUkFaw[OTVjMQoRhCrPgFqNjfpmAiKqENSa];
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								return true;
							}
							goto IL_00d4;
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
					public niejlyKuLHahjvMtAXbNkbPNqmf(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class mSKaEhdKeXWwxtjiThAkshTwbwmg<T> : IDisposable, IEnumerator, IEnumerable, IEnumerable<T>, IEnumerator<T> where T : ControllerMap
				{
					private T WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int wtKbEuOgpmCyodusgKCfdeRTDQVb;

					public int vwsWqbAxZchMsrPtAyVDSdLCrYZ;

					public int LZYmkpJdDrlFtkHjqyUubFKNUCs;

					public int kHPEEBGwlYJndavghTRnPpnmDafU;

					public ControllerType kzGnRgYHSFGNTdSGWaTSSJNwLQb;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt ylaUrhJZceAwhTzoopOeGpFoTPJ;

					public int yaacJpKFcaVTTWtJmbsuaOIljAB;

					public IList<T> ywjsfZjgVrNphTngBgbxQxhcCyt;

					public int EGQcryjeYKDaFDswcXvydwvUKrRm;

					T IEnumerator<T>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<T> IEnumerable<T>.GetEnumerator()
					{
						mSKaEhdKeXWwxtjiThAkshTwbwmg<T> mSKaEhdKeXWwxtjiThAkshTwbwmg2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							mSKaEhdKeXWwxtjiThAkshTwbwmg2 = this;
						}
						else
						{
							mSKaEhdKeXWwxtjiThAkshTwbwmg2 = new mSKaEhdKeXWwxtjiThAkshTwbwmg<T>(0);
							mSKaEhdKeXWwxtjiThAkshTwbwmg2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						mSKaEhdKeXWwxtjiThAkshTwbwmg2.wtKbEuOgpmCyodusgKCfdeRTDQVb = vwsWqbAxZchMsrPtAyVDSdLCrYZ;
						mSKaEhdKeXWwxtjiThAkshTwbwmg2.LZYmkpJdDrlFtkHjqyUubFKNUCs = kHPEEBGwlYJndavghTRnPpnmDafU;
						return mSKaEhdKeXWwxtjiThAkshTwbwmg2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<T>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						T val;
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 0:
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							kzGnRgYHSFGNTdSGWaTSSJNwLQb = XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>();
							ylaUrhJZceAwhTzoopOeGpFoTPJ = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(kzGnRgYHSFGNTdSGWaTSSJNwLQb);
							yaacJpKFcaVTTWtJmbsuaOIljAB = ylaUrhJZceAwhTzoopOeGpFoTPJ.iFNXApJjlWtDZdwedJFKpfGAMok(wtKbEuOgpmCyodusgKCfdeRTDQVb);
							if (yaacJpKFcaVTTWtJmbsuaOIljAB < 0)
							{
								break;
							}
							ywjsfZjgVrNphTngBgbxQxhcCyt = ylaUrhJZceAwhTzoopOeGpFoTPJ[yaacJpKFcaVTTWtJmbsuaOIljAB].mapSet.gfBmEOaJlorgkCybHFpQvKcqfebg<T>();
							EGQcryjeYKDaFDswcXvydwvUKrRm = 0;
							goto IL_00f6;
						case 1:
							{
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								goto IL_00e8;
							}
							IL_00e8:
							EGQcryjeYKDaFDswcXvydwvUKrRm++;
							goto IL_00f6;
							IL_00f6:
							if (EGQcryjeYKDaFDswcXvydwvUKrRm >= ywjsfZjgVrNphTngBgbxQxhcCyt.Count)
							{
								break;
							}
							val = ywjsfZjgVrNphTngBgbxQxhcCyt[EGQcryjeYKDaFDswcXvydwvUKrRm];
							if (val.categoryId == LZYmkpJdDrlFtkHjqyUubFKNUCs)
							{
								WCNlIsEdYuVTqbNYvICUPcTebLU = ywjsfZjgVrNphTngBgbxQxhcCyt[EGQcryjeYKDaFDswcXvydwvUKrRm];
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								return true;
							}
							goto IL_00e8;
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
					public mSKaEhdKeXWwxtjiThAkshTwbwmg(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}
				}

				private sealed class UdVjikDIQZnEIhKRxyaHnacGFvsZ : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ControllerType guEuWFKSUNviYZgARiewhDnEceT;

					public ControllerType dCrCLiKKKlaSSJCUCnULxHTQLiPz;

					public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

					public int gmlZVSBTtPIWuYPylEQcoNUGUio;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt bNQwyZhLcbaoTHHmQyZqQzTKRzs;

					public int eOczbvVEDvyBjgsPcTumDoWTton;

					public IList<ControllerMap> DzAMdgznpumztEbivAsmdQkdTVtb;

					public int ZNmBqoHChtZJLbWXAujzibwLyhA;

					public ActionElementMap wmIPVdIozUtfbinhGHtfMpdgZUN;

					public IEnumerator<ActionElementMap> cBOLtCtiYlXjHraRJfOKgzghilsv;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						UdVjikDIQZnEIhKRxyaHnacGFvsZ udVjikDIQZnEIhKRxyaHnacGFvsZ;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							udVjikDIQZnEIhKRxyaHnacGFvsZ = this;
						}
						else
						{
							udVjikDIQZnEIhKRxyaHnacGFvsZ = new UdVjikDIQZnEIhKRxyaHnacGFvsZ(0);
							udVjikDIQZnEIhKRxyaHnacGFvsZ.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						udVjikDIQZnEIhKRxyaHnacGFvsZ.guEuWFKSUNviYZgARiewhDnEceT = dCrCLiKKKlaSSJCUCnULxHTQLiPz;
						udVjikDIQZnEIhKRxyaHnacGFvsZ.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = gmlZVSBTtPIWuYPylEQcoNUGUio;
						udVjikDIQZnEIhKRxyaHnacGFvsZ.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						return udVjikDIQZnEIhKRxyaHnacGFvsZ;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (aCGiPaCCkBbVoaUFLfEYHFYRMYCM < 0)
								{
									break;
								}
								bNQwyZhLcbaoTHHmQyZqQzTKRzs = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(guEuWFKSUNviYZgARiewhDnEceT);
								eOczbvVEDvyBjgsPcTumDoWTton = 0;
								goto IL_0176;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0131;
								}
								IL_0131:
								if (cBOLtCtiYlXjHraRJfOKgzghilsv.MoveNext())
								{
									wmIPVdIozUtfbinhGHtfMpdgZUN = cBOLtCtiYlXjHraRJfOKgzghilsv.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = wmIPVdIozUtfbinhGHtfMpdgZUN;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								HdewXsODqmLMEPpoysUldNhnevm();
								goto IL_0144;
								IL_0176:
								if (eOczbvVEDvyBjgsPcTumDoWTton >= bNQwyZhLcbaoTHHmQyZqQzTKRzs.Count)
								{
									break;
								}
								DzAMdgznpumztEbivAsmdQkdTVtb = bNQwyZhLcbaoTHHmQyZqQzTKRzs[eOczbvVEDvyBjgsPcTumDoWTton].mapSet.Maps;
								ZNmBqoHChtZJLbWXAujzibwLyhA = 0;
								goto IL_0152;
								IL_0144:
								ZNmBqoHChtZJLbWXAujzibwLyhA++;
								goto IL_0152;
								IL_0152:
								if (ZNmBqoHChtZJLbWXAujzibwLyhA < DzAMdgznpumztEbivAsmdQkdTVtb.Count)
								{
									if ((!IftNYOsoyZKKlecDyJEriHNLMeG || DzAMdgznpumztEbivAsmdQkdTVtb[ZNmBqoHChtZJLbWXAujzibwLyhA].enabled) && DzAMdgznpumztEbivAsmdQkdTVtb[ZNmBqoHChtZJLbWXAujzibwLyhA].ContainsAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM))
									{
										cBOLtCtiYlXjHraRJfOKgzghilsv = DzAMdgznpumztEbivAsmdQkdTVtb[ZNmBqoHChtZJLbWXAujzibwLyhA].ButtonMapsWithAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM, IftNYOsoyZKKlecDyJEriHNLMeG).GetEnumerator();
										SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
										goto IL_0131;
									}
									goto IL_0144;
								}
								eOczbvVEDvyBjgsPcTumDoWTton++;
								goto IL_0176;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								HdewXsODqmLMEPpoysUldNhnevm();
							}
						}
					}

					[DebuggerHidden]
					public UdVjikDIQZnEIhKRxyaHnacGFvsZ(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void HdewXsODqmLMEPpoysUldNhnevm()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (cBOLtCtiYlXjHraRJfOKgzghilsv != null)
						{
							cBOLtCtiYlXjHraRJfOKgzghilsv.Dispose();
						}
					}
				}

				private sealed class HtMFDazxNLAhDRQNMXThXIOFvWt : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ControllerType guEuWFKSUNviYZgARiewhDnEceT;

					public ControllerType dCrCLiKKKlaSSJCUCnULxHTQLiPz;

					public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

					public int gmlZVSBTtPIWuYPylEQcoNUGUio;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt rgogBOYepUeuysfGZxhfYRADtKD;

					public int SgYlXTfVEFbBmJpegiXeTuhPdqr;

					public IList<ControllerMap> wBRAtuErVamEYPtloNVoJORfbHwX;

					public int dbSQALPDEdSNjwcHJCLqzqcoDgM;

					public ActionElementMap CqHFksVPXjBovgKoshCOJIdWYqH;

					public IEnumerator<ActionElementMap> KbTwSSkpzTzPQrpoqzCZqMwpJdH;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						HtMFDazxNLAhDRQNMXThXIOFvWt htMFDazxNLAhDRQNMXThXIOFvWt;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							htMFDazxNLAhDRQNMXThXIOFvWt = this;
						}
						else
						{
							htMFDazxNLAhDRQNMXThXIOFvWt = new HtMFDazxNLAhDRQNMXThXIOFvWt(0);
							htMFDazxNLAhDRQNMXThXIOFvWt.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						htMFDazxNLAhDRQNMXThXIOFvWt.guEuWFKSUNviYZgARiewhDnEceT = dCrCLiKKKlaSSJCUCnULxHTQLiPz;
						htMFDazxNLAhDRQNMXThXIOFvWt.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = gmlZVSBTtPIWuYPylEQcoNUGUio;
						htMFDazxNLAhDRQNMXThXIOFvWt.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						return htMFDazxNLAhDRQNMXThXIOFvWt;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (aCGiPaCCkBbVoaUFLfEYHFYRMYCM < 0)
								{
									break;
								}
								rgogBOYepUeuysfGZxhfYRADtKD = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(guEuWFKSUNviYZgARiewhDnEceT);
								SgYlXTfVEFbBmJpegiXeTuhPdqr = 0;
								goto IL_0196;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0151;
								}
								IL_0164:
								dbSQALPDEdSNjwcHJCLqzqcoDgM++;
								goto IL_0172;
								IL_0196:
								if (SgYlXTfVEFbBmJpegiXeTuhPdqr >= rgogBOYepUeuysfGZxhfYRADtKD.Count)
								{
									break;
								}
								wBRAtuErVamEYPtloNVoJORfbHwX = rgogBOYepUeuysfGZxhfYRADtKD[SgYlXTfVEFbBmJpegiXeTuhPdqr].mapSet.Maps;
								dbSQALPDEdSNjwcHJCLqzqcoDgM = 0;
								goto IL_0172;
								IL_0151:
								if (KbTwSSkpzTzPQrpoqzCZqMwpJdH.MoveNext())
								{
									CqHFksVPXjBovgKoshCOJIdWYqH = KbTwSSkpzTzPQrpoqzCZqMwpJdH.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = CqHFksVPXjBovgKoshCOJIdWYqH;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								KhCopPccbKesAeHTLibfYSJvqBII();
								goto IL_0164;
								IL_0172:
								if (dbSQALPDEdSNjwcHJCLqzqcoDgM < wBRAtuErVamEYPtloNVoJORfbHwX.Count)
								{
									if (!(wBRAtuErVamEYPtloNVoJORfbHwX[dbSQALPDEdSNjwcHJCLqzqcoDgM] is ControllerMapWithAxes))
									{
										break;
									}
									if ((!IftNYOsoyZKKlecDyJEriHNLMeG || wBRAtuErVamEYPtloNVoJORfbHwX[dbSQALPDEdSNjwcHJCLqzqcoDgM].enabled) && wBRAtuErVamEYPtloNVoJORfbHwX[dbSQALPDEdSNjwcHJCLqzqcoDgM].ContainsAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM))
									{
										KbTwSSkpzTzPQrpoqzCZqMwpJdH = (wBRAtuErVamEYPtloNVoJORfbHwX[dbSQALPDEdSNjwcHJCLqzqcoDgM] as ControllerMapWithAxes).AxisMapsWithAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM, IftNYOsoyZKKlecDyJEriHNLMeG).GetEnumerator();
										SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
										goto IL_0151;
									}
									goto IL_0164;
								}
								SgYlXTfVEFbBmJpegiXeTuhPdqr++;
								goto IL_0196;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								KhCopPccbKesAeHTLibfYSJvqBII();
							}
						}
					}

					[DebuggerHidden]
					public HtMFDazxNLAhDRQNMXThXIOFvWt(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void KhCopPccbKesAeHTLibfYSJvqBII()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (KbTwSSkpzTzPQrpoqzCZqMwpJdH != null)
						{
							KbTwSSkpzTzPQrpoqzCZqMwpJdH.Dispose();
						}
					}
				}

				private sealed class EEyIpKAoAxTmGdXXIzVYruSHfYRU : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ControllerType guEuWFKSUNviYZgARiewhDnEceT;

					public ControllerType dCrCLiKKKlaSSJCUCnULxHTQLiPz;

					public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

					public int gmlZVSBTtPIWuYPylEQcoNUGUio;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt XFANRmwRTMrtLEZZLLsDihwAXcv;

					public int NxQVeZxxZZyWXSzClTcdvNZqEJG;

					public IList<ControllerMap> hDVoQayAkSYsaDVRnLCyIWmzAAw;

					public int vxllUkZpiBbXCOJcNPsCMgcMDJSF;

					public ActionElementMap NYgaJxeDRfMzOVRbGuJTpkUMuJ;

					public IEnumerator<ActionElementMap> JxDEvFHQGEMLFAMBFkBZMvUauuyy;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						EEyIpKAoAxTmGdXXIzVYruSHfYRU eEyIpKAoAxTmGdXXIzVYruSHfYRU;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							eEyIpKAoAxTmGdXXIzVYruSHfYRU = this;
						}
						else
						{
							eEyIpKAoAxTmGdXXIzVYruSHfYRU = new EEyIpKAoAxTmGdXXIzVYruSHfYRU(0);
							eEyIpKAoAxTmGdXXIzVYruSHfYRU.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						eEyIpKAoAxTmGdXXIzVYruSHfYRU.guEuWFKSUNviYZgARiewhDnEceT = dCrCLiKKKlaSSJCUCnULxHTQLiPz;
						eEyIpKAoAxTmGdXXIzVYruSHfYRU.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = gmlZVSBTtPIWuYPylEQcoNUGUio;
						eEyIpKAoAxTmGdXXIzVYruSHfYRU.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						return eEyIpKAoAxTmGdXXIzVYruSHfYRU;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (aCGiPaCCkBbVoaUFLfEYHFYRMYCM < 0)
								{
									break;
								}
								XFANRmwRTMrtLEZZLLsDihwAXcv = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(guEuWFKSUNviYZgARiewhDnEceT);
								NxQVeZxxZZyWXSzClTcdvNZqEJG = 0;
								goto IL_0176;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0131;
								}
								IL_0131:
								if (JxDEvFHQGEMLFAMBFkBZMvUauuyy.MoveNext())
								{
									NYgaJxeDRfMzOVRbGuJTpkUMuJ = JxDEvFHQGEMLFAMBFkBZMvUauuyy.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = NYgaJxeDRfMzOVRbGuJTpkUMuJ;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								ouPblKrYqEidbFMWovgDTItcxWH();
								goto IL_0144;
								IL_0176:
								if (NxQVeZxxZZyWXSzClTcdvNZqEJG >= XFANRmwRTMrtLEZZLLsDihwAXcv.Count)
								{
									break;
								}
								hDVoQayAkSYsaDVRnLCyIWmzAAw = XFANRmwRTMrtLEZZLLsDihwAXcv[NxQVeZxxZZyWXSzClTcdvNZqEJG].mapSet.Maps;
								vxllUkZpiBbXCOJcNPsCMgcMDJSF = 0;
								goto IL_0152;
								IL_0144:
								vxllUkZpiBbXCOJcNPsCMgcMDJSF++;
								goto IL_0152;
								IL_0152:
								if (vxllUkZpiBbXCOJcNPsCMgcMDJSF < hDVoQayAkSYsaDVRnLCyIWmzAAw.Count)
								{
									if ((!IftNYOsoyZKKlecDyJEriHNLMeG || hDVoQayAkSYsaDVRnLCyIWmzAAw[vxllUkZpiBbXCOJcNPsCMgcMDJSF].enabled) && hDVoQayAkSYsaDVRnLCyIWmzAAw[vxllUkZpiBbXCOJcNPsCMgcMDJSF].ContainsAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM))
									{
										JxDEvFHQGEMLFAMBFkBZMvUauuyy = hDVoQayAkSYsaDVRnLCyIWmzAAw[vxllUkZpiBbXCOJcNPsCMgcMDJSF].ElementMapsWithAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM, IftNYOsoyZKKlecDyJEriHNLMeG).GetEnumerator();
										SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
										goto IL_0131;
									}
									goto IL_0144;
								}
								NxQVeZxxZZyWXSzClTcdvNZqEJG++;
								goto IL_0176;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								ouPblKrYqEidbFMWovgDTItcxWH();
							}
						}
					}

					[DebuggerHidden]
					public EEyIpKAoAxTmGdXXIzVYruSHfYRU(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void ouPblKrYqEidbFMWovgDTItcxWH()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (JxDEvFHQGEMLFAMBFkBZMvUauuyy != null)
						{
							JxDEvFHQGEMLFAMBFkBZMvUauuyy.Dispose();
						}
					}
				}

				private sealed class YJkBnEDXswQVGNzcVffrhStXAkE : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ControllerType guEuWFKSUNviYZgARiewhDnEceT;

					public ControllerType dCrCLiKKKlaSSJCUCnULxHTQLiPz;

					public int wtKbEuOgpmCyodusgKCfdeRTDQVb;

					public int vwsWqbAxZchMsrPtAyVDSdLCrYZ;

					public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

					public int gmlZVSBTtPIWuYPylEQcoNUGUio;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt oFaifQbhdwOikHWvWfpRlsZkRZsQ;

					public int rmWfvpMcSfoSpVnvYiHjoEQcAuC;

					public IList<ControllerMap> BuHQLVSsSwxaNrcjKOOblcxKkJe;

					public int JaIUMVmexMWouhsBKWwhHOtCpsS;

					public ActionElementMap HGUDyRkRgSYfEuohzsJeeYwPeUO;

					public IEnumerator<ActionElementMap> VmgrDLToYMSAKpQcMhSsWEYXywh;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						YJkBnEDXswQVGNzcVffrhStXAkE yJkBnEDXswQVGNzcVffrhStXAkE;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							yJkBnEDXswQVGNzcVffrhStXAkE = this;
						}
						else
						{
							yJkBnEDXswQVGNzcVffrhStXAkE = new YJkBnEDXswQVGNzcVffrhStXAkE(0);
							yJkBnEDXswQVGNzcVffrhStXAkE.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						yJkBnEDXswQVGNzcVffrhStXAkE.guEuWFKSUNviYZgARiewhDnEceT = dCrCLiKKKlaSSJCUCnULxHTQLiPz;
						yJkBnEDXswQVGNzcVffrhStXAkE.wtKbEuOgpmCyodusgKCfdeRTDQVb = vwsWqbAxZchMsrPtAyVDSdLCrYZ;
						yJkBnEDXswQVGNzcVffrhStXAkE.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = gmlZVSBTtPIWuYPylEQcoNUGUio;
						yJkBnEDXswQVGNzcVffrhStXAkE.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						return yJkBnEDXswQVGNzcVffrhStXAkE;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (aCGiPaCCkBbVoaUFLfEYHFYRMYCM < 0)
								{
									break;
								}
								oFaifQbhdwOikHWvWfpRlsZkRZsQ = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(guEuWFKSUNviYZgARiewhDnEceT);
								rmWfvpMcSfoSpVnvYiHjoEQcAuC = oFaifQbhdwOikHWvWfpRlsZkRZsQ.iFNXApJjlWtDZdwedJFKpfGAMok(wtKbEuOgpmCyodusgKCfdeRTDQVb);
								if (rmWfvpMcSfoSpVnvYiHjoEQcAuC < 0)
								{
									break;
								}
								BuHQLVSsSwxaNrcjKOOblcxKkJe = oFaifQbhdwOikHWvWfpRlsZkRZsQ[rmWfvpMcSfoSpVnvYiHjoEQcAuC].mapSet.Maps;
								JaIUMVmexMWouhsBKWwhHOtCpsS = 0;
								goto IL_0169;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0148;
								}
								IL_015b:
								JaIUMVmexMWouhsBKWwhHOtCpsS++;
								goto IL_0169;
								IL_0148:
								if (VmgrDLToYMSAKpQcMhSsWEYXywh.MoveNext())
								{
									HGUDyRkRgSYfEuohzsJeeYwPeUO = VmgrDLToYMSAKpQcMhSsWEYXywh.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = HGUDyRkRgSYfEuohzsJeeYwPeUO;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								VecgJgjfEkRWQIDwxMxREMBcykl();
								goto IL_015b;
								IL_0169:
								if (JaIUMVmexMWouhsBKWwhHOtCpsS >= BuHQLVSsSwxaNrcjKOOblcxKkJe.Count)
								{
									break;
								}
								if ((!IftNYOsoyZKKlecDyJEriHNLMeG || BuHQLVSsSwxaNrcjKOOblcxKkJe[JaIUMVmexMWouhsBKWwhHOtCpsS].enabled) && BuHQLVSsSwxaNrcjKOOblcxKkJe[JaIUMVmexMWouhsBKWwhHOtCpsS].ContainsAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM))
								{
									VmgrDLToYMSAKpQcMhSsWEYXywh = BuHQLVSsSwxaNrcjKOOblcxKkJe[JaIUMVmexMWouhsBKWwhHOtCpsS].ButtonMapsWithAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM, IftNYOsoyZKKlecDyJEriHNLMeG).GetEnumerator();
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0148;
								}
								goto IL_015b;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								VecgJgjfEkRWQIDwxMxREMBcykl();
							}
						}
					}

					[DebuggerHidden]
					public YJkBnEDXswQVGNzcVffrhStXAkE(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void VecgJgjfEkRWQIDwxMxREMBcykl()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (VmgrDLToYMSAKpQcMhSsWEYXywh != null)
						{
							VmgrDLToYMSAKpQcMhSsWEYXywh.Dispose();
						}
					}
				}

				private sealed class aGYhMjuoCpJJYFIdnmXaYgRONab : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ControllerType guEuWFKSUNviYZgARiewhDnEceT;

					public ControllerType dCrCLiKKKlaSSJCUCnULxHTQLiPz;

					public int wtKbEuOgpmCyodusgKCfdeRTDQVb;

					public int vwsWqbAxZchMsrPtAyVDSdLCrYZ;

					public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

					public int gmlZVSBTtPIWuYPylEQcoNUGUio;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt eWeBmbyShiDHFgTiXHLCYgQFGTz;

					public int iBuoTKCKCqytOXUITlGOADeWVTR;

					public IList<ControllerMap> QMQlynTgUuKFtBEjqiMEDjhVGnx;

					public int DndDBJvjsFqTnnkctjVreMCHeTWe;

					public ActionElementMap eRIjzKjcKKwCgoLSZUPXAVnammS;

					public IEnumerator<ActionElementMap> bjyhoabyRefZeyRvkuFkLdoIdwP;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						aGYhMjuoCpJJYFIdnmXaYgRONab aGYhMjuoCpJJYFIdnmXaYgRONab2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							aGYhMjuoCpJJYFIdnmXaYgRONab2 = this;
						}
						else
						{
							aGYhMjuoCpJJYFIdnmXaYgRONab2 = new aGYhMjuoCpJJYFIdnmXaYgRONab(0);
							aGYhMjuoCpJJYFIdnmXaYgRONab2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						aGYhMjuoCpJJYFIdnmXaYgRONab2.guEuWFKSUNviYZgARiewhDnEceT = dCrCLiKKKlaSSJCUCnULxHTQLiPz;
						aGYhMjuoCpJJYFIdnmXaYgRONab2.wtKbEuOgpmCyodusgKCfdeRTDQVb = vwsWqbAxZchMsrPtAyVDSdLCrYZ;
						aGYhMjuoCpJJYFIdnmXaYgRONab2.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = gmlZVSBTtPIWuYPylEQcoNUGUio;
						aGYhMjuoCpJJYFIdnmXaYgRONab2.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						return aGYhMjuoCpJJYFIdnmXaYgRONab2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (aCGiPaCCkBbVoaUFLfEYHFYRMYCM < 0)
								{
									break;
								}
								eWeBmbyShiDHFgTiXHLCYgQFGTz = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(guEuWFKSUNviYZgARiewhDnEceT);
								iBuoTKCKCqytOXUITlGOADeWVTR = eWeBmbyShiDHFgTiXHLCYgQFGTz.iFNXApJjlWtDZdwedJFKpfGAMok(wtKbEuOgpmCyodusgKCfdeRTDQVb);
								if (iBuoTKCKCqytOXUITlGOADeWVTR < 0)
								{
									break;
								}
								QMQlynTgUuKFtBEjqiMEDjhVGnx = eWeBmbyShiDHFgTiXHLCYgQFGTz[iBuoTKCKCqytOXUITlGOADeWVTR].mapSet.Maps;
								DndDBJvjsFqTnnkctjVreMCHeTWe = 0;
								goto IL_0189;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0168;
								}
								IL_0168:
								if (bjyhoabyRefZeyRvkuFkLdoIdwP.MoveNext())
								{
									eRIjzKjcKKwCgoLSZUPXAVnammS = bjyhoabyRefZeyRvkuFkLdoIdwP.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = eRIjzKjcKKwCgoLSZUPXAVnammS;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								kKuJdPrzNxDRjVZOnuGJXfWUzcC();
								goto IL_017b;
								IL_017b:
								DndDBJvjsFqTnnkctjVreMCHeTWe++;
								goto IL_0189;
								IL_0189:
								if (DndDBJvjsFqTnnkctjVreMCHeTWe >= QMQlynTgUuKFtBEjqiMEDjhVGnx.Count || !(QMQlynTgUuKFtBEjqiMEDjhVGnx[DndDBJvjsFqTnnkctjVreMCHeTWe] is ControllerMapWithAxes))
								{
									break;
								}
								if ((!IftNYOsoyZKKlecDyJEriHNLMeG || QMQlynTgUuKFtBEjqiMEDjhVGnx[DndDBJvjsFqTnnkctjVreMCHeTWe].enabled) && QMQlynTgUuKFtBEjqiMEDjhVGnx[DndDBJvjsFqTnnkctjVreMCHeTWe].ContainsAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM))
								{
									bjyhoabyRefZeyRvkuFkLdoIdwP = (QMQlynTgUuKFtBEjqiMEDjhVGnx[DndDBJvjsFqTnnkctjVreMCHeTWe] as ControllerMapWithAxes).AxisMapsWithAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM, IftNYOsoyZKKlecDyJEriHNLMeG).GetEnumerator();
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0168;
								}
								goto IL_017b;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								kKuJdPrzNxDRjVZOnuGJXfWUzcC();
							}
						}
					}

					[DebuggerHidden]
					public aGYhMjuoCpJJYFIdnmXaYgRONab(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void kKuJdPrzNxDRjVZOnuGJXfWUzcC()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (bjyhoabyRefZeyRvkuFkLdoIdwP != null)
						{
							bjyhoabyRefZeyRvkuFkLdoIdwP.Dispose();
						}
					}
				}

				private sealed class OToFLcqinEebyQqRdMgxJPMYXVH : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ControllerType guEuWFKSUNviYZgARiewhDnEceT;

					public ControllerType dCrCLiKKKlaSSJCUCnULxHTQLiPz;

					public int wtKbEuOgpmCyodusgKCfdeRTDQVb;

					public int vwsWqbAxZchMsrPtAyVDSdLCrYZ;

					public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

					public int gmlZVSBTtPIWuYPylEQcoNUGUio;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt JaaIndkMEnCImBPSZwhomLJLBDO;

					public int OjVEEkQSCYWVPzxLedsPkpEkZjF;

					public IList<ControllerMap> yamXulmJBkOyVUrEeNqHLMQAjVG;

					public int BDwonlhSwFETpjfltGRiATjAJSm;

					public ActionElementMap qNrPTfAlrvdcMkajBvYDiFsvPri;

					public IEnumerator<ActionElementMap> PrCySXwAIyisotxBdhxGoQRhCNb;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						OToFLcqinEebyQqRdMgxJPMYXVH oToFLcqinEebyQqRdMgxJPMYXVH;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							oToFLcqinEebyQqRdMgxJPMYXVH = this;
						}
						else
						{
							oToFLcqinEebyQqRdMgxJPMYXVH = new OToFLcqinEebyQqRdMgxJPMYXVH(0);
							oToFLcqinEebyQqRdMgxJPMYXVH.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						oToFLcqinEebyQqRdMgxJPMYXVH.guEuWFKSUNviYZgARiewhDnEceT = dCrCLiKKKlaSSJCUCnULxHTQLiPz;
						oToFLcqinEebyQqRdMgxJPMYXVH.wtKbEuOgpmCyodusgKCfdeRTDQVb = vwsWqbAxZchMsrPtAyVDSdLCrYZ;
						oToFLcqinEebyQqRdMgxJPMYXVH.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = gmlZVSBTtPIWuYPylEQcoNUGUio;
						oToFLcqinEebyQqRdMgxJPMYXVH.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						return oToFLcqinEebyQqRdMgxJPMYXVH;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (aCGiPaCCkBbVoaUFLfEYHFYRMYCM < 0)
								{
									break;
								}
								JaaIndkMEnCImBPSZwhomLJLBDO = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(guEuWFKSUNviYZgARiewhDnEceT);
								OjVEEkQSCYWVPzxLedsPkpEkZjF = JaaIndkMEnCImBPSZwhomLJLBDO.iFNXApJjlWtDZdwedJFKpfGAMok(wtKbEuOgpmCyodusgKCfdeRTDQVb);
								if (OjVEEkQSCYWVPzxLedsPkpEkZjF < 0)
								{
									break;
								}
								yamXulmJBkOyVUrEeNqHLMQAjVG = JaaIndkMEnCImBPSZwhomLJLBDO[OjVEEkQSCYWVPzxLedsPkpEkZjF].mapSet.Maps;
								BDwonlhSwFETpjfltGRiATjAJSm = 0;
								goto IL_0169;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0148;
								}
								IL_015b:
								BDwonlhSwFETpjfltGRiATjAJSm++;
								goto IL_0169;
								IL_0148:
								if (PrCySXwAIyisotxBdhxGoQRhCNb.MoveNext())
								{
									qNrPTfAlrvdcMkajBvYDiFsvPri = PrCySXwAIyisotxBdhxGoQRhCNb.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = qNrPTfAlrvdcMkajBvYDiFsvPri;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								ZkqabZjWImpfFiXonTfmgVFxoUpb();
								goto IL_015b;
								IL_0169:
								if (BDwonlhSwFETpjfltGRiATjAJSm >= yamXulmJBkOyVUrEeNqHLMQAjVG.Count)
								{
									break;
								}
								if ((!IftNYOsoyZKKlecDyJEriHNLMeG || yamXulmJBkOyVUrEeNqHLMQAjVG[BDwonlhSwFETpjfltGRiATjAJSm].enabled) && yamXulmJBkOyVUrEeNqHLMQAjVG[BDwonlhSwFETpjfltGRiATjAJSm].ContainsAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM))
								{
									PrCySXwAIyisotxBdhxGoQRhCNb = yamXulmJBkOyVUrEeNqHLMQAjVG[BDwonlhSwFETpjfltGRiATjAJSm].ElementMapsWithAction(aCGiPaCCkBbVoaUFLfEYHFYRMYCM, IftNYOsoyZKKlecDyJEriHNLMeG).GetEnumerator();
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0148;
								}
								goto IL_015b;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								ZkqabZjWImpfFiXonTfmgVFxoUpb();
							}
						}
					}

					[DebuggerHidden]
					public OToFLcqinEebyQqRdMgxJPMYXVH(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void ZkqabZjWImpfFiXonTfmgVFxoUpb()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (PrCySXwAIyisotxBdhxGoQRhCNb != null)
						{
							PrCySXwAIyisotxBdhxGoQRhCNb.Dispose();
						}
					}
				}

				private sealed class lMZTHluAuWFFEhYQlbROeeVGkLIJ : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
				{
					private ActionElementMap WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public MapHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IControllerElementTarget hUCShNLWPPluAIqgccGiIeEsIkNe;

					public IControllerElementTarget JpiXZhoXgCfPNJtJyBDKpaqTCLOI;

					public bool HVfcpAROGzpFWuuYJoSHpTnUUmb;

					public bool mDMZcELkXRDZmNvYUejFJxqckgb;

					public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

					public int gmlZVSBTtPIWuYPylEQcoNUGUio;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public Controller MuKtUvsZCBwQyvkWkSbrGdXsygK;

					public GqqVmTmEPnWlhtHJrWWOcCmltOt ZvTvMhIQZJoddQHiZQaYzLcxcoF;

					public int ISxGoEEFVwPxSfkasiHUknEgzEib;

					public int fnpfQuUPJFCbUEcsschjCSrYeTgX;

					public SaFIhRkKoaFsJonuErfrovvvDai RNsMoDsOKXLNxvCdgfOqjEcIPdVs;

					public IList<ControllerMap> WpbttmSmaNLwnhgNsrYHhqMKHej;

					public int AKGjKgAVITpAvWhtYYQsRufumQP;

					public int QrTUTLeotvsPWzAerrGLdmhRdnAK;

					public ControllerMap jyZLIsUFvnJpbBRpfBxStovZYdk;

					public TempListPool.TList<ActionElementMap> zArwaPmmlHqAdcNSOFEEgoPzwaX;

					public List<ActionElementMap> AightdzuzkVWEVKAtZrwweZsGuU;

					public bool DIWeRjdvRrbhrCGQBAinbspaXiis;

					public ActionElementMap uQmxtZcSnCmHvTIomtxFgLupICz;

					public List<ActionElementMap>.Enumerator AXdWSnEUlYknkXyaZVGMWilLbBA;

					ActionElementMap IEnumerator<ActionElementMap>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
					{
						lMZTHluAuWFFEhYQlbROeeVGkLIJ lMZTHluAuWFFEhYQlbROeeVGkLIJ2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							lMZTHluAuWFFEhYQlbROeeVGkLIJ2 = this;
						}
						else
						{
							lMZTHluAuWFFEhYQlbROeeVGkLIJ2 = new lMZTHluAuWFFEhYQlbROeeVGkLIJ(0);
							lMZTHluAuWFFEhYQlbROeeVGkLIJ2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						lMZTHluAuWFFEhYQlbROeeVGkLIJ2.hUCShNLWPPluAIqgccGiIeEsIkNe = JpiXZhoXgCfPNJtJyBDKpaqTCLOI;
						lMZTHluAuWFFEhYQlbROeeVGkLIJ2.HVfcpAROGzpFWuuYJoSHpTnUUmb = mDMZcELkXRDZmNvYUejFJxqckgb;
						lMZTHluAuWFFEhYQlbROeeVGkLIJ2.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = gmlZVSBTtPIWuYPylEQcoNUGUio;
						lMZTHluAuWFFEhYQlbROeeVGkLIJ2.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						return lMZTHluAuWFFEhYQlbROeeVGkLIJ2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							int sRJUeDWyyYFsEaMQQCwxNbjBZLJ = SRJUeDWyyYFsEaMQQCwxNbjBZLJ;
							if (sRJUeDWyyYFsEaMQQCwxNbjBZLJ != 0)
							{
								if (sRJUeDWyyYFsEaMQQCwxNbjBZLJ == 3)
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									goto IL_01aa;
								}
							}
							else
							{
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (hUCShNLWPPluAIqgccGiIeEsIkNe != null)
								{
									MuKtUvsZCBwQyvkWkSbrGdXsygK = hUCShNLWPPluAIqgccGiIeEsIkNe.controller;
									if (MuKtUvsZCBwQyvkWkSbrGdXsygK != null)
									{
										ZvTvMhIQZJoddQHiZQaYzLcxcoF = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(MuKtUvsZCBwQyvkWkSbrGdXsygK.type);
										ISxGoEEFVwPxSfkasiHUknEgzEib = ZvTvMhIQZJoddQHiZQaYzLcxcoF.Count;
										fnpfQuUPJFCbUEcsschjCSrYeTgX = 0;
										goto IL_01f0;
									}
								}
							}
							goto IL_0201;
							IL_0201:
							return false;
							IL_01c3:
							QrTUTLeotvsPWzAerrGLdmhRdnAK++;
							goto IL_01d1;
							IL_01d1:
							if (QrTUTLeotvsPWzAerrGLdmhRdnAK < AKGjKgAVITpAvWhtYYQsRufumQP)
							{
								jyZLIsUFvnJpbBRpfBxStovZYdk = WpbttmSmaNLwnhgNsrYHhqMKHej[QrTUTLeotvsPWzAerrGLdmhRdnAK];
								if (!IftNYOsoyZKKlecDyJEriHNLMeG || jyZLIsUFvnJpbBRpfBxStovZYdk.enabled)
								{
									zArwaPmmlHqAdcNSOFEEgoPzwaX = TempListPool.GetTList<ActionElementMap>();
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									AightdzuzkVWEVKAtZrwweZsGuU = zArwaPmmlHqAdcNSOFEEgoPzwaX.list;
									jyZLIsUFvnJpbBRpfBxStovZYdk.VOIVoTgEPzUDZzgXkQydAIFJfLn(hUCShNLWPPluAIqgccGiIeEsIkNe, HVfcpAROGzpFWuuYJoSHpTnUUmb, aCGiPaCCkBbVoaUFLfEYHFYRMYCM, IftNYOsoyZKKlecDyJEriHNLMeG, AightdzuzkVWEVKAtZrwweZsGuU, true, out DIWeRjdvRrbhrCGQBAinbspaXiis);
									AXdWSnEUlYknkXyaZVGMWilLbBA = AightdzuzkVWEVKAtZrwweZsGuU.GetEnumerator();
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									goto IL_01aa;
								}
								goto IL_01c3;
							}
							fnpfQuUPJFCbUEcsschjCSrYeTgX++;
							goto IL_01f0;
							IL_01aa:
							if (AXdWSnEUlYknkXyaZVGMWilLbBA.MoveNext())
							{
								uQmxtZcSnCmHvTIomtxFgLupICz = AXdWSnEUlYknkXyaZVGMWilLbBA.Current;
								WCNlIsEdYuVTqbNYvICUPcTebLU = uQmxtZcSnCmHvTIomtxFgLupICz;
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
								return true;
							}
							RacyvbbBTwbGNveJxSXswjMVTih();
							IhlkRloWNDtURGJAnjPdBnztYuu();
							goto IL_01c3;
							IL_01f0:
							if (fnpfQuUPJFCbUEcsschjCSrYeTgX < ISxGoEEFVwPxSfkasiHUknEgzEib)
							{
								RNsMoDsOKXLNxvCdgfOqjEcIPdVs = ZvTvMhIQZJoddQHiZQaYzLcxcoF[fnpfQuUPJFCbUEcsschjCSrYeTgX].mapSet;
								_ = RNsMoDsOKXLNxvCdgfOqjEcIPdVs.Count;
								WpbttmSmaNLwnhgNsrYHhqMKHej = RNsMoDsOKXLNxvCdgfOqjEcIPdVs.Maps;
								AKGjKgAVITpAvWhtYYQsRufumQP = WpbttmSmaNLwnhgNsrYHhqMKHej.Count;
								QrTUTLeotvsPWzAerrGLdmhRdnAK = 0;
								goto IL_01d1;
							}
							goto IL_0201;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
						case 3:
							try
							{
								switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
								{
								case 2:
								case 3:
									try
									{
										break;
									}
									finally
									{
										RacyvbbBTwbGNveJxSXswjMVTih();
									}
								}
								break;
							}
							finally
							{
								IhlkRloWNDtURGJAnjPdBnztYuu();
							}
						}
					}

					[DebuggerHidden]
					public lMZTHluAuWFFEhYQlbROeeVGkLIJ(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void IhlkRloWNDtURGJAnjPdBnztYuu()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (zArwaPmmlHqAdcNSOFEEgoPzwaX != null)
						{
							((IDisposable)zArwaPmmlHqAdcNSOFEEgoPzwaX).Dispose();
						}
					}

					private void RacyvbbBTwbGNveJxSXswjMVTih()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						((IDisposable)AXdWSnEUlYknkXyaZVGMWilLbBA/*cast due to .constrained prefix*/).Dispose();
					}
				}

				private readonly zejNqQaBPwGHoSseyBcLZGOKcwt GOguJrGpBEqlHBMupBEEEHaUcNUG;

				private Player UeMLjuGiSFGfRltYoIYxjRdaYAm;

				private ControllerHelper ugKyZyJTGtYLrHpCFnUKcqkaRKt;

				private readonly ControllerMapEnabler MupCGYejeWsSEBqcVYPdTIsHHgRD;

				private readonly ControllerMapLayoutManager sbuoITUoXdJeaRvhYMgSiDznReA;

				private readonly int VumWnlylMgxSbyJcluXptXvaaZa;

				public ControllerMapLayoutManager layoutManager => sbuoITUoXdJeaRvhYMgSiDznReA;

				public ControllerMapEnabler mapEnabler => MupCGYejeWsSEBqcVYPdTIsHHgRD;

				public IList<InputBehavior> InputBehaviors
				{
					get
					{
						if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
						{
							ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
							return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
						}
						return UeMLjuGiSFGfRltYoIYxjRdaYAm.scydGtlzvpdcjviISQJWdAbzZFr.qBAcKkDJYAgrLrUyXSQfoyMaOWli(UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP);
					}
				}

				internal MapHelper(Player player, ControllerHelper parent, zejNqQaBPwGHoSseyBcLZGOKcwt startingControllerMapInfo, ControllerMapLayoutManager.nVKdNlGaejzDgsTfDjPFiRPkzxZ controllerMapLayoutManagerSettings, ControllerMapEnabler.nRwNnlnQOFltouymedybQVFLNDP controllerMapEnablerSettings)
				{
					VumWnlylMgxSbyJcluXptXvaaZa = ReInput.id;
					UeMLjuGiSFGfRltYoIYxjRdaYAm = player;
					ugKyZyJTGtYLrHpCFnUKcqkaRKt = parent;
					GOguJrGpBEqlHBMupBEEEHaUcNUG = startingControllerMapInfo;
					MupCGYejeWsSEBqcVYPdTIsHHgRD = new ControllerMapEnabler(player, controllerMapEnablerSettings);
					sbuoITUoXdJeaRvhYMgSiDznReA = new ControllerMapLayoutManager(player, controllerMapLayoutManagerSettings);
					sbuoITUoXdJeaRvhYMgSiDznReA.ApplyCalledEvent += MupCGYejeWsSEBqcVYPdTIsHHgRD.Apply;
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					TKrmdJfWBFBqFwNebAgvmvwReimI<T>(controllerId, categoryId, layoutId, BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					TKrmdJfWBFBqFwNebAgvmvwReimI<T>(controllerId, categoryName, layoutName, BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					TKrmdJfWBFBqFwNebAgvmvwReimI(controllerType, controllerId, categoryId, layoutId, BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					TKrmdJfWBFBqFwNebAgvmvwReimI(controllerType, controllerId, categoryName, layoutName, BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl);
				}

				public void LoadMap<T>(int controllerId, int categoryId, int layoutId, bool startEnabled) where T : ControllerMap
				{
					TKrmdJfWBFBqFwNebAgvmvwReimI<T>(controllerId, categoryId, layoutId, startEnabled ? BoolOption.dfmxWQCrEtuzIjLyNMeBmQbMSWz : BoolOption.yhIBEUAjGRiGHzBVHxfLpdUuzpd);
				}

				public void LoadMap<T>(int controllerId, string categoryName, string layoutName, bool startEnabled) where T : ControllerMap
				{
					TKrmdJfWBFBqFwNebAgvmvwReimI<T>(controllerId, categoryName, layoutName, startEnabled ? BoolOption.dfmxWQCrEtuzIjLyNMeBmQbMSWz : BoolOption.yhIBEUAjGRiGHzBVHxfLpdUuzpd);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId, bool startEnabled)
				{
					TKrmdJfWBFBqFwNebAgvmvwReimI(controllerType, controllerId, categoryId, layoutId, startEnabled ? BoolOption.dfmxWQCrEtuzIjLyNMeBmQbMSWz : BoolOption.yhIBEUAjGRiGHzBVHxfLpdUuzpd);
				}

				public void LoadMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName, bool startEnabled)
				{
					TKrmdJfWBFBqFwNebAgvmvwReimI(controllerType, controllerId, categoryName, layoutName, startEnabled ? BoolOption.dfmxWQCrEtuzIjLyNMeBmQbMSWz : BoolOption.yhIBEUAjGRiGHzBVHxfLpdUuzpd);
				}

				private void TKrmdJfWBFBqFwNebAgvmvwReimI<T>(int P_0, int P_1, int P_2, BoolOption P_3) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						ALfKBHrGSPAWkDtEuMOSNQcQzDA(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), P_0, P_1, P_2, P_3);
					}
				}

				private void TKrmdJfWBFBqFwNebAgvmvwReimI<T>(int P_0, string P_1, string P_2, BoolOption P_3) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						ALfKBHrGSPAWkDtEuMOSNQcQzDA(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), P_0, P_1, P_2, P_3);
					}
				}

				private void TKrmdJfWBFBqFwNebAgvmvwReimI(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						ALfKBHrGSPAWkDtEuMOSNQcQzDA(P_0, P_1, P_2, P_3, P_4);
					}
				}

				private void TKrmdJfWBFBqFwNebAgvmvwReimI(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						ALfKBHrGSPAWkDtEuMOSNQcQzDA(P_0, P_1, P_2, P_3, P_4);
					}
				}

				public IEnumerable<ControllerMap> GetAllMaps()
				{
					dDDyylvQQWScOGizGPGPZFgdDiO dDDyylvQQWScOGizGPGPZFgdDiO2 = new dDDyylvQQWScOGizGPGPZFgdDiO(-2);
					dDDyylvQQWScOGizGPGPZFgdDiO2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return dDDyylvQQWScOGizGPGPZFgdDiO2;
				}

				public int GetAllMaps(List<ControllerMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					int eBADKEfFkgpzzTponatpcvPGNRUi = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
					for (int i = 0; i < eBADKEfFkgpzzTponatpcvPGNRUi; i++)
					{
						GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(i);
						int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
						for (int j = 0; j < count; j++)
						{
							gqqVmTmEPnWlhtHJrWWOcCmltOt[j].mapSet.gfBmEOaJlorgkCybHFpQvKcqfebg(results, true);
						}
					}
					return results.Count;
				}

				public IEnumerable<T> GetAllMaps<T>() where T : ControllerMap
				{
					EpmsBefYkGxMsyxkxWyqxSexvzC<T> epmsBefYkGxMsyxkxWyqxSexvzC = new EpmsBefYkGxMsyxkxWyqxSexvzC<T>(-2);
					epmsBefYkGxMsyxkxWyqxSexvzC.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return epmsBefYkGxMsyxkxWyqxSexvzC;
				}

				public int GetAllMaps<T>(List<T> results) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (XqmnYoifzflCsKxcFaHDewlkEkh.ctIasoEjDOEPmNnnXJueFDtghIqF<T>(out var controllerType))
					{
						GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType);
						int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
						for (int i = 0; i < count; i++)
						{
							gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.gfBmEOaJlorgkCybHFpQvKcqfebg(results, true);
						}
					}
					else
					{
						int eBADKEfFkgpzzTponatpcvPGNRUi = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
						for (int j = 0; j < eBADKEfFkgpzzTponatpcvPGNRUi; j++)
						{
							GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt2 = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(j);
							int count2 = gqqVmTmEPnWlhtHJrWWOcCmltOt2.Count;
							for (int k = 0; k < count2; k++)
							{
								gqqVmTmEPnWlhtHJrWWOcCmltOt2[k].mapSet.gfBmEOaJlorgkCybHFpQvKcqfebg(results, true);
							}
						}
					}
					return results.Count;
				}

				public IEnumerable<ControllerMap> GetAllMaps(ControllerType controllerType)
				{
					vaqXRiPfXgugvDbjBeBEBBvXoVt vaqXRiPfXgugvDbjBeBEBBvXoVt2 = new vaqXRiPfXgugvDbjBeBEBBvXoVt(-2);
					vaqXRiPfXgugvDbjBeBEBBvXoVt2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					vaqXRiPfXgugvDbjBeBEBBvXoVt2.dCrCLiKKKlaSSJCUCnULxHTQLiPz = controllerType;
					return vaqXRiPfXgugvDbjBeBEBBvXoVt2;
				}

				public int GetAllMaps(ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType);
					int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
					for (int i = 0; i < count; i++)
					{
						gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.gfBmEOaJlorgkCybHFpQvKcqfebg(results, true);
					}
					return results.Count;
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId);
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId)
				{
					awCHfNhIWzAMhalgTrGtneiDqiZ awCHfNhIWzAMhalgTrGtneiDqiZ2 = new awCHfNhIWzAMhalgTrGtneiDqiZ(-2);
					awCHfNhIWzAMhalgTrGtneiDqiZ2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					awCHfNhIWzAMhalgTrGtneiDqiZ2.kHPEEBGwlYJndavghTRnPpnmDafU = categoryId;
					return awCHfNhIWzAMhalgTrGtneiDqiZ2;
				}

				public IEnumerable<T> GetAllMapsInCategory<T>(string categoryName) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return GetAllMapsInCategory<T>(mapCategoryId);
				}

				public IEnumerable<T> GetAllMapsInCategory<T>(int categoryId) where T : ControllerMap
				{
					ffyrMHEovQdezjEFSLCFjcyxZRA<T> ffyrMHEovQdezjEFSLCFjcyxZRA2 = new ffyrMHEovQdezjEFSLCFjcyxZRA<T>(-2);
					ffyrMHEovQdezjEFSLCFjcyxZRA2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					ffyrMHEovQdezjEFSLCFjcyxZRA2.kHPEEBGwlYJndavghTRnPpnmDafU = categoryId;
					return ffyrMHEovQdezjEFSLCFjcyxZRA2;
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(string categoryName, ControllerType controllerType)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return new List<ControllerMap>();
					}
					return GetAllMapsInCategory(mapCategoryId, controllerType);
				}

				public IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId, ControllerType controllerType)
				{
					QztIjuDSOUegBZEMHGDBqhpUjX qztIjuDSOUegBZEMHGDBqhpUjX = new QztIjuDSOUegBZEMHGDBqhpUjX(-2);
					qztIjuDSOUegBZEMHGDBqhpUjX.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					qztIjuDSOUegBZEMHGDBqhpUjX.kHPEEBGwlYJndavghTRnPpnmDafU = categoryId;
					qztIjuDSOUegBZEMHGDBqhpUjX.dCrCLiKKKlaSSJCUCnULxHTQLiPz = controllerType;
					return qztIjuDSOUegBZEMHGDBqhpUjX;
				}

				public int GetAllMapsInCategory(string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetAllMapsInCategory(mapCategoryId, results);
				}

				public int GetAllMapsInCategory(int categoryId, List<ControllerMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					int eBADKEfFkgpzzTponatpcvPGNRUi = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
					for (int i = 0; i < eBADKEfFkgpzzTponatpcvPGNRUi; i++)
					{
						GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(i);
						int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
						for (int j = 0; j < count; j++)
						{
							gqqVmTmEPnWlhtHJrWWOcCmltOt[j].mapSet.ctovEHmRefuhMZmHMxOfiJlbBW(categoryId, results, true);
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory<T>(string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetAllMapsInCategory(mapCategoryId, results);
				}

				public int GetAllMapsInCategory<T>(int categoryId, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					if (XqmnYoifzflCsKxcFaHDewlkEkh.ctIasoEjDOEPmNnnXJueFDtghIqF<T>(out var controllerType))
					{
						GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType);
						int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
						for (int i = 0; i < count; i++)
						{
							gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.ctovEHmRefuhMZmHMxOfiJlbBW(categoryId, results, true);
						}
					}
					else
					{
						int eBADKEfFkgpzzTponatpcvPGNRUi = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
						for (int j = 0; j < eBADKEfFkgpzzTponatpcvPGNRUi; j++)
						{
							GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt2 = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(j);
							int count2 = gqqVmTmEPnWlhtHJrWWOcCmltOt2.Count;
							for (int k = 0; k < count2; k++)
							{
								gqqVmTmEPnWlhtHJrWWOcCmltOt2[k].mapSet.ctovEHmRefuhMZmHMxOfiJlbBW(categoryId, results, true);
							}
						}
					}
					return results.Count;
				}

				public int GetAllMapsInCategory(string categoryName, ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetAllMapsInCategory(mapCategoryId, controllerType, results);
				}

				public int GetAllMapsInCategory(int categoryId, ControllerType controllerType, List<ControllerMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType);
					int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
					for (int i = 0; i < count; i++)
					{
						gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.ctovEHmRefuhMZmHMxOfiJlbBW(categoryId, results, true);
					}
					return results.Count;
				}

				public IList<T> GetMaps<T>(int controllerId) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return UtKxnnWSTpRHmpFhxSxDoRrdOH<T>(controllerId);
				}

				public IList<ControllerMap> GetMaps(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return UtKxnnWSTpRHmpFhxSxDoRrdOH(controllerType, controllerId);
				}

				public IList<ControllerMap> GetMaps(Controller controller)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return GetMaps(controller.type, controller.id);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, int categoryId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controllerId < 0 || categoryId < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return cAAxqLTlTxwHzdoSsfJTNFsEgGvk(controllerType, controllerId, categoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return GetMapsInCategory(controllerType, controllerId, mapCategoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(Controller controller, int categoryId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return GetMapsInCategory(controller.type, controller.id, categoryId);
				}

				public IEnumerable<ControllerMap> GetMapsInCategory(Controller controller, string categoryName)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return GetMapsInCategory(controller.type, controller.id, mapCategoryId);
				}

				public int GetMapsInCategory(ControllerType controllerType, int controllerId, int categoryId, List<ControllerMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					ListTools.TryClear(results);
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					if (controllerId < 0 || categoryId < 0)
					{
						return 0;
					}
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType).CXouiQVNNifvOhfkUWFfiMKCNFx(controllerId)?.mapSet.ctovEHmRefuhMZmHMxOfiJlbBW(categoryId, results, false) ?? 0;
				}

				public int GetMapsInCategory(ControllerType controllerType, int controllerId, string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					ListTools.TryClear(results);
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetMapsInCategory(controllerType, controllerId, mapCategoryId, results);
				}

				public int GetMapsInCategory(Controller controller, int categoryId, List<ControllerMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					ListTools.TryClear(results);
					if (controller == null)
					{
						return 0;
					}
					return GetMapsInCategory(controller.type, controller.id, categoryId, results);
				}

				public int GetMapsInCategory(Controller controller, string categoryName, List<ControllerMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					ListTools.TryClear(results);
					if (controller == null)
					{
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetMapsInCategory(controller.type, controller.id, mapCategoryId, results);
				}

				public IEnumerable<T> GetMapsInCategory<T>(int controllerId, int categoryId) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return cAAxqLTlTxwHzdoSsfJTNFsEgGvk<T>(controllerId, categoryId);
				}

				public IEnumerable<T> GetMapsInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return GetMapsInCategory<T>(controllerId, mapCategoryId);
				}

				public int GetMapsInCategory<T>(int controllerId, int categoryId, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					results.Clear();
					if (ReInput.mapping.GetMapCategory(categoryId) == null)
					{
						return 0;
					}
					LEYwjXNPaJjLrFHUDPJUhWSYyxmR lEYwjXNPaJjLrFHUDPJUhWSYyxmR = HKsQgrgAzvFmgvjbLwphvDQOADyD<T>().CXouiQVNNifvOhfkUWFfiMKCNFx(controllerId);
					if (lEYwjXNPaJjLrFHUDPJUhWSYyxmR == null)
					{
						return 0;
					}
					lEYwjXNPaJjLrFHUDPJUhWSYyxmR.mapSet.ctovEHmRefuhMZmHMxOfiJlbBW(categoryId, results, true);
					return results.Count;
				}

				public int GetMapsInCategory<T>(int controllerId, string categoryName, List<T> results) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					ListTools.TryClear(results);
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return GetMapsInCategory(controllerId, mapCategoryId, results);
				}

				public T GetMap<T>(int controllerId, int mapId) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return (T)ZbeejXdnhjohgiTBODgmgtVfAsH(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), controllerId, mapId);
				}

				public T GetMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return (T)ZbeejXdnhjohgiTBODgmgtVfAsH(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), controllerId, categoryId, layoutId);
				}

				public T GetMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return (T)ZbeejXdnhjohgiTBODgmgtVfAsH(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(int mapId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					int eBADKEfFkgpzzTponatpcvPGNRUi = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
					for (int i = 0; i < eBADKEfFkgpzzTponatpcvPGNRUi; i++)
					{
						GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(i);
						int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
						for (int j = 0; j < count; j++)
						{
							SaFIhRkKoaFsJonuErfrovvvDai mapSet = gqqVmTmEPnWlhtHJrWWOcCmltOt[j].mapSet;
							ControllerMap controllerMap = mapSet.udmVdEorzIEcZerNtLKGkDteaniA(mapId);
							if (controllerMap != null)
							{
								return controllerMap;
							}
						}
					}
					return null;
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, int mapId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (mapId < 0)
					{
						return null;
					}
					return ZbeejXdnhjohgiTBODgmgtVfAsH(controllerType, controllerId, mapId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return ZbeejXdnhjohgiTBODgmgtVfAsH(controllerType, controllerId, categoryId, layoutId);
				}

				public ControllerMap GetMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return ZbeejXdnhjohgiTBODgmgtVfAsH(controllerType, controllerId, categoryName, layoutName);
				}

				public ControllerMap GetMap(Controller controller, int mapId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetMap(controller.type, controller.id, mapId);
				}

				public ControllerMap GetMap(Controller controller, int categoryId, int layoutId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetMap(controller.type, controller.id, categoryId, layoutId);
				}

				public ControllerMap GetMap(Controller controller, string categoryName, string layoutName)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetMap(controller.type, controller.id, categoryName, layoutName);
				}

				public T GetFirstMapInCategory<T>(int controllerId, string categoryName) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return GetFirstMapInCategory<T>(controllerId, mapCategoryId);
				}

				public T GetFirstMapInCategory<T>(int controllerId, int categoryId) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return (T)GkJELcHkumiUacFCrPAUMSpyDiC(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, string categoryName)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return GetFirstMapInCategory(controllerType, controllerId, mapCategoryId);
				}

				public ControllerMap GetFirstMapInCategory(ControllerType controllerType, int controllerId, int categoryId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (categoryId < 0)
					{
						return null;
					}
					return GkJELcHkumiUacFCrPAUMSpyDiC(controllerType, controllerId, categoryId);
				}

				public ControllerMap GetFirstMapInCategory(Controller controller, string categoryName)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetFirstMapInCategory(controller.type, controller.id, categoryName);
				}

				public ControllerMap GetFirstMapInCategory(Controller controller, int categoryId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return GetFirstMapInCategory(controller.type, controller.id, categoryId);
				}

				public void AddMap<T>(int controllerId, ControllerMap map) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						ZgRbWiATNlFeprkZvUUfmMFFOxgw(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), controllerId, map, BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl);
					}
				}

				public void AddMap(Controller controller, ControllerMap map)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						ZgRbWiATNlFeprkZvUUfmMFFOxgw(controller, map, BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						ZgRbWiATNlFeprkZvUUfmMFFOxgw(controllerType, controllerId, map, BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl);
					}
				}

				public void AddMap<T>(int controllerId, ControllerMap map, bool startEnabled) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						ZgRbWiATNlFeprkZvUUfmMFFOxgw(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), controllerId, map, startEnabled ? BoolOption.dfmxWQCrEtuzIjLyNMeBmQbMSWz : BoolOption.yhIBEUAjGRiGHzBVHxfLpdUuzpd);
					}
				}

				public void AddMap(Controller controller, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						ZgRbWiATNlFeprkZvUUfmMFFOxgw(controller, map, startEnabled ? BoolOption.dfmxWQCrEtuzIjLyNMeBmQbMSWz : BoolOption.yhIBEUAjGRiGHzBVHxfLpdUuzpd);
					}
				}

				public void AddMap(ControllerType controllerType, int controllerId, ControllerMap map, bool startEnabled)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						ZgRbWiATNlFeprkZvUUfmMFFOxgw(controllerType, controllerId, map, startEnabled ? BoolOption.dfmxWQCrEtuzIjLyNMeBmQbMSWz : BoolOption.yhIBEUAjGRiGHzBVHxfLpdUuzpd);
					}
				}

				public bool AddMapFromXml<T>(int controllerId, string xmlString) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					return SowESkNTKeJSbuZrUIWVsXCwOEm(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), controllerId, xmlString);
				}

				public bool AddMapFromXml(ControllerType controllerType, int controllerId, string xmlString)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					return SowESkNTKeJSbuZrUIWVsXCwOEm(controllerType, controllerId, xmlString);
				}

				public int AddMapsFromXml<T>(int controllerId, List<string> xmlStrings) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (xmlStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < xmlStrings.Count; i++)
					{
						if (AddMapFromXml<T>(controllerId, xmlStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				public int AddMapsFromXml(ControllerType controllerType, int controllerId, List<string> xmlStrings)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (xmlStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < xmlStrings.Count; i++)
					{
						if (AddMapFromXml(controllerType, controllerId, xmlStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				public bool AddMapFromJson<T>(int controllerId, string jsonString) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					return HGCfZrGdhmzyPFEVovflpnBMwEL(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), controllerId, jsonString);
				}

				public bool AddMapFromJson(ControllerType controllerType, int controllerId, string jsonString)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					return HGCfZrGdhmzyPFEVovflpnBMwEL(controllerType, controllerId, jsonString);
				}

				public int AddMapsFromJson<T>(int controllerId, List<string> jsonStrings) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (jsonStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < jsonStrings.Count; i++)
					{
						if (AddMapFromJson<T>(controllerId, jsonStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				public int AddMapsFromJson(ControllerType controllerType, int controllerId, List<string> jsonStrings)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (jsonStrings == null)
					{
						return 0;
					}
					int num = 0;
					for (int i = 0; i < jsonStrings.Count; i++)
					{
						if (AddMapFromJson(controllerType, controllerId, jsonStrings[i]))
						{
							num++;
						}
					}
					return num;
				}

				public void AddEmptyMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						eQaCrHCSVASOaMPBJqPxpVssUXoP(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						eQaCrHCSVASOaMPBJqPxpVssUXoP(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						eQaCrHCSVASOaMPBJqPxpVssUXoP(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void AddEmptyMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						AddEmptyMap(controllerType, controllerId, mapCategoryId, layoutId);
					}
				}

				public void RemoveMap<T>(int controllerId, int mapId) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else if (mapId >= 0)
					{
						WIbIDoGKOAeuuCIwaCRqPWnmUwL(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), controllerId, mapId);
					}
				}

				public void RemoveMap<T>(int controllerId, int categoryId, int layoutId) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						WIbIDoGKOAeuuCIwaCRqPWnmUwL(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap<T>(int controllerId, string categoryName, string layoutName) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						WIbIDoGKOAeuuCIwaCRqPWnmUwL(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), controllerId, categoryName, layoutName);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int mapId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else if (mapId >= 0)
					{
						WIbIDoGKOAeuuCIwaCRqPWnmUwL(controllerType, controllerId, mapId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, int categoryId, int layoutId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else if (categoryId >= 0 && layoutId >= 0)
					{
						WIbIDoGKOAeuuCIwaCRqPWnmUwL(controllerType, controllerId, categoryId, layoutId);
					}
				}

				public void RemoveMap(ControllerType controllerType, int controllerId, string categoryName, string layoutName)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						WIbIDoGKOAeuuCIwaCRqPWnmUwL(controllerType, controllerId, categoryName, layoutName);
					}
				}

				public void ClearMaps<T>(bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						ClearMaps(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), userAssignableOnly);
					}
				}

				public void ClearMaps(ControllerType controllerType, bool userAssignableOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType);
					for (int i = 0; i < gqqVmTmEPnWlhtHJrWWOcCmltOt.Count; i++)
					{
						gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.VcHhfbFqwxAmqhwBHKVJpDjlfufe(userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						ClearMapsInCategory(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsInCategory<T>(mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(int categoryId, int layoutId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						ClearMapsInCategory(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), categoryId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory<T>(string categoryName, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						int layoutId = ReInput.mapping.GetLayoutId(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), layoutName);
						if (layoutId >= 0)
						{
							ClearMapsInCategory<T>(mapCategoryId, layoutId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					int eBADKEfFkgpzzTponatpcvPGNRUi = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
					for (int i = 0; i < eBADKEfFkgpzzTponatpcvPGNRUi; i++)
					{
						GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.PJmyOahSkMBgfbHBeqRHjtHEWWb(i));
						for (int j = 0; j < gqqVmTmEPnWlhtHJrWWOcCmltOt.Count; j++)
						{
							gqqVmTmEPnWlhtHJrWWOcCmltOt[j].mapSet.VcHhfbFqwxAmqhwBHKVJpDjlfufe(categoryId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInCategory(string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsInCategory(mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType);
					for (int i = 0; i < gqqVmTmEPnWlhtHJrWWOcCmltOt.Count; i++)
					{
						gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.VcHhfbFqwxAmqhwBHKVJpDjlfufe(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsInCategory(controllerType, mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, int categoryId, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					InputCategory mapCategory = ReInput.mapping.GetMapCategory(categoryId);
					if (mapCategory != null && (!userAssignableOnly || mapCategory.userAssignable))
					{
						GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType);
						for (int i = 0; i < gqqVmTmEPnWlhtHJrWWOcCmltOt.Count; i++)
						{
							gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.tsiIiRnEIKEeGXdmsiYIGAemsrcr(categoryId, layoutId);
						}
					}
				}

				public void ClearMapsInCategory(ControllerType controllerType, string categoryName, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
						if (layoutId >= 0)
						{
							ClearMapsInCategory(controllerType, mapCategoryId, layoutId, userAssignableOnly);
						}
					}
				}

				public void ClearMapsInLayout<T>(int layoutId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						ClearMapsInLayout(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout<T>(string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsInLayout<T>(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType);
					for (int i = 0; i < gqqVmTmEPnWlhtHJrWWOcCmltOt.Count; i++)
					{
						gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.APfnciKbZAKnDvZgxMizIpBeGyt(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsInLayout(ControllerType controllerType, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId >= 0)
					{
						ClearMapsInLayout(controllerType, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						ClearMapsForController(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), controllerId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, int categoryId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						ClearMapsForController(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), controllerId, categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController<T>(int controllerId, string categoryName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsForController<T>(controllerId, mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, bool userAssignableOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(controllerId);
					if (num >= 0)
					{
						gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.VcHhfbFqwxAmqhwBHKVJpDjlfufe(userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, int categoryId, bool userAssignableOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(controllerId);
					if (num >= 0)
					{
						gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.VcHhfbFqwxAmqhwBHKVJpDjlfufe(categoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForController(ControllerType controllerType, int controllerId, string categoryName, bool userAssignableOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId >= 0)
					{
						ClearMapsForController(controllerType, controllerId, mapCategoryId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout<T>(int controllerId, int layoutId, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						ClearMapsForControllerInLayout(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout<T>(int controllerId, string layoutName, bool userAssignableOnly) where T : ControllerMap
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>(), layoutName);
					if (layoutId >= 0)
					{
						ClearMapsForControllerInLayout<T>(controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, int layoutId, bool userAssignableOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(controllerId);
					if (num >= 0)
					{
						gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.APfnciKbZAKnDvZgxMizIpBeGyt(layoutId, userAssignableOnly);
					}
				}

				public void ClearMapsForControllerInLayout(ControllerType controllerType, int controllerId, string layoutName, bool userAssignableOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId >= 0)
					{
						ClearMapsForControllerInLayout(controllerType, controllerId, layoutId, userAssignableOnly);
					}
				}

				public void ClearAllMaps(bool userAssignableOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi; i++)
					{
						ClearMaps(ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.PJmyOahSkMBgfbHBeqRHjtHEWWb(i), userAssignableOnly);
					}
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return GetFirstButtonMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return GetFirstButtonMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return HQCvgOgHBlHmLDcXvnABIrshlfPs(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetFirstButtonMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return HQCvgOgHBlHmLDcXvnABIrshlfPs(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetFirstButtonMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi; i++)
					{
						ActionElementMap actionElementMap = HQCvgOgHBlHmLDcXvnABIrshlfPs(ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.PJmyOahSkMBgfbHBeqRHjtHEWWb(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return ButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return ButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return zPEKOFqazJeovddkukteneDsutd(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return ButtonMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return zPEKOFqazJeovddkukteneDsutd(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return ButtonMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					EWrEopscmUMLVkKxHJOMvLMSRUM eWrEopscmUMLVkKxHJOMvLMSRUM = new EWrEopscmUMLVkKxHJOMvLMSRUM(-2);
					eWrEopscmUMLVkKxHJOMvLMSRUM.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					eWrEopscmUMLVkKxHJOMvLMSRUM.gmlZVSBTtPIWuYPylEQcoNUGUio = actionId;
					eWrEopscmUMLVkKxHJOMvLMSRUM.TGDalxAGxtEWicADkzmraNyMfPny = skipDisabledMaps;
					return eWrEopscmUMLVkKxHJOMvLMSRUM;
				}

				public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return ButtonMapsWithAction(actionId, skipDisabledMaps);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetButtonMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					if (controller == null)
					{
						results.Clear();
						return 0;
					}
					return dDTksWbQeoRPPFliOyNECYyeJbf(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetButtonMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					return dDTksWbQeoRPPFliOyNECYyeJbf(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetButtonMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return EwxUCWIjgNvgwPkYWOoxwAiADEI(actionId, skipDisabledMaps, results, false);
				}

				public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetButtonMapsWithAction(actionId, skipDisabledMaps, results);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return GetFirstAxisMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return GetFirstAxisMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return ZQYPuRnWvyLQjUgCvQEbpRlJbgvb(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetFirstAxisMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return ZQYPuRnWvyLQjUgCvQEbpRlJbgvb(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetFirstAxisMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi; i++)
					{
						ActionElementMap actionElementMap = ZQYPuRnWvyLQjUgCvQEbpRlJbgvb(ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.PJmyOahSkMBgfbHBeqRHjtHEWWb(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return AxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return AxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return cFbSIfVtfUAAumzIUedwVhCWhkA(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return AxisMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return cFbSIfVtfUAAumzIUedwVhCWhkA(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return AxisMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					IMNgPGONEWasPVwLXyblKOpzqoc iMNgPGONEWasPVwLXyblKOpzqoc = new IMNgPGONEWasPVwLXyblKOpzqoc(-2);
					iMNgPGONEWasPVwLXyblKOpzqoc.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					iMNgPGONEWasPVwLXyblKOpzqoc.gmlZVSBTtPIWuYPylEQcoNUGUio = actionId;
					iMNgPGONEWasPVwLXyblKOpzqoc.TGDalxAGxtEWicADkzmraNyMfPny = skipDisabledMaps;
					return iMNgPGONEWasPVwLXyblKOpzqoc;
				}

				public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return AxisMapsWithAction(actionId, skipDisabledMaps);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetAxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetAxisMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return OpTXrUQqOmFypxKzfhOyCmXqSlp(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetAxisMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (results == null)
					{
						throw new ArgumentNullException("results");
					}
					return OpTXrUQqOmFypxKzfhOyCmXqSlp(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetAxisMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return OPLgbMnDTUePxNEOivAOYPYzSya(actionId, skipDisabledMaps, results, false);
				}

				public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetAxisMapsWithAction(actionId, skipDisabledMaps, results);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return GetFirstElementMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return GetFirstElementMapWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (controller == null)
					{
						return null;
					}
					return DlavhuHGsniKsejEvEhSSMppMwF(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetFirstElementMapWithAction(controller, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return DlavhuHGsniKsejEvEhSSMppMwF(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetFirstElementMapWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					if (actionId < 0)
					{
						return null;
					}
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi; i++)
					{
						ActionElementMap actionElementMap = DlavhuHGsniKsejEvEhSSMppMwF(ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.PJmyOahSkMBgfbHBeqRHjtHEWWb(i), actionId, skipDisabledMaps);
						if (actionElementMap != null)
						{
							return actionElementMap;
						}
					}
					return null;
				}

				public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps)
				{
					return ElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps)
				{
					return ElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					if (controller == null)
					{
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return wAyIcjGTjfmHWUkrwDEAMBzILaTI(controller.type, controller.id, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return ElementMapsWithAction(controller, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					return wAyIcjGTjfmHWUkrwDEAMBzILaTI(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return ElementMapsWithAction(controllerType, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
				{
					YoPCXohQmtrXMGOivtZkUvBhpDB yoPCXohQmtrXMGOivtZkUvBhpDB = new YoPCXohQmtrXMGOivtZkUvBhpDB(-2);
					yoPCXohQmtrXMGOivtZkUvBhpDB.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					yoPCXohQmtrXMGOivtZkUvBhpDB.gmlZVSBTtPIWuYPylEQcoNUGUio = actionId;
					yoPCXohQmtrXMGOivtZkUvBhpDB.TGDalxAGxtEWicADkzmraNyMfPny = skipDisabledMaps;
					return yoPCXohQmtrXMGOivtZkUvBhpDB;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return ElementMapsWithAction(actionId, skipDisabledMaps);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, int controllerId, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return GetElementMapsWithAction(ReInput.controllers.GetController(controllerType, controllerId), actionName, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(Controller controller, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return KtPnmXjUixAFlwRskKIqsCmTKsY(controller.type, controller.id, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(Controller controller, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetElementMapsWithAction(controller, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					return KtPnmXjUixAFlwRskKIqsCmTKsY(controllerType, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(ControllerType controllerType, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetElementMapsWithAction(controllerType, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return paPqgnqavLYCqgponTssufOHcpc(actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					rRNhjRpfbeHXdDjgkCEeGsrflVcU rRNhjRpfbeHXdDjgkCEeGsrflVcU2 = rRNhjRpfbeHXdDjgkCEeGsrflVcU.MyFdjCFHrgeFWbyjPuCXTirWPhx(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(rRNhjRpfbeHXdDjgkCEeGsrflVcU2, skipDisabledMaps);
					rRNhjRpfbeHXdDjgkCEeGsrflVcU.PwDnEpwWkKKCZSBeZgjNATJwzAK(rRNhjRpfbeHXdDjgkCEeGsrflVcU2);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return kjgLeqeVgoWsZfALHXWvGkZmDAM(elementTarget, false, -1, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					rRNhjRpfbeHXdDjgkCEeGsrflVcU rRNhjRpfbeHXdDjgkCEeGsrflVcU2 = rRNhjRpfbeHXdDjgkCEeGsrflVcU.MyFdjCFHrgeFWbyjPuCXTirWPhx(elementTarget);
					IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(rRNhjRpfbeHXdDjgkCEeGsrflVcU2, actionId, skipDisabledMaps);
					rRNhjRpfbeHXdDjgkCEeGsrflVcU.PwDnEpwWkKKCZSBeZgjNATJwzAK(rRNhjRpfbeHXdDjgkCEeGsrflVcU2);
					return result;
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return kjgLeqeVgoWsZfALHXWvGkZmDAM(elementTarget, true, actionId, skipDisabledMaps);
				}

				public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					rRNhjRpfbeHXdDjgkCEeGsrflVcU rRNhjRpfbeHXdDjgkCEeGsrflVcU2 = rRNhjRpfbeHXdDjgkCEeGsrflVcU.MyFdjCFHrgeFWbyjPuCXTirWPhx(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(rRNhjRpfbeHXdDjgkCEeGsrflVcU2, skipDisabledMaps);
					rRNhjRpfbeHXdDjgkCEeGsrflVcU.PwDnEpwWkKKCZSBeZgjNATJwzAK(rRNhjRpfbeHXdDjgkCEeGsrflVcU2);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
				{
					return TythgSbwYmNijsQNDAZZfufNFdk(elementTarget, false, -1, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					rRNhjRpfbeHXdDjgkCEeGsrflVcU rRNhjRpfbeHXdDjgkCEeGsrflVcU2 = rRNhjRpfbeHXdDjgkCEeGsrflVcU.MyFdjCFHrgeFWbyjPuCXTirWPhx(elementTarget);
					ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(rRNhjRpfbeHXdDjgkCEeGsrflVcU2, actionId, skipDisabledMaps);
					rRNhjRpfbeHXdDjgkCEeGsrflVcU.PwDnEpwWkKKCZSBeZgjNATJwzAK(rRNhjRpfbeHXdDjgkCEeGsrflVcU2);
					return firstElementMapWithElementTarget;
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
				{
					return TythgSbwYmNijsQNDAZZfufNFdk(elementTarget, true, actionId, skipDisabledMaps);
				}

				public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					rRNhjRpfbeHXdDjgkCEeGsrflVcU rRNhjRpfbeHXdDjgkCEeGsrflVcU2 = rRNhjRpfbeHXdDjgkCEeGsrflVcU.MyFdjCFHrgeFWbyjPuCXTirWPhx(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(rRNhjRpfbeHXdDjgkCEeGsrflVcU2, skipDisabledMaps, results);
					rRNhjRpfbeHXdDjgkCEeGsrflVcU.PwDnEpwWkKKCZSBeZgjNATJwzAK(rRNhjRpfbeHXdDjgkCEeGsrflVcU2);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return VOIVoTgEPzUDZzgXkQydAIFJfLn(elementTarget, false, -1, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					rRNhjRpfbeHXdDjgkCEeGsrflVcU rRNhjRpfbeHXdDjgkCEeGsrflVcU2 = rRNhjRpfbeHXdDjgkCEeGsrflVcU.MyFdjCFHrgeFWbyjPuCXTirWPhx(elementTarget);
					int elementMapsWithElementTarget = GetElementMapsWithElementTarget(rRNhjRpfbeHXdDjgkCEeGsrflVcU2, actionId, skipDisabledMaps, results);
					rRNhjRpfbeHXdDjgkCEeGsrflVcU.PwDnEpwWkKKCZSBeZgjNATJwzAK(rRNhjRpfbeHXdDjgkCEeGsrflVcU2);
					return elementMapsWithElementTarget;
				}

				public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					return VOIVoTgEPzUDZzgXkQydAIFJfLn(elementTarget, true, actionId, skipDisabledMaps, results, false);
				}

				public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
					return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
				}

				public T[] GetMapSaveData<T>(int controllerId, bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<T>.array;
					}
					return kmPZUPMNpgUcCQUIqJutLEqJyTF<T>(controllerId, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetMapSaveData(ControllerType controllerType, int controllerId, bool userAssignableMapsOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return kmPZUPMNpgUcCQUIqJutLEqJyTF(controllerType, controllerId, userAssignableMapsOnly);
				}

				public T[] GetAllMapSaveData<T>(bool userAssignableMapsOnly) where T : ControllerMapSaveData
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<T>.array;
					}
					return wJRkFBTAxkTZteGkYqLkPfBlWhc<T>(userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(ControllerType controllerType, bool userAssignableMapsOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					return wJRkFBTAxkTZteGkYqLkPfBlWhc(controllerType, userAssignableMapsOnly);
				}

				public ControllerMapSaveData[] GetAllMapSaveData(bool userAssignableMapsOnly)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerMapSaveData>.array;
					}
					ControllerMapSaveData[] array = null;
					for (int i = 0; i < ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi; i++)
					{
						ArrayTools.Combine(ref array, wJRkFBTAxkTZteGkYqLkPfBlWhc(ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.PJmyOahSkMBgfbHBeqRHjtHEWWb(i), userAssignableMapsOnly));
					}
					return array;
				}

				public int SetAllMapsEnabled(bool state)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int num = 0;
					int eBADKEfFkgpzzTponatpcvPGNRUi = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
					for (int i = 0; i < eBADKEfFkgpzzTponatpcvPGNRUi; i++)
					{
						GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(i);
						int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
						for (int j = 0; j < count; j++)
						{
							num += gqqVmTmEPnWlhtHJrWWOcCmltOt[j].mapSet.TMTRFFbUglRweOoVDedwgVjGhZb(state);
						}
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, ControllerType controllerType)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int num = 0;
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType);
					int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
					for (int i = 0; i < count; i++)
					{
						num += gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.TMTRFFbUglRweOoVDedwgVjGhZb(state);
					}
					return num;
				}

				public int SetAllMapsEnabled(bool state, Controller controller)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					return SetAllMapsEnabled(state, controller.type, controller.id);
				}

				public int SetAllMapsEnabled(bool state, ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType).CXouiQVNNifvOhfkUWFfiMKCNFx(controllerId)?.mapSet.TMTRFFbUglRweOoVDedwgVjGhZb(state) ?? 0;
				}

				public int SetMapsEnabled(bool state, int categoryId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int eBADKEfFkgpzzTponatpcvPGNRUi = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
					for (int i = 0; i < eBADKEfFkgpzzTponatpcvPGNRUi; i++)
					{
						GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(i);
						int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
						for (int j = 0; j < count; j++)
						{
							num += gqqVmTmEPnWlhtHJrWWOcCmltOt[j].mapSet.ESPaHOKBIJhjnwmmBBmzpjSLsqj(state, categoryId);
						}
					}
					return num;
				}

				public int SetMapsEnabled(bool state, string categoryName)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, mapCategoryId);
				}

				public int SetMapsEnabled(bool state, string categoryName, string layoutName)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int num = 0;
					int eBADKEfFkgpzzTponatpcvPGNRUi = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
					for (int i = 0; i < eBADKEfFkgpzzTponatpcvPGNRUi; i++)
					{
						ControllerType controllerType = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.PJmyOahSkMBgfbHBeqRHjtHEWWb(i);
						int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
						if (layoutId >= 0)
						{
							num += SetMapsEnabled(state, controllerType, mapCategoryId, layoutId);
						}
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, int categoryId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					int num = 0;
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType);
					int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
					for (int i = 0; i < count; i++)
					{
						num += gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.ESPaHOKBIJhjnwmmBBmzpjSLsqj(state, categoryId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, controllerType, mapCategoryId);
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, int categoryId, int layoutId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (categoryId < 0 || layoutId < 0)
					{
						return 0;
					}
					int num = 0;
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType);
					int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
					for (int i = 0; i < count; i++)
					{
						num += gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.ESPaHOKBIJhjnwmmBBmzpjSLsqj(state, categoryId, layoutId);
					}
					return num;
				}

				public int SetMapsEnabled(bool state, ControllerType controllerType, string categoryName, string layoutName)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controllerType, layoutName);
					if (layoutId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, controllerType, mapCategoryId, layoutId);
				}

				public int SetMapsEnabled(bool state, Controller controller, int categoryId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controller.type).CXouiQVNNifvOhfkUWFfiMKCNFx(controller.id)?.mapSet.ESPaHOKBIJhjnwmmBBmzpjSLsqj(state, categoryId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, int categoryId, int layoutId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					if (categoryId < 0)
					{
						return 0;
					}
					if (layoutId < 0)
					{
						return 0;
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controller.type).CXouiQVNNifvOhfkUWFfiMKCNFx(controller.id)?.mapSet.ESPaHOKBIJhjnwmmBBmzpjSLsqj(state, categoryId, layoutId) ?? 0;
				}

				public int SetMapsEnabled(bool state, Controller controller, string categoryName)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, controller, mapCategoryId);
				}

				public int SetMapsEnabled(bool state, Controller controller, string categoryName, string layoutName)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					if (controller == null)
					{
						return 0;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					int layoutId = ReInput.mapping.GetLayoutId(controller.type, layoutName);
					if (layoutId < 0)
					{
						return 0;
					}
					return SetMapsEnabled(state, controller, mapCategoryId, layoutId);
				}

				public void LoadDefaultMaps(ControllerType controllerType)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						HYSNpqOxyLYdbvIwQQGaXyTZow(false);
						break;
					case ControllerType.Keyboard:
						nzrwhfDOuQHLskLeCNZfYRjspZE(false);
						break;
					case ControllerType.Mouse:
						cWaujwSKNUVkNCcDOOnpVQUKrzM(false);
						break;
					case ControllerType.Custom:
						ZgwLfVQFDeKnjEbfhyHdEbMRkuZ(false);
						break;
					default:
						throw new NotImplementedException();
					}
				}

				public bool ContainsMapInCategory(InputMapCategory category)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					if (category == null)
					{
						return false;
					}
					return ContainsMapInCategory(category.id);
				}

				public bool ContainsMapInCategory(int categoryId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					int eBADKEfFkgpzzTponatpcvPGNRUi = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
					for (int i = 0; i < eBADKEfFkgpzzTponatpcvPGNRUi; i++)
					{
						GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(i);
						int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
						for (int j = 0; j < count; j++)
						{
							if (gqqVmTmEPnWlhtHJrWWOcCmltOt[j].mapSet.nHAVCbxGMaTfEbWjhXgVDIemaqf(categoryId))
							{
								return true;
							}
						}
					}
					return false;
				}

				public bool ContainsMapInCategory(string categoryName)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(categoryName);
					if (mapCategoryId < 0)
					{
						return false;
					}
					return ContainsMapInCategory(mapCategoryId);
				}

				public bool ContainsMapInCategory(ControllerType controllerType, int categoryId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					if (categoryId < 0)
					{
						return false;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType);
					int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
					for (int i = 0; i < count; i++)
					{
						if (gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.nHAVCbxGMaTfEbWjhXgVDIemaqf(categoryId))
						{
							return true;
						}
					}
					return false;
				}

				public InputBehavior GetInputBehavior(int behaviorId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return UeMLjuGiSFGfRltYoIYxjRdaYAm.scydGtlzvpdcjviISQJWdAbzZFr.tTnDGLKfHmwwnZlLMmzdSgXpidO(UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP, behaviorId);
				}

				public InputBehavior GetInputBehavior(string behaviorName)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return UeMLjuGiSFGfRltYoIYxjRdaYAm.scydGtlzvpdcjviISQJWdAbzZFr.tTnDGLKfHmwwnZlLMmzdSgXpidO(UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP, behaviorName);
				}

				internal void iDBXctPcOcjjzWbKaCnxuPiVNUc()
				{
					MupCGYejeWsSEBqcVYPdTIsHHgRD.LoadDefaults();
					sbuoITUoXdJeaRvhYMgSiDznReA.LoadDefaults();
				}

				internal void HYSNpqOxyLYdbvIwQQGaXyTZow(bool P_0)
				{
					if (GOguJrGpBEqlHBMupBEEEHaUcNUG.NfbYpqCcwCtQZDdSPAwknXYBXVp == null)
					{
						return;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Joystick);
					ugKyZyJTGtYLrHpCFnUKcqkaRKt.zDjgwsHxmQpJhkRGMsAWvoTTUnrS.FxzCwAtYmxSdgMTfOdnyfaPfUEa();
					int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
					for (int i = 0; i < count; i++)
					{
						CiBOuMFOJpyCeTavwEkrJOcXHWu<Joystick, JoystickMap>.aLsWzHkpJEuncBoWNDXtzbFVdTda aLsWzHkpJEuncBoWNDXtzbFVdTda = (CiBOuMFOJpyCeTavwEkrJOcXHWu<Joystick, JoystickMap>.aLsWzHkpJEuncBoWNDXtzbFVdTda)gqqVmTmEPnWlhtHJrWWOcCmltOt[i];
						bool[] array = null;
						if (!P_0)
						{
							int count2 = aLsWzHkpJEuncBoWNDXtzbFVdTda.VhZfrlASXHRPSRCbfcxNqUcSXtJ.Count;
							array = new bool[count2];
							for (int j = 0; j < count2; j++)
							{
								array[j] = aLsWzHkpJEuncBoWNDXtzbFVdTda.VhZfrlASXHRPSRCbfcxNqUcSXtJ[j].enabled;
							}
						}
						aLsWzHkpJEuncBoWNDXtzbFVdTda.VhZfrlASXHRPSRCbfcxNqUcSXtJ.VcHhfbFqwxAmqhwBHKVJpDjlfufe(false);
						for (int k = 0; k < GOguJrGpBEqlHBMupBEEEHaUcNUG.NfbYpqCcwCtQZDdSPAwknXYBXVp.Length; k++)
						{
							OFrDCvHjojsDmiqJlFFFkpuWRVkq(aLsWzHkpJEuncBoWNDXtzbFVdTda.FKtcxmBappHTSHGoccIYREwbpfog, aLsWzHkpJEuncBoWNDXtzbFVdTda.VhZfrlASXHRPSRCbfcxNqUcSXtJ, GOguJrGpBEqlHBMupBEEEHaUcNUG.NfbYpqCcwCtQZDdSPAwknXYBXVp[k], P_0);
						}
						if (!P_0)
						{
							int num = MathTools.Min(array.Length, aLsWzHkpJEuncBoWNDXtzbFVdTda.VhZfrlASXHRPSRCbfcxNqUcSXtJ.Count);
							for (int l = 0; l < num; l++)
							{
								aLsWzHkpJEuncBoWNDXtzbFVdTda.VhZfrlASXHRPSRCbfcxNqUcSXtJ[l].enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = sbuoITUoXdJeaRvhYMgSiDznReA.loadFromUserDataStore;
					sbuoITUoXdJeaRvhYMgSiDznReA.loadFromUserDataStore = false;
					sbuoITUoXdJeaRvhYMgSiDznReA.Apply();
					sbuoITUoXdJeaRvhYMgSiDznReA.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void nzrwhfDOuQHLskLeCNZfYRjspZE(bool P_0)
				{
					if (GOguJrGpBEqlHBMupBEEEHaUcNUG.cqlAWjjNEAgNCJpEgiHmmAmXaqG == null)
					{
						return;
					}
					SaFIhRkKoaFsJonuErfrovvvDai mapSet = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Keyboard).CXouiQVNNifvOhfkUWFfiMKCNFx(0).mapSet;
					bool[] array = null;
					if (!P_0)
					{
						int count = mapSet.Count;
						array = new bool[count];
						for (int i = 0; i < count; i++)
						{
							array[i] = mapSet[i].enabled;
						}
					}
					mapSet.VcHhfbFqwxAmqhwBHKVJpDjlfufe(false);
					for (int j = 0; j < GOguJrGpBEqlHBMupBEEEHaUcNUG.cqlAWjjNEAgNCJpEgiHmmAmXaqG.Length; j++)
					{
						jLTtbRfyBUfcjJGsNXajmJFtGHG jLTtbRfyBUfcjJGsNXajmJFtGHG2 = GOguJrGpBEqlHBMupBEEEHaUcNUG.cqlAWjjNEAgNCJpEgiHmmAmXaqG[j];
						if (jLTtbRfyBUfcjJGsNXajmJFtGHG2.categoryId >= 0 && jLTtbRfyBUfcjJGsNXajmJFtGHG2.layoutId >= 0)
						{
							KeyboardMap keyboardMap = ReInput.UserData.FindKeyboardMap_Game(ReInput.controllers.Keyboard, jLTtbRfyBUfcjJGsNXajmJFtGHG2.categoryId, jLTtbRfyBUfcjJGsNXajmJFtGHG2.layoutId);
							if (P_0)
							{
								keyboardMap.enabled = jLTtbRfyBUfcjJGsNXajmJFtGHG2.startEnabled;
							}
							ZgRbWiATNlFeprkZvUUfmMFFOxgw(ControllerType.Keyboard, 0, keyboardMap, BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl);
						}
					}
					if (!P_0)
					{
						int num = MathTools.Min(array.Length, mapSet.Count);
						for (int k = 0; k < num; k++)
						{
							mapSet[k].enabled = array[k];
						}
					}
					bool loadFromUserDataStore = sbuoITUoXdJeaRvhYMgSiDznReA.loadFromUserDataStore;
					sbuoITUoXdJeaRvhYMgSiDznReA.loadFromUserDataStore = false;
					sbuoITUoXdJeaRvhYMgSiDznReA.Apply();
					sbuoITUoXdJeaRvhYMgSiDznReA.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void cWaujwSKNUVkNCcDOOnpVQUKrzM(bool P_0)
				{
					if (GOguJrGpBEqlHBMupBEEEHaUcNUG.sUvIEqyarrwmqaNCnqJIbAnCNdh == null)
					{
						return;
					}
					SaFIhRkKoaFsJonuErfrovvvDai mapSet = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Mouse).CXouiQVNNifvOhfkUWFfiMKCNFx(0).mapSet;
					bool[] array = null;
					if (!P_0)
					{
						int count = mapSet.Count;
						array = new bool[count];
						for (int i = 0; i < count; i++)
						{
							array[i] = mapSet[i].enabled;
						}
					}
					mapSet.VcHhfbFqwxAmqhwBHKVJpDjlfufe(false);
					for (int j = 0; j < GOguJrGpBEqlHBMupBEEEHaUcNUG.sUvIEqyarrwmqaNCnqJIbAnCNdh.Length; j++)
					{
						jLTtbRfyBUfcjJGsNXajmJFtGHG jLTtbRfyBUfcjJGsNXajmJFtGHG2 = GOguJrGpBEqlHBMupBEEEHaUcNUG.sUvIEqyarrwmqaNCnqJIbAnCNdh[j];
						if (jLTtbRfyBUfcjJGsNXajmJFtGHG2.categoryId >= 0 && jLTtbRfyBUfcjJGsNXajmJFtGHG2.layoutId >= 0)
						{
							MouseMap mouseMap = ReInput.UserData.FindMouseMap_Game(ReInput.controllers.Mouse, jLTtbRfyBUfcjJGsNXajmJFtGHG2.categoryId, jLTtbRfyBUfcjJGsNXajmJFtGHG2.layoutId);
							if (P_0)
							{
								mouseMap.enabled = jLTtbRfyBUfcjJGsNXajmJFtGHG2.startEnabled;
							}
							ZgRbWiATNlFeprkZvUUfmMFFOxgw(ControllerType.Mouse, 0, mouseMap, BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl);
						}
					}
					if (!P_0)
					{
						int num = MathTools.Min(array.Length, mapSet.Count);
						for (int k = 0; k < num; k++)
						{
							mapSet[k].enabled = array[k];
						}
					}
					bool loadFromUserDataStore = sbuoITUoXdJeaRvhYMgSiDznReA.loadFromUserDataStore;
					sbuoITUoXdJeaRvhYMgSiDznReA.loadFromUserDataStore = false;
					sbuoITUoXdJeaRvhYMgSiDznReA.Apply();
					sbuoITUoXdJeaRvhYMgSiDznReA.loadFromUserDataStore = loadFromUserDataStore;
				}

				internal void ZgwLfVQFDeKnjEbfhyHdEbMRkuZ(bool P_0)
				{
					if (GOguJrGpBEqlHBMupBEEEHaUcNUG.etuyeCzjmEzqggrlXHYrxufKLfm == null)
					{
						return;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Custom);
					int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
					for (int i = 0; i < count; i++)
					{
						CiBOuMFOJpyCeTavwEkrJOcXHWu<CustomController, CustomControllerMap>.aLsWzHkpJEuncBoWNDXtzbFVdTda aLsWzHkpJEuncBoWNDXtzbFVdTda = (CiBOuMFOJpyCeTavwEkrJOcXHWu<CustomController, CustomControllerMap>.aLsWzHkpJEuncBoWNDXtzbFVdTda)gqqVmTmEPnWlhtHJrWWOcCmltOt[i];
						bool[] array = null;
						if (!P_0)
						{
							int count2 = aLsWzHkpJEuncBoWNDXtzbFVdTda.VhZfrlASXHRPSRCbfcxNqUcSXtJ.Count;
							array = new bool[count2];
							for (int j = 0; j < count2; j++)
							{
								array[j] = aLsWzHkpJEuncBoWNDXtzbFVdTda.VhZfrlASXHRPSRCbfcxNqUcSXtJ[j].enabled;
							}
						}
						aLsWzHkpJEuncBoWNDXtzbFVdTda.VhZfrlASXHRPSRCbfcxNqUcSXtJ.VcHhfbFqwxAmqhwBHKVJpDjlfufe(false);
						for (int k = 0; k < GOguJrGpBEqlHBMupBEEEHaUcNUG.etuyeCzjmEzqggrlXHYrxufKLfm.Length; k++)
						{
							OJGCkVKgYLmxnQvJlAtdSqKbRNYL(aLsWzHkpJEuncBoWNDXtzbFVdTda.FKtcxmBappHTSHGoccIYREwbpfog, aLsWzHkpJEuncBoWNDXtzbFVdTda.VhZfrlASXHRPSRCbfcxNqUcSXtJ, GOguJrGpBEqlHBMupBEEEHaUcNUG.etuyeCzjmEzqggrlXHYrxufKLfm[k], P_0);
						}
						if (!P_0)
						{
							int num = MathTools.Min(array.Length, aLsWzHkpJEuncBoWNDXtzbFVdTda.VhZfrlASXHRPSRCbfcxNqUcSXtJ.Count);
							for (int l = 0; l < num; l++)
							{
								aLsWzHkpJEuncBoWNDXtzbFVdTda.VhZfrlASXHRPSRCbfcxNqUcSXtJ[l].enabled = array[l];
							}
						}
					}
					bool loadFromUserDataStore = sbuoITUoXdJeaRvhYMgSiDznReA.loadFromUserDataStore;
					sbuoITUoXdJeaRvhYMgSiDznReA.loadFromUserDataStore = false;
					sbuoITUoXdJeaRvhYMgSiDznReA.Apply();
					sbuoITUoXdJeaRvhYMgSiDznReA.loadFromUserDataStore = loadFromUserDataStore;
				}

				private GqqVmTmEPnWlhtHJrWWOcCmltOt HKsQgrgAzvFmgvjbLwphvDQOADyD<T>() where T : ControllerMap
				{
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(XqmnYoifzflCsKxcFaHDewlkEkh.uEVNVvQRYSYawWaGkSxRghrpBcv<T>());
				}

				internal global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<JoystickMap> kDkaaEkmIPCqOaiEimBMGrtukXJI(Joystick P_0, bool P_1)
				{
					if (P_0 == null || GOguJrGpBEqlHBMupBEEEHaUcNUG.NfbYpqCcwCtQZDdSPAwknXYBXVp == null)
					{
						return null;
					}
					global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<JoystickMap> kfODxYFjqJsNDPfcwYBfcLaGFcLG2 = new global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<JoystickMap>(P_0.id);
					for (int i = 0; i < GOguJrGpBEqlHBMupBEEEHaUcNUG.NfbYpqCcwCtQZDdSPAwknXYBXVp.Length; i++)
					{
						OFrDCvHjojsDmiqJlFFFkpuWRVkq(P_0, kfODxYFjqJsNDPfcwYBfcLaGFcLG2, GOguJrGpBEqlHBMupBEEEHaUcNUG.NfbYpqCcwCtQZDdSPAwknXYBXVp[i], P_1);
					}
					if (kfODxYFjqJsNDPfcwYBfcLaGFcLG2.Count == 0)
					{
						return null;
					}
					return kfODxYFjqJsNDPfcwYBfcLaGFcLG2;
				}

				private void OFrDCvHjojsDmiqJlFFFkpuWRVkq(Joystick P_0, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<JoystickMap> P_1, jLTtbRfyBUfcjJGsNXajmJFtGHG P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.categoryId >= 0 && P_2.layoutId >= 0)
					{
						JoystickMap joystickMap = ReInput.UserData.TNNQzekbpHjCKEeRbKifsgkUPMA(P_0, P_2.categoryId, P_2.layoutId);
						udRnEWOwQJDseTQQIEzfgbieiXAF(P_0, joystickMap);
						BoolOption boolOption = BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl;
						if (P_3)
						{
							boolOption = (P_2.startEnabled ? BoolOption.dfmxWQCrEtuzIjLyNMeBmQbMSWz : BoolOption.yhIBEUAjGRiGHzBVHxfLpdUuzpd);
						}
						P_1.MoYefDcYehcNuEtBwCxDvPMYqtm(joystickMap, boolOption);
					}
				}

				internal global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<CustomControllerMap> rwxgABCVIxiibSHOEpKtKJAQRJv(CustomController P_0, bool P_1)
				{
					if (P_0 == null || GOguJrGpBEqlHBMupBEEEHaUcNUG.etuyeCzjmEzqggrlXHYrxufKLfm == null)
					{
						return null;
					}
					global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<CustomControllerMap> kfODxYFjqJsNDPfcwYBfcLaGFcLG2 = new global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<CustomControllerMap>(P_0.id);
					for (int i = 0; i < GOguJrGpBEqlHBMupBEEEHaUcNUG.etuyeCzjmEzqggrlXHYrxufKLfm.Length; i++)
					{
						OJGCkVKgYLmxnQvJlAtdSqKbRNYL(P_0, kfODxYFjqJsNDPfcwYBfcLaGFcLG2, GOguJrGpBEqlHBMupBEEEHaUcNUG.etuyeCzjmEzqggrlXHYrxufKLfm[i], P_1);
					}
					if (kfODxYFjqJsNDPfcwYBfcLaGFcLG2.Count == 0)
					{
						return null;
					}
					return kfODxYFjqJsNDPfcwYBfcLaGFcLG2;
				}

				private void OJGCkVKgYLmxnQvJlAtdSqKbRNYL(CustomController P_0, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<CustomControllerMap> P_1, jLTtbRfyBUfcjJGsNXajmJFtGHG P_2, bool P_3)
				{
					if (P_0 != null && P_2 != null && P_2.categoryId >= 0 && P_2.layoutId >= 0)
					{
						CustomControllerMap customControllerMap = ReInput.UserData.afCOBqOskEPFuQelOCcHQoUgyBZ(P_2.categoryId, P_0.sourceControllerId, P_2.layoutId);
						udRnEWOwQJDseTQQIEzfgbieiXAF(P_0, customControllerMap);
						BoolOption boolOption = BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl;
						if (P_3)
						{
							boolOption = (P_2.startEnabled ? BoolOption.dfmxWQCrEtuzIjLyNMeBmQbMSWz : BoolOption.yhIBEUAjGRiGHzBVHxfLpdUuzpd);
						}
						P_1.MoYefDcYehcNuEtBwCxDvPMYqtm(customControllerMap, boolOption);
					}
				}

				internal void udRnEWOwQJDseTQQIEzfgbieiXAF(Controller P_0, ControllerMap P_1)
				{
					if (P_0 != null && P_1 != null)
					{
						P_1.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
						P_0.udRnEWOwQJDseTQQIEzfgbieiXAF(P_1);
					}
				}

				private IList<T> UtKxnnWSTpRHmpFhxSxDoRrdOH<T>(int P_0) where T : ControllerMap
				{
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = HKsQgrgAzvFmgvjbLwphvDQOADyD<T>();
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_0);
					if (num < 0)
					{
						return EmptyObjects<T>.EmptyReadOnlyIListT;
					}
					return gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.gfBmEOaJlorgkCybHFpQvKcqfebg<T>();
				}

				private IList<T> UtKxnnWSTpRHmpFhxSxDoRrdOH<T>(Controller P_0) where T : ControllerMap
				{
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = HKsQgrgAzvFmgvjbLwphvDQOADyD<T>();
					return gqqVmTmEPnWlhtHJrWWOcCmltOt.CXouiQVNNifvOhfkUWFfiMKCNFx(P_0)?.mapSet.gfBmEOaJlorgkCybHFpQvKcqfebg<T>();
				}

				private IList<ControllerMap> UtKxnnWSTpRHmpFhxSxDoRrdOH(ControllerType P_0, int P_1)
				{
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num < 0)
					{
						return EmptyObjects<ControllerMap>.EmptyReadOnlyIListT;
					}
					return gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.Maps;
				}

				private IList<ControllerMap> UtKxnnWSTpRHmpFhxSxDoRrdOH(Controller P_0)
				{
					return UtKxnnWSTpRHmpFhxSxDoRrdOH(P_0.type, P_0.id);
				}

				private void ALfKBHrGSPAWkDtEuMOSNQcQzDA(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					ALfKBHrGSPAWkDtEuMOSNQcQzDA(P_0, P_1, P_2, P_3, BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl);
				}

				private void ALfKBHrGSPAWkDtEuMOSNQcQzDA(Controller P_0, int P_1, int P_2)
				{
					ALfKBHrGSPAWkDtEuMOSNQcQzDA(P_0, P_1, P_2, BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl);
				}

				private void ALfKBHrGSPAWkDtEuMOSNQcQzDA(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					ALfKBHrGSPAWkDtEuMOSNQcQzDA(P_0, P_1, P_2, P_3, BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl);
				}

				private void ALfKBHrGSPAWkDtEuMOSNQcQzDA(Controller P_0, string P_1, string P_2)
				{
					ALfKBHrGSPAWkDtEuMOSNQcQzDA(P_0, P_1, P_2, BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl);
				}

				private void ALfKBHrGSPAWkDtEuMOSNQcQzDA(ControllerType P_0, int P_1, int P_2, int P_3, BoolOption P_4)
				{
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num >= 0)
					{
						Controller controller = gqqVmTmEPnWlhtHJrWWOcCmltOt[num].controller;
						ControllerMap controllerMap = ReInput.UserData.ifCgZrpoeKFgfwvVVGARrzzwHdG(controller, P_2, P_3);
						ZgRbWiATNlFeprkZvUUfmMFFOxgw(controller.type, controller.id, controllerMap, P_4);
					}
				}

				private void ALfKBHrGSPAWkDtEuMOSNQcQzDA(Controller P_0, int P_1, int P_2, BoolOption P_3)
				{
					ALfKBHrGSPAWkDtEuMOSNQcQzDA(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void ALfKBHrGSPAWkDtEuMOSNQcQzDA(ControllerType P_0, int P_1, string P_2, string P_3, BoolOption P_4)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						ALfKBHrGSPAWkDtEuMOSNQcQzDA(P_0, P_1, mapCategoryId, layoutId, P_4);
					}
				}

				private void ALfKBHrGSPAWkDtEuMOSNQcQzDA(Controller P_0, string P_1, string P_2, BoolOption P_3)
				{
					ALfKBHrGSPAWkDtEuMOSNQcQzDA(P_0.type, P_0.id, P_1, P_2, P_3);
				}

				private void ZgRbWiATNlFeprkZvUUfmMFFOxgw(Controller P_0, ControllerMap P_1, BoolOption P_2)
				{
					if (P_0 != null && P_1 != null)
					{
						GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0.type);
						int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_0.id);
						if (num >= 0)
						{
							udRnEWOwQJDseTQQIEzfgbieiXAF(P_0, P_1);
							gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.MoYefDcYehcNuEtBwCxDvPMYqtm(P_1, P_2);
							MupCGYejeWsSEBqcVYPdTIsHHgRD.Apply();
						}
					}
				}

				private void ZgRbWiATNlFeprkZvUUfmMFFOxgw(ControllerType P_0, int P_1, ControllerMap P_2, BoolOption P_3)
				{
					Controller controller = ReInput.controllers.GetController(P_0, P_1);
					if (controller != null)
					{
						ZgRbWiATNlFeprkZvUUfmMFFOxgw(controller, P_2, P_3);
					}
				}

				private bool SowESkNTKeJSbuZrUIWVsXCwOEm(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.ikoBGVHHLVNnLaVaWGffMETVhTJw(P_0);
					if (!controllerMap.WFAybvFElcFTYvXJKZXjWvsTlWu(P_2))
					{
						return false;
					}
					ZgRbWiATNlFeprkZvUUfmMFFOxgw(P_0, P_1, controllerMap, BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl);
					return true;
				}

				private int uKAbgbuFCAaNeswdYGNzPsPzbdVj(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (SowESkNTKeJSbuZrUIWVsXCwOEm(P_0, P_1, P_2[i]))
						{
							num2++;
						}
					}
					return num2;
				}

				private bool HGCfZrGdhmzyPFEVovflpnBMwEL(ControllerType P_0, int P_1, string P_2)
				{
					if (P_2 == null || P_2 == string.Empty)
					{
						return false;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num < 0)
					{
						return false;
					}
					ControllerMap controllerMap = ControllerMap.ikoBGVHHLVNnLaVaWGffMETVhTJw(P_0);
					if (!controllerMap.SDYWZqNutdNGtpNMJBdKBBzlYyCG(P_2))
					{
						return false;
					}
					ZgRbWiATNlFeprkZvUUfmMFFOxgw(P_0, P_1, controllerMap, BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl);
					return true;
				}

				private int mNodDHEGatdarSqVXpfdIZwSIUS(ControllerType P_0, int P_1, List<string> P_2)
				{
					if (P_2 == null || P_2.Count == 0)
					{
						return 0;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					for (int i = 0; i < P_2.Count; i++)
					{
						if (HGCfZrGdhmzyPFEVovflpnBMwEL(P_0, P_1, P_2[i]))
						{
							num2++;
						}
					}
					return num2;
				}

				private void eQaCrHCSVASOaMPBJqPxpVssUXoP(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num >= 0)
					{
						Controller controller = gqqVmTmEPnWlhtHJrWWOcCmltOt[num].controller;
						ControllerMap controllerMap = ControllerMap.SYXlQmHOzCKJIifRKNsrYHodbMla(controller, P_2, P_3);
						ZgRbWiATNlFeprkZvUUfmMFFOxgw(controller.type, controller.id, controllerMap, BoolOption.wLCbAjleYPUOhAnzgTfrtJigKYl);
					}
				}

				private void eQaCrHCSVASOaMPBJqPxpVssUXoP(Controller P_0, int P_1, int P_2)
				{
					eQaCrHCSVASOaMPBJqPxpVssUXoP(P_0.type, P_0.id, P_1, P_2);
				}

				private void eQaCrHCSVASOaMPBJqPxpVssUXoP(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId >= 0 && layoutId >= 0)
					{
						eQaCrHCSVASOaMPBJqPxpVssUXoP(P_0, P_1, mapCategoryId, layoutId);
					}
				}

				private void eQaCrHCSVASOaMPBJqPxpVssUXoP(Controller P_0, string P_1, string P_2)
				{
					eQaCrHCSVASOaMPBJqPxpVssUXoP(P_0.type, P_0.id, P_1, P_2);
				}

				private void WIbIDoGKOAeuuCIwaCRqPWnmUwL(ControllerType P_0, int P_1, int P_2)
				{
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num >= 0)
					{
						gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.QXkvnqomSlAdhfvmzmaPghwHyEOG(P_2);
					}
				}

				private void WIbIDoGKOAeuuCIwaCRqPWnmUwL(Controller P_0, int P_1)
				{
					WIbIDoGKOAeuuCIwaCRqPWnmUwL(P_0.type, P_0.id, P_1);
				}

				private void WIbIDoGKOAeuuCIwaCRqPWnmUwL(ControllerType P_0, int P_1, ControllerMap P_2)
				{
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num >= 0)
					{
						gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.tsiIiRnEIKEeGXdmsiYIGAemsrcr(P_2);
					}
				}

				private void WIbIDoGKOAeuuCIwaCRqPWnmUwL(Controller P_0, ControllerMap P_1)
				{
					WIbIDoGKOAeuuCIwaCRqPWnmUwL(P_0.type, P_0.id, P_1.id);
				}

				private void WIbIDoGKOAeuuCIwaCRqPWnmUwL(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num >= 0)
					{
						gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.tsiIiRnEIKEeGXdmsiYIGAemsrcr(P_2, P_3);
					}
				}

				private void WIbIDoGKOAeuuCIwaCRqPWnmUwL(Controller P_0, int P_1, int P_2)
				{
					WIbIDoGKOAeuuCIwaCRqPWnmUwL(P_0.type, P_0.id, P_1, P_2);
				}

				private void WIbIDoGKOAeuuCIwaCRqPWnmUwL(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num >= 0)
					{
						int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
						int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
						if (mapCategoryId >= 0 && layoutId >= 0)
						{
							gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.tsiIiRnEIKEeGXdmsiYIGAemsrcr(mapCategoryId, layoutId);
						}
					}
				}

				private void WIbIDoGKOAeuuCIwaCRqPWnmUwL(Controller P_0, string P_1, string P_2)
				{
					WIbIDoGKOAeuuCIwaCRqPWnmUwL(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap ZbeejXdnhjohgiTBODgmgtVfAsH(ControllerType P_0, int P_1, int P_2)
				{
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num < 0)
					{
						return null;
					}
					return gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.udmVdEorzIEcZerNtLKGkDteaniA(P_2);
				}

				private ControllerMap ZbeejXdnhjohgiTBODgmgtVfAsH(Controller P_0, int P_1)
				{
					return ZbeejXdnhjohgiTBODgmgtVfAsH(P_0.type, P_0.id, P_1);
				}

				private ControllerMap ZbeejXdnhjohgiTBODgmgtVfAsH(ControllerType P_0, int P_1, int P_2, int P_3)
				{
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num < 0)
					{
						return null;
					}
					return gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.udmVdEorzIEcZerNtLKGkDteaniA(P_2, P_3);
				}

				private ControllerMap ZbeejXdnhjohgiTBODgmgtVfAsH(Controller P_0, int P_1, int P_2)
				{
					return ZbeejXdnhjohgiTBODgmgtVfAsH(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap ZbeejXdnhjohgiTBODgmgtVfAsH(ControllerType P_0, int P_1, string P_2, string P_3)
				{
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(P_2);
					int layoutId = ReInput.mapping.GetLayoutId(P_0, P_3);
					if (mapCategoryId < 0 || layoutId < 0)
					{
						return null;
					}
					return ZbeejXdnhjohgiTBODgmgtVfAsH(P_0, P_1, mapCategoryId, layoutId);
				}

				private ControllerMap ZbeejXdnhjohgiTBODgmgtVfAsH(Controller P_0, string P_1, string P_2)
				{
					return ZbeejXdnhjohgiTBODgmgtVfAsH(P_0.type, P_0.id, P_1, P_2);
				}

				private ControllerMap GkJELcHkumiUacFCrPAUMSpyDiC(ControllerType P_0, int P_1, int P_2)
				{
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num < 0)
					{
						return null;
					}
					return gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.MhguwzvwBlJWCCToEcCYYDJdBng(P_2);
				}

				private ControllerMap GkJELcHkumiUacFCrPAUMSpyDiC(Controller P_0, int P_1)
				{
					return GkJELcHkumiUacFCrPAUMSpyDiC(P_0.type, P_0.id, P_1);
				}

				private ControllerMap GkJELcHkumiUacFCrPAUMSpyDiC(ControllerType P_0, int P_1, string P_2)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return null;
					}
					return GkJELcHkumiUacFCrPAUMSpyDiC(P_0, P_1, mapCategoryId);
				}

				private ControllerMap GkJELcHkumiUacFCrPAUMSpyDiC(Controller P_0, string P_1)
				{
					return GkJELcHkumiUacFCrPAUMSpyDiC(P_0.type, P_0.id, P_1);
				}

				private ControllerMap[] uArsgcdPGMQTXJDTckPTppJPlfZ(ControllerType P_0)
				{
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = 0;
					for (int i = 0; i < gqqVmTmEPnWlhtHJrWWOcCmltOt.Count; i++)
					{
						num += gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.Count;
					}
					ControllerMap[] array = new ControllerMap[num];
					num = 0;
					for (int j = 0; j < gqqVmTmEPnWlhtHJrWWOcCmltOt.Count; j++)
					{
						SaFIhRkKoaFsJonuErfrovvvDai mapSet = gqqVmTmEPnWlhtHJrWWOcCmltOt[j].mapSet;
						for (int k = 0; k < mapSet.Count; k++)
						{
							array[num] = mapSet[k];
							num++;
						}
					}
					return array;
				}

				private ControllerMapSaveData[] kmPZUPMNpgUcCQUIqJutLEqJyTF(ControllerType P_0, int P_1, bool P_2)
				{
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num < 0)
					{
						return null;
					}
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					SaFIhRkKoaFsJonuErfrovvvDai mapSet = gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet;
					for (int i = 0; i < mapSet.Count; i++)
					{
						ControllerMap controllerMap = mapSet[i];
						if (P_2)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = gqqVmTmEPnWlhtHJrWWOcCmltOt[num].controller;
						list.Add(ControllerMapSaveData.ikoBGVHHLVNnLaVaWGffMETVhTJw(controller, controllerMap));
					}
					return list.ToArray();
				}

				private T[] kmPZUPMNpgUcCQUIqJutLEqJyTF<T>(int P_0, bool P_1) where T : ControllerMapSaveData
				{
					ControllerType controllerType = XqmnYoifzflCsKxcFaHDewlkEkh.knHEmNEychMikCIUrAVKQpOamGHf<T>();
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_0);
					if (num < 0)
					{
						return null;
					}
					List<T> list = new List<T>();
					SaFIhRkKoaFsJonuErfrovvvDai mapSet = gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet;
					for (int i = 0; i < mapSet.Count; i++)
					{
						ControllerMap controllerMap = mapSet[i];
						if (P_1)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
							if (mapCategory != null && !mapCategory.userAssignable)
							{
								continue;
							}
						}
						Controller controller = gqqVmTmEPnWlhtHJrWWOcCmltOt[num].controller;
						list.Add(ControllerMapSaveData.ikoBGVHHLVNnLaVaWGffMETVhTJw<T>(controller, controllerMap));
					}
					return list.ToArray();
				}

				private ControllerMapSaveData[] wJRkFBTAxkTZteGkYqLkPfBlWhc(ControllerType P_0, bool P_1)
				{
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					List<ControllerMapSaveData> list = new List<ControllerMapSaveData>();
					for (int i = 0; i < gqqVmTmEPnWlhtHJrWWOcCmltOt.Count; i++)
					{
						SaFIhRkKoaFsJonuErfrovvvDai mapSet = gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet;
						for (int j = 0; j < mapSet.Count; j++)
						{
							ControllerMap controllerMap = mapSet[j];
							if (P_1)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = gqqVmTmEPnWlhtHJrWWOcCmltOt[i].controller;
							list.Add(ControllerMapSaveData.ikoBGVHHLVNnLaVaWGffMETVhTJw(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private T[] wJRkFBTAxkTZteGkYqLkPfBlWhc<T>(bool P_0) where T : ControllerMapSaveData
				{
					ControllerType controllerType = XqmnYoifzflCsKxcFaHDewlkEkh.knHEmNEychMikCIUrAVKQpOamGHf<T>();
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType);
					List<T> list = new List<T>();
					for (int i = 0; i < gqqVmTmEPnWlhtHJrWWOcCmltOt.Count; i++)
					{
						SaFIhRkKoaFsJonuErfrovvvDai mapSet = gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet;
						for (int j = 0; j < mapSet.Count; j++)
						{
							ControllerMap controllerMap = mapSet[j];
							if (P_0)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(controllerMap.categoryId);
								if (mapCategory != null && !mapCategory.userAssignable)
								{
									continue;
								}
							}
							Controller controller = gqqVmTmEPnWlhtHJrWWOcCmltOt[i].controller;
							list.Add(ControllerMapSaveData.ikoBGVHHLVNnLaVaWGffMETVhTJw<T>(controller, controllerMap));
						}
					}
					return list.ToArray();
				}

				private int PeGrdTihPWCAfFzXErwOvBDsSYI(ControllerType P_0, int P_1, int P_2, List<ControllerMap> P_3)
				{
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num < 0)
					{
						return 0;
					}
					return gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.ctovEHmRefuhMZmHMxOfiJlbBW(P_2, P_3, false);
				}

				private int PeGrdTihPWCAfFzXErwOvBDsSYI(Controller P_0, int P_1, List<ControllerMap> P_2)
				{
					return PeGrdTihPWCAfFzXErwOvBDsSYI(P_0.type, P_0.id, P_1, P_2);
				}

				private int PeGrdTihPWCAfFzXErwOvBDsSYI(ControllerType P_0, int P_1, string P_2, List<ControllerMap> P_3)
				{
					int mapCategoryId = ReInput.UserData.GetMapCategoryId(P_2);
					if (mapCategoryId < 0)
					{
						return 0;
					}
					return PeGrdTihPWCAfFzXErwOvBDsSYI(P_0, P_1, mapCategoryId, P_3);
				}

				private int PeGrdTihPWCAfFzXErwOvBDsSYI(Controller P_0, string P_1, List<ControllerMap> P_2)
				{
					return PeGrdTihPWCAfFzXErwOvBDsSYI(P_0.type, P_0.id, P_1, P_2);
				}

				private IEnumerable<ControllerMap> cAAxqLTlTxwHzdoSsfJTNFsEgGvk(ControllerType P_0, int P_1, int P_2)
				{
					niejlyKuLHahjvMtAXbNkbPNqmf niejlyKuLHahjvMtAXbNkbPNqmf2 = new niejlyKuLHahjvMtAXbNkbPNqmf(-2);
					niejlyKuLHahjvMtAXbNkbPNqmf2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					niejlyKuLHahjvMtAXbNkbPNqmf2.dCrCLiKKKlaSSJCUCnULxHTQLiPz = P_0;
					niejlyKuLHahjvMtAXbNkbPNqmf2.vwsWqbAxZchMsrPtAyVDSdLCrYZ = P_1;
					niejlyKuLHahjvMtAXbNkbPNqmf2.kHPEEBGwlYJndavghTRnPpnmDafU = P_2;
					return niejlyKuLHahjvMtAXbNkbPNqmf2;
				}

				private IEnumerable<T> cAAxqLTlTxwHzdoSsfJTNFsEgGvk<T>(int P_0, int P_1) where T : ControllerMap
				{
					mSKaEhdKeXWwxtjiThAkshTwbwmg<T> mSKaEhdKeXWwxtjiThAkshTwbwmg2 = new mSKaEhdKeXWwxtjiThAkshTwbwmg<T>(-2);
					mSKaEhdKeXWwxtjiThAkshTwbwmg2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					mSKaEhdKeXWwxtjiThAkshTwbwmg2.vwsWqbAxZchMsrPtAyVDSdLCrYZ = P_0;
					mSKaEhdKeXWwxtjiThAkshTwbwmg2.kHPEEBGwlYJndavghTRnPpnmDafU = P_1;
					return mSKaEhdKeXWwxtjiThAkshTwbwmg2;
				}

				private ActionElementMap HQCvgOgHBlHmLDcXvnABIrshlfPs(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					for (int i = 0; i < gqqVmTmEPnWlhtHJrWWOcCmltOt.Count; i++)
					{
						IList<ControllerMap> maps = gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.Maps;
						for (int j = 0; j < maps.Count; j++)
						{
							if ((!P_2 || maps[j].enabled) && maps[j].ContainsAction(P_1))
							{
								ActionElementMap firstButtonMapWithAction = maps[j].GetFirstButtonMapWithAction(P_1, P_2);
								if (firstButtonMapWithAction != null)
								{
									return firstButtonMapWithAction;
								}
							}
						}
					}
					return null;
				}

				private ActionElementMap HQCvgOgHBlHmLDcXvnABIrshlfPs(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_1);
					return HQCvgOgHBlHmLDcXvnABIrshlfPs(P_0, num, P_2);
				}

				private IEnumerable<ActionElementMap> zPEKOFqazJeovddkukteneDsutd(ControllerType P_0, int P_1, bool P_2)
				{
					UdVjikDIQZnEIhKRxyaHnacGFvsZ udVjikDIQZnEIhKRxyaHnacGFvsZ = new UdVjikDIQZnEIhKRxyaHnacGFvsZ(-2);
					udVjikDIQZnEIhKRxyaHnacGFvsZ.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					udVjikDIQZnEIhKRxyaHnacGFvsZ.dCrCLiKKKlaSSJCUCnULxHTQLiPz = P_0;
					udVjikDIQZnEIhKRxyaHnacGFvsZ.gmlZVSBTtPIWuYPylEQcoNUGUio = P_1;
					udVjikDIQZnEIhKRxyaHnacGFvsZ.TGDalxAGxtEWicADkzmraNyMfPny = P_2;
					return udVjikDIQZnEIhKRxyaHnacGFvsZ;
				}

				private IEnumerable<ActionElementMap> zPEKOFqazJeovddkukteneDsutd(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_1);
					return zPEKOFqazJeovddkukteneDsutd(P_0, num, P_2);
				}

				private ActionElementMap ZQYPuRnWvyLQjUgCvQEbpRlJbgvb(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					for (int i = 0; i < gqqVmTmEPnWlhtHJrWWOcCmltOt.Count; i++)
					{
						IList<ControllerMap> maps = gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.Maps;
						for (int j = 0; j < maps.Count; j++)
						{
							if (!(maps[j] is ControllerMapWithAxes))
							{
								return null;
							}
							if ((!P_2 || maps[j].enabled) && maps[j].ContainsAction(P_1))
							{
								ActionElementMap firstAxisMapWithAction = (maps[j] as ControllerMapWithAxes).GetFirstAxisMapWithAction(P_1, P_2);
								if (firstAxisMapWithAction != null)
								{
									return firstAxisMapWithAction;
								}
							}
						}
					}
					return null;
				}

				private ActionElementMap ZQYPuRnWvyLQjUgCvQEbpRlJbgvb(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_1);
					return ZQYPuRnWvyLQjUgCvQEbpRlJbgvb(P_0, num, P_2);
				}

				private IEnumerable<ActionElementMap> cFbSIfVtfUAAumzIUedwVhCWhkA(ControllerType P_0, int P_1, bool P_2)
				{
					HtMFDazxNLAhDRQNMXThXIOFvWt htMFDazxNLAhDRQNMXThXIOFvWt = new HtMFDazxNLAhDRQNMXThXIOFvWt(-2);
					htMFDazxNLAhDRQNMXThXIOFvWt.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					htMFDazxNLAhDRQNMXThXIOFvWt.dCrCLiKKKlaSSJCUCnULxHTQLiPz = P_0;
					htMFDazxNLAhDRQNMXThXIOFvWt.gmlZVSBTtPIWuYPylEQcoNUGUio = P_1;
					htMFDazxNLAhDRQNMXThXIOFvWt.TGDalxAGxtEWicADkzmraNyMfPny = P_2;
					return htMFDazxNLAhDRQNMXThXIOFvWt;
				}

				private IEnumerable<ActionElementMap> cFbSIfVtfUAAumzIUedwVhCWhkA(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_1);
					return cFbSIfVtfUAAumzIUedwVhCWhkA(P_0, num, P_2);
				}

				private ActionElementMap DlavhuHGsniKsejEvEhSSMppMwF(ControllerType P_0, int P_1, bool P_2)
				{
					if (P_1 < 0)
					{
						return null;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					for (int i = 0; i < gqqVmTmEPnWlhtHJrWWOcCmltOt.Count; i++)
					{
						IList<ControllerMap> maps = gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.Maps;
						for (int j = 0; j < maps.Count; j++)
						{
							if ((!P_2 || maps[j].enabled) && maps[j].ContainsAction(P_1))
							{
								ActionElementMap firstElementMapWithAction = maps[j].GetFirstElementMapWithAction(P_1, P_2);
								if (firstElementMapWithAction != null)
								{
									return firstElementMapWithAction;
								}
							}
						}
					}
					return null;
				}

				private ActionElementMap DlavhuHGsniKsejEvEhSSMppMwF(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_1);
					return DlavhuHGsniKsejEvEhSSMppMwF(P_0, num, P_2);
				}

				private IEnumerable<ActionElementMap> wAyIcjGTjfmHWUkrwDEAMBzILaTI(ControllerType P_0, int P_1, bool P_2)
				{
					EEyIpKAoAxTmGdXXIzVYruSHfYRU eEyIpKAoAxTmGdXXIzVYruSHfYRU = new EEyIpKAoAxTmGdXXIzVYruSHfYRU(-2);
					eEyIpKAoAxTmGdXXIzVYruSHfYRU.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					eEyIpKAoAxTmGdXXIzVYruSHfYRU.dCrCLiKKKlaSSJCUCnULxHTQLiPz = P_0;
					eEyIpKAoAxTmGdXXIzVYruSHfYRU.gmlZVSBTtPIWuYPylEQcoNUGUio = P_1;
					eEyIpKAoAxTmGdXXIzVYruSHfYRU.TGDalxAGxtEWicADkzmraNyMfPny = P_2;
					return eEyIpKAoAxTmGdXXIzVYruSHfYRU;
				}

				private IEnumerable<ActionElementMap> wAyIcjGTjfmHWUkrwDEAMBzILaTI(ControllerType P_0, string P_1, bool P_2)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_1);
					return wAyIcjGTjfmHWUkrwDEAMBzILaTI(P_0, num, P_2);
				}

				private int EwxUCWIjgNvgwPkYWOoxwAiADEI(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
				{
					if (P_2 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_3)
					{
						P_2.Clear();
					}
					if (P_0 < 0)
					{
						return 0;
					}
					int num = 0;
					int eBADKEfFkgpzzTponatpcvPGNRUi = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
					for (int i = 0; i < eBADKEfFkgpzzTponatpcvPGNRUi; i++)
					{
						GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(i);
						int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
						for (int j = 0; j < count; j++)
						{
							SaFIhRkKoaFsJonuErfrovvvDai mapSet = gqqVmTmEPnWlhtHJrWWOcCmltOt[j].mapSet;
							int count2 = mapSet.Count;
							for (int k = 0; k < count2; k++)
							{
								ControllerMap controllerMap = mapSet[k];
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.EwxUCWIjgNvgwPkYWOoxwAiADEI(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int OPLgbMnDTUePxNEOivAOYPYzSya(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
				{
					if (P_2 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_3)
					{
						P_2.Clear();
					}
					if (P_0 < 0)
					{
						return 0;
					}
					int num = 0;
					int eBADKEfFkgpzzTponatpcvPGNRUi = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
					for (int i = 0; i < eBADKEfFkgpzzTponatpcvPGNRUi; i++)
					{
						GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(i);
						int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
						for (int j = 0; j < count; j++)
						{
							SaFIhRkKoaFsJonuErfrovvvDai mapSet = gqqVmTmEPnWlhtHJrWWOcCmltOt[j].mapSet;
							int count2 = mapSet.Count;
							for (int k = 0; k < count2; k++)
							{
								if (mapSet[k] is ControllerMapWithAxes controllerMapWithAxes && (!P_1 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_0))
								{
									num += controllerMapWithAxes.OPLgbMnDTUePxNEOivAOYPYzSya(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int paPqgnqavLYCqgponTssufOHcpc(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
				{
					if (P_2 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_3)
					{
						P_2.Clear();
					}
					if (P_0 < 0)
					{
						return 0;
					}
					int num = 0;
					int eBADKEfFkgpzzTponatpcvPGNRUi = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
					for (int i = 0; i < eBADKEfFkgpzzTponatpcvPGNRUi; i++)
					{
						GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(i);
						int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
						for (int j = 0; j < count; j++)
						{
							SaFIhRkKoaFsJonuErfrovvvDai mapSet = gqqVmTmEPnWlhtHJrWWOcCmltOt[j].mapSet;
							int count2 = mapSet.Count;
							for (int k = 0; k < count2; k++)
							{
								ControllerMap controllerMap = mapSet[k];
								if ((!P_1 || controllerMap.enabled) && controllerMap.ContainsAction(P_0))
								{
									num += controllerMap.paPqgnqavLYCqgponTssufOHcpc(P_0, P_1, P_2, true);
								}
							}
						}
					}
					return num;
				}

				private int dDTksWbQeoRPPFliOyNECYyeJbf(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					if (P_3 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_4)
					{
						P_3.Clear();
					}
					if (P_1 < 0)
					{
						return 0;
					}
					int num = 0;
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					for (int i = 0; i < gqqVmTmEPnWlhtHJrWWOcCmltOt.Count; i++)
					{
						IList<ControllerMap> maps = gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.Maps;
						for (int j = 0; j < maps.Count; j++)
						{
							if ((!P_2 || maps[j].enabled) && maps[j].ContainsAction(P_1))
							{
								num += maps[j].EwxUCWIjgNvgwPkYWOoxwAiADEI(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int dDTksWbQeoRPPFliOyNECYyeJbf(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_1);
					return dDTksWbQeoRPPFliOyNECYyeJbf(P_0, num, P_2, P_3, P_4);
				}

				private int OpTXrUQqOmFypxKzfhOyCmXqSlp(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					if (P_3 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_4)
					{
						P_3.Clear();
					}
					if (P_1 < 0)
					{
						return 0;
					}
					int num = 0;
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					for (int i = 0; i < gqqVmTmEPnWlhtHJrWWOcCmltOt.Count; i++)
					{
						IList<ControllerMap> maps = gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.Maps;
						for (int j = 0; j < maps.Count; j++)
						{
							if (!(maps[j] is ControllerMapWithAxes))
							{
								return P_3.Count;
							}
							if ((!P_2 || maps[j].enabled) && maps[j].ContainsAction(P_1))
							{
								num += (maps[j] as ControllerMapWithAxes).OPLgbMnDTUePxNEOivAOYPYzSya(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int OpTXrUQqOmFypxKzfhOyCmXqSlp(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_1);
					return OpTXrUQqOmFypxKzfhOyCmXqSlp(P_0, num, P_2, P_3, P_4);
				}

				private int KtPnmXjUixAFlwRskKIqsCmTKsY(ControllerType P_0, int P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					if (P_3 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_4)
					{
						P_3.Clear();
					}
					if (P_1 < 0)
					{
						return 0;
					}
					int num = 0;
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					for (int i = 0; i < gqqVmTmEPnWlhtHJrWWOcCmltOt.Count; i++)
					{
						IList<ControllerMap> maps = gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet.Maps;
						for (int j = 0; j < maps.Count; j++)
						{
							if ((!P_2 || maps[j].enabled) && maps[j].ContainsAction(P_1))
							{
								num += maps[j].paPqgnqavLYCqgponTssufOHcpc(P_1, P_2, P_3, true);
							}
						}
					}
					return num;
				}

				private int KtPnmXjUixAFlwRskKIqsCmTKsY(ControllerType P_0, string P_1, bool P_2, List<ActionElementMap> P_3, bool P_4)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_1);
					return KtPnmXjUixAFlwRskKIqsCmTKsY(P_0, num, P_2, P_3, P_4);
				}

				private ActionElementMap HQCvgOgHBlHmLDcXvnABIrshlfPs(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> maps = gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.Maps;
					for (int i = 0; i < maps.Count; i++)
					{
						if ((!P_3 || maps[i].enabled) && maps[i].ContainsAction(P_2))
						{
							ActionElementMap firstButtonMapWithAction = maps[i].GetFirstButtonMapWithAction(P_2, P_3);
							if (firstButtonMapWithAction != null)
							{
								return firstButtonMapWithAction;
							}
						}
					}
					return null;
				}

				private ActionElementMap HQCvgOgHBlHmLDcXvnABIrshlfPs(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_2);
					return HQCvgOgHBlHmLDcXvnABIrshlfPs(P_0, P_1, num, P_3);
				}

				private IEnumerable<ActionElementMap> zPEKOFqazJeovddkukteneDsutd(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					YJkBnEDXswQVGNzcVffrhStXAkE yJkBnEDXswQVGNzcVffrhStXAkE = new YJkBnEDXswQVGNzcVffrhStXAkE(-2);
					yJkBnEDXswQVGNzcVffrhStXAkE.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					yJkBnEDXswQVGNzcVffrhStXAkE.dCrCLiKKKlaSSJCUCnULxHTQLiPz = P_0;
					yJkBnEDXswQVGNzcVffrhStXAkE.vwsWqbAxZchMsrPtAyVDSdLCrYZ = P_1;
					yJkBnEDXswQVGNzcVffrhStXAkE.gmlZVSBTtPIWuYPylEQcoNUGUio = P_2;
					yJkBnEDXswQVGNzcVffrhStXAkE.TGDalxAGxtEWicADkzmraNyMfPny = P_3;
					return yJkBnEDXswQVGNzcVffrhStXAkE;
				}

				private IEnumerable<ActionElementMap> zPEKOFqazJeovddkukteneDsutd(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_2);
					return zPEKOFqazJeovddkukteneDsutd(P_0, P_1, num, P_3);
				}

				private ActionElementMap ZQYPuRnWvyLQjUgCvQEbpRlJbgvb(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> maps = gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.Maps;
					for (int i = 0; i < maps.Count; i++)
					{
						if (!(maps[i] is ControllerMapWithAxes))
						{
							return null;
						}
						if ((!P_3 || maps[i].enabled) && maps[i].ContainsAction(P_2))
						{
							ActionElementMap firstAxisMapWithAction = (maps[i] as ControllerMapWithAxes).GetFirstAxisMapWithAction(P_2, P_3);
							if (firstAxisMapWithAction != null)
							{
								return firstAxisMapWithAction;
							}
						}
					}
					return null;
				}

				private ActionElementMap ZQYPuRnWvyLQjUgCvQEbpRlJbgvb(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_2);
					return ZQYPuRnWvyLQjUgCvQEbpRlJbgvb(P_0, P_1, num, P_3);
				}

				private IEnumerable<ActionElementMap> cFbSIfVtfUAAumzIUedwVhCWhkA(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					aGYhMjuoCpJJYFIdnmXaYgRONab aGYhMjuoCpJJYFIdnmXaYgRONab2 = new aGYhMjuoCpJJYFIdnmXaYgRONab(-2);
					aGYhMjuoCpJJYFIdnmXaYgRONab2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					aGYhMjuoCpJJYFIdnmXaYgRONab2.dCrCLiKKKlaSSJCUCnULxHTQLiPz = P_0;
					aGYhMjuoCpJJYFIdnmXaYgRONab2.vwsWqbAxZchMsrPtAyVDSdLCrYZ = P_1;
					aGYhMjuoCpJJYFIdnmXaYgRONab2.gmlZVSBTtPIWuYPylEQcoNUGUio = P_2;
					aGYhMjuoCpJJYFIdnmXaYgRONab2.TGDalxAGxtEWicADkzmraNyMfPny = P_3;
					return aGYhMjuoCpJJYFIdnmXaYgRONab2;
				}

				private IEnumerable<ActionElementMap> cFbSIfVtfUAAumzIUedwVhCWhkA(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_2);
					return cFbSIfVtfUAAumzIUedwVhCWhkA(P_0, P_1, num, P_3);
				}

				private ActionElementMap DlavhuHGsniKsejEvEhSSMppMwF(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					if (P_2 < 0)
					{
						return null;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num < 0)
					{
						return null;
					}
					IList<ControllerMap> maps = gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.Maps;
					for (int i = 0; i < maps.Count; i++)
					{
						if ((!P_3 || maps[i].enabled) && maps[i].ContainsAction(P_2))
						{
							ActionElementMap firstElementMapWithAction = maps[i].GetFirstElementMapWithAction(P_2, P_3);
							if (firstElementMapWithAction != null)
							{
								return firstElementMapWithAction;
							}
						}
					}
					return null;
				}

				private ActionElementMap DlavhuHGsniKsejEvEhSSMppMwF(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_2);
					return DlavhuHGsniKsejEvEhSSMppMwF(P_0, P_1, num, P_3);
				}

				private IEnumerable<ActionElementMap> wAyIcjGTjfmHWUkrwDEAMBzILaTI(ControllerType P_0, int P_1, int P_2, bool P_3)
				{
					OToFLcqinEebyQqRdMgxJPMYXVH oToFLcqinEebyQqRdMgxJPMYXVH = new OToFLcqinEebyQqRdMgxJPMYXVH(-2);
					oToFLcqinEebyQqRdMgxJPMYXVH.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					oToFLcqinEebyQqRdMgxJPMYXVH.dCrCLiKKKlaSSJCUCnULxHTQLiPz = P_0;
					oToFLcqinEebyQqRdMgxJPMYXVH.vwsWqbAxZchMsrPtAyVDSdLCrYZ = P_1;
					oToFLcqinEebyQqRdMgxJPMYXVH.gmlZVSBTtPIWuYPylEQcoNUGUio = P_2;
					oToFLcqinEebyQqRdMgxJPMYXVH.TGDalxAGxtEWicADkzmraNyMfPny = P_3;
					return oToFLcqinEebyQqRdMgxJPMYXVH;
				}

				private IEnumerable<ActionElementMap> wAyIcjGTjfmHWUkrwDEAMBzILaTI(ControllerType P_0, int P_1, string P_2, bool P_3)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_2);
					return wAyIcjGTjfmHWUkrwDEAMBzILaTI(P_0, P_1, num, P_3);
				}

				private int dDTksWbQeoRPPFliOyNECYyeJbf(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					if (P_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_5)
					{
						P_4.Clear();
					}
					if (P_2 < 0)
					{
						return 0;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> maps = gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.Maps;
					for (int i = 0; i < maps.Count; i++)
					{
						ControllerMap controllerMap = maps[i];
						if ((!P_3 || controllerMap.enabled) && controllerMap.ContainsAction(P_2))
						{
							num2 += controllerMap.EwxUCWIjgNvgwPkYWOoxwAiADEI(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int dDTksWbQeoRPPFliOyNECYyeJbf(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_2);
					return dDTksWbQeoRPPFliOyNECYyeJbf(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int OpTXrUQqOmFypxKzfhOyCmXqSlp(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					if (P_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_5)
					{
						P_4.Clear();
					}
					if (P_2 < 0)
					{
						return 0;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> maps = gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.Maps;
					for (int i = 0; i < maps.Count; i++)
					{
						ControllerMapWithAxes controllerMapWithAxes = maps[i] as ControllerMapWithAxes;
						if (maps == null)
						{
							return num2;
						}
						if ((!P_3 || controllerMapWithAxes.enabled) && controllerMapWithAxes.ContainsAction(P_2))
						{
							num2 += controllerMapWithAxes.OPLgbMnDTUePxNEOivAOYPYzSya(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int OpTXrUQqOmFypxKzfhOyCmXqSlp(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_2);
					return OpTXrUQqOmFypxKzfhOyCmXqSlp(P_0, P_1, num, P_3, P_4, P_5);
				}

				private int KtPnmXjUixAFlwRskKIqsCmTKsY(ControllerType P_0, int P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					if (P_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_5)
					{
						P_4.Clear();
					}
					if (P_2 < 0)
					{
						return 0;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
					int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.iFNXApJjlWtDZdwedJFKpfGAMok(P_1);
					if (num < 0)
					{
						return 0;
					}
					int num2 = 0;
					IList<ControllerMap> maps = gqqVmTmEPnWlhtHJrWWOcCmltOt[num].mapSet.Maps;
					for (int i = 0; i < maps.Count; i++)
					{
						if ((!P_3 || maps[i].enabled) && maps[i].ContainsAction(P_2))
						{
							num2 += maps[i].paPqgnqavLYCqgponTssufOHcpc(P_2, P_3, P_4, true);
						}
					}
					return num2;
				}

				private int KtPnmXjUixAFlwRskKIqsCmTKsY(ControllerType P_0, int P_1, string P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(P_2);
					return KtPnmXjUixAFlwRskKIqsCmTKsY(P_0, P_1, num, P_3, P_4, P_5);
				}

				private ActionElementMap TythgSbwYmNijsQNDAZZfufNFdk(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
				{
					if (P_0 == null)
					{
						return null;
					}
					Controller controller = P_0.controller;
					if (controller == null)
					{
						return null;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controller.type);
					int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
					for (int i = 0; i < count; i++)
					{
						SaFIhRkKoaFsJonuErfrovvvDai mapSet = gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet;
						_ = mapSet.Count;
						IList<ControllerMap> maps = mapSet.Maps;
						int count2 = maps.Count;
						for (int j = 0; j < count2; j++)
						{
							ControllerMap controllerMap = maps[j];
							if (!P_3 || controllerMap.enabled)
							{
								bool flag;
								ActionElementMap actionElementMap = controllerMap.TythgSbwYmNijsQNDAZZfufNFdk(P_0, P_1, P_2, P_3, out flag);
								if (actionElementMap != null)
								{
									return actionElementMap;
								}
							}
						}
					}
					return null;
				}

				private IEnumerable<ActionElementMap> kjgLeqeVgoWsZfALHXWvGkZmDAM(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3)
				{
					lMZTHluAuWFFEhYQlbROeeVGkLIJ lMZTHluAuWFFEhYQlbROeeVGkLIJ2 = new lMZTHluAuWFFEhYQlbROeeVGkLIJ(-2);
					lMZTHluAuWFFEhYQlbROeeVGkLIJ2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					lMZTHluAuWFFEhYQlbROeeVGkLIJ2.JpiXZhoXgCfPNJtJyBDKpaqTCLOI = P_0;
					lMZTHluAuWFFEhYQlbROeeVGkLIJ2.mDMZcELkXRDZmNvYUejFJxqckgb = P_1;
					lMZTHluAuWFFEhYQlbROeeVGkLIJ2.gmlZVSBTtPIWuYPylEQcoNUGUio = P_2;
					lMZTHluAuWFFEhYQlbROeeVGkLIJ2.TGDalxAGxtEWicADkzmraNyMfPny = P_3;
					return lMZTHluAuWFFEhYQlbROeeVGkLIJ2;
				}

				private int VOIVoTgEPzUDZzgXkQydAIFJfLn(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5)
				{
					if (P_4 == null)
					{
						throw new ArgumentNullException("results");
					}
					if (!P_5)
					{
						P_4.Clear();
					}
					if (P_0 == null)
					{
						return 0;
					}
					Controller controller = P_0.controller;
					if (controller == null)
					{
						return 0;
					}
					GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = ugKyZyJTGtYLrHpCFnUKcqkaRKt.YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controller.type);
					int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
					int num = 0;
					for (int i = 0; i < count; i++)
					{
						SaFIhRkKoaFsJonuErfrovvvDai mapSet = gqqVmTmEPnWlhtHJrWWOcCmltOt[i].mapSet;
						_ = mapSet.Count;
						IList<ControllerMap> maps = mapSet.Maps;
						int count2 = maps.Count;
						for (int j = 0; j < count2; j++)
						{
							ControllerMap controllerMap = maps[j];
							if (!P_3 || controllerMap.enabled)
							{
								num += controllerMap.VOIVoTgEPzUDZzgXkQydAIFJfLn(P_0, P_1, P_2, P_3, P_4, P_5, out var _);
							}
						}
					}
					return num;
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class PollingHelper : CodeHelper
			{
				private sealed class WrXBXFcQqBMHXNrRtOlEczoiCYoe : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int sdUcfBHJKZrpwNGKHzcwwlwLVTI;

					public int qsPOrjVoFKLUWZUgvOumbnMylMT;

					public Joystick zMNXIwxWOBIRIFWVqawpQtmPPyr;

					public ControllerPollingInfo hltAclgeTBPFiGcWhkWPhFjhQPB;

					public ControllerPollingInfo TcmZCnbnlXdvMjlUtyNLtfkSmGP;

					public IEnumerator<ControllerPollingInfo> XAdYTMiqMenYmLMHQSntcttNNKN;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						WrXBXFcQqBMHXNrRtOlEczoiCYoe wrXBXFcQqBMHXNrRtOlEczoiCYoe;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							wrXBXFcQqBMHXNrRtOlEczoiCYoe = this;
						}
						else
						{
							wrXBXFcQqBMHXNrRtOlEczoiCYoe = new WrXBXFcQqBMHXNrRtOlEczoiCYoe(0);
							wrXBXFcQqBMHXNrRtOlEczoiCYoe.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						wrXBXFcQqBMHXNrRtOlEczoiCYoe.sdUcfBHJKZrpwNGKHzcwwlwLVTI = qsPOrjVoFKLUWZUgvOumbnMylMT;
						return wrXBXFcQqBMHXNrRtOlEczoiCYoe;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (sdUcfBHJKZrpwNGKHzcwwlwLVTI < 0)
								{
									break;
								}
								zMNXIwxWOBIRIFWVqawpQtmPPyr = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(sdUcfBHJKZrpwNGKHzcwwlwLVTI);
								if (zMNXIwxWOBIRIFWVqawpQtmPPyr == null)
								{
									break;
								}
								XAdYTMiqMenYmLMHQSntcttNNKN = zMNXIwxWOBIRIFWVqawpQtmPPyr.PollForAllElements().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00dc;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (XAdYTMiqMenYmLMHQSntcttNNKN.MoveNext())
								{
									hltAclgeTBPFiGcWhkWPhFjhQPB = XAdYTMiqMenYmLMHQSntcttNNKN.Current;
									ref ControllerPollingInfo tcmZCnbnlXdvMjlUtyNLtfkSmGP = ref TcmZCnbnlXdvMjlUtyNLtfkSmGP;
									tcmZCnbnlXdvMjlUtyNLtfkSmGP = new ControllerPollingInfo(hltAclgeTBPFiGcWhkWPhFjhQPB);
									TcmZCnbnlXdvMjlUtyNLtfkSmGP.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = TcmZCnbnlXdvMjlUtyNLtfkSmGP;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								JVagPLqMvbltFgIkMCcykGcfQFF();
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								JVagPLqMvbltFgIkMCcykGcfQFF();
							}
						}
					}

					[DebuggerHidden]
					public WrXBXFcQqBMHXNrRtOlEczoiCYoe(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void JVagPLqMvbltFgIkMCcykGcfQFF()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (XAdYTMiqMenYmLMHQSntcttNNKN != null)
						{
							XAdYTMiqMenYmLMHQSntcttNNKN.Dispose();
						}
					}
				}

				private sealed class SeOZvOnRhoPJpoTbAacigqMVpsQ : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int sdUcfBHJKZrpwNGKHzcwwlwLVTI;

					public int qsPOrjVoFKLUWZUgvOumbnMylMT;

					public Joystick xWTGDqOTINhLceHLPzArSFjQnmhw;

					public ControllerPollingInfo AlbyfqHtPRoOfxNFhDTDRgXjjOi;

					public ControllerPollingInfo BiJctAJeHNlArAMjYNVuPWKpLWz;

					public IEnumerator<ControllerPollingInfo> aHmSagmYbZNrQizKrrPOlqervyC;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						SeOZvOnRhoPJpoTbAacigqMVpsQ seOZvOnRhoPJpoTbAacigqMVpsQ;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							seOZvOnRhoPJpoTbAacigqMVpsQ = this;
						}
						else
						{
							seOZvOnRhoPJpoTbAacigqMVpsQ = new SeOZvOnRhoPJpoTbAacigqMVpsQ(0);
							seOZvOnRhoPJpoTbAacigqMVpsQ.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						seOZvOnRhoPJpoTbAacigqMVpsQ.sdUcfBHJKZrpwNGKHzcwwlwLVTI = qsPOrjVoFKLUWZUgvOumbnMylMT;
						return seOZvOnRhoPJpoTbAacigqMVpsQ;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (sdUcfBHJKZrpwNGKHzcwwlwLVTI < 0)
								{
									break;
								}
								xWTGDqOTINhLceHLPzArSFjQnmhw = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(sdUcfBHJKZrpwNGKHzcwwlwLVTI);
								if (xWTGDqOTINhLceHLPzArSFjQnmhw == null)
								{
									break;
								}
								aHmSagmYbZNrQizKrrPOlqervyC = xWTGDqOTINhLceHLPzArSFjQnmhw.PollForAllElementsDown().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00dc;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (aHmSagmYbZNrQizKrrPOlqervyC.MoveNext())
								{
									AlbyfqHtPRoOfxNFhDTDRgXjjOi = aHmSagmYbZNrQizKrrPOlqervyC.Current;
									ref ControllerPollingInfo biJctAJeHNlArAMjYNVuPWKpLWz = ref BiJctAJeHNlArAMjYNVuPWKpLWz;
									biJctAJeHNlArAMjYNVuPWKpLWz = new ControllerPollingInfo(AlbyfqHtPRoOfxNFhDTDRgXjjOi);
									BiJctAJeHNlArAMjYNVuPWKpLWz.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = BiJctAJeHNlArAMjYNVuPWKpLWz;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								gbohjLgJlPFllgGUjoRnqaXHVmA();
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								gbohjLgJlPFllgGUjoRnqaXHVmA();
							}
						}
					}

					[DebuggerHidden]
					public SeOZvOnRhoPJpoTbAacigqMVpsQ(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void gbohjLgJlPFllgGUjoRnqaXHVmA()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (aHmSagmYbZNrQizKrrPOlqervyC != null)
						{
							aHmSagmYbZNrQizKrrPOlqervyC.Dispose();
						}
					}
				}

				private sealed class cZjJBOnJdRGDaZURgNuuRufXDIB : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int sdUcfBHJKZrpwNGKHzcwwlwLVTI;

					public int qsPOrjVoFKLUWZUgvOumbnMylMT;

					public Joystick SpNtOqSwZVtHTrXXCoKDWdwVZhl;

					public ControllerPollingInfo kSpdOxLUGTDTbWslxhGYfsorzYhJ;

					public ControllerPollingInfo lKKhjYLNXmCbYcFFDuclHdMgHeC;

					public IEnumerator<ControllerPollingInfo> vjiyvccmWyBknRJPGLzreHXUEam;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						cZjJBOnJdRGDaZURgNuuRufXDIB cZjJBOnJdRGDaZURgNuuRufXDIB2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							cZjJBOnJdRGDaZURgNuuRufXDIB2 = this;
						}
						else
						{
							cZjJBOnJdRGDaZURgNuuRufXDIB2 = new cZjJBOnJdRGDaZURgNuuRufXDIB(0);
							cZjJBOnJdRGDaZURgNuuRufXDIB2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						cZjJBOnJdRGDaZURgNuuRufXDIB2.sdUcfBHJKZrpwNGKHzcwwlwLVTI = qsPOrjVoFKLUWZUgvOumbnMylMT;
						return cZjJBOnJdRGDaZURgNuuRufXDIB2;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (sdUcfBHJKZrpwNGKHzcwwlwLVTI < 0)
								{
									break;
								}
								SpNtOqSwZVtHTrXXCoKDWdwVZhl = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(sdUcfBHJKZrpwNGKHzcwwlwLVTI);
								if (SpNtOqSwZVtHTrXXCoKDWdwVZhl == null)
								{
									break;
								}
								vjiyvccmWyBknRJPGLzreHXUEam = SpNtOqSwZVtHTrXXCoKDWdwVZhl.PollForAllButtons().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00dc;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (vjiyvccmWyBknRJPGLzreHXUEam.MoveNext())
								{
									kSpdOxLUGTDTbWslxhGYfsorzYhJ = vjiyvccmWyBknRJPGLzreHXUEam.Current;
									ref ControllerPollingInfo reference = ref lKKhjYLNXmCbYcFFDuclHdMgHeC;
									reference = new ControllerPollingInfo(kSpdOxLUGTDTbWslxhGYfsorzYhJ);
									lKKhjYLNXmCbYcFFDuclHdMgHeC.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = lKKhjYLNXmCbYcFFDuclHdMgHeC;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								xkHASBdPLUQpbcMJNJbljozaGygH();
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								xkHASBdPLUQpbcMJNJbljozaGygH();
							}
						}
					}

					[DebuggerHidden]
					public cZjJBOnJdRGDaZURgNuuRufXDIB(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void xkHASBdPLUQpbcMJNJbljozaGygH()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (vjiyvccmWyBknRJPGLzreHXUEam != null)
						{
							vjiyvccmWyBknRJPGLzreHXUEam.Dispose();
						}
					}
				}

				private sealed class TVRspyWcQLpCoUdnrvwFGJekQpM : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int sdUcfBHJKZrpwNGKHzcwwlwLVTI;

					public int qsPOrjVoFKLUWZUgvOumbnMylMT;

					public Joystick BiJCeRjnSqBYnqpEODupNhdFBtiC;

					public ControllerPollingInfo iulthCrDByngZbNlwAuTeRnMjEeB;

					public ControllerPollingInfo ZMKmvSbIMMfGzfiAcayyzFLTxIg;

					public IEnumerator<ControllerPollingInfo> VIRZKmDyZHereXCQiCRFlRLlFOi;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						TVRspyWcQLpCoUdnrvwFGJekQpM tVRspyWcQLpCoUdnrvwFGJekQpM;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							tVRspyWcQLpCoUdnrvwFGJekQpM = this;
						}
						else
						{
							tVRspyWcQLpCoUdnrvwFGJekQpM = new TVRspyWcQLpCoUdnrvwFGJekQpM(0);
							tVRspyWcQLpCoUdnrvwFGJekQpM.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						tVRspyWcQLpCoUdnrvwFGJekQpM.sdUcfBHJKZrpwNGKHzcwwlwLVTI = qsPOrjVoFKLUWZUgvOumbnMylMT;
						return tVRspyWcQLpCoUdnrvwFGJekQpM;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (sdUcfBHJKZrpwNGKHzcwwlwLVTI < 0)
								{
									break;
								}
								BiJCeRjnSqBYnqpEODupNhdFBtiC = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(sdUcfBHJKZrpwNGKHzcwwlwLVTI);
								if (BiJCeRjnSqBYnqpEODupNhdFBtiC == null)
								{
									break;
								}
								VIRZKmDyZHereXCQiCRFlRLlFOi = BiJCeRjnSqBYnqpEODupNhdFBtiC.PollForAllButtonsDown().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00dc;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (VIRZKmDyZHereXCQiCRFlRLlFOi.MoveNext())
								{
									iulthCrDByngZbNlwAuTeRnMjEeB = VIRZKmDyZHereXCQiCRFlRLlFOi.Current;
									ref ControllerPollingInfo zMKmvSbIMMfGzfiAcayyzFLTxIg = ref ZMKmvSbIMMfGzfiAcayyzFLTxIg;
									zMKmvSbIMMfGzfiAcayyzFLTxIg = new ControllerPollingInfo(iulthCrDByngZbNlwAuTeRnMjEeB);
									ZMKmvSbIMMfGzfiAcayyzFLTxIg.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = ZMKmvSbIMMfGzfiAcayyzFLTxIg;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								McpBjBVhcpmKHTUXzBhnYtVdaIb();
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								McpBjBVhcpmKHTUXzBhnYtVdaIb();
							}
						}
					}

					[DebuggerHidden]
					public TVRspyWcQLpCoUdnrvwFGJekQpM(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void McpBjBVhcpmKHTUXzBhnYtVdaIb()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (VIRZKmDyZHereXCQiCRFlRLlFOi != null)
						{
							VIRZKmDyZHereXCQiCRFlRLlFOi.Dispose();
						}
					}
				}

				private sealed class HTbLyBVATzcgpdHgPPpyafrbcpaJ : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int sdUcfBHJKZrpwNGKHzcwwlwLVTI;

					public int qsPOrjVoFKLUWZUgvOumbnMylMT;

					public Joystick UGCKabptQijqAswWfXWAapeMfsK;

					public ControllerPollingInfo rdhFDTFXZmezlTFPAIFwWXbFkifT;

					public ControllerPollingInfo tkvcyIEqUDmqNwxPuBDWDdhkFVRK;

					public IEnumerator<ControllerPollingInfo> UJIViNhcbVBpzubZjalvLzIzUzc;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						HTbLyBVATzcgpdHgPPpyafrbcpaJ hTbLyBVATzcgpdHgPPpyafrbcpaJ;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							hTbLyBVATzcgpdHgPPpyafrbcpaJ = this;
						}
						else
						{
							hTbLyBVATzcgpdHgPPpyafrbcpaJ = new HTbLyBVATzcgpdHgPPpyafrbcpaJ(0);
							hTbLyBVATzcgpdHgPPpyafrbcpaJ.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						hTbLyBVATzcgpdHgPPpyafrbcpaJ.sdUcfBHJKZrpwNGKHzcwwlwLVTI = qsPOrjVoFKLUWZUgvOumbnMylMT;
						return hTbLyBVATzcgpdHgPPpyafrbcpaJ;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (sdUcfBHJKZrpwNGKHzcwwlwLVTI < 0)
								{
									break;
								}
								UGCKabptQijqAswWfXWAapeMfsK = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(sdUcfBHJKZrpwNGKHzcwwlwLVTI);
								if (UGCKabptQijqAswWfXWAapeMfsK == null)
								{
									break;
								}
								UJIViNhcbVBpzubZjalvLzIzUzc = UGCKabptQijqAswWfXWAapeMfsK.PollForAllAxes().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00dc;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (UJIViNhcbVBpzubZjalvLzIzUzc.MoveNext())
								{
									rdhFDTFXZmezlTFPAIFwWXbFkifT = UJIViNhcbVBpzubZjalvLzIzUzc.Current;
									ref ControllerPollingInfo reference = ref tkvcyIEqUDmqNwxPuBDWDdhkFVRK;
									reference = new ControllerPollingInfo(rdhFDTFXZmezlTFPAIFwWXbFkifT);
									tkvcyIEqUDmqNwxPuBDWDdhkFVRK.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = tkvcyIEqUDmqNwxPuBDWDdhkFVRK;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								WsKANfWnUFoUBHieZxvyljywbYi();
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								WsKANfWnUFoUBHieZxvyljywbYi();
							}
						}
					}

					[DebuggerHidden]
					public HTbLyBVATzcgpdHgPPpyafrbcpaJ(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void WsKANfWnUFoUBHieZxvyljywbYi()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (UJIViNhcbVBpzubZjalvLzIzUzc != null)
						{
							UJIViNhcbVBpzubZjalvLzIzUzc.Dispose();
						}
					}
				}

				private sealed class AlOxIHRejBBVAcHQIGQwPzoHpmQ : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IList<Joystick> vZeawaXEVTxXsSHpLXwhRkLaOpi;

					public int pkiRppyptjgWnHJBNkcBPPsNBojc;

					public int nZFFMbiuZmaaniePzOLSHHPpimdS;

					public ControllerPollingInfo UuDGMjIRuwlBKLsjcFnOiNQKEJs;

					public ControllerPollingInfo ZqJqNQzAgFhNWfsLwBqZOgebvFgU;

					public IEnumerator<ControllerPollingInfo> uGdnybUSxKQjYvFfDqPmHnFwwnI;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						AlOxIHRejBBVAcHQIGQwPzoHpmQ alOxIHRejBBVAcHQIGQwPzoHpmQ;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							alOxIHRejBBVAcHQIGQwPzoHpmQ = this;
						}
						else
						{
							alOxIHRejBBVAcHQIGQwPzoHpmQ = new AlOxIHRejBBVAcHQIGQwPzoHpmQ(0);
							alOxIHRejBBVAcHQIGQwPzoHpmQ.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return alOxIHRejBBVAcHQIGQwPzoHpmQ;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								vZeawaXEVTxXsSHpLXwhRkLaOpi = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Controllers_readOnly;
								pkiRppyptjgWnHJBNkcBPPsNBojc = vZeawaXEVTxXsSHpLXwhRkLaOpi.Count;
								nZFFMbiuZmaaniePzOLSHHPpimdS = 0;
								goto IL_0108;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (nZFFMbiuZmaaniePzOLSHHPpimdS >= pkiRppyptjgWnHJBNkcBPPsNBojc)
								{
									break;
								}
								uGdnybUSxKQjYvFfDqPmHnFwwnI = vZeawaXEVTxXsSHpLXwhRkLaOpi[nZFFMbiuZmaaniePzOLSHHPpimdS].PollForAllElements().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00e7;
								IL_00e7:
								if (uGdnybUSxKQjYvFfDqPmHnFwwnI.MoveNext())
								{
									UuDGMjIRuwlBKLsjcFnOiNQKEJs = uGdnybUSxKQjYvFfDqPmHnFwwnI.Current;
									ref ControllerPollingInfo zqJqNQzAgFhNWfsLwBqZOgebvFgU = ref ZqJqNQzAgFhNWfsLwBqZOgebvFgU;
									zqJqNQzAgFhNWfsLwBqZOgebvFgU = new ControllerPollingInfo(UuDGMjIRuwlBKLsjcFnOiNQKEJs);
									ZqJqNQzAgFhNWfsLwBqZOgebvFgU.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = ZqJqNQzAgFhNWfsLwBqZOgebvFgU;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								svfAKtvaxJaQdxluRBXFHvBpXNu();
								nZFFMbiuZmaaniePzOLSHHPpimdS++;
								goto IL_0108;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								svfAKtvaxJaQdxluRBXFHvBpXNu();
							}
						}
					}

					[DebuggerHidden]
					public AlOxIHRejBBVAcHQIGQwPzoHpmQ(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void svfAKtvaxJaQdxluRBXFHvBpXNu()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (uGdnybUSxKQjYvFfDqPmHnFwwnI != null)
						{
							uGdnybUSxKQjYvFfDqPmHnFwwnI.Dispose();
						}
					}
				}

				private sealed class sTDdIOKGgepZrTrgalKhuFkVMix : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IList<Joystick> kMpXCGlVRjmvIZahCMTTwSyjMtW;

					public int QzNoqYfrtqHrmYzvxBSvVcXfazRb;

					public int XYQKNKrGUxbTLvUGtMbezZQZLaf;

					public ControllerPollingInfo bKMyxqDjgPBvirJVLJBezEqquBM;

					public ControllerPollingInfo pmrnnDcKfaeKJoBOuedaoPQuFYe;

					public IEnumerator<ControllerPollingInfo> YMjoIYzFreWGOBGmsHqbrffdmci;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						sTDdIOKGgepZrTrgalKhuFkVMix sTDdIOKGgepZrTrgalKhuFkVMix2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							sTDdIOKGgepZrTrgalKhuFkVMix2 = this;
						}
						else
						{
							sTDdIOKGgepZrTrgalKhuFkVMix2 = new sTDdIOKGgepZrTrgalKhuFkVMix(0);
							sTDdIOKGgepZrTrgalKhuFkVMix2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return sTDdIOKGgepZrTrgalKhuFkVMix2;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								kMpXCGlVRjmvIZahCMTTwSyjMtW = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Controllers_readOnly;
								QzNoqYfrtqHrmYzvxBSvVcXfazRb = kMpXCGlVRjmvIZahCMTTwSyjMtW.Count;
								XYQKNKrGUxbTLvUGtMbezZQZLaf = 0;
								goto IL_0108;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (XYQKNKrGUxbTLvUGtMbezZQZLaf >= QzNoqYfrtqHrmYzvxBSvVcXfazRb)
								{
									break;
								}
								YMjoIYzFreWGOBGmsHqbrffdmci = kMpXCGlVRjmvIZahCMTTwSyjMtW[XYQKNKrGUxbTLvUGtMbezZQZLaf].PollForAllElementsDown().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00e7;
								IL_00e7:
								if (YMjoIYzFreWGOBGmsHqbrffdmci.MoveNext())
								{
									bKMyxqDjgPBvirJVLJBezEqquBM = YMjoIYzFreWGOBGmsHqbrffdmci.Current;
									ref ControllerPollingInfo reference = ref pmrnnDcKfaeKJoBOuedaoPQuFYe;
									reference = new ControllerPollingInfo(bKMyxqDjgPBvirJVLJBezEqquBM);
									pmrnnDcKfaeKJoBOuedaoPQuFYe.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = pmrnnDcKfaeKJoBOuedaoPQuFYe;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								EXJhVZJBkDgXnVPyDgCyZwlXjaU();
								XYQKNKrGUxbTLvUGtMbezZQZLaf++;
								goto IL_0108;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								EXJhVZJBkDgXnVPyDgCyZwlXjaU();
							}
						}
					}

					[DebuggerHidden]
					public sTDdIOKGgepZrTrgalKhuFkVMix(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void EXJhVZJBkDgXnVPyDgCyZwlXjaU()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (YMjoIYzFreWGOBGmsHqbrffdmci != null)
						{
							YMjoIYzFreWGOBGmsHqbrffdmci.Dispose();
						}
					}
				}

				private sealed class UpdCdTbImTKgAnJfJhLDEGuwzwb : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IList<Joystick> ylZnqzfOnorPyFyYyhYhgUqjmuW;

					public int IlWLBkKAALdkdzfSahJuhQdFOLQ;

					public int ERrxIaofckXuSQQjDpzkgnOocDk;

					public ControllerPollingInfo ZTMqeHJayuFKdaWriXYsADnXpSE;

					public ControllerPollingInfo XJvVnJoUfcNiXMXcGjFamckikHC;

					public IEnumerator<ControllerPollingInfo> HbaAKxAsnjAnBeRmGQiFrXJlckn;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						UpdCdTbImTKgAnJfJhLDEGuwzwb updCdTbImTKgAnJfJhLDEGuwzwb;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							updCdTbImTKgAnJfJhLDEGuwzwb = this;
						}
						else
						{
							updCdTbImTKgAnJfJhLDEGuwzwb = new UpdCdTbImTKgAnJfJhLDEGuwzwb(0);
							updCdTbImTKgAnJfJhLDEGuwzwb.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return updCdTbImTKgAnJfJhLDEGuwzwb;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								ylZnqzfOnorPyFyYyhYhgUqjmuW = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Controllers_readOnly;
								IlWLBkKAALdkdzfSahJuhQdFOLQ = ylZnqzfOnorPyFyYyhYhgUqjmuW.Count;
								ERrxIaofckXuSQQjDpzkgnOocDk = 0;
								goto IL_0108;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (ERrxIaofckXuSQQjDpzkgnOocDk >= IlWLBkKAALdkdzfSahJuhQdFOLQ)
								{
									break;
								}
								HbaAKxAsnjAnBeRmGQiFrXJlckn = ylZnqzfOnorPyFyYyhYhgUqjmuW[ERrxIaofckXuSQQjDpzkgnOocDk].PollForAllButtons().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00e7;
								IL_00e7:
								if (HbaAKxAsnjAnBeRmGQiFrXJlckn.MoveNext())
								{
									ZTMqeHJayuFKdaWriXYsADnXpSE = HbaAKxAsnjAnBeRmGQiFrXJlckn.Current;
									ref ControllerPollingInfo xJvVnJoUfcNiXMXcGjFamckikHC = ref XJvVnJoUfcNiXMXcGjFamckikHC;
									xJvVnJoUfcNiXMXcGjFamckikHC = new ControllerPollingInfo(ZTMqeHJayuFKdaWriXYsADnXpSE);
									XJvVnJoUfcNiXMXcGjFamckikHC.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = XJvVnJoUfcNiXMXcGjFamckikHC;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								nBSgllrNwJhkTpZGfPeLSEnksIW();
								ERrxIaofckXuSQQjDpzkgnOocDk++;
								goto IL_0108;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								nBSgllrNwJhkTpZGfPeLSEnksIW();
							}
						}
					}

					[DebuggerHidden]
					public UpdCdTbImTKgAnJfJhLDEGuwzwb(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void nBSgllrNwJhkTpZGfPeLSEnksIW()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (HbaAKxAsnjAnBeRmGQiFrXJlckn != null)
						{
							HbaAKxAsnjAnBeRmGQiFrXJlckn.Dispose();
						}
					}
				}

				private sealed class ebTNikTVRrNOmXMKNLjjDsgMCmJ : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IList<Joystick> MAMQrAITAnweYsppmKFMAWSjLKf;

					public int SSscxrkunsDstnLQXythieTQXpt;

					public int vkpDEGkAizAigFQRRFIrtaSCYypI;

					public ControllerPollingInfo jJCJuRdjaiAcQCiiUXItfMiUGZ;

					public ControllerPollingInfo uxBcnSelFEqsDVElrlDIRXYlRwdA;

					public IEnumerator<ControllerPollingInfo> tLaakIkjGohSwYTpXoEkpWeNtIq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						ebTNikTVRrNOmXMKNLjjDsgMCmJ ebTNikTVRrNOmXMKNLjjDsgMCmJ2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							ebTNikTVRrNOmXMKNLjjDsgMCmJ2 = this;
						}
						else
						{
							ebTNikTVRrNOmXMKNLjjDsgMCmJ2 = new ebTNikTVRrNOmXMKNLjjDsgMCmJ(0);
							ebTNikTVRrNOmXMKNLjjDsgMCmJ2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return ebTNikTVRrNOmXMKNLjjDsgMCmJ2;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								MAMQrAITAnweYsppmKFMAWSjLKf = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Controllers_readOnly;
								SSscxrkunsDstnLQXythieTQXpt = MAMQrAITAnweYsppmKFMAWSjLKf.Count;
								vkpDEGkAizAigFQRRFIrtaSCYypI = 0;
								goto IL_0108;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (vkpDEGkAizAigFQRRFIrtaSCYypI >= SSscxrkunsDstnLQXythieTQXpt)
								{
									break;
								}
								tLaakIkjGohSwYTpXoEkpWeNtIq = MAMQrAITAnweYsppmKFMAWSjLKf[vkpDEGkAizAigFQRRFIrtaSCYypI].PollForAllButtonsDown().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00e7;
								IL_00e7:
								if (tLaakIkjGohSwYTpXoEkpWeNtIq.MoveNext())
								{
									jJCJuRdjaiAcQCiiUXItfMiUGZ = tLaakIkjGohSwYTpXoEkpWeNtIq.Current;
									ref ControllerPollingInfo reference = ref uxBcnSelFEqsDVElrlDIRXYlRwdA;
									reference = new ControllerPollingInfo(jJCJuRdjaiAcQCiiUXItfMiUGZ);
									uxBcnSelFEqsDVElrlDIRXYlRwdA.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = uxBcnSelFEqsDVElrlDIRXYlRwdA;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								ZYECXYTSykGcCUmNbtnEEnEGusE();
								vkpDEGkAizAigFQRRFIrtaSCYypI++;
								goto IL_0108;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								ZYECXYTSykGcCUmNbtnEEnEGusE();
							}
						}
					}

					[DebuggerHidden]
					public ebTNikTVRrNOmXMKNLjjDsgMCmJ(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void ZYECXYTSykGcCUmNbtnEEnEGusE()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (tLaakIkjGohSwYTpXoEkpWeNtIq != null)
						{
							tLaakIkjGohSwYTpXoEkpWeNtIq.Dispose();
						}
					}
				}

				private sealed class zsQsjexUNrPxumBfEGRvRbuNTZa : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IList<Joystick> RRhWccfBztBXMjJwqJxRYjAksBB;

					public int yYCBRGhvfiQsodnEqmueOigwSZmR;

					public int hSAfUhFfPexQjmvvHCNfHNBHaWJ;

					public ControllerPollingInfo aTmfLxSvsNrXySURGmIounIybwp;

					public ControllerPollingInfo ZskNqPrkUfKULKjxvLBRyAfnePYF;

					public IEnumerator<ControllerPollingInfo> OmNttQKbqVVtgtCJYqKFJZMoOXA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						zsQsjexUNrPxumBfEGRvRbuNTZa zsQsjexUNrPxumBfEGRvRbuNTZa2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							zsQsjexUNrPxumBfEGRvRbuNTZa2 = this;
						}
						else
						{
							zsQsjexUNrPxumBfEGRvRbuNTZa2 = new zsQsjexUNrPxumBfEGRvRbuNTZa(0);
							zsQsjexUNrPxumBfEGRvRbuNTZa2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return zsQsjexUNrPxumBfEGRvRbuNTZa2;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								RRhWccfBztBXMjJwqJxRYjAksBB = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Controllers_readOnly;
								yYCBRGhvfiQsodnEqmueOigwSZmR = RRhWccfBztBXMjJwqJxRYjAksBB.Count;
								hSAfUhFfPexQjmvvHCNfHNBHaWJ = 0;
								goto IL_0108;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (hSAfUhFfPexQjmvvHCNfHNBHaWJ >= yYCBRGhvfiQsodnEqmueOigwSZmR)
								{
									break;
								}
								OmNttQKbqVVtgtCJYqKFJZMoOXA = RRhWccfBztBXMjJwqJxRYjAksBB[hSAfUhFfPexQjmvvHCNfHNBHaWJ].PollForAllAxes().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00e7;
								IL_00e7:
								if (OmNttQKbqVVtgtCJYqKFJZMoOXA.MoveNext())
								{
									aTmfLxSvsNrXySURGmIounIybwp = OmNttQKbqVVtgtCJYqKFJZMoOXA.Current;
									ref ControllerPollingInfo zskNqPrkUfKULKjxvLBRyAfnePYF = ref ZskNqPrkUfKULKjxvLBRyAfnePYF;
									zskNqPrkUfKULKjxvLBRyAfnePYF = new ControllerPollingInfo(aTmfLxSvsNrXySURGmIounIybwp);
									ZskNqPrkUfKULKjxvLBRyAfnePYF.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = ZskNqPrkUfKULKjxvLBRyAfnePYF;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								wInIMyYGXfVnLQIBMzaZbaqfXno();
								hSAfUhFfPexQjmvvHCNfHNBHaWJ++;
								goto IL_0108;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								wInIMyYGXfVnLQIBMzaZbaqfXno();
							}
						}
					}

					[DebuggerHidden]
					public zsQsjexUNrPxumBfEGRvRbuNTZa(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void wInIMyYGXfVnLQIBMzaZbaqfXno()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (OmNttQKbqVVtgtCJYqKFJZMoOXA != null)
						{
							OmNttQKbqVVtgtCJYqKFJZMoOXA.Dispose();
						}
					}
				}

				private sealed class YodOcKufkqjshRGxlJDHVfvpAZu : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int tXqXJTjBxuSTGyameRbOFiBRaTk;

					public int zhMonKvpOLkvrBNtkyLqdqaacQk;

					public CustomController gzSpDWkUeRptKNzLfsyZxbzgQQI;

					public ControllerPollingInfo mSVmkPFcPYjdBbdQWzyvEuDtrAOa;

					public ControllerPollingInfo PGfilwHZTQXvugvjeyrzzNfUpzf;

					public IEnumerator<ControllerPollingInfo> ltIpgTBHXGFvboTBNmJuNyqOrxr;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						YodOcKufkqjshRGxlJDHVfvpAZu yodOcKufkqjshRGxlJDHVfvpAZu;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							yodOcKufkqjshRGxlJDHVfvpAZu = this;
						}
						else
						{
							yodOcKufkqjshRGxlJDHVfvpAZu = new YodOcKufkqjshRGxlJDHVfvpAZu(0);
							yodOcKufkqjshRGxlJDHVfvpAZu.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						yodOcKufkqjshRGxlJDHVfvpAZu.tXqXJTjBxuSTGyameRbOFiBRaTk = zhMonKvpOLkvrBNtkyLqdqaacQk;
						return yodOcKufkqjshRGxlJDHVfvpAZu;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (tXqXJTjBxuSTGyameRbOFiBRaTk < 0)
								{
									break;
								}
								gzSpDWkUeRptKNzLfsyZxbzgQQI = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(tXqXJTjBxuSTGyameRbOFiBRaTk);
								if (gzSpDWkUeRptKNzLfsyZxbzgQQI == null)
								{
									break;
								}
								ltIpgTBHXGFvboTBNmJuNyqOrxr = gzSpDWkUeRptKNzLfsyZxbzgQQI.PollForAllElements().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00dc;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (ltIpgTBHXGFvboTBNmJuNyqOrxr.MoveNext())
								{
									mSVmkPFcPYjdBbdQWzyvEuDtrAOa = ltIpgTBHXGFvboTBNmJuNyqOrxr.Current;
									ref ControllerPollingInfo pGfilwHZTQXvugvjeyrzzNfUpzf = ref PGfilwHZTQXvugvjeyrzzNfUpzf;
									pGfilwHZTQXvugvjeyrzzNfUpzf = new ControllerPollingInfo(mSVmkPFcPYjdBbdQWzyvEuDtrAOa);
									PGfilwHZTQXvugvjeyrzzNfUpzf.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = PGfilwHZTQXvugvjeyrzzNfUpzf;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								muEPuIGljRjrCEJJrIljcTwwWni();
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								muEPuIGljRjrCEJJrIljcTwwWni();
							}
						}
					}

					[DebuggerHidden]
					public YodOcKufkqjshRGxlJDHVfvpAZu(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void muEPuIGljRjrCEJJrIljcTwwWni()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (ltIpgTBHXGFvboTBNmJuNyqOrxr != null)
						{
							ltIpgTBHXGFvboTBNmJuNyqOrxr.Dispose();
						}
					}
				}

				private sealed class dNZaSFJyKaPiBVcCklZFfnyCrCns : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int tXqXJTjBxuSTGyameRbOFiBRaTk;

					public int zhMonKvpOLkvrBNtkyLqdqaacQk;

					public CustomController TnYvRkFewfBWSHyRWhxjsJrQRPqh;

					public ControllerPollingInfo VDUGQvgOjImIpYCvTJTAGeFBpfYN;

					public ControllerPollingInfo gksAzZiZyYNifOrSxOoLPRRFMwr;

					public IEnumerator<ControllerPollingInfo> eYpvOUxgFSjgrdHDpKmoGrZZsAC;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						dNZaSFJyKaPiBVcCklZFfnyCrCns dNZaSFJyKaPiBVcCklZFfnyCrCns2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							dNZaSFJyKaPiBVcCklZFfnyCrCns2 = this;
						}
						else
						{
							dNZaSFJyKaPiBVcCklZFfnyCrCns2 = new dNZaSFJyKaPiBVcCklZFfnyCrCns(0);
							dNZaSFJyKaPiBVcCklZFfnyCrCns2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						dNZaSFJyKaPiBVcCklZFfnyCrCns2.tXqXJTjBxuSTGyameRbOFiBRaTk = zhMonKvpOLkvrBNtkyLqdqaacQk;
						return dNZaSFJyKaPiBVcCklZFfnyCrCns2;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (tXqXJTjBxuSTGyameRbOFiBRaTk < 0)
								{
									break;
								}
								TnYvRkFewfBWSHyRWhxjsJrQRPqh = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(tXqXJTjBxuSTGyameRbOFiBRaTk);
								if (TnYvRkFewfBWSHyRWhxjsJrQRPqh == null)
								{
									break;
								}
								eYpvOUxgFSjgrdHDpKmoGrZZsAC = TnYvRkFewfBWSHyRWhxjsJrQRPqh.PollForAllElementsDown().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00dc;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (eYpvOUxgFSjgrdHDpKmoGrZZsAC.MoveNext())
								{
									VDUGQvgOjImIpYCvTJTAGeFBpfYN = eYpvOUxgFSjgrdHDpKmoGrZZsAC.Current;
									ref ControllerPollingInfo reference = ref gksAzZiZyYNifOrSxOoLPRRFMwr;
									reference = new ControllerPollingInfo(VDUGQvgOjImIpYCvTJTAGeFBpfYN);
									gksAzZiZyYNifOrSxOoLPRRFMwr.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = gksAzZiZyYNifOrSxOoLPRRFMwr;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								zvoAHEOExThhdNEDwFtRHdrJyOw();
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								zvoAHEOExThhdNEDwFtRHdrJyOw();
							}
						}
					}

					[DebuggerHidden]
					public dNZaSFJyKaPiBVcCklZFfnyCrCns(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void zvoAHEOExThhdNEDwFtRHdrJyOw()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (eYpvOUxgFSjgrdHDpKmoGrZZsAC != null)
						{
							eYpvOUxgFSjgrdHDpKmoGrZZsAC.Dispose();
						}
					}
				}

				private sealed class qOtkSsBHxxabFvRdzOOgTnFuKeq : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int tXqXJTjBxuSTGyameRbOFiBRaTk;

					public int zhMonKvpOLkvrBNtkyLqdqaacQk;

					public CustomController PpJqwHPMoLcqbqRVfdPAFneocCZC;

					public ControllerPollingInfo GPSOHqRIJNYOGmPFRCHgUjxMVUU;

					public ControllerPollingInfo aXbcoIYjFacYRMiAqylcFRfXkfQ;

					public IEnumerator<ControllerPollingInfo> zxzFRFsiBHAJUhVuWYUOxwDfFPu;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						qOtkSsBHxxabFvRdzOOgTnFuKeq qOtkSsBHxxabFvRdzOOgTnFuKeq2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							qOtkSsBHxxabFvRdzOOgTnFuKeq2 = this;
						}
						else
						{
							qOtkSsBHxxabFvRdzOOgTnFuKeq2 = new qOtkSsBHxxabFvRdzOOgTnFuKeq(0);
							qOtkSsBHxxabFvRdzOOgTnFuKeq2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						qOtkSsBHxxabFvRdzOOgTnFuKeq2.tXqXJTjBxuSTGyameRbOFiBRaTk = zhMonKvpOLkvrBNtkyLqdqaacQk;
						return qOtkSsBHxxabFvRdzOOgTnFuKeq2;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (tXqXJTjBxuSTGyameRbOFiBRaTk < 0)
								{
									break;
								}
								PpJqwHPMoLcqbqRVfdPAFneocCZC = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(tXqXJTjBxuSTGyameRbOFiBRaTk);
								if (PpJqwHPMoLcqbqRVfdPAFneocCZC == null)
								{
									break;
								}
								zxzFRFsiBHAJUhVuWYUOxwDfFPu = PpJqwHPMoLcqbqRVfdPAFneocCZC.PollForAllButtons().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00dc;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (zxzFRFsiBHAJUhVuWYUOxwDfFPu.MoveNext())
								{
									GPSOHqRIJNYOGmPFRCHgUjxMVUU = zxzFRFsiBHAJUhVuWYUOxwDfFPu.Current;
									ref ControllerPollingInfo reference = ref aXbcoIYjFacYRMiAqylcFRfXkfQ;
									reference = new ControllerPollingInfo(GPSOHqRIJNYOGmPFRCHgUjxMVUU);
									aXbcoIYjFacYRMiAqylcFRfXkfQ.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = aXbcoIYjFacYRMiAqylcFRfXkfQ;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								XBohOkDbDFwyUevYYAfjWmlDbXF();
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								XBohOkDbDFwyUevYYAfjWmlDbXF();
							}
						}
					}

					[DebuggerHidden]
					public qOtkSsBHxxabFvRdzOOgTnFuKeq(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void XBohOkDbDFwyUevYYAfjWmlDbXF()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (zxzFRFsiBHAJUhVuWYUOxwDfFPu != null)
						{
							zxzFRFsiBHAJUhVuWYUOxwDfFPu.Dispose();
						}
					}
				}

				private sealed class vdfsdNWDfepUKOHAitwyKmqrZor : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int tXqXJTjBxuSTGyameRbOFiBRaTk;

					public int zhMonKvpOLkvrBNtkyLqdqaacQk;

					public CustomController FojtpgBUCONfuxMUdUCMzVQXQnS;

					public ControllerPollingInfo BllzYfanDHosKBugriFIMkuxVMu;

					public ControllerPollingInfo QdQbpXOuOPeyoWrLwgDvJBevSlt;

					public IEnumerator<ControllerPollingInfo> BTTtYmPaBObQdFoYUdwhccFWXPkV;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						vdfsdNWDfepUKOHAitwyKmqrZor vdfsdNWDfepUKOHAitwyKmqrZor2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							vdfsdNWDfepUKOHAitwyKmqrZor2 = this;
						}
						else
						{
							vdfsdNWDfepUKOHAitwyKmqrZor2 = new vdfsdNWDfepUKOHAitwyKmqrZor(0);
							vdfsdNWDfepUKOHAitwyKmqrZor2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						vdfsdNWDfepUKOHAitwyKmqrZor2.tXqXJTjBxuSTGyameRbOFiBRaTk = zhMonKvpOLkvrBNtkyLqdqaacQk;
						return vdfsdNWDfepUKOHAitwyKmqrZor2;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (tXqXJTjBxuSTGyameRbOFiBRaTk < 0)
								{
									break;
								}
								FojtpgBUCONfuxMUdUCMzVQXQnS = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(tXqXJTjBxuSTGyameRbOFiBRaTk);
								if (FojtpgBUCONfuxMUdUCMzVQXQnS == null)
								{
									break;
								}
								BTTtYmPaBObQdFoYUdwhccFWXPkV = FojtpgBUCONfuxMUdUCMzVQXQnS.PollForAllButtonsDown().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00dc;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (BTTtYmPaBObQdFoYUdwhccFWXPkV.MoveNext())
								{
									BllzYfanDHosKBugriFIMkuxVMu = BTTtYmPaBObQdFoYUdwhccFWXPkV.Current;
									ref ControllerPollingInfo qdQbpXOuOPeyoWrLwgDvJBevSlt = ref QdQbpXOuOPeyoWrLwgDvJBevSlt;
									qdQbpXOuOPeyoWrLwgDvJBevSlt = new ControllerPollingInfo(BllzYfanDHosKBugriFIMkuxVMu);
									QdQbpXOuOPeyoWrLwgDvJBevSlt.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = QdQbpXOuOPeyoWrLwgDvJBevSlt;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								LZbeweDTnElnUWwCUylZbaxvfKlq();
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								LZbeweDTnElnUWwCUylZbaxvfKlq();
							}
						}
					}

					[DebuggerHidden]
					public vdfsdNWDfepUKOHAitwyKmqrZor(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void LZbeweDTnElnUWwCUylZbaxvfKlq()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (BTTtYmPaBObQdFoYUdwhccFWXPkV != null)
						{
							BTTtYmPaBObQdFoYUdwhccFWXPkV.Dispose();
						}
					}
				}

				private sealed class ghUEBeGuldFdNsJSZeFDQaSdqz : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public int tXqXJTjBxuSTGyameRbOFiBRaTk;

					public int zhMonKvpOLkvrBNtkyLqdqaacQk;

					public CustomController QLXeQFgzkRSrGlWfpkNspsXbmC;

					public ControllerPollingInfo eEmnagwAocLNzxGzltoAsWJVLpH;

					public ControllerPollingInfo LMQcrjqOOPAuWthbFQXZnpdJFXR;

					public IEnumerator<ControllerPollingInfo> GlwMkepCFjAOMvWmqazklcTEFka;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						ghUEBeGuldFdNsJSZeFDQaSdqz ghUEBeGuldFdNsJSZeFDQaSdqz2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							ghUEBeGuldFdNsJSZeFDQaSdqz2 = this;
						}
						else
						{
							ghUEBeGuldFdNsJSZeFDQaSdqz2 = new ghUEBeGuldFdNsJSZeFDQaSdqz(0);
							ghUEBeGuldFdNsJSZeFDQaSdqz2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						ghUEBeGuldFdNsJSZeFDQaSdqz2.tXqXJTjBxuSTGyameRbOFiBRaTk = zhMonKvpOLkvrBNtkyLqdqaacQk;
						return ghUEBeGuldFdNsJSZeFDQaSdqz2;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (tXqXJTjBxuSTGyameRbOFiBRaTk < 0)
								{
									break;
								}
								QLXeQFgzkRSrGlWfpkNspsXbmC = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(tXqXJTjBxuSTGyameRbOFiBRaTk);
								if (QLXeQFgzkRSrGlWfpkNspsXbmC == null)
								{
									break;
								}
								GlwMkepCFjAOMvWmqazklcTEFka = QLXeQFgzkRSrGlWfpkNspsXbmC.PollForAllAxes().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00dc;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00dc;
								}
								IL_00dc:
								if (GlwMkepCFjAOMvWmqazklcTEFka.MoveNext())
								{
									eEmnagwAocLNzxGzltoAsWJVLpH = GlwMkepCFjAOMvWmqazklcTEFka.Current;
									ref ControllerPollingInfo lMQcrjqOOPAuWthbFQXZnpdJFXR = ref LMQcrjqOOPAuWthbFQXZnpdJFXR;
									lMQcrjqOOPAuWthbFQXZnpdJFXR = new ControllerPollingInfo(eEmnagwAocLNzxGzltoAsWJVLpH);
									LMQcrjqOOPAuWthbFQXZnpdJFXR.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = LMQcrjqOOPAuWthbFQXZnpdJFXR;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								UwKEHdSfCcASmWVLIjhSEFXklNR();
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								UwKEHdSfCcASmWVLIjhSEFXklNR();
							}
						}
					}

					[DebuggerHidden]
					public ghUEBeGuldFdNsJSZeFDQaSdqz(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void UwKEHdSfCcASmWVLIjhSEFXklNR()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (GlwMkepCFjAOMvWmqazklcTEFka != null)
						{
							GlwMkepCFjAOMvWmqazklcTEFka.Dispose();
						}
					}
				}

				private sealed class VVuSvErERkWjFlBsDhhWLVxeGOL : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IList<CustomController> tElQcekUyExwMXhWOrXmrDbnHrx;

					public int bbVvYfxleXuaadGruDRSwFnDEUw;

					public int OXBuNoSOfLEyQIKcbVwKkErrZYo;

					public ControllerPollingInfo iOvOYueSKmBAUGWvUMppXOyplpo;

					public ControllerPollingInfo AEWudmUTJnZCLpIAxbOJJhUdGkq;

					public IEnumerator<ControllerPollingInfo> XUIWwsCeVjtrgljiQfuvDexldW;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						VVuSvErERkWjFlBsDhhWLVxeGOL vVuSvErERkWjFlBsDhhWLVxeGOL;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							vVuSvErERkWjFlBsDhhWLVxeGOL = this;
						}
						else
						{
							vVuSvErERkWjFlBsDhhWLVxeGOL = new VVuSvErERkWjFlBsDhhWLVxeGOL(0);
							vVuSvErERkWjFlBsDhhWLVxeGOL.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return vVuSvErERkWjFlBsDhhWLVxeGOL;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								tElQcekUyExwMXhWOrXmrDbnHrx = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Controllers_readOnly;
								bbVvYfxleXuaadGruDRSwFnDEUw = tElQcekUyExwMXhWOrXmrDbnHrx.Count;
								OXBuNoSOfLEyQIKcbVwKkErrZYo = 0;
								goto IL_0108;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (OXBuNoSOfLEyQIKcbVwKkErrZYo >= bbVvYfxleXuaadGruDRSwFnDEUw)
								{
									break;
								}
								XUIWwsCeVjtrgljiQfuvDexldW = tElQcekUyExwMXhWOrXmrDbnHrx[OXBuNoSOfLEyQIKcbVwKkErrZYo].PollForAllElements().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00e7;
								IL_00e7:
								if (XUIWwsCeVjtrgljiQfuvDexldW.MoveNext())
								{
									iOvOYueSKmBAUGWvUMppXOyplpo = XUIWwsCeVjtrgljiQfuvDexldW.Current;
									ref ControllerPollingInfo aEWudmUTJnZCLpIAxbOJJhUdGkq = ref AEWudmUTJnZCLpIAxbOJJhUdGkq;
									aEWudmUTJnZCLpIAxbOJJhUdGkq = new ControllerPollingInfo(iOvOYueSKmBAUGWvUMppXOyplpo);
									AEWudmUTJnZCLpIAxbOJJhUdGkq.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = AEWudmUTJnZCLpIAxbOJJhUdGkq;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								VZimGCvPssYoxImilllfEXXqGgh();
								OXBuNoSOfLEyQIKcbVwKkErrZYo++;
								goto IL_0108;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								VZimGCvPssYoxImilllfEXXqGgh();
							}
						}
					}

					[DebuggerHidden]
					public VVuSvErERkWjFlBsDhhWLVxeGOL(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void VZimGCvPssYoxImilllfEXXqGgh()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (XUIWwsCeVjtrgljiQfuvDexldW != null)
						{
							XUIWwsCeVjtrgljiQfuvDexldW.Dispose();
						}
					}
				}

				private sealed class inVjMGgaHrZnqUfLjXUDoeRCiZj : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IList<CustomController> RIQaLUoMWeoYkmJQdWmwWPPxUFI;

					public int zucAIBaAAfDqqtchhqcNttpWJsC;

					public int XMJwIhCfqqXkWvantRpJWHSBoOS;

					public ControllerPollingInfo yrdFsHkeMARJxswSfbuXWAAfMwQ;

					public ControllerPollingInfo OqyjOinnaioClcifMTXphcTxwkN;

					public IEnumerator<ControllerPollingInfo> dvkllTYcygNrtWBxpPjXKLRItBb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						inVjMGgaHrZnqUfLjXUDoeRCiZj inVjMGgaHrZnqUfLjXUDoeRCiZj2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							inVjMGgaHrZnqUfLjXUDoeRCiZj2 = this;
						}
						else
						{
							inVjMGgaHrZnqUfLjXUDoeRCiZj2 = new inVjMGgaHrZnqUfLjXUDoeRCiZj(0);
							inVjMGgaHrZnqUfLjXUDoeRCiZj2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return inVjMGgaHrZnqUfLjXUDoeRCiZj2;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								RIQaLUoMWeoYkmJQdWmwWPPxUFI = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Controllers_readOnly;
								zucAIBaAAfDqqtchhqcNttpWJsC = RIQaLUoMWeoYkmJQdWmwWPPxUFI.Count;
								XMJwIhCfqqXkWvantRpJWHSBoOS = 0;
								goto IL_0108;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (XMJwIhCfqqXkWvantRpJWHSBoOS >= zucAIBaAAfDqqtchhqcNttpWJsC)
								{
									break;
								}
								dvkllTYcygNrtWBxpPjXKLRItBb = RIQaLUoMWeoYkmJQdWmwWPPxUFI[XMJwIhCfqqXkWvantRpJWHSBoOS].PollForAllElementsDown().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00e7;
								IL_00e7:
								if (dvkllTYcygNrtWBxpPjXKLRItBb.MoveNext())
								{
									yrdFsHkeMARJxswSfbuXWAAfMwQ = dvkllTYcygNrtWBxpPjXKLRItBb.Current;
									ref ControllerPollingInfo oqyjOinnaioClcifMTXphcTxwkN = ref OqyjOinnaioClcifMTXphcTxwkN;
									oqyjOinnaioClcifMTXphcTxwkN = new ControllerPollingInfo(yrdFsHkeMARJxswSfbuXWAAfMwQ);
									OqyjOinnaioClcifMTXphcTxwkN.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = OqyjOinnaioClcifMTXphcTxwkN;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								qfTvTMUsEicTMojvqoYUJZYzZoU();
								XMJwIhCfqqXkWvantRpJWHSBoOS++;
								goto IL_0108;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								qfTvTMUsEicTMojvqoYUJZYzZoU();
							}
						}
					}

					[DebuggerHidden]
					public inVjMGgaHrZnqUfLjXUDoeRCiZj(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void qfTvTMUsEicTMojvqoYUJZYzZoU()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (dvkllTYcygNrtWBxpPjXKLRItBb != null)
						{
							dvkllTYcygNrtWBxpPjXKLRItBb.Dispose();
						}
					}
				}

				private sealed class TKWBplVDNRqxeTvdsiATsBqDZGj : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IList<CustomController> LWCWAfCTzONFiYbjiWblEVMkXRF;

					public int fZeURPKjOmByrqEnnAjrjrjyCIbL;

					public int MmOAzDdgAByXabpBePljKzQkSPnJ;

					public ControllerPollingInfo wVBbgRDbQzopsfkGgPstcSlwAmVd;

					public ControllerPollingInfo EFAlpMGVPlIJbGDEdECEjKVRgnh;

					public IEnumerator<ControllerPollingInfo> PoxTWxAUImdmPLEkFtVpkThQClR;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						TKWBplVDNRqxeTvdsiATsBqDZGj tKWBplVDNRqxeTvdsiATsBqDZGj;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							tKWBplVDNRqxeTvdsiATsBqDZGj = this;
						}
						else
						{
							tKWBplVDNRqxeTvdsiATsBqDZGj = new TKWBplVDNRqxeTvdsiATsBqDZGj(0);
							tKWBplVDNRqxeTvdsiATsBqDZGj.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return tKWBplVDNRqxeTvdsiATsBqDZGj;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								LWCWAfCTzONFiYbjiWblEVMkXRF = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Controllers_readOnly;
								fZeURPKjOmByrqEnnAjrjrjyCIbL = LWCWAfCTzONFiYbjiWblEVMkXRF.Count;
								MmOAzDdgAByXabpBePljKzQkSPnJ = 0;
								goto IL_0108;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (MmOAzDdgAByXabpBePljKzQkSPnJ >= fZeURPKjOmByrqEnnAjrjrjyCIbL)
								{
									break;
								}
								PoxTWxAUImdmPLEkFtVpkThQClR = LWCWAfCTzONFiYbjiWblEVMkXRF[MmOAzDdgAByXabpBePljKzQkSPnJ].PollForAllButtons().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00e7;
								IL_00e7:
								if (PoxTWxAUImdmPLEkFtVpkThQClR.MoveNext())
								{
									wVBbgRDbQzopsfkGgPstcSlwAmVd = PoxTWxAUImdmPLEkFtVpkThQClR.Current;
									ref ControllerPollingInfo eFAlpMGVPlIJbGDEdECEjKVRgnh = ref EFAlpMGVPlIJbGDEdECEjKVRgnh;
									eFAlpMGVPlIJbGDEdECEjKVRgnh = new ControllerPollingInfo(wVBbgRDbQzopsfkGgPstcSlwAmVd);
									EFAlpMGVPlIJbGDEdECEjKVRgnh.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = EFAlpMGVPlIJbGDEdECEjKVRgnh;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								rNgQgYRxYOfueMJlSKqfhdTlZxy();
								MmOAzDdgAByXabpBePljKzQkSPnJ++;
								goto IL_0108;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								rNgQgYRxYOfueMJlSKqfhdTlZxy();
							}
						}
					}

					[DebuggerHidden]
					public TKWBplVDNRqxeTvdsiATsBqDZGj(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void rNgQgYRxYOfueMJlSKqfhdTlZxy()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (PoxTWxAUImdmPLEkFtVpkThQClR != null)
						{
							PoxTWxAUImdmPLEkFtVpkThQClR.Dispose();
						}
					}
				}

				private sealed class fIbdgJyJpIbHSdSAJdalTwlxJhxC : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IList<CustomController> VZqHoGhqBNWpaHNgxbzxFcdRLOe;

					public int ioGeYghiuXcSKYaSgoyKUxSOunxb;

					public int sXpOUkhtLiRwhxCevCNIroCAfVA;

					public ControllerPollingInfo TBAIzWheINsImBAsKznQJKmxLSPl;

					public ControllerPollingInfo VQsQOlzoLdGXhhJfPCWDDSxwMeg;

					public IEnumerator<ControllerPollingInfo> oVHqRBJPUaIsjBwmXfkCHncxMOA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						fIbdgJyJpIbHSdSAJdalTwlxJhxC fIbdgJyJpIbHSdSAJdalTwlxJhxC2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							fIbdgJyJpIbHSdSAJdalTwlxJhxC2 = this;
						}
						else
						{
							fIbdgJyJpIbHSdSAJdalTwlxJhxC2 = new fIbdgJyJpIbHSdSAJdalTwlxJhxC(0);
							fIbdgJyJpIbHSdSAJdalTwlxJhxC2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return fIbdgJyJpIbHSdSAJdalTwlxJhxC2;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								VZqHoGhqBNWpaHNgxbzxFcdRLOe = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Controllers_readOnly;
								ioGeYghiuXcSKYaSgoyKUxSOunxb = VZqHoGhqBNWpaHNgxbzxFcdRLOe.Count;
								sXpOUkhtLiRwhxCevCNIroCAfVA = 0;
								goto IL_0108;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (sXpOUkhtLiRwhxCevCNIroCAfVA >= ioGeYghiuXcSKYaSgoyKUxSOunxb)
								{
									break;
								}
								oVHqRBJPUaIsjBwmXfkCHncxMOA = VZqHoGhqBNWpaHNgxbzxFcdRLOe[sXpOUkhtLiRwhxCevCNIroCAfVA].PollForAllButtonsDown().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00e7;
								IL_00e7:
								if (oVHqRBJPUaIsjBwmXfkCHncxMOA.MoveNext())
								{
									TBAIzWheINsImBAsKznQJKmxLSPl = oVHqRBJPUaIsjBwmXfkCHncxMOA.Current;
									ref ControllerPollingInfo vQsQOlzoLdGXhhJfPCWDDSxwMeg = ref VQsQOlzoLdGXhhJfPCWDDSxwMeg;
									vQsQOlzoLdGXhhJfPCWDDSxwMeg = new ControllerPollingInfo(TBAIzWheINsImBAsKznQJKmxLSPl);
									VQsQOlzoLdGXhhJfPCWDDSxwMeg.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = VQsQOlzoLdGXhhJfPCWDDSxwMeg;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								kkWjwvEhvlWYaLIzAiLoyVDfYfR();
								sXpOUkhtLiRwhxCevCNIroCAfVA++;
								goto IL_0108;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								kkWjwvEhvlWYaLIzAiLoyVDfYfR();
							}
						}
					}

					[DebuggerHidden]
					public fIbdgJyJpIbHSdSAJdalTwlxJhxC(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void kkWjwvEhvlWYaLIzAiLoyVDfYfR()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (oVHqRBJPUaIsjBwmXfkCHncxMOA != null)
						{
							oVHqRBJPUaIsjBwmXfkCHncxMOA.Dispose();
						}
					}
				}

				private sealed class FlEsPFFENzUenoIaeAnpgbdrsAq : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IList<CustomController> OMpBgQHdKgASlLROqSdLFtGYFJzi;

					public int YXQEapyYFNvPXKuwbXfARQzXczr;

					public int lpfAzWIVXGHYISQLUPBXTHicPrV;

					public ControllerPollingInfo beFUqpGXkVxQvBFdrfSVXLWmawj;

					public ControllerPollingInfo msSVBLdGfBKtNUyZjpeAeESFvEy;

					public IEnumerator<ControllerPollingInfo> ksZPGRwPhFijdPAGcmUoPFkuIFc;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						FlEsPFFENzUenoIaeAnpgbdrsAq flEsPFFENzUenoIaeAnpgbdrsAq;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							flEsPFFENzUenoIaeAnpgbdrsAq = this;
						}
						else
						{
							flEsPFFENzUenoIaeAnpgbdrsAq = new FlEsPFFENzUenoIaeAnpgbdrsAq(0);
							flEsPFFENzUenoIaeAnpgbdrsAq.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return flEsPFFENzUenoIaeAnpgbdrsAq;
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
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								OMpBgQHdKgASlLROqSdLFtGYFJzi = GxphHAMqMhNBLjnlhXuBQmXaALiE.ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Controllers_readOnly;
								YXQEapyYFNvPXKuwbXfARQzXczr = OMpBgQHdKgASlLROqSdLFtGYFJzi.Count;
								lpfAzWIVXGHYISQLUPBXTHicPrV = 0;
								goto IL_0108;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00e7;
								}
								IL_0108:
								if (lpfAzWIVXGHYISQLUPBXTHicPrV >= YXQEapyYFNvPXKuwbXfARQzXczr)
								{
									break;
								}
								ksZPGRwPhFijdPAGcmUoPFkuIFc = OMpBgQHdKgASlLROqSdLFtGYFJzi[lpfAzWIVXGHYISQLUPBXTHicPrV].PollForAllAxes().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00e7;
								IL_00e7:
								if (ksZPGRwPhFijdPAGcmUoPFkuIFc.MoveNext())
								{
									beFUqpGXkVxQvBFdrfSVXLWmawj = ksZPGRwPhFijdPAGcmUoPFkuIFc.Current;
									ref ControllerPollingInfo reference = ref msSVBLdGfBKtNUyZjpeAeESFvEy;
									reference = new ControllerPollingInfo(beFUqpGXkVxQvBFdrfSVXLWmawj);
									msSVBLdGfBKtNUyZjpeAeESFvEy.playerId = GxphHAMqMhNBLjnlhXuBQmXaALiE.UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
									WCNlIsEdYuVTqbNYvICUPcTebLU = msSVBLdGfBKtNUyZjpeAeESFvEy;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								yObhgMJkvxggGsXJPJXnzvscDEXd();
								lpfAzWIVXGHYISQLUPBXTHicPrV++;
								goto IL_0108;
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
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								yObhgMJkvxggGsXJPJXnzvscDEXd();
							}
						}
					}

					[DebuggerHidden]
					public FlEsPFFENzUenoIaeAnpgbdrsAq(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void yObhgMJkvxggGsXJPJXnzvscDEXd()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (ksZPGRwPhFijdPAGcmUoPFkuIFc != null)
						{
							ksZPGRwPhFijdPAGcmUoPFkuIFc.Dispose();
						}
					}
				}

				private readonly Player UeMLjuGiSFGfRltYoIYxjRdaYAm;

				private readonly ControllerHelper ugKyZyJTGtYLrHpCFnUKcqkaRKt;

				private readonly int VumWnlylMgxSbyJcluXptXvaaZa;

				internal PollingHelper(Player player, ControllerHelper parent)
				{
					VumWnlylMgxSbyJcluXptXvaaZa = ReInput.id;
					UeMLjuGiSFGfRltYoIYxjRdaYAm = player;
					ugKyZyJTGtYLrHpCFnUKcqkaRKt = parent;
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => hyWEznkpZnCHzfcHojpLzoneCvyC(), 
						ControllerType.Joystick => TPeaefIQntVrpOAZJBmPvVRingR(controllerId), 
						ControllerType.Mouse => JctJOlqUAcSHtrKTkDhqAfqYdqyJ(), 
						ControllerType.Custom => CtcvieBJrGGXyHrVBBpahyqubKH(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => YsihUDAQvqGuRHQplAvyPgOZcnK(), 
						ControllerType.Joystick => JWWZmlKbszDDIoPzaZbWPnrSKdy(controllerId), 
						ControllerType.Mouse => UkwEMbvVcqpwccvScSQSSEnPjNl(), 
						ControllerType.Custom => wAWNxpVEOvZvJtxGKwISNabJAhA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => hyWEznkpZnCHzfcHojpLzoneCvyC(), 
						ControllerType.Joystick => xBPqMkOhBUCscAPttIooWAXqHvO(controllerId), 
						ControllerType.Mouse => QkOHkGLpaCpqwUPpzHINnTyyPiY(), 
						ControllerType.Custom => lhlbjxegrXbGyFnpddAUGxSVObj(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => YsihUDAQvqGuRHQplAvyPgOZcnK(), 
						ControllerType.Joystick => nUDXIiGmcsYHEoyfhiMrurtGIUz(controllerId), 
						ControllerType.Mouse => cvKlstuetRpLqtYWfPzRWZOImAP(), 
						ControllerType.Custom => qkMZGCzglnVjyozxCLYGbjCDrSc(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY(), 
						ControllerType.Joystick => SzaVUwuxuStVudqiDOedbzdUFjv(controllerId), 
						ControllerType.Mouse => KccjWBRlqNefKJtONmeFqHdjQRn(), 
						ControllerType.Custom => UMewfvUKWTsJdVILhigNiDnsKtp(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => GDTRtyJdiGNqaKicbrgdtRvqOHF(), 
						ControllerType.Joystick => rgGbAbGjtWXpUyrjislYFuvynVJ(controllerId), 
						ControllerType.Mouse => zvIyUDBRrgFtClHMTFEfFyrZmYQ(), 
						ControllerType.Custom => EHGCsVxVAdkVXoRNAbvyqundrjb(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => mENAeZeCVThercryLzDDaWWwAfIF(), 
						ControllerType.Joystick => dqJnHrPynjmGwuHXwLLzopnkZDx(controllerId), 
						ControllerType.Mouse => vkSEpdgbYbJZIASlGKYuOGIuCKpM(), 
						ControllerType.Custom => fVeTNuGXJmEwQKfKVnEYncBRejT(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => GDTRtyJdiGNqaKicbrgdtRvqOHF(), 
						ControllerType.Joystick => ZcdzSQoqbiPzKOaobweRedGOMHX(controllerId), 
						ControllerType.Mouse => YjiqDLNDAyXmIKIdnmzTAbkZHux(), 
						ControllerType.Custom => mVHmsJeIrRhQdRmStbVmiWnQSeQ(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => mENAeZeCVThercryLzDDaWWwAfIF(), 
						ControllerType.Joystick => ifLyEuKWSFFyHNlFWbFvzHuHIJX(controllerId), 
						ControllerType.Mouse => sGnZfrsndkQuxnIfiAjlxgExdQO(), 
						ControllerType.Custom => cSTaALWojGypKeiqoNXDplOLeol(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => odIzQzpvCiCuAWoINFzNZJzIPII(controllerId), 
						ControllerType.Mouse => yeahmXUBSZaGduljQunHxFkibYz(), 
						ControllerType.Custom => lAkBylauoTmTgOELUwxNwIOPChY(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => hyWEznkpZnCHzfcHojpLzoneCvyC(), 
						ControllerType.Joystick => RdcBMjhCECQBIRvqqFfggQVUNGg(), 
						ControllerType.Mouse => JctJOlqUAcSHtrKTkDhqAfqYdqyJ(), 
						ControllerType.Custom => GzbNpIDKebmkOFGFmXxqGvCbfqb(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => hyWEznkpZnCHzfcHojpLzoneCvyC(), 
						ControllerType.Joystick => hfJOZVucIHczYsttwhukrJcsyVv(), 
						ControllerType.Mouse => QkOHkGLpaCpqwUPpzHINnTyyPiY(), 
						ControllerType.Custom => HOLQfDIdqdtvOUoaIDTFjZoijqGd(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => YsihUDAQvqGuRHQplAvyPgOZcnK(), 
						ControllerType.Joystick => tiAcPesTbwwOSIcfTycPCasZCYj(), 
						ControllerType.Mouse => cvKlstuetRpLqtYWfPzRWZOImAP(), 
						ControllerType.Custom => nZLEfrMKdkyMqtFTeAxQOIPiYJk(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Keyboard => ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY(), 
						ControllerType.Joystick => irjsKDPNtrZmkumaRpuQyFlIShu(), 
						ControllerType.Mouse => KccjWBRlqNefKJtONmeFqHdjQRn(), 
						ControllerType.Custom => WFNaZjDydvWGfSByIlHtOEFZhQl(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElements(ControllerType controllerType)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => GDTRtyJdiGNqaKicbrgdtRvqOHF(), 
						ControllerType.Joystick => erVHfuOXQJQmixaNxIGRYDHFFmc(), 
						ControllerType.Mouse => zvIyUDBRrgFtClHMTFEfFyrZmYQ(), 
						ControllerType.Custom => LDbbFzgGBZBtlwNAamuGaFxphto(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllElementsDown(ControllerType controllerType)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => mENAeZeCVThercryLzDDaWWwAfIF(), 
						ControllerType.Joystick => ZFkAoDIDCULCKqCMJiqzlrqfyyyP(), 
						ControllerType.Mouse => vkSEpdgbYbJZIASlGKYuOGIuCKpM(), 
						ControllerType.Custom => bYGRiiTjCpEmWspRFAbFHwSSBLR(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtons(ControllerType controllerType)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => GDTRtyJdiGNqaKicbrgdtRvqOHF(), 
						ControllerType.Joystick => bDiADUDvggEEvgiabwWCEYVMFrq(), 
						ControllerType.Mouse => YjiqDLNDAyXmIKIdnmzTAbkZHux(), 
						ControllerType.Custom => iwkqLxbnxQdjMxrryXpjaIRSFFnC(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllButtonsDown(ControllerType controllerType)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => mENAeZeCVThercryLzDDaWWwAfIF(), 
						ControllerType.Joystick => MekJfrMVwstkkdeGJzaSIojEhPeK(), 
						ControllerType.Mouse => sGnZfrsndkQuxnIfiAjlxgExdQO(), 
						ControllerType.Custom => MZmoCAIzSQZMaFaOcqFhLZjmhfe(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersOfTypeForAllAxes(ControllerType controllerType)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Joystick => oTMUZeacEsgqzBrDYkhEWjiXxUwB(), 
						ControllerType.Mouse => yeahmXUBSZaGduljQunHxFkibYz(), 
						ControllerType.Custom => UItEHssUfFoTkLnHHgGNaeGMFOr(), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo TPeaefIQntVrpOAZJBmPvVRingR(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					Joystick joystick = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					ControllerPollingInfo result = joystick.PollForFirstElement();
					if (result.success)
					{
						result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
					}
					return result;
				}

				private ControllerPollingInfo JWWZmlKbszDDIoPzaZbWPnrSKdy(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					Joystick joystick = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					ControllerPollingInfo result = joystick.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
					}
					return result;
				}

				private ControllerPollingInfo xBPqMkOhBUCscAPttIooWAXqHvO(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					Joystick joystick = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					ControllerPollingInfo result = joystick.PollForFirstButton();
					if (result.success)
					{
						result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
					}
					return result;
				}

				private ControllerPollingInfo nUDXIiGmcsYHEoyfhiMrurtGIUz(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					Joystick joystick = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					ControllerPollingInfo result = joystick.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
					}
					return result;
				}

				private ControllerPollingInfo SzaVUwuxuStVudqiDOedbzdUFjv(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					Joystick joystick = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(P_0);
					if (joystick == null)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					ControllerPollingInfo result = joystick.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
					}
					return result;
				}

				private IEnumerable<ControllerPollingInfo> rgGbAbGjtWXpUyrjislYFuvynVJ(int P_0)
				{
					WrXBXFcQqBMHXNrRtOlEczoiCYoe wrXBXFcQqBMHXNrRtOlEczoiCYoe = new WrXBXFcQqBMHXNrRtOlEczoiCYoe(-2);
					wrXBXFcQqBMHXNrRtOlEczoiCYoe.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					wrXBXFcQqBMHXNrRtOlEczoiCYoe.qsPOrjVoFKLUWZUgvOumbnMylMT = P_0;
					return wrXBXFcQqBMHXNrRtOlEczoiCYoe;
				}

				private IEnumerable<ControllerPollingInfo> dqJnHrPynjmGwuHXwLLzopnkZDx(int P_0)
				{
					SeOZvOnRhoPJpoTbAacigqMVpsQ seOZvOnRhoPJpoTbAacigqMVpsQ = new SeOZvOnRhoPJpoTbAacigqMVpsQ(-2);
					seOZvOnRhoPJpoTbAacigqMVpsQ.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					seOZvOnRhoPJpoTbAacigqMVpsQ.qsPOrjVoFKLUWZUgvOumbnMylMT = P_0;
					return seOZvOnRhoPJpoTbAacigqMVpsQ;
				}

				private IEnumerable<ControllerPollingInfo> ZcdzSQoqbiPzKOaobweRedGOMHX(int P_0)
				{
					cZjJBOnJdRGDaZURgNuuRufXDIB cZjJBOnJdRGDaZURgNuuRufXDIB2 = new cZjJBOnJdRGDaZURgNuuRufXDIB(-2);
					cZjJBOnJdRGDaZURgNuuRufXDIB2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					cZjJBOnJdRGDaZURgNuuRufXDIB2.qsPOrjVoFKLUWZUgvOumbnMylMT = P_0;
					return cZjJBOnJdRGDaZURgNuuRufXDIB2;
				}

				private IEnumerable<ControllerPollingInfo> ifLyEuKWSFFyHNlFWbFvzHuHIJX(int P_0)
				{
					TVRspyWcQLpCoUdnrvwFGJekQpM tVRspyWcQLpCoUdnrvwFGJekQpM = new TVRspyWcQLpCoUdnrvwFGJekQpM(-2);
					tVRspyWcQLpCoUdnrvwFGJekQpM.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					tVRspyWcQLpCoUdnrvwFGJekQpM.qsPOrjVoFKLUWZUgvOumbnMylMT = P_0;
					return tVRspyWcQLpCoUdnrvwFGJekQpM;
				}

				private IEnumerable<ControllerPollingInfo> odIzQzpvCiCuAWoINFzNZJzIPII(int P_0)
				{
					HTbLyBVATzcgpdHgPPpyafrbcpaJ hTbLyBVATzcgpdHgPPpyafrbcpaJ = new HTbLyBVATzcgpdHgPPpyafrbcpaJ(-2);
					hTbLyBVATzcgpdHgPPpyafrbcpaJ.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					hTbLyBVATzcgpdHgPPpyafrbcpaJ.qsPOrjVoFKLUWZUgvOumbnMylMT = P_0;
					return hTbLyBVATzcgpdHgPPpyafrbcpaJ;
				}

				private ControllerPollingInfo RdcBMjhCECQBIRvqqFfggQVUNGg()
				{
					IList<Joystick> controllers_readOnly = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = controllers_readOnly[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo FkoUKIdaRciQBCDkqEKrQSFgFtzh()
				{
					IList<Joystick> controllers_readOnly = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = controllers_readOnly[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo hfJOZVucIHczYsttwhukrJcsyVv()
				{
					IList<Joystick> controllers_readOnly = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = controllers_readOnly[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo tiAcPesTbwwOSIcfTycPCasZCYj()
				{
					IList<Joystick> controllers_readOnly = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = controllers_readOnly[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo irjsKDPNtrZmkumaRpuQyFlIShu()
				{
					IList<Joystick> controllers_readOnly = ugKyZyJTGtYLrHpCFnUKcqkaRKt.joystickSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						Joystick joystick = controllers_readOnly[i];
						ControllerPollingInfo result = joystick.PollForFirstAxis();
						if (result.success)
						{
							result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private IEnumerable<ControllerPollingInfo> erVHfuOXQJQmixaNxIGRYDHFFmc()
				{
					AlOxIHRejBBVAcHQIGQwPzoHpmQ alOxIHRejBBVAcHQIGQwPzoHpmQ = new AlOxIHRejBBVAcHQIGQwPzoHpmQ(-2);
					alOxIHRejBBVAcHQIGQwPzoHpmQ.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return alOxIHRejBBVAcHQIGQwPzoHpmQ;
				}

				private IEnumerable<ControllerPollingInfo> ZFkAoDIDCULCKqCMJiqzlrqfyyyP()
				{
					sTDdIOKGgepZrTrgalKhuFkVMix sTDdIOKGgepZrTrgalKhuFkVMix2 = new sTDdIOKGgepZrTrgalKhuFkVMix(-2);
					sTDdIOKGgepZrTrgalKhuFkVMix2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return sTDdIOKGgepZrTrgalKhuFkVMix2;
				}

				private IEnumerable<ControllerPollingInfo> bDiADUDvggEEvgiabwWCEYVMFrq()
				{
					UpdCdTbImTKgAnJfJhLDEGuwzwb updCdTbImTKgAnJfJhLDEGuwzwb = new UpdCdTbImTKgAnJfJhLDEGuwzwb(-2);
					updCdTbImTKgAnJfJhLDEGuwzwb.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return updCdTbImTKgAnJfJhLDEGuwzwb;
				}

				private IEnumerable<ControllerPollingInfo> MekJfrMVwstkkdeGJzaSIojEhPeK()
				{
					ebTNikTVRrNOmXMKNLjjDsgMCmJ ebTNikTVRrNOmXMKNLjjDsgMCmJ2 = new ebTNikTVRrNOmXMKNLjjDsgMCmJ(-2);
					ebTNikTVRrNOmXMKNLjjDsgMCmJ2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return ebTNikTVRrNOmXMKNLjjDsgMCmJ2;
				}

				private IEnumerable<ControllerPollingInfo> oTMUZeacEsgqzBrDYkhEWjiXxUwB()
				{
					zsQsjexUNrPxumBfEGRvRbuNTZa zsQsjexUNrPxumBfEGRvRbuNTZa2 = new zsQsjexUNrPxumBfEGRvRbuNTZa(-2);
					zsQsjexUNrPxumBfEGRvRbuNTZa2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return zsQsjexUNrPxumBfEGRvRbuNTZa2;
				}

				private ControllerPollingInfo hyWEznkpZnCHzfcHojpLzoneCvyC()
				{
					if (!ugKyZyJTGtYLrHpCFnUKcqkaRKt.UIBRXGNLUQPBDoxieWrzmCOAPEx)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo YsihUDAQvqGuRHQplAvyPgOZcnK()
				{
					if (!ugKyZyJTGtYLrHpCFnUKcqkaRKt.UIBRXGNLUQPBDoxieWrzmCOAPEx)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.Keyboard.PollForFirstKeyDown();
				}

				private IEnumerable<ControllerPollingInfo> GDTRtyJdiGNqaKicbrgdtRvqOHF()
				{
					if (!ugKyZyJTGtYLrHpCFnUKcqkaRKt.UIBRXGNLUQPBDoxieWrzmCOAPEx)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> mENAeZeCVThercryLzDDaWWwAfIF()
				{
					if (!ugKyZyJTGtYLrHpCFnUKcqkaRKt.UIBRXGNLUQPBDoxieWrzmCOAPEx)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.Keyboard.PollForAllKeysDown();
				}

				private ControllerPollingInfo JctJOlqUAcSHtrKTkDhqAfqYdqyJ()
				{
					if (!ugKyZyJTGtYLrHpCFnUKcqkaRKt.rrPXkOLavtpHLJnPIGgLaikBwJx)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo UkwEMbvVcqpwccvScSQSSEnPjNl()
				{
					if (!ugKyZyJTGtYLrHpCFnUKcqkaRKt.rrPXkOLavtpHLJnPIGgLaikBwJx)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo QkOHkGLpaCpqwUPpzHINnTyyPiY()
				{
					if (!ugKyZyJTGtYLrHpCFnUKcqkaRKt.rrPXkOLavtpHLJnPIGgLaikBwJx)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo cvKlstuetRpLqtYWfPzRWZOImAP()
				{
					if (!ugKyZyJTGtYLrHpCFnUKcqkaRKt.rrPXkOLavtpHLJnPIGgLaikBwJx)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo KccjWBRlqNefKJtONmeFqHdjQRn()
				{
					if (!ugKyZyJTGtYLrHpCFnUKcqkaRKt.rrPXkOLavtpHLJnPIGgLaikBwJx)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.Mouse.PollForFirstAxis();
				}

				private IEnumerable<ControllerPollingInfo> zvIyUDBRrgFtClHMTFEfFyrZmYQ()
				{
					if (!ugKyZyJTGtYLrHpCFnUKcqkaRKt.rrPXkOLavtpHLJnPIGgLaikBwJx)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> vkSEpdgbYbJZIASlGKYuOGIuCKpM()
				{
					if (!ugKyZyJTGtYLrHpCFnUKcqkaRKt.rrPXkOLavtpHLJnPIGgLaikBwJx)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> YjiqDLNDAyXmIKIdnmzTAbkZHux()
				{
					if (!ugKyZyJTGtYLrHpCFnUKcqkaRKt.rrPXkOLavtpHLJnPIGgLaikBwJx)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> sGnZfrsndkQuxnIfiAjlxgExdQO()
				{
					if (!ugKyZyJTGtYLrHpCFnUKcqkaRKt.rrPXkOLavtpHLJnPIGgLaikBwJx)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> yeahmXUBSZaGduljQunHxFkibYz()
				{
					if (!ugKyZyJTGtYLrHpCFnUKcqkaRKt.rrPXkOLavtpHLJnPIGgLaikBwJx)
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return ugKyZyJTGtYLrHpCFnUKcqkaRKt.Mouse.PollForAllAxes();
				}

				private ControllerPollingInfo CtcvieBJrGGXyHrVBBpahyqubKH(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					CustomController customController = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					ControllerPollingInfo result = customController.PollForFirstElement();
					if (result.success)
					{
						result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
					}
					return result;
				}

				private ControllerPollingInfo wAWNxpVEOvZvJtxGKwISNabJAhA(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					CustomController customController = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					ControllerPollingInfo result = customController.PollForFirstElementDown();
					if (result.success)
					{
						result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
					}
					return result;
				}

				private ControllerPollingInfo lhlbjxegrXbGyFnpddAUGxSVObj(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					CustomController customController = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					ControllerPollingInfo result = customController.PollForFirstButton();
					if (result.success)
					{
						result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
					}
					return result;
				}

				private ControllerPollingInfo qkMZGCzglnVjyozxCLYGbjCDrSc(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					CustomController customController = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					ControllerPollingInfo result = customController.PollForFirstButtonDown();
					if (result.success)
					{
						result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
					}
					return result;
				}

				private ControllerPollingInfo UMewfvUKWTsJdVILhigNiDnsKtp(int P_0)
				{
					if (P_0 < 0)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					CustomController customController = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.ZqzzcVLLrMBIUyLpDAZiOGBIopG(P_0);
					if (customController == null)
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					ControllerPollingInfo result = customController.PollForFirstAxis();
					if (result.success)
					{
						result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
					}
					return result;
				}

				private IEnumerable<ControllerPollingInfo> EHGCsVxVAdkVXoRNAbvyqundrjb(int P_0)
				{
					YodOcKufkqjshRGxlJDHVfvpAZu yodOcKufkqjshRGxlJDHVfvpAZu = new YodOcKufkqjshRGxlJDHVfvpAZu(-2);
					yodOcKufkqjshRGxlJDHVfvpAZu.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					yodOcKufkqjshRGxlJDHVfvpAZu.zhMonKvpOLkvrBNtkyLqdqaacQk = P_0;
					return yodOcKufkqjshRGxlJDHVfvpAZu;
				}

				private IEnumerable<ControllerPollingInfo> fVeTNuGXJmEwQKfKVnEYncBRejT(int P_0)
				{
					dNZaSFJyKaPiBVcCklZFfnyCrCns dNZaSFJyKaPiBVcCklZFfnyCrCns2 = new dNZaSFJyKaPiBVcCklZFfnyCrCns(-2);
					dNZaSFJyKaPiBVcCklZFfnyCrCns2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					dNZaSFJyKaPiBVcCklZFfnyCrCns2.zhMonKvpOLkvrBNtkyLqdqaacQk = P_0;
					return dNZaSFJyKaPiBVcCklZFfnyCrCns2;
				}

				private IEnumerable<ControllerPollingInfo> mVHmsJeIrRhQdRmStbVmiWnQSeQ(int P_0)
				{
					qOtkSsBHxxabFvRdzOOgTnFuKeq qOtkSsBHxxabFvRdzOOgTnFuKeq2 = new qOtkSsBHxxabFvRdzOOgTnFuKeq(-2);
					qOtkSsBHxxabFvRdzOOgTnFuKeq2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					qOtkSsBHxxabFvRdzOOgTnFuKeq2.zhMonKvpOLkvrBNtkyLqdqaacQk = P_0;
					return qOtkSsBHxxabFvRdzOOgTnFuKeq2;
				}

				private IEnumerable<ControllerPollingInfo> cSTaALWojGypKeiqoNXDplOLeol(int P_0)
				{
					vdfsdNWDfepUKOHAitwyKmqrZor vdfsdNWDfepUKOHAitwyKmqrZor2 = new vdfsdNWDfepUKOHAitwyKmqrZor(-2);
					vdfsdNWDfepUKOHAitwyKmqrZor2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					vdfsdNWDfepUKOHAitwyKmqrZor2.zhMonKvpOLkvrBNtkyLqdqaacQk = P_0;
					return vdfsdNWDfepUKOHAitwyKmqrZor2;
				}

				private IEnumerable<ControllerPollingInfo> lAkBylauoTmTgOELUwxNwIOPChY(int P_0)
				{
					ghUEBeGuldFdNsJSZeFDQaSdqz ghUEBeGuldFdNsJSZeFDQaSdqz2 = new ghUEBeGuldFdNsJSZeFDQaSdqz(-2);
					ghUEBeGuldFdNsJSZeFDQaSdqz2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					ghUEBeGuldFdNsJSZeFDQaSdqz2.zhMonKvpOLkvrBNtkyLqdqaacQk = P_0;
					return ghUEBeGuldFdNsJSZeFDQaSdqz2;
				}

				private ControllerPollingInfo GzbNpIDKebmkOFGFmXxqGvCbfqb()
				{
					IList<CustomController> controllers_readOnly = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = controllers_readOnly[i].PollForFirstElement();
						if (result.success)
						{
							result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo xzUulTHqkvJqpsKDyCCofgEjERd()
				{
					IList<CustomController> controllers_readOnly = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = controllers_readOnly[i].PollForFirstElementDown();
						if (result.success)
						{
							result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo HOLQfDIdqdtvOUoaIDTFjZoijqGd()
				{
					IList<CustomController> controllers_readOnly = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = controllers_readOnly[i].PollForFirstButton();
						if (result.success)
						{
							result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo nZLEfrMKdkyMqtFTeAxQOIPiYJk()
				{
					IList<CustomController> controllers_readOnly = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						ControllerPollingInfo result = controllers_readOnly[i].PollForFirstButtonDown();
						if (result.success)
						{
							result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo WFNaZjDydvWGfSByIlHtOEFZhQl()
				{
					IList<CustomController> controllers_readOnly = ugKyZyJTGtYLrHpCFnUKcqkaRKt.customControllerSet.Controllers_readOnly;
					int count = controllers_readOnly.Count;
					for (int i = 0; i < count; i++)
					{
						CustomController customController = controllers_readOnly[i];
						ControllerPollingInfo result = customController.PollForFirstAxis();
						if (result.success)
						{
							result.playerId = UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP;
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private IEnumerable<ControllerPollingInfo> LDbbFzgGBZBtlwNAamuGaFxphto()
				{
					VVuSvErERkWjFlBsDhhWLVxeGOL vVuSvErERkWjFlBsDhhWLVxeGOL = new VVuSvErERkWjFlBsDhhWLVxeGOL(-2);
					vVuSvErERkWjFlBsDhhWLVxeGOL.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return vVuSvErERkWjFlBsDhhWLVxeGOL;
				}

				private IEnumerable<ControllerPollingInfo> bYGRiiTjCpEmWspRFAbFHwSSBLR()
				{
					inVjMGgaHrZnqUfLjXUDoeRCiZj inVjMGgaHrZnqUfLjXUDoeRCiZj2 = new inVjMGgaHrZnqUfLjXUDoeRCiZj(-2);
					inVjMGgaHrZnqUfLjXUDoeRCiZj2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return inVjMGgaHrZnqUfLjXUDoeRCiZj2;
				}

				private IEnumerable<ControllerPollingInfo> iwkqLxbnxQdjMxrryXpjaIRSFFnC()
				{
					TKWBplVDNRqxeTvdsiATsBqDZGj tKWBplVDNRqxeTvdsiATsBqDZGj = new TKWBplVDNRqxeTvdsiATsBqDZGj(-2);
					tKWBplVDNRqxeTvdsiATsBqDZGj.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return tKWBplVDNRqxeTvdsiATsBqDZGj;
				}

				private IEnumerable<ControllerPollingInfo> MZmoCAIzSQZMaFaOcqFhLZjmhfe()
				{
					fIbdgJyJpIbHSdSAJdalTwlxJhxC fIbdgJyJpIbHSdSAJdalTwlxJhxC2 = new fIbdgJyJpIbHSdSAJdalTwlxJhxC(-2);
					fIbdgJyJpIbHSdSAJdalTwlxJhxC2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return fIbdgJyJpIbHSdSAJdalTwlxJhxC2;
				}

				private IEnumerable<ControllerPollingInfo> UItEHssUfFoTkLnHHgGNaeGMFOr()
				{
					FlEsPFFENzUenoIaeAnpgbdrsAq flEsPFFENzUenoIaeAnpgbdrsAq = new FlEsPFFENzUenoIaeAnpgbdrsAq(-2);
					flEsPFFENzUenoIaeAnpgbdrsAq.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return flEsPFFENzUenoIaeAnpgbdrsAq;
				}
			}

			private sealed class OTTGsfEUxxHXiaLlgFVUsaPkJFxL : IDisposable, IEnumerator, IEnumerable, IEnumerable<Controller>, IEnumerator<Controller>
			{
				private Controller WCNlIsEdYuVTqbNYvICUPcTebLU;

				private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

				private int dFCUHNznYmJZjnnffQJUVAprSDy;

				public ControllerHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

				public int mSnfERXRcvqiWtFvBZJgzDBRqNG;

				public IList<Joystick> ulpIJIOsBGmqCxqkohDyUjDWriX;

				public int hJKhwrjWrvGJfCnccjZHqwGNaNlg;

				public int kJwtzxyeTqqnKVVbQSzSyoeELdl;

				public IList<CustomController> tIaMDhWcFxvjTUrQqYtNCOysfHY;

				public int TnGvnuQnKaDPtMqorxGFegicDtk;

				Controller IEnumerator<Controller>.Current
				{
					[DebuggerHidden]
					get
					{
						return WCNlIsEdYuVTqbNYvICUPcTebLU;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return WCNlIsEdYuVTqbNYvICUPcTebLU;
					}
				}

				[DebuggerHidden]
				IEnumerator<Controller> IEnumerable<Controller>.GetEnumerator()
				{
					OTTGsfEUxxHXiaLlgFVUsaPkJFxL oTTGsfEUxxHXiaLlgFVUsaPkJFxL;
					if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
						oTTGsfEUxxHXiaLlgFVUsaPkJFxL = this;
					}
					else
					{
						oTTGsfEUxxHXiaLlgFVUsaPkJFxL = new OTTGsfEUxxHXiaLlgFVUsaPkJFxL(0);
						oTTGsfEUxxHXiaLlgFVUsaPkJFxL.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
					}
					return oTTGsfEUxxHXiaLlgFVUsaPkJFxL;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Controller>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
					{
					case 0:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
						{
							ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
							break;
						}
						if (GxphHAMqMhNBLjnlhXuBQmXaALiE.rrPXkOLavtpHLJnPIGgLaikBwJx)
						{
							WCNlIsEdYuVTqbNYvICUPcTebLU = GxphHAMqMhNBLjnlhXuBQmXaALiE.Mouse;
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
							return true;
						}
						goto IL_0083;
					case 1:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_0083;
					case 2:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_00b1;
					case 3:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						hJKhwrjWrvGJfCnccjZHqwGNaNlg++;
						goto IL_0111;
					case 4:
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							TnGvnuQnKaDPtMqorxGFegicDtk++;
							goto IL_017f;
						}
						IL_017f:
						if (TnGvnuQnKaDPtMqorxGFegicDtk < kJwtzxyeTqqnKVVbQSzSyoeELdl)
						{
							WCNlIsEdYuVTqbNYvICUPcTebLU = tIaMDhWcFxvjTUrQqYtNCOysfHY[TnGvnuQnKaDPtMqorxGFegicDtk];
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 4;
							return true;
						}
						break;
						IL_00b1:
						mSnfERXRcvqiWtFvBZJgzDBRqNG = GxphHAMqMhNBLjnlhXuBQmXaALiE.joystickCount;
						ulpIJIOsBGmqCxqkohDyUjDWriX = GxphHAMqMhNBLjnlhXuBQmXaALiE.Joysticks;
						hJKhwrjWrvGJfCnccjZHqwGNaNlg = 0;
						goto IL_0111;
						IL_0111:
						if (hJKhwrjWrvGJfCnccjZHqwGNaNlg < mSnfERXRcvqiWtFvBZJgzDBRqNG)
						{
							WCNlIsEdYuVTqbNYvICUPcTebLU = ulpIJIOsBGmqCxqkohDyUjDWriX[hJKhwrjWrvGJfCnccjZHqwGNaNlg];
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
							return true;
						}
						kJwtzxyeTqqnKVVbQSzSyoeELdl = GxphHAMqMhNBLjnlhXuBQmXaALiE.customControllerCount;
						tIaMDhWcFxvjTUrQqYtNCOysfHY = GxphHAMqMhNBLjnlhXuBQmXaALiE.CustomControllers;
						TnGvnuQnKaDPtMqorxGFegicDtk = 0;
						goto IL_017f;
						IL_0083:
						if (GxphHAMqMhNBLjnlhXuBQmXaALiE.UIBRXGNLUQPBDoxieWrzmCOAPEx)
						{
							WCNlIsEdYuVTqbNYvICUPcTebLU = GxphHAMqMhNBLjnlhXuBQmXaALiE.Keyboard;
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
							return true;
						}
						goto IL_00b1;
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
				public OTTGsfEUxxHXiaLlgFVUsaPkJFxL(int _003C_003E1__state)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
					dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private readonly ESxitgnzJOKaHGGExYoKxkgWcPJJ YxYZgJunZgjDewbNAktNRCBhIdX;

			private bool rrPXkOLavtpHLJnPIGgLaikBwJx;

			private bool UIBRXGNLUQPBDoxieWrzmCOAPEx;

			private bool zlYDTNKiaxXGfRIGFAQXTtMAFnn;

			private double JaOlCQvasOScqPARpVuCVNIdVsx;

			private double BbaEdquwKdhCWAGOevXkfrNAnUH;

			private SafeAction<ControllerAssignmentChangedEventArgs> LMZARZPqfeAfrKsPUzdgLjLveefV = new SafeAction<ControllerAssignmentChangedEventArgs>(delegate(Exception P_0)
			{
				ReInput.HandleCallbackException("Player.ControllerHelper.ControllerAddedEvent", P_0);
			});

			private SafeAction<ControllerAssignmentChangedEventArgs> OhloACwTqQhXUoHrppdlczGCNJU = new SafeAction<ControllerAssignmentChangedEventArgs>(delegate(Exception P_0)
			{
				ReInput.HandleCallbackException("Player.ControllerHelper.ControllerRemovedEvent", P_0);
			});

			private readonly BkWacRVcSqktKoxKKLjyunbsXrx zDjgwsHxmQpJhkRGMsAWvoTTUnrS;

			private readonly Player UeMLjuGiSFGfRltYoIYxjRdaYAm;

			private readonly azjbOeFBgqcQlKHDiWTROdmqZMv dHzdxJGgfVamEigJTrTmGDfvxRqc;

			private readonly int VumWnlylMgxSbyJcluXptXvaaZa;

			public readonly MapHelper maps;

			public readonly ConflictCheckingHelper conflictChecking;

			public readonly PollingHelper polling;

			[CompilerGenerated]
			private static Action<Exception> aiXaKuCWRzBHdQrFqgBzyLzkAydQ;

			[CompilerGenerated]
			private static Action<Exception> sPMAcpellUZLaqoZiORhMgRZWDu;

			private CiBOuMFOJpyCeTavwEkrJOcXHWu<Joystick, JoystickMap> joystickSet => (CiBOuMFOJpyCeTavwEkrJOcXHWu<Joystick, JoystickMap>)YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Joystick);

			private global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<KeyboardMap> keyboardMapSet => (global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<KeyboardMap>)YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Keyboard).CXouiQVNNifvOhfkUWFfiMKCNFx(0).mapSet;

			private global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<MouseMap> mouseMapSet => (global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<MouseMap>)YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Mouse).CXouiQVNNifvOhfkUWFfiMKCNFx(0).mapSet;

			private CiBOuMFOJpyCeTavwEkrJOcXHWu<CustomController, CustomControllerMap> customControllerSet => (CiBOuMFOJpyCeTavwEkrJOcXHWu<CustomController, CustomControllerMap>)YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Custom);

			public bool hasMouse
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					return rrPXkOLavtpHLJnPIGgLaikBwJx;
				}
				set
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						if (rrPXkOLavtpHLJnPIGgLaikBwJx == value)
						{
							return;
						}
						rrPXkOLavtpHLJnPIGgLaikBwJx = value;
						if (value)
						{
							dHzdxJGgfVamEigJTrTmGDfvxRqc.ztcXjeonNMANOsnNizYgnnvxcMY(Mouse);
						}
						else
						{
							dHzdxJGgfVamEigJTrTmGDfvxRqc.EpPUHSOjmleHMsWUMfpjcKkxcPX(Mouse);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (LMZARZPqfeAfrKsPUzdgLjLveefV.Count > 0)
							{
								LMZARZPqfeAfrKsPUzdgLjLveefV.Invoke(new ControllerAssignmentChangedEventArgs(UeMLjuGiSFGfRltYoIYxjRdaYAm.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
							}
						}
						else if (OhloACwTqQhXUoHrppdlczGCNJU.Count > 0)
						{
							OhloACwTqQhXUoHrppdlczGCNJU.Invoke(new ControllerAssignmentChangedEventArgs(UeMLjuGiSFGfRltYoIYxjRdaYAm.id, ReInput.controllers.Mouse.id, ControllerType.Mouse, value));
						}
					}
				}
			}

			public bool hasKeyboard
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					return UIBRXGNLUQPBDoxieWrzmCOAPEx;
				}
				set
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						if (UIBRXGNLUQPBDoxieWrzmCOAPEx == value)
						{
							return;
						}
						UIBRXGNLUQPBDoxieWrzmCOAPEx = value;
						if (value)
						{
							dHzdxJGgfVamEigJTrTmGDfvxRqc.ztcXjeonNMANOsnNizYgnnvxcMY(Keyboard);
						}
						else
						{
							dHzdxJGgfVamEigJTrTmGDfvxRqc.EpPUHSOjmleHMsWUMfpjcKkxcPX(Keyboard);
						}
						if (value)
						{
							maps.layoutManager.Apply();
							if (LMZARZPqfeAfrKsPUzdgLjLveefV.Count > 0)
							{
								LMZARZPqfeAfrKsPUzdgLjLveefV.Invoke(new ControllerAssignmentChangedEventArgs(UeMLjuGiSFGfRltYoIYxjRdaYAm.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
							}
						}
						else if (OhloACwTqQhXUoHrppdlczGCNJU.Count > 0)
						{
							OhloACwTqQhXUoHrppdlczGCNJU.Invoke(new ControllerAssignmentChangedEventArgs(UeMLjuGiSFGfRltYoIYxjRdaYAm.id, ReInput.controllers.Keyboard.id, ControllerType.Keyboard, value));
						}
					}
				}
			}

			public bool excludeFromControllerAutoAssignment
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return false;
					}
					return zlYDTNKiaxXGfRIGFAQXTtMAFnn;
				}
				set
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						zlYDTNKiaxXGfRIGFAQXTtMAFnn = value;
					}
				}
			}

			public Keyboard Keyboard
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return ReInput.controllers.Keyboard;
				}
			}

			public Mouse Mouse
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return null;
					}
					return ReInput.controllers.Mouse;
				}
			}

			public int joystickCount
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					return YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Joystick).Count;
				}
			}

			public IList<Joystick> Joysticks
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<Joystick>.EmptyReadOnlyIListT;
					}
					return (YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Joystick) as CiBOuMFOJpyCeTavwEkrJOcXHWu<Joystick, JoystickMap>).Controllers_readOnly;
				}
			}

			public int customControllerCount
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return 0;
					}
					return YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Custom).Count;
				}
			}

			public IList<CustomController> CustomControllers
			{
				get
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
						return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
					}
					return (YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Custom) as CiBOuMFOJpyCeTavwEkrJOcXHWu<CustomController, CustomControllerMap>).Controllers_readOnly;
				}
			}

			public IEnumerable<Controller> Controllers
			{
				get
				{
					OTTGsfEUxxHXiaLlgFVUsaPkJFxL oTTGsfEUxxHXiaLlgFVUsaPkJFxL = new OTTGsfEUxxHXiaLlgFVUsaPkJFxL(-2);
					oTTGsfEUxxHXiaLlgFVUsaPkJFxL.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return oTTGsfEUxxHXiaLlgFVUsaPkJFxL;
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerAddedEvent
			{
				add
				{
					LMZARZPqfeAfrKsPUzdgLjLveefV.AddDelegate(value);
				}
				remove
				{
					LMZARZPqfeAfrKsPUzdgLjLveefV.RemoveDelegate(value);
				}
			}

			public event Action<ControllerAssignmentChangedEventArgs> ControllerRemovedEvent
			{
				add
				{
					OhloACwTqQhXUoHrppdlczGCNJU.AddDelegate(value);
				}
				remove
				{
					OhloACwTqQhXUoHrppdlczGCNJU.RemoveDelegate(value);
				}
			}

			internal ControllerHelper(Player player, zejNqQaBPwGHoSseyBcLZGOKcwt startingControllerMapInfo, ControllerMapLayoutManager.nVKdNlGaejzDgsTfDjPFiRPkzxZ controllerMapLayoutManagerSettings, ControllerMapEnabler.nRwNnlnQOFltouymedybQVFLNDP controllerMapEnablerSettings)
			{
				VumWnlylMgxSbyJcluXptXvaaZa = ReInput.id;
				UeMLjuGiSFGfRltYoIYxjRdaYAm = player;
				maps = new MapHelper(player, this, startingControllerMapInfo, controllerMapLayoutManagerSettings, controllerMapEnablerSettings);
				polling = new PollingHelper(player, this);
				conflictChecking = new ConflictCheckingHelper(player, this);
				YxYZgJunZgjDewbNAktNRCBhIdX = new ESxitgnzJOKaHGGExYoKxkgWcPJJ(4);
				YxYZgJunZgjDewbNAktNRCBhIdX.KFygjWdigylybvJFqAHIIdLZxfwa(0, ControllerType.Joystick, new CiBOuMFOJpyCeTavwEkrJOcXHWu<Joystick, JoystickMap>());
				YxYZgJunZgjDewbNAktNRCBhIdX.KFygjWdigylybvJFqAHIIdLZxfwa(1, ControllerType.Keyboard, new CiBOuMFOJpyCeTavwEkrJOcXHWu<Keyboard, KeyboardMap>());
				YxYZgJunZgjDewbNAktNRCBhIdX.KFygjWdigylybvJFqAHIIdLZxfwa(2, ControllerType.Mouse, new CiBOuMFOJpyCeTavwEkrJOcXHWu<Mouse, MouseMap>());
				YxYZgJunZgjDewbNAktNRCBhIdX.KFygjWdigylybvJFqAHIIdLZxfwa(3, ControllerType.Custom, new CiBOuMFOJpyCeTavwEkrJOcXHWu<CustomController, CustomControllerMap>());
				zDjgwsHxmQpJhkRGMsAWvoTTUnrS = new BkWacRVcSqktKoxKKLjyunbsXrx(player);
				dHzdxJGgfVamEigJTrTmGDfvxRqc = new azjbOeFBgqcQlKHDiWTROdmqZMv(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
			}

			public T GetController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				return (T)YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(XqmnYoifzflCsKxcFaHDewlkEkh.COrXrkTEKmpseQxNMlRJlIhLHQU<T>()).ZqzzcVLLrMBIUyLpDAZiOGBIopG(controllerId);
			}

			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				return YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType).ZqzzcVLLrMBIUyLpDAZiOGBIopG(controllerId);
			}

			public T GetControllerWithTag<T>(string tag) where T : Controller
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				return (T)YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(XqmnYoifzflCsKxcFaHDewlkEkh.COrXrkTEKmpseQxNMlRJlIhLHQU<T>()).nzOJKNVhwbNfErkEKCbnggvNzLZ(tag);
			}

			public Controller GetControllerWithTag(ControllerType controllerType, string tag)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				return YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(controllerType).nzOJKNVhwbNfErkEKCbnggvNzLZ(tag);
			}

			public void AddController<T>(int controllerId, bool removeFromOtherPlayers) where T : Controller
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					tUnghiHvJLidlTBQdQnaACAvMpOh(controllerId, removeFromOtherPlayers);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					AddController(ControllerType.Keyboard, controllerId, removeFromOtherPlayers);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					AddController(ControllerType.Mouse, controllerId, removeFromOtherPlayers);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					lObdySffSxtSFDoDQQyUyVZrHkI(controllerId, removeFromOtherPlayers);
					return;
				}
				throw new NotImplementedException();
			}

			public void AddController(Controller controller, bool removeFromOtherPlayers)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						tUnghiHvJLidlTBQdQnaACAvMpOh(controller as Joystick, removeFromOtherPlayers);
						break;
					case ControllerType.Keyboard:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Mouse:
						AddController(controller.type, controller.id, removeFromOtherPlayers);
						break;
					case ControllerType.Custom:
						lObdySffSxtSFDoDQQyUyVZrHkI(controller as CustomController, removeFromOtherPlayers);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public void AddController(ControllerType controllerType, int controllerId, bool removeFromOtherPlayers)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					tUnghiHvJLidlTBQdQnaACAvMpOh(ReInput.controllers.GetController(controllerType, controllerId) as Joystick, removeFromOtherPlayers);
					break;
				case ControllerType.Keyboard:
					if (removeFromOtherPlayers)
					{
						ReInput.controllers.RemoveControllerFromAllPlayers(controllerType, controllerId);
					}
					hasKeyboard = true;
					break;
				case ControllerType.Mouse:
					if (removeFromOtherPlayers)
					{
						ReInput.controllers.RemoveControllerFromAllPlayers(controllerType, controllerId);
					}
					hasMouse = true;
					break;
				case ControllerType.Custom:
					lObdySffSxtSFDoDQQyUyVZrHkI(ReInput.controllers.GetController(controllerType, controllerId) as CustomController, removeFromOtherPlayers);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					PIUibaZzJyyFaqSXWQcpLHakJEY(controllerId);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					RemoveController(ControllerType.Keyboard, 0);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					RemoveController(ControllerType.Mouse, 0);
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					tWdfQmBPudobtUdhGKshtjyjmUgb(controllerId);
					return;
				}
				throw new NotImplementedException();
			}

			public void RemoveController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					PIUibaZzJyyFaqSXWQcpLHakJEY(controllerId);
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					tWdfQmBPudobtUdhGKshtjyjmUgb(controllerId);
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void RemoveController(Controller controller)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else if (controller != null)
				{
					switch (controller.type)
					{
					case ControllerType.Joystick:
						PIUibaZzJyyFaqSXWQcpLHakJEY(controller as Joystick);
						break;
					case ControllerType.Keyboard:
						hasKeyboard = false;
						break;
					case ControllerType.Mouse:
						hasMouse = false;
						break;
					case ControllerType.Custom:
						tWdfQmBPudobtUdhGKshtjyjmUgb(controller as CustomController);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}

			public bool ContainsController<T>(int controllerId) where T : Controller
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return false;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					return ContainsController(ControllerType.Joystick, controllerId);
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					return UIBRXGNLUQPBDoxieWrzmCOAPEx;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return rrPXkOLavtpHLJnPIGgLaikBwJx;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return ContainsController(ControllerType.Custom, controllerId);
				}
				throw new NotImplementedException();
			}

			public bool ContainsController(ControllerType controllerType, int controllerId)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return false;
				}
				return controllerType switch
				{
					ControllerType.Joystick => YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Joystick).qUMsmxJoDabnMgpnPbuRnplJapZC(controllerId), 
					ControllerType.Keyboard => UIBRXGNLUQPBDoxieWrzmCOAPEx, 
					ControllerType.Mouse => rrPXkOLavtpHLJnPIGgLaikBwJx, 
					ControllerType.Custom => YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Custom).qUMsmxJoDabnMgpnPbuRnplJapZC(controllerId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public bool ContainsController(Controller controller)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return false;
				}
				if (controller == null)
				{
					return false;
				}
				return ContainsController(controller.type, controller.id);
			}

			public void ClearControllersOfType<T>() where T : Controller
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					vkMTAyScOVeWdUpDLbgiFTobBUDD();
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					hasKeyboard = false;
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					hasMouse = false;
					return;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					UXUMYpVlNXZxPwCSJAydvfrLcFf();
					return;
				}
				if (object.ReferenceEquals(typeFromHandle, typeof(Controller)))
				{
					ClearAllControllers();
					return;
				}
				throw new NotImplementedException();
			}

			public void ClearControllersOfType(ControllerType controllerType)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					vkMTAyScOVeWdUpDLbgiFTobBUDD();
					break;
				case ControllerType.Keyboard:
					hasKeyboard = false;
					break;
				case ControllerType.Mouse:
					hasMouse = false;
					break;
				case ControllerType.Custom:
					UXUMYpVlNXZxPwCSJAydvfrLcFf();
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public void ClearAllControllers()
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return;
				}
				vkMTAyScOVeWdUpDLbgiFTobBUDD();
				UXUMYpVlNXZxPwCSJAydvfrLcFf();
				hasMouse = false;
				hasKeyboard = false;
			}

			public Controller GetLastActiveController()
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				eatnGRIFXxOfeBtBanXkHdGjVbl(ControllerType.Joystick, ref result, ref num);
				if (rrPXkOLavtpHLJnPIGgLaikBwJx && JaOlCQvasOScqPARpVuCVNIdVsx > num)
				{
					result = Mouse;
					num = JaOlCQvasOScqPARpVuCVNIdVsx;
				}
				if (UIBRXGNLUQPBDoxieWrzmCOAPEx && BbaEdquwKdhCWAGOevXkfrNAnUH > num)
				{
					result = Keyboard;
					num = BbaEdquwKdhCWAGOevXkfrNAnUH;
				}
				eatnGRIFXxOfeBtBanXkHdGjVbl(ControllerType.Custom, ref result, ref num);
				return result;
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				Controller result = null;
				double num = 0.0;
				switch (controllerType)
				{
				case ControllerType.Joystick:
				case ControllerType.Custom:
					eatnGRIFXxOfeBtBanXkHdGjVbl(controllerType, ref result, ref num);
					break;
				case ControllerType.Keyboard:
					if (UIBRXGNLUQPBDoxieWrzmCOAPEx && BbaEdquwKdhCWAGOevXkfrNAnUH > 0.0)
					{
						result = Keyboard;
					}
					break;
				case ControllerType.Mouse:
					if (rrPXkOLavtpHLJnPIGgLaikBwJx && JaOlCQvasOScqPARpVuCVNIdVsx > 0.0)
					{
						result = Mouse;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				return result;
			}

			private void eatnGRIFXxOfeBtBanXkHdGjVbl(ControllerType P_0, ref Controller P_1, ref double P_2)
			{
				GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
				int count = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count;
				for (int i = 0; i < count; i++)
				{
					double lastActiveTime = gqqVmTmEPnWlhtHJrWWOcCmltOt[i].lastActiveTime;
					if (!(lastActiveTime <= P_2))
					{
						P_1 = gqqVmTmEPnWlhtHJrWWOcCmltOt[i].controller;
						P_2 = lastActiveTime;
					}
				}
			}

			public Controller GetLastActiveController<T>() where T : Controller
			{
				return GetLastActiveController(XqmnYoifzflCsKxcFaHDewlkEkh.COrXrkTEKmpseQxNMlRJlIhLHQU<T>());
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						UeMLjuGiSFGfRltYoIYxjRdaYAm.scydGtlzvpdcjviISQJWdAbzZFr.yriBQDnkYvrvyaiUGEOUCIKrzPN(UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP, callback);
					}
				}
			}

			public void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						UeMLjuGiSFGfRltYoIYxjRdaYAm.scydGtlzvpdcjviISQJWdAbzZFr.yriBQDnkYvrvyaiUGEOUCIKrzPN(UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP, callback, controllerType);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						UeMLjuGiSFGfRltYoIYxjRdaYAm.scydGtlzvpdcjviISQJWdAbzZFr.ePRwkMZZWtoOHNmXUYNXQjcOLks(UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP, callback);
					}
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						UeMLjuGiSFGfRltYoIYxjRdaYAm.scydGtlzvpdcjviISQJWdAbzZFr.ePRwkMZZWtoOHNmXUYNXQjcOLks(UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP, callback, controllerType);
					}
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (ReInput.isReady)
				{
					if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					}
					else
					{
						UeMLjuGiSFGfRltYoIYxjRdaYAm.scydGtlzvpdcjviISQJWdAbzZFr.JITpkVFOnUeywEjxEasvcfvrohL(UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP);
					}
				}
			}

			public Controller GetFirstControllerWithTemplate(Guid templateTypeGuid)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				int eBADKEfFkgpzzTponatpcvPGNRUi = YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
				for (int i = 0; i < eBADKEfFkgpzzTponatpcvPGNRUi; i++)
				{
					Controller controller = JeQUQBSflFVFhvzgpiyNxgAGfhA(YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(i).controllerType, Controller.implementsTemplateDelegate_Guid, templateTypeGuid);
					if (controller != null)
					{
						return controller;
					}
				}
				return null;
			}

			public Controller GetFirstControllerWithTemplate(Type templateType)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				int eBADKEfFkgpzzTponatpcvPGNRUi = YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi;
				for (int i = 0; i < eBADKEfFkgpzzTponatpcvPGNRUi; i++)
				{
					Controller controller = JeQUQBSflFVFhvzgpiyNxgAGfhA(YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(i).controllerType, Controller.implementsTemplateDelegate_Type, templateType);
					if (controller != null)
					{
						return controller;
					}
				}
				return null;
			}

			public Controller GetFirstControllerWithTemplate<T>() where T : class
			{
				return GetFirstControllerWithTemplate(typeof(T));
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return dHzdxJGgfVamEigJTrTmGDfvxRqc.xbXCiCGpUEnZvbvPgjxSgXChLGvD<TInterface>();
			}

			private Controller JeQUQBSflFVFhvzgpiyNxgAGfhA<TDelegateParam>(ControllerType P_0, Func<Controller, TDelegateParam, bool> P_1, TDelegateParam P_2)
			{
				switch (P_0)
				{
				case ControllerType.Joystick:
				{
					int num2 = joystickCount;
					IList<Joystick> joysticks = Joysticks;
					for (int j = 0; j < num2; j++)
					{
						if (P_1(joysticks[j], P_2))
						{
							return joysticks[j];
						}
					}
					return null;
				}
				case ControllerType.Keyboard:
					if (UIBRXGNLUQPBDoxieWrzmCOAPEx && P_1(Keyboard, P_2))
					{
						return Keyboard;
					}
					return null;
				case ControllerType.Mouse:
					if (rrPXkOLavtpHLJnPIGgLaikBwJx && P_1(Mouse, P_2))
					{
						return Mouse;
					}
					return null;
				case ControllerType.Custom:
				{
					int num = customControllerCount;
					IList<CustomController> customControllers = CustomControllers;
					for (int i = 0; i < num; i++)
					{
						if (P_1(customControllers[i], P_2))
						{
							return customControllers[i];
						}
					}
					return null;
				}
				default:
					throw new NotImplementedException();
				}
			}

			internal void iDBXctPcOcjjzWbKaCnxuPiVNUc()
			{
				for (int i = 0; i < YxYZgJunZgjDewbNAktNRCBhIdX.eBADKEfFkgpzzTponatpcvPGNRUi; i++)
				{
					YxYZgJunZgjDewbNAktNRCBhIdX.rlRqYWeSrZSmdwKmEJMJPHTplWA(i).VcHhfbFqwxAmqhwBHKVJpDjlfufe();
				}
				YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Keyboard).WLmhwxVIRpQznYyjnRtiVlRHzYd(new CiBOuMFOJpyCeTavwEkrJOcXHWu<Keyboard, KeyboardMap>.aLsWzHkpJEuncBoWNDXtzbFVdTda(ReInput.AkpZeTvTvDWYnEqWDyDWrcufUCI.Keyboard, new global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<KeyboardMap>(0)));
				YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Mouse).WLmhwxVIRpQznYyjnRtiVlRHzYd(new CiBOuMFOJpyCeTavwEkrJOcXHWu<Mouse, MouseMap>.aLsWzHkpJEuncBoWNDXtzbFVdTda(ReInput.AkpZeTvTvDWYnEqWDyDWrcufUCI.Mouse, new global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<MouseMap>(0)));
				zDjgwsHxmQpJhkRGMsAWvoTTUnrS.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
				BbaEdquwKdhCWAGOevXkfrNAnUH = 0.0;
				JaOlCQvasOScqPARpVuCVNIdVsx = 0.0;
				maps.iDBXctPcOcjjzWbKaCnxuPiVNUc();
			}

			internal double bjeMDwUhupEACsloaEuCzQcznzh(int P_0)
			{
				return zDjgwsHxmQpJhkRGMsAWvoTTUnrS.gvqEbQFhpyMkfjXoFHFMRwMMJtS(P_0)?.PlfBhVKChjwFIAQSRxnPWLyCaBq ?? (-1.0);
			}

			internal void tUnghiHvJLidlTBQdQnaACAvMpOh(Joystick P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Joystick);
				if (gqqVmTmEPnWlhtHJrWWOcCmltOt.qUMsmxJoDabnMgpnPbuRnplJapZC(P_0.id))
				{
					return;
				}
				if (P_1)
				{
					ReInput.controllers.RemoveJoystickFromAllPlayers(P_0);
				}
				BkWacRVcSqktKoxKKLjyunbsXrx.SIJZlQxwimktYHKcVVfKUnkmxyn sIJZlQxwimktYHKcVVfKUnkmxyn = zDjgwsHxmQpJhkRGMsAWvoTTUnrS.gvqEbQFhpyMkfjXoFHFMRwMMJtS(P_0.id);
				CiBOuMFOJpyCeTavwEkrJOcXHWu<Joystick, JoystickMap>.aLsWzHkpJEuncBoWNDXtzbFVdTda aLsWzHkpJEuncBoWNDXtzbFVdTda;
				if (sIJZlQxwimktYHKcVVfKUnkmxyn != null && sIJZlQxwimktYHKcVVfKUnkmxyn.VhZfrlASXHRPSRCbfcxNqUcSXtJ != null)
				{
					aLsWzHkpJEuncBoWNDXtzbFVdTda = new CiBOuMFOJpyCeTavwEkrJOcXHWu<Joystick, JoystickMap>.aLsWzHkpJEuncBoWNDXtzbFVdTda(P_0, sIJZlQxwimktYHKcVVfKUnkmxyn.VhZfrlASXHRPSRCbfcxNqUcSXtJ);
				}
				else
				{
					global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<JoystickMap> kfODxYFjqJsNDPfcwYBfcLaGFcLG2 = maps.kDkaaEkmIPCqOaiEimBMGrtukXJI(P_0, true);
					if (kfODxYFjqJsNDPfcwYBfcLaGFcLG2 == null)
					{
						kfODxYFjqJsNDPfcwYBfcLaGFcLG2 = new global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<JoystickMap>(P_0.id);
					}
					aLsWzHkpJEuncBoWNDXtzbFVdTda = new CiBOuMFOJpyCeTavwEkrJOcXHWu<Joystick, JoystickMap>.aLsWzHkpJEuncBoWNDXtzbFVdTda(P_0, kfODxYFjqJsNDPfcwYBfcLaGFcLG2);
				}
				gqqVmTmEPnWlhtHJrWWOcCmltOt.WLmhwxVIRpQznYyjnRtiVlRHzYd(aLsWzHkpJEuncBoWNDXtzbFVdTda);
				zDjgwsHxmQpJhkRGMsAWvoTTUnrS.TXPDIkiKZyOgtxZjjNIOUuEOnmW(aLsWzHkpJEuncBoWNDXtzbFVdTda);
				dHzdxJGgfVamEigJTrTmGDfvxRqc.ztcXjeonNMANOsnNizYgnnvxcMY(P_0);
				maps.layoutManager.Apply();
				if (LMZARZPqfeAfrKsPUzdgLjLveefV.Count > 0)
				{
					LMZARZPqfeAfrKsPUzdgLjLveefV.Invoke(new ControllerAssignmentChangedEventArgs(UeMLjuGiSFGfRltYoIYxjRdaYAm.id, P_0.id, ControllerType.Joystick, state: true));
				}
			}

			internal void tUnghiHvJLidlTBQdQnaACAvMpOh(int P_0, bool P_1)
			{
				Joystick joystick = ReInput.controllers.GetJoystick(P_0);
				if (joystick != null)
				{
					tUnghiHvJLidlTBQdQnaACAvMpOh(joystick, P_1);
				}
			}

			internal void PIUibaZzJyyFaqSXWQcpLHakJEY(int P_0)
			{
				GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Joystick);
				if (gqqVmTmEPnWlhtHJrWWOcCmltOt.qUMsmxJoDabnMgpnPbuRnplJapZC(P_0))
				{
					if (gqqVmTmEPnWlhtHJrWWOcCmltOt.CXouiQVNNifvOhfkUWFfiMKCNFx(P_0) is CiBOuMFOJpyCeTavwEkrJOcXHWu<Joystick, JoystickMap>.aLsWzHkpJEuncBoWNDXtzbFVdTda aLsWzHkpJEuncBoWNDXtzbFVdTda)
					{
						zDjgwsHxmQpJhkRGMsAWvoTTUnrS.TXPDIkiKZyOgtxZjjNIOUuEOnmW(aLsWzHkpJEuncBoWNDXtzbFVdTda);
					}
					gqqVmTmEPnWlhtHJrWWOcCmltOt.xBnLqyjdZjJraDJKyHVWmGRDquG(P_0);
					Joystick joystick = ReInput.controllers.GetJoystick(P_0);
					dHzdxJGgfVamEigJTrTmGDfvxRqc.EpPUHSOjmleHMsWUMfpjcKkxcPX(joystick);
					if (OhloACwTqQhXUoHrppdlczGCNJU.Count > 0)
					{
						OhloACwTqQhXUoHrppdlczGCNJU.Invoke(new ControllerAssignmentChangedEventArgs(UeMLjuGiSFGfRltYoIYxjRdaYAm.id, joystick.id, ControllerType.Joystick, state: false));
					}
				}
			}

			internal void PIUibaZzJyyFaqSXWQcpLHakJEY(Joystick P_0)
			{
				if (P_0 != null)
				{
					PIUibaZzJyyFaqSXWQcpLHakJEY(P_0.id);
				}
			}

			internal void vkMTAyScOVeWdUpDLbgiFTobBUDD()
			{
				GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Joystick);
				for (int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count - 1; num >= 0; num--)
				{
					zDjgwsHxmQpJhkRGMsAWvoTTUnrS.TXPDIkiKZyOgtxZjjNIOUuEOnmW(gqqVmTmEPnWlhtHJrWWOcCmltOt[num] as CiBOuMFOJpyCeTavwEkrJOcXHWu<Joystick, JoystickMap>.aLsWzHkpJEuncBoWNDXtzbFVdTda);
					dHzdxJGgfVamEigJTrTmGDfvxRqc.EpPUHSOjmleHMsWUMfpjcKkxcPX(gqqVmTmEPnWlhtHJrWWOcCmltOt[num].controller);
					int id = gqqVmTmEPnWlhtHJrWWOcCmltOt[num].controller.id;
					gqqVmTmEPnWlhtHJrWWOcCmltOt.AwAkOvTQBbpundzBkvKAJQrGudy(num);
					if (OhloACwTqQhXUoHrppdlczGCNJU.Count > 0)
					{
						OhloACwTqQhXUoHrppdlczGCNJU.Invoke(new ControllerAssignmentChangedEventArgs(UeMLjuGiSFGfRltYoIYxjRdaYAm.id, id, ControllerType.Joystick, state: false));
					}
				}
				gqqVmTmEPnWlhtHJrWWOcCmltOt.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			}

			internal void lObdySffSxtSFDoDQQyUyVZrHkI(CustomController P_0, bool P_1)
			{
				if (P_0 == null)
				{
					return;
				}
				GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Custom);
				if (!gqqVmTmEPnWlhtHJrWWOcCmltOt.qUMsmxJoDabnMgpnPbuRnplJapZC(P_0.id))
				{
					if (P_1)
					{
						ReInput.controllers.RemoveCustomControllerFromAllPlayers(P_0);
					}
					global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<CustomControllerMap> kfODxYFjqJsNDPfcwYBfcLaGFcLG2 = maps.rwxgABCVIxiibSHOEpKtKJAQRJv(P_0, true);
					if (kfODxYFjqJsNDPfcwYBfcLaGFcLG2 == null)
					{
						kfODxYFjqJsNDPfcwYBfcLaGFcLG2 = new global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<CustomControllerMap>(P_0.id);
					}
					CiBOuMFOJpyCeTavwEkrJOcXHWu<CustomController, CustomControllerMap>.aLsWzHkpJEuncBoWNDXtzbFVdTda aLsWzHkpJEuncBoWNDXtzbFVdTda = new CiBOuMFOJpyCeTavwEkrJOcXHWu<CustomController, CustomControllerMap>.aLsWzHkpJEuncBoWNDXtzbFVdTda(P_0, kfODxYFjqJsNDPfcwYBfcLaGFcLG2);
					gqqVmTmEPnWlhtHJrWWOcCmltOt.WLmhwxVIRpQznYyjnRtiVlRHzYd(aLsWzHkpJEuncBoWNDXtzbFVdTda);
					dHzdxJGgfVamEigJTrTmGDfvxRqc.ztcXjeonNMANOsnNizYgnnvxcMY(P_0);
					maps.layoutManager.Apply();
					if (LMZARZPqfeAfrKsPUzdgLjLveefV.Count > 0)
					{
						LMZARZPqfeAfrKsPUzdgLjLveefV.Invoke(new ControllerAssignmentChangedEventArgs(UeMLjuGiSFGfRltYoIYxjRdaYAm.id, P_0.id, ControllerType.Custom, state: true));
					}
				}
			}

			internal void lObdySffSxtSFDoDQQyUyVZrHkI(int P_0, bool P_1)
			{
				CustomController customController = ReInput.controllers.GetCustomController(P_0);
				if (customController != null)
				{
					lObdySffSxtSFDoDQQyUyVZrHkI(customController, P_1);
				}
			}

			internal void tWdfQmBPudobtUdhGKshtjyjmUgb(int P_0)
			{
				GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Custom);
				if (gqqVmTmEPnWlhtHJrWWOcCmltOt.qUMsmxJoDabnMgpnPbuRnplJapZC(P_0))
				{
					gqqVmTmEPnWlhtHJrWWOcCmltOt.CXouiQVNNifvOhfkUWFfiMKCNFx(P_0);
					gqqVmTmEPnWlhtHJrWWOcCmltOt.xBnLqyjdZjJraDJKyHVWmGRDquG(P_0);
					CustomController customController = ReInput.controllers.GetCustomController(P_0);
					dHzdxJGgfVamEigJTrTmGDfvxRqc.EpPUHSOjmleHMsWUMfpjcKkxcPX(customController);
					if (OhloACwTqQhXUoHrppdlczGCNJU.Count > 0)
					{
						OhloACwTqQhXUoHrppdlczGCNJU.Invoke(new ControllerAssignmentChangedEventArgs(UeMLjuGiSFGfRltYoIYxjRdaYAm.id, customController.id, ControllerType.Custom, state: false));
					}
				}
			}

			internal void tWdfQmBPudobtUdhGKshtjyjmUgb(CustomController P_0)
			{
				if (P_0 != null)
				{
					tWdfQmBPudobtUdhGKshtjyjmUgb(P_0.id);
				}
			}

			internal void UXUMYpVlNXZxPwCSJAydvfrLcFf()
			{
				GqqVmTmEPnWlhtHJrWWOcCmltOt gqqVmTmEPnWlhtHJrWWOcCmltOt = YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Custom);
				for (int num = gqqVmTmEPnWlhtHJrWWOcCmltOt.Count - 1; num >= 0; num--)
				{
					dHzdxJGgfVamEigJTrTmGDfvxRqc.EpPUHSOjmleHMsWUMfpjcKkxcPX(gqqVmTmEPnWlhtHJrWWOcCmltOt[num].controller);
					int id = gqqVmTmEPnWlhtHJrWWOcCmltOt[num].controller.id;
					gqqVmTmEPnWlhtHJrWWOcCmltOt.AwAkOvTQBbpundzBkvKAJQrGudy(num);
					if (OhloACwTqQhXUoHrppdlczGCNJU.Count > 0)
					{
						OhloACwTqQhXUoHrppdlczGCNJU.Invoke(new ControllerAssignmentChangedEventArgs(UeMLjuGiSFGfRltYoIYxjRdaYAm.id, id, ControllerType.Custom, state: false));
					}
				}
				gqqVmTmEPnWlhtHJrWWOcCmltOt.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			}

			internal CustomController whxNiKHrMFxPJAgBjEgFFOeSlVHA(int P_0)
			{
				CustomController customController = UeMLjuGiSFGfRltYoIYxjRdaYAm.scydGtlzvpdcjviISQJWdAbzZFr.whxNiKHrMFxPJAgBjEgFFOeSlVHA(P_0);
				if (customController == null)
				{
					return null;
				}
				lObdySffSxtSFDoDQQyUyVZrHkI(customController, false);
				return customController;
			}

			internal void DKtbpgXFibSltryXZZqFGlUsBCa(Action<bool, int, int> P_0)
			{
				WbTHuYZckxbtZblpWtRgJDdcYSdL<Joystick, JoystickMap>(ControllerType.Joystick, P_0);
			}

			internal void eOQJVQLbEYJpUqpbngwkDpnPoTCd(Keyboard P_0, ZdLBPTHRMdSwGFQpiatZEUsVVDOA P_1, Action<bool, int, int> P_2)
			{
				if (!UIBRXGNLUQPBDoxieWrzmCOAPEx || !P_0.enabled)
				{
					return;
				}
				wbeHCVDzEAfSpdXrnocntonKjhK iKAziOKgvhrFYCscwOYtGpvMfGf = VvbRiPIRRDOGFeaGvZCVmBjRfXT.IKAziOKgvhrFYCscwOYtGpvMfGf;
				bool flag = false;
				SaFIhRkKoaFsJonuErfrovvvDai mapSet = YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Keyboard).CXouiQVNNifvOhfkUWFfiMKCNFx(0).mapSet;
				int count = mapSet.Count;
				for (int i = 0; i < count; i++)
				{
					KeyboardMap keyboardMap = (KeyboardMap)mapSet[i];
					if (!keyboardMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> buttonMaps_orig = keyboardMap.ButtonMaps_orig;
					int count2 = buttonMaps_orig._count;
					for (int j = 0; j < count2; j++)
					{
						ActionElementMap actionElementMap = buttonMaps_orig._items[j];
						if (!actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt)
						{
							continue;
						}
						int actionId = actionElementMap._actionId;
						bool flag2 = actionElementMap._modifierKey1 != ModifierKey.None || actionElementMap._modifierKey2 != ModifierKey.None || actionElementMap._modifierKey3 != ModifierKey.None;
						KeyboardKeyCode keyboardKeyCode = actionElementMap._keyboardKeyCode;
						bool flag3 = false;
						ModifierKeyFlags modifierKeyFlags;
						tPpCplvxCBpYIIbYhfvfnqNQfUM tPpCplvxCBpYIIbYhfvfnqNQfUM2;
						if (flag2)
						{
							modifierKeyFlags = actionElementMap.modifierKeyFlags;
							if (P_0.mnTzQwiMlCKWrqCIVIoUFKFNePR(keyboardKeyCode, modifierKeyFlags))
							{
								if (!P_1.xpsYTFXAkccEmezmpBWDJVPBuXG(keyboardKeyCode, modifierKeyFlags))
								{
									tPpCplvxCBpYIIbYhfvfnqNQfUM2 = tPpCplvxCBpYIIbYhfvfnqNQfUM.tbTaqwCgVnCLKvHsvgjnjEDiwyz(actionElementMap.JYRMuwETpVNRqJXmtBgBFhZdTeP);
									tPpCplvxCBpYIIbYhfvfnqNQfUM2.YznpIQNoshMCFPANqaYGMzkecBZ(ReInput.currentUpdateLoop, true);
									flag3 = true;
									goto IL_0120;
								}
							}
							else
							{
								tPpCplvxCBpYIIbYhfvfnqNQfUM2 = tPpCplvxCBpYIIbYhfvfnqNQfUM.asgosewYKyFTkMJESKHnECzoAhE(actionElementMap.JYRMuwETpVNRqJXmtBgBFhZdTeP);
								if (tPpCplvxCBpYIIbYhfvfnqNQfUM2 != null)
								{
									goto IL_0120;
								}
							}
							goto IL_0177;
						}
						modifierKeyFlags = ModifierKeyFlags.None;
						ButtonStateFlags buttonStateFlags = P_0.SWrixoLkyvQSLlmQGIDCFFrrltz(actionElementMap.CRqOTsiLfoazJbodeeofQgavSxg);
						goto IL_013e;
						IL_013e:
						if (buttonStateFlags != ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh && (flag3 || !P_1.xpsYTFXAkccEmezmpBWDJVPBuXG(keyboardKeyCode, modifierKeyFlags)))
						{
							hAgYgTFLlHpIEooiGVnWlaoLlDA(P_0, keyboardMap, actionElementMap, iKAziOKgvhrFYCscwOYtGpvMfGf, buttonStateFlags);
							P_2(arg1: true, UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId);
							flag = true;
							continue;
						}
						goto IL_0177;
						IL_0120:
						buttonStateFlags = tPpCplvxCBpYIIbYhfvfnqNQfUM2.OzEITSYbvsjksHLvCKYLgBzVvWQ(true);
						goto IL_013e;
						IL_0177:
						if (iKAziOKgvhrFYCscwOYtGpvMfGf.lvXCTCWOhrCtuFDbbEqyqyUVPhp != 0f)
						{
							iKAziOKgvhrFYCscwOYtGpvMfGf.lvXCTCWOhrCtuFDbbEqyqyUVPhp = 0f;
						}
						if (iKAziOKgvhrFYCscwOYtGpvMfGf.ZkOKkhijFfaSwJkzgQHVpjkjwyi != ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh)
						{
							iKAziOKgvhrFYCscwOYtGpvMfGf.ZkOKkhijFfaSwJkzgQHVpjkjwyi = ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh;
						}
						P_2(arg1: false, UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId);
					}
				}
				if (flag)
				{
					BbaEdquwKdhCWAGOevXkfrNAnUH = ReInput.unscaledTime;
				}
			}

			private static void hAgYgTFLlHpIEooiGVnWlaoLlDA(Keyboard P_0, ControllerMap P_1, ActionElementMap P_2, wbeHCVDzEAfSpdXrnocntonKjhK P_3, ButtonStateFlags P_4)
			{
				float num = (((P_4 & ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa) != ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh) ? 1f : 0f);
				if (num != 0f && P_2._axisContribution == Pole.Negative)
				{
					num *= -1f;
				}
				P_3.lvXCTCWOhrCtuFDbbEqyqyUVPhp = num;
				P_3.ZkOKkhijFfaSwJkzgQHVpjkjwyi = P_4;
				P_3.FKtcxmBappHTSHGoccIYREwbpfog = P_0;
				P_3.guEuWFKSUNviYZgARiewhDnEceT = ControllerType.Keyboard;
				P_3.LSmTRdvHuagVChPSPaniDTWrvDKL = ControllerElementType.Button;
				P_3.PgtyCGUpZbAlPcnBMkOdtmXxupEd = P_2;
				P_3.nuUgjEKzUuMYBIiHUtitJvzUOOl = P_1;
				if (P_3.OVzqgzfQQediHUSdTbkxKkQsdgo)
				{
					P_3.OVzqgzfQQediHUSdTbkxKkQsdgo = false;
				}
				if (P_3.rdzdcCNDtRtIJOVeEPkAOfwnPXY)
				{
					P_3.rdzdcCNDtRtIJOVeEPkAOfwnPXY = false;
				}
			}

			internal void dDwopBTjgiBbyPpfOEoeobDFVYM(Mouse P_0, Action<bool, int, int> P_1)
			{
				if (!rrPXkOLavtpHLJnPIGgLaikBwJx || !P_0.enabled)
				{
					return;
				}
				SaFIhRkKoaFsJonuErfrovvvDai mapSet = YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(ControllerType.Mouse).CXouiQVNNifvOhfkUWFfiMKCNFx(0).mapSet;
				wbeHCVDzEAfSpdXrnocntonKjhK iKAziOKgvhrFYCscwOYtGpvMfGf = VvbRiPIRRDOGFeaGvZCVmBjRfXT.IKAziOKgvhrFYCscwOYtGpvMfGf;
				bool flag = false;
				int count = mapSet.Count;
				for (int i = 0; i < count; i++)
				{
					MouseMap mouseMap = (MouseMap)mapSet[i];
					if (!mouseMap.enabled)
					{
						continue;
					}
					AList<ActionElementMap> axisMaps_orig = mouseMap.AxisMaps_orig;
					if (axisMaps_orig != null)
					{
						int count2 = axisMaps_orig._count;
						for (int j = 0; j < count2; j++)
						{
							ActionElementMap actionElementMap = axisMaps_orig._items[j];
							if (!actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt || actionElementMap._elementType != ControllerElementType.Axis)
							{
								continue;
							}
							int actionId = actionElementMap._actionId;
							if (!P_0.zsAFdEAZFrQLWpDufeXtopzllWwG(actionElementMap, actionId, true, false, out var num))
							{
								continue;
							}
							if (num == 0f)
							{
								P_0.zsAFdEAZFrQLWpDufeXtopzllWwG(actionElementMap, actionId, true, true, out var num2);
								if (num2 == 0f)
								{
									P_1(arg1: false, UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId);
									continue;
								}
							}
							iKAziOKgvhrFYCscwOYtGpvMfGf.lvXCTCWOhrCtuFDbbEqyqyUVPhp = num;
							iKAziOKgvhrFYCscwOYtGpvMfGf.FKtcxmBappHTSHGoccIYREwbpfog = P_0;
							iKAziOKgvhrFYCscwOYtGpvMfGf.guEuWFKSUNviYZgARiewhDnEceT = ControllerType.Mouse;
							iKAziOKgvhrFYCscwOYtGpvMfGf.LSmTRdvHuagVChPSPaniDTWrvDKL = ControllerElementType.Axis;
							iKAziOKgvhrFYCscwOYtGpvMfGf.PgtyCGUpZbAlPcnBMkOdtmXxupEd = actionElementMap;
							iKAziOKgvhrFYCscwOYtGpvMfGf.nuUgjEKzUuMYBIiHUtitJvzUOOl = mouseMap;
							if (iKAziOKgvhrFYCscwOYtGpvMfGf.rdzdcCNDtRtIJOVeEPkAOfwnPXY)
							{
								iKAziOKgvhrFYCscwOYtGpvMfGf.rdzdcCNDtRtIJOVeEPkAOfwnPXY = false;
							}
							if (iKAziOKgvhrFYCscwOYtGpvMfGf.LijFMsBQaBMeyaBSULosMeSZIZpX != AxisCoordinateMode.Relative)
							{
								iKAziOKgvhrFYCscwOYtGpvMfGf.LijFMsBQaBMeyaBSULosMeSZIZpX = AxisCoordinateMode.Relative;
							}
							P_1(arg1: true, UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId);
							flag = true;
						}
					}
					AList<ActionElementMap> buttonMaps_orig = mouseMap.ButtonMaps_orig;
					if (buttonMaps_orig == null)
					{
						continue;
					}
					int count3 = buttonMaps_orig._count;
					for (int k = 0; k < count3; k++)
					{
						ActionElementMap actionElementMap2 = buttonMaps_orig._items[k];
						if (!actionElementMap2.fnEBjitvkHhPtXTzRLmBYpIxFbt || actionElementMap2._elementType != ControllerElementType.Button)
						{
							continue;
						}
						int actionId2 = actionElementMap2._actionId;
						if (!P_0.FzGQGbkmFSyHrWWApQQYywIiiad(actionElementMap2, actionId2, out var lvXCTCWOhrCtuFDbbEqyqyUVPhp, out iKAziOKgvhrFYCscwOYtGpvMfGf.OVzqgzfQQediHUSdTbkxKkQsdgo))
						{
							continue;
						}
						ButtonStateFlags buttonStateFlags = P_0.SWrixoLkyvQSLlmQGIDCFFrrltz(actionElementMap2.CRqOTsiLfoazJbodeeofQgavSxg);
						if (buttonStateFlags == ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh)
						{
							P_1(arg1: false, UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId2);
							continue;
						}
						iKAziOKgvhrFYCscwOYtGpvMfGf.lvXCTCWOhrCtuFDbbEqyqyUVPhp = lvXCTCWOhrCtuFDbbEqyqyUVPhp;
						iKAziOKgvhrFYCscwOYtGpvMfGf.ZkOKkhijFfaSwJkzgQHVpjkjwyi = buttonStateFlags;
						iKAziOKgvhrFYCscwOYtGpvMfGf.FKtcxmBappHTSHGoccIYREwbpfog = P_0;
						iKAziOKgvhrFYCscwOYtGpvMfGf.guEuWFKSUNviYZgARiewhDnEceT = ControllerType.Mouse;
						iKAziOKgvhrFYCscwOYtGpvMfGf.LSmTRdvHuagVChPSPaniDTWrvDKL = ControllerElementType.Button;
						iKAziOKgvhrFYCscwOYtGpvMfGf.PgtyCGUpZbAlPcnBMkOdtmXxupEd = actionElementMap2;
						iKAziOKgvhrFYCscwOYtGpvMfGf.nuUgjEKzUuMYBIiHUtitJvzUOOl = mouseMap;
						if (iKAziOKgvhrFYCscwOYtGpvMfGf.OVzqgzfQQediHUSdTbkxKkQsdgo)
						{
							iKAziOKgvhrFYCscwOYtGpvMfGf.OVzqgzfQQediHUSdTbkxKkQsdgo = false;
						}
						if (iKAziOKgvhrFYCscwOYtGpvMfGf.rdzdcCNDtRtIJOVeEPkAOfwnPXY)
						{
							iKAziOKgvhrFYCscwOYtGpvMfGf.rdzdcCNDtRtIJOVeEPkAOfwnPXY = false;
						}
						P_1(arg1: true, UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId2);
						flag = true;
					}
				}
				if (flag)
				{
					JaOlCQvasOScqPARpVuCVNIdVsx = ReInput.unscaledTime;
				}
			}

			internal void PnucCUBgvYFhldakvrKVPhWaiNR(Action<bool, int, int> P_0)
			{
				WbTHuYZckxbtZblpWtRgJDdcYSdL<CustomController, CustomControllerMap>(ControllerType.Custom, P_0);
			}

			private void WbTHuYZckxbtZblpWtRgJDdcYSdL<T, TMap>(ControllerType P_0, Action<bool, int, int> P_1) where T : ControllerWithAxes where TMap : ControllerMapWithAxes
			{
				CiBOuMFOJpyCeTavwEkrJOcXHWu<T, TMap> ciBOuMFOJpyCeTavwEkrJOcXHWu = (CiBOuMFOJpyCeTavwEkrJOcXHWu<T, TMap>)YxYZgJunZgjDewbNAktNRCBhIdX.voXpBfThsCGWCMHojROqTcsZaAs(P_0);
				wbeHCVDzEAfSpdXrnocntonKjhK iKAziOKgvhrFYCscwOYtGpvMfGf = VvbRiPIRRDOGFeaGvZCVmBjRfXT.IKAziOKgvhrFYCscwOYtGpvMfGf;
				int count = ciBOuMFOJpyCeTavwEkrJOcXHWu.Count;
				for (int i = 0; i < count; i++)
				{
					CiBOuMFOJpyCeTavwEkrJOcXHWu<T, TMap>.aLsWzHkpJEuncBoWNDXtzbFVdTda aLsWzHkpJEuncBoWNDXtzbFVdTda = ciBOuMFOJpyCeTavwEkrJOcXHWu[i];
					T fKtcxmBappHTSHGoccIYREwbpfog = aLsWzHkpJEuncBoWNDXtzbFVdTda.FKtcxmBappHTSHGoccIYREwbpfog;
					if (!fKtcxmBappHTSHGoccIYREwbpfog.enabled)
					{
						continue;
					}
					global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<TMap> vhZfrlASXHRPSRCbfcxNqUcSXtJ = aLsWzHkpJEuncBoWNDXtzbFVdTda.VhZfrlASXHRPSRCbfcxNqUcSXtJ;
					bool flag = false;
					int count2 = vhZfrlASXHRPSRCbfcxNqUcSXtJ.Count;
					for (int j = 0; j < count2; j++)
					{
						TMap nuUgjEKzUuMYBIiHUtitJvzUOOl = vhZfrlASXHRPSRCbfcxNqUcSXtJ[j];
						if (!nuUgjEKzUuMYBIiHUtitJvzUOOl.enabled)
						{
							continue;
						}
						AList<ActionElementMap> axisMaps_orig = nuUgjEKzUuMYBIiHUtitJvzUOOl.AxisMaps_orig;
						if (axisMaps_orig != null)
						{
							int count3 = axisMaps_orig._count;
							for (int k = 0; k < count3; k++)
							{
								ActionElementMap actionElementMap = axisMaps_orig._items[k];
								if (!actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt || actionElementMap._elementType != ControllerElementType.Axis)
								{
									continue;
								}
								int actionId = actionElementMap._actionId;
								if (!fKtcxmBappHTSHGoccIYREwbpfog.zsAFdEAZFrQLWpDufeXtopzllWwG(actionElementMap, actionId, false, false, out var num))
								{
									continue;
								}
								if (num == 0f)
								{
									fKtcxmBappHTSHGoccIYREwbpfog.zsAFdEAZFrQLWpDufeXtopzllWwG(actionElementMap, actionId, false, true, out var num2);
									if (num2 == 0f)
									{
										P_1(arg1: false, UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId);
										continue;
									}
								}
								iKAziOKgvhrFYCscwOYtGpvMfGf.lvXCTCWOhrCtuFDbbEqyqyUVPhp = num;
								iKAziOKgvhrFYCscwOYtGpvMfGf.FKtcxmBappHTSHGoccIYREwbpfog = fKtcxmBappHTSHGoccIYREwbpfog;
								iKAziOKgvhrFYCscwOYtGpvMfGf.guEuWFKSUNviYZgARiewhDnEceT = P_0;
								iKAziOKgvhrFYCscwOYtGpvMfGf.LSmTRdvHuagVChPSPaniDTWrvDKL = ControllerElementType.Axis;
								iKAziOKgvhrFYCscwOYtGpvMfGf.PgtyCGUpZbAlPcnBMkOdtmXxupEd = actionElementMap;
								iKAziOKgvhrFYCscwOYtGpvMfGf.nuUgjEKzUuMYBIiHUtitJvzUOOl = nuUgjEKzUuMYBIiHUtitJvzUOOl;
								iKAziOKgvhrFYCscwOYtGpvMfGf.rdzdcCNDtRtIJOVeEPkAOfwnPXY = fKtcxmBappHTSHGoccIYREwbpfog.calibrationMap.Axes[actionElementMap.CRqOTsiLfoazJbodeeofQgavSxg].applyRangeCalibration;
								iKAziOKgvhrFYCscwOYtGpvMfGf.LijFMsBQaBMeyaBSULosMeSZIZpX = fKtcxmBappHTSHGoccIYREwbpfog.Axes[actionElementMap.elementIndex].PlYUFxznkverJWuzpbzUWwQOLjs?._dataFormat ?? AxisCoordinateMode.Absolute;
								P_1(arg1: true, UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId);
								flag = true;
							}
						}
						AList<ActionElementMap> buttonMaps_orig = nuUgjEKzUuMYBIiHUtitJvzUOOl.ButtonMaps_orig;
						if (buttonMaps_orig != null)
						{
							int count4 = buttonMaps_orig._count;
							for (int l = 0; l < count4; l++)
							{
								ActionElementMap actionElementMap2 = buttonMaps_orig._items[l];
								if (!actionElementMap2.fnEBjitvkHhPtXTzRLmBYpIxFbt || actionElementMap2._elementType != ControllerElementType.Button)
								{
									continue;
								}
								int actionId2 = actionElementMap2._actionId;
								float lvXCTCWOhrCtuFDbbEqyqyUVPhp = 0f;
								int cRqOTsiLfoazJbodeeofQgavSxg = actionElementMap2.CRqOTsiLfoazJbodeeofQgavSxg;
								if (!lzDCpzSnuDgynlfgtDNZpCQRaaeJ(fKtcxmBappHTSHGoccIYREwbpfog, i, cRqOTsiLfoazJbodeeofQgavSxg, actionElementMap2, vhZfrlASXHRPSRCbfcxNqUcSXtJ, actionId2, ref lvXCTCWOhrCtuFDbbEqyqyUVPhp))
								{
									ref bool oVzqgzfQQediHUSdTbkxKkQsdgo = ref iKAziOKgvhrFYCscwOYtGpvMfGf.OVzqgzfQQediHUSdTbkxKkQsdgo;
									if (!fKtcxmBappHTSHGoccIYREwbpfog.FzGQGbkmFSyHrWWApQQYywIiiad(actionElementMap2, actionId2, out lvXCTCWOhrCtuFDbbEqyqyUVPhp, out oVzqgzfQQediHUSdTbkxKkQsdgo))
									{
										continue;
									}
								}
								int cRqOTsiLfoazJbodeeofQgavSxg2 = actionElementMap2.CRqOTsiLfoazJbodeeofQgavSxg;
								ButtonStateFlags buttonStateFlags = fKtcxmBappHTSHGoccIYREwbpfog.SWrixoLkyvQSLlmQGIDCFFrrltz(cRqOTsiLfoazJbodeeofQgavSxg2);
								if (buttonStateFlags == ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh)
								{
									P_1(arg1: false, UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId2);
									continue;
								}
								iKAziOKgvhrFYCscwOYtGpvMfGf.lvXCTCWOhrCtuFDbbEqyqyUVPhp = lvXCTCWOhrCtuFDbbEqyqyUVPhp;
								iKAziOKgvhrFYCscwOYtGpvMfGf.ZkOKkhijFfaSwJkzgQHVpjkjwyi = buttonStateFlags;
								iKAziOKgvhrFYCscwOYtGpvMfGf.FKtcxmBappHTSHGoccIYREwbpfog = fKtcxmBappHTSHGoccIYREwbpfog;
								iKAziOKgvhrFYCscwOYtGpvMfGf.guEuWFKSUNviYZgARiewhDnEceT = P_0;
								iKAziOKgvhrFYCscwOYtGpvMfGf.LSmTRdvHuagVChPSPaniDTWrvDKL = ControllerElementType.Button;
								iKAziOKgvhrFYCscwOYtGpvMfGf.PgtyCGUpZbAlPcnBMkOdtmXxupEd = actionElementMap2;
								iKAziOKgvhrFYCscwOYtGpvMfGf.nuUgjEKzUuMYBIiHUtitJvzUOOl = nuUgjEKzUuMYBIiHUtitJvzUOOl;
								if (iKAziOKgvhrFYCscwOYtGpvMfGf.rdzdcCNDtRtIJOVeEPkAOfwnPXY)
								{
									iKAziOKgvhrFYCscwOYtGpvMfGf.rdzdcCNDtRtIJOVeEPkAOfwnPXY = false;
								}
								P_1(arg1: true, UeMLjuGiSFGfRltYoIYxjRdaYAm.JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId2);
								flag = true;
							}
						}
						if (flag)
						{
							aLsWzHkpJEuncBoWNDXtzbFVdTda.ztehiAbBWLMJjiUjLbqrHIvSSTE();
						}
					}
				}
			}

			private bool lzDCpzSnuDgynlfgtDNZpCQRaaeJ<TMap>(ControllerWithAxes P_0, int P_1, int P_2, ActionElementMap P_3, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<TMap> P_4, int P_5, ref float P_6) where TMap : ControllerMapWithAxes
			{
				if (!P_0.QlXkhNBHPYUNWwhKurdwrqFgWTf.IsUnknownHatCardinal(P_2))
				{
					return false;
				}
				UnknownControllerHat.HatButtons unknownHatButtons = P_0.QlXkhNBHPYUNWwhKurdwrqFgWTf.GetUnknownHatButtons(P_2);
				if (jRtyGQHEIjrFSDyQlaGJpIhzrgV(unknownHatButtons, P_1, P_4))
				{
					unknownHatButtons.GetNeighbors(P_2, out var neighbor, out var neighbor2);
					if (P_0.GetButton(neighbor) || P_0.GetButton(neighbor2))
					{
						if (!P_0.FzGQGbkmFSyHrWWApQQYywIiiad(P_3, P_5, true, out P_6))
						{
							return false;
						}
						return true;
					}
				}
				return false;
			}

			private bool jRtyGQHEIjrFSDyQlaGJpIhzrgV<TMap>(UnknownControllerHat.HatButtons P_0, int P_1, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<TMap> P_2) where TMap : ControllerMapWithAxes
			{
				if (P_0 == null)
				{
					return false;
				}
				if (ReInput.configVars.force4WayHats)
				{
					return true;
				}
				if (tybvGisICqBgBkPQLhBICIzjLVeR(P_0, P_1, P_2))
				{
					return false;
				}
				return true;
			}

			private bool tybvGisICqBgBkPQLhBICIzjLVeR<TMap>(UnknownControllerHat.HatButtons P_0, int P_1, global::kfODxYFjqJsNDPfcwYBfcLaGFcLG<TMap> P_2) where TMap : ControllerMapWithAxes
			{
				if (P_2 == null)
				{
					return false;
				}
				int count = P_2.Count;
				for (int i = 0; i < count; i++)
				{
					TMap val = P_2[i];
					IList<ActionElementMap> buttonMaps = val.ButtonMaps;
					if (buttonMaps == null)
					{
						continue;
					}
					int count2 = buttonMaps.Count;
					for (int j = 0; j < count2; j++)
					{
						int cRqOTsiLfoazJbodeeofQgavSxg = buttonMaps[j].CRqOTsiLfoazJbodeeofQgavSxg;
						if (buttonMaps[j]._actionId >= 0 && P_0.IsCorner(cRqOTsiLfoazJbodeeofQgavSxg))
						{
							return true;
						}
					}
				}
				return false;
			}

			[CompilerGenerated]
			private static void XfINNKEmUKzSsCzPHajDXqTnGNY(Exception P_0)
			{
				ReInput.HandleCallbackException("Player.ControllerHelper.ControllerAddedEvent", P_0);
			}

			[CompilerGenerated]
			private static void NqdcTKpAdLRalzDgqnwzkSilbEj(Exception P_0)
			{
				ReInput.HandleCallbackException("Player.ControllerHelper.ControllerRemovedEvent", P_0);
			}
		}

		private readonly wdexXznqMQgvrkdYBfwPPJZVQDx scydGtlzvpdcjviISQJWdAbzZFr;

		private bool EDIjqnfTfBHPhZHJudQqroNJlrXH;

		private int JYRMuwETpVNRqJXmtBgBFhZdTeP;

		private string qpIGvFaemznETzYbpRdmOKmaPCL;

		private string FeaIAYfHUFDXldnlezDhWbiiNzzy;

		private bool nPLLKPaRzzMBweCuqwFziTYjFUw;

		private readonly int VumWnlylMgxSbyJcluXptXvaaZa;

		public readonly ControllerHelper controllers;

		public int id
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return -1;
				}
				return JYRMuwETpVNRqJXmtBgBFhZdTeP;
			}
			internal set
			{
				JYRMuwETpVNRqJXmtBgBFhZdTeP = value;
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return string.Empty;
				}
				return qpIGvFaemznETzYbpRdmOKmaPCL;
			}
			internal set
			{
				qpIGvFaemznETzYbpRdmOKmaPCL = value;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return string.Empty;
				}
				return FeaIAYfHUFDXldnlezDhWbiiNzzy;
			}
			internal set
			{
				FeaIAYfHUFDXldnlezDhWbiiNzzy = value;
			}
		}

		public bool isPlaying
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return false;
				}
				return nPLLKPaRzzMBweCuqwFziTYjFUw;
			}
			set
			{
				nPLLKPaRzzMBweCuqwFziTYjFUw = value;
			}
		}

		internal Player(bool isSystem, int playerId, string name, string descriptiveName, zejNqQaBPwGHoSseyBcLZGOKcwt startingControllerMapInfo, ControllerMapLayoutManager.nVKdNlGaejzDgsTfDjPFiRPkzxZ controllerMapLayoutManagerSettings, ControllerMapEnabler.nRwNnlnQOFltouymedybQVFLNDP controllerMapEnablerSettings)
		{
			EDIjqnfTfBHPhZHJudQqroNJlrXH = isSystem;
			JYRMuwETpVNRqJXmtBgBFhZdTeP = playerId;
			qpIGvFaemznETzYbpRdmOKmaPCL = name;
			FeaIAYfHUFDXldnlezDhWbiiNzzy = descriptiveName;
			VumWnlylMgxSbyJcluXptXvaaZa = ReInput.id;
			controllers = new ControllerHelper(this, startingControllerMapInfo, controllerMapLayoutManagerSettings, controllerMapEnablerSettings);
			scydGtlzvpdcjviISQJWdAbzZFr = ReInput.AkpZeTvTvDWYnEqWDyDWrcufUCI;
			iDBXctPcOcjjzWbKaCnxuPiVNUc();
		}

		public PlayerSaveData GetSaveData(bool userAssignableMapsOnly)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return default(PlayerSaveData);
			}
			return new PlayerSaveData(controllers.maps.GetAllMapSaveData<JoystickMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<KeyboardMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<MouseMapSaveData>(userAssignableMapsOnly), controllers.maps.GetAllMapSaveData<CustomControllerMapSaveData>(userAssignableMapsOnly), ReInput.mapping.GetInputBehaviors(JYRMuwETpVNRqJXmtBgBFhZdTeP));
		}

		public bool GetButton(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.JFLhhsViRZmASHFRAirmzVNMOhf() ?? false;
		}

		public bool GetButton(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.JFLhhsViRZmASHFRAirmzVNMOhf() ?? false;
		}

		public bool GetButtonDown(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.CmwiIVrqfDqUrfdgDhwXnRxwqAE() ?? false;
		}

		public bool GetButtonDown(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.CmwiIVrqfDqUrfdgDhwXnRxwqAE() ?? false;
		}

		public bool GetButtonUp(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.cpecOFaBXVFHwWEOrZWGPOEkoSMP() ?? false;
		}

		public bool GetButtonUp(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.cpecOFaBXVFHwWEOrZWGPOEkoSMP() ?? false;
		}

		public bool GetButtonPrev(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.NyQDvOIzDpkRBsleftaSWfWiBaUD() ?? false;
		}

		public bool GetButtonPrev(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.NyQDvOIzDpkRBsleftaSWfWiBaUD() ?? false;
		}

		public bool GetButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.QTLvXIaYFpPMOZfpIGILrPOecaW() ?? false;
		}

		public bool GetButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.QTLvXIaYFpPMOZfpIGILrPOecaW() ?? false;
		}

		public bool GetButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.PpZWnKYAyeadsuKqJmajERczqNY() ?? false;
		}

		public bool GetButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.PpZWnKYAyeadsuKqJmajERczqNY() ?? false;
		}

		public bool GetButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.ADNfTWTmfSlOGQjlvAAfCePfsin() ?? false;
		}

		public bool GetButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.ADNfTWTmfSlOGQjlvAAfCePfsin() ?? false;
		}

		public bool GetButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.UUZmGlAOcRhchLoNsdBteRISnEQE(speed) ?? false;
		}

		public bool GetButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.UUZmGlAOcRhchLoNsdBteRISnEQE(speed) ?? false;
		}

		public bool GetButtonDoublePressHold(string actionName)
		{
			return GetButtonDoublePressHold(actionName, 0f);
		}

		public bool GetButtonDoublePressHold(int actionId)
		{
			return GetButtonDoublePressHold(actionId, 0f);
		}

		public bool GetButtonDoublePressDown(string actionName, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.iglKEgVKDfDRCUxquknahEhdtbQ(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.iglKEgVKDfDRCUxquknahEhdtbQ(speed) ?? false;
		}

		public bool GetButtonDoublePressDown(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return GetButtonDoublePressDown(actionName, 0f);
		}

		public bool GetButtonDoublePressDown(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return GetButtonDoublePressDown(actionId, 0f);
		}

		public bool GetButtonDoublePressUp(string actionName, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.pnzcIdXJrVISsrBwsrgSONYhjwk(speed) ?? false;
		}

		public bool GetButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.pnzcIdXJrVISsrBwsrgSONYhjwk(speed) ?? false;
		}

		public bool GetButtonDoublePressUp(string actionName)
		{
			return GetButtonDoublePressUp(actionName, 0f);
		}

		public bool GetButtonDoublePressUp(int actionId)
		{
			return GetButtonDoublePressUp(actionId, 0f);
		}

		public bool GetButtonTimedPress(string actionName, float time)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.MJFiUNuBLTbsJUlFjOVlfkwzBgo(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.MJFiUNuBLTbsJUlFjOVlfkwzBgo(time, 0f) ?? false;
		}

		public bool GetButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.MJFiUNuBLTbsJUlFjOVlfkwzBgo(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.MJFiUNuBLTbsJUlFjOVlfkwzBgo(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.AhxzbaandODBCebugdYNafXSfVN(time) ?? false;
		}

		public bool GetButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.AhxzbaandODBCebugdYNafXSfVN(time) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.JmakveFOtToTPFfcUGpGDreIVVz(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.JmakveFOtToTPFfcUGpGDreIVVz(time, 0f) ?? false;
		}

		public bool GetButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.JmakveFOtToTPFfcUGpGDreIVVz(time, expireIn) ?? false;
		}

		public bool GetButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.JmakveFOtToTPFfcUGpGDreIVVz(time, expireIn) ?? false;
		}

		public bool GetButtonShortPress(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.TDNQHJbeFKJoDxwtrnohFGhnGia() ?? false;
		}

		public bool GetButtonShortPress(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.TDNQHJbeFKJoDxwtrnohFGhnGia() ?? false;
		}

		public bool GetButtonShortPressDown(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.SZLlYDUKPLfOpUVKZFqrIpeYOdq() ?? false;
		}

		public bool GetButtonShortPressDown(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.SZLlYDUKPLfOpUVKZFqrIpeYOdq() ?? false;
		}

		public bool GetButtonShortPressUp(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.uRjrrpPoOXyApRzAqZxwayRoyBU() ?? false;
		}

		public bool GetButtonShortPressUp(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.uRjrrpPoOXyApRzAqZxwayRoyBU() ?? false;
		}

		public bool GetButtonLongPress(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.DPQEfEAGIkMdCxLzhUjNTnVWWUN() ?? false;
		}

		public bool GetButtonLongPress(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.DPQEfEAGIkMdCxLzhUjNTnVWWUN() ?? false;
		}

		public bool GetButtonLongPressDown(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.UFEBQdeMjJKkVodijCmWCvPyPZJ() ?? false;
		}

		public bool GetButtonLongPressDown(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.UFEBQdeMjJKkVodijCmWCvPyPZJ() ?? false;
		}

		public bool GetButtonLongPressUp(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.UuXvkSSlJNzydOxqRRfMzGOVYQy() ?? false;
		}

		public bool GetButtonLongPressUp(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.UuXvkSSlJNzydOxqRRfMzGOVYQy() ?? false;
		}

		public bool GetButtonRepeating(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.xOVlFzhoZHfZzLUlrOuAqsoKUMU() ?? false;
		}

		public bool GetButtonRepeating(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.xOVlFzhoZHfZzLUlrOuAqsoKUMU() ?? false;
		}

		public bool GetAnyButton()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.ZEFJZiaABMktrhDLjeAKbicfiRmL(JYRMuwETpVNRqJXmtBgBFhZdTeP);
		}

		public bool GetAnyButtonDown()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RSwEunaNKyfnjjtVoWSzPKfabcNN(JYRMuwETpVNRqJXmtBgBFhZdTeP);
		}

		public bool GetAnyButtonUp()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.SdgVxmkxIXIaIbUFSwMTeQmRUN(JYRMuwETpVNRqJXmtBgBFhZdTeP);
		}

		public bool GetAnyButtonPrev()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.BDUSBJSsOUWVTWELscIUqkTqfQLB(JYRMuwETpVNRqJXmtBgBFhZdTeP);
		}

		public double GetButtonTimePressed(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.eJIkDJIkPHkALOKPLNjWUzeoogP() ?? 0.0;
		}

		public double GetButtonTimePressed(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.eJIkDJIkPHkALOKPLNjWUzeoogP() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.MiBhFkgQyEvQDqNzuybFYrVQgkac() ?? 0.0;
		}

		public double GetButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.MiBhFkgQyEvQDqNzuybFYrVQgkac() ?? 0.0;
		}

		public bool GetNegativeButton(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.gjvFsQfWVLkGJLUlHHOwfcVAxgI() ?? false;
		}

		public bool GetNegativeButton(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.gjvFsQfWVLkGJLUlHHOwfcVAxgI() ?? false;
		}

		public bool GetNegativeButtonDown(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.wiPVOSjfQFqDVBfmgbvuPukNqlZ() ?? false;
		}

		public bool GetNegativeButtonDown(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.wiPVOSjfQFqDVBfmgbvuPukNqlZ() ?? false;
		}

		public bool GetNegativeButtonUp(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.lSoChdolRrcjvhCMgWkTNuSJzJM() ?? false;
		}

		public bool GetNegativeButtonUp(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.lSoChdolRrcjvhCMgWkTNuSJzJM() ?? false;
		}

		public bool GetNegativeButtonPrev(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.tWNGjrHjjCtCJlLkJMXkyfcwFWa() ?? false;
		}

		public bool GetNegativeButtonPrev(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.tWNGjrHjjCtCJlLkJMXkyfcwFWa() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.wfyKocGkSJJKuvaaDQlbFFZlulI() ?? false;
		}

		public bool GetNegativeButtonSinglePressHold(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.wfyKocGkSJJKuvaaDQlbFFZlulI() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.rNxXdvHMHaWDHmdpbxJrhVReEuF() ?? false;
		}

		public bool GetNegativeButtonSinglePressDown(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.rNxXdvHMHaWDHmdpbxJrhVReEuF() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.LzYqCFtmOAPwFtaNIIAsdeKJjuUW() ?? false;
		}

		public bool GetNegativeButtonSinglePressUp(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.LzYqCFtmOAPwFtaNIIAsdeKJjuUW() ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(string actionName, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.agUAqgemdZpaKOMTCmtHqKZcEwxg(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(int actionId, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.agUAqgemdZpaKOMTCmtHqKZcEwxg(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressHold(string actionName)
		{
			return GetNegativeButtonDoublePressHold(actionName, 0f);
		}

		public bool GetNegativeButtonDoublePressHold(int actionId)
		{
			return GetNegativeButtonDoublePressHold(actionId, 0f);
		}

		public bool GetNegativeButtonDoublePressDown(string actionName, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.wvfXZLJtMOTHRZqKjHcKgEZqIhQy(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressDown(int actionId, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.wvfXZLJtMOTHRZqKjHcKgEZqIhQy(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressDown(string actionName)
		{
			return GetNegativeButtonDoublePressDown(actionName, 0f);
		}

		public bool GetNegativeButtonDoublePressDown(int actionId)
		{
			return GetNegativeButtonDoublePressDown(actionId, 0f);
		}

		public bool GetNegativeButtonDoublePressUp(string actionName, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.KCcpdVlzpCIiXRUPqJoMFQeqdHsG(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressUp(int actionId, float speed)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.KCcpdVlzpCIiXRUPqJoMFQeqdHsG(speed) ?? false;
		}

		public bool GetNegativeButtonDoublePressUp(string actionName)
		{
			return GetNegativeButtonDoublePressUp(actionName, 0f);
		}

		public bool GetNegativeButtonDoublePressUp(int actionId)
		{
			return GetNegativeButtonDoublePressUp(actionId, 0f);
		}

		public bool GetNegativeButtonTimedPress(string actionName, float time)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.HgLItgBCWBsCCYWNBKmKgGDoubH(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.HgLItgBCWBsCCYWNBKmKgGDoubH(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPress(string actionName, float time, float expireIn)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.HgLItgBCWBsCCYWNBKmKgGDoubH(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPress(int actionId, float time, float expireIn)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.HgLItgBCWBsCCYWNBKmKgGDoubH(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(string actionName, float time)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.cDGRdmSKZRTpXeZTLCaInrAktM(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressDown(int actionId, float time)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.cDGRdmSKZRTpXeZTLCaInrAktM(time) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.rwPIJlCPHsrUNNKCobpqYFjHDAa(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.rwPIJlCPHsrUNNKCobpqYFjHDAa(time, 0f) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(string actionName, float time, float expireIn)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.rwPIJlCPHsrUNNKCobpqYFjHDAa(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonTimedPressUp(int actionId, float time, float expireIn)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.rwPIJlCPHsrUNNKCobpqYFjHDAa(time, expireIn) ?? false;
		}

		public bool GetNegativeButtonShortPress(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.nHowdczhJjGQpHoPuhSaxofMeXU() ?? false;
		}

		public bool GetNegativeButtonShortPress(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.nHowdczhJjGQpHoPuhSaxofMeXU() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.QfazomiUZJqoaCvaEoGdIyvImmi() ?? false;
		}

		public bool GetNegativeButtonShortPressDown(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.QfazomiUZJqoaCvaEoGdIyvImmi() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.RBTuBJtXUddlICbnuMOEmSITWbP() ?? false;
		}

		public bool GetNegativeButtonShortPressUp(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.RBTuBJtXUddlICbnuMOEmSITWbP() ?? false;
		}

		public bool GetNegativeButtonLongPress(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.AoOcxpYeHjMNEyQbNoVoYGGKEYs() ?? false;
		}

		public bool GetNegativeButtonLongPress(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.AoOcxpYeHjMNEyQbNoVoYGGKEYs() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.DDgdmSGHKLLlIOmMiTkGuXLuBNc() ?? false;
		}

		public bool GetNegativeButtonLongPressDown(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.DDgdmSGHKLLlIOmMiTkGuXLuBNc() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.JGzwiBNdgTVqoMIKduxivCKdvVw() ?? false;
		}

		public bool GetNegativeButtonLongPressUp(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.JGzwiBNdgTVqoMIKduxivCKdvVw() ?? false;
		}

		public bool GetNegativeButtonRepeating(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.pXXQSEbZHuROokYgEnrXGPzdGtEF() ?? false;
		}

		public bool GetNegativeButtonRepeating(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.pXXQSEbZHuROokYgEnrXGPzdGtEF() ?? false;
		}

		public bool GetAnyNegativeButton()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.nqOePCatWLXLxMGXPYQnhBolKic(JYRMuwETpVNRqJXmtBgBFhZdTeP);
		}

		public bool GetAnyNegativeButtonDown()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.dMTcDaEmFSrHzEOUqoPhOmSTtkWc(JYRMuwETpVNRqJXmtBgBFhZdTeP);
		}

		public bool GetAnyNegativeButtonUp()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.IRONFTFwrVPBpGrUUkUlFjxjhIQ(JYRMuwETpVNRqJXmtBgBFhZdTeP);
		}

		public bool GetAnyNegativeButtonPrev()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.QoIcpQdncbKmYPmwiPrmIoKrKqY(JYRMuwETpVNRqJXmtBgBFhZdTeP);
		}

		public double GetNegativeButtonTimePressed(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.DhArtyydFWSPilbKMhnJVHChwHy() ?? 0.0;
		}

		public double GetNegativeButtonTimePressed(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.DhArtyydFWSPilbKMhnJVHChwHy() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.BfgghzcXbdXcPKaJgTuZMqYCxjg() ?? 0.0;
		}

		public double GetNegativeButtonTimeUnpressed(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.BfgghzcXbdXcPKaJgTuZMqYCxjg() ?? 0.0;
		}

		public float GetAxis(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.MUPgTaacHnwLRmoJOGqdcZFUrOL() ?? 0f;
		}

		public float GetAxis(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.MUPgTaacHnwLRmoJOGqdcZFUrOL() ?? 0f;
		}

		public float GetAxisRaw(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.TXbcHqVYmBHhznWplhLLhIEHQBL() ?? 0f;
		}

		public float GetAxisRaw(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.TXbcHqVYmBHhznWplhLLhIEHQBL() ?? 0f;
		}

		public float GetAxisPrev(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.yhRTsdEWjwmGOFpFVsccvsWQDxL() ?? 0f;
		}

		public float GetAxisPrev(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.yhRTsdEWjwmGOFpFVsccvsWQDxL() ?? 0f;
		}

		public float GetAxisRawPrev(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.MfSnbsPnoWwCjfydtGxjRngFzAj() ?? 0f;
		}

		public float GetAxisRawPrev(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.MfSnbsPnoWwCjfydtGxjRngFzAj() ?? 0f;
		}

		public float GetAxisDelta(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.MxVwcGGHbhfnGaNVFIbAAyLbxvPW() ?? 0f;
		}

		public float GetAxisDelta(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.MxVwcGGHbhfnGaNVFIbAAyLbxvPW() ?? 0f;
		}

		public float GetAxisRawDelta(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.foEYEhchSOmnmeJMLCbFaILSvQG() ?? 0f;
		}

		public float GetAxisRawDelta(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.foEYEhchSOmnmeJMLCbFaILSvQG() ?? 0f;
		}

		public Vector2 GetAxis2D(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			VvbRiPIRRDOGFeaGvZCVmBjRfXT vvbRiPIRRDOGFeaGvZCVmBjRfXT = scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, xAxisActionName, true);
			if (vvbRiPIRRDOGFeaGvZCVmBjRfXT != null)
			{
				result.x = vvbRiPIRRDOGFeaGvZCVmBjRfXT.MUPgTaacHnwLRmoJOGqdcZFUrOL();
			}
			vvbRiPIRRDOGFeaGvZCVmBjRfXT = scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, yAxisActionName, true);
			if (vvbRiPIRRDOGFeaGvZCVmBjRfXT != null)
			{
				result.y = vvbRiPIRRDOGFeaGvZCVmBjRfXT.MUPgTaacHnwLRmoJOGqdcZFUrOL();
			}
			return result;
		}

		public Vector2 GetAxis2D(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			VvbRiPIRRDOGFeaGvZCVmBjRfXT vvbRiPIRRDOGFeaGvZCVmBjRfXT = scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, xAxisActionId, true);
			if (vvbRiPIRRDOGFeaGvZCVmBjRfXT != null)
			{
				result.x = vvbRiPIRRDOGFeaGvZCVmBjRfXT.MUPgTaacHnwLRmoJOGqdcZFUrOL();
			}
			vvbRiPIRRDOGFeaGvZCVmBjRfXT = scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, yAxisActionId, true);
			if (vvbRiPIRRDOGFeaGvZCVmBjRfXT != null)
			{
				result.y = vvbRiPIRRDOGFeaGvZCVmBjRfXT.MUPgTaacHnwLRmoJOGqdcZFUrOL();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			VvbRiPIRRDOGFeaGvZCVmBjRfXT vvbRiPIRRDOGFeaGvZCVmBjRfXT = scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, xAxisActionName, true);
			if (vvbRiPIRRDOGFeaGvZCVmBjRfXT != null)
			{
				result.x = vvbRiPIRRDOGFeaGvZCVmBjRfXT.yhRTsdEWjwmGOFpFVsccvsWQDxL();
			}
			vvbRiPIRRDOGFeaGvZCVmBjRfXT = scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, yAxisActionName, true);
			if (vvbRiPIRRDOGFeaGvZCVmBjRfXT != null)
			{
				result.y = vvbRiPIRRDOGFeaGvZCVmBjRfXT.yhRTsdEWjwmGOFpFVsccvsWQDxL();
			}
			return result;
		}

		public Vector2 GetAxis2DPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			VvbRiPIRRDOGFeaGvZCVmBjRfXT vvbRiPIRRDOGFeaGvZCVmBjRfXT = scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, xAxisActionId, true);
			if (vvbRiPIRRDOGFeaGvZCVmBjRfXT != null)
			{
				result.x = vvbRiPIRRDOGFeaGvZCVmBjRfXT.yhRTsdEWjwmGOFpFVsccvsWQDxL();
			}
			vvbRiPIRRDOGFeaGvZCVmBjRfXT = scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, yAxisActionId, true);
			if (vvbRiPIRRDOGFeaGvZCVmBjRfXT != null)
			{
				result.y = vvbRiPIRRDOGFeaGvZCVmBjRfXT.yhRTsdEWjwmGOFpFVsccvsWQDxL();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			VvbRiPIRRDOGFeaGvZCVmBjRfXT vvbRiPIRRDOGFeaGvZCVmBjRfXT = scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, xAxisActionName, true);
			if (vvbRiPIRRDOGFeaGvZCVmBjRfXT != null)
			{
				result.x = vvbRiPIRRDOGFeaGvZCVmBjRfXT.TXbcHqVYmBHhznWplhLLhIEHQBL();
			}
			vvbRiPIRRDOGFeaGvZCVmBjRfXT = scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, yAxisActionName, true);
			if (vvbRiPIRRDOGFeaGvZCVmBjRfXT != null)
			{
				result.y = vvbRiPIRRDOGFeaGvZCVmBjRfXT.TXbcHqVYmBHhznWplhLLhIEHQBL();
			}
			return result;
		}

		public Vector2 GetAxis2DRaw(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			VvbRiPIRRDOGFeaGvZCVmBjRfXT vvbRiPIRRDOGFeaGvZCVmBjRfXT = scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, xAxisActionId, true);
			if (vvbRiPIRRDOGFeaGvZCVmBjRfXT != null)
			{
				result.x = vvbRiPIRRDOGFeaGvZCVmBjRfXT.TXbcHqVYmBHhznWplhLLhIEHQBL();
			}
			vvbRiPIRRDOGFeaGvZCVmBjRfXT = scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, yAxisActionId, true);
			if (vvbRiPIRRDOGFeaGvZCVmBjRfXT != null)
			{
				result.y = vvbRiPIRRDOGFeaGvZCVmBjRfXT.TXbcHqVYmBHhznWplhLLhIEHQBL();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(string xAxisActionName, string yAxisActionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			VvbRiPIRRDOGFeaGvZCVmBjRfXT vvbRiPIRRDOGFeaGvZCVmBjRfXT = scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, xAxisActionName, true);
			if (vvbRiPIRRDOGFeaGvZCVmBjRfXT != null)
			{
				result.x = vvbRiPIRRDOGFeaGvZCVmBjRfXT.MfSnbsPnoWwCjfydtGxjRngFzAj();
			}
			vvbRiPIRRDOGFeaGvZCVmBjRfXT = scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, yAxisActionName, true);
			if (vvbRiPIRRDOGFeaGvZCVmBjRfXT != null)
			{
				result.y = vvbRiPIRRDOGFeaGvZCVmBjRfXT.MfSnbsPnoWwCjfydtGxjRngFzAj();
			}
			return result;
		}

		public Vector2 GetAxis2DRawPrev(int xAxisActionId, int yAxisActionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return Vector2.zero;
			}
			Vector2 result = default(Vector2);
			VvbRiPIRRDOGFeaGvZCVmBjRfXT vvbRiPIRRDOGFeaGvZCVmBjRfXT = scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, xAxisActionId, true);
			if (vvbRiPIRRDOGFeaGvZCVmBjRfXT != null)
			{
				result.x = vvbRiPIRRDOGFeaGvZCVmBjRfXT.MfSnbsPnoWwCjfydtGxjRngFzAj();
			}
			vvbRiPIRRDOGFeaGvZCVmBjRfXT = scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, yAxisActionId, true);
			if (vvbRiPIRRDOGFeaGvZCVmBjRfXT != null)
			{
				result.y = vvbRiPIRRDOGFeaGvZCVmBjRfXT.MfSnbsPnoWwCjfydtGxjRngFzAj();
			}
			return result;
		}

		public double GetAxisTimeActive(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.ROFGAKBXkOUSJeiEwdoIaObzuwAv() ?? 0.0;
		}

		public double GetAxisTimeActive(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.ROFGAKBXkOUSJeiEwdoIaObzuwAv() ?? 0.0;
		}

		public double GetAxisTimeInactive(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.XordwqAACJLMnlJHKUPRKMLQKpf() ?? 0.0;
		}

		public double GetAxisTimeInactive(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.XordwqAACJLMnlJHKUPRKMLQKpf() ?? 0.0;
		}

		public double GetAxisRawTimeActive(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.OspDFsiqCYnXKftWMMvwNmljEZeJ() ?? 0.0;
		}

		public double GetAxisRawTimeActive(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.OspDFsiqCYnXKftWMMvwNmljEZeJ() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.QsPMxpiDfIBdQvNJUKjEgcEdDeIh() ?? 0.0;
		}

		public double GetAxisRawTimeInactive(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0.0;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.QsPMxpiDfIBdQvNJUKjEgcEdDeIh() ?? 0.0;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return AxisCoordinateMode.Absolute;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.YQlzAWiCZMlULuDcbVAWgHxwLnp() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateMode(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return AxisCoordinateMode.Absolute;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.YQlzAWiCZMlULuDcbVAWgHxwLnp() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return AxisCoordinateMode.Absolute;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.vOVSrAcaeceLsbxuJNqiLFDYiMV() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return AxisCoordinateMode.Absolute;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.vOVSrAcaeceLsbxuJNqiLFDYiMV() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return AxisCoordinateMode.Absolute;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.wrzdWLIoStIKtAegJzJFnwZdBuh() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return AxisCoordinateMode.Absolute;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.wrzdWLIoStIKtAegJzJFnwZdBuh() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return AxisCoordinateMode.Absolute;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.OGNTTWyRbuqPgdvDWeihzMCoqOf() ?? AxisCoordinateMode.Absolute;
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return AxisCoordinateMode.Absolute;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.OGNTTWyRbuqPgdvDWeihzMCoqOf() ?? AxisCoordinateMode.Absolute;
		}

		public IList<InputActionSourceData> GetCurrentInputSources(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.uvXaIVxGMrdmWpixZvZhiudfpZs();
		}

		public IList<InputActionSourceData> GetCurrentInputSources(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<InputActionSourceData>.EmptyReadOnlyIListT;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.uvXaIVxGMrdmWpixZvZhiudfpZs();
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.CEioayAKpkHgZSUoQlmVRVAagDk(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.CEioayAKpkHgZSUoQlmVRVAagDk(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.CEioayAKpkHgZSUoQlmVRVAagDk(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, ControllerType controllerType, int controllerId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.CEioayAKpkHgZSUoQlmVRVAagDk(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(string actionName, Controller controller)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionName, true)?.CEioayAKpkHgZSUoQlmVRVAagDk(controller) ?? false;
		}

		public bool IsCurrentInputSource(int actionId, Controller controller)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			return scydGtlzvpdcjviISQJWdAbzZFr.RBIWoiWucaBtFKDYvIAUOHZykHm(JYRMuwETpVNRqJXmtBgBFhZdTeP, actionId, true)?.CEioayAKpkHgZSUoQlmVRVAagDk(controller) ?? false;
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					scydGtlzvpdcjviISQJWdAbzZFr.oxajqOBcvxFwvcUsERaSFiCLsDM(JYRMuwETpVNRqJXmtBgBFhZdTeP, callback, updateLoop);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					scydGtlzvpdcjviISQJWdAbzZFr.oxajqOBcvxFwvcUsERaSFiCLsDM(JYRMuwETpVNRqJXmtBgBFhZdTeP, callback, updateLoop, actionId);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return;
			}
			int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			if (num >= 0)
			{
				AddInputEventDelegate(callback, updateLoop, num);
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
		{
			AddInputEventDelegate(callback, updateLoop, eventType, (object[])null);
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
		{
			AddInputEventDelegate(callback, updateLoop, eventType, actionId, null);
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
		{
			AddInputEventDelegate(callback, updateLoop, eventType, actionName, null);
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, object[] arguments)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					scydGtlzvpdcjviISQJWdAbzZFr.oxajqOBcvxFwvcUsERaSFiCLsDM(JYRMuwETpVNRqJXmtBgBFhZdTeP, callback, updateLoop, eventType, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId, object[] arguments)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					scydGtlzvpdcjviISQJWdAbzZFr.oxajqOBcvxFwvcUsERaSFiCLsDM(JYRMuwETpVNRqJXmtBgBFhZdTeP, callback, updateLoop, eventType, actionId, arguments);
				}
			}
		}

		public void AddInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName, object[] arguments)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return;
			}
			int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName, true);
			if (num >= 0)
			{
				AddInputEventDelegate(callback, updateLoop, eventType, num, arguments);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					scydGtlzvpdcjviISQJWdAbzZFr.tyFeiIHqbjlgMjxLdJoLlFaykNoz(JYRMuwETpVNRqJXmtBgBFhZdTeP, callback);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					scydGtlzvpdcjviISQJWdAbzZFr.tyFeiIHqbjlgMjxLdJoLlFaykNoz(JYRMuwETpVNRqJXmtBgBFhZdTeP, callback, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return;
			}
			int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					scydGtlzvpdcjviISQJWdAbzZFr.tyFeiIHqbjlgMjxLdJoLlFaykNoz(JYRMuwETpVNRqJXmtBgBFhZdTeP, callback, updateLoop);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					scydGtlzvpdcjviISQJWdAbzZFr.tyFeiIHqbjlgMjxLdJoLlFaykNoz(JYRMuwETpVNRqJXmtBgBFhZdTeP, callback, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					scydGtlzvpdcjviISQJWdAbzZFr.tyFeiIHqbjlgMjxLdJoLlFaykNoz(JYRMuwETpVNRqJXmtBgBFhZdTeP, callback, updateLoop, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return;
			}
			int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					scydGtlzvpdcjviISQJWdAbzZFr.tyFeiIHqbjlgMjxLdJoLlFaykNoz(JYRMuwETpVNRqJXmtBgBFhZdTeP, callback, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return;
			}
			int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, eventType, num);
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					scydGtlzvpdcjviISQJWdAbzZFr.tyFeiIHqbjlgMjxLdJoLlFaykNoz(JYRMuwETpVNRqJXmtBgBFhZdTeP, callback, updateLoop, eventType);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId)
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					scydGtlzvpdcjviISQJWdAbzZFr.tyFeiIHqbjlgMjxLdJoLlFaykNoz(JYRMuwETpVNRqJXmtBgBFhZdTeP, callback, updateLoop, eventType, actionId);
				}
			}
		}

		public void RemoveInputEventDelegate(Action<InputActionEventData> callback, UpdateLoopType updateLoop, InputActionEventType eventType, string actionName)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return;
			}
			int num = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			if (num >= 0)
			{
				RemoveInputEventDelegate(callback, updateLoop, eventType, num);
			}
		}

		public void ClearInputEventDelegates()
		{
			if (ReInput.isReady)
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				}
				else
				{
					scydGtlzvpdcjviISQJWdAbzZFr.oMDCImrWTNmtnocxXQYboXctem(JYRMuwETpVNRqJXmtBgBFhZdTeP);
				}
			}
		}

		public void SetVibration(int motorIndex, float motorLevel)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors: false);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			SetVibration(motorIndex, motorLevel, duration, stopOtherMotors: false);
		}

		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return;
			}
			IList<Joystick> joysticks = controllers.Joysticks;
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				Joystick joystick = joysticks[i];
				if (joystick.supportsVibration)
				{
					joystick.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
				}
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			IList<Joystick> joysticks = controllers.Joysticks;
			int count = joysticks.Count;
			float num = 0f;
			for (int i = 0; i < count; i++)
			{
				Joystick joystick = joysticks[i];
				if (joystick.supportsVibration)
				{
					num = MathTools.Max(joystick.GetVibration(motorIndex), num);
				}
			}
			return num;
		}

		public void StopVibration()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return;
			}
			IList<Joystick> joysticks = controllers.Joysticks;
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				Joystick joystick = joysticks[i];
				if (joystick.supportsVibration)
				{
					joystick.StopVibration();
				}
			}
		}

		internal void agvWMBoHtblzmgSmVloJbsDkfGk()
		{
			iDBXctPcOcjjzWbKaCnxuPiVNUc();
		}

		private void iDBXctPcOcjjzWbKaCnxuPiVNUc()
		{
			controllers.iDBXctPcOcjjzWbKaCnxuPiVNUc();
			nPLLKPaRzzMBweCuqwFziTYjFUw = false;
		}
	}
}
