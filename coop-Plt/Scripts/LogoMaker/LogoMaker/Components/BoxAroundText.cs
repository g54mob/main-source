using Shapes;
using TMPro;
using UnityEngine;

namespace LogoMaker.Components
{
	public class BoxAroundText : MonoBehaviour
	{
		public void Run(TextMeshPro text, Rectangle rectangle, float expansion = 0.5f)
		{
			text.ForceMeshUpdate();
			Bounds bounds = new Bounds(text.textInfo.characterInfo[0].topLeft, Vector3.zero);
			TMP_CharacterInfo[] characterInfo = text.textInfo.characterInfo;
			for (int i = 0; i < characterInfo.Length; i++)
			{
				TMP_CharacterInfo tMP_CharacterInfo = characterInfo[i];
				if (tMP_CharacterInfo.isVisible)
				{
					bounds.Encapsulate(tMP_CharacterInfo.topLeft);
					bounds.Encapsulate(tMP_CharacterInfo.topRight);
					bounds.Encapsulate(tMP_CharacterInfo.bottomLeft);
					bounds.Encapsulate(tMP_CharacterInfo.bottomRight);
				}
			}
			bounds.Expand(expansion);
			rectangle.Width = bounds.size.x;
			rectangle.Height = bounds.size.y;
			Vector3 vector = bounds.center + text.transform.localPosition;
			rectangle.transform.localPosition = new Vector3(vector.x, vector.y, 1f);
			rectangle.transform.localScale = text.transform.localScale;
			Color.RGBToHSV(new Color(0.85f, 0.62f, 0.55f), out var _, out var S, out var V);
			rectangle.Color = Color.HSVToRGB(Random.Range(0f, 1f), S, V);
			SetCorners(rectangle);
		}

		private void SetCorners(Rectangle rectangle)
		{
			rectangle.CornerRadiii = new Vector4(corner(), corner(), corner(), corner());
			static float corner()
			{
				float value = Random.value;
				if (value < 0.25f)
				{
					return 0f;
				}
				if (value < 0.75f)
				{
					return 0.25f;
				}
				return 2f;
			}
		}
	}
}
