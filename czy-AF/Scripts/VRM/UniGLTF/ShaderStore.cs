using UnityEngine;

namespace UniGLTF
{
	public class ShaderStore : IShaderStore
	{
		private readonly string m_defaultShaderName = "Standard";

		private Shader m_default;

		private Shader m_vcolor;

		private Shader m_uniUnlit;

		private Shader m_unlitTexture;

		private Shader m_unlitColor;

		private Shader m_unlitTransparent;

		private Shader m_unlitCutout;

		private Shader Default
		{
			get
			{
				if (m_default == null)
				{
					m_default = Shader.Find(m_defaultShaderName);
				}
				return m_default;
			}
		}

		private Shader VColor
		{
			get
			{
				if (m_vcolor == null)
				{
					m_vcolor = Shader.Find("UniGLTF/StandardVColor");
				}
				return m_vcolor;
			}
		}

		private Shader UniUnlit
		{
			get
			{
				if (m_uniUnlit == null)
				{
					m_uniUnlit = Shader.Find("UniGLTF/UniUnlit");
				}
				return m_uniUnlit;
			}
		}

		private Shader UnlitTexture
		{
			get
			{
				if (m_unlitTexture == null)
				{
					m_unlitTexture = Shader.Find("Unlit/Texture");
				}
				return m_unlitTexture;
			}
		}

		private Shader UnlitColor
		{
			get
			{
				if (m_unlitColor == null)
				{
					m_unlitColor = Shader.Find("Unlit/Color");
				}
				return m_unlitColor;
			}
		}

		private Shader UnlitTransparent
		{
			get
			{
				if (m_unlitTransparent == null)
				{
					m_unlitTransparent = Shader.Find("Unlit/Transparent");
				}
				return m_unlitTransparent;
			}
		}

		private Shader UnlitCutout
		{
			get
			{
				if (m_unlitCutout == null)
				{
					m_unlitCutout = Shader.Find("Unlit/Transparent Cutout");
				}
				return m_unlitCutout;
			}
		}

		public ShaderStore(ImporterContext _)
		{
		}

		public static bool IsWhite(float[] color)
		{
			if (color == null)
			{
				return false;
			}
			if (color.Length != 4)
			{
				return false;
			}
			if (color[0] != 1f || color[1] != 1f || color[2] != 1f || color[3] != 1f)
			{
				return false;
			}
			return true;
		}

		public Shader GetShader(glTFMaterial material)
		{
			if (material == null)
			{
				return Default;
			}
			if (material.extensions != null && material.extensions.KHR_materials_unlit != null)
			{
				return UniUnlit;
			}
			return Default;
		}
	}
}
