using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Terrain.Rendering.Misc
{
	public class CameraShadowFadeScript : MonoBehaviour
	{
		[SerializeField]
		private bool _enabled;

		private Shader _modifiedShader;

		private Shader _originalScreenSpaceShadowShader;

		public bool Enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				_enabled = value;
			}
		}

		private void Awake()
		{
			_modifiedShader = Object.Instantiate(Resources.Load<Shader>("AtmosphereTest/Shaders/NoShadowFadeScreenSpaceShadows"));
		}

		private void OnPostRender()
		{
			if (Enabled)
			{
				GraphicsSettings.SetCustomShader(BuiltinShaderType.ScreenSpaceShadows, _originalScreenSpaceShadowShader);
			}
		}

		private void OnPreRender()
		{
			if (Enabled)
			{
				_originalScreenSpaceShadowShader = GraphicsSettings.GetCustomShader(BuiltinShaderType.ScreenSpaceShadows);
				GraphicsSettings.SetCustomShader(BuiltinShaderType.ScreenSpaceShadows, _modifiedShader);
			}
		}
	}
}
