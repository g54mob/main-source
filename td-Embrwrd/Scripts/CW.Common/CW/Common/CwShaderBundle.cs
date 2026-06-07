using System;
using System.Collections.Generic;
using UnityEngine;

namespace CW.Common
{
	public class CwShaderBundle : ScriptableObject
	{
		public enum Pipeline
		{
			Invalid = -1,
			Standard = 0,
			URP2019 = 1,
			URP2020 = 2,
			URP2021 = 3,
			HDRP2019 = 4,
			HDRP2020 = 5,
			HDRP2021 = 6,
			COUNT = 7
		}

		[Serializable]
		public class ShaderVariant
		{
			public Pipeline Pipe;

			public string Code;

			public int Hash;

			public bool Dirty;

			public string HashString => null;
		}

		[SerializeField]
		private string title;

		[SerializeField]
		private Shader target;

		[SerializeField]
		private int variantHash;

		[SerializeField]
		private int projectHash;

		[SerializeField]
		private List<ShaderVariant> variants;

		public string Title
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Shader Target
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int VariantHash
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int ProjectHash
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public List<ShaderVariant> Variants => null;

		public bool Dirty => false;

		public static int GetProjectHash()
		{
			return 0;
		}

		public static Pipeline DetectProjectPipeline()
		{
			return default(Pipeline);
		}

		public static bool IsStandard(Pipeline pipe)
		{
			return false;
		}

		public static bool IsScriptable(Pipeline pipe)
		{
			return false;
		}

		public static bool IsURP(Pipeline pipe)
		{
			return false;
		}

		public static bool IsHDRP(Pipeline pipe)
		{
			return false;
		}
	}
}
