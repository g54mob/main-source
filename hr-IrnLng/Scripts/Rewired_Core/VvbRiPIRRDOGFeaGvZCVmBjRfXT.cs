using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal sealed class VvbRiPIRRDOGFeaGvZCVmBjRfXT
{
	internal enum CIxBuEeASTjOkXSChHkrvFPOWiW
	{
		bWiGnINBAKCCgAJdFTQNTISvBlW = 0,
		RlAwwSywSSQUidrZslnSooSUgRN = 1,
		WQNdYJSAYYvmjxKbWASGxbAiIpYg = 2
	}

	private class cimxWPlcTmDbPdabCBgkxkeJymej
	{
		internal class MDYFuPsMttZDragBTBSBtxjkuUR
		{
			internal double iSTcZADSCajtNEvvhcRkCNUdVBej;

			private InputBehavior zQlPNEwerdNvUCLXMXvSaeCQpU;

			internal float ySNDGRIpQlQpKFddPugZhVCLbny;

			internal float PRMsxTDJDJDnoyZGKHOwQjACxxl;

			internal AxisCoordinateMode LijFMsBQaBMeyaBSULosMeSZIZpX;

			internal AxisCoordinateMode OxabChjxtippqCQXpiTAvxJpMMzW;

			internal ButtonStateFlags ZkOKkhijFfaSwJkzgQHVpjkjwyi;

			internal ButtonStateFlags kJpRshcmvkDLHSyHwGmqfpuOmup;

			internal ButtonStateFlags tCJWNlINYkYQhdNRGoSqalwUkrg;

			internal ButtonStateFlags iFAcjjFjPdmeITJuglsileyTQdKR;

			internal float yZnCjuBcgXKJRscwnPfOToSVNLO;

			internal float kQOapVRoWrExOsKQLiswrXxOKlg;

			internal float MapRlNrlPmmPNvjqcwKoYpYPCjw;

			internal float TMoPpejkFOaGMERhLMQhteAyVBB;

			private double VyeTyhlKkRUoqOXDtbgthARXUnR;

			private double eXiPlxrCNTqVrnraqdhyahUnbqI;

			internal PquZCbpjYFkKlBIfdRFwpRnRWHO eBnnsbKKlvdroUItYZOyuiXoBfX;

			internal PquZCbpjYFkKlBIfdRFwpRnRWHO eECSHXxdrjTqskjQSgxGAkEcSZHx;

			internal ButtonStateRecorder QytMOarMSYVjuJhJUVBqsfQkLdK;

			internal ButtonStateRecorder LvcFYcwEMiGxtCAfYFMrpxYrjVah;

			internal YRGgzqGPDhlGloNBrbdfHxcjAAR cHDYAGjpPBgSRUdXYDRoshXrpyF;

			internal YRGgzqGPDhlGloNBrbdfHxcjAAR ufgHnxHlGWBFdzkmuBriMMqGUxA;

			internal TimerAbs GUWTkSxajHRoxnsVTIrekyZTkJG;

			internal TimerAbs frhLeRUVUgQUZJpngaySRPOfGZe;

			internal readonly PASInWXkNNmEwyEmMgFltCXsgqq HroijPAWawlYzgzgwVsdtnbRToN = new PASInWXkNNmEwyEmMgFltCXsgqq();

			internal double vButtonTimePressed => QytMOarMSYVjuJhJUVBqsfQkLdK.timePressed;

			internal double vButtonTimeUnpressed => QytMOarMSYVjuJhJUVBqsfQkLdK.timeUnpressed;

			internal double negativeVButtonTimePressed => LvcFYcwEMiGxtCAfYFMrpxYrjVah.timePressed;

			internal double negativeVButtonTimeUnpressed => LvcFYcwEMiGxtCAfYFMrpxYrjVah.timeUnpressed;

			internal double vAxisTimeActive
			{
				get
				{
					if (ySNDGRIpQlQpKFddPugZhVCLbny == 0f && yZnCjuBcgXKJRscwnPfOToSVNLO == 0f)
					{
						return 0.0;
					}
					double num = MrDlgHQWcTNhuavzUwxfaiVsbmR - VyeTyhlKkRUoqOXDtbgthARXUnR;
					if (num < 0.0)
					{
						num = 0.0;
					}
					return num;
				}
			}

			internal double vAxisTimeInactive
			{
				get
				{
					if (ySNDGRIpQlQpKFddPugZhVCLbny != 0f || yZnCjuBcgXKJRscwnPfOToSVNLO != 0f)
					{
						return 0.0;
					}
					double num = MrDlgHQWcTNhuavzUwxfaiVsbmR - VyeTyhlKkRUoqOXDtbgthARXUnR;
					if (num < 0.0)
					{
						num = 0.0;
					}
					return num;
				}
			}

			internal double vAxisRawTimeActive
			{
				get
				{
					if (ySNDGRIpQlQpKFddPugZhVCLbny == 0f && MapRlNrlPmmPNvjqcwKoYpYPCjw == 0f)
					{
						return 0.0;
					}
					double num = MrDlgHQWcTNhuavzUwxfaiVsbmR - eXiPlxrCNTqVrnraqdhyahUnbqI;
					if (num < 0.0)
					{
						num = 0.0;
					}
					return num;
				}
			}

			internal double vAxisRawTimeInactive
			{
				get
				{
					if (ySNDGRIpQlQpKFddPugZhVCLbny != 0f || MapRlNrlPmmPNvjqcwKoYpYPCjw != 0f)
					{
						return 0.0;
					}
					double num = MrDlgHQWcTNhuavzUwxfaiVsbmR - eXiPlxrCNTqVrnraqdhyahUnbqI;
					if (num < 0.0)
					{
						num = 0.0;
					}
					return num;
				}
			}

			internal MDYFuPsMttZDragBTBSBtxjkuUR(InputBehavior inputBehavior)
			{
				zQlPNEwerdNvUCLXMXvSaeCQpU = inputBehavior;
				if (inputBehavior.buttonDownBuffer > 0f)
				{
					GUWTkSxajHRoxnsVTIrekyZTkJG = new TimerAbs(inputBehavior.buttonDownBuffer);
					frhLeRUVUgQUZJpngaySRPOfGZe = new TimerAbs(inputBehavior.buttonDownBuffer);
				}
				QytMOarMSYVjuJhJUVBqsfQkLdK = new ButtonStateRecorder();
				LvcFYcwEMiGxtCAfYFMrpxYrjVah = new ButtonStateRecorder();
				eBnnsbKKlvdroUItYZOyuiXoBfX = new PquZCbpjYFkKlBIfdRFwpRnRWHO(inputBehavior.buttonDoublePressSpeed);
				eECSHXxdrjTqskjQSgxGAkEcSZHx = new PquZCbpjYFkKlBIfdRFwpRnRWHO(inputBehavior.buttonDoublePressSpeed);
				cHDYAGjpPBgSRUdXYDRoshXrpyF = new YRGgzqGPDhlGloNBrbdfHxcjAAR(inputBehavior.buttonRepeatDelay, inputBehavior.buttonRepeatRate);
				ufgHnxHlGWBFdzkmuBriMMqGUxA = new YRGgzqGPDhlGloNBrbdfHxcjAAR(inputBehavior.buttonRepeatDelay, inputBehavior.buttonRepeatRate);
				piKdWOSujDUKqHEGhCzscdbupyR();
			}

			internal void SvQEVJLJHpARhDgKbZaKAetYbCj(double P_0)
			{
				if (ySNDGRIpQlQpKFddPugZhVCLbny != 0f || yZnCjuBcgXKJRscwnPfOToSVNLO != 0f)
				{
					if (PRMsxTDJDJDnoyZGKHOwQjACxxl == 0f && kQOapVRoWrExOsKQLiswrXxOKlg == 0f)
					{
						VyeTyhlKkRUoqOXDtbgthARXUnR = MrDlgHQWcTNhuavzUwxfaiVsbmR;
					}
				}
				else if (PRMsxTDJDJDnoyZGKHOwQjACxxl != 0f || kQOapVRoWrExOsKQLiswrXxOKlg != 0f)
				{
					VyeTyhlKkRUoqOXDtbgthARXUnR = MrDlgHQWcTNhuavzUwxfaiVsbmR;
				}
				if (ySNDGRIpQlQpKFddPugZhVCLbny != 0f || MapRlNrlPmmPNvjqcwKoYpYPCjw != 0f)
				{
					if (PRMsxTDJDJDnoyZGKHOwQjACxxl == 0f && TMoPpejkFOaGMERhLMQhteAyVBB == 0f)
					{
						eXiPlxrCNTqVrnraqdhyahUnbqI = MrDlgHQWcTNhuavzUwxfaiVsbmR;
					}
				}
				else if (PRMsxTDJDJDnoyZGKHOwQjACxxl != 0f || TMoPpejkFOaGMERhLMQhteAyVBB != 0f)
				{
					eXiPlxrCNTqVrnraqdhyahUnbqI = MrDlgHQWcTNhuavzUwxfaiVsbmR;
				}
			}

			internal void CEECqVYzTLXpaHfYBSHgvLNpRvE()
			{
				if (PRMsxTDJDJDnoyZGKHOwQjACxxl != ySNDGRIpQlQpKFddPugZhVCLbny)
				{
					PRMsxTDJDJDnoyZGKHOwQjACxxl = ySNDGRIpQlQpKFddPugZhVCLbny;
				}
				if (kJpRshcmvkDLHSyHwGmqfpuOmup != ZkOKkhijFfaSwJkzgQHVpjkjwyi)
				{
					kJpRshcmvkDLHSyHwGmqfpuOmup = ZkOKkhijFfaSwJkzgQHVpjkjwyi;
				}
				if (iFAcjjFjPdmeITJuglsileyTQdKR != tCJWNlINYkYQhdNRGoSqalwUkrg)
				{
					iFAcjjFjPdmeITJuglsileyTQdKR = tCJWNlINYkYQhdNRGoSqalwUkrg;
				}
				if (kQOapVRoWrExOsKQLiswrXxOKlg != yZnCjuBcgXKJRscwnPfOToSVNLO)
				{
					kQOapVRoWrExOsKQLiswrXxOKlg = yZnCjuBcgXKJRscwnPfOToSVNLO;
				}
				if (TMoPpejkFOaGMERhLMQhteAyVBB != MapRlNrlPmmPNvjqcwKoYpYPCjw)
				{
					TMoPpejkFOaGMERhLMQhteAyVBB = MapRlNrlPmmPNvjqcwKoYpYPCjw;
				}
				if (OxabChjxtippqCQXpiTAvxJpMMzW != LijFMsBQaBMeyaBSULosMeSZIZpX)
				{
					OxabChjxtippqCQXpiTAvxJpMMzW = LijFMsBQaBMeyaBSULosMeSZIZpX;
				}
				if (LijFMsBQaBMeyaBSULosMeSZIZpX != AxisCoordinateMode.Absolute)
				{
					LijFMsBQaBMeyaBSULosMeSZIZpX = AxisCoordinateMode.Absolute;
				}
			}

			internal void PMSAYoXbhvPkAQdDUezQWkYYJtk()
			{
				if (GUWTkSxajHRoxnsVTIrekyZTkJG != null)
				{
					GUWTkSxajHRoxnsVTIrekyZTkJG.Update();
					frhLeRUVUgQUZJpngaySRPOfGZe.Update();
				}
			}

			internal void DITelGtwtKyfFRPvubjIoKXTRFV(bool P_0, bool P_1, bool P_2, bool P_3)
			{
				QytMOarMSYVjuJhJUVBqsfQkLdK.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(P_0, P_1, MrDlgHQWcTNhuavzUwxfaiVsbmR);
				LvcFYcwEMiGxtCAfYFMrpxYrjVah.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(P_2, P_3, MrDlgHQWcTNhuavzUwxfaiVsbmR);
				float buttonDoublePressSpeed = zQlPNEwerdNvUCLXMXvSaeCQpU.buttonDoublePressSpeed;
				eBnnsbKKlvdroUItYZOyuiXoBfX.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(buttonDoublePressSpeed, P_0, P_1);
				eECSHXxdrjTqskjQSgxGAkEcSZHx.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(buttonDoublePressSpeed, P_2, P_3);
				float buttonRepeatDelay = zQlPNEwerdNvUCLXMXvSaeCQpU.buttonRepeatDelay;
				float buttonRepeatRate = zQlPNEwerdNvUCLXMXvSaeCQpU.buttonRepeatRate;
				cHDYAGjpPBgSRUdXYDRoshXrpyF.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(P_0, P_1, buttonRepeatDelay, buttonRepeatRate, MrDlgHQWcTNhuavzUwxfaiVsbmR);
				ufgHnxHlGWBFdzkmuBriMMqGUxA.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(P_2, P_3, buttonRepeatDelay, buttonRepeatRate, MrDlgHQWcTNhuavzUwxfaiVsbmR);
			}

			internal bool mPlAUlmvBoiMgLeLoRSujyUTqTL()
			{
				if (MrDlgHQWcTNhuavzUwxfaiVsbmR < iSTcZADSCajtNEvvhcRkCNUdVBej + (double)zQlPNEwerdNvUCLXMXvSaeCQpU.buttonDoublePressSpeed + 2.0 * (double)rsIsvuyohiSXvmTdTmaszbehYjV)
				{
					return false;
				}
				if (ySNDGRIpQlQpKFddPugZhVCLbny != 0f)
				{
					return false;
				}
				if (PRMsxTDJDJDnoyZGKHOwQjACxxl != 0f)
				{
					return false;
				}
				if (ZkOKkhijFfaSwJkzgQHVpjkjwyi == ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh)
				{
					return false;
				}
				if (kJpRshcmvkDLHSyHwGmqfpuOmup == ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh)
				{
					return false;
				}
				if (tCJWNlINYkYQhdNRGoSqalwUkrg == ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh)
				{
					return false;
				}
				if (iFAcjjFjPdmeITJuglsileyTQdKR == ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh)
				{
					return false;
				}
				if (yZnCjuBcgXKJRscwnPfOToSVNLO != 0f)
				{
					return false;
				}
				if (kQOapVRoWrExOsKQLiswrXxOKlg != 0f)
				{
					return false;
				}
				if (MapRlNrlPmmPNvjqcwKoYpYPCjw != 0f)
				{
					return false;
				}
				if (TMoPpejkFOaGMERhLMQhteAyVBB != 0f)
				{
					return false;
				}
				if (GUWTkSxajHRoxnsVTIrekyZTkJG != null && GUWTkSxajHRoxnsVTIrekyZTkJG.running)
				{
					return false;
				}
				if (frhLeRUVUgQUZJpngaySRPOfGZe != null && frhLeRUVUgQUZJpngaySRPOfGZe.running)
				{
					return false;
				}
				return true;
			}

			internal void uwlWYxLGDfwSqjksjQyyOdDIXUc()
			{
				ZkOKkhijFfaSwJkzgQHVpjkjwyi &= ~ButtonStateFlags.ppYdXkDrMSlYvDAaCqFoehbWDwU;
				tCJWNlINYkYQhdNRGoSqalwUkrg &= ~ButtonStateFlags.ppYdXkDrMSlYvDAaCqFoehbWDwU;
			}

			internal void sMUgVFzNYCmMbTjSKBcLQHtNmmC()
			{
				if (ySNDGRIpQlQpKFddPugZhVCLbny != 0f || yZnCjuBcgXKJRscwnPfOToSVNLO != 0f)
				{
					VyeTyhlKkRUoqOXDtbgthARXUnR = MrDlgHQWcTNhuavzUwxfaiVsbmR;
				}
				if (ySNDGRIpQlQpKFddPugZhVCLbny != 0f || MapRlNrlPmmPNvjqcwKoYpYPCjw != 0f)
				{
					eXiPlxrCNTqVrnraqdhyahUnbqI = MrDlgHQWcTNhuavzUwxfaiVsbmR;
				}
				ySNDGRIpQlQpKFddPugZhVCLbny = 0f;
				PRMsxTDJDJDnoyZGKHOwQjACxxl = 0f;
				LijFMsBQaBMeyaBSULosMeSZIZpX = AxisCoordinateMode.Absolute;
				ZkOKkhijFfaSwJkzgQHVpjkjwyi = ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh;
				kJpRshcmvkDLHSyHwGmqfpuOmup = ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh;
				tCJWNlINYkYQhdNRGoSqalwUkrg = ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh;
				iFAcjjFjPdmeITJuglsileyTQdKR = ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh;
				yZnCjuBcgXKJRscwnPfOToSVNLO = 0f;
				kQOapVRoWrExOsKQLiswrXxOKlg = 0f;
				MapRlNrlPmmPNvjqcwKoYpYPCjw = 0f;
				TMoPpejkFOaGMERhLMQhteAyVBB = 0f;
				if (GUWTkSxajHRoxnsVTIrekyZTkJG != null)
				{
					GUWTkSxajHRoxnsVTIrekyZTkJG.Clear();
					frhLeRUVUgQUZJpngaySRPOfGZe.Clear();
				}
				eBnnsbKKlvdroUItYZOyuiXoBfX.agvWMBoHtblzmgSmVloJbsDkfGk();
				eECSHXxdrjTqskjQSgxGAkEcSZHx.agvWMBoHtblzmgSmVloJbsDkfGk();
				QytMOarMSYVjuJhJUVBqsfQkLdK.sMUgVFzNYCmMbTjSKBcLQHtNmmC(MrDlgHQWcTNhuavzUwxfaiVsbmR);
				LvcFYcwEMiGxtCAfYFMrpxYrjVah.sMUgVFzNYCmMbTjSKBcLQHtNmmC(MrDlgHQWcTNhuavzUwxfaiVsbmR);
				cHDYAGjpPBgSRUdXYDRoshXrpyF.agvWMBoHtblzmgSmVloJbsDkfGk();
				ufgHnxHlGWBFdzkmuBriMMqGUxA.agvWMBoHtblzmgSmVloJbsDkfGk();
				HroijPAWawlYzgzgwVsdtnbRToN.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			}

			internal void piKdWOSujDUKqHEGhCzscdbupyR()
			{
				sMUgVFzNYCmMbTjSKBcLQHtNmmC();
				QytMOarMSYVjuJhJUVBqsfQkLdK.agvWMBoHtblzmgSmVloJbsDkfGk();
				LvcFYcwEMiGxtCAfYFMrpxYrjVah.agvWMBoHtblzmgSmVloJbsDkfGk();
				VyeTyhlKkRUoqOXDtbgthARXUnR = MrDlgHQWcTNhuavzUwxfaiVsbmR;
				eXiPlxrCNTqVrnraqdhyahUnbqI = MrDlgHQWcTNhuavzUwxfaiVsbmR;
			}
		}

		public MDYFuPsMttZDragBTBSBtxjkuUR[] KKxvXzhbFzmenMQwioAojqUOeaj;

		private readonly int[] gUNLFGDzsYivuMVwxuBTNVowmzr;

		private int jZIrWyBTDMYPCOWflxuDUQgsNSP;

		internal MDYFuPsMttZDragBTBSBtxjkuUR TrWUdtjebjTxiTudwuGvXSlDJgg;

		internal UpdateLoopType updateLoop
		{
			set
			{
				jZIrWyBTDMYPCOWflxuDUQgsNSP = gUNLFGDzsYivuMVwxuBTNVowmzr[(int)value];
				TrWUdtjebjTxiTudwuGvXSlDJgg = KKxvXzhbFzmenMQwioAojqUOeaj[jZIrWyBTDMYPCOWflxuDUQgsNSP];
			}
		}

		internal cimxWPlcTmDbPdabCBgkxkeJymej(UpdateLoopSetting updateLoopSetting, InputBehavior inputBehavior)
		{
			gUNLFGDzsYivuMVwxuBTNVowmzr = new int[3];
			ArrayTools.Fill(gUNLFGDzsYivuMVwxuBTNVowmzr, -1);
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
				for (int i = 0; i < list.Count; i++)
				{
					gUNLFGDzsYivuMVwxuBTNVowmzr[(int)list[i]] = num;
					num++;
				}
			}
			KKxvXzhbFzmenMQwioAojqUOeaj = new MDYFuPsMttZDragBTBSBtxjkuUR[num];
			for (int j = 0; j < num; j++)
			{
				KKxvXzhbFzmenMQwioAojqUOeaj[j] = new MDYFuPsMttZDragBTBSBtxjkuUR(inputBehavior);
			}
			TrWUdtjebjTxiTudwuGvXSlDJgg = KKxvXzhbFzmenMQwioAojqUOeaj[0];
		}

		internal bool mPlAUlmvBoiMgLeLoRSujyUTqTL()
		{
			for (int i = 0; i < 3; i++)
			{
				if (gUNLFGDzsYivuMVwxuBTNVowmzr[i] >= 0 && !KKxvXzhbFzmenMQwioAojqUOeaj[gUNLFGDzsYivuMVwxuBTNVowmzr[i]].mPlAUlmvBoiMgLeLoRSujyUTqTL())
				{
					return false;
				}
			}
			return true;
		}

		internal void agvWMBoHtblzmgSmVloJbsDkfGk()
		{
			for (int i = 0; i < KKxvXzhbFzmenMQwioAojqUOeaj.Length; i++)
			{
				KKxvXzhbFzmenMQwioAojqUOeaj[i].piKdWOSujDUKqHEGhCzscdbupyR();
			}
		}

		internal void sMUgVFzNYCmMbTjSKBcLQHtNmmC()
		{
			for (int i = 0; i < KKxvXzhbFzmenMQwioAojqUOeaj.Length; i++)
			{
				KKxvXzhbFzmenMQwioAojqUOeaj[i].sMUgVFzNYCmMbTjSKBcLQHtNmmC();
			}
		}
	}

	private class OnPXEYCHjbopsoCeSRwopWkBCIe
	{
		internal class jludlniluJbQtcUqwjmNhoidZCv
		{
			internal Vector3 CtwjsdScMpAOZEQvdhyOtjFoTAxK;

			internal Vector3 OCtcIgCcmEDZFQuiVkxsrCFjQRO;

			internal Vector3 hXjFolbbyYjLlUHxqmEOvJyipLmd;

			internal void uvCeMewwiHfKoeHvwtFkLxDTeOBG()
			{
				CtwjsdScMpAOZEQvdhyOtjFoTAxK = ReInput.controllers.Mouse.screenPosition;
				hXjFolbbyYjLlUHxqmEOvJyipLmd = CtwjsdScMpAOZEQvdhyOtjFoTAxK - OCtcIgCcmEDZFQuiVkxsrCFjQRO;
			}

			internal void zmIDWVUqVihiweiOKEzxelXEqUXQ()
			{
				OCtcIgCcmEDZFQuiVkxsrCFjQRO.x = CtwjsdScMpAOZEQvdhyOtjFoTAxK.x;
				OCtcIgCcmEDZFQuiVkxsrCFjQRO.y = CtwjsdScMpAOZEQvdhyOtjFoTAxK.y;
				OCtcIgCcmEDZFQuiVkxsrCFjQRO.z = CtwjsdScMpAOZEQvdhyOtjFoTAxK.z;
			}
		}

		private ADictionary<int, jludlniluJbQtcUqwjmNhoidZCv> ALzKzwEPPCnkjtevfNykduPJedu;

		private jludlniluJbQtcUqwjmNhoidZCv QEHGEaSoyfYJDjxPbapvAChmqyL;

		private UpdateLoopType ZlHBNkfwgSQZbHeSmjWbXjevOqK;

		internal jludlniluJbQtcUqwjmNhoidZCv current => QEHGEaSoyfYJDjxPbapvAChmqyL;

		internal OnPXEYCHjbopsoCeSRwopWkBCIe(UpdateLoopSetting updateLoopSetting)
		{
			QEHGEaSoyfYJDjxPbapvAChmqyL = null;
			ALzKzwEPPCnkjtevfNykduPJedu = new ADictionary<int, jludlniluJbQtcUqwjmNhoidZCv>();
			using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			for (int i = 0; i < list.Count; i++)
			{
				jludlniluJbQtcUqwjmNhoidZCv jludlniluJbQtcUqwjmNhoidZCv2 = new jludlniluJbQtcUqwjmNhoidZCv();
				ALzKzwEPPCnkjtevfNykduPJedu.Add((int)list[i], jludlniluJbQtcUqwjmNhoidZCv2);
				if (QEHGEaSoyfYJDjxPbapvAChmqyL == null)
				{
					QEHGEaSoyfYJDjxPbapvAChmqyL = jludlniluJbQtcUqwjmNhoidZCv2;
				}
			}
		}

		internal void uvCeMewwiHfKoeHvwtFkLxDTeOBG(UpdateLoopType P_0)
		{
			if (ZlHBNkfwgSQZbHeSmjWbXjevOqK != P_0)
			{
				ZlHBNkfwgSQZbHeSmjWbXjevOqK = P_0;
			}
			QEHGEaSoyfYJDjxPbapvAChmqyL = ALzKzwEPPCnkjtevfNykduPJedu[(int)P_0];
			QEHGEaSoyfYJDjxPbapvAChmqyL.uvCeMewwiHfKoeHvwtFkLxDTeOBG();
		}

		internal void zmIDWVUqVihiweiOKEzxelXEqUXQ()
		{
			QEHGEaSoyfYJDjxPbapvAChmqyL.zmIDWVUqVihiweiOKEzxelXEqUXQ();
		}
	}

	private const int KdctUWuKKPApxPTwWoGPwYuqrRE = 4;

	internal readonly string qpIGvFaemznETzYbpRdmOKmaPCL;

	internal readonly int CYBGYVfPDvCydagiBzJBExAfcuYb;

	internal readonly int EpFfrTuakcvBKacoggaztTmGfrG;

	private readonly int VumWnlylMgxSbyJcluXptXvaaZa;

	private InputBehavior zQlPNEwerdNvUCLXMXvSaeCQpU;

	private cimxWPlcTmDbPdabCBgkxkeJymej SDGPnTyJBledggiEkINiOCYmeOkD;

	private static ConfigVars LOkMduUeVwqIadHuBlHhVcCnHqW;

	private static OnPXEYCHjbopsoCeSRwopWkBCIe RdmvZcjCoyFbhyKgpLQbFiJxcqn;

	private static UpdateLoopType feXycwAOzGdljyeHjexWYpHVqTp;

	private static double MrDlgHQWcTNhuavzUwxfaiVsbmR;

	private static float rsIsvuyohiSXvmTdTmaszbehYjV;

	private static uint JkzAFnBMOLnffetRBhHjkdIMsMN;

	private float xquTffRodEKdzbDFCeyZIjImDaK;

	private float XHHrfsVLgxrCIAPkEsPnxvVodLF;

	private float nprhlSVwSOflMhJmUvJfsDTMohu;

	private float spIiAzjgBjXZyRBoRWOcMmBRJBJ;

	private ButtonStateFlags QsXcVaAnhNCqShitAeJvyerFhOsA;

	private ButtonStateFlags bKglRMrewQDpklEJOFNJktvnxyog;

	private float DKaphJjYcOVsotWUZQeJpZZHeHI;

	private bool IzZFCqguxwAaZbgWIHNPupUWcZWh;

	private AxisCoordinateMode qtDoHVBvWbheqhbxsalOFvuZOmT;

	private AxisCoordinateMode yerDNDesxPlGMDZECoFjYQoeckF;

	private readonly PASInWXkNNmEwyEmMgFltCXsgqq YlEIZNroPZASSGNJjSlGDlLfJiz = new PASInWXkNNmEwyEmMgFltCXsgqq();

	private uint LmdLCVOQkddFJBAsGknlNDwjdAO;

	private uint pXYMRotxEZNfQEOAohNymCuqdIQ;

	private bool fnmNyFDHvACriDqGjPNCMYYnpzE;

	private CIxBuEeASTjOkXSChHkrvFPOWiW YDCMgEhoqnecsKoQhySMgzvEdSwI;

	private int etLgPXbDjDbbhRQTPZEDckBFjNj;

	private PASInWXkNNmEwyEmMgFltCXsgqq[] HKgPJczASLIFOLNNZURaNgyDgoI;

	private List<InputActionSourceData> mwNQaEBNSkYgnutXqmDqcmYMFRN;

	private ReadOnlyCollection<InputActionSourceData> NwBXbItjMxYIglXGYORzvhQGsta;

	private bool DOZWLFGKLcVXJpbdeblPVsgYfnzH;

	internal bool IAPkqDUzQJdPHucoTqCGLiJSizt;

	internal CIxBuEeASTjOkXSChHkrvFPOWiW zeUqVPIDVWYcAggYWXLnNfyRBHX = CIxBuEeASTjOkXSChHkrvFPOWiW.WQNdYJSAYYvmjxKbWASGxbAiIpYg;

	internal static readonly wbeHCVDzEAfSpdXrnocntonKjhK IKAziOKgvhrFYCscwOYtGpvMfGf;

	static VvbRiPIRRDOGFeaGvZCVmBjRfXT()
	{
		IKAziOKgvhrFYCscwOYtGpvMfGf = new wbeHCVDzEAfSpdXrnocntonKjhK();
	}

	internal VvbRiPIRRDOGFeaGvZCVmBjRfXT(int playerId, InputAction action, InputBehavior inputBehavior, ConfigVars configVars)
	{
		VumWnlylMgxSbyJcluXptXvaaZa = ReInput._id;
		LOkMduUeVwqIadHuBlHhVcCnHqW = configVars;
		EpFfrTuakcvBKacoggaztTmGfrG = playerId;
		CYBGYVfPDvCydagiBzJBExAfcuYb = action.id;
		qpIGvFaemznETzYbpRdmOKmaPCL = action.name;
		zQlPNEwerdNvUCLXMXvSaeCQpU = inputBehavior;
		SDGPnTyJBledggiEkINiOCYmeOkD = new cimxWPlcTmDbPdabCBgkxkeJymej(configVars.updateLoop, inputBehavior);
		HKgPJczASLIFOLNNZURaNgyDgoI = new PASInWXkNNmEwyEmMgFltCXsgqq[4];
		ArrayTools.Populate(HKgPJczASLIFOLNNZURaNgyDgoI);
		mwNQaEBNSkYgnutXqmDqcmYMFRN = new List<InputActionSourceData>();
		NwBXbItjMxYIglXGYORzvhQGsta = new ReadOnlyCollection<InputActionSourceData>(mwNQaEBNSkYgnutXqmDqcmYMFRN);
	}

	internal static void ZiymOPuXhjhmAzOQLyeRogxsHYa(ConfigVars P_0)
	{
		RdmvZcjCoyFbhyKgpLQbFiJxcqn = new OnPXEYCHjbopsoCeSRwopWkBCIe(P_0.updateLoop);
	}

	internal static void UIRnsHnENNoXIiApdjlDWHOSAVj(UpdateLoopType P_0)
	{
		feXycwAOzGdljyeHjexWYpHVqTp = P_0;
		MrDlgHQWcTNhuavzUwxfaiVsbmR = ReInput.unscaledTime;
		rsIsvuyohiSXvmTdTmaszbehYjV = (float)ReInput.unscaledDeltaTime;
		JkzAFnBMOLnffetRBhHjkdIMsMN = ReInput.absFrame;
		RdmvZcjCoyFbhyKgpLQbFiJxcqn.uvCeMewwiHfKoeHvwtFkLxDTeOBG(P_0);
	}

	internal static void FmqbFCAglOyiasCaFtvYdiGPKNPD()
	{
		RdmvZcjCoyFbhyKgpLQbFiJxcqn.zmIDWVUqVihiweiOKEzxelXEqUXQ();
	}

	private void kUWRCCoeiwDtIJKpGcSiUGViRxIH()
	{
		SDGPnTyJBledggiEkINiOCYmeOkD.updateLoop = feXycwAOzGdljyeHjexWYpHVqTp;
		SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.CEECqVYzTLXpaHfYBSHgvLNpRvE();
		SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.PMSAYoXbhvPkAQdDUezQWkYYJtk();
		if (xquTffRodEKdzbDFCeyZIjImDaK != 0f)
		{
			xquTffRodEKdzbDFCeyZIjImDaK = 0f;
		}
		if (XHHrfsVLgxrCIAPkEsPnxvVodLF != 0f)
		{
			XHHrfsVLgxrCIAPkEsPnxvVodLF = 0f;
		}
		if (QsXcVaAnhNCqShitAeJvyerFhOsA != ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh)
		{
			QsXcVaAnhNCqShitAeJvyerFhOsA = ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh;
		}
		if (bKglRMrewQDpklEJOFNJktvnxyog != ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh)
		{
			bKglRMrewQDpklEJOFNJktvnxyog = ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh;
		}
		if (DKaphJjYcOVsotWUZQeJpZZHeHI != 0f)
		{
			DKaphJjYcOVsotWUZQeJpZZHeHI = 0f;
		}
		if (IzZFCqguxwAaZbgWIHNPupUWcZWh)
		{
			IzZFCqguxwAaZbgWIHNPupUWcZWh = false;
		}
		if (nprhlSVwSOflMhJmUvJfsDTMohu != 0f)
		{
			nprhlSVwSOflMhJmUvJfsDTMohu = 0f;
		}
		if (spIiAzjgBjXZyRBoRWOcMmBRJBJ != 0f)
		{
			spIiAzjgBjXZyRBoRWOcMmBRJBJ = 0f;
		}
		if (qtDoHVBvWbheqhbxsalOFvuZOmT != AxisCoordinateMode.Absolute)
		{
			qtDoHVBvWbheqhbxsalOFvuZOmT = AxisCoordinateMode.Absolute;
		}
		if (yerDNDesxPlGMDZECoFjYQoeckF != AxisCoordinateMode.Absolute)
		{
			yerDNDesxPlGMDZECoFjYQoeckF = AxisCoordinateMode.Absolute;
		}
		if (etLgPXbDjDbbhRQTPZEDckBFjNj > 0)
		{
			irZhnrPvoLKwgiNXCsjexFJjIpF();
		}
		if (YlEIZNroPZASSGNJjSlGDlLfJiz.NosALOCJZWSRRlLkYnXjziASvDO)
		{
			YlEIZNroPZASSGNJjSlGDlLfJiz.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
		}
	}

	internal void AUSocaxjOFPiynwlRPvgzxGUtHA(bool P_0)
	{
		if (LmdLCVOQkddFJBAsGknlNDwjdAO != JkzAFnBMOLnffetRBhHjkdIMsMN)
		{
			LmdLCVOQkddFJBAsGknlNDwjdAO = JkzAFnBMOLnffetRBhHjkdIMsMN;
			if (YDCMgEhoqnecsKoQhySMgzvEdSwI != zeUqVPIDVWYcAggYWXLnNfyRBHX)
			{
				YDCMgEhoqnecsKoQhySMgzvEdSwI = zeUqVPIDVWYcAggYWXLnNfyRBHX;
			}
			if (IAPkqDUzQJdPHucoTqCGLiJSizt)
			{
				kUWRCCoeiwDtIJKpGcSiUGViRxIH();
			}
			else if (zeUqVPIDVWYcAggYWXLnNfyRBHX == CIxBuEeASTjOkXSChHkrvFPOWiW.WQNdYJSAYYvmjxKbWASGxbAiIpYg)
			{
				zeUqVPIDVWYcAggYWXLnNfyRBHX = CIxBuEeASTjOkXSChHkrvFPOWiW.RlAwwSywSSQUidrZslnSooSUgRN;
			}
		}
		if (!P_0)
		{
			return;
		}
		if (pXYMRotxEZNfQEOAohNymCuqdIQ != JkzAFnBMOLnffetRBhHjkdIMsMN)
		{
			pXYMRotxEZNfQEOAohNymCuqdIQ = JkzAFnBMOLnffetRBhHjkdIMsMN;
			if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
			{
				ztehiAbBWLMJjiUjLbqrHIvSSTE();
				kUWRCCoeiwDtIJKpGcSiUGViRxIH();
			}
			SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.iSTcZADSCajtNEvvhcRkCNUdVBej = MrDlgHQWcTNhuavzUwxfaiVsbmR;
		}
		wbeHCVDzEAfSpdXrnocntonKjhK iKAziOKgvhrFYCscwOYtGpvMfGf = IKAziOKgvhrFYCscwOYtGpvMfGf;
		int cRqOTsiLfoazJbodeeofQgavSxg = iKAziOKgvhrFYCscwOYtGpvMfGf.PgtyCGUpZbAlPcnBMkOdtmXxupEd.CRqOTsiLfoazJbodeeofQgavSxg;
		hYEDsbfHjWpxuVCufRoaqQStbvgX(iKAziOKgvhrFYCscwOYtGpvMfGf.FKtcxmBappHTSHGoccIYREwbpfog, iKAziOKgvhrFYCscwOYtGpvMfGf.nuUgjEKzUuMYBIiHUtitJvzUOOl, iKAziOKgvhrFYCscwOYtGpvMfGf.PgtyCGUpZbAlPcnBMkOdtmXxupEd);
		if (iKAziOKgvhrFYCscwOYtGpvMfGf.LSmTRdvHuagVChPSPaniDTWrvDKL == ControllerElementType.Button)
		{
			if (iKAziOKgvhrFYCscwOYtGpvMfGf.OVzqgzfQQediHUSdTbkxKkQsdgo)
			{
				if (iKAziOKgvhrFYCscwOYtGpvMfGf.PgtyCGUpZbAlPcnBMkOdtmXxupEd._axisContribution == Pole.Positive)
				{
					ixpYSWaqAyxNDXvnQiwkmezGFGW(ref QsXcVaAnhNCqShitAeJvyerFhOsA, iKAziOKgvhrFYCscwOYtGpvMfGf.ZkOKkhijFfaSwJkzgQHVpjkjwyi);
				}
				else
				{
					ixpYSWaqAyxNDXvnQiwkmezGFGW(ref bKglRMrewQDpklEJOFNJktvnxyog, iKAziOKgvhrFYCscwOYtGpvMfGf.ZkOKkhijFfaSwJkzgQHVpjkjwyi);
				}
				if (qtDoHVBvWbheqhbxsalOFvuZOmT == AxisCoordinateMode.Absolute)
				{
					xquTffRodEKdzbDFCeyZIjImDaK += iKAziOKgvhrFYCscwOYtGpvMfGf.lvXCTCWOhrCtuFDbbEqyqyUVPhp;
				}
				return;
			}
			if (iKAziOKgvhrFYCscwOYtGpvMfGf.PgtyCGUpZbAlPcnBMkOdtmXxupEd._axisContribution == Pole.Positive)
			{
				ixpYSWaqAyxNDXvnQiwkmezGFGW(ref QsXcVaAnhNCqShitAeJvyerFhOsA, iKAziOKgvhrFYCscwOYtGpvMfGf.ZkOKkhijFfaSwJkzgQHVpjkjwyi);
			}
			else
			{
				ixpYSWaqAyxNDXvnQiwkmezGFGW(ref bKglRMrewQDpklEJOFNJktvnxyog, iKAziOKgvhrFYCscwOYtGpvMfGf.ZkOKkhijFfaSwJkzgQHVpjkjwyi);
			}
			if (iKAziOKgvhrFYCscwOYtGpvMfGf.lvXCTCWOhrCtuFDbbEqyqyUVPhp != 0f)
			{
				DKaphJjYcOVsotWUZQeJpZZHeHI += (int)(1f * MathTools.Sign(iKAziOKgvhrFYCscwOYtGpvMfGf.lvXCTCWOhrCtuFDbbEqyqyUVPhp));
				YlEIZNroPZASSGNJjSlGDlLfJiz.NGXUBbcPdrBYfEJQGstImmQAGjsO(iKAziOKgvhrFYCscwOYtGpvMfGf);
			}
			if ((iKAziOKgvhrFYCscwOYtGpvMfGf.ZkOKkhijFfaSwJkzgQHVpjkjwyi & ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa) != ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh)
			{
				IzZFCqguxwAaZbgWIHNPupUWcZWh = true;
			}
			return;
		}
		if (iKAziOKgvhrFYCscwOYtGpvMfGf.LSmTRdvHuagVChPSPaniDTWrvDKL == ControllerElementType.Axis)
		{
			switch (iKAziOKgvhrFYCscwOYtGpvMfGf.guEuWFKSUNviYZgARiewhDnEceT)
			{
			case ControllerType.Mouse:
				if ((cRqOTsiLfoazJbodeeofQgavSxg < 2 && zQlPNEwerdNvUCLXMXvSaeCQpU.mouseXYAxisMode == MouseXYAxisMode.DigitalAxis) || (cRqOTsiLfoazJbodeeofQgavSxg > 1 && zQlPNEwerdNvUCLXMXvSaeCQpU.mouseOtherAxisMode == MouseOtherAxisMode.DigitalAxis))
				{
					EFxXYbRVWYryIANPrHKewIXrlOt(iKAziOKgvhrFYCscwOYtGpvMfGf, 0f, true);
					break;
				}
				if (cRqOTsiLfoazJbodeeofQgavSxg < 2)
				{
					if (zQlPNEwerdNvUCLXMXvSaeCQpU.mouseXYAxisMode == MouseXYAxisMode.MouseAxis)
					{
						nprhlSVwSOflMhJmUvJfsDTMohu += iKAziOKgvhrFYCscwOYtGpvMfGf.lvXCTCWOhrCtuFDbbEqyqyUVPhp * zQlPNEwerdNvUCLXMXvSaeCQpU.mouseXYAxisSensitivity;
					}
					else if (zQlPNEwerdNvUCLXMXvSaeCQpU.mouseXYAxisMode == MouseXYAxisMode.ScreenPositionDelta || zQlPNEwerdNvUCLXMXvSaeCQpU.mouseXYAxisMode == MouseXYAxisMode.Speed)
					{
						float num;
						float num2;
						if (zQlPNEwerdNvUCLXMXvSaeCQpU.mouseXYAxisDeltaCalc == MouseXYAxisDeltaCalc.Normal)
						{
							num = Screen.width;
							num2 = Screen.height;
						}
						else if (zQlPNEwerdNvUCLXMXvSaeCQpU.mouseXYAxisDeltaCalc == MouseXYAxisDeltaCalc.ScreenWidth)
						{
							num = Screen.width;
							num2 = num;
						}
						else
						{
							if (zQlPNEwerdNvUCLXMXvSaeCQpU.mouseXYAxisDeltaCalc != MouseXYAxisDeltaCalc.ScreenHeight)
							{
								throw new NotImplementedException();
							}
							num2 = Screen.height;
							num = num2;
						}
						OnPXEYCHjbopsoCeSRwopWkBCIe.jludlniluJbQtcUqwjmNhoidZCv current = RdmvZcjCoyFbhyKgpLQbFiJxcqn.current;
						if (cRqOTsiLfoazJbodeeofQgavSxg == 0)
						{
							float x = current.hXjFolbbyYjLlUHxqmEOvJyipLmd.x;
							if (x != 0f)
							{
								float num3 = x / num;
								if (zQlPNEwerdNvUCLXMXvSaeCQpU.mouseXYAxisMode == MouseXYAxisMode.Speed)
								{
									num3 /= rsIsvuyohiSXvmTdTmaszbehYjV;
								}
								nprhlSVwSOflMhJmUvJfsDTMohu += num3;
							}
						}
						else
						{
							float y = current.hXjFolbbyYjLlUHxqmEOvJyipLmd.y;
							if (y != 0f)
							{
								float num4 = y / num2;
								if (zQlPNEwerdNvUCLXMXvSaeCQpU.mouseXYAxisMode == MouseXYAxisMode.Speed)
								{
									num4 /= rsIsvuyohiSXvmTdTmaszbehYjV;
								}
								nprhlSVwSOflMhJmUvJfsDTMohu += num4;
							}
						}
					}
				}
				else if (zQlPNEwerdNvUCLXMXvSaeCQpU.mouseOtherAxisMode == MouseOtherAxisMode.MouseAxis)
				{
					nprhlSVwSOflMhJmUvJfsDTMohu += iKAziOKgvhrFYCscwOYtGpvMfGf.lvXCTCWOhrCtuFDbbEqyqyUVPhp * zQlPNEwerdNvUCLXMXvSaeCQpU.mouseOtherAxisSensitivity;
				}
				EFxXYbRVWYryIANPrHKewIXrlOt(iKAziOKgvhrFYCscwOYtGpvMfGf, zQlPNEwerdNvUCLXMXvSaeCQpU.buttonDeadZone, false);
				break;
			case ControllerType.Joystick:
				UkGWkLnIKCiaLabdGbCSouXgiAXV(iKAziOKgvhrFYCscwOYtGpvMfGf, zQlPNEwerdNvUCLXMXvSaeCQpU.joystickAxisSensitivity);
				break;
			case ControllerType.Custom:
				UkGWkLnIKCiaLabdGbCSouXgiAXV(iKAziOKgvhrFYCscwOYtGpvMfGf, zQlPNEwerdNvUCLXMXvSaeCQpU.customControllerAxisSensitivity);
				break;
			default:
				throw new NotImplementedException();
			}
			return;
		}
		throw new NotImplementedException();
	}

	private void UkGWkLnIKCiaLabdGbCSouXgiAXV(wbeHCVDzEAfSpdXrnocntonKjhK P_0, float P_1)
	{
		float num = P_0.lvXCTCWOhrCtuFDbbEqyqyUVPhp * P_1;
		if (P_0.rdzdcCNDtRtIJOVeEPkAOfwnPXY)
		{
			if (P_0.LijFMsBQaBMeyaBSULosMeSZIZpX == AxisCoordinateMode.Absolute)
			{
				if (qtDoHVBvWbheqhbxsalOFvuZOmT == AxisCoordinateMode.Absolute)
				{
					xquTffRodEKdzbDFCeyZIjImDaK += num;
				}
			}
			else if (P_0.LijFMsBQaBMeyaBSULosMeSZIZpX == AxisCoordinateMode.Relative)
			{
				if (qtDoHVBvWbheqhbxsalOFvuZOmT != AxisCoordinateMode.Relative)
				{
					xquTffRodEKdzbDFCeyZIjImDaK = num;
					qtDoHVBvWbheqhbxsalOFvuZOmT = AxisCoordinateMode.Relative;
				}
				else
				{
					xquTffRodEKdzbDFCeyZIjImDaK = MathTools.MaxMagnitude(xquTffRodEKdzbDFCeyZIjImDaK, num);
				}
			}
		}
		else if (P_0.LijFMsBQaBMeyaBSULosMeSZIZpX == AxisCoordinateMode.Absolute)
		{
			if (yerDNDesxPlGMDZECoFjYQoeckF == AxisCoordinateMode.Absolute && MathTools.Abs(num) > MathTools.Abs(XHHrfsVLgxrCIAPkEsPnxvVodLF))
			{
				XHHrfsVLgxrCIAPkEsPnxvVodLF = num;
			}
		}
		else if (P_0.LijFMsBQaBMeyaBSULosMeSZIZpX == AxisCoordinateMode.Relative)
		{
			if (yerDNDesxPlGMDZECoFjYQoeckF != AxisCoordinateMode.Relative)
			{
				XHHrfsVLgxrCIAPkEsPnxvVodLF = num;
				yerDNDesxPlGMDZECoFjYQoeckF = AxisCoordinateMode.Relative;
			}
			else if (MathTools.Abs(num) > MathTools.Abs(XHHrfsVLgxrCIAPkEsPnxvVodLF))
			{
				XHHrfsVLgxrCIAPkEsPnxvVodLF = num;
			}
		}
		EFxXYbRVWYryIANPrHKewIXrlOt(P_0, zQlPNEwerdNvUCLXMXvSaeCQpU.buttonDeadZone, false);
	}

	private void EFxXYbRVWYryIANPrHKewIXrlOt(wbeHCVDzEAfSpdXrnocntonKjhK P_0, float P_1, bool P_2)
	{
		tPpCplvxCBpYIIbYhfvfnqNQfUM tPpCplvxCBpYIIbYhfvfnqNQfUM2 = tPpCplvxCBpYIIbYhfvfnqNQfUM.tbTaqwCgVnCLKvHsvgjnjEDiwyz(P_0.PgtyCGUpZbAlPcnBMkOdtmXxupEd.JYRMuwETpVNRqJXmtBgBFhZdTeP);
		if (P_0.PgtyCGUpZbAlPcnBMkOdtmXxupEd._axisRange == AxisRange.Full)
		{
			if (MathTools.Abs(P_0.lvXCTCWOhrCtuFDbbEqyqyUVPhp) > P_1)
			{
				tPpCplvxCBpYIIbYhfvfnqNQfUM2.YznpIQNoshMCFPANqaYGMzkecBZ(feXycwAOzGdljyeHjexWYpHVqTp, P_0.lvXCTCWOhrCtuFDbbEqyqyUVPhp > 0f);
			}
			ButtonStateFlags buttonStateFlags = tPpCplvxCBpYIIbYhfvfnqNQfUM2.OzEITSYbvsjksHLvCKYLgBzVvWQ(true);
			ButtonStateFlags buttonStateFlags2 = tPpCplvxCBpYIIbYhfvfnqNQfUM2.OzEITSYbvsjksHLvCKYLgBzVvWQ(false);
			ixpYSWaqAyxNDXvnQiwkmezGFGW(ref QsXcVaAnhNCqShitAeJvyerFhOsA, buttonStateFlags);
			ixpYSWaqAyxNDXvnQiwkmezGFGW(ref bKglRMrewQDpklEJOFNJktvnxyog, buttonStateFlags2);
			if (P_2 && ((buttonStateFlags & ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa) != ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh || (buttonStateFlags2 & ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa) != ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh))
			{
				if (P_0.lvXCTCWOhrCtuFDbbEqyqyUVPhp != 0f)
				{
					DKaphJjYcOVsotWUZQeJpZZHeHI += (int)(1f * MathTools.Sign(P_0.lvXCTCWOhrCtuFDbbEqyqyUVPhp));
					YlEIZNroPZASSGNJjSlGDlLfJiz.NGXUBbcPdrBYfEJQGstImmQAGjsO(P_0);
				}
				IzZFCqguxwAaZbgWIHNPupUWcZWh = true;
			}
			return;
		}
		ButtonStateFlags buttonStateFlags3;
		if (P_0.PgtyCGUpZbAlPcnBMkOdtmXxupEd._axisContribution == Pole.Positive)
		{
			if (P_0.lvXCTCWOhrCtuFDbbEqyqyUVPhp > P_1)
			{
				tPpCplvxCBpYIIbYhfvfnqNQfUM2.YznpIQNoshMCFPANqaYGMzkecBZ(feXycwAOzGdljyeHjexWYpHVqTp, true);
			}
			buttonStateFlags3 = tPpCplvxCBpYIIbYhfvfnqNQfUM2.OzEITSYbvsjksHLvCKYLgBzVvWQ(true);
			ixpYSWaqAyxNDXvnQiwkmezGFGW(ref QsXcVaAnhNCqShitAeJvyerFhOsA, buttonStateFlags3);
		}
		else
		{
			if (MathTools.Abs(P_0.lvXCTCWOhrCtuFDbbEqyqyUVPhp) > P_1)
			{
				tPpCplvxCBpYIIbYhfvfnqNQfUM2.YznpIQNoshMCFPANqaYGMzkecBZ(feXycwAOzGdljyeHjexWYpHVqTp, false);
			}
			buttonStateFlags3 = tPpCplvxCBpYIIbYhfvfnqNQfUM2.OzEITSYbvsjksHLvCKYLgBzVvWQ(false);
			ixpYSWaqAyxNDXvnQiwkmezGFGW(ref bKglRMrewQDpklEJOFNJktvnxyog, buttonStateFlags3);
		}
		if (P_2)
		{
			if (P_0.lvXCTCWOhrCtuFDbbEqyqyUVPhp != 0f)
			{
				DKaphJjYcOVsotWUZQeJpZZHeHI += (int)(1f * MathTools.Sign(P_0.lvXCTCWOhrCtuFDbbEqyqyUVPhp));
				YlEIZNroPZASSGNJjSlGDlLfJiz.NGXUBbcPdrBYfEJQGstImmQAGjsO(P_0);
			}
			if ((buttonStateFlags3 & ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa) != ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh)
			{
				IzZFCqguxwAaZbgWIHNPupUWcZWh = true;
			}
		}
	}

	internal void TIGQjegnUMUwRUVNgQHfuaqPqhU()
	{
		if (LmdLCVOQkddFJBAsGknlNDwjdAO != JkzAFnBMOLnffetRBhHjkdIMsMN)
		{
			sMUgVFzNYCmMbTjSKBcLQHtNmmC(false);
		}
		else
		{
			if (zeUqVPIDVWYcAggYWXLnNfyRBHX == CIxBuEeASTjOkXSChHkrvFPOWiW.RlAwwSywSSQUidrZslnSooSUgRN)
			{
				return;
			}
			cimxWPlcTmDbPdabCBgkxkeJymej.MDYFuPsMttZDragBTBSBtxjkuUR trWUdtjebjTxiTudwuGvXSlDJgg = SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg;
			trWUdtjebjTxiTudwuGvXSlDJgg.ZkOKkhijFfaSwJkzgQHVpjkjwyi = QsXcVaAnhNCqShitAeJvyerFhOsA;
			trWUdtjebjTxiTudwuGvXSlDJgg.tCJWNlINYkYQhdNRGoSqalwUkrg = bKglRMrewQDpklEJOFNJktvnxyog;
			if (nprhlSVwSOflMhJmUvJfsDTMohu != 0f)
			{
				trWUdtjebjTxiTudwuGvXSlDJgg.ySNDGRIpQlQpKFddPugZhVCLbny = nprhlSVwSOflMhJmUvJfsDTMohu;
				trWUdtjebjTxiTudwuGvXSlDJgg.LijFMsBQaBMeyaBSULosMeSZIZpX = AxisCoordinateMode.Relative;
			}
			else if (XHHrfsVLgxrCIAPkEsPnxvVodLF != 0f)
			{
				trWUdtjebjTxiTudwuGvXSlDJgg.ySNDGRIpQlQpKFddPugZhVCLbny = XHHrfsVLgxrCIAPkEsPnxvVodLF;
				trWUdtjebjTxiTudwuGvXSlDJgg.LijFMsBQaBMeyaBSULosMeSZIZpX = yerDNDesxPlGMDZECoFjYQoeckF;
			}
			else
			{
				float ySNDGRIpQlQpKFddPugZhVCLbny = MathTools.Clamp(xquTffRodEKdzbDFCeyZIjImDaK, -1f, 1f);
				trWUdtjebjTxiTudwuGvXSlDJgg.ySNDGRIpQlQpKFddPugZhVCLbny = ySNDGRIpQlQpKFddPugZhVCLbny;
				trWUdtjebjTxiTudwuGvXSlDJgg.LijFMsBQaBMeyaBSULosMeSZIZpX = qtDoHVBvWbheqhbxsalOFvuZOmT;
			}
			if (fnmNyFDHvACriDqGjPNCMYYnpzE)
			{
				trWUdtjebjTxiTudwuGvXSlDJgg.uwlWYxLGDfwSqjksjQyyOdDIXUc();
				fnmNyFDHvACriDqGjPNCMYYnpzE = false;
			}
			eMUlwCZRnTKRYQJBlBcMpdqEGkR();
			trWUdtjebjTxiTudwuGvXSlDJgg.SvQEVJLJHpARhDgKbZaKAetYbCj(MrDlgHQWcTNhuavzUwxfaiVsbmR);
			if (trWUdtjebjTxiTudwuGvXSlDJgg.GUWTkSxajHRoxnsVTIrekyZTkJG != null)
			{
				if (OZnCSdYrbsHmUqpRMHVRQumZfNP())
				{
					trWUdtjebjTxiTudwuGvXSlDJgg.GUWTkSxajHRoxnsVTIrekyZTkJG.Start(zQlPNEwerdNvUCLXMXvSaeCQpU.buttonDownBuffer);
				}
				if (PNHdOVeiOALymEezWcCUCTQWqHL())
				{
					trWUdtjebjTxiTudwuGvXSlDJgg.frhLeRUVUgQUZJpngaySRPOfGZe.Start(zQlPNEwerdNvUCLXMXvSaeCQpU.buttonDownBuffer);
				}
			}
			trWUdtjebjTxiTudwuGvXSlDJgg.DITelGtwtKyfFRPvubjIoKXTRFV(CmwiIVrqfDqUrfdgDhwXnRxwqAE(), JFLhhsViRZmASHFRAirmzVNMOhf(), wiPVOSjfQFqDVBfmgbvuPukNqlZ(), gjvFsQfWVLkGJLUlHHOwfcVAxgI());
			if (DOZWLFGKLcVXJpbdeblPVsgYfnzH)
			{
				ZGiatqgfSCAiRTZdeZggphzXCtbv();
			}
			if (pXYMRotxEZNfQEOAohNymCuqdIQ != JkzAFnBMOLnffetRBhHjkdIMsMN && SDGPnTyJBledggiEkINiOCYmeOkD.mPlAUlmvBoiMgLeLoRSujyUTqTL())
			{
				sMUgVFzNYCmMbTjSKBcLQHtNmmC(true);
			}
		}
	}

	internal void eMUlwCZRnTKRYQJBlBcMpdqEGkR()
	{
		if (YlEIZNroPZASSGNJjSlGDlLfJiz.NosALOCJZWSRRlLkYnXjziASvDO)
		{
			SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.HroijPAWawlYzgzgwVsdtnbRToN.NGXUBbcPdrBYfEJQGstImmQAGjsO(YlEIZNroPZASSGNJjSlGDlLfJiz);
		}
		SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.MapRlNrlPmmPNvjqcwKoYpYPCjw = MathTools.Clamp(DKaphJjYcOVsotWUZQeJpZZHeHI, -1f, 1f);
		if (!zQlPNEwerdNvUCLXMXvSaeCQpU.digitalAxisSimulation)
		{
			SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.yZnCjuBcgXKJRscwnPfOToSVNLO = SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.MapRlNrlPmmPNvjqcwKoYpYPCjw;
			if (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.HroijPAWawlYzgzgwVsdtnbRToN.NosALOCJZWSRRlLkYnXjziASvDO)
			{
				SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.HroijPAWawlYzgzgwVsdtnbRToN.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			}
			return;
		}
		if (!IzZFCqguxwAaZbgWIHNPupUWcZWh)
		{
			if (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.yZnCjuBcgXKJRscwnPfOToSVNLO == 0f)
			{
				return;
			}
			float digitalAxisGravity = zQlPNEwerdNvUCLXMXvSaeCQpU.digitalAxisGravity;
			if (digitalAxisGravity != 0f)
			{
				float num = zQlPNEwerdNvUCLXMXvSaeCQpU.digitalAxisGravity * rsIsvuyohiSXvmTdTmaszbehYjV;
				if (MathTools.Abs(num) >= MathTools.Abs(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.yZnCjuBcgXKJRscwnPfOToSVNLO))
				{
					SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.yZnCjuBcgXKJRscwnPfOToSVNLO = 0f;
					SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.HroijPAWawlYzgzgwVsdtnbRToN.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
					return;
				}
				float num2 = ((SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.yZnCjuBcgXKJRscwnPfOToSVNLO > 0f) ? (-1f) : 1f);
				SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.yZnCjuBcgXKJRscwnPfOToSVNLO = MathTools.Clamp(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.yZnCjuBcgXKJRscwnPfOToSVNLO + num2 * num, -1f, 1f);
				PASInWXkNNmEwyEmMgFltCXsgqq hroijPAWawlYzgzgwVsdtnbRToN = SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.HroijPAWawlYzgzgwVsdtnbRToN;
				hYEDsbfHjWpxuVCufRoaqQStbvgX(hroijPAWawlYzgzgwVsdtnbRToN.FKtcxmBappHTSHGoccIYREwbpfog, hroijPAWawlYzgzgwVsdtnbRToN.nuUgjEKzUuMYBIiHUtitJvzUOOl, hroijPAWawlYzgzgwVsdtnbRToN.PgtyCGUpZbAlPcnBMkOdtmXxupEd);
			}
			return;
		}
		float num3 = MathTools.Clamp(DKaphJjYcOVsotWUZQeJpZZHeHI, -1f, 1f);
		float num4 = ((num3 != 0f) ? MathTools.Sign(num3) : 0f);
		float num5 = ((SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.yZnCjuBcgXKJRscwnPfOToSVNLO != 0f) ? MathTools.Sign(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.yZnCjuBcgXKJRscwnPfOToSVNLO) : 0f);
		float digitalAxisSensitivity = zQlPNEwerdNvUCLXMXvSaeCQpU.digitalAxisSensitivity;
		if (digitalAxisSensitivity > 0f)
		{
			num3 *= digitalAxisSensitivity * rsIsvuyohiSXvmTdTmaszbehYjV;
		}
		if (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.yZnCjuBcgXKJRscwnPfOToSVNLO != 0f)
		{
			if ((num3 != 0f && num4 != num5) ? true : false)
			{
				if (zQlPNEwerdNvUCLXMXvSaeCQpU.digitalAxisInstantReverse)
				{
					num3 += -1f * SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.yZnCjuBcgXKJRscwnPfOToSVNLO;
				}
				else if (!zQlPNEwerdNvUCLXMXvSaeCQpU.digitalAxisSnap)
				{
					num3 += SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.yZnCjuBcgXKJRscwnPfOToSVNLO;
				}
			}
			else
			{
				num3 += SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.yZnCjuBcgXKJRscwnPfOToSVNLO;
			}
		}
		else
		{
			num3 += SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.yZnCjuBcgXKJRscwnPfOToSVNLO;
		}
		SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.yZnCjuBcgXKJRscwnPfOToSVNLO = MathTools.Clamp(num3, -1f, 1f);
	}

	public float MUPgTaacHnwLRmoJOGqdcZFUrOL()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return 0f;
		}
		if (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.LijFMsBQaBMeyaBSULosMeSZIZpX == AxisCoordinateMode.Relative)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.ySNDGRIpQlQpKFddPugZhVCLbny;
		}
		return MathTools.MaxMagnitude(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.ySNDGRIpQlQpKFddPugZhVCLbny, SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.yZnCjuBcgXKJRscwnPfOToSVNLO);
	}

	public float yhRTsdEWjwmGOFpFVsccvsWQDxL()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return 0f;
		}
		if (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.OxabChjxtippqCQXpiTAvxJpMMzW == AxisCoordinateMode.Relative)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.PRMsxTDJDJDnoyZGKHOwQjACxxl;
		}
		return MathTools.MaxMagnitude(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.PRMsxTDJDJDnoyZGKHOwQjACxxl, SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.kQOapVRoWrExOsKQLiswrXxOKlg);
	}

	public float MxVwcGGHbhfnGaNVFIbAAyLbxvPW()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return 0f;
		}
		return MUPgTaacHnwLRmoJOGqdcZFUrOL() - yhRTsdEWjwmGOFpFVsccvsWQDxL();
	}

	public double ROFGAKBXkOUSJeiEwdoIaObzuwAv()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return 0.0;
		}
		return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.vAxisTimeActive;
	}

	public double XordwqAACJLMnlJHKUPRKMLQKpf()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			NvhfAudZhLuhPpUWceoIImxazKId();
		}
		return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.vAxisTimeInactive;
	}

	public AxisCoordinateMode YQlzAWiCZMlULuDcbVAWgHxwLnp()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.ySNDGRIpQlQpKFddPugZhVCLbny) >= MathTools.Abs(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.yZnCjuBcgXKJRscwnPfOToSVNLO))
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.LijFMsBQaBMeyaBSULosMeSZIZpX;
		}
		return AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode wrzdWLIoStIKtAegJzJFnwZdBuh()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.PRMsxTDJDJDnoyZGKHOwQjACxxl) >= MathTools.Abs(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.kQOapVRoWrExOsKQLiswrXxOKlg))
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.OxabChjxtippqCQXpiTAvxJpMMzW;
		}
		return AxisCoordinateMode.Absolute;
	}

	public float TXbcHqVYmBHhznWplhLLhIEHQBL()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return 0f;
		}
		if (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.LijFMsBQaBMeyaBSULosMeSZIZpX == AxisCoordinateMode.Relative)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.ySNDGRIpQlQpKFddPugZhVCLbny;
		}
		return MathTools.MaxMagnitude(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.ySNDGRIpQlQpKFddPugZhVCLbny, SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.MapRlNrlPmmPNvjqcwKoYpYPCjw);
	}

	public float MfSnbsPnoWwCjfydtGxjRngFzAj()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return 0f;
		}
		if (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.OxabChjxtippqCQXpiTAvxJpMMzW == AxisCoordinateMode.Relative)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.PRMsxTDJDJDnoyZGKHOwQjACxxl;
		}
		return MathTools.MaxMagnitude(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.PRMsxTDJDJDnoyZGKHOwQjACxxl, SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.TMoPpejkFOaGMERhLMQhteAyVBB);
	}

	public float foEYEhchSOmnmeJMLCbFaILSvQG()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return 0f;
		}
		return TXbcHqVYmBHhznWplhLLhIEHQBL() - MfSnbsPnoWwCjfydtGxjRngFzAj();
	}

	public double OspDFsiqCYnXKftWMMvwNmljEZeJ()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return 0.0;
		}
		return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.vAxisRawTimeActive;
	}

	public double QsPMxpiDfIBdQvNJUKjEgcEdDeIh()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			NvhfAudZhLuhPpUWceoIImxazKId();
		}
		return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.vAxisRawTimeInactive;
	}

	public AxisCoordinateMode vOVSrAcaeceLsbxuJNqiLFDYiMV()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.ySNDGRIpQlQpKFddPugZhVCLbny) >= MathTools.Abs(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.MapRlNrlPmmPNvjqcwKoYpYPCjw))
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.LijFMsBQaBMeyaBSULosMeSZIZpX;
		}
		return AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode OGNTTWyRbuqPgdvDWeihzMCoqOf()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.PRMsxTDJDJDnoyZGKHOwQjACxxl) >= MathTools.Abs(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.TMoPpejkFOaGMERhLMQhteAyVBB))
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.OxabChjxtippqCQXpiTAvxJpMMzW;
		}
		return AxisCoordinateMode.Absolute;
	}

	public bool JFLhhsViRZmASHFRAirmzVNMOhf()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (!LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue)
		{
			return (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.ZkOKkhijFfaSwJkzgQHVpjkjwyi & ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa) != 0;
		}
		if ((SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.ZkOKkhijFfaSwJkzgQHVpjkjwyi & ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa) == 0)
		{
			return gjvFsQfWVLkGJLUlHHOwfcVAxgI();
		}
		return true;
	}

	public bool CmwiIVrqfDqUrfdgDhwXnRxwqAE()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.GUWTkSxajHRoxnsVTIrekyZTkJG == null)
		{
			return OZnCSdYrbsHmUqpRMHVRQumZfNP();
		}
		if (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.GUWTkSxajHRoxnsVTIrekyZTkJG.running)
		{
			return true;
		}
		if (LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue && SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.frhLeRUVUgQUZJpngaySRPOfGZe.running)
		{
			return true;
		}
		return false;
	}

	public bool cpecOFaBXVFHwWEOrZWGPOEkoSMP()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (!LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue)
		{
			return (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.ZkOKkhijFfaSwJkzgQHVpjkjwyi & ButtonStateFlags.UQGNyIlHcyEjlcCTeYUyHSUqsWj) != 0;
		}
		if ((SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.ZkOKkhijFfaSwJkzgQHVpjkjwyi & ButtonStateFlags.UQGNyIlHcyEjlcCTeYUyHSUqsWj) == 0 && (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.tCJWNlINYkYQhdNRGoSqalwUkrg & ButtonStateFlags.UQGNyIlHcyEjlcCTeYUyHSUqsWj) == 0)
		{
			return false;
		}
		if ((SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.ZkOKkhijFfaSwJkzgQHVpjkjwyi & ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa) != ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh)
		{
			return false;
		}
		if ((SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.tCJWNlINYkYQhdNRGoSqalwUkrg & ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa) != ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh)
		{
			return false;
		}
		return true;
	}

	public bool QTLvXIaYFpPMOZfpIGILrPOecaW()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (!LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eBnnsbKKlvdroUItYZOyuiXoBfX.singlePressHold;
		}
		if (!SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eBnnsbKKlvdroUItYZOyuiXoBfX.singlePressHold)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eECSHXxdrjTqskjQSgxGAkEcSZHx.singlePressHold;
		}
		return true;
	}

	public bool PpZWnKYAyeadsuKqJmajERczqNY()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (!LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eBnnsbKKlvdroUItYZOyuiXoBfX.singlePressDown;
		}
		bool singlePressDown = SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eBnnsbKKlvdroUItYZOyuiXoBfX.singlePressDown;
		bool singlePressDown2 = SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eECSHXxdrjTqskjQSgxGAkEcSZHx.singlePressDown;
		if (!singlePressDown && !singlePressDown2)
		{
			return false;
		}
		if (!singlePressDown && SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eBnnsbKKlvdroUItYZOyuiXoBfX.singlePressHold)
		{
			return false;
		}
		if (!singlePressDown2 && SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eECSHXxdrjTqskjQSgxGAkEcSZHx.singlePressHold)
		{
			return false;
		}
		return true;
	}

	public bool ADNfTWTmfSlOGQjlvAAfCePfsin()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (!LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eBnnsbKKlvdroUItYZOyuiXoBfX.singlePressUp;
		}
		bool singlePressUp = SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eBnnsbKKlvdroUItYZOyuiXoBfX.singlePressUp;
		bool singlePressUp2 = SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eECSHXxdrjTqskjQSgxGAkEcSZHx.singlePressUp;
		if (!singlePressUp && !singlePressUp2)
		{
			return false;
		}
		if (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eBnnsbKKlvdroUItYZOyuiXoBfX.singlePressHold)
		{
			return false;
		}
		if (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eECSHXxdrjTqskjQSgxGAkEcSZHx.singlePressHold)
		{
			return false;
		}
		return true;
	}

	public bool UUZmGlAOcRhchLoNsdBteRISnEQE()
	{
		return UUZmGlAOcRhchLoNsdBteRISnEQE(0f);
	}

	public bool UUZmGlAOcRhchLoNsdBteRISnEQE(float P_0)
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (P_0 > 0f)
		{
			if (!LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue)
			{
				return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.QytMOarMSYVjuJhJUVBqsfQkLdK.qqoQTcwXGEOuvgOuoaHFIhKZOIw(P_0);
			}
			if (!SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.QytMOarMSYVjuJhJUVBqsfQkLdK.qqoQTcwXGEOuvgOuoaHFIhKZOIw(P_0))
			{
				return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.LvcFYcwEMiGxtCAfYFMrpxYrjVah.qqoQTcwXGEOuvgOuoaHFIhKZOIw(P_0);
			}
			return true;
		}
		if (!LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eBnnsbKKlvdroUItYZOyuiXoBfX.doublePressHold;
		}
		if (!SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eBnnsbKKlvdroUItYZOyuiXoBfX.doublePressHold)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eECSHXxdrjTqskjQSgxGAkEcSZHx.doublePressHold;
		}
		return true;
	}

	public bool iglKEgVKDfDRCUxquknahEhdtbQ()
	{
		return iglKEgVKDfDRCUxquknahEhdtbQ(0f);
	}

	public bool iglKEgVKDfDRCUxquknahEhdtbQ(float P_0)
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (!CmwiIVrqfDqUrfdgDhwXnRxwqAE())
		{
			return false;
		}
		if (!LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue)
		{
			if (P_0 > 0f)
			{
				return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.QytMOarMSYVjuJhJUVBqsfQkLdK.qqoQTcwXGEOuvgOuoaHFIhKZOIw(P_0);
			}
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eBnnsbKKlvdroUItYZOyuiXoBfX.doublePressHold;
		}
		if (P_0 > 0f)
		{
			if (!SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.QytMOarMSYVjuJhJUVBqsfQkLdK.qqoQTcwXGEOuvgOuoaHFIhKZOIw(P_0))
			{
				return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.LvcFYcwEMiGxtCAfYFMrpxYrjVah.qqoQTcwXGEOuvgOuoaHFIhKZOIw(P_0);
			}
			return true;
		}
		if (!SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eBnnsbKKlvdroUItYZOyuiXoBfX.doublePressHold)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eECSHXxdrjTqskjQSgxGAkEcSZHx.doublePressHold;
		}
		return true;
	}

	public bool pnzcIdXJrVISsrBwsrgSONYhjwk()
	{
		return pnzcIdXJrVISsrBwsrgSONYhjwk(0f);
	}

	public bool pnzcIdXJrVISsrBwsrgSONYhjwk(float P_0)
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (!cpecOFaBXVFHwWEOrZWGPOEkoSMP())
		{
			return false;
		}
		if (!LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue)
		{
			if (P_0 > 0f)
			{
				return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.QytMOarMSYVjuJhJUVBqsfQkLdK.khReyfaxYnVKatcOpyVRiAvmqwLx(P_0);
			}
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eBnnsbKKlvdroUItYZOyuiXoBfX.doublePressUp;
		}
		if (P_0 > 0f)
		{
			if (!SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.QytMOarMSYVjuJhJUVBqsfQkLdK.khReyfaxYnVKatcOpyVRiAvmqwLx(P_0))
			{
				return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.LvcFYcwEMiGxtCAfYFMrpxYrjVah.khReyfaxYnVKatcOpyVRiAvmqwLx(P_0);
			}
			return true;
		}
		if (!SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eBnnsbKKlvdroUItYZOyuiXoBfX.doublePressUp)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eECSHXxdrjTqskjQSgxGAkEcSZHx.doublePressUp;
		}
		return true;
	}

	public bool MJFiUNuBLTbsJUlFjOVlfkwzBgo(float P_0)
	{
		return MJFiUNuBLTbsJUlFjOVlfkwzBgo(P_0, 0f);
	}

	public bool MJFiUNuBLTbsJUlFjOVlfkwzBgo(float P_0, float P_1)
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
		}
		if (!JFLhhsViRZmASHFRAirmzVNMOhf())
		{
			return false;
		}
		double num = SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.vButtonTimePressed;
		if (LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue)
		{
			num = MathTools.Max(num, SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.negativeVButtonTimePressed);
		}
		if (num < (double)P_0)
		{
			return false;
		}
		if (P_1 > 0f && num >= (double)(P_0 + P_1))
		{
			return false;
		}
		return true;
	}

	public bool AhxzbaandODBCebugdYNafXSfVN(float P_0)
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (P_0 <= 0f)
		{
			return OZnCSdYrbsHmUqpRMHVRQumZfNP();
		}
		if (!JFLhhsViRZmASHFRAirmzVNMOhf())
		{
			return false;
		}
		if (!LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue)
		{
			ButtonStateRecorder qytMOarMSYVjuJhJUVBqsfQkLdK = SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.QytMOarMSYVjuJhJUVBqsfQkLdK;
			if (qytMOarMSYVjuJhJUVBqsfQkLdK.timePressed < (double)P_0)
			{
				return false;
			}
			if (ReInput.unscaledTimePrev - qytMOarMSYVjuJhJUVBqsfQkLdK.lastTimeUnpressed >= (double)P_0)
			{
				return false;
			}
			return true;
		}
		ButtonStateRecorder qytMOarMSYVjuJhJUVBqsfQkLdK2 = SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.QytMOarMSYVjuJhJUVBqsfQkLdK;
		ButtonStateRecorder lvcFYcwEMiGxtCAfYFMrpxYrjVah = SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.LvcFYcwEMiGxtCAfYFMrpxYrjVah;
		if (qytMOarMSYVjuJhJUVBqsfQkLdK2.timePressed < (double)P_0 && lvcFYcwEMiGxtCAfYFMrpxYrjVah.timePressed < (double)P_0)
		{
			return false;
		}
		if (ReInput.unscaledTimePrev - qytMOarMSYVjuJhJUVBqsfQkLdK2.lastTimeUnpressed >= (double)P_0 || ReInput.unscaledTimePrev - lvcFYcwEMiGxtCAfYFMrpxYrjVah.lastTimeUnpressed >= (double)P_0)
		{
			return false;
		}
		return true;
	}

	public bool JmakveFOtToTPFfcUGpGDreIVVz(float P_0)
	{
		return JmakveFOtToTPFfcUGpGDreIVVz(P_0, 0f);
	}

	public bool JmakveFOtToTPFfcUGpGDreIVVz(float P_0, float P_1)
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
		}
		if (!cpecOFaBXVFHwWEOrZWGPOEkoSMP())
		{
			return false;
		}
		if (!LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue)
		{
			double num = ReInput.unscaledTime - SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.QytMOarMSYVjuJhJUVBqsfQkLdK.lastTimeStateChangedToPressed;
			if (num < (double)P_0)
			{
				return false;
			}
			if (P_1 > 0f && num >= (double)(P_0 + P_1))
			{
				return false;
			}
			return true;
		}
		double num2 = ReInput.unscaledTime - MathTools.Max(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.QytMOarMSYVjuJhJUVBqsfQkLdK.lastTimeStateChangedToPressed, SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.LvcFYcwEMiGxtCAfYFMrpxYrjVah.lastTimeStateChangedToPressed);
		if (num2 < (double)P_0)
		{
			return false;
		}
		if (P_1 > 0f && num2 >= (double)(P_0 + P_1))
		{
			return false;
		}
		return true;
	}

	public bool TDNQHJbeFKJoDxwtrnohFGhnGia()
	{
		return MJFiUNuBLTbsJUlFjOVlfkwzBgo(zQlPNEwerdNvUCLXMXvSaeCQpU.buttonShortPressTime, zQlPNEwerdNvUCLXMXvSaeCQpU.buttonShortPressExpiresIn);
	}

	public bool SZLlYDUKPLfOpUVKZFqrIpeYOdq()
	{
		return AhxzbaandODBCebugdYNafXSfVN(zQlPNEwerdNvUCLXMXvSaeCQpU.buttonShortPressTime);
	}

	public bool uRjrrpPoOXyApRzAqZxwayRoyBU()
	{
		return JmakveFOtToTPFfcUGpGDreIVVz(zQlPNEwerdNvUCLXMXvSaeCQpU.buttonShortPressTime, zQlPNEwerdNvUCLXMXvSaeCQpU.buttonShortPressExpiresIn);
	}

	public bool DPQEfEAGIkMdCxLzhUjNTnVWWUN()
	{
		return MJFiUNuBLTbsJUlFjOVlfkwzBgo(zQlPNEwerdNvUCLXMXvSaeCQpU.buttonLongPressTime, zQlPNEwerdNvUCLXMXvSaeCQpU.buttonLongPressExpiresIn);
	}

	public bool UFEBQdeMjJKkVodijCmWCvPyPZJ()
	{
		return AhxzbaandODBCebugdYNafXSfVN(zQlPNEwerdNvUCLXMXvSaeCQpU.buttonLongPressTime);
	}

	public bool UuXvkSSlJNzydOxqRRfMzGOVYQy()
	{
		return JmakveFOtToTPFfcUGpGDreIVVz(zQlPNEwerdNvUCLXMXvSaeCQpU.buttonLongPressTime, zQlPNEwerdNvUCLXMXvSaeCQpU.buttonLongPressExpiresIn);
	}

	public bool xOVlFzhoZHfZzLUlrOuAqsoKUMU()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (!LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.cHDYAGjpPBgSRUdXYDRoshXrpyF.state;
		}
		if (!SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.cHDYAGjpPBgSRUdXYDRoshXrpyF.state)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.ufgHnxHlGWBFdzkmuBriMMqGUxA.state;
		}
		return true;
	}

	public bool NyQDvOIzDpkRBsleftaSWfWiBaUD()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (!LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue)
		{
			return (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.kJpRshcmvkDLHSyHwGmqfpuOmup & ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa) != 0;
		}
		if ((SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.kJpRshcmvkDLHSyHwGmqfpuOmup & ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa) == 0)
		{
			return tWNGjrHjjCtCJlLkJMXkyfcwFWa();
		}
		return true;
	}

	public double eJIkDJIkPHkALOKPLNjWUzeoogP()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return 0.0;
		}
		if (!LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.vButtonTimePressed;
		}
		return MathTools.Max(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.vButtonTimePressed, SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.negativeVButtonTimePressed);
	}

	public double MiBhFkgQyEvQDqNzuybFYrVQgkac()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			NvhfAudZhLuhPpUWceoIImxazKId();
		}
		if (!LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.vButtonTimeUnpressed;
		}
		return MathTools.Min(SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.vButtonTimeUnpressed, SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.negativeVButtonTimeUnpressed);
	}

	private bool OZnCSdYrbsHmUqpRMHVRQumZfNP()
	{
		if (!LOkMduUeVwqIadHuBlHhVcCnHqW.activateActionButtonsOnNegativeValue)
		{
			return (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.ZkOKkhijFfaSwJkzgQHVpjkjwyi & ButtonStateFlags.ppYdXkDrMSlYvDAaCqFoehbWDwU) != 0;
		}
		if ((SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.ZkOKkhijFfaSwJkzgQHVpjkjwyi & ButtonStateFlags.ppYdXkDrMSlYvDAaCqFoehbWDwU) == 0 && (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.tCJWNlINYkYQhdNRGoSqalwUkrg & ButtonStateFlags.ppYdXkDrMSlYvDAaCqFoehbWDwU) == 0)
		{
			return false;
		}
		if ((SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.ZkOKkhijFfaSwJkzgQHVpjkjwyi & ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa) != ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh && (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.ZkOKkhijFfaSwJkzgQHVpjkjwyi & ButtonStateFlags.ppYdXkDrMSlYvDAaCqFoehbWDwU) == 0)
		{
			return false;
		}
		if ((SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.tCJWNlINYkYQhdNRGoSqalwUkrg & ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa) != ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh && (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.tCJWNlINYkYQhdNRGoSqalwUkrg & ButtonStateFlags.ppYdXkDrMSlYvDAaCqFoehbWDwU) == 0)
		{
			return false;
		}
		return true;
	}

	public bool gjvFsQfWVLkGJLUlHHOwfcVAxgI()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		return (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.tCJWNlINYkYQhdNRGoSqalwUkrg & ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa) != 0;
	}

	public bool wiPVOSjfQFqDVBfmgbvuPukNqlZ()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.frhLeRUVUgQUZJpngaySRPOfGZe == null)
		{
			return PNHdOVeiOALymEezWcCUCTQWqHL();
		}
		if (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.frhLeRUVUgQUZJpngaySRPOfGZe.running)
		{
			return true;
		}
		return false;
	}

	public bool lSoChdolRrcjvhCMgWkTNuSJzJM()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		return (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.tCJWNlINYkYQhdNRGoSqalwUkrg & ButtonStateFlags.UQGNyIlHcyEjlcCTeYUyHSUqsWj) != 0;
	}

	public bool wfyKocGkSJJKuvaaDQlbFFZlulI()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eECSHXxdrjTqskjQSgxGAkEcSZHx.singlePressHold;
	}

	public bool rNxXdvHMHaWDHmdpbxJrhVReEuF()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eECSHXxdrjTqskjQSgxGAkEcSZHx.singlePressDown;
	}

	public bool LzYqCFtmOAPwFtaNIIAsdeKJjuUW()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eECSHXxdrjTqskjQSgxGAkEcSZHx.singlePressUp;
	}

	public bool agUAqgemdZpaKOMTCmtHqKZcEwxg()
	{
		return agUAqgemdZpaKOMTCmtHqKZcEwxg(0f);
	}

	public bool agUAqgemdZpaKOMTCmtHqKZcEwxg(float P_0)
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (P_0 > 0f)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.LvcFYcwEMiGxtCAfYFMrpxYrjVah.qqoQTcwXGEOuvgOuoaHFIhKZOIw(P_0);
		}
		return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eECSHXxdrjTqskjQSgxGAkEcSZHx.doublePressHold;
	}

	public bool wvfXZLJtMOTHRZqKjHcKgEZqIhQy()
	{
		return wvfXZLJtMOTHRZqKjHcKgEZqIhQy(0f);
	}

	public bool wvfXZLJtMOTHRZqKjHcKgEZqIhQy(float P_0)
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (!wiPVOSjfQFqDVBfmgbvuPukNqlZ())
		{
			return false;
		}
		if (P_0 > 0f)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.LvcFYcwEMiGxtCAfYFMrpxYrjVah.qqoQTcwXGEOuvgOuoaHFIhKZOIw(P_0);
		}
		return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eECSHXxdrjTqskjQSgxGAkEcSZHx.doublePressHold;
	}

	public bool KCcpdVlzpCIiXRUPqJoMFQeqdHsG()
	{
		return KCcpdVlzpCIiXRUPqJoMFQeqdHsG(0f);
	}

	public bool KCcpdVlzpCIiXRUPqJoMFQeqdHsG(float P_0)
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (!lSoChdolRrcjvhCMgWkTNuSJzJM())
		{
			return false;
		}
		if (P_0 > 0f)
		{
			return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.LvcFYcwEMiGxtCAfYFMrpxYrjVah.khReyfaxYnVKatcOpyVRiAvmqwLx(P_0);
		}
		return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.eECSHXxdrjTqskjQSgxGAkEcSZHx.doublePressUp;
	}

	public bool HgLItgBCWBsCCYWNBKmKgGDoubH(float P_0)
	{
		return HgLItgBCWBsCCYWNBKmKgGDoubH(P_0, 0f);
	}

	public bool HgLItgBCWBsCCYWNBKmKgGDoubH(float P_0, float P_1)
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
		}
		if (!gjvFsQfWVLkGJLUlHHOwfcVAxgI())
		{
			return false;
		}
		double negativeVButtonTimePressed = SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.negativeVButtonTimePressed;
		if (negativeVButtonTimePressed < (double)P_0)
		{
			return false;
		}
		if (P_1 > 0f && negativeVButtonTimePressed >= (double)(P_0 + P_1))
		{
			return false;
		}
		return true;
	}

	public bool cDGRdmSKZRTpXeZTLCaInrAktM(float P_0)
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (P_0 <= 0f)
		{
			return PNHdOVeiOALymEezWcCUCTQWqHL();
		}
		if (!gjvFsQfWVLkGJLUlHHOwfcVAxgI())
		{
			return false;
		}
		ButtonStateRecorder lvcFYcwEMiGxtCAfYFMrpxYrjVah = SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.LvcFYcwEMiGxtCAfYFMrpxYrjVah;
		if (lvcFYcwEMiGxtCAfYFMrpxYrjVah.timePressed < (double)P_0)
		{
			return false;
		}
		if (ReInput.unscaledTimePrev - lvcFYcwEMiGxtCAfYFMrpxYrjVah.lastTimeUnpressed >= (double)P_0)
		{
			return false;
		}
		return true;
	}

	public bool rwPIJlCPHsrUNNKCobpqYFjHDAa(float P_0)
	{
		return rwPIJlCPHsrUNNKCobpqYFjHDAa(P_0, 0f);
	}

	public bool rwPIJlCPHsrUNNKCobpqYFjHDAa(float P_0, float P_1)
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
		}
		if (!lSoChdolRrcjvhCMgWkTNuSJzJM())
		{
			return false;
		}
		double num = ReInput.unscaledTime - SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.LvcFYcwEMiGxtCAfYFMrpxYrjVah.lastTimeStateChangedToPressed;
		if (num < (double)P_0)
		{
			return false;
		}
		if (P_1 > 0f && num >= (double)(P_0 + P_1))
		{
			return false;
		}
		return true;
	}

	public bool nHowdczhJjGQpHoPuhSaxofMeXU()
	{
		return HgLItgBCWBsCCYWNBKmKgGDoubH(zQlPNEwerdNvUCLXMXvSaeCQpU.buttonShortPressTime, zQlPNEwerdNvUCLXMXvSaeCQpU.buttonShortPressExpiresIn);
	}

	public bool QfazomiUZJqoaCvaEoGdIyvImmi()
	{
		return cDGRdmSKZRTpXeZTLCaInrAktM(zQlPNEwerdNvUCLXMXvSaeCQpU.buttonShortPressTime);
	}

	public bool RBTuBJtXUddlICbnuMOEmSITWbP()
	{
		return rwPIJlCPHsrUNNKCobpqYFjHDAa(zQlPNEwerdNvUCLXMXvSaeCQpU.buttonShortPressTime, zQlPNEwerdNvUCLXMXvSaeCQpU.buttonShortPressExpiresIn);
	}

	public bool AoOcxpYeHjMNEyQbNoVoYGGKEYs()
	{
		return HgLItgBCWBsCCYWNBKmKgGDoubH(zQlPNEwerdNvUCLXMXvSaeCQpU.buttonLongPressTime, zQlPNEwerdNvUCLXMXvSaeCQpU.buttonLongPressExpiresIn);
	}

	public bool DDgdmSGHKLLlIOmMiTkGuXLuBNc()
	{
		return cDGRdmSKZRTpXeZTLCaInrAktM(zQlPNEwerdNvUCLXMXvSaeCQpU.buttonLongPressTime);
	}

	public bool JGzwiBNdgTVqoMIKduxivCKdvVw()
	{
		return rwPIJlCPHsrUNNKCobpqYFjHDAa(zQlPNEwerdNvUCLXMXvSaeCQpU.buttonLongPressTime, zQlPNEwerdNvUCLXMXvSaeCQpU.buttonLongPressExpiresIn);
	}

	public bool pXXQSEbZHuROokYgEnrXGPzdGtEF()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.ufgHnxHlGWBFdzkmuBriMMqGUxA.state;
	}

	public bool tWNGjrHjjCtCJlLkJMXkyfcwFWa()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return false;
		}
		return (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.iFAcjjFjPdmeITJuglsileyTQdKR & ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa) != 0;
	}

	public double DhArtyydFWSPilbKMhnJVHChwHy()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			return 0.0;
		}
		return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.negativeVButtonTimePressed;
	}

	public double BfgghzcXbdXcPKaJgTuZMqYCxjg()
	{
		if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
		{
			NvhfAudZhLuhPpUWceoIImxazKId();
		}
		return SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.negativeVButtonTimeUnpressed;
	}

	private bool PNHdOVeiOALymEezWcCUCTQWqHL()
	{
		return (SDGPnTyJBledggiEkINiOCYmeOkD.TrWUdtjebjTxiTudwuGvXSlDJgg.tCJWNlINYkYQhdNRGoSqalwUkrg & ButtonStateFlags.ppYdXkDrMSlYvDAaCqFoehbWDwU) != 0;
	}

	public void JWSNHsnEKntQzajLBtUESPRKDeF()
	{
		for (int i = 0; i < SDGPnTyJBledggiEkINiOCYmeOkD.KKxvXzhbFzmenMQwioAojqUOeaj.Length; i++)
		{
			SDGPnTyJBledggiEkINiOCYmeOkD.KKxvXzhbFzmenMQwioAojqUOeaj[i].GUWTkSxajHRoxnsVTIrekyZTkJG.Clear();
			SDGPnTyJBledggiEkINiOCYmeOkD.KKxvXzhbFzmenMQwioAojqUOeaj[i].frhLeRUVUgQUZJpngaySRPOfGZe.Clear();
		}
	}

	internal InputActionEventData tNawgIhQaANJOrBkRFNFPViZPhI(UpdateLoopType P_0)
	{
		return new InputActionEventData(this, EpFfrTuakcvBKacoggaztTmGfrG, CYBGYVfPDvCydagiBzJBExAfcuYb, P_0);
	}

	public IList<InputActionSourceData> uvXaIVxGMrdmWpixZvZhiudfpZs()
	{
		if (!DOZWLFGKLcVXJpbdeblPVsgYfnzH)
		{
			ZGiatqgfSCAiRTZdeZggphzXCtbv();
		}
		return NwBXbItjMxYIglXGYORzvhQGsta;
	}

	public bool CEioayAKpkHgZSUoQlmVRVAagDk(ControllerType P_0)
	{
		if (!DOZWLFGKLcVXJpbdeblPVsgYfnzH)
		{
			uvXaIVxGMrdmWpixZvZhiudfpZs();
		}
		for (int i = 0; i < etLgPXbDjDbbhRQTPZEDckBFjNj; i++)
		{
			if (HKgPJczASLIFOLNNZURaNgyDgoI[i].FKtcxmBappHTSHGoccIYREwbpfog.type == P_0)
			{
				return true;
			}
		}
		return false;
	}

	public bool CEioayAKpkHgZSUoQlmVRVAagDk(ControllerType P_0, int P_1)
	{
		if (!DOZWLFGKLcVXJpbdeblPVsgYfnzH)
		{
			uvXaIVxGMrdmWpixZvZhiudfpZs();
		}
		for (int i = 0; i < etLgPXbDjDbbhRQTPZEDckBFjNj; i++)
		{
			Controller fKtcxmBappHTSHGoccIYREwbpfog = HKgPJczASLIFOLNNZURaNgyDgoI[i].FKtcxmBappHTSHGoccIYREwbpfog;
			if (fKtcxmBappHTSHGoccIYREwbpfog.type == P_0 && fKtcxmBappHTSHGoccIYREwbpfog.id == P_1)
			{
				return true;
			}
		}
		return false;
	}

	public bool CEioayAKpkHgZSUoQlmVRVAagDk(Controller P_0)
	{
		if (!DOZWLFGKLcVXJpbdeblPVsgYfnzH)
		{
			uvXaIVxGMrdmWpixZvZhiudfpZs();
		}
		for (int i = 0; i < etLgPXbDjDbbhRQTPZEDckBFjNj; i++)
		{
			if (HKgPJczASLIFOLNNZURaNgyDgoI[i].FKtcxmBappHTSHGoccIYREwbpfog == P_0)
			{
				return true;
			}
		}
		return false;
	}

	internal void agvWMBoHtblzmgSmVloJbsDkfGk()
	{
		SDGPnTyJBledggiEkINiOCYmeOkD.agvWMBoHtblzmgSmVloJbsDkfGk();
	}

	private void ztehiAbBWLMJjiUjLbqrHIvSSTE()
	{
		if (YDCMgEhoqnecsKoQhySMgzvEdSwI == CIxBuEeASTjOkXSChHkrvFPOWiW.WQNdYJSAYYvmjxKbWASGxbAiIpYg)
		{
			fnmNyFDHvACriDqGjPNCMYYnpzE = true;
		}
		zeUqVPIDVWYcAggYWXLnNfyRBHX = CIxBuEeASTjOkXSChHkrvFPOWiW.bWiGnINBAKCCgAJdFTQNTISvBlW;
		IAPkqDUzQJdPHucoTqCGLiJSizt = true;
	}

	private void sMUgVFzNYCmMbTjSKBcLQHtNmmC(bool P_0)
	{
		SDGPnTyJBledggiEkINiOCYmeOkD.sMUgVFzNYCmMbTjSKBcLQHtNmmC();
		if (etLgPXbDjDbbhRQTPZEDckBFjNj > 0)
		{
			irZhnrPvoLKwgiNXCsjexFJjIpF();
		}
		zeUqVPIDVWYcAggYWXLnNfyRBHX = (P_0 ? CIxBuEeASTjOkXSChHkrvFPOWiW.RlAwwSywSSQUidrZslnSooSUgRN : CIxBuEeASTjOkXSChHkrvFPOWiW.WQNdYJSAYYvmjxKbWASGxbAiIpYg);
		IAPkqDUzQJdPHucoTqCGLiJSizt = false;
	}

	private void NvhfAudZhLuhPpUWceoIImxazKId()
	{
		SDGPnTyJBledggiEkINiOCYmeOkD.updateLoop = feXycwAOzGdljyeHjexWYpHVqTp;
	}

	private void irZhnrPvoLKwgiNXCsjexFJjIpF()
	{
		etLgPXbDjDbbhRQTPZEDckBFjNj = 0;
		if (DOZWLFGKLcVXJpbdeblPVsgYfnzH)
		{
			mwNQaEBNSkYgnutXqmDqcmYMFRN.Clear();
		}
	}

	private void hYEDsbfHjWpxuVCufRoaqQStbvgX(Controller P_0, ControllerMap P_1, ActionElementMap P_2)
	{
		if (etLgPXbDjDbbhRQTPZEDckBFjNj + 1 > HKgPJczASLIFOLNNZURaNgyDgoI.Length)
		{
			gUCUxdzKLYKdLrOnTaHdVATubCZ();
		}
		PASInWXkNNmEwyEmMgFltCXsgqq pASInWXkNNmEwyEmMgFltCXsgqq = HKgPJczASLIFOLNNZURaNgyDgoI[etLgPXbDjDbbhRQTPZEDckBFjNj];
		pASInWXkNNmEwyEmMgFltCXsgqq.NosALOCJZWSRRlLkYnXjziASvDO = true;
		pASInWXkNNmEwyEmMgFltCXsgqq.FKtcxmBappHTSHGoccIYREwbpfog = P_0;
		pASInWXkNNmEwyEmMgFltCXsgqq.nuUgjEKzUuMYBIiHUtitJvzUOOl = P_1;
		pASInWXkNNmEwyEmMgFltCXsgqq.PgtyCGUpZbAlPcnBMkOdtmXxupEd = P_2;
		etLgPXbDjDbbhRQTPZEDckBFjNj++;
	}

	private void gUCUxdzKLYKdLrOnTaHdVATubCZ()
	{
		ArrayTools.Expand(ref HKgPJczASLIFOLNNZURaNgyDgoI, 4);
		int num = etLgPXbDjDbbhRQTPZEDckBFjNj + 4;
		for (int i = etLgPXbDjDbbhRQTPZEDckBFjNj; i < num; i++)
		{
			HKgPJczASLIFOLNNZURaNgyDgoI[i] = new PASInWXkNNmEwyEmMgFltCXsgqq();
		}
	}

	private void ZGiatqgfSCAiRTZdeZggphzXCtbv()
	{
		if (!DOZWLFGKLcVXJpbdeblPVsgYfnzH)
		{
			DOZWLFGKLcVXJpbdeblPVsgYfnzH = true;
		}
		for (int i = 0; i < etLgPXbDjDbbhRQTPZEDckBFjNj; i++)
		{
			mwNQaEBNSkYgnutXqmDqcmYMFRN.Add(new InputActionSourceData(HKgPJczASLIFOLNNZURaNgyDgoI[i]));
		}
	}

	private static void ixpYSWaqAyxNDXvnQiwkmezGFGW(ref ButtonStateFlags P_0, ButtonStateFlags P_1)
	{
		if (P_0 == ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh)
		{
			P_0 = P_1;
		}
		else if ((P_1 & ButtonStateFlags.ppYdXkDrMSlYvDAaCqFoehbWDwU) != ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh)
		{
			if ((P_0 & ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa) == 0 || (P_0 & ButtonStateFlags.ppYdXkDrMSlYvDAaCqFoehbWDwU) != ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh)
			{
				P_0 = ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa | ButtonStateFlags.ppYdXkDrMSlYvDAaCqFoehbWDwU;
			}
		}
		else if ((P_1 & ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa) != ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh)
		{
			P_0 = ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa;
		}
	}
}
