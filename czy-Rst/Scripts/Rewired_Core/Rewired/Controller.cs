using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public abstract class Controller
	{
		public abstract class Element
		{
			internal abstract class bichVacXImjrhzYncfMpWQizAgrJ
			{
				public abstract class iYbOuMJIrJhTiAjymugzklCVLYwm
				{
					public abstract void GhLPaVNcvaMBhDDjBQdTfBZxkRoO();
				}

				protected readonly int AroiAYoWZtrmxQOdYERyfjPNaurb;

				protected readonly int[] FbdfAabSgqAcbGduBbbYeuhHphlaB;

				protected iYbOuMJIrJhTiAjymugzklCVLYwm[] WzSZdGhqRByxigDFUiRLuGcqAiMCA;

				public iYbOuMJIrJhTiAjymugzklCVLYwm GeSbjRBQSrftRFdtRlUbOnoUUrYb;

				private int aGTXsyaHeHgGSMaduftfDVZurmTKA;

				public int hNritsHzSPJnxRQfJUyBtadbitPA = -1;

				protected ReadOnlyCollection<iYbOuMJIrJhTiAjymugzklCVLYwm> vIKeaHJyiTtFMnsHwlBDAOxXNuLH;

				public IList<iYbOuMJIrJhTiAjymugzklCVLYwm> keqpceJolbIIOdNjuoTmgFRisHMdc => vIKeaHJyiTtFMnsHwlBDAOxXNuLH;

				public UpdateLoopType zwotyQMjNNPWaauZkuHfgqpPPonF
				{
					set
					{
						if (hNritsHzSPJnxRQfJUyBtadbitPA != (int)updateLoopType)
						{
							hNritsHzSPJnxRQfJUyBtadbitPA = (int)updateLoopType;
							aGTXsyaHeHgGSMaduftfDVZurmTKA = FbdfAabSgqAcbGduBbbYeuhHphlaB[(int)updateLoopType];
							GeSbjRBQSrftRFdtRlUbOnoUUrYb = WzSZdGhqRByxigDFUiRLuGcqAiMCA[aGTXsyaHeHgGSMaduftfDVZurmTKA];
						}
					}
				}

				public bichVacXImjrhzYncfMpWQizAgrJ(UpdateLoopSetting P_0)
				{
					FbdfAabSgqAcbGduBbbYeuhHphlaB = new int[3];
					AroiAYoWZtrmxQOdYERyfjPNaurb = 0;
					using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
					{
						List<UpdateLoopType> list = tList.list;
						EnumConverter.ToUpdateLoopTypes(P_0, list);
						for (int i = 0; i < list.Count; i++)
						{
							FbdfAabSgqAcbGduBbbYeuhHphlaB[(int)list[i]] = AroiAYoWZtrmxQOdYERyfjPNaurb;
							AroiAYoWZtrmxQOdYERyfjPNaurb++;
						}
					}
					WzSZdGhqRByxigDFUiRLuGcqAiMCA = new iYbOuMJIrJhTiAjymugzklCVLYwm[AroiAYoWZtrmxQOdYERyfjPNaurb];
					vIKeaHJyiTtFMnsHwlBDAOxXNuLH = new ReadOnlyCollection<iYbOuMJIrJhTiAjymugzklCVLYwm>(WzSZdGhqRByxigDFUiRLuGcqAiMCA);
				}

				public void WSYkLSePPUARtaDmyBmydRiVvaCE()
				{
					for (int i = 0; i < AroiAYoWZtrmxQOdYERyfjPNaurb; i++)
					{
						WzSZdGhqRByxigDFUiRLuGcqAiMCA[i].GhLPaVNcvaMBhDDjBQdTfBZxkRoO();
					}
				}

				public iYbOuMJIrJhTiAjymugzklCVLYwm NcIkuriSxYgDpmpRRajejlyWCeWAb(UpdateLoopType P_0)
				{
					return WzSZdGhqRByxigDFUiRLuGcqAiMCA[FbdfAabSgqAcbGduBbbYeuhHphlaB[(int)P_0]];
				}
			}

			public readonly int id;

			public readonly string name;

			public readonly ControllerElementType type;

			internal bichVacXImjrhzYncfMpWQizAgrJ xvLftKFVDqAMSDhMgQaeDMHwhggUb;

			internal int lJNgqPgIDbUDuVOMXsHMUyMNJOis;

			internal Controller PVhaaUSScreMCCMfGAFzHCnhBcGVB;

			internal readonly int ajhoJpBzljiuQdLiJzdMWAyrcMji;

			private CompoundElement DkWgQTdbvnZvQkIJeHYRalyDCEFmc;

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = PVhaaUSScreMCCMfGAFzHCnhBcGVB.GetElementIdentifierById(id);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			public bool isMemberElement
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return false;
					}
					return lJNgqPgIDbUDuVOMXsHMUyMNJOis > 0;
				}
			}

			public CompoundElement compoundElement => DkWgQTdbvnZvQkIJeHYRalyDCEFmc;

			internal Element(Controller P_0, int P_1, string P_2, ControllerElementType P_3)
			{
				PVhaaUSScreMCCMfGAFzHCnhBcGVB = P_0;
				id = P_1;
				name = P_2;
				type = P_3;
				ajhoJpBzljiuQdLiJzdMWAyrcMji = ReInput.id;
			}

			public void Reset()
			{
				if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
				{
					ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
				}
				else if (xvLftKFVDqAMSDhMgQaeDMHwhggUb != null)
				{
					xvLftKFVDqAMSDhMgQaeDMHwhggUb.WSYkLSePPUARtaDmyBmydRiVvaCE();
				}
			}

			internal void yzvfXmiATqYMtWwYDTozscIzRpxp(CompoundElement P_0)
			{
				if (lJNgqPgIDbUDuVOMXsHMUyMNJOis > 0)
				{
					Logger.LogWarning("This element is already a member of a compound element! This is not supported. Resulting values may be unpredictable.");
				}
				lJNgqPgIDbUDuVOMXsHMUyMNJOis++;
				if (DkWgQTdbvnZvQkIJeHYRalyDCEFmc == null)
				{
					DkWgQTdbvnZvQkIJeHYRalyDCEFmc = P_0;
				}
			}

			internal void pUQVMMkCwCfylfIhSaYsvruKnwfA(CompoundElement P_0)
			{
				if (lJNgqPgIDbUDuVOMXsHMUyMNJOis == 0)
				{
					Logger.LogWarning("This element is not a member of a compound element!");
					lJNgqPgIDbUDuVOMXsHMUyMNJOis = 0;
					return;
				}
				lJNgqPgIDbUDuVOMXsHMUyMNJOis--;
				if (DkWgQTdbvnZvQkIJeHYRalyDCEFmc == P_0)
				{
					DkWgQTdbvnZvQkIJeHYRalyDCEFmc = null;
				}
			}
		}

		public sealed class Axis : Element
		{
			internal class icqJAnumHetTtbUWKbZIRQCPOuUq : bichVacXImjrhzYncfMpWQizAgrJ
			{
				public class bbeOFXnUFSRVisiSFKSjhoupylSM : iYbOuMJIrJhTiAjymugzklCVLYwm
				{
					private const float npsblISEDCcRKQcduRSgyEgNNMbA = 0.001f;

					public float hIWJMcZSHWsEYbiVrvkfZyxLEVjp;

					public float HRwOeKNPgdlVaHqPUOKcLSYrWiMO;

					public float qoXKCHiSuuJogkqepoxPrdnmIlPiA;

					public float HApyoumFyeKKFQOgeGwILEQzwmtF;

					public float OjUXKZKhuSYuMjdANIcZGDGoSCFe;

					public float nELArJeITQGYlOvHoAhYgnlsCLTiA;

					public double DSwCzdhaIxQzCpDSZSMHIgEfMyAqA;

					public double tAJWxIMqLwdLVjqxpktREOJXkHmT;

					public double cZvxvZOpwbgrOggJVPpHVzLvInIjA;

					public double UyruhQTvNZVhwjbZziBmEZDiPkoU;

					public double UnwtMueUwhWtPaJMDGvmZdOPARAX;

					public double tsjxtdLrApeVAEUfUPHTcgtZuxLX;

					public double QxtYvfhhqhqaHKkgDawWCHShmmCZA
					{
						get
						{
							if ((double)hIWJMcZSHWsEYbiVrvkfZyxLEVjp == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - cZvxvZOpwbgrOggJVPpHVzLvInIjA;
						}
					}

					public double BdxkZBFSfQCobpOtEqryMfMbciVr
					{
						get
						{
							if ((double)qoXKCHiSuuJogkqepoxPrdnmIlPiA == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - UyruhQTvNZVhwjbZziBmEZDiPkoU;
						}
					}

					public double wlinutYIlhgNvgnAAjMXdDajMNVMA
					{
						get
						{
							if (hIWJMcZSHWsEYbiVrvkfZyxLEVjp != 0f)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - DSwCzdhaIxQzCpDSZSMHIgEfMyAqA;
						}
					}

					public double OaxxJZykhFrXINzoVCrWFkIboDRA
					{
						get
						{
							if ((double)qoXKCHiSuuJogkqepoxPrdnmIlPiA != 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - tAJWxIMqLwdLVjqxpktREOJXkHmT;
						}
					}

					public void KEvHObjeNQrwZMjKTEiOFvciURiib(bool P_0)
					{
						double unscaledTime = ReInput.unscaledTime;
						if (P_0)
						{
							if (!MathTools.Approximately(OjUXKZKhuSYuMjdANIcZGDGoSCFe, 0f))
							{
								DSwCzdhaIxQzCpDSZSMHIgEfMyAqA = unscaledTime;
							}
							else
							{
								cZvxvZOpwbgrOggJVPpHVzLvInIjA = unscaledTime;
							}
							if (!MathTools.IsNear(OjUXKZKhuSYuMjdANIcZGDGoSCFe, nELArJeITQGYlOvHoAhYgnlsCLTiA, 0.001f))
							{
								UnwtMueUwhWtPaJMDGvmZdOPARAX = unscaledTime;
							}
						}
						else
						{
							if (!MathTools.Approximately(hIWJMcZSHWsEYbiVrvkfZyxLEVjp, 0f))
							{
								DSwCzdhaIxQzCpDSZSMHIgEfMyAqA = unscaledTime;
							}
							else
							{
								cZvxvZOpwbgrOggJVPpHVzLvInIjA = unscaledTime;
							}
							if (!MathTools.IsNear(hIWJMcZSHWsEYbiVrvkfZyxLEVjp, HRwOeKNPgdlVaHqPUOKcLSYrWiMO, 0.001f))
							{
								UnwtMueUwhWtPaJMDGvmZdOPARAX = unscaledTime;
							}
						}
						if (!MathTools.Approximately(qoXKCHiSuuJogkqepoxPrdnmIlPiA, 0f))
						{
							tAJWxIMqLwdLVjqxpktREOJXkHmT = unscaledTime;
						}
						else
						{
							UyruhQTvNZVhwjbZziBmEZDiPkoU = unscaledTime;
						}
						if (!MathTools.IsNear(qoXKCHiSuuJogkqepoxPrdnmIlPiA, HApyoumFyeKKFQOgeGwILEQzwmtF, 0.001f))
						{
							tsjxtdLrApeVAEUfUPHTcgtZuxLX = unscaledTime;
						}
					}

					public void uhdcWcrVHnejeRPIsUVkzweyUdvm(float P_0)
					{
						if (HApyoumFyeKKFQOgeGwILEQzwmtF != qoXKCHiSuuJogkqepoxPrdnmIlPiA)
						{
							HApyoumFyeKKFQOgeGwILEQzwmtF = qoXKCHiSuuJogkqepoxPrdnmIlPiA;
						}
						if (qoXKCHiSuuJogkqepoxPrdnmIlPiA != P_0)
						{
							qoXKCHiSuuJogkqepoxPrdnmIlPiA = P_0;
						}
					}

					public virtual void dWftSbVCZcedyfFiSRnUXoODUJdO()
					{
						hIWJMcZSHWsEYbiVrvkfZyxLEVjp = 0f;
						HRwOeKNPgdlVaHqPUOKcLSYrWiMO = 0f;
						qoXKCHiSuuJogkqepoxPrdnmIlPiA = 0f;
						HApyoumFyeKKFQOgeGwILEQzwmtF = 0f;
						DSwCzdhaIxQzCpDSZSMHIgEfMyAqA = 0.0;
						tAJWxIMqLwdLVjqxpktREOJXkHmT = 0.0;
						cZvxvZOpwbgrOggJVPpHVzLvInIjA = 0.0;
						UyruhQTvNZVhwjbZziBmEZDiPkoU = 0.0;
						UnwtMueUwhWtPaJMDGvmZdOPARAX = 0.0;
						tsjxtdLrApeVAEUfUPHTcgtZuxLX = 0.0;
					}
				}

				public icqJAnumHetTtbUWKbZIRQCPOuUq(UpdateLoopSetting P_0)
					: base(P_0)
				{
					for (int i = 0; i < AroiAYoWZtrmxQOdYERyfjPNaurb; i++)
					{
						WzSZdGhqRByxigDFUiRLuGcqAiMCA[i] = new bbeOFXnUFSRVisiSFKSjhoupylSM();
					}
					GeSbjRBQSrftRFdtRlUbOnoUUrYb = WzSZdGhqRByxigDFUiRLuGcqAiMCA[0];
				}
			}

			internal readonly AxisRange spyKkMsDSYGhoDOwKTrPUGFUCGnt;

			internal readonly HardwareAxisInfo hGVuzmiWOAnhEmGFXjTzQspEcSPiA;

			public float value
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).OjUXKZKhuSYuMjdANIcZGDGoSCFe;
					}
					return ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).hIWJMcZSHWsEYbiVrvkfZyxLEVjp;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).nELArJeITQGYlOvHoAhYgnlsCLTiA;
					}
					return ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).HRwOeKNPgdlVaHqPUOKcLSYrWiMO;
				}
			}

			public float valueRaw
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0f;
					}
					return ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).qoXKCHiSuuJogkqepoxPrdnmIlPiA;
				}
				internal set
				{
					((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).uhdcWcrVHnejeRPIsUVkzweyUdvm(num);
				}
			}

			public float valueRawPrev
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0f;
					}
					return ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).HApyoumFyeKKFQOgeGwILEQzwmtF;
				}
			}

			public float valueDelta
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0f;
					}
					return value - valuePrev;
				}
			}

			public float valueDeltaRaw
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0f;
					}
					return ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).qoXKCHiSuuJogkqepoxPrdnmIlPiA - ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).HApyoumFyeKKFQOgeGwILEQzwmtF;
				}
			}

			public double lastTimeActive
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0.0;
					}
					return ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).DSwCzdhaIxQzCpDSZSMHIgEfMyAqA;
				}
			}

			public double lastTimeActiveRaw
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0.0;
					}
					return ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).tAJWxIMqLwdLVjqxpktREOJXkHmT;
				}
			}

			public double lastTimeInactive
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0.0;
					}
					return ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).cZvxvZOpwbgrOggJVPpHVzLvInIjA;
				}
			}

			public double lastTimeInactiveRaw
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0.0;
					}
					return ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).UyruhQTvNZVhwjbZziBmEZDiPkoU;
				}
			}

			public double lastTimeValueChanged
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0.0;
					}
					return ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).UnwtMueUwhWtPaJMDGvmZdOPARAX;
				}
			}

			public double lastTimeValueChangedRaw
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0.0;
					}
					return ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).tsjxtdLrApeVAEUfUPHTcgtZuxLX;
				}
			}

			public double timeActive
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0.0;
					}
					return ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).QxtYvfhhqhqaHKkgDawWCHShmmCZA;
				}
			}

			public double timeActiveRaw
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0.0;
					}
					return ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).QxtYvfhhqhqaHKkgDawWCHShmmCZA;
				}
			}

			public double timeInactive
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0.0;
					}
					return ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).wlinutYIlhgNvgnAAjMXdDajMNVMA;
				}
			}

			public double timeInactiveRaw
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0.0;
					}
					return ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).OaxxJZykhFrXINzoVCrWFkIboDRA;
				}
			}

			public float pollingDeadZone
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0f;
					}
					if (hGVuzmiWOAnhEmGFXjTzQspEcSPiA == null)
					{
						return -1f;
					}
					return hGVuzmiWOAnhEmGFXjTzQspEcSPiA._pollingDeadZone;
				}
				set
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return;
					}
					if (value < 0f)
					{
						value = -1f;
					}
					if (hGVuzmiWOAnhEmGFXjTzQspEcSPiA != null)
					{
						hGVuzmiWOAnhEmGFXjTzQspEcSPiA._pollingDeadZone = value;
					}
				}
			}

			internal float RGeXyNWWzljooqCtdlGYBDfJOuvV => ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).hIWJMcZSHWsEYbiVrvkfZyxLEVjp;

			internal float YniPASXloEhglNOivcDPbsDPGNtN => ((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).HRwOeKNPgdlVaHqPUOKcLSYrWiMO;

			internal float XpSsNXWTRdqOFZzqKORsXwzttbRs
			{
				get
				{
					if (hGVuzmiWOAnhEmGFXjTzQspEcSPiA == null)
					{
						return ReInput.configuration.defaultAbsoluteAxisPollingDeadZone;
					}
					if (hGVuzmiWOAnhEmGFXjTzQspEcSPiA._pollingDeadZone >= 0f)
					{
						return hGVuzmiWOAnhEmGFXjTzQspEcSPiA._pollingDeadZone;
					}
					return hGVuzmiWOAnhEmGFXjTzQspEcSPiA._dataFormat switch
					{
						AxisCoordinateMode.Absolute => ReInput.configuration.defaultAbsoluteAxisPollingDeadZone, 
						AxisCoordinateMode.Relative => ReInput.configuration.defaultRelativeAxisPollingDeadZone, 
						_ => throw new NotImplementedException(), 
					};
				}
			}

			internal void CaQzOHlSRLxyOCaFzJQBXrUydOLY(float P_0)
			{
				icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM obj = (icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb;
				obj.nELArJeITQGYlOvHoAhYgnlsCLTiA = obj.OjUXKZKhuSYuMjdANIcZGDGoSCFe;
				obj.OjUXKZKhuSYuMjdANIcZGDGoSCFe = P_0;
			}

			internal Axis(Controller P_0, int P_1, string P_2, AxisRange P_3, HardwareAxisInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Axis)
			{
				xvLftKFVDqAMSDhMgQaeDMHwhggUb = new icqJAnumHetTtbUWKbZIRQCPOuUq(ReInput.configVars.updateLoop);
				spyKkMsDSYGhoDOwKTrPUGFUCGnt = P_3;
				hGVuzmiWOAnhEmGFXjTzQspEcSPiA = P_4;
			}

			internal void btDxpVkziGaudWoyiggQGtlcabyZ(UpdateLoopType P_0)
			{
				if (xvLftKFVDqAMSDhMgQaeDMHwhggUb != null && xvLftKFVDqAMSDhMgQaeDMHwhggUb.hNritsHzSPJnxRQfJUyBtadbitPA != (int)P_0)
				{
					xvLftKFVDqAMSDhMgQaeDMHwhggUb.zwotyQMjNNPWaauZkuHfgqpPPonF = P_0;
				}
			}

			internal void TbXHKBfIRnoJwjoMRKnmWJOqUhxT(AxisCalibration P_0)
			{
				icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM bbeOFXnUFSRVisiSFKSjhoupylSM = (icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb;
				bbeOFXnUFSRVisiSFKSjhoupylSM.HRwOeKNPgdlVaHqPUOKcLSYrWiMO = bbeOFXnUFSRVisiSFKSjhoupylSM.hIWJMcZSHWsEYbiVrvkfZyxLEVjp;
				float hIWJMcZSHWsEYbiVrvkfZyxLEVjp = P_0.GetCalibratedValue(bbeOFXnUFSRVisiSFKSjhoupylSM.qoXKCHiSuuJogkqepoxPrdnmIlPiA, spyKkMsDSYGhoDOwKTrPUGFUCGnt);
				if (P_0.applyRangeCalibration)
				{
					hIWJMcZSHWsEYbiVrvkfZyxLEVjp = MathTools.Clamp(hIWJMcZSHWsEYbiVrvkfZyxLEVjp, -1f, 1f);
				}
				bbeOFXnUFSRVisiSFKSjhoupylSM.hIWJMcZSHWsEYbiVrvkfZyxLEVjp = hIWJMcZSHWsEYbiVrvkfZyxLEVjp;
			}

			internal void AFzZNTfEwYaqsWZAqHOjkADExKSs()
			{
				icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM obj = (icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb;
				obj.HRwOeKNPgdlVaHqPUOKcLSYrWiMO = obj.hIWJMcZSHWsEYbiVrvkfZyxLEVjp;
				obj.hIWJMcZSHWsEYbiVrvkfZyxLEVjp = obj.qoXKCHiSuuJogkqepoxPrdnmIlPiA;
			}

			internal void OYbzcmZKLozkOLJYcetOJBdWwUnpA()
			{
				icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM obj = (icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb;
				obj.HRwOeKNPgdlVaHqPUOKcLSYrWiMO = obj.hIWJMcZSHWsEYbiVrvkfZyxLEVjp;
				obj.hIWJMcZSHWsEYbiVrvkfZyxLEVjp = 0f;
			}

			internal void rkXcsejOnlNzjRXzKvySDceUuDmw()
			{
				((icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).KEvHObjeNQrwZMjKTEiOFvciURiib(base.isMemberElement);
			}

			internal void GgMvXAUrwiUHbXTVvMDQNDTLXRpX(float P_0)
			{
				for (int i = 0; i < xvLftKFVDqAMSDhMgQaeDMHwhggUb.keqpceJolbIIOdNjuoTmgFRisHMdc.Count; i++)
				{
					if (xvLftKFVDqAMSDhMgQaeDMHwhggUb.keqpceJolbIIOdNjuoTmgFRisHMdc[i] is icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM bbeOFXnUFSRVisiSFKSjhoupylSM)
					{
						bbeOFXnUFSRVisiSFKSjhoupylSM.uhdcWcrVHnejeRPIsUVkzweyUdvm(P_0);
						bbeOFXnUFSRVisiSFKSjhoupylSM.HRwOeKNPgdlVaHqPUOKcLSYrWiMO = bbeOFXnUFSRVisiSFKSjhoupylSM.hIWJMcZSHWsEYbiVrvkfZyxLEVjp;
						bbeOFXnUFSRVisiSFKSjhoupylSM.hIWJMcZSHWsEYbiVrvkfZyxLEVjp = 0f;
						bbeOFXnUFSRVisiSFKSjhoupylSM.KEvHObjeNQrwZMjKTEiOFvciURiib(base.isMemberElement);
					}
				}
			}

			internal float WrQNkgvPSzdiZlgWPqODPhhgICoL(UpdateLoopType P_0, AxisCalibration P_1)
			{
				icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM bbeOFXnUFSRVisiSFKSjhoupylSM = (icqJAnumHetTtbUWKbZIRQCPOuUq.bbeOFXnUFSRVisiSFKSjhoupylSM)xvLftKFVDqAMSDhMgQaeDMHwhggUb.NcIkuriSxYgDpmpRRajejlyWCeWAb(P_0);
				float result = P_1.GetCalibratedValue(bbeOFXnUFSRVisiSFKSjhoupylSM.qoXKCHiSuuJogkqepoxPrdnmIlPiA, spyKkMsDSYGhoDOwKTrPUGFUCGnt, P_1.deadZone, applySensitivity: false, applyInversion: true);
				if (P_1.applyRangeCalibration)
				{
					result = MathTools.Clamp(result, -1f, 1f);
				}
				return result;
			}
		}

		public sealed class Button : Element
		{
			internal class byfXzbQLdsTDWLBOsXXyXCXECEOl : bichVacXImjrhzYncfMpWQizAgrJ
			{
				public class LJZSfYvABOkaaoihPztTvKgXIFSS : iYbOuMJIrJhTiAjymugzklCVLYwm
				{
					public bool ktCWeSsbsZnlUsKEqjngmKfTyoo;

					public bool nZdCHjsswxfLKJQfsllhHsELxZeeb;

					public ButtonStateRecorder GrnRDovhgvTKbgZBLRLUoMXIOvPm;

					public apFcJoiTMPzetoBCwhhDqnJBeCoL lqfjGSXAvzAJGHCwmgobtiLlwIOb;

					public LJZSfYvABOkaaoihPztTvKgXIFSS()
					{
						GrnRDovhgvTKbgZBLRLUoMXIOvPm = new ButtonStateRecorder();
						lqfjGSXAvzAJGHCwmgobtiLlwIOb = new apFcJoiTMPzetoBCwhhDqnJBeCoL(0.3f);
					}

					public void FlYIGJTkwnBrVOWbpebjhGRkVHof(bool P_0)
					{
						if (nZdCHjsswxfLKJQfsllhHsELxZeeb != ktCWeSsbsZnlUsKEqjngmKfTyoo)
						{
							nZdCHjsswxfLKJQfsllhHsELxZeeb = ktCWeSsbsZnlUsKEqjngmKfTyoo;
						}
						if (ktCWeSsbsZnlUsKEqjngmKfTyoo != P_0)
						{
							ktCWeSsbsZnlUsKEqjngmKfTyoo = P_0;
						}
						GrnRDovhgvTKbgZBLRLUoMXIOvPm.ApkPQPyeABoMoWjCtQLCndpyAqqN(P_0 && !nZdCHjsswxfLKJQfsllhHsELxZeeb, P_0, ReInput.unscaledTime);
						lqfjGSXAvzAJGHCwmgobtiLlwIOb.goPVdjcmstPEpKawpAdyeMqIchUgb(0.3f, P_0 && !nZdCHjsswxfLKJQfsllhHsELxZeeb, P_0);
					}

					public virtual void SKuAmELyrhUJXsgpBGAraYqkbTdK()
					{
						ktCWeSsbsZnlUsKEqjngmKfTyoo = false;
						nZdCHjsswxfLKJQfsllhHsELxZeeb = false;
						GrnRDovhgvTKbgZBLRLUoMXIOvPm.mPMEuOaUvhWxVmFbbcecXWvRAHUhb();
						lqfjGSXAvzAJGHCwmgobtiLlwIOb.ZpBcKIjSkVFHiaMAGGUjFwpFFekTc();
					}
				}

				public class EECZUwpNIuOlvgFCwajscpOSVMjt : LJZSfYvABOkaaoihPztTvKgXIFSS
				{
					public float OaJAhzcoGJnCnADOwfjnAvUCCxSsA;

					public float sNerAniQfKnNnGfVPMEMUydTTDgp;

					public void WYuYyLdyePgAGZFzpWTgfYrbodmT(float P_0)
					{
						if (sNerAniQfKnNnGfVPMEMUydTTDgp != OaJAhzcoGJnCnADOwfjnAvUCCxSsA)
						{
							sNerAniQfKnNnGfVPMEMUydTTDgp = OaJAhzcoGJnCnADOwfjnAvUCCxSsA;
						}
						if (OaJAhzcoGJnCnADOwfjnAvUCCxSsA != P_0)
						{
							OaJAhzcoGJnCnADOwfjnAvUCCxSsA = ((P_0 > 0.001f) ? P_0 : 0f);
						}
						FlYIGJTkwnBrVOWbpebjhGRkVHof(OaJAhzcoGJnCnADOwfjnAvUCCxSsA > 0f);
					}

					public virtual void IzSIindYkCsFykprdWmlotmwqCYR()
					{
						SKuAmELyrhUJXsgpBGAraYqkbTdK();
						OaJAhzcoGJnCnADOwfjnAvUCCxSsA = 0f;
						sNerAniQfKnNnGfVPMEMUydTTDgp = 0f;
					}
				}

				public byfXzbQLdsTDWLBOsXXyXCXECEOl(UpdateLoopSetting P_0, bool P_1)
					: base(P_0)
				{
					for (int i = 0; i < AroiAYoWZtrmxQOdYERyfjPNaurb; i++)
					{
						if (P_1)
						{
							WzSZdGhqRByxigDFUiRLuGcqAiMCA[i] = new EECZUwpNIuOlvgFCwajscpOSVMjt();
						}
						else
						{
							WzSZdGhqRByxigDFUiRLuGcqAiMCA[i] = new LJZSfYvABOkaaoihPztTvKgXIFSS();
						}
					}
					GeSbjRBQSrftRFdtRlUbOnoUUrYb = WzSZdGhqRByxigDFUiRLuGcqAiMCA[0];
				}

				public void PzUTpmptTkHhWbgbWuAtAZmjTjgx(float P_0)
				{
					for (int i = 0; i < WzSZdGhqRByxigDFUiRLuGcqAiMCA.Length; i++)
					{
						((LJZSfYvABOkaaoihPztTvKgXIFSS)WzSZdGhqRByxigDFUiRLuGcqAiMCA[i]).lqfjGSXAvzAJGHCwmgobtiLlwIOb.QfbmLDZczHlCFirKoMAsuPyYoTOV(P_0);
					}
				}

				public void wJimiVLlFSKDGIVuAkGxcWzVsVWu()
				{
					for (int i = 0; i < WzSZdGhqRByxigDFUiRLuGcqAiMCA.Length; i++)
					{
						((LJZSfYvABOkaaoihPztTvKgXIFSS)WzSZdGhqRByxigDFUiRLuGcqAiMCA[i]).lqfjGSXAvzAJGHCwmgobtiLlwIOb.QfbmLDZczHlCFirKoMAsuPyYoTOV(0.3f);
					}
				}
			}

			internal readonly bool mlSnRsjhtggaCipjEPsBshCydthH;

			internal readonly HardwareButtonInfo pLzpMJtRPtqfibaeYqmLotHIfhsr;

			public bool valuePrev
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return false;
					}
					return ((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).nZdCHjsswxfLKJQfsllhHsELxZeeb;
				}
			}

			public bool value
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return false;
					}
					return ((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).ktCWeSsbsZnlUsKEqjngmKfTyoo;
				}
			}

			public float pressure
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0f;
					}
					if (!mlSnRsjhtggaCipjEPsBshCydthH)
					{
						if (!((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).ktCWeSsbsZnlUsKEqjngmKfTyoo)
						{
							return 0f;
						}
						return 1f;
					}
					return ((byfXzbQLdsTDWLBOsXXyXCXECEOl.EECZUwpNIuOlvgFCwajscpOSVMjt)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).OaJAhzcoGJnCnADOwfjnAvUCCxSsA;
				}
			}

			public float pressurePrev
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0f;
					}
					if (!mlSnRsjhtggaCipjEPsBshCydthH)
					{
						if (!((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).nZdCHjsswxfLKJQfsllhHsELxZeeb)
						{
							return 0f;
						}
						return 1f;
					}
					return ((byfXzbQLdsTDWLBOsXXyXCXECEOl.EECZUwpNIuOlvgFCwajscpOSVMjt)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).sNerAniQfKnNnGfVPMEMUydTTDgp;
				}
			}

			public bool isPressureSensitive
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return false;
					}
					return mlSnRsjhtggaCipjEPsBshCydthH;
				}
			}

			public bool justPressed
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return false;
					}
					if (!((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).nZdCHjsswxfLKJQfsllhHsELxZeeb && ((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).ktCWeSsbsZnlUsKEqjngmKfTyoo)
					{
						return true;
					}
					return false;
				}
			}

			public bool justReleased
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return false;
					}
					if (((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).nZdCHjsswxfLKJQfsllhHsELxZeeb && !((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).ktCWeSsbsZnlUsKEqjngmKfTyoo)
					{
						return true;
					}
					return false;
				}
			}

			public bool justChangedState
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return false;
					}
					if (((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).nZdCHjsswxfLKJQfsllhHsELxZeeb != ((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).ktCWeSsbsZnlUsKEqjngmKfTyoo)
					{
						return true;
					}
					return false;
				}
			}

			public bool doublePressedAndHeld
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return false;
					}
					return ((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).lqfjGSXAvzAJGHCwmgobtiLlwIOb.josGReLUJYeyedmIycvZhuUKpgLHb;
				}
			}

			public bool justDoublePressed
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return false;
					}
					if (!justPressed)
					{
						return false;
					}
					return ((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).lqfjGSXAvzAJGHCwmgobtiLlwIOb.josGReLUJYeyedmIycvZhuUKpgLHb;
				}
			}

			public double timePressed
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0.0;
					}
					return ((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).GrnRDovhgvTKbgZBLRLUoMXIOvPm.mHufGrBEeQAkIAlrsGBdvRucMlHcA;
				}
			}

			public double timeUnpressed
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0.0;
					}
					return ((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).GrnRDovhgvTKbgZBLRLUoMXIOvPm.YrgsIQQRTOkRBhjkPDlhJGnhPMmk;
				}
			}

			public double lastTimePressed
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0.0;
					}
					return ((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).GrnRDovhgvTKbgZBLRLUoMXIOvPm.SFSCnzaaBbzKyLOSZlUphtPMfcejb;
				}
			}

			public double lastTimeUnpressed
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0.0;
					}
					return ((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).GrnRDovhgvTKbgZBLRLUoMXIOvPm.EWDzbBMrZaiDTUdVVSrgpwZgACbk;
				}
			}

			public double lastTimeStateChanged
			{
				get
				{
					if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
					{
						ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
						return 0.0;
					}
					return ((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).GrnRDovhgvTKbgZBLRLUoMXIOvPm.SXWgJvhTlJkwGqzOlCnCiUzAtJHT;
				}
			}

			internal ButtonStateFlags HFKTZXBlKKISWBiTraqUmmfEreLL
			{
				get
				{
					byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS lJZSfYvABOkaaoihPztTvKgXIFSS = (byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb;
					ButtonStateFlags buttonStateFlags = ButtonStateFlags.Off;
					if (lJZSfYvABOkaaoihPztTvKgXIFSS.ktCWeSsbsZnlUsKEqjngmKfTyoo)
					{
						buttonStateFlags |= ButtonStateFlags.On;
						if (!lJZSfYvABOkaaoihPztTvKgXIFSS.nZdCHjsswxfLKJQfsllhHsELxZeeb)
						{
							buttonStateFlags |= ButtonStateFlags.Down;
						}
					}
					else if (lJZSfYvABOkaaoihPztTvKgXIFSS.nZdCHjsswxfLKJQfsllhHsELxZeeb)
					{
						buttonStateFlags |= ButtonStateFlags.Up;
					}
					return buttonStateFlags;
				}
			}

			internal Button(Controller P_0, int P_1, string P_2, HardwareButtonInfo P_3)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				pLzpMJtRPtqfibaeYqmLotHIfhsr = P_3;
				xvLftKFVDqAMSDhMgQaeDMHwhggUb = new byfXzbQLdsTDWLBOsXXyXCXECEOl(ReInput.configVars.updateLoop, false);
			}

			internal Button(Controller P_0, int P_1, string P_2, bool P_3, HardwareButtonInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				pLzpMJtRPtqfibaeYqmLotHIfhsr = P_4;
				mlSnRsjhtggaCipjEPsBshCydthH = P_3;
				xvLftKFVDqAMSDhMgQaeDMHwhggUb = new byfXzbQLdsTDWLBOsXXyXCXECEOl(ReInput.configVars.updateLoop, P_3);
			}

			public bool DoublePressedAndHeld(float speed)
			{
				if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
				{
					ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
					return false;
				}
				if (speed <= 0f)
				{
					return ((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).lqfjGSXAvzAJGHCwmgobtiLlwIOb.josGReLUJYeyedmIycvZhuUKpgLHb;
				}
				return ((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).GrnRDovhgvTKbgZBLRLUoMXIOvPm.jeyaRDJlnatKcrACBLNEtwrUGZSuA(speed);
			}

			public bool JustDoublePressed(float speed)
			{
				if (ReInput._id != ajhoJpBzljiuQdLiJzdMWAyrcMji)
				{
					ReInput.CheckInitialized(ajhoJpBzljiuQdLiJzdMWAyrcMji);
					return false;
				}
				if (!justPressed)
				{
					return false;
				}
				if (speed <= 0f)
				{
					return ((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).lqfjGSXAvzAJGHCwmgobtiLlwIOb.josGReLUJYeyedmIycvZhuUKpgLHb;
				}
				return ((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).GrnRDovhgvTKbgZBLRLUoMXIOvPm.jeyaRDJlnatKcrACBLNEtwrUGZSuA(speed);
			}

			internal void wwiDNeLfkwfiCXIMYvGOWvdxgzbD(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
			{
				if (xvLftKFVDqAMSDhMgQaeDMHwhggUb != null && xvLftKFVDqAMSDhMgQaeDMHwhggUb.hNritsHzSPJnxRQfJUyBtadbitPA != (int)P_0)
				{
					xvLftKFVDqAMSDhMgQaeDMHwhggUb.zwotyQMjNNPWaauZkuHfgqpPPonF = P_0;
				}
				if (mlSnRsjhtggaCipjEPsBshCydthH)
				{
					((byfXzbQLdsTDWLBOsXXyXCXECEOl.EECZUwpNIuOlvgFCwajscpOSVMjt)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).WYuYyLdyePgAGZFzpWTgfYrbodmT(P_2.buttonPressureValues[P_1]);
				}
				else
				{
					((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).FlYIGJTkwnBrVOWbpebjhGRkVHof(P_2.buttonValues[P_1]);
				}
			}

			internal void IpkDrYjFLirhpFtdxAwlLEHwuDCLA(UpdateLoopType P_0)
			{
				if (xvLftKFVDqAMSDhMgQaeDMHwhggUb != null && xvLftKFVDqAMSDhMgQaeDMHwhggUb.hNritsHzSPJnxRQfJUyBtadbitPA != (int)P_0)
				{
					xvLftKFVDqAMSDhMgQaeDMHwhggUb.zwotyQMjNNPWaauZkuHfgqpPPonF = P_0;
				}
				if (mlSnRsjhtggaCipjEPsBshCydthH)
				{
					((byfXzbQLdsTDWLBOsXXyXCXECEOl.EECZUwpNIuOlvgFCwajscpOSVMjt)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).WYuYyLdyePgAGZFzpWTgfYrbodmT(0f);
				}
				else
				{
					((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)xvLftKFVDqAMSDhMgQaeDMHwhggUb.GeSbjRBQSrftRFdtRlUbOnoUUrYb).FlYIGJTkwnBrVOWbpebjhGRkVHof(false);
				}
			}

			internal void AejiKTjXzAmTBFgLPmSEewEdstyOB()
			{
				for (int i = 0; i < xvLftKFVDqAMSDhMgQaeDMHwhggUb.keqpceJolbIIOdNjuoTmgFRisHMdc.Count; i++)
				{
					bichVacXImjrhzYncfMpWQizAgrJ.iYbOuMJIrJhTiAjymugzklCVLYwm iYbOuMJIrJhTiAjymugzklCVLYwm = xvLftKFVDqAMSDhMgQaeDMHwhggUb.keqpceJolbIIOdNjuoTmgFRisHMdc[i];
					if (iYbOuMJIrJhTiAjymugzklCVLYwm != null)
					{
						if (mlSnRsjhtggaCipjEPsBshCydthH)
						{
							((byfXzbQLdsTDWLBOsXXyXCXECEOl.EECZUwpNIuOlvgFCwajscpOSVMjt)iYbOuMJIrJhTiAjymugzklCVLYwm).WYuYyLdyePgAGZFzpWTgfYrbodmT(0f);
						}
						else
						{
							((byfXzbQLdsTDWLBOsXXyXCXECEOl.LJZSfYvABOkaaoihPztTvKgXIFSS)iYbOuMJIrJhTiAjymugzklCVLYwm).FlYIGJTkwnBrVOWbpebjhGRkVHof(false);
						}
					}
				}
			}
		}

		public abstract class CompoundElement
		{
			private class qEQqrdNAnRsUTejRCDgjCHOfHIMI
			{
				public readonly Element akxAfrkrNUBbrgbPFdIeMdKLURWfc;

				public readonly int TGBBiAHpBjEmgzUsuwOQhbkqqBZn;

				public qEQqrdNAnRsUTejRCDgjCHOfHIMI(Element P_0, int P_1)
				{
					akxAfrkrNUBbrgbPFdIeMdKLURWfc = P_0;
					TGBBiAHpBjEmgzUsuwOQhbkqqBZn = P_1;
				}
			}

			private int cSdPiQKWLMKugdyZUbidfveOUlUr;

			private string qtqSkRAcSZkbaSjowFsOcyAsiiQi;

			private CompoundControllerElementType gkXTcohYDAjgOlCpgwbNaCxoOJpj;

			private int nZPQbWVCdlwjIMJeYCrmDytjLdrG;

			private qEQqrdNAnRsUTejRCDgjCHOfHIMI[] FTrIvqREeLmvYChsuAdTewwhlWOt;

			private Controller JUjWZIBftGcVzQkvvctGyJRfnSoF;

			internal readonly int xEfMliUJyXMkdDMQJvCGMNzkwOpb;

			public int id
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return -1;
					}
					return cSdPiQKWLMKugdyZUbidfveOUlUr;
				}
			}

			public string name
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return string.Empty;
					}
					return qtqSkRAcSZkbaSjowFsOcyAsiiQi;
				}
			}

			public CompoundControllerElementType type
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return CompoundControllerElementType.Axis2D;
					}
					return gkXTcohYDAjgOlCpgwbNaCxoOJpj;
				}
			}

			public bool hasElements
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return false;
					}
					return nZPQbWVCdlwjIMJeYCrmDytjLdrG > 0;
				}
			}

			public int elementCount
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return 0;
					}
					return nZPQbWVCdlwjIMJeYCrmDytjLdrG;
				}
			}

			public abstract int elementCapacity { get; }

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = JUjWZIBftGcVzQkvvctGyJRfnSoF.GetElementIdentifierById(cSdPiQKWLMKugdyZUbidfveOUlUr);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			internal CompoundElement(Controller P_0, int P_1, string P_2, CompoundControllerElementType P_3)
			{
				JUjWZIBftGcVzQkvvctGyJRfnSoF = P_0;
				cSdPiQKWLMKugdyZUbidfveOUlUr = P_1;
				qtqSkRAcSZkbaSjowFsOcyAsiiQi = P_2;
				gkXTcohYDAjgOlCpgwbNaCxoOJpj = P_3;
				FTrIvqREeLmvYChsuAdTewwhlWOt = new qEQqrdNAnRsUTejRCDgjCHOfHIMI[elementCapacity];
				xEfMliUJyXMkdDMQJvCGMNzkwOpb = ReInput.id;
			}

			internal Element lwiwQPaHiVqTJnkadJhIICFaWYRs(int P_0)
			{
				if (P_0 < 0 || P_0 >= FTrIvqREeLmvYChsuAdTewwhlWOt.Length)
				{
					return null;
				}
				if (FTrIvqREeLmvYChsuAdTewwhlWOt[P_0] == null)
				{
					return null;
				}
				return FTrIvqREeLmvYChsuAdTewwhlWOt[P_0].akxAfrkrNUBbrgbPFdIeMdKLURWfc;
			}

			internal _0001 lwiwQPaHiVqTJnkadJhIICFaWYRs<_0001>(int P_0) where _0001 : Element
			{
				if (P_0 < 0 || P_0 >= FTrIvqREeLmvYChsuAdTewwhlWOt.Length)
				{
					return null;
				}
				if (FTrIvqREeLmvYChsuAdTewwhlWOt[P_0] == null)
				{
					return null;
				}
				return FTrIvqREeLmvYChsuAdTewwhlWOt[P_0].akxAfrkrNUBbrgbPFdIeMdKLURWfc as _0001;
			}

			internal _0001 ocJklRQwgqECsfoosgwKBqcIIiZg<_0001>(int P_0, out int P_1) where _0001 : Element
			{
				P_1 = -1;
				if (P_0 < 0 || P_0 >= FTrIvqREeLmvYChsuAdTewwhlWOt.Length)
				{
					return null;
				}
				if (FTrIvqREeLmvYChsuAdTewwhlWOt[P_0] == null)
				{
					return null;
				}
				P_1 = FTrIvqREeLmvYChsuAdTewwhlWOt[P_0].TGBBiAHpBjEmgzUsuwOQhbkqqBZn;
				return FTrIvqREeLmvYChsuAdTewwhlWOt[P_0].akxAfrkrNUBbrgbPFdIeMdKLURWfc as _0001;
			}

			internal bool UjmItkvLWFDWthALbSAHTHLqkILgA(Element P_0, int P_1)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (nZPQbWVCdlwjIMJeYCrmDytjLdrG >= elementCapacity)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				if (P_0.isMemberElement)
				{
					Logger.LogWarning("Cannot add element! The element you are trying to add is already a member of another compound element.");
					return false;
				}
				if (eOIJimaDhYmHudXnNfPcEMFDDdQbA(P_0) >= 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the element you are trying to add.");
					return false;
				}
				int num = IclmIdBHHeuoumcOmefDWgYLRoau();
				if (num < 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				return xGMoBXfPZeXDuNBgcoBcacrJAUGV(P_0, P_1, num);
			}

			internal bool ALVtdEPAZrmeEIenCwpnNxBnCuaR(Element P_0)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (nZPQbWVCdlwjIMJeYCrmDytjLdrG == 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element has no elements.");
					return false;
				}
				int num = eOIJimaDhYmHudXnNfPcEMFDDdQbA(P_0);
				if (num < 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element does not contain the element you are trying to remove.");
					return false;
				}
				return PJUQflqzKPNBnsCDooyXwItipvIb(num);
			}

			internal void fuupeFjLXPyZByAbgOsYfqmsnLLi()
			{
				for (int i = 0; i < FTrIvqREeLmvYChsuAdTewwhlWOt.Length; i++)
				{
					PJUQflqzKPNBnsCDooyXwItipvIb(i);
				}
				nZPQbWVCdlwjIMJeYCrmDytjLdrG = 0;
			}

			private int eOIJimaDhYmHudXnNfPcEMFDDdQbA(Element P_0)
			{
				if (P_0 == null)
				{
					return -1;
				}
				for (int i = 0; i < FTrIvqREeLmvYChsuAdTewwhlWOt.Length; i++)
				{
					if (FTrIvqREeLmvYChsuAdTewwhlWOt[i] != null && FTrIvqREeLmvYChsuAdTewwhlWOt[i].akxAfrkrNUBbrgbPFdIeMdKLURWfc == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private bool xGMoBXfPZeXDuNBgcoBcacrJAUGV(Element P_0, int P_1, int P_2)
			{
				if (P_2 < 0 || P_2 >= FTrIvqREeLmvYChsuAdTewwhlWOt.Length)
				{
					return false;
				}
				if (FTrIvqREeLmvYChsuAdTewwhlWOt[P_2] != null)
				{
					return false;
				}
				FTrIvqREeLmvYChsuAdTewwhlWOt[P_2] = new qEQqrdNAnRsUTejRCDgjCHOfHIMI(P_0, P_1);
				P_0.yzvfXmiATqYMtWwYDTozscIzRpxp(this);
				nZPQbWVCdlwjIMJeYCrmDytjLdrG++;
				return true;
			}

			private bool PJUQflqzKPNBnsCDooyXwItipvIb(int P_0)
			{
				if (P_0 < 0 || P_0 >= FTrIvqREeLmvYChsuAdTewwhlWOt.Length)
				{
					return false;
				}
				if (FTrIvqREeLmvYChsuAdTewwhlWOt[P_0] == null)
				{
					return false;
				}
				if (FTrIvqREeLmvYChsuAdTewwhlWOt[P_0].akxAfrkrNUBbrgbPFdIeMdKLURWfc != null)
				{
					FTrIvqREeLmvYChsuAdTewwhlWOt[P_0].akxAfrkrNUBbrgbPFdIeMdKLURWfc.pUQVMMkCwCfylfIhSaYsvruKnwfA(this);
				}
				FTrIvqREeLmvYChsuAdTewwhlWOt[P_0] = null;
				nZPQbWVCdlwjIMJeYCrmDytjLdrG--;
				return true;
			}

			private int IclmIdBHHeuoumcOmefDWgYLRoau()
			{
				for (int i = 0; i < FTrIvqREeLmvYChsuAdTewwhlWOt.Length; i++)
				{
					if (FTrIvqREeLmvYChsuAdTewwhlWOt[i] == null)
					{
						return i;
					}
				}
				return -1;
			}
		}

		public sealed class Axis2D : CompoundElement
		{
			private const int fgNgIODpZWMKuDhQChdOERufMMffC = 2;

			private CalibrationMap uFZDZMizYNErzgcYDCjnQTknTBSTA;

			int CompoundElement.elementCapacity => 2;

			public Axis xAxis
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return null;
					}
					return lwiwQPaHiVqTJnkadJhIICFaWYRs<Axis>(0);
				}
			}

			public Axis yAxis
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return null;
					}
					return lwiwQPaHiVqTJnkadJhIICFaWYRs<Axis>(1);
				}
			}

			public Vector2 value
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return Vector2.zero;
					}
					return ooeQpglTSbStdTNZFBdowhxpafOK();
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return Vector2.zero;
					}
					return TqOpzOTnMjOTbgrUDtnBNaLpIroeA();
				}
			}

			public Vector2 valueRaw
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRaw : 0f, (yAxis != null) ? yAxis.valueRaw : 0f);
				}
			}

			public Vector2 valueRawPrev
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRawPrev : 0f, (yAxis != null) ? yAxis.valueRawPrev : 0f);
				}
			}

			internal Axis2D(Controller P_0, int P_1, string P_2, Axis P_3, Axis P_4, int P_5, int P_6, CalibrationMap P_7)
				: base(P_0, P_1, P_2, CompoundControllerElementType.Axis2D)
			{
				UjmItkvLWFDWthALbSAHTHLqkILgA(P_3, P_5);
				UjmItkvLWFDWthALbSAHTHLqkILgA(P_4, P_6);
				uFZDZMizYNErzgcYDCjnQTknTBSTA = P_7;
			}

			internal void pkjqqBFPgSKScLobcXPLJUtWaEGy()
			{
				Vector2 vector = value;
				if (xAxis != null)
				{
					xAxis.CaQzOHlSRLxyOCaFzJQBXrUydOLY(vector.x);
				}
				if (yAxis != null)
				{
					yAxis.CaQzOHlSRLxyOCaFzJQBXrUydOLY(vector.y);
				}
			}

			private Vector2 ooeQpglTSbStdTNZFBdowhxpafOK()
			{
				if (uFZDZMizYNErzgcYDCjnQTknTBSTA == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = ocJklRQwgqECsfoosgwKBqcIIiZg<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = ocJklRQwgqECsfoosgwKBqcIIiZg<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRaw ?? 0f;
				float valueRawY = axis2?.valueRaw ?? 0f;
				return uFZDZMizYNErzgcYDCjnQTknTBSTA.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}

			private Vector2 TqOpzOTnMjOTbgrUDtnBNaLpIroeA()
			{
				if (uFZDZMizYNErzgcYDCjnQTknTBSTA == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = ocJklRQwgqECsfoosgwKBqcIIiZg<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = ocJklRQwgqECsfoosgwKBqcIIiZg<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRawPrev ?? 0f;
				float valueRawY = axis2?.valueRawPrev ?? 0f;
				return uFZDZMizYNErzgcYDCjnQTknTBSTA.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}
		}

		public sealed class Hat : CompoundElement
		{
			private const int QrSazBaJcLGNXHgLCaTpEaeRmwxK = 8;

			private const int FqTcXqqaWruNtsNitKpxbeWVvBIo = 0;

			private const int oMsDRTIBowEmDVmNWqGZgIQDVNXb = 1;

			private const int EWegtEJDpIVytuZxxibxMawynAWOA = 2;

			private const int wjipSlVRQFDPpMLGwdBteBYKmOfw = 3;

			private const int VRASHFFGTjMrATBIzweMScWsSRSE = 4;

			private const int ROQEBqZKKlSYNximqprtcAGpDUjr = 5;

			private const int KvALgGVeHJzPpANfYGMOhHLCZOKc = 6;

			private const int oWVKlQUcauJCeIbXERARinqCBWyc = 7;

			private readonly int HPtATDjsQMviNTSpavIyquUmyMYB;

			private readonly Button[] tMHvkSxccqfLppJSMbtiOMNrjRcW;

			private readonly ReadOnlyCollection<Button> UTqqqukzrxsUYAcwknWzijiyhVQm;

			private readonly int[] WGxCGbgmWFtiFRCRBgcapGNEgvof;

			private bool QvJEwyfWKhCUwLgtengAQnhKsKs;

			int CompoundElement.elementCapacity => 8;

			public bool force4Way
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return false;
					}
					return QvJEwyfWKhCUwLgtengAQnhKsKs;
				}
				set
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
					}
					else
					{
						QvJEwyfWKhCUwLgtengAQnhKsKs = value;
					}
				}
			}

			public int directionCount
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return 0;
					}
					return HPtATDjsQMviNTSpavIyquUmyMYB;
				}
			}

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return UTqqqukzrxsUYAcwknWzijiyhVQm;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return null;
					}
					return lwiwQPaHiVqTJnkadJhIICFaWYRs<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return null;
					}
					return lwiwQPaHiVqTJnkadJhIICFaWYRs<Button>(2);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return null;
					}
					return lwiwQPaHiVqTJnkadJhIICFaWYRs<Button>(4);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return null;
					}
					return lwiwQPaHiVqTJnkadJhIICFaWYRs<Button>(6);
				}
			}

			public Button buttonUpRight
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return null;
					}
					return lwiwQPaHiVqTJnkadJhIICFaWYRs<Button>(1);
				}
			}

			public Button buttonDownRight
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return null;
					}
					return lwiwQPaHiVqTJnkadJhIICFaWYRs<Button>(3);
				}
			}

			public Button buttonDownLeft
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return null;
					}
					return lwiwQPaHiVqTJnkadJhIICFaWYRs<Button>(5);
				}
			}

			public Button buttonUpLeft
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return null;
					}
					return lwiwQPaHiVqTJnkadJhIICFaWYRs<Button>(7);
				}
			}

			internal Hat(Controller P_0, int P_1, string P_2, Button[] P_3, int[] P_4)
				: base(P_0, P_1, P_2, CompoundControllerElementType.Hat)
			{
				int num = ((P_3 != null) ? P_3.Length : 0);
				if (num != ((P_4 != null) ? P_4.Length : 0))
				{
					throw new ArgumentException("buttons.Length must equal buttonIndices.Length!");
				}
				if (num != 0 && num != 4 && num != 8)
				{
					throw new ArgumentException("buttons.Length must be 0, 4, or 8! Length: " + num);
				}
				for (int i = 0; i < num; i++)
				{
					UjmItkvLWFDWthALbSAHTHLqkILgA(P_3[i], P_4[i]);
				}
				tMHvkSxccqfLppJSMbtiOMNrjRcW = P_3;
				WGxCGbgmWFtiFRCRBgcapGNEgvof = P_4;
				HPtATDjsQMviNTSpavIyquUmyMYB = num;
				UTqqqukzrxsUYAcwknWzijiyhVQm = new ReadOnlyCollection<Button>(P_3);
			}

			internal void FcSXuOndlWHpztANWEJhDzbfTjTp(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (HPtATDjsQMviNTSpavIyquUmyMYB == 0)
				{
					return;
				}
				if (HPtATDjsQMviNTSpavIyquUmyMYB == 8 && (QvJEwyfWKhCUwLgtengAQnhKsKs || ReInput.configVars.force4WayHats))
				{
					DvMXrpEbNIdJygOcXuLahzIqpOdO(tMHvkSxccqfLppJSMbtiOMNrjRcW[0], WGxCGbgmWFtiFRCRBgcapGNEgvof[0], WGxCGbgmWFtiFRCRBgcapGNEgvof[7], WGxCGbgmWFtiFRCRBgcapGNEgvof[1], P_0, P_1);
					DvMXrpEbNIdJygOcXuLahzIqpOdO(tMHvkSxccqfLppJSMbtiOMNrjRcW[2], WGxCGbgmWFtiFRCRBgcapGNEgvof[2], WGxCGbgmWFtiFRCRBgcapGNEgvof[1], WGxCGbgmWFtiFRCRBgcapGNEgvof[3], P_0, P_1);
					DvMXrpEbNIdJygOcXuLahzIqpOdO(tMHvkSxccqfLppJSMbtiOMNrjRcW[4], WGxCGbgmWFtiFRCRBgcapGNEgvof[4], WGxCGbgmWFtiFRCRBgcapGNEgvof[5], WGxCGbgmWFtiFRCRBgcapGNEgvof[3], P_0, P_1);
					DvMXrpEbNIdJygOcXuLahzIqpOdO(tMHvkSxccqfLppJSMbtiOMNrjRcW[6], WGxCGbgmWFtiFRCRBgcapGNEgvof[6], WGxCGbgmWFtiFRCRBgcapGNEgvof[5], WGxCGbgmWFtiFRCRBgcapGNEgvof[7], P_0, P_1);
					oNBjDdXYRsmHfMMfDaZTYEhqYHIN(tMHvkSxccqfLppJSMbtiOMNrjRcW[1], WGxCGbgmWFtiFRCRBgcapGNEgvof[1], P_0, P_1);
					oNBjDdXYRsmHfMMfDaZTYEhqYHIN(tMHvkSxccqfLppJSMbtiOMNrjRcW[3], WGxCGbgmWFtiFRCRBgcapGNEgvof[3], P_0, P_1);
					oNBjDdXYRsmHfMMfDaZTYEhqYHIN(tMHvkSxccqfLppJSMbtiOMNrjRcW[5], WGxCGbgmWFtiFRCRBgcapGNEgvof[5], P_0, P_1);
					oNBjDdXYRsmHfMMfDaZTYEhqYHIN(tMHvkSxccqfLppJSMbtiOMNrjRcW[7], WGxCGbgmWFtiFRCRBgcapGNEgvof[7], P_0, P_1);
					return;
				}
				for (int i = 0; i < tMHvkSxccqfLppJSMbtiOMNrjRcW.Length; i++)
				{
					if (tMHvkSxccqfLppJSMbtiOMNrjRcW[i] != null)
					{
						tMHvkSxccqfLppJSMbtiOMNrjRcW[i].wwiDNeLfkwfiCXIMYvGOWvdxgzbD(P_0, WGxCGbgmWFtiFRCRBgcapGNEgvof[i], P_1);
					}
				}
			}

			private void DvMXrpEbNIdJygOcXuLahzIqpOdO(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
			{
				if (P_0 == null || P_1 < 0 || P_1 >= P_5.buttonCount)
				{
					return;
				}
				if (!P_0.isPressureSensitive)
				{
					if (P_2 >= 0 && P_2 < P_5.buttonCount)
					{
						ref bool reference = ref P_5.buttonValues[P_1];
						reference |= P_5.buttonValues[P_2];
					}
					if (P_3 >= 0 && P_3 < P_5.buttonCount)
					{
						ref bool reference2 = ref P_5.buttonValues[P_1];
						reference2 |= P_5.buttonValues[P_3];
					}
				}
				else
				{
					P_5.buttonPressureValues[P_1] = MathTools.MaxMagnitude(P_5.buttonPressureValues[P_1], MathTools.MaxMagnitude((P_2 >= 0 && P_2 < P_5.buttonCount) ? P_5.buttonPressureValues[P_2] : 0f, (P_3 >= 0 && P_3 < P_5.buttonCount) ? P_5.buttonPressureValues[P_3] : 0f));
				}
				P_0.wwiDNeLfkwfiCXIMYvGOWvdxgzbD(P_4, P_1, P_5);
			}

			private void oNBjDdXYRsmHfMMfDaZTYEhqYHIN(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
			{
				if (P_0 != null && P_1 >= 0 && P_1 < P_3.buttonCount)
				{
					if (!P_0.isPressureSensitive)
					{
						P_3.buttonValues[P_1] = false;
					}
					else
					{
						P_3.buttonPressureValues[P_1] = 0f;
					}
					P_0.wwiDNeLfkwfiCXIMYvGOWvdxgzbD(P_2, P_1, P_3);
				}
			}
		}

		public sealed class DirectionalPad : CompoundElement
		{
			private const int vCzRuugVlWKbUAuKFFfKqKoENKOy = 4;

			private const int NUoRKcOnngYzVIdZBpfJHENFraQq = 0;

			private const int OsmcHYGpsStppkVNxtQCNOsquVjkA = 1;

			private const int qXAglpICFtSggrGBIcSciYeJCHceb = 2;

			private const int DbXkhwgqQtopbkCQZNRSJmLBjWAb = 3;

			private readonly int heoeVVKTAKXsFEbzzZGwudJEvAbS;

			private readonly Button[] VeRCiKCEQmrDMPOorMcsscsGcwFnA;

			private readonly ReadOnlyCollection<Button> tsWPbzbcSesrfgzepCkXFxfeqrru;

			private readonly int[] MyIkAmCcoaZLAWiViCrFkENPNcEFA;

			int CompoundElement.elementCapacity => 4;

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return tsWPbzbcSesrfgzepCkXFxfeqrru;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return null;
					}
					return lwiwQPaHiVqTJnkadJhIICFaWYRs<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return null;
					}
					return lwiwQPaHiVqTJnkadJhIICFaWYRs<Button>(1);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return null;
					}
					return lwiwQPaHiVqTJnkadJhIICFaWYRs<Button>(2);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != xEfMliUJyXMkdDMQJvCGMNzkwOpb)
					{
						ReInput.CheckInitialized(xEfMliUJyXMkdDMQJvCGMNzkwOpb);
						return null;
					}
					return lwiwQPaHiVqTJnkadJhIICFaWYRs<Button>(3);
				}
			}

			internal DirectionalPad(Controller P_0, int P_1, string P_2, Button[] P_3, int[] P_4)
				: base(P_0, P_1, P_2, CompoundControllerElementType.DPad)
			{
				int num = ((P_3 != null) ? P_3.Length : 0);
				if (num != ((P_4 != null) ? P_4.Length : 0))
				{
					throw new ArgumentException("buttons.Length must equal buttonIndices.Length!");
				}
				if (num != 0 && num != 4)
				{
					throw new ArgumentException("buttons.Length must be 0 or 4! Length: " + num);
				}
				for (int i = 0; i < num; i++)
				{
					UjmItkvLWFDWthALbSAHTHLqkILgA(P_3[i], P_4[i]);
				}
				VeRCiKCEQmrDMPOorMcsscsGcwFnA = P_3;
				MyIkAmCcoaZLAWiViCrFkENPNcEFA = P_4;
				heoeVVKTAKXsFEbzzZGwudJEvAbS = num;
				tsWPbzbcSesrfgzepCkXFxfeqrru = new ReadOnlyCollection<Button>(P_3);
			}

			internal void dHkBwjvAUaFVUFLrpHTfjtnrnknu(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (heoeVVKTAKXsFEbzzZGwudJEvAbS == 0)
				{
					return;
				}
				for (int i = 0; i < VeRCiKCEQmrDMPOorMcsscsGcwFnA.Length; i++)
				{
					if (VeRCiKCEQmrDMPOorMcsscsGcwFnA[i] != null)
					{
						VeRCiKCEQmrDMPOorMcsscsGcwFnA[i].wwiDNeLfkwfiCXIMYvGOWvdxgzbD(P_0, MyIkAmCcoaZLAWiViCrFkENPNcEFA[i], P_1);
					}
				}
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			private Controller uUswrLkhHsPzaeIyZyRcJbzPpjOL;

			private IControllerExtensionSource quNHftdvylKLyVoXwlogWhmFqLqm;

			internal readonly int _reInputId;

			internal bool isJoystickConnected
			{
				get
				{
					if (uUswrLkhHsPzaeIyZyRcJbzPpjOL == null)
					{
						return false;
					}
					return uUswrLkhHsPzaeIyZyRcJbzPpjOL._isConnected;
				}
			}

			internal bool enabled
			{
				get
				{
					if (uUswrLkhHsPzaeIyZyRcJbzPpjOL == null)
					{
						return false;
					}
					return uUswrLkhHsPzaeIyZyRcJbzPpjOL.enabled;
				}
			}

			public Controller controller => uUswrLkhHsPzaeIyZyRcJbzPpjOL;

			internal Extension(IControllerExtensionSource P_0)
			{
				_reInputId = ReInput.id;
				EOIOBNBnmlMeWCubOuRUFgLfibqd(P_0);
			}

			internal Extension(Extension P_0)
				: this(P_0.quNHftdvylKLyVoXwlogWhmFqLqm)
			{
				uUswrLkhHsPzaeIyZyRcJbzPpjOL = P_0.uUswrLkhHsPzaeIyZyRcJbzPpjOL;
			}

			internal T GetController<T>() where T : Controller
			{
				if (uUswrLkhHsPzaeIyZyRcJbzPpjOL == null)
				{
					return null;
				}
				return uUswrLkhHsPzaeIyZyRcJbzPpjOL as T;
			}

			internal void SetController(Controller controller)
			{
				uUswrLkhHsPzaeIyZyRcJbzPpjOL = controller;
			}

			[CustomObfuscation(rename = false)]
			internal IControllerExtensionSource GetSource()
			{
				return quNHftdvylKLyVoXwlogWhmFqLqm;
			}

			internal void SetSource(Extension extension)
			{
				if (extension == null)
				{
					EOIOBNBnmlMeWCubOuRUFgLfibqd(null);
				}
				else
				{
					EOIOBNBnmlMeWCubOuRUFgLfibqd(extension.quNHftdvylKLyVoXwlogWhmFqLqm);
				}
			}

			private void EOIOBNBnmlMeWCubOuRUFgLfibqd(IControllerExtensionSource P_0)
			{
				quNHftdvylKLyVoXwlogWhmFqLqm = P_0;
				SourceUpdated(quNHftdvylKLyVoXwlogWhmFqLqm);
			}

			internal virtual void Clear()
			{
			}

			internal abstract void SourceUpdated(IControllerExtensionSource source);

			internal abstract void UpdateData(UpdateLoopType updateLoop);

			internal abstract Extension Clone();
		}

		[Serializable]
		private sealed class BDBvIFJsYRWbJVVAvHFOGRjJcqAb
		{
			public static readonly BDBvIFJsYRWbJVVAvHFOGRjJcqAb _003C_003E9 = new BDBvIFJsYRWbJVVAvHFOGRjJcqAb();

			public static Func<Controller, Guid, bool> _003C_003E9__166_0;

			public static Func<Controller, Type, bool> _003C_003E9__169_0;

			internal bool CKbKzkmxpVQuKXBtkZvGEUrGYYQj(Controller P_0, Guid P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}

			internal bool frSxCaeCKIvBmRqzXyNhVNUZCPohA(Controller P_0, Type P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}
		}

		private sealed class QdsHtRGjfklkysyUVXABaCEjqosWA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int FvNOwQhPXgDkGQclIRMMSjsHPtgj;

			private ControllerPollingInfo FePRNDnIgdbtXdgkeovaSrLCRetpA;

			private int FReskBnlpvceIkUlfQHGtGremLEQ;

			public Controller FrslpACpuNGHIUlqPjBXKIjzgNWIA;

			private int ngNBtJLkbujcBOIWwmmoUiYNBSoy;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return FePRNDnIgdbtXdgkeovaSrLCRetpA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return FePRNDnIgdbtXdgkeovaSrLCRetpA;
				}
			}

			[DebuggerHidden]
			public QdsHtRGjfklkysyUVXABaCEjqosWA(int P_0)
			{
				FvNOwQhPXgDkGQclIRMMSjsHPtgj = P_0;
				FReskBnlpvceIkUlfQHGtGremLEQ = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int fvNOwQhPXgDkGQclIRMMSjsHPtgj = FvNOwQhPXgDkGQclIRMMSjsHPtgj;
				Controller frslpACpuNGHIUlqPjBXKIjzgNWIA = FrslpACpuNGHIUlqPjBXKIjzgNWIA;
				if (fvNOwQhPXgDkGQclIRMMSjsHPtgj != 0)
				{
					if (fvNOwQhPXgDkGQclIRMMSjsHPtgj != 1)
					{
						return false;
					}
					FvNOwQhPXgDkGQclIRMMSjsHPtgj = -1;
					goto IL_00a0;
				}
				FvNOwQhPXgDkGQclIRMMSjsHPtgj = -1;
				if (ReInput._id != frslpACpuNGHIUlqPjBXKIjzgNWIA.AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(frslpACpuNGHIUlqPjBXKIjzgNWIA.AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return false;
				}
				frslpACpuNGHIUlqPjBXKIjzgNWIA.UpdatePollingFrameTracking();
				ngNBtJLkbujcBOIWwmmoUiYNBSoy = 0;
				goto IL_00b0;
				IL_00b0:
				if (ngNBtJLkbujcBOIWwmmoUiYNBSoy < frslpACpuNGHIUlqPjBXKIjzgNWIA._buttonCount)
				{
					if (frslpACpuNGHIUlqPjBXKIjzgNWIA.jFKsqGbWdgDxxqtQrdNxXCvxFDOd(ngNBtJLkbujcBOIWwmmoUiYNBSoy, out var num))
					{
						FePRNDnIgdbtXdgkeovaSrLCRetpA = new ControllerPollingInfo(true, -1, frslpACpuNGHIUlqPjBXKIjzgNWIA.id, frslpACpuNGHIUlqPjBXKIjzgNWIA._name, frslpACpuNGHIUlqPjBXKIjzgNWIA._type, ControllerElementType.Button, ngNBtJLkbujcBOIWwmmoUiYNBSoy, Pole.Positive, frslpACpuNGHIUlqPjBXKIjzgNWIA.UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetElementIdentifierName(num), num, KeyCode.None);
						FvNOwQhPXgDkGQclIRMMSjsHPtgj = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				ngNBtJLkbujcBOIWwmmoUiYNBSoy++;
				goto IL_00b0;
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
				QdsHtRGjfklkysyUVXABaCEjqosWA qdsHtRGjfklkysyUVXABaCEjqosWA;
				if (FvNOwQhPXgDkGQclIRMMSjsHPtgj == -2 && FReskBnlpvceIkUlfQHGtGremLEQ == Environment.CurrentManagedThreadId)
				{
					FvNOwQhPXgDkGQclIRMMSjsHPtgj = 0;
					qdsHtRGjfklkysyUVXABaCEjqosWA = this;
				}
				else
				{
					qdsHtRGjfklkysyUVXABaCEjqosWA = new QdsHtRGjfklkysyUVXABaCEjqosWA(0);
					qdsHtRGjfklkysyUVXABaCEjqosWA.FrslpACpuNGHIUlqPjBXKIjzgNWIA = FrslpACpuNGHIUlqPjBXKIjzgNWIA;
				}
				return qdsHtRGjfklkysyUVXABaCEjqosWA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class GqBleinsNZJSVXDhTbacqDQFpePg : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int PTdwuVpawbFwXCaPRVFPQIrTCTjgb;

			private ControllerPollingInfo WMsFYHIvWUxYqOrCUuhlyddLmkxA;

			private int OLHKOptGgFDqsfubdpdKsalshcvW;

			public Controller OAKDzeHKkdCkkFGTzLUEsPtYirfYA;

			private int wxLFWshDNrNEAHrLkNpCsabrJXtYA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return WMsFYHIvWUxYqOrCUuhlyddLmkxA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WMsFYHIvWUxYqOrCUuhlyddLmkxA;
				}
			}

			[DebuggerHidden]
			public GqBleinsNZJSVXDhTbacqDQFpePg(int P_0)
			{
				PTdwuVpawbFwXCaPRVFPQIrTCTjgb = P_0;
				OLHKOptGgFDqsfubdpdKsalshcvW = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int pTdwuVpawbFwXCaPRVFPQIrTCTjgb = PTdwuVpawbFwXCaPRVFPQIrTCTjgb;
				Controller oAKDzeHKkdCkkFGTzLUEsPtYirfYA = OAKDzeHKkdCkkFGTzLUEsPtYirfYA;
				if (pTdwuVpawbFwXCaPRVFPQIrTCTjgb != 0)
				{
					if (pTdwuVpawbFwXCaPRVFPQIrTCTjgb != 1)
					{
						return false;
					}
					PTdwuVpawbFwXCaPRVFPQIrTCTjgb = -1;
					goto IL_00a0;
				}
				PTdwuVpawbFwXCaPRVFPQIrTCTjgb = -1;
				if (ReInput._id != oAKDzeHKkdCkkFGTzLUEsPtYirfYA.AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(oAKDzeHKkdCkkFGTzLUEsPtYirfYA.AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return false;
				}
				oAKDzeHKkdCkkFGTzLUEsPtYirfYA.UpdatePollingFrameTracking();
				wxLFWshDNrNEAHrLkNpCsabrJXtYA = 0;
				goto IL_00b0;
				IL_00b0:
				if (wxLFWshDNrNEAHrLkNpCsabrJXtYA < oAKDzeHKkdCkkFGTzLUEsPtYirfYA._buttonCount)
				{
					if (oAKDzeHKkdCkkFGTzLUEsPtYirfYA.NhvknmfrBYrHsWhRECgdbnkWrInh(wxLFWshDNrNEAHrLkNpCsabrJXtYA, out var num))
					{
						WMsFYHIvWUxYqOrCUuhlyddLmkxA = new ControllerPollingInfo(true, -1, oAKDzeHKkdCkkFGTzLUEsPtYirfYA.id, oAKDzeHKkdCkkFGTzLUEsPtYirfYA._name, oAKDzeHKkdCkkFGTzLUEsPtYirfYA._type, ControllerElementType.Button, wxLFWshDNrNEAHrLkNpCsabrJXtYA, Pole.Positive, oAKDzeHKkdCkkFGTzLUEsPtYirfYA.UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetElementIdentifierName(num), num, KeyCode.None);
						PTdwuVpawbFwXCaPRVFPQIrTCTjgb = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				wxLFWshDNrNEAHrLkNpCsabrJXtYA++;
				goto IL_00b0;
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
				GqBleinsNZJSVXDhTbacqDQFpePg gqBleinsNZJSVXDhTbacqDQFpePg;
				if (PTdwuVpawbFwXCaPRVFPQIrTCTjgb == -2 && OLHKOptGgFDqsfubdpdKsalshcvW == Environment.CurrentManagedThreadId)
				{
					PTdwuVpawbFwXCaPRVFPQIrTCTjgb = 0;
					gqBleinsNZJSVXDhTbacqDQFpePg = this;
				}
				else
				{
					gqBleinsNZJSVXDhTbacqDQFpePg = new GqBleinsNZJSVXDhTbacqDQFpePg(0);
					gqBleinsNZJSVXDhTbacqDQFpePg.OAKDzeHKkdCkkFGTzLUEsPtYirfYA = OAKDzeHKkdCkkFGTzLUEsPtYirfYA;
				}
				return gqBleinsNZJSVXDhTbacqDQFpePg;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		public readonly int id;

		protected string _tag;

		protected string _name;

		private readonly DeviceLocalizationInfo oajsVrNDplezTsJzchKTAtteLdTX;

		protected string _hardwareName;

		protected readonly ControllerType _type;

		internal readonly Guid lcQyDEaPLwhlbiUKrOtQaptBTwRjc;

		protected string _hardwareIdentifier;

		protected bool _isConnected;

		private Extension qgtoMgfylAiOqBOPBnGYYnlrdRy;

		private bool EcnteuXKUIMtAGwFzwEklmLpdHLH;

		private ControllerIdentifier wLJhrfzlupYyDpUbgnBpqhXsQjDx;

		internal int AxoBCjPHwoqMddBzfEGmrNYYGhxf;

		protected readonly int _buttonCount;

		protected readonly Button[] buttons;

		protected readonly ReadOnlyCollection<Button> buttons_readOnly;

		private readonly IList<Element> ugGtgBqJFZkYnZNnDjdBBGAOEHgg;

		private readonly ReadOnlyCollection<Element> yPVEBxCnxzszNPFJQRuroyLpmqwLA;

		private readonly IList<CompoundElement> BEEuaALwzpfBAQBWnivrAGyYzlap;

		private readonly ReadOnlyCollection<CompoundElement> tljBtRuujSAYTPMPcCOrIjhmFItt;

		[CustomObfuscation(rename = false)]
		internal readonly InputSource inputSource;

		internal readonly ControllerDataUpdater ucqtfsuOTseRsybfPGjEFawPmfNK;

		internal readonly HardwareControllerMap_Game UzVdrXbKoYScsNhLYrSoTUeynXDBb;

		internal uint GeiOfNRnWNcHtBrYaaUFiXYntovY;

		private uint fVewfcNUnxuLHIObVhrujAgMwAWWA;

		private uint TDzHcrLdecsmkOdcoBtUAVxKiHln;

		private ITryGetLocalizedName MJtEEWueGtvMylAtdGIDFrLYhQgtA;

		private readonly LocalizedString iYdnQChPatuxaQytJgGkAzSpJlai;

		private readonly pdzTLPmqpuLIOpAzKgpvnBvFeTFbA YgHftLFmMOmJGnOkvnWkmhbCSVxFb;

		private Action<bool> SKBRKCvyVJAhrrcPGnaHKgSqKIsu;

		private IControllerTemplate[] PyIuAVAlVuJFWfsaHFcqFjWUwxBV;

		private ReadOnlyCollection<IControllerTemplate> bLyjPuSIrssHcQDZOAzCdRakeMrv;

		private static Func<Controller, Guid, bool> EMKawNCZyzAAdioUFHfsRTkuPOKk;

		private static Func<Controller, Type, bool> wzBEqDGpxgLihbYTbKuRQqGNVqjDc;

		internal bool NnDKyZKMhsJHVzKusjENJZSSRvEA => fVewfcNUnxuLHIObVhrujAgMwAWWA == ReInput.previousFrame;

		public bool enabled
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return false;
				}
				return EcnteuXKUIMtAGwFzwEklmLpdHLH;
			}
			set
			{
				SXQqxQnpROfgArPviygPWFsoFYZS(value);
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return string.Empty;
				}
				if (!LocalizationManager.isEnabled)
				{
					return _name;
				}
				if (SUbfQRFbPzwGnnrqYMULqgcOxeVP != null && SUbfQRFbPzwGnnrqYMULqgcOxeVP.TryGetLocalizedName(out var value))
				{
					return value;
				}
				if (_type == ControllerType.Joystick && lcQyDEaPLwhlbiUKrOtQaptBTwRjc == Consts.joystickGuid_unknownController)
				{
					return _name;
				}
				if (oajsVrNDplezTsJzchKTAtteLdTX == null || oajsVrNDplezTsJzchKTAtteLdTX.parentKeys == null)
				{
					return _name;
				}
				LocalizationManager.GetAndUpdateLocalizedString(iYdnQChPatuxaQytJgGkAzSpJlai, (oajsVrNDplezTsJzchKTAtteLdTX != null) ? oajsVrNDplezTsJzchKTAtteLdTX.parentKeys : null, dXDhgciBpvPiLRoZXBpiBCxofOAPA.VAyqCRnPdBxTMsjTXxMMdwTFWTiJ(_type), _name, out value);
				return value;
			}
			internal set
			{
				_name = text;
			}
		}

		public string tag
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return string.Empty;
				}
				return _tag;
			}
			set
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				}
				else
				{
					_tag = value;
				}
			}
		}

		public string hardwareName
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return string.Empty;
				}
				return _hardwareName;
			}
		}

		public ControllerType type
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return ControllerType.Keyboard;
				}
				return _type;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return Guid.Empty;
				}
				return lcQyDEaPLwhlbiUKrOtQaptBTwRjc;
			}
		}

		public abstract Guid deviceInstanceGuid { get; }

		public ControllerIdentifier identifier => wLJhrfzlupYyDpUbgnBpqhXsQjDx;

		public bool isConnected
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return false;
				}
				return _isConnected;
			}
			internal set
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				}
				else if (!flag)
				{
					Disconnected();
				}
				else
				{
					Connected();
				}
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return string.Empty;
				}
				return _hardwareIdentifier;
			}
		}

		public string mapTypeString => _type.ToString() + "Map";

		public int elementCount
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return 0;
				}
				return ugGtgBqJFZkYnZNnDjdBBGAOEHgg.Count;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return 0;
				}
				return _buttonCount;
			}
		}

		public IList<Element> Elements
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return EmptyObjects<Element>.EmptyReadOnlyIListT;
				}
				return yPVEBxCnxzszNPFJQRuroyLpmqwLA;
			}
		}

		public IList<CompoundElement> CompoundElements
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return EmptyObjects<CompoundElement>.EmptyReadOnlyIListT;
				}
				return tljBtRuujSAYTPMPcCOrIjhmFItt;
			}
		}

		public IList<Button> Buttons
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return EmptyObjects<Button>.EmptyReadOnlyIListT;
				}
				return buttons_readOnly;
			}
		}

		public Extension extension
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return null;
				}
				return qgtoMgfylAiOqBOPBnGYYnlrdRy;
			}
		}

		public IList<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return UzVdrXbKoYScsNhLYrSoTUeynXDBb.elementIdentifiers_readOnly;
			}
		}

		public IList<ControllerElementIdentifier> ButtonElementIdentifiers
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return UzVdrXbKoYScsNhLYrSoTUeynXDBb.buttonElementIdentifiers_readOnly;
			}
		}

		internal ITryGetLocalizedName SUbfQRFbPzwGnnrqYMULqgcOxeVP
		{
			get
			{
				return MJtEEWueGtvMylAtdGIDFrLYhQgtA;
			}
			set
			{
				MJtEEWueGtvMylAtdGIDFrLYhQgtA = mJtEEWueGtvMylAtdGIDFrLYhQgtA;
			}
		}

		public IList<IControllerTemplate> Templates
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return EmptyObjects<IControllerTemplate>.EmptyReadOnlyIListT;
				}
				return bLyjPuSIrssHcQDZOAzCdRakeMrv;
			}
		}

		public int templateCount
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return 0;
				}
				return PyIuAVAlVuJFWfsaHFcqFjWUwxBV.Length;
			}
		}

		internal static Func<Controller, Guid, bool> FWQwaXBZWWFHHutFHVaGHadmFoHn => BDBvIFJsYRWbJVVAvHFOGRjJcqAb._003C_003E9.CKbKzkmxpVQuKXBtkZvGEUrGYYQj;

		internal static Func<Controller, Type, bool> qcOmCOCGqkBlTdkUaWfuGplhrPeP => BDBvIFJsYRWbJVVAvHFOGRjJcqAb._003C_003E9.frSxCaeCKIvBmRqzXyNhVNUZCPohA;

		internal event Action<bool> IIIhsSunUeAPwsOElcOCmgPSHxiU
		{
			add
			{
				SKBRKCvyVJAhrrcPGnaHKgSqKIsu = (Action<bool>)Delegate.Combine(SKBRKCvyVJAhrrcPGnaHKgSqKIsu, b);
			}
			remove
			{
				SKBRKCvyVJAhrrcPGnaHKgSqKIsu = (Action<bool>)Delegate.Remove(SKBRKCvyVJAhrrcPGnaHKgSqKIsu, value2);
			}
		}

		internal Controller(int P_0, InputSource P_1, string P_2, string P_3, string P_4, ControllerType P_5, Guid P_6, int P_7, bool[] P_8, HardwareButtonInfo[] P_9, HardwareControllerMap_Game P_10, Extension P_11, ControllerDataUpdater P_12)
		{
			id = P_0;
			inputSource = P_1;
			_type = P_5;
			lcQyDEaPLwhlbiUKrOtQaptBTwRjc = P_6;
			_buttonCount = P_7;
			_name = P_2;
			_hardwareName = P_3;
			_hardwareIdentifier = P_4;
			ucqtfsuOTseRsybfPGjEFawPmfNK = P_12;
			UzVdrXbKoYScsNhLYrSoTUeynXDBb = P_10;
			oajsVrNDplezTsJzchKTAtteLdTX = P_10.deviceLocalizationInfo;
			EcnteuXKUIMtAGwFzwEklmLpdHLH = true;
			AxoBCjPHwoqMddBzfEGmrNYYGhxf = ReInput.id;
			iYdnQChPatuxaQytJgGkAzSpJlai = new LocalizedString();
			YgHftLFmMOmJGnOkvnWkmhbCSVxFb = new pdzTLPmqpuLIOpAzKgpvnBvFeTFbA(delegate
			{
				_ = name;
			});
			CHBwbEmfRmAQRKzmfrZoSkBSuoot(P_11);
			ugGtgBqJFZkYnZNnDjdBBGAOEHgg = new List<Element>(P_7);
			yPVEBxCnxzszNPFJQRuroyLpmqwLA = new ReadOnlyCollection<Element>(ugGtgBqJFZkYnZNnDjdBBGAOEHgg);
			BEEuaALwzpfBAQBWnivrAGyYzlap = new List<CompoundElement>();
			tljBtRuujSAYTPMPcCOrIjhmFItt = new ReadOnlyCollection<CompoundElement>(BEEuaALwzpfBAQBWnivrAGyYzlap);
			buttons = new Button[P_7];
			if (P_8 == null || P_8.Length < P_7)
			{
				for (int num = 0; num < P_7; num++)
				{
					buttons[num] = new Button(this, P_10.buttonElementIdentifierIds[num], "Button " + num, false, (P_9 != null) ? P_9[num] : new HardwareButtonInfo());
					DUFHWeGImWnELqobFlRGBIbQIJIp(buttons[num]);
				}
			}
			else
			{
				for (int num2 = 0; num2 < P_7; num2++)
				{
					buttons[num2] = new Button(this, P_10.buttonElementIdentifierIds[num2], "Button " + num2, P_8[num2], (P_9 != null) ? P_9[num2] : new HardwareButtonInfo());
					DUFHWeGImWnELqobFlRGBIbQIJIp(buttons[num2]);
				}
			}
			buttons_readOnly = new ReadOnlyCollection<Button>(buttons);
			PyIuAVAlVuJFWfsaHFcqFjWUwxBV = EmptyObjects<IControllerTemplate>.array;
			bLyjPuSIrssHcQDZOAzCdRakeMrv = new ReadOnlyCollection<IControllerTemplate>(PyIuAVAlVuJFWfsaHFcqFjWUwxBV);
			if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
			{
				((goyuORzVCSsvhefHsgPEBCMfboVoA)YgHftLFmMOmJGnOkvnWkmhbCSVxFb).Localize();
			}
			Connected();
		}

		internal virtual void yAFKgfmSqcdzYvwLywJEIeWPEynEA()
		{
			wLJhrfzlupYyDpUbgnBpqhXsQjDx = new ControllerIdentifier(this);
		}

		public virtual Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return null;
			}
			if (UzVdrXbKoYScsNhLYrSoTUeynXDBb == null)
			{
				return null;
			}
			int buttonIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0)
			{
				return null;
			}
			return buttons[buttonIndex];
		}

		public virtual CompoundElement GetCompoundElementById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return null;
			}
			int count = BEEuaALwzpfBAQBWnivrAGyYzlap.Count;
			for (int i = 0; i < count; i++)
			{
				if (BEEuaALwzpfBAQBWnivrAGyYzlap[i] != null && BEEuaALwzpfBAQBWnivrAGyYzlap[i].id == elementIdentifierId)
				{
					return BEEuaALwzpfBAQBWnivrAGyYzlap[i];
				}
			}
			return null;
		}

		[Obsolete("This method is deprecated. Use GetCompoundElementById instead.", false)]
		public virtual CompoundElement GetCompundElementById(int elementIdentifierId)
		{
			return GetCompoundElementById(elementIdentifierId);
		}

		public int GetButtonIndexById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return -1;
			}
			return UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementIdentifierId);
		}

		public ControllerElementIdentifier GetElementIdentifierById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return null;
			}
			return UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetElementIdentifierById(elementIdentifierId);
		}

		public virtual bool GetButton(int index)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].value;
		}

		public virtual bool GetButtonDown(int index)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].justPressed;
		}

		public virtual bool GetButtonUp(int index)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].justReleased;
		}

		public virtual bool GetButtonChanged(int index)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].value != buttons[index].valuePrev;
		}

		public virtual bool GetButtonPrev(int index)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].valuePrev;
		}

		public virtual bool GetButtonDoublePressHold(int index)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			return GetButtonDoublePressHold(index, 0f);
		}

		public virtual bool GetButtonDoublePressHold(int index, float speed)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].DoublePressedAndHeld(speed);
		}

		public virtual bool GetButtonDoublePressDown(int index)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			return GetButtonDoublePressDown(index, 0f);
		}

		public virtual bool GetButtonDoublePressDown(int index, float speed)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].JustDoublePressed(speed);
		}

		public virtual double GetButtonTimePressed(int index)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].timePressed;
		}

		public virtual double GetButtonTimeUnpressed(int index)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].timeUnpressed;
		}

		public virtual double GetButtonLastTimePressed(int index)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].lastTimePressed;
		}

		public virtual double GetButtonLastTimeUnpressed(int index)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].lastTimeUnpressed;
		}

		public virtual bool GetAnyButton()
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].value)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonDown()
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].justPressed)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonUp()
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].justReleased)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonPrev()
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].valuePrev)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonChanged()
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].justChangedState)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetButtonById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			int buttonIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].value;
		}

		public virtual bool GetButtonDownById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			int buttonIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justPressed;
		}

		public virtual bool GetButtonUpById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			int buttonIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justReleased;
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			int buttonIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].DoublePressedAndHeld(speed);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			int buttonIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].JustDoublePressed(speed);
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			int buttonIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressHold(buttonIndex, 0f);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			int buttonIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressDown(buttonIndex, 0f);
		}

		public virtual bool GetButtonPrevById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			int buttonIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].valuePrev;
		}

		public virtual double GetButtonTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			int buttonIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timePressed;
		}

		public virtual double GetButtonTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			int buttonIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timeUnpressed;
		}

		public virtual double GetButtonLastTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			int buttonIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].lastTimePressed;
		}

		public virtual double GetButtonLastTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			int buttonIndex = UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].lastTimeUnpressed;
		}

		public virtual ControllerPollingInfo PollForFirstElement()
		{
			return PollForFirstButton();
		}

		public virtual ControllerPollingInfo PollForFirstElementDown()
		{
			return PollForFirstButtonDown();
		}

		public virtual ControllerPollingInfo PollForFirstButton()
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (jFKsqGbWdgDxxqtQrdNxXCvxFDOd(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
		}

		public virtual ControllerPollingInfo PollForFirstButtonDown()
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (NhvknmfrBYrHsWhRECgdbnkWrInh(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, UzVdrXbKoYScsNhLYrSoTUeynXDBb.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return PollForAllButtons();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return PollForAllButtonsDown();
		}

		[IteratorStateMachine(typeof(QdsHtRGjfklkysyUVXABaCEjqosWA))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			return new QdsHtRGjfklkysyUVXABaCEjqosWA(-2)
			{
				FrslpACpuNGHIUlqPjBXKIjzgNWIA = this
			};
		}

		[IteratorStateMachine(typeof(GqBleinsNZJSVXDhTbacqDQFpePg))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			return new GqBleinsNZJSVXDhTbacqDQFpePg(-2)
			{
				OAKDzeHKkdCkkFGTzLUEsPtYirfYA = this
			};
		}

		private bool jFKsqGbWdgDxxqtQrdNxXCvxFDOd(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].value || buttons[P_0].pLzpMJtRPtqfibaeYqmLotHIfhsr._excludeFromPolling)
			{
				return false;
			}
			P_1 = UzVdrXbKoYScsNhLYrSoTUeynXDBb.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		private bool NhvknmfrBYrHsWhRECgdbnkWrInh(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].justPressed || buttons[P_0].pLzpMJtRPtqfibaeYqmLotHIfhsr._excludeFromPolling)
			{
				return false;
			}
			P_1 = UzVdrXbKoYScsNhLYrSoTUeynXDBb.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		protected void UpdatePollingFrameTracking()
		{
			if (TDzHcrLdecsmkOdcoBtUAVxKiHln == ReInput.currentFrame)
			{
				return;
			}
			fVewfcNUnxuLHIObVhrujAgMwAWWA = TDzHcrLdecsmkOdcoBtUAVxKiHln;
			TDzHcrLdecsmkOdcoBtUAVxKiHln = ReInput.currentFrame;
			if (!NnDKyZKMhsJHVzKusjENJZSSRvEA)
			{
				if (GeiOfNRnWNcHtBrYaaUFiXYntovY == uint.MaxValue)
				{
					GeiOfNRnWNcHtBrYaaUFiXYntovY = 0u;
				}
				else
				{
					GeiOfNRnWNcHtBrYaaUFiXYntovY++;
				}
			}
		}

		public virtual double GetLastTimeActive()
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public virtual double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			return GetLastTimeAnyButtonPressed();
		}

		public virtual double GetLastTimeAnyElementChanged()
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			return GetLastTimeAnyElementChanged(useRawValues: false);
		}

		public virtual double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			return GetLastTimeAnyButtonChanged();
		}

		public double GetLastTimeAnyButtonPressed()
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			if (buttons == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < buttons.Length; i++)
			{
				double lastTimePressed = buttons[i].lastTimePressed;
				if (lastTimePressed > num)
				{
					num = lastTimePressed;
				}
			}
			return num;
		}

		public double GetLastTimeAnyButtonChanged()
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0.0;
			}
			if (buttons == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < buttons.Length; i++)
			{
				double lastTimeStateChanged = buttons[i].lastTimeStateChanged;
				if (lastTimeStateChanged > num)
				{
					num = lastTimeStateChanged;
				}
			}
			return num;
		}

		public T GetExtension<T>() where T : class
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return null;
			}
			return qgtoMgfylAiOqBOPBnGYYnlrdRy as T;
		}

		public IControllerTemplate GetTemplate(Guid typeGuid)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return null;
			}
			for (int i = 0; i < PyIuAVAlVuJFWfsaHFcqFjWUwxBV.Length; i++)
			{
				if (PyIuAVAlVuJFWfsaHFcqFjWUwxBV[i].typeGuid == typeGuid)
				{
					return PyIuAVAlVuJFWfsaHFcqFjWUwxBV[i];
				}
			}
			return null;
		}

		public IControllerTemplate GetTemplate(Type type)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return null;
			}
			for (int i = 0; i < PyIuAVAlVuJFWfsaHFcqFjWUwxBV.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(PyIuAVAlVuJFWfsaHFcqFjWUwxBV[i].GetType(), type))
				{
					return PyIuAVAlVuJFWfsaHFcqFjWUwxBV[i];
				}
			}
			return null;
		}

		public T GetTemplate<T>() where T : class
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return null;
			}
			for (int i = 0; i < PyIuAVAlVuJFWfsaHFcqFjWUwxBV.Length; i++)
			{
				if (PyIuAVAlVuJFWfsaHFcqFjWUwxBV[i] as T != null)
				{
					return PyIuAVAlVuJFWfsaHFcqFjWUwxBV[i] as T;
				}
			}
			return null;
		}

		public bool ImplementsTemplate(Guid typeGuid)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			for (int i = 0; i < PyIuAVAlVuJFWfsaHFcqFjWUwxBV.Length; i++)
			{
				if (PyIuAVAlVuJFWfsaHFcqFjWUwxBV[i].typeGuid == typeGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool ImplementsTemplate(Type type)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			for (int i = 0; i < PyIuAVAlVuJFWfsaHFcqFjWUwxBV.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(PyIuAVAlVuJFWfsaHFcqFjWUwxBV[i].GetType(), type))
				{
					return true;
				}
			}
			return false;
		}

		public bool ImplementsTemplate<T>() where T : class
		{
			return ImplementsTemplate(typeof(T));
		}

		internal void MamxKOLmQtiBsJFosXLuYlRIOZOF(IControllerTemplate[] P_0)
		{
			if (P_0 != null)
			{
				PyIuAVAlVuJFWfsaHFcqFjWUwxBV = P_0;
				bLyjPuSIrssHcQDZOAzCdRakeMrv = new ReadOnlyCollection<IControllerTemplate>(PyIuAVAlVuJFWfsaHFcqFjWUwxBV);
			}
		}

		internal virtual void TphwDqkAytPBkZdmXYWPheGltdaf(UpdateLoopType P_0)
		{
			bool num = ReInput.IsInputAllowed(_type);
			int num2 = _buttonCount;
			if (num)
			{
				for (int i = 0; i < num2; i++)
				{
					if (buttons[i].lJNgqPgIDbUDuVOMXsHMUyMNJOis <= 0)
					{
						buttons[i].wwiDNeLfkwfiCXIMYvGOWvdxgzbD(P_0, i, ucqtfsuOTseRsybfPGjEFawPmfNK);
					}
				}
			}
			else
			{
				for (int j = 0; j < num2; j++)
				{
					if (buttons[j].lJNgqPgIDbUDuVOMXsHMUyMNJOis <= 0)
					{
						buttons[j].IpkDrYjFLirhpFtdxAwlLEHwuDCLA(P_0);
					}
				}
			}
			if (qgtoMgfylAiOqBOPBnGYYnlrdRy != null)
			{
				qgtoMgfylAiOqBOPBnGYYnlrdRy.UpdateData(P_0);
			}
		}

		internal virtual ButtonStateFlags ldCWXEWHrzPWFgYlYEOyXHwAqhRe(int P_0)
		{
			if (P_0 < 0 || P_0 >= _buttonCount)
			{
				return ButtonStateFlags.Off;
			}
			return buttons[P_0].HFKTZXBlKKISWBiTraqUmmfEreLL;
		}

		internal void CHBwbEmfRmAQRKzmfrZoSkBSuoot(Extension P_0)
		{
			if (P_0 == null)
			{
				qgtoMgfylAiOqBOPBnGYYnlrdRy = null;
				return;
			}
			if (qgtoMgfylAiOqBOPBnGYYnlrdRy != null)
			{
				UONPvyrtOdqCGVHocvgcaZuNlxxv(P_0);
				return;
			}
			P_0.SetController(this);
			qgtoMgfylAiOqBOPBnGYYnlrdRy = P_0.Clone();
		}

		internal void UONPvyrtOdqCGVHocvgcaZuNlxxv(Extension P_0)
		{
			if (qgtoMgfylAiOqBOPBnGYYnlrdRy != null)
			{
				qgtoMgfylAiOqBOPBnGYYnlrdRy.SetSource(P_0);
				qgtoMgfylAiOqBOPBnGYYnlrdRy.SetController(this);
				P_0?.SetController(this);
			}
			else
			{
				CHBwbEmfRmAQRKzmfrZoSkBSuoot(P_0);
			}
		}

		internal virtual void xbzMqJvVogJAviEMRocpklZVZryW()
		{
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i] != null)
				{
					buttons[i].Reset();
				}
			}
			if (ucqtfsuOTseRsybfPGjEFawPmfNK != null)
			{
				ucqtfsuOTseRsybfPGjEFawPmfNK.ClearData();
			}
			if (qgtoMgfylAiOqBOPBnGYYnlrdRy != null)
			{
				qgtoMgfylAiOqBOPBnGYYnlrdRy.Clear();
			}
		}

		internal virtual bool SXQqxQnpROfgArPviygPWFsoFYZS(bool P_0)
		{
			if (EcnteuXKUIMtAGwFzwEklmLpdHLH == P_0)
			{
				return false;
			}
			if (!P_0)
			{
				xbzMqJvVogJAviEMRocpklZVZryW();
			}
			EcnteuXKUIMtAGwFzwEklmLpdHLH = P_0;
			if (SKBRKCvyVJAhrrcPGnaHKgSqKIsu != null)
			{
				SKBRKCvyVJAhrrcPGnaHKgSqKIsu(P_0);
			}
			return true;
		}

		internal virtual void FeQHluiWzbggXquWcpGEIuFssFTaA(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			P_0.controllerId = id;
			IList<ActionElementMap> buttonMaps = P_0.ButtonMaps;
			for (int i = 0; i < buttonMaps.Count; i++)
			{
				XxMvlVzqErvGSYjarMeZYpjHprtT(P_0, buttonMaps[i]);
			}
			for (int num = buttonMaps.Count - 1; num >= 0; num--)
			{
				if (buttonMaps[num].elementIndex < 0)
				{
					P_0.DeleteElementMap(buttonMaps[num].xYazCGhLJSNpewHjYMCgVGmvJCJk);
				}
			}
		}

		internal virtual void XxMvlVzqErvGSYjarMeZYpjHprtT(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null && P_1._elementType == ControllerElementType.Button)
			{
				P_1.STLLClZycMGvQuJnbJckqZikooUE(P_0);
			}
		}

		internal bool RptbHJCcIuiLyZQvQNPcvZWySinAA(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
		{
			P_3 = false;
			P_2 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int coqXdmPghseNBOvihWdoifSiCjzh = P_0.coqXdmPghseNBOvihWdoifSiCjzh;
			if (coqXdmPghseNBOvihWdoifSiCjzh < 0 || coqXdmPghseNBOvihWdoifSiCjzh >= _buttonCount)
			{
				return false;
			}
			P_3 = buttons[coqXdmPghseNBOvihWdoifSiCjzh].mlSnRsjhtggaCipjEPsBshCydthH;
			float num = ((!P_3) ? (buttons[coqXdmPghseNBOvihWdoifSiCjzh].value ? 1f : 0f) : buttons[coqXdmPghseNBOvihWdoifSiCjzh].pressure);
			if (num > 0f)
			{
				if (P_0._elementType == ControllerElementType.Button)
				{
					if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
				else if (P_0._elementType == ControllerElementType.Axis)
				{
					if (P_0._axisRange == AxisRange.Full)
					{
						if (P_0._invert)
						{
							num *= -1f;
						}
					}
					else if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
			}
			P_2 = num;
			return true;
		}

		internal bool dFXwCyhgmrZdmeNmqvZMxkEALXTQ(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
		{
			P_3 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			float num = (P_2 ? 1f : 0f);
			if (num > 0f)
			{
				if (P_0._elementType == ControllerElementType.Button)
				{
					if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
				else if (P_0._elementType == ControllerElementType.Axis)
				{
					if (P_0._axisRange == AxisRange.Full)
					{
						if (P_0._invert)
						{
							num *= -1f;
						}
					}
					else if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
			}
			P_3 = num;
			return true;
		}

		internal void DUFHWeGImWnELqobFlRGBIbQIJIp(Element P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(ugGtgBqJFZkYnZNnDjdBBGAOEHgg, P_0);
			}
		}

		internal void oKeADPnZuMDqfiFDYZDUysjhzVIH(CompoundElement P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(BEEuaALwzpfBAQBWnivrAGyYzlap, P_0);
			}
		}

		internal virtual Guid yHuKNzCmrAjKVQYEcWGtDkKRHjSk()
		{
			return Guid.Empty;
		}

		internal virtual void lpGHWOOJdXrtWGgitYfjarUifXfB(bool P_0)
		{
			if (!P_0 && !ReInput.IsInputAllowed(_type) && qgtoMgfylAiOqBOPBnGYYnlrdRy != null)
			{
				qgtoMgfylAiOqBOPBnGYYnlrdRy.Clear();
			}
		}

		protected virtual void Connected()
		{
			_isConnected = true;
		}

		protected virtual void Disconnected()
		{
			_isConnected = false;
			if (ucqtfsuOTseRsybfPGjEFawPmfNK != null)
			{
				ucqtfsuOTseRsybfPGjEFawPmfNK.ClearData();
			}
		}

		[CompilerGenerated]
		private void XvFAdOpAmsfmbnmYTsCqWzOEjtOL()
		{
			_ = name;
		}
	}
}
