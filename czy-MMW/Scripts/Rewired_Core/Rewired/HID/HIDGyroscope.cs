using System;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class HIDGyroscope : HIDControllerElementWithDataSet
	{
		internal class jWoVnpibgvhLXzAeXPXxuBvTmxiI : JZcHblEZdJOfYfdmMrRocOPDgYAZ
		{
			private int fylbnSnLFxaiOHlFtInhjuHcuWSo;

			private int DXuLGbutkUGsJKnNdUFIZlHqxOLQ;

			public float[] HIEEDvNxpAXUDsasUXNAgRmYlWFU => (rgvihrYYfduivUTwfcIgkZfCHrqN as OFNUqbSXmHxCOPJpycUoDwfKcaiQA).riHjKulUfNrWBvhZUUvhdYmcLhXA;

			public ExpandableArray_DataContainer<GiuyxAjgsLMZoyJQQDMOmNkokChH> bJQJVcJNzHSmxHGzSgoDDgUKyCRW => (rgvihrYYfduivUTwfcIgkZfCHrqN as OFNUqbSXmHxCOPJpycUoDwfKcaiQA).nKVAyDkAQBKzJQuQPIkMLCiYVOLd;

			public jWoVnpibgvhLXzAeXPXxuBvTmxiI(UpdateLoopSetting P_0, int P_1, int P_2)
			{
				fylbnSnLFxaiOHlFtInhjuHcuWSo = P_1;
				DXuLGbutkUGsJKnNdUFIZlHqxOLQ = P_2;
				wCAnnDolWFcDCqlwUjBcoDqKkfNA(P_0, yILFBYgElfoeGKRHfigPEvJBkivMc);
			}

			public virtual void BTGJihOJeAGCZaXfaOyuACkVPKUvA(UpdateLoopType P_0)
			{
				base.fBLiUOKwdLvJrmEZnARhHshUcoXZ(P_0);
				(rgvihrYYfduivUTwfcIgkZfCHrqN as OFNUqbSXmHxCOPJpycUoDwfKcaiQA).LuPjTdmywzoWHCJcBZXpIHCkYdPe();
			}

			public void mDLHQXkSOsWThpVolKysJOiPpjsUA(float[] P_0, float P_1)
			{
				for (int i = 0; i < nmYcSLhBeqLQvFKuKpqdnzeiJRqub.Length; i++)
				{
					(nmYcSLhBeqLQvFKuKpqdnzeiJRqub[i] as OFNUqbSXmHxCOPJpycUoDwfKcaiQA).RmbDEvBFgrfrsFMIcvgEQpAHtJjPd(P_0, P_1);
				}
			}

			private zeqqtlhhdqKkPgNxrCdktEnMMtCS yILFBYgElfoeGKRHfigPEvJBkivMc(UpdateLoopType P_0)
			{
				return new OFNUqbSXmHxCOPJpycUoDwfKcaiQA(P_0, fylbnSnLFxaiOHlFtInhjuHcuWSo, DXuLGbutkUGsJKnNdUFIZlHqxOLQ);
			}
		}

		internal class OFNUqbSXmHxCOPJpycUoDwfKcaiQA : zeqqtlhhdqKkPgNxrCdktEnMMtCS
		{
			private float[] mXZwmNAbMiYBSGTnCwmfPuPhIBvC;

			public float[] riHjKulUfNrWBvhZUUvhdYmcLhXA;

			public ExpandableArray_DataContainer<GiuyxAjgsLMZoyJQQDMOmNkokChH> nKVAyDkAQBKzJQuQPIkMLCiYVOLd;

			private ExpandableArray_DataContainer<GiuyxAjgsLMZoyJQQDMOmNkokChH> gwvTrTfjuSIYOEXKusapquSFuWVK;

			public OFNUqbSXmHxCOPJpycUoDwfKcaiQA(UpdateLoopType P_0, int P_1, int P_2)
				: base(P_0)
			{
				riHjKulUfNrWBvhZUUvhdYmcLhXA = new float[P_1];
				mXZwmNAbMiYBSGTnCwmfPuPhIBvC = new float[P_1];
				nKVAyDkAQBKzJQuQPIkMLCiYVOLd = new ExpandableArray_DataContainer<GiuyxAjgsLMZoyJQQDMOmNkokChH>(P_2, false, 20);
				gwvTrTfjuSIYOEXKusapquSFuWVK = new ExpandableArray_DataContainer<GiuyxAjgsLMZoyJQQDMOmNkokChH>(P_2, false, 20);
			}

			public void LuPjTdmywzoWHCJcBZXpIHCkYdPe()
			{
				for (int i = 0; i < mXZwmNAbMiYBSGTnCwmfPuPhIBvC.Length; i++)
				{
					riHjKulUfNrWBvhZUUvhdYmcLhXA[i] = mXZwmNAbMiYBSGTnCwmfPuPhIBvC[i];
					mXZwmNAbMiYBSGTnCwmfPuPhIBvC[i] = 0f;
				}
				nKVAyDkAQBKzJQuQPIkMLCiYVOLd.Clear();
				int count = gwvTrTfjuSIYOEXKusapquSFuWVK.Count;
				for (int j = 0; j < count; j++)
				{
					nKVAyDkAQBKzJQuQPIkMLCiYVOLd.AddData(gwvTrTfjuSIYOEXKusapquSFuWVK[j]);
				}
				gwvTrTfjuSIYOEXKusapquSFuWVK.Clear();
			}

			public void RmbDEvBFgrfrsFMIcvgEQpAHtJjPd(float[] P_0, float P_1)
			{
				for (int i = 0; i < mXZwmNAbMiYBSGTnCwmfPuPhIBvC.Length; i++)
				{
					mXZwmNAbMiYBSGTnCwmfPuPhIBvC[i] += P_0[i];
				}
				gwvTrTfjuSIYOEXKusapquSFuWVK.injector.iKXxodlWcMEjGlxpoLEenDMFzuLQ(P_0, P_1);
				gwvTrTfjuSIYOEXKusapquSFuWVK.Inject();
			}

			public virtual void YkXfXpekBHyNgvkuIjfpbBraeLpqc()
			{
				Array.Clear(riHjKulUfNrWBvhZUUvhdYmcLhXA, 0, riHjKulUfNrWBvhZUUvhdYmcLhXA.Length);
				gwvTrTfjuSIYOEXKusapquSFuWVK.Clear();
				nKVAyDkAQBKzJQuQPIkMLCiYVOLd.Clear();
			}
		}

		public class GiuyxAjgsLMZoyJQQDMOmNkokChH : ExpandableArray_DataContainer<GiuyxAjgsLMZoyJQQDMOmNkokChH>.TVBgovhjLayvQrOmBMxqiXsndkMlA, IComparable<GiuyxAjgsLMZoyJQQDMOmNkokChH>
		{
			public Vector3 cWevxravOZkFimTGMKQZfvGPQDgd;

			public float EUSnZeZyQsAWYltoKOVynUanzgdH;

			public GiuyxAjgsLMZoyJQQDMOmNkokChH()
			{
			}

			public GiuyxAjgsLMZoyJQQDMOmNkokChH(float[] P_0, float P_1)
			{
				iKXxodlWcMEjGlxpoLEenDMFzuLQ(P_0, P_1);
			}

			public void iKXxodlWcMEjGlxpoLEenDMFzuLQ(float[] P_0, float P_1)
			{
				int num = MathTools.Min(P_0.Length, 3);
				for (int i = 0; i < num; i++)
				{
					cWevxravOZkFimTGMKQZfvGPQDgd[i] = P_0[i];
				}
				EUSnZeZyQsAWYltoKOVynUanzgdH = P_1;
			}

			public void qPbGavBaJHXbZMLTVgNcfGFjWxTB(GiuyxAjgsLMZoyJQQDMOmNkokChH P_0)
			{
				cWevxravOZkFimTGMKQZfvGPQDgd = P_0.cWevxravOZkFimTGMKQZfvGPQDgd;
				EUSnZeZyQsAWYltoKOVynUanzgdH = P_0.EUSnZeZyQsAWYltoKOVynUanzgdH;
			}

			void ExpandableArray_DataContainer<GiuyxAjgsLMZoyJQQDMOmNkokChH>.TVBgovhjLayvQrOmBMxqiXsndkMlA.VbTqOFRLGqiIOJyOYDrdMAAkHrCj(GiuyxAjgsLMZoyJQQDMOmNkokChH P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in qPbGavBaJHXbZMLTVgNcfGFjWxTB
				this.qPbGavBaJHXbZMLTVgNcfGFjWxTB(P_0);
			}

			public bool gXEhszTdbtcVAChsMEewtWYsXFZr(GiuyxAjgsLMZoyJQQDMOmNkokChH P_0)
			{
				if (EUSnZeZyQsAWYltoKOVynUanzgdH == P_0.EUSnZeZyQsAWYltoKOVynUanzgdH)
				{
					return cWevxravOZkFimTGMKQZfvGPQDgd == P_0.cWevxravOZkFimTGMKQZfvGPQDgd;
				}
				return false;
			}

			bool ExpandableArray_DataContainer<GiuyxAjgsLMZoyJQQDMOmNkokChH>.TVBgovhjLayvQrOmBMxqiXsndkMlA.QgkDGSvRNRxKxMuMbYBjOcyJRoub(GiuyxAjgsLMZoyJQQDMOmNkokChH P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in gXEhszTdbtcVAChsMEewtWYsXFZr
				return this.gXEhszTdbtcVAChsMEewtWYsXFZr(P_0);
			}

			public void lZAFXlqvyIyaEdNCtAipvJGTBAbX()
			{
				cWevxravOZkFimTGMKQZfvGPQDgd.x = 0f;
				cWevxravOZkFimTGMKQZfvGPQDgd.y = 0f;
				cWevxravOZkFimTGMKQZfvGPQDgd.z = 0f;
				EUSnZeZyQsAWYltoKOVynUanzgdH = 0f;
			}

			void ExpandableArray_DataContainer<GiuyxAjgsLMZoyJQQDMOmNkokChH>.TVBgovhjLayvQrOmBMxqiXsndkMlA.wDPkJYfYYWdMcbWjbRouiAosDabW()
			{
				//ILSpy generated this explicit interface implementation from .override directive in lZAFXlqvyIyaEdNCtAipvJGTBAbX
				this.lZAFXlqvyIyaEdNCtAipvJGTBAbX();
			}

			public int CompareTo(GiuyxAjgsLMZoyJQQDMOmNkokChH other)
			{
				return 0;
			}

			int IComparable<GiuyxAjgsLMZoyJQQDMOmNkokChH>.CompareTo(GiuyxAjgsLMZoyJQQDMOmNkokChH other)
			{
				//ILSpy generated this explicit interface implementation from .override directive in CompareTo
				return this.CompareTo(other);
			}
		}

		public double timestamp;

		public readonly float[] lastRawValue;

		public readonly int valueLength;

		private readonly byte[] kzJuIpFPtVDZdxgKYqwtHpoMMDWg;

		private readonly float[] HdTLyJOhErtrqTKTZyKPtzCWMCVM;

		private readonly int ZyiYQADZofvQJHKEWFiciTBkYBVgA;

		private readonly int TFEKjrfPqaDEVzOdXcvuzVzcIEEl;

		private readonly Action<byte[], float[]> MJLbGfElYAMccZENFePmdgkfZWaTA;

		private readonly Func<float> kGSAXVkOKRnErqnDMxIQiMxXeUaAA;

		public float[] rawValue => (dataSet as jWoVnpibgvhLXzAeXPXxuBvTmxiI).HIEEDvNxpAXUDsasUXNAgRmYlWFU;

		public ExpandableArray_DataContainer<GiuyxAjgsLMZoyJQQDMOmNkokChH> events => (dataSet as jWoVnpibgvhLXzAeXPXxuBvTmxiI).bJQJVcJNzHSmxHGzSgoDDgUKyCRW;

		public HIDGyroscope(UpdateLoopSetting P_0, byte P_1, HIDInfo P_2, int P_3, int P_4, Action<byte[], float[]> P_5, Func<float> P_6)
			: base(new jWoVnpibgvhLXzAeXPXxuBvTmxiI(P_0, P_3, P_4), P_1, P_2)
		{
			valueLength = P_3;
			MJLbGfElYAMccZENFePmdgkfZWaTA = P_5;
			kGSAXVkOKRnErqnDMxIQiMxXeUaAA = P_6;
			ZyiYQADZofvQJHKEWFiciTBkYBVgA = ((P_2.bitSize > 0) ? ((P_2.bitSize + 8 - 1) / 8) : 0);
			TFEKjrfPqaDEVzOdXcvuzVzcIEEl = P_2.dataIndex;
			kzJuIpFPtVDZdxgKYqwtHpoMMDWg = new byte[ZyiYQADZofvQJHKEWFiciTBkYBVgA];
			HdTLyJOhErtrqTKTZyKPtzCWMCVM = new float[P_3];
			lastRawValue = new float[P_3];
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (inputReport != null && inputReport[0] == reportId)
			{
				this.timestamp = timestamp;
				for (int i = 0; i < ZyiYQADZofvQJHKEWFiciTBkYBVgA; i++)
				{
					kzJuIpFPtVDZdxgKYqwtHpoMMDWg[i] = inputReport[TFEKjrfPqaDEVzOdXcvuzVzcIEEl + i];
				}
				if (MJLbGfElYAMccZENFePmdgkfZWaTA != null)
				{
					MJLbGfElYAMccZENFePmdgkfZWaTA(kzJuIpFPtVDZdxgKYqwtHpoMMDWg, HdTLyJOhErtrqTKTZyKPtzCWMCVM);
				}
				float num = ((kGSAXVkOKRnErqnDMxIQiMxXeUaAA != null) ? kGSAXVkOKRnErqnDMxIQiMxXeUaAA() : 0f);
				(dataSet as jWoVnpibgvhLXzAeXPXxuBvTmxiI).mDLHQXkSOsWThpVolKysJOiPpjsUA(HdTLyJOhErtrqTKTZyKPtzCWMCVM, num);
				for (int j = 0; j < valueLength; j++)
				{
					lastRawValue[j] = HdTLyJOhErtrqTKTZyKPtzCWMCVM[j];
				}
			}
		}

		public void UpdateValueManual(float[] value, double timestamp)
		{
			this.timestamp = timestamp;
			float num = ((kGSAXVkOKRnErqnDMxIQiMxXeUaAA != null) ? kGSAXVkOKRnErqnDMxIQiMxXeUaAA() : 0f);
			for (int i = 0; i < valueLength; i++)
			{
				HdTLyJOhErtrqTKTZyKPtzCWMCVM[i] = value[i];
			}
			(dataSet as jWoVnpibgvhLXzAeXPXxuBvTmxiI).mDLHQXkSOsWThpVolKysJOiPpjsUA(HdTLyJOhErtrqTKTZyKPtzCWMCVM, num);
			for (int j = 0; j < valueLength; j++)
			{
				lastRawValue[j] = HdTLyJOhErtrqTKTZyKPtzCWMCVM[j];
			}
		}
	}
}
