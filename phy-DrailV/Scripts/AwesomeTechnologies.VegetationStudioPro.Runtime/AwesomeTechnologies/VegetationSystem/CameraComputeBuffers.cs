using System.Collections.Generic;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	public class CameraComputeBuffers
	{
		public ComputeBuffer MergeBuffer;

		public ComputeBuffer VisibleBufferLOD0;

		public ComputeBuffer VisibleBufferLOD1;

		public ComputeBuffer VisibleBufferLOD2;

		public ComputeBuffer VisibleBufferLOD3;

		public ComputeBuffer ShadowBufferLOD0;

		public ComputeBuffer ShadowBufferLOD1;

		public ComputeBuffer ShadowBufferLOD2;

		public ComputeBuffer ShadowBufferLOD3;

		private readonly uint[] _args = new uint[5];

		public readonly List<ComputeBuffer> ArgsBufferMergedLOD0List = new List<ComputeBuffer>();

		public readonly List<ComputeBuffer> ArgsBufferMergedLOD1List = new List<ComputeBuffer>();

		public readonly List<ComputeBuffer> ArgsBufferMergedLOD2List = new List<ComputeBuffer>();

		public readonly List<ComputeBuffer> ArgsBufferMergedLOD3List = new List<ComputeBuffer>();

		public readonly List<ComputeBuffer> ShadowArgsBufferMergedLOD0List = new List<ComputeBuffer>();

		public readonly List<ComputeBuffer> ShadowArgsBufferMergedLOD1List = new List<ComputeBuffer>();

		public readonly List<ComputeBuffer> ShadowArgsBufferMergedLOD2List = new List<ComputeBuffer>();

		public readonly List<ComputeBuffer> ShadowArgsBufferMergedLOD3List = new List<ComputeBuffer>();

		public CameraComputeBuffers(Mesh vegetationMeshLod0, Mesh vegetationMeshLod1, Mesh vegetationMeshLod2, Mesh vegetationMeshLod3)
		{
			MergeBuffer = new ComputeBuffer(5000, 144, ComputeBufferType.Append);
			MergeBuffer.SetCounterValue(0u);
			VisibleBufferLOD0 = new ComputeBuffer(5000, 144, ComputeBufferType.Append);
			VisibleBufferLOD0.SetCounterValue(0u);
			VisibleBufferLOD1 = new ComputeBuffer(5000, 144, ComputeBufferType.Append);
			VisibleBufferLOD1.SetCounterValue(0u);
			VisibleBufferLOD2 = new ComputeBuffer(5000, 144, ComputeBufferType.Append);
			VisibleBufferLOD2.SetCounterValue(0u);
			VisibleBufferLOD3 = new ComputeBuffer(5000, 144, ComputeBufferType.Append);
			VisibleBufferLOD3.SetCounterValue(0u);
			ShadowBufferLOD0 = new ComputeBuffer(5000, 144, ComputeBufferType.Append);
			ShadowBufferLOD0.SetCounterValue(0u);
			ShadowBufferLOD1 = new ComputeBuffer(5000, 144, ComputeBufferType.Append);
			ShadowBufferLOD1.SetCounterValue(0u);
			ShadowBufferLOD2 = new ComputeBuffer(5000, 144, ComputeBufferType.Append);
			ShadowBufferLOD2.SetCounterValue(0u);
			ShadowBufferLOD3 = new ComputeBuffer(5000, 144, ComputeBufferType.Append);
			ShadowBufferLOD3.SetCounterValue(0u);
			for (int i = 0; i <= vegetationMeshLod0.subMeshCount - 1; i++)
			{
				_args[0] = vegetationMeshLod0.GetIndexCount(i);
				_args[2] = vegetationMeshLod0.GetIndexStart(i);
				ComputeBuffer computeBuffer = new ComputeBuffer(1, _args.Length * 4, ComputeBufferType.DrawIndirect);
				computeBuffer.SetData(_args);
				ArgsBufferMergedLOD0List.Add(computeBuffer);
				ComputeBuffer computeBuffer2 = new ComputeBuffer(1, _args.Length * 4, ComputeBufferType.DrawIndirect);
				computeBuffer2.SetData(_args);
				ShadowArgsBufferMergedLOD0List.Add(computeBuffer2);
			}
			for (int j = 0; j <= vegetationMeshLod1.subMeshCount - 1; j++)
			{
				_args[0] = vegetationMeshLod1.GetIndexCount(j);
				_args[2] = vegetationMeshLod1.GetIndexStart(j);
				ComputeBuffer computeBuffer3 = new ComputeBuffer(1, _args.Length * 4, ComputeBufferType.DrawIndirect);
				computeBuffer3.SetData(_args);
				ArgsBufferMergedLOD1List.Add(computeBuffer3);
				ComputeBuffer computeBuffer4 = new ComputeBuffer(1, _args.Length * 4, ComputeBufferType.DrawIndirect);
				computeBuffer4.SetData(_args);
				ShadowArgsBufferMergedLOD1List.Add(computeBuffer4);
			}
			for (int k = 0; k <= vegetationMeshLod2.subMeshCount - 1; k++)
			{
				_args[0] = vegetationMeshLod2.GetIndexCount(k);
				_args[2] = vegetationMeshLod2.GetIndexStart(k);
				ComputeBuffer computeBuffer5 = new ComputeBuffer(1, _args.Length * 4, ComputeBufferType.DrawIndirect);
				computeBuffer5.SetData(_args);
				ArgsBufferMergedLOD2List.Add(computeBuffer5);
				ComputeBuffer computeBuffer6 = new ComputeBuffer(1, _args.Length * 4, ComputeBufferType.DrawIndirect);
				computeBuffer6.SetData(_args);
				ShadowArgsBufferMergedLOD2List.Add(computeBuffer6);
			}
			for (int l = 0; l <= vegetationMeshLod3.subMeshCount - 1; l++)
			{
				_args[0] = vegetationMeshLod3.GetIndexCount(l);
				_args[2] = vegetationMeshLod3.GetIndexStart(l);
				ComputeBuffer computeBuffer7 = new ComputeBuffer(1, _args.Length * 4, ComputeBufferType.DrawIndirect);
				computeBuffer7.SetData(_args);
				ArgsBufferMergedLOD3List.Add(computeBuffer7);
				ComputeBuffer computeBuffer8 = new ComputeBuffer(1, _args.Length * 4, ComputeBufferType.DrawIndirect);
				computeBuffer8.SetData(_args);
				ShadowArgsBufferMergedLOD3List.Add(computeBuffer8);
			}
		}

		public void UpdateComputeBufferSize(int newInstanceCount)
		{
			MergeBuffer?.Release();
			MergeBuffer = null;
			VisibleBufferLOD0?.Release();
			VisibleBufferLOD0 = null;
			VisibleBufferLOD1?.Release();
			VisibleBufferLOD1 = null;
			VisibleBufferLOD2?.Release();
			VisibleBufferLOD2 = null;
			VisibleBufferLOD3?.Release();
			VisibleBufferLOD3 = null;
			ShadowBufferLOD0?.Release();
			ShadowBufferLOD0 = null;
			ShadowBufferLOD1?.Release();
			ShadowBufferLOD1 = null;
			ShadowBufferLOD2?.Release();
			ShadowBufferLOD2 = null;
			ShadowBufferLOD3?.Release();
			ShadowBufferLOD3 = null;
			MergeBuffer = new ComputeBuffer(newInstanceCount, 144, ComputeBufferType.Append);
			MergeBuffer.SetCounterValue(0u);
			VisibleBufferLOD0 = new ComputeBuffer(newInstanceCount, 144, ComputeBufferType.Append);
			VisibleBufferLOD0.SetCounterValue(0u);
			VisibleBufferLOD1 = new ComputeBuffer(newInstanceCount, 144, ComputeBufferType.Append);
			VisibleBufferLOD1.SetCounterValue(0u);
			VisibleBufferLOD2 = new ComputeBuffer(newInstanceCount, 144, ComputeBufferType.Append);
			VisibleBufferLOD2.SetCounterValue(0u);
			VisibleBufferLOD3 = new ComputeBuffer(newInstanceCount, 144, ComputeBufferType.Append);
			VisibleBufferLOD3.SetCounterValue(0u);
			ShadowBufferLOD0 = new ComputeBuffer(newInstanceCount, 144, ComputeBufferType.Append);
			ShadowBufferLOD0.SetCounterValue(0u);
			ShadowBufferLOD1 = new ComputeBuffer(newInstanceCount, 144, ComputeBufferType.Append);
			ShadowBufferLOD1.SetCounterValue(0u);
			ShadowBufferLOD2 = new ComputeBuffer(newInstanceCount, 144, ComputeBufferType.Append);
			ShadowBufferLOD2.SetCounterValue(0u);
			ShadowBufferLOD3 = new ComputeBuffer(newInstanceCount, 144, ComputeBufferType.Append);
			ShadowBufferLOD3.SetCounterValue(0u);
		}

		public void DestroyComputeBuffers()
		{
			MergeBuffer?.Release();
			MergeBuffer = null;
			VisibleBufferLOD0?.Release();
			VisibleBufferLOD0 = null;
			VisibleBufferLOD1?.Release();
			VisibleBufferLOD1 = null;
			VisibleBufferLOD2?.Release();
			VisibleBufferLOD2 = null;
			VisibleBufferLOD3?.Release();
			VisibleBufferLOD3 = null;
			ShadowBufferLOD0?.Release();
			ShadowBufferLOD0 = null;
			ShadowBufferLOD1?.Release();
			ShadowBufferLOD1 = null;
			ShadowBufferLOD2?.Release();
			ShadowBufferLOD2 = null;
			ShadowBufferLOD3?.Release();
			ShadowBufferLOD3 = null;
			ReleaseArgsBuffers();
		}

		private void ReleaseArgsBuffers()
		{
			for (int i = 0; i <= ArgsBufferMergedLOD0List.Count - 1; i++)
			{
				if (ArgsBufferMergedLOD0List[i] != null)
				{
					ArgsBufferMergedLOD0List[i].Release();
				}
			}
			for (int j = 0; j <= ArgsBufferMergedLOD1List.Count - 1; j++)
			{
				if (ArgsBufferMergedLOD1List[j] != null)
				{
					ArgsBufferMergedLOD1List[j].Release();
				}
			}
			for (int k = 0; k <= ArgsBufferMergedLOD2List.Count - 1; k++)
			{
				if (ArgsBufferMergedLOD2List[k] != null)
				{
					ArgsBufferMergedLOD2List[k].Release();
				}
			}
			for (int l = 0; l <= ArgsBufferMergedLOD3List.Count - 1; l++)
			{
				if (ArgsBufferMergedLOD3List[l] != null)
				{
					ArgsBufferMergedLOD3List[l].Release();
				}
			}
			for (int m = 0; m <= ShadowArgsBufferMergedLOD0List.Count - 1; m++)
			{
				if (ShadowArgsBufferMergedLOD0List[m] != null)
				{
					ShadowArgsBufferMergedLOD0List[m].Release();
				}
			}
			for (int n = 0; n <= ShadowArgsBufferMergedLOD1List.Count - 1; n++)
			{
				if (ShadowArgsBufferMergedLOD1List[n] != null)
				{
					ShadowArgsBufferMergedLOD1List[n].Release();
				}
			}
			for (int num = 0; num <= ShadowArgsBufferMergedLOD2List.Count - 1; num++)
			{
				if (ShadowArgsBufferMergedLOD2List[num] != null)
				{
					ShadowArgsBufferMergedLOD2List[num].Release();
				}
			}
			for (int num2 = 0; num2 <= ShadowArgsBufferMergedLOD3List.Count - 1; num2++)
			{
				if (ShadowArgsBufferMergedLOD3List[num2] != null)
				{
					ShadowArgsBufferMergedLOD3List[num2].Release();
				}
			}
			ArgsBufferMergedLOD0List.Clear();
			ArgsBufferMergedLOD1List.Clear();
			ArgsBufferMergedLOD2List.Clear();
			ArgsBufferMergedLOD3List.Clear();
			ShadowArgsBufferMergedLOD0List.Clear();
			ShadowArgsBufferMergedLOD1List.Clear();
			ShadowArgsBufferMergedLOD2List.Clear();
			ShadowArgsBufferMergedLOD3List.Clear();
		}
	}
}
