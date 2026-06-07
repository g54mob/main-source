using System;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class PlanetShaderOptionsData
	{
		[SerializeField]
		private bool _atmosScaleAuto = true;

		[SerializeField]
		private bool _legacySkyShader;

		[SerializeField]
		private bool _scaleDepthAuto = true;

		public bool AtmosScaleAuto
		{
			get
			{
				return _atmosScaleAuto;
			}
			set
			{
				_atmosScaleAuto = value;
			}
		}

		public bool LegacySkyShader
		{
			get
			{
				return _legacySkyShader;
			}
			set
			{
				_legacySkyShader = value;
			}
		}

		public bool ScaleDepthAuto
		{
			get
			{
				return _scaleDepthAuto;
			}
			set
			{
				_scaleDepthAuto = value;
			}
		}

		internal void CopyFrom(PlanetShaderOptionsData source)
		{
			AtmosScaleAuto = source.AtmosScaleAuto;
			ScaleDepthAuto = source.ScaleDepthAuto;
			LegacySkyShader = source.LegacySkyShader;
		}
	}
}
