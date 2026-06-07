using TMPro;
using UnityEngine;

namespace VampireSurvivors.App.Graphics
{
	public class GenericShadowText : MonoBehaviour
	{
		[SerializeField]
		private TextMeshPro _Text;

		[SerializeField]
		private TextMeshPro _ShadowText;

		public TextMeshPro Text => null;

		public TextMeshPro ShadowText => null;

		public void SetText(string text)
		{
		}

		public void SetShadowEnabled(bool value)
		{
		}

		public void SetTextColor(Color col)
		{
		}

		public void SetShadowColor(Color col)
		{
		}

		public void ForceTextUpdates()
		{
		}

		public void SetDepth(int depth)
		{
		}

		public void SetAlpha(float alpha)
		{
		}
	}
}
