using UnityEngine;

namespace MPUIKIT
{
	internal class MPImageUtility
	{
		private static Sprite _emptySprite;

		internal static Sprite EmptySprite
		{
			get
			{
				if (_emptySprite == null)
				{
					_emptySprite = Resources.Load<Sprite>("mpui_default_empty_sprite");
				}
				return _emptySprite;
			}
		}

		internal static void FixAdditionalShaderChannelsInCanvas(Canvas canvas)
		{
			if (!(canvas == null))
			{
				AdditionalCanvasShaderChannels additionalShaderChannels = canvas.additionalShaderChannels;
				additionalShaderChannels |= AdditionalCanvasShaderChannels.TexCoord1;
				additionalShaderChannels |= AdditionalCanvasShaderChannels.TexCoord2;
				additionalShaderChannels |= AdditionalCanvasShaderChannels.TexCoord3;
				additionalShaderChannels |= AdditionalCanvasShaderChannels.Normal;
				additionalShaderChannels |= AdditionalCanvasShaderChannels.Tangent;
				canvas.additionalShaderChannels = additionalShaderChannels;
			}
		}

		internal static Vector2 Encode_0_1_16(Vector4 input)
		{
			float num = 0.99609375f;
			float num2 = 65535f;
			float num3 = num2 * num2;
			float num4 = num2 - 1f;
			Vector4 vector = input * num * num4;
			float x = Mathf.Floor(vector.x) / num2 + Mathf.Floor(vector.y) / num3;
			float y = Mathf.Floor(vector.z) / num2 + Mathf.Floor(vector.w) / num3;
			return new Vector2(x, y);
		}
	}
}
