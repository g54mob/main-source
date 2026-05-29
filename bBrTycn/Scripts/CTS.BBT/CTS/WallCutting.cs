using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	[RequireComponent(typeof(MeshRenderer))]
	public class WallCutting : MonoBehaviour
	{
		public class Cutter
		{
			public Vector3 center;

			public Vector3 extents;
		}

		private MeshRenderer _renderer;

		private static Shader BaseShader;

		private static Shader SingleCutShader;

		private static Shader DoubleCutShader;

		private static readonly int SHBoxCenter = Shader.PropertyToID("_CutBoxCenter");

		private static readonly int SHBoxExtents = Shader.PropertyToID("_CutBoxExtents");

		private static readonly int SHBoxTwoCenter = Shader.PropertyToID("_CutBoxTwoCenter");

		private static readonly int SHBoxTwoExtents = Shader.PropertyToID("_CutBoxTwoExtents");

		private List<Cutter> _cutters = new List<Cutter>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialization()
		{
			BaseShader = Shader.Find("CTS/BBT/Wall");
			SingleCutShader = Shader.Find("Hidden/CTS/BBT/Wall_OneCut");
			DoubleCutShader = Shader.Find("Hidden/CTS/BBT/Wall_TwoCut");
		}

		private void Awake()
		{
			_renderer = GetComponent<MeshRenderer>();
		}

		public bool TryCut(Cutter p_cutter)
		{
			if (_cutters.Count >= 2)
			{
				return false;
			}
			_cutters.Add(p_cutter);
			UpdateCut();
			return true;
		}

		public void StopCut(Cutter p_cutter)
		{
			if (_cutters.Count > 0)
			{
				_cutters.Remove(p_cutter);
				UpdateCut();
			}
		}

		private void UpdateCut()
		{
			Material[] materials = _renderer.materials;
			int count = _cutters.Count;
			if (count > 0)
			{
				MaterialPropertyBlock materialPropertyBlock;
				Material[] array;
				if (count == 1)
				{
					materialPropertyBlock = new MaterialPropertyBlock();
					_renderer.GetPropertyBlock(materialPropertyBlock);
					materialPropertyBlock.SetVector(SHBoxCenter, base.transform.InverseTransformPoint(_cutters[0].center));
					materialPropertyBlock.SetVector(SHBoxExtents, base.transform.rotation * _cutters[0].extents.Div(base.transform.lossyScale));
					_renderer.SetPropertyBlock(materialPropertyBlock);
					array = materials;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].shader = SingleCutShader;
					}
					return;
				}
				materialPropertyBlock = new MaterialPropertyBlock();
				_renderer.GetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.SetVector(SHBoxCenter, base.transform.InverseTransformPoint(_cutters[0].center));
				materialPropertyBlock.SetVector(SHBoxExtents, base.transform.rotation * _cutters[0].extents.Div(base.transform.lossyScale));
				materialPropertyBlock.SetVector(SHBoxTwoCenter, base.transform.InverseTransformPoint(_cutters[1].center));
				materialPropertyBlock.SetVector(SHBoxTwoExtents, base.transform.rotation * _cutters[1].extents.Div(base.transform.lossyScale));
				_renderer.SetPropertyBlock(materialPropertyBlock);
				array = materials;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].shader = DoubleCutShader;
				}
			}
			else
			{
				Material[] array = materials;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].shader = BaseShader;
				}
			}
		}
	}
}
