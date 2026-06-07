using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class OjcmMGKoEtsDrpMbbivWBgdDESNv
{
	private class WJNHEfCEAkfNakChtWTpqmWkCgvkA
	{
		private readonly AList<IControllerTemplate> pHajGVmzGZAAwrXcPqhCipqputUw;

		private IList rKoHUiaiHIcbhdEECbUTwWJGpznM;

		private IList lgKwOuNotHliSjKtTzBTPqKJuRrv;

		public readonly Type FandxKHEgMbvMCgihlvVPlFQFYHnb;

		public WJNHEfCEAkfNakChtWTpqmWkCgvkA(Type P_0)
		{
			FandxKHEgMbvMCgihlvVPlFQFYHnb = P_0;
			pHajGVmzGZAAwrXcPqhCipqputUw = new AList<IControllerTemplate>();
		}

		public IList<_0001> ChgqnpiYpqFkXiHRaBzukPbRbQYZ<_0001>() where _0001 : IControllerTemplate
		{
			if (rKoHUiaiHIcbhdEECbUTwWJGpznM == null)
			{
				pNMUrBgIjBgCuhvFYhZqfEJIkRchB<_0001>();
			}
			return lgKwOuNotHliSjKtTzBTPqKJuRrv as IList<_0001>;
		}

		public void wzXggIKkxhsrawvnQjGZdzqcgvhhc(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				pHajGVmzGZAAwrXcPqhCipqputUw.Add(P_0);
				if (rKoHUiaiHIcbhdEECbUTwWJGpznM != null)
				{
					rKoHUiaiHIcbhdEECbUTwWJGpznM.Add(P_0);
				}
			}
		}

		public void KPHBOtemfYchhRUvZkqhgqZNndjyA(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				pHajGVmzGZAAwrXcPqhCipqputUw.Remove(P_0);
				if (rKoHUiaiHIcbhdEECbUTwWJGpznM != null)
				{
					rKoHUiaiHIcbhdEECbUTwWJGpznM.Remove(P_0);
				}
			}
		}

		private void pNMUrBgIjBgCuhvFYhZqfEJIkRchB<_0001>() where _0001 : IControllerTemplate
		{
			rKoHUiaiHIcbhdEECbUTwWJGpznM = new AList<_0001>();
			lgKwOuNotHliSjKtTzBTPqKJuRrv = new ReadOnlyCollection<_0001>((AList<_0001>)rKoHUiaiHIcbhdEECbUTwWJGpznM);
			for (int i = 0; i < pHajGVmzGZAAwrXcPqhCipqputUw._count; i++)
			{
				rKoHUiaiHIcbhdEECbUTwWJGpznM.Add(pHajGVmzGZAAwrXcPqhCipqputUw._items[i]);
			}
		}
	}

	private readonly AList<WJNHEfCEAkfNakChtWTpqmWkCgvkA> PFMcwutUSncXIGyvghqKFjmFPAXuA;

	private readonly Type[] dQVusPTHEHiBBjmYHmjZvKuIUzzZ;

	private readonly Type[] cPxTtpMIoGxATxEdueLtawYfNFTFA;

	private readonly int gdRmtRvdfaYhVasgeQNJsMYrPOnH;

	public OjcmMGKoEtsDrpMbbivWBgdDESNv(Type[] P_0, Type[] P_1)
	{
		if (P_0.Length != P_1.Length)
		{
			throw new Exception("Controller template types and controller template interface types array lengths do not match.");
		}
		dQVusPTHEHiBBjmYHmjZvKuIUzzZ = P_0;
		cPxTtpMIoGxATxEdueLtawYfNFTFA = P_1;
		gdRmtRvdfaYhVasgeQNJsMYrPOnH = dQVusPTHEHiBBjmYHmjZvKuIUzzZ.Length;
		PFMcwutUSncXIGyvghqKFjmFPAXuA = new AList<WJNHEfCEAkfNakChtWTpqmWkCgvkA>();
		for (int i = 0; i < gdRmtRvdfaYhVasgeQNJsMYrPOnH; i++)
		{
			PFMcwutUSncXIGyvghqKFjmFPAXuA.Add(new WJNHEfCEAkfNakChtWTpqmWkCgvkA(cPxTtpMIoGxATxEdueLtawYfNFTFA[i]));
		}
	}

	public void mcsxbweWRGUKtgrASoFyRmtDKWxj(Controller P_0)
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
			Type type = nHySDXdRJTcCKtqgSFCeSkFjqaeg(controllerTemplate.GetType());
			if (type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				MPvfUubaFxhWdzAwsFoJAkqmUXStA(type)?.wzXggIKkxhsrawvnQjGZdzqcgvhhc(controllerTemplate);
			}
		}
	}

	public void HOZrlIfnvifRuONAxZciwsfqtFKU(Controller P_0)
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
			Type type = nHySDXdRJTcCKtqgSFCeSkFjqaeg(controllerTemplate.GetType());
			if (type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				MPvfUubaFxhWdzAwsFoJAkqmUXStA(type)?.KPHBOtemfYchhRUvZkqhgqZNndjyA(controllerTemplate);
			}
		}
	}

	public IList<_0001> SCJuuKoJjCugoMTQgClkGCmJsHoD<_0001>() where _0001 : IControllerTemplate
	{
		Type typeFromHandle = typeof(_0001);
		for (int i = 0; i < PFMcwutUSncXIGyvghqKFjmFPAXuA._count; i++)
		{
			WJNHEfCEAkfNakChtWTpqmWkCgvkA wJNHEfCEAkfNakChtWTpqmWkCgvkA = PFMcwutUSncXIGyvghqKFjmFPAXuA._items[i];
			if ((object)wJNHEfCEAkfNakChtWTpqmWkCgvkA.FandxKHEgMbvMCgihlvVPlFQFYHnb == typeFromHandle)
			{
				return wJNHEfCEAkfNakChtWTpqmWkCgvkA.ChgqnpiYpqFkXiHRaBzukPbRbQYZ<_0001>();
			}
		}
		string text = "";
		for (int j = 0; j < cPxTtpMIoGxATxEdueLtawYfNFTFA.Length; j++)
		{
			text += cPxTtpMIoGxATxEdueLtawYfNFTFA[j].Name;
			if (j != cPxTtpMIoGxATxEdueLtawYfNFTFA.Length - 1)
			{
				text += "\n";
			}
		}
		Logger.LogError("Invalid Controller Template type \"" + typeFromHandle.Name + "\". Only the following Controller Template interface types are allowed:\n" + text);
		return EmptyObjects<_0001>.EmptyReadOnlyIListT;
	}

	private WJNHEfCEAkfNakChtWTpqmWkCgvkA MPvfUubaFxhWdzAwsFoJAkqmUXStA(Type P_0)
	{
		for (int i = 0; i < PFMcwutUSncXIGyvghqKFjmFPAXuA._count; i++)
		{
			if ((object)P_0 == PFMcwutUSncXIGyvghqKFjmFPAXuA._items[i].FandxKHEgMbvMCgihlvVPlFQFYHnb)
			{
				return PFMcwutUSncXIGyvghqKFjmFPAXuA._items[i];
			}
		}
		return null;
	}

	private Type nHySDXdRJTcCKtqgSFCeSkFjqaeg(Type P_0)
	{
		for (int i = 0; i < gdRmtRvdfaYhVasgeQNJsMYrPOnH; i++)
		{
			if ((object)dQVusPTHEHiBBjmYHmjZvKuIUzzZ[i] == P_0)
			{
				return cPxTtpMIoGxATxEdueLtawYfNFTFA[i];
			}
		}
		return null;
	}
}
