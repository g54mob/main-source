using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	[Serializable]
	public class CullingSettings : IDataValidate
	{
		public enum CameraCullingMode
		{
			Off = 0,
			Reset = 10,
			Keep = 20,
			AnimatorLinkage = 30
		}

		public enum CameraCullingMethod
		{
			AutomaticRenderer = 0,
			ManualRenderer = 10
		}

		public struct CullingParams
		{
			public bool useDistanceCulling;

			public float distanceCullingLength;

			public float distanceCullingFadeRatio;

			public void Convert(CullingSettings cullingSettings)
			{
			}
		}

		public CameraCullingMode cameraCullingMode;

		public CameraCullingMethod cameraCullingMethod;

		public List<Renderer> cameraCullingRenderers;

		public CheckSliderSerializeData distanceCullingLength;

		[Range(0f, 1f)]
		public float distanceCullingFadeRatio;

		public GameObject distanceCullingReferenceObject;

		public void DataValidate()
		{
		}

		public CullingSettings Clone()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
