using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class YTvdJthXdoAvuaeWVmMDxzYuGHkq
{
	private class IyKrMEphrrfzhbvWHFbsDCnHstQPA
	{
		private readonly AList<IControllerTemplate> pYfDEyZTfSwTvqLJpFdVCjZIsGrH;

		private IList pynJKBHweRWxqgZpcgMMIKovyKEk;

		private IList xaFPFteYFMQJVgWzxfPOvdbmUvYD;

		public readonly Type FdiiTlfXVLJzPxPNTXLGNkzwRned;

		public IyKrMEphrrfzhbvWHFbsDCnHstQPA(Type P_0)
		{
			FdiiTlfXVLJzPxPNTXLGNkzwRned = P_0;
			pYfDEyZTfSwTvqLJpFdVCjZIsGrH = new AList<IControllerTemplate>();
		}

		public IList<_0001> KwhknMTGUlSRCzHmKbRjOlEowFzv<_0001>() where _0001 : IControllerTemplate
		{
			if (pynJKBHweRWxqgZpcgMMIKovyKEk == null)
			{
				nvFeeoTKFAkRrmiTqpjrmmTHGTNe<_0001>();
			}
			return xaFPFteYFMQJVgWzxfPOvdbmUvYD as IList<_0001>;
		}

		public void mIWrljXUZiVJzmAukggYJZcZyHGC(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				pYfDEyZTfSwTvqLJpFdVCjZIsGrH.Add(P_0);
				if (pynJKBHweRWxqgZpcgMMIKovyKEk != null)
				{
					pynJKBHweRWxqgZpcgMMIKovyKEk.Add(P_0);
				}
			}
		}

		public void YnCHMQZJYHNocDKttSfkKDmmuPMF(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				pYfDEyZTfSwTvqLJpFdVCjZIsGrH.Remove(P_0);
				if (pynJKBHweRWxqgZpcgMMIKovyKEk != null)
				{
					pynJKBHweRWxqgZpcgMMIKovyKEk.Remove(P_0);
				}
			}
		}

		private void nvFeeoTKFAkRrmiTqpjrmmTHGTNe<_0001>() where _0001 : IControllerTemplate
		{
			pynJKBHweRWxqgZpcgMMIKovyKEk = new AList<_0001>();
			xaFPFteYFMQJVgWzxfPOvdbmUvYD = new ReadOnlyCollection<_0001>((AList<_0001>)pynJKBHweRWxqgZpcgMMIKovyKEk);
			for (int i = 0; i < pYfDEyZTfSwTvqLJpFdVCjZIsGrH._count; i++)
			{
				pynJKBHweRWxqgZpcgMMIKovyKEk.Add(pYfDEyZTfSwTvqLJpFdVCjZIsGrH._items[i]);
			}
		}
	}

	private readonly AList<IyKrMEphrrfzhbvWHFbsDCnHstQPA> TZLdETEJpejvNzIAAYdVTODkDIgJ;

	private readonly Type[] dNQfBmybMItDOrEjhXvMwTHvibGL;

	private readonly Type[] emsaYWjNHFwaAqKvMrOcQrfOMsse;

	private readonly int gaYCbudCKrFuKShTShmCgSlYuQUxA;

	public YTvdJthXdoAvuaeWVmMDxzYuGHkq(Type[] P_0, Type[] P_1)
	{
		if (P_0.Length != P_1.Length)
		{
			throw new Exception("Controller template types and controller template interface types array lengths do not match.");
		}
		dNQfBmybMItDOrEjhXvMwTHvibGL = P_0;
		emsaYWjNHFwaAqKvMrOcQrfOMsse = P_1;
		gaYCbudCKrFuKShTShmCgSlYuQUxA = dNQfBmybMItDOrEjhXvMwTHvibGL.Length;
		TZLdETEJpejvNzIAAYdVTODkDIgJ = new AList<IyKrMEphrrfzhbvWHFbsDCnHstQPA>();
		for (int i = 0; i < gaYCbudCKrFuKShTShmCgSlYuQUxA; i++)
		{
			TZLdETEJpejvNzIAAYdVTODkDIgJ.Add(new IyKrMEphrrfzhbvWHFbsDCnHstQPA(emsaYWjNHFwaAqKvMrOcQrfOMsse[i]));
		}
	}

	public void qevgkVDPuVaeixjpkpKzloScNZWQ(Controller P_0)
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
			Type type = tbbZPwYeqAXYVcLJcFjhqoVCvxFK(controllerTemplate.GetType());
			if (type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				ANwpmHAFcamcmcwHMvGEKXDJvOhP(type)?.mIWrljXUZiVJzmAukggYJZcZyHGC(controllerTemplate);
			}
		}
	}

	public void XVEqIlUIOtfUtTWfTYpbORGLUmrF(Controller P_0)
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
			Type type = tbbZPwYeqAXYVcLJcFjhqoVCvxFK(controllerTemplate.GetType());
			if (type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				ANwpmHAFcamcmcwHMvGEKXDJvOhP(type)?.YnCHMQZJYHNocDKttSfkKDmmuPMF(controllerTemplate);
			}
		}
	}

	public IList<_0001> IgIylPTTuRBEtTXkGHmhoOzerfFQ<_0001>() where _0001 : IControllerTemplate
	{
		Type typeFromHandle = typeof(_0001);
		for (int i = 0; i < TZLdETEJpejvNzIAAYdVTODkDIgJ._count; i++)
		{
			IyKrMEphrrfzhbvWHFbsDCnHstQPA iyKrMEphrrfzhbvWHFbsDCnHstQPA = TZLdETEJpejvNzIAAYdVTODkDIgJ._items[i];
			if ((object)iyKrMEphrrfzhbvWHFbsDCnHstQPA.FdiiTlfXVLJzPxPNTXLGNkzwRned == typeFromHandle)
			{
				return iyKrMEphrrfzhbvWHFbsDCnHstQPA.KwhknMTGUlSRCzHmKbRjOlEowFzv<_0001>();
			}
		}
		string text = "";
		for (int j = 0; j < emsaYWjNHFwaAqKvMrOcQrfOMsse.Length; j++)
		{
			text += emsaYWjNHFwaAqKvMrOcQrfOMsse[j].Name;
			if (j != emsaYWjNHFwaAqKvMrOcQrfOMsse.Length - 1)
			{
				text += "\n";
			}
		}
		Logger.LogError("Invalid Controller Template type \"" + typeFromHandle.Name + "\". Only the following Controller Template interface types are allowed:\n" + text);
		return EmptyObjects<_0001>.EmptyReadOnlyIListT;
	}

	private IyKrMEphrrfzhbvWHFbsDCnHstQPA ANwpmHAFcamcmcwHMvGEKXDJvOhP(Type P_0)
	{
		for (int i = 0; i < TZLdETEJpejvNzIAAYdVTODkDIgJ._count; i++)
		{
			if ((object)P_0 == TZLdETEJpejvNzIAAYdVTODkDIgJ._items[i].FdiiTlfXVLJzPxPNTXLGNkzwRned)
			{
				return TZLdETEJpejvNzIAAYdVTODkDIgJ._items[i];
			}
		}
		return null;
	}

	private Type tbbZPwYeqAXYVcLJcFjhqoVCvxFK(Type P_0)
	{
		for (int i = 0; i < gaYCbudCKrFuKShTShmCgSlYuQUxA; i++)
		{
			if ((object)dNQfBmybMItDOrEjhXvMwTHvibGL[i] == P_0)
			{
				return emsaYWjNHFwaAqKvMrOcQrfOMsse[i];
			}
		}
		return null;
	}
}
