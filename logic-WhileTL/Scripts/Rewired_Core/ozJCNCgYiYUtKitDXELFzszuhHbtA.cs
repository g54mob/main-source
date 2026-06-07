using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class ozJCNCgYiYUtKitDXELFzszuhHbtA
{
	private class sWcWZjEwrDbaFkLmHcgiRUwDlwPC
	{
		private readonly AList<IControllerTemplate> yStgeWABMBrpmQklPqcEgwUnhfhE;

		private IList UzjSTMiTkmfUboWWTffFIBgPXGnu;

		private IList datfiVhkMSUdSuBKSZjZiHdBfyxHA;

		public readonly Type znvDEmuGvKVGSdBvMcCkiViHjgxuA;

		public sWcWZjEwrDbaFkLmHcgiRUwDlwPC(Type P_0)
		{
			znvDEmuGvKVGSdBvMcCkiViHjgxuA = P_0;
			yStgeWABMBrpmQklPqcEgwUnhfhE = new AList<IControllerTemplate>();
		}

		public IList<_0001> tWtWyiwhraIpSCZoPgyYnIEdINde<_0001>() where _0001 : IControllerTemplate
		{
			if (UzjSTMiTkmfUboWWTffFIBgPXGnu == null)
			{
				gZLcrCVdqwsOTrFVWzqlxCqkVdCn<_0001>();
			}
			return datfiVhkMSUdSuBKSZjZiHdBfyxHA as IList<_0001>;
		}

		public void ObmRPnBAXLGPNSMVFccJbPKCnMoh(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				yStgeWABMBrpmQklPqcEgwUnhfhE.Add(P_0);
				if (UzjSTMiTkmfUboWWTffFIBgPXGnu != null)
				{
					UzjSTMiTkmfUboWWTffFIBgPXGnu.Add(P_0);
				}
			}
		}

		public void hZGQqfkCleotngNoRVwWiwgaxpqJ(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				yStgeWABMBrpmQklPqcEgwUnhfhE.Remove(P_0);
				if (UzjSTMiTkmfUboWWTffFIBgPXGnu != null)
				{
					UzjSTMiTkmfUboWWTffFIBgPXGnu.Remove(P_0);
				}
			}
		}

		private void gZLcrCVdqwsOTrFVWzqlxCqkVdCn<_0001>() where _0001 : IControllerTemplate
		{
			UzjSTMiTkmfUboWWTffFIBgPXGnu = new AList<_0001>();
			datfiVhkMSUdSuBKSZjZiHdBfyxHA = new ReadOnlyCollection<_0001>((AList<_0001>)UzjSTMiTkmfUboWWTffFIBgPXGnu);
			for (int i = 0; i < yStgeWABMBrpmQklPqcEgwUnhfhE._count; i++)
			{
				UzjSTMiTkmfUboWWTffFIBgPXGnu.Add(yStgeWABMBrpmQklPqcEgwUnhfhE._items[i]);
			}
		}
	}

	private readonly AList<sWcWZjEwrDbaFkLmHcgiRUwDlwPC> dJsDpGEjafNELocKBNFILiVaQTEP;

	private readonly Type[] WXTgAAfENEsTTOHwiXQcbbbYITVo;

	private readonly Type[] mxoAKAdepPwpgEkFOcoIwAgVwUPoA;

	private readonly int EidAtDURxZmbULWHDErvQICZbRNx;

	public ozJCNCgYiYUtKitDXELFzszuhHbtA(Type[] P_0, Type[] P_1)
	{
		if (P_0.Length != P_1.Length)
		{
			throw new Exception("Controller template types and controller template interface types array lengths do not match.");
		}
		WXTgAAfENEsTTOHwiXQcbbbYITVo = P_0;
		mxoAKAdepPwpgEkFOcoIwAgVwUPoA = P_1;
		EidAtDURxZmbULWHDErvQICZbRNx = WXTgAAfENEsTTOHwiXQcbbbYITVo.Length;
		dJsDpGEjafNELocKBNFILiVaQTEP = new AList<sWcWZjEwrDbaFkLmHcgiRUwDlwPC>();
		for (int i = 0; i < EidAtDURxZmbULWHDErvQICZbRNx; i++)
		{
			dJsDpGEjafNELocKBNFILiVaQTEP.Add(new sWcWZjEwrDbaFkLmHcgiRUwDlwPC(mxoAKAdepPwpgEkFOcoIwAgVwUPoA[i]));
		}
	}

	public void rGVWdbmPmKnjVBEVVakBlQfKAAd(Controller P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		int templateCount = P_0.templateCount;
		for (int i = 0; i < templateCount; i++)
		{
			IControllerTemplate controllerTemplate = P_0.Templates[i];
			if (controllerTemplate == null)
			{
				Logger.LogError("Template was null.");
				continue;
			}
			Type type = LNzwjCSihGVsSzTOiSksIaURPXws(controllerTemplate.GetType());
			if ((object)type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				gdWmOrQRVyoNtpwJtIIdORVqAzXX(type)?.ObmRPnBAXLGPNSMVFccJbPKCnMoh(controllerTemplate);
			}
		}
	}

	public void SxXykpNMIEhvyDiSjOwvEbWrniXR(Controller P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		int templateCount = P_0.templateCount;
		for (int i = 0; i < templateCount; i++)
		{
			IControllerTemplate controllerTemplate = P_0.Templates[i];
			if (controllerTemplate == null)
			{
				Logger.LogError("Template was null.");
				continue;
			}
			Type type = LNzwjCSihGVsSzTOiSksIaURPXws(controllerTemplate.GetType());
			if ((object)type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				gdWmOrQRVyoNtpwJtIIdORVqAzXX(type)?.hZGQqfkCleotngNoRVwWiwgaxpqJ(controllerTemplate);
			}
		}
	}

	public IList<_0001> tWtWyiwhraIpSCZoPgyYnIEdINde<_0001>() where _0001 : IControllerTemplate
	{
		Type typeFromHandle = typeof(_0001);
		for (int i = 0; i < dJsDpGEjafNELocKBNFILiVaQTEP._count; i++)
		{
			sWcWZjEwrDbaFkLmHcgiRUwDlwPC sWcWZjEwrDbaFkLmHcgiRUwDlwPC2 = dJsDpGEjafNELocKBNFILiVaQTEP._items[i];
			if ((object)sWcWZjEwrDbaFkLmHcgiRUwDlwPC2.znvDEmuGvKVGSdBvMcCkiViHjgxuA == typeFromHandle)
			{
				return sWcWZjEwrDbaFkLmHcgiRUwDlwPC2.tWtWyiwhraIpSCZoPgyYnIEdINde<_0001>();
			}
		}
		string text = "";
		for (int j = 0; j < mxoAKAdepPwpgEkFOcoIwAgVwUPoA.Length; j++)
		{
			text += mxoAKAdepPwpgEkFOcoIwAgVwUPoA[j].Name;
			if (j != mxoAKAdepPwpgEkFOcoIwAgVwUPoA.Length - 1)
			{
				text += "\n";
			}
		}
		Logger.LogError("Invalid Controller Template type \"" + typeFromHandle.Name + "\". Only the following Controller Template interface types are allowed:\n" + text);
		return EmptyObjects<_0001>.EmptyReadOnlyIListT;
	}

	private sWcWZjEwrDbaFkLmHcgiRUwDlwPC gdWmOrQRVyoNtpwJtIIdORVqAzXX(Type P_0)
	{
		for (int i = 0; i < dJsDpGEjafNELocKBNFILiVaQTEP._count; i++)
		{
			if ((object)P_0 == dJsDpGEjafNELocKBNFILiVaQTEP._items[i].znvDEmuGvKVGSdBvMcCkiViHjgxuA)
			{
				return dJsDpGEjafNELocKBNFILiVaQTEP._items[i];
			}
		}
		return null;
	}

	private Type LNzwjCSihGVsSzTOiSksIaURPXws(Type P_0)
	{
		for (int i = 0; i < EidAtDURxZmbULWHDErvQICZbRNx; i++)
		{
			if ((object)WXTgAAfENEsTTOHwiXQcbbbYITVo[i] == P_0)
			{
				return mxoAKAdepPwpgEkFOcoIwAgVwUPoA[i];
			}
		}
		return null;
	}
}
