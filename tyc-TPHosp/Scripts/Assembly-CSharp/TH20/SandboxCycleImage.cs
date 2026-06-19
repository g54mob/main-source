using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SandboxCycleImage : MonoBehaviour
	{
		[SerializeField]
		private Image Image;

		[SerializeField]
		private TMP_Text Text;

		[SerializeField]
		private CanvasGroup CanvasGroup;

		[SerializeField]
		private float ZeroAlphaAtScale = 0.5f;

		public void LateUpdate()
		{
			if (CanvasGroup != null)
			{
				float value = Mathf.Lerp(0f - ZeroAlphaAtScale, 1f, base.transform.localScale.x);
				CanvasGroup.alpha = Mathf.Clamp01(value);
			}
		}

		public void SetImage(Sprite sprite)
		{
			Image.sprite = sprite;
		}

		public void SetImage(Texture2D texture)
		{
			SetImage(Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), Vector2.zero));
		}

		public void SetTitle(string title)
		{
			if (Text != null)
			{
				Text.text = title;
			}
		}
	}
}
