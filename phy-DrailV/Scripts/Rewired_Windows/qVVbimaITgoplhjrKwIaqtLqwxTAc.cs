using System;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class qVVbimaITgoplhjrKwIaqtLqwxTAc : cSzgNdSPWsXOWYbsSyTeXGnVQTxv
{
	internal class jCMLEabzOlfEGlfHYBMcUUSidlwI : nQhciUzXdTqxtyrcwLcDDRzxcNdk
	{
		private int QCOFsGxIkxDEmAbTaixfrCMMvZhd;

		private int erlIWfjkCIowpDBaSENkAGXoqmdcb;

		public float[] QGEPzKgIedvthGPliWOduwXNjWui => (BkOPFuJPuwwYFxfFTaZXlqNCSHtU as USnuYUUBwIEnjCzIzhKxcGKzWgBu).QGEPzKgIedvthGPliWOduwXNjWui;

		public RingBuffer<RabBRypoXYAJwkbCIuOqggayIjHt> mOMEUBQyWiiPqJDJTDuPNharRHPG => (BkOPFuJPuwwYFxfFTaZXlqNCSHtU as USnuYUUBwIEnjCzIzhKxcGKzWgBu).mOMEUBQyWiiPqJDJTDuPNharRHPG;

		public jCMLEabzOlfEGlfHYBMcUUSidlwI(UpdateLoopSetting P_0, int P_1, int P_2)
		{
			QCOFsGxIkxDEmAbTaixfrCMMvZhd = P_1;
			erlIWfjkCIowpDBaSENkAGXoqmdcb = P_2;
			qMWksQEqmcasrkaUqJAdGQoioDgg(P_0, BbYvuIxHBDKNMRTmNXigTOZwNoZG);
		}

		public override void mefhGqvTkcrETnFSidhNngFjAYNV(UpdateLoopType P_0)
		{
			base.mefhGqvTkcrETnFSidhNngFjAYNV(P_0);
			(BkOPFuJPuwwYFxfFTaZXlqNCSHtU as USnuYUUBwIEnjCzIzhKxcGKzWgBu).mefhGqvTkcrETnFSidhNngFjAYNV();
		}

		public void gdEkduATFDAbUvNRMlPKUHBlwBvr(float[] P_0, float P_1)
		{
			for (int i = 0; i < EFpHrsFLouNlEgYqRjLITLMXDVui.Length; i++)
			{
				(EFpHrsFLouNlEgYqRjLITLMXDVui[i] as USnuYUUBwIEnjCzIzhKxcGKzWgBu).trsfRiBFSIjLrLMemKcGjgULCoSi(P_0, P_1);
			}
		}

		private ZirEdAMKfgjqovtnBVQNMbFyiXxCA BbYvuIxHBDKNMRTmNXigTOZwNoZG(UpdateLoopType P_0)
		{
			return new USnuYUUBwIEnjCzIzhKxcGKzWgBu(P_0, QCOFsGxIkxDEmAbTaixfrCMMvZhd, erlIWfjkCIowpDBaSENkAGXoqmdcb);
		}
	}

	internal class USnuYUUBwIEnjCzIzhKxcGKzWgBu : ZirEdAMKfgjqovtnBVQNMbFyiXxCA
	{
		[Serializable]
		private sealed class RJNSeNtxvgVoQkJspHhcPrXcQAvG
		{
			public static readonly RJNSeNtxvgVoQkJspHhcPrXcQAvG _003C_003E9 = new RJNSeNtxvgVoQkJspHhcPrXcQAvG();

			public static Func<RabBRypoXYAJwkbCIuOqggayIjHt> _003C_003E9__5_0;

			internal RabBRypoXYAJwkbCIuOqggayIjHt TaiVpqxKFaSbPudlOcFXRoRttktd()
			{
				return new RabBRypoXYAJwkbCIuOqggayIjHt();
			}
		}

		private float[] zhgobvglGWsvNdkhLJfwpmwqVaUy;

		public float[] QGEPzKgIedvthGPliWOduwXNjWui;

		public RingBuffer<RabBRypoXYAJwkbCIuOqggayIjHt> mOMEUBQyWiiPqJDJTDuPNharRHPG;

		private RingBuffer<RabBRypoXYAJwkbCIuOqggayIjHt> IkAEdaGwcdjoPCmkTjpCEDgJaRmEB;

		private ObjectPool<RabBRypoXYAJwkbCIuOqggayIjHt> GgqiGmtQsufRCndhxvJDVWptWoOL;

		public USnuYUUBwIEnjCzIzhKxcGKzWgBu(UpdateLoopType P_0, int P_1, int P_2)
			: base(P_0)
		{
			QGEPzKgIedvthGPliWOduwXNjWui = new float[P_1];
			zhgobvglGWsvNdkhLJfwpmwqVaUy = new float[P_1];
			mOMEUBQyWiiPqJDJTDuPNharRHPG = new RingBuffer<RabBRypoXYAJwkbCIuOqggayIjHt>(P_2);
			IkAEdaGwcdjoPCmkTjpCEDgJaRmEB = new RingBuffer<RabBRypoXYAJwkbCIuOqggayIjHt>(P_2);
			GgqiGmtQsufRCndhxvJDVWptWoOL = new ObjectPool<RabBRypoXYAJwkbCIuOqggayIjHt>(P_2, RJNSeNtxvgVoQkJspHhcPrXcQAvG._003C_003E9.TaiVpqxKFaSbPudlOcFXRoRttktd);
		}

		public void mefhGqvTkcrETnFSidhNngFjAYNV()
		{
			for (int i = 0; i < zhgobvglGWsvNdkhLJfwpmwqVaUy.Length; i++)
			{
				QGEPzKgIedvthGPliWOduwXNjWui[i] = zhgobvglGWsvNdkhLJfwpmwqVaUy[i];
				zhgobvglGWsvNdkhLJfwpmwqVaUy[i] = 0f;
			}
			CollectionTools.Clear(GgqiGmtQsufRCndhxvJDVWptWoOL, mOMEUBQyWiiPqJDJTDuPNharRHPG);
			int count = IkAEdaGwcdjoPCmkTjpCEDgJaRmEB.Count;
			for (int j = 0; j < count; j++)
			{
				RabBRypoXYAJwkbCIuOqggayIjHt rabBRypoXYAJwkbCIuOqggayIjHt = GgqiGmtQsufRCndhxvJDVWptWoOL.Get();
				rabBRypoXYAJwkbCIuOqggayIjHt.xQEFQkhJhvnmwGSMyzYdziphFTng(IkAEdaGwcdjoPCmkTjpCEDgJaRmEB[j]);
				CollectionTools.Enqueue(GgqiGmtQsufRCndhxvJDVWptWoOL, mOMEUBQyWiiPqJDJTDuPNharRHPG, rabBRypoXYAJwkbCIuOqggayIjHt, out var _);
			}
			CollectionTools.Clear(GgqiGmtQsufRCndhxvJDVWptWoOL, IkAEdaGwcdjoPCmkTjpCEDgJaRmEB);
		}

		public void trsfRiBFSIjLrLMemKcGjgULCoSi(float[] P_0, float P_1)
		{
			for (int i = 0; i < zhgobvglGWsvNdkhLJfwpmwqVaUy.Length; i++)
			{
				zhgobvglGWsvNdkhLJfwpmwqVaUy[i] += P_0[i];
			}
			RabBRypoXYAJwkbCIuOqggayIjHt rabBRypoXYAJwkbCIuOqggayIjHt = GgqiGmtQsufRCndhxvJDVWptWoOL.Get();
			rabBRypoXYAJwkbCIuOqggayIjHt.TBPPzgWuguKbGbwgzGoaAckRXMzv(P_0, P_1);
			CollectionTools.Enqueue(GgqiGmtQsufRCndhxvJDVWptWoOL, IkAEdaGwcdjoPCmkTjpCEDgJaRmEB, rabBRypoXYAJwkbCIuOqggayIjHt, out var _);
		}

		public override void sbvNiOKcscCGRBGGcMbdhHrjtptuB()
		{
			Array.Clear(QGEPzKgIedvthGPliWOduwXNjWui, 0, QGEPzKgIedvthGPliWOduwXNjWui.Length);
			CollectionTools.Clear(GgqiGmtQsufRCndhxvJDVWptWoOL, IkAEdaGwcdjoPCmkTjpCEDgJaRmEB);
			CollectionTools.Clear(GgqiGmtQsufRCndhxvJDVWptWoOL, mOMEUBQyWiiPqJDJTDuPNharRHPG);
		}
	}

	public class RabBRypoXYAJwkbCIuOqggayIjHt
	{
		public Vector3 QGEPzKgIedvthGPliWOduwXNjWui;

		public float rUDxkIqFCKfJYnEJOjJtlBdnXVRN;

		public RabBRypoXYAJwkbCIuOqggayIjHt()
		{
		}

		public RabBRypoXYAJwkbCIuOqggayIjHt(float[] P_0, float P_1)
		{
			TBPPzgWuguKbGbwgzGoaAckRXMzv(P_0, P_1);
		}

		public void TBPPzgWuguKbGbwgzGoaAckRXMzv(float[] P_0, float P_1)
		{
			int num = MathTools.Min(P_0.Length, 3);
			for (int i = 0; i < num; i++)
			{
				QGEPzKgIedvthGPliWOduwXNjWui[i] = P_0[i];
			}
			rUDxkIqFCKfJYnEJOjJtlBdnXVRN = P_1;
		}

		public void xQEFQkhJhvnmwGSMyzYdziphFTng(RabBRypoXYAJwkbCIuOqggayIjHt P_0)
		{
			QGEPzKgIedvthGPliWOduwXNjWui = P_0.QGEPzKgIedvthGPliWOduwXNjWui;
			rUDxkIqFCKfJYnEJOjJtlBdnXVRN = P_0.rUDxkIqFCKfJYnEJOjJtlBdnXVRN;
		}

		public void TBPPzgWuguKbGbwgzGoaAckRXMzv(RabBRypoXYAJwkbCIuOqggayIjHt P_0)
		{
			QGEPzKgIedvthGPliWOduwXNjWui = P_0.QGEPzKgIedvthGPliWOduwXNjWui;
			rUDxkIqFCKfJYnEJOjJtlBdnXVRN = P_0.rUDxkIqFCKfJYnEJOjJtlBdnXVRN;
		}

		public bool JRxBWnhQlwwPGktFTDexAbegXFrzB(RabBRypoXYAJwkbCIuOqggayIjHt P_0)
		{
			if (rUDxkIqFCKfJYnEJOjJtlBdnXVRN == P_0.rUDxkIqFCKfJYnEJOjJtlBdnXVRN)
			{
				return QGEPzKgIedvthGPliWOduwXNjWui == P_0.QGEPzKgIedvthGPliWOduwXNjWui;
			}
			return false;
		}

		public void DwNKXiEShimVDUzntAObjUXyaFmo()
		{
			QGEPzKgIedvthGPliWOduwXNjWui.x = 0f;
			QGEPzKgIedvthGPliWOduwXNjWui.y = 0f;
			QGEPzKgIedvthGPliWOduwXNjWui.z = 0f;
			rUDxkIqFCKfJYnEJOjJtlBdnXVRN = 0f;
		}
	}

	public double YxFdZozJytryXOxcRaQAmySLFHVc;

	public readonly float[] byxGkOgARwUJQCPZJukQPfWRpXkj;

	public readonly int QCOFsGxIkxDEmAbTaixfrCMMvZhd;

	private readonly byte[] QtXcZTickhBwGLYIAJbqpdfWpmzB;

	private readonly float[] sRMazpEPLOpwkgPUCaKqPCeHvSGQe;

	private readonly int NFBfIavLmQumHiFjQGXsgfhnLmUeA;

	private readonly int LMvFEAtZBwQRlFfEWyZfAAUImHJg;

	private readonly Action<byte[], float[]> zovEYMDwzpRetqGCitWoSXfGWxUAA;

	private readonly Func<float> yMCeSNaTfGlOPsnZYUmClJYcTsrAA;

	public float[] QGEPzKgIedvthGPliWOduwXNjWui => (xSxdXdIXGcMohhPTuDvIiQULhHADb as jCMLEabzOlfEGlfHYBMcUUSidlwI).QGEPzKgIedvthGPliWOduwXNjWui;

	public RingBuffer<RabBRypoXYAJwkbCIuOqggayIjHt> mOMEUBQyWiiPqJDJTDuPNharRHPG => (xSxdXdIXGcMohhPTuDvIiQULhHADb as jCMLEabzOlfEGlfHYBMcUUSidlwI).mOMEUBQyWiiPqJDJTDuPNharRHPG;

	public qVVbimaITgoplhjrKwIaqtLqwxTAc(UpdateLoopSetting P_0, byte P_1, HIDInfo P_2, int P_3, int P_4, Action<byte[], float[]> P_5, Func<float> P_6)
		: base(new jCMLEabzOlfEGlfHYBMcUUSidlwI(P_0, P_3, P_4), P_1, P_2)
	{
		QCOFsGxIkxDEmAbTaixfrCMMvZhd = P_3;
		zovEYMDwzpRetqGCitWoSXfGWxUAA = P_5;
		yMCeSNaTfGlOPsnZYUmClJYcTsrAA = P_6;
		NFBfIavLmQumHiFjQGXsgfhnLmUeA = ((P_2.bitSize > 0) ? ((P_2.bitSize + 8 - 1) / 8) : 0);
		LMvFEAtZBwQRlFfEWyZfAAUImHJg = P_2.dataIndex;
		QtXcZTickhBwGLYIAJbqpdfWpmzB = new byte[NFBfIavLmQumHiFjQGXsgfhnLmUeA];
		sRMazpEPLOpwkgPUCaKqPCeHvSGQe = new float[P_3];
		byxGkOgARwUJQCPZJukQPfWRpXkj = new float[P_3];
	}

	public override void trsfRiBFSIjLrLMemKcGjgULCoSi(NativeBuffer P_0, double P_1)
	{
		if (P_0 != null && P_0[0] == UQBUMeskXtetUCCacGGybviytBzpA)
		{
			YxFdZozJytryXOxcRaQAmySLFHVc = P_1;
			for (int i = 0; i < NFBfIavLmQumHiFjQGXsgfhnLmUeA; i++)
			{
				QtXcZTickhBwGLYIAJbqpdfWpmzB[i] = P_0[LMvFEAtZBwQRlFfEWyZfAAUImHJg + i];
			}
			if (zovEYMDwzpRetqGCitWoSXfGWxUAA != null)
			{
				zovEYMDwzpRetqGCitWoSXfGWxUAA(QtXcZTickhBwGLYIAJbqpdfWpmzB, sRMazpEPLOpwkgPUCaKqPCeHvSGQe);
			}
			float num = ((yMCeSNaTfGlOPsnZYUmClJYcTsrAA != null) ? yMCeSNaTfGlOPsnZYUmClJYcTsrAA() : 0f);
			(xSxdXdIXGcMohhPTuDvIiQULhHADb as jCMLEabzOlfEGlfHYBMcUUSidlwI).gdEkduATFDAbUvNRMlPKUHBlwBvr(sRMazpEPLOpwkgPUCaKqPCeHvSGQe, num);
			for (int j = 0; j < QCOFsGxIkxDEmAbTaixfrCMMvZhd; j++)
			{
				byxGkOgARwUJQCPZJukQPfWRpXkj[j] = sRMazpEPLOpwkgPUCaKqPCeHvSGQe[j];
			}
		}
	}

	public void YIgPiAURoRMNKnmhgmMVyzRrGlUJ(float[] P_0, double P_1)
	{
		YxFdZozJytryXOxcRaQAmySLFHVc = P_1;
		float num = ((yMCeSNaTfGlOPsnZYUmClJYcTsrAA != null) ? yMCeSNaTfGlOPsnZYUmClJYcTsrAA() : 0f);
		for (int i = 0; i < QCOFsGxIkxDEmAbTaixfrCMMvZhd; i++)
		{
			sRMazpEPLOpwkgPUCaKqPCeHvSGQe[i] = P_0[i];
		}
		(xSxdXdIXGcMohhPTuDvIiQULhHADb as jCMLEabzOlfEGlfHYBMcUUSidlwI).gdEkduATFDAbUvNRMlPKUHBlwBvr(sRMazpEPLOpwkgPUCaKqPCeHvSGQe, num);
		for (int j = 0; j < QCOFsGxIkxDEmAbTaixfrCMMvZhd; j++)
		{
			byxGkOgARwUJQCPZJukQPfWRpXkj[j] = sRMazpEPLOpwkgPUCaKqPCeHvSGQe[j];
		}
	}
}
