using Rhizomatic.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GRP
{
	public class SignalVisual : MonoBehaviour
	{
		public SignalVisualConfig config;

		public Renderer renderer;

		public TextAdapter keyText;

		public SpriteRenderer keySprite;

		private MaterialPropertyBlock channelMaterialBlock;

		private MaterialPropertyBlock valueMaterialBlock;

		public void Setup(Channel channel, Key key)
		{
		}

		public void SetValue(float value)
		{
		}

		public static Sprite KeyToSprite(SignalVisualConfig config, Key key)
		{
			return null;
		}

		public static string KeyToText(Key key)
		{
			return null;
		}
	}
}
